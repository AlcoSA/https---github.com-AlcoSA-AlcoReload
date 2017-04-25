using System;
using System.Windows.Forms;
using System.Drawing;

[ToolboxBitmapAttribute(typeof(DateTimePicker))]
public class DateTimeGridColumn : DataGridViewColumn
{

    public DateTimeGridColumn() : base(new DateTimeCell()) { }

    public override DataGridViewCell CellTemplate
    {
        get
        {
            return base.CellTemplate;
        }
        set
        {
            if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DateTimeCell)))
                throw new InvalidCastException("Debe especificar una instancia de DateTimeCell");
            base.CellTemplate = value;
        }
    }

}

