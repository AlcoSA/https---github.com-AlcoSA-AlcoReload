using System;
using System.Windows.Forms;

namespace ControlesPersonalizados.Filtro_DragDrop
{
    public partial class FiltroDragDrop : UserControl
    {        
        #region Variables
        GridFiltrado.GridMultiGruposFiltros gridfiltro = null;
        #endregion
        #region Constructor
        public FiltroDragDrop()
        {
            InitializeComponent();
        }
        #endregion
        #region Propiedades
        public GridFiltrado.GridMultiGruposFiltros Grid
        {
            get { return gridfiltro; }
            set { gridfiltro = value; }
        }
        #endregion
        #region Procedimientos
        public void LimpiarFiltros()
        {
            try
            {
                foreach (Control c in flpFiltros.Controls)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(c.Tag)))
                    {
                        gridfiltro._EliminarFiltro(Convert.ToString(c.Tag));
                    }
                }
                flpFiltros.Controls.Clear();
                flpFiltros.Controls.Add(lbindicacion);
                lbindicacion.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " . No se pueden limpiar los filtros");
            }
        }

        public void AgregarFiltro(string nombre_columna, string valor, string valor_secundario, GridFiltrado.Elementos_Grid.TipoValor tipovalor,
            GridFiltrado.Elementos_Grid.TipoCoincidencia tipocoincidencia)
        {
            try
            {
                lbindicacion.Visible = false;
                flpFiltros.Controls.RemoveByKey("restaurar");
                Label labelencabezado = new Label();
                labelencabezado.Text = nombre_columna;
                labelencabezado.Width = Convert.ToInt32(labelencabezado.CreateGraphics().MeasureString(labelencabezado.Text, labelencabezado.Font).Width) + 5;
                switch (tipovalor)
                {
                    case GridFiltrado.Elementos_Grid.TipoValor.NUMERICO:
                        {
                            FiltroNumerico numericfiltro = new FiltroNumerico();
                            numericfiltro.Name = nombre_columna;
                            numericfiltro.Tag = nombre_columna;
                            numericfiltro.ValorMaximo = -999999999;
                            numericfiltro.ValorMinimo = 999999999;
                            numericfiltro.Decimales = 2;
                            numericfiltro.Value = Convert.ToDecimal(valor);
                            numericfiltro.TipoCoincidencia = tipocoincidencia;
                            numericfiltro.ValueChanged += Filtros_ValueChanged;
                            numericfiltro.CambiarCoincidencia += cnt_CambiarCoincidencia;
                            flpFiltros.Controls.AddRange(new Control[] { labelencabezado, numericfiltro });
                            gridfiltro._AgregarFiltro(new GridFiltrado.Elementos_Grid.Filtro(nombre_columna,
                                    numericfiltro.Value, tipovalor, numericfiltro.TipoCoincidencia));
                            break; }
                    case GridFiltrado.Elementos_Grid.TipoValor.TEXTO:
                        {
                            FiltroTexto textboxfiltro = new FiltroTexto();
                            textboxfiltro.Name = nombre_columna;
                            textboxfiltro.Tag = nombre_columna;
                            textboxfiltro.TipoCoincidencia = tipocoincidencia;
                            textboxfiltro.Text = valor;
                            textboxfiltro.TextChanged += Filtros_ValueChanged;
                            textboxfiltro.CambiarCoincidencia += cnt_CambiarCoincidencia;
                            flpFiltros.Controls.AddRange(new Control[] { labelencabezado, textboxfiltro });
                            gridfiltro._AgregarFiltro(new GridFiltrado.Elementos_Grid.Filtro(nombre_columna,
                                    textboxfiltro.Text, tipovalor, textboxfiltro.TipoCoincidencia));
                            break; }
                    case GridFiltrado.Elementos_Grid.TipoValor.BOOLEANO:
                        {
                            CheckBox checkfiltro = new CheckBox();
                            checkfiltro.Name = nombre_columna;
                            checkfiltro.Tag = nombre_columna;
                            checkfiltro.Text = string.Empty;
                            checkfiltro.Checked = Convert.ToBoolean(Convert.ToInt32(valor));
                            checkfiltro.CheckedChanged += Filtros_ValueChanged;
                            flpFiltros.Controls.AddRange(new Control[] { labelencabezado, checkfiltro });
                            gridfiltro._AgregarFiltro(new GridFiltrado.Elementos_Grid.Filtro(nombre_columna,
                                    checkfiltro.Checked, tipovalor));
                            break; }
                    case GridFiltrado.Elementos_Grid.TipoValor.FECHA:
                        {
                            FiltroFechas fechasfiltro = new FiltroFechas();
                            fechasfiltro.Name = nombre_columna;
                            fechasfiltro.Tag = nombre_columna;
                            fechasfiltro.FechaDesde = Convert.ToDateTime(valor);
                            fechasfiltro.FechaHasta = Convert.ToDateTime(valor_secundario);
                            fechasfiltro.FiltrarButton_Click += Filtros_ValueChanged;
                            flpFiltros.Controls.AddRange(new Control[] { labelencabezado, fechasfiltro });

                            gridfiltro._AgregarFiltro(new GridFiltrado.Elementos_Grid.Filtro(nombre_columna,
                                    new DateTime[] { fechasfiltro.FechaDesde, fechasfiltro.FechaHasta },
                                    GridFiltrado.Elementos_Grid.TipoValor.FECHA));
                            break; }
                }
                Button mbtn = new Button();
                mbtn.Text = "Restaurar";
                mbtn.Name = "restaurar";
                mbtn.Click += Mbtn_Click;
                flpFiltros.Controls.Add(mbtn);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " . No se puede agregar el filtro");
            }
        }
        #endregion
        private void flpFiltros_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string mdata = e.Data.GetData("Text").ToString();
                    if (!flpFiltros.Controls.ContainsKey(mdata.Split('-')[0]))
                    { e.Effect = DragDropEffects.Copy; }                    
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void flpFiltros_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (gridfiltro == null)
                {
                    throw new ArgumentException("No se ha asignado un valor de fuente valido", "gridfiltrado");
                }
                lbindicacion.Visible = false;
                flpFiltros.Controls.RemoveByKey("restaurar");
                string mdata = e.Data.GetData("Text").ToString();
                Label labelencabezado = new Label();
                labelencabezado.Text = mdata.Split('-')[1];
                labelencabezado.Width = Convert.ToInt32( labelencabezado.CreateGraphics().MeasureString(labelencabezado.Text, labelencabezado.Font).Width) + 5;
                Type coltype = gridfiltro.TablaDatos.Columns[mdata.Split('-')[0].ToString()].DataType;
                if (coltype == Type.GetType("System.String"))
                {
                    FiltroTexto textboxfiltro = new FiltroTexto();
                    textboxfiltro.Name = mdata.Split('-')[0].ToString();
                    textboxfiltro.Tag = mdata.Split('-')[0].ToString();
                    textboxfiltro.TextChanged += Filtros_ValueChanged;
                    textboxfiltro.CambiarCoincidencia += cnt_CambiarCoincidencia;
                    flpFiltros.Controls.AddRange(new Control[] { labelencabezado, textboxfiltro });                    
                    gridfiltro._AgregarFiltro(new GridFiltrado.Elementos_Grid.Filtro(mdata.Split('-')[0].ToString(),
                            string.Empty, GridFiltrado.Elementos_Grid.TipoValor.TEXTO, textboxfiltro.TipoCoincidencia));
                }
                else if (coltype == Type.GetType("System.DateTime"))
                {                    
                    FiltroFechas fechasfiltro = new FiltroFechas();
                    fechasfiltro.Name = mdata.Split('-')[0].ToString();
                    fechasfiltro.Tag = mdata.Split('-')[0].ToString();
                    fechasfiltro.FiltrarButton_Click += Filtros_ValueChanged;
                    flpFiltros.Controls.AddRange(new Control[] { labelencabezado, fechasfiltro});

                    gridfiltro._AgregarFiltro(new GridFiltrado.Elementos_Grid.Filtro(mdata.Split('-')[0].ToString(),
                            new DateTime[] { fechasfiltro.FechaDesde, fechasfiltro.FechaHasta },
                            GridFiltrado.Elementos_Grid.TipoValor.FECHA));

                }
                else if (coltype == Type.GetType("System.Int16") || coltype == Type.GetType("System.Int32") ||
                     coltype == Type.GetType("System.Int64"))
                {
                    FiltroNumerico numericfiltro = new FiltroNumerico();
                    numericfiltro.Name = mdata.Split('-')[0].ToString();
                    numericfiltro.Tag = mdata.Split('-')[0].ToString();
                    numericfiltro.ValorMaximo = -999999999;
                    numericfiltro.ValorMinimo = 999999999;
                    numericfiltro.Decimales =0;
                    numericfiltro.ValueChanged +=  Filtros_ValueChanged;
                    numericfiltro.CambiarCoincidencia += cnt_CambiarCoincidencia;
                    flpFiltros.Controls.AddRange(new Control[] { labelencabezado, numericfiltro });
                    gridfiltro._AgregarFiltro(new GridFiltrado.Elementos_Grid.Filtro(mdata.Split('-')[0].ToString(),
                            numericfiltro.Value, GridFiltrado.Elementos_Grid.TipoValor.NUMERICO,
                            numericfiltro.TipoCoincidencia));
                }
                else if (coltype == Type.GetType("System.Double") || coltype == Type.GetType("System.Decimal"))
                {

                    FiltroNumerico numericfiltro = new FiltroNumerico();
                    numericfiltro.Name = mdata.Split('-')[0].ToString();
                    numericfiltro.Tag = mdata.Split('-')[0].ToString();
                    numericfiltro.ValorMaximo = -999999999;
                    numericfiltro.ValorMinimo = 999999999;
                    numericfiltro.Decimales = 2;
                    numericfiltro.ValueChanged += Filtros_ValueChanged;
                    numericfiltro.CambiarCoincidencia += cnt_CambiarCoincidencia;
                    flpFiltros.Controls.AddRange(new Control[] { labelencabezado, numericfiltro });
                    gridfiltro._AgregarFiltro(new GridFiltrado.Elementos_Grid.Filtro(mdata.Split('-')[0].ToString(),
                            numericfiltro.Value, GridFiltrado.Elementos_Grid.TipoValor.NUMERICO,
                            numericfiltro.TipoCoincidencia));
                }
                else if (coltype == Type.GetType("System.Boolean"))
                {
                    CheckBox checkfiltro = new CheckBox();
                    checkfiltro.Name = mdata.Split('-')[0].ToString();
                    checkfiltro.Tag = mdata.Split('-')[0].ToString();
                    checkfiltro.Text = string.Empty;
                    checkfiltro.CheckedChanged += Filtros_ValueChanged;                    
                    flpFiltros.Controls.AddRange(new Control[] { labelencabezado, checkfiltro });
                    gridfiltro._AgregarFiltro(new GridFiltrado.Elementos_Grid.Filtro(mdata.Split('-')[0].ToString(),
                            0, GridFiltrado.Elementos_Grid.TipoValor.NUMERICO));
                }
                else
                { }
                Button mbtn = new Button();
                mbtn.Text = "Restaurar";
                mbtn.Name = "restaurar";
                mbtn.Click += Mbtn_Click;
                flpFiltros.Controls.Add(mbtn);
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void cnt_CambiarCoincidencia(object sender, CambioCoincidenciaEventArgs e)
        {
            try
            {
                Control c = (Control)sender;
                GridFiltrado.Elementos_Grid.Filtro f= gridfiltro.ObtenerFiltro(Convert.ToString(c.Tag), GridFiltrado.Elementos_Grid.TipoFiltro.FILTRO_DRAGDROP);
                f.TipoCoincidencia = e.TipoCoincidencia;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }            
        }
        private void Mbtn_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarFiltros();
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Filtros_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Control c = (Control)sender;
                if (c.GetType() == typeof(FiltroTexto))
                {
                    gridfiltro.ObtenerFiltro(Convert.ToString(c.Tag), GridFiltrado.Elementos_Grid.TipoFiltro.FILTRO_DRAGDROP).Valor = ((FiltroTexto)sender).Text;
                }
                else if (c.GetType() == typeof(FiltroFechas))
                {
                    gridfiltro.ObtenerFiltro(Convert.ToString(c.Tag), GridFiltrado.Elementos_Grid.TipoFiltro.FILTRO_DRAGDROP).Valor = new DateTime[] { ((FiltroFechas)sender).FechaDesde,
                        ((FiltroFechas)sender).FechaHasta};
                }
                else if (c.GetType() == typeof(FiltroNumerico))
                {
                    gridfiltro.ObtenerFiltro(Convert.ToString(c.Tag), GridFiltrado.Elementos_Grid.TipoFiltro.FILTRO_DRAGDROP).Valor = ((FiltroNumerico)sender).Value;
                }
                else if (c.GetType() == typeof(CheckBox))
                {
                    gridfiltro.ObtenerFiltro(Convert.ToString(c.Tag), GridFiltrado.Elementos_Grid.TipoFiltro.FILTRO_DRAGDROP).Valor = Convert.ToInt32(((CheckBox)sender).Checked);
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void flpagrupaciones_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string mdata = e.Data.GetData("Text").ToString();
                    if (!flpagrupaciones.Controls.ContainsKey(mdata.Split('-')[0]))
                    {
                        e.Effect = DragDropEffects.Copy;
                    }                        
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void flpagrupaciones_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (gridfiltro == null)
                {
                    throw new ArgumentException("No se ha asignado un valor de fuente valido", "gridfiltrado");
                }               
                string mdata = e.Data.GetData("Text").ToString();
                lbindicador.Visible = false;
                flpagrupaciones.Controls.RemoveByKey("restaurar");
                Button btngrupo = new Button();
                btngrupo.Text = mdata.Split('-')[1];
                btngrupo.Name = mdata.Split('-')[0];
                btngrupo.Tag = mdata.Split('-')[0];
                btngrupo.Click += grupo_Click;
                btngrupo.FlatStyle = FlatStyle.Flat;
                flpagrupaciones.Controls.Add(btngrupo);
                gridfiltro._AgregarGrupo(btngrupo.Name);
                Button mbtn = new Button();
                mbtn.Text = "Restaurar";
                mbtn.Name = "restaurar";
                mbtn.Click += Mbtn_Click1; ;
                flpagrupaciones.Controls.Add(mbtn);             
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void Mbtn_Click1(object sender, EventArgs e)
        {
            try
            {                
                gridfiltro._LimpiarGrupos();
                flpagrupaciones.Controls.Clear();
                flpagrupaciones.Controls.Add(lbindicador);
                lbindicador.Visible = true;
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void grupo_Click(object sender, EventArgs e)
        {
            try
            {
                Control c = (Control)sender;
                gridfiltro._EliminarGrupo(Convert.ToString(c.Tag));
                flpagrupaciones.Controls.Remove(c);
                if (flpagrupaciones.Controls.Count == 2)
                {
                    lbindicador.Visible = true;
                    flpagrupaciones.Controls.RemoveByKey("restaurar");
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);                
            }
        }
        private void ttToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem tsm = (ToolStripMenuItem)sender;                
                foreach (ToolStripMenuItem c in btntotales.DropDownItems)
                {
                    c.Checked = Convert.ToInt32(c.Tag) == Convert.ToInt32(tsm.Tag);
                }
                gridfiltro.Total = (GridFiltrado.Elementos_Grid.TOTAL)Convert.ToInt32(tsm.Tag);
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
        private void btnformularcolumna_Click(object sender, EventArgs e)
        {
            try
            {
                bool continuar_formulada = true;                
                GridFiltrado.Elementos_Grid.ColumnaFormulada cform = null;
                if (gridfiltro.Columnas_Formuladas.Count > 0)
                {
                    FrmColumnasFormuladas fms = new FrmColumnasFormuladas();
                    fms.Columnas_Formuladas = gridfiltro.Columnas_Formuladas;
                    if (fms.ShowDialog() == DialogResult.OK)
                    {
                        cform = gridfiltro.ObtenerColumna(fms.Columna_Seleccionada);                        
                    }
                    else
                    { continuar_formulada = false; }
                }
                if (continuar_formulada)
                {
                    FrmColumnaFormulada fcf = new FrmColumnaFormulada();
                    if (cform != null)
                    {
                        fcf.Nombre_Columna = cform.Nombre_Columna;
                        fcf.Expresion = cform.Expresion;
                        fcf.Posicion = cform.Posicion;
                    }
                    fcf.Tabla_Datos = gridfiltro.TablaDatos;
                    if (fcf.ShowDialog() == DialogResult.OK)
                    {
                        if (cform != null)
                        {
                            cform.Nombre_Columna = fcf.Nombre_Columna;
                            cform.Expresion = fcf.Expresion;
                            cform.Posicion = fcf.Posicion;
                        }
                        else
                        {
                            gridfiltro.AgregarColumnaFormulada(fcf.Nombre_Columna,
                                fcf.Expresion, fcf.Posicion);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }
        }
    }
}
