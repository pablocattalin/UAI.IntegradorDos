using System;
using System.Collections.Generic;
using System.Linq;
using UAI.IntegradorDos.Modelos;

namespace UAI.IntegradorDos.Logica
{
    public class InversorLogica: LogicaBase<Inversor>
    {
        public List<Inversor> _inversores;
        private AccionLogica _accionLogica;
        private InversionLogica _inversionLogica;
        private ComisionLogica _comisionLogica;
        public InversorLogica(AccionLogica accionLogica, ComisionLogica comisionLogica)
        {
            _inversores = new List<Inversor>();
            _accionLogica = accionLogica;
            _inversionLogica = new InversionLogica();
            _comisionLogica = comisionLogica;
        }
        

        public override void Actualizar(Inversor pInversor , Inversor modeloActual = null)
        {
            var inversorBuscado = Buscar(_inversores, p => p.Legajo == pInversor.Legajo);
            inversorBuscado.Saldo = pInversor.Saldo;
            inversorBuscado.Legajo = pInversor.Legajo;
            inversorBuscado.Nombre = pInversor.Nombre;
            inversorBuscado.Apellido = pInversor.Apellido;
        }

        public Inversor Agregar(Inversor inversor)
        {
            try
            {
                var inversorBuscado = Buscar(_inversores, p => p.Dni == inversor.Dni);
                if (inversorBuscado != null) throw new ApplicationException("El dni fue cargado");
                inversor.Legajo = _inversores.Count == 0 ? 1 : _inversores.Max(a => a.Legajo) + 1;                 
                Insertar(_inversores, inversor);
                return (Inversor)inversor.Clone();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Inversor DevolverPorLegajo(Inversor inversor)
        {
            var inversorBuscado =  Buscar(_inversores, p => p.Legajo == inversor.Legajo);
            return inversorBuscado != null ? (Inversor)inversorBuscado.Clone() : inversorBuscado;
        }

        public List<Inversor> DevolverTodos()
        {
            var list = (from inversor in _inversores select inversor).ToList();
            list.Sort(new Inversor.Ordenamiento());
            return list;
        }
        

        public Inversor Eliminar(Inversor inversor)
        {
            try
            {
                var inversorBuscado = Buscar(_inversores, p => p.Legajo == inversor.Legajo);
                if (inversorBuscado.Inversiones.Count > 0) throw new ApplicationException("El inversor tiene acciones compradas, no debe poseer acciones para poder ser eliminado");
                if (inversorBuscado.Saldo != 0) throw new ApplicationException("El saldo debe ser igual a cero para poder ser eliminado");
                Remover(_inversores, inversorBuscado);
                return inversor;
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Comprar(Inversor pInversor, Accion pAccion)
        {
            try
            {
                var accionistas = DevolverTodos();
                var accionesCompradas = _accionLogica.DevolverTodasAccionesCompradas();
                var accionBuscada = _accionLogica.DevolverPorCodigo(pAccion);
                if ((accionesCompradas.Where(a => a.Codigo == pAccion.Codigo).Sum(a => a.CantidadEmitida) + pAccion.CantidadEmitida) > accionBuscada.CantidadEmitida)
                {
                    throw new ApplicationException("No se puede realizar la operacion, se supera la cantidad de acciones disponbiles");
                }
                var inversor = Buscar(_inversores, p => p.Legajo == pInversor.Legajo);
                var importeOperacion = inversor.Operar(accionBuscada.DevolverImporteOperacion(pAccion.CantidadEmitida));                
                _comisionLogica.Calcular(inversor, accionBuscada.DevolverImporteOperacion(pAccion.CantidadEmitida));
                if (importeOperacion > inversor.Saldo)
                {
                    throw new ApplicationException("No contas con el importe suficiente para realizar la operacion");
                }
                var inversion = _inversionLogica.Agregar(inversor.Inversiones, new Inversion
                {
                    Accion = new Accion
                    {
                        CotizacionActual = accionBuscada.CotizacionActual,
                        CantidadEmitida = accionBuscada.CantidadEmitida,
                        Codigo = accionBuscada.Codigo,
                        Denominacion = accionBuscada.Denominacion
                    },
                    Cantidad = pAccion.CantidadEmitida,
                    Codigo = accionBuscada.Codigo,
                    Legajo = pInversor.Legajo
                });
                pInversor.Saldo -= importeOperacion;
                Actualizar(pInversor);
                _accionLogica.CargarInversionista(accionBuscada, inversion);                
                
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void Vender(Inversor pInversor, Accion pAccion)
        {
            try
            {
                var accionBuscada = _accionLogica.DevolverPorCodigo(pAccion);
                var inversor = Buscar(_inversores, p => p.Legajo == pInversor.Legajo);
                if (pAccion.CantidadEmitida > inversor.Inversiones.Where(a => a.Codigo == accionBuscada.Codigo).Sum(a => a.Cantidad))
                {
                    throw new ApplicationException("No se pueden vender mas cantitades de las que tiene en la cartera");
                }
                var importeOperacion = inversor.Operar(accionBuscada.DevolverImporteOperacion(pAccion.CantidadEmitida));
                _comisionLogica.Calcular(inversor, accionBuscada.DevolverImporteOperacion(pAccion.CantidadEmitida));
                var inversion = _inversionLogica.Eliminar(inversor.Inversiones, pAccion);
                _accionLogica.ModificarInversionista(accionBuscada, inversion);
                pInversor.Saldo += importeOperacion;
                Actualizar(pInversor);
            }            
            catch(Exception ex)
            {
                throw ex;
            }
        }      
    }
}
