using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UAI.IntegradorDos.Logica
{
    public abstract class LogicaBase<T> where T: class
    {
        public T Insertar(List<T> lista, T modelo)
        {
            lista.Add(modelo);
            return modelo;
        }

        public T Buscar(List<T> lista, Func<T, bool> criterio)
        {
            return lista.Where(criterio).FirstOrDefault();
        }

        public T Remover(List<T> lista, T modelo)
        {
            lista.Remove(modelo);
            return modelo;
        }

        public abstract void Actualizar(T modelo, T modeloActual = null);        
    }
}
