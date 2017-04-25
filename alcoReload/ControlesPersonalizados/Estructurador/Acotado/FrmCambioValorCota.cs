using System;
using System.Windows.Forms;

namespace ControlesPersonalizados.Estructurador
{
    public partial class FrmCambioValorCota : Form
    {
        public FrmCambioValorCota()
        {
            InitializeComponent();
        }
        #region Propiedades
        public decimal ValorCota
        {
            get { return nudvalorcota.Value; }
            set { nudvalorcota.Value = value; }
        }
        #endregion

        private void btncancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
    }
}
