Imports Datos
Public Class ClsParametrosInformesDinamicos
#Region "Variables"
    Private taparametros As New dsGeneralesAplicacionTableAdapters.tg017_parametrosinformesdinamicosTableAdapter
#End Region

    Public Sub Insertar(usuario As String, idinforme As Integer, tipodato As Integer, nombrebd As String,
                        nombre As String, estado As Integer)
        Try
            taparametros.sp_tg017_insert(usuario, idinforme, tipodato, nombrebd, nombre, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, usuario As String, idinforme As Integer, tipodato As Integer, nombrebd As String,
                        nombre As String, estado As Integer)
        Try
            taparametros.sp_tg017_update(id, usuario, idinforme, tipodato, nombrebd, nombre, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarporId(id As Integer)
        Try
            taparametros.sp_tg017_deletebyId(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdInforme(idinforme As Integer) As List(Of ParametroInforme)
        TraerxIdInforme = New List(Of ParametroInforme)
        Try
            Dim tab As dsGeneralesAplicacion.tg017_parametrosinformesdinamicosDataTable = taparametros.TraerporIdInforme(idinforme)
            For Each p As dsGeneralesAplicacion.tg017_parametrosinformesdinamicosRow In tab.Rows
                TraerxIdInforme.Add(New ParametroInforme(p.fg017_rowid, p.fg017_fechacreacion, p.fg017_usuariocreacion, p.fg017_rowidinforme,
                                                         p.fg017_tipodato, p.fg017_nombrebd, p.fg017_nombre, p.fg017_fechamodificacion,
                                                         p.fg017_usuariomodificacion, p.fg017_estado))
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdInformeyEstado(idinforme As Integer, estado As Integer) As List(Of ParametroInforme)
        TraerxIdInformeyEstado = New List(Of ParametroInforme)
        Try
            Dim tab As dsGeneralesAplicacion.tg017_parametrosinformesdinamicosDataTable = taparametros.TraerporIdInformeyEstado(idinforme, estado)
            For Each p As dsGeneralesAplicacion.tg017_parametrosinformesdinamicosRow In tab.Rows
                TraerxIdInformeyEstado.Add(New ParametroInforme(p.fg017_rowid, p.fg017_fechacreacion, p.fg017_usuariocreacion, p.fg017_rowidinforme,
                                                         p.fg017_tipodato, p.fg017_nombrebd, p.fg017_nombre, p.fg017_fechamodificacion,
                                                         p.fg017_usuariomodificacion, p.fg017_estado))
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class

Public Class ParametroInforme
    Inherits ClsBaseParametros
#Region "Variables"
    Protected _idinforme As Integer = 0
    Protected _tipodato As ClsEnums.TiposDato = ClsEnums.TiposDato.TEXTO
    Protected _nombrebd As String = String.Empty
    Protected _nombre As String = String.Empty
#End Region
#Region "Propiedades"
    Public Property IdInforme As Integer
        Get
            Return _idinforme
        End Get
        Set(value As Integer)
            _idinforme = value
        End Set
    End Property
    Public Property TipoDato As ClsEnums.TiposDato
        Get
            Return _tipodato
        End Get
        Set(value As ClsEnums.TiposDato)
            _tipodato = value
        End Set
    End Property
    Public Property NombreBD As String
        Get
            Return _nombrebd
        End Get
        Set(value As String)
            _nombrebd = value
        End Set
    End Property
    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
#End Region
#Region "Ctor"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                   idinforme As Integer, tipodato As Integer, nombrebd As String, nombre As String,
                   fechamodificacion As DateTime, usuariomodificacion As String, idestado As Integer)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = Trim(usuariocreacion)
        _idinforme = idinforme
        _tipodato = DirectCast(tipodato, ClsEnums.TiposDato)
        _nombrebd = Trim(nombrebd)
        _nombre = Trim(nombre)
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = Trim(usuariomodificacion)
        Me.IdEstado = idestado
    End Sub
#End Region
End Class
