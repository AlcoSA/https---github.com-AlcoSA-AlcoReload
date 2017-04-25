Imports Datos
Public Class ClsPlantillaOrdenProd
#Region "vars"
    Private plantilla As New dsAlcoOrdenesProduccionTableAdapters.top011_plantillasOPTableAdapter
#End Region
#Region "procs"
    Public Sub Insertar(usuario As String, idhijoop As Integer, idtipoModelo As Integer, idClasificacion As Integer,
                             idFamiliaModelo As Integer, idConfiguracion As Integer, idAdicionales As Integer)
        Try
            plantilla.sp_top011_insert(usuario, idhijoop, idtipoModelo,
                                        idClasificacion, idFamiliaModelo,
                                        idConfiguracion, idAdicionales)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(usuario As String, idhijoop As Integer, idtipoModelo As Integer, idClasificacion As Integer,
                             idFamiliaModelo As Integer, idConfiguracion As Integer, idAdicionales As Integer)
        Try
            plantilla.sp_top011_update(usuario, idhijoop, idtipoModelo, idClasificacion,
                                       idFamiliaModelo, idConfiguracion, idAdicionales)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerHistorialCreadoTabla(nit As String, codobra As String) As DataTable
        TraerHistorialCreadoTabla = Nothing
        Try
            Dim plant As New dsAlcoOrdenesProduccionTableAdapters.sp_top011_selectGroupedTableAdapter
            Return plant.GetData(nit, codobra).Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporIdOrdenProd(id As Integer) As PlantillaModelo
        TraerporIdOrdenProd = New PlantillaModelo()
        Try
            Dim taxId As New dsAlcoOrdenesProduccionTableAdapters.sp_top011_selectByIdHijoOpTableAdapter
            Dim txid As dsAlcoOrdenesProduccion.sp_top011_selectByIdHijoOpDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim pm As dsAlcoOrdenesProduccion.sp_top011_selectByIdHijoOpRow = DirectCast(txid.Rows(0), dsAlcoOrdenesProduccion.sp_top011_selectByIdHijoOpRow)
                TraerporIdOrdenProd = New PlantillaModelo(pm.Id, pm.Usuario_Creacion, pm.Fecha_Creacion,
                                                   pm.Id_TipoModelo, pm.Prefijo_Tipo_Modelo, pm.Tipo_Modelo,
                                                   pm.Id_ClasificacionModelo, pm.Prefijo_Clasificacion_Modelo, pm.Clasificacion_Modelo,
                                                   pm.IdFamiliaModelo, pm.Prefijo_Familia_Modelo, pm.Familia_Modelo,
                                                   pm.Id_Configuracion, pm.Configuracion,
                                                   pm.Id_CaracteristicasAd, pm.Prefijo_caracteristica_ad, pm.Caracteristica_Adicional,
                                                   pm.Nombre_Modelo, pm.Descripcion, pm.Usuario_Modificacion,
                                               pm.Fecha_Modificacion, 0, String.Empty, 0, False, False)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporId(id As Integer) As PlantillaModelo
        TraerporId = New PlantillaModelo()
        Try
            Dim taxId As New dsAlcoOrdenesProduccionTableAdapters.sp_top011_selectByIdTableAdapter
            Dim txid As dsAlcoOrdenesProduccion.sp_top011_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim pm As dsAlcoOrdenesProduccion.sp_top011_selectByIdRow = DirectCast(txid.Rows(0), dsAlcoOrdenesProduccion.sp_top011_selectByIdRow)
                TraerporId = New PlantillaModelo(pm.Id, pm.Usuario_Creacion, pm.Fecha_Creacion,
                                                   pm.Id_TipoModelo, pm.Prefijo_Tipo_Modelo, pm.Tipo_Modelo,
                                                   pm.Id_ClasificacionModelo, pm.Prefijo_Clasificacion_Modelo, pm.Clasificacion_Modelo,
                                                   pm.IdFamiliaModelo, pm.Prefijo_Familia_Modelo, pm.Familia_Modelo,
                                                   pm.Id_Configuracion, pm.Configuracion,
                                                   pm.Id_CaracteristicasAd, pm.Prefijo_caracteristica_ad, pm.Caracteristica_Adicional,
                                                   pm.Nombre_Modelo, pm.Descripcion, pm.Usuario_Modificacion,
                                               pm.Fecha_Modificacion, 0, String.Empty, 0, False, False)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class
