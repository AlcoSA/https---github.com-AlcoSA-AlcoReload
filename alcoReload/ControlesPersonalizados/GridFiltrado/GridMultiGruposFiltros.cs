using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text;
using DatagridTreeView;
using System.Data;
using System.Collections.ObjectModel;

namespace ControlesPersonalizados.GridFiltrado
{
    public class GridMultiGruposFiltros : DataTreeGridView
    {
        #region enums
        protected enum TipoCarga
        {
            NORMAL = 0,
            GRUPOS = 1
        }
        #endregion
        #region vars
        private DataTable tabladatos = null;        
        private Boolean mostrarFiltros = true;
        int filaActualimpresion = 0;
        Elementos_Grid.Filtros filtros;
        Elementos_Grid.Grupos grupos;
        Elementos_Grid.ColumnasFormuladas columnas_formuladas;
        TipoCarga tipocarga = TipoCarga.NORMAL;
        Elementos_Grid.TOTAL total = Elementos_Grid.TOTAL.NINGUNA;
        #endregion
        #region ctor
        public GridMultiGruposFiltros()
        {
            this.BackgroundColor = Color.White;
            this.RowHeadersVisible = true;
            this.RowHeadersWidth = 25;
            this.BorderStyle = BorderStyle.Fixed3D;
            filtros = new Elementos_Grid.Filtros();
            grupos = new Elementos_Grid.Grupos();
            columnas_formuladas = new Elementos_Grid.ColumnasFormuladas();
        }
        #endregion
        #region props
        public DataTable TablaDatos
        {
            get { return tabladatos; }
            set
            {
                tabladatos = value;
                this.AutoGenerateColumns = !(this.Columns.Count > 0 || columnas_formuladas.Count > 0);                
                Filtrar();                
            }
        }
        [Browsable(true)]
        public Boolean MostrarFiltros
        {
            get { return mostrarFiltros; }
            set { mostrarFiltros = value; }
        }
        public Elementos_Grid.TOTAL Total
        {
            get { return total; }
            set { total = value;
                Filtrar();
            }
        }

        public ReadOnlyCollection<Elementos_Grid.Filtro> Filtros
        {
            get { return filtros.ToList().AsReadOnly(); }
        }
        public ReadOnlyCollection<Elementos_Grid.Grupo> Grupos
        {
            get { return grupos.ToList().AsReadOnly(); }
        }
        public ReadOnlyCollection<Elementos_Grid.ColumnaFormulada> Columnas_Formuladas
        {
            get { return columnas_formuladas.ToList().AsReadOnly(); }
        }
        #endregion
        #region Procedimientos
        public void Reiniciar_Grid()
        {
                grupos.Clear();
                filtros.Clear();
                columnas_formuladas.Clear();
                total = Elementos_Grid.TOTAL.NINGUNA;
        }
        public void Imprimir(bool vistaprevia = false)
        {
            try
            {
                System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
                PrintDialog frmimp = new PrintDialog();
                frmimp.Document = doc;
                if (frmimp.ShowDialog() == DialogResult.OK)
                {
                    doc.PrintPage += Doc_PrintPage;
                    if (vistaprevia)
                    {
                        PrintPreviewDialog frmimpprevio = new PrintPreviewDialog();
                        frmimpprevio.Document = doc;
                        frmimpprevio.Show();
                    }
                    else
                    {
                        doc.Print();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error generando impresión" + ex.Message, ex.InnerException);
            }
        }
        private void Doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int x = e.MarginBounds.Left;
                int saltLinea = e.PageSettings.Margins.Top;
                int alturaagregada = Convert.ToInt32(e.Graphics.MeasureString("A", this.Font).Height);
                //ENCABEZADO
                e.Graphics.DrawString(DateTime.Now.ToString(), new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold), SystemBrushes.WindowText, new Point(x, saltLinea - alturaagregada - 5));
                e.Graphics.DrawLine(SystemPens.WindowText, new Point(x, saltLinea - 3), new Point(e.MarginBounds.Right, saltLinea - 3));

                if (filaActualimpresion == 0)
                {
                    for (int j = 0; j < this.Columns.Count; j++)
                    {
                        if (this.Columns[j].Visible)
                        {
                            Rectangle r = new Rectangle(new Point(x, saltLinea), new Size(this.Columns[j].Width, alturaagregada));
                            e.Graphics.DrawString(this.Columns[j].HeaderText, new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold), SystemBrushes.WindowText, r, new StringFormat());
                            e.Graphics.DrawRectangle(SystemPens.Control, r);
                            x += r.Width;
                        }

                    }
                    x = e.MarginBounds.Left;
                    saltLinea += alturaagregada;
                }

                //TERMINA ENCABEZADO

                //CONTENIDO DEL GRID
                for (int i = filaActualimpresion; i < this.Rows.Count; i++)
                {
                    for (int j = 0; j < this.Columns.Count; j++)
                    {
                        if (this.Columns[j].Visible)
                        {
                            Rectangle r = new Rectangle(new Point(x, saltLinea), new Size(this.Columns[j].Width, alturaagregada));
                            e.Graphics.DrawString(this[j, i].Value.ToString(), this.Font, SystemBrushes.WindowText, r, new StringFormat());
                            e.Graphics.DrawRectangle(SystemPens.Control, r);
                            x += r.Width;
                        }
                    }
                    filaActualimpresion++;
                    saltLinea += alturaagregada;
                    x = e.MarginBounds.Left;
                    //VERIFICACION                    
                    e.HasMorePages = (saltLinea >= e.MarginBounds.Bottom);
                }
                //TERMINA CONTENIDO

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ConstruirFiltrosExcel()
        {
            try
            {                
                foreach (DataGridViewColumn c in this.Columns)
                {
                    if (c.Tag != null)
                    {
                        if (((object[])c.Tag).Count() <= 0)
                        {
                            filtros.RemoveAt(c.Name);
                        }
                        else
                        {
                            Elementos_Grid.Filtro f;
                            if (filtros[c.Name, Elementos_Grid.TipoFiltro.FILTRO_EXCEL] != null)
                            {
                                f = filtros[c.Name, Elementos_Grid.TipoFiltro.FILTRO_EXCEL];
                                f.Cambiar_Valor_Sin_Trigger(c.Tag);
                            }
                            else
                            {
                                f = null;
                                Type coltype = tabladatos.Columns[c.Name].DataType;
                                if (coltype == Type.GetType("System.String"))
                                {
                                    f = new Elementos_Grid.Filtro(c.Name, c.Tag,
                                        Elementos_Grid.TipoValor.MULTIPLES_VALORES_TEXTO, Elementos_Grid.TipoCoincidencia.IGUALQUE,
                                         Elementos_Grid.TipoFiltro.FILTRO_EXCEL);
                                }
                                else if (coltype == Type.GetType("System.DateTime"))
                                {
                                    f = new Elementos_Grid.Filtro(c.Name, c.Tag,
                                    Elementos_Grid.TipoValor.MULTIPLES_VALORES_FECHA, Elementos_Grid.TipoCoincidencia.IGUALQUE,
                                     Elementos_Grid.TipoFiltro.FILTRO_EXCEL);
                                }
                                else if (coltype == Type.GetType("System.Int16") || coltype == Type.GetType("System.Int32") ||
                                     coltype == Type.GetType("System.Int64") || coltype == Type.GetType("System.Double") ||
                                     coltype == Type.GetType("System.Decimal") || coltype == Type.GetType("System.Boolean"))
                                {
                                    f = new Elementos_Grid.Filtro(c.Name, c.Tag,
                                    Elementos_Grid.TipoValor.MULTIPLES_VALORES_NUMERICOS, Elementos_Grid.TipoCoincidencia.IGUALQUE,
                                     Elementos_Grid.TipoFiltro.FILTRO_EXCEL);
                                }
                                filtros.Add(f);
                            }
                        }
                    }
                    else
                    {
                        Elementos_Grid.Filtro f = ObtenerFiltro(c.Name, Elementos_Grid.TipoFiltro.FILTRO_EXCEL);
                        if (f != null)
                            filtros.Remove(f);
                    }
                }
                Filtrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AgregarTotalTabla(ref DataTable tabla)
        {
            try
            {
                DataRow r = tabla.NewRow();
                foreach (DataColumn c in tabla.Columns)
                {
                    if (c.DataType == Type.GetType("System.Double") || c.DataType == Type.GetType("System.Decimal"))
                    {
                        r[c.ColumnName] = tabla.AsEnumerable().Sum(x => Convert.ToDecimal(x[c.ColumnName]));
                    }
                    else if (c.DataType == Type.GetType("System.Int16") || c.DataType == Type.GetType("System.Int32") ||
                     c.DataType == Type.GetType("System.Int64"))
                    {
                        r[c.ColumnName] = 0;
                    }
                    else if (c.DataType == Type.GetType("System.DateTime"))
                    {
                        r[c.ColumnName] = DateTime.Now;
                    }
                    else if (c.DataType == Type.GetType("System.Boolean"))
                    {
                        r[c.ColumnName] = false;
                    }
                    else { r[c.ColumnName] = string.Empty; }
                }
                switch (total)
                {
                    case Elementos_Grid.TOTAL.PRIMERAFILA:
                        {
                            tabla.Rows.InsertAt(r, 0);
                            break;
                        }
                    case Elementos_Grid.TOTAL.ULTIMAFILA:
                        {
                            tabla.Rows.Add(r);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        private void cargarTabla(DataTable tabla)
        {
            if (tipocarga == TipoCarga.GRUPOS)
            {
                this.Nodes.Clear();
                this.Columns.RemoveAt(0);
                foreach (Elementos_Grid.ColumnaFormulada cf in columnas_formuladas)
                {
                    DataGridViewColumn c = this.Columns[cf.Nombre_Columna];
                    if (c != null) { this.Columns.Remove(c); }
                }
            }
            if(tabla!=null)
            {
                if (total != Elementos_Grid.TOTAL.NINGUNA) { AgregarTotalTabla(ref tabla); }
                tabla.Columns.Cast<DataColumn>().ToList().ForEach(
                   delegate (DataColumn c)
                   {
                       if (this.Columns.Contains(c.ColumnName))
                       {
                           this.Columns[c.ColumnName].DataPropertyName = c.ColumnName;
                       }
                   }
                   );
            }            
            this.DataSource = tabla;
            tipocarga = TipoCarga.NORMAL;    
        }
        private DataTable AgruparTabla(DataTable tabla, string campo)
        {
            return tabla.AsEnumerable().GroupBy(d => d[campo]).Select(g => g.First()).CopyToDataTable();
        }
        private DataTable FiltrarTabla(DataTable tabla, string campo, string valor)
        {
            return tabla.AsEnumerable().Where(d => Convert.ToString(d[campo]) == valor).CopyToDataTable();
        }
        private void cargarTablaAgrupaciones(DataTable tabla, DataGridViewTreeNode nodobase = null,
            int indice = 0)
        {
            if (indice == 0)
            {
                #region BASE
                if (tipocarga == TipoCarga.GRUPOS)
                {
                    this.Nodes.Clear();
                }
                else
                {
                    this.DataSource = null;
                }

                if (this.Columns.Count > 0)
                {
                    if (this.Columns[0].GetType() != typeof(DataGridViewTreeColumn))
                    {
                        DataGridViewTreeColumn cnode = new DataGridViewTreeColumn();
                        cnode.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        this.Columns.Insert(0, cnode);
                    }
                    if (columnas_formuladas.Count > 0)
                    {
                        foreach (Elementos_Grid.ColumnaFormulada cf in columnas_formuladas)
                        {
                            if (!this.Columns.Contains(cf.Nombre_Columna))
                            {
                                this.Columns.Add(cf.Nombre_Columna, cf.Nombre_Columna);
                            }                            
                        }
                    }
                }
                else
                {
                    DataGridViewTreeColumn cnode = new DataGridViewTreeColumn();
                    cnode.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    this.Columns.Insert(0, cnode);
                    foreach (DataColumn c in tabla.Columns)
                    {
                        this.Columns.Add(c.ColumnName, c.Caption);
                    }
                }
                #endregion
            }

                var t = AgruparTabla(tabla, grupos[indice].Nombre_Columna);
                foreach (DataRow R in t.Rows)
                {                    
                    DataGridViewTreeNode N = new DataGridViewTreeNode();
                    if (nodobase == null) { this.Nodes.Add(N); } else { nodobase.Nodes.Add(N); }                    
                    N.Cells[0].Value = R[grupos[indice].Nombre_Columna];
                    var t1 = FiltrarTabla(tabla, grupos[indice].Nombre_Columna,Convert.ToString(R[grupos[indice].Nombre_Columna]));
                    N.Cells[0].Value = Convert.ToString(R[grupos[indice].Nombre_Columna]) + " Resultados encontrados: " + Convert.ToString(t1.Rows.Count);

                    if (indice == grupos.Count - 1)
                    {
                    if (total != Elementos_Grid.TOTAL.NINGUNA) { AgregarTotalTabla(ref t1); }
                    foreach (DataRow r in t1.Rows)
                        {
                            DataGridViewTreeNode n = new DataGridViewTreeNode();
                            N.Nodes.Add(n);
                            foreach (DataColumn c in t1.Columns)
                            {
                            if (this.Columns.Contains(c.ColumnName))
                            {
                                n.Cells[this.Columns[c.ColumnName].Index].Value = r[c.ColumnName];
                            }                                
                            }
                        }
                    }
                    else
                    {
                        cargarTablaAgrupaciones(t1, N, indice + 1);
                    }
                    
                }            
            tipocarga = TipoCarga.GRUPOS;
        }
        #endregion
        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            base.OnCellMouseDown(e);
            try
            {
                if (e.Button == MouseButtons.Right && e.RowIndex == -1)
                {
                    if (!(this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewImageColumn)))
                    {
                        this.DoDragDrop(this.Columns[e.ColumnIndex].Name + "-" + this.Columns[e.ColumnIndex].HeaderText, DragDropEffects.All);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
            try
            {
                if (tabladatos != null)
                {
                    if (e.ColumnIndex >= 0)
                    {
                        if (!(this.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewImageColumn)) && e.RowIndex == -1)
                        {
                            e.PaintBackground(e.CellBounds, e.State == DataGridViewElementStates.Selected);
                            StringFormat sf = new StringFormat();
                            sf.Alignment = StringAlignment.Center;
                            sf.LineAlignment = StringAlignment.Far;
                            e.Graphics.DrawString(this.Columns[e.ColumnIndex].HeaderText,
                                this.Font, SystemBrushes.WindowText, e.CellBounds, sf);
                            Rectangle ri = new Rectangle(e.CellBounds.Width - 19, e.CellBounds.Y + 3, 16, 16);
                            Rectangle rj = new Rectangle(3, e.CellBounds.Y + 3, 16, 16);
                            List<Rectangle> listaRectangulos = new List<Rectangle>();
                            if (mostrarFiltros)
                            {
                                e.Graphics.DrawImage(Properties.Resources.Filtro_12x12, e.CellBounds.X + ri.Location.X + 2,
                                    ri.Location.Y + 2, 12, 12);
                            }
                            listaRectangulos.Add(ri);
                            if (this.Columns[e.ColumnIndex].Tag != null)
                            {
                                listaRectangulos.Add(rj);
                            }
                            this.Columns[e.ColumnIndex].HeaderCell.Tag = listaRectangulos;
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        if (e.RowIndex == -1)
                        {
                            e.PaintBackground(e.CellBounds, e.State == DataGridViewElementStates.Selected);
                            e.PaintContent(e.ClipBounds);
                            e.Graphics.DrawImage(Properties.Resources.Filtrar_visibilidad_16x16, e.CellBounds.X + (e.CellBounds.Width / 2) - (6),
                                e.CellBounds.Y + (e.CellBounds.Height / 2) - (6), 12, 12);
                            e.Handled = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (mostrarFiltros)
                {
                    if (this.Columns[e.ColumnIndex].HeaderCell.Tag != null)
                    {
                        if (e.ColumnIndex >= 0)
                        {
                            List<Rectangle> listaRectangulos = (List<Rectangle>)this.Columns[e.ColumnIndex].HeaderCell.Tag;
                            Rectangle recfiltro = listaRectangulos[0];

                            if (recfiltro.Contains(e.X, e.Y))
                            {
                                FrmfiltroGrid ffiltro = new FrmfiltroGrid();
                                ffiltro.Grid = this;
                                Point pt = PointToScreen(this.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location);
                                pt.Y += this.ColumnHeadersHeight;
                                if (pt.Y + ffiltro.Height >= Screen.PrimaryScreen.WorkingArea.Height)
                                {
                                    pt.Y -= ffiltro.Height;
                                }
                                ffiltro.ColumnaSeleccionada = this.Columns[e.ColumnIndex].Name;
                                ffiltro.Location = pt;
                                ffiltro.Show();
                            }
                            else
                            {
                                base.OnColumnHeaderMouseClick(e);
                            }
                            Rectangle reccierrefiltro;
                            if (listaRectangulos.Count > 1)
                            {
                                reccierrefiltro = listaRectangulos[1];
                                if (reccierrefiltro.Contains(e.X, e.Y))
                                {                                    
                                    this.Columns[e.ColumnIndex].Tag = null;
                                    _EliminarFiltro(this.Columns[e.ColumnIndex].Name);
                                }
                                else
                                {
                                    base.OnColumnHeaderMouseClick(e);
                                }
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
        protected override void OnCellMouseClick(DataGridViewCellMouseEventArgs e)
        {
            base.OnCellMouseClick(e);
            if (e.RowIndex < 0 && e.ColumnIndex < 0)
            {
                FrmVisibilidadColumnas ffiltro = new FrmVisibilidadColumnas();
                ffiltro.Grid = this;
                Point pt = PointToScreen(this.GetCellDisplayRectangle(0, -1, false).Location);
                pt.Y += this.ColumnHeadersHeight;
                ffiltro.Location = pt;
                ffiltro.Show();
            }
        }
        private void Filtrar()
        {
            try
            {
                if (tabladatos != null)
                {
                    string filtro = filtros.ObtenerFiltroSelect();
                    DataRow[] rs = tabladatos.Select(filtro);
                    DataTable tablanueva = tabladatos.Copy();
                    tablanueva.Rows.Clear();
                    for (int i = 0; i < rs.Count(); i++)
                    {
                        tablanueva.ImportRow(rs[i]);
                    }
                    CrearColumnasFormuladas(ref tablanueva);
                    if (grupos.Count > 0)
                    {
                        cargarTablaAgrupaciones(tablanueva);
                    }
                    else
                    { cargarTabla(tablanueva); }
                }
                else
                {
                    cargarTabla(null);
                }
            }
            catch (Exception ex)
            {
                ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica);
            }

        }

        #region Filtros
        internal void _AgregarFiltro(Elementos_Grid.Filtro filtro)
        {
            filtro.ValorChanged += Filtro_ValorChanged;
            filtros.Add(filtro);
        }
        private void Filtro_ValorChanged(object sender, Elementos_Grid.FiltroValorChangedEventargs e)
        {
            Filtrar();
        }
        internal void _EliminarFiltro(string nombre_columna)
        {
            filtros.RemoveAt(nombre_columna);
            Filtrar();
        }
        internal Elementos_Grid.Filtro ObtenerFiltro(string nombre_columna, Elementos_Grid.TipoFiltro tipofiltro)
        {
            return filtros[nombre_columna, tipofiltro];
        }
        #endregion

        #region Grupos
        public void AgregarGrupo(string nombre_columna)
        {
            grupos.Add(new Elementos_Grid.Grupo(nombre_columna));            
        }
        public void EliminarGrupo(string nombre_columna)
        {
            grupos.RemoveAt(nombre_columna);            
        }
        public void LimpiarGrupos()
        {
            grupos.Clear();            
        }
        internal void _AgregarGrupo(string nombre_columna)
        {            
            grupos.Add(new Elementos_Grid.Grupo(nombre_columna));
            Filtrar();
        }
        internal void _EliminarGrupo(string nombre_columna)
        {
            grupos.RemoveAt(nombre_columna);
            Filtrar();
        }
        internal void _LimpiarGrupos()
        {
            grupos.Clear();
            Filtrar();
        }
        #endregion

        #region Columnas Formuladas
        private void CrearColumnasFormuladas(ref DataTable tabla)
        {
            foreach (Elementos_Grid.ColumnaFormulada cf in columnas_formuladas)
            {
                DataColumn c = new DataColumn(cf.Nombre_Columna);
                c.Expression = cf.Expresion;
                tabla.Columns.Add(c);
                c.SetOrdinal(cf.Posicion);
            }
        }
        public Elementos_Grid.ColumnaFormulada ObtenerColumna(string nombre_columna)
        {
            try
            {
                return columnas_formuladas[nombre_columna];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public void AgregarColumnaFormulada(string nombre_columna, string expresion, int posicion)
        {
            try
            {
                columnas_formuladas.Add(new Elementos_Grid.ColumnaFormulada(nombre_columna, expresion, posicion));
                this.AutoGenerateColumns = true;
                Filtrar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public void EliminarListaColumnasFormuladas(string[] lista_columnas_formuladas)
        {
            try
            {
                for (int i = 0; i < lista_columnas_formuladas.Length; i++)
                {
                   Elementos_Grid.ColumnaFormulada cf= columnas_formuladas[lista_columnas_formuladas[i]];
                    if (cf != null)
                    {
                        columnas_formuladas.Remove(cf);
                        if (tipocarga == TipoCarga.GRUPOS)
                        {
                            DataGridViewColumn c = this.Columns[cf.Nombre_Columna];
                            if (c != null) { this.Columns.Remove(c); }
                        }                        
                    }
                }
                Filtrar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Exportar
        private void creartablaagrupada(ref DataTable tabla, DataGridViewTreeNode nodobase = null)
        {
            if (nodobase == null)
            {
                foreach (DataGridViewTreeNode n in this.Nodes)
                {
                    DataRow filanueva = tabla.NewRow();
                    for (int i = 0; i < this.Columns.Count; i++)
                    {
                        if (tabla.Columns.Contains(this.Columns[i].Name))
                        {
                            filanueva[this.Columns[i].Name] = Convert.ToString(n.Cells[i].Value);
                        }
                        tabla.Rows.Add(filanueva);
                        if (n.Nodes.Count > 0)
                        {
                            creartablaagrupada(ref tabla, n);
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewTreeNode n in nodobase.Nodes)
                {
                    DataRow filanueva = tabla.NewRow();
                    for (int i = 0; i < this.Columns.Count; i++)
                    {
                        if (tabla.Columns.Contains(this.Columns[i].Name))
                        {
                            filanueva[this.Columns[i].Name] = Convert.ToString(n.Cells[i].Value);
                        }
                        tabla.Rows.Add(filanueva);
                        if (n.Nodes.Count > 0)
                        {
                            creartablaagrupada(ref tabla, n);
                        }
                    }
                }
            }
        }
        public void ExportaraExcel()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.AddExtension = true;
                sfd.DefaultExt = "xls";
                sfd.Filter = "Documento de Excel | *.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (tabladatos == null)
                    {
                        DataTable tb = new DataTable();
                        for (int i = 0; i < this.Columns.Count; i++)
                        {
                            tb.Columns.Add(new DataColumn(this.Columns[i].Name));
                        }
                        if (this.Nodes.Count > 0)
                        { creartablaagrupada(ref tb); }
                        else
                        {
                            for (int i = 0; i < this.Rows.Count; i++)
                            {
                                DataRow filanueva = tb.NewRow();
                                for (int j = 0; j < this.Columns.Count; j++)
                                {
                                    filanueva[j] = Convert.ToString(this[j, i].Value);
                                }
                            }
                        }

                    }
                    else
                    {
                        DataTable tb = tabladatos.Copy();
                        for (int i = 0; i < this.Columns.Count; i++)
                        {
                            if (tb.Columns.Contains(this.Columns[i].Name))
                            {
                                if (!this.Columns[i].Visible)
                                {
                                    tb.Columns.Remove(this.Columns[i].Name);
                                }
                            }
                        }
                        switch (tipocarga)
                        {
                            case TipoCarga.NORMAL:
                                {   
                                    FormatosExportacion.Excel.Excel_XML exc = new FormatosExportacion.Excel.Excel_XML(sfd.FileName, "sistema_alco_mrp");
                                    exc.Exportar(new DataTable[] { tb });
                                    break; }
                            case TipoCarga.GRUPOS:
                                {
                                    DataColumn c = new DataColumn(this.Columns[0].Name, typeof(string));
                                    tb.Columns.Add(c);
                                    c.SetOrdinal(0);
                                    creartablaagrupada(ref tb);
                                    FormatosExportacion.Excel.Excel_XML exc = new FormatosExportacion.Excel.Excel_XML(sfd.FileName, "sistema_alco_mrp");
                                    exc.Exportar(new DataTable[] { tb });
                                    break; }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        #endregion
    }
}