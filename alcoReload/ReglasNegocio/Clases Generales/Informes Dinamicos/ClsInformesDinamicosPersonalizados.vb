Imports Datos
Public Class ClsInformesDinamicosPersonalizados
#Region "vars"
    Private tainf As New dsGeneralesAplicacionTableAdapters.tg020_informespersonalizadosTableAdapter
#End Region

    Public Function Insertar(usuario As String, idinforme As Integer, idtipototal As Integer,
                             nombreinforme As String, estado As Integer) As Integer
        Try
            Return Convert.ToInt32(tainf.sp_tg020_insert(usuario, idinforme, idtipototal, nombreinforme, estado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(id As Integer, usuario As String, idinforme As Integer, idtipototal As Integer,
                             nombreinforme As String, estado As Integer)
        Try
            tainf.sp_tg020_update(id, usuario, idinforme, idtipototal, nombreinforme, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdInforme(idinforme As Integer) As List(Of InformeDinamicoPersonalizado)
        TraerxIdInforme = New List(Of InformeDinamicoPersonalizado)
        Try
            Dim tbi As dsGeneralesAplicacion.tg020_informespersonalizadosDataTable = tainf.TraerxIdInforme(idinforme)
            For Each i As dsGeneralesAplicacion.tg020_informespersonalizadosRow In tbi.Rows
                TraerxIdInforme.Add(New InformeDinamicoPersonalizado(i.fg020_rowid, i.fg020_fechacreacion,
                                                                     i.fg020_usuariocreacion, i.fg020_rowidinforme,
                                                                     i.fg020_rowidtipototal, i.fg020_nombreinforme,
                                                                     i.fg020_fechamodificacion, i.fg020_usuariomodificacion,
                                                                     i.fg020_estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxIdInformeyUsuario(idinforme As Integer, usuario As String) As List(Of InformeDinamicoPersonalizado)
        TraerxIdInformeyUsuario = New List(Of InformeDinamicoPersonalizado)
        Try
            Dim tbi As dsGeneralesAplicacion.tg020_informespersonalizadosDataTable = tainf.TraerxIdInformeyUsuario(idinforme, usuario)
            For Each i As dsGeneralesAplicacion.tg020_informespersonalizadosRow In tbi.Rows
                TraerxIdInformeyUsuario.Add(New InformeDinamicoPersonalizado(i.fg020_rowid, i.fg020_fechacreacion,
                                                                     i.fg020_usuariocreacion, i.fg020_rowidinforme,
                                                                     i.fg020_rowidtipototal, i.fg020_nombreinforme,
                                                                     i.fg020_fechamodificacion, i.fg020_usuariomodificacion,
                                                                     i.fg020_estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxId(id As Integer) As InformeDinamicoPersonalizado
        TraerxId = New InformeDinamicoPersonalizado
        Try
            Dim tbi As dsGeneralesAplicacion.tg020_informespersonalizadosDataTable = tainf.TraerxId(id)
            If tbi.Rows.Count > 0 Then
                Dim i As dsGeneralesAplicacion.tg020_informespersonalizadosRow = DirectCast(tbi.Rows(0), dsGeneralesAplicacion.tg020_informespersonalizadosRow)
                TraerxId = New InformeDinamicoPersonalizado(i.fg020_rowid, i.fg020_fechacreacion,
                                                                     i.fg020_usuariocreacion, i.fg020_rowidinforme,
                                                                     i.fg020_rowidtipototal, i.fg020_nombreinforme,
                                                                     i.fg020_fechamodificacion, i.fg020_usuariomodificacion,
                                                                     i.fg020_estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class

Public Class InformeDinamicoPersonalizado
    Inherits ClsBaseParametros
#Region "vars"
    Protected _idinforme As Integer = 0
    Protected _idtipototal As Integer = 0
    Protected _nombreinforme As String = String.Empty
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
    Public Property IdTipoTotal As Integer
        Get
            Return _idtipototal
        End Get
        Set(value As Integer)
            _idtipototal = value
        End Set
    End Property
    Public Property NombreInforme As String
        Get
            Return _nombreinforme
        End Get
        Set(value As String)
            _nombreinforme = value
        End Set
    End Property
#End Region
#Region "ctor"
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String, idinforme As Integer,
                   idtipototal As Integer, nombreinforme As String, fechamodificacion As DateTime, usuariomodificacion As String,
                   idestado As Integer)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = usuariocreacion
        _idinforme = idinforme
        _idtipototal = idtipototal
        _nombreinforme = nombreinforme
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = usuariomodificacion
        Me.IdEstado = idestado
    End Sub
#End Region
End Class
