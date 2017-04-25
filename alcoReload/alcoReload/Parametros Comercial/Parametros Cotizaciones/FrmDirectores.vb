Imports ReglasNegocio
Imports Validaciones

Public Class FrmDirectores
#Region "Variables"
    Private mDirector As ClsDirectores
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
            curid = Convert.ToInt32(r.Cells(Id.DataPropertyName).Value)
            txtNombreDirector.Text = r.Cells(nombres.DataPropertyName).Value.ToString()
            txtTelFijo.Text = r.Cells(telFijo.DataPropertyName).Value.ToString()
            txtTelMovil.Text = r.Cells(telMovil.DataPropertyName).Value.ToString()
            txtCorreo.Text = r.Cells(correo.DataPropertyName).Value
            cmbEstado.SelectedValue = r.Cells(idEstado.DataPropertyName).Value
            cbValorDefecto.Checked = Convert.ToBoolean(r.Cells(valorDefecto.DataPropertyName).Value)
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

    Private Sub FrmDirectores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mDirector = New ClsDirectores
            Dim objLista As List(Of director) = mDirector.TraerTodos(dwItems.TablaDatos)
            cargarEstados()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Function Validar() As Boolean
        Try
            objValidacion = New ClsValidaciones
            mDirector = New ClsDirectores
            If Not objValidacion.TextBoxDigitado(txtNombreDirector, ErrorProvider1) Then Return False
            If Not objValidacion.TextBoxDigitado(txtTelFijo, ErrorProvider1) Then Return False
            If Not objValidacion.EmailCorrecto(txtCorreo, ErrorProvider1) Then Return False
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                If mDirector.TraerxNombre(txtNombreDirector.Text) = True Then
                    ErrorProvider1.SetError(txtNombreDirector, "Ya existe este registro")
                    Return False
                End If
                ErrorProvider1.Clear()
            End If
            Return True
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If Validar() Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mDirector.Ingresar(My.Settings.UsuarioActivo, txtNombreDirector.Text, txtTelFijo.Text, txtTelMovil.Text,
                                       txtCorreo.Text, cmbEstado.SelectedValue, Convert.ToInt32(cbValorDefecto.Checked))
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mDirector.Modificar(curid, txtNombreDirector.Text, txtTelFijo.Text, txtTelMovil.Text, txtCorreo.Text,
                                        My.Settings.UsuarioActivo, cmbEstado.SelectedValue, Convert.ToInt32(cbValorDefecto.Checked))
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                FrmDirectores_Load(Nothing, Nothing)
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
            txtNombreDirector.Clear()
            txtTelFijo.Clear()
            txtTelMovil.Clear()
            txtCorreo.Clear()
            cmbEstado.SelectedValue =
            cbValorDefecto.Checked = False
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

    Private Sub txtNombreDirector_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNombreDirector.KeyUp
        objValidacion = New ClsValidaciones
        Try
            objValidacion.SoloLetras(ErrorProvider1, txtNombreDirector)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbEstado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedValueChanged
        Try
            If CInt(cmbEstado.SelectedValue) = 1 Then
                cbValorDefecto.Enabled = True
                Return
            End If
            cbValorDefecto.Checked = False
            cbValorDefecto.Enabled = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class