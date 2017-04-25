using System.Drawing;
using System.Windows.Forms;

namespace EspecialColumns.Columna_Formula
{
    [ToolboxBitmapAttribute(typeof(MaskedTextBox))]
    public class FormuleGridColumn : DataGridViewColumn
    {
        public FormuleGridColumn() : base(new FormuleCell()) { }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {                
                base.CellTemplate = value;
            }
        }
    }
}
