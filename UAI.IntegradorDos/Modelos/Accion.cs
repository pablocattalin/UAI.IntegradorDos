using System;
using System.Collections;
using System.Collections.Generic;

namespace UAI.IntegradorDos.Modelos
{
    public class Accion: ICloneable, IDisposable, IEnumerable
    {
        public Accion()
        {
            InversionesInvolucradas = new List<Inversion>();
        }
        public string Codigo { get; set; }
        public string Denominacion { get; set; }
        private decimal _cotizacionActual;
        public decimal CotizacionActual { get
            {
                return _cotizacionActual;
            } 
            set
            {                
                if (_cotizacionActual != value)
                {
                    _cotizacionActual = value;
                    CambioCotizacion?.Invoke(this, new CambioCotizacionEventArgs(value));
                };
            }
        }
        public double CantidadEmitida { get; set; }
        public event EventHandler<CambioCotizacionEventArgs> CambioCotizacion;
        public List<Inversion> InversionesInvolucradas { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        

        public decimal DevolverImporteOperacion(double cantidadEmitida)
        {
            return CotizacionActual * (decimal)cantidadEmitida;
        }

        public void Dispose() { }
        
        public IEnumerator GetEnumerator()
        {
            return new AccionCodigo(this);
        }

        public class OrdenCodigoDesc: IComparer<Accion>
        {
            public int Compare(Accion x, Accion y)
            {
                return string.Compare(x.Codigo, y.Codigo) * -1;
            }
        }        
    }
}
