using System;
using System.Windows.Forms;
using Formulador;
using System.Drawing;

namespace ControlesPersonalizados
{
    public partial class DibujosPlantilla : UserControl
    {
        #region Variables
        private int id;
        private AnalizadorLexico analizador;
        private bool ignorarfactorvisibilidad = true;
        #endregion
        #region Constructor
        public DibujosPlantilla()
        {
            InitializeComponent();
            dDxf.IgnorarFactorVisibilidad = ignorarfactorvisibilidad;
        }
        #endregion
        #region Propiedades
        public string Predeterminado
        {
            get {
                if (Convert.ToString(txtpredeterminado.Tag).StartsWith("="))
                { return Convert.ToString(txtpredeterminado.Tag); }
                else
                { return txtpredeterminado.Text; }
                 }
            set {
                if (value.StartsWith("="))
                {
                    txtpredeterminado.Tag = value;
                    if (analizador != null)
                    {
                        txtpredeterminado.Text = analizador.EjecutarExpresion(value.Remove(0,1));
                    }                    
                }
                else
                { txtpredeterminado.Text = value; }
                 }
        }
        public string Nombre
        {
            get { return txtnombre.Text; }
            set { txtnombre.Text = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public bool PlantillaVidrio
        {
            get { return cbplantillavidrio.Checked; }
            set { cbplantillavidrio.Checked = value; }
        }
        public AnalizadorLexico AnalizadorSintactico
        {
            get { return analizador; }
            set
            {
                analizador = value;
                dDxf.Analizador = this.analizador;
                if(Convert.ToString(txtpredeterminado.Tag).StartsWith("="))
                {
                    txtpredeterminado.Text = analizador.EjecutarExpresion(Convert.ToString(txtpredeterminado.Tag).Remove(0, 1));
                }
            }
        }
        public bool SoloLectura
        {
            set
            {
                txtnombre.ReadOnly = value;
                btnformular.Enabled = !value;
                txtpredeterminado.ReadOnly = value;
                btncancelar.Enabled = !value;
                dDxf.SoloLectura = value;
            }
        }
        public bool IgnorarFactorVisibilidad
        {
            get { return ignorarfactorvisibilidad; }
            set { ignorarfactorvisibilidad = value; }
        }
        #endregion        
        #region Procedimientos
        public string ObtenerStrImagen()
        {
            return dDxf.ObtenerDxf();
        }
        public void LeerImagen(string dxf)
        {
            try
            {
             if(!string.IsNullOrEmpty(dxf))   dDxf.LeerDxf(dxf);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool ContieneAnticondensaciones()
        {
            return dDxf.Ventana.ContieneAnticondensaciones();
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
        #region Eventos
        private void btncancelar_Click(object sender, EventArgs e)
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
        #endregion
        private void btnformular_Click(object sender, EventArgs e)
        {
                Formulador.Formularios_Ayuda.FrmFormulador fform = new Formulador.Formularios_Ayuda.FrmFormulador();
                fform.Analizador = analizador;
                if (Convert.ToString(txtpredeterminado.Tag).StartsWith("="))
                {
                    fform.Formula = Convert.ToString(txtpredeterminado.Tag).Remove(0, 1);
                }
                else
                {
                    fform.Formula = txtpredeterminado.Text;
                }
                if (fform.ShowDialog() == DialogResult.OK)
                {
                    txtpredeterminado.Tag = "=" + fform.Formula;
                    txtpredeterminado.Text = fform.Valor;
                }
        }
        private void txtpredeterminado_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (cbplantillavidrio.Checked)
                { e.Handled = true; }
                if ((e.KeyCode == Keys.D0 && e.Shift))
                {
                    Formulador.Formularios_Ayuda.FrmFormuladorMin fform = new Formulador.Formularios_Ayuda.FrmFormuladorMin();
                    fform.FormBorderStyle = FormBorderStyle.None;
                    fform.StartPosition = FormStartPosition.Manual;
                    if (Convert.ToString(((TextBox)sender).Tag).StartsWith("="))
                    {
                        fform.Formula = Convert.ToString(((TextBox)sender).Tag).Remove(0, 1);
                    }
                    else
                    {
                        fform.Formula = ((TextBox)sender).Text;
                    }
                    fform.Analizador = analizador;
                    Point p = txtpredeterminado.PointToScreen(new Point(0, 0));
                    fform.Location = new Point(p.X, p.Y + txtpredeterminado.Height);
                    if (fform.ShowDialog() == DialogResult.OK)
                    {
                        txtpredeterminado.Tag = "=" + fform.Formula;
                        txtpredeterminado.Text = fform.Valor;
                    }
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void cbplantillavidrio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox ch = (CheckBox)sender;
                if(ch.Checked)
                {
                    txtpredeterminado.Tag = string.Empty;
                    txtpredeterminado.Text = "0";
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);                
            }
        }
    }
}
