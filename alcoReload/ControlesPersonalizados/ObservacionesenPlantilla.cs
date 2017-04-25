using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    
    public partial class ObservacionesenPlantilla : UserControl
    {
        #region Variables
        private int id=0;
        #endregion
        #region Constructor
        public ObservacionesenPlantilla()
        {
            InitializeComponent();
        }
        #endregion
        #region Propiedades
        public bool Imprimir
        {
            get { return cbimprimir.Checked; }
            set { cbimprimir.Checked = value; }
        }
        public string Observacion
        {
            get { return rtbobservacion.Text; }
            set { rtbobservacion.Text = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion
        #region Delegados
        public event Cancelar_Click cancelar_Click;
        protected virtual void OnCancelar_Click(EventArgs e)
        {
            if (cancelar_Click != null)
            {
                cancelar_Click(this, e);
            }
        }
        #endregion

        private void btncancel_Click(object sender, EventArgs e)
        {
            try
            {
                OnCancelar_Click(e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
