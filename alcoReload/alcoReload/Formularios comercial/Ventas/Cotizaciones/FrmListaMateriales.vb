Imports Formulador
Imports ReglasNegocio

Public Class FrmListaMateriales

#Region "Variables"
    Private _lista As ObjetosCollection
    Private _referenciaItem As String = String.Empty
    Private mArticulo As New ClsArticulos
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.MODIFICAR
    Private id_cotiza As Integer = 0
    Private _versionCostoKiloAluminio As Integer = 0
    Private _versionCostoVidrio As Integer = 0
    Private _versionCostoAccesorio As Integer = 0
    Private _versionCostoAcabado As Integer = 0
    Private _versionCostoNivel As Integer = 0
    Private _versionCostoOtrosArticulos As Integer = 0
    Private _mostrarprecios As Boolean = True
#End Region

#Region "Propiedades"
    Public Property IdCotiza As Integer
        Get
            Return id_cotiza
        End Get
        Set(value As Integer)
            id_cotiza = value
        End Set
    End Property
    Public Property VersionCostoKiloAluminio As Integer
        Get
            Return _versionCostoKiloAluminio
        End Get
        Set(value As Integer)
            _versionCostoKiloAluminio = value
        End Set
    End Property
    Public Property VersionCostoVidrio As Integer
        Get
            Return _versionCostoVidrio
        End Get
        Set(value As Integer)
            _versionCostoVidrio = value
        End Set
    End Property
    Public Property VersionCostoAccesorio As Integer
        Get
            Return _versionCostoAccesorio
        End Get
        Set(value As Integer)
            _versionCostoAccesorio = value
        End Set
    End Property
    Public Property VersionCostoAcabado As Integer
        Get
            Return _versionCostoAcabado
        End Get
        Set(value As Integer)
            _versionCostoAcabado = value
        End Set
    End Property
    Public Property VersionCostoNivel As Integer
        Get
            Return _versionCostoNivel
        End Get
        Set(value As Integer)
            _versionCostoNivel = value
        End Set
    End Property
    Public Property VersionCostoOtrosArticulos As Integer
        Get
            Return _versionCostoOtrosArticulos
        End Get
        Set(value As Integer)
            _versionCostoOtrosArticulos = value
        End Set
    End Property
    Public Property Tipo_Formulario As ClsEnums.TiOperacion
        Get
            Return tform
        End Get
        Set(value As ClsEnums.TiOperacion)
            tform = value
        End Set
    End Property
    Public Property lista() As ObjetosCollection
        Get
            Return _lista
        End Get
        Set(ByVal value As ObjetosCollection)
            _lista = value
        End Set
    End Property
    Public Property referenciaItem() As String
        Get
            Return _referenciaItem
        End Get
        Set(ByVal value As String)
            _referenciaItem = value
        End Set
    End Property
    Public Property MostrarFinanciero As Boolean
        Get
            Return _mostrarprecios
        End Get
        Set(value As Boolean)
            _mostrarprecios = value
        End Set
    End Property
#End Region
    Private Sub cargarDatos()
        Try

            Dim mArtTemp As New ClsArticuloTemporal
            Dim _listArticulos = mArtTemp.TraerConExistentes_II(id_cotiza).Where(Function(x) x.IdFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO)
            Dim mColTemp As New ClsAcabadoTemporal
            Dim _listColores = mColTemp.TraerconExistentes(id_cotiza, ClsEnums.FamiliasMateriales.VIDRIO)
            Dim mEspTemp As New ClsEspesorTemporal
            Dim _listEspesores = mEspTemp.TraerConExistentes(id_cotiza)
            dwItem.Rows.Clear()
            For Each obj As Objeto In _lista
                If Convert.ToBoolean(Convert.ToInt32(obj.Parametros.Item("VISIBILIDAD").Valor)) Then
                    Dim r As DataGridViewRow = dwItem.Rows(dwItem.Rows.Add())
                    r.Cells(material.Index).Value = obj.Nombre
                    r.Cells(tipo.Index).Value = obj.TipoObjeto
                    r.Cells(indice.Index).Value = obj.Indice
                    r.Cells(referencia.Index).Value = obj.Parametros.Item("REFERENCIA").Valor
                    r.Cells(piezasxunidad.Index).Value = obj.Parametros.Item("PXUNIDAD").Valor
                    r.Cells(para.Index).Value = obj.Parametros.Item("PARA").Valor

                    Select Case obj.TipoObjeto
                        Case TiposElementos.Perfiles, TiposElementos.Accesorios, TiposElementos.Otros
                            'r.Cells(material.Index).Value = obj.TipoObjeto.ToString.ToUpper
                            r.Cells(ancho.Index).Value = obj.Parametros.Item("DIMENSION").Valor
                            r.Cells(acabado.Index).Value = obj.Parametros.Item("ACABADO").Valor
                            r.Cells(ubicacion.Index).Value = obj.Parametros.Item("UBICACION").Valor
                            r.Cells(alto.Index).Value = 0
                            r.Cells(espesor.Index).Value = 0
                        Case Is = TiposElementos.Vidrios
                            r.Cells(tipo.Index).Value = ClsEnums.FamiliasMateriales.VIDRIO
                            r.Cells(referencia.Index) = New DataGridViewComboBoxCell
                            DirectCast(r.Cells(referencia.Index), DataGridViewComboBoxCell).DisplayMember = "Referencia"
                            DirectCast(r.Cells(referencia.Index), DataGridViewComboBoxCell).ValueMember = "Referencia"
                            DirectCast(r.Cells(referencia.Index), DataGridViewComboBoxCell).DataSource = _listArticulos.Where(Function(a) a.IdFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO).ToList()
                            r.Cells(acabado.Index) = New DataGridViewComboBoxCell
                            DirectCast(r.Cells(acabado.Index), DataGridViewComboBoxCell).DisplayMember = "Prefijo"
                            DirectCast(r.Cells(acabado.Index), DataGridViewComboBoxCell).ValueMember = "Prefijo"
                            DirectCast(r.Cells(acabado.Index), DataGridViewComboBoxCell).DataSource = _listColores
                            r.Cells(espesor.Index) = New DataGridViewComboBoxCell
                            DirectCast(r.Cells(espesor.Index), DataGridViewComboBoxCell).DisplayMember = "Prefijo"
                            DirectCast(r.Cells(espesor.Index), DataGridViewComboBoxCell).ValueMember = "Prefijo"
                            DirectCast(r.Cells(espesor.Index), DataGridViewComboBoxCell).DataSource = _listEspesores
                            r.Cells(referencia.Index).Value = obj.Parametros.Item("REFERENCIA").Valor
                            r.Cells(ancho.Index).Value = obj.Parametros.Item("ANCHO").Valor
                            r.Cells(alto.Index).Value = obj.Parametros.Item("ALTO").Valor
                            r.Cells(acabado.Index).Value = obj.Parametros.Item("COLOR").Valor
                            r.Cells(espesor.Index).Value = obj.Parametros.Item("ESPESOR").Valor
                            r.Cells(ubicacion.Index).Value = obj.Parametros.Item("ORIENTACION").Valor
                    End Select
                    r.Cells(orientacion.Index).Value = obj.Parametros.Item("ORIENTACION").Valor
                    r.Cells(cantidad.Index).Value = obj.Parametros.Item("CANTIDAD").Valor
                    r.Cells(cantidadrequerida.Index).Value = Math.Round(CDec(r.Cells(cantidad.Index).Value) * CDec(r.Cells(piezasxunidad.Index).Value), 2)
                    r.Cells(costou.Index).Value = obj.Costo_Unitario
                    r.Cells(costo.Index).Value = obj.Costo_Total
                    r.Cells(CostoSinDesperdicio.Index).Value = obj.Costo_Unitario - obj.VlrDesperdicio
                    r.Cells(utilizar.Index).Value = obj.Utilizar
                    'CalcularPrecioenGrid(r)
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub calculoTotales()
        Try
            dwTotales.Rows.Clear()
            Dim total As DataGridViewRow = dwTotales.Rows(dwTotales.Rows.Add)
            'costos sin desperdicio
            total.Cells(tVidSinDesp.Index).Value = dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) DirectCast(r.Cells(tipo.Index).Value, TiposElementos) = TiposElementos.Vidrios And Convert.ToBoolean(r.Cells(utilizar.Index).Value)).Sum(Function(r) Convert.ToDecimal(r.Cells(CostoSinDesperdicio.Index).Value))
            total.Cells(tPerfSinDesp.Index).Value = dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) DirectCast(r.Cells(tipo.Index).Value, TiposElementos) = TiposElementos.Perfiles And Convert.ToBoolean(r.Cells(utilizar.Index).Value)).Sum(Function(r) Convert.ToDecimal(r.Cells(CostoSinDesperdicio.Index).Value))
            total.Cells(tAccesoSinDesp.Index).Value = dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) DirectCast(r.Cells(tipo.Index).Value, TiposElementos) = TiposElementos.Accesorios And Convert.ToBoolean(r.Cells(utilizar.Index).Value)).Sum(Function(r) Convert.ToDecimal(r.Cells(CostoSinDesperdicio.Index).Value))
            total.Cells(tOtrosSinDesp.Index).Value = dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) DirectCast(r.Cells(tipo.Index).Value, TiposElementos) = TiposElementos.Otros And Convert.ToBoolean(r.Cells(utilizar.Index).Value)).Sum(Function(r) Convert.ToDecimal(r.Cells(CostoSinDesperdicio.Index).Value))
            ' constos con desperdicio
            total.Cells(tPerfileria.Index).Value = dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) DirectCast(r.Cells(tipo.Index).Value, TiposElementos) = TiposElementos.Perfiles And Convert.ToBoolean(r.Cells(utilizar.Index).Value)).Sum(Function(r) Convert.ToDecimal(r.Cells(costo.Index).Value))
            total.Cells(tAccesorio.Index).Value = dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) DirectCast(r.Cells(tipo.Index).Value, TiposElementos) = TiposElementos.Accesorios And Convert.ToBoolean(r.Cells(utilizar.Index).Value)).Sum(Function(r) Convert.ToDecimal(r.Cells(costo.Index).Value))
            total.Cells(tVidrio.Index).Value = dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) DirectCast(r.Cells(tipo.Index).Value, TiposElementos) = TiposElementos.Vidrios And Convert.ToBoolean(r.Cells(utilizar.Index).Value)).Sum(Function(r) Convert.ToDecimal(r.Cells(costo.Index).Value))
            total.Cells(tOtros.Index).Value = dwItem.Rows.Cast(Of DataGridViewRow).Where(Function(r) DirectCast(r.Cells(tipo.Index).Value, TiposElementos) = TiposElementos.Otros And Convert.ToBoolean(r.Cells(utilizar.Index).Value)).Sum(Function(r) Convert.ToDecimal(r.Cells(costo.Index).Value))
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub CalcularPrecioenGrid(r As DataGridViewRow)
        Try
            Dim costoVidrio As New ClsCostoVidrio
            Dim costoAccesorio As New ClsCostoAccesorio
            Dim costoaluminio As New CostoArticulo.ClsCostoAluminio
            Dim costosotros As New ClsCostoOtrosArticulos
            Dim mArticulo As New ClsArticulos
            Dim costo_base As Decimal = 0

            Dim fact As Decimal = 1 + (mArticulo.TraerxReferencia(r.Cells(referencia.Index).Value).porcDesperdicio / 100)
            Dim pxuni As Decimal = CDec(r.Cells(piezasxunidad.Index).Value)
            Dim cant As Decimal = CDec(r.Cells(cantidad.Index).Value)
            Select Case DirectCast(r.Cells(tipo.Index).Value, TiposElementos)
                Case TiposElementos.Vidrios
                    costo_base = costoVidrio.TraerCostoxReferenciaAcabadoEspesor(r.Cells(referencia.Index).Value,
                                                                                                                r.Cells(espesor.Index).Value,
                                                                                                                r.Cells(acabado.Index).Value,
                                                                                                                versionCostoVidrio)
                    If costo_base <= 0 Then
                        Dim mCostoVidTemp As New ClsCostoVidrioTemporal
                        costo_base = mCostoVidTemp.TraerCostoxReferencia(idcotiza, r.Cells(referencia.Index).Value,
                                                                                                                r.Cells(espesor.Index).Value,
                                                                                                                r.Cells(acabado.Index).Value)
                    End If
                    Dim anc As Decimal = CDec(r.Cells(ancho.Index).Value) / 1000
                    Dim alt As Decimal = CDec(r.Cells(alto.Index).Value) / 1000
                    r.Cells(costou.Index).Value = Math.Round(costo_base * anc * alt * fact * pxuni, 0)
                    r.Cells(CostoSinDesperdicio.Index).Value = (costo_base * anc * alt * pxuni) * (fact - (fact - 1))
                Case TiposElementos.Perfiles
                    costo_base = costoaluminio.TraerCostoxReferenciayAcabado(r.Cells(referencia.Index).Value,
                                                                            r.Cells(acabado.Index).Value, versionCostoAcabado,
                                                                            versionCostoNivel, versionCostoKiloAluminio)
                    Dim dimen As Decimal = CDec(r.Cells(ancho.Index).Value) / 1000
                    r.Cells(costou.Index).Value = Math.Round(dimen * fact * pxuni * costo_base, 0)
                    r.Cells(CostoSinDesperdicio.Index).Value = (costo_base * dimen * pxuni) * (fact - (fact - 1))
                Case TiposElementos.Accesorios
                    costo_base = costoAccesorio.TraerCostoxReferencia(r.Cells(referencia.Index).Value, versionCostoAccesorio)
                    Dim dimen As Decimal = CDec(r.Cells(ancho.Index).Value) / 1000
                    If dimen > 0 Then
                        r.Cells(costou.Index).Value = Math.Round(costo_base * dimen * pxuni * fact, 0)
                        r.Cells(CostoSinDesperdicio.Index).Value = (costo_base * dimen * pxuni) * (fact - (fact - 1))
                    Else
                        r.Cells(costou.Index).Value = Math.Round(costo_base * fact * pxuni)
                        r.Cells(CostoSinDesperdicio.Index).Value = (costo_base * pxuni) * (fact - (fact - 1))
                    End If
                Case TiposElementos.Otros
                    costo_base = costosotros.TraerxReferencia(r.Cells(referencia.Index).Value, versionCostoOtrosArticulos)
                    r.Cells(costou.Index).Value = Math.Round(costo_base * fact * pxuni, 0)
                    r.Cells(CostoSinDesperdicio.Index).Value = (costo_base * pxuni) * (fact - (fact - 1))
            End Select
            r.Cells(costo.Index).Value = Math.Round(CDec(r.Cells(costou.Index).Value) * cant, 0)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub FrmListaMateriales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If tform = ClsEnums.TiOperacion.SOLO_LECTURA Then
                dwItem.ReadOnly = True
            End If
            dwTotales.Visible = _mostrarprecios
            costo.Visible = _mostrarprecios
            costou.Visible = _mostrarprecios
            CostoSinDesperdicio.Visible = _mostrarprecios
            cargarDatos()
            calculoTotales()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            dwItem.EndEdit()
            For i As Integer = 0 To dwItem.Rows.Count - 1
                Dim obj As Objeto = _lista.Item(Convert.ToString(dwItem.Item(material.Index, i).Value), Convert.ToInt32(dwItem.Item(indice.Index, i).Value))
                obj.Utilizar = Convert.ToBoolean(dwItem.Item(utilizar.Index, i).Value)
                If obj.TipoObjeto = TiposElementos.Vidrios Then
                    If Not obj.Parametros("REFERENCIA").Valor.Equals(Convert.ToString(dwItem.Item(referencia.Index, i).Value)) Then
                        obj.Parametros("REFERENCIA").Formula = String.Empty
                        obj.Parametros("REFERENCIA").Valor = Convert.ToString(dwItem.Item(referencia.Index, i).Value)
                    End If
                    If Not obj.Parametros("COLOR").Valor.Equals(Convert.ToString(dwItem.Item(acabado.Index, i).Value)) Then
                        obj.Parametros("COLOR").Formula = String.Empty
                        obj.Parametros("COLOR").Valor = Convert.ToString(dwItem.Item(acabado.Index, i).Value)
                    End If
                    If Not obj.Parametros("ESPESOR").Valor.Equals(Convert.ToString(dwItem.Item(espesor.Index, i).Value)) Then
                        obj.Parametros("ESPESOR").Formula = String.Empty
                        obj.Parametros("ESPESOR").Valor = Convert.ToString(dwItem.Item(espesor.Index, i).Value)
                    End If
                End If
            Next
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwItem.CellBeginEdit
        Try
            If e.RowIndex < 0 Then
                e.Cancel = True
                Return
            End If
            If e.ColumnIndex <> utilizar.Index Then
                If DirectCast(Convert.ToInt32(dwItem.Item(tipo.Index, e.RowIndex).Value), TiposElementos) = TiposElementos.Vidrios Then
                    If Not (e.ColumnIndex = referencia.Index Or e.ColumnIndex = acabado.Index Or e.ColumnIndex = espesor.Index) Then
                        e.Cancel = True
                    End If
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItem.CellEndEdit
        Try
            CalcularPrecioenGrid(dwItem.Rows(e.RowIndex))
            calculoTotales()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

End Class