Imports Datos

Public Class ClsEncabeOrdenProd
#Region "vars"
    Dim morden As New dsAlcoOrdenesProduccionTableAdapters.top001_OrdenDePedidoTableAdapter
#End Region
#Region "props"
    Public Function Insertar(idordenped As Integer, usuario As String, estado As Integer) As Integer
        Try
            Return Convert.ToInt32(morden.sp_top001_insert(idordenped, usuario, estado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(idordenped As Integer, estado As Integer, usuario As String, id As Integer)
        Try
            morden.sp_top001_update(id, idordenped, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
    Public Function TraerOrdenesPedidoAprobadas() As DataTable
        Try
            Dim ta As New dsAlcoOrdenesProduccionTableAdapters.sp_top001_selectCombinadoByestadoGenerarTableAdapter
            Return ta.GetData().Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerListadeCorte(idordenprod As Integer) As DataTable
        Try
            Dim ta As New dsAlcoOrdenesProduccionTableAdapters.sp_top001_selectlistacorteTableAdapter
            Return ta.GetData(idordenprod).Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerFamiliasporIdOp(idop As Integer) As List(Of FamiliaModelo)
        TraerFamiliasporIdOp = New List(Of FamiliaModelo)
        Try
            Dim ta As New dsAlcoOrdenesProduccionTableAdapters.sp_top001_selectFamiliasporIdOpTableAdapter
            Dim t_fam As dsAlcoOrdenesProduccion.sp_top001_selectFamiliasporIdOpDataTable = ta.GetData(idop)
            t_fam.ToList().ForEach(Sub(f As dsAlcoOrdenesProduccion.sp_top001_selectFamiliasporIdOpRow)
                                       TraerFamiliasporIdOp.Add(New FamiliaModelo(f.Id, "", Now, f.Familia, "", "",
                                                                                  "", Now, 1, ""))
                                   End Sub)

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
Public Class paraPlanos
#Region "vars"
    Private _id As Integer
    Private _idoped As Integer
    Private _nit As String
    Private _cliente As String
    Private _telefonoCliente As String
    Private _direccionCliente As String
    Private _mailCliente As String
    Private _contactoCliente As String
    Private _codigoObra As String
    Private _obra As String
    Private _contactoObra As String
    Private _telefonoObra As String
    Private _direccionObra As String
    Private _ciudadObra As String
    Private _mailObra As String
    Private _fechaRecibido As DateTime
    Private _fechaTomaMedidas As DateTime
    Private _idTiempoEntrega As Integer
    Private _diasEntrega As Integer
    Private _fechaEntrega As DateTime
    Private _semanaEntrega As Integer
    Private _puntos As Decimal
    Private _idVendedor As String
    Private _zona As String
    Private _metros As Decimal
    Private _destinoMateriales As String
    Private _idTerceroProduccion As Integer
    Private _terceroProduccion As String
    Private _numeroDevoluciones As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _fechaModi As DateTime
    Private _usuarioModi As String
    Private _fechaAprobacion As DateTime
    Private _usuarioAprobacion As String
    Private _fechaAnulacion As DateTime
    Private _usuarioAnulacion As String
    Private _idEstado As Integer
    Private _estado As String
    Private _indDiasHabiles As Boolean
    Private _facturable As Boolean
    Private _aprobacionCliente As Boolean
#End Region
#Region "props"
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property IdOPed As Integer
        Get
            Return _idoped
        End Get
        Set(ByVal value As Integer)
            _idoped = value
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
    Public Property TelefonoCliente() As String
        Get
            Return _telefonoCliente
        End Get
        Set(ByVal value As String)
            _telefonoCliente = value
        End Set
    End Property
    Public Property DireccionCliente() As String
        Get
            Return _direccionCliente
        End Get
        Set(ByVal value As String)
            _direccionCliente = value
        End Set
    End Property
    Public Property MailCliente() As String
        Get
            Return _mailCliente
        End Get
        Set(ByVal value As String)
            _mailCliente = value
        End Set
    End Property
    Public Property ContactoCliente() As String
        Get
            Return _contactoCliente
        End Get
        Set(ByVal value As String)
            _contactoCliente = value
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
    Public Property ContactoObra() As String
        Get
            Return _contactoObra
        End Get
        Set(ByVal value As String)
            _contactoObra = value
        End Set
    End Property
    Public Property TelefonoObra() As String
        Get
            Return _telefonoObra
        End Get
        Set(ByVal value As String)
            _telefonoObra = value
        End Set
    End Property
    Public Property DireccionObra() As String
        Get
            Return _direccionObra
        End Get
        Set(ByVal value As String)
            _direccionObra = value
        End Set
    End Property
    Public Property CiudadObra() As String
        Get
            Return _ciudadObra
        End Get
        Set(ByVal value As String)
            _ciudadObra = value
        End Set
    End Property
    Public Property MailObra() As String
        Get
            Return _mailObra
        End Get
        Set(ByVal value As String)
            _mailObra = value
        End Set
    End Property
    Public Property FechaRecibido() As DateTime
        Get
            Return _fechaRecibido
        End Get
        Set(ByVal value As DateTime)
            _fechaRecibido = value
        End Set
    End Property
    Public Property FechaTomaMedidas() As DateTime
        Get
            Return _fechaTomaMedidas
        End Get
        Set(ByVal value As DateTime)
            _fechaTomaMedidas = value
        End Set
    End Property
    Public Property IdTiempoEntrega() As Integer
        Get
            Return _idTiempoEntrega
        End Get
        Set(ByVal value As Integer)
            _idTiempoEntrega = value
        End Set
    End Property
    Public Property DiasEntrega() As Integer
        Get
            Return _diasEntrega
        End Get
        Set(ByVal value As Integer)
            _diasEntrega = value
        End Set
    End Property
    Public Property FechaEntrega() As DateTime
        Get
            Return _fechaEntrega
        End Get
        Set(ByVal value As DateTime)
            _fechaEntrega = value
        End Set
    End Property
    Public Property SemanaEntrega() As Integer
        Get
            Return _semanaEntrega
        End Get
        Set(ByVal value As Integer)
            _semanaEntrega = value
        End Set
    End Property
    Public Property Puntos() As Decimal
        Get
            Return _puntos
        End Get
        Set(ByVal value As Decimal)
            _puntos = value
        End Set
    End Property
    Public Property IdVendedor() As String
        Get
            Return _idVendedor
        End Get
        Set(ByVal value As String)
            _idVendedor = value
        End Set
    End Property
    Public Property Zona() As String
        Get
            Return _zona
        End Get
        Set(ByVal value As String)
            _zona = value
        End Set
    End Property
    Public Property Metros() As Decimal
        Get
            Return _metros
        End Get
        Set(ByVal value As Decimal)
            _metros = value
        End Set
    End Property
    Public Property DestinoMateriales() As String
        Get
            Return _destinoMateriales
        End Get
        Set(ByVal value As String)
            _destinoMateriales = value
        End Set
    End Property
    Public Property IdTerceroProduccion() As Integer
        Get
            Return _idTerceroProduccion
        End Get
        Set(ByVal value As Integer)
            _idTerceroProduccion = value
        End Set
    End Property
    Public Property TerceroProduccion() As String
        Get
            Return _terceroProduccion
        End Get
        Set(ByVal value As String)
            _terceroProduccion = value
        End Set
    End Property
    Public Property NumeroDevoluciones() As Integer
        Get
            Return _numeroDevoluciones
        End Get
        Set(ByVal value As Integer)
            _numeroDevoluciones = value
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
    Public Property UsuarioCreacion() As String
        Get
            Return _usuarioCreacion
        End Get
        Set(ByVal value As String)
            _usuarioCreacion = value
        End Set
    End Property
    Public Property FechaModi() As DateTime
        Get
            Return _fechaModi
        End Get
        Set(ByVal value As DateTime)
            _fechaModi = value
        End Set
    End Property
    Public Property UsuarioModi() As String
        Get
            Return _usuarioModi
        End Get
        Set(ByVal value As String)
            _usuarioModi = value
        End Set
    End Property
    Public Property FechaAprobacion() As DateTime
        Get
            Return _fechaAprobacion
        End Get
        Set(ByVal value As DateTime)
            _fechaAprobacion = value
        End Set
    End Property
    Public Property UsuarioAprobacion() As String
        Get
            Return _usuarioAprobacion
        End Get
        Set(ByVal value As String)
            _usuarioAprobacion = value
        End Set
    End Property
    Public Property FechaAnulacion() As DateTime
        Get
            Return _fechaAnulacion
        End Get
        Set(ByVal value As DateTime)
            _fechaAnulacion = value
        End Set
    End Property
    Public Property UsuarioAnulacion() As String
        Get
            Return _usuarioAnulacion
        End Get
        Set(ByVal value As String)
            _usuarioAnulacion = value
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
    Public Property Estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property
    Public Property IndDiasHabiles() As Boolean
        Get
            Return _indDiasHabiles
        End Get
        Set(ByVal value As Boolean)
            _indDiasHabiles = value
        End Set
    End Property
    Public Property Facturable() As Boolean
        Get
            Return _facturable
        End Get
        Set(ByVal value As Boolean)
            _facturable = value
        End Set
    End Property
    Public Property AprobacionCliente() As Boolean
        Get
            Return _aprobacionCliente
        End Get
        Set(ByVal value As Boolean)
            _aprobacionCliente = value
        End Set
    End Property
#End Region
#Region "ctor"
    Public Sub New()
        Try

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, idoped As Integer, Nit As String, Cliente As String, TelefonoCliente As String,
                   DireccionCliente As String, MailCliente As String, ContactoCliente As String, CodigoObra As String, Obra As String,
                   ContactoObra As String, TelefonoObra As String, DireccionObra As String, CiudadObra As String, MailObra As String,
                   FechaRecibido As DateTime, FechaTomaMedidas As DateTime, IdTiempoEntrega As Integer, DiasEntrega As Integer,
                   FechaEntrega As DateTime, SemanaEntrega As Integer, Puntos As Decimal, IdVendedor As String, Zona As String, Metros As Decimal,
                   DestinoMateriales As String, IdTerceroProduccion As Integer, TerceroProduccion As String, NumeroDevoluciones As Integer,
                   FechaCreacion As DateTime, UsuarioCreacion As String, FechaModi As DateTime, UsuarioModi As String, FechaAprobacion As DateTime,
                   UsuarioAprobacion As String, FechaAnulacion As DateTime, UsuarioAnulacion As String, IdEstado As Integer, Estado As String,
                   IndDiasHabiles As Boolean, Facturable As Boolean, AprobacionCliente As Boolean)
        Try
            _id = id
            _idoped = idoped
            _nit = Trim(Nit)
            _cliente = Trim(Cliente)
            _telefonoCliente = Trim(TelefonoCliente)
            _direccionCliente = Trim(DireccionCliente)
            _mailCliente = Trim(MailCliente)
            _contactoCliente = Trim(ContactoCliente)
            _codigoObra = Trim(CodigoObra)
            _obra = Trim(Obra)
            _contactoObra = Trim(ContactoObra)
            _telefonoObra = Trim(TelefonoObra)
            _direccionObra = Trim(DireccionObra)
            _ciudadObra = Trim(CiudadObra)
            _mailObra = Trim(MailObra)
            _fechaRecibido = FechaRecibido
            _fechaTomaMedidas = FechaTomaMedidas
            _idTiempoEntrega = IdTiempoEntrega
            _diasEntrega = DiasEntrega
            _fechaEntrega = FechaEntrega
            _semanaEntrega = SemanaEntrega
            _puntos = Puntos
            _idVendedor = IdVendedor
            _zona = Trim(Zona)
            _metros = Metros
            _destinoMateriales = Trim(DestinoMateriales)
            _idTerceroProduccion = IdTerceroProduccion
            _terceroProduccion = Trim(TerceroProduccion)
            _numeroDevoluciones = NumeroDevoluciones
            _fechaCreacion = FechaCreacion
            _usuarioCreacion = Trim(UsuarioCreacion)
            _fechaModi = FechaModi
            _usuarioModi = Trim(UsuarioModi)
            _fechaAprobacion = FechaAprobacion
            _usuarioAprobacion = Trim(UsuarioAprobacion)
            _fechaAnulacion = FechaAnulacion
            _usuarioAnulacion = Trim(UsuarioAnulacion)
            _idEstado = IdEstado
            _estado = Trim(Estado)
            _indDiasHabiles = IndDiasHabiles
            _facturable = Facturable
            _aprobacionCliente = AprobacionCliente
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class