using System;

namespace UAI.IntegradorDos.Modelos
{
    public class Inversion: ICloneable, IDisposable
    {
        public string Codigo { get; set; }
        public long Legajo { get; set; }
        public double Cantidad { get; set; }        
        public Inversor Inversor { get; set; }
        public Accion Accion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Dispose()
        {
            
        }
    }
}
