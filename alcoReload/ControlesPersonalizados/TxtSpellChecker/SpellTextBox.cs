using System;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Forms.Integration;


namespace ControlesPersonalizados.TxtSpellChecker
{
    public partial class SpellTextBox : UserControl
    {
        public ElementHost elemHost;
        public System.Windows.Controls.TextBox txtWpf;
        public SpellTextBox()
        {
            try
            {
                InitializeComponent();
                elemHost = new ElementHost();
                txtWpf = new System.Windows.Controls.TextBox();
                this.AddSizeMapping();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message,ex.InnerException);
            }
            
        }
        
        private void AddSizeMapping()
        {

            elemHost.PropertyMap.Add(
                "Size",
                new PropertyTranslator(OnSizeChanged));
        }

        private  void OnSizeChanged(object sender, String propertyName, object value)
        {
            ElementHost host = sender as ElementHost;
            host.Child = txtWpf;
            txtWpf.Height = elemHost.Size.Height;
            txtWpf.Width = elemHost.Size.Width;
            this.Controls.Add(elemHost);
        }

        private void SpellTextBox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                txtWpf.Height = elemHost.Size.Height;
                txtWpf.Width = elemHost.Size.Width;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void SpellTextBox_Load(object sender, EventArgs e)
        {

        }
    }
}
