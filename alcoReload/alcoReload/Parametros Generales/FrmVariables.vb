Imports ReglasNegocio
Imports Validaciones

Public Class FrmVariables

#Region "Variables"
    Private mVariables As New ClsVariables
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
    Private Sub cargarTipos()
        Try
            Dim mtipos As New ClsTiposDatos
            Dim listTiposD As List(Of TipoDato) = mtipos.TraerxEstado(1)
            Dim bsource As New BindingSource()
            bsource.DataSource = listTiposD
            listTiposD.Insert(0, New TipoDato)
            cmbTipoDato.DisplayMember = "Nombre"
            cmbTipoDato.ValueMember = "Id"
            cmbTipoDato.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub Modificar()
        Try
            If Not My.Settings.Es_Desarrollador Then
                MsgBox("No tiene permisos para realizar esta acción", MsgBoxStyle.Information)
                Return
            End If
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = r.Cells(Id.DataPropertyName).Value
            txtnombre.Text = r.Cells(Nombre_Variable.DataPropertyName).Value
            txtDescripcion.Text = r.Cells(Descripcion.DataPropertyName).Value
            cmbTipoDato.SelectedValue = Int32.Parse(r.Cells(Id_TipoDato.DataPropertyName).Value)
            cbdesdebd.Checked = Convert.ToBoolean(r.Cells(Valor_Desde_BD.DataPropertyName).Value)
            cbedicionproduccion.Checked = Convert.ToBoolean(r.Cells(Edicion_Produccion.DataPropertyName).Value)
            cbusopredeterminado.Checked = Convert.ToBoolean(r.Cells(Uso_Predeterminado.DataPropertyName).Value)
            chbimprimir.Checked = Convert.ToBoolean(r.Cells(Imprimir.DataPropertyName).Value)
            cmbEstado.SelectedValue = r.Cells(Id_Estado.DataPropertyName).Value
            nudorden.Value = Convert.ToInt32(r.Cells(Orden.DataPropertyName).Value)
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
            mVariables = New ClsVariables
            Dim objLista As List(Of Variables) = mVariables.TraerTodos(dwItems.TablaDatos)
            cargarTipos()
            cargarEstados()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Function Validacion() As Boolean
        Try
            objValidacion = New ClsValidaciones
            If Not objValidacion.TextBoxDigitado(txtnombre, ErrorProvider1) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbTipoDato, ErrorProvider1) Then Return False
            If Not objValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider1) Then Return False
            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try

    End Function

    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If Validacion() Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mVariables.Ingresar(My.Settings.UsuarioActivo, txtnombre.Text, txtDescripcion.Text,
                                        Int32.Parse(cmbTipoDato.SelectedValue), cmbEstado.SelectedValue,
                                        cbdesdebd.Checked, cbedicionproduccion.Checked, cbusopredeterminado.Checked, Convert.ToInt32(nudorden.Value), chbimprimir.Checked)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mVariables.Modificar(curid, My.Settings.UsuarioActivo, txtnombre.Text, txtDescripcion.Text,
                                         Int32.Parse(cmbTipoDato.SelectedValue), cmbEstado.SelectedValue, cbdesdebd.Checked,
                                         cbusopredeterminado.Checked, cbedicionproduccion.Checked, Convert.ToInt32(nudorden.Value), chbimprimir.Checked)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                Frm_Load(Nothing, Nothing)
                btnLimpiar_Click(Nothing, Nothing)
            Else
                Return
            End If
        Catch ex As Exception
            If ex.Message.Contains("UNIQUE KEY 'ti006_variables$fi006_nombreVariable'") Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(txtnombre, "Ya existe una variable con este nombre. Verifique la información")
                Return
            End If
            If ex.Message.Contains("UNIQUE KEY 'ti006_variables$fi006_descripcion'") Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(txtDescripcion, "Ya existe una variable con esta descripción. Verifique la información")
                Return
            End If
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            curid = 0
            txtDescripcion.Text = String.Empty
            txtnombre.Text = String.Empty
            cmbEstado.SelectedValue = 1
            cbdesdebd.Checked = False
            cbusopredeterminado.Checked = False
            cmbTipoDato.SelectedValue = 0
            cbedicionproduccion.Checked = False
            chbimprimir.Checked = False
            nudorden.Value = dwItems.Rows.Count + 1
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

    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudorden.GotFocus
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

    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudorden.Leave
        Try
            Dim nud As NumericUpDown = DirectCast(sender, NumericUpDown)
            If nud.Controls.Item(1).Text = "" Then
                nud.Controls.Item(1).Text = "0.00"
                nud.Value = 0.00
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class