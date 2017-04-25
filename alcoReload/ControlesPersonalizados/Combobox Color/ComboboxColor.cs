using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlesPersonalizados.Combobox_Color
{
    public class ComboboxColor : ComboBox
    {
        public ComboboxColor() : base()
        {
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Items.AddRange(Enum.GetValues(typeof(KnownColor)).Cast<KnownColor>().Select(c => c.ToString()).ToArray());
        }

        #region Propiedades
        public new DrawMode DrawMode
        {
            get
            {
                return base.DrawMode;
            }
            set
            {
                if (value != DrawMode.OwnerDrawFixed)
                {
                    throw new NotSupportedException("Para múltiples columnas debe ser: DrawMode.OwnerDrawFixed");
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
        #endregion

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.DrawBackground();
            if (e.Index >= 0)
            {
                Rectangle r = e.Bounds;
                r.X += 4; r.Y += 2;
                r.Width -= 8; r.Height -= 4;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromName(this.Items[e.Index].ToString())), r);
            }               
            
        }

    }
}
