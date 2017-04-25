Imports Datos
Public Class ClsDescuentosGeneralesPlantillaOrdenProd
#Region "Variables"
    Private tadescuentos As New dsAlcoOrdenesProduccionTableAdapters.top010_descuentosGlobalesHijoOpTableAdapter
#End Region

    Public Sub Insertar(idhijoop As Integer, iddescuento As Integer, formula As String,
                        valor As Decimal, usuario As String)
        Try
            tadescuentos.sp_top010_insert(idhijoop, iddescuento, formula, valor,
                                         usuario, ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxIdItemOp(idhijoOp As Integer)
        Try
            tadescuentos.sp_top010_deleteByIdOP(idhijoOp)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdHijoOP(idhijoOp As Integer) As List(Of descuentoGlobal)
        TraerporIdHijoOP = New List(Of descuentoGlobal)
        Try
            Dim taAll As New dsAlcoOrdenesProduccionTableAdapters.sp_top010_selectByIdHijoOPTableAdapter
            Dim txall As dsAlcoOrdenesProduccion.sp_top010_selectByIdHijoOPDataTable = taAll.GetData(idhijoOp)
            txall.Rows.Cast(Of dsAlcoOrdenesProduccion.sp_top010_selectByIdHijoOPRow).ToList.ForEach(
            Sub(d)
                TraerporIdHijoOP.Add(New descuentoGlobal(d.fop010_rowid, d.fop010_rowidHijoOp, d.fop010_rowidDescuento, d.fi026_descuento,
                                                         d.fop010_formula, d.fop010_valor, d.fop010_usuarioCreacion, d.fop010_fechaCreacion,
                                                         d.fop010_usuarioModificacion, d.fop010_fechaModificacion, d.fop010_rowidEstado, String.Empty))
            End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function


End Class
