using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace RichTextBoxSintaxHighLight
{
    public class RichtTexboxSyntax : System.Windows.Forms.RichTextBox
    {
        #region Variables
        private ConfiguracionSintaxis configuraciones;
        private static bool puedepintar = true;
        private string linea = string.Empty;
        private int largocontenido = 0;
        private int cantidadlineas = 0;
        private int lineacomienzo = 0;
        private int lineafinal = 0;
        private string palabrasclave = string.Empty;
        private int seleccionactual = 0;

        Stack<string> undoList = new Stack<string>();
        Stack<string> redolist = new Stack<string>();
        bool fromkdown = false;
        #endregion

        #region Constructor
        public RichtTexboxSyntax()
        {
            configuraciones = new ConfiguracionSintaxis();            
        }
        #endregion

        #region Propiedades
        public ConfiguracionSintaxis Configuraciones
        {
            get { return configuraciones; }
        }
        #endregion

        #region Procedimientos



        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            try
            {
                if (m.Msg == 0x00f)
                {
                    if (puedepintar)
                        base.WndProc(ref m);
                    else
                        m.Result = IntPtr.Zero;
                }
                else
                    base.WndProc(ref m);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }            
        }

        protected override void OnTextChanged(EventArgs e)
        {
            try
            {
                if (!fromkdown) { undoList.Push(this.Text); }
                fromkdown = false;
                largocontenido = this.TextLength;
                puedepintar = false;
                lineacomienzo = this.SelectionStart;
                while ((lineacomienzo > 0) && (Text[lineacomienzo - 1] != '\n'))
                    lineacomienzo--;
                lineafinal = this.SelectionStart;
                while ((lineafinal < this.Text.Length) && (this.Text[lineafinal] != '\n'))
                    lineafinal++;
                cantidadlineas = lineafinal - lineacomienzo;
                linea = Text.Substring(lineacomienzo, cantidadlineas);
                ProcesarLinea();
                puedepintar = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }            
        }

        private void ProcesarLinea()
        {
            try
            {
                int nPosition = SelectionStart;
                this.SelectionStart = lineacomienzo;
                this.SelectionLength = cantidadlineas;
                this.SelectionColor = Color.Black;
                ProcesarRegex(palabrasclave, Color.Red, true);
                if (Configuraciones.IdentificacionNumericaHabilitada)
                    ProcesarRegex("\\b(?:[0-9]*\\.)?[0-9]+\\b", Configuraciones.ColorNumeros, false);
                if (Configuraciones.IdentificacionCadenas)
                    ProcesarRegex("\'[^\'\\\\\\r\\n]*(?:\\\\.[^\'\\\\\\r\\n]*)*\'", Configuraciones.ColorCadenasdeTexto, false);
                if (Configuraciones.ComentariosHabilitados && !string.IsNullOrEmpty(Configuraciones.Comentario))
                    ProcesarRegex(configuraciones.Comentario + ".*$", configuraciones.ColorComentarios, false);
                this.SelectionStart = nPosition;
                this.SelectionLength = 0;
                this.SelectionColor = Color.Black;
                seleccionactual = nPosition;
                //"\"[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\""; //Reconocimiento de cadena con comilla doble
                //"\'[^\'\\\\\\r\\n]*(?:\\\\.[^\'\\\\\\r\\n]*)*\'";  //Reconocimiento de cadena con comilla simple
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void ProcesarRegex(string strregex, Color color, bool colordesdeLista)
        {
            try
            {
                Regex palabrasClave = new Regex(strregex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                Match regMatch;
                for (regMatch = palabrasClave.Match(linea); regMatch.Success; regMatch = regMatch.NextMatch())
                {
                    this.SelectionStart = lineacomienzo + regMatch.Index;
                    this.SelectionLength = regMatch.Length;
                    if (colordesdeLista && configuraciones.PalabrasClave.ContainsKey(regMatch.Value))
                        this.SelectionColor = configuraciones.PalabrasClave[regMatch.Value];
                    else
                        this.SelectionColor = color;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
            
        }

        public void CompilarPalabrasClave()
        {            
            try
            {
                foreach (KeyValuePair<string, Color> key in configuraciones.PalabrasClave)
                {
                    string clave = key.Key;
                    palabrasclave += "\\b" + clave + "\\b|";
                }
                if (!string.IsNullOrEmpty(palabrasclave))
                {
                    palabrasclave = palabrasclave.Substring(0, palabrasclave.Length - 1);
                }
                if (this.TextLength > 0)
                {
                    ProcesarTodaslasLineas();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }            
        }

        public void ProcesarTodaslasLineas()
        {
            try
            {
                puedepintar = false;
                int posicioninicial = 0;
                int i = 0;
                int nOriginalPos = SelectionStart;
                while (i < Lines.Length)
                {
                    linea = Lines[i];
                    lineacomienzo = posicioninicial;
                    lineafinal = lineacomienzo + linea.Length;
                    ProcesarLinea();
                    i++;
                    posicioninicial += linea.Length + 1;
                }
                puedepintar = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }          
        }
        
        public void DevolucionEdicion()
        {
            if (undoList.Count > 0)
            {
                redolist.Push(undoList.Pop());
                this.Text = undoList.Count > 0 ? undoList.Pop() : string.Empty;
                if (this.SelectionStart > this.TextLength || this.SelectionStart == 0)
                {
                    this.SelectionStart = this.TextLength;
                }
                
                fromkdown = true;
            }
        }

        public void AdelantoEdicion()
        {
            if (redolist.Count > 0)
            {
                this.Text = redolist.Pop();
                this.SelectionStart = this.Text.Length;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Control && e.KeyCode == Keys.Z)
            {
                DevolucionEdicion();          
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                AdelantoEdicion();
            }            
        }
        #endregion



    }
}
