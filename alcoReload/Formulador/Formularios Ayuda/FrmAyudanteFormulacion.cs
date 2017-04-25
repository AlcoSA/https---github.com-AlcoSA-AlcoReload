using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Multiusos;
namespace Formulador.Formularios_Ayuda
{
    public partial class FrmAyudanteFormulacion : Form
    {
        #region Variables
        private List<string> listayuda;
        private Control controlayudado;
        private int indexultimoitem = 0;
        private int lenghtultimoitem = 0;
        private bool eliminarultimo = false;
        private OperacionesTeclado anteclas= null;
        private string cadenaayuda = string.Empty;
        private bool ayudaenviada = false;
        #endregion
        #region Constructor
        public FrmAyudanteFormulacion()
        {
            InitializeComponent();
        }
        #endregion
        #region Propiedades
        public List<string> ListaAyuda
        {
            get { return listayuda; }
            set { listayuda=value; }
        }
        public Control ControlAyudado
        {
            get { return controlayudado; }
            set { controlayudado = value; }
        }
        public int IndexultimoItem
        {
            get { return indexultimoitem; }
            set { indexultimoitem = value; }
        }
        public int LenghtUltimoItem
        {
            get { return lenghtultimoitem; }
            set { lenghtultimoitem = value; }
        }
        public bool EliminarUltimo
        {
            get { return eliminarultimo; }
            set { eliminarultimo = value; }
        }
        #endregion
        #region Procedimientos
        private List<string> filtrarLista()
        {
            try
            {
                return listayuda.Where(s => s.ToLower().Contains(cadenaayuda.ToLower())).ToList();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void cargarLista(List<string> lista)
        {
            try
            {
                if (lista != null)
                {
                    lbayudante.Items.Clear();
                    for (int i = 0; i < lista.Count; i++)
                    {
                        lbayudante.Items.Add(lista[i]);
                        lbayudante.SelectedIndex = 0;
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void EnviarAyuda()
        {
            try
            {
                if (lbayudante.SelectedItem != null)
                {
                    RichTextBox rtb = (RichTextBox)controlayudado;
                    string txt = string.Empty;
                    int ultimosstart = rtb.SelectionStart;
                    if (eliminarultimo)
                    {
                        if (indexultimoitem >= 0)
                        {
                            
                            txt = rtb.Text.Remove(indexultimoitem, lenghtultimoitem);
                            rtb.Text = txt.Insert(indexultimoitem, lbayudante.SelectedItem.ToString());
                            rtb.SelectionStart = indexultimoitem + lbayudante.SelectedItem.ToString().Length;
                        }
                        else
                        {
                            txt = rtb.Text.Remove(rtb.SelectionStart - 1, 1);
                            rtb.Text = txt.Insert(rtb.SelectionStart - 1, lbayudante.SelectedItem.ToString());
                            rtb.SelectionStart = ultimosstart + lbayudante.SelectedItem.ToString().Length;
                        }
                    }
                    else
                    {
                        txt = rtb.Text.Remove(indexultimoitem+1, lenghtultimoitem-1);

                        rtb.Text = txt.Insert(indexultimoitem+1, lbayudante.SelectedItem.ToString());
                        rtb.SelectionStart = indexultimoitem + 1 + lbayudante.SelectedItem.ToString().Length;
                    }
                    ayudaenviada = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        #endregion

        private void FrmAyudanteFormulacion_Load(object sender, EventArgs e)
        {
            try
            {
                anteclas = new OperacionesTeclado();
                IEnumerable<IGrouping<string, string>> l= listayuda.GroupBy(x => x).ToList();
                listayuda.Clear();
                foreach (var it in l)
                {
                    listayuda.Add(it.Key.ToString());
                }                    
                if (controlayudado != null)
                {
                    RichTextBox rtb = (RichTextBox)controlayudado;
                    if (indexultimoitem >= 0)
                    {
                        if (rtb.Text.Substring(indexultimoitem, lenghtultimoitem).Equals(".") || rtb.Text.Substring(indexultimoitem, lenghtultimoitem).Equals("'"))
                        {
                            cadenaayuda = String.Empty;
                        }
                        else
                        {
                            cadenaayuda = rtb.Text.Substring(indexultimoitem, lenghtultimoitem).Replace("'", "");
                        }
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(rtb.Text))
                        {
                            cadenaayuda = rtb.Text.Substring(0, 1);
                        }
                        else {
                            cadenaayuda = String.Empty;
                        }                        
                    }
                    cargarLista(filtrarLista());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmAyudanteFormulacion_Deactivate(object sender, EventArgs e)
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

        private void FrmAyudanteFormulacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if(!ayudaenviada)
                {
                    RichTextBox rtb = (RichTextBox)controlayudado;
                    rtb.SelectionStart = indexultimoitem + lenghtultimoitem;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbayudante_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                EnviarAyuda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbayudante_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    EnviarAyuda();
                }
                else
                {
                    OperacionesTeclado.TipoTecla ttecla = anteclas.DefinirTipoTecla(e);
                    if (ttecla == OperacionesTeclado.TipoTecla.Letras || ttecla == OperacionesTeclado.TipoTecla.Numerica)
                    {
                        string vtecla = anteclas.ObtenerValorTecla(e).ToString();
                        RichTextBox rtb = (RichTextBox)controlayudado;
                        if (indexultimoitem < 0)
                        {
                            rtb.Text = rtb.Text.Insert(1, vtecla);
                        }
                        else
                        {
                                rtb.Text = rtb.Text.Insert(indexultimoitem + lenghtultimoitem, vtecla);                            
                        }
                        lenghtultimoitem += 1;
                        cadenaayuda += vtecla;
                        cargarLista(filtrarLista());
                    }
                    else
                    {
                        if (e.KeyCode == Keys.Back)
                        {
                            if (cadenaayuda.Length > 0)
                            {
                                cadenaayuda = cadenaayuda.Remove(cadenaayuda.Length - 1, 1);
                                RichTextBox rtb = (RichTextBox)controlayudado;
                                rtb.Text = rtb.Text.Remove(indexultimoitem + lenghtultimoitem - 1, 1);
                                lenghtultimoitem -= 1;
                                cargarLista(filtrarLista());
                            }

                        }
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
