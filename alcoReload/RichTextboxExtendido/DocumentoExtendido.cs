using System;
using System.Drawing;
using System.Windows.Forms;

namespace RichTextboxExtendido
{
    public partial class DocumentoExtendido : UserControl
    {
        #region Variables
        float hheight = 1.25F;
        float fheight = 1.25F;
        Size psize = new Size(21, 27);
        Padding mmargin = new Padding(3, 2, 3, 2);
        RichTextBox cpart = null;
        #endregion

        public DocumentoExtendido()
        {
            InitializeComponent();
        }

        #region  Propiedades
        /// <summary>
        /// Este procedimiento convierte los centímetros del encabezado a pixeles
        /// </summary>
        public float HeaderHeightCm
        {
            get { return hheight; }
            set
            {
                fheight = value;
                tlpBaseDoc.RowStyles[0].Height = YCmtoPixels(value);
            }
        }

        /// <summary>
        /// Este procedimiento convierte los centímetros del pie de página a pixeles
        /// </summary>
        public float FooterHeightCm
        {
            get { return fheight; }
            set
            {
                fheight = value;
                tlpBaseDoc.RowStyles[2].Height = YCmtoPixels(value);
            }
        }

        /// <summary>
        /// Este procedimiento permite cambiar el tamaño a los márgenes de la página
        /// </summary>
        public Padding ThisMarginCm
        {
            get
            { return mmargin; }
            set
            {
                mmargin = value;
                this.Padding = new Padding((int)Math.Ceiling(XCmtoPixels(value.Left)),
                   (int)Math.Ceiling(YCmtoPixels(value.Top)) - (int)Math.Ceiling(tlpBaseDoc.RowStyles[0].Height), (int)Math.Ceiling(XCmtoPixels(value.Right)),
                    (int)Math.Ceiling(YCmtoPixels(value.Bottom)) - (int)Math.Ceiling(tlpBaseDoc.RowStyles[2].Height));
            }
        }

        public RichTextBox Header
        {
            get
            {
                return txtheader;
            }
        }

        public RichTextBox Body
        {
            get
            {
                return txtbody;
            }
        }

        public RichTextBox Footer
        {
            get
            {
                return txtfooter;
            }
        }
        /// <summary>
        /// Este procedimiento permite cambiar el tamaño de la página, por ejemplo,
        /// tamaño carta, tamaño oficio, entre otros.
        /// </summary>
        public Size PageSizeCm
        {
            get { return psize; }
            set
            {
                psize = value;
                int mcwidth = (int)Math.Ceiling(XCmtoPixels(value.Width));
                int mcheight = (int)Math.Ceiling(YCmtoPixels(value.Height));
                //this.Size = new Size(mcwidth, mcheight);
                //this.MaximumSize = new Size(mcwidth, mcheight);
                //this.MinimumSize = new Size(mcwidth, mcheight);
            }
        }

        public Size PageSize
        {
            get
            {
                int mcwidth = (int)Math.Ceiling(XCmtoPixels(psize.Width));
                int mcheight = (int)Math.Ceiling(YCmtoPixels(psize.Height));
                return new Size(mcwidth, mcheight);
            }
        }

        public RichTextBox CurrentDocumentPart
        {
            get {
                if (cpart == null)
                { return txtbody; }
                else
                { return cpart; }
                 }
        }

        #endregion

        #region Procedimientos
        /// <summary>
        /// Este procedimiento convierte los centímetros de alto del documento a pixeles
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        private float YCmtoPixels(float cm)
        {
            try
            {
                return cm * this.CreateGraphics().DpiY / 2.54F;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Este procedimiento convierte los centímetros de ancho del documento a pixeles
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        private float XCmtoPixels(float cm)
        {
            try
            {
                return cm * this.CreateGraphics().DpiX / 2.54F;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <summary>
        /// Este procedimiento envía el documento a la impresora
        /// </summary>
        public void Print()
        {
            Extension.Imprimir(this);
        }

        /// <summary>
        /// Este procedimiento permite la vista previa del documento a imprimir
        /// </summary>
        public void Visualize()
        {
            Extension.Visualizar(this);
        }

        #endregion

        /// <summary>
        /// Este evento se activa cuando el usuario da doble click en el encabezado o al
        /// pie de página del documento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dpart_Sec_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ((RichTextBox)sender).ReadOnly = false;
                ((RichTextBox)sender).Cursor = System.Windows.Forms.Cursors.IBeam;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Este procedimiento sirve para proteger el encabezado y el pie de página y saltar estos espacios cuando se está
        /// digitando, también cambia el cursor a flecha cuando está sobre estos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dpart_Sec_Leave(object sender, EventArgs e)
        {
            try
            {
                ((RichTextBox)sender).ReadOnly = true;
                ((RichTextBox)sender).Cursor = System.Windows.Forms.Cursors.Arrow;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DocPart_Enter(object sender, EventArgs e)
        {
            cpart = ((RichTextBox)sender);
        }

        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //private extern static int GetWindowLong(IntPtr hWnd, int index);

        //public static bool VerticalScrollBarVisible(Control ctl)
        //{
        //    int style = GetWindowLong(ctl.Handle, -16);
        //    return (style & 0x200000) != 0;
        //}

        private void txtbody_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            if (e.NewRectangle.Height > this.PageSize.Height)
            {      
                this.MaximumSize = new Size(this.PageSize.Width, this.PageSize.Height + (e.NewRectangle.Height - this.PageSize.Height) + 100);
                this.Height = this.MaximumSize.Height + 100;
            }
            else
            {
                this.MaximumSize = new Size(this.PageSize.Width, this.PageSize.Height + 100);
                this.Height = this.MaximumSize.Height + 100;
            }
        }
    }
}
