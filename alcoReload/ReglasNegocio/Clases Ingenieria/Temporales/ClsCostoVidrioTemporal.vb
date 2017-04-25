Imports Datos

Public Class ClsCostoVidrioTemporal
#Region "Variables"
    Private taCostoVidTemp As New dsbAlcoIngenieriaTableAdapters.ti038_costoVidrioTemporalTableAdapter
#End Region
    Public Sub Insertar(usuario As String, idCotiza As Integer, vidrioTemporal As Boolean, idVidrio As Integer,
                        espesorTemporal As Boolean, idEspesor As Integer, colorTemporal As Boolean,
                        idColor As Integer, costo As Decimal, idEstado As Integer)
        Try
            taCostoVidTemp.sp_ti038_insert(usuario, idCotiza, vidrioTemporal, idVidrio, espesorTemporal,
                                           idEspesor, colorTemporal, idColor, costo, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, costo As Decimal)
        Try
            taCostoVidTemp.sp_ti038_update(id, costo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(id As Integer, idEstado As Integer)
        Try
            taCostoVidTemp.sp_ti038_updateEstado(id, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerCostoEspecifico(idCotiza As Integer, temp_vidrio As Boolean, idVidrio As Integer, temp_espesor As Boolean,
                                idEspesor As Integer, temp_color As Boolean, idColor As Integer) As costoVidrioTemporal
        Try
            TraerCostoEspecifico = New costoVidrioTemporal
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti038_selectByItemsTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti038_selectByItemsDataTable = taAll.GetData(idCotiza, temp_vidrio, idVidrio, temp_espesor,
                                                                                           idEspesor, temp_color, idColor)
            If txAll.Rows.Count > 0 Then
                Dim cos As dsbAlcoIngenieria.sp_ti038_selectByItemsRow = DirectCast(txAll.Rows(0), dsbAlcoIngenieria.sp_ti038_selectByItemsRow)
                TraerCostoEspecifico = New costoVidrioTemporal(cos.id, cos.fechaCreacion, cos.usuarioCreacion, cos.idCotiza, cos.vidrioTemporal,
                                                           cos.idVidrio, cos.vidrio, cos.espesorTemporal, cos.idEspesor, cos.espesor,
                                                           cos.colorTemporal, cos.idColor, cos.color, cos.costo, cos.idEstado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerCostoxReferencia(idcotiza As Integer, vidrio As String, espesor As String, color As String) As Decimal
        Try
            Return Convert.ToDecimal(taCostoVidTemp.sp_ti038_selectbyReferenciaEspecificos(vidrio, espesor, color, idcotiza))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdCotiza(idCotiza As Integer) As List(Of costoVidrioTemporal)
        Try
            TraerxIdCotiza = New List(Of costoVidrioTemporal)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti038_selectByIdCotizaTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti038_selectByIdCotizaDataTable = taAll.GetData(idCotiza)
            For Each cos As dsbAlcoIngenieria.sp_ti038_selectByIdCotizaRow In txAll
                TraerxIdCotiza.Add(New costoVidrioTemporal(cos.id, cos.fechaCreacion, cos.usuarioCreacion, cos.idCotiza,
                                                           cos.vidrioTemporal, cos.idVidrio, cos.vidrio, cos.espesorTemporal,
                                                           cos.idEspesor, cos.espesor, cos.colorTemporal, cos.idColor, cos.color,
                                                           cos.costo, cos.idEstado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxVidrio(idCotiza As Integer, temporal As Boolean, idVidrio As Integer) As List(Of costoVidrioTemporal)
        Try
            Dim lista As List(Of costoVidrioTemporal) = TraerxIdCotiza(idCotiza).Where(Function(a)
                                                                                           Return a.VidrioTemporal = temporal And a.IdVidrio = idVidrio
                                                                                       End Function).ToList
            TraerxVidrio = lista
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxColor(idCotiza As Integer, temporal As Boolean, idColor As Integer) As List(Of costoVidrioTemporal)
        Try
            Dim lista As List(Of costoVidrioTemporal) = TraerxIdCotiza(idCotiza).Where(Function(a)
                                                                                           Return a.ColorTemporal = temporal And a.IdColor = idColor
                                                                                       End Function).ToList
            TraerxColor = lista
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxEspesor(idCotiza As Integer, temporal As Boolean, idEspesor As Integer) As List(Of costoVidrioTemporal)
        Try
            Dim lista As List(Of costoVidrioTemporal) = TraerxIdCotiza(idCotiza).Where(Function(a)
                                                                                           Return a.EspesorTemporal = temporal And a.IdEspesor = idEspesor
                                                                                       End Function).ToList
            TraerxEspesor = lista
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
Public Class costoVidrioTemporal
#Region "Variables"
    Private _id As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _idCotiza As Integer
    Private _vidrioTemporal As Boolean
    Private _idVidrio As Integer
    Private _vidrio As String
    Private _espesorTemporal As Boolean
    Private _idEspesor As Integer
    Private _espesor As String
    Private _colorTemporal As Boolean
    Private _idColor As Integer
    Private _color As String
    Private _costo As Decimal
    Private _idEstado As Integer
#End Region
#Region "Propiedades"
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property FechaCreacion() As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _fechaCreacion = value
        End Set
    End Property
    Public Property UsuarioCreacion() As String
        Get
            Return _usuarioCreacion
        End Get
        Set(ByVal value As String)
            _usuarioCreacion = value
        End Set
    End Property
    Public Property IdCotiza() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
        End Set
    End Property
    Public Property VidrioTemporal() As Boolean
        Get
            Return _vidrioTemporal
        End Get
        Set(ByVal value As Boolean)
            _vidrioTemporal = value
        End Set
    End Property
    Public Property IdVidrio() As Integer
        Get
            Return _idVidrio
        End Get
        Set(ByVal value As Integer)
            _idVidrio = value
        End Set
    End Property
    Public Property Vidrio() As String
        Get
            Return _vidrio
        End Get
        Set(ByVal value As String)
            _vidrio = value
        End Set
    End Property
    Public Property EspesorTemporal() As Boolean
        Get
            Return _espesorTemporal
        End Get
        Set(ByVal value As Boolean)
            _espesorTemporal = value
        End Set
    End Property
    Public Property IdEspesor() As Integer
        Get
            Return _idEspesor
        End Get
        Set(ByVal value As Integer)
            _idEspesor = value
        End Set
    End Property
    Public Property Espesor() As String
        Get
            Return _espesor
        End Get
        Set(ByVal value As String)
            _espesor = value
        End Set
    End Property
    Public Property ColorTemporal() As Boolean
        Get
            Return _colorTemporal
        End Get
        Set(ByVal value As Boolean)
            _colorTemporal = value
        End Set
    End Property
    Public Property IdColor() As Integer
        Get
            Return _idColor
        End Get
        Set(ByVal value As Integer)
            _idColor = value
        End Set
    End Property
    Public Property Color() As String
        Get
            Return _color
        End Get
        Set(ByVal value As String)
            _color = value
        End Set
    End Property
    Public Property Costo() As Decimal
        Get
            Return _costo
        End Get
        Set(ByVal value As Decimal)
            _costo = value
        End Set
    End Property
    Public Property IdEstado() As Integer
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Integer)
            _idEstado = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()
        Try

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idCotiza As Integer,
                   vidrioTemporal As Boolean, idVidrio As Integer, vidrio As String, espesorTemporal As Boolean,
                   idEspesor As Integer, espesor As String, colorTemporal As Boolean, idColor As Integer,
                   color As String, costo As Decimal, idEstado As Integer)
        Try
            _id = id
            _fechaCreacion = fechaCreacion
            _usuarioCreacion = Trim(usuarioCreacion)
            _idCotiza = idCotiza
            _vidrioTemporal = vidrioTemporal
            _idVidrio = idVidrio
            _vidrio = Trim(vidrio)
            _espesorTemporal = espesorTemporal
            _idEspesor = idEspesor
            _espesor = Trim(espesor)
            _colorTemporal = colorTemporal
            _idColor = idColor
            _color = Trim(color)
            _costo = costo
            _idEstado = idEstado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
