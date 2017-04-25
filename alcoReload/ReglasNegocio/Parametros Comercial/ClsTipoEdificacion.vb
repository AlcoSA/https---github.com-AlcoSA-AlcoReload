Imports Datos
Namespace tipoEdificacion
    Public Class ClsTipoEdificacion
#Region "Variables"
        Private taTipoEdificacion As New dsAlcoComercialTableAdapters.tc010_tipoedificacionTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
        ''' <summary>
        ''' Inserta un nuevo registro de tipo edificación en la base de datos
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <param name="descripcion"></param>
        ''' <param name="idEstado"></param>
        Public Sub Ingresar(usuario As String, descripcion As String, idEstado As Integer, valorDefecto As Integer)
            Try
                taTipoEdificacion.sp_tc010_insert(usuario, descripcion, idEstado, valorDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Actualiza el registro correspondiente al Id en la base de datos
        ''' </summary>
        ''' <param name="Descripcion"></param>
        ''' <param name="usuarioModi"></param>
        ''' <param name="idEstado"></param>
        ''' <param name="id"></param>
        Public Sub Modificar(Descripcion As String, usuarioModi As String, idEstado As Integer, id As Integer, valorDefecto As Integer)
            Try
                taTipoEdificacion.sp_tc010_update(Descripcion, usuarioModi, idEstado, id, valorDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Obtiene todos los registros de tipo edificación activos e inactivos
        ''' </summary>
        ''' <returns></returns>
        Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of tipoEdificacion)
            Try
                traerTodos = New List(Of tipoEdificacion)
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc010_selectAllTableAdapter
                Dim txall As dsAlcoComercial.sp_tc010_selectAllDataTable = taAll.GetData()
                For Each ti As dsAlcoComercial.sp_tc010_selectAllRow In txall.Rows
                    traerTodos.Add(New tipoEdificacion(ti.id_Tipo_Edificacion, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Tipo_Edificacion,
                                                       ti.Usuario_Creacion, ti.Fecha_Modi, ti.id_Estado, ti.Estado, ti.valor_Defecto))
                Next
                If txall.Rows.Count > 0 Then
                    dt = txall.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de tipo edificación correspondiente al Id
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function TraerxId(id As Integer) As tipoEdificacion
            Try
                TraerxId = New tipoEdificacion
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc010_selectByIdTableAdapter
                Dim txid As dsAlcoComercial.sp_tc010_selectByIdDataTable = taAll.GetData(id)
                If txid.Rows.Count > 0 Then
                    Dim ti As dsAlcoComercial.sp_tc010_selectByIdRow = DirectCast(txid.Rows(0), dsAlcoComercial.sp_tc010_selectByIdRow)
                    TraerxId = New tipoEdificacion(ti.id_Tipo_Edificacion, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Tipo_Edificacion,
                                                       ti.Usuario_Creacion, ti.Fecha_Modi, ti.id_Estado, ti.Estado, ti.valorDefecto)
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de tipo edificación con la descripción indicada
        ''' </summary>
        ''' <param name="Descripcion"></param>
        ''' <returns></returns>
        Public Function TraerxDescripcion(Descripcion As String) As Boolean
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc010_selectByDescripcionTableAdapter
                Dim txid As dsAlcoComercial.sp_tc010_selectByDescripcionDataTable = taAll.GetData(Descripcion)
                If txid.Rows.Count > 0 Then Return True
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene todos los registros de tipo edificación según el estado indicado
        ''' </summary>
        ''' <param name="idEstado"></param>
        ''' <returns></returns>
        Public Function TraerxEstado(idEstado As Integer) As List(Of tipoEdificacion)
            Try
                TraerxEstado = New List(Of tipoEdificacion)
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc010_selectByEstadoTableAdapter
                Dim txid As dsAlcoComercial.sp_tc010_selectByEstadoDataTable = taAll.GetData(idEstado)
                If txid.Rows.Count > 0 Then
                    For Each ti As dsAlcoComercial.sp_tc010_selectByEstadoRow In txid.Rows
                        TraerxEstado.Add(New tipoEdificacion(ti.id_Tipo_Edificacion, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Tipo_Edificacion,
                                                                 ti.Usuario_Creacion, ti.Fecha_Modi, ti.id_Estado, ti.Estado, ti.valorDefecto))
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
    Public Class tipoEdificacion
        Inherits ClsBaseParametros
#Region "Variables"

        Private _descripcion As String = String.Empty
        Private _valorDefecto As Integer = 0

#End Region
#Region "Propiedades"
        Public Property descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal value As String)
                _descripcion = value
            End Set
        End Property
        Public Property valorDefecto As Integer
            Get
                Return _valorDefecto
            End Get
            Set(ByVal value As Integer)
                _valorDefecto = value
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
                       fechaModi As Date, idEstado As Integer, estado As String, valorPorDefecto As Integer)
            Try
                Me.Id = id
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                Me.FechaCreacion = fechaCreacion
                _descripcion = descripcion
                _valorDefecto = valorPorDefecto
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

