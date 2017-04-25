Imports Datos

Public Class ClsMovitoOrdenTrabajo
#Region "Variables"
    Private taMovitoOrdenTrabajo As New dsAlcoComercial2TableAdapters.tc098_movitoOrdenTrabajoTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(Usuario As String, idConcepto As Integer, descripcionConcepto As String, precio As Decimal,
                             cantidadOrden As Decimal, cantidadOriginal As Decimal, porcentRetenido As Decimal,
                             idUnidadMedida As String, notas As String, motivo As String, facturable As Boolean,
                             idEstado As Integer, idOrdenTrabajo As Integer) As Integer
        Try
            Return Convert.ToInt32(taMovitoOrdenTrabajo.sp_tc098_insert(Usuario, idConcepto, descripcionConcepto, precio,
                                                                        cantidadOrden, cantidadOriginal, porcentRetenido,
                                                                        idUnidadMedida, notas, motivo, facturable, idEstado,
                                                                        idOrdenTrabajo))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub ActualizarEstadoById(id As Integer, idEstado As Integer)
        Try
            taMovitoOrdenTrabajo.sp_tc098_updateEstadoById(idEstado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstadoByOrdenTrabajo(idOrdenTrabajo As Integer, idEstado As Integer)
        Try
            taMovitoOrdenTrabajo.sp_tc098_updateEstadoByIdOT(idOrdenTrabajo, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdOrdenOT(idOrdenTrabajo As Integer) As List(Of movitoOrdenTrabajo)
        Try
            TraerxIdOrdenOT = New List(Of movitoOrdenTrabajo)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc098_selectByIdOTTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc098_selectByIdOTDataTable = taAll.GetData(idOrdenTrabajo)
            For Each mov As dsAlcoComercial2.sp_tc098_selectByIdOTRow In txAll.Rows
                TraerxIdOrdenOT.Add(New movitoOrdenTrabajo(mov.id, mov.fechaCreacion, mov.usuarioCreacion, mov.idOrdenTrabajo,
                                                           mov.idConcepto, mov.concepto, mov.unidadMedida, mov.precio, mov.cantidadOrden,
                                                           mov.cantidadOriginal, mov.porcentajeRetenido, mov.notas, mov.motivo,
                                                           mov.facturable, mov.usuarioModi, mov.fechaModificacion, mov.idEstado, mov.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdConcepto(idContrato As Integer, idProveedor As Integer, idConcepto As Integer) As List(Of movitoOrdenTrabajo)
        Try
            TraerxIdConcepto = New List(Of movitoOrdenTrabajo)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc098_selectByConceptoTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc098_selectByConceptoDataTable = taAll.GetData(idContrato, idProveedor, idConcepto)
            For Each mov As dsAlcoComercial2.sp_tc098_selectByConceptoRow In txAll
                TraerxIdConcepto.Add(New movitoOrdenTrabajo(mov.id, mov.idOrdenTrabajo, mov.idConcepto, mov.concepto, mov.descripcion,
                                                            mov.unidadMedida, mov.precioUnitario, mov.cantidadTotal, mov.cantidadDisponible,
                                                            mov.porcentRetenido, mov.idTipoObra, mov.tipoObra, mov.notas, mov.facturable))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerConceptos(idContrato As Integer, idProveedor As Integer) As List(Of conceptosOT)
        Try
            TraerConceptos = New List(Of conceptosOT)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc098_selectConceptosTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc098_selectConceptosDataTable = taAll.GetData(idContrato, idProveedor)
            For Each con As dsAlcoComercial2.sp_tc098_selectConceptosRow In txAll
                TraerConceptos.Add(New conceptosOT(con.idConcepto, con.concepto, con.unidadMedida, con.precioUnitario,
                                                   con.idTipoObra, con.tipoObra, con.porcRetenido))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerConceptosxCuentaCobro(idCuentaCobro As Integer) As List(Of conceptosOT)
        Try
            TraerConceptosxCuentaCobro = New List(Of conceptosOT)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc098_selectConceptosByCuentaCobroTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc098_selectConceptosByCuentaCobroDataTable = taAll.GetData(idCuentaCobro)
            For Each con As dsAlcoComercial2.sp_tc098_selectConceptosByCuentaCobroRow In txAll
                TraerConceptosxCuentaCobro.Add(New conceptosOT(con.idConcepto, con.concepto, con.unidadMedida,
                                                               con.precioUnitario, con.idTipoObra, con.tipoObra, con.porcRetenido))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class movitoOrdenTrabajo
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idOrdenTrabajo As Integer
    Private _idConcepto As Integer
    Private _concepto As String
    Private _descripcion As String
    Private _unidadMedida As String
    Private _precio As Decimal
    Private _cantidadTotal As Decimal
    Private _cantidadOriginal As Decimal
    Private _cantidadDisponible As Decimal
    Private _porcRetenido As Decimal
    Private _idTipoObra As Integer
    Private _tipoObra As String
    Private _notas As String
    Private _motivo As String
    Private _facturable As Boolean
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
    Public Property IdConcepto() As Integer
        Get
            Return _idConcepto
        End Get
        Set(ByVal value As Integer)
            _idConcepto = value
        End Set
    End Property
    Public Property Concepto() As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public Property UnidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property
    Public Property Precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property
    Public Property CantidadTotal() As Decimal
        Get
            Return _cantidadTotal
        End Get
        Set(ByVal value As Decimal)
            _cantidadTotal = value
        End Set
    End Property
    Public Property CantidadOriginal() As Decimal
        Get
            Return _cantidadOriginal
        End Get
        Set(ByVal value As Decimal)
            _cantidadOriginal = value
        End Set
    End Property
    Public Property CantidadDisponible() As Decimal
        Get
            Return _cantidadDisponible
        End Get
        Set(ByVal value As Decimal)
            _cantidadDisponible = value
        End Set
    End Property
    Public Property PorcentajeRetenido() As Decimal
        Get
            Return _porcRetenido
        End Get
        Set(ByVal value As Decimal)
            _porcRetenido = value
        End Set
    End Property
    Public Property IdTipoObra() As Integer
        Get
            Return _idTipoObra
        End Get
        Set(ByVal value As Integer)
            _idTipoObra = value
        End Set
    End Property
    Public Property TipoObra() As String
        Get
            Return _tipoObra
        End Get
        Set(ByVal value As String)
            _tipoObra = value
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
    Public Property Motivo() As String
        Get
            Return _motivo
        End Get
        Set(ByVal value As String)
            _motivo = value
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
#End Region
#Region "Procedimientos"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idOrdenTrabajo As Integer,
                   idConcepto As Integer, concepto As String, unidadMedida As String, precio As Decimal,
                   cantidadOrden As Decimal, cantidadOriginal As Decimal, porcentRetenido As Decimal, notas As String,
                   motivo As String, facturable As Boolean, usuarioModi As String, fechaModi As DateTime,
                   idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idOrdenTrabajo = idOrdenTrabajo
            _idConcepto = idConcepto
            _concepto = concepto
            _unidadMedida = unidadMedida
            _precio = precio
            _cantidadTotal = cantidadOrden
            _cantidadOriginal = cantidadOriginal
            _porcRetenido = porcentRetenido
            _notas = notas
            _motivo = motivo
            _facturable = facturable
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = FechaModificacion
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, idOrdenTrabajo As Integer, idConcepto As Integer, concepto As String, descripcion As String,
                   unidadMedida As String, precio As Decimal, cantidadTotal As Decimal, cantidadDisponible As Decimal,
                   porcentRetenido As Decimal, idTipoObra As Integer, tipoObra As String,
                   notas As String, facturable As Boolean)
        Try
            Me.Id = id
            _idOrdenTrabajo = idOrdenTrabajo
            _idConcepto = idConcepto
            _concepto = RTrim(concepto)
            _descripcion = RTrim(descripcion)
            _unidadMedida = RTrim(unidadMedida)
            _precio = precio
            _cantidadTotal = cantidadTotal
            _cantidadDisponible = cantidadDisponible
            _porcRetenido = porcentRetenido
            _idTipoObra = idTipoObra
            _tipoObra = RTrim(tipoObra)
            _notas = RTrim(notas)
            _facturable = facturable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class conceptosOT
#Region "Variables"
    Private _idConcepto As Integer
    Private _concepto As String
    Private _unidadMedida As String
    Private _precioUnitario As Decimal
    Private _idTipoObra As Integer
    Private _tipoObra As String
    Private _porcRetenido As Decimal
#End Region
#Region "Propiedades"
    Public Property IdConcepto() As Integer
        Get
            Return _idConcepto
        End Get
        Set(ByVal value As Integer)
            _idConcepto = value
        End Set
    End Property
    Public Property Concepto() As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
        End Set
    End Property
    Public Property UnidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property
    Public Property PrecioUnitario() As Decimal
        Get
            Return _precioUnitario
        End Get
        Set(ByVal value As Decimal)
            _precioUnitario = value
        End Set
    End Property
    Public Property IdTipoObra() As Integer
        Get
            Return _idTipoObra
        End Get
        Set(ByVal value As Integer)
            _idTipoObra = value
        End Set
    End Property
    Public Property TipoObra() As String
        Get
            Return _tipoObra
        End Get
        Set(ByVal value As String)
            _tipoObra = value
        End Set
    End Property
    Public Property PorcRetenido() As Decimal
        Get
            Return _porcRetenido
        End Get
        Set(ByVal value As Decimal)
            _porcRetenido = value
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
    Public Sub New(idConcepto As Integer, concepto As String, unidadMedida As String, precioUnitario As Decimal,
                   idTipoObra As Integer, tipoObra As String, porcRetenido As Decimal)
        Try
            _idConcepto = idConcepto
            _concepto = concepto
            _unidadMedida = unidadMedida
            _precioUnitario = precioUnitario
            _idTipoObra = idTipoObra
            _tipoObra = tipoObra
            _porcRetenido = porcRetenido
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
