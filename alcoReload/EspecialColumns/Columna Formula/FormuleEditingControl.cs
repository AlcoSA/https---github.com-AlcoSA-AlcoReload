using System;
using System.Collections.Generic;
using RichTextBoxSintaxHighLight;
using Formulador;
using System.Windows.Forms;
using Multiusos;
using System.Linq;

namespace EspecialColumns.Columna_Formula
{
    class FormuleEditingControl : RichtTexboxSyntax, IDataGridViewEditingControl
    {
        #region Variables
        private DataGridView grid;
        OperacionesTeclado anteclas = null;
        private bool valueChanged;
        Keys ultima_suelta = Keys.None;
        Formulador.Formulacion_Grids.AnalizadorDataGridView fdgrid = null;
        #endregion

        #region Constructor
        public FormuleEditingControl()
        {

            anteclas = new OperacionesTeclado();
            fdgrid = new Formulador.Formulacion_Grids.AnalizadorDataGridView(grid);
            Ejecutor e = new Ejecutor();
            foreach (var k in e.FuncionesMatematicas.Keys)
            {
                if (!this.Configuraciones.PalabrasClave.ContainsKey(k.ToString()))
                {
                    this.Configuraciones.PalabrasClave.Add(k.ToString(), System.Drawing.Color.DarkOrange);
                }                
            }
            foreach (var k in e.VariablesNumericas.Keys)
            {
                if (!this.Configuraciones.PalabrasClave.ContainsKey(k.ToString()))
                {
                    this.Configuraciones.PalabrasClave.Add(k.ToString(), System.Drawing.Color.Chocolate);
                }
                
            }
            foreach (var k in e.VariablesCadena.Keys)
            {
                if (!this.Configuraciones.PalabrasClave.ContainsKey(k.ToString()))
                {
                    this.Configuraciones.PalabrasClave.Add(k.ToString(), System.Drawing.Color.Lime);
                }                
            }
            foreach (var k in e.FuncionesCadena.Keys)
            {
                if (!this.Configuraciones.PalabrasClave.ContainsKey(k.ToString()))
                {
                    this.Configuraciones.PalabrasClave.Add(k.ToString(), System.Drawing.Color.DarkGreen);
                }                
            }
            this.CompilarPalabrasClave();
            this.SelectAll();
        }
        #endregion        
        protected override void OnTextChanged(EventArgs e)
        {
            SendToGridValueChanged();
            base.OnTextChanged(e);
            
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {            
            try
            {
                if (!this.Text.StartsWith("="))
                { return; }
                else
                {
                    if (!e.Control && !(ultima_suelta == Keys.Control || ultima_suelta == Keys.ControlKey))
                    {
                        char vtecla = anteclas.ObtenerValorTecla(e);
                        var ttecla = anteclas.DefinirTipoTecla(e);
                        if (ttecla == OperacionesTeclado.TipoTecla.Letras || (ttecla == OperacionesTeclado.TipoTecla.Puntuacion && !(vtecla.Equals(',') || vtecla.Equals(';'))))
                        {
                            System.Text.RegularExpressions.Match mth = fdgrid.ListaAyuda(this.Text, this.SelectionStart);
                            List<string> listaayuda = this.Configuraciones.PalabrasClave.Keys.Select(x => x).ToList();
                            if (listaayuda.Count > 0)
                            {
                                Formulador.Formularios_Ayuda.FrmAyudanteFormulacion ayudante = new Formulador.Formularios_Ayuda.FrmAyudanteFormulacion();
                                if (mth != null)
                                {
                                    ayudante.IndexultimoItem = mth.Index;
                                    ayudante.LenghtUltimoItem = mth.Length;
                                    if (this.Text.Substring(mth.Index, 1).Equals("'"))
                                    {
                                        ayudante.IndexultimoItem = mth.Index + 1;
                                        ayudante.LenghtUltimoItem = mth.Length - 1;
                                    }
                                    if (this.Text.Substring(mth.Index + mth.Length - 1, 1).Equals("'"))
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
                                ayudante.ControlAyudado = this;
                                System.Drawing.Point pt = this.PointToScreen(this.GetPositionFromCharIndex(this.SelectionStart));
                                pt.Y += Convert.ToInt32(this.CreateGraphics().MeasureString("a", this.Font).Height);
                                ayudante.Location = pt;
                                ayudante.Show();
                            }
                        }
                    }
                }
                ultima_suelta = e.KeyCode;
                base.OnKeyUp(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SendToGridValueChanged()
        {
            valueChanged = true;
            if (grid != null)
                grid.NotifyCurrentCellDirty(true);
        }
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return grid;
            }

            set
            {
                grid = value;
                if (grid != null)
                {
                    if (grid.GetType() == typeof(DatagridTreeView.DataTreeGridView))
                    {
                        this.Configuraciones.PalabrasClave.Add("PADRE", System.Drawing.Color.Magenta);
                        this.Configuraciones.PalabrasClave.Add("HIJO", System.Drawing.Color.Magenta);                       
                    }
                    else
                    {
                        this.Configuraciones.PalabrasClave.Add("TABLA", System.Drawing.Color.Magenta);
                    }
                    CompilarPalabrasClave();
                }
            }
        }
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Text.ToString();
            }

            set
            {
                throw new NotImplementedException("Es una propiedades de solo lectura");
            }
        }
        public int EditingControlRowIndex { get; set; }
        public bool EditingControlValueChanged
        {
            get { return valueChanged; }
            set { valueChanged = value; }
        }
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {            
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }
        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:                
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }
        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }
    }
}
