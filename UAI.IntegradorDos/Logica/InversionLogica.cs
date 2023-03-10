using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UAI.IntegradorDos.Modelos;
using UAI.IntegradorDos.ModeloVista;

namespace UAI.IntegradorDos.Logica
{
    public class InversionLogica: LogicaBase<Inversion>
    {        

        public InversionLogica()
        {            
        }

        public override void Actualizar(Inversion modelo, Inversion modeloActual = null)
        {
            modeloActual.Cantidad = modelo.Cantidad;
        }

        public Inversion Agregar(List<Inversion> inversiones, Inversion inversion)
        {
            var inversionBuscada = Buscar(inversiones, p => p.Codigo == inversion.Codigo);
            if (inversionBuscada != null)
            {
                inversionBuscada.Cantidad += inversion.Cantidad;
                Actualizar(inversionBuscada, inversion);                
            }           
            else
            {
                Insertar(inversiones, inversion);
            }
            return inversion;
        }

        public Inversion Eliminar(List<Inversion> inversiones, Accion pAccion)
        {
            var inversionBuscada = Buscar(inversiones, p => p.Codigo == pAccion.Codigo);
            inversionBuscada.Cantidad -= pAccion.CantidadEmitida;
            Actualizar(inversionBuscada, new Inversion { Cantidad = pAccion.CantidadEmitida});            
            if (inversionBuscada.Cantidad == 0)
                Remover(inversiones, inversionBuscada);
            return inversionBuscada;
        }
    }
}
