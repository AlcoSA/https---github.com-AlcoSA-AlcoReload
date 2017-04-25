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
    public partial class FrmfiltroGrid : Form
    {
        #region vars
        private GridMultiGruposFiltros grid;
        private string columnaseleccionada;
        private string[] mesesnombre = {"--", "Enero", "Febrero", "Marzo", "Abril",
            "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
        private bool En_carga, cambiartodos, cambiarIndividual = false;        
        #endregion
        #region props
        public GridMultiGruposFiltros Grid
        {
            get { return grid; }
            set { grid = value; }
        }
        public string ColumnaSeleccionada
        {
            get { return columnaseleccionada; }
            set { columnaseleccionada = value; }
        }
        #endregion        
        #region ctor
        public FrmfiltroGrid()
        {
            InitializeComponent();
        }
        #endregion
        #region procs
        private DataTable datosAgrupados()
        {
            try
            {
                var q = from DataRow rw in grid.TablaDatos.Rows
                        group rw by rw[columnaseleccionada];
               return q.Select(dr => dr.First()).CopyToDataTable();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void listasdeUso(DataTable tablabusqueda, out List<string> listanormal, out List<DateTime> listafechas)
        {
            try
            {
                listanormal = new List<string>();
                listafechas = new List<DateTime>();
                foreach (DataRow rw in tablabusqueda.Rows)
                {
                    DateTime esfecha;
                    if (DateTime.TryParse(rw[columnaseleccionada].ToString(), out esfecha))
                    {
                        listafechas.Add(esfecha);
                    }
                    else
                    {
                        listanormal.Add(rw[columnaseleccionada].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cambiarChecknodos(TreeNode nd, bool valorchequeo)
        {
            try
            {
                nd.Checked = valorchequeo;
                for (int i = 0; i < nd.Nodes.Count; i++)
                {
                    cambiarChecknodos(nd.Nodes[i], valorchequeo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cambiarCheckPadres(TreeNode nd, bool valorchequeo)
        {
            try
            {
                if (nd.Parent != null)
                {
                    nd.Parent.Checked = valorchequeo;
                    cambiarCheckPadres(nd.Parent, valorchequeo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cambiarCheckHijos(TreeNode nd, bool valorchequeo)
        {
            try
            {
                for (int i = 0; i < nd.Nodes.Count; i++)
                {
                    nd.Nodes[i].Checked = valorchequeo;
                    cambiarCheckHijos(nd.Nodes[i], valorchequeo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool verificarCheckPadre(TreeNode nd)
        {
            try
            {
                if (nd.Parent != null)
                {
                    for (int i = 0; i < nd.Parent.Nodes.Count; i++)
                    {
                        if (nd.Parent.Nodes[i].Checked)
                        { return true; }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        #endregion

        private void btonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                bool todos_seleccionados = false;
                List<object> filtro = new List<object>();
                if (tvFiltro.Nodes[0].Checked)
                {
                    todos_seleccionados = true;
                }
                else
                {                    
                    foreach (TreeNode nr in tvFiltro.Nodes)
                    {
                        if (nr.Checked)
                        {
                            if (nr.Nodes.Count > 0)
                            {
                                foreach (TreeNode nsr in nr.Nodes)
                                {
                                    if (nsr.Checked)
                                    {
                                        foreach (TreeNode nsrr in nsr.Nodes)
                                        {
                                            if (nsrr.Checked)
                                            {
                                                TimeSpan ts = (TimeSpan)nsrr.Tag;
                                                filtro.Add(new DateTime(Convert.ToInt32(nr.Text), Convert.ToInt32(nsr.Tag),
                                                    Convert.ToInt32(nsrr.Text), ts.Hours, ts.Minutes, ts.Seconds));                                               
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                filtro.Add(nr.Text);                                
                            }
                        }
                    }
                }
                if (!todos_seleccionados)
                {
                    grid.Columns[columnaseleccionada].Tag = filtro.ToArray();
                }
                else
                {
                    grid.Columns[columnaseleccionada].Tag = null;
                }
                grid.ConstruirFiltrosExcel();
                this.grid.FindForm().Focus();
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btonCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndesc_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid != null)
                {
                    grid.Sort(grid.Columns[columnaseleccionada], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    throw new Exception("No hay una tabla seleccionada");
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnasc_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid != null)
                {
                    grid.Sort(grid.Columns[columnaseleccionada], System.ComponentModel.ListSortDirection.Descending);
                }
                else
                {
                    throw new Exception("No hay una tabla seleccionada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmfiltroGrid_Deactivate(object sender, EventArgs e)
        {
            try
            {                
                this.Close();
                this.grid.FindForm().Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmfiltroGrid_Load(object sender, EventArgs e)
        {
            try
            {
                En_carga = true;
                bool contfiltro = grid.Columns[columnaseleccionada].Tag !=null;
                tvFiltro.Nodes[0].Checked = !contfiltro;
                DataTable agrupados = datosAgrupados();
                List<string> listatextoplano = new List<string>();
                List<DateTime> listafechas = new List<DateTime>();
                listasdeUso(agrupados, out listatextoplano, out listafechas);
                List<int> añosagrupados = listafechas.GroupBy(fecha => fecha.Year).Select(fecha => fecha.First().Year).ToList();                
                foreach (string dato in listatextoplano)
                {
                    TreeNode n = new TreeNode(dato);
                    if (contfiltro)
                    {
                        n.Checked = ((object[])grid.Columns[columnaseleccionada].Tag).Contains(dato);
                    }
                    else
                    { n.Checked = true; }
                    
                    tvFiltro.Nodes.Add(n);
                }
                foreach (int año in añosagrupados)
                {
                    TreeNode n = new TreeNode(año.ToString());
                    n.Tag = año;
                    tvFiltro.Nodes.Add(n);
                    List<int> mesesagrupados = listafechas.Where(f => f.Year == año).GroupBy(f => f.Month).Select(f => f.First().Month).ToList();
                    foreach (int mes in mesesagrupados)
                    {
                        TreeNode nd = new TreeNode(mesesnombre[mes]);
                        nd.Tag = mes;
                        n.Nodes.Add(nd);
                        List<int> diasagrupados = listafechas.Where(f => f.Year == año && f.Month == mes).Select(f => f.Day).ToList();

                        for (int i = 0; i < diasagrupados.Count; i++)
                        {

                            List<TimeSpan> tiempo = listafechas.Where(f => f.Year == año && f.Month == mes).Select(f => f.TimeOfDay).ToList();

                            TreeNode nds = new TreeNode(diasagrupados[i].ToString());
                            DateTime fecha = new DateTime(año, mes, diasagrupados[i], tiempo[i].Hours, tiempo[i].Minutes, tiempo[i].Seconds, DateTimeKind.Unspecified);
                            if (contfiltro)
                            {
                                if (!n.Checked)
                                {
                                    n.Checked = ((object[])grid.Columns[columnaseleccionada].Tag).Contains(fecha);
                                }
                                if (!nd.Checked)
                                {
                                    nd.Checked = ((object[])grid.Columns[columnaseleccionada].Tag).Contains(fecha);
                                }
                                nds.Checked = ((object[])grid.Columns[columnaseleccionada].Tag).Contains(fecha);
                            }
                            else
                            {
                                n.Checked = true;
                                nd.Checked = true;
                                nds.Checked = true;
                            }
                            nds.ToolTipText = tiempo[i].ToString();
                            nds.Tag = tiempo[i];
                            nd.Nodes.Add(nds);
                        }
                    }
                }
                En_carga = false;
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
                if (!En_carga && !cambiartodos && !cambiarIndividual)
                {
                    if (e.Node == tvFiltro.Nodes["todos"])
                    {
                        cambiartodos = true;
                        for (int i = 1; i < tvFiltro.Nodes.Count; i++)
                        {
                            cambiarChecknodos(tvFiltro.Nodes[i], e.Node.Checked);
                        }
                        cambiartodos = false;
                    }
                    else
                    {
                        cambiarIndividual = true;
                        if (!e.Node.Checked)
                        {
                            tvFiltro.Nodes[0].Checked = false;
                            if (!verificarCheckPadre(e.Node)) { cambiarCheckPadres(e.Node, false); }
                        }
                        else
                        {
                            cambiarCheckPadres(e.Node, true);
                        }
                        cambiarCheckHijos(e.Node, e.Node.Checked);
                        cambiarIndividual = false;
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
