Imports ReglasNegocio
Imports ReglasNegocio.Contratos

Public Class frmContratosOT
#Region "Variables"
    Private fuenteInicial As DataTable = Nothing
    Private tieneInstalacion As Boolean = False
#End Region
#Region "Procedimientos"

    Private Sub objetoyPara()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim mContrato As New clsContratos
            Dim cont As contrato = mContrato.TraerObjetoYPara(r.Cells(idContrato.DataPropertyName).Value)
            Dim info As New ContextMenuStrip
            info.Items.Add("Contrato: " & cont.nContrato)
            info.Items.Add("Objeto: " & cont.Objeto)
            info.Items.Add("Para: " & cont.Para)
            info.Show(MousePosition)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub abrirOTContrato()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim frm As New frmOrdenTrabajo
            frm.MdiParent = Me.MdiParent
            frm.WindowState = FormWindowState.Maximized
            frm.Text += " desde contrato"
            frm.TipoOrdenTrabajo = ClsEnums.TipoOrdenTrabajo.DESDE_CONTRATO
            frm.IdContrato = r.Cells(idContrato.DataPropertyName).Value
            frm.NombreObra = r.Cells(obra.DataPropertyName).Value
            frm.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub abrirOTAdicionales()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            Dim frm As New frmOrdenTrabajo
            frm.MdiParent = Me.MdiParent
            frm.WindowState = FormWindowState.Maximized
            frm.Text += " adicional"
            frm.TipoOrdenTrabajo = ClsEnums.TipoOrdenTrabajo.ADICIONALES
            frm.IdContrato = r.Cells(idContrato.DataPropertyName).Value
            frm.NombreObra = r.Cells(obra.DataPropertyName).Value
            frm.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
                If e.Button = MouseButtons.Right Then
                    r.Selected = True
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("Mostrar objeto y para", Nothing, AddressOf objetoyPara)
                    'Dim mObjContrato As New clsRelacionObjetoContratos
                    'Dim list As List(Of relacionObjetosContratos) = mObjContrato.traerxIdContrato(r.Cells(idContrato.DataPropertyName).Value)
                    'If list.Count > 0 Then
                    '    Dim inst As Integer = 0
                    '    For Each item As relacionObjetosContratos In list
                    '        If item.idObjeto = ClsEnums.ObjetosContratos.INSTALACION Then
                    '            inst += 1
                    '        End If
                    '    Next
                    '    If inst > 0 Then
                    '        Dim mOrdenTrabajo As New ClsOrdenTrabajo
                    '        If Not mOrdenTrabajo.TieneOTxContrato(r.Cells(idContrato.DataPropertyName).Value) Then
                    '            menu.Items.Add("Orden de trabajo contrato", Nothing, AddressOf abrirOTContrato)
                    '        End If
                    '    End If
                    'End If
                    menu.Items.Add("Orden de trabajo contrato", Nothing, AddressOf abrirOTContrato)
                    menu.Items.Add("Orden de trabajo adicionales", Nothing, AddressOf abrirOTAdicionales)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub frmContratosOT_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Try
            dwItems.DataSource = Nothing
            dwItems.TablaDatos = Nothing
            dwItems.Rows.Clear()
            Dim mOrdenTrabajo As New ClsOrdenTrabajo
            mOrdenTrabajo.TraerContratos(dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class