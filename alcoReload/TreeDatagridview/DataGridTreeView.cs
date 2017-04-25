using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace DatagridTreeView
{

    [System.ComponentModel.DesignerCategory("code"),ToolboxBitmapAttribute(typeof(DataGridView)),
    ComplexBindingProperties(), Docking(DockingBehavior.Ask), Designer(typeof(DatagridTreeView.DataGridTreeViewDesigner), typeof(IDesigner))]
	public class DataTreeGridView:DataGridView
    {

        #region Variables
        private DataGridViewTreeNode root;
		internal ImageList imagelist;
        private bool showlines = true;
        private bool virtualnodes = false;
        #endregion

        #region Constructor
        public DataTreeGridView()
		{
            RowTemplate = new DataGridViewTreeNode() as DataGridViewRow;			
            AllowUserToAddRows = false;
			AllowUserToDeleteRows = false;
            root = new DataGridViewTreeNode(this);
            root.isroot = true;
            BackgroundColor = Color.White;
			base.Rows.CollectionChanged += delegate(object sender, System.ComponentModel.CollectionChangeEventArgs e){};
        }
        #endregion             

        #region Propiedades Sobre-Escritas

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		EditorBrowsable(EditorBrowsableState.Never)]
        public new DataGridViewRowCollection Rows
        {
            get { return base.Rows; }
        }

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new bool VirtualMode
        {
            get { return false; }
            set { throw new NotSupportedException("El control no es compatible, con el modo virtual"); }
        }
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new DataGridViewRow RowTemplate
        {
            get { return base.RowTemplate; }
            set { base.RowTemplate = value; }
        }
     

        #endregion

        #region Propiedades Publicas
        [ Category("Data"),
		Description("Retorna la colección de nodos base del control"),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
		public DataGridViewTreeNodesCollection Nodes
		{
			get
			{
				return root.Nodes;
			}
		}

        [Browsable(false)]
		public new DataGridViewTreeNode CurrentRow
		{
			get
			{
				return base.CurrentRow as DataGridViewTreeNode;
			}
		}

        [DefaultValue(false), Category("Behavior")]
        public bool VirtualNodes
        {
            get { return virtualnodes; }
            set { virtualnodes = value; }
        }
	
        [Browsable(false)]
		public DataGridViewTreeNode CurrentNode
		{
			get
			{
				return base.CurrentRow as DataGridViewTreeNode;
            }
		}

        [DefaultValue(true), Category("Appearance")]
        public bool ShowLines
        {
            get { return this.showlines; }
            set { 
                if (value != this.showlines) {
                    this.showlines = value;
                    this.Invalidate();
                } 
            }
        }
      
	    [Category("Design")]
		public ImageList ImageList
		{
			get { return this.imagelist; }
			set { 
				this.imagelist = value; 
			}
		}

        public new int RowCount
        {
            get { return this.Nodes.Count; }
        }
        #endregion

        #region Colocación, expansión/contracción nodos
        //Este procedimiento sirve cuando se ha agregado una nueva fila
        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            base.OnRowsAdded(e);
            int count = e.RowCount - 1;
            DataGridViewTreeNode row;
            while (count >= 0)
            {
                row = base.Rows[e.RowIndex + count] as DataGridViewTreeNode;
                if (row != null)
                {              
                    row.Sited();                   
                }
                count--;
            }
        }
		internal protected void UnSiteAll()
		{
			this.UnSiteNode(this.root);
		}
		internal protected virtual void UnSiteNode(DataGridViewTreeNode node)
		{
            if (node.IsSited || node.isroot)
			{
                // Siempre se deben remover, los hijos primero.
				foreach (DataGridViewTreeNode childNode in node.Nodes)
				{
					this.UnSiteNode(childNode);
				}
				if (!node.isroot)
				{
                    if (base.Rows.Count > 0)
                    {
                        base.Rows.Remove(node);
                        node.UnSited();
                    } 
                    
				}
			}
		}
        //Este procedimiento sirve para ubicar extender o contraer los nodos cuando se le agregan o suprimen elementos
        internal protected virtual bool CollapseNode(DataGridViewTreeNode node)
		{
			if (node.isexpanded)
			{
				CollapsingEventArgs exp = new CollapsingEventArgs(node);
				this.OnNodeCollapsing(exp);
				if (!exp.Cancel)
				{
                    this.SuspendLayout();
                    node.isexpanded = false;
					foreach (DataGridViewTreeNode childNode in node.Nodes)
					{
						Debug.Assert(childNode.RowIndex != -1, "La fila no esta en el control.");
						this.UnSiteNode(childNode);
					}
					CollapsedEventArgs exped = new CollapsedEventArgs(node);
					this.OnNodeCollapsed(exped);
                    this.ResumeLayout(true);
                    this.InvalidateCell(node.Cells[0]);
				}
				return !exp.Cancel;
			}
			else
			{			
				return false;
			}
		}
        //Este procedimiento sirve para ubicar elemento en el nodo
		internal protected virtual void SiteNode(DataGridViewTreeNode node)
		{
			int rowIndex = -1;
			DataGridViewTreeNode currentRow;
			node.grid = this;

			if (node.Parent != null && node.Parent.isroot == false)
			{
				Debug.Assert(node.Parent != null && node.Parent.isexpanded == true);

				if (node.Index > 0)
				{
					currentRow = node.Parent.Nodes[node.Index - 1];
				}
				else
				{
					currentRow = node.Parent;
				}
			}
			else
			{
				if (node.Index > 0)
				{
					currentRow = node.Parent.Nodes[node.Index - 1];
				}
				else
				{
					currentRow = null;
				}
			}
			if (currentRow != null)
			{
				while (currentRow.Level >= node.Level)
				{
					if (currentRow.RowIndex < base.Rows.Count - 1)
					{
						currentRow = base.Rows[currentRow.RowIndex + 1] as DataGridViewTreeNode;
						Debug.Assert(currentRow != null);
					}
					else
						break;
				}
				if (currentRow == node.Parent)
					rowIndex = currentRow.RowIndex + 1;
				else if (currentRow.Level < node.Level)
					rowIndex = currentRow.RowIndex;
				else
					rowIndex = currentRow.RowIndex + 1;
			}
			else
				rowIndex = 0;
			Debug.Assert(rowIndex != -1);
			this.SiteNode(node, rowIndex);

			Debug.Assert(node.IsSited);
			if (node.isexpanded)
			{
				foreach (DataGridViewTreeNode childNode in node.Nodes)
				{
					this.SiteNode(childNode);
				}
			}
		}
        //Este procedimiento sirve para ubicar elemento en el nodo
        internal protected virtual void SiteNode(DataGridViewTreeNode node, int index)
		{
			if (index < base.Rows.Count)
			{
				base.Rows.Insert(index, node);
			}
			else
			{
				base.Rows.Add(node);
			}
		}

		internal protected virtual bool ExpandNode(DataGridViewTreeNode node)
		{
            if (!node.isexpanded || this.virtualnodes)
			{
				ExpandingEventArgs exp = new ExpandingEventArgs(node);
				this.OnNodeExpanding(exp);

				if (!exp.Cancel)
				{
                    this.SuspendLayout();
                    node.isexpanded = true;
					foreach (DataGridViewTreeNode childNode in node.Nodes)
					{
						Debug.Assert(childNode.RowIndex == -1, "La fila esta en el control ¡ok!");

						this.SiteNode(childNode);
					}

					ExpandedEventArgs exped = new ExpandedEventArgs(node);
					this.OnNodeExpanded(exped);
                    this.ResumeLayout(true);
                    this.InvalidateCell(node.Cells[0]);
				}

				return !exp.Cancel;
			}
			else
			{
				return false;
			}
        }
   #endregion

        #region Collapse/Expand events
        public event ExpandingEventHandler NodeExpanding;
        public event ExpandedEventHandler NodeExpanded;
        public event CollapsingEventHandler NodeCollapsing;
        public event CollapsedEventHandler NodeCollapsed;

        protected virtual void OnNodeExpanding(ExpandingEventArgs e)
        {
            if (this.NodeExpanding != null)
            {
                NodeExpanding(this, e);
            }
        }
        protected virtual void OnNodeExpanded(ExpandedEventArgs e)
        {
            if (this.NodeExpanded != null)
            {
                NodeExpanded(this, e);
            }
        }
        protected virtual void OnNodeCollapsing(CollapsingEventArgs e)
        {
            if (this.NodeCollapsing != null)
            {
                NodeCollapsing(this, e);
            }

        }
        protected virtual void OnNodeCollapsed(CollapsedEventArgs e)
        {
            if (this.NodeCollapsed != null)
            {
                NodeCollapsed(this, e);
            }
        }
        #endregion

        #region Generales
        protected override void Dispose(bool disposing)
        {
            base.Dispose(Disposing);
            this.UnSiteAll();
        }
        #endregion

    }
}
