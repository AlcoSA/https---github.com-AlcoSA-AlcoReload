using System;
using System.Drawing;
using System.Windows.Forms;

namespace DXF
{
    public partial class CargadorDXF : UserControl
    {
        #region Variables
        private string dxf = string.Empty;
        private string rutadxf = string.Empty;
        private Importador_DXF.CADImage cadimage = null;
        private bool mousedown = false;
        private Point puntocomparacion;
        #endregion
        public CargadorDXF()
        {
            InitializeComponent();
            cadimage = new Importador_DXF.CADImage();
            puntocomparacion = new Point(0, 0);
        }
        #region Propiedades
        public Image ImagenDXF
        {
            get
            {
                return pbdxf.Image;
            }
        }
        public string RutaDXF
        {
            get
            {
                return rutadxf;
            }
            set
            { rutadxf = value; }
        }
        public string DXFActual
        {
            get
            {
                return dxf;
            }
        }
        #endregion

        #region Procedimientos

        public void cargarDXFdesdeStringdxf(string dxf)
        {
            try
            {                
                if (!string.IsNullOrEmpty(rutadxf))
                {
                    cadimage.Base = new Point(0, this.Bottom);
                    cadimage.LoadFromDXFString(dxf);                    
                    this.dxf = dxf;
                    cadimage.StreamDispose();
                    cargarDXF();
                }
            }
            catch (Exception ex)
            {

                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        public void cargarDXF(string ruta)
        {
            try
            {
                rutadxf = ruta;
                if (!string.IsNullOrEmpty(rutadxf))
                {
                    cadimage.Base = new Point(0, this.Bottom);
                    cadimage.LoadFromFile(rutadxf);
                    System.IO.StreamReader archivortf = new System.IO.StreamReader(ruta);                    
                    dxf = archivortf.ReadToEnd();
                    cadimage.StreamDispose();
                    cargarDXF();                 
                }
            }
            catch (Exception ex)
            {

                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void cargarDXF()
        {
            try
            {
               Bitmap bmp = new Bitmap(pbdxf.Width, pbdxf.Height);
                Graphics g = Graphics.FromImage(bmp);
                cadimage.Draw(g);                
                pbdxf.Image = bmp;                
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        #endregion

        private void btnzoommas_Click(object sender, EventArgs e)
        {
            try
            {
                cadimage.FScale += 0.5F; //cadimage.FScale * 2;
                cargarDXF();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void btnzoommenos_Click(object sender, EventArgs e)
        {
            try
            {
                if (cadimage.FScale > 0.5F)
                {
                    cadimage.FScale -= 0.5F; //cadimage.FScale * 2;
                    cargarDXF();
                }                
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void pbdxf_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if(mousedown)
                {
                    cadimage.Base = new Point(cadimage.Base.X - ((puntocomparacion.X - e.X)),
                        cadimage.Base.Y - ((puntocomparacion.Y - e.Y)));
                    puntocomparacion = new Point(e.X, e.Y);
                    cargarDXF();
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void pbdxf_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    mousedown = false;
                    puntocomparacion = new Point(0, 0);
                    cargarDXF();
                }                
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void pbdxf_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    mousedown = true;
                    puntocomparacion = new Point(e.X, e.Y);
                }                
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void btnnormalizar_Click(object sender, EventArgs e)
        {
            try
            {
                cadimage.Base = new Point(0,this.Bottom);
                cadimage.FScale = 1;
                cargarDXF();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
    }
}
