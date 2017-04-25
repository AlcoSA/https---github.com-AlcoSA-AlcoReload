Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Informes
Imports ReglasNegocio
Imports Validaciones
Imports System.IO

Public Class FrmListadoNotas
#Region "Variables"
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private objValidacion As ClsValidaciones
    Private fuenteInicial As DataTable = Nothing
    Private mNotaCobro As ClsNotasCobro
    Private _dsInformes As New datosInformesTableAdapters.sp_tc053_selectByIdXMLTableAdapter
#End Region
#Region "Procedimientos"
    Private Sub Anular()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            If Convert.ToInt32(r.Cells(idEstado.DataPropertyName).Value) = ClsEnums.Estados.PAGADO Then
                MessageBox.Show("La nota de cobro ya se encuentra pagada", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Convert.ToInt32(r.Cells(idEstado.DataPropertyName).Value) = ClsEnums.Estados.ANULADO Then
                MessageBox.Show("La nota de cobro ya se encuentra anulada", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If MessageBox.Show("¿Esta seguro de anular la nota de cobro?", "",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim mAnticipoxNota As New clsAnticiposPorNota
                Dim listCuotaxNotaCobro As List(Of CuotaxNotaCobro) = mAnticipoxNota.TraerxIdNotaCobro(r.Cells(id.DataPropertyName).Value)
                Dim mMovitoAnticipo As New clsMovitoPlanAnticipos
                For Each cuota As CuotaxNotaCobro In listCuotaxNotaCobro
                    mMovitoAnticipo.ActualizarEstado(cuota.IdMovitoAnticipo, ClsEnums.Estados.ACTIVO)
                    Dim movito As cuota = mMovitoAnticipo.traerxId(cuota.IdMovitoAnticipo)
                    Dim mPlanAnticipo As New ClsPlanAnticipos
                    mPlanAnticipo.ActualizarEstado(movito.idPlananticipo, ClsEnums.Estados.ACTIVO)
                Next
                mNotaCobro = New ClsNotasCobro
                mNotaCobro.ActualizarEstado(r.Cells(id.DataPropertyName).Value, ClsEnums.Estados.ANULADO)
                mAnticipoxNota.UpdateAnticipoxCuota(r.Cells(id.DataPropertyName).Value, ClsEnums.Estados.ANULADO)
                FrmListadoNotas_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Pagada()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            If Convert.ToInt32(r.Cells(idEstado.DataPropertyName).Value) = ClsEnums.Estados.PAGADO Then
                MessageBox.Show("La nota de cobro ya se encuentra pagada", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Convert.ToInt32(r.Cells(idEstado.DataPropertyName).Value) = ClsEnums.Estados.ANULADO Then
                MessageBox.Show("La nota de cobro ya se encuentra anulada", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If MessageBox.Show("Se actualizará el estado de la nota de cobro a PAGADO. ¿Desea continuar?", "",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                mNotaCobro = New ClsNotasCobro
                mNotaCobro.ActualizarEstado(r.Cells(id.DataPropertyName).Value, ClsEnums.Estados.PAGADO)

                Dim mAnticipoPorNota As New clsAnticiposPorNota
                mAnticipoPorNota.UpdateAnticipoxCuota(r.Cells(id.DataPropertyName).Value, ClsEnums.Estados.PAGADO)

                Dim listCuotaxNotaCobro As List(Of CuotaxNotaCobro) = mAnticipoPorNota.TraerxIdNotaCobro(r.Cells(id.DataPropertyName).Value)
                Dim mPlanAnticipo As New ClsPlanAnticipos
                Dim mMovitoAnticipo As New clsMovitoPlanAnticipos
                For Each item As CuotaxNotaCobro In listCuotaxNotaCobro
                    mMovitoAnticipo.ActualizarEstado(item.IdMovitoAnticipo, ClsEnums.Estados.PAGADO)
                    Dim movitoAnticipo As cuota = mMovitoAnticipo.traerxId(item.IdMovitoAnticipo)
                    If mPlanAnticipo.TraerPendientesxPagar(movitoAnticipo.idPlananticipo) = 0 Then
                        mPlanAnticipo.ActualizarEstado(movitoAnticipo.idPlananticipo, ClsEnums.Estados.PAGADO)
                    End If
                Next
                FrmListadoNotas_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub verDetalle()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim frm As New FrmVerDetalleNota
            frm.IdNotaCobro = r.Cells(id.DataPropertyName).Value
            frm.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub imprimir()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim idNota As Integer = Convert.ToInt32(r.Cells(id.DataPropertyName).Value)

            Dim ds As New DataSet
            Dim dt As DataTable
            dt = _dsInformes.GetData(idNota).CopyToDataTable
            dt.TableName = "NotaCobro"
            ds.Tables.Add(dt)
            'ds.WriteXmlSchema(io.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "NotaCobro.xml"))
            Dim b As New Informes.NotadeCobroXml
            b.SetDataSource(ds)

            b.PrintToPrinter(1, False, 0, 1)

            ActualizarImpresiones(idNota, 1)
            MessageBox.Show("Impresión completa", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub exportarExcel()
        Try
            Dim _save As New SaveFileDialog()
            _save.Filter = "Excel (XML Excel (*.xml)|*.xml | Todos los Archivos (*.*) |*.*"
            _save.ShowDialog()
            Dim expExcel As New FormatosExportacion.Excel.Excel_XML(_save.FileName, System.Security.Principal.WindowsIdentity.GetCurrent().Name)
            expExcel.Exportar(New DataTable() {dwItems.TablaDatos})
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub exportarPdf()
        Try
            'Intentar generar el documento.
            Dim doc As New Document(PageSize.LEGAL.Rotate(), 10, 10, 10, 10)
            'Path que guarda el reporte en el escritorio de windows (Desktop).
            Dim filename As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\Reportenotas.pdf"
            Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
            PdfWriter.GetInstance(doc, file)
            doc.Open()
            ExportarDatosPDF(doc)
            doc.Dispose()
            doc.Close()
            Process.Start(filename)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ActualizarImpresiones(idNota As Integer, impresionesNuevas As Integer)
        Try
            mNotaCobro = New ClsNotasCobro
            Dim impresionesActuales As Integer = mNotaCobro.TraerNumeroImpresiones(idNota)
            mNotaCobro.ActualizarNumImpresiones(idNota, impresionesActuales + impresionesNuevas)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Exportar a PDF"
    'La funcion se usara en el metodo para crear el reporte en PDF.
    Public Function GetColumnasSize(ByVal dg As DataGridView) As Single()
        Dim values As Single() = New Single(dg.ColumnCount - 1) {}
        For i As Integer = 0 To dg.ColumnCount - 1
            values(i) = CSng(dg.Columns(i).Width)
        Next
        Return values
    End Function


    Public Sub ExportarDatosPDF(ByRef document As Document)
        'Se crea un objeto PDFTable con el numero de columnas del DataGridView.
        Dim datatable As New PdfPTable(dwItems.Columns.Count)
        'Dim pdfFila As PdfPRow
        'Se asignan algunas propiedades para el diseño del PDF.
        datatable.DefaultCell.Padding = 3
        Dim headerwidths As Single() = GetColumnasSize(dwItems)
        datatable.SetWidths(headerwidths)
        datatable.WidthPercentage = 100
        datatable.DefaultCell.BorderWidth = 2
        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        'Se crea el encabezado en el PDF. 
        Dim encabezado As New Paragraph("LISTADO NOTAS DE COBRO", New Font(Font.Name = "Tahoma", 20, Font.Bold))

        'Se crea el texto abajo del encabezado.
        Dim texto As New Phrase("Reporte productos:" + Now.Date(), New Font(Font.Name = "Tahoma", 14, Font.Bold))
        'Se capturan los nombres de las columnas del DataGridView.
        For i As Integer = 0 To dwItems.ColumnCount - 1
            datatable.AddCell(dwItems.Columns(i).HeaderText)
        Next
        'For Each FILA As DataGridViewRow In dwItems.Rows
        '    For Each columan As DataGridViewColumn In dwItems.Columns

        '        pdfFila.WriteCells(0, 30, CSng(columan.Width), CSng(columan.CellTemplate.))
        '    Next
        'Next

        datatable.HeaderRows = 1
        datatable.DefaultCell.BorderWidth = 1
        'Se generan las columnas del DataGridView.
        For Each r As DataGridViewRow In dwItems.Rows
            For i As Integer = 0 To dwItems.ColumnCount - 1
                If IsNothing(r.Cells(i).Value) Then
                    datatable.AddCell("")
                Else
                    datatable.AddCell(r.Cells(i).Value.ToString)
                End If
            Next
            datatable.CompleteRow()
        Next
        'Se agrega el PDFTable al documento.
        document.Add(encabezado)
        document.Add(texto)
        document.Add(datatable)
        document.Close()
        document.CloseDocument()
    End Sub
#End Region
    Private Sub FrmListadoNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mNotaCobro = New ClsNotasCobro
            mNotaCobro.TraerTodos(dwItems.TablaDatos)
            dwItems.AutoGenerateColumns = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
                dwItems.Rows(e.RowIndex).Selected = True
                Dim menu As New ContextMenuStrip
                menu.Items.Add("Anular", Nothing, AddressOf Anular)
                menu.Items.Add("Pagada", Nothing, AddressOf Pagada)
                Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
                If Convert.ToInt32(r.Cells(idOrigen.DataPropertyName).Value) = ClsEnums.OrigenNota.PORANTICIPO Then
                    menu.Items.Add("Ver detalle", Nothing, AddressOf verDetalle)
                End If
                menu.Items.Add("Imprimir", Nothing, AddressOf imprimir)
                menu.Items.Add("Excel", Nothing, AddressOf exportarExcel)
                menu.Items.Add("Pdf", Nothing, AddressOf exportarPdf)
                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class