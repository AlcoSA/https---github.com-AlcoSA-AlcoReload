using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Formulador
{
   public class ObjetosCollection : System.Collections.Generic.IList<Objeto>
    {
        #region Variables
        internal List<Objeto> listaobjetos;
        #endregion

        #region Constructor
        public ObjetosCollection() { listaobjetos = new List<Objeto>(); }
        #endregion

        #region Propiedades
        public Objeto this[int index]
        {
            get
            {
                return listaobjetos[index];
            }

            set
            {
                listaobjetos[index] = value;
            }
        }
        public Objeto this[string nombre]
        {
            get
            {                
                return listaobjetos.Find(x => x.Nombre == nombre);                                
            }

            set
            {
                if (listaobjetos.Exists(x => x.Nombre == nombre))
                    listaobjetos[listaobjetos.FindIndex(x => x.Nombre == nombre)] = value;                
            }
        }

        public Objeto this[string nombre, int index]
        {
            get
            {                
                return listaobjetos.FirstOrDefault(x => x.Nombre == nombre && x.Indice == index);
                
            }
            set
            {
                if (listaobjetos.Exists(x => x.Nombre == nombre && x.Indice == index))
                    listaobjetos[listaobjetos.FindIndex(x => x.Nombre == nombre && x.Indice == index)] = value;
            }
        }

        public int Count
        {
            get
            {
                return listaobjetos.Count;
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

        public int CountbyName(string name)
        {
            return listaobjetos.Where(x => x.Nombre == name).Count();
        }

        public void Add(Objeto item)
        {
          
                listaobjetos.Add(item);
               }

        public void Clear()
        {
            listaobjetos.Clear(); ;
        }

        public bool Contains(Objeto item)
        {
          return  listaobjetos.Contains(item);
        }

        public bool Contains(string name)
        {
            return listaobjetos.Exists(x => x.Nombre == name);            
        }

        public bool Contains(string name, int indice)
        {
            return listaobjetos.Exists(x => x.Nombre == name && x.Indice == indice);            
        }

        public void CopyTo(Objeto[] array, int arrayIndex)
        {
            listaobjetos.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Objeto> GetEnumerator()
        {
            return listaobjetos.GetEnumerator();
        }

        public int IndexOf(Objeto item)
        {
            return listaobjetos.IndexOf(item);
        }

        public void Insert(int index, Objeto item)
        {
            listaobjetos.Insert(index, item);
        }

        public bool Remove(Objeto item)
        {
            for (int i = 0; i < listaobjetos.Count; i++)
            {
                if (listaobjetos[i].Nombre.Equals(item.Nombre) && listaobjetos[i].Indice > item.Indice)
                {
                    listaobjetos[i].Indice--;
                }
            }
            return listaobjetos.Remove(item);
        }

        public void RemoveAt(int index)
        {
            for (int i = 0; i < listaobjetos.Count; i++)
            {
                if (listaobjetos[i].Nombre.Equals(listaobjetos[index].Nombre) && listaobjetos[i].Indice > listaobjetos[index].Indice)
                {
                    listaobjetos[i].Indice--;
                }
            }
            listaobjetos.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        

    }
}
