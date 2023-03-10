using UAI.IntegradorDos.Logica;
using UAI.IntegradorDos.Parametros;

namespace UAI.IntegradorDos.Modelos
{
    public class InversorPremium : Inversor
    {
        public override decimal Operar(decimal importeOperacion)
        {
            decimal totalOperacion;
            if (importeOperacion > (int)EComisiones.IMPORTE_REDUCE_COMISION)
            {
                importeOperacion -= (decimal)EComisiones.IMPORTE_REDUCE_COMISION;
                totalOperacion = importeOperacion + ComisionPremium(importeOperacion);
                totalOperacion += base.Operar((decimal)EComisiones.IMPORTE_REDUCE_COMISION);
            }
            else
            {
                totalOperacion = base.Operar(importeOperacion);
            }            
            return totalOperacion;        
        }

        public decimal ComisionPremium(decimal importeOperacion)
        {
            return (importeOperacion * (((decimal)EComisiones.COMISION - 0.5M) / 100));
        }
       
    }
}
