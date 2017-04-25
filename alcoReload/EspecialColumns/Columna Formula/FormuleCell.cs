using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EspecialColumns.Columna_Formula
{
   public class FormuleCell : DataGridViewTextBoxCell
    {

        #region Variables
        private string formula= string.Empty;
        #endregion
        #region Constructor
        public FormuleCell() : base()
        {
            formula = string.Empty;
        }        
        #endregion
        #region Propiedades

        public override Type EditType
        {
            get { return typeof(FormuleEditingControl); }
        }

        public string Formula
        {
            get { return formula;}
            set { formula = value;
                if (formula.StartsWith("="))
                {
                    if (this.DataGridView.GetType() == typeof(TreeGrid_MRP.TreeGridViewMRP))
                    {
                        Formulador.Formulacion_Grids.AnalizadorTreeGridview analiza = new Formulador.Formulacion_Grids.AnalizadorTreeGridview((DatagridTreeView.DataTreeGridView)DataGridView);
                        analiza.Verificar(formula);
                        if (analiza.Mensajes.Count > 0)
                        {
                            MessageBox.Show(string.Join("\n", analiza.Mensajes.Select(x => x.Mensaje + " => " + x.IndicadorInicio.ToString() + "-" + x.LargoCadena.ToString()).ToArray()));
                            this.Value = "ERROR";
                        }
                        else
                        { this.Value = analiza.Evaluar(formula.Remove(0, 1)); }
                    }
                    else
                    {
                        Formulador.Formulacion_Grids.AnalizadorDataGridView analiza = new Formulador.Formulacion_Grids.AnalizadorDataGridView(this.DataGridView);
                        analiza.Verificar(formula);
                        if (analiza.Mensajes.Count > 0)
                        {
                            MessageBox.Show(string.Join("\n", analiza.Mensajes.Select(x => x.Mensaje + " => " + x.IndicadorInicio.ToString() + "-" + x.LargoCadena.ToString()).ToArray()));
                            this.Value = "ERROR";
                        }
                        else
                        { this.Value = analiza.Evaluar(formula.Remove(0, 1)); }
                    }
                }
            }
        }
        #endregion
                    
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            FormuleEditingControl ctl = DataGridView.EditingControl as FormuleEditingControl;
            try
            {
                if (this.Value == null)
                {
                    ctl.Text = Convert.ToString(this.DefaultNewRowValue);
                }
                else
                {
                    ctl.Text = this.Value.ToString();
                }
            }
            catch (Exception)
            {
                ctl.Text = Convert.ToString(this.DefaultNewRowValue);
            }
            finally { ctl.SelectAll(); }
        }
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {            
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            if (!string.IsNullOrEmpty(formula))
            {
                graphics.DrawImage(Properties.Resources.F_de_X_8x8, cellBounds.X + cellBounds.Width - 10, cellBounds.Y + 2);
            }            
        }       
    }
}
