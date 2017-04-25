using System.Windows.Forms;
using System.Drawing;
namespace DatagridTreeView
{
    [ToolboxBitmapAttribute(typeof(TreeView))]
    public class DataGridViewTreeColumn : DataGridViewTextBoxColumn
    {
        #region Variables
        internal Image imagendefectonodo;
        #endregion

        #region Constructor

        public DataGridViewTreeColumn() : base()
        {
            this.CellTemplate = new DataGridViewTreeCell();
            CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            base.ReadOnly = true;
        }
        #endregion

        #region Propiedades

        public Image ImagenporDefecto
        {
            get { return imagendefectonodo; }
            set { imagendefectonodo = value; }
        }
        #endregion

        #region Eventos, Procedimientos y Funciones

        //Este procedimiento sirve para copiar columnas o filas de registros a otras celdas sin alterar la información
        public override object Clone()
        {
            DataGridViewTreeColumn c = (DataGridViewTreeColumn)base.Clone();
            c.imagendefectonodo = this.imagendefectonodo;
            return c;
        }

        #endregion
    }
}
