Imports Datos
Public Class ClsDibujosPlantillaOrdenProd
#Region "Variables"
    Private tadibujos As New dsAlcoOrdenesProduccionTableAdapters.top007_dibujosHijosOpTableAdapter
#End Region

    Public Sub Insertar(idhijoOprod As Integer, usuario As String, nombre As String,
                        predeterminado As String, dxf As String, estado As Integer, plantilla_vidrio As Boolean)
        Try
            tadibujos.sp_top007_insert(idhijoOprod, usuario, nombre, predeterminado, dxf,
                                       estado, plantilla_vidrio)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub Insertar_desde_Plantilla(idplantilla As Integer, idhijoOprod As Integer, usuario As String)
        Try
            tadibujos.sp_top007_insert_desdePlantilla(idplantilla, idhijoOprod, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxIdItemOp(idhijoOp As Integer)
        Try
            tadibujos.sp_top007_deletebyIdOP(idhijoOp)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarxId(id As Integer)
        Try
            tadibujos.sp_top007_deletebyId(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdHijoOp(idhijoOp As Integer, ByRef Optional tb As DataTable = Nothing) As List(Of DibujoModelo)
        TraerporIdHijoOp = New List(Of DibujoModelo)
        Try
            Dim txall As dsAlcoOrdenesProduccion.top007_dibujosHijosOpDataTable = tadibujos.TraerxIdHijoOp(idhijoOp)
            txall.Rows.Cast(Of dsAlcoOrdenesProduccion.top007_dibujosHijosOpRow).ToList.ForEach(
                Sub(dm)
                    TraerporIdHijoOp.Add(New DibujoModelo(dm.fop007_rowid, dm.fop007_usuarioCreacion, dm.fop007_fechaCreacion,
                                         dm.fop007_nombre, dm.fop007_rowidHijoOp, dm.fop007_customDxf, dm.fop007_predeterminado,
                                         dm.fop007_plantillaVidrio, dm.fop007_usuarioModificacion, dm.fop007_fechaModificacion,
                                         dm.fop007_rowidEstado, String.Empty))
                End Sub)
            tb = If(txall.Count > 0, txall.CopyToDataTable, New DataTable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
