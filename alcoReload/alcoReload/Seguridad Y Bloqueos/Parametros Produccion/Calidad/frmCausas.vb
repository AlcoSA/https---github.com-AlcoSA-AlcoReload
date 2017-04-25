Imports ReglasNegocio

Public Class frmCausas
#Region "Variables"
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curId As Integer = 0
    Private fuenteInicial As DataTable = Nothing
#End Region
#Region "Procedimientos"
    Private Sub cargarEstados()
        Try
            Dim mEstados As New ClsEstados
            Dim list As List(Of Estado) = mEstados.TraerTodos.Where(Function(a)
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
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            tform = ClsEnums.TiOperacion.MODIFICAR
            curId = r.Cells(id.DataPropertyName).Value
            txtNombre.Text = r.Cells(nombre.DataPropertyName).Value
            txtDescripcion.Text = r.Cells(descripcion.DataPropertyName).Value
            cmbEstado.SelectedValue = r.Cells(idEstado.DataPropertyName).Value
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacion() As Boolean
        Try
            If txtNombre.Text = String.Empty Then
                ErrorProvider.SetError(txtNombre, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()
            If txtDescripcion.Text = String.Empty Then
                ErrorProvider.SetError(txtDescripcion, "El campo no debe estar vacío. Ingrese la información")
                Return False
            End If
            ErrorProvider.Clear()
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                Dim mCausa As New ClsCausas
                If mCausa.ExisteRegistro(txtNombre.Text) Then
                    ErrorProvider.SetError(txtNombre, "Ya existe esta causa")
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
#End Region
    Private Sub frmCausas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarEstados()
            Dim mCausas As New ClsCausas
            mCausas.TraerTodos(dwItems.TablaDatos)
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
                Dim mCausas As New ClsCausas
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mCausas.Insertar(My.Settings.UsuarioActivo, txtNombre.Text, txtDescripcion.Text, cmbEstado.SelectedValue)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mCausas.Modificar(txtNombre.Text, txtDescripcion.Text, My.Settings.UsuarioActivo, cmbEstado.SelectedValue, curId)
                End If
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnLimpiar_Click(Nothing, Nothing)
                frmCausas_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        Try
            curId = 0
            txtNombre.Text = String.Empty
            txtDescripcion.Text = String.Empty
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