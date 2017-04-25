Imports ReglasNegocio
Imports Validaciones
Public Class FrmMotivosDevolucionProduccion
#Region "Variables"
    Private _motdevol As ClsMotivosDevolucionOp
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
                If _validacion.RichTextBoxDigitado(txtDescripcion, ErrorProvider1) Then

                    _motdevol.Insertar(txtDescripcion.Text, My.Settings.UsuarioActivo, cmbEstado.SelectedValue)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                frmObjetos_Load(Nothing, Nothing)
            Else
                If _validacion.RichTextBoxDigitado(txtDescripcion, ErrorProvider1) Then
                    _motdevol.Modificar(_curid, txtDescripcion.Text, My.Settings.UsuarioActivo, cmbEstado.SelectedValue)
                End If
                MsgBox("La información se actualizó exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                frmObjetos_Load(Nothing, Nothing)
            End If
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
            txtDescripcion.Text = r.Cells(Motivo.Index).Value.ToString().Trim
            cmbEstado.SelectedValue = Convert.ToInt32(r.Cells(Id_estado.Index).Value)
            _tform = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Procedimientos Controles"
    Private Sub Frm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            DirectCast(Me.MdiParent, frmInicial).btnGuardar.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnLimpiar.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnimpresion.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnimprimir.Enabled = True
            DirectCast(Me.MdiParent, frmInicial).btnrecargar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnexportar.Enabled = False
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnGuardar.Click, AddressOf GuardadoTotal_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Click, AddressOf GuardadoTotal_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal.Click, AddressOf GuardadoTotal_Click

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            DirectCast(Me.MdiParent, frmInicial).btnGuardar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnLimpiar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnimpresion.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnimprimir.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnvistaprevia.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnrecargar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnexportar.Enabled = False
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnGuardar.Click, AddressOf GuardadoTotal_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Click, AddressOf GuardadoTotal_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal.Click, AddressOf GuardadoTotal_Click

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub frmObjetos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            _motdevol = New ClsMotivosDevolucionOp
            cargarEstados()
            _motdevol.TraerTodos(dwItems.TablaDatos)
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