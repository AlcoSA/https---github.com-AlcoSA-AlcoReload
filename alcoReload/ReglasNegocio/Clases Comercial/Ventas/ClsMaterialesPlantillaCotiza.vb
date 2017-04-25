Imports Datos
Public Class ClsMaterialesPlantillaCotiza
#Region "Variables"
    Private tamaterial As New dsAlcoCotizacionesTableAdapters.tc061_materialeshijocotizaTableAdapter
#End Region

    Public Function Insertar(idhijocotiza As Integer, iditemplantilla As Integer, usuario As String, idfamiliamateria As Integer, idorientacionposicionmaterial As Integer,
                    espesor As String, valor_espesor As String, articulo As String, articulo_valor As String,
                    idubicacionmaterial As Integer, idmaterialpara As Integer, acabado As String, acabado_valor As String, idtipoMaterial As Integer,
                    idtipocortes As Integer, cantidad As String, cantidad_valor As Decimal, pxuni As String, pxuni_valor As Decimal,
                    ancho As String, ancho_valor As Decimal, alto As String, alto_valor As Decimal,
                    peso As String, peso_valor As Decimal, descuento As String, descuento_valor As Decimal,
                    observaciones As String, observaciones_valor As String, estado As Integer,
                    visibilidad As String, visibilidad_valor As Boolean, utilizar As Boolean,
                    desperdicio As Decimal, costo_instalacion As Decimal, indicador As Integer) As Integer
        Try
            Return Convert.ToInt32(tamaterial.sp_tc061_insert(idhijocotiza, usuario, iditemplantilla, idfamiliamateria,
                                       idorientacionposicionmaterial, idubicacionmaterial, idmaterialpara, idtipoMaterial, idtipocortes,
                                       espesor, valor_espesor,
                                       acabado, acabado_valor, articulo, articulo_valor,
                                       cantidad, cantidad_valor, pxuni, pxuni_valor, ancho, ancho_valor, peso, peso_valor,
                                       alto, alto_valor, descuento, descuento_valor,
                                       observaciones, observaciones_valor, desperdicio, costo_instalacion,
                                       visibilidad, visibilidad_valor,
                                       utilizar, indicador, estado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub BorrarporIdHijoCotiza(idhijocotiza As Integer)
        Try
            tamaterial.sp_tc061_deletebyIdHijoCotiza(idhijocotiza)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdHijoCotiza(idhijocotiza As Integer) As List(Of MaterialPlantillaMovimiento)
        TraerporIdHijoCotiza = New List(Of MaterialPlantillaMovimiento)
        Try
            Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc061_selectbyIdHijoCotizaTableAdapter
            Dim txall As dsAlcoCotizaciones.sp_tc061_selectbyIdHijoCotizaDataTable = taAll.GetData(idhijocotiza)
            For Each mp As dsAlcoCotizaciones.sp_tc061_selectbyIdHijoCotizaRow In txall.Rows
                TraerporIdHijoCotiza.Add(New MaterialPlantillaMovimiento(mp.Id, mp.Id_hijo_cotiza, mp.Id_Item_Plantilla, mp.Usuario_Creacion, mp.Fecha_Creacion,
                                                     mp.Id_Familia, mp.Familia, mp.Id_Orientacion, mp.Orientacion, mp.Articulo, mp.Articulo_valor, mp.Espesor, mp.valor_espesor,
                                                                     mp.Id_UbicaMaterial, mp.Ubicacion_Material, mp.Id_MaterialPara, mp.Material_Para, mp.Acabado, mp.acabado_valor,
                                                                     mp.Id_TipoMaterial, mp.Tipo_Material, mp.Id_TiposCortes, mp.Tipo_Cortes, mp.imagen_tipo_corte, mp.Cantidad, mp.cantidad_valor,
                                                                     mp.Pxunidad, mp.pxunidad_valor, mp.Ancho, mp.ancho_valor, mp.Alto,
                                                                     mp.alto_valor, mp.Peso, mp.peso_valor, mp.Descuento, mp.descuento_valor,
                                                                     mp.Observaciones, mp.observaciones_valor, mp.Usuario_Modificacion, mp.Fecha_Modificacion,
                                                                     mp.Id_Estado, mp.Estado, mp.Visibilidad, mp.visibilidad_valor,
                                                                     mp.utilizar, mp.PorcentajeDesperdicio, mp.costo_instalacion, mp.indicador))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class

Public Class MaterialPlantillaMovimiento
    Inherits MaterialPlantilla
#Region "Variables"
    Protected _idhijomov As Integer = 0
    Protected _iditemoriginal As Integer = 0
    Protected _utilizar As Boolean = True
    Protected _desperdicio As Decimal = 0
    Protected _articuloValor As String = String.Empty
    Protected _pxunidadvalor As Decimal = 0
    Protected _cantidadvalor As Decimal = 0
    Protected _anchovalor As Decimal = 0
    Protected _altovalor As Decimal = 0
    Protected _descuentovalor As Decimal = 0
    Protected _pesovalor As Decimal = 0
    Protected _observacionesvalor As String = String.Empty
    Protected _visibilidadvalor As Boolean = False
    Protected _espesorvalor As String = String.Empty
    Protected _acabadovalor As String = String.Empty
#End Region

#Region "Propiedades"
    Public Property IdHijoMovimiento As Integer
        Get
            Return _idhijomov
        End Get
        Set(value As Integer)
            _idhijomov = value
        End Set
    End Property
    Public Property IditemOriginal As Integer
        Get
            Return _iditemoriginal
        End Get
        Set(value As Integer)
            _iditemoriginal = value
        End Set
    End Property
    Public Property Utilizar As Boolean
        Get
            Return _utilizar
        End Get
        Set(value As Boolean)
            _utilizar = value
        End Set
    End Property
    Public Property desperdicio As Decimal
        Get
            Return _desperdicio
        End Get
        Set(ByVal value As Decimal)
            _desperdicio = value
        End Set
    End Property
    Public Property Articulo_Valor As String
        Get
            Return _articuloValor
        End Get
        Set(value As String)
            _articuloValor = value
        End Set
    End Property
    Public Property Cantidad_Valor As Decimal
        Get
            Return _cantidadvalor
        End Get
        Set(ByVal value As Decimal)
            _cantidadvalor = value
        End Set
    End Property
    Public Property Ancho_Valor As Decimal
        Get
            Return _anchovalor
        End Get
        Set(ByVal value As Decimal)
            _anchovalor = value
        End Set
    End Property
    Public Property Alto_Valor As Decimal
        Get
            Return _altovalor
        End Get
        Set(ByVal value As Decimal)
            _altovalor = value
        End Set
    End Property
    Public Property Descuento_Valor As Decimal
        Get
            Return _descuentovalor
        End Get
        Set(ByVal value As Decimal)
            _descuentovalor = value
        End Set
    End Property
    Public Property Peso_Valor As Decimal
        Get
            Return _pesovalor
        End Get
        Set(ByVal value As Decimal)
            _pesovalor = value
        End Set
    End Property
    Public Property Observaciones_Valor As String
        Get
            Return _observacionesvalor
        End Get
        Set(ByVal value As String)
            _observacionesvalor = value
        End Set
    End Property
    Public Property Visibilidad_Valor As Boolean
        Get
            Return _visibilidadvalor
        End Get
        Set(ByVal value As Boolean)
            _visibilidadvalor = value
        End Set
    End Property
    Public Property Espesor_Valor As String
        Get
            Return _espesorvalor
        End Get
        Set(ByVal value As String)
            _espesorvalor = value
        End Set
    End Property
    Public Property Acabado_Valor As String
        Get
            Return _acabadovalor
        End Get
        Set(ByVal value As String)
            _acabadovalor = value
        End Set
    End Property
    Public Property PiezasxUnidad_Valor As Decimal
        Get
            Return _pxunidadvalor
        End Get
        Set(value As Decimal)
            _pxunidadvalor = value
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

    Public Sub New(id As Integer, idhijocotiza As Integer, iditemoriginal As Integer, usuariocreacion As String, fechacreacion As Date,
                   idfamiliamaterial As Integer, familiamaterial As String, idorientacionposicion As Integer,
                   orientacionposicion As String, articulo As String, articulo_valor As String,
                   espesor As String, espesor_valor As String,
                   idubicacionmaterial As Integer, ubicacionmaterial As String, idmaterialpara As Integer,
                   materialpara As String, acabado As String, acabado_valor As String,
                   IdTipoMaterial As Integer, tipomaterial As String, idtipocortes As Integer,
                    TipoCortes As String, ImagenTipoCorte As Byte(),
                   cantidad As String, cantidad_valor As Decimal, pxuni As String, pxuni_valor As Decimal,
                   ancho As String, ancho_valor As Decimal,
                   alto As String, alto_valor As Decimal, peso As String, peso_valor As Decimal,
                   descuento As String, descuento_valor As Decimal, observaciones As String, observaciones_valor As String,
                   usuariomodificacion As String, fechamodificacion As Date, idestado As Integer, estado As String,
                   visibilidad As String, visibilidad_valor As Boolean, utilizar As Boolean, desperdicio As Decimal,
                   costo_instala As Decimal, indicador As Integer)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _idhijomov = idhijocotiza
            _iditemoriginal = iditemoriginal
            _cantidad = Trim(cantidad)
            _cantidadvalor = cantidad_valor
            _piezasxunidad = Trim(pxuni)
            _pxunidadvalor = pxuni_valor
            _ancho = Trim(ancho)
            _anchovalor = ancho_valor
            _alto = Trim(alto)
            _altovalor = alto_valor
            _descuento = Trim(descuento)
            _descuentovalor = descuento_valor
            _observaciones = Trim(observaciones)
            _observacionesvalor = Trim(observaciones_valor)
            _visibilidad = Trim(visibilidad)
            _visibilidadvalor = visibilidad_valor
            _peso = Trim(peso)
            _pesovalor = peso_valor
            _utilizar = utilizar
            _desperdicio = desperdicio
            _espesor = Trim(espesor)
            _espesorvalor = Trim(espesor_valor)
            _acabado = Trim(acabado)
            _acabadovalor = Trim(acabado_valor)
            _idfamiliamaterial = idfamiliamaterial
            _familiamaterial = Trim(familiamaterial)
            _idorientacionposicion = idorientacionposicion
            _orientacionposicion = Trim(orientacionposicion)
            _articulo = Trim(articulo)
            _articuloValor = Trim(articulo_valor)
            _articulo_referencia = Trim(ArticuloReferencia)
            _idubicacionmaterial = idubicacionmaterial
            _ubicacionmaterial = Trim(ubicacionmaterial)
            _idmaterialpara = idmaterialpara
            _materialpara = Trim(materialpara)
            _idtipomaterial = IdTipoMaterial
            _tipomaterial = Trim(tipomaterial)
            _idtipocortes = idtipocortes
            _tipocortes = Trim(TipoCortes)
            _imagentipocorte = ImagenTipoCorte
            _indicador = indicador
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = Trim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Overrides Function Formulacion_Formula_Valor(conIds As Boolean) As Dictionary(Of String, String())
        Formulacion_Formula_Valor = New Dictionary(Of String, String())
        Try
            Formulacion_Formula_Valor.Add("REFERENCIA", {If(_articulo.StartsWith("="), _articulo, ""), _articuloValor})
            If _idfamiliamaterial = ClsEnums.FamiliasMateriales.VIDRIO Then
                Formulacion_Formula_Valor.Add("COLOR", {_acabado, _acabadovalor})
                Formulacion_Formula_Valor.Add("ANCHO", {_ancho, _anchovalor.ToString()})
                Formulacion_Formula_Valor.Add("ALTO", {_alto, _altovalor.ToString()})
                Formulacion_Formula_Valor.Add("ESPESOR", {_espesor, _espesorvalor})
            Else
                Formulacion_Formula_Valor.Add("ACABADO", {_acabado, _acabadovalor})
                Formulacion_Formula_Valor.Add("DIMENSION", {_ancho, _anchovalor.ToString()})
            End If
            Formulacion_Formula_Valor.Add("CANTIDAD", {_cantidad, _cantidadvalor.ToString()})
            Formulacion_Formula_Valor.Add("PXUNIDAD", {_piezasxunidad, _pxunidadvalor.ToString()})
            Formulacion_Formula_Valor.Add("DESCUENTO", {_descuento, _descuentovalor.ToString()})
            Formulacion_Formula_Valor.Add("DETALLE", {_observaciones, _observacionesvalor})
            Formulacion_Formula_Valor.Add("ORIENTACION", {"", _orientacionposicion})
            Formulacion_Formula_Valor.Add("UBICACION", {"", _ubicacionmaterial})
            Formulacion_Formula_Valor.Add("PARA", {"", _materialpara})
            Formulacion_Formula_Valor.Add("TIPO", {"", _tipomaterial})
            Formulacion_Formula_Valor.Add("PESO", {_peso, _pesovalor.ToString()})
            If _idfamiliamaterial = ClsEnums.FamiliasMateriales.PERFILERIA Then
                Formulacion_Formula_Valor.Add("CORTES", {"", _tipocortes})
            End If
            Formulacion_Formula_Valor.Add("VISIBILIDAD", {_visibilidad, Convert.ToInt32(_visibilidadvalor).ToString()})
            If conIds Then
                Formulacion_Formula_Valor.Add("ARTICULO", {_articulo, _articulo})
                Formulacion_Formula_Valor.Add("IDORIENTACIONPOSICION", {"", Convert.ToString(_idorientacionposicion)})
                Formulacion_Formula_Valor.Add("IDUBICACIONMATERIAL", {"", Convert.ToString(_idubicacionmaterial)})
                Formulacion_Formula_Valor.Add("IDMATERIALPARA", {"", Convert.ToString(_idmaterialpara)})
                Formulacion_Formula_Valor.Add("IDTIPOMATERIAL", {"", Convert.ToString(_idtipomaterial)})
                Formulacion_Formula_Valor.Add("IDTIPOCORTES", {"", Convert.ToString(_idtipocortes)})
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region

End Class
