Imports ReglasNegocio

Public Class frmMotivosPorSecciones
#Region "Variables"
#End Region
#Region "Procedimientos"
    Private Sub cargarInformacion()
        Try
            dwItems.Rows.Clear()
            Dim mMotivoxSeccion As New ClsMotivosPorSeccion
            Dim list As List(Of motivoPorSeccion) = mMotivoxSeccion.TraerTodos()
            For Each mot As motivoPorSeccion In list
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(id.Index).Value = mot.Id
                r.Cells(idSeccion.Index).Value = mot.IdSeccion
                r.Cells(prefijoSeccion.Index).Value = mot.PrefijoSeccion
                r.Cells(seccion.Index).Value = mot.DescripcionSeccion
                r.Cells(idConcepto.Index).Value = mot.IdConcepto
                r.Cells(codigoMotivo.Index).Value = mot.CodigoMotivo
                r.Cells(motivo.Index).Value = mot.DescripcionMotivo
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarSecciones()
        Try
            Dim mSeccion As New ClsSecciones
            Dim list As List(Of seccion) = mSeccion.TraerTodos()
            cmbSecciones.DisplayMember = "Prefijo"
            cmbSecciones.DatosVisibles = {"Prefijo", "Descripcion"}
            cmbSecciones.ValueMember = "Id"
            cmbSecciones.DataSource = list
            cmbSecciones.SelectedItem = Nothing
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
                    Dim mMotivoxSeccion As New ClsMotivosPorSeccion
                    mMotivoxSeccion.Modificar(r.Cells(id.Index).Value, ClsEnums.Estados.ARCHIVADO)
                    dwItems.Rows.Remove(r)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionAgregar() As Boolean
        Try
            If cmbSecciones.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbSecciones, "Debe seleccionar la sección")
                Return False
            End If
            ErrorProvider.Clear()
            If cmbMotivo.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbMotivo, "Debe seleccionar el motivo")
                Return False
            End If
            ErrorProvider.Clear()

            Dim sec As seccion = cmbSecciones.SelectedItem
            Dim mot As motivo = cmbMotivo.SelectedItem
            Dim conteo As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If CInt(r.Cells(idSeccion.Index).Value) = sec.Id And CInt(r.Cells(idConcepto.Index).Value) = mot.IdConcepto And
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
    Private Sub frmMotivosPorSecciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarSecciones()
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
                Dim secc As seccion = cmbSecciones.SelectedItem
                Dim mot As motivo = cmbMotivo.SelectedItem
                r.Cells(idSeccion.Index).Value = secc.Id
                r.Cells(prefijoSeccion.Index).Value = secc.Prefijo
                r.Cells(seccion.Index).Value = secc.Descripcion
                r.Cells(idConcepto.Index).Value = mot.IdConcepto
                r.Cells(codigoMotivo.Index).Value = mot.Codigo
                r.Cells(motivo.Index).Value = mot.Descripcion

                cmbSecciones.SelectedItem = Nothing
                cmbMotivo.SelectedItem = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try
            Dim mMotivoxSeccion As New ClsMotivosPorSeccion
            For Each r As DataGridViewRow In dwItems.Rows()
                If r.Cells(id.Index).Value Is Nothing Then
                    mMotivoxSeccion.Insertar(My.Settings.UsuarioActivo, r.Cells(idSeccion.Index).Value, r.Cells(idConcepto.Index).Value,
                                             r.Cells(codigoMotivo.Index).Value, ClsEnums.Estados.ACTIVO)
                End If
            Next
            MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnLimpiar_Click(Nothing, Nothing)
            frmMotivosPorSecciones_Load(Nothing, Nothing)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        Try
            cmbSecciones.SelectedItem = Nothing
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