Imports System.Printing
Imports System.Drawing.Printing
Public Class FrmConfiguracionImpresionCotiza
#Region "Variables"
    Dim prints As New PrinterSettings
#End Region
#Region "Propiedades"
    Public ReadOnly Property ConfiguracionImpresora As PrinterSettings
        Get
            Return prints
        End Get
    End Property
    Public ReadOnly Property ImprimirImagenes As Boolean
        Get
            Return chbimagenes.Checked
        End Get
    End Property


    Public ReadOnly Property NumeroCopias As Int32
        Get
            Return nudcopias.Value
        End Get
    End Property
    Public ReadOnly Property imprimirTodo As Boolean
        Get
            Return rbtodo.Checked
        End Get
    End Property
    Public ReadOnly Property desde As Int32
        Get
            Return If(String.IsNullOrEmpty(txtdesde.Text), 1, txtdesde.Text)
        End Get
    End Property
    Public ReadOnly Property hasta As Int32
        Get
            Return If(String.IsNullOrEmpty(txthasta.Text), 1, txthasta.Text)
        End Get
    End Property
#End Region
    Private Sub cargarImpresoras()
        Try
            For Each imp In PrinterSettings.InstalledPrinters
                cbimpresora.Items.Add(imp)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub FrmConfiguracionImpresionCotiza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarImpresoras()
            Dim pset As New PrinterSettings
            For i As Integer = 0 To cbimpresora.Items.Count - 1
                pset.PrinterName = cbimpresora.Items(i)
                If pset.IsDefaultPrinter Then
                    cbimpresora.SelectedIndex = i
                    Exit For
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cbimpresora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbimpresora.SelectedIndexChanged
        Try
            Dim a As PrintServer = New PrintServer()
            Dim propr As PrintQueue = a.GetPrintQueue(cbimpresora.SelectedItem)
            'Dim propprint As New LocalPrintServer()

            'Dim propr As PrintQueue = propprint.GetPrintQueue(cbimpresora.SelectedItem)
            lbestado.Text = propr.QueueStatus.ToString()
            lbpuerto.Text = propr.QueuePort.Name
            lbcomentario.Text = propr.Comment
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub rbpaginas_CheckedChanged(sender As Object, e As EventArgs) Handles rbpaginas.CheckedChanged
        Try
            txtdesde.Enabled = DirectCast(sender, RadioButton).Checked
            txthasta.Enabled = DirectCast(sender, RadioButton).Checked
            txtdesde.ReadOnly = Not DirectCast(sender, RadioButton).Checked
            txthasta.ReadOnly = Not DirectCast(sender, RadioButton).Checked
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

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
            prints.PrinterName = cbimpresora.SelectedItem
            If rbpaginas.Checked Then
                prints.PrintRange = PrintRange.SomePages
                prints.FromPage = Convert.ToInt32(txtdesde.Text)
                prints.ToPage = Convert.ToInt32(txthasta.Text)
            Else
                prints.PrintRange = PrintRange.AllPages
            End If
            prints.Copies = nudcopias.Value
            DialogResult = DialogResult.OK
            Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

End Class