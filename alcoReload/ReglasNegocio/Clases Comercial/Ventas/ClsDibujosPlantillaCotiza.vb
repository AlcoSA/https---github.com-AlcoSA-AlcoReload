Imports Datos
Public Class ClsDibujosPlantillaCotiza
#Region "Variables"
    Private tadibujos As New dsAlcoCotizacionesTableAdapters.tc062_dibujosHijoCotizaTableAdapter
#End Region

    Public Sub Insertar(idhijocotiza As Integer, idplantilla As Integer, usuario As String)
        Try
            tadibujos.sp_tc062_insert(idhijocotiza, idplantilla, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub BorrarporIdHijoCotiza(idhijocotiza As Integer)
        Try
            tadibujos.sp_tc062_deletebyIdhijoCotiza(idhijocotiza)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdHijoCotiza(idhijocotiza As Integer) As List(Of DibujoModelo)
        TraerporIdHijoCotiza = New List(Of DibujoModelo)
        Try
            Dim txall As dsAlcoCotizaciones.tc062_dibujosHijoCotizaDataTable = tadibujos.GetDataBy2(idhijocotiza)
            For Each dm As dsAlcoCotizaciones.tc062_dibujosHijoCotizaRow In txall.Rows
                TraerporIdHijoCotiza.Add(New DibujoModelo(dm.fc062_rowid, dm.fc062_usuarioCreacion, dm.fc062_fechaCreacion,
                                                dm.fc062_nombre, dm.fc062_rowididhijoCotiza, dm.fc062_customdxf, dm.fc062_predeterminado,
                                                dm.fc062_plantillavidrio, dm.fc062_usuarioModificacion, dm.fc062_fechaModificacion, dm.fc062_rowidEstado, String.Empty))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
