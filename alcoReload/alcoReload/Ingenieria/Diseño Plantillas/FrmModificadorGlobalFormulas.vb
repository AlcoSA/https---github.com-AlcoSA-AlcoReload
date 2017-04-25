Imports ReglasNegocio
Imports Formulador
Public Class FrmModificadorGlobalFormulas

#Region "Variables"
    Private analizador As AnalizadorLexico
#End Region

#Region "Carga Combo"
    Private Sub CargarOrientacion()
        Try
            Dim morienta As New ClsOrientacionPosicionMaterial
            Dim listaorienta As List(Of OrientacionPosicion) = morienta.Traerxestado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listaorienta
            cborientacion.DisplayMember = "Nombre"
            cborientacion.ValueMember = "Id"
            cborientacion.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargarUbicacion()
        Try
            Dim mubica As New ClsUbicacionMaterial
            Dim listaubica As List(Of UbicacionMaterial) = mubica.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listaubica
            cbubicacion.DisplayMember = "Nombre"
            cbubicacion.ValueMember = "Id"
            cbubicacion.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargarMaterialPara()
        Try
            Dim mmaterialpara As New ClsMaterialPara
            Dim listamaterialpara As List(Of MaterialPara) = mmaterialpara.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listamaterialpara
            cbmaterialpara.DisplayMember = "Nombre"
            cbmaterialpara.ValueMember = "Id"
            cbmaterialpara.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargarTipoMaterial()
        Try
            Dim mtipomaterial As New ClsTiposMaterial
            Dim listatipomaterial As List(Of TipoMaterial) = mtipomaterial.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listatipomaterial
            cbtipomaterial.DisplayMember = "Nombre"
            cbtipomaterial.ValueMember = "Id"
            cbtipomaterial.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CargarCortes()
        Try
            Dim mtipocorte As New ClsTiposCortes
            Dim listatipocorte As List(Of TipoCorte) = mtipocorte.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listatipocorte
            cbcortes.DisplayMember = "Nombre"
            cbcortes.ValueMember = "Id"
            cbcortes.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

#Region "Carga Plantilla"

    Private Sub cargarVariablesplantilla()
        Try
            Dim mvarplantilla As New ClsVariablesPlantillas
            Dim valvar As New ClsValoresVariables
            Dim listvariablesutilizadas As List(Of VariablePlantilla) = mvarplantilla.TraerxIdPlantilla(Convert.ToInt32(itPlantillas.Seleted_rowid))
            For Each var As VariablePlantilla In listvariablesutilizadas
                Dim valorvaria As String = String.Empty
                Dim valminimo As String = String.Empty
                Dim valmaximo As String = String.Empty
                Dim cformula As String = String.Empty
                Dim tdato As Integer = var.TipoDato
                Select Case tdato
                    Case Is = ClsEnums.TiposDato.NUMERICO
                        valminimo = If(String.IsNullOrEmpty(var.ValorMinimo) Or var.ValorMinimo.StartsWith("="), 0, var.ValorMinimo)
                        valmaximo = If(String.IsNullOrEmpty(var.ValorMaximo) Or var.ValorMaximo.StartsWith("="), Int32.MaxValue, var.ValorMaximo)
                    Case Is = ClsEnums.TiposDato.TEXTO
                        valminimo = If(var.ValorMinimo.StartsWith("="), String.Empty, var.ValorMinimo)
                        valmaximo = If(var.ValorMaximo.StartsWith("="), String.Empty, var.ValorMaximo)
                    Case Is = ClsEnums.TiposDato.BOOLEANO
                        valminimo = 0
                        valmaximo = 1
                    Case Is = ClsEnums.TiposDato.FECHA
                        valminimo = If(String.IsNullOrEmpty(var.ValorMinimo) Or var.ValorMinimo.StartsWith("="), Date.MinValue.ToString(), var.ValorMinimo)
                        valmaximo = If(String.IsNullOrEmpty(var.ValorMaximo) Or var.ValorMaximo.StartsWith("="), Date.MaxValue.ToString(), var.ValorMaximo)
                End Select
                valorvaria = var.ValorMinimo

                If analizador.ListaVariables.Contains(var.Variable) Then
                    Dim param As Parametro = analizador.ListaVariables.Item(var.Variable)
                    param.Restricciones.Clear()
                    If Not String.IsNullOrEmpty(Convert.ToString(var.ValorMinimo)) Then
                        If Convert.ToString(var.ValorMinimo).StartsWith("=") Then
                            param.Restricciones.Add(New Restriccion("MINIMO", Convert.ToString(var.ValorMinimo),
                                                                    valminimo, tdato))
                        Else
                            param.Restricciones.Add(New Restriccion("MINIMO",
                                                                    valminimo, tdato))
                        End If
                    End If
                    If Not String.IsNullOrEmpty(var.ValorMaximo) Then
                        If Convert.ToString(var.ValorMaximo).StartsWith("=") Then
                            param.Restricciones.Add(New Restriccion("MAXIMO", var.ValorMaximo,
                                                                        valmaximo, tdato))
                        Else
                            param.Restricciones.Add(New Restriccion("MAXIMO",
                                                                    valmaximo, tdato))
                        End If
                    End If
                    param.TipoValor = tdato
                    param.Valor = valorvaria
                    param.Formula = valorvaria
                Else
                    Dim param As New Parametro(var.Variable, valorvaria, valorvaria, tdato)
                    param.Id = var.Id
                    If Not String.IsNullOrEmpty(var.ValorMinimo) Then
                        If Convert.ToString(var.ValorMinimo).StartsWith("=") Then
                            param.Restricciones.Add(New Restriccion("MINIMO", var.ValorMinimo,
                                                                    valminimo, tdato))
                        Else
                            param.Restricciones.Add(New Restriccion("MINIMO",
                                                                    valminimo, tdato))
                        End If
                    End If

                    If Not String.IsNullOrEmpty(var.ValorMaximo) Then
                        If var.ValorMaximo.StartsWith("=") Then
                            param.Restricciones.Add(New Restriccion("MAXIMO", var.ValorMaximo,
                                                                        valmaximo, tdato))
                        Else
                            param.Restricciones.Add(New Restriccion("MAXIMO",
                                                                    valmaximo, tdato))
                        End If
                    End If
                    analizador.ListaVariables.Add(param)
                End If
            Next
            cargaryCrearDescuentosGlobales()
            VerificaryCrearMateriales()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargaryCrearDescuentosGlobales()
        Try
            Dim listDescuentosGlobales As New List(Of descuentoGlobal)

            Dim mdescuentosGlobales = New ClsDescuentosGlobales
            listDescuentosGlobales = mdescuentosGlobales.TraerxIdPlantilla(Convert.ToInt32(itPlantillas.Seleted_rowid))

            If listDescuentosGlobales.Count = 0 Then Return
            For Each var As descuentoGlobal In listDescuentosGlobales
                analizador.ListaDescuentos.Add(New Formulador.Descuento(var.Id,
                                                        var.IdDescuento,
                                                         var.Descuento,
                                                         var.Valor,
                                                         var.Formula))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub VerificaryCrearMateriales()
        Try
            Dim cmaterial As New ClsMaterialesPlantilla
            Dim lmateriales As List(Of MaterialPlantilla) = cmaterial.TraerxIdplantilla(Convert.ToInt32(itPlantillas.Seleted_rowid))
            Dim cv As Integer = 0
            Dim cp As Integer = 0
            Dim ca As Integer = 0
            For i = 0 To lmateriales.Count - 1
                Dim c As Integer = 0
                Dim nmat As String = String.Empty
                Select Case lmateriales(i).IdFamiliaMaterial
                    Case Is = ClsEnums.FamiliasMateriales.ACCESORIOS
                        nmat = "ACCESORIOS"
                        ca += 1
                        c = ca
                    Case Is = ClsEnums.FamiliasMateriales.PERFILERIA
                        nmat = "PERFIL"
                        cp += 1
                        c = cp
                    Case Is = ClsEnums.FamiliasMateriales.VIDRIO
                        nmat = "VIDRIO"
                        cv += 1
                        c = cv
                End Select
                Dim nuevomaterial As New Objeto(nmat, c)
                nuevomaterial.Id = lmateriales(i).Id
                nuevomaterial.TipoObjeto = lmateriales(i).IdFamiliaMaterial
                analizador.ListaMateriales.Add(nuevomaterial)
                Dim dic As Dictionary(Of String, String) = lmateriales(i).Formulacion(True)
                For Each f In dic
                    If f.Value.StartsWith("=") Then
                        nuevomaterial.Parametros.Add(New Parametro(f.Key, f.Value.Remove(0, 1),
                                                         0, TiposValores.Letras))
                    Else
                        nuevomaterial.Parametros.Add(New Parametro(f.Key, String.Empty,
                                 f.Value, TiposValores.Letras))
                    End If
                Next
                Dim listadescuentos As List(Of DescuentoMaterial)
                Dim mdescuentosmaterial As New ClsDescuentosMaterial
                listadescuentos = mdescuentosmaterial.TraerxIdmaterial(lmateriales(i).Id)
                For Each d In listadescuentos
                    If Not (nuevomaterial.Descuentos.Contains(d.Descuento)) Then
                        nuevomaterial.Descuentos.Add(New Formulador.Descuento(d.Id, d.IdDescuento,
                                                                              d.Descuento,
                                                                              d.Valor, d.Formula))
                    End If
                Next

            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub ValorarCompleto()
        Try
            analizador.ValorarRestricciones()
            analizador.ValorarElementosDescuentos()
            analizador.ValorarElementosMaterial()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

#Region "Procedimientos"
    Private Sub cargarPlantillas()
        Try
            Dim pmodelo As New ClsPlantillasModelos
            pmodelo.TraerxEstado(ClsEnums.Estados.ACTIVO, itPlantillas.TablaFuente)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarElementosPlantilla(idplantilla As Integer)
        Try
            Dim mmaterialas As New ClsMaterialesPlantilla
            Dim listamateriales As List(Of MaterialPlantilla) = mmaterialas.TraerxIdplantilla(idplantilla)
            Dim bsource As New BindingSource()
            bsource.DataSource = listamateriales
            lbelementos.DisplayMember = "ArticuloReferencia"
            lbelementos.ValueMember = "Id"
            lbelementos.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarPlantillasporArticulo(articulo As String, id As Integer)
        Try
            lbdiseños.Items.Clear()
            Dim plantillas As New ClsPlantillasModelos
            Dim listaplantillas As List(Of PlantillaModelo) = plantillas.TraerporIdArticuloMAterial(articulo)
            For i As Integer = 0 To listaplantillas.Count - 1
                lbdiseños.Items.Add(listaplantillas(i).Id & "-" & listaplantillas(i).NombreModelo)
            Next
            Dim mmaterial As New ClsMaterialesPlantilla
            Dim material As MaterialPlantilla = mmaterial.TraerxId(id)
            Select Case DirectCast(material.IdFamiliaMaterial, ClsEnums.FamiliasMateriales)
                Case ClsEnums.FamiliasMateriales.PERFILERIA
                    txtespesor.Enabled = False
                    btnformulaespesor.Enabled = False
                    txtalto.Enabled = False
                    btnformularalto.Enabled = False
                    cbcortes.Enabled = True
                    cbubicacion.Enabled = True
                    txtreferencia.Enabled = False
                    txtreferencia.Text = material.ArticuloReferencia
                    btnformularreferencia.Enabled = False
                Case ClsEnums.FamiliasMateriales.ACCESORIOS
                    txtalto.Enabled = False
                    btnformularalto.Enabled = False
                    txtespesor.Enabled = False
                    btnformulaespesor.Enabled = False
                    cbcortes.Enabled = False
                    cbubicacion.Enabled = False
                    txtreferencia.Enabled = False
                    txtreferencia.Text = material.ArticuloReferencia
                    btnformularreferencia.Enabled = False
                Case ClsEnums.FamiliasMateriales.OTROS
                    txtalto.Enabled = True
                    btnformularalto.Enabled = True
                    txtespesor.Enabled = False
                    btnformulaespesor.Enabled = False
                    cbcortes.Enabled = False
                    cbubicacion.Enabled = False
                    cbmaterialpara.Enabled = False
                    cborientacion.Enabled = False
                    cbtipomaterial.Enabled = False
                    txtpeso.Enabled = False
                    txtreferencia.Enabled = False
                    txtreferencia.Text = material.ArticuloReferencia
                    btnformularreferencia.Enabled = False
                Case ClsEnums.FamiliasMateriales.VIDRIO
                    txtalto.Enabled = True
                    btnformularalto.Enabled = True
                    txtespesor.Enabled = True
                    btnformulaespesor.Enabled = True
                    cbcortes.Enabled = False
                    cbubicacion.Enabled = False
                    txtreferencia.Enabled = True
                    txtreferencia.Text = material.Articulo
                    btnformularreferencia.Enabled = True
            End Select
            txtespesor.Text = material.Espesor
            txtacabado.Text = material.Acabado
            txtcantidad.Text = material.Cantidad
            txtpxuni.Text = material.PiezasxUnidad
            txtancho.Text = material.Ancho
            txtalto.Text = material.Alto
            txtdetalle.Text = material.Observaciones
            txtpeso.Text = material.peso
            txtvisibilidad.Text = material.Visibilidad
            cbcortes.SelectedValue = material.IdTipoCortes
            cbubicacion.SelectedValue = material.IdUbicacionMaterial
            cbmaterialpara.SelectedValue = material.IdMaterialPara
            cborientacion.SelectedValue = material.IdOrientacionyPosicion
            cbtipomaterial.SelectedValue = material.IdTipoMaterial

            txtespesor.Tag = material.Espesor
            txtacabado.Tag = material.Acabado
            txtcantidad.Tag = material.Cantidad
            txtpxuni.Tag = material.PiezasxUnidad
            txtancho.Tag = material.Ancho
            txtancho.Tag = material.Ancho
            txtalto.Tag = material.Alto
            txtdetalle.Tag = material.Observaciones
            txtpeso.Tag = material.peso
            txtvisibilidad.Tag = material.Visibilidad
            cbcortes.Tag = material.IdTipoCortes
            cbubicacion.Tag = material.IdUbicacionMaterial
            cbmaterialpara.Tag = material.IdMaterialPara
            cborientacion.Tag = material.IdOrientacionyPosicion
            cbtipomaterial.Tag = material.IdTipoMaterial

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
            btnsParcial.Enabled = True
            AddHandler btnsParcial.Click, AddressOf Guardar_Click
            AddHandler btnguardar.Click, AddressOf Guardar_Click
            AddHandler btnsTotal.Click, AddressOf Guardar_Click
            AddHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
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
            btnsParcial.Enabled = False
            RemoveHandler btnsParcial.Click, AddressOf Guardar_Click
            RemoveHandler btnguardar.Click, AddressOf Guardar_Click
            RemoveHandler btnsTotal.Click, AddressOf Guardar_Click
            RemoveHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        Try
            txtalto.Enabled = True
            btnformularalto.Enabled = True
            txtespesor.Enabled = True
            btnformulaespesor.Enabled = True
            cbcortes.Enabled = True
            cbubicacion.Enabled = True
            cbmaterialpara.Enabled = True
            cborientacion.Enabled = True
            cbtipomaterial.Enabled = True
            txtpeso.Enabled = True
            txtreferencia.Enabled = True
            btnformularreferencia.Enabled = False
            analizador = New AnalizadorLexico
            itPlantillas.Text = String.Empty
            itPlantillas.Seleted_rowid = 0
            lbdiseños.Items.Clear()
            lbelementos.DataSource = Nothing
            txtreferencia.Text = String.Empty
            txtespesor.Text = String.Empty
            txtacabado.Text = String.Empty
            txtcantidad.Text = String.Empty
            txtancho.Text = String.Empty
            txtalto.Text = String.Empty
            txtdetalle.Text = String.Empty
            txtpeso.Text = String.Empty
            txtvisibilidad.Text = String.Empty
            txtpxuni.Text = String.Empty
            txtreferencia.Tag = String.Empty
            txtespesor.Tag = String.Empty
            txtacabado.Tag = String.Empty
            txtcantidad.Tag = String.Empty
            txtancho.Tag = String.Empty
            txtalto.Tag = String.Empty
            txtdetalle.Tag = String.Empty
            txtpeso.Tag = String.Empty
            txtvisibilidad.Tag = String.Empty
            txtpxuni.Tag = String.Empty
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Guardar_Click(sender As Object, e As EventArgs)
        Try
            Dim mat As New ClsMaterialesPlantilla
#Region "Modificación Original"
            Dim id As Integer = DirectCast(lbelementos.SelectedItem, MaterialPlantilla).Id
            If Not txtreferencia.Text.Equals(Convert.ToString(txtreferencia.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(txtreferencia.AccessibleName),
                                          txtreferencia.Text)
            End If
            If Not txtespesor.Text.Equals(Convert.ToString(txtespesor.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(txtespesor.AccessibleName),
                                          txtespesor.Text)
            End If
            If Not txtacabado.Text.Equals(Convert.ToString(txtacabado.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(txtacabado.AccessibleName),
                                          txtacabado.Text)
            End If
            If Not txtcantidad.Text.Equals(Convert.ToString(txtcantidad.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(txtcantidad.AccessibleName),
                                          txtcantidad.Text)
            End If
            If Not txtancho.Text.Equals(Convert.ToString(txtancho.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(txtancho.AccessibleName),
                                          txtancho.Text)
            End If
            If Not txtalto.Text.Equals(Convert.ToString(txtalto.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(txtalto.AccessibleName),
                                          txtalto.Text)
            End If
            If Not txtdetalle.Text.Equals(Convert.ToString(txtdetalle.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(txtdetalle.AccessibleName),
                                          txtdetalle.Text)
            End If
            If Not Convert.ToString(cborientacion.SelectedValue).Equals(Convert.ToString(cborientacion.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(cborientacion.AccessibleName),
                          Convert.ToString(cborientacion.SelectedValue))
            End If
            If Not Convert.ToString(cbubicacion.SelectedValue).Equals(Convert.ToString(cbubicacion.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(cbubicacion.AccessibleName),
                        Convert.ToString(cbubicacion.SelectedValue))
            End If
            If Not Convert.ToString(cbmaterialpara.SelectedValue).Equals(Convert.ToString(cbmaterialpara.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(cbmaterialpara.AccessibleName),
                        Convert.ToString(cbmaterialpara.SelectedValue))
            End If
            If Not Convert.ToString(cbtipomaterial.SelectedValue).Equals(Convert.ToString(cbtipomaterial.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(cbtipomaterial.AccessibleName),
                        Convert.ToString(cbtipomaterial.SelectedValue))
            End If
            If Not Convert.ToString(cbcortes.SelectedValue).Equals(Convert.ToString(cbcortes.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(cbcortes.AccessibleName),
                        Convert.ToString(cbcortes.SelectedValue))
            End If
            If Not txtpeso.Text.Equals(Convert.ToString(txtpeso.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(txtpeso.AccessibleName),
                                          txtpeso.Text)
            End If
            If Not txtvisibilidad.Text.Equals(Convert.ToString(txtvisibilidad.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(txtvisibilidad.AccessibleName),
                                          txtvisibilidad.Text)
            End If
            If Not txtpxuni.Text.Equals(Convert.ToString(txtpxuni.Tag)) Then
                mat.ModificarFormulaporId(id, Convert.ToInt32(txtpxuni.AccessibleName),
                                          txtpxuni.Text)
            End If
#End Region
#Region "Modificaciones Secundarias"

            Dim listnoposibles As New List(Of String)
            Dim idf As Integer = DirectCast(lbelementos.SelectedItem, MaterialPlantilla).IdFamiliaMaterial
            For i As Integer = 0 To lbdiseños.Items.Count - 1
                If lbdiseños.GetItemChecked(i) Then
                    Dim idp As Integer = Convert.ToInt32(lbdiseños.Items(i).ToString().Split("-")(0))
                    Dim ref As Integer = Convert.ToInt32(lbdiseños.Items(i).ToString().Split("-")(1))
                    If Not txtreferencia.Text.Equals(Convert.ToString(txtreferencia.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                                              Convert.ToInt32(txtreferencia.AccessibleName),
                                                              txtreferencia.Tag, txtreferencia.Text) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not txtespesor.Text.Equals(Convert.ToString(txtespesor.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(txtespesor.AccessibleName),
                                          txtespesor.Tag, txtespesor.Text) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not txtacabado.Text.Equals(Convert.ToString(txtacabado.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(txtacabado.AccessibleName),
                                          txtacabado.Tag, txtacabado.Text) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not txtcantidad.Text.Equals(Convert.ToString(txtcantidad.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(txtcantidad.AccessibleName),
                                          txtcantidad.Tag, txtcantidad.Text) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not txtancho.Text.Equals(Convert.ToString(txtancho.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(txtancho.AccessibleName),
                                          txtancho.Tag, txtancho.Text) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not txtalto.Text.Equals(Convert.ToString(txtalto.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(txtalto.AccessibleName),
                                          txtalto.Tag, txtalto.Text) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not txtdetalle.Text.Equals(Convert.ToString(txtdetalle.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(txtdetalle.AccessibleName),
                                          txtdetalle.Tag, txtdetalle.Text) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not Convert.ToString(cborientacion.SelectedValue).Equals(Convert.ToString(cborientacion.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(cborientacion.AccessibleName),
                                          cborientacion.Tag, Convert.ToString(cborientacion.SelectedValue)) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not Convert.ToString(cbubicacion.SelectedValue).Equals(Convert.ToString(cbubicacion.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(cbubicacion.AccessibleName),
                                          cbubicacion.Tag, Convert.ToString(cbubicacion.SelectedValue)) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not Convert.ToString(cbmaterialpara.SelectedValue).Equals(Convert.ToString(cbmaterialpara.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(cbmaterialpara.AccessibleName),
                                          cbmaterialpara.Tag, Convert.ToString(cbmaterialpara.SelectedValue)) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not Convert.ToString(cbtipomaterial.SelectedValue).Equals(Convert.ToString(cbtipomaterial.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(cbtipomaterial.AccessibleName),
                                          cbtipomaterial.Tag, Convert.ToString(cbtipomaterial.SelectedValue)) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not Convert.ToString(cbcortes.SelectedValue).Equals(Convert.ToString(cbcortes.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(cbcortes.AccessibleName),
                                          cbcortes.Tag, Convert.ToString(cbcortes.SelectedValue)) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not txtpeso.Text.Equals(Convert.ToString(txtpeso.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(txtpeso.AccessibleName),
                                          txtpeso.Tag, txtpeso.Text) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not txtvisibilidad.Text.Equals(Convert.ToString(txtvisibilidad.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(txtvisibilidad.AccessibleName),
                                          txtvisibilidad.Tag, txtvisibilidad.Text) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                    If Not txtpxuni.Text.Equals(Convert.ToString(txtpxuni.Tag)) Then
                        If mat.ModificarFormulaporIdPlantilla(idp, idf,
                                          Convert.ToInt32(txtpxuni.AccessibleName),
                                          txtpxuni.Tag, txtpxuni.Text) <= 0 Then
                            listnoposibles.Add(ref)
                        End If
                    End If
                End If
            Next

            If listnoposibles.Count > 0 Then
                MsgBox("Los siguientes diseños no se pudieron modificar: " & String.Join(vbCr, listnoposibles.ToArray()) & " . Debe realizar las modificación manualmente", MsgBoxStyle.Exclamation)
            Else
                MsgBox("Las modificaciones se han realizado correctamente", MsgBoxStyle.Information)
            End If
#End Region
            txtreferencia.Tag = txtreferencia.Text
            txtespesor.Tag = txtespesor.Text
            txtacabado.Tag = txtacabado.Text
            txtcantidad.Tag = txtcantidad.Text
            txtancho.Tag = txtancho.Text
            txtalto.Tag = txtalto.Text
            txtdetalle.Tag = txtdetalle.Text
            txtpeso.Tag = txtpeso.Text
            txtvisibilidad.Tag = txtvisibilidad.Text
            cborientacion.Tag = cborientacion.SelectedValue
            cbubicacion.Tag = cbubicacion.SelectedValue
            cbmaterialpara.Tag = cbmaterialpara.SelectedValue
            cbtipomaterial.Tag = cbtipomaterial.SelectedValue
            cbcortes.Tag = cbcortes.SelectedValue
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmModificadorGlobalFormulas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarPlantillas()
            CargarOrientacion()
            CargarUbicacion()
            CargarMaterialPara()
            CargarTipoMaterial()
            CargarCortes()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itPlantillas_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itPlantillas.selected_value_changed
        Try
            If e.Id > 0 Then
                analizador = New AnalizadorLexico
                cargarElementosPlantilla(e.Id)
                cargarVariablesplantilla()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub lbelementos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbelementos.SelectedIndexChanged
        Try
            cargarPlantillasporArticulo(DirectCast(lbelementos.SelectedItem, MaterialPlantilla).Articulo, Convert.ToInt32(lbelementos.SelectedValue))
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cbcortes_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cbcortes.DrawItem
        Try
            Dim cmb As ComboBox = DirectCast(sender, ComboBox)
            Dim utimagen As New ClsUtilidadesImagenes
            Dim ltcorte As List(Of TipoCorte) = DirectCast(cmb.DataSource, System.Windows.Forms.BindingSource).List
            Dim g As Graphics = e.Graphics
            Dim bSelected As Boolean = CBool(e.State And DrawItemState.Selected)
            Dim bValue As Boolean = CBool(e.State And DrawItemState.ComboBoxEdit)
            Dim rDraw As Rectangle = e.Bounds
            rDraw.Inflate(-1, -1)
            If bSelected And Not bValue Then
                g.FillRectangle(Brushes.LightBlue, rDraw)
                g.DrawRectangle(Pens.DodgerBlue, rDraw)
            Else
                g.FillRectangle(Brushes.White, e.Bounds)
            End If
            Dim img As Image = utimagen.ArregloBytesaImagen(ltcorte.Item(e.Index).Imagen)
            g.DrawImage(img, rDraw.X + 5, rDraw.Y, rDraw.Width - 5, rDraw.Height)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cbcortes_MeasureItem(sender As Object, e As MeasureItemEventArgs) Handles cbcortes.MeasureItem
        Try
            e.ItemHeight = 30
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnformularreferencia_Click(sender As Object, e As EventArgs) Handles btnformularreferencia.Click
        Try
            Dim formu As New Formulador.Formularios_Ayuda.FrmFormulador
            If Not String.IsNullOrEmpty(txtreferencia.Text) Then
                If txtreferencia.Text.StartsWith("=") Then
                    formu.Formula = txtreferencia.Text.Remove(0, 1)
                    formu.Text = txtreferencia.Text.Remove(0, 1)
                Else
                    formu.Formula = txtreferencia.Text
                    formu.Text = txtreferencia.Text
                End If
            End If
            formu.Analizador = analizador
            If formu.ShowDialog() = DialogResult.OK Then
                txtreferencia.Text = formu.Formula
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnformulaespesor_Click(sender As Object, e As EventArgs) Handles btnformulaespesor.Click
        Try
            Dim formu As New Formulador.Formularios_Ayuda.FrmFormulador
            If Not String.IsNullOrEmpty(txtespesor.Text) Then
                If txtespesor.Text.StartsWith("=") Then
                    formu.Formula = txtespesor.Text.Remove(0, 1)
                    formu.Text = txtespesor.Text.Remove(0, 1)
                Else
                    formu.Formula = txtespesor.Text
                    formu.Text = txtespesor.Text
                End If
            End If
            formu.Analizador = analizador
            If formu.ShowDialog() = DialogResult.OK Then
                txtespesor.Text = formu.Formula
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnformularacabado_Click(sender As Object, e As EventArgs) Handles btnformularacabado.Click
        Try
            Dim formu As New Formulador.Formularios_Ayuda.FrmFormulador
            If Not String.IsNullOrEmpty(txtacabado.Text) Then
                If txtacabado.Text.StartsWith("=") Then
                    formu.Formula = txtacabado.Text.Remove(0, 1)
                    formu.Text = txtacabado.Text.Remove(0, 1)
                Else
                    formu.Formula = txtacabado.Text
                    formu.Text = txtacabado.Text
                End If
            End If
            formu.Analizador = analizador
            If formu.ShowDialog() = DialogResult.OK Then
                txtacabado.Text = formu.Formula
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnformularcantidad_Click(sender As Object, e As EventArgs) Handles btnformularcantidad.Click
        Try
            Dim formu As New Formulador.Formularios_Ayuda.FrmFormulador
            If Not String.IsNullOrEmpty(txtcantidad.Text) Then
                If txtcantidad.Text.StartsWith("=") Then
                    formu.Formula = txtcantidad.Text.Remove(0, 1)
                    formu.Text = txtcantidad.Text.Remove(0, 1)
                Else
                    formu.Formula = txtcantidad.Text
                    formu.Text = txtcantidad.Text
                End If
            End If
            formu.Analizador = analizador
            If formu.ShowDialog() = DialogResult.OK Then
                txtcantidad.Text = formu.Formula
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnformularancho_Click(sender As Object, e As EventArgs) Handles btnformularancho.Click
        Try
            Dim formu As New Formulador.Formularios_Ayuda.FrmFormulador
            If Not String.IsNullOrEmpty(txtancho.Text) Then
                If txtancho.Text.StartsWith("=") Then
                    formu.Formula = txtancho.Text.Remove(0, 1)
                    formu.Text = txtancho.Text.Remove(0, 1)
                Else
                    formu.Formula = txtancho.Text
                    formu.Text = txtancho.Text
                End If
            End If
            formu.Analizador = analizador
            If formu.ShowDialog() = DialogResult.OK Then
                txtancho.Text = formu.Formula
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnformularalto_Click(sender As Object, e As EventArgs) Handles btnformularalto.Click
        Try
            Dim formu As New Formulador.Formularios_Ayuda.FrmFormulador
            If Not String.IsNullOrEmpty(txtalto.Text) Then
                If txtalto.Text.StartsWith("=") Then
                    formu.Formula = txtalto.Text.Remove(0, 1)
                    formu.Text = txtalto.Text.Remove(0, 1)
                Else
                    formu.Formula = txtalto.Text
                    formu.Text = txtalto.Text
                End If
            End If
            formu.Analizador = analizador
            If formu.ShowDialog() = DialogResult.OK Then
                txtalto.Text = formu.Formula
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnformulardetalle_Click(sender As Object, e As EventArgs) Handles btnformulardetalle.Click
        Try
            Dim formu As New Formulador.Formularios_Ayuda.FrmFormulador
            If Not String.IsNullOrEmpty(txtdetalle.Text) Then
                If txtdetalle.Text.StartsWith("=") Then
                    formu.Formula = txtdetalle.Text.Remove(0, 1)
                    formu.Text = txtdetalle.Text.Remove(0, 1)
                Else
                    formu.Formula = txtdetalle.Text
                    formu.Text = txtdetalle.Text
                End If
            End If
            formu.Analizador = analizador
            If formu.ShowDialog() = DialogResult.OK Then
                txtdetalle.Text = formu.Formula
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnformularpeso_Click(sender As Object, e As EventArgs) Handles btnformularpeso.Click
        Try
            Dim formu As New Formulador.Formularios_Ayuda.FrmFormulador
            If Not String.IsNullOrEmpty(txtpeso.Text) Then
                If txtpeso.Text.StartsWith("=") Then
                    formu.Formula = txtpeso.Text.Remove(0, 1)
                    formu.Text = txtpeso.Text.Remove(0, 1)
                Else
                    formu.Formula = txtpeso.Text
                    formu.Text = txtpeso.Text
                End If
            End If
            formu.Analizador = analizador
            If formu.ShowDialog() = DialogResult.OK Then
                txtpeso.Text = formu.Formula
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnformularvisibilidad_Click(sender As Object, e As EventArgs) Handles btnformularvisibilidad.Click
        Try
            Dim formu As New Formulador.Formularios_Ayuda.FrmFormulador
            If Not String.IsNullOrEmpty(txtvisibilidad.Text) Then
                If txtvisibilidad.Text.StartsWith("=") Then
                    formu.Formula = txtvisibilidad.Text.Remove(0, 1)
                    formu.Text = txtvisibilidad.Text.Remove(0, 1)
                Else
                    formu.Formula = txtvisibilidad.Text
                    formu.Text = txtvisibilidad.Text
                End If
            End If
            formu.Analizador = analizador
            If formu.ShowDialog() = DialogResult.OK Then
                txtvisibilidad.Text = formu.Formula
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnformularpxuni_Click(sender As Object, e As EventArgs) Handles btnformularpxuni.Click
        Try
            Dim formu As New Formulador.Formularios_Ayuda.FrmFormulador
            If Not String.IsNullOrEmpty(txtpxuni.Text) Then
                If txtpxuni.Text.StartsWith("=") Then
                    formu.Formula = txtpxuni.Text.Remove(0, 1)
                    formu.Text = txtpxuni.Text.Remove(0, 1)
                Else
                    formu.Formula = txtpxuni.Text
                    formu.Text = txtpxuni.Text
                End If
            End If
            formu.Analizador = analizador
            If formu.ShowDialog() = DialogResult.OK Then
                txtpxuni.Text = formu.Formula
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class