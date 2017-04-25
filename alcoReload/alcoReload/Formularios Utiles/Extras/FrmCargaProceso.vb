Imports System.ComponentModel

Public Class FrmCargaProceso
#Region "Propiedades"
    Public Property Proceso As String
        Get
            Return lbproceso.Text
        End Get
        Set(value As String)
            lbproceso.Text = value
        End Set
    End Property
    Private _porcentaje As String = 0
    Public Property porcentaje() As String
        Get
            Return _porcentaje
        End Get
        Set(ByVal value As String)
            lbPorcentaje.Text = value
        End Set
    End Property
    Private _showPorcentaje As Boolean = False
    Public Property ShowPorcentaje() As Boolean
        Get
            Return _showPorcentaje
        End Get
        Set(ByVal value As Boolean)
            lbPorcentaje.Visible = value
        End Set
    End Property
#End Region
    Private Sub FrmCargaProceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckForIllegalCrossThreadCalls = False
            lbPorcentaje.BringToFront()
            centrarPorcentaje()
            bppcargaproceso.Start()

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub FrmCargaProceso_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            bppcargaproceso.Stop()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub centrarPorcentaje()
        Try
            lbPorcentaje.Location = New Point((Me.Width / 2) - (lbPorcentaje.Width / 2), Me.Height)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub


End Class