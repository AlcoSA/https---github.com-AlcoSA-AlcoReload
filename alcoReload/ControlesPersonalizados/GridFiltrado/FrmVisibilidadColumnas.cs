using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlesPersonalizados.GridFiltrado
{
    public partial class FrmVisibilidadColumnas : Form
    {
        #region Variables
        private GridFiltrado.GridMultiGruposFiltros grid;
        private DataGridView grid2;
        private bool estacargando = false;
        #endregion
        #region Propiedades
        public GridMultiGruposFiltros Grid
        {
            set { grid = value; }
        }
        public DataGridView Grid2
        {
            set { grid2 = value; }
        }
        #endregion
        public FrmVisibilidadColumnas()
        {
            InitializeComponent();
        }

        private void FrmVisiibilidadColumnas_Load(object sender, EventArgs e)
        {
            try
            {
                estacargando = true;
                if (grid == null)
                    if (grid2 == null)
                    { throw new Exception("Error de carga. el parámetro [Grid] no esta definido"); }
                    else
                    {
                        llenarGrid(grid2);
                    }
                else {
                    llenarGrid(grid);
                }
                estacargando = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tvFiltro_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (!estacargando)
                {
                    if (e.Node == tvFiltro.Nodes[0])
                    {
                        for (int i = 1; i < tvFiltro.Nodes.Count; i++)
                        {
                            tvFiltro.Nodes[i].Checked = e.Node.Checked;
                        }
                    }
                    else
                    {
                        if (grid == null)
                        {
                            if (grid2 != null)
                            {
                                grid2.Columns[e.Node.Name].Visible = e.Node.Checked;
                            }
                        }
                        else { grid.Columns[e.Node.Name].Visible = e.Node.Checked; }
                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmVisibilidadColumnas_Deactivate(object sender, EventArgs e)
        {
            try
            {
                if (grid != null)
                { grid.FindForm().Focus(); }
                if (grid2 != null)
                { grid2.FindForm().Focus(); }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmVisibilidadColumnas_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (grid != null)
                    { grid.FindForm().Focus(); }
                    if (grid2 != null)
                    { grid2.FindForm().Focus(); }
                    this.Close();
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message);
            }
        }
        private void llenarGrid(DataGridView grid)
        {
            foreach (DataGridViewColumn c in grid.Columns)
            {
                TreeNode n = new TreeNode(c.HeaderText);
                n.Name = c.Name;
                n.Checked = c.Visible;
                tvFiltro.Nodes.Add(n);
            }
        }
    }
}
