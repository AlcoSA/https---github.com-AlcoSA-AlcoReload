using System;
using System.Windows.Forms;

namespace EspecialColumns.Columna_Colores
{
    public class ColorGridColumns : DataGridViewColumn
    {

        public ColorGridColumns() : base(new ColorCell()) { }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof(ColorCell)))
                    throw new InvalidCastException("Debe especificar una instancia de StateCell");
                base.CellTemplate = value;
            }
        }
    }
}
