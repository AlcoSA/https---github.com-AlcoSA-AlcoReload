Imports ReglasNegocio

Public Class FrmVerDetalleNota
#Region "Variables"
    Private _idNotaCobro As Integer
    Private mAnticipoPorNota As clsAnticiposPorNota
#End Region
#Region "Propiedades"
    Public Property IdNotaCobro() As Integer
        Get
            Return _idNotaCobro
        End Get
        Set(ByVal value As Integer)
            _idNotaCobro = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarInformacion()
        Try
            mAnticipoPorNota = New clsAnticiposPorNota
            Dim list As List(Of CuotaxNotaCobro) = mAnticipoPorNota.TraerDetalleNotaCobro(_idNotaCobro)
            For Each cuota As CuotaxNotaCobro In list
                Dim r As DataGridViewRow = dwItems.Rows(dwItems.Rows.Add())
                r.Cells(col_numeroCuota.Index).Value = cuota.NumeroCuota
                r.Cells(col_porcentCuota.Index).Value = cuota.PorcentajeCuota
                r.Cells(col_fechaCancelacion.Index).Value = cuota.FechaCuota
                r.Cells(col_valorCuota.Index).Value = cuota.ValorCuota
                r.Cells(col_idEstado.Index).Value = cuota.IdEstado
                r.Cells(col_estado.Index).Value = cuota.Estado
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmVerDetalleNota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class