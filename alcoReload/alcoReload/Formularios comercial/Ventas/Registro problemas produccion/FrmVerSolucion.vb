Imports ReglasNegocio

Public Class FrmVerSolucion
#Region "Variables"
    Private _idEncabezado As Integer
    Private _consecutivo As Integer
    Private _estado As String
    Private _fechaRegistro As DateTime
    Private _vendedor As String
    Private _idSeccion As Integer
    Private _seccion As String
    Private _nit As String
    Private _cliente As String
    Private _codigoObra As String
    Private _obra As String
#End Region
#Region "Propiedades"
    Public Property IdEncabezado() As Integer
        Get
            Return _idEncabezado
        End Get
        Set(ByVal value As Integer)
            _idEncabezado = value
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
    Public Property Estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property
    Public Property FechaRegistro() As DateTime
        Get
            Return _fechaRegistro
        End Get
        Set(ByVal value As DateTime)
            _fechaRegistro = value
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
    Public Property IdSeccion() As Integer
        Get
            Return _idSeccion
        End Get
        Set(ByVal value As Integer)
            _idSeccion = value
        End Set
    End Property
    Public Property Seccion() As String
        Get
            Return _seccion
        End Get
        Set(ByVal value As String)
            _seccion = value
        End Set
    End Property
    Public Property Nit() As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property
    Public Property CodigoObra() As String
        Get
            Return _codigoObra
        End Get
        Set(ByVal value As String)
            _codigoObra = value
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
#End Region
#Region "Procedimientos"
    Private Sub cargarInformacion()
        Try
            txtConsecutivo.Text = _consecutivo
            txtEstado.Text = _estado
            txtFecha.Text = _fechaRegistro.ToShortDateString()
            txtVendedor.Text = _vendedor
            txtSeccion.Text = _seccion
            txtNit.Text = _nit
            txtCliente.Text = _cliente
            txtCodigoObra.Text = _codigoObra
            txtObra.Text = _obra
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarMovimientos()
        Try
            Dim mEncabezado As New ClsEncabezadoProblemasP
            txtDescripcionProblema.Text = mEncabezado.TraerxId(_idEncabezado).DescripcionProblema

            Dim mCausa As New ClsMovitoCausasPp
            Dim causa As movitoCausaPp = mCausa.TraerxIdEncabezado(_idEncabezado)
            If causa.Descripcion IsNot Nothing And causa.Descripcion <> String.Empty Then
                txtAnalisisCausa.Text = causa.Descripcion
            End If

            Dim mAcInmediata As New ClsMovitoAccionesImnediatasPp
            Dim acInmediata As movitoAccionInmediataPp = mAcInmediata.TraerxIdEncabezado(_idEncabezado)
            If acInmediata.Descripcion IsNot Nothing And acInmediata.Descripcion <> String.Empty Then
                txtAccionInmediata.Text = acInmediata.Descripcion
            End If

            Dim mAcDefinida As New ClsMovitoAccionesDefinidasPp
            Dim acDefinida As movitoAccionDefinidaPp = mAcDefinida.TraerxIdEncabezado(_idEncabezado)
            If acDefinida.Descripcion IsNot Nothing And acDefinida.Descripcion <> String.Empty Then
                txtAccionDefinida.Text = acDefinida.Descripcion
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmVerSolucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarInformacion()
            cargarMovimientos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class