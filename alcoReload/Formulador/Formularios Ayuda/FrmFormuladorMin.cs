using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Multiusos;

namespace Formulador.Formularios_Ayuda
{
    public partial class FrmFormuladorMin : Form
    {
        #region Variables
        string valorformula = "0";
        OperacionesTeclado anteclas = null;
        AnalizadorLexico analizador = null;
        bool seleccioninicial = false;
        Keys ultima_suelta = Keys.None;
        #endregion
        #region Constructor
        public FrmFormuladorMin()
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
        public string Formula
        {
            get { return rtbformulador.Text; }
            set {
                rtbformulador.Text = value;

            }
        }
        public bool SeleccionInicial
        {
            get { return seleccioninicial; }
            set { seleccioninicial = value; }
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
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(p.Nombre))
                    { rtbformulador.Configuraciones.PalabrasClave.Add(p.Nombre, Color.Blue); }
                    if (p.Restricciones.Count > 0)
                    {
                        for (int j = 0; j < p.Restricciones.Count; j++)
                        {
                            if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(p.Restricciones[j].Nombre))
                            {
                                rtbformulador.Configuraciones.PalabrasClave.Add(p.Restricciones[j].Nombre, Color.Navy);
                            }
                        }
                    }
                }

                for (int i = 0; i < analizador.ListaDescuentos.Count; i++)
                {
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(analizador.ListaDescuentos[i].Nombre))
                    {
                        rtbformulador.Configuraciones.PalabrasClave.Add(analizador.ListaDescuentos[i].Nombre, Color.Purple);
                    }
                }

                for (int i = 0; i < analizador.ListaMateriales.Count; i++)
                {
                    Objeto o = analizador.ListaMateriales[i];
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(o.Nombre))
                    { rtbformulador.Configuraciones.PalabrasClave.Add(o.Nombre, Color.Red); }
                    if (o.Parametros.Count > 0)
                    {
                        for (int j = 0; j < o.Parametros.Count; j++)
                        {
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
                }
                foreach (var k in exec.VariablesNumericas.Keys)
                {
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(k.ToString()))
                    {
                        rtbformulador.Configuraciones.PalabrasClave.Add(k.ToString(), Color.Chocolate);
                    }
                }
                foreach (var k in exec.VariablesCadena.Keys)
                {
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(k.ToString()))
                    {
                        rtbformulador.Configuraciones.PalabrasClave.Add(k.ToString(), Color.Lime);
                    }
                }
                foreach (var k in exec.FuncionesCadena.Keys)
                {
                    if (!rtbformulador.Configuraciones.PalabrasClave.ContainsKey(k.ToString()))
                    {
                        rtbformulador.Configuraciones.PalabrasClave.Add(k.ToString(), Color.DarkGreen);
                    }
                }
                rtbformulador.CompilarPalabrasClave();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        private void FrmFormuladorCotas_Load(object sender, EventArgs e)
        {
            try
            {
                cargarPalabrasClave();
                anteclas = new OperacionesTeclado();
                rtbformulador.SelectionStart = rtbformulador.TextLength;
                if (seleccioninicial)
                {
                    rtbformulador.Select(0, rtbformulador.TextLength);
                }
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
                if (analizador.VerificarSintaxis(rtbformulador.Text, true))
                {
                    valorformula = analizador.ValorFinal;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(analizador.Mensajes[0].Mensaje);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                            List<string> listaayuda = analizador.ListaAyuda(rtbformulador.Text, rtbformulador.SelectionStart,out mth);
                            if (listaayuda.Count > 0)
                            {
                                FrmAyudanteFormulacion ayudante = new FrmAyudanteFormulacion();
                                if (mth != null)
                                {
                                    ayudante.IndexultimoItem = mth.Index;
                                    ayudante.LenghtUltimoItem = mth.Length;
                                    if (rtbformulador.Text.Substring(mth.Index, 1).Equals("'"))
                                    {
                                        ayudante.IndexultimoItem = mth.Index + 1;
                                        ayudante.LenghtUltimoItem = mth.Length - 1;
                                    }
                                    if (rtbformulador.Text.Substring(mth.Index + mth.Length - 1, 1).Equals("'"))
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
    }
}
