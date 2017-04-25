using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlesPersonalizados.Estructurador
{
    public partial class FrmDivisionesEstructura : Form
    {
        public FrmDivisionesEstructura()
        {
            InitializeComponent();
        }

        public decimal Divisiones
        {
            get{ return nudDivisiones.Value; }
        }

        public bool Horizontal
        {
            get { return rbhorizontal.Checked; }
        }

        public bool Vertical
        {
            get { return rbvertical.Checked; }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
