using System;
using System.Collections;
using System.Collections.Generic;

namespace Formulador
{
    public class ParametrosCollection : System.Collections.Generic.IList<Parametro>
    {
        #region Variables
        internal List<Parametro> listaparametros;
        internal Objeto owner = null;
        #endregion
        #region Constructor
        public ParametrosCollection() { listaparametros = new List<Parametro>(); }
        public ParametrosCollection(Objeto owner) { this.owner = owner; listaparametros = new List<Parametro>(); }
        #endregion
        #region Propiedades

        public Parametro this[int index]
        {
            get
            {
                return listaparametros[index];
            }

            set
            {
                listaparametros[index] = value;
            }
        }

        public Parametro this[string nombre]
        {
            get
            {                
                return listaparametros.Find(x => x.Nombre == nombre);                
            }
            set
            {
                if (listaparametros.Exists(x => x.Nombre == nombre))
                    listaparametros[listaparametros.FindIndex(x => x.Nombre == nombre)] = value;
            }
        }

        public int Count
        {
            get
            {
                return listaparametros.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        #endregion
        public void Add(Parametro item)
        {
            listaparametros.Add(item);
        }

        public void Clear()
        {
            listaparametros.Clear();
        }

        public bool Contains(Parametro item)
        {
            return listaparametros.Contains(item);
        }
        public bool Contains(string nombre)
        {
            return listaparametros.Exists(x => x.Nombre == nombre);
        }

        public void CopyTo(Parametro[] array, int arrayIndex)
        {
            listaparametros.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Parametro> GetEnumerator()
        {
            return listaparametros.GetEnumerator();
        }

        public int IndexOf(Parametro item)
        {
            return listaparametros.IndexOf(item);
        }

        public void Insert(int index, Parametro item)
        {
            listaparametros.Insert(index, item);
        }

        public bool Remove(Parametro item)
        {
            return listaparametros.Remove(item);
        }

        public void RemoveAt(int index)
        {
            listaparametros.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }
}
