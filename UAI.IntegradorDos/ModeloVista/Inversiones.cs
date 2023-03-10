using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAI.IntegradorDos.ModeloVista
{
    public class Inversiones
    {
        public string Codigo { get; set; }
        public string Denominacion { get; set; }
        public decimal CotizacionActual { get; set; }
        public double Cantidad { get; set; }
        public decimal InversionTotal { get; set; }
    }
}