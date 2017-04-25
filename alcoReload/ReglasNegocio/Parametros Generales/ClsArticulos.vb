Imports Datos
Public Class ClsArticulos
#Region "Variables"
    Private taarticulos As New dsbAlcoIngenieriaTableAdapters.ti017_articulosTableAdapter
    Private taUnidades As New dsAlcoComercialTableAdapters.alco_spUnidadesMedidasTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Inserta un nuevo registro en la tabla de artículos
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="idfamiliamaterial"></param>
    ''' <param name="referencia"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="peso"></param>
    ''' <param name="perimetro"></param>
    ''' <param name="unidadmedida"></param>
    ''' <param name="nivel"></param>
    ''' <param name="porcDesperdicio"></param>
    ''' <param name="estado"></param>
    ''' <returns></returns>
    Public Function Ingresar(usuario As String, idfamiliamaterial As Integer, referencia As String, descripcion As String,
                             peso As Decimal, perimetro As Decimal, unidadmedida As String, nivel As Integer, idTasaImpuesto As Integer,
                             porcDesperdicio As Decimal, costo_instalacion As Decimal, estado As Integer, altoDescuento As Decimal) As Integer
        Try
            Return Convert.ToInt32(taarticulos.sp_ti017_insert(usuario, idfamiliamaterial, referencia, descripcion, peso,
                                                               perimetro, unidadmedida, nivel, idTasaImpuesto,
                                                               porcDesperdicio, costo_instalacion, estado, altoDescuento))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Modifica la información del registro indicado
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idfamiliamaterial"></param>
    ''' <param name="referencia"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="peso"></param>
    ''' <param name="perimetro"></param>
    ''' <param name="unidadMedida"></param>
    ''' <param name="nivel"></param>
    ''' <param name="porcDesperdicio"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, idfamiliamaterial As Integer, referencia As String,
                         descripcion As String, peso As Decimal, perimetro As Decimal, unidadMedida As String,
                         nivel As Integer, idTasaImpuesto As Integer, porcDesperdicio As Decimal,
                         costo_instalacion As Decimal, altoDescuento As Decimal, estado As Integer)
        Try
            taarticulos.sp_ti017_updateById(idfamiliamaterial, referencia, descripcion, peso, perimetro,
                                            unidadMedida, nivel, idTasaImpuesto, porcDesperdicio, costo_instalacion,
                                            usuario, estado, altoDescuento, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Retorna verdadero si existe el registro con los valores ingresados
    ''' </summary>
    ''' <param name="idFamiliaMaterial"></param>
    ''' <param name="referencia"></param>
    ''' <returns></returns>
    Public Function ExisteArticulo(idFamiliaMaterial As Integer, referencia As String) As Boolean
        Try
            If Convert.ToInt32(taarticulos.sp_ti017_selectExistByReferenciaAndMaterial(idFamiliaMaterial, referencia)) > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los artículos ragistrados
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of Articulo)
        TraerTodos = New List(Of Articulo)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti017_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti017_selectAllDataTable = taAll.GetData()
            For Each ar As dsbAlcoIngenieria.sp_ti017_selectAllRow In txall.Rows
                TraerTodos.Add(New Articulo(ar.Id, ar.Usuario_Creacion, ar.Fecha_Creacion, ar.Referencia, ar.Descripcion, ar.Id_Familia_Material,
                                            ar.Familia_Material, ar.Peso, ar.Perimetro, ar.Unidad_medida, ar.Id_Nivel, ar.Nivel, ar.Id_Tasa_Impuesto,
                                            ar.Tasa_Impuesto, ar.porcentajeDesperdicio, ar.costo_instalacion, ar.Usuario_Modificacion, ar.Fecha_Modificacion, ar.Id_Estado,
                                            ar.Estado, ar.Alto_para_descuentos))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxEstado(estado As Integer) As DataTable
        Try
            Return taarticulos.GetData().Where(Function(r) r.fi017_rowidEstado = estado).CopyToDataTable()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Este procedimiento sirve para obtener los artículos filtrados por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As Articulo
        TraerxId = New Articulo()
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti017_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti017_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim ar As dsbAlcoIngenieria.sp_ti017_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti017_selectByIdRow)
                TraerxId = New Articulo(ar.Id, ar.Usuario_Creacion, ar.Fecha_Creacion, ar.Referencia, ar.Descripcion, ar.Id_Familia_Material,
                                        ar.Familia_Material, ar.Peso, ar.Perimetro, ar.Unidad_medida, ar.Id_Nivel, ar.Nivel, ar.Id_Tasa_Impuesto,
                                        ar.Tasa_Impuesto, ar.porcentajeDesperdicio, ar.costo_instalacion, ar.Usuario_Modificacion, ar.Fecha_Modificacion, ar.Id_Estado,
                                        ar.Estado, ar.Alto_para_descuentos)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExisteMovimiento(idArticulo As Integer) As List(Of Articulo)
        Try
            ExisteMovimiento = New List(Of Articulo)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti017_selectExistMovimientoTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti017_selectExistMovimientoDataTable = taAll.GetData(idArticulo)
            For Each art As dsbAlcoIngenieria.sp_ti017_selectExistMovimientoRow In txAll
                ExisteMovimiento.Add(New Articulo(art.idCosto, art.familiaMaterial, art.costo))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la información del artículo correspondiente a la referencia indicada
    ''' </summary>
    ''' <param name="referencia"></param>
    ''' <returns></returns>
    Public Function TraerxReferencia(referencia As String) As Articulo
        Try
            TraerxReferencia = New Articulo
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti017_selectByReferenciaTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti017_selectByReferenciaDataTable = taAll.GetData(referencia)
            If txAll.Rows.Count > 0 Then
                For Each ar As dsbAlcoIngenieria.sp_ti017_selectByReferenciaRow In txAll.Rows
                    TraerxReferencia = New Articulo(ar.Id, ar.Usuario_Creacion, ar.Fecha_Creacion, ar.Referencia, ar.Descripcion,
                                                    ar.Id_Familia_Material, ar.Familia_Material, ar.Peso, ar.Perimetro, ar.Unidad_medida,
                                                    ar.Id_Nivel, ar.Nivel, ar.Id_Tasa_Impuesto, ar.Tasa_Impuesto, ar.porcentajeDesperdicio,
                                                    ar.costo_instalacion, ar.Usuario_Modificacion, ar.Fecha_Modificacion, ar.Id_Estado, ar.Estado, ar.Alto_para_descuentos)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerUltimoByFamiliaMaterial(idFamiliaMaterial As Integer) As Articulo
        Try
            TraerUltimoByFamiliaMaterial = New Articulo
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti017_selectUltimoByFamiliaMaterialTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti017_selectUltimoByFamiliaMaterialDataTable = taAll.GetData(idFamiliaMaterial)
            If txAll.Rows.Count > 0 Then
                Dim art As dsbAlcoIngenieria.sp_ti017_selectUltimoByFamiliaMaterialRow = DirectCast(txAll.Rows(0),
                    dsbAlcoIngenieria.sp_ti017_selectUltimoByFamiliaMaterialRow)
                TraerUltimoByFamiliaMaterial = New Articulo(art.Id, art.Usuario_Creacion, art.Fecha_Creacion, art.Referencia,
                                                            art.Descripcion, art.Id_Familia_Material, art.Familia_Material,
                                                            art.Peso, art.Perimetro, art.Unidad_medida, art.Id_Nivel, art.Nivel,
                                                            art.Id_Tasa_Impuesto, art.Tasa_Impuesto, art.porcentajeDesperdicio, art.costo_instalacion,
                                                            art.Usuario_Modificacion, art.Fecha_Modificacion, art.Id_Estado, art.Estado,
                                                            art.Alto_para_descuentos)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ValidarImagenes(listadxf As List(Of String), ByRef mensaje As String) As Boolean
        Try
            For i = 0 To listadxf.Count - 1
                If String.IsNullOrEmpty(listadxf(i)) Then
                    mensaje = "La imagen [" & i.ToString() & "], no tiene una descripción valida, Verifique la información"
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxFamiliayEstado(familia As ClsEnums.FamiliasMateriales, estado As ClsEnums.Estados,
                                         Optional ByRef dt As DataTable = Nothing) As List(Of Articulo)
        TraerxFamiliayEstado = New List(Of Articulo)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti017_selectbyEstadoyFamiliaTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti017_selectbyEstadoyFamiliaDataTable = taAll.GetData(familia, estado)
            For Each ar As dsbAlcoIngenieria.sp_ti017_selectbyEstadoyFamiliaRow In txall.Rows
                TraerxFamiliayEstado.Add(New Articulo(ar.Id, ar.Usuario_Creacion, ar.Fecha_Creacion, ar.Referencia, ar.Descripcion,
                                                      ar.Id_Familia_Material, ar.Familia_Material, ar.Peso, ar.Perimetro, ar.Unidad_medida,
                                                      ar.Id_Nivel, ar.Nivel, ar.Id_Tasa_Impuesto, ar.Tasa_Impuesto, ar.porcentajeDesperdicio, ar.costo_instalacion,
                                                      ar.Usuario_Modificacion, ar.Fecha_Modificacion, ar.Id_Estado, ar.Estado,
                                                      ar.Alto_para_descuentos))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Procedimiento que devuelve os registros de artículos correspondientes al rowid de familia material indicado
    ''' </summary>
    ''' <param name="idFamiliaMaterial"></param>
    ''' <returns></returns>
    Public Function TraerxFamiliaMaterial(idFamiliaMaterial As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of Articulo)
        Try
            TraerxFamiliaMaterial = New List(Of Articulo)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti017_selectByFamiliaMaterialTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti017_selectByFamiliaMaterialDataTable = taAll.GetData(idFamiliaMaterial)
            If txAll.Rows.Count > 0 Then
                For Each ar As dsbAlcoIngenieria.sp_ti017_selectByFamiliaMaterialRow In txAll.Rows
                    TraerxFamiliaMaterial.Add(New Articulo(ar.Id, ar.Usuario_Creacion, ar.Fecha_Creacion, ar.Referencia, ar.Descripcion,
                                                           ar.Id_Familia_Material, ar.Familia_Material, ar.Peso, ar.Perimetro, ar.Unidad_medida,
                                                           ar.Id_Nivel, ar.Nivel, ar.Id_Tasa_Impuesto, ar.Tasa_Impuesto, ar.porcentajeDesperdicio, ar.costo_instalacion,
                                                           ar.Usuario_Modificacion, ar.Fecha_Modificacion, ar.Id_Estado, ar.Estado,
                                                           ar.Alto_para_descuentos))
                Next
                dt = txAll.CopyToDataTable()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Obtiene los articulos de la familia otros, trabajo vidrio y trabajo perfilería
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    Public Function TraerOtros(ByRef dt As DataTable) As List(Of Articulo)
        Try
            TraerOtros = New List(Of Articulo)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti017_selectOtrosAndTrabajosTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti017_selectOtrosAndTrabajosDataTable = taAll.GetData()
            For Each ar As dsbAlcoIngenieria.sp_ti017_selectOtrosAndTrabajosRow In txAll
                TraerOtros.Add(New Articulo(ar.Id, ar.Usuario_Creacion, ar.Fecha_Creacion, ar.Referencia, ar.Descripcion,
                                            ar.Id_Familia_Material, ar.Familia_Material, ar.Peso, ar.Perimetro, ar.Unidad_medida,
                                            ar.Id_Nivel, ar.Nivel, ar.Id_Tasa_Impuesto, ar.Tasa_Impuesto, ar.porcentajeDesperdicio, ar.costo_instalacion,
                                            ar.Usuario_Modificacion, ar.Fecha_Modificacion, ar.Id_Estado, ar.Estado,
                                            ar.Alto_para_descuentos))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
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

#End Region
End Class

Public Class Articulo
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idfamiliamaterial As Integer = 0
    Private _idnivel As Integer = 0
    Private _referencia As String = String.Empty
    Private _descripcion As String = String.Empty
    Private _peso As Decimal = 0
    Private _perimetro As Decimal = 0
    Private _nombrefamiliamaterial As String = String.Empty
    Private _nivel As String = String.Empty
    Private _idTasaImpuesto As Integer
    Private _tasaImpuesto As String
    Private _porcDesperdicio As Decimal
    Private _unidadMedida As String
    Private _idCosto As Integer
    Private _costo As Decimal
    Private _costo_instalacion As Decimal
#End Region
#Region "Propiedades"
    Public Property IdFamiliaMaterial As Integer
        Get
            Return _idfamiliamaterial
        End Get
        Set(value As Integer)
            _idfamiliamaterial = value
        End Set
    End Property
    Public Property NombreFamiliaMaterial As String
        Get
            Return _nombrefamiliamaterial
        End Get
        Set(value As String)
            _nombrefamiliamaterial = value
        End Set
    End Property
    Public Property IdNivel As Integer
        Get
            Return _idnivel
        End Get
        Set(value As Integer)
            _idnivel = value
        End Set
    End Property
    Public Property Nivel As String
        Get
            Return _nivel
        End Get
        Set(value As String)
            _nivel = value
        End Set
    End Property
    Public Property Referencia As String
        Get
            Return _referencia
        End Get
        Set(ByVal value As String)
            _referencia = value
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
    Public Property Peso As Decimal
        Get
            Return _peso
        End Get
        Set(value As Decimal)
            _peso = value
        End Set
    End Property
    Public Property Perimetro As Decimal
        Get
            Return _perimetro
        End Get
        Set(value As Decimal)
            _perimetro = value
        End Set
    End Property
    Public Property unidadMedida As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property
    Public Property IdTasaImpuesto As Integer
        Get
            Return _idTasaImpuesto
        End Get
        Set(ByVal value As Integer)
            _idTasaImpuesto = value
        End Set
    End Property
    Public Property TasaImpuesto As String
        Get
            Return _tasaImpuesto
        End Get
        Set(ByVal value As String)
            _tasaImpuesto = value
        End Set
    End Property
    Public Property porcDesperdicio As Decimal
        Get
            Return _porcDesperdicio
        End Get
        Set(ByVal value As Decimal)
            _porcDesperdicio = value
        End Set
    End Property
    Public Property IdCosto As Integer
        Get
            Return _idCosto
        End Get
        Set(ByVal value As Integer)
            _idCosto = value
        End Set
    End Property
    Public Property Costo As Decimal
        Get
            Return _costo
        End Get
        Set(ByVal value As Decimal)
            _costo = value
        End Set
    End Property

    Public Property Costo_Instalacion As Decimal
        Get
            Return _costo_instalacion
        End Get
        Set(ByVal value As Decimal)
            _costo_instalacion = value
        End Set
    End Property
    Private _altoDescuento As Decimal
    Public Property AltoDecuento() As Decimal
        Get
            Return _altoDescuento
        End Get
        Set(ByVal value As Decimal)
            _altoDescuento = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, referencia As String, descripcion As String,
                   IdFamiliaMaterial As Integer, nombrefamiliamaterial As String, peso As Decimal, perimetro As Decimal,
                   unidadMedida As String, idnivel As Integer, nivel As String, idTasaImpuesto As Integer, tasaImpuesto As String,
                   porcDesperdicio As Decimal, costo_instalacion As Decimal, UsuarioModificacion As String, FechaModificacion As Date, IdEstado As Integer, Estado As String,
                   altoDescuento As Decimal)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _referencia = Trim(referencia)
            _descripcion = Trim(descripcion)
            _peso = peso
            _perimetro = perimetro
            _unidadMedida = unidadMedida
            _idnivel = idnivel
            _nivel = Trim(nivel)
            _idTasaImpuesto = idTasaImpuesto
            _tasaImpuesto = Trim(tasaImpuesto)
            _porcDesperdicio = porcDesperdicio
            _costo_instalacion = costo_instalacion
            _idfamiliamaterial = IdFamiliaMaterial
            _nombrefamiliamaterial = Trim(nombrefamiliamaterial)
            Me.UsuarioModificacion = Trim(UsuarioModificacion)
            Me.FechaModificacion = FechaModificacion
            Me.IdEstado = IdEstado
            Me.Estado = Trim(Estado)
            _altoDescuento = altoDescuento
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(referencia As String, descripcion As String)
        Try
            _referencia = referencia
            _descripcion = descripcion
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub New(idCosto As Integer, familiaMaterial As Integer, costo As Decimal)
        Try
            _idCosto = idCosto
            _idfamiliamaterial = familiaMaterial
            _costo = costo
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
