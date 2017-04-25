using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ControlesPersonalizados.GridFiltrado.Elementos_Grid
{
    public class Grupos : IList<Grupo>
    {
        #region vars
        private List<Grupo> lista;
        #endregion
        #region ctor
        public Grupos()
        { lista = new List<Grupo>(); }
        #endregion
        public Grupo this[int index]
        {
            get
            {
                return lista[index];
            }

            set
            {
                lista[index] = value;
            }
        }

        public Grupo this[string nombre_columna]
        {
            get
            {
                return lista.FirstOrDefault(x=> x.Nombre_Columna == nombre_columna);
            }
        }

        public int Count
        {
            get
            {
                return lista.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
               return false;
            }
        }

        public void Add(Grupo item)
        {
           lista.Add(item);
        }

        public void Clear()
        {
            lista.Clear();
        }

        public bool Contains(Grupo item)
        {
            return lista.Contains(item);
        }

        public void CopyTo(Grupo[] array, int arrayIndex)
        {
            lista.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Grupo> GetEnumerator()
        {
            return lista.GetEnumerator();
        }

        public int IndexOf(Grupo item)
        {
            return lista.IndexOf(item);
        }

        public void Insert(int index, Grupo item)
        {
            lista.Insert(index, item);
        }

        public bool Remove(Grupo item)
        {
            return lista.Remove(item);
        }

        public void RemoveAt(int index)
        {
            lista.RemoveAt(index);
        }

        public void RemoveAt(string nombre_columna)
        {
            Grupo grupo = lista.FirstOrDefault(x => x.Nombre_Columna == nombre_columna);
            if (grupo != null) { Remove(grupo); }            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return lista.GetEnumerator();
        }
    }
}
