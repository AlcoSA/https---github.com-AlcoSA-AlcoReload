Imports Datos
Public Class ClsDescuentosGeneralesPlantillaCotiza
#Region "Variables"
    Private tadescuentos As New dsAlcoCotizacionesTableAdapters.tc065_descuentosGlobalesHijoCotizaTableAdapter
#End Region

    Public Sub Insertar(idhijocotiza As Integer, iddescuento As Integer, formula As String,
                        valor As Decimal, usuario As String)
        Try
            tadescuentos.sp_tc065_insert(idhijocotiza, iddescuento, formula,
                                         valor, usuario, ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub BorrarporIdHijoCotiza(idhijocotiza As Integer)
        Try
            tadescuentos.sp_tc065_deletebyIdHijoCotiza(idhijocotiza)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdHijoCotiza(idhijocotiza As Integer) As List(Of descuentoGlobal)
        TraerporIdHijoCotiza = New List(Of descuentoGlobal)
        Try
            Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc065_selectbyIdHijoCotizaTableAdapter
            Dim txall As dsAlcoCotizaciones.sp_tc065_selectbyIdHijoCotizaDataTable = taAll.GetData(idhijocotiza)
            For Each d As dsAlcoCotizaciones.sp_tc065_selectbyIdHijoCotizaRow In txall.Rows
                TraerporIdHijoCotiza.Add(New descuentoGlobal(d.fc065_rowid, d.fc065_rowidhijocotiza, d.fc065_rowiddescuento,
                                                             d.fi026_descuento, d.fc065_formula, d.fc065_valor,
                                                     d.fc065_usuariocreacion, d.fc065_fechacreacion, d.fc065_usuariomodificacion,
                                                     d.fc065_fechamodificacion, d.fc065_rowidestado, String.Empty))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class

