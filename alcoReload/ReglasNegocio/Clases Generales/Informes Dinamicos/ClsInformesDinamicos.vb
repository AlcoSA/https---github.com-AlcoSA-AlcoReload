Imports Datos
Public Class ClsInformesDinamicos
#Region "Variables"
    Private tainformes As New dsGeneralesAplicacionTableAdapters.tg016_informesdinamicosTableAdapter
#End Region
    Public Sub Insertar(usuario As String, rowidmodulo As Integer, nombreinforme As String, nombresp As String, estado As Integer)
        Try
            tainformes.sp_tg016_insert(usuario, rowidmodulo, nombreinforme, nombresp, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, usuario As String, rowidmodulo As Integer, nombreinforme As String,
                         nombresp As String, estado As Integer)
        Try
            tainformes.sp_tg016_update(id, usuario, rowidmodulo, nombreinforme, nombresp, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos() As DataTable
        TraerTodos = New DataTable
        Try
            TraerTodos = tainformes.TraerTodos()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxModulo(modulo As ClsEnums.ModulosAplicacion) As List(Of InformeDinamico)
        TraerxModulo = New List(Of InformeDinamico)
        Try
            Dim tinf As dsGeneralesAplicacion.tg016_informesdinamicosDataTable = tainformes.TraerporModulo(modulo)
            For Each i As dsGeneralesAplicacion.tg016_informesdinamicosRow In tinf.Rows
                TraerxModulo.Add(New InformeDinamico(i.fg016_rowid, i.fg016_fechacreacion, i.fg016_usuariocreacion,
                                                     i.fg016_rowidmodulo, i.fg016_nombreinforme, i.fg016_nombresp,
                                                     i.fg016_fechamodificacion, i.fg016_usuariomodificacion, i.fg016_estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function EjecutarProcedimientoInforme(proc_sql As String, diccionario_parametros As Dictionary(Of String, Object)) As DataTable
        Try
            Dim ejecutor As New Datos.ClsEjecutorSql
            Return ejecutor.EjecutarSP(proc_sql, diccionario_parametros)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
Public Class InformeDinamico
    Inherits ClsBaseParametros
#Region "vars"
    Protected _idmodulo As Integer = 0
    Protected _nombreinforme As String = String.Empty
    Protected _nombresp As String = String.Empty
#End Region

#Region "props"
    Public Property IdModulo As Integer
        Get
            Return _idmodulo
        End Get
        Set(value As Integer)
            _idmodulo = value
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
    Public Property NombreSP As String
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
    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String, idmodulo As Integer,
                   nombreinforme As String, nombresp As String, fechamodificacion As DateTime, usuariomodificacion As String,
                   idestado As Integer)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = usuariocreacion
        _idmodulo = idmodulo
        _nombreinforme = nombreinforme
        _nombresp = nombresp
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = usuariomodificacion
        Me.IdEstado = idestado
    End Sub
#End Region

End Class
