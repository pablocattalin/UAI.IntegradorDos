using System.Collections.Generic;
using System;
using UAI.IntegradorDos.Modelos;
using System.Linq;
using System.Text.RegularExpressions;

namespace UAI.IntegradorDos.Logica
{
    public class AccionLogica : LogicaBase<Accion>
    {
        public List<Accion> _acciones;
        

        public EventHandler<CambioCotizacionEventArgs> _subscribe { get; private set; }

        public AccionLogica(EventHandler<CambioCotizacionEventArgs> subscribe)
        {
            _acciones = new List<Accion>();
            _subscribe = subscribe;
        }


        public Accion Agregar(Accion pAccion)
        {
            var regex = new Regex(@"^[A-Z]{4}[-]{1}[0-9]{4}[-]{1}[A-Z]{1}[0-9]{1}[A-Z]{1}[0-9]{1}");
            if (!regex.IsMatch(pAccion.Codigo))
            {
                throw new Exception("El codigo requiere que sean 4 letras - 4 numeros - Primera y tercera posicion letra y segunda y cuarta posicion numero");
            }
            Insertar(_acciones, pAccion);            
            return (Accion)pAccion.Clone();
        }

        public Accion DevolverPorCodigo(Accion Accion)
        {
            return Buscar(_acciones, p => p.Codigo == Accion.Codigo);
        }

        public Accion Eliminar(Accion Accion)
        {
            try
            {
                var accionBuscado = Buscar(_acciones, p => p.Codigo == Accion.Codigo);
                if (accionBuscado.InversionesInvolucradas.Count > 0 )
                {
                    throw new ApplicationException("No se pueden eliminar acciones que han sido compradas y estan en la cartera de accionistas");
                }
                Remover(_acciones, accionBuscado);
                return Accion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public List<Accion> DevolverTodasAccionesCompradas()
        {
            return (from accion in _acciones 
                    where accion.InversionesInvolucradas.Count > 0
                    select new Accion
                    {
                        CotizacionActual = accion.CotizacionActual,
                        CantidadEmitida = accion.InversionesInvolucradas.Sum(a => a.Cantidad),
                        Codigo = accion.Codigo,
                        Denominacion = accion.Denominacion,                        
                    }).ToList();
        }

        public override void Actualizar(Accion pAccion, Accion modeloActual = null)
        {
            try
            {
                var accionBuscada = Buscar(_acciones, p => p.Codigo == pAccion.Codigo);
                var acciones = DevolverTodasAccionesCompradas();
                if (acciones.Where(a => a.Codigo == pAccion.Codigo).Sum(a => a.CantidadEmitida) > pAccion.CantidadEmitida)
                {
                    throw new ApplicationException("La cantidad ingresada no puede ser menor a la cantidad que estan compradas");
                }                                    
                accionBuscada.CotizacionActual = pAccion.CotizacionActual;
                accionBuscada.CantidadEmitida = pAccion.CantidadEmitida;
                accionBuscada.Denominacion = pAccion.Denominacion;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

      

        public void CargarInversionista(Accion pAccion, Inversion inversion)
        {
            var accionBuscada = Buscar(_acciones, p => p.Codigo == pAccion.Codigo);
            if (accionBuscada.InversionesInvolucradas.Any(a => a.Legajo == inversion.Legajo))
            {
                var inversionCargada = accionBuscada.InversionesInvolucradas.Find(a => a.Legajo == inversion.Legajo);
                inversionCargada.Cantidad = inversion.Cantidad;
            } 
            else
            {
                var inversionClon = (Inversion)inversion.Clone();
                inversionClon.Accion = null;
                inversion.Inversor = null;
                accionBuscada.InversionesInvolucradas.Add(inversionClon);
            }
            accionBuscada.CambioCotizacion += _subscribe;            
        }
        

        public void ModificarInversionista(Accion pAccion, Inversion inversion)
        {
            var accionBuscada = Buscar(_acciones, p => p.Codigo == pAccion.Codigo);            
            var inversionCargada = accionBuscada.InversionesInvolucradas.Find(a => a.Legajo == inversion.Legajo);
            if (inversion.Cantidad == 0)
            {
                accionBuscada.InversionesInvolucradas.Remove(inversionCargada);
            }   
            else
            {
                inversionCargada.Cantidad = inversion.Cantidad;
            }            
            if (accionBuscada.InversionesInvolucradas.Count == 0)
                accionBuscada.CambioCotizacion -= _subscribe;
        }

        public List<Accion> DevolverTodos()
        {
            var list = (from a in _acciones 
                    select new Accion { CotizacionActual = a.CotizacionActual, 
                        CantidadEmitida = a.CantidadEmitida,
                        Codigo = a.Codigo,
                        Denominacion = a.Denominacion,                        
                    }).ToList();
            list.Sort(new Accion.OrdenCodigoDesc());
            return list;
        }

        public string ConvertirCodigo(string codigo)
        {            
            var chArr = codigo.ToCharArray();
            string res = "";
            for (int i = 0; i < chArr.Length; i++)
            {
                if (i == 4 || i == 8)
                    res += "-" + chArr[i];
                else
                    res += chArr[i];
            }
            return res;
        }
    }
}
