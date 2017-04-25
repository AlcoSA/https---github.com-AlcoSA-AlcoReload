Imports ControlesPersonalizados.Estructurador
Imports DatagridTreeView
Imports Formulador
Imports ReglasNegocio
Public Class FrmTomaMedidas

#Region "Variables"
    Private _idcontrato As Integer = 0
    Dim movitoIc As clsMovitoItemsContrato
#End Region

#Region "Propiedades"
    Public Property IdContrato As Integer
        Get
            Return _idcontrato
        End Get
        Set(value As Integer)
            _idcontrato = value
        End Set
    End Property
#End Region

#Region "Procedimientos"
    Private Sub cargarDibujo(n As DatagridTreeView.DataGridViewTreeNode)
        Try
            Dim dibujoscotiza As New ClsDibujosItemsCotiza
            Dim listaestructura As List(Of DibujoPadreCotiza) = dibujoscotiza.TraerxIdITemCotiza(Convert.ToInt32(n.Cells(idcotiza.Index).Value))
            eatomapuntos.Cotas.Add(New Cota_Region_Estructural(eatomapuntos.EstructuraPrincipal, Tipo_Cota.HORIZONTAL, Convert.ToString(n.Cells(ancho.Index).Value)))
            eatomapuntos.Cotas.Add(New Cota_Region_Estructural(eatomapuntos.EstructuraPrincipal, Tipo_Cota.VERTICAL, Convert.ToString(n.Cells(alto.Index).Value)))
            If listaestructura.Count > 0 Then
                Dim dib As DibujoPadreCotiza = listaestructura.First(Function(x) x.Nivel = 0)
                If dib.DXF.Equals("Pared") Then
                ElseIf dib.DXF.Equals("Perfil") Then
                    eatomapuntos.EstructuraPrincipal.TipoEstructura = Tipo_Estructura.PERFIL
                Else
                    Dim rw As DataGridViewRow = n.Nodes.First(Function(p) Convert.ToInt32(p.Cells(idcotiza.Index).Value) = dib.IdHijo)
                    If IsNothing(rw.Cells(especial.Index).Value) Then
                        cargarAnalizador(rw)
                    End If
                    eatomapuntos.EstructuraPrincipal.Arquitecto = New DXF.Dibujante_DXF.Ventana(DirectCast(rw.Cells(especial.Index).Value, AnalizadorLexico),
                                                                                                New SizeF(700, 700))
                    eatomapuntos.EstructuraPrincipal.Estructura = dib.DXF
                End If
                CargarDibujos(listaestructura, dib, eatomapuntos.EstructuraPrincipal)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargarDibujos(lista As List(Of DibujoPadreCotiza), item As DibujoPadreCotiza, ByRef creg As ControlesPersonalizados.Estructurador.RegionEstructuras)
        Try
            Dim lnew As List(Of DibujoPadreCotiza) = lista.Where(Function(x) x.IdContendor = item.Id).ToList()
            For Each e As DibujoPadreCotiza In lnew
                Dim rg As New RegionEstructuras(e.X, e.Y, e.Ancho, e.Alto)
                If e.DXF.Equals("Pared") Then
                    rg.TipoEstructura = Tipo_Estructura.BASICO
                ElseIf e.DXF.Equals("Ele_Arriba") Then
                    rg.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_ARRIBA
                ElseIf e.DXF.Equals("Ele_Izquierda") Then
                    rg.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_IZQUIERDA
                ElseIf e.DXF.Equals("Ele_Abajo") Then
                    rg.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_ABAJO
                ElseIf e.DXF.Equals("Ele_Derecha") Then
                    rg.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_DERECHA
                ElseIf e.DXF.Split("&")(0).Equals("Perfil") Then
                    Dim ndh As DataGridViewTreeNode = dwItems.Nodes.FirstOrDefault(Function(n) Convert.ToInt32(n.Cells(idcotiza.Index).Value) = e.IdPadre).Nodes.FirstOrDefault(Function(n) Convert.ToInt32(n.Cells(idcotiza.Index).Value) = e.IdHijo)
                    rg.TipoEstructura = Tipo_Estructura.PERFIL
                    rg.Referencia_Perfil = e.DXF.Split("&")(1)
                    rg.Id_Hijo_Owner = e.IdHijo
                    If ndh IsNot Nothing Then
                        rg.Index_Hijo_Owner = ndh.Index
                        eatomapuntos.Cotas.Add(New Cota_Region_Estructural(rg, Tipo_Cota.CENTRAL, Convert.ToString(ndh.Cells(ancho.Index).Value)))
                    End If
                Else
                    Dim ndh As DataGridViewTreeNode = dwItems.Nodes.FirstOrDefault(Function(n) Convert.ToInt32(n.Cells(idcotiza.Index).Value) = e.IdPadre).Nodes.FirstOrDefault(Function(n) Convert.ToInt32(n.Cells(idcotiza.Index).Value) = e.IdHijo)
                    If ndh.Cells(especial.Index).Value Is Nothing Then
                        cargarAnalizador(ndh)
                    End If
                    Dim vn As New DXF.Dibujante_DXF.Ventana(DirectCast(ndh.Cells(especial.Index).Value, AnalizadorLexico), New SizeF(700, 700))
                    vn.LeerDxfPersonalizado(e.DXF)
                    rg.Arquitecto = vn
                    rg.Id_Hijo_Owner = e.IdHijo
                    If ndh IsNot Nothing Then
                        rg.Index_Hijo_Owner = ndh.Index
                        If rg.X <> creg.X Or rg.Ancho <> creg.Ancho Then
                            eatomapuntos.Cotas.Add(New Cota_Region_Estructural(rg, Tipo_Cota.HORIZONTAL, Convert.ToString(ndh.Cells(ancho.Index).Value)))
                        End If
                        If rg.Y <> creg.Y Or rg.Alto <> creg.Alto Then
                            eatomapuntos.Cotas.Add(New Cota_Region_Estructural(rg, Tipo_Cota.VERTICAL, Convert.ToString(ndh.Cells(alto.Index).Value)))
                        End If
                    End If
                End If
                creg.Estructuras.Add(rg)
                CargarDibujos(lista, e, rg)
            Next            '
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarAnalizador(ByRef r As DataGridViewRow)
        Try
            Dim analizador = New AnalizadorLexico
            Dim cplantilla As New CargasPlantilla
            cplantilla.CargarPlantilla(Convert.ToInt32(r.Cells(idcotiza.Index).Value), analizador, ClsEnums.TipoCarga.COTIZA)
            r.Cells(especial.Index).Value = analizador
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub CargarDatos()
        Try
            Dim mMovitoHijo As New movitoHijos.ClsMovitoHijos
            Dim listaItems As List(Of ItemContrato) = movitoIc.tc040_selectAllByIdContrato(_idcontrato)
            For Each item As ItemContrato In listaItems
                Dim n As DatagridTreeView.DataGridViewTreeNode = dwItems.Nodes.Add()
                n.Cells(iditemcontrato.Index).Value = item.Id
                n.Cells(iditemcontrato.Index).Tag = item.Id
                n.Cells(idcotiza.Index).Value = item.IdItemCotiza
                n.Cells(idcotiza.Index).Tag = item.IdItemCotiza
                n.Cells(nombre.Index).Value = item.ubicacion
                n.Cells(nombre.Index).Tag = item.ubicacion
                n.Cells(ancho.Index).Value = Math.Round(item.ancho, 0)
                n.Cells(ancho.Index).Tag = Math.Round(item.ancho, 0)
                n.Cells(alto.Index).Value = Math.Round(item.alto, 0)
                n.Cells(alto.Index).Tag = Math.Round(item.alto, 0)
                n.Cells(cantidad.Index).Value = Math.Round(item.cantidad, 0)
                n.Cells(cantidad.Index).Tag = Math.Round(item.cantidad, 0)
                n.Cells(observaciones.Index).Value = String.Empty
                Dim listHijos As List(Of movitoHijos.movitoHijo) = mMovitoHijo.TraerxIdPadre(item.IdItemCotiza)
                For Each ith As movitoHijos.movitoHijo In listHijos
                    Dim ndh As DatagridTreeView.DataGridViewTreeNode = n.Nodes.Add
                    ndh.Cells(idcotiza.Index).Value = ith.Id
                    ndh.Cells(idcotiza.Index).Tag = ith.Id
                    ndh.Cells(nombre.Index).Value = RTrim(ith.referencia)
                    ndh.Cells(nombre.Index).Tag = RTrim(ith.referencia)
                    ndh.Cells(ancho.Index).Value = Math.Round(ith.ancho, 0)
                    ndh.Cells(ancho.Index).Tag = Math.Round(ith.ancho, 0)
                    ndh.Cells(alto.Index).Value = Math.Round(ith.alto, 0)
                    ndh.Cells(alto.Index).Tag = Math.Round(ith.alto, 0)
                    ndh.Cells(cantidad.Index).Value = Math.Round(ith.cantidad, 0)
                    ndh.Cells(cantidad.Index).Tag = Math.Round(ith.cantidad, 0)
                    ndh.Cells(observaciones.Index).Value = String.Empty
                Next
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
    Private Sub Frm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            Dim btnsRecargar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnrecargar
            Dim btnsimpresion As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimpresion
            Dim btnsexportar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnexportar
            btnsexportar.Enabled = False
            btnsimpresion.Enabled = False
            btnsParcial.Enabled = False
            btnsLimpiar.Enabled = False
            btnsRecargar.Enabled = False
            AddHandler btnguardar.Click, AddressOf Guardar_Click
            AddHandler btnsTotal.Click, AddressOf Guardar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            Dim btnsRecargar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnrecargar
            Dim btnsimpresion As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimpresion
            Dim btnsexportar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnexportar
            btnsexportar.Enabled = True
            btnsimpresion.Enabled = True
            btnsParcial.Enabled = True
            btnsLimpiar.Enabled = True
            btnsRecargar.Enabled = True
            RemoveHandler btnguardar.Click, AddressOf Guardar_Click
            RemoveHandler btnsTotal.Click, AddressOf Guardar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Guardar_Click(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmTomaMedidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            movitoIc = New clsMovitoItemsContrato
            CargarDatos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dwItems.CellClick
        Try
            If e.RowIndex >= 0 Then
                If DirectCast(dwItems.Rows(e.RowIndex), DatagridTreeView.DataGridViewTreeNode).Level = 1 Then
                    For Each n As DataGridViewTreeNode In dwItems.Nodes
                        n.Cells(enedicion.Index).Value = False
                    Next
                    dwItems.Item(enedicion.Index, e.RowIndex).Value = True
                    If e.ColumnIndex = btndibujo.Index Then
                        eatomapuntos.EstructuraPrincipal.Estructura = String.Empty
                        eatomapuntos.EstructuraPrincipal.TipoEstructura = Tipo_Estructura.BASICO
                        eatomapuntos.EstructuraPrincipal.Estructuras.Clear()
                        eatomapuntos.Cotas = New List(Of Cota_Region_Estructural)
                        eatomapuntos.Cota_Seleccionada = Nothing
                        cargarDibujo(DirectCast(dwItems.Rows(e.RowIndex), DatagridTreeView.DataGridViewTreeNode))
                        eatomapuntos.Refresh()
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwItems.CellBeginEdit
        Try
            Dim n As DataGridViewTreeNode = DirectCast(dwItems.Rows(e.RowIndex), DatagridTreeView.DataGridViewTreeNode)
            If n.Level > 1 Then
                If Convert.ToBoolean(n.Parent.Cells(enedicion.Index).Value) Then
                    Dim rs As ControlesPersonalizados.Estructurador.RegionEstructuras() = eatomapuntos.ObtenerRegionxId(eatomapuntos.EstructuraPrincipal, Convert.ToInt32(n.Cells(idcotiza.Index).Value))
                    If rs.Length > 0 Then
                        Select Case e.ColumnIndex
                            Case ancho.Index
                                Dim c = eatomapuntos.Cotas.FirstOrDefault(Function(x) rs.Contains(x.Propietario) And (x.Orientacion = Tipo_Cota.HORIZONTAL Or x.Orientacion = Tipo_Cota.CENTRAL))
                                e.Cancel = (c Is Nothing)
                            Case alto.Index
                                Dim c = eatomapuntos.Cotas.FirstOrDefault(Function(x) rs.Contains(x.Propietario) And x.Orientacion = Tipo_Cota.VERTICAL)
                                e.Cancel = (c Is Nothing)
                        End Select
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwItems.CellEndEdit
        Try
            Dim n As DataGridViewTreeNode = DirectCast(dwItems.Rows(e.RowIndex), DatagridTreeView.DataGridViewTreeNode)
            If Not IsNumeric(n.Cells(e.ColumnIndex).Value) Then
                n.Cells(e.ColumnIndex).Value = n.Cells(e.ColumnIndex).Tag
            End If
            If n.Level = 1 Then
                Select Case e.ColumnIndex
                    Case ancho.Index
                        Dim c = eatomapuntos.Cotas.Where(Function(x) x.Propietario Is eatomapuntos.EstructuraPrincipal And (x.Orientacion = Tipo_Cota.HORIZONTAL Or x.Orientacion = Tipo_Cota.CENTRAL)).ToArray()
                        For i As Integer = 0 To c.Length - 1
                            c(i).Texto = Convert.ToString(n.Cells(e.ColumnIndex).Value)
                        Next
                    Case alto.Index
                        Dim c = eatomapuntos.Cotas.Where(Function(x) x.Propietario Is eatomapuntos.EstructuraPrincipal And x.Orientacion = Tipo_Cota.VERTICAL).ToArray()
                        For i As Integer = 0 To c.Length - 1
                            c(i).Texto = Convert.ToString(n.Cells(e.ColumnIndex).Value)
                        Next
                End Select
                eatomapuntos.Refresh()
            Else
                Dim rs As ControlesPersonalizados.Estructurador.RegionEstructuras() = eatomapuntos.ObtenerRegionxId(eatomapuntos.EstructuraPrincipal, Convert.ToInt32(n.Cells(idcotiza.Index).Value))
                Select Case e.ColumnIndex
                    Case ancho.Index
                        Dim c = eatomapuntos.Cotas.Where(Function(x) rs.Contains(x.Propietario) And (x.Orientacion = Tipo_Cota.HORIZONTAL Or x.Orientacion = Tipo_Cota.CENTRAL)).ToArray()
                        For i As Integer = 0 To c.Length - 1
                            c(i).Texto = Convert.ToString(n.Cells(e.ColumnIndex).Value)
                        Next
                    Case alto.Index
                        Dim c = eatomapuntos.Cotas.Where(Function(x) rs.Contains(x.Propietario) And x.Orientacion = Tipo_Cota.VERTICAL).ToArray()
                        For i As Integer = 0 To c.Length - 1
                            c(i).Texto = Convert.ToString(n.Cells(e.ColumnIndex).Value)
                        Next
                End Select
                eatomapuntos.Refresh()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub eatomapuntos_valor_Cota_Cambiado(sender As Object, e As ValorCotaCambiado_EventArgs) Handles eatomapuntos.valor_Cota_Cambiado
        Try
            Dim n As DataGridViewTreeNode
            If e.Cota.Propietario.Id_Hijo_Owner <= 0 Then
                n = dwItems.Nodes.FirstOrDefault(Function(x) Convert.ToBoolean(x.Cells(enedicion.Index).Value))
            Else
                n = dwItems.Nodes.FirstOrDefault(Function(x) Convert.ToBoolean(x.Cells(enedicion.Index).Value)).Nodes.FirstOrDefault(Function(x) Convert.ToInt32(x.Cells(idcotiza.Index).Value) = e.Cota.Propietario.Id_Hijo_Owner)
            End If
            If n IsNot Nothing Then
                Select Case e.Cota.Orientacion
                    Case Tipo_Cota.HORIZONTAL, Tipo_Cota.CENTRAL
                        n.Cells(ancho.Index).Value = e.Valor_Nuevo
                    Case Tipo_Cota.VERTICAL
                        n.Cells(alto.Index).Value = e.Valor_Nuevo
                End Select
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItems_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItems.CellMouseDown
        Try
            Dim n As DataGridViewTreeNode = DirectCast(dwItems.Rows(e.RowIndex), DataGridViewTreeNode)
            If e.Button = MouseButtons.Right Then
                n.Selected = True
                Dim menu As New ContextMenuStrip
                If n.Level > 1 Then
                    menu.Items.Add("Modificar Variables", Nothing, AddressOf ModificarVariables)
                Else
                    If Convert.ToInt32(n.Cells(cantidad.Index).Value) > 1 Then
                        menu.Items.Add("Medida Bano Diferente", Nothing, AddressOf MedidaBanoDiferente)
                    End If
                End If
                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub MedidaBanoDiferente()
        Try
            Dim n As DataGridViewTreeNode = DirectCast(dwItems.SelectedRows(0), DataGridViewTreeNode)
            Dim fcantdup As New FrmCantidad_a_Duplicar
            fcantdup.Cantidad_Maxima = Convert.ToDecimal(n.Cells(cantidad.Index).Value) - 1
            fcantdup.Cantidad = fcantdup.Cantidad_Maxima
            If fcantdup.ShowDialog() = DialogResult.OK Then
                Dim nn As New DataGridViewTreeNode
                dwItems.Nodes.Add(nn)
                For i As Integer = 1 To n.Cells.Count - 1
                    nn.Cells(i).Value = n.Cells(i).Value
                Next
                n.Cells(cantidad.Index).Value = Convert.ToInt32(n.Cells(cantidad.Index).Value) - fcantdup.Cantidad
                nn.Cells(cantidad.Index).Value = fcantdup.Cantidad
                For i As Integer = 0 To n.Nodes.Count - 1
                    Dim nd As New DataGridViewTreeNode()
                    nn.Nodes.Add(nd)
                    For j As Integer = 1 To n.Cells.Count - 1
                        nd.Cells(j).Value = n.Nodes(i).Cells(j).Value
                    Next
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ModificarVariables()
        Try
            Dim n As DataGridViewTreeNode = DirectCast(dwItems.SelectedRows(0), DataGridViewTreeNode)
            Dim fmodificacionvar As New FrmModificacionVariables
            fmodificacionvar.IdPlantilla = Convert.ToInt32(n.Cells(idcotiza.Index).Value)
            If fmodificacionvar.ShowDialog() = DialogResult.OK Then
                n.Cells(especial.Index).Value = fmodificacionvar.Analizador
                If fmodificacionvar.Analizador.ListaVariables.Contains("ANCHO") Then
                    n.Cells(ancho.Index).Value = fmodificacionvar.Analizador.ListaVariables.Item("ANCHO").Valor
                End If
                If fmodificacionvar.Analizador.ListaVariables.Contains("ALTO") Then
                    n.Cells(alto.Index).Value = fmodificacionvar.Analizador.ListaVariables.Item("ALTO").Valor
                End If
                If fmodificacionvar.Analizador.ListaVariables.Contains("DIMENSION") Then
                    n.Cells(ancho.Index).Value = fmodificacionvar.Analizador.ListaVariables.Item("DIMENSION").Valor
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

End Class