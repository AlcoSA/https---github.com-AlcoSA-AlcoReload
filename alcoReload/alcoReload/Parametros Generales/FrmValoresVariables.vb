Imports ReglasNegocio
Imports Validaciones

Public Class FrmValoresVariables

#Region "Variables"
    Private mvaloresvarable As ClsValoresVariables
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
            curid = r.Cells(Id.DataPropertyName).Value
            cmbVariables.SelectedValue = Convert.ToInt32(r.Cells(Id_Variable.Index).Value)
            txtvalor.Text = r.Cells(Valor.Index).Value
            cmbEstado.SelectedValue = r.Cells(Id_Estado.Index).Value
            cbValorDefecto.Checked = Convert.ToBoolean(r.Cells(Valor_Predet.Index).Value)
            cbimprimir.Checked = Convert.ToBoolean(r.Cells(imprimir.Index).Value)
            txtDescTecnica.Text = r.Cells(desc_Tecnica.Index).Value.ToString.Trim
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVariables()
        Try
            Dim variar As New ClsVariables
            Dim listvariables As List(Of Variables) = variar.TraerxEstadoyValorDesdeBd(ClsEnums.Estados.ACTIVO, True)
            listvariables.Insert(0, New Variables)
            Dim bsource As New BindingSource()
            bsource.DataSource = listvariables
            cmbVariables.DisplayMember = "Nombre"
            cmbVariables.ValueMember = "Id"
            cmbVariables.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
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
            mvaloresvarable = New ClsValoresVariables
            Dim objLista As List(Of ValorVariable) = mvaloresvarable.TraerTodos(dwItems.TablaDatos)
            cargarVariables()
            cargarEstados()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function Validar() As Boolean
        Try
            objValidacion = New ClsValidaciones
            If dwItems.Rows.Cast(Of DataGridViewRow).Where(Function(x) Convert.ToInt32(x.Cells(Id.Index).Value) = Convert.ToInt32(cmbVariables.SelectedValue) And Convert.ToString(x.Cells(Valor.Index).Value) = txtvalor.Text).Count() > 0 And tform = ClsEnums.TiOperacion.INSERTAR Then
                MsgBox("El valor ya ha sido ingresado para esa variable. Verifique la información", MsgBoxStyle.Critical)
                txtvalor.Text = String.Empty
                Return False
            End If
            If Not objValidacion.ComboBoxSeleccionado(cmbVariables, ErrorProvider1) Then Return False
            If Not objValidacion.TextBoxDigitado(txtvalor, ErrorProvider1) Then Return False
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If Validar() Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mvaloresvarable.Ingresar(My.Settings.UsuarioActivo, Convert.ToInt32(cmbVariables.SelectedValue),
                                             txtvalor.Text, cbValorDefecto.Checked, cbimprimir.Checked, cmbEstado.SelectedValue, txtDescTecnica.Text)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mvaloresvarable.Modificar(curid, My.Settings.UsuarioActivo, Convert.ToInt32(cmbVariables.SelectedValue),
                                              txtvalor.Text, cbValorDefecto.Checked, cbimprimir.Checked, cmbEstado.SelectedValue, txtDescTecnica.Text)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                Frm_Load(Nothing, Nothing)
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
            cmbVariables.SelectedValue = 0
            txtvalor.Text = String.Empty
            cmbEstado.SelectedValue = 1
            cbValorDefecto.Checked = False
            cbimprimir.Checked = False
            txtDescTecnica.Text = String.Empty
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