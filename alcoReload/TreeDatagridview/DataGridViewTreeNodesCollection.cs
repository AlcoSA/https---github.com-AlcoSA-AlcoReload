using System;
using System.Collections.Generic;

namespace DatagridTreeView
{
    public class DataGridViewTreeNodesCollection : System.Collections.Generic.IList<DataGridViewTreeNode>
    {
        #region Variables

        internal System.Collections.Generic.List<DataGridViewTreeNode> nodes;
		internal DataGridViewTreeNode owner;

        #endregion

        #region Constructor
        internal DataGridViewTreeNodesCollection(DataGridViewTreeNode owner)
		{            
			this.owner = owner;
			this.nodes = new List<DataGridViewTreeNode>();
        }
        #endregion

        #region Propiedades
        public int Count
        {
            get { return nodes.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public DataGridViewTreeNode this[int index]
        {
            get
            {
                return this.nodes[index];
            }
            set
            {
                this.nodes[index] = value;
            }
        }
        #endregion

        //Este procedimiento recibe los parámetros necesarios para el nuevo registro
        public void Add(DataGridViewTreeNode item)
		{
            item.grid = this.owner.grid;
            nodes.Add(item);
            owner.AddChildNode(item);
            if (!owner.HasChildren && this.owner.IsSited)
            {
                this.owner.grid.InvalidateRow(this.owner.RowIndex);
            }            
        }
        //Este procedimiento agrega el nodo en el que quedará el registro
        //Este procedimiento agrega verifica que la cantidad de elementos en la matriz de valores, 
        //no sea mayor a la cantidad de elementos en la matriz de nodos
        public DataGridViewTreeNode Add(params object[] values)
        {
            if (values.Length > owner.Cells.Count && owner.index >=0)
                throw new ArgumentOutOfRangeException("El numero de datos es mayor a la cantidad de columnas");
            DataGridViewTreeNode node = new DataGridViewTreeNode();
            Add(node);
            for (int i = 0; i < values.Length; i++)
            {
                node.Cells[i].Value = values[i];
            }
            return node;
        }
        //Este procedimiento ingresa el nuevo elemento en los nodos generados
        public void Insert(int index, DataGridViewTreeNode item)
        {
            item.grid = this.owner.grid;
            this.nodes.Insert(index, item);
            this.owner.InsertChildNode(index, item);
        }
        //Este procedimiento sirve para eliminar elementos de los nodos
        public bool Remove(DataGridViewTreeNode item)
		{
            owner.RemoveChildNode(item);
            return nodes.Remove(item);
		}
        //Este procedimiento sirve para eliminar un elemento indicando el nodo
        public void RemoveAt(int index)
		{
			DataGridViewTreeNode node = this.nodes[index];
			this.owner.RemoveChildNode(node);
			this.nodes.RemoveAt(index);
		}
        //Este procedimiento sirve para limpiar todos los registros de un nodo
        public void Clear()
		{
            owner.ClearNodes();
            this.nodes.Clear();
        }

        public int IndexOf(DataGridViewTreeNode item)
        {
            return this.nodes.IndexOf(item);
        }		

		public bool Contains(DataGridViewTreeNode item)
		{
			return this.nodes.Contains(item);
		}

		public void CopyTo(DataGridViewTreeNode[] array, int arrayIndex)
		{
            nodes.CopyTo(array, arrayIndex);			
		}

		public IEnumerator<DataGridViewTreeNode> GetEnumerator()
		{
			return nodes.GetEnumerator();
		}

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
