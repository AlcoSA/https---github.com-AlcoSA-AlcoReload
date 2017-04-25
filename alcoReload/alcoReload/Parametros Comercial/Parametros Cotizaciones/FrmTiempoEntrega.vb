Imports ReglasNegocio
Imports ReglasNegocio.TiempoEntrega
Imports Validaciones

Public Class FrmTiempoEntrega
#Region "Variables"
    Private mTiempoentrega As ClsTiempoEntrega
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
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = Convert.ToInt32(r.Cells(id_Tiempo_Entrega.DataPropertyName).Value)
            nudDias.Value = Convert.ToInt32(r.Cells(dias.DataPropertyName).Value)
            txtDescripcion.Text = r.Cells(Tiempo_Entrega.DataPropertyName).Value.ToString()
            txtMotivo.Text = r.Cells(Motivo_Creacion.DataPropertyName).Value.ToString()
            cmbEstado.SelectedValue = r.Cells(Id_Estado.DataPropertyName).Value
            cbValorPorDefecto.Checked = Convert.ToBoolean(r.Cells(valor_Defecto.DataPropertyName).Value)
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
    Private Sub FrmTiempoEntrega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mTiempoentrega = New ClsTiempoEntrega
            Dim objLista As List(Of tiempoEntrega) = mTiempoentrega.traerTodos(dwItems.TablaDatos)
            cargarEstados()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function Validaciones() As Boolean
        Try
            objValidacion = New ClsValidaciones
            mTiempoentrega = New ClsTiempoEntrega
            If Not objValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider1) Then Return False
            If Not objValidacion.TextBoxDigitado(txtMotivo, ErrorProvider1) Then Return False
            If Not objValidacion.NumeroMayorACero(nudDias, ErrorProvider1) Then Return False
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                If mTiempoentrega.TraerxDescripcion(txtDescripcion.Text) = True Then
                    ErrorProvider1.SetError(txtDescripcion, "Ya existe este registro")
                    Return False
                End If
                ErrorProvider1.Clear()
            End If
            Return True
        Catch ex As Exception
            Return False
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If Validaciones() Then
                Dim mutiimagen As New ClsUtilidadesImagenes
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mTiempoentrega.Ingresar(My.Settings.UsuarioActivo, txtDescripcion.Text, cmbEstado.SelectedValue,
                                            txtMotivo.Text, Convert.ToInt32(cbValorPorDefecto.Checked), nudDias.Value)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mTiempoentrega.Modificar(txtDescripcion.Text, My.Settings.UsuarioActivo, cmbEstado.SelectedValue,
                                             txtMotivo.Text, curid, Convert.ToInt32(cbValorPorDefecto.Checked), nudDias.Value)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                FrmTiempoEntrega_Load(Nothing, Nothing)
            Else
                Return
            End If
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            curid = 0
            txtDescripcion.Text = String.Empty
            txtMotivo.Text = String.Empty
            cmbEstado.SelectedValue = 1
            ErrorProvider1.Clear()
            cbValorPorDefecto.Checked = False
            nudDias.Value = 0
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

    Private Sub cmbEstado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedValueChanged
        Try
            If CInt(cmbEstado.SelectedValue) = 1 Then
                cbValorPorDefecto.Enabled = True
                Return
            End If
            cbValorPorDefecto.Checked = False
            cbValorPorDefecto.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class