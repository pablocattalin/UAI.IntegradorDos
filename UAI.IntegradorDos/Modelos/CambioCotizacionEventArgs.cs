namespace UAI.IntegradorDos.Modelos
{
    public class CambioCotizacionEventArgs
    {
        decimal _cotizacionActual;
        public CambioCotizacionEventArgs(decimal cotizacionActual)
        {
            _cotizacionActual = cotizacionActual;
        }
        public decimal CotizacionActual { get { return _cotizacionActual; } }

    }
}
