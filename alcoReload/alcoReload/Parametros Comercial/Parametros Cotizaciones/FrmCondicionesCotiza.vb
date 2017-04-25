Imports ReglasNegocio
Imports Validaciones

Public Class FrmCondicionesCotiza
#Region "Variables"
    Private mCondiciones As ClsCondiciones
    Private _objGrupos As New ClsGruposCondiciones
    Private curid As Integer = 0
    Private objValidacion As ClsValidaciones
    Private fuenteInicial As DataTable = Nothing
#End Region
#Region "Propiedades"
    Private _operacionActual As ClsEnums.TiOperacion
    Public Property operacionActual() As ClsEnums.TiOperacion
        Get
            Return _operacionActual
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            _operacionActual = value
        End Set
    End Property
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
    Private Sub cargarTiposObras()
        Try
            Dim mTipoObra As New ClsTiposObras
            Dim listTipoObras As List(Of tipoObra) = mTipoObra.TraerTodos()
            cmbTipoObra.DisplayMember = "Descripcion"
            cmbTipoObra.ValueMember = "id"
            cmbTipoObra.DataSource = listTipoObras.ToList
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            curid = Convert.ToInt32(r.Cells(id.DataPropertyName).Value)
            cmbEstado.SelectedValue = r.Cells(idEstado.DataPropertyName).Value
            cmbTipoObra.SelectedValue = r.Cells(idTipoObra.DataPropertyName).Value
            txtCondicion.Text = r.Cells(Condicion.DataPropertyName).Value.ToString
            cmbGrupo.SelectedValue = r.Cells(idGrupo.DataPropertyName).Value
            _operacionActual = ClsEnums.TiOperacion.MODIFICAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Sub cargarGrupos()
        Try
            Dim listgrupos As List(Of grupoCondiones) = _objGrupos.selectAll()
            cmbGrupo.ValueMember = "id"
            cmbGrupo.DisplayMember = "Descripcion"
            cmbGrupo.DataSource = listgrupos.ToList()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
#Region "Procedimientos de controles"
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

    Private Sub FrmFactores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mCondiciones = New ClsCondiciones
            Dim listObjeto As List(Of condicion) = mCondiciones.selectAll(dwItems.TablaDatos)
            cargarGrupos()
            cargarEstados()
            cargarTiposObras()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Function Validar() As Boolean
        Try
            objValidacion = New ClsValidaciones
            mCondiciones = New ClsCondiciones
            If Not objValidacion.TextBoxDigitado(txtCondicion, ErrorProvider1) Then Return False
            Return True
        Catch ex As Exception
            Return False
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function

    Private Sub GuardadoTotal_Click(sender As System.Object, e As System.EventArgs)
        Try
            mCondiciones = New ClsCondiciones
            If Validar() Then
                If _operacionActual = ClsEnums.TiOperacion.INSERTAR Then
                    mCondiciones.insert(Now, My.Settings.UsuarioActivo, cmbTipoObra.SelectedValue, txtCondicion.Text, cmbEstado.SelectedValue, cmbGrupo.SelectedValue)
                ElseIf _operacionActual = ClsEnums.TiOperacion.MODIFICAR Then
                    mCondiciones.update(curid, My.Settings.UsuarioActivo, cmbTipoObra.SelectedValue, txtCondicion.Text, cmbEstado.SelectedValue, cmbGrupo.SelectedValue)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                FrmFactores_Load(Nothing, Nothing)
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
            cmbTipoObra.SelectedValue = 1
            cmbEstado.SelectedValue = 1
            txtCondicion.Clear()
            ErrorProvider1.Clear()
            _operacionActual = ClsEnums.TiOperacion.INSERTAR
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