﻿Imports ReglasNegocio
Imports Validaciones
Public Class frmTipoEscritura
#Region "Variables"
    Private _objTipoEscrituras As clsTipoEscritura
    Private _idToEdit As Integer
    Private fuenteInicial As DataTable = Nothing
    Private _validacion As New ClsValidaciones
#End Region
#Region "Propiedades"
    Private _tipoOperacom As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Public Property tipoOperacion() As ClsEnums.TiOperacion
        Get
            Return _tipoOperacom
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            _tipoOperacom = value
        End Set
    End Property
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
            If _tipoOperacom = ClsEnums.TiOperacion.INSERTAR Then
                If _validacion.TextBoxDigitado(txtDescripcion, ErrorProvider1) Then
                    _objTipoEscrituras = New clsTipoEscritura
                    _objTipoEscrituras.insert(My.Settings.UsuarioActivo, txtDescripcion.Text, cmbEstado.SelectedValue)
                End If
                MsgBox("La información se guardo exitosamente", MsgBoxStyle.Information)
                btnLimpiar_Click(Nothing, Nothing)
                frmObjetos_Load(Nothing, Nothing)
            Else
                If _validacion.TextBoxDigitado(txtDescripcion, ErrorProvider1) Then
                    _objTipoEscrituras = New clsTipoEscritura
                    _objTipoEscrituras.update(_idToEdit, txtDescripcion.Text, My.Settings.UsuarioActivo, cmbEstado.SelectedValue)
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
            _idToEdit = 0
            txtDescripcion.Clear()
            cmbEstado.SelectedValue = 1
            txtDescripcion.Clear()
            ErrorProvider1.Clear()
            _tipoOperacom = ClsEnums.TiOperacion.INSERTAR
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Modificar()
        Try
            Dim r As DataGridViewRow = dwItems.SelectedRows(0)
            _idToEdit = Convert.ToInt32(r.Cells(id.DataPropertyName).Value)
            txtDescripcion.Text = r.Cells(descripcion.DataPropertyName).Value.ToString().Trim
            cmbEstado.SelectedValue = r.Cells(idEstado.DataPropertyName).Value
            _tipoOperacom = ClsEnums.TiOperacion.MODIFICAR
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
            _objTipoEscrituras = New clsTipoEscritura
            dwItems.TablaDatos = Nothing
            Dim listaObjetosContratos As List(Of tipoEscritura) = _objTipoEscrituras.traerTodos(dwItems.TablaDatos)
            cargarEstados()
        Catch ex As Exception

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