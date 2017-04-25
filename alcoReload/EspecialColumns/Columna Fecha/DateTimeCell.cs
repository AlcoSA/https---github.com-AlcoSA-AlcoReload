using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class DateTimeCell : DataGridViewTextBoxCell
{
    public DateTimeCell() : base() {
        Style.Format = "yyyy/MM/dd";
        Value = DateTime.Now; }
    public override Type EditType
    {
        get { return typeof(DateTimeEditingControl); }
    }
    public override Type ValueType
    {
        get { return typeof(DateTime); }
    }
    public override object DefaultNewRowValue
    {
        get
        {
            object defaultValue = base.DefaultNewRowValue;
            if (defaultValue is DateTime)
                return defaultValue;
            else
                return DateTime.Now;
        }
    }
    public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    {
        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
        DateTimeEditingControl ctl = DataGridView.EditingControl as DateTimeEditingControl;
        try
        {
            if (this.Value == null)
            {
                ctl.Value = (DateTime)this.DefaultNewRowValue;
            }
            else
            { 
                ctl.Value = (DateTime)this.Value;
            }
        }
        catch (Exception)
        {
            ctl.Value = (DateTime)this.DefaultNewRowValue;
        }

        if (dataGridViewCellStyle.Format.Length == 1)
        {
            string[] patterns = DateTimeFormatInfo.CurrentInfo.GetAllDateTimePatterns(dataGridViewCellStyle.Format.ToCharArray()[0]);
            if (patterns.Length > 0)
                ctl.CustomFormat = patterns[0].ToString();
            else
                ctl.CustomFormat = dataGridViewCellStyle.Format;
        }
        else
            ctl.CustomFormat = dataGridViewCellStyle.Format;
    }
    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    {
        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        using (DateTimePicker dtp = new DateTimePicker())
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = this.Style.Format;
            if (this.RowIndex > -1)
            {
                if (this.Value == null)
                { dtp.Value = (DateTime)this.DefaultNewRowValue; }
                else { dtp.Value = (DateTime)this.Value; }
            }
            dtp.Height = cellBounds.Height;
            dtp.Width = cellBounds.Width;
            Bitmap bmp = new Bitmap(cellBounds.Width, cellBounds.Height);
            dtp.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            graphics.DrawImage(bmp, new Point(cellBounds.X, cellBounds.Y));
        }        
    }
}
