Imports Datos
Public Class ClsObservacionesPlantillaOrdenProd

#Region "Variables"
    Private taobservaciones As New dsAlcoOrdenesProduccionTableAdapters.top008_observacionesHijoOpTableAdapter

#End Region

    Public Sub Insertar(usuario As String, idhijoOp As Integer, observacion As String, visibilidad As Boolean,
                        estado As Integer)
        Try
            taobservaciones.sp_top008_insert(usuario, idhijoOp, observacion, visibilidad, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub Insertar_desde_Plantilla(idplantilla As Integer, idhijoOprod As Integer, usuario As String)
        Try
            taobservaciones.sp_top008_insert_desdePlantilla(idplantilla, idhijoOprod, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxIdItemOp(idhijoOp As Integer)
        Try
            taobservaciones.sp_top008_deletebyIdOP(idhijoOp)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxId(id As Integer)
        Try
            taobservaciones.sp_top008_deleteById(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdHijoOP(idhijoOp As Integer) As List(Of ObservacionPlantilla)
        TraerporIdHijoOP = New List(Of ObservacionPlantilla)()
        Try
            Dim txall As dsAlcoOrdenesProduccion.top008_observacionesHijoOpDataTable = taobservaciones.TraerxIdHijoOp(idhijoOp)
            txall.Rows.Cast(Of dsAlcoOrdenesProduccion.top008_observacionesHijoOpRow).ToList.ForEach(
                Sub(Obs)
                    TraerporIdHijoOP.Add(New ObservacionPlantilla(Obs.fop008_rowid, Obs.fop008_usuarioCreacion, Obs.fop008_fechaCreacion,
                                            Obs.fop008_rowidHijoOp, String.Empty, Convert.ToBoolean(Obs.fop008_visibilidad),
                                            Obs.fop008_observacion, Obs.fop008_usuarioModificacion,
                                            Obs.fop008_fechaModificacion, Obs.fop008_rowidEstado, String.Empty))

                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
