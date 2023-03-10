using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using UAI.IntegradorDos.Logica;
using UAI.IntegradorDos.Parametros;

namespace UAI.IntegradorDos.Modelos
{
    public class Inversor: ICloneable, IDisposable
    {
        public Inversor()
        {
            Inversiones = new List<Inversion>();
        }
        public long Legajo { get; set; }
        public long Dni { get; set; }
        public decimal Saldo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public List<Inversion> Inversiones { get; set; }        

        public object Clone()
        {
            var clon = (Inversor)this.MemberwiseClone();
            clon.Inversiones = clon.Inversiones.Select(a => new Inversion
            {
                Accion = (Accion)a.Accion.Clone(),
                Cantidad = a.Cantidad,
                Codigo = a.Codigo,
                Legajo = a.Legajo
            }).ToList();
            return clon;
        }

        public decimal DevolverTotalInversiones()
        {
            return Inversiones.Sum(a => (decimal)a.Cantidad * a.Accion.CotizacionActual);
        }

        public void Dispose()
        {
            
        }

        public virtual decimal Operar(decimal importeOperacion)
        {
            return importeOperacion + (importeOperacion * ((decimal)EComisiones.COMISION / 100));                        
        }

        public decimal DevolverComision(decimal importeOperacion)
        {
            return (importeOperacion * ((decimal)EComisiones.COMISION / 100));
        }


        public class Ordenamiento : IComparer<Inversor>
        {
            public int Compare(Inversor x, Inversor y)
            {
                return (int)(y.Legajo - x.Legajo);
            }
        }
    }
}
