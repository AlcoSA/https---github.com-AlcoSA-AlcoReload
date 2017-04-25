using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace SpecialColumns
{
    [ToolboxBitmapAttribute(typeof(ProgressBar))]
    public class DataGridViewProgressBarColumn : DataGridViewColumn
    {
        #region ctor
        public DataGridViewProgressBarColumn(): base(new DataGridViewProgressBarCell())
        {
        }
        #endregion

        #region props
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DataGridViewProgressBarCell)))
                {
                    throw new InvalidCastException("Debe ser una celda de tipo Barra de Progreso");
                }
                base.CellTemplate = value;
            }
        }
        /// <summary>
        /// Este procedimiento sirve para validar que la barra tenga información y pintarla en pantalla
        /// </summary>
        [Browsable(true)]
        public Color ColorBarra
        {
            get
            {

                if (this.CeldaProgresoPLantilla == null)
                {
                    throw new InvalidOperationException("El procedimiento no puede ser completado, porque no se ha definido correctamente la plantilla de la celda");
                }
                return this.CeldaProgresoPLantilla.Color;

            }
            set
            {

                if (this.CeldaProgresoPLantilla == null)
                {
                    throw new InvalidOperationException("El procedimiento no puede ser completado, porque no se ha definido correctamente la plantilla de la celda");
                }
                this.CeldaProgresoPLantilla.Color = value;
                if (this.DataGridView != null)
                {
                    DataGridViewRowCollection dataGridViewRows = this.DataGridView.Rows;
                    int rowCount = dataGridViewRows.Count;
                    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                    {
                        DataGridViewRow dataGridViewRow = dataGridViewRows.SharedRow(rowIndex);
                        DataGridViewProgressBarCell dataGridViewCell = dataGridViewRow.Cells[this.Index] as DataGridViewProgressBarCell;
                        if (dataGridViewCell != null)
                        {
                            dataGridViewCell.DarColor(rowIndex, value);
                        }
                    }
                    this.DataGridView.InvalidateColumn(this.Index);

                }
            }
        }
        #endregion

        #region Eventos, Procedimientos y Funciones
        private DataGridViewProgressBarCell CeldaProgresoPLantilla
        {
            get
            {
                return (DataGridViewProgressBarCell)this.CellTemplate;
            }
        }
        #endregion
    }
}
