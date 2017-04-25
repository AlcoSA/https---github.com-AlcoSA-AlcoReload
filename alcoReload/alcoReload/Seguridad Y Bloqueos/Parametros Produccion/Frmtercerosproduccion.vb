Imports ReglasNegocio
Imports Validaciones
Public Class Frmtercerosproduccion
#Region "Variables"
    Private _tercerosprod As ClsTercerosProduccion
    Private _curid As Integer
    Private _validacion As New ClsValidaciones
    Private _tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
#End Region

#Region "Procedimientos Usuarios"
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
    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If _tform = ClsEnums.TiOperacion.INSERTAR Then
                If _validacion.TextBoxDigitado(txtDescripcion, ErrorProvider1) Then
                    _tercerosprod.Insertar(txtDescripcion.Text, txtdireccion.Text, txttelefono.Text,
                                           My.Settings.UsuarioActivo, cmbEstado.SelectedValue)
                End If

            Else
                If _validacion.TextBoxDigitado(txtDescripcion, ErrorProvider1) Then
                    _tercerosprod.Modificar(txtDescripcion.Text, txtdireccion.Text, txttelefono.Text,
                                            My.Settings.UsuarioActivo, cmbEstado.SelectedValue, _curid)
                End If
            End If
            MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
            btnLimpiar_Click(Nothing, Nothing)
            frmObjetos_Load(Nothing, Nothing)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            _curid = 0
            txtDescripcion.Clear()
            cmbEstado.SelectedValue = 1
            txtDescripcion.Clear()
            ErrorProvider1.Clear()
            _tform = ClsEnums.TiOperacion.INSERTAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            _curid = Convert.ToInt32(r.Cells(id.Index).Value)
            txtDescripcion.Text = r.Cells(tercero.Index).Value
            txtdireccion.Text = r.Cells(direccion.Index).Value
            txttelefono.Text = r.Cells(telefono.Index).Value
            cmbEstado.SelectedValue = Convert.ToInt32(r.Cells(Id_estado.Index).Value)
            _tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Procedimientos Controles"
    Private Sub frmObjetos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            ErrorProvider1.Clear()
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

    Private Sub frmObjetos_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
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

    Private Sub frmObjetos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            _tercerosprod = New ClsTercerosProduccion
            cargarEstados()
            _tercerosprod.TraerTodos(dwItems.TablaDatos)
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
#End Region
End Class