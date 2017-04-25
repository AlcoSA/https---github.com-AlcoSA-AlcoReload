using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlesPersonalizados.Filtro_DragDrop
{
    public partial class FiltroTexto : UserControl
    {
        #region delg
        public delegate void Cambiar_Coincidencia(object sender, CambioCoincidenciaEventArgs e);
        public event Cambiar_Coincidencia CambiarCoincidencia;
        protected virtual void OnCambiar_Coincidencia(CambioCoincidenciaEventArgs e)
        {
            CambiarCoincidencia?.Invoke(this, e);
        }
       
        #endregion

        #region ctor
        public FiltroTexto()
        {
            InitializeComponent();
            cbtipofiltro.SelectedIndex = 0;
        }
        #endregion

        #region props
        public override string Text
        {
            get
            {
                return txtfiltro.Text;
            }

            set
            {
                txtfiltro.Text = value;
            }
        }
        public GridFiltrado.Elementos_Grid.TipoCoincidencia TipoCoincidencia
        {
            get
            {
                if (cbtipofiltro.SelectedIndex == 0)
                {
                    return GridFiltrado.Elementos_Grid.TipoCoincidencia.COMO;
                }
                else
                {
                    return GridFiltrado.Elementos_Grid.TipoCoincidencia.IGUALQUE;
                }
            }
            set
            {
                cbtipofiltro.SelectedIndex = value == GridFiltrado.Elementos_Grid.TipoCoincidencia.COMO?0:1;                
            }
        }
        #endregion

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                OnTextChanged(new EventArgs());

            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (cbtipofiltro.SelectedIndex == 0)
                {
                    OnTextChanged(new EventArgs());
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void cbtipofiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OnCambiar_Coincidencia(new CambioCoincidenciaEventArgs(TipoCoincidencia));
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
    }
}
