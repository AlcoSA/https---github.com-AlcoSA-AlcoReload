Imports Datos
Namespace grupoUso
    Public Class ClsGrupoUso
#Region "Variables"
        Private taGrupoUso As New dsAlcoComercialTableAdapters.tc011_gruposUsoTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
        ''' <summary>
        ''' Inserta un nuevo registro de grupo de uso en la base de datos
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <param name="descripcion"></param>
        ''' <param name="idEstado"></param>
        Public Sub Ingresar(usuario As String, descripcion As String, idEstado As Integer, valorPorDefecto As Integer)
            Try
                taGrupoUso.sp_tc011_insert(usuario, descripcion, idEstado, valorPorDefecto)
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
        Public Sub Modificar(descripcion As String, usuario As String, idestado As Integer, id As Integer, valorPorDefecto As Integer)
            Try
                taGrupoUso.sp_tc011_update(descripcion, usuario, idestado, id, valorPorDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Obtiene todos los registros de grupo de uso activos e inactivos
        ''' </summary>
        ''' <returns></returns>
        Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of grupoUso)
            traerTodos = New List(Of grupoUso)
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc011_selectAllTableAdapter
                Dim txall As dsAlcoComercial.sp_tc011_selectAllDataTable = taAll.GetData()
                For Each ti As dsAlcoComercial.sp_tc011_selectAllRow In txall.Rows
                    traerTodos.Add(New grupoUso(ti.Id_Grupo_Uso, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Grupo_Uso, ti.Usuario_Modi,
                                                    ti.Fecha_Modi, ti.Id_Estado, ti.valor_Defecto))
                Next
                If txall.Rows.Count > 0 Then
                    dt = txall.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de grupo de uso correspondiente al Id
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function TraerxId(id As Integer) As grupoUso
            Try
                TraerxId = New grupoUso
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc011_selectByIdTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc011_selectByIdDataTable = taAll.GetData(id)
                    If txid.Rows.Count > 0 Then
                        Dim ti As dsAlcoComercial.sp_tc011_selectByIdRow = DirectCast(txid.Rows(0), dsAlcoComercial.sp_tc011_selectByIdRow)
                        TraerxId = New grupoUso(ti.Id_Grupo_Uso, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Grupo_Uso, ti.Usuario_Modi,
                                                ti.Fecha_Modi, ti.Id_Estado, ti.valorPorDefecto)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de grupo de uso con la descripción indicada
        ''' </summary>
        ''' <param name="descripcion"></param>
        ''' <returns></returns>
        Public Function TraerxDescripcion(descripcion As String) As Boolean
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc011_selectByDescripcionTableAdapter
                Dim txid As dsAlcoComercial.sp_tc011_selectByDescripcionDataTable = taAll.GetData(descripcion)
                If txid.Rows.Count > 0 Then Return True
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene todos los registros de grupos de uso según el estado indicado
        ''' </summary>
        ''' <param name="idEstado"></param>
        ''' <returns></returns>
        Public Function TraerxEstado(idEstado As Integer) As List(Of grupoUso)
            Try
                TraerxEstado = New List(Of grupoUso)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc011_selectByEstadoTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc011_selectByEstadoDataTable = taAll.GetData(idEstado)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc011_selectByEstadoRow In txid.Rows
                            TraerxEstado.Add(New grupoUso(ti.Id_Grupo_Uso, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Grupo_Uso,
                                                          ti.Usuario_Modi, ti.Fecha_Modi, ti.Id_Estado, ti.valorPorDefecto))
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
    Public Class grupoUso
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
                       fechaModi As DateTime, idEstado As Integer, valorPorDefecto As Integer)
            Try
                Me.Id = id
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                Me.FechaCreacion = fechaCreacion
                _Descripcion = descripcion
                _valorDefecto = valorPorDefecto
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

