Imports Datos
Namespace ManoObraInstalacion
    Public Class ClsManoObraInstalacion

#Region "Variables"
        Private taManoObraInstalacion As New dsAlcoComercialTableAdapters.tc008_ManoObraInstalacionTableAdapter
        Private taUnidades As New dsAlcoComercialTableAdapters.alco_spUnidadesMedidasTableAdapter
#End Region
#Region "Propiedades"

#End Region
#Region "Procedimientos"
        ''' <summary>
        ''' Procedimiento  que ingresa la informacion de la mano de obra de instalacion
        ''' </summary>
        ''' <param name="usuario"></param>
        ''' <param name="idUnidadMedida"></param>
        ''' <param name="valor"></param>
        ''' <param name="idEstado"></param>
        ''' <param name="descripcion"></param>
        ''' <param name="idCiudad"></param>
        Public Sub Ingresar(usuario As String, idUnidadMedida As String, valor As Decimal, idEstado As Integer, descripcion As String,
                            idCiudad As Integer, valorPorDefecto As Integer)
            Try
                taManoObraInstalacion.sp_tc008_insert(usuario, idUnidadMedida, valor, idEstado, descripcion, idCiudad, valorPorDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Procedimiento que actualiza la informacion de la mano de obra de instalacion
        ''' </summary>
        ''' <param name="idUnidadMedida"></param>
        ''' <param name="valor"></param>
        ''' <param name="usuarioModi"></param>
        ''' <param name="idEstado"></param>
        ''' <param name="Descripcion"></param>
        ''' <param name="idCiudad"></param>
        ''' <param name="id"></param>
        Public Sub Modificar(idUnidadMedida As String, valor As Decimal, usuarioModi As String, idEstado As Integer, Descripcion As String,
                             idCiudad As Integer, id As Integer, valorPorDefecto As Integer)
            Try
                taManoObraInstalacion.sp_tc008_update(idUnidadMedida, valor, usuarioModi, idEstado, Descripcion, idCiudad, id, valorPorDefecto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        ''' <summary>
        ''' Funcion que devuelve la informacion de todas las tasas de impuesto
        ''' </summary>
        ''' <returns></returns>
        Public Function traerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of manoObraInstalacion)
            traerTodos = New List(Of manoObraInstalacion)
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc008_selectAllTableAdapter
                Dim txall As dsAlcoComercial.sp_tc008_selectAllDataTable = taAll.GetData()
                For Each ti As dsAlcoComercial.sp_tc008_selectAllRow In txall.Rows
                    traerTodos.Add(New manoObraInstalacion(ti.id_ManoObra, ti.Usuario_Creacion, ti.Fecha_Creacion,
                                                           ti.Descripcion, ti.Unidad_Medida, ti.Valor,
                                                           ti.id_Ciudad, ti.Ciudad, ti.id_Dpto, ti.id_Pais, ti.Usuario_Modi, ti.Fecha_modi,
                                                           ti.Id_estado, ti.Estado, ti.valor_Defecto))
                Next
                If txall.Rows.Count > 0 Then
                    dt = txall.CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        ''' <summary>
        ''' Función que devuelve las unidades de medida
        ''' </summary>
        ''' <returns></returns>
        Public Function traerUnidades() As DataTable
            Try
                traerUnidades = taUnidades.GetData
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Funcion que trae la informacion de las identidicaciones segun el id del tipo de identificacion
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function TraerxId(id As Integer) As List(Of manoObraInstalacion)
            Try
                TraerxId = New List(Of manoObraInstalacion)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc008_selectByIdTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc008_selectByIdDataTable = taAll.GetData(id)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc008_selectByIdRow In txid.Rows
                            TraerxId.Add(New manoObraInstalacion(ti.id_ManoObra, ti.Usuario_Creacion, ti.Fecha_Creacion,
                                                                 ti.Descripcion, ti.Unidad_Medida, ti.Valor, ti.id_Ciudad, ti.Ciudad,
                                                                 ti.id_Dpto, ti.id_Pais, ti.Usuario_Modi, ti.Fecha_modi, ti.Id_estado,
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
        ''' <summary>
        ''' Indica si existe algún registro según la descripción
        ''' </summary>
        ''' <param name="descripcion"></param>
        ''' <returns></returns>
        Public Function TraerxDescripcion(descripcion As String) As Boolean
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc008_selectByDescripcionTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc008_selectByDescripcionDataTable = taAll.GetData(descripcion)
                If txAll.Rows.Count > 0 Then Return True
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        ''' <summary>
        ''' Funcion que trae la informacion segun el estado de tasa de impuesto
        ''' </summary>
        ''' <param name="idEstado"></param>
        ''' <returns></returns>
        Public Function TraerxEstado(idEstado As Integer) As List(Of manoObraInstalacion)
            Try
                TraerxEstado = New List(Of manoObraInstalacion)
                Try
                    Dim taAll As New dsAlcoComercialTableAdapters.sp_tc008_selectByEstadoTableAdapter
                    Dim txid As dsAlcoComercial.sp_tc008_selectByEstadoDataTable = taAll.GetData(idEstado)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoComercial.sp_tc008_selectByEstadoRow In txid.Rows
                            TraerxEstado.Add(New manoObraInstalacion(ti.id_ManoObra, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Descripcion,
                                                                     ti.Unidad_Medida, ti.Valor, ti.id_Ciudad, ti.Ciudad, ti.id_Dpto, ti.id_Pais,
                                                                     ti.Usuario_Modi, ti.Fecha_modi, ti.Id_estado, ti.Estado, ti.valorPorDefecto))
                        Next
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function ExisteManoObra(valor As Decimal, idCiudad As Integer) As Boolean
            Try
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc008_selectByValorTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc008_selectByValorDataTable = taAll.GetData(valor, idCiudad)
                If txAll.Rows.Count > 0 Then Return True
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerUltimoxCiudad(idCiudad As Integer) As manoObraInstalacion
            Try
                TraerUltimoxCiudad = New manoObraInstalacion
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc008_selectUltimoByCiudadTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc008_selectUltimoByCiudadDataTable = taAll.GetData(idCiudad)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoComercial.sp_tc008_selectUltimoByCiudadRow In txAll
                        TraerUltimoxCiudad = New manoObraInstalacion(ti.id_ManoObra, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Descripcion,
                                                                       ti.Unidad_Medida, ti.Valor, ti.id_Ciudad, ti.Ciudad, ti.id_Dpto, ti.id_Pais,
                                                                       ti.Usuario_Modi, ti.Fecha_modi, ti.Id_estado, ti.Estado, ti.valorPorDefecto)
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerxValorDefectoAndCiudad(idCiudad As Integer) As List(Of manoObraInstalacion)
            Try
                TraerxValorDefectoAndCiudad = New List(Of manoObraInstalacion)
                Dim taAll As New dsAlcoComercialTableAdapters.sp_tc008_selectByCiudadAndValorDefectoTableAdapter
                Dim txAll As dsAlcoComercial.sp_tc008_selectByCiudadAndValorDefectoDataTable = taAll.GetData(idCiudad)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoComercial.sp_tc008_selectByCiudadAndValorDefectoRow In txAll.Rows
                        TraerxValorDefectoAndCiudad.Add(New manoObraInstalacion(ti.id_ManoObra, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Descripcion,
                                                                                ti.Unidad_Medida, ti.Valor, ti.id_Ciudad, ti.Ciudad, ti.id_Dpto, ti.id_Pais,
                                                                                ti.Usuario_Modi, ti.Fecha_modi, ti.Id_estado, ti.Estado, ti.valorPorDefecto))
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
    Public Class manoObraInstalacion
        Inherits ClsBaseParametros
#Region "Variables"
        Private _idUnidadadMedida As String = String.Empty
        Private _valor As Decimal = 0
        Private _idCiudad As Integer = 0
        Private _ciudad As String
        Private _descripcion As String = String.Empty
        Private _valorPorDefecto As Integer = 0
        Private _idDpto As Integer
        Private _idPais As Integer
#End Region
#Region "Propiedades"
        Public Property idUnidadMedida() As String
            Get
                Return _idUnidadadMedida
            End Get
            Set(ByVal value As String)
                _idUnidadadMedida = value
            End Set
        End Property
        Public Property valorInstalacion() As Decimal
            Get
                Return _valor
            End Get
            Set(ByVal value As Decimal)
                _valor = value
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
            Set(value As String)
                _ciudad = value
            End Set
        End Property

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
        Public Sub New(id As Integer, usuarioCreacion As String, fechaCreacion As DateTime, descripcion As String, unidadMedida As String,
                       valor As Decimal, idCiudad As Integer, ciudad As String, idDpto As Integer, idPais As Integer, usuarioModi As String,
                       fechaModi As Date, idEstado As Integer, estado As String, valorPorDefecto As Integer)
            Try
                Me.Id = id
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                Me.FechaCreacion = fechaCreacion
                _idUnidadadMedida = unidadMedida
                _valor = valor
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

