Imports ReglasNegocio
Imports ReglasNegocio.Ciudades
Imports ReglasNegocio.Factores
Imports Validaciones

Public Class FrmFactores
#Region "Variables"
    Private mFactores As ClsFactores
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private objValidacion As ClsValidaciones
    Private mPais As ClsPaises
    Private mDepto As ClsDepartamentos
    Private mCiudad As ClsCiudades
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
            curid = Convert.ToInt32(r.Cells(id_Factor.DataPropertyName).Value)
            nudTasa.Value = r.Cells(Tasa.DataPropertyName).Value.ToString
            nudTasa.Enabled = False
            nudTasa.ReadOnly = True
            cmbEstado.SelectedValue = r.Cells(id_Estado.DataPropertyName).Value
            txtDescripcion.Text = r.Cells(Descripcion.DataPropertyName).Value.ToString
            txtDescripcion.Enabled = False
            txtDescripcion.ReadOnly = True
            cmbPais.SelectedValue = Convert.ToInt32(r.Cells(id_Pais.DataPropertyName).Value)
            cmbDepartamento.SelectedValue = Convert.ToInt32(r.Cells(id_Dpto.DataPropertyName).Value)
            cmbCiudad.SelectedValue = Convert.ToInt32(r.Cells(id_Ciudad.DataPropertyName).Value)
            cbValorPorDefecto.Checked = Convert.ToBoolean(r.Cells(valor_Defecto.DataPropertyName).Value)
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarPais()
        Try
            mPais = New ClsPaises
            Dim listPaises As List(Of Pais) = mPais.TraerxValorDefecto()
            If Not mPais.ExisteValorDefecto Then
                listPaises.Insert(0, New Pais)
            End If
            cmbPais.DisplayMember = "descripcion"
            cmbPais.ValueMember = "Id"
            cmbPais.DataSource = listPaises
            cmbDepartamento.Enabled = False
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarDepartamento(idPais As Integer)
        Try
            mDepto = New ClsDepartamentos
            Dim listDptos As List(Of Departamento) = mDepto.TraerxValorDefectoAndIdPais(idPais)
            If Not mDepto.ExisteValorDefecto Then
                listDptos.Insert(0, New Departamento)
            End If
            cmbDepartamento.DisplayMember = "descripcion"
            cmbDepartamento.ValueMember = "Id"
            cmbDepartamento.DataSource = listDptos
            cmbCiudad.Enabled = False
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarCiudad(idDpto As Integer)
        Try
            mCiudad = New ClsCiudades
            Dim listCiudades As List(Of Ciudad) = mCiudad.TraerxIdDepartamentoAndValorDefecto(idDpto)
            If Not mCiudad.ExisteValorDefecto Then
                listCiudades.Insert(0, New Ciudad)
            End If
            cmbCiudad.DisplayMember = "nombreCiudad"
            cmbCiudad.ValueMember = "Id"
            cmbCiudad.DataSource = listCiudades
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

    Private Sub FrmFactores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mFactores = New ClsFactores
            Dim listObjeto As List(Of factores) = mFactores.traerTodos(dwItems.TablaDatos)
            cargarPais()
            cargarEstados()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Try
            objValidacion = New ClsValidaciones
            mFactores = New ClsFactores
            If Not objValidacion.NumeroMayorACero(nudTasa, ErrorProvider1) Then Return False
            If Not objValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider1) Then Return False
            Return True
        Catch ex As Exception
            Return False
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function

    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If Validar() Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mFactores.Ingresar(My.Settings.UsuarioActivo, nudTasa.Value, cmbEstado.SelectedValue, cmbCiudad.SelectedValue,
                                       txtDescripcion.Text, Convert.ToInt32(cbValorPorDefecto.Checked))

                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mFactores.Modificar(cmbEstado.SelectedValue, curid, Convert.ToInt32(cbValorPorDefecto.Checked), My.Settings.UsuarioActivo, cmbCiudad.SelectedValue)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                FrmFactores_Load(Nothing, Nothing)
            Else
                Return
            End If

        Catch ex As Exception
            If ex.Message.Contains("índice único 'IX_tc009_factor'") Then
                ErrorProvider1.Clear()
                ErrorProvider1.SetError(nudTasa, "Ya existe este factor para la ciudad seleccionada. Verifique la información")
                Return
            End If
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            curid = 0
            nudTasa.Value = 0
            nudTasa.Enabled = True
            nudTasa.ReadOnly = False
            cmbPais.SelectedValue = 0
            cmbDepartamento.SelectedValue = 0
            cmbCiudad.SelectedValue = 0
            cmbEstado.SelectedValue = 1
            txtDescripcion.Clear()
            txtDescripcion.ReadOnly = False
            txtDescripcion.Enabled = True
            ErrorProvider1.Clear()
            cbValorPorDefecto.Checked = False
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

    Private Sub cmbPais_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedValueChanged
        Try
            cmbDepartamento.Enabled = True
            cargarDepartamento(cmbPais.SelectedValue)
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbDepartamento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDepartamento.SelectedValueChanged
        Try
            cmbCiudad.Enabled = True
            cargarCiudad(cmbDepartamento.SelectedValue)
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudTasa.GotFocus
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

    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudTasa.Leave
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