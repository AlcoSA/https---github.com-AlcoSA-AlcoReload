Imports Datos
Public Class clsRelacionParaContrato
#Region "Variables"
    Private _objParaContrato As New dsAlcoContratosTableAdapters.tc042_RelacionContratoTiposTableAdapter
#End Region
#Region "Procedimientos y funciones"
    Public Sub tc042_insert(usuarioCreacion As String, idContrato As Integer, idTipoObra As Integer)
        Try
            _objParaContrato.sp_tc042_insert(usuarioCreacion, idContrato, idTipoObra, usuarioCreacion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub tc042_update(id As Integer, fc042_rowidContrato As Integer, idTipoObra As Integer, usuarioModi As String, idestado As Integer)
        Try
            _objParaContrato.sp_tc042_update(id, fc042_rowidContrato, idTipoObra, usuarioModi, idestado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarporIdContrato(idcontrato As Integer)
        Try
            _objParaContrato.sp_tc042_deleteByIdContrato(idcontrato)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function traerTodos() As List(Of relacionParaContrato)
        traerTodos = New List(Of relacionParaContrato)
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc042_selectAllTableAdapter
            Dim td As dsAlcoContratos.sp_tc042_selectAllDataTable = ta.GetData()
            If td.Rows.Count > 0 Then
                For Each fila As dsAlcoContratos.sp_tc042_selectAllRow In td.Rows
                    traerTodos.Add(New relacionParaContrato(fila.id, fila.idContrato, fila.idTipoObra, fila.usuarioCreacion, fila.FechaCreacion, fila.usuarioCreacion,
                                                           fila.FechaMOdificacion, fila.idestado, fila.Estado))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try

    End Function
    Public Function traerxId(id As Integer) As List(Of relacionParaContrato)
        traerxId = New List(Of relacionParaContrato)
        Try
            traerxId.AddRange(traerTodos().Where(Function(a) a.Id = id And a.IdEstado = ClsEnums.Estados.ACTIVO))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerxIdContrato(idContrato As Integer) As List(Of relacionParaContrato)
        traerxIdContrato = New List(Of relacionParaContrato)
        Try
            traerxIdContrato.AddRange(traerTodos().Where(Function(a) a.idContrato = idContrato And a.IdEstado = ClsEnums.Estados.ACTIVO))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class relacionParaContrato : Inherits tipoObra
#Region "Propiedades"
    Private _idContrato As Integer
    Public Property idContrato() As Integer
        Get
            Return _idContrato
        End Get
        Set(ByVal value As Integer)
            _idContrato = value
        End Set
    End Property
    Private _idTipoObra As Integer
    Public Property idTipoObra() As Integer
        Get
            Return _idTipoObra
        End Get
        Set(ByVal value As Integer)
            _idTipoObra = value
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
    Public Sub New(id As Integer, idContrato As Integer, idTipoObra As Integer, usuarioCreacion As String, fechaCreacion As DateTime,
                   usuarioModificacion As String, fechaModificacion As DateTime, idEstado As Integer, estado As String)
        Try
            Me.idContrato = id
            _idContrato = idContrato
            _idTipoObra = idTipoObra
            Me.UsuarioCreacion = usuarioCreacion
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioModificacion = usuarioModificacion
            Me.FechaModificacion = fechaModificacion
            Me.IdEstado = idEstado
            Me.Estado = estado

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
