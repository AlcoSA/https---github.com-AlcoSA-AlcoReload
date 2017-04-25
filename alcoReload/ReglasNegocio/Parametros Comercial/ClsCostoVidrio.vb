Imports Datos

Public Class ClsCostoVidrio
#Region "Variables"
    Private taCostoVidrio As New dsAlcoComercialTableAdapters.tc030_costoVidrioTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Inserta un nuevo registro de costos de vidrio en la base de datos
    ''' </summary>
    Public Sub Insertar(usuarioCreacion As String, idArticulo As Integer, idEspesor As Integer, idAcabado As Integer,
                        version As Integer, costo As Decimal)
        Try
            taCostoVidrio.sp_tc030_insert(usuarioCreacion, idArticulo, idEspesor, idAcabado, version, costo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene la máxima versión del costo de vidrio
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerMaxVersion() As Integer
        Try
            Return Convert.ToInt32(taCostoVidrio.sp_tc030_selectMaxVersion())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene los registros de costo vidrio
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(versionBase As Integer, Optional ByRef tabla As DataTable = Nothing) As List(Of costoVidrio)
        Try
            TraerTodos = New List(Of costoVidrio)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc030_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc030_selectAllDataTable = taAll.GetData(versionBase)
            For Each ti As dsAlcoComercial.sp_tc030_selectAllRow In txAll.Rows
                TraerTodos.Add(New costoVidrio(ti.fechaCreacion, ti.usuarioCreacion, ti.idArticulo, ti.articulo,
                                               ti.idEspesor, ti.espesor, ti.idAcabado, ti.acabado, ti.versionActual,
                                               ti.nuevaVersion, ti.costo))
            Next
            tabla = txAll
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerCosto(idVidrio As Integer, idEspesor As Integer, idAcabado As Integer, version As Integer) As Decimal
        Try
            Return Convert.ToDecimal(taCostoVidrio.sp_tc030_selectCosto(idVidrio, idEspesor, idAcabado, version))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerCostoxReferenciaAcabadoEspesor(referencia As String,
                                                        espesor As String,
                                                        acabado As String, version As Integer) As Decimal
        Try
            Return Convert.ToDecimal(taCostoVidrio.sp_tc030_selectByReferenciaEspecificos(referencia,
                                                                                          espesor, acabado,
                                                                                          version))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerCostoxReferenciaAcabadoEspesor(referencia As String, espesor As String, acabado As String) As Decimal
        Try
            taCostoVidrio = New dsAlcoComercialTableAdapters.tc030_costoVidrioTableAdapter
            Return Convert.ToDecimal(taCostoVidrio.sp_tc030_selectCostoxReferencia(referencia, espesor, acabado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function ExisteCosto(version As Integer, idVidrio As Integer, idColor As Integer, idEspesor As Integer) As Boolean
        Try
            Dim listCostos As List(Of costoVidrio) = TraerTodos(version).Where(Function(a) a.idArticulo = idVidrio And
                                                                                   a.idAcabado = idColor And a.idEspesor = idEspesor).ToList
            If listCostos.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class costoVidrio
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idArticulo As Integer
    Private _articulo As String
    Private _idEspesor As Integer
    Private _espesor As String
    Private _idAcabado As Integer
    Private _acabado As String
    Private _version As Integer
    Private _nuevaVersion As Integer
    Private _costo As Decimal
#End Region

#Region "Propiedades"
    Public Property idArticulo() As Integer
        Get
            Return _idArticulo
        End Get
        Set(ByVal value As Integer)
            _idArticulo = value
        End Set
    End Property

    Public Property articulo() As String
        Get
            Return _articulo
        End Get
        Set(ByVal value As String)
            _articulo = value
        End Set
    End Property

    Public Property idEspesor() As Integer
        Get
            Return _idEspesor
        End Get
        Set(ByVal value As Integer)
            _idEspesor = value
        End Set
    End Property

    Public Property espesor() As String
        Get
            Return _espesor
        End Get
        Set(ByVal value As String)
            _espesor = value
        End Set
    End Property

    Public Property idAcabado() As Integer
        Get
            Return _idAcabado
        End Get
        Set(ByVal value As Integer)
            _idAcabado = value
        End Set
    End Property

    Public Property acabado() As String
        Get
            Return _acabado
        End Get
        Set(ByVal value As String)
            _acabado = value
        End Set
    End Property

    Public Property versionActual() As Integer
        Get
            Return _version
        End Get
        Set(ByVal value As Integer)
            _version = value
        End Set
    End Property

    Public Property nuevaVersion() As Integer
        Get
            Return _nuevaVersion
        End Get
        Set(ByVal value As Integer)
            _nuevaVersion = value
        End Set
    End Property

    Public Property costo() As Decimal
        Get
            Return _costo
        End Get
        Set(ByVal value As Decimal)
            _costo = value
        End Set
    End Property
#End Region

#Region "Procedimientos"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(fechaCreacion As DateTime, usuarioCreacion As String, idArticulo As Integer,
                   articulo As String, idEspesor As Integer, espesor As String, idAcabado As Integer,
                   acabado As String, version As Integer, nuevaVersion As Integer, costo As Decimal)
        Try
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _idArticulo = idArticulo
            _articulo = Trim(articulo)
            _idEspesor = idEspesor
            _espesor = Trim(espesor)
            _idAcabado = idAcabado
            _acabado = Trim(acabado)
            _version = version
            _nuevaVersion = nuevaVersion
            _costo = costo
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
