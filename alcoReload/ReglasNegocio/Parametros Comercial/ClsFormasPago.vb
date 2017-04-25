Imports Datos
Namespace FormasPago
    Public Class ClsFormasPago
#Region "Variables"
        Private taFormasPago As New dsAlcoComercialTableAdapters.tc005_formasPagoTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
        ''' <summary>
        ''' Inserta un nuevo registro de formas de pago en la base de datos
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <param name="descripcion"></param>
        ''' <param name="idEstado"></param>
        Public Sub Ingresar(usuario As String, descripcion As String, idEstado As Integer, valorPorDefecto As Integer)
            Try
                taFormasPago.sp_tc005_insert(usuario, descripcion, idEstado, valorPorDefecto)
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
        ''' <param name="id"></param>
        Public Sub Modificar(descripcion As String, usuarioModi As String, idEstado As Integer, id As Integer, valorPorDefecto As Integer)
            Try
                taFormasPago.sp_tc005_update(descripcion, usuarioModi, idEstado, id, valorPorDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        '''' <summary>
        '''' Obtiene la forma de pago por defecto para que sea primera en el combo box
        '''' </summary>
        '''' <returns></returns>
        'Public Function TraerxValorDefecto() As List(Of formaPago)
        '    TraerxValorDefecto = New List(Of formaPago)
        '    Try
        '        Dim taAll As New dsAlcoComercialTableAdapters.sp_tc005_selectByValorDefectoTableAdapter
        '        Dim txAll As dsAlcoComercial.sp_tc005_selectByValorDefectoDataTable = taAll.GetData()
        '        For Each ti As dsAlcoComercial.sp_tc005_selectByValorDefectoRow In txAll.Rows
        '            TraerxValorDefecto.Add(New formaPago(ti.id_Forma_Pago, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Forma_de_Pago,
        '                                                     ti.Usuario_Modi, ti.Fecha_Modi, ti.id_Estado, ti.Estado, ti.valorPorDefecto))
        '        Next
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message, ex.InnerException)
        '    End Try
        'End Function

        'Public Function ExisteValorDefecto() As Boolean
        '    Try
        '        Dim taAll As New dsAlcoComercialTableAdapters.sp_tc005_selectExistValorDefectoTableAdapter
        '        Dim txAll As dsAlcoComercial.sp_tc005_selectExistValorDefectoDataTable = taAll.GetData()
        '        If txAll.Rows.Count > 0 Then Return True
        '        Return False
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message, ex.InnerException)
        '    End Try
        'End Function

        ''' <summary>
        ''' Obtiene todos los registros de formas de pago activos e inactivos
        ''' </summary>
        ''' <returns></returns>
        Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of formaPago)
            traerTodos = New List(Of formaPago)
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc005_selectAllTableAdapter
                Dim txall As dsAlcoComercial.sp_tc005_selectAllDataTable = taAll.GetData()
                For Each ti As dsAlcoComercial.sp_tc005_selectAllRow In txall.Rows
                    traerTodos.Add(New formaPago(ti.id_Forma_Pago, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Forma_Pago, ti.Usuario_Modi,
                                                     ti.Fecha_Modi, ti.id_Estado, ti.Estado, ti.valor_Defecto))
                Next
                If txall.Rows.Count > 0 Then
                    dt = txall.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de forma de pago correspondiente al Id
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function TraerxId(id As Integer) As formaPago
            Try
                TraerxId = New formaPago
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc005_selectByIdTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc005_selectByIdDataTable = taAll.GetData(id)
                    If txid.Rows.Count > 0 Then
                        Dim ti As dsAlcoComercial.sp_tc005_selectByIdRow = DirectCast(txid.Rows(0), dsAlcoComercial.sp_tc005_selectByIdRow)
                        TraerxId = New formaPago(ti.id_Forma_Pago, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Forma_de_Pago, ti.Usuario_Modi,
                                                 ti.Fecha_Modi, ti.id_Estado, ti.Estado, ti.valorPorDefecto)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de forma de pago con la descripción indicada
        ''' </summary>
        ''' <param name="descripcion"></param>
        ''' <returns></returns>
        Public Function TraerxDescripcion(descripcion As String) As Boolean
            Try
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc005_selectByDescripcionTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc005_selectByDescripcionDataTable = taAll.GetData(descripcion)
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
        ''' Obtiene todos los registros de estados según el estado indicado
        ''' </summary>
        ''' <param name="idEstado"></param>
        ''' <returns></returns>
        Public Function TraerxEstado(idEstado As Integer) As List(Of formaPago)
            Try
                TraerxEstado = New List(Of formaPago)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc005_selectByEstadoTableAdapter
                    Dim txFP As dsAlcoComercial.sp_tc005_selectByEstadoDataTable = taAll.GetData(idEstado)
                    If txFP.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc005_selectByEstadoRow In txFP.Rows
                            TraerxEstado.Add(New formaPago(ti.id_Forma_Pago, ti.Usuario_Creacion, ti.Fecha_Creacion,
                                                           ti.Forma_de_Pago, ti.Usuario_Modi, ti.Fecha_Modi, idEstado,
                                                           ti.Estado, ti.valorPorDefecto))
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
    Public Class formaPago
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
        Public Property valorPorDefecto As Integer
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
                       fechaModi As DateTime, idEstado As Integer, estado As String, valorPorDefecto As Integer)
            Try
                Me.Id = id
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                Me.FechaCreacion = fechaCreacion
                _descripcion = Trim(descripcion)
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

