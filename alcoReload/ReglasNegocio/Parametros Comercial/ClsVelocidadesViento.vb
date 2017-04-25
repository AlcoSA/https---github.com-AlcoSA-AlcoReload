Imports Datos
Public Class ClsVelocidadesViento
#Region "Variables"
    Private tavelocidad As New dsAlcoComercialTableAdapters.tc038_velocidadesVientoTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="idciudad"></param>
    ''' <param name="idversion"></param>
    ''' <param name="valor"></param>
    ''' <param name="estado"></param>
    Public Sub Insertar(usuario As String, idciudad As Integer, idversion As Integer,
                        valor As Decimal, estado As Integer)
        Try
            tavelocidad.sp_tc038_insert(usuario, idciudad, idversion, valor, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idciudad"></param>
    ''' <param name="idversion"></param>
    ''' <param name="valor"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, idciudad As Integer, idversion As Integer,
                        valor As Decimal, estado As Integer)
        Try
            tavelocidad.sp_tc038_update(id, usuario, idciudad, idversion, valor, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene todos los registros de aluminios
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of VelocidadViento)
        Try
            TraerTodos = New List(Of VelocidadViento)
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc038_selectAllTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc038_selectAllDataTable = taAll.GetData()
            For Each ti As dsAlcoComercial.sp_tc038_selectAllRow In txAll.Rows
                TraerTodos.Add(New VelocidadViento(ti.Id, ti.Fecha_Creacion, ti.Usuario_Creacion, ti.Id_Ciudad, ti.Ciudad,
                                                ti.Id_Version_CV, ti.Version, ti.Valor, ti.Usuario_Modi, ti.Fecha_Modi,
                                                   ti.Id_Estado, ti.Estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxIdciudadyIdversion(idciudad As Integer, idversion As Integer) As VelocidadViento
        Try
            TraerxIdciudadyIdversion = New VelocidadViento
            Dim taAll As New dsAlcoComercialTableAdapters.sp_tc038_selectbyIdCiudadandIdVersionTableAdapter
            Dim txAll As dsAlcoComercial.sp_tc038_selectbyIdCiudadandIdVersionDataTable = taAll.GetData(idciudad, idversion)
            If txAll.Rows.Count > 0 Then
                For Each ti As dsAlcoComercial.sp_tc038_selectbyIdCiudadandIdVersionRow In txAll.Rows
                    TraerxIdciudadyIdversion = New VelocidadViento(ti.fc038_rowid, ti.fc038_fechacreacion, ti.fc038_usuariocreacion, ti.fc038_rowidCiudad,
                                                                   String.Empty, ti.fc038_rowidVersionCV, String.Empty, ti.fc038_valor, ti.fc038_usuariomodificacion,
                                                                   ti.fc038_fechamodificacion, ti.fc038_rowidestado, String.Empty)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class VelocidadViento
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idciudad As Integer
    Private _ciudad As String
    Private _idversion As Integer
    Private _version As String
    Private _valor As Decimal
#End Region
#Region "Propiedades"
    Public Property IdCiudad As Integer
        Get
            Return _idciudad
        End Get
        Set(ByVal value As Integer)
            _idciudad = value
        End Set
    End Property
    Public Property Ciudad As String
        Get
            Return _ciudad
        End Get
        Set(ByVal value As String)
            _ciudad = value
        End Set
    End Property
    Public Property IdVersion As Integer
        Get
            Return _idversion
        End Get
        Set(ByVal value As Integer)
            _idversion = value
        End Set
    End Property
    Public Property Version As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property
    Public Property Valor As Decimal
        Get
            Return _valor
        End Get
        Set(ByVal value As Decimal)
            _valor = value
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

    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idciudad As Integer, ciudad As String, idversion As Integer, version As String,
                   valor As Decimal, usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            _idciudad = idciudad
            _ciudad = Trim(ciudad)
            _idversion = idversion
            _version = Trim(version)
            _valor = valor
            Me.UsuarioModificacion = Trim(usuarioModi)
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
