Imports Datos
Public Class ClsEncabeEnlaceConector
#Region "vars"
    Private _objenlace As New dsGeneralesAplicacionTableAdapters.tg015_encabeenlaceplanosTableAdapter
#End Region
    Public Function Insertar(usuario As String, nombreplano As String, idconector As Integer, idestado As Integer) As Integer
        Try
            Return Convert.ToInt32(_objenlace.sp_tg015_insert(usuario, nombreplano, idconector, idestado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Modificar(usuario As String, nombreplano As String, idconector As Integer, idestado As Integer, id As Integer)
        Try
            _objenlace.sp_tg015_update(usuario, nombreplano, idconector, idestado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdConector(idconector As Integer) As List(Of EncabezadoEnlaceConector)
        TraerporIdConector = New List(Of EncabezadoEnlaceConector)
        Try
            Dim te As dsGeneralesAplicacion.tg015_encabeenlaceplanosDataTable = _objenlace.TraerporIdConector(idconector)
            te.ToList().ForEach(Sub(x)
                                    TraerporIdConector.Add(New EncabezadoEnlaceConector(x.fg015_rowid,
                                                                                        x.fg015_fechacreacion, x.fg015_usuariocreacion,
                                                                                        x.fg015_rowidconector, x.fg015_nombreplano,
                                                                                        x.fg015_fechamodificacion, x.fg015_usuariomodificacion, x.fg015_rowidestado))
                                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporId(id As Integer) As EncabezadoEnlaceConector
        TraerporId = New EncabezadoEnlaceConector
        Try
            Dim te As dsGeneralesAplicacion.tg015_encabeenlaceplanosDataTable = _objenlace.TraerporId(id)
            te.ToList().ForEach(Sub(x)
                                    TraerporId = New EncabezadoEnlaceConector(x.fg015_rowid,
                                                                                        x.fg015_fechacreacion, x.fg015_usuariocreacion,
                                                                                        x.fg015_rowidconector, x.fg015_nombreplano,
                                                                                        x.fg015_fechamodificacion, x.fg015_usuariomodificacion, x.fg015_rowidestado)
                                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
Public Class EncabezadoEnlaceConector
    Inherits ClsBaseParametros
#Region "vars"
    Private _idconector As Integer = 0
    Private _nombreplano As String = String.Empty
#End Region
#Region "props"
    Public Property IdConector As Integer
        Get
            Return _idconector
        End Get
        Set(value As Integer)
            _idconector = value
        End Set
    End Property
    Public Property NombrePlano As String
        Get
            Return _nombreplano
        End Get
        Set(value As String)
            _nombreplano = value
        End Set
    End Property

#End Region
#Region "ctor"
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                   idconector As Integer, nombreplano As String,
                   FechaModificacion As DateTime, usuariomodificacion As String, idestado As Integer)
        _id = id
        _fechacreacion = fechacreacion
        _usuariocreacion = Trim(usuariocreacion)
        _idconector = idconector
        _nombreplano = nombreplano
        _fechamodificacion = FechaModificacion
        _usuariomodificacion = Trim(usuariomodificacion)
    End Sub

#End Region
End Class
