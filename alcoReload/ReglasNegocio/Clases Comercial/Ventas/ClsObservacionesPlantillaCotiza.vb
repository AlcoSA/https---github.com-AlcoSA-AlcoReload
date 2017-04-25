Imports Datos
Public Class ClsObservacionesPlantillaCotiza

#Region "Variables"
    Private taobservaciones As New dsAlcoCotizacionesTableAdapters.tc063_observacionesHijoCotizaTableAdapter
#End Region

    Public Sub Insertar(idhijocotiza As Integer, idplantilla As Integer, usuario As String)
        Try
            taobservaciones.sp_tc063_insert(idplantilla, idhijocotiza, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub BorrarporIdHijoCotiza(idhijocotiza As Integer)
        Try
            taobservaciones.sp_tc063_deletebyIdHijoCotiza(idhijocotiza)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdHijoCotiza(idhijocotiza As Integer) As List(Of ObservacionPlantilla)
        TraerporIdHijoCotiza = New List(Of ObservacionPlantilla)()
        Try
            Dim txall As dsAlcoCotizaciones.tc063_observacionesHijoCotizaDataTable = taobservaciones.GetDataBy2(idhijocotiza)
            For Each op As dsAlcoCotizaciones.tc063_observacionesHijoCotizaRow In txall.Rows
                TraerporIdHijoCotiza.Add(New ObservacionPlantilla(op.fc063_rowid, op.fc063_usuarioCreacion, op.fc063_fechaCreacion,
                                                        op.fc063_rowidIdHijoCotiza, String.Empty, Convert.ToBoolean(op.fc063_visibilidad),
                                                                  op.fc063_observacion, op.fc063_usuarioModificacion,
                                                        op.fc063_fechaModificacion, op.fc063_rowidEstado, String.Empty))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
