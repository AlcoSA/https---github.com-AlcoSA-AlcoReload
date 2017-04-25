Imports Datos
Public Class clsRelacionObjetoContratos
#Region "Variables"
    Private _objRelacionObjetoContratos As New dsAlcoContratosTableAdapters.tc043_RelacionContratoObjetosTableAdapter
#End Region
#Region "Procedimientos y funciones"
    Public Sub tc043_insert(usuarioCreacion As String, idContrato As Integer, idTipoObjeto As Integer)
        Try
            _objRelacionObjetoContratos.sp_tc043_insert(usuarioCreacion, idContrato, idTipoObjeto, usuarioCreacion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub update(id As Integer, idcontrato As Integer, idTipoObjeto As Integer, usuarioModi As String, idEstado As Integer)
        Try
            _objRelacionObjetoContratos.sp_tc043_update(id, idcontrato, idTipoObjeto, usuarioModi, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarporIdContrato(idcontrato As Integer)
        Try
            _objRelacionObjetoContratos.sp_tc043_deletebyIdContrato(idcontrato)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function traertodas() As List(Of relacionObjetosContratos)
        traertodas = New List(Of relacionObjetosContratos)
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc043_selectAllTableAdapter
            Dim td As dsAlcoContratos.sp_tc043_selectAllDataTable = ta.GetData()
            If td.Rows.Count > 0 Then
                For Each fila As dsAlcoContratos.sp_tc043_selectAllRow In td.Rows
                    traertodas.Add(New relacionObjetosContratos(fila.id, fila.idContrato, fila.idTipoObjeto, fila.fechaCreacion,
                                                                fila.usuarioCreacion, fila.usuarioModi, fila.FechaModi, fila.Idestado, fila.Estado))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerxId(id As Integer) As List(Of relacionObjetosContratos)
        traerxId = New List(Of relacionObjetosContratos)
        Try
            traerxId.AddRange(traertodas().Where(Function(a) a.Id = id And a.IdEstado = ClsEnums.Estados.ACTIVO))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerxIdContrato(idContrato As Integer) As List(Of relacionObjetosContratos)
        traerxIdContrato = New List(Of relacionObjetosContratos)
        Try
            traerxIdContrato.AddRange(traertodas().Where(Function(a) a.idContrato = idContrato And a.IdEstado = ClsEnums.Estados.ACTIVO))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class relacionObjetosContratos : Inherits objetoContrato
#Region "Variables"
    Private _idContrato As Integer
    Public Property idContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
    Private _idObjeto As Integer
    Public Property idObjeto() As Integer
        Get
            Return _idObjeto
        End Get
        Set(ByVal value As Integer)
            _idObjeto = value
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
    Public Sub New(Id As Integer, idContrato As Integer, idObjeto As Integer, FechaCreacion As DateTime, UsuarioCreacion As String,
            UsuarioModi As String, FechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = Id
            _idContrato = idContrato
            _idObjeto = idObjeto
            Me.FechaCreacion = FechaCreacion
            Me.UsuarioCreacion = UsuarioCreacion
            Me.UsuarioModificacion = UsuarioModi
            Me.FechaModificacion = FechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
