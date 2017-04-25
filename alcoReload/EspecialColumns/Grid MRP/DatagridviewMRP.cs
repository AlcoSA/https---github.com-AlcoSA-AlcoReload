using System;
using System.Windows.Forms;

namespace EspecialColumns.Grid_MRP
{
    public class DatagridviewMRP : DataGridView
    {
        private Formulador.Formulacion_Grids.AnalizadorDataGridView analiza;
        public DataGridViewCell celdaenuso = null;
        public DatagridviewMRP() : base()
        {
            analiza = new Formulador.Formulacion_Grids.AnalizadorDataGridView(this);
        }
        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {            
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (this[e.ColumnIndex, e.RowIndex].GetType() == typeof(Columna_Formula.FormuleCell))
                {
                    if (Convert.ToString(this[e.ColumnIndex, e.RowIndex].Value).StartsWith("="))
                    {
                        string formula = Convert.ToString(this[e.ColumnIndex, e.RowIndex].Value);
                        ((Columna_Formula.FormuleCell)this[e.ColumnIndex, e.RowIndex]).Formula = formula;
                    }
                    else
                    {
                        ((Columna_Formula.FormuleCell)this[e.ColumnIndex, e.RowIndex]).Formula = string.Empty;
                    }
                }
            }
            celdaenuso = null;
            base.OnCellEndEdit(e);
        }
        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            base.OnCellBeginEdit(e);
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (this[e.ColumnIndex, e.RowIndex].GetType() == typeof(Columna_Formula.FormuleCell))
                {
                    if (!string.IsNullOrEmpty(((Columna_Formula.FormuleCell)this[e.ColumnIndex, e.RowIndex]).Formula))
                    {
                        string f = ((Columna_Formula.FormuleCell)this[e.ColumnIndex, e.RowIndex]).Formula;
                        ((Columna_Formula.FormuleCell)this[e.ColumnIndex, e.RowIndex]).Formula = Convert.ToString(this[e.ColumnIndex, e.RowIndex].Value);
                        this[e.ColumnIndex, e.RowIndex].Value = f;

                    }                    
                }
            }
            celdaenuso = this[e.ColumnIndex, e.RowIndex];
        }        
        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            if (this.EditingControl != null)
            {
                if (this.EditingControl.GetType() == typeof(Columna_Formula.FormuleEditingControl))
                {
                    if (e.ColumnIndex > -1 && e.RowIndex > -1)
                    {
                        if (celdaenuso != this[e.ColumnIndex, e.RowIndex])
                        {
                            this.EditingControl.Text += "TABLA(" + e.RowIndex.ToString() + ", " + e.ColumnIndex.ToString() + ")";
                            ((Columna_Formula.FormuleEditingControl)this.EditingControl).SelectionStart = ((Columna_Formula.FormuleEditingControl)this.EditingControl).TextLength;
                        }
                        else
                        {
                            base.OnCellMouseDown(e);
                        }
                    }                   
                }
                else
                {
                    base.OnCellMouseDown(e);
                }
            }
            else
            {
                base.OnCellMouseDown(e);
            }
            
            
        }
        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            base.OnEditingControlShowing(e);
            if (e.Control.GetType() == typeof(Columna_Formula.FormuleEditingControl))
            {
                //e.Control.TextChanged -= Control_TextChanged;
                e.Control.TextChanged += Control_TextChanged;
            }
        }
        private void Control_TextChanged(object sender, EventArgs e)
        {
            if (celdaenuso != null)
            {
                System.Drawing.Size s = this.CreateGraphics().MeasureString(((Columna_Formula.FormuleEditingControl)sender).Text, this.Font).ToSize();
                if (celdaenuso.OwningColumn.MinimumWidth > s.Width)
                {
                    celdaenuso.OwningColumn.Width = s.Width;
                }
            }
        }
        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            base.OnCellValueChanged(e);
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {                
                for (int j = 0; j < this.Columns.Count; j++)
                {
                    if (this.Columns[j].GetType() == typeof(Columna_Formula.FormuleGridColumn))
                    {
                        for (int i = 0; i < this.Rows.Count; i++)
                        {
                            string formula = ((Columna_Formula.FormuleCell)this[j, i]).Formula;
                            if (formula.StartsWith("="))
                            {
                                ((Columna_Formula.FormuleCell)this[j, i]).Formula = formula;
                            }
                        }
                    }
                }
            }
        }
    }
}
