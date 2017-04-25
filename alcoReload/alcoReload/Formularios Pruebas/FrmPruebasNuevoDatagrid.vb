Public Class FrmPruebasNuevoDatagrid

    Private Sub btncargar_Click_1(sender As Object, e As EventArgs) Handles btncargar.Click
        Try
            For i = 0 To 50
                Dim n = dw.Nodes.Add(i.ToString() + "i")
                For j = 0 To 20
                    Dim nd = n.Nodes.Add(j.ToString() + "j", "Prueba", "Esto es una prueba")
                    For k = 0 To 20
                        Dim ndc = nd.Nodes.Add(k.ToString() + "k")
                    Next
                Next
            Next
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class