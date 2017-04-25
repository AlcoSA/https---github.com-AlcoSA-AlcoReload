Imports Datos
Public Class ClsAprobacionPlantilla

#Region "Variables"
    Private taaprobado As New dsbAlcoIngenieriaTableAdapters.ti035_aprobacionesplantillaTableAdapter
#End Region

#Region "Procedimientos"
    Public Sub Aprobar(usuario As String, idplantilla As Integer)
        Try
            taaprobado.Insert(usuario, idplantilla, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub Reaprobar(usuario As String, Idplantilla As Integer, Id As Integer)
        Try
            taaprobado.Update(Idplantilla, usuario, Id, Id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporidPlantilla(idplantilla As Integer) As AprobacionPlantilla
        TraerporidPlantilla = New AprobacionPlantilla()
        Try
            Dim fila As dsbAlcoIngenieria.ti035_aprobacionesplantillaRow = taaprobado.GetData().FirstOrDefault(Function(x) x.fi035_rowidplantilla = idplantilla)
            If Not fila Is Nothing Then
                TraerporidPlantilla = New AprobacionPlantilla(fila.fi035_rowid, fila.fi035_fechacreacion, fila.fi035_usuariocreacion, fila.fi035_rowidplantilla, fila.fi035_fechamodificacion, fila.fi035_usuariomodificacion)
            End If


        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region

End Class

Public Class AprobacionPlantilla
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idplantilla As Integer

#End Region

#Region "Propiedades"
    Public Property IdPlantilla As Integer
        Get
            Return _idplantilla

        End Get
        Set(value As Integer)

            _idplantilla = value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, fechacreacion As DateTime,
                   usuariocreacion As String, idplantilla As Integer, fechamodificacion As DateTime,
                   usuariomodificacion As String)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = usuariocreacion
        _idplantilla = _idplantilla
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = usuariomodificacion
    End Sub
#End Region

End Class