using System;
using System.Windows.Forms;

namespace EspecialColumns.TreeGrid_MRP
{
    public class TreeGridViewMRP : DatagridTreeView.DataTreeGridView
    {
        public DataGridViewCell celdaenuso = null;
        private Formulador.Formulacion_Grids.AnalizadorTreeGridview analiza;
        public TreeGridViewMRP() : base()
        {
            analiza = new Formulador.Formulacion_Grids.AnalizadorTreeGridview(this);
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
                        DatagridTreeView.DataGridViewTreeNode nO = (DatagridTreeView.DataGridViewTreeNode)celdaenuso.OwningRow;
                        DatagridTreeView.DataGridViewTreeNode nN = (DatagridTreeView.DataGridViewTreeNode)this.Rows[e.RowIndex];
                       
                        if (celdaenuso != this[e.ColumnIndex, e.RowIndex])
                        {
                            if (nO.Level > 1)
                            {
                                if (nO.Parent == nN)
                                {
                                    this.EditingControl.Text += "PADRE(" + nN.Index.ToString() + ").VALOR(" + e.ColumnIndex.ToString() + ")";
                                }
                                else if (nO.Parent == nN.Parent)
                                {
                                    this.EditingControl.Text += "PADRE(" + nN.Parent.Index.ToString() + ").HIJO(" + nN.Index + "," +  e.ColumnIndex.ToString() + ")";
                                }                                
                            }
                            else if (nO.Level == 1)
                            {
                                if (nO == nN)
                                {
                                    this.EditingControl.Text += "PADRE(" + nN.Index.ToString() + ").VALOR(" + e.ColumnIndex.ToString() + ")";
                                }
                                else if (nO.Nodes.Contains(nN))
                                {
                                    this.EditingControl.Text += "PADRE(" + nN.Parent.Index.ToString() + ").HIJO(" + nN.Index + "," + e.ColumnIndex.ToString() + ")";
                                }
                            }
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
        protected override void OnCellValueChanged(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1) 
                {
                    if (!Convert.ToString(this[e.ColumnIndex, e.RowIndex].Value).StartsWith("="))
                    {
                        base.OnCellValueChanged(e);
                        for (int j = 0; j < this.Columns.Count; j++)
                        {
                            if (this.Columns[j].GetType() == typeof(Columna_Formula.FormuleGridColumn))
                            {
                                for (int i = 0; i < this.Nodes.Count; i++)
                                {
                                    string formula_p = ((Columna_Formula.FormuleCell)this.Nodes[i].Cells[j]).Formula;
                                    if (formula_p.StartsWith("="))
                                    {
                                        ((Columna_Formula.FormuleCell)this.Nodes[i].Cells[j]).Formula = formula_p;
                                    }
                                    for (int n = 0; n < this.Nodes[i].Nodes.Count; n++)
                                    {
                                        string formula_n = ((Columna_Formula.FormuleCell)this.Nodes[i].Nodes[n].Cells[j]).Formula;
                                        if (formula_n.StartsWith("="))
                                        {
                                            ((Columna_Formula.FormuleCell)this.Nodes[i].Nodes[n].Cells[j]).Formula = formula_n;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }   
        }
        
        
    }
}