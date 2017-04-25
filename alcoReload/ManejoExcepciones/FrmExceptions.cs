using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ManejoExcepciones
{
    public partial class FrmExceptions : Form
    {
        #region Variables
        private Exception ex;
        private TipoExcepcion tipoexcepcion = TipoExcepcion.Critica;
        #endregion

        #region Propiedades
        public Exception Excepcion
        {
            get { return ex; }
            set { ex = value;
                pgpropiedades.SelectedObject = ex;
                lbmensaje.Text = ex.Message;
            }
        }

        public TipoExcepcion TipoExcepcion
        {
            get { return tipoexcepcion; }
            set { tipoexcepcion = value;
                switch (tipoexcepcion)
                {
                    case TipoExcepcion.Critica:
                        pbicono.Image = iml.Images[0];
                        break;
                    case TipoExcepcion.Advertencia:
                        pbicono.Image = iml.Images[1];
                        break;
                }
            }
        }
        
        #endregion
        #region Procedimientos
        private Bitmap capturarPantalla()
        {
            Rectangle tamanoEscritorio = Screen.PrimaryScreen.Bounds;
            Bitmap objBitmap = new Bitmap(tamanoEscritorio.Width,
                tamanoEscritorio.Height);
            Graphics objGrafico = Graphics.FromImage(objBitmap);
            objGrafico.CopyFromScreen(0, 0, 0, 0, objBitmap.Size);
            Thread.Sleep(1000);

            objGrafico.Flush();
            return objBitmap;
        }
        #endregion
        public FrmExceptions()
        {
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbenviar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add("analista1@alco.com.co");
            mmsg.To.Add("camiloa@alco.com.co");
            mmsg.To.Add("svallejo@alco.com.co");
            mmsg.Subject = "Error de aplicación";
            mmsg.Body = "<html>" + "\n";
            mmsg.Body += "<body>" + "\n";
            mmsg.Body += "<p> <b> Fecha: </b>" + DateTime.Now.ToString() + "</p>" + "\n";
            mmsg.Body += "<p> <b> Usuario: </b>" + Properties.Settings.Default.Usuario + "</p>" + "\n";

            GridItem g = pgpropiedades.SelectedGridItem;
            if (g.Parent != null)
            { g = g.Parent; }

            mmsg.Body += "<table border = 1>" + "\n";
            mmsg.Body += "<tr><th colspan=2><h1>Descripción error</h1></th></tr>" + "\n";
            mmsg.Body += " <tr><th><b>Propiedad</b></th><th><b>Valor</b></th></tr>" + "\n";
            mmsg.Body += "" + "\n";
            mmsg.Body += "" + "\n";
            foreach (GridItem a in g.GridItems)
            {
                mmsg.Body += "<tr><td>" + Convert.ToString(a.Label) + "</td><td>" + Convert.ToString(a.Value) + "</td></tr>" + "\n";
            }
            mmsg.Body += "<tr><td>" + gbdescripcionsituacion.Text + "</td><td>" + rtbdescripcion.Text + "</td></tr>" + "\n";
            mmsg.Body += "</table> " + "\n";
            mmsg.Body += "</body>" + "\n";
            mmsg.Body += "</html>" + "\n";
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            try
            {
                mmsg.From = new System.Net.Mail.MailAddress("alco@alco.com.co");
                this.Hide();
                capturarPantalla().Save(Path.Combine(Path.GetTempPath(), "Error.png"), System.Drawing.Imaging.ImageFormat.Png);
                this.Show();
                mmsg.Attachments.Add(new System.Net.Mail.Attachment(Path.Combine(Path.GetTempPath(), "Error.png")));
            }
            catch (Exception)
            {                
            }            
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials =
                new System.Net.NetworkCredential("alco@alco.com.co", "alco2016");
            cliente.Host = "mail.alco.com.co";
            try
            {    
                cliente.Send(mmsg);                
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void FrmExceptions_Load(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Exclamation.Play();
            System.Threading.Thread.Sleep(250);
        }
    }
}
