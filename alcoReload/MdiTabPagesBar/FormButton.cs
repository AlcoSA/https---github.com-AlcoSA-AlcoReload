using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MdiTabPagesBar
{
    #region Eventos
    public delegate void MdiFormClosedEventHandler(object sender, EventArgs e);
    #endregion
    public partial class FormButton : UserControl    
    {
        #region Variables
        Form mform;
        Int32 originalWidth = 72;
        ToolStripItem myhost;
        MdiToolStripTabBar owner;
        int index = -1;
        #endregion
        #region Propiedades
        public bool MaxVisible
        {
            get { return btnMaximizar.Visible; }
            set { btnMaximizar.Visible = value; }
        }
        public bool MinVisible
        {
            get { return btnMinimizar.Visible; }
            set { btnMinimizar.Visible = value; }
        }
        public bool CloseVisible
        {
            get { return btnCerrar.Visible; }
            set
            {
                btnCerrar.Visible = value;
            }
        }
        public Form MyForm
        {
            get { return mform; }
            set { mform = value; }
        }
        public ToolStripItem MdiToolStripHost
        {
            get { return myhost; }
            set
            {
                myhost = value;
            }
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
                Graphics Gp = this.CreateGraphics();
                float textWidth = Gp.MeasureString(this.Text, this.Font).Width;
                this.Width = originalWidth + Convert.ToInt32(textWidth);
            }
        }
        public MdiToolStripTabBar Owner
        {
            get
            { return owner; }
            set
            { owner = value; }
        }
        public int Index
        { get { return index; }
            set { index = value; }
        }
        
        #endregion
        #region Elementos de diseño
        Color enfasiscolor = Color.DodgerBlue;
        public Color ColorEnfasis
        {
            get { return enfasiscolor; }
            set { enfasiscolor = value; }
        }
        #endregion
        #region Constructor

        public FormButton(Form msform)
        {
            InitializeComponent();
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, enfasiscolor.R, enfasiscolor.G, enfasiscolor.B);
            btnCerrar.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, enfasiscolor.R, enfasiscolor.G, enfasiscolor.B);
            btnMaximizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, enfasiscolor.R, enfasiscolor.G, enfasiscolor.B);
            btnMaximizar.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, enfasiscolor.R, enfasiscolor.G, enfasiscolor.B);
            btnMinimizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, enfasiscolor.R, enfasiscolor.G, enfasiscolor.B);
            btnMinimizar.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, enfasiscolor.R, enfasiscolor.G, enfasiscolor.B);
            mform = msform;
            mform.FormClosing += Mform_FormClosing;
            mform.FormClosed += Mform_FormClosed;
            mform.TextChanged += Mform_TextChanged;
            this.Text = msform.Text;
        }

        private void Mform_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Text = mform.Text;
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Mform_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                OnMdiFormClosed(new EventArgs());
                owner.Items.Remove(this.myhost);
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message);
            }
        }

        private void Mform_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //e.Cancel = false;
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message);
            }
        }

        #endregion       
        #region Delegados
        public event MdiFormClosedEventHandler MDIFormClosed;
        protected virtual void OnMdiFormClosed(EventArgs e)
        {
            MDIFormClosed?.Invoke(this, e);
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen basicpen = new Pen(new SolidBrush(enfasiscolor), 2);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            if (owner.SelectedItem == myhost)
            {
                basicpen.Width = 2F;
                e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(enfasiscolor), this.ClientRectangle, sf);
            }
            else
            {
                e.Graphics.DrawString(this.Text, this.Font, SystemBrushes.ActiveCaptionText, this.ClientRectangle, sf);
                basicpen.Width = 1.5F;
            }
            e.Graphics.DrawLine(basicpen, new Point(0, 1), new Point(0, this.Height));
            e.Graphics.DrawLine(basicpen, new Point(1, 1), new Point(this.Width - 1, 1));
            e.Graphics.DrawLine(basicpen, new Point(this.Width - 1, 1), new Point(this.Width - 1, this.Height));
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                mform.Close();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            try
            {
                mform.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            try
            {
                mform.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void FormButton_Click(object sender, EventArgs e)
        {
            try
            {
                mform.Activate();
                mform.WindowState = FormWindowState.Maximized;
                owner.SelectedItem = myhost;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        protected override void Select(bool directed, bool forward)
        {            
            mform.Activate();
            mform.WindowState = FormWindowState.Maximized;
            owner.SelectedItem = myhost;
        }

        private void btnCerrar_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath buttonPath =
         new System.Drawing.Drawing2D.GraphicsPath();

           
            System.Drawing.Rectangle newRectangle = btnCerrar.ClientRectangle;

           
            newRectangle.Inflate(-4, -4);

           
            e.Graphics.DrawEllipse(System.Drawing.Pens.Transparent, newRectangle);

           
            buttonPath.AddEllipse(newRectangle);
                        
            btnCerrar.Region = new System.Drawing.Region(buttonPath);
        }
    }
}
