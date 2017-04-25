Imports Datos
Public Class ClsCostosExtraObra
#Region "vars"
    Private tacex As New dsAlcoComercial2TableAdapters.tc110_otroscostosobraTableAdapter
#End Region
    Public Sub Insertar(nombre As String, valor As Decimal, usuario As String, idestado As Integer)
        Try
            tacex.sp_tc110_insert(nombre, valor, usuario, idestado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(nombre As String, valor As Decimal, usuario As String,
                          idestado As Integer, id As Integer)
        Try
            tacex.sp_tc110_update(nombre, valor, usuario, idestado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodosTabla() As DataTable
        Try
            Dim ta As New dsAlcoComercial2TableAdapters.sp_tc110_selectAllTableAdapter
            Return ta.GetData().Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporIdEstado(idestado As Integer) As List(Of CostoExtraObra)
        TraerporIdEstado = New List(Of CostoExtraObra)

        Try
            Dim ta As New dsAlcoComercial2TableAdapters.sp_tc110_selectByEstadoTableAdapter
            Dim taex As dsAlcoComercial2.sp_tc110_selectByEstadoDataTable = ta.GetData(idestado)
            taex.ToList().ForEach(Sub(x)
                                      TraerporIdEstado.Add(New CostoExtraObra(x.id, x.fechacreacion, x.usuariocreacion,
                                                                              x.nombre, x.valor,
                                                                              x.fechamodificacion, x.usuariomodificacion,
                                                                              x.idestado, x.descripcion))
                                  End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
Public Class CostoExtraObra
    Inherits ClsBaseParametros
#Region "vars"
    Protected _nombre As String
    Protected _valor As Decimal
#End Region
#Region "props"
    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
    Public Property Valor As Decimal
        Get
            Return _valor
        End Get
        Set(value As Decimal)
            _valor = value
        End Set
    End Property
#End Region
#Region "ctor"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                   nombre As String, valor As Decimal, fechamodificacion As DateTime,
                   usuariomodificacion As String, idestado As Integer, estado As String)
        _id = id
        _fechacreacion = fechacreacion
        _usuariocreacion = Trim(usuariocreacion)
        _nombre = Trim(nombre)
        _valor = valor
        _fechamodificacion = fechamodificacion
        _usuariomodificacion = Trim(usuariomodificacion)
        _idestado = idestado
        _estado = Trim(estado)
    End Sub
#End Region
End Class
