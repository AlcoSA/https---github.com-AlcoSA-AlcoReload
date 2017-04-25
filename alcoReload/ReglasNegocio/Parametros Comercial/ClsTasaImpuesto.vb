Imports Datos
Namespace TasaImpuesto
    Public Class ClsTasaImpuesto
#Region "Variables"
        Private taTasaImpuesto As New dsAlcoComercialTableAdapters.tc007_tasaImpuestoTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
        ''' <summary>
        ''' Inserta un nuevo registro de tasa impuesto en la base de datos
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <param name="descripcion"></param>
        ''' <param name="idEstado"></param>
        ''' <param name="sigla"></param>
        ''' <param name="tasa"></param>
        Public Sub Ingresar(usuario As String, descripcion As String, idEstado As Integer, sigla As String,
                            tasa As Decimal, valorDefecto As Integer)
            Try
                taTasaImpuesto.sp_tc007_insert(usuario, descripcion, idEstado, sigla, tasa, valorDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        ''' <summary>
        ''' Procedimiento que actualiza la informacion de la tasa segun el id recibido
        ''' </summary>
        ''' <param name="descripcion"></param>
        ''' <param name="usuarioModi"></param>
        ''' <param name="idEstado"></param>
        ''' <param name="sigla"></param>
        ''' <param name="tasa"></param>
        ''' <param name="id"></param>
        Public Sub Modificar(descripcion As String, usuarioModi As String, idEstado As Integer, sigla As String,
                             tasa As Decimal, id As Integer, valorxDefecto As Integer)
            Try
                taTasaImpuesto.sp_tc007_update(usuarioModi, descripcion, idEstado, sigla, tasa, id, valorxDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        'Public Function TraerxValorDefecto() As List(Of tasaImpuesto)
        '    TraerxValorDefecto = New List(Of tasaImpuesto)
        '    Try
        '        Dim taAll As New dsAlcoComercialTableAdapters.sp_tc007_selectByValorDefectoTableAdapter
        '        Dim txAll As dsAlcoComercial.sp_tc007_selectByValorDefectoDataTable = taAll.GetData()
        '        For Each ti As dsAlcoComercial.sp_tc007_selectByValorDefectoRow In txAll.Rows
        '            TraerxValorDefecto.Add(New tasaImpuesto(ti.id_Tasa, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Descripcion,
        '                                                        ti.Sigla, ti.Tasa, ti.Usuario_Modi, ti.Fecha_Modi, ti.id_Estado, ti.Estado,
        '                                                        ti.ValorPorDefecto))
        '        Next
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message, ex.InnerException)
        '    End Try
        'End Function
        'Public Function ExisteValorDefecto() As Boolean
        '    Try
        '        Dim taAll As New dsAlcoComercialTableAdapters.sp_tc007_selectExistValorDefectoTableAdapter
        '        Dim txAll As dsAlcoComercial.sp_tc007_selectExistValorDefectoDataTable = taAll.GetData()
        '        If txAll.Rows.Count > 0 Then Return True
        '        Return False
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message, ex.InnerException)
        '    End Try
        'End Function

        ''' <summary>
        ''' Obtiene todos los registros de tasa impuesto activos e inactivos
        ''' </summary>
        ''' <returns></returns>
        Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of tasaImpuesto)
            traerTodos = New List(Of tasaImpuesto)
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc007_selectAllTableAdapter
                Dim txall As dsAlcoComercial.sp_tc007_selectAllDataTable = taAll.GetData()
                For Each ti As dsAlcoComercial.sp_tc007_selectAllRow In txall.Rows
                    traerTodos.Add(New tasaImpuesto(ti.id_Tasa, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Descripcion, ti.Sigla, ti.Tasa,
                                                    ti.Usuario_Modi, ti.Fecha_Modi, ti.id_Estado, ti.Estado, ti.Valor_Defecto))
                Next
                If txall.Rows.Count > 0 Then
                    dt = txall.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de tasa impuesto correspondiente al Id
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function TraerxId(id As Integer) As tasaImpuesto
            Try
                TraerxId = New tasaImpuesto
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc007_selectByIdTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc007_selectByIdDataTable = taAll.GetData(id)
                    If txid.Rows.Count > 0 Then
                        Dim ti As dsAlcoComercial.sp_tc007_selectByIdRow = DirectCast(txid.Rows(0), dsAlcoComercial.sp_tc007_selectByIdRow)
                        TraerxId = New tasaImpuesto(ti.id_Tasa_Impuesto, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Descripcion, ti.Sigla,
                                                    ti.Tasa, ti.Usuario_Modi, ti.Fecha_Modi, ti.Id_Estado, ti.Estado, ti.valorPorDefecto)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de tasa impuesto con la sigla indicada
        ''' </summary>
        ''' <param name="sigla"></param>
        ''' <returns></returns>
        Public Function TraerxSigla(sigla As String) As List(Of tasaImpuesto)
            Try
                TraerxSigla = New List(Of tasaImpuesto)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc007_selectBySiglaTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc007_selectBySiglaDataTable = taAll.GetData(sigla)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc007_selectBySiglaRow In txid
                            TraerxSigla.Add(New tasaImpuesto(ti.id_Tasa_Impuesto, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Descripcion, ti.Sigla,
                                                             ti.Tasa, ti.Usuario_Modi, ti.Fecha_Modi, ti.Id_Estado, ti.Estado, ti.valorPorDefecto))
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
        ''' Obtiene todos los registros de tasas de impuesto según el estado indicado
        ''' </summary>
        ''' <param name="idEstado"></param>
        ''' <returns></returns>
        Public Function TraerxEstado(idEstado As Integer) As List(Of tasaImpuesto)
            Try
                TraerxEstado = New List(Of tasaImpuesto)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc007_SelectByEstadoTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc007_SelectByEstadoDataTable = taAll.GetData(idEstado)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc007_SelectByEstadoRow In txid
                            TraerxEstado.Add(New tasaImpuesto(ti.id_Tasa_Impuesto, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Descripcion, ti.Sigla,
                                                              ti.Tasa, ti.Usuario_Modi, ti.Fecha_Modi, ti.Id_Estado, ti.Estado, ti.valorPorDefecto))
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
    Public Class tasaImpuesto
        Inherits ClsBaseParametros
#Region "Variables"
        Private _descripcion As String = String.Empty
        Private _sigla As String = String.Empty
        Private _tasa As Decimal = 0
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
        Public Property sigla() As String
            Get
                Return _sigla
            End Get
            Set(ByVal value As String)
                _sigla = value
            End Set
        End Property
        Public Property tasa() As Decimal
            Get
                Return _tasa
            End Get
            Set(ByVal value As Decimal)
                _tasa = value
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
                       sigla As String, tasa As Decimal, usuarioModi As String, fechaModi As Date,
                       idEstado As Integer, estado As String, valorPorDefecto As Integer)
            Try
                Me.Id = id
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                Me.FechaCreacion = fechaCreacion
                _descripcion = Trim(descripcion)
                _sigla = Trim(sigla)
                _tasa = tasa
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

