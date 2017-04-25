Imports ReglasNegocio
Imports Validaciones

Public Class frmConceptos
#Region "Variables"
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private loadCompleted As Boolean = False
    Private curid As Integer = 0
    Private fuenteInicial As DataTable = Nothing
#End Region
#Region "Propiedades"
    Public Property Operacion() As ClsEnums.TiOperacion
        Get
            Return tform
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            tform = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarUnidadMedida()
        Try
            Dim mArticulos As New ClsArticulos
            Dim td As DataTable = mArticulos.traerUnidades()
            cmbUnidadMedida.ValueMember = "Unidad"
            cmbUnidadMedida.DisplayMember = "Unidad"
            cmbUnidadMedida.DataSource = td
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTiposObras()
        Try
            Dim mTipoObra As New ClsTiposObras
            Dim listTObras As List(Of tipoObra) = mTipoObra.TraerxEstado(ClsEnums.Estados.ACTIVO)
            cmbTipoObra.DisplayMember = "Descripcion"
            cmbTipoObra.ValueMember = "Id"
            cmbTipoObra.DataSource = listTObras
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarEstados()
        Try
            Dim mEstado As New ClsEstados
            Dim listEstados As List(Of Estado) = mEstado.TraerTodos().Where(Function(a) a.Id = ClsEnums.Estados.ACTIVO Or
                                                                                a.Id = ClsEnums.Estados.INACTIVO).ToList
            cmbEstado.DisplayMember = "Descripcion"
            cmbEstado.ValueMember = "Id"
            cmbEstado.DataSource = listEstados
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub prepararInformacion()
        Try
            Dim mConcepto As New ClsConceptos
            Dim objLista As List(Of concepto) = mConcepto.TraerTodos(dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function Validacion() As Boolean
        Try
            Dim mValidacion As New ClsValidaciones
            If Not mValidacion.TextBoxDigitado(txtConcepto, ErrorProvider) Then
                Return False
            End If
            If Not mValidacion.TextBoxDigitado(txtDescripcion, ErrorProvider) Then
                Return False
            End If
            If cmbUnidadMedida.SelectedValue Is String.Empty Then
                ErrorProvider.SetError(cmbUnidadMedida, "Debe seleccionar un dato. Verifique la información")
                Return False
            End If
            ErrorProvider.Clear()
            If Not mValidacion.ComboBoxSeleccionado(cmbTipoObra, ErrorProvider) Then
                Return False
            End If
            If Not mValidacion.ComboBoxSeleccionado(cmbEstado, ErrorProvider) Then
                Return False
            End If
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                Dim mConcepto As New ClsConceptos
                If mConcepto.ExisteConcepto(txtConcepto.Text) Then
                    MessageBox.Show("El concepto ya existe")
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = r.Cells(id.DataPropertyName).Value
            txtConcepto.Text = r.Cells(concepto.DataPropertyName).Value
            txtDescripcion.Text = r.Cells(descripcion.DataPropertyName).Value
            cmbUnidadMedida.SelectedValue = r.Cells(undMedida.DataPropertyName).Value
            cmbTipoObra.SelectedValue = r.Cells(idTipoObra.DataPropertyName).Value
            cbConceptoContrato.Checked = r.Cells(cContrato.DataPropertyName).Value
            cbConceptoAdicional.Checked = r.Cells(cAdicional.DataPropertyName).Value
            cbConceptoEspecial.Checked = r.Cells(cEspecial.DataPropertyName).Value
            cbCruzaConOP.Checked = r.Cells(cruzaConOP.DataPropertyName).Value
            cmbEstado.SelectedValue = r.Cells(idEstado.DataPropertyName).Value
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmConceptos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarUnidadMedida()
            cmbUnidadMedida.SelectedValue = ""
            cargarTiposObras()
            cmbTipoObra.SelectedValue = 0
            cargarEstados()
            cmbEstado.SelectedValue = 0
            prepararInformacion()
            loadCompleted = True
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
            If Validacion() Then
                Dim mConcepto As New ClsConceptos
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mConcepto.Insertar(My.Settings.UsuarioActivo, txtConcepto.Text, txtDescripcion.Text, cmbUnidadMedida.SelectedValue,
                                       cmbTipoObra.SelectedValue, cbConceptoContrato.Checked, cbConceptoAdicional.Checked, cbConceptoEspecial.Checked,
                                       cbCruzaConOP.Checked, cmbEstado.SelectedValue)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mConcepto.Modificar(curid, txtConcepto.Text, txtDescripcion.Text, cmbUnidadMedida.SelectedValue,
                                        cmbTipoObra.SelectedValue, cbConceptoContrato.Checked, cbConceptoAdicional.Checked,
                                        cbConceptoEspecial.Checked, cbCruzaConOP.Checked, My.Settings.UsuarioActivo, cmbEstado.SelectedValue)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                frmConceptos_Load(Nothing, Nothing)
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
            txtConcepto.Text = String.Empty
            txtDescripcion.Text = String.Empty
            cmbUnidadMedida.SelectedValue = ""
            cmbTipoObra.SelectedValue = 0
            cmbEstado.SelectedValue = 0
            cbConceptoContrato.Checked = False
            cbConceptoAdicional.Checked = False
            cbConceptoEspecial.Checked = False
            cbCruzaConOP.Checked = False
            ErrorProvider.Clear()
            tform = ClsEnums.TiOperacion.INSERTAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
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
End Class