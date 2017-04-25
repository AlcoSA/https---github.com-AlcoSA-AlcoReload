Imports ReglasNegocio
Imports Validaciones

Public Class FrmConfiguraciones

#Region "Variables"

    Private mconfiguraciones As ClsConfiguraciones
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private objValidacion As ClsValidaciones
    Private fuenteInicial As DataTable = Nothing
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
    Private Sub Modificar()
        Try
            If Not My.Settings.Es_Desarrollador Then
                MsgBox("No tiene permisos para realizar esta acción", MsgBoxStyle.Information)
                Return
            End If
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = Convert.ToInt32(r.Cells(Id.DataPropertyName).Value)
            txtconfiguracion.Text = r.Cells(Configuracion.DataPropertyName).Value
            nudnumerocuerpos.Value = Convert.ToInt32(r.Cells(Numero_Cuerpos.DataPropertyName).Value)
            nudnumeronaves.Value = Convert.ToInt32(r.Cells(Numero_Naves.DataPropertyName).Value)
            nudnumerofijos.Value = Convert.ToInt32(r.Cells(Numero_Fijos.DataPropertyName).Value)
            cmbEstado.SelectedValue = r.Cells(Id_Estado.DataPropertyName).Value
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

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

    Private Sub Frm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            mconfiguraciones = New ClsConfiguraciones
            Dim objLista As List(Of Configuracion) = mconfiguraciones.TraerTodos(dwItems.TablaDatos)
            cargarEstados()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            objValidacion = New ClsValidaciones
            If objValidacion.TextBoxDigitado(txtconfiguracion, ErrorProvider1) Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mconfiguraciones.Ingresar(My.Settings.UsuarioActivo, txtconfiguracion.Text, Convert.ToInt32(nudnumerocuerpos.Value),
                                              cmbEstado.SelectedValue, Convert.ToInt32(nudnumeronaves.Value), Convert.ToInt32(nudnumerofijos.Value))
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mconfiguraciones.Modificar(curid, My.Settings.UsuarioActivo, txtconfiguracion.Text, Convert.ToInt32(nudnumerocuerpos.Value),
                                               cmbEstado.SelectedValue, Convert.ToInt32(nudnumeronaves.Value), Convert.ToInt32(nudnumerofijos.Value))
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                Frm_Load(Nothing, Nothing)
            Else
                Return
            End If
        Catch ex As Exception
            If ex.Message.Contains("UNIQUE KEY 'ti019_configuraciones$fi019_configuracion'") Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(txtconfiguracion, "Ya existe una configuración con esta descripción. Verifique la información")
                Return
            End If
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            curid = 0
            txtconfiguracion.Text = String.Empty
            nudnumerofijos.Value = 0
            nudnumeronaves.Value = 0
            nudnumerocuerpos.Value = 0
            cmbEstado.SelectedValue = 1
            ErrorProvider1.Clear()
            tform = ClsEnums.TiOperacion.INSERTAR
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dw_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 And e.Button = Windows.Forms.MouseButtons.Right Then
                dwItems.Rows(e.RowIndex).Selected = True
                Dim menu As New ContextMenuStrip
                menu.Items.Add("Modificar", Nothing, AddressOf Modificar)
                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub nudnumero_ValueChanged(sender As Object, e As EventArgs) Handles nudnumerocuerpos.ValueChanged, nudnumeronaves.ValueChanged
        Try
            If nudnumerocuerpos.Value < nudnumeronaves.Value Then
                MsgBox("El numero de cuerpos no debe ser menor al número de naves", MsgBoxStyle.Critical)
                nudnumeronaves.Value = nudnumerocuerpos.Value
            Else
                nudnumerofijos.Value = nudnumerocuerpos.Value - nudnumeronaves.Value
            End If
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub txtconfiguracion_Leave(sender As Object, e As EventArgs) Handles txtconfiguracion.Leave
        Try
            Dim xs As Integer = 0
            Dim os As Integer = 0
            If Not String.IsNullOrEmpty(txtconfiguracion.Text) Then
                For Each c In txtconfiguracion.Text
                    If c.ToString().Equals("X") Then
                        xs += 1
                    ElseIf c.ToString().Equals("O") Then
                        os += 1
                    Else
                    End If
                Next
            End If
            nudnumerocuerpos.Value = xs + os
            nudnumerofijos.Value = os
            nudnumeronaves.Value = xs
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudnumerocuerpos.GotFocus,
            nudnumeronaves.GotFocus, nudnumerofijos.GotFocus
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

    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudnumerocuerpos.Leave,
            nudnumeronaves.Leave, nudnumerofijos.Leave
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
End Class