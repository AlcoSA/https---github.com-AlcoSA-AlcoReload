Public Class FrmCantidad_a_Duplicar
#Region "Variables"

#End Region

#Region "Propiedades"
    Public Property Cantidad_Maxima As Decimal
        Get
            Return nudcantidadduplicar.Maximum
        End Get
        Set(value As Decimal)
            nudcantidadduplicar.Maximum = value
        End Set
    End Property

    Public Property Cantidad As Decimal
        Get
            Return nudcantidadduplicar.Value
        End Get
        Set(value As Decimal)
            nudcantidadduplicar.Value = value
        End Set
    End Property

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            DialogResult = DialogResult.Cancel
            Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        Try
            DialogResult = DialogResult.OK
            Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
End Class