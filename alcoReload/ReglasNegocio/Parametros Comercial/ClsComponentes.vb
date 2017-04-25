Imports Datos
Namespace Componente
    Public Class ClsComponentes
#Region "Variables"
        Private taComponentes As New dsAlcoComercialTableAdapters.tc025_ComponenteTableAdapter
#End Region

#Region "Procedimientos"
        ''' <summary>
        ''' Inserta un nuevo registro de componentes en la base de datos
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <param name="descripcion"></param>
        ''' <param name="idEstado"></param>
        Public Sub Ingresar(usuario As String, descripcion As String, idEstado As Integer,
                            valorDefecto As Integer)
            Try
                taComponentes.sp_tc025_insert(usuario, descripcion, idEstado, valorDefecto)
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
        Public Sub Modificar(descripcion As String, usuario As String, idEstado As Integer,
                             id As Integer, valorDefecto As Integer)
            Try
                taComponentes.sp_tc025_update(descripcion, usuario, idEstado, id, valorDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Obtiene todos los registros de componentes activos e inactivos
        ''' </summary>
        ''' <returns></returns>
        Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of componente)
            Try
                TraerTodos = New List(Of componente)
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc025_selectAllTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc025_selectAllDataTable = taAll.GetData()
                For Each ti As dsAlcoComercial.sp_tc025_selectAllRow In txAll.Rows
                    TraerTodos.Add(New componente(ti.Id, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Descripcion,
                                                      ti.Usuario_Modi, ti.Fecha_Modi, ti.Id_Estado, ti.Estado, ti.valor_Defecto))
                Next
                If txAll.Rows.Count > 0 Then
                    dt = txAll.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de componentes correspondiente al Id
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function TraerxId(id As Integer) As List(Of componente)
            Try
                TraerxId = New List(Of componente)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc025_selectByIdTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc025_selectByIdDataTable = taAll.GetData(id)
                    If txid.Rows.Count > 0 Then
                        Dim ti As dsAlcoComercial.sp_tc025_selectByIdRow = DirectCast(txid.Rows(0), dsAlcoComercial.sp_tc025_selectByIdRow)
                        TraerxId.Add(New componente(ti.Id, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Descripcion,
                                                  ti._Usuario_Ult__Modi, ti._Fecha_Ult__Modi, ti.Estado, "",
                                                  ti.valorPorDefecto))
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene todos los registros de componentes según el estado indicado
        ''' </summary>
        ''' <param name="idEstado"></param>
        ''' <returns></returns>
        Public Function TraerxEstado(idEstado As Integer) As List(Of componente)
            Try
                TraerxEstado = New List(Of componente)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc025_selectByEstadoTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc025_selectByEstadoDataTable = taAll.GetData(idEstado)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc025_selectByEstadoRow In txid.Rows
                            TraerxEstado.Add(New componente(ti.Id, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Descripcion,
                                                            ti._Usuario_Ult__Modi, ti._Fecha_Ult__Modi,
                                                            ti.Estado, "", ti.valorPorDefecto))
                        Next
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene la lista de componentes correspondientes al tipo de cotización seleccionado
        ''' </summary>
        ''' <param name="idTipoCotiza"></param>
        ''' <returns></returns>
        Public Function TraerxIdTipoCotizacion(idTipoCotiza As Integer) As List(Of componente)
            Try
                TraerxIdTipoCotizacion = New List(Of componente)
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc025_selectByIdTipoObraTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc025_selectByIdTipoObraDataTable = taAll.GetData(idTipoCotiza)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoComercial.sp_tc025_selectByIdTipoObraRow In txAll.Rows
                        TraerxIdTipoCotizacion.Add(New componente(ti.id, ti.usuarioCreccion, ti.fechaCreacion, ti.descripcion,
                                                                  ti.usuarioModi, ti.fechaModi, ti.estado, "", ti.valorDefecto))
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de componentes con la descripción indicada
        ''' </summary>
        ''' <param name="descripcion"></param>
        ''' <returns></returns>
        Public Function traerxDescripcion(descripcion As String) As Boolean
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc025_selectByDescripcionTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc025_selectByDescripcionDataTable = taAll.GetData(descripcion)
                If txAll.Rows.Count > 0 Then Return True
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
#End Region
    End Class
    Public Class componente
        Inherits ClsBaseParametros
#Region "Variables"
        Private _Descripcion As String = String.Empty
        Private _valorDefecto As Integer
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
        Public Sub New(id As Integer, usuarioCreacion As String, fechaCreacion As DateTime, descripcion As String,
                       usuarioModi As String, fechaModi As DateTime, IdEstado As Integer, estado As String, valorDefecto As Integer)
            Try
                Me.Id = id
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                Me.FechaCreacion = fechaCreacion
                _Descripcion = Trim(descripcion)
                _valorDefecto = valorDefecto
                Me.UsuarioModificacion = Trim(usuarioModi)
                Me.FechaModificacion = fechaModi
                Me.IdEstado = IdEstado
                Me.Estado = estado
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Namespace
