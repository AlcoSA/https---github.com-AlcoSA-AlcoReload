Imports ReglasNegocio

Public Class FrmVerTemporales
#Region "Variables"
    Private mArtTemp As ClsArticuloTemporal
    Private mColTemp As ClsAcabadoTemporal
    Private mEspTemp As ClsEspesorTemporal
    Private mCostoTemp As ClsCostoVidrioTemporal

    Private _idCotiza As Integer
#End Region
#Region "Propiedades"
    Public Property IdCotiza() As Integer
        Get
            Return _idCotiza
        End Get
        Set(ByVal value As Integer)
            _idCotiza = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarArticulos()
        Try
            mArtTemp = New ClsArticuloTemporal
            Dim listArticulos As List(Of articuloTemporal) = mArtTemp.TraerxIdCotiza(_idCotiza)
            For Each art As articuloTemporal In listArticulos
                Dim r As DataGridViewRow = dwArticulos.Rows(dwArticulos.Rows.Add())
                r.Cells(art_id.Index).Value = art.Id
                r.Cells(art_Referencia.Index).Value = art.Referencia
                r.Cells(art_Descripcion.Index).Value = art.Descripcion
                r.Cells(art_idFamilia.Index).Value = art.IdFamiliaMaterial
                r.Cells(art_familia.Index).Value = art.FamiliaMaterial
                r.Cells(art_costo.Index).Value = art.Costo
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarColores()
        Try
            mColTemp = New ClsAcabadoTemporal
            Dim listColores As List(Of acabadoTemporal) = mColTemp.TraerxIdCotiza(_idCotiza)
            For Each col As acabadoTemporal In listColores
                Dim r As DataGridViewRow = dwColores.Rows(dwColores.Rows.Add())
                r.Cells(col_id.Index).Value = col.Id
                r.Cells(col_prefijo.Index).Value = col.Prefijo
                r.Cells(col_nombre.Index).Value = col.Nombre
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarEspesores()
        Try
            mEspTemp = New ClsEspesorTemporal
            Dim listEspesores As List(Of espesorTemporal) = mEspTemp.TraerxIdCotiza(_idCotiza)
            For Each esp As espesorTemporal In listEspesores
                Dim r As DataGridViewRow = dwEspesores.Rows(dwEspesores.Rows.Add())
                r.Cells(esp_id.Index).Value = esp.Id
                r.Cells(esp_prefijo.Index).Value = esp.Prefijo
                r.Cells(esp_descripcion.Index).Value = esp.Descripcion
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarCostoVidrio()
        Try
            mCostoTemp = New ClsCostoVidrioTemporal
            Dim listCostos As List(Of costoVidrioTemporal) = mCostoTemp.TraerxIdCotiza(_idCotiza)
            For Each cv As costoVidrioTemporal In listCostos
                Dim r As DataGridViewRow = dwCostoVidrio.Rows(dwCostoVidrio.Rows.Add())
                r.Cells(cv_id.Index).Value = cv.Id
                r.Cells(cv_vidrioTemporal.Index).Value = cv.VidrioTemporal
                r.Cells(cv_idVidrio.Index).Value = cv.IdVidrio
                r.Cells(cv_vidrio.Index).Value = cv.Vidrio
                r.Cells(cv_colorTemporal.Index).Value = cv.ColorTemporal
                r.Cells(cv_idColor.Index).Value = cv.IdColor
                r.Cells(cv_color.Index).Value = cv.Color
                r.Cells(cv_espesorTemporal.Index).Value = cv.EspesorTemporal
                r.Cells(cv_idEspesor.Index).Value = cv.IdEspesor
                r.Cells(cv_espesor.Index).Value = cv.Espesor
                r.Cells(cv_costo.Index).Value = cv.Costo
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmVerTemporales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarArticulos()
            cargarColores()
            cargarEspesores()
            cargarCostoVidrio()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class