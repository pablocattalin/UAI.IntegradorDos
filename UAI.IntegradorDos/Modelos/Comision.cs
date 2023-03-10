using System;

namespace UAI.IntegradorDos.Modelos
{
    public class Comision: ICloneable
    {
        public decimal ComisionComun { get; set; }
        public decimal ComisionComunPremium { get; set; }
        public decimal ComisionPremium { get; set; }
        public decimal TotalComisiones { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
