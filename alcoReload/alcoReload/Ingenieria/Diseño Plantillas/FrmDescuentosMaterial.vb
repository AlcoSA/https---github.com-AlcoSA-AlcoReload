Imports ReglasNegocio
Imports Formulador
Imports ReglasNegocio.ClsEnums
Public Class FrmDescuentosMaterial

#Region "Variables"
    Private _material As Objeto = Nothing
    Private _analizador As AnalizadorLexico
    Private listadesc As List(Of DescuentoMaterial)
    Private listDescGlobal As List(Of descuentoGlobal)
    Private selectDescuento As descuentoGlobal
#End Region
#Region "Propiedades"
    Public Property Material As Objeto
        Get
            Return _material
        End Get
        Set(value As Objeto)
            _material = value
        End Set
    End Property
    Public Property Analizador As AnalizadorLexico
        Get
            Return _analizador
        End Get
        Set(value As AnalizadorLexico)
            _analizador = value
        End Set
    End Property
    Public Property Descuentos As List(Of DescuentoMaterial)
        Get
            Return listadesc
        End Get
        Set(value As List(Of DescuentoMaterial))
            listadesc = value
        End Set
    End Property
    Private _tipoDescuento As tipoDescuento
    Public Property tipoDescuento() As tipoDescuento
        Get
            Return _tipoDescuento
        End Get
        Set(ByVal value As tipoDescuento)
            _tipoDescuento = value
        End Set
    End Property
    Public Property _idModelo As Integer

    Public Property idModelo() As Integer
        Get
            Return _idModelo
        End Get
        Set(ByVal value As Integer)
            _idModelo = value
        End Set
    End Property

    Public Property descuentoGlobal() As List(Of descuentoGlobal)
        Get
            Return listDescGlobal
        End Get
        Set(ByVal value As List(Of descuentoGlobal))
            listDescGlobal = value
        End Set
    End Property

#End Region
#Region "CargarProcedimientos"
    Private Sub cargarDescuentos()
        Try
            Dim desc As New ClsDescuentos
            Dim listadescuento As List(Of ReglasNegocio.Descuento) = desc.TraerxEstado(ClsEnums.Estados.ACTIVO)
            If _tipoDescuento = tipoDescuento.DSCINDIVIDUAL Then
                For Each d As ReglasNegocio.Descuento In listadescuento
                    Dim r As DataGridViewRow = dwitems.Rows(dwitems.Rows.Add())
                    r.Cells(iddescuento.Index).Value = d.Id
                    r.Cells(descuento.Index).Value = d.Descuento
                    r.Cells(usar.Index).Value = _material.Descuentos.Contains(d.Descuento)
                    If Convert.ToBoolean(r.Cells(usar.Index).Value) Then
                        r.Cells(id.Index).Value = _material.Descuentos.Item(d.Descuento).Id
                        r.Cells(valor.Index).Tag = _material.Descuentos.Item(d.Descuento).Formula
                        r.Cells(valor.Index).Value = _material.Descuentos.Item(d.Descuento).Valor
                    Else
                        r.Cells(id.Index).Value = 0
                        r.Cells(valor.Index).Tag = String.Empty
                        r.Cells(valor.Index).Value = 0
                    End If
                Next
            ElseIf _tipoDescuento = tipoDescuento.DSCGOLBAL Then
                For Each d As ReglasNegocio.Descuento In listadescuento
                    Dim r As DataGridViewRow = dwitems.Rows(dwitems.Rows.Add())
                    r.Cells(iddescuento.Index).Value = d.Id
                    r.Cells(descuento.Index).Value = d.Descuento
                    If ContieneDescuento(d.Id) Then
                        r.Cells(id.Index).Value = selectDescuento.Id

                        If selectDescuento.Formula.StartsWith("=") Then
                            r.Cells(valor.Index).Tag = selectDescuento.Formula
                            r.Cells(valor.Index).Value = Analizador.EjecutarExpresion(Replace(selectDescuento.Valor, "=", ""))
                        Else
                            r.Cells(valor.Index).Value = selectDescuento.Valor
                        End If
                        r.Cells(usar.Index).Value = True
                    Else
                        r.Cells(id.Index).Value = 0
                        r.Cells(valor.Index).Tag = String.Empty
                        r.Cells(valor.Index).Value = 0
                    End If
                Next
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
    Private Function ContieneDescuento(idDescuento As Integer) As Boolean
        Try
            Dim listdesc As List(Of descuentoGlobal) = listDescGlobal.Where(Function(x) x.IdDescuento = idDescuento).ToList()
            If (listdesc.Count > 0) Then
                selectDescuento = listdesc.First()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Sub FrmDescuentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarDescuentos()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        Try
            If _tipoDescuento = tipoDescuento.DSCINDIVIDUAL Then
                listadesc = New List(Of DescuentoMaterial)
                For Each r As DataGridViewRow In dwitems.Rows
                    If Convert.ToBoolean(r.Cells(usar.Index).Value) Then

                        listadesc.Add(New DescuentoMaterial(r.Cells(id.Index).Value, r.Cells(iddescuento.Index).Value,
                                                            r.Cells(descuento.Index).Value,
                                                            Convert.ToString(r.Cells(descuento.Index).Tag),
                                                            Convert.ToDecimal(r.Cells(valor.Index).Value)))
                    End If
                Next
                Me.DialogResult = DialogResult.OK
            ElseIf _tipoDescuento = tipoDescuento.DSCGOLBAL Then
                listDescGlobal = New List(Of descuentoGlobal)
                For Each desc As DataGridViewRow In dwitems.Rows
                    If (Convert.ToBoolean(desc.Cells(usar.Index).Value) = True) Then
                        If Convert.ToString(desc.Cells(valor.Index).Value).StartsWith("=") Then
                            listDescGlobal.Add(New descuentoGlobal(desc.Cells(id.Index).Value, _idModelo, desc.Cells(iddescuento.Index).Value,
                                                               desc.Cells(descuento.Index).Value, desc.Cells(valor.Index).Tag))
                        Else
                            listDescGlobal.Add(New descuentoGlobal(desc.Cells(id.Index).Value, _idModelo, desc.Cells(iddescuento.Index).Value,
                                                               desc.Cells(descuento.Index).Value, desc.Cells(valor.Index).Value))
                        End If
                    End If
                Next
                Me.DialogResult = DialogResult.OK
            End If
            Me.Close()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwitems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwitems.CellEndEdit
        Try
            If _tipoDescuento = tipoDescuento.DSCINDIVIDUAL Then
                If e.RowIndex >= 0 Then
                    If dwitems.Columns(e.ColumnIndex) Is usar Then
                        If Not Convert.ToBoolean(dwitems.Item(e.ColumnIndex, e.RowIndex).Value) Then
                            If Convert.ToInt32(dwitems.Item(id.Index, e.RowIndex).Value) > 0 Then
                                Dim desc As New ClsDescuentosMaterial
                                desc.EliminarxId(Convert.ToInt32(dwitems.Item(id.Index, e.RowIndex).Value))
                            End If
                        End If
                    End If
                End If
            ElseIf _tipoDescuento = tipoDescuento.DSCGOLBAL Then
                If e.RowIndex >= 0 Then
                    If dwitems.Columns(e.ColumnIndex) Is usar Then
                        If Not Convert.ToBoolean(dwitems.Item(e.ColumnIndex, e.RowIndex).Value) Then
                            If Convert.ToInt32(dwitems.Item(id.Index, e.RowIndex).Value) > 0 Then
                                Dim desc As New ClsDescuentosGlobales
                                desc.EliminarxId(Convert.ToInt32(dwitems.Item(id.Index, e.RowIndex).Value))
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwitems_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwitems.CellBeginEdit
        Try
            If _tipoDescuento = tipoDescuento.DSCINDIVIDUAL Then
                If e.RowIndex >= 0 Then
                    If dwitems.Columns(e.ColumnIndex) Is usar Then
                        If Convert.ToBoolean(dwitems.Item(e.ColumnIndex, e.RowIndex).Value) Then
                            If Convert.ToInt32(dwitems.Item(id.Index, e.RowIndex).Value) > 0 Then
                                If MsgBox("Este descuento ya ha sido guardado anteriormente. ¿Esta seguro que quiere eliminarlo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                    Dim desc As New ClsDescuentosMaterial
                                    desc.EliminarxId(Convert.ToInt32(dwitems.Item(id.Index, e.RowIndex).Value))
                                    dwitems.Item(id.Index, e.RowIndex).Value = 0
                                    dwitems.Item(valor.Index, e.RowIndex).Value = 0
                                    dwitems.Item(usar.Index, e.RowIndex).Value = False
                                    e.Cancel = True
                                End If
                            End If
                        End If
                    End If
                End If
            ElseIf _tipoDescuento = tipoDescuento.DSCGOLBAL Then
                If e.RowIndex >= 0 Then
                    If dwitems.Columns(e.ColumnIndex) Is usar Then
                        If Convert.ToBoolean(dwitems.Item(e.ColumnIndex, e.RowIndex).Value) Then
                            If Convert.ToInt32(dwitems.Item(id.Index, e.RowIndex).Value) > 0 Then
                                If MsgBox("Este descuento ya ha sido guardado anteriormente. ¿Esta seguro que quiere eliminarlo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                    Dim desc As New ClsDescuentosGlobales
                                    desc.EliminarxId(Convert.ToInt32(dwitems.Item(id.Index, e.RowIndex).Value))
                                    dwitems.Item(id.Index, e.RowIndex).Value = 0
                                    dwitems.Item(valor.Index, e.RowIndex).Value = 0
                                    dwitems.Item(usar.Index, e.RowIndex).Value = False
                                    e.Cancel = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwitems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dwitems.CellClick
        Try
            If e.RowIndex >= 0 Then
                If TypeOf dwitems.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                    Dim formu As New Formulador.Formularios_Ayuda.FrmFormulador
                    formu.Analizador = Analizador
                    If Not String.IsNullOrEmpty(Convert.ToString(dwitems.Item(valor.Index, e.RowIndex).Tag)) Then
                        Dim frm As String = Convert.ToString(dwitems.Item(valor.Index, e.RowIndex).Tag)
                        formu.Formula = frm.Substring(1, frm.Length - 1)
                    End If
                    If formu.ShowDialog() = DialogResult.OK Then
                        If (String.IsNullOrEmpty(formu.Formula)) Or IsNumeric(formu.Formula) Then
                            dwitems.Item(valor.Index, e.RowIndex).Value = formu.Valor
                        Else
                            dwitems.Item(valor.Index, e.RowIndex).Tag = "=" & formu.Formula
                            dwitems.Item(valor.Index, e.RowIndex).Value = formu.Valor
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btonAddDescuento_Click(sender As Object, e As EventArgs) Handles btonAddDescuento.Click
        Try
            Dim qDescuentos As New FrmQuickAddDescuento
            If qDescuentos.ShowDialog = DialogResult.OK Then
                dwitems.Rows.Clear()
                cargarDescuentos()
            End If
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwitems_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dwitems.ColumnWidthChanged
        Try
            Me.Width = dwitems.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 60
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class