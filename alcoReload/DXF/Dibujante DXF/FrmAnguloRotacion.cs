using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXF.Dibujante_DXF
{
    public partial class FrmAnguloRotacion : Form
    {
        public FrmAnguloRotacion()
        {
            InitializeComponent();
        }

        public float Angulo
        {
            get { return Convert.ToSingle(nudangulo.Value); }
            set { nudangulo.Value = Convert.ToDecimal(value); }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
    }
}
