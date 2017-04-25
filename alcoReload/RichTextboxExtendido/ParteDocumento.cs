using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RichTextboxExtendido
{
    public class ParteDocumento : System.Windows.Forms.RichTextBox
    {
        #region CONSTANTES WinApi

        private const int WM_PAINT = 15;

        #endregion

        #region Variables Generales
        string mdpname = string.Empty;
        bool drawpart = true;
        Color mmarginc = Color.LightGray;
        bool dtopb = true;
        bool dleftb = true;
        bool dbottomb = true;
        bool drightb = true;
        Color bcolor = Color.LightGray;
        bool bmargin = true;

        #endregion

        #region Propiedades

        public String DocumentPartName
        {
            get
            { return mdpname; }
            set
            {
                mdpname = value;
                base.Invalidate();
            }
        }

        public bool DrawPartName
        {
            get { return drawpart; }
            set
            {
                drawpart = value;
                base.Invalidate();
            }
        }

        public Color MarginColor
        {
            get
            { return mmarginc; }
            set
            {
                mmarginc = value;
                base.Invalidate();
            }
        }

        public Color BorderColor
        {
            get
            { return bcolor; }
            set
            {
                bcolor = value;
                base.Invalidate();
            }
        }

        public bool DrawTopBorder
        {
            get { return dtopb; }
            set
            {
                dtopb = value;
                base.Invalidate();
            }
        }
        public bool DrawLeftBorder
        {
            get { return dleftb; }
            set
            {
                dleftb = value;
                base.Invalidate();
            }
        }
        public bool DrawBottomBorder
        {
            get { return dbottomb; }
            set
            {
                dbottomb = value;
                base.Invalidate();
            }
        }
        public bool DrawRightBorder
        {
            get { return drightb; }
            set
            {
                drightb = value;
                base.Invalidate();
            }
        }

        public bool BlockOnMargin
        {
            get { return bmargin; }
            set
            {
                bmargin = value;
                base.Invalidate();
            }
        }

        #endregion

        #region ExtensionBasadaEnAPiWin32
        /// <summary>
        /// Este procedimiento sirve para que el documento sea más dinámico, permitiendo modificaciones de tamaño
        /// e imprimir sin hacer uso de la opción de impresión de VS.
        /// </summary>
        /// <param name="dllName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr LoadLibrary(string dllName);
        protected override CreateParams CreateParams
        {
            get
            {
                if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
                {
                    base.CreateParams.ClassName = "RICHEDIT50W";
                }
                return base.CreateParams;
            }
        }


        #endregion

        /// <summary>
        /// Este procedimiento sirve para pintar el título inicial en la página.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_PAINT:

                    using (Graphics graphic = base.CreateGraphics())
                    {
                        OnPaint(new PaintEventArgs(graphic, base.ClientRectangle));
                        Font mfon = new Font(base.Font.FontFamily, 20F, FontStyle.Bold);
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        Rectangle mrect = new Rectangle(0, 0, base.Width, base.Height);
                        Pen mpen = new Pen(mmarginc);
                        mpen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        if (drawpart && base.TextLength <= 0)
                        {
                            graphic.DrawString(mdpname, mfon, Brushes.LightGray, mrect, sf);
                        }
                        else if (base.ReadOnly && drawpart)
                        {
                            //graphic.FillRectangle(new SolidBrush(Color.FromArgb(50, 255, 255, 255)), mrect);
                        }
                    }

                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Este procedimiento sirve para pintar y dar funcionamiento al botón bajar, ubicado debajo del scrollbar
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            base.Invalidate();

        }

        /// <summary>
        /// Este procedimiento sirve para desactivar la propiedad readonly del documento en pantalla
        /// </summary>
        /// <param name="e"></param>
        protected override void OnReadOnlyChanged(EventArgs e)
        {
            base.OnReadOnlyChanged(e);
            base.Invalidate();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ParteDocumento
            // 
            this.EnableAutoDragDrop = true;
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResumeLayout(false);

        }
    }
}
