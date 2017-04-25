Imports Datos
Public Class ClsGruposCondiciones
#Region "Variables"
    Private _objGrupoCondicion As New dsAlcoComercial2TableAdapters.tc108_gruposCondicionesTableAdapter

#End Region
#Region "Procedimientos"
    Public Function insert(descripcion As String, usuario As String, idEstado As Integer) As Integer
        Try
            insert = CInt(_objGrupoCondicion.sp_tc108_insert(descripcion, usuario, idEstado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub update(id As Integer, descripcion As String, usuario As String)
        Try
            _objGrupoCondicion.sp_tc108_update(id, descripcion, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function selectAll(ByRef Optional dt As DataTable = Nothing) As List(Of grupoCondiones)
        selectAll = New List(Of grupoCondiones)
        Try
            Dim ta As New dsAlcoComercial2TableAdapters.sp_tc108_selectAllTableAdapter
            Dim tx As dsAlcoComercial2.sp_tc108_selectAllDataTable = ta.GetData()
            For Each fila As dsAlcoComercial2.sp_tc108_selectAllRow In tx.Rows
                selectAll.Add(New grupoCondiones(fila.id, fila.Descripcion, fila.UsuarioCreacion, fila.FechaCreacion, fila.UsuarioModi, fila.FechaModi,
                                                 fila.idEstado, fila.Estado))
            Next
            dt = tx.CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try

    End Function
#End Region
End Class
Public Class grupoCondiones : Inherits ClsBaseParametros
#Region "propiedades"
    Private _decripcion As String
    Public Property descripcion() As String
        Get
            Return _decripcion
        End Get
        Set(ByVal value As String)
            _decripcion = value
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
    Sub New(id As Integer, descripcion As String, usuarioCrea As String, fechaCreacion As DateTime, usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.descripcion = descripcion.Trim
            Me.UsuarioCreacion = usuarioCrea.Trim
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioModificacion = usuarioModi.Trim
            Me.FechaModificacion = FechaModificacion
            Me.IdEstado = idEstado
            Me.Estado = estado.Trim
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
End Class
