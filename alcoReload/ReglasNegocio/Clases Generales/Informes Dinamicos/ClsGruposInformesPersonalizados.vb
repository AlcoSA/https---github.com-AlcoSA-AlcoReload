Imports Datos
Public Class ClsGruposInformesPersonalizados
#Region "vars"
    Private tagrupo As New dsGeneralesAplicacionTableAdapters.tg023_agrupacioninformesTableAdapter
#End Region
    Public Sub Insertar(usuario As String, idinforme As Integer, nombre_columna As String)
        Try
            tagrupo.sp_tg023_insert(usuario, idinforme, nombre_columna)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarxIdInforme(idinforme As Integer)
        Try
            tagrupo.sp_tg023_deleteByIdInforme(idinforme)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdInforme(idinforme As Integer) As List(Of GrupoInformePersonalizado)
        TraerxIdInforme = New List(Of GrupoInformePersonalizado)
        Try
            Dim tg As dsGeneralesAplicacion.tg023_agrupacioninformesDataTable = tagrupo.TraerxIdInforme(idinforme)
            For Each g As dsGeneralesAplicacion.tg023_agrupacioninformesRow In tg.Rows
                TraerxIdInforme.Add(New GrupoInformePersonalizado(g.fg023_rowid, g.fg023_fechacrecaion, g.fg023_usuariocreacion,
                                                                  g.fg023_rowidinforme, g.fg023_nombrecolumna, g.fg023_fechamodificacion,
                                                                  g.fg023_usuariomodificacion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
Public Class GrupoInformePersonalizado
    Inherits ClsBaseParametros
#Region "vars"
    Protected _idinforme As Integer = 0
    Protected _nombre_columna As String = String.Empty
#End Region
#Region "props"
    Public Property IdInforme As Integer
        Get
            Return _idinforme
        End Get
        Set(value As Integer)
            _idinforme = value
        End Set
    End Property
    Public Property NombreColumna As String
        Get
            Return _nombre_columna
        End Get
        Set(value As String)
            _nombre_columna = value
        End Set
    End Property
#End Region
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                   idinforme As Integer, nombrecolumna As String, fechamodificacion As DateTime, usuariomodificacion As String)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = usuariocreacion
        _idinforme = idinforme
        _nombre_columna = nombrecolumna
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = usuariomodificacion
    End Sub
End Class
