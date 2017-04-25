using System;
using System.Drawing;
using System.Windows.Forms;

namespace ToolStrip_Extras
{
    [ToolboxBitmapAttribute(typeof(NumericUpDown))]
    public class NumericUpDownToolStripItem : ToolStripControlHost
    {
        #region Variables
        private NumericUpDown num = new NumericUpDown();
        #endregion

        #region Constructor
        public NumericUpDownToolStripItem() : base(new NumericUpDown())
        {
            num = (NumericUpDown)base.Control;
            num.Value = 0;
        }
        #endregion

        #region Propiedades
        public decimal Value
        {
            get { return this.num.Value; }
            set { this.num.Value = value; }
        }
        public NumericUpDown NumericUpDown
        {
            get { return num; }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                decimal n;
                if (decimal.TryParse(value, out n))
                {
                    base.Text = n.ToString();
                }
                else
                {
                    base.Text = "0";
                }

            }
        }

        #endregion
        protected override void OnSubscribeControlEvents(Control control)
        {
            base.OnSubscribeControlEvents(control);
        }
        protected override void OnUnsubscribeControlEvents(Control control)
        {
            base.OnUnsubscribeControlEvents(control);
        }

    }
}