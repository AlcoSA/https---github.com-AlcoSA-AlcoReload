Imports Datos
Public Class ClsDibujosItemsCotiza
#Region "Variables"
    Private tadibujositems As New dsAlcoCotizacionesTableAdapters.tc021_dibujositemsCotizaTableAdapter
#End Region

#Region "Procedimientos"

    Public Function Ingresar(idpadre As Integer, idhijo As Integer, usuario As String, dxf As String, x As Double, y As Double, ancho As Double,
                        alto As Double, orientacion As Integer, nivel As Integer, idcontenedor As Integer) As Integer
        Try
            Return Convert.ToInt32(tadibujositems.sp_tc021_insert(idpadre, idhijo, usuario,
                                                                  dxf, x, y, ancho, alto,
                                                                  orientacion, nivel, idcontenedor))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Modificar(id As Integer, idpadre As Integer, idhijo As Integer, usuario As String, dxf As String, x As Double, y As Double, ancho As Double,
                        alto As Double, orientacion As Integer, nivel As Integer, idcontenedor As Integer)
        Try
            tadibujositems.sp_tc021_update(id, usuario, idpadre, idhijo, dxf, x, y,
                                     ancho, alto, orientacion, nivel, idcontenedor)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function Duplicar(id_original As Integer, id_padre_nuevo As Integer, id_hijo_nuevo As Integer,
                        id_contenedor_nuevo As Integer, usuario As String) As Integer
        Try
            Return Convert.ToInt32(tadibujositems.sp_tc021_duplicar(id_original, id_padre_nuevo,
                                                                    id_hijo_nuevo, id_contenedor_nuevo,
                                                                    usuario))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub BorrarxIdItemCotiza(iditemcotiza As Integer)
        Try
            tadibujositems.sp_tc021_deletebyIditemcotiza(iditemcotiza)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerxIdITemCotiza(iditemcotiza As Integer) As List(Of DibujoPadreCotiza)
        TraerxIdITemCotiza = New List(Of DibujoPadreCotiza)
        Try
            Dim ta As dsAlcoCotizaciones.tc021_dibujositemsCotizaDataTable = tadibujositems.TraerporIdItemCotiza(iditemcotiza)
            For Each dc As dsAlcoCotizaciones.tc021_dibujositemsCotizaRow In ta.Rows
                TraerxIdITemCotiza.Add(New DibujoPadreCotiza(dc.fc021_rowid, dc.fc021_fechacreacion, dc.fc021_usuariocreacion,
                                                             dc.fc021_rowiditempadre, dc.fc021_rowiditemhijo, dc.fc021_x, dc.fc021_y, dc.fc021_ancho,
                                                             dc.fc021_alto, dc.fc021_orientacion, dc.fc021_nivel,
                                                             dc.fc021_idcontenedor, dc.fc021_dxf, dc.fc021_fechamodificacion, dc.fc021_usuariomodificacion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxIdCotiza(idcotiza As Integer) As List(Of DibujoPadreCotiza)
        TraerxIdCotiza = New List(Of DibujoPadreCotiza)
        Try
            Dim ta As dsAlcoCotizaciones.tc021_dibujositemsCotizaDataTable = tadibujositems.TraerporIdCotiza(idcotiza)
            For Each dc As dsAlcoCotizaciones.tc021_dibujositemsCotizaRow In ta.Rows
                TraerxIdCotiza.Add(New DibujoPadreCotiza(dc.fc021_rowid, dc.fc021_fechacreacion, dc.fc021_usuariocreacion,
                                                             dc.fc021_rowiditempadre, dc.fc021_rowiditemhijo, dc.fc021_x,
                                                         dc.fc021_y, dc.fc021_ancho, dc.fc021_alto, dc.fc021_orientacion,
                                                         dc.fc021_nivel, dc.fc021_idcontenedor, dc.fc021_dxf, dc.fc021_fechamodificacion, dc.fc021_usuariomodificacion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region

End Class
Public Class DibujoPadreCotiza
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idpadre As Integer = 0
    Private _idhijo As Integer = 0
    Private _x As Double = 0
    Private _y As Double = 0
    Private _ancho As Double = 0
    Private _alto As Double = 0
    Private _nivel As Integer = 0
    Private _idcontendor As Integer = 0
    Private _orientacion As Integer = 0
    Private _dxf As String = String.Empty
#End Region
#Region "Propiedades"
    Public Property IdPadre As Integer
        Get
            Return _idpadre
        End Get
        Set(value As Integer)
            _idpadre = value
        End Set
    End Property
    Public Property IdHijo As Integer
        Get
            Return _idhijo
        End Get
        Set(value As Integer)
            _idhijo = value
        End Set
    End Property
    Public Property X As Double
        Get
            Return _x
        End Get
        Set(value As Double)
            _x = value
        End Set
    End Property
    Public Property Y As Double
        Get
            Return _y
        End Get
        Set(value As Double)
            _y = value
        End Set
    End Property
    Public Property Ancho As Double
        Get
            Return _ancho
        End Get
        Set(value As Double)
            _ancho = value
        End Set
    End Property
    Public Property Alto As Double
        Get
            Return _alto
        End Get
        Set(value As Double)
            _alto = value
        End Set
    End Property
    Public Property Nivel As Integer
        Get
            Return _nivel
        End Get
        Set(value As Integer)
            _nivel = value
        End Set
    End Property
    Public Property IdContendor As Integer
        Get
            Return _idcontendor
        End Get
        Set(value As Integer)
            _idcontendor = value
        End Set
    End Property
    Public Property DXF As String
        Get
            Return _dxf
        End Get
        Set(value As String)
            _dxf = value
        End Set
    End Property
    Public Property Orientacion As Integer
        Get
            Return _orientacion
        End Get
        Set(value As Integer)
            _orientacion = value
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
    Public Sub New(id As Integer, FechaCreacion As DateTime, UsuarioCreacion As String,
                   idpadre As Integer, idhijo As Integer, x As Double, y As Double, ancho As Double,
                   alto As Double, orientacion As Integer,
                   nivel As Integer, idcontenedor As Integer, dxf As String,
                   FechaModi As DateTime, UsuarioModi As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(UsuarioCreacion)
            Me.FechaCreacion = FechaCreacion
            _idpadre = idpadre
            _idhijo = idhijo
            _x = x
            _y = y
            _ancho = ancho
            _alto = alto
            _orientacion = orientacion
            _nivel = nivel
            _idcontendor = idcontenedor
            _dxf = dxf
            Me.UsuarioModificacion = Trim(UsuarioModi)
            Me.FechaModificacion = FechaModi

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class


