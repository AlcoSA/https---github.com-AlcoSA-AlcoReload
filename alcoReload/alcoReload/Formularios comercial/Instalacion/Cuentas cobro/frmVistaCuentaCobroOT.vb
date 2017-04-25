Imports DatagridTreeView
Imports ReglasNegocio

Public Class frmVistaCuentaCobro
#Region "Variables"
    Private _idContrato As Integer
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
    Public Property IdContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
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
    Private Sub cargarInformacion()
        Try
            lblDocumento.Text = _documento
            lblConsecutivo.Text = _consecutivo
            txtObra.Text = _obra
            txtVendedor.Text = _vendedor
            txtFechaCreacion.Text = _fechaCreacion.ToShortDateString()
            txtProveedor.Text = _proveedor
            txtEncargado.Text = _encargado
            txtObservaciones.Text = _observaciones
            cargarGrid()

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarGrid()
        Try
            Dim mMovitoOrdenTrabajo As New ClsMovitoOrdenTrabajo
            Dim mMovitoCuentaCobro As New ClsMovitoCuentaCobro
            Dim listConceptos As List(Of conceptosOT) = mMovitoOrdenTrabajo.TraerConceptosxCuentaCobro(_idCuentaCobro)
            For Each con As conceptosOT In listConceptos
                Dim ndpd As DataGridViewTreeNode = dwCuentaCobro.Nodes.Add()
                ndpd.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
                ndpd.Cells(cc_id.Index).Value = Nothing
                ndpd.Cells(cc_idConcepto.Index).Value = con.IdConcepto
                ndpd.Cells(cc_concepto.Index).Value = con.Concepto
                ndpd.Cells(cc_undMedida.Index).Value = con.UnidadMedida
                ndpd.Cells(cc_precioUnitario.Index).Value = con.PrecioUnitario
                ndpd.Cells(cc_porcRetenido.Index).Value = con.PorcRetenido
                Dim listMovCCobro As List(Of movitoCuentaCobro) = mMovitoCuentaCobro.TraerxCuentaCobroOT(_idCuentaCobro).Where(Function(a)
                                                                                                                                   Return a.IdConcepto = con.IdConcepto
                                                                                                                               End Function).ToList
                Dim subtotal As Decimal = 0
                For Each item As movitoCuentaCobro In listMovCCobro
                    Dim nd As DataGridViewTreeNode = ndpd.Nodes.Add()
                    nd.Cells(cc_id.Index).Value = item.Id
                    nd.Cells(cc_idConcepto.Index).Value = item.IdConcepto
                    nd.Cells(cc_concepto.Index).Value = item.Concepto
                    nd.Cells(cc_descripcion.Index).Value = item.Descripcion
                    nd.Cells(cc_undMedida.Index).Value = item.UnidadMedida
                    nd.Cells(cc_cantidad.Index).Value = item.Cantidad
                    nd.Cells(cc_precioUnitario.Index).Value = item.Precio
                    nd.Cells(cc_subtotal.Index).Value = item.Cantidad * item.Precio
                    subtotal += CDec(nd.Cells(cc_subtotal.Index).Value)
                    nd.Cells(cc_porcRetenido.Index).Value = item.PorcRetenido
                    nd.Cells(cc_facturable.Index).Value = item.Facturable
                Next
                ndpd.Cells(cc_subtotal.Index).Value = subtotal
            Next
            cargarTotales()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarTotales()
        Try
            Dim subtotal As Decimal = 0
            Dim porcRetenido As Decimal = 0
            For Each nodo As DataGridViewTreeNode In dwCuentaCobro.Nodes
                subtotal += CDec(nodo.Cells(cc_subtotal.Index).Value)
                porcRetenido += (CDec(nodo.Cells(cc_subtotal.Index).Value) * (CDec(nodo.Cells(cc_porcRetenido.Index).Value) / 100))
            Next
            lblSubtotal.Text = FormatCurrency(subtotal, 0)
            lblRetenido.Text = FormatCurrency(porcRetenido, 0)
            lblTotal.Text = FormatCurrency(subtotal - porcRetenido, 0)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub frmVistaCuentaCobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
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
                    Dim list As List(Of movitoCuentaCobro) = mMovitoCuentaCobro.TraerxCuentaCobroOT(_idCuentaCobro)
                    For Each movito As movitoCuentaCobro In list
                        If Not mMovitoCuentaCobro.MovitosActivos(movito.IdMovitoOT) Then
                            Dim mMovitoOrdenTrabajo As New ClsMovitoOrdenTrabajo
                            mMovitoOrdenTrabajo.ActualizarEstadoById(movito.IdMovitoOT, ClsEnums.Estados.ACTIVO)
                        End If
                    Next
                    Me.DialogResult = DialogResult.OK
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class