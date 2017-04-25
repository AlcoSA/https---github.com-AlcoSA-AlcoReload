using System;
using System.Drawing;
using System.Windows.Forms;

namespace ToolStrip_Extras
{
    [ToolboxBitmapAttribute(typeof(DateTimePicker))]
    public class DatetimePickerToolStripItem : ToolStripControlHost
    {
        #region Variables
        private DateTimePicker picker = new DateTimePicker();
        #endregion

        #region Constructor
        public DatetimePickerToolStripItem() : base(new DateTimePicker())
        {
            picker = (DateTimePicker)base.Control;
            picker.Value = DateTime.Now;
            this.Format = picker.Format;
        }
        #endregion

        #region Propiedades

        public DateTimePickerFormat Format
        {
            get { return this.picker.Format; }
            set { this.picker.Format = value; }
        }
        public string CustomFormat
        {
            get { return this.picker.CustomFormat; }
            set { this.picker.CustomFormat = value; }
        }
        public DateTime Value
        {
            get { return this.picker.Value; }
            set { this.picker.Value = value; }
        }
        public DateTimePicker DateTimePicker
        {
            get { return picker; }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                DateTime f;
                if (DateTime.TryParse(value, out f))
                {
                    base.Text = f.ToShortDateString();
                }
                else
                {
                    base.Text = DateTime.Now.ToShortDateString();
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