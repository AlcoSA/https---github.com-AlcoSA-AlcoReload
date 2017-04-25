Imports Datos

Public Class clsMovitoPoliza
#Region "Variables"
    Private taPolizaContrato As New dsAlcoContratosTableAdapters.tc050_polizasContratosTableAdapter
#End Region
#Region "Variables"
    Public Sub Insertar(usuarioCreacion As String, idContrato As Integer, idTipoPoliza As Integer, idAseguradora As Integer,
                        consecutivo As String, numeroCertificado As String, valorPoliza As Decimal, fechaInicio As DateTime,
                        fechaVencimiento As DateTime, observaciones As String, idEstado As Integer)
        Try
            taPolizaContrato.sp_tc050_insert(usuarioCreacion, idContrato, idTipoPoliza, idAseguradora, consecutivo, numeroCertificado,
                                             valorPoliza, fechaInicio, fechaVencimiento, observaciones, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, idTipoPoliza As Integer, idAseguradora As Integer, consecutivo As String,
                         anexo As String, valorPoliza As Decimal, fechaInicio As DateTime, fechaVencimiento As DateTime,
                         observaciones As String, usuario As String)
        Try
            taPolizaContrato.sp_tc050_update(id, idTipoPoliza, idAseguradora, consecutivo, anexo, valorPoliza,
                                             fechaInicio, fechaVencimiento, observaciones, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(id As Integer, idEstado As Integer)
        Try
            taPolizaContrato.sp_tc050_updateEstado(id, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos() As List(Of movitoPoliza)
        Try
            TraerTodos = New List(Of movitoPoliza)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc050_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc050_selectAllDataTable = taAll.GetData()
            For Each pol As dsAlcoContratos.sp_tc050_selectAllRow In txAll.Rows
                TraerTodos.Add(New movitoPoliza(pol.id, pol.fechaCreacion, pol.usuarioCreacion, pol.idContrato, pol.idTipoPoliza,
                                                pol.tipoPoliza, pol.idAseguradora, pol.aseguradora, pol.consecutivo, pol.anexo,
                                                pol.valorPoliza, pol.fechaInicio, pol.fechaVencimiento, pol.obsevacion,
                                                pol.usuarioModi, pol.fechaModi, pol.idEstado, pol.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIDContrato(idContrato As Integer) As List(Of movitoPoliza)
        Try
            TraerxIDContrato = New List(Of movitoPoliza)
            TraerxIDContrato = TraerTodos().Where(Function(a) a.IdContrato = idContrato And a.IdEstado <> ClsEnums.Estados.ARCHIVADO).ToList
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExistePoliza(idContrato As Integer, idTipoPoliza As Integer, idAseguradora As Integer,
                                    consecutivo As String, anexo As String) As Boolean
        Try
            Dim listExistentes As List(Of movitoPoliza) = TraerTodos().Where(Function(a) a.IdContrato = idContrato And a.IdTipoPoliza = idTipoPoliza And
                                                     a.IdAseguradora = idAseguradora And a.Consecutivo = consecutivo And a.Anexo = anexo).ToList
            If listExistentes.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function PolizaVigente(idContrato As Integer, idTipoPoliza As Integer) As movitoPoliza
        Try
            Dim list As List(Of movitoPoliza) = TraerTodos()
            PolizaVigente = list.FirstOrDefault(Function(a) a.IdContrato = idContrato And a.IdTipoPoliza = idTipoPoliza And
                                                                       a.IdEstado = ClsEnums.Estados.VIGENTE)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class movitoPoliza
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idContrato As Integer
    Private _idTipoPoliza As Integer
    Private _tipoPoliza As String
    Private _idAseguradora As Integer
    Private _aseguradora As String
    Private _consecutivo As String
    Private _anexo As String
    Private _valorPoliza As Decimal
    Private _fechaInicio As DateTime
    Private _fechaVencimiento As DateTime
    Private _observacion As String
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
    Public Property IdTipoPoliza() As Integer
        Get
            Return _idTipoPoliza
        End Get
        Set(ByVal value As Integer)
            _idTipoPoliza = value
        End Set
    End Property
    Public Property TipoPoliza() As String
        Get
            Return _tipoPoliza
        End Get
        Set(ByVal value As String)
            _tipoPoliza = value
        End Set
    End Property
    Public Property IdAseguradora() As Integer
        Get
            Return _idAseguradora
        End Get
        Set(ByVal value As Integer)
            _idAseguradora = value
        End Set
    End Property
    Public Property Aseguradora() As String
        Get
            Return _aseguradora
        End Get
        Set(ByVal value As String)
            _aseguradora = value
        End Set
    End Property
    Public Property Consecutivo() As String
        Get
            Return _consecutivo
        End Get
        Set(ByVal value As String)
            _consecutivo = value
        End Set
    End Property
    Public Property Anexo() As String
        Get
            Return _anexo
        End Get
        Set(ByVal value As String)
            _anexo = value
        End Set
    End Property
    Public Property ValorPoliza() As Decimal
        Get
            Return _valorPoliza
        End Get
        Set(ByVal value As Decimal)
            _valorPoliza = value
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
    Public Property FechaVencimiento() As DateTime
        Get
            Return _fechaVencimiento
        End Get
        Set(ByVal value As DateTime)
            _fechaVencimiento = value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Return _observacion
        End Get
        Set(ByVal value As String)
            _observacion = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idContrato As Integer, idTipoPotiza As Integer,
                   tipoPoliza As String, idAseguradora As Integer, aseguradora As String, consecutivo As String, anexo As String,
                   valorPoliza As Decimal, fechaInicio As DateTime, fechaVencimiento As DateTime, observacion As String, usuarioModi As String,
                   fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idContrato = idContrato
            _idTipoPoliza = idTipoPotiza
            _tipoPoliza = tipoPoliza
            _idAseguradora = idAseguradora
            _aseguradora = aseguradora
            _consecutivo = consecutivo
            _anexo = anexo
            _valorPoliza = valorPoliza
            _fechaInicio = fechaInicio
            _fechaVencimiento = fechaVencimiento
            _observacion = observacion
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
