Imports Datos
Public Class ClsDescuentosMaterialPlantillaCotiza
#Region "Variables"
    Private tadescuentosm As New dsAlcoCotizacionesTableAdapters.tc064_descuentosmaterialesHijoCotizaTableAdapter
#End Region
    Public Sub Insertar(idmaterial As Integer, iddescuento As Integer, formula As String,
                    valor As Decimal, usuario As String)
        Try
            tadescuentosm.sp_tc064_insert(idmaterial, iddescuento, formula,
                                         valor, usuario, ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub BorrarporIdHijoCotiza(idhijocotiza As Integer)
        Try
            tadescuentosm.sp_tc064_deletebyIdHijoCotiza(idhijocotiza)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerxIdMaterialHijoCotiza(idmaterialhijocotiza As Integer) As List(Of DescuentoMaterial)
        TraerxIdMaterialHijoCotiza = New List(Of DescuentoMaterial)
        Try
            Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc064_selectbyIdMaterialHijoCotizaTableAdapter
            Dim txall As dsAlcoCotizaciones.sp_tc064_selectbyIdMaterialHijoCotizaDataTable = taAll.GetData(idmaterialhijocotiza)
            For Each d As dsAlcoCotizaciones.sp_tc064_selectbyIdMaterialHijoCotizaRow In txall.Rows
                TraerxIdMaterialHijoCotiza.Add(New DescuentoMaterial(d.fc064_rowid, d.fc064_rowidmaterial, d.fc064_rowiddescuento, d.fi026_descuento,
                                                                     d.fc064_formula, d.fc064_valor,
                                                     d.fc064_usuariocreacion, d.fc064_fechacreacion, d.fc064_usuariomodificacion,
                                                     d.fc064_fechamodificacion, d.fc064_rowidestado, d.fi001_Descripcion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
