Imports Datos
Public Class ClsMaterialesPlantillaOrdenProd
#Region "Variables"
    Private tamaterial As New dsAlcoOrdenesProduccionTableAdapters.top004_materialesHijoOpTableAdapter
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
            Return Convert.ToInt32(tamaterial.sp_top004_insert(usuario, idhijoop, iditemplantilla, idfamiliamateria,
                                       idorientacionposicionmaterial, idubicacionmaterial, idmaterialpara, idtipoMaterial, idtipocortes,
                                       espesor, valor_espesor,
                                       acabado, acabado_valor, articulo, articulo_valor,
                                       cantidad, cantidad_valor, pxuni, pxuni_valor, ancho,
                                       ancho_valor, peso, peso_valor,
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
            tamaterial.sp_top004_deletebyIdOP(idhijoOp)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Elimina el material y todos los descuentos asociados a este
    ''' </summary>
    ''' <param name="id">Id del material</param>
    Public Sub EliminarxId(id As Integer)
        Try
            tamaterial.sp_top004_deletebyId(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerporIdHijoOp(idhijocotiza As Integer) As List(Of MaterialPlantillaMovimiento)
        TraerporIdHijoOp = New List(Of MaterialPlantillaMovimiento)
        Try
            Dim taAll As New dsAlcoOrdenesProduccionTableAdapters.sp_top004_selectByIdHijoOPTableAdapter
            Dim txall As dsAlcoOrdenesProduccion.sp_top004_selectByIdHijoOPDataTable = taAll.GetData(idhijocotiza)
            txall.Rows.Cast(Of dsAlcoOrdenesProduccion.sp_top004_selectByIdHijoOPRow).ToList.ForEach(
                Sub(mp)
                    TraerporIdHijoOp.Add(New MaterialPlantillaMovimiento(mp.Id, mp.Id_hijo_Op, mp.Id_Item_Plantilla, mp.Usuario_Creacion, mp.Fecha_Creacion,
                                                     mp.Id_Familia, mp.Familia, mp.Id_Orientacion, mp.Orientacion, mp.Articulo, mp.Articulo_valor, mp.Espesor, mp.valor_espesor,
                                                                     mp.Id_UbicaMaterial, mp.Ubicacion_Material, mp.Id_MaterialPara, mp.Material_Para, mp.Acabado, mp.acabado_valor,
                                                                     mp.Id_TipoMaterial, mp.Tipo_Material, mp.Id_TiposCortes, mp.Tipo_Cortes, mp.imagen_tipo_corte, mp.Cantidad, mp.cantidad_valor,
                                                                     mp.Pxunidad, mp.pxunidad_valor, mp.Ancho, mp.ancho_valor, mp.Alto,
                                                                     mp.alto_valor, mp.Peso, mp.peso_valor, mp.Descuento, mp.descuento_valor,
                                                                     mp.Observaciones, mp.observaciones_valor, mp.Usuario_Modificacion, mp.Fecha_Modificacion,
                                                                     mp.Id_Estado, mp.Estado, mp.Visibilidad, mp.visibilidad_valor,
                                                                     mp.utilizar, mp.PorcentajeDesperdicio, mp.costo_instalacion, mp.indicador))
                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class