Imports Datos
Namespace TiempoEntrega
    Public Class ClsTiempoEntrega
#Region "Variables"
        Private taTiempoEntrega As New dsAlcoComercialTableAdapters.tc006_tiemposEntregaTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
        ''' <summary>
        ''' Inserta un nuevo registro de tiempo de entrega en la base de datos
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <param name="descripcion"></param>
        ''' <param name="idEstado"></param>
        ''' <param name="motivo"></param>
        ''' <param name="valorPorDefecto"></param>
        ''' <param name="dias"></param>
        Public Sub Ingresar(usuario As String, descripcion As String, idEstado As Integer, motivo As String, valorPorDefecto As Integer, dias As Integer)
            Try
                taTiempoEntrega.sp_tc006_insert(usuario, dias, descripcion, motivo, idEstado, valorPorDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Actualiza el registro correspondiente al Id en la base de datos
        ''' </summary>
        ''' <param name="descripcion"></param>
        ''' <param name="usuarioModi"></param>
        ''' <param name="idEstado"></param>
        ''' <param name="motivo"></param>
        ''' <param name="id"></param>
        ''' <param name="valorPorDefecto"></param>
        ''' <param name="dias"></param>
        Public Sub Modificar(descripcion As String, usuarioModi As String, idEstado As Integer, motivo As String, id As Integer,
                             valorPorDefecto As Integer, dias As Integer)
            Try
                taTiempoEntrega.sp_tc006_update(descripcion, dias, usuarioModi, idEstado, motivo, id, valorPorDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Obtiene todos los registros de tiempo entrega activos e inactivos
        ''' </summary>
        ''' <returns></returns>
        Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of tiempoEntrega)
            traerTodos = New List(Of tiempoEntrega)
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc006_selectAllTableAdapter
                Dim txall As dsAlcoComercial.sp_tc006_selectAllDataTable = taAll.GetData()
                For Each ti As dsAlcoComercial.sp_tc006_selectAllRow In txall.Rows
                    traerTodos.Add(New tiempoEntrega(ti.id_Tiempo_Entrega, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Tiempo_Entrega,
                                                     ti.Usuario_Modi, ti.Fecha_Creacion, ti.Id_Estado, ti.Estado, ti.Motivo_Creacion, ti.valor_Defecto,
                                                     ti.dias))
                Next
                If txall.Rows.Count > 0 Then
                    dt = txall.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de tiempo entrega correspondiente al Id
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function TraerxId(id As Integer) As tiempoEntrega
            Try
                TraerxId = New tiempoEntrega
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc006_selectByIdTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc006_selectByIdDataTable = taAll.GetData(id)
                    If txid.Rows.Count > 0 Then
                        Dim ti As dsAlcoComercial.sp_tc006_selectByIdRow = DirectCast(txid.Rows(0), dsAlcoComercial.sp_tc006_selectByIdRow)
                        TraerxId = New tiempoEntrega(ti.id_Tiempo_Entrega, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Tiempo_Entrega,
                                                     ti.Usuario_Modi, ti.Fecha_Creacion, ti.Id_Estado, ti.Estado, ti.Motivo_Creacion, ti.valorPorDefecto,
                                                     ti.dias)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de tiempo entrega con la descripción indicada
        ''' </summary>
        ''' <param name="nombre"></param>
        ''' <returns></returns>
        Public Function TraerxDescripcion(nombre As String) As Boolean
            Try
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc006_selectByDescripcionTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc006_selectByDescripcionDataTable = taAll.GetData(nombre)
                    If txid.Rows.Count > 0 Then Return True
                    Return False
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene todos los registros de tiempo entrega según el estado indicado
        ''' </summary>
        ''' <param name="idEstado"></param>
        ''' <returns></returns>
        Public Function TraerxEstado(idEstado As Integer) As List(Of tiempoEntrega)
            Try
                TraerxEstado = New List(Of tiempoEntrega)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc006_selectByEstadoTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc006_selectByEstadoDataTable = taAll.GetData(idEstado)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc006_selectByEstadoRow In txid.Rows
                            TraerxEstado.Add(New tiempoEntrega(ti.id_Tiempo_Entrega, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Tiempo_Entrega,
                                                               ti.Usuario_Modi, ti.Fecha_Creacion, ti.Id_Estado, ti.Estado, ti.Motivo_Creacion,
                                                               ti.valorPorDefecto, ti.dias))
                        Next
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
#End Region
#Region "Funciones"

#End Region
    End Class
    Public Class tiempoEntrega
        Inherits ClsBaseParametros
#Region "Variables"
        Private _descripcion As String = String.Empty
        Private _motivo As String = String.Empty
        Private _valorDefecto As Integer = 0
        Private _dias As Integer = 0
#End Region
#Region "Propiedades"
        Public Property descripcion As String
            Get
                Return _descripcion
            End Get
            Set(ByVal value As String)
                _descripcion = value
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
        Public Property valorPorDefecto As Integer
            Get
                Return _valorDefecto
            End Get
            Set(ByVal value As Integer)
                _valorDefecto = value
            End Set
        End Property
        Public Property dias() As Integer
            Get
                Return _dias
            End Get
            Set(ByVal value As Integer)
                _dias = value
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
        Public Sub New(id As Integer, usuarioCreacion As String, fechaCreacion As DateTime, descripcion As String, usuarioModi As String,
                       fechaModi As Date, idEstado As Integer, estado As String, motivo As String, valorPorDefecto As Integer, dias As Integer)
            Try
                Me.Id = id
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                Me.FechaCreacion = fechaCreacion
                _descripcion = Trim(descripcion)
                _motivo = Trim(motivo)
                _valorDefecto = valorPorDefecto
                _dias = dias
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
End Namespace

