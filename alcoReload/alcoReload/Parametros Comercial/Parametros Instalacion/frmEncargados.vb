Imports ReglasNegocio
Imports Validaciones

Public Class frmEncargados
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
    Private Sub cargarProveedores()
        Try
            Dim mProveedor As New ClsProveedores
            mProveedor.TraerTodos(itProveedor.TablaFuente)
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
            Dim mEncargado As New ClsEncargados
            Dim objLista As List(Of encargado) = mEncargado.TraerTodos(dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function Validacion() As Boolean
        Try
            Dim mValidacion As New ClsValidaciones
            If Not mValidacion.TextBoxDigitado(txtNombre, ErrorProvider) Then
                Return False
            End If
            If itProveedor.Text = String.Empty Then
                ErrorProvider.SetError(itProveedor, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()
            If Not mValidacion.TextBoxDigitado(txtTelefono, ErrorProvider) Then
                Return False
            End If
            If Not mValidacion.ComboBoxSeleccionado(cmbEstado, ErrorProvider) Then
                Return False
            End If

            If tform = ClsEnums.TiOperacion.INSERTAR Then
                Dim mEncargado As New ClsEncargados
                If mEncargado.ExisteEncargado(RTrim(txtNombre.Text), RTrim(itProveedor.Text)) Then
                    MessageBox.Show("El encargado ya existe")
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
            txtNombre.Text = r.Cells(nombreEncargado.DataPropertyName).Value
            itProveedor.Seleted_rowid = r.Cells(idProveedor.DataPropertyName).Value
            itProveedor.Text = r.Cells(proveedor.DataPropertyName).Value
            txtTelefono.Text = r.Cells(telefono.DataPropertyName).Value
            cmbEstado.SelectedValue = r.Cells(idEstado.DataPropertyName).Value
            tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmEncargados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarProveedores()
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
                Dim mEncargado As New ClsEncargados
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mEncargado.Insertar(My.Settings.UsuarioActivo, txtNombre.Text, itProveedor.Seleted_rowid,
                                        txtTelefono.Text, cmbEstado.SelectedValue)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mEncargado.Modificar(curid, txtNombre.Text, itProveedor.Seleted_rowid, txtTelefono.Text,
                                         My.Settings.UsuarioActivo, cmbEstado.SelectedValue)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                frmEncargados_Load(Nothing, Nothing)
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
            txtNombre.Text = String.Empty
            itProveedor.Seleted_rowid = Nothing
            itProveedor.Text = String.Empty
            txtTelefono.Text = String.Empty
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