using System;
using UAI.IntegradorDos.Modelos;
using UAI.IntegradorDos.Parametros;

namespace UAI.IntegradorDos.Logica
{
    public class ComisionLogica
    {
        public Comision _comision;
        public ComisionLogica()
        {
            _comision = new Comision();
        }

        public void Calcular(InversorPremium inversor, decimal importeOperacion)
        {
            _comision.ComisionPremium += inversor.ComisionPremium(importeOperacion - (decimal)EComisiones.IMPORTE_REDUCE_COMISION);            
            _comision.ComisionComunPremium += inversor.DevolverComision((decimal)EComisiones.IMPORTE_REDUCE_COMISION);
            _comision.TotalComisiones = _comision.ComisionPremium + _comision.ComisionComun + _comision.ComisionComunPremium;
        }

        public void Calcular(Inversor inversor, decimal importeOperacion)
        {
            if (inversor is InversorPremium && (decimal)EComisiones.IMPORTE_REDUCE_COMISION < importeOperacion) {
                Calcular(inversor as InversorPremium, importeOperacion);
            } 
            else
            {
                _comision.ComisionComun += inversor.DevolverComision(importeOperacion);
                _comision.TotalComisiones += inversor.DevolverComision(importeOperacion);
            }
        }

        public Comision Devolver()
        {
            return (Comision)_comision.Clone();
        }

    }
}
