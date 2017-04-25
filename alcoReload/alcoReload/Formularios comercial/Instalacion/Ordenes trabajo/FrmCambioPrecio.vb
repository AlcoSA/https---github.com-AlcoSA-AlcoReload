Public Class FrmCambioPrecio
#Region "Variables"
    Private _precio As Decimal
    Private _porcRetenido As Decimal
    Private _razonDeCambio As String
#End Region
#Region "Propiedades"
    Public Property Precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property
    Public Property PorcRetenido() As Decimal
        Get
            Return _porcRetenido
        End Get
        Set(ByVal value As Decimal)
            _porcRetenido = value
        End Set
    End Property
    Public Property MotivoCambio() As String
        Get
            Return _razonDeCambio
        End Get
        Set(ByVal value As String)
            _razonDeCambio = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Function hayCambios()
        Try
            If nudPrecio.Value = _precio And nudRetenido.Value = _porcRetenido Then
                Return False
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
#End Region
    Private Sub FrmCambioPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            nudPrecio.Value = _precio
            nudRetenido.Value = _porcRetenido
            If _razonDeCambio IsNot Nothing Then
                txtRazon.Text = _razonDeCambio
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If hayCambios() Then
                If txtRazon.Text = String.Empty Then
                    ErrorProvider.SetError(txtRazon, "Debe indicar el motivo del cambio de precio")
                    Return
                End If
                ErrorProvider.Clear()
                _precio = nudPrecio.Value
                _porcRetenido = nudRetenido.Value
                _razonDeCambio = txtRazon.Text
                Me.DialogResult = DialogResult.OK
            Else
                Me.DialogResult = DialogResult.Abort
            End If
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class