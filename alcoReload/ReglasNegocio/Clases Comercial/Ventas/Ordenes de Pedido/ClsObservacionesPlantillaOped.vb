Imports Datos
Public Class ClsObservacionesPlantillaOped

#Region "Variables"
    Private taobservaciones As New dsAlcoProduccionTableAdapters.tp009_observacionesHijoOPTableAdapter

#End Region

    Public Sub Insertar(idhijoOp As Integer, iditemCotiza As Integer, usuario As String)
        Try
            taobservaciones.sp_tp009_insert(iditemCotiza, idhijoOp, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxIdItemOp(idhijoOp As Integer)
        Try
            taobservaciones.sp_tp009_deleteByIdItemOp(idhijoOp)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdHijoOP(idhijoOp As Integer, ByRef Optional tb As DataTable = Nothing) As List(Of ObservacionPlantilla)
        TraerporIdHijoOP = New List(Of ObservacionPlantilla)()
        Try
            Dim txall As dsAlcoProduccion.tp009_observacionesHijoOPDataTable = taobservaciones.TraerxIdItemOp(idhijoOp)
            txall.Rows.Cast(Of dsAlcoProduccion.tp009_observacionesHijoOPRow).ToList.ForEach(
                Sub(Obs)
                    TraerporIdHijoOP.Add(New ObservacionPlantilla(Obs.fp009_rowid, Obs.fp009_usuarioCreacion, Obs.fp009_fechaCreacion,
                                            Obs.fp009_rowidIdHijoOP, String.Empty, Convert.ToBoolean(Obs.fp009_visibilidad),
                                            Obs.fp009_observacion, Obs.fp009_usuarioModificacion,
                                            Obs.fp009_fechaModificacion, Obs.fp009_rowidEstado, String.Empty))

                End Sub)
            tb = If(txall.Count > 0, txall.CopyToDataTable, New DataTable)

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
