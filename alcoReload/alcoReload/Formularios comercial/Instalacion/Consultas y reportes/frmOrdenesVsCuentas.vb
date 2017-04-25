Imports DatagridTreeView
Imports ReglasNegocio

Public Class frmOrdenesVsCuentas
#Region "Variables"
    Private nodo_facturable As New DataGridViewTreeNode
    Private snod_OtContratoFact As New DataGridViewTreeNode
    Private snod_OtAdicionalFact As New DataGridViewTreeNode
    Private snod_OtDirectaFact As New DataGridViewTreeNode

    Private nodo_Nofactutable As New DataGridViewTreeNode
    Private snod_OtContratoNoFact As New DataGridViewTreeNode
    Private snod_OtAdicionalNoFact As New DataGridViewTreeNode
    Private snod_OtDirectaNoFact As New DataGridViewTreeNode

    Private nodo_totales As New DataGridViewTreeNode
#End Region
#Region "Procedimientos"
    Private Sub cargarNodos()
        Try
            'Dim nodo_facturable As New DataGridViewTreeNode
            dwOrdenesTrabajo.Nodes.Add(nodo_facturable)
            nodo_facturable.Cells(ot_id.Index).Value = "FACTURABLE"
            nodo_facturable.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
            nodo_facturable.DefaultCellStyle.BackColor = Color.DarkGray
            'Subnodos

            nodo_facturable.Nodes.Add(snod_OtContratoFact)
            snod_OtContratoFact.Cells(ot_id.Index).Value = "Odenes desde contrato"
            snod_OtContratoFact.DefaultCellStyle.BackColor = Color.Gainsboro

            nodo_facturable.Nodes.Add(snod_OtAdicionalFact)
            snod_OtAdicionalFact.Cells(ot_id.Index).Value = "Ordenes adicionales"
            snod_OtAdicionalFact.DefaultCellStyle.BackColor = Color.Gainsboro

            nodo_facturable.Nodes.Add(snod_OtDirectaFact)
            snod_OtDirectaFact.Cells(ot_id.Index).Value = "Ordenes directas"
            snod_OtDirectaFact.DefaultCellStyle.BackColor = Color.Gainsboro

            nodo_facturable.Expand()



            dwOrdenesTrabajo.Nodes.Add(nodo_Nofactutable)
            nodo_Nofactutable.Cells(ot_id.Index).Value = "NO FACTURABLE"
            nodo_Nofactutable.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
            nodo_Nofactutable.DefaultCellStyle.BackColor = Color.DarkGray
            'Subnodos
            nodo_Nofactutable.Nodes.Add(snod_OtContratoNoFact)
            snod_OtContratoNoFact.Cells(ot_id.Index).Value = "Ordenes desde contrato"
            snod_OtContratoNoFact.DefaultCellStyle.BackColor = Color.Gainsboro

            nodo_Nofactutable.Nodes.Add(snod_OtAdicionalNoFact)
            snod_OtAdicionalNoFact.Cells(ot_id.Index).Value = "Ordenes adicionales"
            snod_OtAdicionalNoFact.DefaultCellStyle.BackColor = Color.Gainsboro

            nodo_Nofactutable.Nodes.Add(snod_OtDirectaNoFact)
            snod_OtDirectaNoFact.Cells(ot_id.Index).Value = "Ordenes directas"
            snod_OtDirectaNoFact.DefaultCellStyle.BackColor = Color.Gainsboro

            nodo_Nofactutable.Expand()



            dwOrdenesTrabajo.Nodes.Add(nodo_totales)
            nodo_totales.Cells(ot_id.Index).Value = "TOTALES"
            nodo_totales.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
            nodo_totales.DefaultCellStyle.BackColor = Color.DarkGray

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub limpiarNodos()
        Try
            For Each nod As DataGridViewTreeNode In dwOrdenesTrabajo.Nodes
                If nod.Level = 1 Then
                    For Each nodo As DataGridViewTreeNode In nod.Nodes
                        nodo.Nodes.Clear()
                    Next
                End If
            Next
            nodo_totales.Nodes.Clear()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub getData(ByVal dataCollection As AutoCompleteStringCollection)
        Dim mObras As New clsObrasUnoee
        Dim listObras As List(Of obrasUnoee) = mObras.traerObras()
        For Each obra As obrasUnoee In listObras
            dataCollection.Add(obra.nombreObra)
        Next
    End Sub
    Private Sub cargarInformacion()
        Try
            limpiarNodos()
            Dim mMovitoCuentaCobro As New ClsMovitoCuentaCobro
            Dim list As List(Of ordenesVsCuentas) = mMovitoCuentaCobro.TraerOrdenesVsCuentas(txtObra.Text)
            Dim precTotal As Decimal = 0
            Dim pagadoTotal As Decimal = 0
            Dim disponibleTotal As Decimal = 0
            Dim precClienteTotal As Decimal = 0
            Dim utilidadTotal As Decimal = 0
            For Each ovc As ordenesVsCuentas In list
                Dim nod As New DataGridViewTreeNode
                If ovc.Facturable Then
                    If ovc.Contrato Then
                        snod_OtContratoFact.Nodes.Add(nod)
                        snod_OtContratoFact.Expand()
                    ElseIf ovc.Adicional Then
                        snod_OtAdicionalFact.Nodes.Add(nod)
                        snod_OtAdicionalFact.Expand()
                    ElseIf ovc.Directa Then
                        snod_OtDirectaFact.Nodes.Add(nod)
                        snod_OtDirectaFact.Expand()
                    End If
                Else
                    If ovc.Contrato Then
                        snod_OtContratoNoFact.Nodes.Add(nod)
                        snod_OtContratoNoFact.Expand()
                    ElseIf ovc.Adicional Then
                        snod_OtAdicionalNoFact.Nodes.Add(nod)
                        snod_OtAdicionalNoFact.Expand()
                    ElseIf ovc.Directa Then
                        snod_OtDirectaNoFact.Nodes.Add(nod)
                        snod_OtDirectaNoFact.Expand()
                    End If
                End If
                nod.Cells(ot_concepto.Index).Value = ovc.Concepto
                nod.Cells(ot_descripcion.Index).Value = ovc.Descripcion
                nod.Cells(ot_proveedor.Index).Value = ovc.Proveedor
                nod.Cells(ot_cantidad.Index).Value = ovc.Cantidad
                nod.Cells(ot_precioUnitario.Index).Value = ovc.PrecioUnitario
                nod.Cells(ot_precioTotal.Index).Value = ovc.PrecioTotal
                precTotal += ovc.PrecioTotal
                nod.Cells(ot_pagado.Index).Value = ovc.Pagado
                pagadoTotal += ovc.Pagado
                nod.Cells(ot_disponible.Index).Value = ovc.Disponible
                disponibleTotal += ovc.Disponible
                nod.Cells(ot_precioCliente.Index).Value = ovc.PrecioCliente
                nod.Cells(ot_precioTotalCliente.Index).Value = ovc.PrecioTotalCliente
                precClienteTotal += ovc.PrecioTotalCliente
                nod.Cells(ot_utilidad.Index).Value = ovc.Utilidad
                utilidadTotal += ovc.Utilidad
                nod.Cells(ot_motivo.Index).Value = ovc.Motivo
            Next
            Dim totales As New DataGridViewTreeNode
            nodo_totales.Nodes.Add(totales)
            nodo_totales.Expand()
            totales.Cells(ot_precioTotal.Index).Value = precTotal
            totales.Cells(ot_pagado.Index).Value = pagadoTotal
            totales.Cells(ot_disponible.Index).Value = disponibleTotal
            totales.Cells(ot_precioTotalCliente.Index).Value = precClienteTotal
            totales.Cells(ot_utilidad.Index).Value = utilidadTotal
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarDetalle()
        Try
            dwPagoRetenidos.Rows.Clear()
            Dim mMovitoPagoRet As New ClsMovitoPagoRetenido
            Dim list As List(Of detallePagoRet) = mMovitoPagoRet.TraerDetallexObra(txtObra.Text)
            For Each det As detallePagoRet In list
                Dim r As DataGridViewRow = dwPagoRetenidos.Rows(dwPagoRetenidos.Rows.Add())
                r.Cells(pr_fechaPagoRetenido.Index).Value = det.FechaPagoRetenido
                r.Cells(pr_fechaCuenta.Index).Value = det.FechaCuenta
                r.Cells(pr_proveedor.Index).Value = det.Proveedor
                r.Cells(pr_encargado.Index).Value = det.Encargado
                r.Cells(pr_subtotal.Index).Value = det.Subtotal
                r.Cells(pr_retenido.Index).Value = det.Retenido
                r.Cells(pr_total.Index).Value = det.Total
                r.Cells(pr_retenidoPagado.Index).Value = det.Pagado
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmOrdenesVsCuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarNodos()

            txtObra.AutoCompleteMode = AutoCompleteMode.Suggest
            txtObra.AutoCompleteSource = AutoCompleteSource.CustomSource
            Dim DataCollection As New AutoCompleteStringCollection()
            getData(DataCollection)
            txtObra.AutoCompleteCustomSource = DataCollection
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub BuscarObra(sender As Object, e As EventArgs) Handles btnBuscarObra.Click, txtObra.Leave
        Try
            cargarInformacion()
            cargarDetalle()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Try
            Dim tablafuente As New DataTable
            tablafuente.Columns.Add("Id")
            tablafuente.Columns.Add("Concepto")
            tablafuente.Columns.Add("Descripcion")
            tablafuente.Columns.Add("Proveedor")
            tablafuente.Columns.Add("Cantidad")
            tablafuente.Columns.Add("Precio_unitario")
            tablafuente.Columns.Add("Precio_total")
            tablafuente.Columns.Add("Pagado")
            tablafuente.Columns.Add("Disponible")
            tablafuente.Columns.Add("Precio_cliente")
            tablafuente.Columns.Add("Precio_total_cliente")
            tablafuente.Columns.Add("Utilidad")
            tablafuente.Columns.Add("Motivo")

            For Each nodoTitulo As DataGridViewTreeNode In dwOrdenesTrabajo.Nodes
                Dim rTitulo As DataRow = tablafuente.Rows.Add()
                rTitulo("Id") = nodoTitulo.Cells(ot_id.Index).Value
                For Each nodoPadre As DataGridViewTreeNode In nodoTitulo.Nodes
                    If nodoPadre.Nodes.Count > 0 Then
                        Dim rPadre As DataRow = tablafuente.Rows.Add()
                        rPadre("Id") = nodoPadre.Cells(ot_id.Index).Value
                        For Each nodo As DataGridViewTreeNode In nodoPadre.Nodes
                            Dim row As DataRow = tablafuente.Rows.Add()
                            row("Concepto") = nodo.Cells(ot_concepto.Index).Value
                            row("Descripcion") = nodo.Cells(ot_descripcion.Index).Value
                            row("Proveedor") = nodo.Cells(ot_proveedor.Index).Value
                            row("Cantidad") = nodo.Cells(ot_cantidad.Index).Value
                            row("Precio_unitario") = nodo.Cells(ot_precioUnitario.Index).Value
                            row("Precio_total") = nodo.Cells(ot_precioTotal.Index).Value
                            row("Pagado") = nodo.Cells(ot_pagado.Index).Value
                            row("Disponible") = nodo.Cells(ot_disponible.Index).Value
                            row("Precio_cliente") = nodo.Cells(ot_precioCliente.Index).Value
                            row("Precio_total_cliente") = nodo.Cells(ot_precioTotalCliente.Index).Value
                            row("Utilidad") = nodo.Cells(ot_utilidad.Index).Value
                            row("Motivo") = nodo.Cells(ot_motivo.Index).Value
                        Next
                    End If
                    If nodoTitulo Is nodo_totales Then
                        Dim rTotales As DataRow = tablafuente.Rows.Add()
                        rTotales("Precio_total") = nodoPadre.Cells(ot_precioTotal.Index).Value
                        rTotales("Pagado") = nodoPadre.Cells(ot_pagado.Index).Value
                        rTotales("Disponible") = nodoPadre.Cells(ot_disponible.Index).Value
                        rTotales("Precio_total_cliente") = nodoPadre.Cells(ot_precioTotalCliente.Index).Value
                        rTotales("Utilidad") = nodoPadre.Cells(ot_utilidad.Index).Value
                    End If
                Next
            Next



            'nodo_facturable.Expand()
            'snod_OtContratoFact.Expand()
            'snod_OtAdicionalFact.Expand()
            'snod_OtDirectaFact.Expand()
            'nodo_Nofactutable.Expand()
            'snod_OtContratoNoFact.Expand()
            'snod_OtAdicionalNoFact.Expand()
            'snod_OtDirectaNoFact.Expand()
            'nodo_totales.Expand()

            'Dim conteo As Integer = 0
            'For Each r As DataGridViewRow In dwOrdenesTrabajo.Rows
            '    DirectCast(r, DataGridViewTreeNode)
            '    conteo += 1
            'Next

            'MsgBox(tablafuente.Rows.Count & " filas")





            Dim save As New SaveFileDialog
            save.Filter = "Excel (XML Excel (*.xml)|*.xml | Todos los Archivos (*.*) |*.*"
            save.ShowDialog()
            Dim expExcel As New FormatosExportacion.Excel.Excel_XML(save.FileName, System.Security.Principal.WindowsIdentity.GetCurrent().Name)
            expExcel.Exportar(New DataTable() {tablafuente})
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class