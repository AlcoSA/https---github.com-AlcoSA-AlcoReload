Imports ReglasNegocio
Imports ReglasNegocio.Componente
Imports Validaciones

Public Class FrmTiposObra
#Region "Variables"
    Private mTipoObra As ClsTiposObras
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
    Private Sub cargarParaSegunTiposObra()
        Try
            Dim mObjetosContratos As New clsObjetosContratos
            Dim listObjetosContratos As List(Of objetoContrato) = mObjetosContratos.traerTodos()
            Dim bsource, bsource2 As New BindingSource()
            bsource.DataSource = listObjetosContratos.Where(Function(a) a.Id <> 3 And a.Id <> 4)
            cmbParaSuministro.DisplayMember = "Descripcion"
            cmbParaSuministro.ValueMember = "Id"
            cmbParaSuministro.DataSource = bsource

            bsource2.DataSource = listObjetosContratos.Where(Function(a) a.Id <> 1 And a.Id <> 2).ToList
            cmbParaInstalacion.DisplayMember = "Descripcion"
            cmbParaInstalacion.ValueMember = "Id"
            cmbParaInstalacion.DataSource = listObjetosContratos.Where(Function(a) a.Id <> 1 And a.Id <> 2).ToList
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = Convert.ToInt32(r.Cells(Id.DataPropertyName).Value)
            txtDescripcion.Text = r.Cells(descripcion.DataPropertyName).Value.ToString()
            cmbComponente.SelectedValue = Convert.ToInt32(r.Cells(idComponente.DataPropertyName).Value)
            cmbEstado.SelectedValue = r.Cells(idEstado.DataPropertyName).Value
            cbValorDefecto.Checked = Convert.ToBoolean(r.Cells(valorDefecto.DataPropertyName).Value)
            cbIVA.Checked = Convert.ToBoolean(r.Cells(tipoImpuesto.DataPropertyName).Value)
            cmbParaSuministro.SelectedValue = CInt(r.Cells(idParaSuministro.DataPropertyName).Value)
            cmbParaInstalacion.SelectedValue = CInt(r.Cells(idParaInstalacion.DataPropertyName).Value)
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cargarComponentes()
        Try
            Dim mComponente As New ClsComponentes
            Dim listaComponentes As List(Of componente) = mComponente.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listaComponentes
            cmbComponente.DisplayMember = "descripcion"
            cmbComponente.ValueMember = "Id"
            cmbComponente.DataSource = bsource
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

    Private Sub FrmTiposObra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mTipoObra = New ClsTiposObras
            cargarComponentes()
            Dim objLista As List(Of tipoObra) = mTipoObra.TraerTodos(dwItems.TablaDatos)
            cargarEstados()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function Validacion() As Boolean
        Try
            objValidacion = New ClsValidaciones
            mTipoObra = New ClsTiposObras
            If Not objValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider) Then Return False
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                If mTipoObra.TraerxDescripcion(txtDescripcion.Text) = True Then
                    ErrorProvider.SetError(txtDescripcion, "Ya existe este registro")
                    Return False
                End If
                ErrorProvider.Clear()
            End If
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
                    mTipoObra.Ingresar(My.Settings.UsuarioActivo, txtDescripcion.Text, cmbComponente.SelectedValue,
                                       cmbEstado.SelectedValue, Convert.ToInt32(cbValorDefecto.Checked),
                                       Int32.Parse(cbIVA.Tag), cmbParaSuministro.SelectedValue, cmbParaInstalacion.SelectedValue)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mTipoObra.Modificar(My.Settings.UsuarioActivo, txtDescripcion.Text, cmbEstado.SelectedValue,
                                        Convert.ToInt32(cbValorDefecto.Checked), curid, cmbComponente.SelectedValue,
                                        Convert.ToInt32(cbIVA.Checked), cmbParaSuministro.SelectedValue, cmbParaInstalacion.SelectedValue)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                FrmTiposObra_Load(Nothing, Nothing)
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
            txtDescripcion.Clear()
            cmbEstado.SelectedValue = 1
            cbValorDefecto.Checked = False
            cbIVA.Checked = False
            cmbComponente.SelectedValue = 0
            ErrorProvider.Clear()
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

    Private Sub cbIVA_CheckedChanged(sender As Object, e As EventArgs) Handles cbIVA.CheckedChanged
        Try
            If cbIVA.Checked Then
                cbIVA.Tag = 1
                cbIVA.Text = "IVA pleno"
            Else
                cbIVA.Tag = 2
                cbIVA.Text = "IVA sobre la utilidad"
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