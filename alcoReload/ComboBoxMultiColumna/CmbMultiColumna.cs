using System;
using System.Windows.Forms;
using System.Drawing;

namespace ComboBoxMultiColumna
{
    public class CmbMultiColumna : ComboBox
    {
        #region Variables
        const int columnPadding = 5;
        private float[] columnWidths = new float[0];
        string[] datosvisibles;
        #endregion

        #region Propiedades

        public new DrawMode DrawMode
        {
            get
            {
                return base.DrawMode;
            }
            set
            {
                if (value != DrawMode.OwnerDrawVariable)
                {
                    throw new NotSupportedException("Para múltiples columnas debe ser: DrawMode.OwnerDrawVariable");
                }
                base.DrawMode = value;
            }
        }

        public new ComboBoxStyle DropDownStyle
        {
            get
            {
                return base.DropDownStyle;
            }
            set
            {
                if (value == ComboBoxStyle.Simple)
                {
                    throw new NotSupportedException("ComboBoxStyle Simple: No esta soportado");
                }
                base.DropDownStyle = value;
            }
        }

        public string[] DatosVisibles {
            get { return datosvisibles; }
            set { datosvisibles = value;
            }
        }

        #endregion

        #region Constructor
        public CmbMultiColumna() : base()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
        }
        #endregion

        #region Procedimientos

        private float CalculateTotalWidth()
        {
            float totWidth = 0;
            foreach (int width in columnWidths)
            {
                totWidth += (width + columnPadding);
            }
            return totWidth + SystemInformation.VerticalScrollBarWidth;
        }

        #endregion

        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
        }

        protected override void OnDropDown(EventArgs e)
        {
            this.DropDownWidth = (int)CalculateTotalWidth();
            base.OnDropDown(e);            
        }        

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
            if (DesignMode)
                return;
            if (columnWidths.Length != datosvisibles.Length)
            {
                columnWidths = new float[datosvisibles.Length];
            }
            for (int colIndex = 0; colIndex < columnWidths.Length; colIndex++)
            {
                string item = Convert.ToString(FilterItemOnProperty(Items[e.Index], datosvisibles[colIndex]));
                SizeF sizeF = e.Graphics.MeasureString(item, Font);
                columnWidths[colIndex] = Math.Max(columnWidths[colIndex], sizeF.Width);
            }

            float totWidth = CalculateTotalWidth();

            e.ItemWidth = (int)totWidth;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (DesignMode)
                return;
            e.DrawBackground();
            Rectangle boundsRect = e.Bounds;
            int lastRight = 0;
            if (e.Index>=0)
            {
                using (Pen linePen = new Pen(SystemColors.GrayText))
                {
                    using (SolidBrush brush = new SolidBrush(ForeColor))
                    {
                        if (e.State == (DrawItemState.ComboBoxEdit | DrawItemState.NoAccelerator | DrawItemState.NoFocusRect) || !DroppedDown)
                        {
                            string item = Convert.ToString(FilterItemOnProperty(Items[e.Index], DisplayMember));
                            e.Graphics.DrawString(item, Font, brush, boundsRect);                           
                        }
                        else
                        {
                            for (int colIndex = 0; colIndex < datosvisibles.Length; colIndex++)
                            {
                                string item = Convert.ToString(FilterItemOnProperty(Items[e.Index], datosvisibles[colIndex]));
                                boundsRect.X = lastRight;
                                boundsRect.Width = (int)columnWidths[colIndex] + columnPadding;
                                lastRight = boundsRect.Right;

                                e.Graphics.DrawString(item, Font, brush, boundsRect);
                                if (colIndex < datosvisibles.Length - 1)
                                {
                                    e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, boundsRect.Right, boundsRect.Bottom);
                                }
                            }
                        }
                    }
                }
            }            
            e.DrawFocusRectangle();
        }
    }
}
