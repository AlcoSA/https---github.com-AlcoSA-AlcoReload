Imports Datos
Namespace CostoNivel
    Public Class ClsCostoNivel
#Region "Variables"
        Private taCostoNivel As New dsAlcoComercialTableAdapters.tc004_costosNivelesTableAdapter
#End Region
#Region "Procedimientos"
        ''' <summary>
        ''' Inserta la nueva versión de costos de niveles
        ''' </summary>
        ''' <param name="idNivel"></param>
        ''' <param name="version"></param>
        ''' <param name="costo"></param>
        ''' <param name="motivoCreacion"></param>
        ''' <param name="usuarioCreacion"></param>
        Public Sub Ingresar(idNivel As Integer, version As Integer, costo As Decimal,
                            motivoCreacion As String, usuarioCreacion As String)
            Try
                taCostoNivel.sp_tc004_insert(idNivel, version, costo, motivoCreacion, usuarioCreacion)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Obtiene los los costos de nivel correspondientes a la versión indicada
        ''' </summary>
        ''' <param name="versionBase"></param>
        ''' <param name="dt"></param>
        ''' <returns></returns>
        Public Function TraerTodos(versionBase As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of CostoNivel)
            Try
                TraerTodos = New List(Of CostoNivel)
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc004_selectAllTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc004_selectAllDataTable = taAll.GetData(versionBase)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoComercial.sp_tc004_selectAllRow In txAll
                        TraerTodos.Add(New CostoNivel(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idNivel, ti.nivel,
                                                      ti.version, ti.nuevaVersion, ti.costo, ti.nuevoCosto, ti.motivoCreacion))
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene la última versión del costo nivel
        ''' </summary>
        ''' <returns></returns>
        Public Function TraerMaxVersion() As Integer
            Try
                Return Convert.ToInt32(taCostoNivel.sp_tc004_selectMaxVersion())
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el costo correspondiente al Id indicado en su última versión
        ''' </summary>
        ''' <param name="idNivel"></param>
        ''' <returns></returns>
        Public Function TraerxId(idNivel As Integer) As Decimal
            Try
                Return Convert.ToDecimal(taCostoNivel.sp_tc004_selectByIdAndMaxVersion(idNivel))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
#End Region
    End Class
    Public Class CostoNivel
        Inherits ClsBaseParametros
#Region "Variables"
        Private _idNivel As Integer = 0
        Private _nivel As String = String.Empty
        Private _versionCosto As Integer
        Private _nuevaVersion As Integer
        Private _valorCosto As Decimal = 0
        Private _nuevoCosto As Decimal
        Private _motivo As String = String.Empty
#End Region
#Region "Propiedades"
        Public Property idNivel() As Integer
            Get
                Return _idNivel
            End Get
            Set(ByVal value As Integer)
                _idNivel = value
            End Set
        End Property
        Public Property Nivel() As String
            Get
                Return _nivel
            End Get
            Set(ByVal value As String)
                _nivel = value
            End Set
        End Property
        Public Property VersionCosto() As Integer
            Get
                Return _versionCosto
            End Get
            Set(ByVal value As Integer)
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
        Public Property valorCosto() As Decimal
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
        Public Property motivo() As String
            Get
                Return _motivo
            End Get
            Set(ByVal value As String)
                _motivo = value
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
        Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String,
                       idNivel As Integer, nivel As String, version As Integer, nuevaVersion As Integer,
                       costo As Decimal, nuevoCosto As Decimal, motivo As String)
            Try
                Me.Id = id
                Me.FechaCreacion = fechaCreacion
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                _idNivel = idNivel
                _nivel = Trim(nivel)
                _versionCosto = version
                _nuevaVersion = nuevaVersion
                _valorCosto = costo
                _nuevoCosto = nuevoCosto
                _motivo = Trim(motivo)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Namespace
