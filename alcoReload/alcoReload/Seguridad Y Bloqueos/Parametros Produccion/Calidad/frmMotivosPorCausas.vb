Imports ReglasNegocio

Public Class frmMotivosPorCausas
#Region "Variables"
#End Region
#Region "Procedimientos"
    Private Sub cargarInformacion()
        Try
            dwItems.Rows.Clear()
            Dim mMotivoxCausa As New ClsMotivosPorCausa
            Dim list As List(Of motivoporcausa) = mMotivoxCausa.TraerTodos()
            For Each mot As motivoporcausa In list
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(id.Index).Value = mot.Id
                r.Cells(idCausa.Index).Value = mot.IdCausa
                r.Cells(nombreCausa.Index).Value = mot.NombreCausa
                r.Cells(causa.Index).Value = mot.Causa
                r.Cells(idConcepto.Index).Value = mot.IdConcepto
                r.Cells(codigoMotivo.Index).Value = mot.CodigoMotivo
                r.Cells(motivo.Index).Value = mot.Motivo
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarCausas()
        Try
            Dim mCausa As New ClsCausas
            Dim list As List(Of causa) = mCausa.TraerTodos()
            cmbCausas.DisplayMember = "Nombre"
            cmbCausas.DatosVisibles = {"Nombre", "Descripcion"}
            cmbCausas.ValueMember = "Id"
            cmbCausas.DataSource = list
            cmbCausas.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarMotivos()
        Try
            Dim mMotivos As New ClsMotivos
            Dim list As List(Of motivo) = mMotivos.TraerTodos(76)
            cmbMotivo.DisplayMember = "CodigoDescripcion"
            cmbMotivo.ValueMember = "Codigo"
            cmbMotivo.DatosVisibles = {"CodigoDescripcion"}
            cmbMotivo.DataSource = list
            cmbMotivo.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub eliminar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            If MessageBox.Show("¿Esta seguro de eliminar el registro?", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information) = DialogResult.Yes Then
                If r.Cells(id.Index).Value Is Nothing Then
                    dwItems.Rows.Remove(r)
                Else
                    Dim mMotivoxCausa As New ClsMotivosPorCausa
                    mMotivoxCausa.Modificar(r.Cells(id.Index).Value, ClsEnums.Estados.ARCHIVADO)
                    dwItems.Rows.Remove(r)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionAgregar() As Boolean
        Try
            If cmbCausas.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbCausas, "Debe seleccionar la causa")
                Return False
            End If
            ErrorProvider.Clear()
            If cmbMotivo.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbMotivo, "Debe seleccionar el motivo")
                Return False
            End If
            ErrorProvider.Clear()

            Dim cau As causa = cmbCausas.SelectedItem
            Dim mot As motivo = cmbMotivo.SelectedItem
            Dim conteo As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If CInt(r.Cells(idCausa.Index).Value) = cau.Id And CInt(r.Cells(idConcepto.Index).Value) = mot.IdConcepto And
                    Convert.ToString(r.Cells(codigoMotivo.Index).Value) = mot.Codigo Then
                    conteo += 1
                End If
            Next
            If conteo > 0 Then
                MsgBox("Ya existe la combinación indicada")
                Return False
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub frmMotivosPorCausas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarCausas()
            cargarMotivos()
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Activated(sender As Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            btnsParcial.Enabled = False
            AddHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            btnsParcial.Enabled = False
            RemoveHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If validacionAgregar() Then
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                Dim cau As causa = cmbCausas.SelectedItem
                Dim mot As motivo = cmbMotivo.SelectedItem
                r.Cells(idCausa.Index).Value = cau.Id
                r.Cells(nombreCausa.Index).Value = cau.Nombre
                r.Cells(causa.Index).Value = cau.Descripcion
                r.Cells(idConcepto.Index).Value = mot.IdConcepto
                r.Cells(codigoMotivo.Index).Value = mot.Codigo
                r.Cells(motivo.Index).Value = mot.Descripcion

                cmbCausas.SelectedItem = Nothing
                cmbMotivo.SelectedItem = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try
            Dim mMotivoxCausa As New ClsMotivosPorCausa
            For Each r As DataGridViewRow In dwItems.Rows()
                If r.Cells(id.Index).Value Is Nothing Then
                    mMotivoxCausa.Insertar(My.Settings.UsuarioActivo, r.Cells(idCausa.Index).Value, r.Cells(idConcepto.Index).Value,
                                           r.Cells(codigoMotivo.Index).Value, ClsEnums.Estados.ACTIVO)
                End If
            Next
            MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnLimpiar_Click(Nothing, Nothing)
            frmMotivosPorCausas_Load(Nothing, Nothing)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        Try
            cmbCausas.SelectedItem = Nothing
            cmbMotivo.SelectedItem = Nothing
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
                    menu.Items.Add("Eliminar", Nothing, AddressOf eliminar)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class