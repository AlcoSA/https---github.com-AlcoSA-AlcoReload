Imports Datos

Public Class ClsCambioPrecio
#Region "Variables"
    Private taCambioPrecio As New dsAlcoComercial2TableAdapters.tc099_cambioPrecioTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(Usuario As String, idMovitoOT As Integer, precioAnterior As Decimal, nuevoPrecio As Decimal,
                        porcRetenidoAnterior As Decimal, nuevoPorcRetenido As Decimal, motivo As String)
        Try
            taCambioPrecio.Insert(Usuario, idMovitoOT, precioAnterior, nuevoPrecio, porcRetenidoAnterior,
                                  nuevoPorcRetenido, motivo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
