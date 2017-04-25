Imports ReglasNegocio

Public Class frmDevoluciones
#Region "Variables"
    Private _idCuentaCobro As Integer
    Private _documentoCCobro As String
    Private _consecutivoCCobro As Integer
    Private _obra As String
    Private _vendedor As String
    Private _fechaCreacion As DateTime
    Private _proveedor As String
    Private _encargado As String

    Private loadCompleted As Boolean = False
    Private Sep As Char
#End Region
#Region "Propiedades"
    Public Property IdCuentaCobro() As Integer
        Get
            Return _idCuentaCobro
        End Get
        Set(ByVal value As Integer)
            _idCuentaCobro = value
        End Set
    End Property
    Public Property DocumentoCCobro() As String
        Get
            Return _documentoCCobro
        End Get
        Set(ByVal value As String)
            _documentoCCobro = value
        End Set
    End Property
    Public Property ConsecutivoCCobro() As Integer
        Get
            Return _consecutivoCCobro
        End Get
        Set(ByVal value As Integer)
            _consecutivoCCobro = value
        End Set
    End Property
    Public Property Obra() As String
        Get
            Return _obra
        End Get
        Set(ByVal value As String)
            _obra = value
        End Set
    End Property
    Public Property Vendedor() As String
        Get
            Return _vendedor
        End Get
        Set(ByVal value As String)
            _vendedor = value
        End Set
    End Property
    Public Property FechaCreacion() As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _fechaCreacion = value
        End Set
    End Property
    Public Property Proveedor() As String
        Get
            Return _proveedor
        End Get
        Set(ByVal value As String)
            _proveedor = value
        End Set
    End Property
    Public Property Encargado() As String
        Get
            Return _encargado
        End Get
        Set(ByVal value As String)
            _encargado = value
        End Set
    End Property
#End Region
#Region "Prcedimientos"
    Private Sub cargarDocumentos()
        Try
            Dim mDocumentos As New ClsDocumentosOT
            Dim list As List(Of documentoOT) = mDocumentos.TraerTodos().Where(Function(a) a.Prefijo.Contains("DCC")).ToList
            cmbDocumentos.DisplayMember = "Prefijo"
            cmbDocumentos.ValueMember = "Id"
            cmbDocumentos.DatosVisibles = {"Prefijo", "Descripcion"}
            cmbDocumentos.DataSource = list
            cmbDocumentos.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarMovitosCCobro()
        Try
            dwItems.Rows.Clear()
            Dim mMovitoCCobro As New ClsMovitoCuentaCobro
            Dim list As List(Of cuentaCobroDevolucion) = mMovitoCCobro.TraerMovimientosParaDevolucion(_idCuentaCobro)
            For Each mov As cuentaCobroDevolucion In list
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(col_idMovito.Index).Value = mov.IdMovitoCCobro
                r.Cells(col_idConcepto.Index).Value = mov.IdConcepto
                r.Cells(col_concepto.Index).Value = mov.Concepto
                r.Cells(col_unidadMedida.Index).Value = mov.UnidadMedida
                r.Cells(col_cantidad.Index).Value = mov.Cantidad
                r.Cells(col_valor.Index).Value = mov.Valor
                r.Cells(col_total.Index).Value = mov.Total
                r.Cells(col_cantidadDisponible.Index).Value = mov.CantidadDisponible
                r.Cells(col_valorDisponible.Index).Value = mov.ValorDisponible
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacion() As Boolean
        Try
            If cmbDocumentos.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbDocumentos, "Debe seleccionar el documento")
                Return False
            End If
            ErrorProvider.Clear()

            If lblConsecutivo.Text = String.Empty Then
                ErrorProvider.SetError(lblConsecutivo, "La devolución no tiene consecutivo")
                Return False
            End If
            ErrorProvider.Clear()

            If Not IsNumeric(lblConsecutivo.Text) Then
                ErrorProvider.SetError(lblConsecutivo, "El consecutivo no es válido")
                Return False
            End If
            ErrorProvider.Clear()

            Dim conteo As Integer = 0
            For Each r As DataGridViewRow In dwItems.Rows
                If CBool(r.Cells(col_Insertar.Index).Value) = True Then
                    conteo += 1
                End If
            Next

            If conteo = 0 Then
                ErrorProvider.SetError(dwItems, "No hay ninguna cantidad o valor a devolver")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub frmDevoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarDocumentos()
            txtDocumentoCCobro.Text = _documentoCCobro
            txtConsecutivoCCobro.Text = _consecutivoCCobro
            txtObra.Text = _obra
            txtVendedor.Text = _vendedor
            txtFechaCreacion.Text = _fechaCreacion.ToShortDateString()
            txtProveedor.Text = _proveedor
            txtEncargado.Text = _encargado
            cargarMovitosCCobro()

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
            dwItems.EndEdit()
            cmbDocumentos.Focus()
            If validacion() Then
                Dim mDevolucion As New ClsDevolucion
                Dim idDevolucion As Integer = mDevolucion.Insertar(My.Settings.UsuarioActivo, _idCuentaCobro, cmbDocumentos.SelectedValue,
                                                                   CInt(lblConsecutivo.Text), ClsEnums.Estados.ACTIVO)
                Dim mDocumento As New ClsDocumentosOT
                mDocumento.ActualizarConsecutivo(CInt(lblConsecutivo.Text), cmbDocumentos.SelectedValue)
                Dim mMovitoDevolucion As New ClsMovitoDevolucion
                For Each r As DataGridViewRow In dwItems.Rows
                    If CBool(r.Cells(col_Insertar.Index).Value) = True Then
                        mMovitoDevolucion.Insertar(My.Settings.UsuarioActivo, idDevolucion, r.Cells(col_idMovito.Index).Value,
                                                   r.Cells(col_cantDevolucion.Index).Value, r.Cells(col_valorDevolucion.Index).Value, ClsEnums.Estados.ACTIVO)
                    End If
                Next
                MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnLimpiar_Click(Nothing, Nothing)
                frmDevoluciones_Load(Nothing, Nothing)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        Try
            cmbDocumentos.Focus()
            cmbDocumentos.SelectedItem = Nothing
            lblConsecutivo.Text = Nothing
            For Each r As DataGridViewRow In dwItems.Rows
                r.Cells(col_cantDevolucion.Index).Value = 0.00
                r.Cells(col_valorDevolucion.Index).Value = 0.00
                r.Cells(col_Insertar.Index).Value = False
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbDocumentos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDocumentos.SelectedValueChanged
        Try
            If loadCompleted Then
                If cmbDocumentos.SelectedItem IsNot Nothing Then
                    Dim docto As documentoOT = cmbDocumentos.SelectedItem
                    lblConsecutivo.Text = docto.ConsecutivoProximo
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwItems.EditingControlShowing
        Try
            Dim columnIndex As Integer = dwItems.CurrentCell.ColumnIndex

            If dwItems.Columns(columnIndex) Is col_cantDevolucion Or dwItems.Columns(columnIndex) Is col_valorDevolucion Then
                Dim dText As DataGridViewTextBoxEditingControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
                RemoveHandler dText.KeyPress, AddressOf dText_KeyPress
                AddHandler dText.KeyPress, AddressOf dText_KeyPress
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dText_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Try
            Dim columnIndex As Integer = dwItems.CurrentCell.ColumnIndex

            If dwItems.Columns(columnIndex) Is col_cantDevolucion Or dwItems.Columns(columnIndex) Is col_valorDevolucion Then
                If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar) Or Char.IsPunctuation(e.KeyChar)) Then e.Handled = True
                If Char.IsPunctuation(e.KeyChar) Then
                    If e.KeyChar <> "."c Then e.Handled = True
                End If
                Return
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItems.CellEndEdit
        Try
            If loadCompleted Then
                If e.RowIndex >= 0 Then
                    Dim r As DataGridViewRow = dwItems.Rows(e.RowIndex)
                    If e.ColumnIndex = col_cantDevolucion.Index Then
                        If CDec(r.Cells(col_cantDevolucion.Index).Value) > CDec(r.Cells(col_cantidadDisponible.Index).Value) Then
                            r.Cells(col_cantDevolucion.Index).Value = 0.00
                            Return
                        End If
                        If CDec(r.Cells(col_cantDevolucion.Index).Value) > 0.00 Then
                            r.Cells(col_valorDevolucion.Index).Value = CDec(r.Cells(col_cantDevolucion.Index).Value) * CDec(r.Cells(col_valor.Index).Value)
                            r.Cells(col_Insertar.Index).Value = True
                        Else
                            r.Cells(col_valorDevolucion.Index).Value = 0
                            r.Cells(col_Insertar.Index).Value = False
                        End If
                        'cantidadesyValoresDevolver(True)
                    ElseIf e.ColumnIndex = col_valorDevolucion.Index Then
                        If CDec(r.Cells(col_valorDevolucion.Index).Value) > CDec(r.Cells(col_valorDisponible.Index).Value) Then
                            r.Cells(col_valorDevolucion.Index).Value = 0.00
                            Return
                        End If
                        If CDec(r.Cells(col_valorDevolucion.Index).Value) > 0.00 Then
                            r.Cells(col_cantDevolucion.Index).Value = CDec(r.Cells(col_valorDevolucion.Index).Value) / CDec(r.Cells(col_valor.Index).Value)
                            r.Cells(col_Insertar.Index).Value = True
                        Else
                            r.Cells(col_cantDevolucion.Index).Value = 0
                            r.Cells(col_Insertar.Index).Value = False
                        End If
                        'cantidadesyValoresDevolver(False)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class