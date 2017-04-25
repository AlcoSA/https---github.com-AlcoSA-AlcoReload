Imports ReglasNegocio

Public Class frmDetallePagados
#Region "Variables"
    Private fuenteInicial As DataTable = Nothing
#End Region
#Region "Procedimientos"

#End Region
    Private Sub frmDetallePagados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim mMovitoPagoRet As New ClsMovitoPagoRetenido
            mMovitoPagoRet.traerDetalle(dwItems.TablaDatos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class