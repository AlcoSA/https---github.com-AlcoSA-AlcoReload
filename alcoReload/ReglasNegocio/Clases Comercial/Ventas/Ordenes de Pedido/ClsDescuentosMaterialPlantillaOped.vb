Imports Datos
Public Class ClsDescuentosMaterialPlantillaOped
#Region "Variables"
    Private tadescuentosm As New dsAlcoProduccionTableAdapters.tp011_descuentosmaterialesHijoOPTableAdapter
#End Region
    Public Sub Insertar(idmaterial As Integer, iddescuento As Integer, formula As String,
                    valor As Decimal, usuario As String)
        Try
            tadescuentosm.sp_tp011_insert(idmaterial, iddescuento, formula,
                                         valor, usuario, ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarxIdItemOp(idhijoOp As Integer)
        Try
            tadescuentosm.sp_tp011_deletebyIdHijoOp(idhijoOp)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdMaterialHijoOp(idmaterialhijoOP As Integer, ByRef Optional tb As DataTable = Nothing) As List(Of DescuentoMaterial)
        TraerxIdMaterialHijoOp = New List(Of DescuentoMaterial)
        Try
            Dim taAll As New dsAlcoProduccionTableAdapters.sp_tp011_selectbyIdMaterialHijoOpTableAdapter
            Dim txall As dsAlcoProduccion.sp_tp011_selectbyIdMaterialHijoOpDataTable = taAll.GetData(idmaterialhijoOP)
            For Each d As dsAlcoProduccion.sp_tp011_selectbyIdMaterialHijoOpRow In txall.Rows
                TraerxIdMaterialHijoOp.Add(New DescuentoMaterial(d.fp011_rowid, d.fp011_rowidmaterial, d.fp011_rowiddescuento,
                                                                 d.fi026_descuento, d.fp011_formula, d.fp011_valor,
                                                                 d.fp011_usuariocreacion, d.fp011_fechacreacion, d.fp011_usuariomodificacion,
                                                                d.fp011_fechamodificacion, d.fp011_rowidestado, d.fi001_Descripcion))
            Next
            tb = If(txall.Count > 0, txall.CopyToDataTable, New DataTable)

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
