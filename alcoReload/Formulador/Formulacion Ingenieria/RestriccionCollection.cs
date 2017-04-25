using System;
using System.Collections;
using System.Collections.Generic;
namespace Formulador
{
    public class RestriccionCollection : IList<Restriccion>
    {
        #region Variables
        internal List<Restriccion> listarestricciones;
        internal Parametro owner = null;
        #endregion
        #region Constructor
        public RestriccionCollection() { this.listarestricciones = new List<Restriccion>(); }
        public RestriccionCollection(Parametro owner) { this.owner = owner; this.listarestricciones = new List<Restriccion>(); }
        #endregion
        #region Propiedades
        public Restriccion this[int index]
        {
            get
            {
                return listarestricciones[index];
            }

            set
            {
                listarestricciones[index] = value;
            }
        }

        public Restriccion this[string nombre]
        {
            get
            {
                return listarestricciones.Find(x => x.Nombre == nombre);  
            }
            set
            {
                for (int i = 0; i < listarestricciones.Count; i++)
                {
                    if (listarestricciones[i].Nombre.Equals(nombre))
                    {
                        listarestricciones[i] = value;
                    }
                }
            }
        }

        public int Count
        {
            get
            {
                return listarestricciones.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false; ;
            }
        }
        #endregion



        public void Add(Restriccion item)
        {
            listarestricciones.Add(item);
        }

        public void Clear()
        {
            listarestricciones.Clear();
        }

        public bool Contains(Restriccion item)
        {
           return listarestricciones.Contains(item);
        }

        public bool Contains(string nombre)
        {
            return listarestricciones.Exists(x => x.Nombre == nombre);                        
        }

        public void CopyTo(Restriccion[] array, int arrayIndex)
        {
            listarestricciones.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Restriccion> GetEnumerator()
        {
            return listarestricciones.GetEnumerator();
        }

        public int IndexOf(Restriccion item)
        {
            return listarestricciones.IndexOf(item);
        }

        public void Insert(int index, Restriccion item)
        {
            listarestricciones.Insert(index, item);
        }

        public bool Remove(Restriccion item)
        {
            return listarestricciones.Remove(item);
        }

        public void RemoveAt(int index)
        {
            listarestricciones.RemoveAt(index) ;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
