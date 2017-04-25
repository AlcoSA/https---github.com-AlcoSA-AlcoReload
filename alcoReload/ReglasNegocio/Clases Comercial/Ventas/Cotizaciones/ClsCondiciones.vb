Imports Datos
Public Class ClsCondiciones
#Region "Variables"
    Private _objCondicionCotiza As New dsAlcoComercial2TableAdapters.tc071_condicionesTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub insert(fechaCreacion As DateTime, usuarioCreacion As String, idTipoObra As Integer, condicion As String, idEstado As Integer, idgrupo As Integer)
        Try
            _objCondicionCotiza.sp_tc071_insert(fechaCreacion, usuarioCreacion, idTipoObra, condicion, idEstado, idgrupo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub update(id As Integer, usuarioModi As String, idTipoObra As Integer, condicion As String, idEstado As Integer, idGrupo As Integer)
        Try
            _objCondicionCotiza.sp_tc071_update(id, usuarioModi, idTipoObra, condicion, idEstado, idGrupo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function selectAll(Optional ByRef dt As DataTable = Nothing) As List(Of condicion)
        Try
            selectAll = New List(Of condicion)
            Dim ta As New dsAlcoComercial2TableAdapters.sp_tc071_selectAllTableAdapter
            Dim td As dsAlcoComercial2.sp_tc071_selectAllDataTable = ta.GetData()
            If td.Rows.Count > 0 Then
                For Each fila As dsAlcoComercial2.sp_tc071_selectAllRow In td.Rows
                    selectAll.Add(New condicion(fila.id, fila.FechaCreacion, fila.UsuarioCreacion, fila.Condicion, fila.idTipoObra, fila.TipoObra, fila.FechaModi, fila.UsuarioModi, fila.IdEstado,
                                                fila.Estado, fila.idGrupo, fila.Grupo))
                Next
                dt = td.CopyToDataTable
            End If
        Catch ex As Exception

            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function selectByIdCondicion(idCondicion As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of condicion)
        Try
            selectByIdCondicion = New List(Of condicion)
            selectByIdCondicion.AddRange(selectAll(dt).Where(Function(a) a.Id = idCondicion).ToList)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function selectByIdTipoObra(idTipoObra As Integer) As List(Of condicion)
        Try
            selectByIdTipoObra = New List(Of condicion)
            selectByIdTipoObra.AddRange(selectAll().Where(Function(a) a.idTipoObra = idTipoObra).ToList)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class condicion : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _condicion As String
    Public Property Condicion() As String
        Get
            Return _condicion
        End Get
        Set(ByVal value As String)
            _condicion = value
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
    Private _tipoObra As String
    Public Property tipoObra() As String
        Get
            Return _tipoObra
        End Get
        Set(ByVal value As String)
            _tipoObra = value
        End Set
    End Property
    Private _idgrupo As Integer
    Public Property idGrupo() As Integer
        Get
            Return _idgrupo
        End Get
        Set(ByVal value As Integer)
            _idgrupo = value
        End Set
    End Property
    Private _grupo As String
    Public Property Grupo() As String
        Get
            Return _grupo
        End Get
        Set(ByVal value As String)
            _grupo = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Sub New(id As Integer, fechaCreacion As Date, usuarioCreacion As String, condicion As String, idTipoObra As Integer, TipoObra As String, fechaModificacion As DateTime,
            usuarioModi As String, idEstado As Integer, estado As String, idGrupo As Integer, grupo As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            Me.FechaCreacion = fechaModificacion
            Me.UsuarioModificacion = usuarioModi
            Me.IdEstado = idEstado
            Me.Estado = estado
            _condicion = condicion
            _idTipoObra = idTipoObra
            _tipoObra = TipoObra
            _idgrupo = idGrupo
            _grupo = grupo

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region


End Class
