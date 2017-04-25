Imports Datos
Public Class ClsMedidasPerfileria
#Region "vars"
    Private tameds As New dsbAlcoIngenieriaTableAdapters.ti040_medidasperfileriaTableAdapter
#End Region
#Region "procs"
    Public Sub Insertar(usuario As String, idperfil As Integer, medida As Decimal, descuento As Decimal, estado As Integer)
        Try
            tameds.sp_ti040_insert(usuario, idperfil, medida, descuento, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(usuario As String, idperfil As Integer, medida As Decimal, descuento As Decimal, estado As Integer, id As Integer)
        Try
            tameds.sp_ti040_update(usuario, idperfil, medida, descuento, estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodosTabla() As DataTable
        Try
            Dim tamed As New dsbAlcoIngenieriaTableAdapters.sp_ti040_selectAllTableAdapter
            Return tamed.GetData().Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxEstado(estado As Integer) As List(Of LotePerfileria)
        TraerxEstado = New List(Of LotePerfileria)
        Try
            Dim tamed As New dsbAlcoIngenieriaTableAdapters.sp_ti040_selectByEstadoTableAdapter
            Dim tmed As dsbAlcoIngenieria.sp_ti040_selectByEstadoDataTable = tamed.GetData(estado)
            For Each m As dsbAlcoIngenieria.sp_ti040_selectByEstadoRow In tmed
                TraerxEstado.Add(New LotePerfileria(m.id, m.fecha_creacion, m.usuario_creacion,
                                                     m.idperfil, m.referencia, m.medida, m.descuento,
                                                     m.fecha_modificacion, m.usuario_modificacion, m.id_estado, m.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class LotePerfileria
    Inherits ClsBaseParametros
#Region "vars"
    Private _idperfil As Integer
    Private _referencia As String
    Private _medida As Decimal
    Private _descuento As Decimal
#End Region
#Region "props"
    Public Property IdPerfil As Integer
        Get
            Return _idperfil
        End Get
        Set(value As Integer)
            _idperfil = value
        End Set
    End Property
    Public Property Referencia As String
        Get
            Return _referencia
        End Get
        Set(value As String)
            _referencia = value
        End Set
    End Property
    Public Property Medida As Decimal
        Get
            Return _medida
        End Get
        Set(value As Decimal)
            _medida = value
        End Set
    End Property
    Public Property Descuento As Decimal
        Get
            Return _descuento
        End Get
        Set(value As Decimal)
            _descuento = value
        End Set
    End Property
#End Region
#Region "ctor"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                   idperfil As Integer, referencia As String, medida As Decimal, descuento As Decimal,
                   fechamodificacion As DateTime, usuariomodificacion As String,
                   idestado As Integer, estado As String)
        _id = id
        _fechacreacion = fechacreacion
        _usuariocreacion = usuariocreacion
        _idperfil = idperfil
        _referencia = referencia
        _medida = medida
        _descuento = descuento
        _fechamodificacion = fechamodificacion
        _idestado = idestado
        _estado = estado
    End Sub
#End Region
End Class


