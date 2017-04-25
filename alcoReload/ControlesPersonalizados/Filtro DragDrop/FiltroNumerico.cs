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
    public partial class FiltroNumerico : UserControl
    {
        #region delg
        public delegate void Cambiar_Coincidencia(object sender, CambioCoincidenciaEventArgs e);
        public delegate void Value_Changed(object sender, EventArgs e);
        public event Cambiar_Coincidencia CambiarCoincidencia;
        protected virtual void OnCambiar_Coincidencia(CambioCoincidenciaEventArgs e)
        {
            CambiarCoincidencia?.Invoke(this, e);
        }
        public event Value_Changed ValueChanged;
        protected virtual void OnValue_Changed(EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }
        #endregion
        #region props
        public decimal Value
        {
            get
            {
                return nudfiltro.Value;
            }

            set
            {
                nudfiltro.Value = value;
            }
        }
        public decimal ValorMaximo
        {
            get { return nudfiltro.Maximum; }
            set { nudfiltro.Maximum = value; }
        }
        public decimal ValorMinimo
        {
            get { return nudfiltro.Minimum; }
            set { nudfiltro.Minimum = value; }
        }
        public GridFiltrado.Elementos_Grid.TipoCoincidencia TipoCoincidencia
        {
            get
            {
                switch (cbtipofiltro.SelectedIndex)
                {
                    case 0:
                        return GridFiltrado.Elementos_Grid.TipoCoincidencia.IGUALQUE;                        
                    case 1:
                        return GridFiltrado.Elementos_Grid.TipoCoincidencia.MAYORQUE;
                    case 2:
                        return GridFiltrado.Elementos_Grid.TipoCoincidencia.MENORQUE;
                    case 3:
                        return GridFiltrado.Elementos_Grid.TipoCoincidencia.MAYOROIGUALQUE;
                    case 4:
                        return GridFiltrado.Elementos_Grid.TipoCoincidencia.MENORIGUALQUE;
                }
                return GridFiltrado.Elementos_Grid.TipoCoincidencia.IGUALQUE;
            }
            set
            {
                switch (value)
                {
                    case GridFiltrado.Elementos_Grid.TipoCoincidencia.IGUALQUE:
                        cbtipofiltro.SelectedIndex = 0;
                        break;
                    case GridFiltrado.Elementos_Grid.TipoCoincidencia.MAYORQUE:
                        cbtipofiltro.SelectedIndex = 1;
                        break;
                    case GridFiltrado.Elementos_Grid.TipoCoincidencia.MENORQUE:
                        cbtipofiltro.SelectedIndex = 2;
                        break;
                    case GridFiltrado.Elementos_Grid.TipoCoincidencia.MAYOROIGUALQUE:
                        cbtipofiltro.SelectedIndex = 3;
                        break;
                    case GridFiltrado.Elementos_Grid.TipoCoincidencia.MENORIGUALQUE:
                        cbtipofiltro.SelectedIndex = 4;
                        break;                    
                }                
            }
        }
        public int Decimales
        {
            get { return nudfiltro.DecimalPlaces; }
            set { nudfiltro.DecimalPlaces=value; }
        }
        #endregion
        public FiltroNumerico()
        {
            InitializeComponent();
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

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                OnValue_Changed(new EventArgs());
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void nudfiltro_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                OnValue_Changed(new EventArgs());
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
    }
}
