Imports System.Reflection
Imports ReglasNegocio

Public Class FrmListaProblemasProduccion
#Region "Variables"
    Private actualizar As Boolean = False
#End Region
#Region "Procedimientos"
    Private Sub Abrir()
        Try
            abrirProblemasProduccion(False)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            abrirProblemasProduccion(True)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub abrirProblemasProduccion(modificar As Boolean)
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim frm As New FrmProblemasProduccion
            frm.IdEncabezado = r.Cells(id.Index).Value
            frm.Consecutivo = r.Cells(consecutivo.Index).Value
            frm.EstadoSolucion = r.Cells(estadoSolucion.Index).Value
            frm.FechaRegistro = r.Cells(fechaRegistro.Index).Value
            frm.IdVendedor = r.Cells(idVendedor.Index).Value
            frm.Vendedor = r.Cells(vendedor.Index).Value
            frm.IdSeccion = r.Cells(idSeccion.Index).Value
            frm.Seccion = r.Cells(seccion.Index).Value
            frm.Nit = r.Cells(nit.Index).Value
            frm.Cliente = r.Cells(cliente.Index).Value
            frm.CodigoObra = r.Cells(codigoObra.Index).Value
            frm.Obra = r.Cells(obra.Index).Value
            frm.DescripcionProblema = r.Cells(descripcionProblema.Index).Value
            If modificar = True Then
                frm.Operacion = ClsEnums.TiOperacion.MODIFICAR
            End If
            frm.MdiParent = Me.Parent.Parent
            frm.Show()
            actualizar = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#End Region
    Private Sub FrmListaProblemasProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mEncabezado As New ClsEncabezadoProblemasP
            Dim list As List(Of encabezadoPP) = mEncabezado.TraerxEstados(ClsEnums.Estados.ENVIADO & ", " & ClsEnums.Estados.SOLUCIONADO_PARCIAL, dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
                If e.Button = MouseButtons.Right Then
                    r.Selected = True
                    Dim menu As New ContextMenuStrip
                    If CInt(r.Cells(idEstadoSolucion.Index).Value) = ClsEnums.Estados.SOLUCIONADO_PARCIAL Then
                        menu.Items.Add("Modificar", Nothing, AddressOf Modificar)
                    Else
                        menu.Items.Add("Abrir", Nothing, AddressOf Abrir)
                    End If
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub FrmListaProblemasProduccion_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        If actualizar Then
            Dim mEncabezado As New ClsEncabezadoProblemasP
            dwItems.TablaDatos = Nothing
            dwItems.Rows.Clear()
            mEncabezado.TraerxEstados(ClsEnums.Estados.ENVIADO & ", " & ClsEnums.Estados.SOLUCIONADO_PARCIAL, dwItems.TablaDatos)
        End If
        actualizar = False
    End Sub
End Class