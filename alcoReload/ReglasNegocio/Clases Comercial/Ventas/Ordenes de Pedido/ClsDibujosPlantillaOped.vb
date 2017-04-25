Imports Datos
Public Class ClsDibujosPlantillaOped
#Region "Variables"
    Private tadibujos As New dsAlcoProduccionTableAdapters.tp008_dibujosHijoOPTableAdapter
#End Region

    Public Sub Insertar(idhijoOp As Integer, idHijoCotiza As Integer, usuario As String)
        Try
            tadibujos.sp_tp008_insert(idhijoOp, idHijoCotiza, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxIdItemOp(idhijoOp As Integer)
        Try
            tadibujos.sp_tp008_deleteByIdItemOp(idhijoOp)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdHijoOp(idhijoOp As Integer, ByRef Optional tb As DataTable = Nothing) As List(Of DibujoModelo)
        TraerporIdHijoOp = New List(Of DibujoModelo)
        Try
            Dim txall As dsAlcoProduccion.tp008_dibujosHijoOPDataTable = tadibujos.TraerporIdItemOp(idhijoOp)
            txall.Rows.Cast(Of dsAlcoProduccion.tp008_dibujosHijoOPRow).ToList.ForEach(
                Sub(dm)
                    TraerporIdHijoOp.Add(New DibujoModelo(dm.fp008_rowid, dm.fp008_usuarioCreacion, dm.fp008_fechaCreacion,
                                         dm.fp008_nombre, dm.fp008_rowididhijoOP, dm.fp008_customdxf, dm.fp008_predeterminado,
                                         dm.fp008_plantillavidrio, dm.fp008_usuarioModificacion, dm.fp008_fechaModificacion,
                                         dm.fp008_rowidEstado, String.Empty))
                End Sub)
            tb = If(txall.Count > 0, txall.CopyToDataTable, New DataTable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
