Imports Datos
Public Class ClsMaterialesPlantillaOped
#Region "Variables"
    Private tamaterial As New dsAlcoProduccionTableAdapters.tp005_materialeshijoOpTableAdapter
#End Region


    Public Function Insertar(idhijoop As Integer, iditemplantilla As Integer, usuario As String, idfamiliamateria As Integer, idorientacionposicionmaterial As Integer,
                    espesor As String, valor_espesor As String, articulo As String, articulo_valor As String,
                    idubicacionmaterial As Integer, idmaterialpara As Integer, acabado As String, acabado_valor As String, idtipoMaterial As Integer,
                    idtipocortes As Integer, cantidad As String, cantidad_valor As Decimal, pxuni As String, pxuni_valor As Decimal,
                    ancho As String, ancho_valor As Decimal, alto As String, alto_valor As Decimal,
                    peso As String, peso_valor As Decimal, descuento As String, descuento_valor As Decimal,
                    observaciones As String, observaciones_valor As String, estado As Integer,
                    visibilidad As String, visibilidad_valor As Boolean, utilizar As Boolean,
                    desperdicio As Decimal, costo_instalacion As Decimal, indicador As Integer) As Integer
        Try
            Return Convert.ToInt32(tamaterial.sp_tp005_insert(idhijoop, usuario, iditemplantilla, idfamiliamateria,
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
    Public Sub EliminarxIdItemOp(idhijoOp As Integer)
        Try
            tamaterial.sp_tp005_deleteByIdHijoOp(idhijoOp)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerporIdHijoOp(idhijocotiza As Integer) As List(Of MaterialPlantillaMovimiento)
        TraerporIdHijoOp = New List(Of MaterialPlantillaMovimiento)
        Try
            Dim taAll As New dsAlcoProduccionTableAdapters.sp_tp005_selectByIdHijoOpTableAdapter
            Dim txall As dsAlcoProduccion.sp_tp005_selectByIdHijoOpDataTable = taAll.GetData(idhijocotiza)
            For Each mp As dsAlcoProduccion.sp_tp005_selectByIdHijoOpRow In txall.Rows
                TraerporIdHijoOp.Add(New MaterialPlantillaMovimiento(mp.Id, mp.Id_hijo_Op, mp.Id_Item_Plantilla, mp.Usuario_Creacion, mp.Fecha_Creacion,
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

Public Class MaterialPlantillaOp
    Inherits MaterialPlantilla
#Region "Variables"
    Private _idhijocotiza As Integer = 0
    Private _iditemoriginal As Integer = 0
    Private _utilizar As Boolean = True
#End Region
#Region "Propiedades"
    Public Property IdHijoCotiza As Integer
        Get
            Return _idhijocotiza
        End Get
        Set(value As Integer)
            _idhijocotiza = value
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
    Public _desperdicio As Decimal
    Public Property desperdicio() As Decimal
        Get
            Return _desperdicio
        End Get
        Set(ByVal value As Decimal)
            _desperdicio = value
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

    Public Sub New(id As Integer, idhijoOP As Integer, iditemoriginal As Integer, usuariocreacion As String, fechacreacion As Date,
                   idfamiliamaterial As Integer, familiamaterial As String, idorientacionposicion As Integer,
                   orientacionposicion As String, articulo As String, articuloReferencia As String, espesor As String, idubicacionmaterial As Integer,
                   ubicacionmaterial As String, idmaterialpara As Integer, materialpara As String, acabado As String,
                   idtipomaterial As Integer, tipomaterial As String, idtipocortes As Integer, tipocortes As String, imagentipocorte As Byte(),
                   cantidad As String, ancho As String, alto As String, peso As String, descuento As String, observaciones As String, usuariomodificacion As String,
                   fechamodificacion As Date, idestado As Integer, estado As String, visibilidad As String, utilizar As Boolean, desperdicio As Decimal)
        Try
            Me.Id = id
            _idhijocotiza = idhijoOP
            _iditemoriginal = iditemoriginal
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            Me.Cantidad = Trim(cantidad)
            Me.Ancho = Trim(ancho)
            Me.Alto = Trim(alto)
            Me.Descuento = Trim(descuento)
            Me.Observaciones = Trim(observaciones)
            Me.Visibilidad = Trim(visibilidad)
            Me.IdFamiliaMaterial = idfamiliamaterial
            Me.FamiliaMaterial = Trim(familiamaterial)
            Me.IdOrientacionyPosicion = idorientacionposicion
            Me.OrientacionyPosicion = Trim(orientacionposicion)
            Me.Articulo = Trim(articulo)
            Me.ArticuloReferencia = Trim(articuloReferencia)
            Me.Espesor = Trim(espesor)
            Me.IdUbicacionMaterial = idubicacionmaterial
            Me.UbicacionMaterial = Trim(ubicacionmaterial)
            Me.IdMaterialPara = idmaterialpara
            Me.MaterialPara = Trim(materialpara)
            Me.Acabado = Trim(acabado)
            Me.IdTipoMaterial = idtipomaterial
            Me.TipoMaterial = Trim(tipomaterial)
            Me.IdTipoCortes = idtipocortes
            Me.TipoCortes = Trim(tipocortes)
            Me.ImagenTipoCorte = imagentipocorte
            Me.peso = peso
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = Trim(estado)
            _utilizar = utilizar
            _desperdicio = desperdicio
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

End Class
