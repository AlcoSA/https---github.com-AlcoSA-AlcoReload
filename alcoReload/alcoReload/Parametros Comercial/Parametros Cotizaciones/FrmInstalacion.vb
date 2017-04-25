Imports ReglasNegocio
Imports ReglasNegocio.Ciudades
Imports ReglasNegocio.ManoObraInstalacion
Imports Validaciones

Public Class FrmInstalacion
#Region "Variables"
    Private mInstalacion As ClsManoObraInstalacion
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
    Private Sub cargarUnidade()
        Try
            Dim td As DataTable = mInstalacion.traerUnidades()
            cmbUnidadMedida.ValueMember = "Unidad"
            cmbUnidadMedida.DisplayMember = "Unidad"
            cmbUnidadMedida.DataSource = td
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

    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = Convert.ToInt32(r.Cells(id_ManoObra.DataPropertyName).Value)
            txtDescripcion.Text = r.Cells(Descripcion.DataPropertyName).Value.ToString
            cmbPais.SelectedValue = Convert.ToInt32(r.Cells(id_Pais.DataPropertyName).Value)
            cmbDepartamento.SelectedValue = Convert.ToInt32(r.Cells(Id_Dpto.DataPropertyName).Value)
            cmbCiudad.SelectedValue = Convert.ToInt32(r.Cells(Id_Ciudad.DataPropertyName).Value)
            cmbUnidadMedida.SelectedValue = r.Cells(Unidad_Medida.DataPropertyName).Value
            nudValor.Value = r.Cells(Valor.DataPropertyName).Value.ToString
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

    Private Sub FrmInstalacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mInstalacion = New ClsManoObraInstalacion
            Dim objLista As List(Of manoObraInstalacion) = mInstalacion.traerTodos(dwItems.TablaDatos)
            cargarPais()
            cargarUnidade()
            cargarEstados()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function Validar() As Boolean
        objValidacion = New ClsValidaciones
        Try
            If Not objValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider1) Then Return False
            If Not objValidacion.ComboBoxSeleccionado(cmbCiudad, ErrorProvider1) Then Return False
            'If Not objValidacion.NumeroMayorACero(nudValor, ErrorProvider1) Then Return False
            If (String.IsNullOrEmpty(cmbUnidadMedida.SelectedValue)) Then
                ErrorProvider1.SetError(cmbUnidadMedida, "Debe seleccionar un dato. Verifique la información")
                Return False
            End If
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                If mInstalacion.TraerxDescripcion(txtDescripcion.Text) = True Then
                    ErrorProvider1.SetError(txtDescripcion, "Ya existe este registro")
                    Return False
                End If
                ErrorProvider1.Clear()
            End If
            ErrorProvider1.Clear()
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
                    mInstalacion.Ingresar(My.Settings.UsuarioActivo, cmbUnidadMedida.Text, nudValor.Value, cmbEstado.SelectedValue,
                                          txtDescripcion.Text, cmbCiudad.SelectedValue, Convert.ToInt32(cbValorPorDefecto.Checked))
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mInstalacion.Modificar(cmbUnidadMedida.Text, nudValor.Value, My.Settings.UsuarioActivo, cmbEstado.SelectedValue,
                                           txtDescripcion.Text, cmbCiudad.SelectedValue, curid, Convert.ToInt32(cbValorPorDefecto.Checked))
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                FrmInstalacion_Load(Nothing, Nothing)
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
            cmbCiudad.SelectedValue = 0
            cmbUnidadMedida.SelectedValue = String.Empty
            cmbPais.SelectedValue = 0
            cmbDepartamento.SelectedValue = 0
            cmbCiudad.SelectedValue = 0
            nudValor.Value = 0
            cmbEstado.SelectedValue = 1
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

    Private Sub nud_GotFocus(sender As Object, e As EventArgs) Handles nudValor.GotFocus
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

    Private Sub nud_Leave(sender As Object, e As EventArgs) Handles nudValor.Leave
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