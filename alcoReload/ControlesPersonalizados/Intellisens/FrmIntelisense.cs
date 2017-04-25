using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlesPersonalizados.Intellisens
{
    public partial class FrmIntelisense : Form
    {
        public FrmIntelisense()
        {
            InitializeComponent();
        }
        #region Variables
        Multiusos.OperacionesTeclado tecla;
        string[] columnasvisibles;
        string[] filtros;
        DataTable tablafuente;
        string filtro;
        object controlbase;        
        string columnaseleccionada;
        string columnacomparacion;
        #endregion

        #region Propiedades
        public string[] ColumnasVisibles
        {
            get { return columnasvisibles; }
            set {
                columnasvisibles = value;
                AplicarVisibilidad();
            }

        }
        public string[] Filtros
        {
            get { return filtros; }
            set { filtros = value; }
        }
        public DataTable TablaFuente
        {
            get { return tablafuente; }
            set { tablafuente = value;
                dwintelisense.DataSource = value;
                AplicarVisibilidad();
            }
        }
        public string Filtro
        {
            get { return filtro; }
            set { filtro = value;
                if(!string.IsNullOrEmpty(value))
                { AplicarFiltro(); }                
            }
        }
        public object ControlBase
        {
            get { return controlbase; }
            set { controlbase = value; }
        }
        public string ColumnaSeleccionada
        {
            get { return columnaseleccionada; }
            set { columnaseleccionada = value; }
        }
        public string ColumnaIdComparacion
        {
            get { return columnacomparacion; }
            set { columnacomparacion = value; }
        }
        #endregion

        #region Procedimientos

        void AplicarVisibilidad()
        {
            if(columnasvisibles != null)
            {
                for (int i = 0; i < dwintelisense.Columns.Count; i++)
                {
                    dwintelisense.Columns[i].Visible = columnasvisibles.Contains(dwintelisense.Columns[i].Name);
                }
            }            
        }

        string CrearFiltro()
        {
            try
            {
                return string.Join(" or ", filtros.Select(f => f + " like '" + filtro.Replace("%", "[%]") + "%'").ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        void AplicarFiltro()
        {            
            DataTable tn = tablafuente.Copy();
            tn.Rows.Clear();
            tablafuente.Select(CrearFiltro()).CopyToDataTable(tn, LoadOption.OverwriteChanges);
            dwintelisense.DataSource = tn;            
        }
        #endregion        

        private void dwintelisense_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
                {
                    if (controlbase.GetType() == typeof(intellises))
                    {
                        ((intellises)controlbase).Text = Convert.ToString(dwintelisense.SelectedRows[0].Cells[columnaseleccionada].Value);
                        DataRow rw= tablafuente.AsEnumerable().FirstOrDefault(r => Convert.ToString(r[columnacomparacion]) == Convert.ToString(dwintelisense.SelectedRows[0].Cells[columnacomparacion].Value));
                        if (rw != null)
                        {
                            ((intellises)controlbase).selected_item = rw;
                        }                        
                    }
                    else if (controlbase.GetType() == typeof(TextBox))
                    {
                        ((TextBox)controlbase).Text = Convert.ToString(dwintelisense.SelectedRows[0].Cells[columnaseleccionada].Value);

                    }
                    else if (controlbase.GetType() == typeof(DataGridViewTextBoxCell))
                    {
                        ((DataGridViewTextBoxCell)controlbase).DataGridView.EditingControl.Text= Convert.ToString(dwintelisense.SelectedRows[0].Cells[columnaseleccionada].Value);
                        ((DataGridViewTextBoxCell)controlbase).Value = Convert.ToString(dwintelisense.SelectedRows[0].Cells[columnaseleccionada].Value);

                        
                    }
                    this.Close();
                }
                else if (e.KeyCode == Keys.Back)
                {
                    if(filtro.Length>0)
                    {
                        filtro = filtro.Remove(filtro.Length - 1, 1);
                        if (controlbase.GetType() == typeof(intellises))
                        {
                            ((intellises)controlbase).Text = filtro;
                        }
                        else if (controlbase.GetType() == typeof(TextBox))
                        {
                            ((TextBox)controlbase).Text = filtro;
                        }
                        else if (controlbase.GetType() == typeof(DataGridViewTextBoxCell))
                        {                            
                            ((DataGridViewTextBoxCell)controlbase).DataGridView.EditingControl.Text = filtro;
                            ((DataGridViewTextBoxCell)controlbase).Value = filtro;
                        }
                    }
                    AplicarFiltro();
                }
                else if(e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                else
                {
                    var tt = tecla.DefinirTipoTecla(e);
                    if(tt != Multiusos.OperacionesTeclado.TipoTecla.Desconocida)
                    {
                        filtro += tecla.ObtenerValorTecla(e).ToString();
                        if (controlbase.GetType() == typeof(intellises))
                        {
                            ((intellises)controlbase).Text = filtro;
                        }
                        else if (controlbase.GetType() == typeof(TextBox))
                        {
                            ((TextBox)controlbase).Text = filtro;
                        }
                        else if (controlbase.GetType() == typeof(DataGridViewTextBoxCell))
                        {
                            ((TextBox)((DataGridViewTextBoxCell)controlbase).DataGridView.EditingControl).Text = filtro;
                            ((DataGridViewTextBoxCell)controlbase).Value = filtro;
                        }
                        AplicarFiltro();
                    }                    
                }                 
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void FrmIntelisense_Load(object sender, EventArgs e)
        {
            try
            {
                tecla = new Multiusos.OperacionesTeclado();         
                       
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void FrmIntelisense_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void dwintelisense_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (controlbase.GetType() == typeof(intellises))
                {
                    
                    ((intellises)controlbase).Text = Convert.ToString(dwintelisense[columnaseleccionada, e.RowIndex].Value);
                    DataRow rw = tablafuente.AsEnumerable().FirstOrDefault(r => Convert.ToString(r[columnacomparacion]) == Convert.ToString(dwintelisense[columnacomparacion, e.RowIndex].Value));
                    if (rw != null)
                    {
                        ((intellises)controlbase).selected_item = rw;
                    }
                }
                else if (controlbase.GetType() == typeof(TextBox))
                {
                    ((TextBox)controlbase).Text = Convert.ToString(dwintelisense[columnaseleccionada, e.RowIndex].Value);

                }
                else if (controlbase.GetType() == typeof(DataGridViewTextBoxCell))
                {
                    ((DataGridViewTextBoxCell)controlbase).Value = Convert.ToString(dwintelisense[columnaseleccionada, e.RowIndex].Value);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

        private void FrmIntelisense_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (controlbase.GetType() == typeof(intellises))
                {
                    ((intellises)controlbase).grid_showed = false;
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
    }
}
