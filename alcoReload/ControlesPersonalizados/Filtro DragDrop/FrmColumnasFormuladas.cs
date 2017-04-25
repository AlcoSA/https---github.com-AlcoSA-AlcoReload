using System;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace ControlesPersonalizados.Filtro_DragDrop
{
    public partial class FrmColumnasFormuladas : Form
    {
        #region vars
        private ReadOnlyCollection<GridFiltrado.Elementos_Grid.ColumnaFormulada> cols_formuladas;
        private List<string> lista_eliminados;
        #endregion
        #region ctor
        public FrmColumnasFormuladas()
        {
            InitializeComponent();
        }
        #endregion
        #region props
        public ReadOnlyCollection<GridFiltrado.Elementos_Grid.ColumnaFormulada> Columnas_Formuladas
        {
            set { cols_formuladas = value; }
        }
        public string Columna_Seleccionada
        {
            get { return Convert.ToString(lbcolumnasformuladas.SelectedItem); }
        }

        public List<string> Eliminados
        {
            get { return lista_eliminados; }
        }
        #endregion


        private void btonCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void FrmColumnasFormuladas_Load(object sender, EventArgs e)
        {
            try
            {
                if (cols_formuladas != null)
                {
                    foreach (var cf in cols_formuladas)
                    {
                        lbcolumnasformuladas.Items.Add(cf.Nombre_Columna);
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void btonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void lbcolumnasformuladas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (lbcolumnasformuladas.SelectedIndex != 0)
                {
                    if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                    {
                        lista_eliminados.Add(Convert.ToString(lbcolumnasformuladas.SelectedItem));
                        lbcolumnasformuladas.Items.RemoveAt(lbcolumnasformuladas.SelectedIndex);
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
