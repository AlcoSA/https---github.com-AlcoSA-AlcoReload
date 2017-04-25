using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace ControlesPersonalizados.Estructurador
{
    public class ConjuntoEstructural : IList<RegionEstructuras>
    {
        #region Variables
        private RegionEstructuras owner;
        private List<RegionEstructuras> listaestructuras;
        #endregion

        #region Constructor
        public ConjuntoEstructural(RegionEstructuras owner)
        {
            this.owner = owner;
            listaestructuras = new List<RegionEstructuras>();
        }
        #endregion

        public RegionEstructuras this[int index]
        {
            get
            {
                return listaestructuras[index];
            }

            set
            {
                listaestructuras[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return listaestructuras.Count();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(RegionEstructuras item)
        {
            if (!string.IsNullOrEmpty(owner.Estructura))
            {
                item.Estructura = owner.Estructura;                
            }
            if (owner.Owner == null)
            {
                item.Contenedor_General = owner;
            }
            else
            {
                item.Contenedor_General = owner.Contenedor_General;
            }            
            item.Owner = owner;
            item.RegionControlContenedor = owner.RegionControlContenedor;
            item.Desfase = owner.Desfase;
            item.Nivel = owner.Nivel + 1;
            listaestructuras.Add(item);
        }

        public void Clear()
        {
            listaestructuras.Clear();
        }

        public bool Contains(RegionEstructuras item)
        {
            return listaestructuras.Contains(item);
        }

        public void CopyTo(RegionEstructuras[] array, int arrayIndex)
        {
            listaestructuras.CopyTo(array, arrayIndex);
        }

        public IEnumerator<RegionEstructuras> GetEnumerator()
        {
           return listaestructuras.GetEnumerator();
        }

        public int IndexOf(RegionEstructuras item)
        {
            return listaestructuras.IndexOf(item);
        }

        public void Insert(int index, RegionEstructuras item)
        {
            item.Nivel = owner.Nivel + 1;
            listaestructuras.Insert(index, item);
        }

        public bool Remove(RegionEstructuras item)
        {
            return listaestructuras.Remove(item);
        }

        public void RemoveAt(int index)
        {
            listaestructuras.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return listaestructuras.AsEnumerable().GetEnumerator();
        }


    }
}
