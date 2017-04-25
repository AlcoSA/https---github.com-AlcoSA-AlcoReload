using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formulador
{
    public class Descuentos : System.Collections.Generic.IList<Descuento>
    {
        #region Variables
        private Objeto owner;
        private List<Descuento> descuentos;
        
        #endregion
        #region Constructor
        public Descuentos(Objeto owner)
        { this.owner = owner;
            descuentos = new List<Descuento>();
        }
        public Descuentos()
        {
            descuentos = new List<Descuento>();
        }
        #endregion
        public Descuento this[int index]
        {
            get
            {
               return descuentos[index];
            }

            set
            {
                descuentos[index] = value;
            }
        }

        public Descuento this[string nombre]
        {
            get
            {
                for (int i = 0; i < descuentos.Count; i++)
                {
                    if (descuentos[i].nombre.Equals(nombre))
                    {
                        return descuentos[i];
                    }
                }
                return null;
            }
        }

        public int Count
        {
            get
            {
                return descuentos.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(Descuento item)
        {
            item.owner = this;
            descuentos.Add(item);
        }

        public void Clear()
        {            
            descuentos.Clear();
            //Descuento item = new Descuento(1, "DESCUENTO", 0, string.Empty);
            //item.calculado = true;
            //Add(item);
        }

        public bool Contains(Descuento item)
        {
            return descuentos.Contains(item);
        }

        public bool Contains(string nombre)
        {
            for (int i = 0; i < descuentos.Count; i++)
            {
                if (descuentos[i].nombre.Equals(nombre))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(Descuento[] array, int arrayIndex)
        {
            descuentos.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Descuento> GetEnumerator()
        {
            return descuentos.GetEnumerator();
        }

        public int IndexOf(Descuento item)
        {
            return descuentos.IndexOf(item);
        }

        public void Insert(int index, Descuento item)
        {
            item.owner = this;
            descuentos.Insert(index, item);
        }

        public bool Remove(Descuento item)
        {
            return descuentos.Remove(item);
        }

        public void RemoveAt(int index)
        {
            descuentos.RemoveAt(index);
        }

        public decimal Calculado()
        {
            decimal calculo = 0;
            for (int i = 0; i < descuentos.Count; i++)
            {
                if (!descuentos[i].calculado)
                { calculo += descuentos[i].Valor; }                
            }
            return calculo;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return descuentos.GetEnumerator();
        }
    }
}
