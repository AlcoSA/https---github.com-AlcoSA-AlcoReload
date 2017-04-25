Imports Datos
Namespace tipoCubuerta
    Public Class ClsTipoCubierta
#Region "Variables"
        Private taTipoCubierta As New dsAlcoComercialTableAdapters.tc013_tipoCubiertaTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
        ''' <summary>
        ''' Inserta un nuevo registro de tipo cubierta en la base de datos
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <param name="descripcion"></param>
        ''' <param name="idEstado"></param>
        Public Sub Ingresar(usuario As String, descripcion As String, idEstado As Integer, valorDefecto As Integer)
            Try
                taTipoCubierta.sp_tc013_insert(usuario, descripcion, idEstado, valorDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Actualiza el registro correspondiente al Id en la base de datos
        ''' </summary>
        ''' <param name="descripcion"></param>
        ''' <param name="usuario"></param>
        ''' <param name="idestado"></param>
        ''' <param name="id"></param>
        Public Sub Modificar(descripcion As String, usuario As String, idestado As Integer, id As Integer, valorDefecto As Integer)
            Try
                taTipoCubierta.sp_tc013_update(descripcion, usuario, idestado, id, valorDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Obtiene todos los registros de tipo cubierta activos e inactivos
        ''' </summary>
        ''' <returns></returns>
        Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of tipoCubuertas)
            traerTodos = New List(Of tipoCubuertas)
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc013_selectAllTableAdapter
                Dim txall As dsAlcoComercial.sp_tc013_selectAllDataTable = taAll.GetData()
                For Each ti As dsAlcoComercial.sp_tc013_selectAllRow In txall.Rows
                    traerTodos.Add(New tipoCubuertas(ti.Id_Tipo_Cubierta, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Tipo_Cubierta,
                                                     ti.Usuario_Modi, ti.Fecha_Modi, ti.id_Estado, ti.valor_Defecto))
                Next
                If txall.Rows.Count > 0 Then
                    dt = txall.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de tipo cubierta correspondiente al Id
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function TraerxId(id As Integer) As tipoCubuertas
            Try
                TraerxId = New tipoCubuertas
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc013_selectByIdTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc013_selectByIdDataTable = taAll.GetData(id)
                    If txid.Rows.Count > 0 Then
                        Dim ti As dsAlcoComercial.sp_tc013_selectByIdRow = DirectCast(txid.Rows(0), dsAlcoComercial.sp_tc013_selectByIdRow)
                        TraerxId = New tipoCubuertas(ti.Id_Tipo_Cubierta, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Tipo_Cubierta, ti.Usuario_Modi,
                                                     ti.Fecha_Modi, ti.id_Estado, ti.valorPorDefecto)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de tipo cubierta con la descripción indicada
        ''' </summary>
        ''' <param name="descripcion"></param>
        ''' <returns></returns>
        Public Function TraerxDescripcion(descripcion As String) As Boolean
            Try
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc013_selectByDescripcionTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc013_selectByDescripcionDataTable = taAll.GetData(descripcion)
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
        ''' Obtiene todos los registros de tipo cubierta según el estado indicado
        ''' </summary>
        ''' <param name="idEstado"></param>
        ''' <returns></returns>
        Public Function TraerxEstado(idEstado As Integer) As List(Of tipoCubuertas)
            Try
                TraerxEstado = New List(Of tipoCubuertas)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc013_selectByEstadoTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc013_selectByEstadoDataTable = taAll.GetData(idEstado)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc013_selectByEstadoRow In txid
                            TraerxEstado.Add(New tipoCubuertas(ti.Id_Tipo_Cubierta, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Tipo_Cubierta,
                                                               ti.Usuario_Modi, ti.Fecha_Modi, ti.id_Estado, ti.valorPorDefecto))
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
    Public Class tipoCubuertas
        Inherits ClsBaseParametros
#Region "Variables"
        Private _Descripcion As String = String.Empty
        Private _valorDefecto As Integer = 0
#End Region
#Region "Propiedades"

        Public Property Descripcion() As String
            Get
                Return _Descripcion
            End Get
            Set(ByVal value As String)
                _Descripcion = value
            End Set
        End Property

        Public Property valorDefecto() As Integer
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
                       fechaModi As DateTime, idEstado As Integer, valorDefecto As Integer)
            Try
                Me.Id = id
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                Me.FechaCreacion = fechaCreacion
                _Descripcion = descripcion
                _valorDefecto = valorDefecto
                Me.UsuarioModificacion = Trim(usuarioModi)
                Me.FechaModificacion = fechaModi
                Me.IdEstado = idEstado
                '  Me.Estado = estado
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Namespace

