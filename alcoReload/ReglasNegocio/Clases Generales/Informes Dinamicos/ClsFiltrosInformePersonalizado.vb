Imports Datos
Public Class ClsFiltrosInformePersonalizado
#Region "vars"
    Private tafiltro As New dsGeneralesAplicacionTableAdapters.tg022_filtrosinformeTableAdapter
#End Region
    Public Sub Insertar(usuario As String, idinforme As Integer, idtipovalor As Integer,
                        idtipocoincidencia As Integer, nombre_columna As String, valor As String)
        Try
            tafiltro.sp_tg022_insert(usuario, idinforme, idtipovalor, idtipocoincidencia,
                                     nombre_columna, valor)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarxIdInforme(idinforme As Integer)
        Try
            tafiltro.sp_tg022_deleteByIdInforme(idinforme)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdInforme(idinforme As Integer) As List(Of FiltroInformePersonalizado)
        TraerxIdInforme = New List(Of FiltroInformePersonalizado)
        Try
            Dim t_filtros As dsGeneralesAplicacion.tg022_filtrosinformeDataTable = tafiltro.TraerxIdInforme(idinforme)
            For Each f As dsGeneralesAplicacion.tg022_filtrosinformeRow In t_filtros.Rows
                TraerxIdInforme.Add(New FiltroInformePersonalizado(f.fg022_rowid, f.fg022_fechacrecion, f.fg022_usuariocreacion,
                                                                    f.fg022_rowidinforme, f.fg022_rowidtipovalor, f.fg022_rowidtipocoincidencia,
                                                                    f.fg022_nombrecolumna, f.fg022_valor, f.fg022_fechamodificacion, f.fg022_usuariomodificacion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class

Public Class FiltroInformePersonalizado
    Inherits ClsBaseParametros
#Region "vars"
    Protected _idinforme As Integer = 0
    Protected _idtipovalor As Integer = 0
    Protected _idtipocoincidencia As Integer = 0
    Protected _nombre_columna As String = String.Empty
    Protected _valor As String = String.Empty
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
    Public Property IdTipoValor As Integer
        Get
            Return _idtipovalor
        End Get
        Set(value As Integer)
            _idtipovalor = value
        End Set
    End Property
    Public Property IdTipoCoincidencia As Integer
        Get
            Return _idtipocoincidencia
        End Get
        Set(value As Integer)
            _idtipocoincidencia = value
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
    Public Property Valor As String
        Get
            Return _valor
        End Get
        Set(value As String)
            _valor = value
        End Set
    End Property
#End Region
#Region "ctor"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                   idinforme As Integer, idtipovalor As Integer, idtipocoincidencia As Integer,
                   nombrecolumna As String, valor As String, fechamodificacion As DateTime, usuariomodificacion As String)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = usuariocreacion
        _idinforme = idinforme
        _idtipovalor = idtipovalor
        _idtipocoincidencia = idtipocoincidencia
        _nombre_columna = nombrecolumna
        _valor = valor
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = usuariomodificacion
    End Sub
#End Region
End Class