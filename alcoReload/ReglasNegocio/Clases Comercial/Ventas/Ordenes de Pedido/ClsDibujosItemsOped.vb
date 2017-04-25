Imports Datos
Public Class ClsDibujosItemsOps
#Region "Variables"
    Private tadibujositems As New dsAlcoProduccionTableAdapters.tp007_dibujosiPadresOPTableAdapter
#End Region

#Region "Procedimientos"

    Public Function Ingresar(idpadre As Integer, idhijo As Integer, usuario As String, dxf As String, x As Double, y As Double, ancho As Double,
                        alto As Double, orientacion As Integer, nivel As Integer, idcontenedor As Integer) As Integer
        Try
            Return Convert.ToInt32(tadibujositems.sp_tp007_insert(idpadre, idhijo,
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
            tadibujositems.sp_tp007_deleteByIdPadreOp(iditemPadreop)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdITemOp(iditemop As Integer, ByRef Optional tb As DataTable = Nothing) As List(Of DibujoPadreCotiza)
        TraerxIdITemOp = New List(Of DibujoPadreCotiza)
        Try
            Dim ta As dsAlcoProduccion.tp007_dibujosiPadresOPDataTable = tadibujositems.TraerpoxIdPadreOP(iditemop)
            ta.Rows.Cast(Of dsAlcoProduccion.tp007_dibujosiPadresOPRow).ToList.ForEach(
                Sub(dc)
                    TraerxIdITemOp.Add(New DibujoPadreCotiza(dc.fp007_rowid, dc.fp007_fechacreacion, dc.fp007_usuariocreacion,
                                                             dc.fp007_rowiditempadreOp, dc.fp007_rowiditemhijoOP, dc.fp007_x, dc.fp007_y, dc.fp007_ancho, dc.fp007_alto, dc.fp007_orientacion, dc.fp007_nivel,
                                                             dc.fp007_idcontenedor, dc.fp007_dxf, dc.fp007_fechamodificacion, dc.fp007_usuariomodificacion))
                End Sub)
            tb = If(ta.Count > 0, ta.CopyToDataTable, New DataTable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class


