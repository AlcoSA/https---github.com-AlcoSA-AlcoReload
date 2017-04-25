Imports Datos
Public Class ClsExtraCostosCotiza
#Region "vars"
    Dim taexc As New dsAlcoCotizacionesTableAdapters.tc111_costosextracotizaTableAdapter
#End Region
    Public Function Insertar(idotro As Integer, idcotiza As Integer,
                             valor As Decimal, duracion As Integer, usuario As String) As Integer
        Try
            Return Convert.ToInt32(taexc.sp_tc111_insert(idotro, idcotiza, valor, duracion, usuario))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(idotro As Integer, idcotiza As Integer,
                            valor As Decimal, duracion As Integer, usuario As String, id As Integer)
        Try
            taexc.sp_tc111_update(idotro, idcotiza, valor, duracion, usuario, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarporId(id As Integer)
        Try
            taexc.sp_tc111_deleteById(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerporIdCotiza(idcotiza As Integer) As List(Of ExtraCostoCotiza)
        TraerporIdCotiza = New List(Of ExtraCostoCotiza)
        Try
            Dim texc As New dsAlcoCotizacionesTableAdapters.sp_tc111_selectByIdCotizaTableAdapter
            Dim tec As dsAlcoCotizaciones.sp_tc111_selectByIdCotizaDataTable = texc.GetData(idcotiza)
            tec.ToList.ForEach(Sub(e)
                                   TraerporIdCotiza.Add(New ExtraCostoCotiza(e.id, e.fechacreacion, e.usuariocreacion,
                                                                             e.idotro, e.nombre, e.costo, e.duracion, e.idcotiza,
                                                                             e.fechamodificacion, e.usuariomodificacion))

                               End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
Public Class ExtraCostoCotiza
    Inherits CostoExtraObra
#Region "vars"
    Protected _idotro As Integer
    Protected _idcotiza As Integer
    Protected _duracion As Integer
#End Region
#Region "props"
    Public Property IdOtro As Integer
        Get
            Return _idotro
        End Get
        Set(value As Integer)
            _idotro = value
        End Set
    End Property
    Public Property IdCotiza As Integer
        Get
            Return _idcotiza
        End Get
        Set(value As Integer)
            _idcotiza = value
        End Set
    End Property
    Public Property Duracion As Integer
        Get
            Return _duracion
        End Get
        Set(value As Integer)
            _duracion = value
        End Set
    End Property
#End Region
#Region "ctor"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                   idotro As Integer, nombre As String, valor As Decimal, duracion As Integer, idcotiza As Integer,
                   fechamodificacion As DateTime, usuariomodificacion As String)
        _id = id
        _fechacreacion = _fechacreacion
        _usuariocreacion = usuariocreacion
        _idotro = idotro
        _nombre = Trim(nombre)
        _valor = valor
        _duracion = duracion
        _idcotiza = idcotiza
        _fechamodificacion = fechamodificacion
        _usuariomodificacion = usuariomodificacion
    End Sub
#End Region
End Class
