Imports Datos
Namespace CostoKiloAluminio
    Public Class ClsCostoKiloAluminio
#Region "Variables"
        Private taCostoKiloAluminio As New dsAlcoComercialTableAdapters.tc029_costoKiloAluminioTableAdapter
#End Region
#Region "Procedimientos"
        ''' <summary>
        ''' Inserta una nueva version y costo de kilo de aluminio
        ''' </summary>
        ''' <param name="idCostokAluminio"></param>
        ''' <param name="usuarioCreacion"></param>
        ''' <param name="costo"></param>
        ''' <param name="version"></param>
        Public Sub Ingresar(idCostokAluminio As Integer, usuarioCreacion As String,
                            costo As Decimal, version As Integer)
            Try
                taCostoKiloAluminio.sp_tc029_insert(idCostokAluminio, usuarioCreacion, costo, version)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Obtiene la última versión del costo por kilo de aluminio
        ''' </summary>
        ''' <returns></returns>
        Public Function TraerUltimaVersion() As Integer
            Try
                Return Convert.ToInt32(taCostoKiloAluminio.sp_tc029_selectMaxVersion())
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el costo correspondiente a la última versión del costo por kilo aluminio
        ''' </summary>
        ''' <returns></returns>
        Public Function TraerUltimoCosto() As Decimal
            Try
                Return Convert.ToDecimal(taCostoKiloAluminio.sp_tc029_selectUltimoCosto())
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene todos los registros de costo kilo aluminio
        ''' </summary>
        ''' <returns></returns>
        Public Function TraerTodos(versionBase As Integer) As List(Of CostoKAluminio)
            Try
                TraerTodos = New List(Of CostoKAluminio)
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc029_selectAllTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc029_selectAllDataTable = taAll.GetData(versionBase)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoComercial.sp_tc029_selectAllRow In txAll
                        TraerTodos.Add(New CostoKAluminio(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idKiloAluminio,
                                                          ti.kiloAluminio, ti.version, ti.nuevaVersion, ti.costo, ti.nuevoCosto))
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
#End Region
#Region "Funciones"

#End Region
    End Class
    Public Class CostoKAluminio
        Inherits ClsBaseParametros
#Region "Variables"
        Private _idkiloAluminio As Integer
        Private _descripcion As String
        Private _version As Integer
        Private _nuevaVersion As Integer
        Private _Costo As Decimal
        Private _nuevoCosto As Decimal
#End Region
#Region "Propiedades"
        Public Property idKiloAluminio() As Integer
            Get
                Return _idkiloAluminio
            End Get
            Set(ByVal value As Integer)
                _idkiloAluminio = value
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
        Public Property NuevaVersion() As Integer
            Get
                Return _nuevaVersion
            End Get
            Set(ByVal value As Integer)
                _nuevaVersion = value
            End Set
        End Property
        Public Property Costo() As Decimal
            Get
                Return _Costo
            End Get
            Set(ByVal value As Decimal)
                _Costo = value
            End Set
        End Property
        Public Property NuevoCosto() As Decimal
            Get
                Return _nuevoCosto
            End Get
            Set(ByVal value As Decimal)
                _nuevoCosto = value
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
        Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idKiloAluminio As Integer,
                       descripcion As String, version As Integer, nuevaVersion As Integer, costo As Decimal, nuevoCosto As Decimal)
            Try
                Me.Id = id
                Me.FechaCreacion = fechaCreacion
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                _idkiloAluminio = idKiloAluminio
                _descripcion = Trim(descripcion)
                _version = version
                _nuevaVersion = nuevaVersion
                _Costo = costo
                _nuevoCosto = nuevoCosto
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Namespace

