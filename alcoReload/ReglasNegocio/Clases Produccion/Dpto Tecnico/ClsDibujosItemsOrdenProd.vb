Imports Datos
Public Class ClsDibujosItemsOrdenProd
#Region "Variables"
    Private tadibujositems As New dsAlcoOrdenesProduccionTableAdapters.top006_dibujosPadresOpTableAdapter
#End Region

#Region "Procedimientos"

    Public Function Ingresar(idpadre As Integer, idhijo As Integer, usuario As String, dxf As String, x As Double, y As Double, ancho As Double,
                        alto As Double, orientacion As Integer, nivel As Integer, idcontenedor As Integer) As Integer
        Try
            Return Convert.ToInt32(tadibujositems.sp_top006_insert(idpadre, idhijo,
                                                                  usuario, dxf, x, y,
                                                                  ancho, alto, orientacion,
                                                                  nivel,
                                                                  idcontenedor))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub BorrarxIdItemOp(iditemPadreop As Integer)
        Try
            tadibujositems.sp_top006_deleteByIdOP(iditemPadreop)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdITemOp(iditemop As Integer) As List(Of DibujoPadreCotiza)
        TraerxIdITemOp = New List(Of DibujoPadreCotiza)
        Try
            Dim ta As dsAlcoOrdenesProduccion.top006_dibujosPadresOpDataTable = tadibujositems.TraerporIdPadreOP(iditemop)
            ta.Rows.Cast(Of dsAlcoOrdenesProduccion.top006_dibujosPadresOpRow).ToList.ForEach(
                Sub(dc)
                    TraerxIdITemOp.Add(New DibujoPadreCotiza(dc.fop006_rowid, dc.fop006_fechaCreacion, dc.fop006_usuarioCreacion,
                                                             dc.fop006_rowidItemPadreOp, dc.fop006_rowidItemHijoOp, dc.fop006_x,
                                                             dc.fop006_y, dc.fop006_ancho, dc.fop006_alto, dc.fop006_orientacion, dc.fop006_nivel,
                                                             dc.fop006_idContenedor, dc.fop006_dxf, dc.fop006_fechaModificacion, dc.fop006_usuarioModificacion))
                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class


