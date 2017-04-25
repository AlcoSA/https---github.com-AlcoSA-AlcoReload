Imports Datos
Namespace CostoAcabado
    Public Class ClsCostoAcabado
#Region "Variables"
        Private taCostoAcabado As New dsAlcoComercialTableAdapters.tc015_costoAcabadoTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
        ''' <summary>
        ''' Ingresa un nuevo registro de costo de acabado en la base de datos
        ''' </summary>
        ''' <param name="idAcabado"></param>
        ''' <param name="version"></param>
        ''' <param name="costo"></param>
        ''' <param name="usuarioCreacion"></param>
        Public Sub Ingresar(idAcabado As Integer, version As Integer, costo As Decimal,
                            usuarioCreacion As String)
            Try
                taCostoAcabado.sp_tc015_insert(idAcabado, version, costo, usuarioCreacion, 1)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Obtiene la última versión en que se encuentran los registros
        ''' </summary>
        ''' <returns></returns>
        Public Function TraerUltimaVersion() As Integer
            Try
                Return Convert.ToInt32(taCostoAcabado.sp_tc015_selectMaxVersion())
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el costo correspondiente al Id indicado y su última versión
        ''' </summary>
        ''' <param name="idAcabado"></param>
        ''' <returns></returns>
        Public Function TraerxId(idAcabado As Integer) As Decimal
            Try
                Return Convert.ToDecimal(taCostoAcabado.sp_tc015_selectByIdAndMaxVersion(idAcabado))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' obtiene todos los registros de costo acabado
        ''' </summary>
        ''' <returns></returns>
        Public Function TraerTodos(versionBase As Integer) As List(Of costoAcabado)
            Try
                TraerTodos = New List(Of costoAcabado)
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc015_selectAllTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc015_selectAllDataTable = taAll.GetData(versionBase)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoComercial.sp_tc015_selectAllRow In txAll.Rows
                        TraerTodos.Add(New costoAcabado(ti.id, ti.usuarioCreacion, ti.fechaCreacion, ti.idAcabado, ti.acabado,
                                                        ti.version, ti.nuevaVersion, ti.costo, ti.nuevoCosto))
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
    Public Class costoAcabado
        Inherits ClsBaseParametros
#Region "Variables"
        Private _idAcabado As Integer = 0
        Private _versionCosto As Integer = 0
        Private _valorCosto As Decimal = 0
        Private _acabado As String = String.Empty
        Private _nuevaVersion As Integer
        Private _nuevoCosto As Decimal
#End Region
#Region "Propiedades"

        Public Property idAcabado() As Integer
            Get
                Return _idAcabado
            End Get
            Set(ByVal value As Integer)
                _idAcabado = value
            End Set
        End Property
        Public Property version() As Integer
            Get
                Return _versionCosto
            End Get
            Set(value As Integer)
                _versionCosto = value
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
                Return _valorCosto
            End Get
            Set(ByVal value As Decimal)
                _valorCosto = value
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
        Public Property acabado() As String
            Get
                Return _acabado
            End Get
            Set(ByVal value As String)
                _acabado = value
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
        Public Sub New(id As Integer, usuarioCreacion As String, fechaCreacion As DateTime, idAcabado As Integer, acabado As String,
                       version As Integer, nuevaVersion As Integer, Costo As Decimal, nuevoCosto As Decimal)
            Try
                Me.Id = id
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                Me.FechaCreacion = fechaCreacion
                _idAcabado = idAcabado
                _acabado = Trim(acabado)
                _versionCosto = version
                _nuevaVersion = nuevaVersion
                _valorCosto = Costo
                _nuevoCosto = nuevoCosto
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Namespace

