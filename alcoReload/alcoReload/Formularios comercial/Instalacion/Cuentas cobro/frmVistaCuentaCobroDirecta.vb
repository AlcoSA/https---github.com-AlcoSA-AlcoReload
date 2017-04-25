Imports ReglasNegocio

Public Class frmVistaCuentaCobroDirecta
#Region "Variables"
    Private _idCuentaCobro As Integer
    Private _idDocumento As Integer
    Private _documento As String
    Private _consecutivo As Integer
    Private _obra As String
    Private _vendedor As String
    Private _proveedor As String
    Private _encargado As String
    Private _fechaCreacion As DateTime
    Private _idEstado As Integer
    Private _observaciones As String
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
    Public Property IdDocumento() As Integer
        Get
            Return _idDocumento
        End Get
        Set(ByVal value As Integer)
            _idDocumento = value
        End Set
    End Property
    Public Property Documento() As String
        Get
            Return _documento
        End Get
        Set(ByVal value As String)
            _documento = value
        End Set
    End Property
    Public Property Consecutivo() As Integer
        Get
            Return _consecutivo
        End Get
        Set(ByVal value As Integer)
            _consecutivo = value
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
    Public Property FechaCreacion() As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _fechaCreacion = value
        End Set
    End Property
    Public Property IdEstado() As Integer
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Integer)
            _idEstado = value
        End Set
    End Property
    Public Property Observaciones() As String
        Get
            Return _observaciones
        End Get
        Set(ByVal value As String)
            _observaciones = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarEncabezado()
        Try
            lblDocumento.Text = _documento
            lblConsecutivo.Text = _consecutivo
            txtObra.Text = _obra
            txtVendedor.Text = _vendedor
            txtFechaCreacion.Text = _fechaCreacion.ToShortDateString()
            txtProveedor.Text = _proveedor
            txtEncargado.Text = _encargado
            txtObservaciones.Text = _observaciones
            cargarMovimiento()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarMovimiento()
        Try
            Dim mMovimientoCuenta As New ClsMovitoCuentaCobro
            Dim list As List(Of movitoCuentaCobro) = mMovimientoCuenta.TraerxCuentaCobroDirecta(_idCuentaCobro)
            For Each mov As movitoCuentaCobro In list
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(item_idMovimiento.Index).Value = mov.Id
                r.Cells(item_idConcepto.Index).Value = mov.IdConceptoEspecial
                r.Cells(item_concepto.Index).Value = mov.ConceptoEspecial
                r.Cells(item_descripcion.Index).Value = mov.DescripcionEspecial
                r.Cells(item_cantidad.Index).Value = mov.Cantidad
                r.Cells(item_undMedida.Index).Value = mov.UnidadMedida
                r.Cells(item_precioUnitario.Index).Value = mov.Precio
                r.Cells(item_precioCliente.Index).Value = mov.PrecioCliente
                r.Cells(item_subtotal.Index).Value = mov.Cantidad * mov.Precio
                r.Cells(item_porcRetenido.Index).Value = mov.PorcRetenido
                r.Cells(item_facturable.Index).Value = mov.Facturable
                r.Cells(item_idMotivo.Index).Value = mov.IdMotivo
                r.Cells(item_motivo.Index).Value = mov.Motivo
                r.Cells(item_idEstado.Index).Value = mov.IdEstado
                If mov.IdEstado = ClsEnums.Estados.ACTIVO Then
                    r.Cells(item_estado.Index).Value = ImageList.Images(1)
                ElseIf mov.IdEstado = ClsEnums.Estados.ANULADO Then
                    r.Cells(item_estado.Index).Value = ImageList.Images(0)
                End If
            Next
            cargarTotales()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTotales()
        Try
            Dim subtotal As Decimal = 0
            Dim retenido As Decimal = 0
            For Each r As DataGridViewRow In dwItems.Rows
                subtotal += CDec(r.Cells(item_subtotal.Index).Value)
                retenido += CDec(r.Cells(item_subtotal.Index).Value) * (CDec(r.Cells(item_porcRetenido.Index).Value) / 100)
            Next
            lblSubtotal.Text = FormatCurrency(subtotal, 0)
            lblRetenido.Text = FormatCurrency(retenido, 0)
            lblTotal.Text = FormatCurrency(subtotal - retenido, 0)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmVistaCuentaCobroDirecta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarEncabezado()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAnularCuenta_Click(sender As Object, e As EventArgs) Handles btnAnularCuenta.Click
        Try
            If _idEstado = ClsEnums.Estados.ANULADO Then
                MessageBox.Show("La cuenta de cobro ya ha sido anulada", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If (MessageBox.Show("¿Está seguro de anular la cuenta de cobro?", "", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information)) = DialogResult.Yes Then
                    Dim mCuentaCobro As New ClsCuentaCobro
                    Dim mMovitoCuentaCobro As New ClsMovitoCuentaCobro
                    If mCuentaCobro.TieneMovimientos(_idCuentaCobro) Then
                        MessageBox.Show("La cuenta de cobro tiene movimientos activos, no se puede anular")
                        Return
                    End If
                    mCuentaCobro.ActualizarEstado(_idCuentaCobro, ClsEnums.Estados.ANULADO, My.Settings.UsuarioActivo)
                    mMovitoCuentaCobro.ActualizarEstado(_idCuentaCobro, ClsEnums.Estados.ANULADO, My.Settings.UsuarioActivo)
                    Me.DialogResult = DialogResult.OK
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class