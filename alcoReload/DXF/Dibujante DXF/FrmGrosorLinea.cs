using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXF
{
    public partial class FrmGrosorLinea : Form
    {
        public FrmGrosorLinea()
        {
            InitializeComponent();
        }
        #region Propiedades
        public decimal Grosor_Linea
        {
            get { return nudgrosor.Value; }
            set { nudgrosor.Value = value; }
        }
        #endregion
        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
