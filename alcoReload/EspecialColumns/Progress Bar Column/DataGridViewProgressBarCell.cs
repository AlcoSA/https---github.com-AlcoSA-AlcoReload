using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace SpecialColumns
{
    public class DataGridViewProgressBarCell :  DataGridViewImageCell
   {
        #region vars
        static Image imagenvacia;
        private Color color_barra;
        #endregion
        #region ctor
        public DataGridViewProgressBarCell()
            : base()
        {
            this.Value = 0;
            this.ValueType = typeof(decimal);
        }
       #endregion

       #region props
         public Color Color
        {
            get { return color_barra; }
            set { color_barra = value; }
        }
        public new object Value
        {
            get { return base.Value; }
            set {
                decimal valor = 0;
                if (decimal.TryParse(Convert.ToString(value), out valor))
                {
                    base.Value = value;
                }
                else
                {
                    throw new Exception("Esta celda solo acepta valores numericos");
                }
            }
        }
        #endregion
        #region procs
        static DataGridViewProgressBarCell()
        {
            imagenvacia = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        internal void DarColor(int rowIndex, Color value)
        {
            this.Color = value;
        }
        #endregion

        #region Eventos

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return imagenvacia;
        }

        protected override void PaintBorder(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle bounds, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle)
        {
            base.PaintBorder(graphics, clipBounds, bounds, cellStyle, advancedBorderStyle);
            
        }
        /// <summary>
        /// Este procedimiento sirve para dar formato y pintar las barras
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="clipBounds"></param>
        /// <param name="cellBounds"></param>
        /// <param name="rowIndex"></param>
        /// <param name="elementState"></param>
        /// <param name="value"></param>
        /// <param name="formattedValue"></param>
        /// <param name="errorText"></param>
        /// <param name="cellStyle"></param>
        /// <param name="advancedBorderStyle"></param>
        /// <param name="paintParts"></param>
        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (Convert.ToInt32(value) == 0)
            {

            }
            decimal progreso = Convert.ToDecimal(value);
            decimal porcentaje = progreso / 100;
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            Rectangle rect = new Rectangle(new Point(cellBounds.X + 2, cellBounds.Y + 2), new Size(cellBounds.Width - 4, cellBounds.Height -4));
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(240,240,240)), cellBounds.X, cellBounds.Y, cellBounds.Width -1, cellBounds.Height - 1);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(200, 200, 200)), rect);

            if (porcentaje >= 0)
              { 
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(100,color_barra)), rect.X ,
                    rect.Y, Convert.ToInt32((porcentaje * rect.Width)), rect.Height);

                graphics.FillRectangle(new SolidBrush(Color.FromArgb(200, color_barra)), rect.X,
                    rect.Y + 6, Convert.ToInt32((porcentaje * rect.Width)), rect.Height - 6);

                graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.White)), rect.X,
                    rect.Y + (rect.Height/ 2) -2, Convert.ToInt32((porcentaje * rect.Width)), 3);

                graphics.DrawString(Convert.ToInt32(progreso).ToString() + "%", cellStyle.Font,
                    new SolidBrush(cellStyle.ForeColor), cellBounds.X + (cellBounds.Width / 2) - 10,
                    cellBounds.Y + (cellBounds.Height / 2) - 5);
            }
            else
            {
                graphics.DrawString(Convert.ToInt32(progreso).ToString() + "%",
                    cellStyle.Font, new SolidBrush(cellStyle.ForeColor),
                    cellBounds.X + (cellBounds.Width / 2) - 10,
                    cellBounds.Y + (cellBounds.Height / 2) - 5);                
            }
        }

        /// <summary>
        /// Este procedimiento sirve para copiar columnas o filas de registros a otras celdas sin alterar la información
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            DataGridViewProgressBarCell dataGridViewCell = base.Clone() as DataGridViewProgressBarCell;
            if (dataGridViewCell != null)
            {
                dataGridViewCell.Color= this.Color;
            }
            return dataGridViewCell;
        }


        #endregion
   }
}
