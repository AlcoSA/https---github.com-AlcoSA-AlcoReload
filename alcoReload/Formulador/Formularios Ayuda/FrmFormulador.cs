using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Multiusos;

namespace Formulador.Formularios_Ayuda
{
    public partial class FrmFormulador : Form
    {

        #region Variables
        string valorformula = "0";
        OperacionesTeclado anteclas = null;
        AnalizadorLexico analizador = null;
        bool permitircierre = false;
        string formulaRecalculo = "";
        Keys ultima_suelta = Keys.None;
        #endregion
        #region Constructor
        public FrmFormulador()
        {
            InitializeComponent();
        }
        #endregion
        #region Propiedades
        public string Valor
        {
            get { return valorformula; }
        }
        public AnalizadorLexico Analizador
        {
            set
            {
                analizador = value;
            }
        }
        public string FormulaRecalculo
        {
            get {
                return formulaRecalculo;
            }
            set {
                formulaRecalculo = value;
            }
        }
        public string Formula
        {
            get { return rtbformulador.Text; }
            set
            {
                rtbformulador.Text = value;

            }
        }
        #endregion
        #region Procedimientos
        private void cargarPalabrasClave()
        {
            try
            {
                for (int i = 0; i < analizador.ListaVariables.Count; i++)
                {
                    Parametro p = analizador.ListaVariables[i];
                    TreeNode n = new TreeNode(p.Nombre);
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(p.Nombre))
                    {
                        rtbformulador.Configuraciones.PalabrasClave.Add(p.Nombre, Color.Blue);                      
                    }
                    tvvariables.Nodes.Add(n);
                    if (p.Restricciones.Count > 0)
                    {
                        for (int j = 0; j < p.Restricciones.Count; j++)
                        {
                            if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(p.Restricciones[j].Nombre))
                            {
                                rtbformulador.Configuraciones.PalabrasClave.Add(p.Restricciones[j].Nombre, Color.Navy);                                                                
                            }
                            n.Nodes.Add(p.Restricciones[j].Nombre);
                        }
                    }
                }

                for (int i = 0; i < analizador.ListaDescuentos.Count; i++)
                {
                    TreeNode n = new TreeNode(analizador.ListaDescuentos[i].Nombre);
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(analizador.ListaDescuentos[i].Nombre))
                    {
                        rtbformulador.Configuraciones.PalabrasClave.Add(analizador.ListaDescuentos[i].Nombre, Color.Purple);
                    }
                    tvdescuentos.Nodes.Add(analizador.ListaDescuentos[i].Nombre);
                }


                for (int i = 0; i < analizador.ListaMateriales.Count; i++)
                {
                    Objeto o = analizador.ListaMateriales[i];
                    TreeNode n = new TreeNode();
                    switch (o.Nombre)
                    {
                        case "VIDRIO":
                            {
                                n = new TreeNode(o.Parametros[7].Valor + "(" + o.Indice + ")");
                                n.Tag = o.Nombre + "(" + o.Indice + ")";
                                break;
                            }
                        case "PERFIL":
                            {
                                 n = new TreeNode(o.Parametros[0].Valor + "(" + o.Indice + ")");
                                n.Tag = o.Nombre + "(" + o.Indice + ")";
                                break;
                            }
                        case "ACCESORIOS":
                            {
                                n = new TreeNode(o.Parametros[0].Valor + "(" + o.Indice + ")");
                                n.Tag = o.Nombre + "(" + o.Indice + ")";
                                break;
                            }
                    }
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(o.Nombre))
                    {
                        rtbformulador.Configuraciones.PalabrasClave.Add(o.Nombre, Color.Red);                       
                    }
                    switch (o.Nombre)
                    {
                        case "VIDRIO":
                            {
                                tvmateriales.Nodes[0].Nodes.Add(n);
                                break;
                            }
                        case "PERFIL":
                            {
                                tvmateriales.Nodes[1].Nodes.Add(n);
                                break;
                            }
                        case "ACCESORIOS":
                            {
                                tvmateriales.Nodes[2].Nodes.Add(n);
                                break;
                            }
                    }
                    if (o.Parametros.Count > 0)
                    {
                        for (int j = 0; j < o.Parametros.Count; j++)
                        {
                            n.Nodes.Add(o.Parametros[j].Nombre);
                            if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(o.Parametros[j].Nombre))
                            {
                                rtbformulador.Configuraciones.PalabrasClave.Add(o.Parametros[j].Nombre, Color.Blue);                                
                            }
                        }
                    }
                }

                Ejecutor exec = analizador.EjecutorFormulas;
                foreach (var k in exec.FuncionesMatematicas.Keys)
                {
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(k.ToString()))
                    {
                        rtbformulador.Configuraciones.PalabrasClave.Add(k.ToString(), Color.DarkOrange);
                    }
                    tvfunciones.Nodes[1].Nodes.Add(k.ToString());
                }
                foreach (var k in exec.VariablesNumericas.Keys)
                {
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(k.ToString()))
                    {
                        rtbformulador.Configuraciones.PalabrasClave.Add(k.ToString(), Color.Chocolate);
                    }
                    tvfunciones.Nodes[0].Nodes.Add(k.ToString());
                }
                foreach (var k in exec.VariablesCadena.Keys)
                {
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(k.ToString()))
                    {
                        rtbformulador.Configuraciones.PalabrasClave.Add(k.ToString(), Color.Lime);
                    }
                    tvfunciones.Nodes[2].Nodes.Add(k.ToString());
                }
                foreach (var k in exec.FuncionesCadena.Keys)
                {
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(k.ToString()))
                    {
                        rtbformulador.Configuraciones.PalabrasClave.Add(k.ToString(), Color.DarkGreen);
                    }
                    tvfunciones.Nodes[3].Nodes.Add(k.ToString());
                }
                rtbformulador.CompilarPalabrasClave();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void cargarErrores()
        {
            try
            {
                for (int i = 0; i < analizador.Mensajes.Count; i++)
                {
                    dwerrores.Rows.Add(analizador.Mensajes[i].Mensaje,
                        analizador.Mensajes[i].IndicadorInicio,
                        analizador.Mensajes[i].LargoCadena);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #endregion

        private void FrmFormulador_Load(object sender, EventArgs e)
        {
            try
            {
                anteclas = new OperacionesTeclado();
                cargarPalabrasClave();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tvvariables_ItemDrag(object sender, ItemDragEventArgs e)
        {
            try
            {
                TreeView tv   = (TreeView)sender;
                TreeNode node = (TreeNode)e.Item;
                tv.DoDragDrop(node.FullPath, DragDropEffects.Copy | DragDropEffects.Move);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tvvariables_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                rtbformulador.Text = rtbformulador.Text.Insert(rtbformulador.SelectionStart, e.Node.FullPath);
                rtbformulador.SelectionStart = rtbformulador.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tvvariables_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeView tv = (TreeView)sender;                
                tv.DoDragDrop(e.Node.FullPath, DragDropEffects.Copy | DragDropEffects.Move);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tvfunciones_ItemDrag(object sender, ItemDragEventArgs e)
        {
            try
            {
                TreeView tv = (TreeView)sender;
                TreeNode node = (TreeNode)e.Item;
                if (node.Level > 0)
                {
                    tv.DoDragDrop(node.Text, DragDropEffects.Copy | DragDropEffects.Move);
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tvfunciones_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeView tv = (TreeView)sender;
                if (e.Node.Level > 0)
                { tv.DoDragDrop(e.Node.FullPath, DragDropEffects.Copy | DragDropEffects.Move); }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tvfunciones_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Level > 0)
                {
                    rtbformulador.Text = rtbformulador.Text.Insert(rtbformulador.SelectionStart, e.Node.Text);
                    rtbformulador.SelectionStart = rtbformulador.Text.Length;

                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tvmateriales_ItemDrag(object sender, ItemDragEventArgs e)
        {
            try
            {
                TreeView tv = (TreeView)sender;
                TreeNode node = (TreeNode)e.Item;
                if (node.Level > 0)
                {
                    string[] mat = node.FullPath.Split('.');
                    if (mat.Length == 3)
                    {
                        tv.DoDragDrop(node.Parent.Tag + "." + mat[2], DragDropEffects.Copy | DragDropEffects.Move);
                    }
                    else
                    {
                        tv.DoDragDrop(node.Tag, DragDropEffects.Copy | DragDropEffects.Move);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tvmateriales_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeView tv = (TreeView)sender;                
                if (e.Node.Level > 0)
                {
                    string[] mat = e.Node.FullPath.Split('.');
                    if (mat.Length == 3)
                    {
                        tv.DoDragDrop(mat[1] + "." + mat[2], DragDropEffects.Copy | DragDropEffects.Move);
                    }
                    else
                    {
                        tv.DoDragDrop(mat[1], DragDropEffects.Copy | DragDropEffects.Move);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tvmateriales_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Level > 0)
                {
                    string[] mat = e.Node.FullPath.Split('.');
                    if (mat.Length == 3)
                    { rtbformulador.Text = rtbformulador.Text.Insert(rtbformulador.SelectionStart, mat[1] + "." + mat[2]); }
                    else
                    { rtbformulador.Text = rtbformulador.Text.Insert(rtbformulador.SelectionStart, mat[1]); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnguardarcerrar_Click(object sender, EventArgs e)
        {
            try
            {
                dwerrores.Rows.Clear();
                analizador.Mensajes.Clear();
                if (analizador.VerificarSintaxis(rtbformulador.Text, true))
                {
                    permitircierre = true;
                    valorformula = analizador.ValorFinal;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    cargarErrores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void btnguardar()
        {
            try
            {
                dwerrores.Rows.Clear();
                analizador.Mensajes.Clear();
                if (analizador.VerificarSintaxis(formulaRecalculo, true))
                {
                    permitircierre = true;
                    valorformula = analizador.ValorFinal;
                }
                else
                {
                    cargarErrores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnverificar_Click(object sender, EventArgs e)
        {
            try
            {
                dwerrores.Rows.Clear();
                analizador.Mensajes.Clear();
                if (analizador.VerificarSintaxis(rtbformulador.Text, false))
                {
                    MessageBox.Show("Formulación correcta", "Formulación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cargarErrores();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void rtbformulador_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.Space)
                { }
                else
                {
                    if (!e.Control && !(ultima_suelta == Keys.Control || ultima_suelta == Keys.ControlKey))
                    {
                        char vtecla = anteclas.ObtenerValorTecla(e);
                        var ttecla = anteclas.DefinirTipoTecla(e);
                        if (ttecla == OperacionesTeclado.TipoTecla.Letras || (ttecla == OperacionesTeclado.TipoTecla.Puntuacion && !(vtecla.Equals(',') || vtecla.Equals(';'))))
                        {
                            System.Text.RegularExpressions.Match mth = null;
                            List<string> listaayuda = analizador.ListaAyuda(rtbformulador.Text, rtbformulador.SelectionStart, out mth);
                            if (listaayuda.Count > 0)
                            {
                                FrmAyudanteFormulacion ayudante = new FrmAyudanteFormulacion();
                                if (mth != null)
                                {
                                    ayudante.IndexultimoItem = mth.Index;
                                    ayudante.LenghtUltimoItem = mth.Length;
                                    if (rtbformulador.Text.Substring(mth.Index, 1).Equals("'"))
                                    {
                                        ayudante.IndexultimoItem = mth.Index+1;
                                        ayudante.LenghtUltimoItem = mth.Length-1;
                                    }
                                    if (rtbformulador.Text.Substring(mth.Index + mth.Length-1, 1).Equals("'"))
                                    {
                                        ayudante.LenghtUltimoItem = mth.Length - 2;
                                    }
                                }
                                else
                                {
                                    ayudante.IndexultimoItem = 0;
                                    ayudante.LenghtUltimoItem = 1;
                                }
                                ayudante.EliminarUltimo = (ttecla == OperacionesTeclado.TipoTecla.Letras);
                                ayudante.ListaAyuda = listaayuda;
                                ayudante.ControlAyudado = rtbformulador;
                                Point pt = rtbformulador.PointToScreen(rtbformulador.GetPositionFromCharIndex(rtbformulador.SelectionStart));
                                pt.Y += Convert.ToInt32(rtbformulador.CreateGraphics().MeasureString("a", rtbformulador.Font).Height);
                                ayudante.Location = pt;
                                ayudante.Show();
                            }
                        }
                    }
                }
                ultima_suelta = e.KeyCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FrmFormulador_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!permitircierre)
                {
                    if (MessageBox.Show("¿Esta seguro que desea cerrar sin guardar los cambios?", "Formulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
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
