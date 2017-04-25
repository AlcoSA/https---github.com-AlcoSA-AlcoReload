Imports ReglasNegocio

Public Class frmVistaDevoluciones
#Region "Variables"
    Private _idDevolucion As Integer
    Private _idDocumento As Integer
    Private _documento As String
    Private _consecutivo As Integer
    Private _obra As String
    Private _vendedor As String
    Private _fechaCreacion As DateTime
    Private _proveedor As String
    Private _encargado As String
    Private _idEstado As Integer
#End Region
#Region "Propiedades"
    Public Property IdDevolucion() As Integer
        Get
            Return _idDevolucion
        End Get
        Set(ByVal value As Integer)
            _idDevolucion = value
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
    Public Property IdEstado() As Integer
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Integer)
            _idEstado = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarInformacion()
        Try
            Dim mMovitoDevolucion As New ClsMovitoDevolucion
            Dim list As List(Of movitoDevolucion) = mMovitoDevolucion.TraerxIdDevolucion(_idDevolucion)
            Dim cantidadDevuelta As Decimal = 0
            Dim valorDevuelto As Decimal = 0
            For Each mov As movitoDevolucion In list
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(col_id.Index).Value = mov.Id
                r.Cells(col_concepto.Index).Value = mov.Concepto
                r.Cells(col_descripcion.Index).Value = mov.DescripcionConcepto
                r.Cells(col_precio.Index).Value = mov.Precio
                r.Cells(col_retenido.Index).Value = mov.Retenido
                r.Cells(col_undMedida.Index).Value = mov.UnidadMedida
                r.Cells(col_cantidadDevuelta.Index).Value = mov.CantidadDevuelta
                r.Cells(col_valorDevuelto.Index).Value = mov.ValorDevuelto
                cantidadDevuelta += mov.CantidadDevuelta
                valorDevuelto += mov.ValorDevuelto
            Next
            lblCantidadDevuelta.Text = cantidadDevuelta
            lblValorDevuelto.Text = FormatCurrency(valorDevuelto, 0)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmVistaDevoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblDocumento.Text = _documento
            lblConsecutivo.Text = _consecutivo
            txtObra.Text = _obra
            txtVendedor.Text = _vendedor
            txtFechaCreacion.Text = _fechaCreacion.ToShortDateString()
            txtProveedor.Text = _proveedor
            txtEncargado.Text = _encargado
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAnularDevolucion_Click(sender As Object, e As EventArgs) Handles btnAnularDevolucion.Click
        Try
            If _idEstado = ClsEnums.Estados.ANULADO Then
                MessageBox.Show("La devolución ya ha sido anulada", "", MessageBoxButtons.OK)
            Else
                If MessageBox.Show("¿Está seguro de anular la devolución seleccionada?", "", MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Information) = DialogResult.Yes Then
                    Dim mDevolucion As New ClsDevolucion
                    Dim mMovitoDevolucion As New ClsMovitoDevolucion
                    mDevolucion.ActualizarEstado(_idDevolucion, ClsEnums.Estados.ANULADO, My.Settings.UsuarioActivo)
                    mMovitoDevolucion.ActualizarEstado(_idDevolucion, ClsEnums.Estados.ACTIVO, My.Settings.UsuarioActivo)
                End If

                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class