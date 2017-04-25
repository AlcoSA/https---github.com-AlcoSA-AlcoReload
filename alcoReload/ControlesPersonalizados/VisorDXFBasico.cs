using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public delegate void Cargar_Click(object sender, EventArgs e);
    public delegate void Cancelar_Click(object sender, EventArgs e);
    public partial class VisorDXFBasico : UserControl
    {
        #region Variables
        private int id;
        #endregion
        #region Propiedades
        public string Descripcion
        {
            get { return txtdescripcion.Text; }
            set { txtdescripcion.Text = value; }
        }
        public string DXF
        {
            get { return pbcargadxf.DXFActual; }            
        }
        public Image ImagenDXF
        {
            get { return pbcargadxf.ImagenDXF; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion
        #region Constructor
        public VisorDXFBasico()
        {
            InitializeComponent();
        }
        #endregion
        #region Delegados
        public event Cargar_Click cargar_Click;
        public event Cancelar_Click cancelar_Click;
        protected virtual void OnCargar_Click(EventArgs e)
        {
            if (cargar_Click != null)
            {
                cargar_Click(this, e);
            }
        }
        protected virtual void OnCancelar_Click(EventArgs e)
        {
            if (cancelar_Click != null)
            {
                cancelar_Click(this, e);
            }
        }
        #endregion
        #region Procedimientos
        public void CargarDXFdesdeRuta(string ruta)
        {
            try
            {
                pbcargadxf.cargarDXF(ruta);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void CargarDXFdesdedxf(string dxf)
        {
            try
            {
                pbcargadxf.cargarDXFdesdeStringdxf(dxf);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion

        private void btncargar_Click(object sender, EventArgs e)
        {
            try
            {
                OnCargar_Click(new EventArgs());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                OnCancelar_Click(new EventArgs());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }            
        }

        private void pbcargadxf_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.Control && e.KeyCode == Keys.V)
                {
                    if (Clipboard.ContainsFileDropList())
                    {
                        string ruta = Clipboard.GetFileDropList()[0];
                        if (System.IO.Path.GetExtension(ruta).Equals(".dxf"))
                        {
                            CargarDXFdesdeRuta(ruta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
