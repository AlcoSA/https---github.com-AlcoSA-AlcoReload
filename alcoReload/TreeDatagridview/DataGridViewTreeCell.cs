using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace DatagridTreeView
{

    public class DataGridViewTreeCell:DataGridViewTextBoxCell
    {
        #region Constantes
        private const int INDENT_WIDTH = 20;
        private const int INDENT_MARGIN = 5;
        #endregion

        #region Variables
        private int glyphWidth = 15;
		private int calculatedLeftPadding;
		internal bool IsSited;
		private Padding _previousPadding;
        private int _imageWidth = 0, _imageHeight = 0, _imageHeightOffset = 0;
        VisualStyleRenderer glyphopen = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Opened);
        VisualStyleRenderer glyphclose = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Closed);
        Rectangle glyphRect;
        #endregion

        #region Constructor
        public DataGridViewTreeCell() : base()
		{			
			glyphWidth = 15;
			calculatedLeftPadding = 0;
			this.IsSited = false;       
		}
        #endregion

        #region Propiedades

        protected virtual int GlyphMargin
        {
            get
            {
                return (System.Math.Abs(this.OwningNode.level) - 1) * INDENT_WIDTH + INDENT_MARGIN;
            }
        }

        protected virtual int GlyphOffset
        {
            get
            {
                return ((this.OwningNode.level - 1) * INDENT_WIDTH);
            }
        }

        public DataGridViewTreeNode OwningNode
        {
            get { return base.OwningRow as DataGridViewTreeNode; }
        }

        #endregion

        #region Eventos,Procedimientos y Funciones
        public override object Clone()
        {
			DataGridViewTreeCell cell = (DataGridViewTreeCell)base.Clone();
            cell.Value = this.Value;
            cell.glyphWidth = this.glyphWidth;
            cell.calculatedLeftPadding = this.calculatedLeftPadding;
            return cell;
        }

		internal protected virtual void UnSited()
		{
			this.IsSited = false;
			this.Style.Padding = this._previousPadding;
		}

		internal protected virtual void Sited()
		{
			this.IsSited = true;
			this._previousPadding = this.Style.Padding;
			this.UpdateStyle();
		}
        //Este procedimiento sirve para actualizar el estilo de la columna
        internal protected virtual void UpdateStyle(){
			if (!this.IsSited) return;			
			Size preferredSize;
			using (Graphics g = this.OwningNode.grid.CreateGraphics() ) {
				preferredSize =this.GetPreferredSize(g, this.InheritedStyle, this.RowIndex, new Size(0, 0));
			}
			if (this.OwningNode.Image != null)
			{
                _imageWidth = this.OwningNode.Image.Width + 2;
				_imageHeight = this.OwningNode.Image.Height+2;
			}
			else
			{
                _imageWidth = glyphWidth;
				_imageHeight = 0;
			}
			// Creacion del Metodo Clear
			if (preferredSize.Height < _imageHeight)
			{
                this.Style.Padding = new Padding(_previousPadding.Left + (System.Math.Abs(this.OwningNode.level) * INDENT_WIDTH) + _imageWidth + INDENT_MARGIN,
                    _previousPadding.Top + (_imageHeight / 2), _previousPadding.Right, _previousPadding.Bottom + (_imageHeight / 2));
				_imageHeightOffset = 2;
			}
			else
			{
                this.Style.Padding = new Padding(_previousPadding.Left + (System.Math.Abs(this.OwningNode.level) * INDENT_WIDTH) +
                    _imageWidth + INDENT_MARGIN, _previousPadding.Top, _previousPadding.Right, _previousPadding.Bottom);
			}
            calculatedLeftPadding = ((System.Math.Abs(this.OwningNode.level) - 1) * glyphWidth) + _imageWidth + INDENT_MARGIN;
		}
        //Este procedimiento sirve para pintar las celdas del DataGrid
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {            
            if (OwningNode == null) return;            
            if (this._imageHeight == 0 && OwningNode.Image != null) this.UpdateStyle();
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, null, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            glyphRect = new Rectangle(cellBounds.X + this.GlyphMargin, cellBounds.Y, INDENT_WIDTH, cellBounds.Height);
            #region Imagen en Celda
            if (OwningNode.Image != null)
            {
                Point pp;
                if (_imageHeight > cellBounds.Height)
                    pp = new Point(glyphRect.X + this.glyphWidth, cellBounds.Y + _imageHeightOffset);
                else
                    pp = new Point(glyphRect.X + this.glyphWidth, (cellBounds.Height / 2 - _imageHeight / 2) + cellBounds.Y);

                System.Drawing.Drawing2D.GraphicsContainer gc = graphics.BeginContainer();
                {
                    graphics.SetClip(cellBounds);
                    graphics.DrawImageUnscaled(OwningNode.Image, pp);
                }
                graphics.EndContainer(gc);
            }
            #endregion

            #region Lineas de indicación
            if (OwningNode.grid.ShowLines)
            {
                using (Pen linePen = new Pen(SystemBrushes.ControlDarkDark, 1.0f))
                {
                    linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    if (OwningNode.Level == 1)
                    {                        
                        graphics.DrawLine(linePen, cellBounds.Left, cellBounds.Top + cellBounds.Height / 2, glyphRect.X, cellBounds.Top + cellBounds.Height / 2); //Horizontal
                        if (OwningNode.isexpanded)
                        {
                            graphics.DrawLine(linePen, glyphRect.X + (glyphRect.Width / 3)-2, cellBounds.Top + cellBounds.Height / 2, glyphRect.X + (glyphRect.Width / 3)-2, cellBounds.Bottom);
                        }
                    }
                    else
                    {
                        graphics.DrawLine(linePen, glyphRect.X+3 , (cellBounds.Top + cellBounds.Height / 2)-3, ((glyphRect.X + 7) - INDENT_WIDTH)-3, (cellBounds.Top + cellBounds.Height / 2)-3); //Horizontal
                        if (!OwningNode.isfirstsibling)
                        {graphics.DrawLine(linePen, ((glyphRect.X + 7) - INDENT_WIDTH)-3, glyphRect.Y, ((glyphRect.X + 7) - INDENT_WIDTH)-3, (cellBounds.Top + cellBounds.Height / 2)-1);}
                        if (!OwningNode.IsLastSibling)
                        {
                            if (!OwningNode.isexpanded)
                            {
                                graphics.DrawLine(linePen, ((glyphRect.X + 7) - INDENT_WIDTH)-3, cellBounds.Top, ((glyphRect.X + 7) - INDENT_WIDTH)-3, cellBounds.Bottom);
                            }
                        }
                        if (OwningNode.isexpanded && OwningNode.HasChildren)
                        { graphics.DrawLine(linePen, glyphRect.X + 7, cellBounds.Y + (cellBounds.Height / 2), glyphRect.X + 7, cellBounds.Bottom); }//Vertical Unión Entre Hijos y Padres
                    }
                }
            }
            #endregion

            #region Glyph
            if (OwningNode.HasChildren || OwningNode.grid.VirtualNodes || OwningNode.Nodes.Count > 0)
            {
                if (Application.RenderWithVisualStyles)
                {
                    if (OwningNode.isexpanded)
                    {                       
                       glyphopen.DrawBackground(graphics, new Rectangle(glyphRect.X, glyphRect.Y +  (glyphRect.Height / 2) -5, 10, 10));                        
                    }
                    else
                    {                        
                        glyphclose.DrawBackground(graphics, new Rectangle(glyphRect.X, glyphRect.Y + (glyphRect.Height / 2)-5, 10, 10));                        
                    }
                }
            }
            else
            {
                graphics.FillEllipse(Brushes.DarkBlue, new Rectangle(glyphRect.X, glyphRect.Y + (glyphRect.Height / 2)-5, 5, 5));
            }
            #endregion
        }

		protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
		{
            try
            {
                if (this.glyphRect != null && this.OwningNode != null && this.OwningNode.HasChildren)
                {                    
                        if (e.X < this.glyphRect.X + this.glyphRect.Width)
                        {
                            if (this.OwningNode.isexpanded )
                                this.OwningNode.Collapse();
                            else
                                this.OwningNode.Expand();
                        }                    
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message, ex.InnerException);
            }			
        }
        #endregion
    }
}
