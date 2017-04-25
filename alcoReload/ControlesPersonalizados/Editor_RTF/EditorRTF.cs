using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace ControlesPersonalizados.Editor_RTF
{
    public partial class EditorRTF : UserControl
    {
        #region Enumeradores
        public enum TipoGuardado
        {
            ARCHIVO_WORD = 1,
            ARCHIVO_PDF = 2
        }
        #endregion
        public EditorRTF()
        {
            InitializeComponent();
            rtf = new DocumentoRTF();            
            cbtamaniosfuente.DataSource = new int[] { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };
            cbfamiliafuentes.DataSource = FontFamily.Families.Select(f => f.Name).ToArray();            
            ertdDoc.Body.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ertdDoc.Header.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ertdDoc.Footer.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ertdDoc.Body.SelectionChanged += Body_SelectionChanged;
            nudencabezado.Value = Convert.ToDecimal(ertdDoc.HeaderHeightCm);
            nudppagina.Value = Convert.ToDecimal(ertdDoc.FooterHeightCm);
        }        
        #region Variables
        DataTable tablavariables;
        DocumentoRTF rtf;
        DataSet tablasvalores;
        bool combinado = false;
        #endregion
        #region Propiedades
        public bool VisualizarVariables
        {
            set { spcdoctos.Panel1Collapsed = value; }
        }
        public DataTable TablaVariables
        {
            get { return tablavariables; }
            set { tablavariables = value;
                cargarVariables(value);
            }
        }
        public DataSet TablasValoresVariables
        {
            get { return tablasvalores; }
            set { tablasvalores = value;
                ValorarTabla();
            }
        }
        public RichTextBox Encabezado_Control
        { get { return ertdDoc.Header; } }
        public RichTextBox Cuerpo_Control
        { get { return ertdDoc.Body; } }
        public RichTextBox PiedePagina_Control
        { get { return ertdDoc.Footer; } }
        public string Encabezado
        {
            get { return ertdDoc.Header.Rtf; }
            set { ertdDoc.Header.Rtf = value; }
        }
        public string Cuerpo
        {
            get { return ertdDoc.Body.Rtf; }
            set { ertdDoc.Body.Rtf = value; }
        }
        public string PiedePagina
        {
            get { return ertdDoc.Footer.Rtf; }
            set { ertdDoc.Footer.Rtf = value; }
        }
        public decimal AltoEncabezado
        {
            get { return nudencabezado.Value; }
            set { nudencabezado.Value = value; }
        }
        public decimal AltoPiedePagina
        {
            get { return nudppagina.Value; }
            set { nudppagina.Value = value; }
        }
        public bool Combinado
        {
            get { return combinado; }            
        }
        #endregion
        #region Procedimientos
        private void cargarVariables(DataTable tb)
        {
            
            if(tb != null)
            {
                dwCampos.AutoGenerateColumns = false;
                for (int i = 0; i < tb.Columns.Count; i++)
                {
                    if (dwCampos.Columns.Contains(tb.Columns[i].ColumnName))
                    {
                        dwCampos.Columns[tb.Columns[i].ColumnName].DataPropertyName = tb.Columns[i].ColumnName;
                    }
                }
                dwCampos.DataSource = tb;
            }           
        }
        private void ModificarFuente()
        {
            try
            {
                FontStyle fstyle = new FontStyle();
                if (btnnegrilla.Checked) fstyle = fstyle | FontStyle.Bold;
                if (btncursiva.Checked) fstyle = fstyle | FontStyle.Italic;
                if (btnsubrayar.Checked) fstyle = fstyle | FontStyle.Underline;
                ertdDoc.CurrentDocumentPart.SelectionFont = new Font(Convert.ToString(cbfamiliafuentes.SelectedItem),
                    Convert.ToSingle(cbtamaniosfuente.SelectedItem), fstyle);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }            
        }
        private string[] formulaReal(string[] formula_original)
        {
            try
            {
                List<string> formula_nueva = new List<string>();
                for (int i = 0; i < formula_original.Length; i++)
                {
                    var tablas = tablasvalores.Tables.Cast<DataTable>().Where(t => t.Columns.Contains(formula_original[i]));
                    if (tablas.Count() > 0)
                    {
                        var tabla = tablas.ToArray()[0];
                        var valores = from cust in tabla.AsEnumerable()
                                      select "'" + Convert.ToString(cust[formula_original[i]]).Trim() + "'";
                        var val = valores.ToArray();
                        if (val.Length > 1)
                        {
                            formula_nueva.Add(string.Join(",", val));
                        }
                        else
                        {
                            if (val.Length > 0)
                            {
                                formula_nueva.Add(val[0]);
                            }
                            else
                            {
                                formula_nueva.Add("''");
                            }
                        }

                    }
                    else
                    {
                        formula_nueva.Add(formula_original[i]);
                    }
                }

                return formula_nueva.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex.InnerException);
            }           
        }
        public void ValorarTabla()
        {
            try
            {
                for (int i = 0; i < dwCampos.Rows.Count; i++)
                {
                    Formulador.AnalizadorLexico an = new Formulador.AnalizadorLexico();
                    dwCampos[valor.Index, i].Value = string.Empty;
                    string[] elementos_formula = an.ObtenerElementos(Convert.ToString(dwCampos[ValorVarSistemas.Index, i].Value));
                    string formula_real = string.Join("", formulaReal(elementos_formula));
                    dwCampos[valor.Index, i].Value = an.EjecutarExpresion(formula_real);
                }
                Combinar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void Combinar()
        {
            try
            {
                for (int i = 0; i < dwCampos.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dwCampos[valor.Index, i].Value).Trim()))
                    {
                        ertdDoc.Header.Rtf = ertdDoc.Header.Rtf.Replace("[" + Convert.ToString(dwCampos[nombreVariable.Index, i].Value).Trim() + "]",
                        Convert.ToString(dwCampos[valor.Index, i].Value).Trim());
                        ertdDoc.Body.Rtf = ertdDoc.Body.Rtf.Replace("[" + Convert.ToString(dwCampos[nombreVariable.Index, i].Value).Trim() + "]",
                            Convert.ToString(dwCampos[valor.Index, i].Value).Trim());
                        ertdDoc.Footer.Rtf = ertdDoc.Footer.Rtf.Replace("[" + Convert.ToString(dwCampos[nombreVariable.Index, i].Value).Trim() + "]",
                                            Convert.ToString(dwCampos[valor.Index, i].Value).Trim());
                    }                    
                }
                ertdDoc.Header.ReadOnly = true;
                ertdDoc.Body.ReadOnly = true;
                ertdDoc.Footer.ReadOnly = true;
                combinado = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }            
        }

        public void Descombinar()
        {
            try
            {
                ertdDoc.Header.ReadOnly = false;
                ertdDoc.Body.ReadOnly = false;
                ertdDoc.Footer.ReadOnly = false;
                for (int i = 0; i < dwCampos.Rows.Count; i++)
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(dwCampos[valor.Index, i].Value).Trim()))
                    {
                        if(ertdDoc.Header.Text.Contains(Convert.ToString(dwCampos[valor.Index, i].Value).Trim()))
                        {
                            ertdDoc.Header.Rtf = ertdDoc.Header.Rtf.Replace(Convert.ToString(dwCampos[valor.Index, i].Value).Trim(),
                               "[" + Convert.ToString(dwCampos[nombreVariable.Index, i].Value).Trim() + "]");
                        }
                        if (ertdDoc.Body.Text.Contains(Convert.ToString(dwCampos[valor.Index, i].Value).Trim()))
                        {
                            ertdDoc.Body.Rtf = ertdDoc.Body.Rtf.Replace(Convert.ToString(dwCampos[valor.Index, i].Value).Trim(),
                            "[" + Convert.ToString(dwCampos[nombreVariable.Index, i].Value).Trim() + "]");
                        }
                        if (ertdDoc.Footer.Text.Contains(Convert.ToString(dwCampos[valor.Index, i].Value).Trim()))
                        {
                            ertdDoc.Footer.Rtf = ertdDoc.Footer.Rtf.Replace(Convert.ToString(dwCampos[valor.Index, i].Value).Trim(),
                                                "[" + Convert.ToString(dwCampos[nombreVariable.Index, i].Value).Trim() + "]");
                        }
                    }                    
                }                
                combinado = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }


        public void VistaPrevia()
        {
            ertdDoc.Visualize();
        }
        public void Imprimir()
        {
            ertdDoc.Print();
        }
        public void GuardarArchivo(string ruta, TipoGuardado tipoguardado)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(rtf.Encabezado_TipoWord(ertdDoc.Header.Rtf.Substring(ertdDoc.Header.Rtf.IndexOf(@"\par"),
                ertdDoc.Header.Rtf.LastIndexOf(@"}") - ertdDoc.Header.Rtf.IndexOf(@"\par")))).AppendLine();
                string pdp = ertdDoc.Footer.Rtf.Substring(ertdDoc.Footer.Rtf.IndexOf(@"\par"),
                    ertdDoc.Footer.Rtf.LastIndexOf(@"}")- ertdDoc.Footer.Rtf.IndexOf(@"\par"));
            sb.Append(rtf.PiedePagina_TipoWord(pdp.Replace("[Paginas]", "").Replace(@"P\'e1gina pg de pgs", ""))).AppendLine();
            sb.Append(rtf.Cuerpo_TipoWord(ertdDoc.Body.Rtf.Substring(ertdDoc.Body.Rtf.IndexOf(@"\pard"), ertdDoc.Body.Rtf.LastIndexOf(@"\par") - (ertdDoc.Body.Rtf.IndexOf(@"\pard"))))).AppendLine();
            rtf.Base_TipoWord(new string[] { Convert.ToString(cbfamiliafuentes.SelectedItem) }, new Color[] { Color.Black }, sb.ToString());
            string temporal = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "alcominutatemporal.rtf");
            System.IO.StreamWriter sw = new System.IO.StreamWriter(temporal);
            sw.Write(rtf.Base_TipoWord(new string[] { Convert.ToString(cbfamiliafuentes.SelectedItem) }, new Color[] { Color.Black }, sb.ToString()));
            sw.Close();
            if(tipoguardado == TipoGuardado.ARCHIVO_PDF)
            { rtf.Exportar_a_PDF(temporal, ruta); }
            else if (tipoguardado == TipoGuardado.ARCHIVO_WORD)
            { System.IO.File.Move(temporal, ruta);}            
        }
        #endregion
        private void Body_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                RichTextBox rb = (RichTextBox)sender;
                if (rb.SelectionFont != null)
                {
                    btnnegrilla.Checked = rb.SelectionFont.Bold;
                    btncursiva.Checked = rb.SelectionFont.Italic;
                    btnsubrayar.Checked = rb.SelectionFont.Underline;
                    cbfamiliafuentes.SelectedItem = rb.SelectionFont.FontFamily;
                    cbtamaniosfuente.SelectedItem = Convert.ToInt32(rb.SelectionFont.Size);
                    btnizquierda.Checked = rb.SelectionAlignment == HorizontalAlignment.Left;
                    btncentro.Checked = rb.SelectionAlignment == HorizontalAlignment.Center;
                    btnderecha.Checked = rb.SelectionAlignment == HorizontalAlignment.Right;
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ToolStripTextBox txt = (ToolStripTextBox)sender;
                DataTable t = tablavariables.Copy();
                t.Rows.Clear();                
                DataRow[] rows = tablavariables.Rows.Cast<DataRow>().Where(r => Convert.ToString(r[nombreVariable.Name]).ToLower().Contains(txt.Text.ToLower())).ToArray();
                for (int i = 0; i < rows.Length;i++)
                {
                    t.ImportRow(rows[i]);
                }
                dwCampos.DataSource = t;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void flpdoctos_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                FlowLayoutPanel flp = (FlowLayoutPanel)sender;
                if(flp.Width >= ertdDoc.Width)
                {
                    int padcomp = (flp.Width - ertdDoc.Width) / 2;
                    flp.Padding = new Padding(padcomp, 0, padcomp, 0);
                }
                else
                {
                    flp.Padding = new Padding(0, 0, 0, 0);
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void dwCampos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if(e.Button == MouseButtons.Left)
                {                    
                    dwCampos.DoDragDrop("[" +  Convert.ToString(dwCampos[nombreVariable.Index, e.RowIndex].Value).Trim() + "]", DragDropEffects.All);
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnatras_Click(object sender, EventArgs e)
        {
            try
            {
                if (ertdDoc.CurrentDocumentPart != null)
                    ertdDoc.CurrentDocumentPart.Undo();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnadelante_Click(object sender, EventArgs e)
        {
            try
            {
                if(ertdDoc.CurrentDocumentPart != null)
                    ertdDoc.CurrentDocumentPart.Redo();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnimagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opfdialog = new OpenFileDialog();
                opfdialog.Filter = "Archivos de Imagen (*.bmp;*.jpg;*.gif; *.tiff; *.png;)|*.bmp;*.jpg;*.gif;*.tiff;*.png| Todos los Archivos (*.*)|*.*";
                opfdialog.Multiselect = false;
                if(opfdialog.ShowDialog()== DialogResult.OK)
                {
                    Bitmap i = new Bitmap(opfdialog.FileName);
                    Clipboard.SetDataObject(i);                        
                    DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (ertdDoc.CurrentDocumentPart.CanPaste(myFormat))
                    {
                        ertdDoc.CurrentDocumentPart.Paste(myFormat);
                    }
                    else
                    {
                        MessageBox.Show("No es un formato de imagen valido. Verifique el archivo");
                    }                    
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btntabla_Click(object sender, EventArgs e)
        {
            try
            {
                FrmConfTabla conft = new FrmConfTabla();
                if(conft.ShowDialog() == DialogResult.OK)
                {
                    int i = ertdDoc.CurrentDocumentPart.SelectedRtf.IndexOf(@"\uc1");
                    ertdDoc.CurrentDocumentPart.SelectedRtf = ertdDoc.CurrentDocumentPart.SelectedRtf.Insert(i + 4, rtf.Tabla(conft.Filas, conft.Columnas, ertdDoc.CurrentDocumentPart.Width / 2));
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnaumentarfuente_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbtamaniosfuente.SelectedItem) < 36)
                {
                    cbtamaniosfuente.SelectedItem = Convert.ToInt32(cbtamaniosfuente.SelectedItem) + 1;
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }            
        }
        private void btndisminuirfuente_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbtamaniosfuente.SelectedItem) > 8)
            {
                cbtamaniosfuente.SelectedItem = Convert.ToInt32(cbtamaniosfuente.SelectedItem) - 1;
            }
        }
        private void evento_CambiosFuente_Click(object sender, EventArgs e)
        {
            try
            {
                ModificarFuente();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }            
        }
        private void EditorRTF_Load(object sender, EventArgs e)
        {
            try
            {
                cbtamaniosfuente.SelectedItem = 10;
                cbfamiliafuentes.SelectedItem = "Calibri";
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }            
        }
        private void btnizquierda_Click(object sender, EventArgs e)
        {
            try
            {
                ertdDoc.CurrentDocumentPart.SelectionAlignment = HorizontalAlignment.Left;
                btncentro.Checked = false;
                btnderecha.Checked = false;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btncentro_Click(object sender, EventArgs e)
        {
            try
            {
                ertdDoc.CurrentDocumentPart.SelectionAlignment = HorizontalAlignment.Center;
                btnizquierda.Checked = false;
                btnderecha.Checked = false;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnderecha_Click(object sender, EventArgs e)
        {
            try
            {
                ertdDoc.CurrentDocumentPart.SelectionAlignment = HorizontalAlignment.Right;
                btncentro.Checked = false;
                btnizquierda.Checked = false;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ertdDoc.ThisMarginCm = new Padding(3,2,2,2);
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void estrechoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {                
                    ertdDoc.ThisMarginCm = new Padding(1);
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void anchoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ertdDoc.ThisMarginCm = new Padding(5, 3, 5, 3);
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnvinetas_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                ertdDoc.CurrentDocumentPart.SelectedRtf = rtf.ListaVinetas((DocumentoRTF.TipoVineta)btnvinetas.DropDownItems.IndexOfKey(e.ClickedItem.Name),
                    rtf.ObtenerLista(ertdDoc.CurrentDocumentPart.SelectedText), Convert.ToString(cbtamaniosfuente.SelectedItem)); 
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnnumeradas_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                ertdDoc.CurrentDocumentPart.SelectedRtf = rtf.ListaEnumerada((DocumentoRTF.TipoEnumerador)btnnumeradas.DropDownItems.IndexOfKey(e.ClickedItem.Name),
                    rtf.ObtenerLista(ertdDoc.CurrentDocumentPart.SelectedText), Convert.ToString(cbtamaniosfuente.SelectedItem));
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void nudencabezado_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ertdDoc.HeaderHeightCm = Convert.ToSingle(nudencabezado.Value);                
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void nudppagina_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ertdDoc.FooterHeightCm = Convert.ToSingle(nudppagina.Value);
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }

    }
}
