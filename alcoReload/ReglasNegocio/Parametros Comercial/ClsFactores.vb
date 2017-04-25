Imports Datos
Namespace Factores
    Public Class ClsFactores
#Region "Variables"
        Private taFactores As New dsAlcoComercialTableAdapters.tc009_factorTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
        ''' <summary>
        ''' Inserta un nuevo registro de factores en la base de datos
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <param name="tasa"></param>
        ''' <param name="idEstado"></param>
        ''' <param name="idCiudad"></param>
        Public Sub Ingresar(usuario As String, tasa As Decimal, idEstado As Integer, idCiudad As Integer, descripcion As String, valorxDefecto As Integer)
            Try
                taFactores.sp_tc009_insert(usuario, tasa, idEstado, idCiudad, descripcion, valorxDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Actualiza el registro correspondiente al Id en la base de datos
        ''' </summary>
        ''' <param name="idEstado"></param>
        ''' <param name="id"></param>
        Public Sub Modificar(idEstado As Integer, id As Integer, valorDefecto As Integer, usuarioModi As String, idCiudad As Integer)
            Try
                taFactores.sp_tc009_update(idEstado, id, valorDefecto, usuarioModi, idCiudad)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Indica si existe un factor asociado a la ciudad seleccionada
        ''' </summary>
        ''' <param name="tasa"></param>
        ''' <param name="rowidCiud"></param>
        ''' <returns></returns>
        Public Function ExisteFactor(tasa As Decimal, rowidCiud As Integer) As Boolean
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc009_selectByTasaTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc009_selectByTasaDataTable = taAll.GetData(tasa, rowidCiud)
                If txAll.Rows.Count > 0 Then Return True
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Indica si la ciudad ya tiene un factor por defecto
        ''' </summary>
        ''' <param name="idCiudad"></param>
        ''' <returns></returns>
        Public Function ExisteValorDefecto(idCiudad As Integer) As Boolean
            Try
                Dim Count As Integer = Convert.ToInt32(taFactores.sp_tc009_selectExistValorDefecto(idCiudad))
                If Count > 0 Then
                    Return True
                End If
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el factor por defecto de la ciudad indicada
        ''' </summary>
        ''' <param name="idCiudad"></param>
        ''' <returns></returns>
        Public Function traerValorDefectoByCiudad(idCiudad As Integer) As List(Of factores)
            Try
                traerValorDefectoByCiudad = New List(Of factores)
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc009_selectValorDefectoByCiudadTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc009_selectValorDefectoByCiudadDataTable = taAll.GetData(idCiudad)
                For Each ti As dsAlcoComercial.sp_tc009_selectValorDefectoByCiudadRow In txAll.Rows
                    traerValorDefectoByCiudad.Add(New factores(ti.id_Factor, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Tasa, ti.idCiudad, ti.Ciudad, ti.id_Dpto, ti.id_Pais,
                                                               ti.Usuario_Modi, ti.Fecha_Modi, ti.id_Estado, ti.Estado, ti.Descripcion, ti.valorPorDefecto))
                Next
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene todos los registros de factores activos e inactivos
        ''' </summary>
        ''' <returns></returns>
        Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of factores)
            traerTodos = New List(Of factores)
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc009_selectAllTableAdapter
                Dim txall As dsAlcoComercial.sp_tc009_selectAllDataTable = taAll.GetData()
                For Each ti As dsAlcoComercial.sp_tc009_selectAllRow In txall.Rows
                    traerTodos.Add(New factores(ti.id_Factor, ti.Usuario_Creacion, ti.Fecha_Creacion,
                                                    ti.Tasa, ti.id_Ciudad, ti.Ciudad, ti.id_Dpto, ti.id_Pais, ti.Usuario_Modi, ti.Fecha_Modi,
                                                    ti.id_Estado, ti.Estado, ti.Descripcion, ti.valor_Defecto))
                Next
                If txall.Rows.Count > 0 Then
                    dt = txall.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de factores correspondiente al Id
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function TraerxId(id As Integer) As factores
            Try
                TraerxId = New factores
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc009_selectByIDTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc009_selectByIDDataTable = taAll.GetData(id)
                    If txid.Rows.Count > 0 Then
                        Dim ti As dsAlcoComercial.sp_tc009_selectByIDRow = DirectCast(txid.Rows(0), dsAlcoComercial.sp_tc009_selectByIDRow)
                        TraerxId = New factores(ti.id_Factor, ti.Usuario_Creacion, ti.Fecha_Creacion,
                                                ti.Tasa, ti.idCiudad, ti.Ciudad, ti.id_Dpto, ti.id_Pais, ti.Usuario_Modi,
                                                ti.Fecha_Modi, ti.id_Estado, ti.Estado, ti.Descripcion, ti.valorPorDefecto)
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el registro de factores con la sigla indicada
        ''' </summary>
        ''' <param name="ciudad"></param>
        ''' <returns></returns>
        Public Function TraerxSigla(ciudad As String) As List(Of factores)
            Try
                TraerxSigla = New List(Of factores)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc009_selectByCiudadTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc009_selectByCiudadDataTable = taAll.GetData(ciudad)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc009_selectByCiudadRow In txid.Rows
                            TraerxSigla.Add(New factores(ti.id_Factor, ti.Usuario_Creacion, ti.Fecha_Creacion,
                                                         ti.Tasa, ti.idCiudad, ti.Ciudad, ti.id_Dpto, ti.id_Pais, ti.Usuario_Modi, ti.Fecha_Modi,
                                                         ti.id_Estado, ti.Estado, ti.Descripcion, ti.valorPorDefecto))
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
        ''' Obtiene todos los registros de factores según el estado indicado
        ''' </summary>
        ''' <param name="idEstado"></param>
        ''' <returns></returns>
        Public Function TraerxEstado(idEstado As Integer) As List(Of factores)
            Try
                TraerxEstado = New List(Of factores)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc009_selectByEstadoTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc009_selectByEstadoDataTable = taAll.GetData(idEstado)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc009_selectByEstadoRow In txid.Rows
                            TraerxEstado.Add(New factores(ti.id_Factor, ti.Usuario_Creacion,
                                                          ti.Fecha_Creacion, ti.Tasa, ti.idCiudad, ti.Ciudad, ti.id_Dpto, ti.id_Pais,
                                                          ti.Usuario_Modi, ti.Fecha_Modi, ti.id_Estado, ti.Estado, ti.Descripcion, ti.valorPorDefecto))
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
        ''' Obtiene los registros con el estado y la ciudad indicada, ordenados por valor defecto
        ''' </summary>
        ''' <param name="idEstado"></param>
        ''' <param name="idCiudad"></param>
        ''' <returns></returns>
        Public Function TraerxEstadoAndCiudad(idEstado As Integer, idCiudad As Integer) As List(Of factores)
            Try
                TraerxEstadoAndCiudad = New List(Of factores)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc009_selectByEstadoAndCiudadTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc009_selectByEstadoAndCiudadDataTable = taAll.GetData(idEstado, idCiudad)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc009_selectByEstadoAndCiudadRow In txid.Rows
                            TraerxEstadoAndCiudad.Add(New factores(ti.id_Factor, ti.Usuario_Creacion,
                                                                   ti.Fecha_Creacion, ti.Tasa, ti.idCiudad, ti.Ciudad, ti.id_Dpto, ti.id_Pais,
                                                                   ti.Usuario_Modi, ti.Fecha_Modi, ti.id_Estado, ti.Estado, ti.Descripcion, ti.valorPorDefecto))
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
        ''' Obtiene el último factor ingresado para una ciudad desde el formulario de cotizaciones
        ''' </summary>
        ''' <param name="idCiudad"></param>
        ''' <returns></returns>
        Public Function TraerUltimoxCiudad(idCiudad As Integer) As factores
            Try
                TraerUltimoxCiudad = New factores
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc009_selectUltimoByCiudadTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc009_selectUltimoByCiudadDataTable = taAll.GetData(idCiudad)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoComercial.sp_tc009_selectUltimoByCiudadRow In txAll
                        TraerUltimoxCiudad = New factores(ti.id_Factor, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Tasa,
                                                            ti.idCiudad, ti.Ciudad, ti.id_Dpto, ti.id_Pais, ti.Usuario_Modi, ti.Fecha_Modi, ti.id_Estado,
                                                            ti.Estado, ti.Descripcion, ti.valorPorDefecto)
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
    Public Class factores
        Inherits ClsBaseParametros
#Region "Variables"
        Private _tasa As Decimal = 0
        Private _idCiudad As Integer = 0
        Private _ciudad As String = String.Empty
        Private _descripcion As String = String.Empty
        Private _valorPorDefecto As Integer = 0
        Private _idDpto As Integer
        Private _idPais As Integer
#End Region

#Region "Propiedades"
        Public Property tasa() As Decimal
            Get
                Return _tasa
            End Get
            Set(ByVal value As Decimal)
                _tasa = value
            End Set
        End Property

        Public Property idCiudad() As Integer
            Get
                Return _idCiudad
            End Get
            Set(ByVal value As Integer)
                _idCiudad = value
            End Set
        End Property

        Public Property Ciudad As String
            Get
                Return _ciudad
            End Get
            Set(ByVal value As String)
                _ciudad = value
            End Set
        End Property
        Public Property Descripcion As String
            Get
                Return _descripcion
            End Get
            Set(ByVal value As String)
                _descripcion = value
            End Set
        End Property
        Public Property valorPorDefecto As Integer
            Get
                Return _valorPorDefecto
            End Get
            Set(ByVal value As Integer)
                _valorPorDefecto = value
            End Set
        End Property
        Public Property idDpto() As Integer
            Get
                Return _idDpto
            End Get
            Set(ByVal value As Integer)
                _idDpto = value
            End Set
        End Property
        Public Property idPais() As Integer
            Get
                Return _idPais
            End Get
            Set(ByVal value As Integer)
                _idPais = value
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
        Public Sub New(id As Integer, usuarioCreacion As String, fechaCreacion As DateTime,
                       tasa As Decimal, idCiudad As Integer, ciudad As String, idDpto As Integer, idPais As Integer,
                       usuarioModi As String, fechaModi As Date, idEstado As Integer, estado As String, descripcion As String, valorPorDefecto As Integer)
            Try
                Me.Id = id
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                Me.FechaCreacion = fechaCreacion
                _tasa = tasa
                _idCiudad = idCiudad
                _ciudad = ciudad
                _idDpto = idDpto
                _idPais = idPais
                _descripcion = Trim(descripcion)
                _valorPorDefecto = valorPorDefecto
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

