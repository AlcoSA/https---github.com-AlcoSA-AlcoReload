Imports Datos
Public Class ClsOrdenDePedido
#Region "Variables"
    Private _objOp As New dsAlcoProduccionTableAdapters.tp002_ordenDePedidoTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(IdContrato As Integer, documento As String, NitCliente As String, Cliente As String, TelCliente As String, DirCliente As String, mailcliente As String, contactocliente As String,
                             codObra As String, Obra As String, contactoobra As String, TelObra As String, DirObra As String, CiudadObra As String, mailobra As String,
                             fecha_recibido As DateTime, idtiempoentrega As Integer, FechaEntrega As DateTime, fechaTomaMedidas As DateTime, SemanaEntrega As Integer,
                            Puntos As Integer, idVendedor As String, Zona As String, Metros As Decimal, destinomateriales As String, idterceroPorduccion As Integer, NoDevoluciones As Integer,
                            usuario As String, idEstado As Integer, indDiasHabiles As Boolean, facturable As Boolean) As Integer
        Try
            Return Convert.ToInt32(_objOp.sp_tp002_insert(IdContrato, documento, NitCliente, Cliente, TelCliente, DirCliente, mailcliente, contactocliente,
                          codObra, Obra, contactoobra, TelObra, DirObra, CiudadObra, mailobra, fecha_recibido, fechaTomaMedidas, idtiempoentrega,
                          FechaEntrega, SemanaEntrega, Puntos, idVendedor, Zona, Metros, destinomateriales, idterceroPorduccion,
                          NoDevoluciones, usuario, idEstado, indDiasHabiles, facturable))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(IdContrato As Integer, documento As String, NitCliente As String, Cliente As String, TelCliente As String, DirCliente As String, mailcliente As String, contactocliente As String,
                             codObra As String, Obra As String, contactoobra As String, TelObra As String, DirObra As String, CiudadObra As String, mailobra As String,
                             fecha_recibido As DateTime, idtiempoentrega As Integer, FechaEntrega As DateTime, fecha_TomaMedidas As DateTime, SemanaEntrega As Integer,
                            Puntos As Integer, idVendedor As String, Zona As String, Metros As Decimal, destinomateriales As String, idterceroPorduccion As Integer, NoDevoluciones As Integer,
                            usuario As String, idEstado As Integer, id As Integer, indDiasHabiles As Boolean, facturable As Boolean)
        Try
            _objOp.sp_tp002_update(id, IdContrato, documento, NitCliente, Cliente, TelCliente, DirCliente, mailcliente,
                                   contactocliente, codObra, Obra, contactoobra, TelObra, DirObra, CiudadObra,
                                   mailobra, fecha_recibido, fecha_TomaMedidas, idtiempoentrega,
                                   FechaEntrega, SemanaEntrega, Puntos, idVendedor, Zona, Metros,
                                   destinomateriales, idterceroPorduccion, NoDevoluciones, usuario,
                                   idEstado, indDiasHabiles, facturable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstadoAprobacionCliente(idorden As Integer, estado As Integer)
        Try
            _objOp.sp_tp002_updateEstadoAprobacionCliente(idorden, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub updateParaAprobar(idEstado As Integer, usuario As String, ids As String)
        Try
            _objOp.sp_tp002_updateParaAprobar(idEstado, usuario, ids)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(ByRef Optional tabla As DataTable = Nothing) As List(Of OrdenDePedido)
        Try
            TraerTodos = New List(Of OrdenDePedido)
            Dim ta As New dsAlcoProduccionTableAdapters.sp_tp002_selectAllTableAdapter
            Dim tb As dsAlcoProduccion.sp_tp002_selectAllDataTable = ta.GetData()
            tb.Rows.Cast(Of dsAlcoProduccion.sp_tp002_selectAllRow).ToList.ForEach(
                Sub(d)
                    TraerTodos.Add(New OrdenDePedido(d.Id, d.Id_contrato, d.documento, d.nit, d.cliente, d.telefono_cliente, d.direccion_cliente, d.mail_cliente,
                                                         d.codigo_obra, d.obra, d.telefono_obra, d.direccion_obra, d.mail_obra, d.ciudad_obra, d.fecha_Toma_medidas,
                                                        d.id_tiempo_entrega, d.tiempo_entrega, d.fecha_recibido,
                                                         d.FechaEntrega, d.SemanaEntrega, d.Puntos, d.idVendedor, d.Zona,
                                                         d.Metros, d.Destino_Materiales, d.idTerceroProd, d.TerceroProduccion, d.nroDevoluciones,
                                                         d.FechaCreacion, d.UsuarioCreacion, d.UsuarioAprobacion, d.FechaAprobacion, d.UsuarioAnulacion, d.FechaAnulacion, d.FechaModi,
                                                         d.UsuarioModi, d.Idestado, d.Estado, d.indDiasHabiles, d.facturable, d.Aproba_cliente))
                End Sub)
            tabla = If(tb.Count > 0, tb.CopyToDataTable, New DataTable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdOrden(idorden As Integer) As OrdenDePedido
        Try
            TraerxIdOrden = New OrdenDePedido
            Dim ta As New dsAlcoProduccionTableAdapters.sp_tp002_selectByIdTableAdapter
            Dim tb As dsAlcoProduccion.sp_tp002_selectByIdDataTable = ta.GetData(idorden)
            If tb.Rows.Count > 0 Then
                Dim d As dsAlcoProduccion.sp_tp002_selectByIdRow = DirectCast(tb.Rows(0), dsAlcoProduccion.sp_tp002_selectByIdRow)
                TraerxIdOrden = New OrdenDePedido(d.Id, d.Id_contrato, d.documento, d.nit, d.cliente, d.telefono_cliente, d.direccion_cliente, d.mail_cliente,
                                                         d.codigo_obra, d.obra, d.telefono_obra, d.direccion_obra, d.mail_obra, d.ciudad_obra, d.fecha_Toma_medidas,
                                                        d.id_tiempo_entrega, d.tiempo_entrega, d.fecha_recibido,
                                                         d.FechaEntrega, d.SemanaEntrega, d.Puntos, d.idVendedor, d.Zona,
                                                         d.Metros, d.Destino_Materiales, d.idTerceroProd, d.TerceroProduccion, d.nroDevoluciones,
                                                         d.FechaCreacion, d.UsuarioCreacion, d.UsuarioAprobacion, d.FechaAprobacion, d.UsuarioAnulacion, d.FechaAnulacion, d.FechaModi,
                                                         d.UsuarioModi, d.Idestado, d.Estado, d.indDiasHabiles, d.facturable, d.Aproba_cliente)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerActivos(ByRef Optional tabla As DataTable = Nothing) As List(Of OrdenDePedido)
        Try
            traerActivos = New List(Of OrdenDePedido)
            traerActivos.AddRange(TraerTodos(tabla).Where(Function(a) a.IdEstado = ClsEnums.Estados.RECHAZADO_PRODUCCION))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerparaAprobacion(ByRef Optional tabla As DataTable = Nothing) As List(Of OrdenDePedido)
        Try
            TraerparaAprobacion = New List(Of OrdenDePedido)
            Dim ta As New dsAlcoProduccionTableAdapters.sp_tp002_selectPendientesTableAdapter
            Dim tb As dsAlcoProduccion.sp_tp002_selectPendientesDataTable = ta.GetData()
            tb.Rows.Cast(Of dsAlcoProduccion.sp_tp002_selectPendientesRow).ToList.ForEach(
                Sub(d)
                    TraerTodos.Add(New OrdenDePedido(d.Id, d.Id_contrato, d.documento, d.nit, d.cliente, d.telefono_cliente, d.direccion_cliente, d.mail_cliente,
                                                         d.codigo_obra, d.obra, d.telefono_obra, d.direccion_obra, d.mail_obra, d.ciudad_obra, d.fecha_Toma_medidas,
                                                        d.id_tiempo_entrega, d.tiempo_entrega, d.fecha_recibido,
                                                         d.FechaEntrega, d.SemanaEntrega, d.Puntos, d.idVendedor, d.Zona,
                                                         d.Metros, d.Destino_Materiales, d.idTerceroProd, d.TerceroProduccion, d.nroDevoluciones,
                                                         d.FechaCreacion, d.UsuarioCreacion, d.UsuarioAprobacion, d.FechaAprobacion, d.UsuarioAnulacion, d.FechaAnulacion, d.FechaModi,
                                                         d.UsuarioModi, d.Idestado, d.Estado, d.indDiasHabiles, d.facturable, d.Aproba_cliente))
                End Sub)
            tabla = If(tb.Count > 0, tb.CopyToDataTable, New DataTable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerParaInstalacion(idContrato As Integer) As List(Of OrdenPedidoInstalacion)
        Try
            TraerParaInstalacion = New List(Of OrdenPedidoInstalacion)
            Dim ta As New dsAlcoProduccionTableAdapters.sp_tp002_selectForInstalacionTableAdapter
            Dim tb As dsAlcoProduccion.sp_tp002_selectForInstalacionDataTable = ta.GetData(idContrato)
            For Each d As dsAlcoProduccion.sp_tp002_selectForInstalacionRow In tb
                TraerParaInstalacion.Add(New OrdenPedidoInstalacion(d.idOP, d.fechaInicio, d.fechaEntrega, d.metros, d.instalado, d.disponible, d.tipo))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class OrdenDePedido : Inherits ClsBaseParametros
#Region "vars"
    Protected _idContrato As Integer
    Protected _documento As String
    Protected _nit As String
    Protected _cliente As String
    Protected _telCliente As String
    Protected _dirCliente As String
    Protected _correocliente As String
    Protected _codObra As String
    Protected _obra As String
    Protected _telObra As String
    Protected _dirObra As String
    Protected _correoobra As String
    Protected _ciudadObra As String
    Protected _fechaTomaMedidas As DateTime
    Protected _idplazoentrega As Integer
    Protected _plazoEntrega As Integer
    Protected _fechaRecibo As DateTime
    Protected _fechaEntrega As DateTime
    Protected _semanaEntrega As Integer
    Protected _punto As Decimal
    Protected _idVendedor As String
    Protected _zona As String
    Protected _metros As Decimal
    Protected _ubicacionVentaneria As String
    Protected _idTerceroProduccion As Integer
    Protected _terceroProduccion As String
    Protected _nroDevoluciones As Integer
    Protected _diasHabiles As Boolean
    Protected _facturable As Boolean
    Protected _aprobada_cliente As Integer = 0
#End Region
#Region "Propiedades"
    Public Property IdContrato As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
    Public Property Documento As String
        Get
            Return _documento
        End Get
        Set(value As String)
            _documento = value
        End Set
    End Property
    Public Property Nit As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property
    Public Property Cliente As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property
    Public Property TelCliente As String
        Get
            Return _telCliente
        End Get
        Set(ByVal value As String)
            _telCliente = value
        End Set
    End Property
    Public Property DirCliente As String
        Get
            Return _dirCliente
        End Get
        Set(ByVal value As String)
            _dirCliente = value
        End Set
    End Property
    Public Property Correo_Cliente As String
        Get
            Return _correocliente
        End Get
        Set(value As String)
            _correocliente = value
        End Set
    End Property
    Public Property CodObra As String
        Get
            Return _codObra
        End Get
        Set(ByVal value As String)
            _codObra = value
        End Set
    End Property
    Public Property Obra As String
        Get
            Return _obra
        End Get
        Set(ByVal value As String)
            _obra = value
        End Set
    End Property
    Public Property TelObra As String
        Get
            Return _telObra
        End Get
        Set(ByVal value As String)
            _telObra = value
        End Set
    End Property
    Public Property DirObra As String
        Get
            Return _dirObra
        End Get
        Set(ByVal value As String)
            _dirObra = value
        End Set
    End Property
    Public Property Correo_Obra As String
        Get
            Return _correoobra
        End Get
        Set(value As String)
            _correoobra = value
        End Set
    End Property
    Public Property CiudadObra As String
        Get
            Return _ciudadObra
        End Get
        Set(ByVal value As String)
            _ciudadObra = value
        End Set
    End Property
    Public Property fechaTomaMedidas As DateTime
        Get
            Return _fechaTomaMedidas
        End Get
        Set(ByVal value As DateTime)
            _fechaTomaMedidas = value
        End Set
    End Property
    Public Property IdPlazoEntrega As Integer
        Get
            Return _idplazoentrega
        End Get
        Set(value As Integer)
            _idplazoentrega = value
        End Set
    End Property
    Public Property PlazoEntrega As Integer
        Get
            Return _plazoEntrega
        End Get
        Set(ByVal value As Integer)
            _plazoEntrega = value
        End Set
    End Property
    Public Property fechaRecibo As DateTime
        Get
            Return _fechaRecibo
        End Get
        Set(ByVal value As DateTime)
            _fechaRecibo = value
        End Set
    End Property
    Public Property FechaEntrega As DateTime
        Get
            Return _fechaEntrega
        End Get
        Set(ByVal value As DateTime)
            _fechaEntrega = value
        End Set
    End Property
    Public Property SemanaEnetrega As Integer
        Get
            Return _semanaEntrega
        End Get
        Set(ByVal value As Integer)
            _semanaEntrega = value
        End Set
    End Property
    Public Property Puntos As Decimal
        Get
            Return _punto
        End Get
        Set(ByVal value As Decimal)
            _punto = value
        End Set
    End Property
    Public Property IdVendedor As String
        Get
            Return _idVendedor
        End Get
        Set(ByVal value As String)
            _idVendedor = value
        End Set
    End Property
    Public Property Zona As String
        Get
            Return _zona
        End Get
        Set(ByVal value As String)
            _zona = value
        End Set
    End Property
    Public Property metros As Decimal
        Get
            Return _metros
        End Get
        Set(ByVal value As Decimal)
            _metros = value
        End Set
    End Property
    Public Property UbicacionVentaneria As String
        Get
            Return _ubicacionVentaneria
        End Get
        Set(ByVal value As String)
            _ubicacionVentaneria = value
        End Set
    End Property
    Public Property idTerceroProduccion As Integer
        Get
            Return _idTerceroProduccion
        End Get
        Set(ByVal value As Integer)
            _idTerceroProduccion = value
        End Set
    End Property
    Public Property terceroProduccion As String
        Get
            Return _terceroProduccion
        End Get
        Set(ByVal value As String)
            _terceroProduccion = value
        End Set
    End Property
    Public Property NroDevoluciones As Integer
        Get
            Return _nroDevoluciones
        End Get
        Set(ByVal value As Integer)
            _nroDevoluciones = value
        End Set
    End Property
    Public Property diasHabiles As Boolean
        Get
            Return _diasHabiles
        End Get
        Set(ByVal value As Boolean)
            _diasHabiles = value
        End Set
    End Property
    Public Property Facturable As Boolean
        Get
            Return _facturable
        End Get
        Set(value As Boolean)
            _facturable = value
        End Set
    End Property
    Public Property Aprobada_Cliente As Integer
        Get
            Return _aprobada_cliente
        End Get
        Set(value As Integer)
            _aprobada_cliente = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(Id As Integer, IdContrato As Integer, documento As String, NitCliente As String, Cliente As String,
                TelCliente As String, DirCliente As String, mail_cliente As String, codObra As String,
                Obra As String, TelObra As String, DirObra As String, mail_obra As String, CiudadObra As String,
                fechaTomaMedias As DateTime, idplazoentrega As Integer, PlazoEntrega As Integer, fechaRecibo As DateTime,
                FechaEntrega As DateTime, SemanaEnterga As Integer, Puntos As Decimal, idVendedor As String,
                Zona As String, Metros As Decimal, UbicacionVentaneria As String,
                idterceroPorduccion As Integer, TercedorProduccion As String, NoDevoluciones As Integer,
                FechaCreacion As DateTime, usuariocrea As String, usarioaprobacion As String,
                FechaAprobacion As DateTime, usuaioAnulacion As String, FechaAnulacion As DateTime, FechaMod As DateTime,
                UsuarioModi As String, IdEstado As Integer, Estado As String, diasHabiles As Boolean, facturable As Boolean, aprobada_cliente As Integer)
        Try
            _id = Id
            _usuariocreacion = Trim(usuariocrea)
            _fechacreacion = FechaCreacion
            _usuariomodificacion = Trim(UsuarioModificacion)
            _fechamodificacion = FechaModificacion
            _usuarioAprobacion = Trim(usuarioAprobacion)
            _fechaAprobacion = FechaAprobacion
            _usuarioAnulacion = Trim(usuarioAnulacion)
            _fechaAnulacion = FechaAnulacion
            _idestado = IdEstado
            _estado = Trim(Estado)
            _idContrato = IdContrato
            _documento = documento
            _nit = Trim(NitCliente)
            _telCliente = Trim(TelCliente)
            _dirCliente = Trim(DirCliente)
            _correocliente = Trim(mail_cliente)
            _codObra = Trim(codObra)
            _obra = Trim(Obra)
            _telObra = Trim(TelObra)
            _dirObra = Trim(DirObra)
            _correoobra = Trim(mail_obra)
            _ciudadObra = Trim(CiudadObra)
            _fechaTomaMedidas = fechaTomaMedias
            _idplazoentrega = idplazoentrega
            _plazoEntrega = PlazoEntrega
            _fechaRecibo = fechaRecibo
            _fechaEntrega = FechaEntrega
            _semanaEntrega = SemanaEnterga
            _punto = Puntos
            _idVendedor = Trim(idVendedor)
            _zona = Trim(Zona)
            _metros = Metros
            _ubicacionVentaneria = Trim(UbicacionVentaneria)
            _idTerceroProduccion = idterceroPorduccion
            _terceroProduccion = Trim(TercedorProduccion)
            _diasHabiles = diasHabiles
            _facturable = facturable
            _aprobada_cliente = aprobada_cliente
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class OrdenPedidoInstalacion
#Region "Variables"
    Private _idOP As Integer
    Private _fechaInicio As DateTime
    Private _fechaEntrega As DateTime
    Private _metros As Decimal
    Private _instalado As Decimal
    Private _disponible As Decimal
    Private _tipo As String
#End Region
#Region "Propiedades"
    Public Property IdOrdenPedido() As Integer
        Get
            Return _idOP
        End Get
        Set(ByVal value As Integer)
            _idOP = value
        End Set
    End Property
    Public Property FechaInicio() As DateTime
        Get
            Return _fechaInicio
        End Get
        Set(ByVal value As DateTime)
            _fechaInicio = value
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
    Public Property Metros() As Decimal
        Get
            Return _metros
        End Get
        Set(ByVal value As Decimal)
            _metros = value
        End Set
    End Property
    Public Property Instalado() As Decimal
        Get
            Return _instalado
        End Get
        Set(ByVal value As Decimal)
            _instalado = value
        End Set
    End Property
    Public Property Disponible() As Decimal
        Get
            Return _disponible
        End Get
        Set(ByVal value As Decimal)
            _disponible = value
        End Set
    End Property
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Public Sub New()
        Try

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(idOP As Integer, fechaInicio As DateTime, fechaEntrega As DateTime, metros As Decimal,
                   instalado As Decimal, disponible As Decimal, tipo As String)
        Try
            _idOP = idOP
            _fechaInicio = fechaInicio
            _fechaEntrega = fechaEntrega
            _metros = metros
            _instalado = instalado
            _disponible = disponible
            _tipo = tipo
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class

