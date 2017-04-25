using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlesPersonalizados.GridFiltrado.Elementos_Grid
{
    public class ColumnasFormuladas : IList<ColumnaFormulada>
    {
        #region vars
        private List<ColumnaFormulada> lista;
        #endregion
        #region ctor
        public ColumnasFormuladas()
        {
            lista = new List<ColumnaFormulada>();
        }
        #endregion
        public ColumnaFormulada this[int index]
        {
            get
            {
                return lista[index];
            }

            set
            {
                lista[index]=value;
            }
        }

        public ColumnaFormulada this[string nombre_columnas]
        {
            get
            {
                return lista.FirstOrDefault(x=>x.Nombre_Columna == nombre_columnas);
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

        public void Add(ColumnaFormulada item)
        {
            lista.Add(item);
        }

        public void Clear()
        {
            lista.Clear();
        }

        public bool Contains(ColumnaFormulada item)
        {
            return lista.Contains(item);
        }

        public void CopyTo(ColumnaFormulada[] array, int arrayIndex)
        {
            lista.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ColumnaFormulada> GetEnumerator()
        {
            return lista.GetEnumerator();
        }

        public int IndexOf(ColumnaFormulada item)
        {
            return lista.IndexOf(item);
        }

        public void Insert(int index, ColumnaFormulada item)
        {
            lista.Insert(index,item);
        }

        public bool Remove(ColumnaFormulada item)
        {
            return lista.Remove(item);
        }

        public void RemoveAt(int index)
        {
            lista.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return lista.GetEnumerator();
        }
    }
}
