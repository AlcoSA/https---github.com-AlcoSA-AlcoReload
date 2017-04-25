Imports Datos
Public Class ClsHistorialCorreosOrdenPed
#Region "Variables"
    Private _objOp As New dsAlcoProduccionTableAdapters.tp020_historialcorreosopTableAdapter
#End Region
    Public Sub Insertar(idorden As Integer, ip As String, destino As String, direnvio As String,
                        identificacion As String, cargo_empresa As String, asunto As String, cuerpo As String)
        Try
            _objOp.sp_tp020_insert(idorden, ip, destino, direnvio, identificacion, cargo_empresa,
                                   asunto, cuerpo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdOrden(idorden As Integer) As List(Of HistorialCorreos)
        TraerporIdOrden = New List(Of HistorialCorreos)
        Try
            Dim tp As dsAlcoProduccion.tp020_historialcorreosopDataTable = _objOp.TraerxIdOrden(idorden)
            For Each hc As dsAlcoProduccion.tp020_historialcorreosopRow In tp.Rows
                TraerporIdOrden.Add(New HistorialCorreos(hc.fp020_rowid, hc.fp020_rowidordenpedido,
                                                         hc.fp020_ip, hc.fp020_destinatario, hc.fp020_direccionenvio,
                                                         hc.fp020_identificacion, hc.fp020_cargoempresa, hc.fp020_asunto, hc.fp020_cuerpo, hc.fp020_fechaenvio))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
Public Class HistorialCorreos
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idh As Integer
    Private _ip As String
    Private _destino As String
    Private _direccion_envio As String
    Private _identificacion As String
    Private _cargo_empresa As String
    Private _asunto As String
    Private _cuerpo As String
    Private _fechaenvio As DateTime
#End Region
#Region "Propiedades"
    Public Property Id_Heradado As Integer
        Get
            Return _idh
        End Get
        Set(value As Integer)
            _idh = value
        End Set
    End Property
    Public Property Ip As String
        Get
            Return _ip
        End Get
        Set(value As String)
            _ip = value
        End Set
    End Property
    Public Property Destino As String
        Get
            Return _destino
        End Get
        Set(value As String)
            _destino = value
        End Set
    End Property
    Public Property Direccion_Envio As String
        Get
            Return _direccion_envio
        End Get
        Set(value As String)
            _direccion_envio = value
        End Set
    End Property
    Public Property Identificacion As String
        Get
            Return _identificacion
        End Get
        Set(value As String)
            _identificacion = value
        End Set
    End Property
    Public Property Cargo_Empresa As String
        Get
            Return _cargo_empresa
        End Get
        Set(value As String)
            _cargo_empresa = value
        End Set
    End Property
    Public Property Asunto As String
        Get
            Return _asunto
        End Get
        Set(value As String)
            _asunto = value
        End Set
    End Property
    Public Property Cuerpo As String
        Get
            Return _cuerpo
        End Get
        Set(value As String)
            _cuerpo = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, idh As Integer, ip As String, destino As String, direnvio As String,
                   identificacion As String, cargo_empresa As String, asunto As String, cuerpo As String, fechaenvio As DateTime)
        Me.Id = id
        _idh = idh
        _ip = ip
        _destino = destino
        _direccion_envio = direnvio
        _identificacion = identificacion
        _cargo_empresa = _cargo_empresa
        _asunto = asunto
        _cuerpo = cuerpo
        _fechaenvio = fechaenvio
    End Sub
#End Region

End Class
