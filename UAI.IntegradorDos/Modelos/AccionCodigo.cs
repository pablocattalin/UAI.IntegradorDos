using System.Collections;
using System.Linq;

namespace UAI.IntegradorDos.Modelos
{
    public class AccionCodigo : IEnumerator
    {
        public string _current = "";
        int len = 0;
        private Accion _accion;
        public AccionCodigo(Accion accion)
        {            
            _accion = accion;            
        }

        object IEnumerator.Current => _current;

        public bool MoveNext()
        {
            if (len != _accion.Codigo.Length)
            {
                if (_accion.Codigo[len] != '-')
                {
                    _current += _accion.Codigo[len];
                }

            }
            len++;
            bool sigue = len <= _accion.Codigo.Length;            
            if (!sigue)
                Reset();                  
            return sigue;
        }

        public void Reset()
        {
            len = 0;
            _current = "";
        }
    }
}