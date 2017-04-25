Imports Datos
Public Class ClsConector
#Region "Variables"
    Private _objConector As New dsGeneralesAplicacionTableAdapters.tg011_conectorPlanosTableAdapter

#End Region
#Region "Procedimientos"
    Public Function insertar(descripcion As String, usuarioCreacion As String, idEstado As Integer) As Integer
        Try
            insertar = CInt(_objConector.sp_tg011_insert(descripcion, usuarioCreacion, idEstado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub update(descripcion As String, usuarioModi As String, idEstado As Integer, id As Integer)
        Try
            _objConector.Update(descripcion, usuarioModi, idEstado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function SelectAll() As List(Of conector)
        SelectAll = New List(Of conector)
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg011_selectAllTableAdapter
            Dim dt As dsGeneralesAplicacion.sp_tg011_selectAllDataTable = ta.GetData()
            If dt.Rows.Count > 0 Then
                dt.Rows.Cast(Of dsGeneralesAplicacion.sp_tg011_selectAllRow).ToList.ForEach(Sub(r)
                                                                                                SelectAll.Add(New conector(r.id,
                                                                                                                           r.Descripcion, r.UsuarioCreacion, r.FechaCreacion, r.UsuarioModi, r.FechaModi,
                                                                                                                           r.idEstado, r.Estado))
                                                                                            End Sub)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class conector : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _descripcion As String
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
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
    Sub New(id As Integer, descripcion As String, usarioCreacion As String, fechaCreacion As DateTime,
            usuarioModi As String, fechaModi As DateTime, idEstado As Integer, Estado As String)
        Try
            Me.Id = id
            _descripcion = descripcion.Trim()
            Me.UsuarioCreacion = UsuarioCreacion.Trim()
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioModificacion = UsuarioModificacion.Trim()
            Me.IdEstado = idEstado
            Me.Estado = Estado.Trim()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
