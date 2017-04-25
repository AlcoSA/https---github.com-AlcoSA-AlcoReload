Public Class FrmComplementos
#Region "vars"
    Private _complementos As Dictionary(Of Integer, String)
    Private _seleccionados As List(Of Integer) = New List(Of Integer)
#End Region
#Region "props"
    Public Property Complementos As Dictionary(Of Integer, String)
        Get
            Return _complementos
        End Get
        Set(value As Dictionary(Of Integer, String))
            _complementos = value
        End Set
    End Property
    Public Property Seleccionados As List(Of Integer)
        Get
            Return _seleccionados
        End Get
        Set(value As List(Of Integer))
            _seleccionados = value
        End Set
    End Property
#End Region
    Private Sub FrmComplementos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            chlubicacion.DataSource = New BindingSource(_complementos, Nothing)
            chlubicacion.DisplayMember = "Value"
            chlubicacion.ValueMember = "Key"
            For i As Integer = 0 To chlubicacion.Items.Count - 1
                If _seleccionados.Contains(DirectCast(chlubicacion.Items.Item(i), KeyValuePair(Of Integer, String)).Value) Then
                    chlubicacion.SetItemChecked(i, True)
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        Try
            _seleccionados.Clear()
            For Each c In chlubicacion.CheckedItems
                _seleccionados.Add(DirectCast(c, KeyValuePair(Of Integer, String)).Value)
            Next
            DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class