Imports ReglasNegocio

Public Class frmCuentasPorFecha
#Region "Variables"
    Private fuenteInicial As DataTable
#End Region
#Region "Procedimientos"
    Private Sub crearColumnas()
        Try
            dwItems.Columns.Add("ciudad", "Ciudad")

            Dim colFecha As New DataGridViewColumn
            colFecha.Name = "fechaCreacion"
            colFecha.HeaderText = "Fecha creación"
            colFecha.DefaultCellStyle.Format = "dd/mm/yyyy"
            dwItems.Columns.Add(colFecha)

            Dim colIdDocumento As New DataGridViewColumn
            colIdDocumento.Name = "idDocumento"
            colIdDocumento.Visible = False
            dwItems.Columns.Add(colIdDocumento)

            dwItems.Columns.Add("documento", "Documento")
            dwItems.Columns.Add("consecutivo", "Consecutivo")

            Dim colIdProveedor As New DataGridViewColumn
            colIdProveedor.Name = "idProveedor"
            colIdProveedor.Visible = False
            dwItems.Columns.Add(colIdProveedor)

            dwItems.Columns.Add("proveedor", "Proveedor")

            Dim colIdEncargado As New DataGridViewColumn
            colIdEncargado.Name = "idEncargado"
            colIdEncargado.Visible = False
            dwItems.Columns.Add(colIdEncargado)

            dwItems.Columns.Add("encargado", "Encargado")
            dwItems.Columns.Add("codigoObra", "Código obra")
            dwItems.Columns.Add("obra", "Obra")
            dwItems.Columns.Add("concepto", "Concepto")
            dwItems.Columns.Add("descripcionConcepto", "Descripción")
            dwItems.Columns.Add("unidadMedida", "Unidad medida")

            Dim colCantidad As New DataGridViewColumn
            colCantidad.Name = "cantidad"
            colCantidad.HeaderText = "Cantidad"
            colCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dwItems.Columns.Add(colCantidad)

            Dim colPrecio As New DataGridViewColumn
            colPrecio.Name = "precio"
            colPrecio.HeaderText = "Precio"
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            colPrecio.DefaultCellStyle.Format = "N2"
            dwItems.Columns.Add(colPrecio)

            Dim colPorcRetenido As New DataGridViewColumn
            colPorcRetenido.Name = "porcRetenido"
            colPorcRetenido.Visible = False
            dwItems.Columns.Add(colPorcRetenido)

            Dim colSubtotal As New DataGridViewColumn
            colSubtotal.Name = "subtotal"
            colSubtotal.HeaderText = "Subtotal"
            colSubtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            colSubtotal.DefaultCellStyle.Format = "N2"
            dwItems.Columns.Add(colSubtotal)

            Dim colRetenido As New DataGridViewColumn
            colRetenido.Name = "retenido"
            colRetenido.HeaderText = "retenido"
            colRetenido.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            colRetenido.DefaultCellStyle.Format = "N2"
            dwItems.Columns.Add(colRetenido)

            Dim colTotal As New DataGridViewColumn
            colTotal.Name = "total"
            colTotal.HeaderText = "Total"
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            colTotal.DefaultCellStyle.Format = "N2"
            dwItems.Columns.Add(colTotal)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarDatos(tb As DataTable)
        Try
            If tb.Rows.Count = 0 Then Exit Sub
            'crearColumnas()
            tb.Columns.Cast(Of DataColumn).AsParallel.ForAll(Sub(columna)
                                                                 If dwItems.Columns.Contains(columna.ColumnName) Then
                                                                     dwItems.Columns(columna.ColumnName).DataPropertyName = columna.ColumnName
                                                                 End If
                                                             End Sub)
            dwItems.DataSource = tb
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionBuscar() As Boolean
        Try
            If dtpFechaInicial.Value.Date > dtpFechaFin.Value.Date Then
                ErrorProvider.SetError(dtpFechaInicial, "La fecha inicial no puede ser mayor a la fecha final")
                Return False
            End If
            ErrorProvider.Clear()

            If dtpFechaFin.Value.Date < dtpFechaInicial.Value.Date Then
                ErrorProvider.SetError(dtpFechaFin, "La fecha final de puede ser inferior a la fecha inicial")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub frmCuentasPorFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If validacionBuscar() Then
                lblSubtotal.Text = String.Empty
                lblRetenido.Text = String.Empty
                lblTotal.Text = String.Empty
                Dim mMovitoCuenta As New ClsMovitoCuentaCobro
                Dim list As List(Of detalleMovitoCuentaCobro) = mMovitoCuenta.TraerxFechas(dtpFechaInicial.Value.Date, dtpFechaFin.Value.Date, dwItems.TablaDatos)
                'If dwItems.TablaDatos IsNot Nothing Then
                '    fddFiltros.TablaFuente = dwItems.TablaDatos
                '    fuenteInicial = dwItems.TablaDatos
                '    fddFiltros.TablaFuente = fuenteInicial
                '    cargarDatos(fuenteInicial)

                '    Dim subt As Decimal = 0
                '    Dim ret As Decimal = 0
                '    Dim tot As Decimal = 0
                '    For Each r As DataGridViewRow In dwItems.Rows
                '        subt += CDec(r.Cells(subtotal.DataPropertyName).Value)
                '        ret += CDec(r.Cells(retenido.DataPropertyName).Value)
                '        tot += CDec(r.Cells(total.DataPropertyName).Value)
                '    Next

                '    lblSubtotal.Text = FormatCurrency(subt)
                '    lblRetenido.Text = FormatCurrency(ret)
                '    lblTotal.Text = FormatCurrency(tot)
                'Else
                'End If
                dwItems.Rows.Clear()
                Dim subt As Decimal = 0
                Dim ret As Decimal = 0
                Dim tot As Decimal = 0
                For Each det As detalleMovitoCuentaCobro In list
                    Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                    r.Cells(ciudad.Index).Value = det.Ciudad
                    r.Cells(fechaCreacion.Index).Value = det.FechaCreacion
                    r.Cells(idDocumento.Index).Value = det.IdDocumento
                    r.Cells(documento.Index).Value = det.Documento
                    r.Cells(consecutivo.Index).Value = det.Consecutivo
                    r.Cells(idProveedor.Index).Value = det.IdProveedor
                    r.Cells(proveedor.Index).Value = det.Proveedor
                    r.Cells(idEncargado.Index).Value = det.IdEncargado
                    r.Cells(encargado.Index).Value = det.Encargado
                    r.Cells(codigoObra.Index).Value = det.CodigoObra
                    r.Cells(obra.Index).Value = det.Obra
                    r.Cells(concepto.Index).Value = det.Concepto
                    r.Cells(descripcionConcepto.Index).Value = det.Descripcion
                    r.Cells(unidadMedida.Index).Value = det.UnidadMedida
                    r.Cells(cantidad.Index).Value = det.Cantidad
                    r.Cells(precio.Index).Value = det.Precio
                    r.Cells(porcRetenido.Index).Value = det.PorcRetenido
                    r.Cells(subtotal.Index).Value = det.Subtotal
                    subt += det.Subtotal
                    r.Cells(retenido.Index).Value = det.Retenido
                    ret += det.Retenido
                    r.Cells(total.Index).Value = det.Total
                    tot += det.Total
                Next
                lblSubtotal.Text = FormatCurrency(subt)
                lblRetenido.Text = FormatCurrency(ret)
                lblTotal.Text = FormatCurrency(tot)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dtp_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicial.ValueChanged, dtpFechaFin.ValueChanged
        Try
            ErrorProvider.Clear()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class