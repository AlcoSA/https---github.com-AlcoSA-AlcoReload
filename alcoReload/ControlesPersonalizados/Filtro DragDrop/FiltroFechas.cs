using System;
using System.Windows.Forms;

namespace ControlesPersonalizados.Filtro_DragDrop
{
    public partial class FiltroFechas : UserControl
    {        
        public FiltroFechas()
        {
            InitializeComponent();
        }

        #region Propiedades

        public DateTime FechaDesde
        {
            get
            { return dtpdesde.Value; }
            set { dtpdesde.Value = value; }
        }

        public DateTime FechaHasta
        {
            get
            { return dtphasta.Value; }
            set { dtphasta.Value = value; }
        }

        #endregion
        #region Delegados
        public delegate void filtrar_Click(object sender, EventArgs e);
        public event filtrar_Click FiltrarButton_Click;
        protected virtual void OnFiltrar_Click(EventArgs e)
        {
            if (FiltrarButton_Click != null)
            {
                FiltrarButton_Click(this, e);
            }
        }
        #endregion

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                OnFiltrar_Click(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpdesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtphasta.MinDate = dtpdesde.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtphasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpdesde.MaxDate = dtphasta.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
