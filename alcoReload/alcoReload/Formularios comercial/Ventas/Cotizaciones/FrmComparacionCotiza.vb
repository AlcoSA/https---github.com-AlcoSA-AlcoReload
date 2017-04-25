Imports System.ComponentModel
Imports DatagridTreeView
Imports ReglasNegocio
Imports ReglasNegocio.cotizaciones
Imports ReglasNegocio.movitoPadres

Public Class FrmComparacionCotiza
#Region "Variables"
    Private _listIdCotiza As List(Of Integer)
#End Region
#Region "Propiedades"
    Public Property ListIdCotiza() As List(Of Integer)
        Get
            Return _listIdCotiza
        End Get
        Set(ByVal value As List(Of Integer))
            _listIdCotiza = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarCotizaciones()
        Try
            Dim mPadreCotiza As New ClsMovitoPadres
            Dim mCotizacion As New ClsCostizaciones
            For Each id As Integer In _listIdCotiza
                Dim cot As cotizacion = mCotizacion.TraerxId(id)
                Dim nodo As DataGridViewTreeNode = dwCotizaciones.Nodes.Add()
                nodo.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.5, FontStyle.Bold)
                nodo.DefaultCellStyle.BackColor = Color.DarkGray
                nodo.Cells(cot_id.Index).Value = id
                nodo.Cells(cot_nombreCotiza.Index).Value = cot.nombreCotizacion
                nodo.Cells(cot_verCostoKiloAluminio.Index).Value = cot.versionCostoKiloAluminio
                nodo.Cells(cot_verCostoVidrio.Index).Value = cot.versionCostoVidrio

                Dim listPadres As List(Of movitoPadre) = mPadreCotiza.TraerxIdCotiza(id)
                For Each padre As movitoPadre In listPadres
                    Dim nodoPadre As DataGridViewTreeNode = nodo.Nodes.Add()
                    nodoPadre.Cells(cot_idHijo.Index).Value = padre.Id
                    nodoPadre.Cells(cot_ubicacion.Index).Value = RTrim(padre.Ubicacion)
                    nodoPadre.Cells(cot_descripcion.Index).Value = RTrim(padre.Descripcion)
                Next
            Next
            For Each nodo As DataGridViewTreeNode In dwCotizaciones.Nodes
                nodo.Expand()
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub configurarColumnas()
        Try
            Dim listToRemove As New List(Of Integer)
            For Each col As DataGridViewColumn In dwComparacion.Columns
                If col.Index > 5 Then
                    listToRemove.Add(col.Index)
                End If
            Next
            For Each index As Integer In listToRemove
                dwComparacion.Columns.RemoveAt(6)
            Next
            For Each nodo As DataGridViewTreeNode In dwCotizaciones.Nodes
                Dim conteoNodo As Integer = 0
                For Each nodoHijo As DataGridViewTreeNode In nodo.Nodes
                    If CBool(nodoHijo.Cells(cot_seleccion.Index).Value) = True Then
                        conteoNodo += 1
                    End If
                Next
                Dim index_colPrecUnit As Integer
                Dim index_colPrecTotal As Integer
                If conteoNodo > 0 Then
                    index_colPrecUnit = dwComparacion.Columns.Add("comp_cot_precUnit_" & nodo.Cells(cot_id.Index).Value.ToString(), "Cotización " &
                                                                           nodo.Cells(cot_id.Index).Value.ToString() &
                                                                           " ver " & nodo.Cells(cot_verCostoKiloAluminio.Index).Value.ToString() &
                                                                           "." & nodo.Cells(cot_verCostoVidrio.Index).Value.ToString() & " Precio un")
                    index_colPrecTotal = dwComparacion.Columns.Add("comp_cot_precTotal" & nodo.Cells(cot_id.Index).Value.ToString(), "Cotización " &
                                              nodo.Cells(cot_id.Index).Value.ToString() &
                                              " ver " & nodo.Cells(cot_verCostoKiloAluminio.Index).Value.ToString() & "." &
                                              nodo.Cells(cot_verCostoVidrio.Index).Value.ToString() & " Precio total")
                End If
                dwComparacion.Columns(index_colPrecUnit).DefaultCellStyle.Format = "C0"
                dwComparacion.Columns(index_colPrecTotal).DefaultCellStyle.Format = "C0"
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub comparacion()
        Try
            Dim dTable As DataTable = dTableHijos()
            dwComparacion.Rows.Clear()
            For Each row As DataRow In dTable.Rows
                Dim r As DataGridViewRow = dwComparacion.Rows(dwComparacion.Rows.Add())
                r.Cells(comp_ubicacion.Index).Value = row.Item("ubicacion")
                r.Cells(comp_descripcion.Index).Value = row.Item("descripcion")
                r.Cells(comp_vidrio.Index).Value = row.Item("vidrio")
                r.Cells(comp_ancho.Index).Value = row.Item("ancho")
                r.Cells(comp_alto.Index).Value = row.Item("alto")
                r.Cells(comp_cantidad.Index).Value = row.Item("cantidad")
                r.Cells("comp_cot_precUnit_" & row.Item("idCotiza").ToString()).Value = CDec(row.Item("precio_un"))
                r.Cells("comp_cot_precTotal" & row.Item("idCotiza").ToString()).Value = CDec(row.Item("precio_total"))
            Next
            dwComparacion.Sort(dwComparacion.Columns(comp_ubicacion.Index), ListSortDirection.Ascending)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function dTableHijos() As DataTable
        Try
            Dim dtable As New DataTable
            dtable.Columns.Add("idCotiza")
            dtable.Columns.Add("id")
            dtable.Columns.Add("ubicacion")
            dtable.Columns.Add("descripcion")
            dtable.Columns.Add("vidrio")
            dtable.Columns.Add("ancho")
            dtable.Columns.Add("alto")
            dtable.Columns.Add("cantidad")
            dtable.Columns.Add("precio_un")
            dtable.Columns.Add("precio_total")

            Dim mPadres As New ClsMovitoPadres
            For Each ndp As DataGridViewTreeNode In dwCotizaciones.Nodes
                For Each nodo As DataGridViewTreeNode In ndp.Nodes
                    If CBool(nodo.Cells(cot_seleccion.Index).Value) = True Then
                        Dim padre As movitoPadre = mPadres.TraerxId(nodo.Cells(cot_idHijo.Index).Value)
                        Dim row As DataRow = dtable.Rows.Add()
                        row.Item("idCotiza") = padre.IdCotiza
                        row.Item("id") = padre.Id
                        row.Item("ubicacion") = RTrim(padre.Ubicacion)
                        row.Item("descripcion") = RTrim(padre.Descripcion)
                        row.Item("vidrio") = RTrim(padre.Vidrio)
                        row.Item("ancho") = padre.Ancho
                        row.Item("alto") = padre.Alto
                        row.Item("cantidad") = padre.Cantidad
                        row.Item("precio_un") = padre.precioUnitario
                        row.Item("precio_total") = padre.precioTotal
                    End If
                Next
            Next
            Return dtable
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            dTableHijos = Nothing
        End Try
    End Function
#End Region
    Private Sub FrmComparacionCotiza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarCotizaciones()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnComparar_Click(sender As Object, e As EventArgs) Handles btnComparar.Click
        Try
            configurarColumnas()
            comparacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class