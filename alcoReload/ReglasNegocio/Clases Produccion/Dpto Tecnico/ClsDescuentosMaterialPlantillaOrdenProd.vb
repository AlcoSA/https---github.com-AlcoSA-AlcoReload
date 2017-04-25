Imports Datos
Public Class ClsDescuentosMaterialPlantillaOrdenProd
#Region "Variables"
    Private tadescuentosm As New dsAlcoOrdenesProduccionTableAdapters.top009_descuentosMaterialesHijoOpTableAdapter
#End Region
    Public Sub Insertar(idmaterial As Integer, iddescuento As Integer, formula As String,
                    valor As Decimal, usuario As String)
        Try
            tadescuentosm.sp_top009_insert(idmaterial, iddescuento, formula,
            valor, usuario, ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdMaterialHijoOp(idmaterialhijoOP As Integer) As List(Of DescuentoMaterial)
        TraerxIdMaterialHijoOp = New List(Of DescuentoMaterial)
        Try
            Dim taAll As New dsAlcoOrdenesProduccionTableAdapters.sp_top009_selectByIdMaterialTableAdapter
            Dim txall As dsAlcoOrdenesProduccion.sp_top009_selectByIdMaterialDataTable = taAll.GetData(idmaterialhijoOP)
            txall.Rows.Cast(Of dsAlcoOrdenesProduccion.sp_top009_selectByIdMaterialRow).ToList.ForEach(
            Sub(d)
                TraerxIdMaterialHijoOp.Add(New DescuentoMaterial(d.fop009_rowid, d.fop009_rowidMaterial, d.fop009_rowidDescuento,
                                                                 d.fi026_descuento, d.fop009_formula, d.fop009_valor,
                                                                 d.fop009_usuarioCreacion, d.fop009_fechaCreacion, d.fop009_usuarioModificacion,
                                                                d.fop009_fechaModificacion, d.fop009_rowidEstado, String.Empty))
            End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub EliminarxIdItemOp(idhijoop As Integer)
        Try
            tadescuentosm.sp_top009_deletebyIdHijoOp(idhijoop)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

End Class
