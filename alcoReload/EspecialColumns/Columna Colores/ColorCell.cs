using System;
using System.Drawing;
using System.Windows.Forms;

namespace EspecialColumns.Columna_Colores
{
    public class ColorCell : DataGridViewTextBoxCell
    {
        public ColorCell() : base()
        {
            base.ReadOnly = true;
            this.Value = DefaultNewRowValue;
        }
        
        public override object DefaultNewRowValue
        {
            get
            {
                return Color.White;
            }
        }
        public override bool ReadOnly
        {
            get
            {
                return true;
            }

            set
            {
            }
        }
        private Color obtenercolor(object color)
        {
            try
            {
                if (color.GetType() == typeof(Color))
                {
                    return (Color)color;
                }
                else
                {
                    return Color.FromName(Convert.ToString(color));
                }
            }
            catch
            {
                return Color.White;
            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, null, null, errorText, cellStyle, advancedBorderStyle, paintParts);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Color c = obtenercolor(value);
            Rectangle r = new Rectangle(cellBounds.X + (cellBounds.Width / 2) - ((cellBounds.Height-4)/2),
                cellBounds.Y + 2, cellBounds.Height-4, cellBounds.Height - 4);
            graphics.FillEllipse(new SolidBrush(c), r);
            graphics.FillEllipse(new SolidBrush(Color.FromArgb(150,255,255,255)),
                r.X + 7, r.Y, 9,12);
            graphics.DrawEllipse(Pens.Black, r);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        }
    }
}