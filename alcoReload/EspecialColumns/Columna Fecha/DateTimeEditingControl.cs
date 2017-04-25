using System;
using System.Windows.Forms;

class DateTimeEditingControl : DateTimePicker, IDataGridViewEditingControl
{

    private DataGridView grid;
    private bool valueChanged;

    public DateTimeEditingControl()
    {
        this.Format = DateTimePickerFormat.Custom;
        this.CustomFormat="dd/MM/yyyy";
    }
    protected override void OnValueChanged(EventArgs eventargs)
    {
        base.OnValueChanged(eventargs);
        SendToGridValueChanged();
    }
    private void SendToGridValueChanged()
    {
        valueChanged = true;
        if (grid != null)
            grid.NotifyCurrentCellDirty(true);
    }
    
    #region Miembros de IDataGridViewEditingControl
    public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
    {
        this.Font = dataGridViewCellStyle.Font;
        this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
        this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        
    }
    public DataGridView EditingControlDataGridView
    {
        get { return grid; }
        set { grid = value; }
    }    
    public object EditingControlFormattedValue
    {
        get
        {
            return this.Value.ToString(this.CustomFormat);
        }
        set
        {
            try { this.Value = DateTime.Parse((string)value); }
            catch { this.Value = DateTime.Now; }
            SendToGridValueChanged();
        }
    }
    public int EditingControlRowIndex { get; set; }
    public bool EditingControlValueChanged
    {
        get { return valueChanged; }
        set { valueChanged = value; }
    }
    public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
    {
        switch (keyData & Keys.KeyCode)
        {
            case Keys.Left:
            case Keys.Up:
            case Keys.Down:
            case Keys.Right:
            case Keys.Home:
            case Keys.End:
            case Keys.PageDown:
            case Keys.PageUp:
                return true;
            default:
                return !dataGridViewWantsInputKey;
        }
    }
    public Cursor EditingPanelCursor
    {
        get { return base.Cursor; }
    }
    public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
    {
        return EditingControlFormattedValue;
    }
    public void PrepareEditingControlForEdit(bool selectAll)
    {
    }
    public bool RepositionEditingControlOnValueChange
    {
        get { return false; }
    }

    #endregion

}
