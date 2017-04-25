Imports Formulador
Imports ReglasNegocio
Public Class FrmEditorModelos

#Region "vars"
    Private _idplantilloprod As Integer = 0
    Private _analizador As AnalizadorLexico
    Private _dibujosoprod As ClsDibujosPlantillaOrdenProd
    Private _observacionesoprod As ClsObservacionesPlantillaOrdenProd
    Private _materialoprod As ClsMaterialesPlantillaOrdenProd
    Private _variableoprod As ClsVariablesPlantillaOrdenProd
    Private _descuentosglobalesoprod As New ClsDescuentosGeneralesPlantillaOrdenProd
#End Region

#Region "props"
    Public Property IdPlantillaOProd As Integer
        Get
            Return _idplantilloprod
        End Get
        Set(value As Integer)
            _idplantilloprod = value
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
#End Region

#Region "procs"
    Private Sub cargarTiposModelo()
        Try
            Dim tmodelo As New ClsTipoModelo()
            Dim listTmodelo As List(Of TipoModelo) = tmodelo.TraerxEstado(ClsEnums.Estados.ACTIVO)
            listTmodelo.Insert(0, New TipoModelo())
            Dim bsource As New BindingSource()
            bsource.DataSource = listTmodelo
            Dim v As Integer = Convert.ToInt32(cbtipomodelo.SelectedValue)
            cbtipomodelo.ValueMember = "Id"
            cbtipomodelo.DisplayMember = "Tipo"
            cbtipomodelo.DataSource = bsource
            cbtipomodelo.SelectedValue = v
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarClasificacionModelo()
        Try
            Dim cfmodelo As New ClsClasificacionModelos()
            Dim listCmodelo As List(Of ClasificacionModelo) = cfmodelo.TraerxEstado(ClsEnums.Estados.ACTIVO)
            listCmodelo.Insert(0, New ClasificacionModelo())
            Dim bsource As New BindingSource()
            bsource.DataSource = listCmodelo
            Dim v As Integer = Convert.ToInt32(cbclasificacionmodelo.SelectedValue)
            cbclasificacionmodelo.ValueMember = "Id"
            cbclasificacionmodelo.DisplayMember = "Clasificacion"
            cbclasificacionmodelo.DataSource = bsource
            cbclasificacionmodelo.SelectedValue = v
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarFamiliasModelo()
        Try
            Dim fmodelo As New ClsFamiliaModelo()
            Dim listfmodelo As List(Of FamiliaModelo) = fmodelo.TraerxEstado(ClsEnums.Estados.ACTIVO)
            listfmodelo.Insert(0, New FamiliaModelo())
            Dim bsource As New BindingSource()
            bsource.DataSource = listfmodelo
            Dim v As Integer = Convert.ToInt32(cbfamiliamodelo.SelectedValue)
            cbfamiliamodelo.ValueMember = "Id"
            cbfamiliamodelo.DisplayMember = "Familia"
            cbfamiliamodelo.DataSource = bsource
            cbfamiliamodelo.SelectedValue = v
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarConfiguraciones()
        Try
            Dim fmodelo As New ClsConfiguraciones()
            Dim listCmodelo As List(Of Configuracion) = fmodelo.TraerxEstado(ClsEnums.Estados.ACTIVO)
            listCmodelo.Insert(0, New Configuracion())
            Dim bsource As New BindingSource()
            bsource.DataSource = listCmodelo
            Dim v As Integer = Convert.ToInt32(cbconfiguracionmodelo.SelectedValue)
            cbconfiguracionmodelo.ValueMember = "Id"
            cbconfiguracionmodelo.DisplayMember = "Configuracion"
            cbconfiguracionmodelo.DataSource = bsource
            cbconfiguracionmodelo.SelectedValue = v
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarCaracteristicasAdicionales()
        Try
            Dim camodelo As New ClsCaracteristicasAdicionales()
            Dim listCAmodelo As List(Of CaracteristicaAdicional) = camodelo.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listCAmodelo
            Dim v As Integer = Convert.ToInt32(cbcaracteristicasadicionales.SelectedValue)
            cbcaracteristicasadicionales.ValueMember = "Id"
            cbcaracteristicasadicionales.DisplayMember = "Descripcion"
            cbcaracteristicasadicionales.DataSource = bsource
            If v > 0 Then cbcaracteristicasadicionales.SelectedValue = v
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarPerfileria()
        Try
            If preferencia.DataSource Is Nothing Then
                Dim marticulos As New ClsArticulos
                Dim listArticulos As List(Of Articulo) = marticulos.TraerxFamiliayEstado(ClsEnums.FamiliasMateriales.PERFILERIA, ClsEnums.Estados.ACTIVO)
                listArticulos.Insert(0, New Articulo)
                Dim bsource As New BindingSource()
                bsource.DataSource = listArticulos
                preferencia.DisplayMember = "Referencia"
                preferencia.ValueMember = "Id"
                preferencia.DataSource = bsource
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarAccesorios()
        Try
            If areferencia.DataSource Is Nothing Then
                Dim marticulos As New ClsArticulos
                Dim listArticulos As List(Of Articulo) = marticulos.TraerxFamiliayEstado(ClsEnums.FamiliasMateriales.ACCESORIOS, ClsEnums.Estados.ACTIVO)
                listArticulos.Insert(0, New Articulo)
                Dim bsource As New BindingSource()
                bsource.DataSource = listArticulos
                areferencia.DisplayMember = "Referencia"
                areferencia.ValueMember = "Id"
                areferencia.DataSource = bsource
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarOtros()
        Try
            If oreferencia.DataSource Is Nothing Then
                Dim marticulos As New ClsArticulos
                Dim listArticulos As List(Of Articulo) = marticulos.TraerxFamiliayEstado(ClsEnums.FamiliasMateriales.OTROS, ClsEnums.Estados.ACTIVO)
                listArticulos.Insert(0, New Articulo)
                Dim bsource As New BindingSource()
                bsource.DataSource = listArticulos
                oreferencia.DisplayMember = "Referencia"
                oreferencia.ValueMember = "Id"
                oreferencia.DataSource = bsource
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarOrientacionyPosicionMateriales()
        Try
            Dim morienta As New ClsOrientacionPosicionMaterial
            Dim listaorienta As List(Of OrientacionPosicion) = morienta.Traerxestado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listaorienta
            vorientacion.DisplayMember = "Nombre"
            vorientacion.ValueMember = "Id"
            vorientacion.DataSource = bsource
            porientacion.DisplayMember = "Nombre"
            porientacion.ValueMember = "Id"
            porientacion.DataSource = bsource
            aorientacion.DisplayMember = "Nombre"
            aorientacion.ValueMember = "Id"
            aorientacion.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarUbicacionMateriales()
        Try
            Dim mubica As New ClsUbicacionMaterial
            Dim listaubica As List(Of UbicacionMaterial) = mubica.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listaubica
            pubicacion.DisplayMember = "Nombre"
            pubicacion.ValueMember = "Id"
            pubicacion.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarMaterialPara()
        Try
            Dim mmaterialpara As New ClsMaterialPara
            Dim listamaterialpara As List(Of MaterialPara) = mmaterialpara.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listamaterialpara
            vmaterialpara.DisplayMember = "Nombre"
            vmaterialpara.ValueMember = "Id"
            vmaterialpara.DataSource = bsource
            pmaterialpara.DisplayMember = "Nombre"
            pmaterialpara.ValueMember = "Id"
            pmaterialpara.DataSource = bsource
            amaterialpara.DisplayMember = "Nombre"
            amaterialpara.ValueMember = "Id"
            amaterialpara.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarTipoMaterial()
        Try
            Dim mtipomaterial As New ClsTiposMaterial
            Dim listatipomaterial As List(Of TipoMaterial) = mtipomaterial.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listatipomaterial
            vtipomaterial.DisplayMember = "Nombre"
            vtipomaterial.ValueMember = "Id"
            vtipomaterial.DataSource = bsource
            ptipomaterial.DisplayMember = "Nombre"
            ptipomaterial.ValueMember = "Id"
            ptipomaterial.DataSource = bsource
            atipomaterial.DisplayMember = "Nombre"
            atipomaterial.ValueMember = "Id"
            atipomaterial.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarTipoCortes()
        Try
            Dim mtipocorte As New ClsTiposCortes
            Dim listatipocorte As List(Of TipoCorte) = mtipocorte.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listatipocorte
            pcortes.DisplayMember = "Nombre"
            pcortes.ValueMember = "Id"
            pcortes.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarDescuentosG()
        Try
            Dim desc As New ClsDescuentos
            Dim listadescuento As List(Of ReglasNegocio.Descuento) = desc.TraerxEstado(ClsEnums.Estados.ACTIVO)
            Dim bsource As New BindingSource()
            bsource.DataSource = listadescuento
            descuentoG.ValueMember = "Id"
            descuentoG.DisplayMember = "Descuento"
            descuentoG.DataSource = bsource
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargar_variables()
        Try
            _variableoprod = New ClsVariablesPlantillaOrdenProd
            Dim lvars As List(Of VariableItemCotiza) = _variableoprod.TraerxIdItemOp(_idplantilloprod)
            Dim valvar As New ClsValoresVariables
            lvars.ForEach(Sub(v)
                              Dim r As DataGridViewRow = dwvariables.Rows(dwvariables.Rows.Add())
                              r.Cells(id.Index).Value = v.Id
                              r.Cells(idvariable.Index).Value = v.IdVariable
                              r.Cells(variable.Index).Value = v.NombreVariable
                              If v.DesdeBaseDatos Then
                                  Dim lvvar As List(Of ValorVariable) = valvar.TraerxIdVariable(v.IdVariable)
                                  r.Cells(valor.Index) = New DataGridViewComboBoxCell
                                  r.Cells(vminimo.Index) = New DataGridViewComboBoxCell
                                  r.Cells(vmaximo.Index) = New DataGridViewComboBoxCell
                                  Dim valores = lvvar.Select(Function(x) x.Valor).ToArray()
                                  DirectCast(r.Cells(valor.Index), DataGridViewComboBoxCell).Items.AddRange(valores)
                                  DirectCast(r.Cells(vminimo.Index), DataGridViewComboBoxCell).Items.AddRange(valores)
                                  DirectCast(r.Cells(vmaximo.Index), DataGridViewComboBoxCell).Items.AddRange(valores)
                                  r.Cells(valor.Index).Value = v.Valor
                                  If valores.Contains(v.ValorMinimo) Then
                                      r.Cells(vminimo.Index).Value = v.ValorMinimo
                                  End If
                                  If valores.Contains(v.ValorMaximo) Then
                                      r.Cells(vmaximo.Index).Value = v.ValorMaximo
                                  End If
                              Else
                                  r.Cells(valor.Index).Value = v.Valor
                                  r.Cells(vminimo.Index).Tag = v.Minimo
                                  r.Cells(vminimo.Index).Value = v.ValorMinimo
                                  r.Cells(vmaximo.Index).Tag = v.Maximo
                                  r.Cells(vmaximo.Index).Value = v.ValorMaximo
                              End If
                              r.Cells(tipodato.Index).Value = v.TipoDato
                          End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try

    End Sub
    Private Sub cargar_materiales()
        Try
            _materialoprod = New ClsMaterialesPlantillaOrdenProd
            Dim lmateriales As List(Of MaterialPlantillaMovimiento) = _materialoprod.TraerporIdHijoOp(_idplantilloprod)
            Dim r As DataGridViewRow
            lmateriales.ForEach(Sub(m)
                                    Select Case DirectCast(m.IdFamiliaMaterial, ClsEnums.FamiliasMateriales)
                                        Case ClsEnums.FamiliasMateriales.VIDRIO
#Region "vidrio"
                                            r = dwVidrios.Rows(dwVidrios.Rows.Add())
                                            r.Cells(vid.Index).Value = m.Id
                                            r.Cells(vreferencia.Index).Tag = m.Articulo
                                            r.Cells(vreferencia.Index).Value = m.Articulo_Valor
                                            r.Cells(vespesor.Index).Tag = m.Espesor
                                            r.Cells(vespesor.Index).Value = m.Espesor_Valor
                                            r.Cells(vacabado.Index).Tag = m.Acabado
                                            r.Cells(vacabado.Index).Value = m.Acabado_Valor
                                            r.Cells(vancho.Index).Tag = m.Ancho
                                            r.Cells(vancho.Index).Value = m.Ancho_Valor
                                            r.Cells(valto.Index).Tag = m.Alto
                                            r.Cells(valto.Index).Value = m.Alto_Valor
                                            r.Cells(vpeso.Index).Tag = m.peso
                                            r.Cells(vpeso.Index).Value = m.Peso_Valor
                                            r.Cells(vcantidad.Index).Tag = m.Cantidad
                                            r.Cells(vcantidad.Index).Value = m.Cantidad_Valor
                                            r.Cells(vpxuni.Index).Tag = m.PiezasxUnidad
                                            r.Cells(vpxuni.Index).Value = m.PiezasxUnidad_Valor
                                            r.Cells(vorientacion.Index).Value = m.IdOrientacionyPosicion
                                            r.Cells(vmaterialpara.Index).Value = m.IdMaterialPara
                                            r.Cells(vtipomaterial.Index).Value = m.IdTipoMaterial
                                            r.Cells(vdetalle.Index).Tag = m.Observaciones
                                            r.Cells(vdetalle.Index).Value = m.Observaciones_Valor.Replace("'", "")
                                            r.Cells(vvisibilidad.Index).Tag = m.Visibilidad
                                            r.Cells(vvisibilidad.Index).Value = Convert.ToInt32(m.Visibilidad_Valor)
#End Region
                                        Case ClsEnums.FamiliasMateriales.PERFILERIA
#Region "perfileria"
                                            r = dwPerfiles.Rows(dwPerfiles.Rows.Add())
                                            r.Cells(pid.Index).Value = m.Id
                                            r.Cells(preferencia.Index).Value = Convert.ToInt32(m.Articulo)
                                            r.Cells(pacabado.Index).Tag = m.Acabado
                                            r.Cells(pacabado.Index).Value = m.Acabado_Valor
                                            r.Cells(pdimension.Index).Tag = m.Ancho
                                            r.Cells(pdimension.Index).Value = m.Ancho_Valor
                                            r.Cells(ppeso.Index).Tag = m.peso
                                            r.Cells(ppeso.Index).Value = m.Peso_Valor
                                            r.Cells(pcantidad.Index).Tag = m.Cantidad
                                            r.Cells(pcantidad.Index).Value = m.Cantidad_Valor
                                            r.Cells(ppxuni.Index).Tag = m.PiezasxUnidad
                                            r.Cells(ppxuni.Index).Value = m.PiezasxUnidad_Valor
                                            r.Cells(porientacion.Index).Value = m.IdOrientacionyPosicion
                                            r.Cells(pubicacion.Index).Value = m.IdUbicacionMaterial
                                            r.Cells(pmaterialpara.Index).Value = m.IdMaterialPara
                                            r.Cells(ptipomaterial.Index).Value = m.IdTipoMaterial
                                            r.Cells(pcortes.Index).Value = m.IdTipoCortes
                                            r.Cells(pdetalle.Index).Tag = m.Observaciones
                                            r.Cells(pdetalle.Index).Value = m.Observaciones_Valor.Replace("'", "")
                                            r.Cells(pvisibilidad.Index).Tag = m.Visibilidad
                                            r.Cells(pvisibilidad.Index).Value = Convert.ToInt32(m.Visibilidad_Valor)
                                            r.Cells(pdescuento.Index).Value = m.Descuento
#End Region
                                        Case ClsEnums.FamiliasMateriales.ACCESORIOS
#Region "accesorio"
                                            r = dwAccesorios.Rows(dwAccesorios.Rows.Add())
                                            r.Cells(aid.Index).Value = m.Id
                                            r.Cells(areferencia.Index).Value = Convert.ToInt32(m.Articulo)
                                            r.Cells(aacabado.Index).Tag = m.Acabado
                                            r.Cells(aacabado.Index).Value = m.Acabado_Valor
                                            r.Cells(adimension.Index).Tag = m.Ancho
                                            r.Cells(adimension.Index).Value = m.Ancho_Valor
                                            r.Cells(acantidad.Index).Tag = m.Cantidad
                                            r.Cells(acantidad.Index).Value = m.Cantidad_Valor
                                            r.Cells(apxuni.Index).Tag = m.PiezasxUnidad
                                            r.Cells(apxuni.Index).Value = m.PiezasxUnidad_Valor
                                            r.Cells(aorientacion.Index).Value = m.IdOrientacionyPosicion
                                            r.Cells(amaterialpara.Index).Value = m.IdMaterialPara
                                            r.Cells(atipomaterial.Index).Value = m.IdTipoMaterial
                                            r.Cells(adetalle.Index).Tag = m.Observaciones
                                            r.Cells(adetalle.Index).Value = m.Observaciones_Valor.Replace("'", "")
                                            r.Cells(avisibilidad.Index).Tag = m.Visibilidad
                                            r.Cells(avisibilidad.Index).Value = Convert.ToInt32(m.Visibilidad_Valor)
                                            r.Cells(apeso.Index).Tag = m.peso
                                            r.Cells(apeso.Index).Value = m.Peso_Valor
#End Region
                                        Case ClsEnums.FamiliasMateriales.OTROS
#Region "otro"
                                            r = dwotros.Rows(dwotros.Rows.Add())
                                            r.Cells(oid.Index).Value = m.Id
                                            r.Cells(oreferencia.Index).Value = Convert.ToInt32(m.Articulo)
                                            r.Cells(oancho.Index).Tag = m.Ancho
                                            r.Cells(oancho.Index).Value = m.Ancho_Valor
                                            r.Cells(oalto.Index).Tag = m.Alto
                                            r.Cells(oalto.Index).Value = m.Alto_Valor
                                            r.Cells(ocantidad.Index).Tag = m.Cantidad
                                            r.Cells(ocantidad.Index).Value = m.Cantidad_Valor
                                            r.Cells(opxuni.Index).Tag = m.PiezasxUnidad
                                            r.Cells(opxuni.Index).Value = m.PiezasxUnidad_Valor
                                            r.Cells(odetalle.Index).Tag = m.Observaciones
                                            r.Cells(odetalle.Index).Value = m.Observaciones_Valor.Replace("'", "")
                                            r.Cells(ovisibilidad.Index).Tag = m.Visibilidad
                                            r.Cells(ovisibilidad.Index).Value = Convert.ToInt32(m.Visibilidad_Valor)
#End Region
                                    End Select

                                    Dim mdescuentosmaterial As New ClsDescuentosMaterialPlantillaOrdenProd
                                    Dim listadescuentos As List(Of DescuentoMaterial) = mdescuentosmaterial.TraerxIdMaterialHijoOp(m.Id)
                                    listadescuentos.ForEach(Sub(d)

                                                            End Sub)


                                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargar_descuentos()
        Try
            _descuentosglobalesoprod = New ClsDescuentosGeneralesPlantillaOrdenProd
            Dim listDescuentosGlobales As List(Of descuentoGlobal) = _descuentosglobalesoprod.TraerporIdHijoOP(_idplantilloprod)
            listDescuentosGlobales.ForEach(Sub(d)
                                               Dim r As DataGridViewRow = dwDescuentos.Rows(dwDescuentos.Rows.Add())
                                               r.Cells(idDescGlobal.Index).Value = d.Id
                                               r.Cells(usarG.Index).Value = True
                                               r.Cells(descuentoG.Index).Value = d.IdDescuento
                                               r.Cells(valorG.Index).Tag = d.Formula
                                               r.Cells(valorG.Index).Value = d.Valor
                                           End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarDibujos()
        Try
            _dibujosoprod = New ClsDibujosPlantillaOrdenProd
            Dim listdibujos As List(Of DibujoModelo) = _dibujosoprod.TraerporIdHijoOp(_idplantilloprod)
            listdibujos.ForEach(Sub(d)
                                    flpContenedordibujos.Controls.Add(NuevoDibujo(d.Id, d.Nombre, d.Predeterminado,
                                                                                  d.DXF, d.PlantillaVidrio))
                                End Sub
                )
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Function NuevoDibujo(iddibujo As Integer, nombre As String, predeterminado As String, dxf As String, plantillavidrio As Boolean) As Control
        Try
            Dim dibujoplantilla As New ControlesPersonalizados.DibujosPlantilla
            dibujoplantilla.AnalizadorSintactico = _analizador
            dibujoplantilla.Id = iddibujo
            dibujoplantilla.Nombre = nombre
            dibujoplantilla.Predeterminado = predeterminado
            dibujoplantilla.PlantillaVidrio = plantillavidrio
            dibujoplantilla.Size = New Size(500, 490)
            dibujoplantilla.LeerImagen(dxf)
            AddHandler dibujoplantilla.cancelar_Click, AddressOf btnQuitarDibujo
            Return dibujoplantilla
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Sub cargarObservaciones()
        Try
            _observacionesoprod = New ClsObservacionesPlantillaOrdenProd
            Dim listobserva As List(Of ObservacionPlantilla) = _observacionesoprod.TraerporIdHijoOP(_idplantilloprod)
            For Each observacion As ObservacionPlantilla In listobserva
                flpcontenedorobservaciones.Controls.Add(NuevaObservacion(observacion.Id, observacion.Observacion,
                                                                         observacion.Visibilidad))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Function NuevaObservacion(idobservacion As Integer, textoobservacion As String, imprimirobservacion As Boolean) As Control
        Try
            Dim obsplantilla As New ControlesPersonalizados.ObservacionesenPlantilla
            obsplantilla.Id = idobservacion
            obsplantilla.Observacion = textoobservacion
            obsplantilla.Imprimir = imprimirobservacion
            obsplantilla.Width = flpcontenedorobservaciones.Width
            AddHandler obsplantilla.cancelar_Click, AddressOf btnQuitarObservacion
            Return obsplantilla
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Sub material(rw As DataGridViewRow)
        Try
            Dim dw As DataGridView = rw.DataGridView
            Dim nombrematerial As String = dw.AccessibleName
            Dim ColumnastipoTexto() As String = New String() {"REFERENCIA", "DETALLE"}
            If _analizador.ListaMateriales.Contains(nombrematerial, rw.Index + 1) Then
                Dim materialcreado As Objeto = Analizador.ListaMateriales.Item(nombrematerial, rw.Index + 1)
                For Each c As DataGridViewColumn In dw.Columns
                    If Not TypeOf c Is DataGridViewButtonColumn And c.Visible Then
                        Dim tipov As TiposValores = TiposValores.Numerico
                        If ColumnastipoTexto.Contains(c.HeaderText) Then
                            tipov = TiposValores.Letras
                        End If
                        Dim variablematerial As Parametro = materialcreado.Parametros.Item(c.HeaderText)
                        variablematerial.Formula = Convert.ToString(rw.Cells(c.Index).Tag)
                        If TypeOf c Is DataGridViewComboBoxColumn Then
                            variablematerial.Valor = Convert.ToString(rw.Cells(c.Index).FormattedValue)
                        Else
                            variablematerial.Valor = Convert.ToString(rw.Cells(c.Index).Value)
                        End If
                        variablematerial.TipoValor = tipov
                    End If
                Next
            Else
                Dim nuevomaterial As New Objeto(nombrematerial, rw.Index + 1)
                Analizador.ListaMateriales.Add(nuevomaterial)
                If dw Is dwVidrios Then
                    nuevomaterial.TipoObjeto = TiposElementos.Vidrios
                ElseIf dw Is dwPerfiles Then
                    nuevomaterial.TipoObjeto = TiposElementos.Perfiles
                ElseIf dw Is dwAccesorios Then
                    nuevomaterial.TipoObjeto = TiposElementos.Accesorios
                End If
                For Each c As DataGridViewColumn In dw.Columns
                    If Not TypeOf c Is DataGridViewButtonColumn And c.Visible Then
                        Dim tipov As TiposValores = TiposValores.Numerico
                        If ColumnastipoTexto.Contains(c.HeaderText) Then
                            tipov = TiposValores.Letras
                        End If
                        If TypeOf c Is DataGridViewComboBoxColumn Then
                            nuevomaterial.Parametros.Add(New Parametro(c.Index, c.HeaderText, String.Empty,
                                                                Convert.ToString(rw.Cells(c.Index).FormattedValue), tipov))
                        Else
                            nuevomaterial.Parametros.Add(New Parametro(c.Index, c.HeaderText, Convert.ToString(rw.Cells(c.Name).Tag),
                                                                Convert.ToString(rw.Cells(c.Index).Value), tipov))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub descuento_global(r As DataGridViewRow)
        Try
            If r.Index > Analizador.ListaDescuentos.Count - 1 Then
                _analizador.ListaDescuentos.Add(New Formulador.Descuento(Convert.ToInt32(r.Cells(idDescGlobal.Index).Value),
                                                     Convert.ToInt32(r.Cells(descuentoG.Index).Value),
                                                     Convert.ToString(r.Cells(descuentoG.Index).FormattedValue),
                                                     Convert.ToString(r.Cells(valorG.Index).Value),
                                                     Convert.ToString(r.Cells(valorG.Index).Tag)))
            Else
                Dim desc As Formulador.Descuento = Analizador.ListaDescuentos.Item(r.Index)
                desc.IdDescuento = Convert.ToInt32(r.Cells(descuentoG.Index).Value)
                desc.Nombre = Convert.ToString(r.Cells(descuentoG.Index).FormattedValue)
                desc.Formula = Convert.ToString(r.Cells(valorG.Index).Tag)
                desc.Valor = Convert.ToString(r.Cells(valorG.Index).Value)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub variable_plantilla(r As DataGridViewRow)
        Try
            Dim valminimo As String = String.Empty
            Dim valmaximo As String = String.Empty
            Dim cformula As String = String.Empty
            Dim tdato As ClsEnums.TiposDato = Convert.ToInt32(r.Cells(tipodato.Index).Value)
            Select Case tdato
                    Case Is = ClsEnums.TiposDato.NUMERICO 'Numérico
                        valminimo = If(String.IsNullOrEmpty(r.Cells(vminimo.Index).Value), 0, r.Cells(vminimo.Index).Value)
                        valmaximo = If(String.IsNullOrEmpty(r.Cells(vmaximo.Index).Value), Int32.MaxValue, r.Cells(vmaximo.Index).Value)
                    Case Is = ClsEnums.TiposDato.TEXTO 'Texto
                        valminimo = r.Cells(vminimo.Index).Value.ToString()
                        valmaximo = r.Cells(vmaximo.Index).Value.ToString()
                    Case Is = ClsEnums.TiposDato.BOOLEANO 'Booleano
                        valminimo = 0
                        valmaximo = 1
                    Case Is = ClsEnums.TiposDato.FECHA 'Fecha
                        valminimo = If(String.IsNullOrEmpty(r.Cells(vminimo.Index).Value), Date.MinValue.ToString(), r.Cells(vminimo.Index).Value)
                        valmaximo = If(String.IsNullOrEmpty(r.Cells(vmaximo.Index).Value), Date.MaxValue.ToString(), r.Cells(vmaximo.Index).Value)
                End Select
            If _analizador.ListaVariables.Contains(r.Cells(variable.Index).Value.ToString()) Then
                Dim param As Parametro = _analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString())
                If TypeOf r.Cells(vminimo.Index) Is DataGridViewComboBoxCell Then
                    param.PosiblesValores.Clear()
                    param.PosiblesValores.AddRange(DirectCast(r.Cells(vminimo.Index), DataGridViewComboBoxCell).Items.Cast(Of String).ToArray())
                End If
                param.Restricciones.Clear()
                If Not String.IsNullOrEmpty(r.Cells(vminimo.Index).Value) Or Not String.IsNullOrEmpty(Convert.ToString(r.Cells(vminimo.Index).Tag)) Then
                    param.Restricciones.Add(New Restriccion("MINIMO", Convert.ToString(r.Cells(vminimo.Index).Tag), valminimo, tdato))
                End If
                If Not String.IsNullOrEmpty(r.Cells(vmaximo.Index).Value) Or Not String.IsNullOrEmpty(Convert.ToString(r.Cells(vmaximo.Index).Tag)) Then
                    param.Restricciones.Add(New Restriccion("MAXIMO", Convert.ToString(r.Cells(vmaximo.Index).Tag), valmaximo, tdato))
                End If
                param.TipoValor = tdato
                param.Valor = Convert.ToString(r.Cells(valor.Index).Value)
                param.Formula = String.Empty
                Analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString()) = param
            Else
                Dim param As New Parametro(r.Cells(variable.Index).Value.ToString(), String.Empty, Convert.ToString(r.Cells(valor.Index).Value), tdato)
                If TypeOf r.Cells(vminimo.Index) Is DataGridViewComboBoxCell Then
                    param.PosiblesValores.Clear()
                    param.PosiblesValores.AddRange(DirectCast(r.Cells(vminimo.Index), DataGridViewComboBoxCell).Items.Cast(Of String).ToArray())
                End If
                If Not String.IsNullOrEmpty(r.Cells(vminimo.Index).Value) Or Not String.IsNullOrEmpty(Convert.ToString(r.Cells(vminimo.Index).Tag)) Then
                    param.Restricciones.Add(New Restriccion("MINIMO", Convert.ToString(r.Cells(vminimo.Index).Tag), valminimo, tdato))
                End If
                If Not String.IsNullOrEmpty(r.Cells(vmaximo.Index).Value) Or Not String.IsNullOrEmpty(Convert.ToString(r.Cells(vmaximo.Index).Tag)) Then
                    param.Restricciones.Add(New Restriccion("MAXIMO", Convert.ToString(r.Cells(vmaximo.Index).Tag), valmaximo, tdato))
                End If
                _analizador.ListaVariables.Add(param)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub recalcular_valores()
        Try
            Dim cp As New CargasPlantilla
            cp.ValorarAnalizador(_analizador)
#Region "variables"
            For Each r As DataGridViewRow In dwvariables.Rows
                Dim v As Parametro = _analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString())
                If v.Restricciones.Contains("MINIMO") Then
                    If Not TypeOf r.Cells(vminimo.Index) Is DataGridViewComboBoxCell Then
                        r.Cells(vminimo.Index).Value = v.Restricciones.Item("MINIMO").Valor
                    End If
                End If
                If v.Restricciones.Contains("MAXIMO") Then
                    If Not TypeOf r.Cells(vminimo.Index) Is DataGridViewComboBoxCell Then
                        r.Cells(vmaximo.Index).Value = v.Restricciones.Item("MAXIMO").Valor
                    End If
                End If
            Next
#End Region
#Region "descuentos"
            For Each r As DataGridViewRow In dwDescuentos.Rows
                Dim desc As Formulador.Descuento = _analizador.ListaDescuentos.Item(Convert.ToString(r.Cells(descuentoG.Index).FormattedValue))
                r.Cells(valorG.Index).Value = desc.Valor
            Next
#End Region
#Region "materiales"
            _analizador.ListaMateriales.ToList().ForEach(Sub(o)
                                                             Dim rw As DataGridViewRow = Nothing
                                                             If o.Nombre = "VIDRIO" Then
                                                                 rw = dwVidrios.Rows(o.Indice - 1)
                                                             ElseIf o.Nombre = "PERFIL" Then
                                                                 rw = dwPerfiles.Rows(o.Indice - 1)
                                                             ElseIf o.Nombre = "ACCESORIOS" Then
                                                                 rw = dwAccesorios.Rows(o.Indice - 1)
                                                             Else
                                                                 rw = dwotros.Rows(o.Indice - 1)
                                                             End If
                                                             'Valoración Parámetros
                                                             For Each p As Parametro In o.Parametros
                                                                 Dim c As DataGridViewCell = rw.Cells.Cast(Of DataGridViewCell).FirstOrDefault(Function(x) x.OwningColumn.HeaderText = p.Nombre)
                                                                 If c IsNot Nothing Then
                                                                     If Not TypeOf c Is DataGridViewComboBoxCell Then
                                                                         c.Value = Replace(p.Valor, "'", String.Empty)
                                                                     End If
                                                                 End If
                                                             Next
                                                         End Sub
                                                         )
#End Region
            For Each c As ControlesPersonalizados.DibujosPlantilla In flpContenedordibujos.Controls
                c.AnalizadorSintactico = _analizador
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub modificar_descuentos_item()
        Try
            Dim r As DataGridViewRow = Nothing
            r = DirectCast(tcmateriales.SelectedTab.Controls(0), DataGridView).SelectedRows(0)
            Dim material As Objeto = Analizador.ListaMateriales.Item(r.DataGridView.AccessibleName, r.Index + 1)
            Dim frmdesc As New FrmDescuentosMaterial
            frmdesc.tipoDescuento = ClsEnums.tipoDescuento.DSCINDIVIDUAL
            frmdesc.Material = material
            frmdesc.Analizador = Analizador
            If frmdesc.ShowDialog() = DialogResult.OK Then
                material.Descuentos.Clear()
                For Each d As DescuentoMaterial In frmdesc.Descuentos
                    material.Descuentos.Add(New Formulador.Descuento(d.Id, d.IdDescuento,
                                                                     d.Descuento, d.Valor,
                                                                     String.Empty))
                Next
                recalcular_valores()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub duplicar()
        Try
            Dim r As DataGridViewRow = dwVidrios.SelectedRows(0)
            Dim rn As DataGridViewRow = dwVidrios.Rows(dwVidrios.Rows.Add())
            For i As Integer = 1 To dwVidrios.ColumnCount - 1
                If TypeOf dwVidrios.Columns(i) Is DataGridViewTextBoxColumn Then
                    rn.Cells(i).Value = r.Cells(i).Value
                    rn.Cells(i).Tag = r.Cells(i).Tag
                ElseIf TypeOf dwVidrios.Columns(i) Is DataGridViewComboBoxColumn Then
                    rn.Cells(i).Value = Convert.ToInt32(r.Cells(i).Value)
                End If
            Next
            material(rn)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub dw_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwDescuentos.CellEndEdit, dwVidrios.CellEndEdit, dwPerfiles.CellEndEdit, dwAccesorios.CellEndEdit, dwotros.CellEndEdit
        Try
            Dim dw As DataGridView = DirectCast(sender, DataGridView)
            If TypeOf dw.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn Then
                If Convert.ToString(dw.Item(e.ColumnIndex, e.RowIndex).Value).StartsWith("=") Then
                    Dim val As String = dw.Item(e.ColumnIndex, e.RowIndex).Tag
                    dw.Item(e.ColumnIndex, e.RowIndex).Tag = dw.Item(e.ColumnIndex, e.RowIndex).Value
                    dw.Item(e.ColumnIndex, e.RowIndex).Value = val
                ElseIf Not Convert.ToString(dw.Item(e.ColumnIndex, e.RowIndex).Value).StartsWith("=") Then
                    If Not Convert.ToString(dw.Item(e.ColumnIndex, e.RowIndex).Tag).StartsWith("=") Then
                        dw.Item(e.ColumnIndex, e.RowIndex).Tag = String.Empty
                    End If
                End If
            Else
                If dw Is dwPerfiles Then
                    If dw.Columns(e.ColumnIndex) Is preferencia Then
                        dw.Item(ppeso.Index, e.RowIndex).Tag = "=" & DirectCast(DirectCast(preferencia.DataSource, BindingSource).List, List(Of Articulo)).First(Function(x) x.Id = Convert.ToInt32(dw.Item(preferencia.Index, e.RowIndex).Value)).Peso
                    End If
                End If
                If dw Is dwAccesorios Then
                    If dw.Columns(e.ColumnIndex) Is areferencia Then
                        dw.Item(apeso.Index, e.RowIndex).Tag = "=" & DirectCast(DirectCast(areferencia.DataSource, BindingSource).List, List(Of Articulo)).First(Function(x) x.Id = Convert.ToInt32(dw.Item(areferencia.Index, e.RowIndex).Value)).Peso
                    End If
                End If
            End If
            If dw Is dwVidrios Or dw Is dwPerfiles Or dw Is dwAccesorios Or dw Is dwotros Then
                material(dw.Rows(e.RowIndex))
            ElseIf dw Is dwDescuentos Then
                descuento_global(dw.Rows(e.RowIndex))
            End If
            recalcular_valores()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub bwanalizador_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwanalizador.DoWork
        Try
            Dim cp As New CargasPlantilla
            cp.CargarPlantilla(_idplantilloprod, _analizador, ClsEnums.TipoCarga.ORDENPRODUCCION)
            cp.ValorarAnalizador(_analizador)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmEditorModelos_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If _idplantilloprod > 0 Then
                bwanalizador.RunWorkerAsync()
                cargarPerfileria()
                cargarAccesorios()
                cargarOtros()
                cargarOrientacionyPosicionMateriales()
                cargarUbicacionMateriales()
                cargarMaterialPara()
                cargarTipoMaterial()
                cargarTipoCortes()
                cargar_variables()
                cargarDescuentosG()
                cargar_materiales()
                cargarDibujos()
                cargarObservaciones()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tsagregardibujo_Click(sender As Object, e As EventArgs) Handles tsagregardibujo.Click
        Try
            flpContenedordibujos.Controls.Add(NuevoDibujo(0, String.Empty, 0, String.Empty, 0))
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnagregarobservacion_Click(sender As Object, e As EventArgs) Handles btnagregarobservacion.Click
        Try
            flpcontenedorobservaciones.Controls.Add(NuevaObservacion(0, String.Empty, 0))
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dwvariables.CellPainting, dwVidrios.CellPainting, dwPerfiles.CellPainting, dwAccesorios.CellPainting, dwDescuentos.CellPainting, dwotros.CellPainting
        Try
            If e.ColumnIndex < 0 And e.RowIndex >= 0 Then
                Dim sf As New StringFormat()
                sf.Alignment = StringAlignment.Center
                sf.LineAlignment = StringAlignment.Center
                e.PaintBackground(e.CellBounds, False)
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), Me.Font, New SolidBrush(Color.Black), e.CellBounds, sf)
                e.Handled = True
            ElseIf e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                Dim dw As DataGridView = DirectCast(sender, DataGridView)
                If dw.Columns(e.ColumnIndex) Is pcortes Then
                    e.Paint(e.ClipBounds, DataGridViewPaintParts.Background Or DataGridViewPaintParts.Border Or
                            DataGridViewPaintParts.ContentBackground)
                    Dim rect As Rectangle = e.CellBounds
                    rect.Width -= 20
                    If dw.Item(e.ColumnIndex, e.RowIndex).Value IsNot Nothing Then
                        Dim ltcorte As List(Of TipoCorte) = DirectCast(pcortes.DataSource, System.Windows.Forms.BindingSource).List
                        Dim tcorte As TipoCorte = ltcorte.Where(Function(x) x.Id = Convert.ToInt32(dw.Item(e.ColumnIndex, e.RowIndex).Value)).ToList()(0)
                        Dim utimagen As New ClsUtilidadesImagenes
                        Dim img As Image = utimagen.ArregloBytesaImagen(tcorte.Imagen)
                        e.Graphics.DrawImage(img, rect)
                    End If
                    e.Handled = True
                ElseIf TypeOf dw.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn Then
                    Dim c As DataGridViewCell = dw.Item(e.ColumnIndex, e.RowIndex)
                    If Not (String.IsNullOrEmpty(c.Tag)) Then
                        If Convert.ToString(c.Tag).StartsWith("=") Then
                            Dim r As Rectangle = e.CellBounds
                            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                            e.Graphics.DrawImage(My.Resources.Fx8x8, New Rectangle(New Point(r.X + r.Width - 10, r.Y + 2), New Size(10, 10)))
                            e.Handled = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dwPerfiles.EditingControlShowing, dwAccesorios.EditingControlShowing, dwVidrios.EditingControlShowing, dwDescuentos.EditingControlShowing, dwotros.EditingControlShowing
        Try
            Dim dw As DataGridView = DirectCast(sender, DataGridView)
            If TypeOf e.Control Is TextBox Then
                RemoveHandler e.Control.KeyDown, AddressOf EditControlcell_KeyDown
                AddHandler e.Control.KeyDown, AddressOf EditControlcell_KeyDown
            ElseIf TypeOf e.Control Is ComboBox Then
                Dim cmb As ComboBox = DirectCast(e.Control, ComboBox)
                If TypeOf DirectCast(cmb.DataSource, System.Windows.Forms.BindingSource).List Is List(Of TipoCorte) Then
                    cmb.DrawMode = DrawMode.OwnerDrawVariable
                    cmb.DropDownHeight = 160
                    RemoveHandler cmb.MeasureItem, AddressOf measureitem_combo
                    RemoveHandler cmb.DrawItem, AddressOf comboCortex_customDraw
                    AddHandler cmb.MeasureItem, AddressOf measureitem_combo
                    AddHandler cmb.DrawItem, AddressOf comboCortex_customDraw
                Else
                    cmb.DrawMode = DrawMode.Normal
                    If cmb.Items.Count > 30 Then
                        cmb.DropDownHeight = 30 * cmb.ItemHeight
                    Else
                        cmb.DropDownHeight = cmb.Items.Count * (cmb.ItemHeight + 1)
                    End If
                    RemoveHandler cmb.MeasureItem, AddressOf measureitem_combo
                    RemoveHandler cmb.DrawItem, AddressOf comboCortex_customDraw
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub measureitem_combo(sender As Object, e As MeasureItemEventArgs)
        Try
            e.ItemHeight = 30
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub comboCortex_customDraw(ByVal sender As Object, ByVal e As DrawItemEventArgs)
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
    Private Sub dw_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwVidrios.CellBeginEdit, dwPerfiles.CellBeginEdit, dwAccesorios.CellBeginEdit, dwotros.CellBeginEdit, dwDescuentos.CellBeginEdit
        Try
            Dim dw As DataGridView = DirectCast(sender, DataGridView)
            If TypeOf dw.Columns(e.ColumnIndex) Is DataGridViewTextBoxColumn Then
                If Not String.IsNullOrEmpty(Convert.ToString(dw.Item(e.ColumnIndex, e.RowIndex).Tag)) Then
                    Dim val As String = Convert.ToString(dw.Item(e.ColumnIndex, e.RowIndex).Value)
                    dw.Item(e.ColumnIndex, e.RowIndex).Value = dw.Item(e.ColumnIndex, e.RowIndex).Tag
                    dw.Item(e.ColumnIndex, e.RowIndex).Tag = val
                End If
            ElseIf TypeOf dw.Columns(e.ColumnIndex) Is DataGridViewComboBoxColumn Then
                If dw Is dwDescuentos And e.ColumnIndex = descuentoG.Index Then
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub EditControlcell_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            Dim txt As TextBox = DirectCast(sender, TextBox)
            Dim dw As DataGridView = DirectCast(txt, DataGridViewTextBoxEditingControl).EditingControlDataGridView
            Dim ccell As DataGridViewCell = dw.CurrentCell
            If e.KeyCode = Keys.D0 And e.Shift Then
                'If txt.Text.StartsWith("=") Then
                Dim formu As New Formularios_Ayuda.FrmFormuladorMin
                formu.FormBorderStyle = FormBorderStyle.None
                formu.StartPosition = FormStartPosition.Manual
                formu.Analizador = Analizador
                If Convert.ToString(ccell.Value).StartsWith("=") Then
                    formu.Formula = Convert.ToString(ccell.Value).Substring(1)
                Else
                    formu.Formula = Convert.ToString(ccell.Value)
                    formu.SeleccionInicial = True
                End If
                Dim r As Rectangle = dw.GetCellDisplayRectangle(ccell.ColumnIndex, ccell.RowIndex, True)
                Dim pt As Point = PointToScreen(r.Location)

                Dim agregado As Integer = 0
                If ccell.DataGridView Is dwDescuentos Then
                    agregado = -25
                End If
                If ccell.DataGridView Is dwDescuentos Then
                    pt = New Point(pt.X + dw.RowHeadersWidth + agregado,
                    pt.Y + tcextras.Location.Y + 12 +
                    dw.ColumnHeadersHeight + (ccell.OwningRow.Height * 2))
                Else
                    pt = New Point(pt.X + dw.RowHeadersWidth + agregado,
                    pt.Y + tcextras.Location.Y + tcmateriales.Location.Y +
                    dw.ColumnHeadersHeight + (ccell.OwningRow.Height * 2))
                End If
                If pt.Y + formu.Height > (Me.Location.Y + Me.Height) Then
                    pt.Y -= (dw.ColumnHeadersHeight + formu.Height)
                End If

                formu.Location = pt
                If formu.ShowDialog() = DialogResult.OK Then
                    'dw.CancelEdit()
                    If (String.IsNullOrEmpty(formu.Formula)) Or IsNumeric(formu.Formula) Then
                        ccell.Value = formu.Valor
                        ccell.Tag = String.Empty
                        txt.Text = formu.Valor
                        txt.Tag = String.Empty
                    Else
                        ccell.Value = formu.Valor
                        ccell.Tag = "=" & formu.Formula
                        txt.Text = formu.Valor
                        txt.Tag = "=" & formu.Formula
                    End If
                Else
                    Dim formula As String = Convert.ToString(ccell.Value)
                    If formula.StartsWith("=") Then
                        ccell.Value = Convert.ToString(ccell.Tag)
                        ccell.Tag = formula
                        txt.Text = Convert.ToString(ccell.Tag)
                        txt.Tag = formula
                    End If
                End If
                dw.EndEdit()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dwVidrios.CellClick, dwPerfiles.CellClick, dwAccesorios.CellClick, dwvariables.CellClick, dwDescuentos.CellClick, dwotros.CellClick
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                Dim dw As DataGridView = DirectCast(sender, DataGridView)
                If TypeOf dw.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                    Dim ncolumn As String = DirectCast(dw.Columns(e.ColumnIndex), DataGridViewButtonColumn).Text
                    Dim formu As New Formulador.Formularios_Ayuda.FrmFormulador
                    Select Case dw.AccessibleName
                        Case = "VIDRIO"
                            formu.Text = formu.Text & " " & DirectCast(dw.Rows(e.RowIndex).Cells(vorientacion.Index), DataGridViewComboBoxCell).FormattedValue.ToString & "(" & e.RowIndex + 1 & ")"
                        Case Is = "PERFIL", "ACCESORIOS", "OTROS"
                            formu.Text = formu.Text & " " & DirectCast(dw.Rows(e.RowIndex).Cells(1), DataGridViewComboBoxCell).FormattedValue.ToString & "(" & e.RowIndex + 1 & ")"
                        Case Else
                            formu.Text = formu.Text
                    End Select
                    formu.Analizador = Analizador
                    If Not String.IsNullOrEmpty(dw.Item(ncolumn, e.RowIndex).Tag) Then
                        Dim frm As String = Convert.ToString(dw.Item(ncolumn, e.RowIndex).Tag)
                        formu.Formula = frm.Substring(1, frm.Length - 1)
                    Else
                        formu.Formula = Convert.ToString(dw.Item(ncolumn, e.RowIndex).Value)
                    End If
                    If formu.ShowDialog() = DialogResult.OK Then
                        If (String.IsNullOrEmpty(formu.Formula)) Or IsNumeric(formu.Formula) Then
                            dw.Item(ncolumn, e.RowIndex).Tag = String.Empty
                            dw.Item(ncolumn, e.RowIndex).Value = formu.Valor
                        Else
                            dw.Item(ncolumn, e.RowIndex).Tag = "=" + formu.Formula
                            dw.Item(ncolumn, e.RowIndex).Value = Analizador.EjecutarExpresion(formu.Formula)
                        End If

                        If dw Is dwVidrios Or dw Is dwPerfiles Or dw Is dwAccesorios Or dw Is dwotros Then
                            'VerificaryCrearMaterial(dw.Rows(e.RowIndex), Nothing)
                        ElseIf dw Is dwvariables Then
                            'RevisaryCrearVariableGeneral(dw.Rows(e.RowIndex))
                        ElseIf dw Is dwDescuentos Then
                            'verificaryCrearDescuentoG(dw.Rows(e.RowIndex))
                        End If
                        'RecalcularValores()
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmEditorModelos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarTiposModelo()
            cargarClasificacionModelo()
            cargarFamiliasModelo()
            cargarConfiguraciones()
            cargarCaracteristicasAdicionales()
            Dim plantilla As New ClsPlantillaOrdenProd
            Dim p = plantilla.TraerporIdOrdenProd(_idplantilloprod)
            cbtipomodelo.SelectedValue = p.IdTipoModelo
            cbclasificacionmodelo.SelectedValue = p.IdClasificacionoModelo
            cbfamiliamodelo.SelectedValue = p.IdFamiliaModelo
            cbconfiguracionmodelo.SelectedValue = p.IdConfiguracion
            cbcaracteristicasadicionales.SelectedValue = p.IdCaracteristicaAdicional
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cbNombre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbtipomodelo.SelectedIndexChanged, cbfamiliamodelo.SelectedIndexChanged, cbconfiguracionmodelo.SelectedIndexChanged, cbclasificacionmodelo.SelectedIndexChanged, cbcaracteristicasadicionales.SelectedIndexChanged
        Try
            Dim cbox As ComboBox = DirectCast(sender, ComboBox)
            If IsNothing(cbox.SelectedItem) Then
                MsgBox("El ítem " & cbox.Text & ", no pertenece a la lista de elementos posibles. Verifique la información", MsgBoxStyle.Critical)
                cbox.SelectedIndex = 0
                Return
            End If
            If Not (IsNothing(cbtipomodelo.DataSource) Or IsNothing(cbfamiliamodelo.DataSource) Or IsNothing(cbconfiguracionmodelo.DataSource) Or IsNothing(cbclasificacionmodelo.DataSource) Or IsNothing(cbcaracteristicasadicionales.DataSource)) Then
                Dim carAdd As String = String.Empty
                Dim carAddes As String = String.Empty
                If Not IsNothing(cbcaracteristicasadicionales.SelectedItem) Then
                    carAdd = DirectCast(cbcaracteristicasadicionales.SelectedItem, CaracteristicaAdicional).Prefijo
                    carAddes = DirectCast(cbcaracteristicasadicionales.SelectedItem, CaracteristicaAdicional).Descripcion
                Else
                    carAdd = DirectCast(cbcaracteristicasadicionales.Items(0), CaracteristicaAdicional).Prefijo
                    carAddes = DirectCast(cbcaracteristicasadicionales.Items(0), CaracteristicaAdicional).Descripcion
                End If
                lbnombre.Text = DirectCast(cbtipomodelo.SelectedItem, TipoModelo).Prefijo &
                    DirectCast(cbclasificacionmodelo.SelectedItem, ClasificacionModelo).Prefijo & "-" &
                    DirectCast(cbfamiliamodelo.SelectedItem, FamiliaModelo).Prefijo & "-" &
                    DirectCast(cbconfiguracionmodelo.SelectedItem, Configuracion).Configuracion & " " &
                    If(String.IsNullOrEmpty(carAdd) Or carAdd.Equals("--"), String.Empty, "-" & carAdd)

                lbdescripcion.Text = DirectCast(cbtipomodelo.SelectedItem, TipoModelo).Tipo & " " &
                    DirectCast(cbclasificacionmodelo.SelectedItem, ClasificacionModelo).Clasificacion & "  " &
                    DirectCast(cbfamiliamodelo.SelectedItem, FamiliaModelo).Familia & "  " &
                    DirectCast(cbconfiguracionmodelo.SelectedItem, Configuracion).Configuracion &
                    If(String.IsNullOrEmpty(carAddes) Or carAddes.Equals("--"), String.Empty, "  " & carAddes)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnQuitarDibujo(sender As Object, e As EventArgs)
        Try
            Dim mdibuj As ControlesPersonalizados.DibujosPlantilla = DirectCast(sender, ControlesPersonalizados.DibujosPlantilla)
            If MsgBox("¿Esta seguro que desea eliminar el dibujo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If mdibuj.Id > 0 Then
                    _dibujosoprod.EliminarxId(mdibuj.Id)
                End If
                flpContenedordibujos.Controls.Remove(mdibuj)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnQuitarObservacion(sender As Object, e As EventArgs)
        Try
            Dim mobserv As ControlesPersonalizados.ObservacionesenPlantilla = DirectCast(sender, ControlesPersonalizados.ObservacionesenPlantilla)
            If MsgBox("¿Esta seguro que desea eliminar la observación?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If mobserv.Id > 0 Then
                    'PENDIENTE ELIMINACION
                    _observacionesoprod.EliminarxId(mobserv.Id)
                End If
                flpcontenedorobservaciones.Controls.Remove(mobserv)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwvariables_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwvariables.CellEndEdit
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwvariables.Rows(e.RowIndex)
                Dim v As Parametro = _analizador.ListaVariables.Item(Convert.ToString(r.Cells(variable.Index).Value))
                Select Case e.ColumnIndex
                    Case vminimo.Index
                        If v.Restricciones.Contains("MINIMO") Then
                            If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(vminimo.Index).Value).Trim()) Then
                                v.Restricciones.Item("MINIMO").Formula = Convert.ToString(r.Cells(vminimo.Index).Tag)
                                v.Restricciones.Item("MINIMO").Valor = Convert.ToString(r.Cells(vminimo.Index).Value)
                            Else
                                v.Restricciones.Remove(v.Restricciones.Item("MINIMO"))
                            End If
                        Else
                            If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(vminimo.Index).Value).Trim()) Then
                                v.Restricciones.Add(New Restriccion("MINIMO", Convert.ToString(r.Cells(vminimo.Index).Tag),
                                                                Convert.ToString(r.Cells(vminimo.Index).Value), Convert.ToInt32(r.Cells(tipodato.Index).Value)))
                            End If
                        End If
                    Case vmaximo.Index
                        If v.Restricciones.Contains("MAXIMO") Then
                            If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(vmaximo.Index).Value).Trim()) Then
                                v.Restricciones.Item("MAXIMO").Formula = Convert.ToString(r.Cells(vmaximo.Index).Tag)
                                v.Restricciones.Item("MAXIMO").Valor = Convert.ToString(r.Cells(vmaximo.Index).Value)
                            Else
                                v.Restricciones.Remove(v.Restricciones.Item("MAXIMO"))
                            End If
                        Else
                            If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(vmaximo.Index).Value).Trim()) Then
                                v.Restricciones.Add(New Restriccion("MAXIMO", Convert.ToString(r.Cells(vmaximo.Index).Tag),
                                                                Convert.ToString(r.Cells(vmaximo.Index).Value), Convert.ToInt32(r.Cells(tipodato.Index).Value)))
                            End If
                        End If
                End Select
                Select Case DirectCast(r.Cells(tipodato.Index).Value, ClsEnums.TiposDato)
                    Case ClsEnums.TiposDato.NUMERICO
                        If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(vmaximo.Index).Value)) Then
                            If Convert.ToDecimal(r.Cells(valor.Index).Value) > Convert.ToDecimal(r.Cells(vmaximo.Index).Value) Then
                                r.Cells(valor.Index).Value = r.Cells(vmaximo.Index).Value
                            End If
                        End If
                        If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(vminimo.Index).Value)) Then
                            If Convert.ToDecimal(r.Cells(valor.Index).Value) < Convert.ToDecimal(r.Cells(vminimo.Index).Value) Then
                                r.Cells(valor.Index).Value = r.Cells(vminimo.Index).Value
                            End If
                        End If
                    Case ClsEnums.TiposDato.TEXTO
                        If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(vminimo.Index).Value)) And Not String.IsNullOrEmpty(Convert.ToString(r.Cells(vmaximo.Index).Value)) Then
                            If Convert.ToString(r.Cells(valor.Index).Value) <> Convert.ToString(r.Cells(vminimo.Index).Value) And Convert.ToString(r.Cells(valor.Index).Value) <> Convert.ToString(r.Cells(vmaximo.Index).Value) Then
                                r.Cells(valor.Index).Value = r.Cells(vminimo.Index).Value
                            End If
                        End If
                End Select
                v.Valor = r.Cells(valor.Index).Value
                recalcular_valores()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tsmiPerfil_Click(sender As Object, e As EventArgs) Handles tsmiPerfil.Click
        Try
            Dim r As DataGridViewRow = dwPerfiles.Rows(dwPerfiles.Rows.Add())
            r.Cells(pdimension.Index).Value = 0
            r.Cells(pcantidad.Index).Value = 0
            r.Cells(pdescuento.Index).Value = 0
            r.Cells(pdetalle.Index).Value = String.Empty
            material(r)
            tcmateriales.SelectedIndex = tpperfileria.TabIndex
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tsmiAccesorio_Click(sender As Object, e As EventArgs) Handles tsmiAccesorio.Click
        Try
            tcmateriales.SelectedIndex = tpaccesorios.TabIndex
            Dim r As DataGridViewRow = dwAccesorios.Rows(dwAccesorios.Rows.Add())
            r.Cells(adimension.Index).Value = 0
            r.Cells(acantidad.Index).Value = 0
            r.Cells(adetalle.Index).Value = String.Empty
            material(r)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tsmiotros_Click(sender As Object, e As EventArgs) Handles tsmiotros.Click
        Try
            tcmateriales.SelectedIndex = tpotros.TabIndex
            Dim r As DataGridViewRow = dwotros.Rows(dwotros.Rows.Add())
            r.Cells(oalto.Index).Value = 0
            r.Cells(oancho.Index).Value = 0
            r.Cells(ocantidad.Index).Value = 0
            r.Cells(ovisibilidad.Index).Value = 0
            r.Cells(odetalle.Index).Value = String.Empty
            material(r)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnagregardescuento_Click(sender As Object, e As EventArgs) Handles btnagregardescuento.Click
        Try
            Dim r As DataGridViewRow = dwDescuentos.Rows(dwDescuentos.Rows.Add())
            r.Cells(id.Index).Value = 0
            r.Cells(valorG.Index).Value = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwPerfiles.CellMouseUp, dwAccesorios.CellMouseUp, dwotros.CellMouseUp
        Try
            Dim dw As DataGridView = DirectCast(sender, DataGridView)
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 And e.Button = MouseButtons.Right Then
                Dim menu As New ContextMenuStrip
                If dw.SelectedRows.Count <= 1 Then
                    dw.Rows(e.RowIndex).Selected = True
                    menu.Items.Add("Modificar Descuentos", Nothing, AddressOf modificar_descuentos_item)
                End If
                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwVidrios_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwVidrios.CellMouseUp
        Try
            Dim dw As DataGridView = DirectCast(sender, DataGridView)
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 And e.Button = MouseButtons.Right Then
                Dim menu As New ContextMenuStrip
                If dw.SelectedRows.Count <= 1 Then
                    dw.Rows(e.RowIndex).Selected = True
                    menu.Items.Add("Modificar Descuentos", Nothing, AddressOf modificar_descuentos_item)
                    menu.Items.Add("Duplicar", Nothing, AddressOf duplicar)
                End If
                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dwVidrios.UserDeletingRow, dwPerfiles.UserDeletingRow, dwAccesorios.UserDeletingRow, dwDescuentos.UserDeletingRow, dwotros.UserDeletingRow
        Try
            If e.Row.Index >= 0 Then
                If MsgBox("¿Esta seguro que quiere eliminar la fila: " & (e.Row.Index + 1).ToString() & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim dw As DataGridView = DirectCast(sender, DataGridView)
                    If dw Is dwDescuentos Then
                        If Convert.ToInt32(e.Row.Cells(idDescGlobal.Index).Value) > 0 Then
                            Dim desc As New ClsDescuentosGlobales
                            desc.EliminarxId(Convert.ToInt32(e.Row.Cells(idDescGlobal.Index).Value))
                        End If
                        If Convert.ToInt32(e.Row.Cells(descuentoG.Index).Value) > 0 Then
                            Dim d As Formulador.Descuento = Analizador.ListaDescuentos.Item(Convert.ToString(e.Row.Cells(descuentoG.Index).FormattedValue))
                            Analizador.ListaDescuentos.Remove(d)
                        End If
                    Else
                        Dim mmaterial As Objeto = Analizador.ListaMateriales.Item(dw.AccessibleName, e.Row.Index + 1)
                        If Not _analizador.VerificarDependenciasConObjeto(mmaterial) Then
                            _analizador.ListaMateriales.Remove(mmaterial)
                        Else
                            MsgBox("Hay formulas que dependen de este elemento, no se puede ejecutar la acción. Verifique la información", MsgBoxStyle.Critical)
                            e.Cancel = True
                        End If
                    End If
                Else
                    e.Cancel = True
                End If
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            e.Cancel = True
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnagregarvariable_Click(sender As Object, e As EventArgs) Handles btnagregarvariable.Click
        Try
            Dim fagvar As New Frmagregarvariables
            If fagvar.ShowDialog() = DialogResult.OK Then
                Dim valvar As New ClsValoresVariables
                fagvar.Variables_Seleccionadas().ForEach(Sub(v)
                                                             If dwvariables.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) Convert.ToString(x.Cells(variable.Index).Value).Equals(v.Nombre)) Is Nothing Then
                                                                 Dim r As DataGridViewRow = dwvariables.Rows(dwvariables.Rows.Add())
                                                                 r.Cells(idvariable.Index).Value = v.Id
                                                                 r.Cells(variable.Index).Value = v.Nombre
                                                                 If v.ValoresDesdeBasedeDatos Then
                                                                     Dim lvvar As List(Of ValorVariable) = valvar.TraerxIdVariable(v.Id)
                                                                     r.Cells(valor.Index) = New DataGridViewComboBoxCell
                                                                     r.Cells(vminimo.Index) = New DataGridViewComboBoxCell
                                                                     r.Cells(vmaximo.Index) = New DataGridViewComboBoxCell
                                                                     Dim valores = lvvar.Select(Function(x) x.Valor).ToArray()
                                                                     DirectCast(r.Cells(valor.Index), DataGridViewComboBoxCell).Items.AddRange(valores)
                                                                     DirectCast(r.Cells(vminimo.Index), DataGridViewComboBoxCell).Items.AddRange(valores)
                                                                     DirectCast(r.Cells(vmaximo.Index), DataGridViewComboBoxCell).Items.AddRange(valores)
                                                                 End If
                                                                 r.Cells(tipodato.Index).Value = v.IdTipoDato
                                                                 variable_plantilla(r)
                                                             End If
                                                         End Sub)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwvariables_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dwvariables.UserDeletingRow
        Try
            If e.Row.Index >= 0 Then
                If MsgBox("¿Esta seguro que quiere eliminar la fila: " & (e.Row.Index + 1).ToString() & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim dw As DataGridView = DirectCast(sender, DataGridView)
                    Dim p = _analizador.ListaVariables.Item(Convert.ToString(e.Row.Cells(variable.Index).Value))
                    If _analizador.VerificarDependenciasConRestriccion(p) Then
                        MsgBox("Uno o mas elementos dependen de esta variable. No se puede ejecutar la acción", MsgBoxStyle.Information)
                        e.Cancel = True
                    Else
                        _analizador.ListaVariables.Remove(p)
                    End If
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            DialogResult = DialogResult.OK
            Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class