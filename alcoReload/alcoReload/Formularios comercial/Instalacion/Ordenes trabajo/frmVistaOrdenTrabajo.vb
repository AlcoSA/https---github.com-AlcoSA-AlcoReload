Imports ReglasNegocio

Public Class frmVistaOrdenTrabajo
#Region "Variables"
    Private _idOrdenTrabajo As Integer
    Private _idDocumento As Integer
    Private _documento As String
    Private _consecutivo As Integer
    Private _obra As String
    Private _vendedor As String
    Private _proveedor As String
    Private _fechaCreacion As String
    Private _notas As String
#End Region
#Region "Propiedades"
    Public Property IdOrdenTrabajo() As Integer
        Get
            Return _idOrdenTrabajo
        End Get
        Set(ByVal value As Integer)
            _idOrdenTrabajo = value
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
    Public Property FechaCreacion() As String
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal value As String)
            _fechaCreacion = value
        End Set
    End Property
    Public Property Notas() As String
        Get
            Return _notas
        End Get
        Set(ByVal value As String)
            _notas = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarInformacion()
        Try
            lblDocumento.Text = _documento
            lblConsecutivo.Text = _consecutivo
            txtObra.Text = _obra
            txtVendedor.Text = _vendedor
            txtFechaCreacion.Text = _fechaCreacion
            txtProveedor.Text = _proveedor
            txtNotas.Text = _notas

            Dim mMovitoOT As New ClsMovitoOrdenTrabajo
            Dim list As List(Of movitoOrdenTrabajo) = mMovitoOT.TraerxIdOrdenOT(_idOrdenTrabajo)
            For Each mov As movitoOrdenTrabajo In list
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(item_concepto.Index).Value = mov.Concepto
                r.Cells(item_cantidadOrden.Index).Value = mov.CantidadTotal
                r.Cells(item_cantidadOrigen.Index).Value = mov.CantidadOriginal
                r.Cells(item_unidadMedida.Index).Value = mov.UnidadMedida
                r.Cells(item_precioUnitario.Index).Value = mov.Precio
                r.Cells(item_subtotal.Index).Value = mov.CantidadTotal * mov.Precio
                r.Cells(item_porcRetenido.Index).Value = mov.PorcentajeRetenido
                r.Cells(item_facturable.Index).Value = mov.Facturable
                r.Cells(item_motivo.Index).Value = mov.Motivo
                r.Cells(item_idEstado.Index).Value = mov.IdEstado
                If mov.IdEstado = ClsEnums.Estados.ACTIVO Then
                    r.Cells(item_estado.Index).Value = ImageList.Images(2)
                ElseIf mov.IdEstado = ClsEnums.Estados.ANULADO Then
                    r.Cells(item_estado.Index).Value = ImageList.Images(0)
                ElseIf mov.IdEstado = ClsEnums.Estados.GENERADO Then
                    r.Cells(item_estado.Index).Value = ImageList.Images(1)
                End If
                r.Cells(item_notas.Index).Value = mov.Notas
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
    Private Sub frmVistaOrdenTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnAnularOrden_Click(sender As Object, e As EventArgs) Handles btnAnularOrden.Click
        Try
            If MessageBox.Show("¿Está seguro de anular toda la orden de trabajo?", "", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim mOrdenTrabajo As New ClsOrdenTrabajo
                Dim mMovitoOrdenTrabajo As New ClsMovitoOrdenTrabajo
                mOrdenTrabajo.ActualizarEstado(_idOrdenTrabajo, ClsEnums.Estados.ANULADO)
                mOrdenTrabajo.ActualizarEstado(_idOrdenTrabajo, ClsEnums.Estados.ANULADO)
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class