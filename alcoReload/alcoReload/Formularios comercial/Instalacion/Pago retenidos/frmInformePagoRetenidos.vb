Imports Informes

Public Class frmInformePagoRetenidos
#Region "Variables"
    Private _ds As DataSet
#End Region
#Region "Propiedades"
    Public Property Ds() As DataSet
        Get
            Return _ds
        End Get
        Set(ByVal value As DataSet)
            _ds = value
        End Set
    End Property
#End Region
    Private Sub frmInformePagoRetenidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim informe As New rpPagoRetenidos
            informe.SetDataSource(_ds)
            crViewer.ReportSource = informe
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class