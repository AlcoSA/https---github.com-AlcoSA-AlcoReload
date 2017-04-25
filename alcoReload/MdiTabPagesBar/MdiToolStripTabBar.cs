using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MdiTabPagesBar
{
    public class MdiToolStripTabBar : System.Windows.Forms.ToolStrip
    {
        #region Variables
        Form mdiform;
        List<Form> mdiChildforms;
        private bool maximvisible = false;
        private bool minvisible = false;
        private bool closevisible = true;
        private ToolStripItem selitem;
        private List<ToolStripItem> reorderedItems = new List<ToolStripItem>();
        ToolStripButton btnrecorreratras;
        ToolStripButton btnrecorreradelante;
        #endregion
        #region Propiedades
        public ToolStripItem SelectedItem
        {
            get { return selitem; }
            set
            {
                selitem = value;
                foreach (ToolStripItem item in this.Items)
                {
                    item.Invalidate();
                }
            }
        }
        public bool MaximizarVisible
        {
            get { return maximvisible; }
            set { maximvisible = value; }
        }
        public bool MinimizarVisible
        {
            get { return minvisible; }
            set { minvisible = value; }
        }
        public bool CerrarVisible
        {
            get { return closevisible; }
            set { closevisible = value; }
        }
        public Form MDIForm
        {
            get { return mdiform; }
            set { mdiform = value; }
        }
        #endregion
        #region Constructor
        public MdiToolStripTabBar()
        {
            mdiChildforms = new List<Form>();
            this.GripStyle = ToolStripGripStyle.Hidden;
            btnrecorreratras = new ToolStripButton();
            btnrecorreradelante = new ToolStripButton();
            //btnrecorreradelante.Enabled = false;
            //btnrecorreratras.Enabled = false;
            btnrecorreradelante.Alignment = ToolStripItemAlignment.Right;
            btnrecorreratras.Alignment = ToolStripItemAlignment.Right;
            btnrecorreradelante.Click += Btnrecorreradelante_Click;
            btnrecorreratras.Click += Btnrecorreratras_Click;
            btnrecorreradelante.Image = Properties.Resources.adelante;
            btnrecorreratras.Image = Properties.Resources.atras;
            this.Items.Add(btnrecorreradelante);
            this.Items.Add(btnrecorreratras);
            this.CanOverflow = false;
            this.RenderMode = ToolStripRenderMode.System;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ItemRemoved += MdiToolStripTabBar_ItemAddedorRemoved;
            this.ItemAdded += MdiToolStripTabBar_ItemAddedorRemoved;
        }     
        #endregion
        #region Procedimientos
        private bool comprobarAncho()
        {
            try
            {
                int mwidht = 0;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i] != btnrecorreratras && this.Items[i] != btnrecorreradelante)
                    {
                        mwidht += this.Items[i].Width;
                    }                    
                }
                return mwidht > this.Width - (btnrecorreradelante.Width + btnrecorreratras.Width);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        
        private bool comprobarAncho(ToolStripItem item, out int index)
        {
            try
            {
                index = 2;
                int mwidht = 0;
                for (int i = 0; i < reorderedItems.Count; i++)
                {
                    mwidht += reorderedItems[i].Width;
                }
                for (int i = reorderedItems.Count +2; i < this.Items.Count; i++)
                {
                    if (this.Items[i] != btnrecorreratras && this.Items[i] != btnrecorreradelante)
                    {
                        mwidht += this.Items[i].Width;
                    }
                    if (this.Items[i] == item)
                    {
                        index = i;
                    }
                }
               
                return mwidht > this.Width - (btnrecorreradelante.Width + btnrecorreratras.Width);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #endregion

        private void MdiToolStripTabBar_ItemAddedorRemoved(object sender, ToolStripItemEventArgs e)
        {
            try
            {
                if (this.Items.IndexOf(e.Item) == -1)
                {
                    FormButton mb = (FormButton)((System.Windows.Forms.ToolStripControlHost)e.Item).Control;
                    
                    if (mb.Index > 2)
                    {
                        Form f= ((FormButton)((System.Windows.Forms.ToolStripControlHost)this.Items[mb.Index-1]).Control).MyForm;
                        f.WindowState = FormWindowState.Maximized;
                    }
                    for (int i = mb.Index; i < this.Items.Count; i++)
                    {
                        ((FormButton)((System.Windows.Forms.ToolStripControlHost)this.Items[i]).Control).Index--;                        
                    }                    
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            this.mdiform = (Form)this.Parent;
            mdiform.MdiChildActivate += Mdiform_MdiChildActivate;
        }

        private void Mdiform_MdiChildActivate(object sender, EventArgs e)
        {
            try
            {
                if (mdiform != null)
                {
                    if (!mdiChildforms.Contains(mdiform.ActiveMdiChild) && mdiform.ActiveMdiChild != null)
                    {
                        FormButton fbutton = new FormButton(mdiform.ActiveMdiChild);
                        fbutton.Owner = this;
                        fbutton.BackColor = this.BackColor;
                        fbutton.MaxVisible = maximvisible;
                        fbutton.MinVisible = minvisible;
                        fbutton.CloseVisible = closevisible;
                        ToolStripControlHost mcontrolhost = new ToolStripControlHost(fbutton);
                        fbutton.MdiToolStripHost = this.Items[this.Items.Add(mcontrolhost)];
                        fbutton.Index = this.Items.Count-1;
                        this.SelectedItem = fbutton.MdiToolStripHost;
                        mdiChildforms.Add(mdiform.ActiveMdiChild);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btnrecorreratras_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                bool botonesmasAnchos = comprobarAncho(selitem, out index);
                if (reorderedItems.Count > 0)
                {
                    this.Items.Insert(2, reorderedItems[reorderedItems.Count - 1]);
                    reorderedItems.RemoveAt(reorderedItems.Count - 1);
                }
                else
                {
                    if (index > 2 && selitem != null)
                    {
                      ToolStripItem mitem =  this.GetNextItem(selitem, ArrowDirection.Left);
                      FormButton mbuton = (FormButton)((System.Windows.Forms.ToolStripControlHost)mitem).Control;
                      mbuton.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Btnrecorreradelante_Click(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                bool botonesmasAnchos = comprobarAncho(selitem, out index);
                if (botonesmasAnchos)
                {
                        reorderedItems.Add(this.Items[2]);
                        this.Items.Remove(this.Items[2]);
                }
                else
                {
                    if(index < this.Items.Count-1)
                    {                        
                        ToolStripItem mitem = this.GetNextItem(selitem, ArrowDirection.Right);
                        FormButton mbuton = (FormButton)((System.Windows.Forms.ToolStripControlHost)mitem).Control;
                        mbuton.Select();
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
