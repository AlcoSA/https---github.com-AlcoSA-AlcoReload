Imports ReglasNegocio
Imports Validaciones

Public Class frmProveedores
#Region "Variables"
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private loadCompleted As Boolean = False
    Private fuenteInicial As DataTable = Nothing
    Private curid As Integer = 0
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
    Private Sub cargarProveedores()
        Try
            Dim mProveedores As New ClsProveedores
            mProveedores.TraerTodosUnoee(itNit.TablaFuente)
            itProveedor.TablaFuente = itNit.TablaFuente
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarEstados()
        Try
            Dim mEstados As New ClsEstados
            Dim listEstados As List(Of Estado) = mEstados.TraerTodos().Where(Function(a) a.Id = ClsEnums.Estados.ACTIVO Or
                                                                                 a.Id = ClsEnums.Estados.INACTIVO).ToList
            cmbEstado.DisplayMember = "Descripcion"
            cmbEstado.ValueMember = "Id"
            cmbEstado.DataSource = listEstados
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarRegiones()
        Try
            Dim mRegion As New ClsRegionesUnoee
            Dim listRegiones As List(Of regionUnoee) = mRegion.TraerTodos()
            cmbZona.DisplayMember = "Descripcion"
            cmbZona.ValueMember = "Id"
            cmbZona.DataSource = listRegiones
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarInfoTextBox()
        Try
            Dim mProveedores As New ClsProveedores
            Dim proveedor As proveedores = mProveedores.TraerProveedorUnoeexNit(itNit.Text)
            txtRpteLegal.Text = proveedor.NombreContacto
            txtDireccion.Text = proveedor.Direccion
            txtTelefono.Text = proveedor.Telefono
            txtIdSiesa.Text = proveedor.IdSiesa
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub prepararInformacion()
        Try
            Dim mProveedor As New ClsProveedores
            Dim objLista As List(Of proveedores) = mProveedor.TraerTodos(dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function Validacion() As Boolean
        Try
            Dim mValidacion As New ClsValidaciones
            If itNit.Text = String.Empty Then
                ErrorProvider.SetError(itNit, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()

            If itProveedor.Text = String.Empty Then
                ErrorProvider.SetError(itProveedor, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()

            If Not mValidacion.TextBoxDigitado(txtRpteLegal, ErrorProvider) Then
                Return False
            End If

            If Not mValidacion.ComboBoxSeleccionado(cmbZona, ErrorProvider) Then
                Return False
            End If

            If Not mValidacion.ComboBoxSeleccionado(cmbEstado, ErrorProvider) Then
                Return False
            End If

            If tform = ClsEnums.TiOperacion.INSERTAR Then
                Dim mProveedor As New ClsProveedores
                If mProveedor.ExisteProveedor(txtIdSiesa.Text) Then
                    MessageBox.Show("El proveedor ya existe")
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
            itNit.Text = r.Cells(nit.DataPropertyName).Value
            itNit.Enabled = False
            itProveedor.Text = r.Cells(nombreProveedor.DataPropertyName).Value
            itProveedor.Enabled = False
            txtRpteLegal.Text = r.Cells(nombreContacto.DataPropertyName).Value
            cmbZona.SelectedValue = r.Cells(idRegionUnoee.DataPropertyName).Value
            txtDireccion.Text = r.Cells(direccion.DataPropertyName).Value
            txtTelefono.Text = r.Cells(telefono.DataPropertyName).Value
            txtIdSiesa.Text = r.Cells(idSiesa.DataPropertyName).Value
            cmbEstado.SelectedValue = r.Cells(idEstado.DataPropertyName).Value
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Funcionamiento intellisens"
    Private Sub itNit_KeyUp(sender As Object, e As KeyEventArgs) Handles itNit.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itProveedor.Text = ""
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub itNit_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itNit.selected_value_changed
        Try
            itProveedor.Text = e.ValorSecundario
            itProveedor.Value2 = e.ValorPrimario
            If loadCompleted Then
                cargarInfoTextBox()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub itProveedor_KeyUp(sender As Object, e As KeyEventArgs) Handles itProveedor.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itNit.Text = ""
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub itProveedor_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itProveedor.selected_value_changed
        Try
            itNit.Text = e.ValorSecundario
            itNit.Value2 = e.ValorPrimario
            If loadCompleted Then
                cargarInfoTextBox()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarProveedores()
            cargarEstados()
            cmbEstado.SelectedValue = 0
            cargarRegiones()
            cmbZona.SelectedValue = 0
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
                Dim mProveedor As New ClsProveedores
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mProveedor.Insert(My.Settings.UsuarioActivo, txtIdSiesa.Text, itNit.Text, itProveedor.Text, txtRpteLegal.Text,
                                      txtDireccion.Text, txtTelefono.Text, cmbZona.SelectedValue, cmbEstado.SelectedValue)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mProveedor.Modificar(curid, txtIdSiesa.Text, itNit.Text, itProveedor.Text, txtRpteLegal.Text, txtDireccion.Text,
                                         txtTelefono.Text, cmbZona.SelectedValue, My.Settings.UsuarioActivo, cmbEstado.SelectedValue)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                frmProveedores_Load(Nothing, Nothing)
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
            itNit.Text = String.Empty
            itNit.Enabled = True
            itProveedor.Text = String.Empty
            itProveedor.Enabled = True
            txtRpteLegal.Text = String.Empty
            cmbZona.SelectedValue = 0
            txtDireccion.Text = String.Empty
            txtTelefono.Text = String.Empty
            txtIdSiesa.Text = String.Empty
            cmbEstado.SelectedValue = 0
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