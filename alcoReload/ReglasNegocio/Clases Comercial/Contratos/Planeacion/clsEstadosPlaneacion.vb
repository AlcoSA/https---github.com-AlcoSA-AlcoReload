Imports Datos

Public Class clsEstadosPlaneacion
#Region "Variables"
    Private taEstadosPlaneacion As New dsAlcoContratosTableAdapters.tc085_estadoPlaneacionTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(idContrato As Integer, idPendiente As Integer, idEstado As Integer)
        Try
            taEstadosPlaneacion.sp_tc085_insert(idContrato, idPendiente, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub actualizarxIdContrato(idContrato As Integer, idPendiente As Integer, idEstado As Integer)
        Try
            taEstadosPlaneacion.sp_tc085_updateByIdContrato(idContrato, idPendiente, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub actualizarxIdPendiente(idPendiente As Integer, idContrato As Integer, idEstado As Integer)
        Try
            taEstadosPlaneacion.sp_tc085_updateByIdPendiente(idPendiente, idContrato, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos() As List(Of estadoPlaneacion)
        Try
            TraerTodos = New List(Of estadoPlaneacion)
            Dim taAll As New dsAlcoContratosTableAdapters.sp_tc085_selectAllTableAdapter
            Dim txAll As dsAlcoContratos.sp_tc085_selectAllDataTable = taAll.GetData()
            For Each est As dsAlcoContratos.sp_tc085_selectAllRow In txAll
                TraerTodos.Add(New estadoPlaneacion(est.id, est.idContrato, est.idPendiente, est.idEstado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExistePlaneacion(idContrato As Integer, idPendiente As Integer) As Boolean
        Try
            Dim lista As New List(Of estadoPlaneacion)
            If idContrato <> 0 Then
                lista = TraerTodos().Where(Function(a) a.IdContrato = idContrato).ToList
            Else
                lista = TraerTodos().Where(Function(a) a.IdPendiente = idPendiente).ToList
            End If
            If lista.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerEstadoxIdPendiente(idPendiente As Integer) As Integer
        Try
            Dim reg As estadoPlaneacion = TraerTodos().FirstOrDefault(Function(a) a.IdPendiente = idPendiente)
            If reg IsNot Nothing Then
                Return Convert.ToInt32(reg.IdEstado)
            Else
                Return ClsEnums.Estados.SIN_CONTRATO
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class estadoPlaneacion
#Region "Variables"
    Private _id As Integer
    Private _idContrato As Integer
    Private _idPendiente As Integer
    Private _idEstado As Integer
#End Region
#Region "Propiedades"
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property IdContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
    Public Property IdPendiente() As Integer
        Get
            Return _idPendiente
        End Get
        Set(ByVal value As Integer)
            _idPendiente = value
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
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, idContrato As Integer, idPendiente As Integer, idEstado As Integer)
        Try
            _id = id
            _idContrato = idContrato
            _idPendiente = idPendiente
            _idEstado = idEstado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
