Imports Datos
Public Class ClsHistorialCorreosCotizacion
#Region "Variables"
    Private _objhc As New dsAlcoCotizacionesTableAdapters.tc105_historialcorreoscotizaTableAdapter
#End Region
    Public Sub Insertar(idcotizacion As Integer, ip As String, destino As String, direnvio As String,
                        nombre As String, identificacion As String, cargo_empresa As String, asunto As String, cuerpo As String)
        Try
            _objhc.sp_tc105_insert(idcotizacion, ip, destino, direnvio, nombre, identificacion, cargo_empresa, asunto, cuerpo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerporIdCotizacion(idcotizacion As Integer) As List(Of HistorialCorreos)
        TraerporIdCotizacion = New List(Of HistorialCorreos)
        Try
            Dim tp As dsAlcoCotizaciones.tc105_historialcorreoscotizaDataTable = _objhc.TraerxIdCotizacion(idcotizacion)
            For Each hc As dsAlcoCotizaciones.tc105_historialcorreoscotizaRow In tp.Rows
                TraerporIdCotizacion.Add(New HistorialCorreos(hc.fc105_rowid, hc.fc105_rowidcotiza,
                                                         hc.fc105_ip, hc.fc105_destinatario, hc.fc105_direccionenvio,
                                                         hc.fc105_identificacion, hc.fc105_cargoempresa,
                                                         hc.fc105_asunto, hc.fc105_cuerpo, hc.fc105_fechaenvio))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
