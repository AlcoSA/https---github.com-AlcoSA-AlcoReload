Imports Datos
Public Class ClsCondicionCotiza
#Region "Variables"
    Private _objRelacionCondicionCotiza As New dsAlcoComercial2TableAdapters.tc072_CondicionCotizacionTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
    Public Function insert(usuarioCreacion As String, idCotizacion As Integer, txtCondicion As String, idEstado As Integer, grupo As String) As Integer
        Try
            insert = CInt(_objRelacionCondicionCotiza.sp_tc072_insert(usuarioCreacion, idCotizacion, txtCondicion, idEstado, grupo))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub update(id As Integer, usuarioModi As String, idCotizacion As Integer, txtCondicion As String, idEstado As Integer, grupo As String)
        Try
            _objRelacionCondicionCotiza.sp_tc072_update(id, usuarioModi, idCotizacion, txtCondicion, idEstado, grupo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub updateEstado(id As Integer, idestado As Integer, usuarioModi As String)
        Try
            _objRelacionCondicionCotiza.sp_tc072_updateEstado(id, usuarioModi, idestado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function selectAll() As List(Of CondicionCotiza)
        Try
            selectAll = New List(Of CondicionCotiza)
            Dim ta As New dsAlcoComercial2TableAdapters.sp_tc072_selectAllTableAdapter
            Dim td As dsAlcoComercial2.sp_tc072_selectAllDataTable = ta.GetData()
            If td.Rows.Count > 0 Then
                For Each fila As dsAlcoComercial2.sp_tc072_selectAllRow In td.Rows
                    selectAll.Add(New CondicionCotiza(fila.Id, fila.FechaCreacion, fila.UsuarioCreacion, fila.Condicion, fila.IdCotizacion,
                                                              fila.FechaModi, fila.USuarioModi, fila.IdEstado, fila.Estado, fila.Grupo))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function selectByIdCotiza(idCotizacion As Integer) As List(Of CondicionCotiza)
        Try
            selectByIdCotiza = New List(Of CondicionCotiza)
            selectByIdCotiza.AddRange(selectAll().Where(Function(a) a.idCotizacion = idCotizacion).ToList)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class CondicionCotiza : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _txtCondicion As String
    Public Property txtCondicion() As String
        Get
            Return _txtCondicion
        End Get
        Set(ByVal value As String)
            _txtCondicion = value
        End Set
    End Property
    Private _idCotizacion As Integer
    Public Property idCotizacion() As Integer
        Get
            Return _idCotizacion
        End Get
        Set(ByVal value As Integer)
            _idCotizacion = value
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
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As Date, usuarioCreacion As String, txtCondicion As String, idCotizacion As Integer, fechaModificacion As DateTime,
            usuarioModi As String, idEstado As Integer, estado As String, Grupo As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            Me.FechaCreacion = fechaModificacion
            Me.UsuarioModificacion = usuarioModi
            Me.IdEstado = idEstado
            Me.Estado = estado
            _txtCondicion = txtCondicion
            _idCotizacion = idCotizacion
            _grupo = Grupo
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
End Class


