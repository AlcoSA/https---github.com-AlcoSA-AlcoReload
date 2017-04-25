Imports ReglasNegocio

Public Class frmDestinatarios
#Region "Variables"
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curId As Integer = 0
    Private fuenteInicial As DataTable = Nothing
#End Region
#Region "Procedimientos"
    Private Sub cargarEstados()
        Try
            Dim mEstado As New ClsEstados
            Dim list As List(Of Estado) = mEstado.TraerTodos().Where(Function(a)
                                                                         Return a.Id = ClsEnums.Estados.ACTIVO Or
                                                                         a.Id = ClsEnums.Estados.INACTIVO
                                                                     End Function).ToList
            cmbEstado.DisplayMember = "Descripcion"
            cmbEstado.ValueMember = "Id"
            cmbEstado.DataSource = list
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarSecciones()
        Try
            Dim mSecciones As New ClsSecciones
            Dim list As List(Of seccion) = mSecciones.TraerTodos()
            cmbSecciones.DisplayMember = "Prefijo"
            cmbSecciones.ValueMember = "Id"
            cmbSecciones.DatosVisibles = {"Prefijo", "Descripcion"}
            cmbSecciones.DataSource = list
            cmbSecciones.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            tform = ClsEnums.TiOperacion.MODIFICAR
            curId = r.Cells(id.DataPropertyName).Value
            cmbSecciones.SelectedValue = r.Cells(idSeccion.DataPropertyName).Value
            txtNombre.Text = r.Cells(nombre.DataPropertyName).Value
            txtCorreo.Text = r.Cells(correo.DataPropertyName).Value
            cmbEstado.SelectedValue = r.Cells(idEstado.DataPropertyName).Value
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacion() As Boolean
        Try
            If cmbSecciones.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbSecciones, "Debe seleccionar la sección")
                Return False
            End If
            ErrorProvider.Clear()

            If txtNombre.Text = String.Empty Then
                ErrorProvider.SetError(txtNombre, "Ingrese el nombre del destinatario")
                Return False
            End If
            ErrorProvider.Clear()

            If txtCorreo.Text = String.Empty Then
                ErrorProvider.SetError(txtCorreo, "Ingrese la dirección de correo electrónico")
                Return False
            End If
            ErrorProvider.Clear()

            If Not ValidarEmail(txtCorreo.Text) Then
                ErrorProvider.SetError(txtCorreo, "La dirección de correo es incorrecta")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbEstado.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbEstado, "Debe seleccionar el estado")
                Return False
            End If
            ErrorProvider.Clear()

            Dim mDestinatarios As New ClsDestinatarios
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                If mDestinatarios.ExisteRegistro(cmbSecciones.SelectedValue, txtCorreo.Text) Then
                    MsgBox("Ya existe este destinatario para la sección indicada")
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Function ValidarEmail(ByVal email As String) As Boolean
        Try
            Dim emailRegex As New System.Text.RegularExpressions.Regex(
            "^(?<user>[^@]+)@(?<host>.+)$")
            Dim emailMatch As System.Text.RegularExpressions.Match =
           emailRegex.Match(email)
            Return emailMatch.Success
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub frmDestinatarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarEstados()
            cargarSecciones()
            Dim mDestinatario As New ClsDestinatarios
            mDestinatario.TraerTodos(dwItems.TablaDatos)
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
    Private Sub Frm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
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
    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try
            If validacion() Then
                Dim mDestinatario As New ClsDestinatarios
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mDestinatario.Insertar(My.Settings.UsuarioActivo, cmbSecciones.SelectedValue,
                                           txtNombre.Text, txtCorreo.Text, cmbEstado.SelectedValue)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mDestinatario.Modificar(cmbSecciones.SelectedValue, txtNombre.Text, txtCorreo.Text,
                                            My.Settings.UsuarioActivo, cmbEstado.SelectedValue, curId)
                End If
                MessageBox.Show("La información se ha guardado exitosamente", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnLimpiar_Click(Nothing, Nothing)
                frmDestinatarios_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        Try
            curId = 0
            cmbSecciones.SelectedItem = Nothing
            txtNombre.Text = String.Empty
            txtCorreo.Text = String.Empty
            cmbEstado.SelectedValue = CInt(ClsEnums.Estados.ACTIVO)
            tform = ClsEnums.TiOperacion.INSERTAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
                If e.Button = MouseButtons.Right Then
                    r.Selected = True
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("Modificar", Nothing, AddressOf Modificar)
                    menu.Show(MousePosition)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class