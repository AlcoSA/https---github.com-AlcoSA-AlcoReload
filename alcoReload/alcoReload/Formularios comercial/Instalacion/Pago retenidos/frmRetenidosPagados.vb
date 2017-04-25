Imports DatagridTreeView
Imports ReglasNegocio

Public Class frmRetenidosPagados
#Region "Variables"
    Private objEncabezado As New Informes.datosInformesTableAdapters.sp_tc103_selectPagoRetenidoXMLTableAdapter
    Private objMovito As New Informes.datosInformesTableAdapters.sp_tc104_selectByPagoRetenidoXMLTableAdapter
    Private objResponsables As New Informes.datosInformesTableAdapters.sp_tc104_selectResponsablesXMLTableAdapter
#End Region
#Region "Procedimientos"
    Private Sub cargarRetenidos()
        Try
            dwItems.Nodes.Clear()
            txtTotal.Text = String.Empty
            Dim mPagoRet As New ClsPagoRetenidos
            Dim listPagoRet As List(Of pagoRetenido) = mPagoRet.TraerTodos()
            Dim total As Decimal = 0
            For Each pagoRet As pagoRetenido In listPagoRet
                Dim ndpd As DataGridViewTreeNode = dwItems.Nodes.Add()
                ndpd.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
                ndpd.Cells(col_id.Index).Value = pagoRet.Id
                ndpd.Cells(col_idDocumento.Index).Value = pagoRet.IdDocumento
                ndpd.Cells(col_documento.Index).Value = pagoRet.Documento
                ndpd.Cells(col_consecutivo.Index).Value = pagoRet.Consecutivo
                ndpd.Cells(col_fechaCreacion.Index).Value = pagoRet.FechaCreacion
                ndpd.Cells(col_idProveedor.Index).Value = pagoRet.IdProveedor
                ndpd.Cells(col_proveedorObra.Index).Value = pagoRet.Proveedor
                ndpd.Cells(col_idEncargado.Index).Value = pagoRet.IdEncargado
                ndpd.Cells(col_encargado.Index).Value = pagoRet.Encargado
                ndpd.Cells(col_idEstado.Index).Value = pagoRet.IdEstado
                ndpd.Cells(col_estado.Index).Value = pagoRet.Estado
                ndpd.Cells(col_idEstadoImpresion.Index).Value = pagoRet.IdEstadoImpresion
                ndpd.Cells(col_estadoImpresion.Index).Value = pagoRet.EstadoImpresion
                Dim valor As Decimal = 0
                Dim mMovitoPagoRet As New ClsMovitoPagoRetenido
                Dim listMovito As List(Of movitoPagoRet) = mMovitoPagoRet.TraerxIdPagoRetenido(pagoRet.Id)
                For Each movito As movitoPagoRet In listMovito
                    Dim nd As DataGridViewTreeNode = ndpd.Nodes.Add()
                    nd.Cells(col_id.Index).Value = movito.Id
                    nd.Cells(col_fechaCreacion.Index).Value = movito.FechaCreacion
                    nd.Cells(col_proveedorObra.Index).Value = movito.Obra
                    nd.Cells(col_valorPagado.Index).Value = movito.ValorPagado
                    valor += movito.ValorPagado
                Next
                ndpd.Cells(col_valorPagado.Index).Value = valor
                total += valor
            Next

            txtTotal.Text = FormatCurrency(total, 2)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub verPagoRetenido()
        Try
            Dim nodo As DataGridViewTreeNode = DirectCast(dwItems.SelectedRows(0), DataGridViewTreeNode)

            Dim frm As New frmVistaPagoRetenido
            frm.IdPagoRetenido = nodo.Cells(col_id.Index).Value
            frm.IdDocumento = nodo.Cells(col_idDocumento.Index).Value
            frm.Documento = nodo.Cells(col_documento.Index).Value
            frm.Consecutivo = nodo.Cells(col_consecutivo.Index).Value
            frm.Proveedor = nodo.Cells(col_proveedorObra.Index).Value
            frm.Encargado = nodo.Cells(col_encargado.Index).Value
            frm.IdEstado = nodo.Cells(col_idEstado.Index).Value

            If frm.ShowDialog() = DialogResult.OK Then
                cargarRetenidos()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub verInforme()
        Try
            Dim nodo As DataGridViewTreeNode = DirectCast(dwItems.SelectedRows(0), DataGridViewTreeNode)

            Dim ds As New DataSet
            ds.Tables.Add(objEncabezado.GetData(nodo.Cells(col_id.Index).Value))
            ds.Tables.Add(objMovito.GetData(nodo.Cells(col_id.Index).Value))
            ds.Tables.Add(objResponsables.GetData(nodo.Cells(col_id.Index).Value))
            ds.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "pagoRetenidos.xml"))

            Dim frm As New frmInformePagoRetenidos
            frm.Ds = ds
            frm.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmRetenidosPagados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarRetenidos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                If e.Button = MouseButtons.Right Then
                    Dim nodo As DataGridViewTreeNode = DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode)
                    If nodo.Level = 1 Then
                        dwItems.Rows(e.RowIndex).Selected = True
                        Dim menu As New ContextMenuStrip
                        menu.Items.Add("Ver pago retenido", Nothing, AddressOf verPagoRetenido)
                        If CInt(nodo.Cells(col_idEstado.Index).Value) <> ClsEnums.Estados.ANULADO Then
                            menu.Items.Add("Ver informe", Nothing, AddressOf verInforme)
                        End If
                        If CInt(nodo.Cells(col_idEstadoImpresion.Index).Value) = ClsEnums.Estados.SIN_IMPRIMIR Then
                            If CInt(nodo.Cells(col_idEstado.Index).Value) <> ClsEnums.Estados.ANULADO Then
                                menu.Items.Add("Imprimir", Nothing)
                            End If
                        End If
                        menu.Show(MousePosition)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class