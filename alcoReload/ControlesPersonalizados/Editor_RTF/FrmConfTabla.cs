using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlesPersonalizados.Editor_RTF
{
    public partial class FrmConfTabla : Form
    {
        public FrmConfTabla()
        {
            InitializeComponent();
        }

        public int Filas
        {
            get { return Convert.ToInt32(nudfilas.Value); }
        }

        public int Columnas
        {
            get { return Convert.ToInt32(nudcolumnas.Value); }
        }

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
