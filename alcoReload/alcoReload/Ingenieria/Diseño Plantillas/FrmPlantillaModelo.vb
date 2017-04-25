Imports ReglasNegocio
Imports Formulador
Public Class FrmPlantillaModelo

#Region "Variables"
    Private mplantmodelo As ClsPlantillasModelos
    Private mvarplantilla As ClsVariablesPlantillas
    Private mobservaplantilla As ClsObservacionesPlantilla
    Private mdibujoplantilla As ClsDibujosModelo
    Private mmaterialesplantilla As ClsMaterialesPlantilla
    Private mdescuentosmaterial As ClsDescuentosMaterial
    Private mdescuentosGlobales As ClsDescuentosGlobales
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private curid As Integer = 0
    Private analizador As AnalizadorLexico
    Private listadescuentos As List(Of ReglasNegocio.Descuento)
    Private duplicada As Boolean = False
#Region "ListasParaFiltrar"
    Dim f_listaVariables As List(Of Variables)
#End Region
#End Region

#Region "Propiedades"

    Public Property IdActual As Integer
        Get
            Return curid
        End Get
        Set(value As Integer)
            curid = value
        End Set
    End Property

    Public Property OperacionActual As ClsEnums.TiOperacion
        Get
            Return tform
        End Get
        Set(value As ClsEnums.TiOperacion)
            tform = value
        End Set
    End Property

    Public Property DuplicarPlantilla As Boolean
        Get
            Return duplicada
        End Get
        Set(value As Boolean)
            duplicada = value
        End Set
    End Property

#End Region

#Region "Procedimientos"
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
    Private Sub cargarVariables()
        Try
            Dim variab As New ClsVariables
            Dim mlista As List(Of Variables) = Nothing
            If f_listaVariables Is Nothing Then
                f_listaVariables = variab.TraerxEstado(ClsEnums.Estados.ACTIVO)
                mlista = f_listaVariables
            Else
                mlista = variab.TraerxEstado(ClsEnums.Estados.ACTIVO)
                Dim l As New List(Of Integer)
                For i = 0 To f_listaVariables.Count - 1
                    l.Add(f_listaVariables(i).Id)
                Next
                mlista = mlista.Where(Function(x) Not l.Contains(x.Id)).ToList()
                f_listaVariables.AddRange(mlista)
            End If
            Dim valvar As New ClsValoresVariables
            For Each v As Variables In mlista
                Dim r As DataGridViewRow = dwvariables.Rows(dwvariables.Rows.Add())
                If v.ValoresDesdeBasedeDatos Then
                    Dim lvar() As String = valvar.TraerxIdVariable(v.Id).Select(Function(x) x.Valor).ToArray()
                    r.Cells(vmaximo.Index) = New DataGridViewComboBoxCell()
                    DirectCast(r.Cells(vmaximo.Index), DataGridViewComboBoxCell).Items.AddRange(lvar)
                    r.Cells(vminimo.Index) = New DataGridViewComboBoxCell()
                    DirectCast(r.Cells(vminimo.Index), DataGridViewComboBoxCell).Items.AddRange(lvar)
                End If
                r.Cells(id.Index).Value = String.Empty
                r.Cells(idvariable.Index).Value = v.Id
                r.Cells(variable.Index).Value = v.Nombre
                r.Cells("vmaximo").Value = String.Empty
                r.Cells("vminimo").Value = String.Empty
                r.Cells(tipodato.Index).Value = v.IdTipoDato
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    r.Cells(usar.Index).Value = v.UsoPredeterminado
                End If
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
    Private Function NuevoDibujo(iddibujo As Integer, nombre As String, predeterminado As String, dxf As String, plantillavidrio As Boolean) As Control
        Try
            Dim dibujoplantilla As New ControlesPersonalizados.DibujosPlantilla
            dibujoplantilla.AnalizadorSintactico = Me.analizador
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
    Private Sub RevisaryCrearVariableGeneral(r As DataGridViewRow)
        Try
            Dim valorvaria As String = String.Empty
            Dim valminimo As String = String.Empty
            Dim valmaximo As String = String.Empty
            Dim cformula As String = String.Empty
            Dim tdato As ClsEnums.TiposDato = Convert.ToInt32(r.Cells(tipodato.Index).Value)
            If Convert.ToBoolean(r.Cells(usar.Index).Value) Then
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
                valorvaria = valminimo
                If analizador.ListaVariables.Contains(r.Cells(variable.Index).Value.ToString()) Then
                    Dim param As Parametro = analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString())
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
                    param.Valor = valorvaria
                    param.Formula = valorvaria
                    analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString()) = param
                Else
                    Dim param As New Parametro(r.Cells(variable.Index).Value.ToString(), valorvaria, valorvaria, tdato)
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
                    analizador.ListaVariables.Add(param)
                End If
            Else
                If analizador.ListaVariables.Contains(r.Cells(variable.Index).Value.ToString()) Then
                    analizador.ListaVariables.Remove(analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString()))
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub verificaryCrearDescuentoG(r As DataGridViewRow)
        Try
            If r.Index > analizador.ListaDescuentos.Count - 1 Then
                analizador.ListaDescuentos.Add(New Formulador.Descuento(Convert.ToInt32(r.Cells(idDescGlobal.Index).Value),
                                                     Convert.ToInt32(r.Cells(descuentoG.Index).Value),
                                                     Convert.ToString(r.Cells(descuentoG.Index).FormattedValue),
                                                     Convert.ToString(r.Cells(valorG.Index).Value),
                                                     Convert.ToString(r.Cells(valorG.Index).Tag)))
            Else
                Dim desc As Formulador.Descuento = analizador.ListaDescuentos.Item(r.Index)
                desc.IdDescuento = Convert.ToInt32(r.Cells(descuentoG.Index).Value)
                desc.Nombre = Convert.ToString(r.Cells(descuentoG.Index).FormattedValue)
                desc.Formula = Convert.ToString(r.Cells(valorG.Index).Tag)
                desc.Valor = Convert.ToString(r.Cells(valorG.Index).Value)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub VerificaryCrearMaterial(rw As DataGridViewRow, listadescuentos As List(Of DescuentoMaterial))
        Try
            Dim dw As DataGridView = rw.DataGridView
            Dim nombrematerial As String = dw.AccessibleName
            Dim ColumnastipoTexto() As String = New String() {"REFERENCIA", "DETALLE"}
            If analizador.ListaMateriales.Contains(nombrematerial, rw.Index + 1) Then
                Dim materialcreado As Objeto = analizador.ListaMateriales.Item(nombrematerial, rw.Index + 1)
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
                If listadescuentos IsNot Nothing Then
                    CrearDescuentosMaterial(materialcreado, listadescuentos)
                End If
            Else
                Dim nuevomaterial As New Objeto(nombrematerial, rw.Index + 1)
                analizador.ListaMateriales.Add(nuevomaterial)
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
                If listadescuentos IsNot Nothing Then
                    CrearDescuentosMaterial(nuevomaterial, listadescuentos)
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub CrearDescuentosMaterial(material As Objeto, listadescuentos As List(Of DescuentoMaterial))
        Try
            material.Descuentos.Clear()
            For Each d In listadescuentos
                If Not (material.Descuentos.Contains(d.Descuento)) Then
                    material.Descuentos.Add(New Formulador.Descuento(d.Id, d.IdDescuento,
                                                                     d.Descuento,
                                                                     d.Valor, d.Formula))
                End If
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub RecalculoFormulas(dw As DataGridView)
        Try
            For Each fila As DataGridViewRow In dw.Rows
                For Each celda As DataGridViewCell In fila.Cells
                    If TypeOf (celda) Is DataGridViewTextBoxCell Then
                        If Not (celda.RowIndex > 0 And celda.ColumnIndex > 0) Then
                            If Not String.IsNullOrEmpty(celda.Tag) Then
                                celda.Value = analizador.EjecutarExpresion(Replace(celda.Tag, "=", ""))
                            End If
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Function listaVariables()
        Try
            Dim listvar As New List(Of Integer)
            For Each rv As DataGridViewRow In dwvariables.Rows
                If Convert.ToBoolean(rv.Cells(usar.Index).Value) Then
                    listvar.Add(Convert.ToInt32(rv.Cells(idvariable.Index).Value))
                End If
            Next
            Return listvar
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Function listaObservaciones()
        Try
            Dim listvobs As New List(Of String)
            For Each cobserva As Control In flpcontenedorobservaciones.Controls
                If TypeOf cobserva Is ControlesPersonalizados.ObservacionesenPlantilla Then
                    listvobs.Add(DirectCast(cobserva,
                                ControlesPersonalizados.ObservacionesenPlantilla).Observacion)
                End If

            Next
            Return listvobs
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Sub CorreccionBasicaMateriales(dw As DataGridView)
        Try
            For Each rv As DataGridViewRow In dw.Rows
                For Each c As DataGridViewCell In rv.Cells
                    If IsNothing(c.Value) And TypeOf c Is DataGridViewTextBoxCell Then
                        c.Value = String.Empty
                    End If
                Next
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Function listaMateriales() As List(Of MaterialPlantilla)
        Try
            CorreccionBasicaMateriales(dwVidrios)
            CorreccionBasicaMateriales(dwPerfiles)
            CorreccionBasicaMateriales(dwAccesorios)
            CorreccionBasicaMateriales(dwotros)
            listaMateriales = New List(Of MaterialPlantilla)
            For Each rv As DataGridViewRow In dwVidrios.Rows
                listaMateriales.Add(New MaterialPlantilla(0, String.Empty, Date.Now, curid, String.Empty, ClsEnums.FamiliasMateriales.VIDRIO,
                                    String.Empty, Convert.ToInt32(rv.Cells(vorientacion.Index).Value), String.Empty,
                                    If(String.IsNullOrEmpty(rv.Cells(vreferencia.Index).Value), rv.Cells(vreferencia.Index).Tag, rv.Cells(vreferencia.Index).Value),
                                    String.Empty, rv.Cells(vespesor.Index).Value.ToString(), 1, String.Empty, Convert.ToInt32(rv.Cells(vmaterialpara.Index).Value), String.Empty,
                                    If(String.IsNullOrEmpty(rv.Cells(vacabado.Index).Value), rv.Cells(vacabado.Index).Tag, rv.Cells(vacabado.Index).Value),
                                    Convert.ToInt32(rv.Cells(vtipomaterial.Index).Value), String.Empty, 1, String.Empty, Nothing, rv.Cells(vcantidad.Index).Value.ToString(),
                                    rv.Cells(vpxuni.Index).Value.ToString(), rv.Cells(vancho.Index).Value.ToString(), rv.Cells(valto.Index).Value.ToString(), rv.Cells(vpeso.Index).Value.ToString(),
                                    0, rv.Cells(vdetalle.Index).Value.ToString(), 0, String.Empty, Date.Now, ClsEnums.Estados.ACTIVO, String.Empty, If(String.IsNullOrEmpty(rv.Cells(vvisibilidad.Index).Value), rv.Cells(vvisibilidad.Index).Tag, rv.Cells(vvisibilidad.Index).Value), rv.Index + 1))
            Next
            For Each rp As DataGridViewRow In dwPerfiles.Rows
                listaMateriales.Add(New MaterialPlantilla(0, String.Empty, Date.Now, curid, String.Empty, ClsEnums.FamiliasMateriales.PERFILERIA,
                                    String.Empty, Convert.ToInt32(rp.Cells(porientacion.Index).Value), String.Empty, rp.Cells(preferencia.Index).Value, String.Empty,
                                    1, Convert.ToInt32(rp.Cells(pubicacion.Index).Value), String.Empty, Convert.ToInt32(rp.Cells(pmaterialpara.Index).Value), String.Empty,
                                    If(String.IsNullOrEmpty(rp.Cells(pacabado.Index).Value), rp.Cells(pacabado.Index).Tag, rp.Cells(pacabado.Index).Value),
                                    Convert.ToInt32(rp.Cells(ptipomaterial.Index).Value), String.Empty, Convert.ToInt32(rp.Cells(pcortes.Index).Value), String.Empty, Nothing,
                                    rp.Cells(pcantidad.Index).Value, rp.Cells(ppxuni.Index).Value,
                                    If(String.IsNullOrEmpty(rp.Cells(pdimension.Index).Value), rp.Cells(pdimension.Index).Tag, rp.Cells(pdimension.Index).Value), 0,
                                    If(String.IsNullOrEmpty(rp.Cells(ppeso.Index).Value), rp.Cells(ppeso.Index).Tag, rp.Cells(ppeso.Index).Value),
                                    If(String.IsNullOrEmpty(rp.Cells(pdescuento.Index).Value), rp.Cells(pdescuento.Index).Tag, rp.Cells(pdescuento.Index).Value),
                                    rp.Cells(pdescuento.Index).Value.ToString(), 0, String.Empty, Date.Now, ClsEnums.Estados.ACTIVO,
                                    String.Empty, If(String.IsNullOrEmpty(rp.Cells(pvisibilidad.Index).Value), rp.Cells(pvisibilidad.Index).Tag, rp.Cells(pvisibilidad.Index).Value), rp.Index + 1))
            Next
            For Each ra As DataGridViewRow In dwAccesorios.Rows
                listaMateriales.Add(New MaterialPlantilla(0, String.Empty, Date.Now, curid, String.Empty, ClsEnums.FamiliasMateriales.ACCESORIOS,
                                    String.Empty, Convert.ToInt32(ra.Cells(aorientacion.Index).Value), String.Empty, ra.Cells(areferencia.Index).Value, String.Empty,
                                    1, 1, String.Empty, Convert.ToInt32(ra.Cells(amaterialpara.Index).Value), String.Empty,
                                    If(String.IsNullOrEmpty(ra.Cells(aacabado.Index).Tag), ra.Cells(aacabado.Index).Value, ra.Cells(aacabado.Index).Tag), Convert.ToInt32(ra.Cells(atipomaterial.Index).Value), String.Empty, 1, String.Empty, Nothing,
                                    ra.Cells(acantidad.Index).Value, ra.Cells(apxuni.Index).Value, If(String.IsNullOrEmpty(ra.Cells(adimension.Index).Value), ra.Cells(adimension.Index).Tag, ra.Cells(adimension.Index).Value), 0,
                                    If(String.IsNullOrEmpty(ra.Cells(apeso.Index).Value), ra.Cells(apeso.Index).Tag, ra.Cells(apeso.Index).Value),
                                    0, ra.Cells(adetalle.Index).Value.ToString(), 0, String.Empty, Date.Now, ClsEnums.Estados.ACTIVO, String.Empty,
                                    If(String.IsNullOrEmpty(ra.Cells(avisibilidad.Index).Value), ra.Cells(avisibilidad.Index).Tag, ra.Cells(avisibilidad.Index).Value), ra.Index + 1))
            Next

            For Each ro As DataGridViewRow In dwotros.Rows
                listaMateriales.Add(New MaterialPlantilla(0, String.Empty, Date.Now, curid, String.Empty, ClsEnums.FamiliasMateriales.OTROS,
                                    String.Empty, 25, String.Empty, ro.Cells(oreferencia.Index).Value,
                                    String.Empty, 1, 1, String.Empty, 1, String.Empty, 32, 2,
                                    String.Empty, 1, String.Empty, Nothing, Convert.ToString(ro.Cells(ocantidad.Index).Value),
                                    Convert.ToString(ro.Cells(ocantidad.Index).Value), Convert.ToString(ro.Cells(oancho.Index).Value), Convert.ToString(ro.Cells(oalto.Index).Value), 0,
                                    0, Convert.ToString(ro.Cells(odetalle.Index).Value), 0, String.Empty, Date.Now, ClsEnums.Estados.ACTIVO, String.Empty,
                                    If(String.IsNullOrEmpty(ro.Cells(ovisibilidad.Index).Value), ro.Cells(ovisibilidad.Index).Tag, ro.Cells(ovisibilidad.Index).Value), ro.Index + 1))
            Next
            Return listaMateriales
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ValidarDibujos(ByRef mensaje As String) As Boolean
        Try
            Dim lnombre As New List(Of String)
            Dim ldibujos As New List(Of String)
            For Each c As Control In flpContenedordibujos.Controls
                If TypeOf c Is ControlesPersonalizados.DibujosPlantilla Then
                    lnombre.Add(DirectCast(c, ControlesPersonalizados.DibujosPlantilla).Nombre)
                    ldibujos.Add(DirectCast(c, ControlesPersonalizados.DibujosPlantilla).ObtenerStrImagen())
                End If
            Next
            Return mdibujoplantilla.ValidarListaImagenes(lnombre, ldibujos, mensaje)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Sub GuardarDescuentos(r As DataGridViewRow, idm As Integer)
        Try
            Dim material As New Objeto
            material = analizador.ListaMateriales.Item(r.DataGridView.AccessibleName, r.Index + 1)
            If material IsNot Nothing Then
                For Each desc In material.Descuentos
                    If desc.IdDescuento >= 0 Then
                        If desc.Id = 0 Then
                            If String.IsNullOrEmpty(desc.Formula) Then
                                If Convert.ToInt32(desc.Valor) > 0 Then
                                    desc.Id = mdescuentosmaterial.Insertar(idm, desc.IdDescuento, desc.Valor, My.Settings.UsuarioActivo, 1)
                                End If
                            Else
                                desc.Id = mdescuentosmaterial.Insertar(idm, desc.IdDescuento, desc.Formula, My.Settings.UsuarioActivo, 1)
                            End If
                        Else
                            If String.IsNullOrEmpty(desc.Formula) Then
                                mdescuentosmaterial.Modificar(desc.Id, idm, desc.IdDescuento, desc.Valor, My.Settings.UsuarioActivo, 1)
                            Else
                                mdescuentosmaterial.Modificar(desc.Id, idm, desc.IdDescuento, desc.Formula, My.Settings.UsuarioActivo, 1)
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Function GuardarDatos(cerrar As Boolean) As Boolean
        bwcargas.RunWorkerAsync()
        Dim causaError As String = String.Empty
        Try
            Dim mensaje As String = String.Empty
            If mplantmodelo.ValidarEncabezado(Convert.ToInt32(cbtipomodelo.SelectedValue),
                                             Convert.ToInt32(cbclasificacionmodelo.SelectedValue),
                                             Convert.ToInt32(cbfamiliamodelo.SelectedValue), Convert.ToInt32(cbconfiguracionmodelo.SelectedValue),
                                             Convert.ToInt32(cbcaracteristicasadicionales.SelectedValue), tform = ClsEnums.TiOperacion.INSERTAR, mensaje) And
                                             mvarplantilla.ValidarDatos(listaVariables(), mensaje) And
                 mobservaplantilla.ValidarOvservaciones(listaObservaciones(), mensaje) And ValidarDibujos(mensaje) And mmaterialesplantilla.validarMateriales(listaMateriales(), mensaje) Then

#Region "Guardar Encabezado"
                causaError = "Error Intentando guardar el encabezado"
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Proceso = "... Guardando Encabezado"
                If tform = ClsEnums.TiOperacion.INSERTAR Or duplicada Then
                    curid = mplantmodelo.Ingresar(My.Settings.UsuarioActivo, Convert.ToInt32(cbtipomodelo.SelectedValue),
                                             Convert.ToInt32(cbclasificacionmodelo.SelectedValue),
                                             Convert.ToInt32(cbfamiliamodelo.SelectedValue), Convert.ToInt32(cbconfiguracionmodelo.SelectedValue),
                                             Convert.ToInt32(cbcaracteristicasadicionales.SelectedValue), lbdescripcion.Text,
                                                  Convert.ToInt32(cbEstado.Tag), cbcalcularNsr.Checked)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    mplantmodelo.Modificar(curid, My.Settings.UsuarioActivo, Convert.ToInt32(cbtipomodelo.SelectedValue),
                                             Convert.ToInt32(cbclasificacionmodelo.SelectedValue),
                                             Convert.ToInt32(cbfamiliamodelo.SelectedValue), Convert.ToInt32(cbconfiguracionmodelo.SelectedValue),
                                             Convert.ToInt32(cbcaracteristicasadicionales.SelectedValue), lbdescripcion.Text,
                                             Convert.ToInt32(cbEstado.Tag), cbcalcularNsr.Checked)
                End If
#End Region
                If curid <= 0 Then
                    If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
                    Throw New Exception("Errores en la conexión con la base de datos han impedido el correcto guardado de la plantilla. Espere un momento he " &
                                        "intente nuevamente.")
                Else
                    ClsInterbloqueos.Bloquear(curid, ClsEnums.ModulosAplicacion.MODULO_PLANTILLAS, My.Settings.UsuarioActivo)
                End If
#Region "Guardar Variables"
                causaError = "Error Intentando guardar las variables"
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Proceso = "...Guardando Variables"
                For Each rv As DataGridViewRow In dwvariables.Rows
                    If Convert.ToBoolean(rv.Cells(usar.Index).Value) Then
                        If String.IsNullOrEmpty(Convert.ToString(rv.Cells(id.Index).Value)) Then
                            rv.Cells(id.Index).Value = mvarplantilla.Ingresar(My.Settings.UsuarioActivo,
                                                                          curid,
                                                                          Convert.ToInt32(rv.Cells(idvariable.Index).Value),
                                                                         If(String.IsNullOrEmpty(rv.Cells(vmaximo.Index).Tag), rv.Cells(vmaximo.Index).Value, rv.Cells(vmaximo.Index).Tag),
                                                                          If(String.IsNullOrEmpty(rv.Cells(vminimo.Index).Tag), rv.Cells(vminimo.Index).Value, rv.Cells(vminimo.Index).Tag),
                                                                          ClsEnums.Estados.ACTIVO)
                        Else
                            mvarplantilla.Modificar(Convert.ToInt32(rv.Cells(id.Index).Value),
                                                    My.Settings.UsuarioActivo, curid,
                                                    Convert.ToInt32(rv.Cells(idvariable.Index).Value),
                                                    If(String.IsNullOrEmpty(rv.Cells(vmaximo.Index).Tag), rv.Cells(vmaximo.Index).Value, rv.Cells(vmaximo.Index).Tag),
                                                    If(String.IsNullOrEmpty(rv.Cells(vminimo.Index).Tag), rv.Cells(vminimo.Index).Value, rv.Cells(vminimo.Index).Tag),
                                                    ClsEnums.Estados.ACTIVO)
                        End If
                    End If
                Next
#End Region

#Region "Guardar Observaciones"
                causaError = "Error Intentando guardar las observaciones"
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Proceso = "...Guardando Observaciones"
                For Each cobserva As Control In flpcontenedorobservaciones.Controls
                    If TypeOf cobserva Is ControlesPersonalizados.ObservacionesenPlantilla Then
                        Dim obs As ControlesPersonalizados.ObservacionesenPlantilla = DirectCast(cobserva, ControlesPersonalizados.ObservacionesenPlantilla)
                        If obs.Id <= 0 Then
                            obs.Id = mobservaplantilla.Ingresar(My.Settings.UsuarioActivo, curid,
                                                       obs.Imprimir, obs.Observacion, ClsEnums.Estados.ACTIVO)
                        Else
                            mobservaplantilla.Modificar(obs.Id, My.Settings.UsuarioActivo, curid,
                                                       obs.Imprimir, obs.Observacion, ClsEnums.Estados.ACTIVO)
                        End If
                    End If
                Next
#End Region

#Region "Guardar Dibujos"
                causaError = "Error Intentando guardar los dibujos"
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Proceso = "... Guardando Dibujos"
                For Each cdibujo As Control In flpContenedordibujos.Controls
                    If TypeOf cdibujo Is ControlesPersonalizados.DibujosPlantilla Then
                        Dim dib As ControlesPersonalizados.DibujosPlantilla = DirectCast(cdibujo, ControlesPersonalizados.DibujosPlantilla)
                        If dib.Id > 0 Then
                            mdibujoplantilla.Modificar(dib.Id, My.Settings.UsuarioActivo, curid, dib.Nombre,
                                                       dib.Predeterminado, dib.ObtenerStrImagen(), ClsEnums.Estados.ACTIVO, dib.PlantillaVidrio)
                        Else
                            dib.Id = mdibujoplantilla.Ingresar(My.Settings.UsuarioActivo, curid, dib.Nombre,
                                                       dib.Predeterminado, dib.ObtenerStrImagen(), ClsEnums.Estados.ACTIVO, dib.PlantillaVidrio)
                        End If
                    End If
                Next
#End Region

#Region "Guardar Vidrios"
                causaError = "Error Intentando guardar los vidrios"
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Proceso = "... Guardando Vidrios"
                For Each rv As DataGridViewRow In dwVidrios.Rows
                    If String.IsNullOrEmpty(rv.Cells(vid.Index).Value) Then
                        rv.Cells(vid.Index).Value = mmaterialesplantilla.Ingresar(My.Settings.UsuarioActivo, curid, ClsEnums.FamiliasMateriales.VIDRIO,
                                                                                Convert.ToInt32(rv.Cells(vorientacion.Index).Value), If(String.IsNullOrEmpty(rv.Cells(vespesor.Index).Tag), rv.Cells(vespesor.Index).Value.ToString(), rv.Cells(vespesor.Index).Tag.ToString()),
                                                                                If(String.IsNullOrEmpty(rv.Cells(vreferencia.Index).Tag), rv.Cells(vreferencia.Index).Value.ToString(), rv.Cells(vreferencia.Index).Tag.ToString()), 1, Convert.ToInt32(rv.Cells(vmaterialpara.Index).Value),
                                                                                If(String.IsNullOrEmpty(rv.Cells(vacabado.Index).Tag), rv.Cells(vacabado.Index).Value.ToString(), rv.Cells(vacabado.Index).Tag.ToString()),
                                                                                Convert.ToInt32(rv.Cells(vtipomaterial.Index).Value), 1,
                                                                                If(String.IsNullOrEmpty(rv.Cells(vcantidad.Index).Tag), rv.Cells(vcantidad.Index).Value.ToString(), rv.Cells(vcantidad.Index).Tag.ToString()),
                                                                                If(String.IsNullOrEmpty(rv.Cells(vpxuni.Index).Tag), rv.Cells(vpxuni.Index).Value.ToString(), rv.Cells(vpxuni.Index).Tag.ToString()),
                                                                                If(String.IsNullOrEmpty(rv.Cells(vancho.Index).Tag), rv.Cells(vancho.Index).Value.ToString(), rv.Cells(vancho.Index).Tag.ToString()),
                                                                                If(String.IsNullOrEmpty(rv.Cells(valto.Index).Tag), rv.Cells(valto.Index).Value.ToString(), rv.Cells(valto.Index).Tag.ToString()),
                                                                                If(String.IsNullOrEmpty(rv.Cells(vpeso.Index).Tag), rv.Cells(vpeso.Index).Value.ToString(), rv.Cells(vpeso.Index).Tag.ToString()),
                                                                                0, If(String.IsNullOrEmpty(rv.Cells(vdetalle.Index).Tag), rv.Cells(vdetalle.Index).Value.ToString(), rv.Cells(vdetalle.Index).Tag.ToString()), ClsEnums.Estados.ACTIVO,
                                                                                If(String.IsNullOrEmpty(rv.Cells(vvisibilidad.Index).Tag), rv.Cells(vvisibilidad.Index).Value.ToString(), rv.Cells(vvisibilidad.Index).Tag.ToString()),
                                                                                rv.Index + 1)
                    Else
                        mmaterialesplantilla.Modificar(Convert.ToInt32(rv.Cells(vid.Index).Value), My.Settings.UsuarioActivo, curid, ClsEnums.FamiliasMateriales.VIDRIO,
                                                        Convert.ToInt32(rv.Cells(vorientacion.Index).Value), If(String.IsNullOrEmpty(rv.Cells(vespesor.Index).Tag), rv.Cells(vespesor.Index).Value.ToString(), rv.Cells(vespesor.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(rv.Cells(vreferencia.Index).Tag), rv.Cells(vreferencia.Index).Value.ToString(), rv.Cells(vreferencia.Index).Tag.ToString()), 1, Convert.ToInt32(rv.Cells(vmaterialpara.Index).Value),
                                                        If(String.IsNullOrEmpty(rv.Cells(vacabado.Index).Tag), rv.Cells(vacabado.Index).Value.ToString(), rv.Cells(vacabado.Index).Tag.ToString()), Convert.ToInt32(rv.Cells(vtipomaterial.Index).Value), 1,
                                                        If(String.IsNullOrEmpty(rv.Cells(vcantidad.Index).Tag), rv.Cells(vcantidad.Index).Value.ToString(), rv.Cells(vcantidad.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(rv.Cells(vpxuni.Index).Tag), rv.Cells(vpxuni.Index).Value.ToString(), rv.Cells(vpxuni.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(rv.Cells(vancho.Index).Tag), rv.Cells(vancho.Index).Value.ToString(), rv.Cells(vancho.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(rv.Cells(valto.Index).Tag), rv.Cells(valto.Index).Value.ToString(), rv.Cells(valto.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(rv.Cells(vpeso.Index).Tag), rv.Cells(vpeso.Index).Value.ToString(), rv.Cells(vpeso.Index).Tag.ToString()),
                                                        0, If(String.IsNullOrEmpty(rv.Cells(vdetalle.Index).Tag), rv.Cells(vdetalle.Index).Value.ToString(), rv.Cells(vdetalle.Index).Tag.ToString()), ClsEnums.Estados.ACTIVO,
                                                        If(String.IsNullOrEmpty(rv.Cells(vvisibilidad.Index).Tag), rv.Cells(vvisibilidad.Index).Value.ToString(), rv.Cells(vvisibilidad.Index).Tag.ToString()), rv.Index + 1)
                    End If
                    GuardarDescuentos(rv, Convert.ToInt32(rv.Cells("vid").Value))
                Next
#End Region

#Region "Guardar Perfiles"
                causaError = "Error Intentando guardar la perfilería"
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Proceso = "... Guardando Perfiles"
                For Each rp As DataGridViewRow In dwPerfiles.Rows
                    If String.IsNullOrEmpty(rp.Cells(pid.Index).Value) Then
                        rp.Cells(pid.Index).Value = mmaterialesplantilla.Ingresar(My.Settings.UsuarioActivo, curid, ClsEnums.FamiliasMateriales.PERFILERIA,
                                                                                Convert.ToInt32(rp.Cells(porientacion.Index).Value), 1, rp.Cells(preferencia.Index).Value.ToString(), Convert.ToInt32(rp.Cells(pubicacion.Index).Value), Convert.ToInt32(rp.Cells(pmaterialpara.Index).Value),
                                                                                If(String.IsNullOrEmpty(rp.Cells(pacabado.Index).Tag), rp.Cells(pacabado.Index).Value.ToString(), rp.Cells(pacabado.Index).Tag.ToString()), Convert.ToInt32(rp.Cells(ptipomaterial.Index).Value), Convert.ToInt32(rp.Cells(pcortes.Index).Value),
                                                                                If(String.IsNullOrEmpty(rp.Cells(pcantidad.Index).Tag), rp.Cells(pcantidad.Index).Value.ToString(), rp.Cells(pcantidad.Index).Tag.ToString()),
                                                                                If(String.IsNullOrEmpty(rp.Cells(ppxuni.Index).Tag), rp.Cells(ppxuni.Index).Value.ToString(), rp.Cells(ppxuni.Index).Tag.ToString()),
                                                                                If(String.IsNullOrEmpty(rp.Cells(pdimension.Index).Tag), rp.Cells(pdimension.Index).Value.ToString(), rp.Cells(pdimension.Index).Tag.ToString()), "0",
                                                                                If(String.IsNullOrEmpty(rp.Cells(ppeso.Index).Tag), rp.Cells(ppeso.Index).Value.ToString(), rp.Cells(ppeso.Index).Tag.ToString()),
                                                                                If(String.IsNullOrEmpty(rp.Cells(pdescuento.Index).Tag), rp.Cells(pdescuento.Index).Value.ToString(), rp.Cells(pdescuento.Index).Tag.ToString()),
                                                                                If(String.IsNullOrEmpty(rp.Cells(pdetalle.Index).Tag), rp.Cells(pdetalle.Index).Value.ToString(), rp.Cells(pdetalle.Index).Tag.ToString()), ClsEnums.Estados.ACTIVO,
                                                                                If(String.IsNullOrEmpty(rp.Cells(pvisibilidad.Index).Tag), rp.Cells(pvisibilidad.Index).Value.ToString(), rp.Cells(pvisibilidad.Index).Tag.ToString()),
                                                                                rp.Index + 1)
                    Else
                        mmaterialesplantilla.Modificar(Convert.ToInt32(rp.Cells(pid.Index).Value), My.Settings.UsuarioActivo, curid, ClsEnums.FamiliasMateriales.PERFILERIA,
                                                        Convert.ToInt32(rp.Cells(porientacion.Index).Value), 1, rp.Cells(preferencia.Index).Value.ToString(), Convert.ToInt32(rp.Cells(pubicacion.Index).Value), Convert.ToInt32(rp.Cells(pmaterialpara.Index).Value),
                                                        If(String.IsNullOrEmpty(rp.Cells(pacabado.Index).Tag), rp.Cells(pacabado.Index).Value.ToString(), rp.Cells(pacabado.Index).Tag.ToString()), Convert.ToInt32(rp.Cells(ptipomaterial.Index).Value), Convert.ToInt32(rp.Cells(pcortes.Index).Value),
                                                        If(String.IsNullOrEmpty(rp.Cells(pcantidad.Index).Tag), rp.Cells(pcantidad.Index).Value.ToString(), rp.Cells(pcantidad.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(rp.Cells(ppxuni.Index).Tag), rp.Cells(ppxuni.Index).Value.ToString(), rp.Cells(ppxuni.Index).Tag.ToString()), If(String.IsNullOrEmpty(rp.Cells(pdimension.Index).Tag), rp.Cells(pdimension.Index).Value.ToString(), rp.Cells(pdimension.Index).Tag.ToString()), 0,
                                                        If(String.IsNullOrEmpty(rp.Cells(ppeso.Index).Tag), rp.Cells(ppeso.Index).Value.ToString(), rp.Cells(ppeso.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(rp.Cells(pdescuento.Index).Tag), rp.Cells(pdescuento.Index).Value.ToString(), rp.Cells(pdescuento.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(rp.Cells(pdetalle.Index).Tag), rp.Cells(pdetalle.Index).Value.ToString(), rp.Cells(pdetalle.Index).Tag.ToString()), ClsEnums.Estados.ACTIVO,
                                                        If(String.IsNullOrEmpty(rp.Cells(pvisibilidad.Index).Tag), rp.Cells(pvisibilidad.Index).Value.ToString(), rp.Cells(pvisibilidad.Index).Tag.ToString()),
                                                        rp.Index + 1)
                    End If
                    GuardarDescuentos(rp, Convert.ToInt32(rp.Cells(pid.Index).Value))
                Next
#End Region

#Region "Guardar Accesorios"
                causaError = "Error Intentando guardar los accesorios"
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Proceso = "... Guardando Accesorios"
                For Each ra As DataGridViewRow In dwAccesorios.Rows
                    If String.IsNullOrEmpty(ra.Cells(aid.Index).Value) Then
                        ra.Cells(aid.Index).Value = mmaterialesplantilla.Ingresar(My.Settings.UsuarioActivo, curid, ClsEnums.FamiliasMateriales.ACCESORIOS,
                                                                                    Convert.ToInt32(ra.Cells(aorientacion.Index).Value), 1, ra.Cells(areferencia.Index).Value.ToString(), 1, Convert.ToInt32(ra.Cells(amaterialpara.Index).Value),
                                                                                    If(String.IsNullOrEmpty(ra.Cells(aacabado.Index).Tag), ra.Cells(aacabado.Index).Value.ToString(), ra.Cells(aacabado.Index).Tag.ToString()), Convert.ToInt32(ra.Cells(atipomaterial.Index).Value), 1,
                                                                                    If(String.IsNullOrEmpty(ra.Cells(acantidad.Index).Tag), ra.Cells(acantidad.Index).Value.ToString(), ra.Cells(acantidad.Index).Tag.ToString()),
                                                                                    If(String.IsNullOrEmpty(ra.Cells(apxuni.Index).Tag), ra.Cells(apxuni.Index).Value.ToString(), ra.Cells(apxuni.Index).Tag.ToString()),
                                                                                    If(String.IsNullOrEmpty(ra.Cells(adimension.Index).Tag), ra.Cells(adimension.Index).Value.ToString(), ra.Cells(adimension.Index).Tag.ToString()), 0,
                                                                                    If(String.IsNullOrEmpty(ra.Cells(apeso.Index).Tag), ra.Cells(apeso.Index).Value.ToString(), ra.Cells(apeso.Index).Tag.ToString()),
                                                                                    0, If(String.IsNullOrEmpty(ra.Cells(adetalle.Index).Tag), ra.Cells(adetalle.Index).Value.ToString(), ra.Cells(adetalle.Index).Tag.ToString()), ClsEnums.Estados.ACTIVO,
                                                                                    If(String.IsNullOrEmpty(ra.Cells(avisibilidad.Index).Tag), ra.Cells(avisibilidad.Index).Value.ToString(), ra.Cells(avisibilidad.Index).Tag.ToString()),
                                                                                    ra.Index + 1)
                    Else
                        mmaterialesplantilla.Modificar(Convert.ToInt32(ra.Cells(aid.Index).Value), My.Settings.UsuarioActivo, curid, ClsEnums.FamiliasMateriales.ACCESORIOS,
                                                        Convert.ToInt32(ra.Cells(aorientacion.Index).Value), 1, ra.Cells(areferencia.Index).Value.ToString(), 1, Convert.ToInt32(ra.Cells(amaterialpara.Index).Value),
                                                        If(String.IsNullOrEmpty(ra.Cells(aacabado.Index).Tag), ra.Cells(aacabado.Index).Value.ToString(), ra.Cells(aacabado.Index).Tag.ToString()), Convert.ToInt32(ra.Cells(atipomaterial.Index).Value), 1,
                                                        If(String.IsNullOrEmpty(ra.Cells(acantidad.Index).Tag), ra.Cells(acantidad.Index).Value.ToString(), ra.Cells(acantidad.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(ra.Cells(apxuni.Index).Tag), ra.Cells(apxuni.Index).Value.ToString(), ra.Cells(apxuni.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(ra.Cells(adimension.Index).Tag), ra.Cells(adimension.Index).Value.ToString(), ra.Cells(adimension.Index).Tag.ToString()), 0,
                                                        If(String.IsNullOrEmpty(ra.Cells(apeso.Index).Tag), ra.Cells(apeso.Index).Value.ToString(), ra.Cells(apeso.Index).Tag.ToString()),
                                                        0, If(String.IsNullOrEmpty(ra.Cells(adetalle.Index).Tag), ra.Cells(adetalle.Index).Value.ToString(), ra.Cells(adetalle.Index).Tag.ToString()), ClsEnums.Estados.ACTIVO,
                                                        If(String.IsNullOrEmpty(ra.Cells(avisibilidad.Index).Tag), ra.Cells(avisibilidad.Index).Value.ToString(), ra.Cells(avisibilidad.Index).Tag.ToString()),
                                                        ra.Index + 1)
                    End If
                    GuardarDescuentos(ra, Convert.ToInt32(ra.Cells(aid.Index).Value))
                Next
#End Region

#Region "Guardar Otros"
                causaError = "Error Intentando guardar los otros"
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Proceso = "... Guardando Otros"
                For Each ro As DataGridViewRow In dwotros.Rows
                    If String.IsNullOrEmpty(ro.Cells(oid.Index).Value) Then
                        ro.Cells(oid.Index).Value = mmaterialesplantilla.Ingresar(My.Settings.UsuarioActivo, curid, ClsEnums.FamiliasMateriales.OTROS,
                                                                                    25, 1, ro.Cells(areferencia.Index).Value.ToString(), 1, 3, "NO APLICA", 1, 1,
                                                                                    If(String.IsNullOrEmpty(ro.Cells(ocantidad.Index).Tag), ro.Cells(ocantidad.Index).Value.ToString(), ro.Cells(ocantidad.Index).Tag.ToString()),
                                                                                    If(String.IsNullOrEmpty(ro.Cells(opxuni.Index).Tag), ro.Cells(opxuni.Index).Value.ToString(), ro.Cells(opxuni.Index).Tag.ToString()),
                                                                                    If(String.IsNullOrEmpty(ro.Cells(oancho.Index).Tag), ro.Cells(oancho.Index).Value.ToString(), ro.Cells(oancho.Index).Tag.ToString()),
                                                                                    If(String.IsNullOrEmpty(ro.Cells(oalto.Index).Tag), ro.Cells(oalto.Index).Value.ToString(), ro.Cells(oalto.Index).Tag.ToString()),
                                                                                    0, 0, If(String.IsNullOrEmpty(ro.Cells(odetalle.Index).Tag), ro.Cells(odetalle.Index).Value.ToString(), ro.Cells(odetalle.Index).Tag.ToString()),
                                                                                    ClsEnums.Estados.ACTIVO,
                                                                                    If(String.IsNullOrEmpty(ro.Cells(ovisibilidad.Index).Tag), ro.Cells(ovisibilidad.Index).Value.ToString(), ro.Cells(ovisibilidad.Index).Tag.ToString()),
                                                                                    ro.Index + 1)
                    Else
                        mmaterialesplantilla.Modificar(Convert.ToInt32(ro.Cells(oid.Index).Value), My.Settings.UsuarioActivo, curid, ClsEnums.FamiliasMateriales.OTROS,
                                                        25, 1, ro.Cells(areferencia.Index).Value.ToString(), 1, 3, "NO APLICA", 1, 1,
                                                        If(String.IsNullOrEmpty(ro.Cells(ocantidad.Index).Tag), ro.Cells(ocantidad.Index).Value.ToString(), ro.Cells(ocantidad.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(ro.Cells(opxuni.Index).Tag), ro.Cells(opxuni.Index).Value.ToString(), ro.Cells(opxuni.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(ro.Cells(oancho.Index).Tag), ro.Cells(oancho.Index).Value.ToString(), ro.Cells(oancho.Index).Tag.ToString()),
                                                        If(String.IsNullOrEmpty(ro.Cells(oalto.Index).Tag), ro.Cells(oalto.Index).Value.ToString(), ro.Cells(oalto.Index).Tag.ToString()),
                                                        0, 0, If(String.IsNullOrEmpty(ro.Cells(odetalle.Index).Tag), ro.Cells(odetalle.Index).Value.ToString(), ro.Cells(odetalle.Index).Tag.ToString()),
                                                        ClsEnums.Estados.ACTIVO,
                                                        If(String.IsNullOrEmpty(ro.Cells(ovisibilidad.Index).Tag), ro.Cells(ovisibilidad.Index).Value.ToString(), ro.Cells(ovisibilidad.Index).Tag.ToString()),
                                                        ro.Index + 1)
                    End If
                    GuardarDescuentos(ro, Convert.ToInt32(ro.Cells(oid.Index).Value))
                Next
#End Region

#Region "Guardar Descuentos Globales"
                causaError = "Error Intentando guardar los descuentos globales"
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Proceso = "...Guardando Descuentos Globales"
                For Each rD As DataGridViewRow In dwDescuentos.Rows
                    If Convert.ToInt32(rD.Cells(idDescGlobal.Index).Value) <= 0 Then
                        rD.Cells(idDescGlobal.Index).Value = mdescuentosGlobales.Insertar(curid, Convert.ToInt32(rD.Cells(descuentoG.Index).Value), If(String.IsNullOrEmpty(Convert.ToString(rD.Cells(valorG.Index).Tag)),
                                                                         Convert.ToString(rD.Cells(valorG.Index).Value), Convert.ToString(rD.Cells(valorG.Index).Tag)),
                                                                          My.Settings.UsuarioActivo, ClsEnums.Estados.ACTIVO)
                    Else
                        mdescuentosGlobales.Modificar(rD.Cells(idDescGlobal.Index).Value, curid, Convert.ToInt32(rD.Cells(descuentoG.Index).Value), If(String.IsNullOrEmpty(Convert.ToString(rD.Cells(valorG.Index).Tag)),
                                                                         Convert.ToString(rD.Cells(valorG.Index).Value), Convert.ToString(rD.Cells(valorG.Index).Tag)),
                                                                         My.Settings.UsuarioActivo, ClsEnums.Estados.ACTIVO)
                    End If
                Next
#End Region
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
                If cerrar Then Me.Close()
                Return True
            Else
                MsgBox(mensaje, MsgBoxStyle.Critical)
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(causaError & ": " & ex.Message, ex.InnerException)
        End Try
    End Function
    Private Sub ModificarDescuentos()
        Try
            Dim r As DataGridViewRow = Nothing
            r = DirectCast(tcmateriales.SelectedTab.Controls(0), DataGridView).SelectedRows(0)
            Dim material As Objeto = analizador.ListaMateriales.Item(r.DataGridView.AccessibleName, r.Index + 1)
            Dim frmdesc As New FrmDescuentosMaterial
            frmdesc.tipoDescuento = ClsEnums.tipoDescuento.DSCINDIVIDUAL
            frmdesc.Material = material
            frmdesc.Analizador = analizador
            If frmdesc.ShowDialog() = DialogResult.OK Then
                material.Descuentos.Clear()
                For Each d As DescuentoMaterial In frmdesc.Descuentos
                    material.Descuentos.Add(New Formulador.Descuento(d.Id, d.IdDescuento,
                                                                     d.Descuento, d.Valor,
                                                                     String.Empty))
                Next
                RecalcularValores()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Copiar()
        Try
            Dim dw As DataGridView = DirectCast(tcmateriales.SelectedTab.Controls(0), DataGridView)
            Dim contenido As String = String.Empty
            For i = 0 To dw.SelectedRows.Count - 1
                Dim r As DataGridViewRow = dw.SelectedRows(i)
                contenido &= r.Index & "|·"
                For j = 1 To r.Cells.Count - 1
                    contenido &= Convert.ToString(r.Cells(j).Value) & "|" & Convert.ToString(r.Cells(j).Tag) & "·"
                Next
                contenido &= "◘"
            Next
            Clipboard.SetData(dw.AccessibleName, contenido)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub Pegar()
        Try
            Dim datos As String() = Nothing
            Dim dw As DataGridView = Nothing
            If Clipboard.ContainsData(dwAccesorios.AccessibleName) Then
                datos = Convert.ToString(Clipboard.GetData(dwAccesorios.AccessibleName)).Split("◘")
                dw = dwAccesorios
            End If

            If Clipboard.ContainsData(dwPerfiles.AccessibleName) Then
                datos = Convert.ToString(Clipboard.GetData(dwPerfiles.AccessibleName)).Split("◘")
                dw = dwPerfiles
            End If

            If Clipboard.ContainsData(dwVidrios.AccessibleName) Then
                datos = Convert.ToString(Clipboard.GetData(dwVidrios.AccessibleName)).Split("◘")
                dw = dwVidrios
            End If
            If Clipboard.ContainsData(dwotros.AccessibleName) Then
                datos = Convert.ToString(Clipboard.GetData(dwotros.AccessibleName)).Split("◘")
                dw = dwotros
            End If
            datos = datos.Where(Function(x) Not String.IsNullOrEmpty(x)).OrderBy(Function(x) Convert.ToInt32(x.Split("·")(0).Split("|")(0))).ToArray()
            For i = 0 To datos.Count - 1
                If Not String.IsNullOrEmpty(Trim(datos(i))) Then
                    Dim r As DataGridViewRow = dw.Rows(dw.Rows.Add())
                    Dim datosfila As String() = datos(i).Split("·")
                    For j = 1 To datosfila.Count - 1
                        If Not String.IsNullOrEmpty(datosfila(j)) Then
                            If TypeOf r.Cells(j) Is DataGridViewComboBoxCell Then
                                If Not String.IsNullOrEmpty(datosfila(j).Split("|")(0)) Then

                                    r.Cells(j).Value = Convert.ToInt32(datosfila(j).Split("|")(0))
                                End If
                            Else
                                r.Cells(j).Tag = datosfila(j).Split("|")(1)
                                r.Cells(j).Value = datosfila(j).Split("|")(0)
                            End If
                        End If
                    Next
                    VerificaryCrearMaterial(r, Nothing)
                End If
            Next
            RecalcularValores()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub RecalcularValores()
        Try
            ValorarVariables()
            ValorarDescuentos()
            ValorarMateriales()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Function listaDescGlobales() As List(Of descuentoGlobal)
        listaDescGlobales = Nothing
        Try
            listaDescGlobales = New List(Of descuentoGlobal)
            For Each fila As DataGridViewRow In dwDescuentos.Rows
                Dim descto As New descuentoGlobal
                descto.Id = Convert.ToInt32(fila.Cells(idDescGlobal.Index).Value)
                descto.IdDescuento = Convert.ToInt32(fila.Cells(descuentoG.Index).Value)
                descto.Descuento = fila.Cells(descuentoG.Index).FormattedValue
                descto.Formula = Convert.ToString(fila.Cells().Item(valorG.Index).Tag)
                descto.Valor = fila.Cells().Item(valorG.Index).Value
                listaDescGlobales.Add(descto)
            Next
            Return listaDescGlobales
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function
#End Region

#Region "Elementos Carga Gráfica"
    Private Sub bwcargas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwcargas.DoWork
        Try
            Application.Run(New FrmCargaProceso)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

#Region "Carga para modificación de plantilla"
    Private Sub cargarPlantilla()
        Try
            Dim mmodelo As PlantillaModelo = mplantmodelo.TraerxId(curid)
            cbtipomodelo.SelectedValue = mmodelo.IdTipoModelo
            cbclasificacionmodelo.SelectedValue = mmodelo.IdClasificacionoModelo
            cbfamiliamodelo.SelectedValue = mmodelo.IdFamiliaModelo
            cbconfiguracionmodelo.SelectedValue = mmodelo.IdConfiguracion
            cbcaracteristicasadicionales.SelectedValue = mmodelo.IdCaracteristicaAdicional
            cbEstado.Checked = Not Convert.ToBoolean(mmodelo.IdEstado - 1)
            cbcalcularNsr.Checked = mmodelo.Calcular_NSR
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarVariablesplantilla()
        Try
            Dim listvariablesutilizadas As List(Of VariablePlantilla) = mvarplantilla.TraerxIdPlantilla(curid)
            For Each var As VariablePlantilla In listvariablesutilizadas
                Dim index As Integer = f_listaVariables.FindIndex(Function(V) V.Id.Equals(var.IdVariable))
                If index >= 0 Then
                    dwvariables.Rows(index).Cells(usar.Index).Value = True
                    If (Not duplicada) Then
                        dwvariables.Rows(index).Cells(id.Index).Value = var.Id
                    End If
                    If var.ValorMinimo.StartsWith("=") Then
                        dwvariables.Rows(index).Cells(vminimo.Index).Tag = var.ValorMinimo
                        dwvariables.Rows(index).Cells(vminimo.Index).Value = 0
                    Else
                        If TypeOf dwvariables.Rows(index).Cells(vminimo.Index) Is DataGridViewComboBoxCell Then
                            If DirectCast(dwvariables.Rows(index).Cells(vminimo.Index), DataGridViewComboBoxCell).Items.Contains(var.ValorMinimo) Then
                                dwvariables.Rows(index).Cells(vminimo.Index).Value = var.ValorMinimo
                            End If
                        Else
                            dwvariables.Rows(index).Cells(vminimo.Index).Value = var.ValorMinimo
                        End If
                        dwvariables.Rows(index).Cells(vminimo.Index).Tag = String.Empty
                    End If
                    If var.ValorMaximo.StartsWith("=") Then
                        dwvariables.Rows(index).Cells(vmaximo.Index).Value = 0
                        dwvariables.Rows(index).Cells(vmaximo.Index).Tag = var.ValorMaximo
                    Else
                        If TypeOf dwvariables.Rows(index).Cells(vmaximo.Index) Is DataGridViewComboBoxCell Then
                            If DirectCast(dwvariables.Rows(index).Cells(vmaximo.Index), DataGridViewComboBoxCell).Items.Contains(var.ValorMaximo) Then
                                dwvariables.Rows(index).Cells(vmaximo.Index).Value = var.ValorMaximo
                            End If
                        Else
                            dwvariables.Rows(index).Cells(vmaximo.Index).Value = var.ValorMaximo
                        End If
                        dwvariables.Rows(index).Cells(vmaximo.Index).Tag = String.Empty
                    End If
                    RevisaryCrearVariableGeneral(dwvariables.Rows(index))
                End If
            Next
            ValorarVariables()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarDescuentosGlobales()
        Try
            Dim listDescuentosGlobales As New List(Of descuentoGlobal)
            mdescuentosGlobales = New ClsDescuentosGlobales
            listDescuentosGlobales = mdescuentosGlobales.TraerxIdPlantilla(curid)
            If listDescuentosGlobales.Count = 0 Then Return
            For Each var As descuentoGlobal In listDescuentosGlobales
                Dim r As DataGridViewRow = dwDescuentos.Rows(dwDescuentos.Rows.Add())
                If (Not duplicada) Then
                    r.Cells(idDescGlobal.Index).Value = var.Id
                End If
                r.Cells(usarG.Index).Value = True
                r.Cells(descuentoG.Index).Value = var.IdDescuento
                r.Cells(valorG.Index).Tag = var.Formula
                r.Cells(valorG.Index).Value = var.Valor
                verificaryCrearDescuentoG(r)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub ValorarVariables()
        Try
            analizador.ValorarRestricciones()
            For Each r As DataGridViewRow In dwvariables.Rows
                If r.Cells(usar.Index).Value Then
                    Dim v As Parametro = analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString())
                    If v.Restricciones.Contains("MINIMO") Then
                        r.Cells(vminimo.Index).Value = v.Restricciones.Item("MINIMO").Valor
                    End If
                    If v.Restricciones.Contains("MAXIMO") Then
                        r.Cells(vmaximo.Index).Value = v.Restricciones.Item("MAXIMO").Valor
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub ValorarDescuentos()
        Try
            analizador.ValorarElementosDescuentos()
            For Each r As DataGridViewRow In dwDescuentos.Rows
                Dim desc As Formulador.Descuento = analizador.ListaDescuentos.Item(Convert.ToString(r.Cells(descuentoG.Index).FormattedValue))
                r.Cells(valorG.Index).Value = desc.Valor
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarMaterialesPlantilla()
        Try
            Dim listmateriales As List(Of MaterialPlantilla) = mmaterialesplantilla.TraerxIdplantilla(curid)

            For Each mat As MaterialPlantilla In listmateriales
                Dim r As DataGridViewRow = Nothing
                Select Case mat.IdFamiliaMaterial
                    Case Is = ClsEnums.FamiliasMateriales.VIDRIO
#Region "Vidrios"
                        r = dwVidrios.Rows(dwVidrios.Rows.Add())
                        If (Not duplicada) Then r.Cells(vid.Index).Value = mat.Id
                        If mat.Articulo.StartsWith("=") Then
                            r.Cells(vreferencia.Index).Tag = mat.Articulo
                            r.Cells(vreferencia.Index).Value = String.Empty
                        Else
                            r.Cells(vreferencia.Index).Value = mat.Articulo
                            r.Cells(vreferencia.Index).Tag = String.Empty
                        End If
                        If mat.Espesor.StartsWith("=") Then
                            r.Cells(vespesor.Index).Tag = mat.Espesor
                            r.Cells(vespesor.Index).Value = 0
                        Else
                            r.Cells(vespesor.Index).Value = mat.Espesor
                            r.Cells(vespesor.Index).Tag = String.Empty
                        End If
                        If mat.Acabado.StartsWith("=") Then
                            r.Cells(vacabado.Index).Tag = mat.Acabado
                            r.Cells(vacabado.Index).Value = String.Empty
                        Else
                            r.Cells(vacabado.Index).Value = mat.Acabado
                            r.Cells(vacabado.Index).Tag = String.Empty
                        End If
                        If mat.Ancho.StartsWith("=") Then
                            r.Cells(vancho.Index).Tag = mat.Ancho
                            r.Cells(vancho.Index).Value = 0
                        Else
                            r.Cells(vancho.Index).Value = mat.Ancho
                            r.Cells(vancho.Index).Tag = String.Empty
                        End If
                        If mat.Alto.StartsWith("=") Then
                            r.Cells(valto.Index).Tag = mat.Alto
                            r.Cells(valto.Index).Value = 0
                        Else
                            r.Cells(valto.Index).Value = mat.Alto
                            r.Cells(valto.Index).Tag = String.Empty
                        End If
                        If mat.peso.StartsWith("=") Then
                            r.Cells(vpeso.Index).Tag = mat.peso
                            r.Cells(vpeso.Index).Value = 0
                        Else
                            r.Cells(vpeso.Index).Value = mat.peso
                            r.Cells(vpeso.Index).Tag = String.Empty
                        End If
                        If mat.Cantidad.StartsWith("=") Then
                            r.Cells(vcantidad.Index).Tag = mat.Cantidad
                            r.Cells(vcantidad.Index).Value = 0
                        Else
                            r.Cells(vcantidad.Index).Value = mat.Cantidad
                            r.Cells(vcantidad.Index).Tag = String.Empty
                        End If
                        If mat.PiezasxUnidad.StartsWith("=") Then
                            r.Cells(vpxuni.Index).Tag = mat.PiezasxUnidad
                            r.Cells(vpxuni.Index).Value = 0
                        Else
                            r.Cells(vpxuni.Index).Value = mat.PiezasxUnidad
                            r.Cells(vpxuni.Index).Tag = String.Empty
                        End If
                        r.Cells(vorientacion.Index).Value = mat.IdOrientacionyPosicion
                        r.Cells(vmaterialpara.Index).Value = mat.IdMaterialPara
                        r.Cells(vtipomaterial.Index).Value = mat.IdTipoMaterial

                        If mat.Observaciones.StartsWith("=") Then
                            r.Cells(vdetalle.Index).Tag = mat.Observaciones
                            r.Cells(vdetalle.Index).Value = String.Empty
                        Else
                            r.Cells(vdetalle.Index).Value = mat.Observaciones
                            r.Cells(vdetalle.Index).Tag = String.Empty
                        End If

                        If mat.Visibilidad.StartsWith("=") Then
                            r.Cells(vvisibilidad.Index).Tag = mat.Visibilidad
                            r.Cells(vvisibilidad.Index).Value = 0
                        Else
                            r.Cells(vvisibilidad.Index).Value = mat.Visibilidad
                            r.Cells(vvisibilidad.Index).Tag = String.Empty
                        End If
#End Region
                    Case Is = ClsEnums.FamiliasMateriales.PERFILERIA
#Region "Perfileria"
                        r = dwPerfiles.Rows(dwPerfiles.Rows.Add())
                        If (Not duplicada) Then r.Cells(pid.Index).Value = mat.Id
                        r.Cells(preferencia.Index).Value = Convert.ToInt32(mat.Articulo)

                        If mat.Acabado.StartsWith("=") Then
                            r.Cells(pacabado.Index).Tag = mat.Acabado
                            r.Cells(pacabado.Index).Value = String.Empty
                        Else
                            r.Cells(pacabado.Index).Value = mat.Acabado
                            r.Cells(pacabado.Index).Tag = String.Empty
                        End If
                        If mat.Ancho.StartsWith("=") Then
                            r.Cells(pdimension.Index).Tag = mat.Ancho
                            r.Cells(pdimension.Index).Value = 0
                        Else
                            r.Cells(pdimension.Index).Value = mat.Ancho
                            r.Cells(pdimension.Index).Tag = String.Empty
                        End If
                        If mat.peso.StartsWith("=") Then
                            r.Cells(ppeso.Index).Tag = mat.peso
                            r.Cells(ppeso.Index).Value = 0
                        Else
                            r.Cells(ppeso.Index).Value = mat.peso
                            r.Cells(ppeso.Index).Tag = String.Empty
                        End If
                        If mat.Cantidad.StartsWith("=") Then
                            r.Cells(pcantidad.Index).Tag = mat.Cantidad
                            r.Cells(pcantidad.Index).Value = 0
                        Else
                            r.Cells(pcantidad.Index).Value = mat.Cantidad
                            r.Cells(pcantidad.Index).Tag = String.Empty
                        End If
                        If mat.PiezasxUnidad.StartsWith("=") Then
                            r.Cells(ppxuni.Index).Tag = mat.PiezasxUnidad
                            r.Cells(ppxuni.Index).Value = 0
                        Else
                            r.Cells(ppxuni.Index).Value = mat.PiezasxUnidad
                            r.Cells(ppxuni.Index).Tag = String.Empty
                        End If
                        r.Cells(porientacion.Index).Value = mat.IdOrientacionyPosicion
                        r.Cells(pubicacion.Index).Value = mat.IdUbicacionMaterial
                        r.Cells(pmaterialpara.Index).Value = mat.IdMaterialPara
                        r.Cells(ptipomaterial.Index).Value = mat.IdTipoMaterial
                        r.Cells(pcortes.Index).Value = mat.IdTipoCortes
                        If mat.Observaciones.StartsWith("=") Then
                            r.Cells(pdetalle.Index).Tag = mat.Observaciones
                            r.Cells(pdetalle.Index).Value = String.Empty
                        Else
                            r.Cells(pdetalle.Index).Value = mat.Observaciones
                            r.Cells(pdetalle.Index).Tag = String.Empty
                        End If
                        If mat.Visibilidad.StartsWith("=") Then
                            r.Cells(pvisibilidad.Index).Tag = mat.Visibilidad
                            r.Cells(pvisibilidad.Index).Value = 0
                        Else
                            r.Cells(pvisibilidad.Index).Value = mat.Visibilidad
                            r.Cells(pvisibilidad.Index).Tag = String.Empty
                        End If
                        r.Cells(pdescuento.Index).Value = mat.Descuento
#End Region
                    Case Is = ClsEnums.FamiliasMateriales.ACCESORIOS
#Region "Accesorios"
                        r = dwAccesorios.Rows(dwAccesorios.Rows.Add())
                        If (Not duplicada) Then r.Cells(aid.Index).Value = mat.Id
                        r.Cells(areferencia.Index).Value = Convert.ToInt32(mat.Articulo)

                        If mat.Acabado.StartsWith("=") Then
                            r.Cells(aacabado.Index).Tag = mat.Acabado
                            r.Cells(aacabado.Index).Value = String.Empty
                        Else
                            r.Cells(aacabado.Index).Value = mat.Acabado
                            r.Cells(aacabado.Index).Tag = String.Empty
                        End If
                        If mat.Ancho.StartsWith("=") Then
                            r.Cells(adimension.Index).Tag = mat.Ancho
                            r.Cells(adimension.Index).Value = 0
                        Else
                            r.Cells(adimension.Index).Value = mat.Ancho
                            r.Cells(adimension.Index).Tag = String.Empty
                        End If
                        If mat.Cantidad.StartsWith("=") Then
                            r.Cells(acantidad.Index).Tag = mat.Cantidad
                            r.Cells(acantidad.Index).Value = 0
                        Else
                            r.Cells(acantidad.Index).Value = mat.Cantidad
                            r.Cells(acantidad.Index).Tag = String.Empty
                        End If
                        If mat.PiezasxUnidad.StartsWith("=") Then
                            r.Cells(apxuni.Index).Tag = mat.PiezasxUnidad
                            r.Cells(apxuni.Index).Value = 0
                        Else
                            r.Cells(apxuni.Index).Value = mat.PiezasxUnidad
                            r.Cells(apxuni.Index).Tag = String.Empty
                        End If
                        r.Cells(aorientacion.Index).Value = mat.IdOrientacionyPosicion
                        r.Cells(amaterialpara.Index).Value = mat.IdMaterialPara
                        r.Cells(atipomaterial.Index).Value = mat.IdTipoMaterial
                        If mat.Observaciones.StartsWith("=") Then
                            r.Cells(adetalle.Index).Tag = mat.Observaciones
                            r.Cells(adetalle.Index).Value = 0
                        Else
                            r.Cells(adetalle.Index).Value = mat.Observaciones
                            r.Cells(adetalle.Index).Tag = String.Empty
                        End If
                        If mat.Visibilidad.StartsWith("=") Then
                            r.Cells(avisibilidad.Index).Tag = mat.Visibilidad
                            r.Cells(avisibilidad.Index).Value = 0
                        Else
                            r.Cells(avisibilidad.Index).Value = mat.Visibilidad
                            r.Cells(avisibilidad.Index).Tag = String.Empty
                        End If
                        If mat.peso.StartsWith("=") Then
                            r.Cells(apeso.Index).Tag = mat.peso
                            r.Cells(apeso.Index).Value = 0
                        Else
                            r.Cells(apeso.Index).Value = mat.peso
                            r.Cells(apeso.Index).Tag = String.Empty
                        End If
#End Region
                    Case Is = ClsEnums.FamiliasMateriales.OTROS
#Region "Otros"
                        r = dwotros.Rows(dwotros.Rows.Add())
                        If (Not duplicada) Then r.Cells(oid.Index).Value = mat.Id
                        r.Cells(oreferencia.Index).Value = Convert.ToInt32(mat.Articulo)
                        If mat.Ancho.StartsWith("=") Then
                            r.Cells(oancho.Index).Tag = mat.Ancho
                            r.Cells(oancho.Index).Value = 0
                        Else
                            r.Cells(oancho.Index).Value = mat.Ancho
                            r.Cells(oancho.Index).Tag = String.Empty
                        End If
                        If mat.Alto.StartsWith("=") Then
                            r.Cells(oalto.Index).Tag = mat.Alto
                            r.Cells(oalto.Index).Value = 0
                        Else
                            r.Cells(oalto.Index).Value = mat.Alto
                            r.Cells(oalto.Index).Tag = String.Empty
                        End If

                        If mat.Cantidad.StartsWith("=") Then
                            r.Cells(ocantidad.Index).Tag = mat.Cantidad
                            r.Cells(ocantidad.Index).Value = 0
                        Else
                            r.Cells(ocantidad.Index).Value = mat.Cantidad
                            r.Cells(ocantidad.Index).Tag = String.Empty
                        End If
                        If mat.PiezasxUnidad.StartsWith("=") Then
                            r.Cells(opxuni.Index).Tag = mat.PiezasxUnidad
                            r.Cells(opxuni.Index).Value = 0
                        Else
                            r.Cells(opxuni.Index).Value = mat.PiezasxUnidad
                            r.Cells(opxuni.Index).Tag = String.Empty
                        End If
                        If mat.Observaciones.StartsWith("=") Then
                            r.Cells(odetalle.Index).Tag = mat.Observaciones
                            r.Cells(odetalle.Index).Value = 0
                        Else
                            r.Cells(odetalle.Index).Value = mat.Observaciones
                            r.Cells(odetalle.Index).Tag = String.Empty
                        End If
                        If mat.Visibilidad.StartsWith("=") Then
                            r.Cells(ovisibilidad.Index).Tag = mat.Visibilidad
                            r.Cells(ovisibilidad.Index).Value = 0
                        Else
                            r.Cells(ovisibilidad.Index).Value = mat.Visibilidad
                            r.Cells(ovisibilidad.Index).Tag = String.Empty
                        End If

#End Region
                End Select
                VerificaryCrearMaterial(r, mdescuentosmaterial.TraerxIdmaterial(mat.Id))
            Next
            ValorarMateriales()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub ValorarMateriales()
        Try
            analizador.ValorarElementosMaterial()
            For Each o As Objeto In analizador.ListaMateriales
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
                    If p.Indice >= 0 Then
                        If Not String.IsNullOrEmpty(Convert.ToString(rw.Cells(p.Indice).Tag)) Then
                            rw.Cells(p.Indice).Value = Replace(p.Valor, "'", String.Empty)
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarDibujos()
        Try
            Dim listdibujos As List(Of DibujoModelo) = mdibujoplantilla.TraerxIdPlantilla(curid)
            For Each dibujo As DibujoModelo In listdibujos
                flpContenedordibujos.Controls.Add(NuevoDibujo(If(Not duplicada, dibujo.Id, 0),
                                                              If(Not duplicada, dibujo.Nombre, String.Empty), If(Not duplicada, dibujo.Predeterminado, 0),
                                                              dibujo.DXF, dibujo.PlantillaVidrio))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarObservaciones()
        Try
            Dim listobserva As List(Of ObservacionPlantilla) = mobservaplantilla.TraerxIdPlantilla(curid)
            For Each observacion As ObservacionPlantilla In listobserva
                flpcontenedorobservaciones.Controls.Add(NuevaObservacion(If(Not duplicada, observacion.Id, 0),
                                                                         observacion.Observacion,
                                                                         observacion.Visibilidad))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

    Private Sub Recargar_Click(sender As Object, e As EventArgs)
        Try
            cargarTiposModelo()
            cargarFamiliasModelo()
            cargarClasificacionModelo()
            cargarConfiguraciones()
            cargarCaracteristicasAdicionales()
            cargarVariables()
            cargarOrientacionyPosicionMateriales()
            cargarUbicacionMateriales()
            cargarMaterialPara()
            cargarTipoMaterial()
            cargarTipoCortes()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            Dim btnsRecargar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnrecargar
            Dim btnexportar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnexportar
            btnexportar.Enabled = False
            btnsParcial.Enabled = True
            AddHandler btnsParcial.Click, AddressOf GuardadoParcial_Click
            AddHandler btnguardar.Click, AddressOf GuardadoParcial_Click
            AddHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
            AddHandler btnsRecargar.Click, AddressOf Recargar_Click
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
            Dim btnexportar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnexportar
            btnexportar.Enabled = True
            btnsParcial.Enabled = False
            RemoveHandler btnsParcial.Click, AddressOf GuardadoParcial_Click
            RemoveHandler btnguardar.Click, AddressOf GuardadoParcial_Click
            RemoveHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
            RemoveHandler btnsRecargar.Click, AddressOf Recargar_Click

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmPlantillaModelo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckForIllegalCrossThreadCalls = False
            analizador = New AnalizadorLexico()
            mplantmodelo = New ClsPlantillasModelos
            mvarplantilla = New ClsVariablesPlantillas
            mobservaplantilla = New ClsObservacionesPlantilla
            mdibujoplantilla = New ClsDibujosModelo
            mmaterialesplantilla = New ClsMaterialesPlantilla
            mdescuentosmaterial = New ClsDescuentosMaterial
            cargarTiposModelo()
            cargarFamiliasModelo()
            cargarClasificacionModelo()
            cargarConfiguraciones()
            cargarCaracteristicasAdicionales()
            cargarVariables()
            cargarOrientacionyPosicionMateriales()
            cargarUbicacionMateriales()
            cargarMaterialPara()
            cargarTipoMaterial()
            cargarTipoCortes()
            cargarDescuentosG()
            Dim desc As New ClsDescuentos
            listadescuentos = desc.TraerxEstado(ClsEnums.Estados.ACTIVO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmPlantillaModelo_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If tform = ClsEnums.TiOperacion.MODIFICAR Or duplicada Then
                bwcargas.RunWorkerAsync()
                cargarPerfileria()
                cargarAccesorios()
                cargarPlantilla()
                cargarVariablesplantilla()
                cargarDescuentosGlobales()
                cargarMaterialesPlantilla()
                RecalcularValores()
                cargarDibujos()
                cargarObservaciones()
                If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
                If duplicada Then
                    curid = 0
                End If
            End If
        Catch ex As Exception
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
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
    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try
            If MsgBox("¿Esta seguro que desea guardar los cambios en la plantilla?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If GuardarDatos(True) Then
                    tform = ClsEnums.TiOperacion.MODIFICAR
                    duplicada = False
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        End Try
    End Sub
    Private Sub GuardadoParcial_Click(sender As Object, e As EventArgs)
        Try
            If MsgBox("¿Esta seguro que desea guardar los cambios en la plantilla?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If GuardarDatos(False) Then
                    tform = ClsEnums.TiOperacion.MODIFICAR
                    duplicada = False
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        End Try
    End Sub
    Private Sub guardadoRapido_click(sender As Object, e As EventArgs)
        Try
            GuardadoTotal_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message, , MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        Try
            ClsInterbloqueos.Desbloquear(curid, ClsEnums.ModulosAplicacion.MODULO_PLANTILLAS)
            curid = 0
            tform = ClsEnums.TiOperacion.INSERTAR
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles cbEstado.CheckedChanged
        Try
            If cbEstado.Checked Then
                cbEstado.Tag = 1
                cbEstado.Text = "Activo"
            Else
                cbEstado.Tag = 2
                cbEstado.Text = "Inactivo"
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tsmiVidrio_Click(sender As Object, e As EventArgs) Handles tsmiVidrio.Click
        Try
            Dim r As DataGridViewRow = dwVidrios.Rows(dwVidrios.Rows.Add())
            r.Cells(vreferencia.Index).Value = String.Empty
            r.Cells(vancho.Index).Value = 0
            r.Cells(valto.Index).Value = 0
            r.Cells(vcantidad.Index).Value = 0
            r.Cells(vdetalle.Index).Value = String.Empty
            VerificaryCrearMaterial(r, Nothing)
            tcmateriales.SelectedIndex = tpvidrio.TabIndex
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
            VerificaryCrearMaterial(r, Nothing)
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
            VerificaryCrearMaterial(r, Nothing)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dwVidrios.CellPainting, dwPerfiles.CellPainting, dwAccesorios.CellPainting, dwDescuentos.CellPainting, dwotros.CellPainting
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
                            Dim d As Formulador.Descuento = analizador.ListaDescuentos.Item(Convert.ToString(e.Row.Cells(descuentoG.Index).FormattedValue))
                            analizador.ListaDescuentos.Remove(d)
                        End If
                    Else
                        If Not analizador.VerificarDependenciasConObjeto(e.Row.Index + 1, dw.AccessibleName) Then
                            Dim mmaterial As Objeto = analizador.ListaMateriales.Item(dw.AccessibleName, e.Row.Index + 1)
                            analizador.ListaMateriales.Remove(mmaterial)
#Region "Re-Evaluación Elementos"
                            Dim grids() As DataGridView = New DataGridView() {dwVidrios, dwPerfiles, dwAccesorios}
                            For Each g As DataGridView In grids
                                For Each r As DataGridViewRow In g.Rows
                                    Dim contiene As Boolean = False
                                    For Each c As DataGridViewCell In r.Cells
                                        For i As Integer = e.Row.Index + 1 To dw.Rows.Count
                                            If Convert.ToString(c.Tag).Contains(dw.AccessibleName & "(" & i + 1 & ")") Then
                                                c.Tag = Convert.ToString(c.Tag).Replace(dw.AccessibleName & "(" & i + 1 & ")", dw.AccessibleName & "(" & i & ")")
                                                contiene = True
                                            End If
                                        Next
                                        If contiene Then
                                            If Not String.IsNullOrEmpty(r.Cells(0).Value) Then
                                                VerificaryCrearMaterial(r, mdescuentosmaterial.TraerxIdmaterial(Convert.ToInt32(r.Cells(0).Value)))
                                            Else
                                                VerificaryCrearMaterial(r, Nothing)
                                            End If
                                        End If
                                    Next
                                Next
                            Next
#End Region
                            If Not String.IsNullOrEmpty(e.Row.Cells(0).Value) Then
                                mdescuentosmaterial.EliminarxIdMaterial(Convert.ToInt32(e.Row.Cells(0).Value))
                                mmaterialesplantilla.EliminarxId(Convert.ToInt32(e.Row.Cells(0).Value))
                            End If
                            'RecalcularValores()
                            'GuardarDatos(False)
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
    Private Sub dwvariables_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dwvariables.CellValueChanged
        Try
            If e.RowIndex >= 0 Then
                If Not IsNothing(dwvariables.Item(usar.Index, e.RowIndex).Value) Then
                    RevisaryCrearVariableGeneral(dwvariables.Rows(e.RowIndex))
                    'RecalcularValores()
                End If
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwvariables_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwvariables.CellEndEdit
        Try
            If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwvariables.Rows(e.RowIndex)
                dwvariables.Item(e.ColumnIndex, e.RowIndex).ErrorText = String.Empty
                If Not IsNothing(dwvariables.Item(usar.Index, e.RowIndex).Value) Then
                    If Not IsNothing(dwvariables.Item(e.ColumnIndex, e.RowIndex).Value) Then
                        If Not String.IsNullOrEmpty(dwvariables.Item(e.ColumnIndex, e.RowIndex).Value.ToString()) Then
                            If Not dwvariables.Item(e.ColumnIndex, e.RowIndex).Value.ToString().Contains("=") Then
                                Dim tvar As Integer = Convert.ToInt32(r.Cells(tipodato.Index).Value) - 1
                                If dwvariables.Columns(e.ColumnIndex) Is vmaximo Or dwvariables.Columns(e.ColumnIndex) Is vminimo Then
                                    Select Case tvar
                                        Case Is = 1 'Numérico
                                            Dim ej As New Ejecutor
                                            Dim _val = ej.ObtenerTokens(r.Cells(e.ColumnIndex).Value)
                                            Dim val As String = ej.Parse(_val)
                                            If Not IsNumeric(val) Then
                                                dwvariables.Item(e.ColumnIndex, e.RowIndex).ErrorText = "El valor debe ser numérico"
                                            Else
                                                dwvariables.Item(e.ColumnIndex, e.RowIndex).ErrorText = String.Empty
                                            End If
                                        Case Is = 2 'Texto
                                        Case Is = 3 'Booleano
                                            If Not IsNumeric(r.Cells(e.ColumnIndex).Value) Then
                                                dwvariables.Item(e.ColumnIndex, e.RowIndex).ErrorText = "Los únicos valores posibles son ceros (0) o unos (1)"
                                            Else
                                                If Convert.ToInt32(r.Cells(e.ColumnIndex).Value) > 1 Or Convert.ToInt32(r.Cells(e.ColumnIndex).Value) < 0 Then
                                                    dwvariables.Item(e.ColumnIndex, e.RowIndex).ErrorText = "Los únicos valores posibles son ceros (0) o unos (1)"
                                                Else
                                                    dwvariables.Item(e.ColumnIndex, e.RowIndex).ErrorText = String.Empty
                                                End If
                                            End If
                                        Case Is = 4 'Fecha
                                            If Not IsDate(r.Cells(e.ColumnIndex).Value) Then
                                                dwvariables.Item(e.ColumnIndex, e.RowIndex).ErrorText = "El valor debe ser de tipo fecha [" & Now.ToString("dd/MM/yyyy") & "]"
                                            Else
                                                dwvariables.Item(e.ColumnIndex, e.RowIndex).ErrorText = String.Empty
                                            End If
                                    End Select
                                End If
                            End If
                        End If
                    Else
                        dwvariables.Item(e.ColumnIndex, e.RowIndex).Value = String.Empty
                    End If
                End If
                If dwvariables.Columns(e.ColumnIndex) Is usar Then
                    If Not Convert.ToBoolean(dwvariables.Item(usar.Index, e.RowIndex).Value) And
                       Not String.IsNullOrEmpty(dwvariables.Rows(e.RowIndex).Cells(id.Index).Value) Then
                        mvarplantilla.EliminarxId(Convert.ToInt32(dwvariables.Rows(e.RowIndex).Cells(id.Index).Value))
                        dwvariables.Rows(e.RowIndex).Cells(id.Index).Value = String.Empty
                    End If
                End If
                dwvariables.UpdateCellErrorText(e.ColumnIndex, e.RowIndex)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwvariables_CellErrorTextChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dwvariables.CellErrorTextChanged
        Try
            If e.ColumnIndex >= 0 And e.RowIndex >= 0 Then
                If Not IsNothing(dwvariables.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    If Not String.IsNullOrEmpty(dwvariables.Item(e.ColumnIndex, e.RowIndex).Value.ToString()) Then
                        If Not String.IsNullOrEmpty(dwvariables.Item(e.ColumnIndex, e.RowIndex).ErrorText) Then
                            dwvariables.Item(usar.Index, e.RowIndex).Value = False
                            MsgBox("La celda: Columna [" & dwvariables.Columns(e.ColumnIndex).HeaderText & "] Fila [" & e.RowIndex + 1 & "], tiene un error. " & dwvariables.Item(e.ColumnIndex, e.RowIndex).ErrorText &
                                   ". Debe corregir el error para poder usar la variable.", MsgBoxStyle.Critical)
                        End If
                    End If
                End If
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
                    mdibujoplantilla.EliminarxId(mdibuj.Id)
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
                    mobservaplantilla.EliminarxId(mobserv.Id)
                End If
                flpcontenedorobservaciones.Controls.Remove(mobserv)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tsagregardibujo_Click(sender As Object, e As EventArgs) Handles tsagregardibujo.Click
        Try
            flpContenedordibujos.Controls.Add(NuevoDibujo(0, String.Empty, 0, String.Empty, False))
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnagregarobservacion_Click(sender As Object, e As EventArgs) Handles btnagregarobservacion.Click
        Try
            flpcontenedorobservaciones.Controls.Add(NuevaObservacion(0, String.Empty, False))
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dwVidrios.RowsAdded, dwAccesorios.RowsAdded, dwPerfiles.RowsAdded, dwotros.RowsAdded
        Try
            Dim dw As DataGridView = DirectCast(sender, DataGridView)
            If dw Is dwVidrios Then
            ElseIf dw Is dwPerfiles Then
                cargarPerfileria()
            ElseIf dw Is dwAccesorios Then
                cargarAccesorios()
            ElseIf dw Is dwotros Then
                cargarOtros()
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
                formu.Analizador = analizador
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
                If pt.Y + formu.Height > Me.MdiParent.Height Then
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
                    formu.Analizador = analizador
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
                            dw.Item(ncolumn, e.RowIndex).Value = analizador.EjecutarExpresion(formu.Formula)
                        End If

                        If dw Is dwVidrios Or dw Is dwPerfiles Or dw Is dwAccesorios Or dw Is dwotros Then
                            VerificaryCrearMaterial(dw.Rows(e.RowIndex), Nothing)
                        ElseIf dw Is dwvariables Then
                            RevisaryCrearVariableGeneral(dw.Rows(e.RowIndex))
                        ElseIf dw Is dwDescuentos Then
                            verificaryCrearDescuentoG(dw.Rows(e.RowIndex))
                        End If
                        RecalcularValores()
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtvariable_TextChanged(sender As Object, e As EventArgs) Handles txtvariable.TextChanged
        Try
            Dim index As Integer = f_listaVariables.FindIndex(Function(Var) Var.Nombre.Contains(txtvariable.Text))
            If index >= 0 Then
                dwvariables.FirstDisplayedScrollingRowIndex = index
                dwvariables.Rows(index).Selected = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwvariables_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwvariables.CellBeginEdit
        Try
            Dim dw As DataGridView = DirectCast(sender, DataGridView)
            If dw.Columns(e.ColumnIndex) Is usar Then
#Region "Verificación Anticondensaciones"
                Dim conanticon As Boolean = False
                For Each c As ControlesPersonalizados.DibujosPlantilla In flpContenedordibujos.Controls
                    If c.ContieneAnticondensaciones() Then
                        conanticon = True
                        Exit For
                    End If
                Next
#End Region

                If Convert.ToBoolean(dw.Item(e.ColumnIndex, e.RowIndex).Value) Then
                    If Not analizador.VerificarDependenciasConRestriccion(Convert.ToString(dw.Item(variable.Index, e.RowIndex).Value)) Then
                        If conanticon And Convert.ToInt32(dw.Item(idvariable.Index, e.RowIndex).Value) = 18 Then
                            MsgBox("Hay dibujos que dependen de este elemento, no se puede ejecutar la acción. Verifique la información", MsgBoxStyle.Critical)
                            e.Cancel = True
                        Else
                            If (Not String.IsNullOrEmpty(Convert.ToString(dw.Item(id.Index, e.RowIndex).Value))) Then
                                mvarplantilla.EliminarxId(Convert.ToInt32(dw.Item(id.Index, e.RowIndex).Value))
                            End If
                        End If
                    Else
                        MsgBox("Hay formulas que dependen de este elemento, no se puede ejecutar la acción. Verifique la información", MsgBoxStyle.Critical)
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwVidrios.CellMouseUp, dwPerfiles.CellMouseUp, dwAccesorios.CellMouseUp, dwotros.CellMouseUp
        Try
            Dim dw As DataGridView = DirectCast(sender, DataGridView)
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 And e.Button = MouseButtons.Right Then
                Dim menu As New ContextMenuStrip
                If dw.SelectedRows.Count <= 1 Then
                    dw.Rows(e.RowIndex).Selected = True
                    menu.Items.Add("Modificar Descuentos", Nothing, AddressOf ModificarDescuentos)
                End If
                menu.Items.Add("Copiar", Nothing, AddressOf Copiar)
                If Clipboard.ContainsData(dw.AccessibleName) Then
                    menu.Items.Add("Pegar", Nothing, AddressOf Pegar)
                End If
                menu.Show(Control.MousePosition)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmPlantillaModelo_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Try
            If e.KeyCode = Keys.ControlKey And e.KeyCode = Keys.G Then
                GuardadoTotal_Click(sender, e)
            End If
            If e.KeyCode = Keys.ControlKey And e.KeyCode = Keys.Shift And e.KeyCode = Keys.A Then
                tsmiAccesorio_Click(sender, e)
            End If
            If e.KeyCode = Keys.ControlKey And e.KeyCode = Keys.Shift And e.KeyCode = Keys.P Then
                tsmiPerfil_Click(sender, e)
            End If
            If e.KeyCode = Keys.ControlKey And e.KeyCode = Keys.Shift And e.KeyCode = Keys.V Then
                tsmiVidrio_Click(sender, e)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnrecvariables_Click(sender As Object, e As EventArgs) Handles btnrecvariables.Click
        Try
            cargarVariables()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonAddGlobal_Click(sender As Object, e As EventArgs) Handles btonAddGlobal.Click
        Try
            Dim r As DataGridViewRow = dwDescuentos.Rows(dwDescuentos.Rows.Add())
            r.Cells(id.Index).Value = 0
            r.Cells(valorG.Index).Value = 0
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwDescuentos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dwDescuentos.RowsAdded
        Try
            dwDescuentos.Rows(e.RowIndex).HeaderCell.Value = e.RowIndex + 1
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
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
                VerificaryCrearMaterial(dw.Rows(e.RowIndex), Nothing)
            ElseIf dw Is dwDescuentos Then
                verificaryCrearDescuentoG(dw.Rows(e.RowIndex))
            End If
            RecalcularValores()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_MouseUp(sender As Object, e As MouseEventArgs) Handles dwVidrios.MouseUp, dwPerfiles.MouseUp, dwAccesorios.MouseUp, dwotros.MouseUp
        Try
            Dim dw As DataGridView = DirectCast(sender, DataGridView)
            If dw.Rows.Count = 0 And e.Button = MouseButtons.Right Then
                Dim menu As New ContextMenuStrip
                If Clipboard.ContainsData(dw.AccessibleName) Then
                    menu.Items.Add("Pegar", Nothing, AddressOf Pegar)
                End If
                menu.Show(Control.MousePosition)
            End If
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
            VerificaryCrearMaterial(r, Nothing)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmPlantillaModelo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            ClsInterbloqueos.Desbloquear(curid, ClsEnums.ModulosAplicacion.MODULO_PLANTILLAS)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnagregardescuento_Click(sender As Object, e As EventArgs) Handles btnagregardescuento.Click
        Try
            Dim qDescuentos As New FrmQuickAddDescuento
            If qDescuentos.ShowDialog = DialogResult.OK Then
                cargarDescuentosG()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class