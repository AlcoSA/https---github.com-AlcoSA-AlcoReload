using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Intellisens
{
    public partial class CtrlIntellisens : UserControl
    {
        [Bindable(BindableSupport.Yes)]
        
        public CtrlIntellisens()
        {
            InitializeComponent();
        }
        #region Variables
        private string DPName;
        #endregion

        #region "Propiedades
        List<string> datoColumna = null;
        public List<string> DatoColumna { get { return datoColumna; } set { datoColumna = value; } }

        public object DataSource
        {
            get { return Dgv.DataSource; }
            set
            {
                Dgv.DataSource = value;
            }
        }
        #endregion

        #region "Procedimientos"
        private void cargarDgv()
        {
            try
            {
                if (validacion())
                {
                    int acum = 0;
                    foreach (DataGridViewColumn col in Dgv.Columns)
                    {
                        int ancho = col.Width;
                        acum += ancho;
                    }
                    Dgv.Width = acum;
                    this.Width = acum;

                    acum = 0;
                    int alto = 0;
                    foreach (DataGridViewRow row in Dgv.Rows)
                    {
                        alto = row.Height;
                        acum += alto;
                    }

                    if (acum > alto * 5)
                    {
                        acum = 0;
                        acum = alto * 5;
                    }
                    Dgv.Height = acum;
                    this.Height = acum;
                    Dgv.BringToFront();
                    this.BringToFront();
                    Dgv.ScrollBars = ScrollBars.Both;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }       
        }

        private bool validacion()
        {
            if (Dgv.Rows.Count < 1)
            {
                Txt.Show();
                Dgv.Rows.Add();
                return false;
            }
            return true;
        }

        public void crearColumnas(string nombreColumna, string encabezado, string dataPropertyName)
        {
            DPName = dataPropertyName;
            Dgv.Columns.Add(nombreColumna, encabezado);            
            cargarDgv();
        }
        #endregion
        
        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Txt.Text == string.Empty)
                {
                    Dgv.Hide();
                    return;
                }
                Dgv.Show();
                cargarDgv();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }          
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Txt.Text == string.Empty)
                {
                    Dgv.Hide();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void CtrlIntellisens_Load(object sender, EventArgs e)
        {
            Dgv.DataSource = this.DataSource;
        }

        private void Dgv_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.DataPropertyName = DPName;
            DPName = string.Empty;
        }
    }
}
