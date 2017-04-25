Imports ReglasNegocio

Public Class FrmDuracionDuplicacion
#Region "Variables"
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
#End Region
#Region "Procedimientos"
    Private Sub cargarEstados()
        Try
            Dim mEstado As New ClsEstados
            Dim listEstados As List(Of Estado) = mEstado.TraerTodos()
            Dim bsource As New BindingSource()
            bsource.DataSource = listEstados.Where(Function(a) a.Id < 3)
            cmbEstado.DisplayMember = "Descripcion"
            cmbEstado.ValueMember = "Id"
            cmbEstado.DataSource = bsource
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub modificacion()
        Try
            tform = ClsEnums.TiOperacion.MODIFICAR
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = r.Cells(id.Index).Value
            nudDias.Value = r.Cells(dias.Index).Value
            nudDias.Enabled = False
            chkVigente.Checked = CBool(r.Cells(vigente.Index).Value)
            chkVigente.Enabled = True
            cmbEstado.SelectedValue = r.Cells(idEstado.Index).Value
            cmbEstado.Enabled = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacion() As Boolean
        Try
            nud_Leave(nudDias, Nothing)
            If nudDias.Value = 0 Then
                ErrorProvider.SetError(nudDias, "El valor no puede ser cero (0)")
                Return False
            End If
            ErrorProvider.Clear()

            If tform = ClsEnums.TiOperacion.INSERTAR Then
                Dim mDuracion As New ClsDuracionDuplicacion
                Dim list As List(Of duracionDuplicado) = mDuracion.TraerTodos()
                Dim conteo As Integer = 0
                For Each dur As duracionDuplicado In list
                    If dur.Dias = nudDias.Value Then
                        conteo += 1
                    End If
                Next
                If conteo > 0 Then
                    ErrorProvider.SetError(nudDias, "El registro ya existe, puede buscarlo y ponerlo como vigente")
                    Return False
                End If
            ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                If chkVigente.Checked = True And CInt(cmbEstado.SelectedValue) <> CInt(ClsEnums.Estados.ACTIVO) Then
                    ErrorProvider.SetError(cmbEstado, "Si el registro va a ser el valor vigente, debe estar ACTIVO")
                    Return False
                End If
                ErrorProvider.Clear()
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub FrmDuracionDuplicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mDuracion As New ClsDuracionDuplicacion
            mDuracion.TraerTodos(dwItems.TablaDatos)
            cargarEstados()

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
    Private Sub Frm_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
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
    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If validacion() Then
                Dim mDuracion As New ClsDuracionDuplicacion
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mDuracion.Insertar(My.Settings.UsuarioActivo, nudDias.Value, cmbEstado.SelectedValue)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mDuracion.Modificar(curid, chkVigente.Checked, cmbEstado.SelectedValue, My.Settings.UsuarioActivo)
                End If
                MessageBox.Show("La información se ha guardado exitosamente", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnLimpiar_Click(Nothing, Nothing)
                FrmDuracionDuplicacion_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            tform = ClsEnums.TiOperacion.INSERTAR
            curid = 0
            nudDias.Value = 0
            nudDias.Enabled = True
            chkVigente.Checked = True
            chkVigente.Enabled = False
            cmbEstado.SelectedValue = CInt(ClsEnums.Estados.ACTIVO)
            cmbEstado.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.Button = MouseButtons.Right Then
                dwItems.Rows(e.RowIndex).Selected = True
                Dim menu As New ContextMenuStrip
                menu.Items.Add("Modificar", Nothing, AddressOf modificacion)
                menu.Show(MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudDias.GotFocus
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Value = 0 Then
                nud.ResetText()
            End If
            Return
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudDias.Leave
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Controls.Item(1).Text = "" Then
                nud.Controls.Item(1).Text = "0"
                nud.Value = 0
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub chkVigente_CheckedChanged(sender As Object, e As EventArgs) Handles chkVigente.CheckedChanged
        Try
            If tform = ClsEnums.TiOperacion.MODIFICAR Then
                If chkVigente.Checked = True Then
                    cmbEstado.SelectedValue = CInt(ClsEnums.Estados.ACTIVO)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class