using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace ControlesPersonalizados.Filtro_DragDrop
{
    public partial class FrmColumnaFormulada : Form
    {
        #region vars
        private DataTable tabla_datos = null;
        private int posicion = 0;
        #endregion
        #region ctor
        public FrmColumnaFormulada()
        {
            InitializeComponent();
        }
        #endregion
        #region props
        public DataTable Tabla_Datos
        {
            get { return tabla_datos; }
            set
            { tabla_datos = value; }
        }
        public string Nombre_Columna
        {
            get { return txtnombrecolumna.Text; }
            set { txtnombrecolumna.Text = value; }
        }
        public string Expresion
        {
            get { return rtxexpression.Text; }
            set { rtxexpression.Text = value; }
        }
        public int Posicion
        {
            get { return lbposicion.SelectedIndex; }
            set
            { posicion = value; }
        }
        #endregion
        private void FrmColumnaFormulada_Load(object sender, EventArgs e)
        {
            try
            {
                if (tabla_datos != null)
                {
                    foreach (DataColumn c in tabla_datos.Columns)
                    {
                        if (c.DataType == Type.GetType("System.Double") || c.DataType == Type.GetType("System.Decimal") ||
                            c.DataType == Type.GetType("System.Int16") || c.DataType == Type.GetType("System.Int32") ||
                         c.DataType == Type.GetType("System.Int64"))
                        {
                            Button b = new Button();
                            b.Text = c.Caption;
                            b.Tag = c.ColumnName;
                            b.Click += B_Click;
                            flpcolumnas.Controls.Add(b);
                            
                        }
                        lbposicion.Items.Add(c.ColumnName);
                    }
                    lbposicion.SelectedIndex = posicion;
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void B_Click(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                rtxexpression.Text += Convert.ToString(b.Tag);
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void btonCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void btonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
    }
}
