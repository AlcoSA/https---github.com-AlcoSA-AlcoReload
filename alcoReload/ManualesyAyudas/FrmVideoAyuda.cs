using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ManualesyAyudas
{
    public partial class FrmVideoAyuda : Form
    {
        #region Variables
        private string rutavideo;        
        #endregion

        #region Propiedades
        public string NombreAyuda
        {
            get { return lbayuda.Text; }
            set { lbayuda.Text = value; }
        }
        public string RutaVideo
        {
            get { return rutavideo; }
            set { rutavideo = value; }
        }
        #endregion

        #region Constructor
        public FrmVideoAyuda()
        {
            InitializeComponent();
        }
        #endregion

        private void FrmVideoAyuda_Shown(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(rutavideo))
                {
                    wmpVideoAyuda.URL = rutavideo;                    
                    tbduracion.Maximum = Convert.ToInt32(wmpVideoAyuda.currentMedia.duration);
                    lbtotalreproduccion.Text = wmpVideoAyuda.currentMedia.durationString;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmVideoAyuda_Load(object sender, EventArgs e)
        {
            try
            {
                wmpVideoAyuda.uiMode = "none";
                wmpVideoAyuda.settings.volume = tbvolumen.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void wmpVideoAyuda_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            try
            {
                if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsStopped)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnreproducir_Click(object sender, EventArgs e)
        {
            try
            {
                wmpVideoAyuda.Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnparar_Click(object sender, EventArgs e)
        {
            try
            {
                wmpVideoAyuda.Ctlcontrols.stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnpausar_Click(object sender, EventArgs e)
        {
            try
            {
                wmpVideoAyuda.Ctlcontrols.pause();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmVideoAyuda_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                wmpVideoAyuda.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void wmpVideoAyuda_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            try
            {
                lbtotalreproduccion.Text = wmpVideoAyuda.currentMedia.durationString;
                tbduracion.Maximum = Convert.ToInt32(wmpVideoAyuda.currentMedia.duration);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mreproduccion_Tick(object sender, EventArgs e)
        {
            try
            {
                if (wmpVideoAyuda.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    lbestadoreproduccion.Text = wmpVideoAyuda.Ctlcontrols.currentPositionString;
                    tbduracion.Value = Convert.ToInt32(wmpVideoAyuda.Ctlcontrols.currentPosition);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnrepetir_Click(object sender, EventArgs e)
        {
            try
            {
                wmpVideoAyuda.Ctlcontrols.currentPosition = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbduracion_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                wmpVideoAyuda.Ctlcontrols.currentPosition = tbduracion.Value;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnvolumen_Click(object sender, EventArgs e)
        {
            try
            {
                wmpVideoAyuda.settings.mute = !wmpVideoAyuda.settings.mute;
                if (wmpVideoAyuda.settings.mute == true)
                {
                    ((Button)sender).Image = Properties.Resources.Sonido_Inactivo_16x16;
                }
                else
                {
                    ((Button)sender).Image = Properties.Resources.Sonido_Activo_16x16;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbvolumen_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                wmpVideoAyuda.settings.volume = tbvolumen.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
