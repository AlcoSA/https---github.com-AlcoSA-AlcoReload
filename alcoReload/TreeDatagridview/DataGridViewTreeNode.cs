using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Text;

namespace DatagridTreeView
{
    [
		ToolboxItem(false),
		DesignTimeVisible(true)
	]
    public class DataGridViewTreeNode : DataGridViewRow
    {
        #region Variables
        internal DataTreeGridView grid;
		internal DataGridViewTreeNode owner;
        internal bool isexpanded;
		internal bool isroot;
		internal bool issited;
        internal bool isfirstsibling;
        internal bool islastsibling;
		internal Image imagen;
		internal int imageindex;
        private Random rndSeed = new Random();
		public int UniqueValue = -1;
        DataGridViewTreeCell celdaX = null;
        DataGridViewTreeNodesCollection nodes;
        internal int index;
		internal int level;
        private bool childCellsCreated = false;
		private ISite site = null;
		private EventHandler disposed = null;
        #endregion

        #region Constructor

        internal DataGridViewTreeNode(DataTreeGridView owner)
			: this()
		{
			this.grid = owner;
			this.isexpanded = true;
		}

        public DataGridViewTreeNode()
        {
            index = -1;
            level = -1;
            isexpanded = false;
            UniqueValue = this.rndSeed.Next();
            issited = false;
            isfirstsibling = false;
            islastsibling = false;
            imageindex = -1;
        }

        #endregion
                
        #region Propiedades

        [System.ComponentModel.Description("Representa la posición numérica que tiene la fila en la colección"),
		System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),
		 Browsable(false),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int RowIndex{
			get{
				return base.Index;
			}
		}

		[Browsable(false),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new int Index
		{
			get
			{
                index = this.owner.Nodes.IndexOf(this);             
				return index;
			}
		}       
        
        [Browsable(false), Description ("Lista de Imagen que el Usuario le Asigna al control"),
        EditorBrowsable( EditorBrowsableState.Never), 
        DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden)]
        public ImageList ImageList
        {
            get
            {
                if (this.grid != null)
                    return this.grid.ImageList;
                else
                    return null;
            }
        }

        public bool IsExpanded
        {
            get
            {
                return this.isexpanded;
            }
        }

		private bool ShouldSerializeImageIndex()
		{
			return (this.imageindex != -1 && this.imagen == null);
		}

        [Category("Appearance"),
        Description("Ubicación numérica de la imagen en la lista de imágenes"), DefaultValue(-1),
        TypeConverter(typeof(ImageIndexConverter)),
        Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(UITypeEditor))]
		public int ImageIndex
		{
			get { return imageindex; }
			set
			{
				imageindex = value;
				if (imageindex != -1)
				{
					this.imagen = null;
				}
				if (this.issited)
				{
					this.celdaX.UpdateStyle();
					if (this.Displayed)
						this.grid.InvalidateRow(this.RowIndex);
				}
			}
		}

		private bool ShouldSerializeImage()
		{
			return (this.imageindex == -1 && this.imagen != null);
		}

        public override bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                base.Visible = value;
                for (int i = 0; i <= this.Nodes.Count - 1; i++)
                { this.Nodes[i].Visible = value; }
                
            }
        }

		public Image Image
		{
			get {
				if (imagen == null && imageindex != -1)
				{
					if (this.ImageList != null && this.imageindex < this.ImageList.Images.Count)
					{
						// Para Tomar la Imagen desde El index
						return this.ImageList.Images[this.imageindex];
					}
					else
						return null;
				}
				else
				{
					return this.imagen;
				};
			}
			set
			{
				imagen = value;
				if (imagen != null)
				{
					// Si no hay lista de imagenes para evitar errores en ejecución, el valor por defecto es "1"
					this.imageindex = -1;
				}
				if (this.issited)
				{
				
					this.celdaX.UpdateStyle();
					if (this.Displayed)
						this.grid.InvalidateRow(this.RowIndex);
				}
			}
		}

        public new DataGridView DataGridView
        {
            get {return this.grid; }
        }

        public override bool Selected
        {
            get
            {
                return base.Selected;
            }
            set
            {
                base.Selected = value;
            }
        }

        [Category("Data"),
 Description("Coleccion de Nodos de El control"),
 DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
 Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public DataGridViewTreeNodesCollection Nodes
        {
            get
            {
                if (nodes == null)
                {
                    nodes = new DataGridViewTreeNodesCollection(this);
                }
                return nodes;
            }
            set {; }
        }

        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellCollection Cells
        {
            get
            {
                if (!childCellsCreated && this.DataGridView == null)
                {
                    if (this.grid == null) return null;

                    this.CreateCells(this.grid);
                    childCellsCreated = true;
                }
                return base.Cells;
            }
        }

        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Level
        {
            get
            {
                if (this.level == -1)
                {
                    int walk = 0;
                    DataGridViewTreeNode walkRow = this.Parent;
                    while (walkRow != null)
                    {
                        walk++;
                        walkRow = walkRow.Parent;
                    }
                    this.level = walk;
                }
                return this.level;
            }
        }

        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewTreeNode Parent
        {
            get
            {
                return this.owner;
            }
        }

        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool HasChildren
        {
            get
            {
                return (this.nodes != null && this.Nodes.Count != 0);
            }
        }

        [Browsable(false)]
        public bool IsSited
        {
            get
            {
                return this.issited;
            }
        }
        [Browsable(false)]
        public bool IsFirstSibling
        {
            get
            {
                return (this.Index == 0);
            }
        }

        [Browsable(false)]
        public bool IsLastSibling
        {
            get
            {
                DataGridViewTreeNode parent = this.Parent;
                if (parent != null && parent.HasChildren)
                {
                    return (this.Index == parent.Nodes.Count - 1);
                }
                else
                    return true;
            }
        }

        public virtual bool Collapse()
        {
            return this.grid.CollapseNode(this);
        }

        public virtual bool Expand()
        {
            if (this.grid != null)
                return this.grid.ExpandNode(this);
            else
            {
                this.isexpanded = true;
                return true;
            }
        }

        #endregion

        #region Eventos, Procedimientos y Funciones

        //Este procedimiento sirve para copiar columnas o filas de registros a otras celdas sin alterar la información
        //public override object Clone()
        //{            
        //    DataGridViewTreeNode n = new DataGridViewTreeNode();
        //    grid.Nodes.Add(n);
        //    grid.Nodes.Remove(n);            
        //    //r.UniqueValue = -1;
        //    //r.level = -1;
        //    //r.grid = null;
        //    //r.owner = null;
        //    //r.imageindex = this.imageindex;
        //    //if (r.imageindex == -1)
        //    //    r.Image = this.Image;
        //    //r.isexpanded = this.isexpanded;
        //    return n;
        //}

        //Este procedimiento sirve para quitar una fila al control
        internal protected virtual void UnSited()
        {
            DataGridViewTreeCell cell;
            foreach (DataGridViewCell DGVcell in this.Cells)
            {
                cell = DGVcell as DataGridViewTreeCell;
                if (cell != null)
                {
                    cell.UnSited();
                }
            }
            this.issited = false;
        }

        //Este procedimiento sirve para agregar una fila al control
        internal protected virtual void Sited()
        {
            this.issited = true;
            this.childCellsCreated = true;
            DataGridViewTreeCell cell;
            foreach (DataGridViewCell DGVcell in this.Cells)
            {
                cell = DGVcell as DataGridViewTreeCell;
                if (cell != null)
                {
                    cell.Sited();
                }
            }
        }

        //Este procedimiento sirve para agregar un nuevo nodo
        internal protected virtual bool InsertChildNode(int index, DataGridViewTreeNode node)
		{
			node.owner = this;
			node.grid = this.grid;

            if (this.grid != null)
                UpdateChildNodes(node);

			if ((this.issited || this.isroot) && this.isexpanded)
				this.grid.SiteNode(node, index);
			return true;
		}
        //Este procedimiento sirve para agregar una colección de nodos
		internal protected virtual bool InsertChildNodes(int index, params DataGridViewTreeNode[] nodes)
		{
			foreach (DataGridViewTreeNode node in nodes)
			{
				this.InsertChildNode(index, node);
			}
			return true;
		}

        //Este procedimiento sirve para agregar un nuevo nivel al nodo
		internal protected virtual bool AddChildNode(DataGridViewTreeNode node)
		{
			node.owner = this;
			node.grid = this.grid;
            node.Visible = this.Visible;
            if (this.grid != null)
                UpdateChildNodes(node);
            if ((this.issited || this.isroot) && this.isexpanded && !node.issited)
            {
                this.grid.SiteNode(node);
            }
            else
            {
                node.CreateCells(grid);                
            }
            return true;
		}

        internal protected virtual void ClearNodes()
        {
            try
            {
                if (HasChildren)
                {
                    foreach (var n in nodes)
                    {
                        RemoveChildNode(n);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        //Este procedimiento sirve para añadir varios niveles a varios nodos
        internal protected virtual bool AddChildNodes(params DataGridViewTreeNode[] nodes)
		{
			foreach (DataGridViewTreeNode node in nodes)
			{
				this.AddChildNode(node);
			}
			return true;

		}

        //Este procedimiento sirve para quitar un registro de un nodo
        internal protected virtual bool RemoveChildNode(DataGridViewTreeNode node)
		{
			if ((this.isroot || this.issited) && this.isexpanded )
			{                
				this.grid.UnSiteNode(node);			
			}
			return true;

		}

        //Este procedimiento sirve para eliminar los nodo
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler Disposed
        {
            add
            {
                this.disposed += value;
            }
            remove
            {
                this.disposed -= value;
            }
        }

		[Browsable(false),DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ISite Site
		{
			get
			{
				return this.site;
			}
			set
			{
				this.site = value;
			}
		}

        //Este procedimiento sirve para actualizar los registros de los nodos
        private void UpdateChildNodes(DataGridViewTreeNode node)
        {
            if (node.HasChildren)
            {
                foreach (DataGridViewTreeNode childNode in node.Nodes)
                {
                    childNode.grid = node.grid;
                    this.UpdateChildNodes(childNode);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(36);
            sb.Append("TreeGridNode { Index=");
            sb.Append(this.RowIndex.ToString(System.Globalization.CultureInfo.CurrentCulture));
            sb.Append(" }");
            return sb.ToString();
        }
               
        protected override void Dispose(bool disposing)
        {
		    if (disposing)
		    {
		        lock(this)
		        {
		            if (this.site != null && this.site.Container != null)
		            {
                    
		            }
                     if (this.disposed != null)
		            {
		                this.disposed(this, EventArgs.Empty);
		            }
		        }
		    }

		    base.Dispose(disposing);
        }
        #endregion
    }

}