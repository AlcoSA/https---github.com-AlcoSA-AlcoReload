Imports ReglasNegocio
Imports Validaciones

Public Class FrmVigencias
#Region "Variables"
    Private mVigencia As New ClsVigencias
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private fuenteInicial As DataTable = Nothing
    Private objValidacion As ClsValidaciones
#End Region
#Region "Procedimientos"
    Private Sub cargarEstados()
        Try
            Dim mEstado As New ClsEstados
            Dim listEstados As List(Of Estado) = mEstado.TraerTodos()
            Dim bsource As New BindingSource()
            bsource.DataSource = listEstados.Where(Function(a) a.Id < 3)
            cmbEstados.DisplayMember = "Descripcion"
            cmbEstados.ValueMember = "Id"
            cmbEstados.DataSource = bsource
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = r.Cells(id.DataPropertyName).Value
            nudDias.Value = r.Cells(dias.DataPropertyName).Value
            cmbEstados.SelectedValue = Convert.ToInt32(r.Cells(idEstado.DataPropertyName).Value)
            cbValorDefecto.Checked = Convert.ToBoolean(Convert.ToInt32(r.Cells(valorDefecto.DataPropertyName).Value))
            nudDias.Enabled = False
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

    Private Sub FrmVigencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mVigencia = New ClsVigencias
            Dim objLista As List(Of Vigencia) = mVigencia.traerTodos(dwItems.TablaDatos)
            cargarEstados()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            If Validar() Then
                mVigencia = New ClsVigencias
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    mVigencia.Ingresar(My.Settings.UsuarioActivo, nudDias.Value & " DIAS", nudDias.Value, cmbEstados.SelectedValue, Convert.ToInt32(cbValorDefecto.Checked))
                Else
                    mVigencia.Modificar(curid, My.Settings.UsuarioActivo, cmbEstados.SelectedValue, Convert.ToInt32(cbValorDefecto.Checked))
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                FrmVigencias_Load(Nothing, Nothing)
            Else
                Return
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Try
            objValidacion = New ClsValidaciones
            If objValidacion.NumeroMayorACero(nudDias, ErrorProvider) Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception("Error en validación: " & ex.Message, ex.InnerException)
        End Try
    End Function

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        Try
            curid = 0
            nudDias.Value = 0
            cmbEstados.SelectedValue = 1
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
End Class