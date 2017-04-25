Imports Datos

Public Class ClsCostoAccesorio
#Region "Variables"
    Private taCostoAccesorio As New dsAlcoComercialTableAdapters.tc031_costoAccesorioTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Inserta un nuevo registro de costo accesorio en la base de datos
    ''' </summary>
    ''' <param name="usuarioCreacion"></param>
    ''' <param name="idAccesorio"></param>
    ''' <param name="version"></param>
    ''' <param name="costo"></param>
    Public Sub Insertar(usuarioCreacion As String, idAccesorio As Integer, version As Integer, costo As Decimal)
        Try
            taCostoAccesorio.sp_tc031_insert(usuarioCreacion, idAccesorio, version, costo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Actualiza los costos indicados
    ''' </summary>
    ''' <param name="costo"></param>
    ''' <param name="idAccesorio"></param>
    ''' <param name="version"></param>
    Public Sub Modificar(costo As Decimal, idAccesorio As Integer, version As Integer)
        Try
            taCostoAccesorio.sp_tc031_updateByIdAccesorio(costo, idAccesorio, version)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Obtiene la última versión de los costos de accesorios
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerMaxVersion() As Integer
        Try
            Return Convert.ToInt32(taCostoAccesorio.sp_tc031_selectMaxVersion())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Eliminar(idCosto As Integer)
        Try
            taCostoAccesorio.sp_tc031_deleteById(idCosto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of costoAccesorio)
        Try
            TraerTodos = New List(Of costoAccesorio)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc031_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc031_selectAllDataTable = taAll.GetData()
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc031_selectAllRow In txAll.Rows
                    TraerTodos.Add(New costoAccesorio(ti.fechaCreacion, ti.usuarioCreacion, ti.idAccesorio,
                                                      ti.referencia, ti.descripcion, ti.version, ti.version + 1,
                                                      ti.costo, ti.nuevoCosto))
                Next
            End If
            dt = txAll.CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxVersion(version As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of costoAccesorio)
        Try
            TraerxVersion = New List(Of costoAccesorio)
            Dim ta As New dsAlcoComercialTableAdapters.sp_tc031_selectByVersionTableAdapter
            Dim tx As dsAlcoComercial.sp_tc031_selectByVersionDataTable = ta.GetData(version)
            For Each ti As dsAlcoComercial.sp_tc031_selectByVersionRow In tx.Rows
                TraerxVersion.Add(New costoAccesorio(ti.fechaCreacion, ti.usuarioCreacion, ti.idAccesorio,
                                                      ti.referencia, ti.descripcion, ti.version, ti.version + 1,
                                                      ti.costo, ti.nuevoCosto))
            Next
            If tx.Rows.Count > 0 Then
                dt = tx.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el registro de costo accesorio correspondiente al Id de accesorio indicado
    ''' </summary>
    ''' <param name="idAccesorio"></param>
    ''' <returns></returns>
    Public Function TraerxIdAccesorio(idAccesorio As Integer, version As Integer) As costoAccesorio
        TraerxIdAccesorio = New costoAccesorio
        Try
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc031_selectByIdAccesorioTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc031_selectByIdAccesorioDataTable = taAll.GetData(idAccesorio, version)
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc031_selectByIdAccesorioRow In txAll.Rows
                    TraerxIdAccesorio = New costoAccesorio(ti.fechaCreacion, ti.usuarioCreacion, ti.idAccesorio,
                                                             ti.referencia, ti.descripcion, ti.version,
                                                             ti.version + 1, ti.costo, ti.nuevoCosto)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerCostoxReferencia(referencia As String, version As Integer) As Decimal
        Try
            taCostoAccesorio = New dsAlcoComercialTableAdapters.tc031_costoAccesorioTableAdapter
            Return Convert.ToDecimal(taCostoAccesorio.sp_tc031_selectByReferenciaVersion(referencia, version))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene el costo de accesorio con la referencia indicada
    ''' </summary>
    ''' <param name="referencia"></param>
    ''' <returns></returns>
    Public Function TraerCostoxReferencia(referencia As String) As Decimal
        Try
            taCostoAccesorio = New dsAlcoComercialTableAdapters.tc031_costoAccesorioTableAdapter
            Return Convert.ToDecimal(taCostoAccesorio.sp_tc031_selectCostoxReferencia(referencia))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExisteCosto(idAccesorio As Integer, version As Integer) As Boolean
        Try
            Dim list As List(Of costoAccesorio) = TraerxVersion(version).Where(Function(a) a.idAccesorio = idAccesorio).ToList()
            If list.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class costoAccesorio
    Inherits ClsBaseParametros

#Region "Variables"
    Private _idAccesorio As Integer
    Private _referencia As String
    Private _descripcion As String
    Private _version As Integer
    Private _costo As Decimal
    Private _nuevoCosto As Decimal
#End Region

#Region "Propiedades"
    Public Property idAccesorio() As Integer
        Get
            Return _idAccesorio
        End Get
        Set(ByVal value As Integer)
            _idAccesorio = value
        End Set
    End Property

    Public Property referencia() As String
        Get
            Return _referencia
        End Get
        Set(ByVal value As String)
            _referencia = value
        End Set
    End Property

    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property version() As Integer
        Get
            Return _version
        End Get
        Set(ByVal value As Integer)
            _version = value
        End Set
    End Property

    Private _nuevaVersion As Integer
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

    Public Property nuevoCosto() As Decimal
        Get
            Return _nuevoCosto
        End Get
        Set(ByVal value As Decimal)
            _nuevoCosto = value
        End Set
    End Property
#End Region

    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub New(fechaCreacion As DateTime, usuarioCreacion As String, idAccesorio As Integer,
                   referencia As String, descripcion As String, version As Integer,
                   nuevaVersion As Integer, costo As Decimal, nuevoCosto As Decimal)
        Try
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _idAccesorio = idAccesorio
            _referencia = Trim(referencia)
            _descripcion = Trim(descripcion)
            _version = version
            _nuevaVersion = nuevaVersion
            _costo = costo
            _nuevoCosto = nuevoCosto
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
End Class