Imports Datos
Public Class ClsDescuentosGeneralesPlantillaOped
#Region "Variables"
    Private tadescuentos As New dsAlcoProduccionTableAdapters.tp012_descuentosGlobalesHijoOpTableAdapter
#End Region

    Public Sub Insertar(idhijoop As Integer, iddescuento As Integer, formula As String,
                        valor As Decimal, usuario As String)
        Try
            tadescuentos.sp_tp012_insert(idhijoop, iddescuento, formula, valor,
                                         usuario, ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxIdItemOp(idhijoOp As Integer)
        Try
            tadescuentos.sp_tp012_deleteByIdHijoOp(idhijoOp)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdHijoOP(idhijoOp As Integer, ByRef Optional tb As DataTable = Nothing) As List(Of descuentoGlobal)
        TraerporIdHijoOP = New List(Of descuentoGlobal)
        Try
            Dim taAll As New dsAlcoProduccionTableAdapters.sp_tp012_selectByIdHijoOpTableAdapter
            Dim txall As dsAlcoProduccion.sp_tp012_selectByIdHijoOpDataTable = taAll.GetData(idhijoOp)
            txall.Rows.Cast(Of dsAlcoProduccion.sp_tp012_selectByIdHijoOpRow).ToList.ForEach(
            Sub(d)
                TraerporIdHijoOP.Add(New descuentoGlobal(d.fp012_rowid, d.fp012_rowidhijoOp, d.fp012_rowiddescuento, d.fi026_descuento,
                                                         d.fp012_formula, d.fp012_valor, d.fp012_usuariocreacion, d.fp012_fechacreacion,
                                                         d.fp012_usuariomodificacion, d.fp012_fechamodificacion, d.fp012_rowidestado, String.Empty))
            End Sub)
            tb = If(txall.Count > 0, txall.CopyToDataTable, New DataTable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function


End Class
