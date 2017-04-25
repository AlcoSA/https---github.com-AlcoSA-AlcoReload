Imports ReglasNegocio
Imports Formulador
Public Class FrmTesteadorPlantillas

#Region "Variables"
    Private _idplantilla As Integer
    Private _analizador As AnalizadorLexico
    Private _dic As New Dictionary(Of String, String)
#End Region

#Region "Propiedades"
    Public Property IdPlantilla As Integer
        Get
            Return _idplantilla
        End Get
        Set(value As Integer)
            _idplantilla = value
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

#Region "Procedimientos"

    Private Sub cargarPlantilla()
        Try
            Dim mplantmodelo As New ClsPlantillasModelos
            Dim mmodelo As PlantillaModelo = mplantmodelo.TraerxId(_idplantilla)
            lbplantilla.Text = mmodelo.Descripcion
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error cargando plantilla",
                                ex.InnerException)
        End Try
    End Sub
    Private Sub cargarVariablesplantilla()
        Try
            dwvariables.Rows.Clear()
            Dim mvarplantilla As New ClsVariablesPlantillas
            Dim valvar As New ClsValoresVariables
            Dim listvariablesutilizadas As List(Of VariablePlantilla) = mvarplantilla.TraerxIdPlantilla(_idplantilla)
            For Each var As VariablePlantilla In listvariablesutilizadas
                Dim r As DataGridViewRow = dwvariables.Rows(dwvariables.Rows.Add())
                r.Cells(id.Index).Value = var.Id
                r.Cells(variable.Index).Value = var.Variable
                r.Cells(tipodato.Index).Value = var.TipoDato
                If var.ValorMinimo.StartsWith("=") Then
                    r.Cells(valorminimo.Index).Tag = var.ValorMinimo
                    r.Cells(valorminimo.Index).Value = 0
                Else
                    r.Cells(valorminimo.Index).Value = var.ValorMinimo
                    r.Cells(valorminimo.Index).Tag = String.Empty
                End If
                If var.ValorMaximo.StartsWith("=") Then
                    r.Cells(valormaximo.Index).Tag = var.ValorMaximo
                    r.Cells(valormaximo.Index).Value = 0
                Else
                    r.Cells(valormaximo.Index).Value = var.ValorMaximo
                    r.Cells(valormaximo.Index).Tag = String.Empty
                End If

                If var.BaseDatos Then
                    r.Cells(valor.Index) = New DataGridViewComboBoxCell()
                    Dim lvvar As List(Of ValorVariable) = valvar.TraerxIdVariable(var.IdVariable)
                    DirectCast(r.Cells(valor.Index), DataGridViewComboBoxCell).Items.AddRange(lvvar.Select(Function(x) x.Valor).ToArray())
                    If lvvar.Where(Function(x) x.ValorporDefecto).Count() > 0 Then
                        r.Cells(valor.Index).Value = lvvar.First(Function(x) x.ValorporDefecto).Valor
                    End If
                End If
                If String.IsNullOrEmpty(r.Cells(valorminimo.Index).Value) Then
                    If _dic.ContainsKey(var.Variable) Then
                        _dic.TryGetValue(var.Variable, r.Cells(valor.Index).Value)
                    Else
                        If Not var.BaseDatos Then
                            Select Case var.TipoDato - 1
                                Case Is = ClsEnums.TiposDato.NUMERICO
                                    r.Cells(valor.Index).Value = 0
                                Case Is = ClsEnums.TiposDato.TEXTO
                                    r.Cells(valor.Index).Value = String.Empty
                                Case Is = ClsEnums.TiposDato.BOOLEANO
                                    r.Cells(valor.Index).Value = 0
                                Case Is = ClsEnums.TiposDato.FECHA
                                    r.Cells(valor.Index).Value = DateTime.MinValue.ToShortDateString()
                            End Select
                        End If
                    End If

                Else
                    If _dic.ContainsKey(var.Variable) Then
                        _dic.TryGetValue(var.Variable, r.Cells(valor.Index).Value)
                    Else
                        r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                    End If
                End If

                RevisaryCrearVariableGeneral(r)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error cargando variables",
                                ex.InnerException)
        End Try
    End Sub
    Private Sub cargarDescuentosGlobales()
        Try
            dwDescuentos.Rows.Clear()
            Dim mdescuentosGlobales As New ClsDescuentosGlobales
            Dim listDescuentosGlobales As New List(Of descuentoGlobal)
            listDescuentosGlobales = mdescuentosGlobales.TraerxIdPlantilla(_idplantilla)
            If listDescuentosGlobales.Count = 0 Then Return
            For Each var As descuentoGlobal In listDescuentosGlobales
                Dim r As DataGridViewRow = dwDescuentos.Rows(dwDescuentos.Rows.Add())
                r.Cells(idDescGlobal.Index).Tag = var.Id
                r.Cells(idDescGlobal.Index).Value = var.Id
                r.Cells(idDescGlobal.Index).Value = var.Id
                r.Cells(iddescuento.Index).Value = var.IdDescuento
                r.Cells(descuentoG.Index).Value = var.Descuento
                r.Cells(valorG.Index).Tag = var.Formula
                r.Cells(valorG.Index).Value = var.Valor
            Next
            If listDescuentosGlobales.Count > 0 Then
                verificaryCrearDescuentoG()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error cargando descuentos",
                                ex.InnerException)
        End Try
    End Sub
    Private Sub verificaryCrearDescuentoG()
        Try
            For Each r As DataGridViewRow In dwDescuentos.Rows
                If Not (Analizador.ListaDescuentos.Contains(Convert.ToString(r.Cells(descuentoG.Index).Value))) Then
                    Analizador.ListaDescuentos.Add(New Formulador.Descuento(Convert.ToInt32(r.Cells(idDescGlobal.Index).Value),
                                                         Convert.ToInt32(r.Cells(iddescuento.Index).Value),
                                                         Convert.ToString(r.Cells(descuentoG.Index).Value),
                                                         Convert.ToString(r.Cells(valorG.Index).Value),
                                                         Convert.ToString(r.Cells(valorG.Index).Tag)))
                Else
                    Dim desc As Formulador.Descuento = Analizador.ListaDescuentos.Item(Convert.ToString(r.Cells(descuentoG.Index).Value))
                    desc.Formula = Convert.ToString(r.Cells(valorG.Index).Tag)
                    desc.Valor = Convert.ToString(r.Cells(valorG.Index).Value)
                End If
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error verificando descuentos",
                                ex.InnerException)
        End Try
    End Sub
    Private Sub RevisaryCrearVariableGeneral(r As DataGridViewRow)
        Try
            Dim valorvaria As String = String.Empty
            Dim valminimo As String = String.Empty
            Dim valmaximo As String = String.Empty
            Dim cformula As String = String.Empty
            Dim tdato As ClsEnums.TiposDato = Convert.ToInt32(r.Cells(tipodato.Index).Value)
            Select Case tdato
                Case Is = ClsEnums.TiposDato.NUMERICO
                    valminimo = If(String.IsNullOrEmpty(r.Cells(valorminimo.Index).Value), 0, r.Cells(valorminimo.Index).Value)
                    valmaximo = If(String.IsNullOrEmpty(r.Cells(valormaximo.Index).Value), Int32.MaxValue, r.Cells(valormaximo.Index).Value)
                Case Is = ClsEnums.TiposDato.TEXTO
                    valminimo = r.Cells(valorminimo.Index).Value.ToString()
                    valmaximo = r.Cells(valormaximo.Index).Value.ToString()
                Case Is = ClsEnums.TiposDato.BOOLEANO
                    valminimo = 0
                    valmaximo = 1
                Case Is = ClsEnums.TiposDato.FECHA
                    valminimo = If(String.IsNullOrEmpty(r.Cells(valorminimo.Index).Value), Date.MinValue.ToString(), r.Cells(valorminimo.Index).Value)
                    valmaximo = If(String.IsNullOrEmpty(r.Cells(valormaximo.Index).Value), Date.MaxValue.ToString(), r.Cells(valormaximo.Index).Value)
            End Select
            valorvaria = Convert.ToString(r.Cells(valor.Index).Value)
            If _analizador.ListaVariables.Contains(r.Cells(variable.Index).Value.ToString()) Then
                Dim param As Parametro = _analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString())
                param.Restricciones.Clear()
                If Not String.IsNullOrEmpty(r.Cells(valorminimo.Index).Value) Or Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valorminimo.Index).Tag)) Then
                    param.Restricciones.Add(New Restriccion("MINIMO", Convert.ToString(r.Cells(valorminimo.Index).Tag), valminimo, tdato))
                End If
                If Not String.IsNullOrEmpty(r.Cells(valormaximo.Index).Value) Or Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valormaximo.Index).Tag)) Then
                    param.Restricciones.Add(New Restriccion("MAXIMO", Convert.ToString(r.Cells(valormaximo.Index).Tag), valmaximo, tdato))
                End If
                param.TipoValor = tdato
                param.Valor = valorvaria
                param.Formula = valorvaria
                _analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString()) = param
            Else
                Dim param As New Parametro(r.Cells(variable.Index).Value.ToString(), valorvaria, valorvaria, tdato)
                If Not String.IsNullOrEmpty(r.Cells(valorminimo.Index).Value) Or Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valorminimo.Index).Tag)) Then
                    param.Restricciones.Add(New Restriccion("MINIMO", Convert.ToString(r.Cells(valorminimo.Index).Tag), valminimo, tdato))
                End If
                If Not String.IsNullOrEmpty(r.Cells(valormaximo.Index).Value) Or Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valormaximo.Index).Tag)) Then
                    param.Restricciones.Add(New Restriccion("MAXIMO", Convert.ToString(r.Cells(valormaximo.Index).Tag), valmaximo, tdato))
                End If
                _analizador.ListaVariables.Add(param)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error verificando variables",
                                ex.InnerException)
        End Try
    End Sub

    Private Sub ValorarDescuentos()
        Try
            Analizador.ValorarElementosDescuentos()
            For Each r As DataGridViewRow In dwDescuentos.Rows
                Dim desc As Formulador.Descuento = Analizador.ListaDescuentos.Item(Convert.ToString(r.Cells(descuentoG.Index).Value))
                r.Cells(valorG.Index).Value = desc.Valor
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Sub EjecutarFormulas()
        Try
            ValorarVariables()
            ValorarDescuentos()
            ValorarMateriales()
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error ejecutando formulas",
                                ex.InnerException)
        End Try
    End Sub
    Private Sub ValorarVariables()
        Try
            Analizador.ValorarRestricciones()
            Dim errores As String = String.Empty
            Dim ej As New Ejecutor
            For Each r As DataGridViewRow In dwvariables.Rows
                Dim v As Parametro = Analizador.ListaVariables.Item(r.Cells(variable.Index).Value.ToString())
                If v.Restricciones.Contains("MINIMO") Then
                    r.Cells(valorminimo.Index).Value = v.Restricciones.Item("MINIMO").Valor
                End If
                If v.Restricciones.Contains("MAXIMO") Then
                    r.Cells(valormaximo.Index).Value = v.Restricciones.Item("MAXIMO").Valor
                End If




                If v.TipoValor = TiposValores.Numerico Then

                    Dim _vmin = ej.ObtenerTokens(Convert.ToString(r.Cells(valorminimo.Index).Value))
                    Dim valmin As String = ej.Parse(_vmin)
                    Dim _vmax = ej.ObtenerTokens(Convert.ToString(r.Cells(valormaximo.Index).Value))
                    Dim valmax As String = ej.Parse(_vmax)
                    Dim vmin As Decimal = If(Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valorminimo.Index).Value)), valmin, 0)
                    Dim vmax As Decimal = If(Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valormaximo.Index).Value)), valmax, Decimal.MaxValue)
                    Dim _val = ej.ObtenerTokens(Convert.ToString(r.Cells(valor.Index).Value))
                    Dim val As String = ej.Parse(_val)
                    If (Convert.ToDecimal(val) < vmin Or
                                                                             Convert.ToDecimal(val) > vmax) And vmax >= vmin Then
                        errores &= v.Nombre & ", "
                        r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                        RevisaryCrearVariableGeneral(r)
                    End If
                End If
            Next
            If Not String.IsNullOrEmpty(errores) Then
                ValorarVariables()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error valorando variables",
                                ex.InnerException)
        End Try
    End Sub
    Private Sub cargarMaterialesPlantilla()
        Try
            dwVidrios.Rows.Clear()
            dwPerfiles.Rows.Clear()
            dwAccesorios.Rows.Clear()
            dwotros.Rows.Clear()
            Dim mmaterialesplantilla As New ClsMaterialesPlantilla
            Dim listmateriales As List(Of MaterialPlantilla) = mmaterialesplantilla.TraerxIdplantilla(_idplantilla)
            Dim desc As New ClsDescuentosMaterial
            For Each mat As MaterialPlantilla In listmateriales
                Dim r As DataGridViewRow = Nothing
                Select Case mat.IdFamiliaMaterial
                    Case Is = ClsEnums.FamiliasMateriales.VIDRIO
                        r = dwVidrios.Rows(dwVidrios.Rows.Add())
                        r.Cells(vid.Index).Value = mat.Id
                        If mat.ArticuloReferencia.StartsWith("=") Then
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
                        r.Cells(vorientacion.Index).Value = mat.OrientacionyPosicion
                        r.Cells(vmaterialpara.Index).Value = mat.MaterialPara
                        r.Cells(vtipomaterial.Index).Value = mat.TipoMaterial
                        If mat.Observaciones.StartsWith("=") Then
                            r.Cells(vdetalle.Index).Tag = mat.Observaciones
                            r.Cells(vdetalle.Index).Value = String.Empty
                        Else
                            r.Cells(vdetalle.Index).Value = mat.Observaciones
                            r.Cells(vdetalle.Index).Tag = String.Empty
                        End If
                        If mat.Visibilidad.StartsWith("=") Then
                            r.Cells(vvisibilidad.Index).Tag = mat.Visibilidad
                            r.Cells(vvisibilidad.Index).Value = False
                        Else
                            r.Cells(vvisibilidad.Index).Value = Convert.ToBoolean(Convert.ToInt32(mat.Visibilidad))
                            r.Cells(vvisibilidad.Index).Tag = String.Empty
                        End If
                    Case Is = ClsEnums.FamiliasMateriales.PERFILERIA
                        r = dwPerfiles.Rows(dwPerfiles.Rows.Add())
                        r.Cells(pid.Index).Value = mat.Id
                        r.Cells(preferencia.Index).Value = mat.ArticuloReferencia

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
                        If mat.peso.StartsWith("=") Then
                            r.Cells(ppeso.Index).Tag = mat.peso
                            r.Cells(ppeso.Index).Value = 0
                        Else

                            r.Cells(ppeso.Index).Value = mat.peso
                            r.Cells(ppeso.Index).Tag = String.Empty
                        End If
                        r.Cells(porientacion.Index).Value = mat.OrientacionyPosicion
                        r.Cells(pubicacion.Index).Value = mat.UbicacionMaterial
                        r.Cells(pmaterialpara.Index).Value = mat.MaterialPara
                        r.Cells(ptipomaterial.Index).Value = mat.TipoMaterial
                        Dim util As New ClsUtilidadesImagenes
                        If mat.ImagenTipoCorte IsNot Nothing Then
                            r.Cells(pcortes.Index).Value = util.ArregloBytesaImagen(mat.ImagenTipoCorte)
                            r.Cells(pcortes.Index).ToolTipText = mat.TipoCortes
                        End If

                        If mat.Observaciones.StartsWith("=") Then
                            r.Cells(pdetalle.Index).Tag = mat.Observaciones
                            r.Cells(pdetalle.Index).Value = String.Empty
                        Else
                            r.Cells(pdetalle.Index).Value = mat.Observaciones
                            r.Cells(pdetalle.Index).Tag = String.Empty
                        End If
                        If mat.Visibilidad.StartsWith("=") Then
                            r.Cells(pvisibilidad.Index).Tag = mat.Visibilidad
                            r.Cells(pvisibilidad.Index).Value = False
                        Else
                            r.Cells(pvisibilidad.Index).Value = Convert.ToBoolean(Convert.ToInt32(mat.Visibilidad))
                            r.Cells(pvisibilidad.Index).Tag = String.Empty
                        End If
                        r.Cells(pdescuento.Index).Value = mat.Descuento

                    Case Is = ClsEnums.FamiliasMateriales.ACCESORIOS
                        r = dwAccesorios.Rows(dwAccesorios.Rows.Add())
                        r.Cells(aid.Index).Value = mat.Id
                        r.Cells(areferencia.Index).Value = mat.ArticuloReferencia

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
                        r.Cells(aorientacion.Index).Value = mat.OrientacionyPosicion
                        r.Cells(amaterialpara.Index).Value = mat.MaterialPara
                        r.Cells(atipomaterial.Index).Value = mat.TipoMaterial
                        If mat.Observaciones.StartsWith("=") Then
                            r.Cells(adetalle.Index).Tag = mat.Observaciones
                            r.Cells(adetalle.Index).Value = String.Empty
                        Else
                            r.Cells(adetalle.Index).Value = mat.Observaciones
                            r.Cells(adetalle.Index).Tag = String.Empty
                        End If
                        If mat.Visibilidad.StartsWith("=") Then
                            r.Cells(avisibilidad.Index).Tag = mat.Visibilidad
                            r.Cells(avisibilidad.Index).Value = False
                        Else
                            r.Cells(avisibilidad.Index).Value = Convert.ToBoolean(Convert.ToInt32(mat.Visibilidad))
                            r.Cells(avisibilidad.Index).Tag = String.Empty
                        End If
                        If mat.peso.StartsWith("=") Then
                            r.Cells(apeso.Index).Tag = mat.peso
                            r.Cells(apeso.Index).Value = 0
                        Else
                            r.Cells(apeso.Index).Value = mat.peso
                            r.Cells(apeso.Index).Tag = String.Empty
                        End If

                    Case Is = ClsEnums.FamiliasMateriales.OTROS
                        r = dwotros.Rows(dwotros.Rows.Add())
                        r.Cells(oid.Index).Value = mat.Id
                        r.Cells(oreferencia.Index).Value = mat.ArticuloReferencia
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
                            r.Cells(odetalle.Index).Value = String.Empty
                        Else
                            r.Cells(odetalle.Index).Value = mat.Observaciones
                            r.Cells(odetalle.Index).Tag = String.Empty
                        End If
                        If mat.Visibilidad.StartsWith("=") Then
                            r.Cells(ovisibilidad.Index).Tag = mat.Visibilidad
                            r.Cells(ovisibilidad.Index).Value = False
                        Else
                            r.Cells(ovisibilidad.Index).Value = Convert.ToBoolean(Convert.ToInt32(mat.Visibilidad))
                            r.Cells(ovisibilidad.Index).Tag = String.Empty
                        End If
                End Select
                Dim listdesc As List(Of DescuentoMaterial) = desc.TraerxIdmaterial(mat.Id)
                VerificaryCrearMaterial(r, listdesc)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error cargando materiales",
                                ex.InnerException)
        End Try
    End Sub
    Private Sub ValorarMateriales()
        Try
            Analizador.ValorarElementosMaterial()
            For Each o As Objeto In Analizador.ListaMateriales
                Dim rw As DataGridViewRow = Nothing
                If o.Nombre = "VIDRIO" Then
                    rw = dwVidrios.Rows(o.Indice - 1)
                ElseIf o.Nombre = "PERFIL" Then
                    rw = dwPerfiles.Rows(o.Indice - 1)
                ElseIf o.Nombre = "ACCESORIOS" Then
                    rw = dwAccesorios.Rows(o.Indice - 1)
                ElseIf o.Nombre = "OTROS" Then
                    rw = dwotros.Rows(o.Indice - 1)
                End If
                'Valoración Parámetros
                For Each p As Parametro In o.Parametros
                    If p.Indice >= 0 Then
                        If Not String.IsNullOrEmpty(Convert.ToString(rw.Cells(p.Indice).Tag)) Then
                            If TypeOf rw.Cells(p.Indice) Is DataGridViewCheckBoxCell Then
                                rw.Cells(p.Indice).Value = Convert.ToBoolean(Convert.ToInt32(Replace(p.Valor, "'", "")))
                            ElseIf TypeOf rw.Cells(p.Indice) Is DataGridViewTextBoxCell Then
                                rw.Cells(p.Indice).Value = Replace(p.Valor, "'", String.Empty)
                            End If
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error valorando materiales",
                                ex.InnerException)
        End Try
    End Sub
    Private Sub cargarDibujos()
        Try
            flpContenedordibujos.Controls.Clear()
            Dim mdibujoplantilla As New ClsDibujosModelo
            Dim listdibujos As List(Of DibujoModelo) = mdibujoplantilla.TraerxIdPlantilla(_idplantilla)
            For Each dibujo As DibujoModelo In listdibujos
                flpContenedordibujos.Controls.Add(NuevoDibujo(dibujo.Id, dibujo.Nombre, dibujo.Predeterminado,
                                                              dibujo.DXF, dibujo.PlantillaVidrio))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error cargando dibujos",
                                ex.InnerException)
        End Try
    End Sub
    Private Sub cargarObservaciones()
        Try
            flpcontenedorobservaciones.Controls.Clear()
            Dim mobservaplantilla As New ClsObservacionesPlantilla
            Dim listobserva As List(Of ObservacionPlantilla) = mobservaplantilla.TraerxIdPlantilla(_idplantilla)
            For Each observacion As ObservacionPlantilla In listobserva
                flpcontenedorobservaciones.Controls.Add(NuevaObservacion(observacion.Id,
                                                                         observacion.Observacion,
                                                                         observacion.Visibilidad))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error cargando observaciones",
                                ex.InnerException)
        End Try
    End Sub

    Private Function NuevaObservacion(idobservacion As Integer, textoobservacion As String, imprimirobservacion As Boolean) As Control
        Try
            Dim obsplantilla As New ControlesPersonalizados.ObservacionesenPlantilla
            obsplantilla.Id = idobservacion
            obsplantilla.Observacion = textoobservacion
            obsplantilla.Imprimir = imprimirobservacion
            obsplantilla.Width = flpcontenedorobservaciones.Width
            'AddHandler obsplantilla.cancelar_Click, AddressOf btnQuitarObservacion
            Return obsplantilla
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error diseñando observación",
                                ex.InnerException)
        End Try
    End Function
    Private Function NuevoDibujo(iddibujo As Integer, nombre As String,
                                 predeterminado As String, dxf As String, plantillavidrio As Boolean) As Control
        Try
            Dim dibujoplantilla As New ControlesPersonalizados.DibujosPlantilla
            dibujoplantilla.SoloLectura = True
            dibujoplantilla.IgnorarFactorVisibilidad = False
            dibujoplantilla.Id = iddibujo
            dibujoplantilla.AnalizadorSintactico = _analizador
            dibujoplantilla.Nombre = nombre
            dibujoplantilla.Predeterminado = predeterminado
            dibujoplantilla.PlantillaVidrio = plantillavidrio
            dibujoplantilla.LeerImagen(dxf)
            Return dibujoplantilla
        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error pintando dibujos",
                                ex.InnerException)
        End Try
    End Function
    Private Sub VerificaryCrearMaterial(rw As DataGridViewRow, listdesc As List(Of DescuentoMaterial))
        Try
            Dim dw As DataGridView = rw.DataGridView
            Dim nombrematerial As String = dw.AccessibleName
            Dim ColumnastipoTexto() As String = New String() {"REFERENCIA", "DETALLE"}
            Dim material As Objeto = Nothing

            If Analizador.ListaMateriales.Contains(nombrematerial, rw.Index + 1) Then
                material = Analizador.ListaMateriales.Item(nombrematerial, rw.Index + 1)
                For Each c As DataGridViewColumn In dw.Columns
                    If Not TypeOf c Is DataGridViewButtonColumn And c.Visible Then
                        Dim tipov As TiposValores = TiposValores.Numerico
                        If ColumnastipoTexto.Contains(c.HeaderText) Then
                            tipov = TiposValores.Letras
                        End If
                        Dim variablematerial As Parametro = material.Parametros.Item(c.HeaderText)
                        variablematerial.Formula = Convert.ToString(rw.Cells(c.Name).Tag)
                        If TypeOf c Is DataGridViewComboBoxColumn Then
                            variablematerial.Valor = Convert.ToString(rw.Cells(c.Name).FormattedValue)
                        Else
                            variablematerial.Valor = Convert.ToString(rw.Cells(c.Name).Value)
                        End If
                        variablematerial.TipoValor = tipov
                    End If
                Next
            Else
                material = New Objeto(nombrematerial, rw.Index + 1)
                Analizador.ListaMateriales.Add(material)
                If dw Is dwVidrios Then
                    material.TipoObjeto = TiposElementos.Vidrios
                ElseIf dw Is dwPerfiles Then
                    material.TipoObjeto = TiposElementos.Perfiles
                ElseIf dw Is dwAccesorios Then
                    material.TipoObjeto = TiposElementos.Accesorios
                End If
                For Each c As DataGridViewColumn In dw.Columns
                    If Not TypeOf c Is DataGridViewButtonColumn And c.Visible Then
                        Dim tipov As TiposValores = TiposValores.Numerico
                        If ColumnastipoTexto.Contains(c.HeaderText) Then
                            tipov = TiposValores.Letras
                        End If
                        If TypeOf c Is DataGridViewComboBoxColumn Then
                            material.Parametros.Add(New Parametro(c.Index, c.HeaderText, String.Empty,
                                                                Convert.ToString(rw.Cells(c.Name).FormattedValue), tipov))
                        Else
                            material.Parametros.Add(New Parametro(c.Index, c.HeaderText, rw.Cells(c.Name).Tag,
                                                                Convert.ToString(rw.Cells(c.Name).Value), tipov))
                        End If
                    End If
                Next
            End If
            If listdesc.Count > 0 Then
                For Each d As DescuentoMaterial In listdesc

                    material.Descuentos.Add(New Formulador.Descuento(d.Id, d.IdDescuento,
                                                                     d.Descuento,
                                                                     d.Valor, d.Formula))
                Next
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message & "|" & Convert.ToString(ex.InnerException) & "Error verificando material",
                                ex.InnerException)
        End Try
    End Sub

#End Region

#Region "Elementos Carga Grafica"
    Private Sub bwcargas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwcargas.DoWork
        Try
            Application.Run(New FrmCargaProceso)
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub Recargar_Click(sender As Object, e As EventArgs)
        Try
            bwcargas.RunWorkerAsync()
            _dic.Clear()
            dwvariables.EndEdit()
            dwAccesorios.EndEdit()
            dwPerfiles.EndEdit()
            dwVidrios.EndEdit()
            dwotros.EndEdit()
            dwDescuentos.EndEdit()
            _analizador = New AnalizadorLexico
            For Each r As DataGridViewRow In dwvariables.Rows
                _dic.Add(Convert.ToString(r.Cells(variable.Index).Value),
                         Convert.ToString(r.Cells(valor.Index).Value))
            Next
            cargarPlantilla()
            cargarVariablesplantilla()
            cargarDescuentosGlobales()
            cargarMaterialesPlantilla()
            cargarDibujos()
            cargarObservaciones()
            EjecutarFormulas()
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        Catch ex As Exception
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Sub Aprobar_Click(sender As Object, e As EventArgs)
        Try
            Dim Check As New ClsAprobacionPlantilla
            Dim id As Integer = Check.TraerporidPlantilla(_idplantilla).Id
            If id <> 0 Then
                Check.Reaprobar(My.Settings.UsuarioActivo, _idplantilla, id)
            Else
                Check.Aprobar(My.Settings.UsuarioActivo, _idplantilla)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Activated(sender As Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsRecargar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnrecargar
            AddHandler btnsRecargar.Click, AddressOf Recargar_Click
            AddHandler btnsParcial.Click, AddressOf Aprobar_Click
            AddHandler btnsTotal.Click, AddressOf Aprobar_Click
            AddHandler btnguardar.Click, AddressOf Aprobar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsRecargar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnrecargar
            RemoveHandler btnsRecargar.Click, AddressOf Recargar_Click
            RemoveHandler btnsParcial.Click, AddressOf Aprobar_Click
            RemoveHandler btnsTotal.Click, AddressOf Aprobar_Click
            RemoveHandler btnguardar.Click, AddressOf Aprobar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwvariables_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dwvariables.CellEndEdit
        Try
            If e.RowIndex >= 0 Then
                Dim r As DataGridViewRow = dwvariables.Rows(e.RowIndex)
                Select Case Convert.ToInt32(dwvariables.Item(tipodato.Index, e.RowIndex).Value)
                    Case Is = ClsEnums.TiposDato.NUMERICO, ClsEnums.TiposDato.BOOLEANO

                        Dim ej As New Ejecutor()
                        Dim v = ej.ObtenerTokens(Convert.ToString(r.Cells(valor.Index).Value))
                        Dim val As String = ej.Parse(v)

                        If Not IsNumeric(val) Then
                            MsgBox("EL valor debe ser numérico. Verifique la información")
                            r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                            Return
                        Else
                            If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valorminimo.Index).Value)) Then
                                Dim vmin = ej.ObtenerTokens(Convert.ToString(r.Cells(valorminimo.Index).Value))
                                Dim valmin As String = ej.Parse(vmin)
                                If Convert.ToDecimal(val) < Convert.ToDecimal(valmin) Then
                                    MsgBox("El valor no debe ser menor que la restricción de valor mínimo. Verifique la información", MsgBoxStyle.Critical)
                                    r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                                    Return
                                End If
                            End If
                            If Not String.IsNullOrEmpty(Convert.ToString(r.Cells(valormaximo.Index).Value)) Then
                                Dim vmax = ej.ObtenerTokens(Convert.ToString(r.Cells(valormaximo.Index).Value))
                                Dim valmax As String = ej.Parse(vmax)
                                If Convert.ToDecimal(val) > Convert.ToDecimal(valmax) Then
                                    MsgBox("El valor no debe ser mayor que la restricción de valor máximo. Verifique la información", MsgBoxStyle.Critical)
                                    r.Cells(valor.Index).Value = r.Cells(valorminimo.Index).Value
                                    Return
                                End If
                            End If
                        End If
                    Case Is = ClsEnums.TiposDato.TEXTO

                    Case Is = ClsEnums.TiposDato.FECHA

                End Select
                RevisaryCrearVariableGeneral(r)
                EjecutarFormulas()
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmTesteadorPlantillas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _analizador = New AnalizadorLexico
            cargarPlantilla()
            cargarObservaciones()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmTesteadorPlantillas_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            cargarPlantilla()
            cargarVariablesplantilla()
            cargarDescuentosGlobales()
            cargarMaterialesPlantilla()
            cargarDibujos()
            cargarObservaciones()
            EjecutarFormulas()
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        Catch ex As Exception
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnvisibilidadcolumnas_Click(sender As Object, e As EventArgs) Handles btnvisibilidadcolumnas.Click
        Try
            Dim selector As New ControlesPersonalizados.GridFiltrado.FrmVisibilidadColumnas
            If tcmateriales.SelectedTab Is tpvidrio Then
                selector.Grid2 = dwVidrios
            ElseIf tcmateriales.SelectedTab Is tpperfileria Then
                selector.Grid2 = dwPerfiles
            ElseIf tcmateriales.SelectedTab Is tpaccesorios Then
                selector.Grid2 = dwAccesorios
            ElseIf tcmateriales.SelectedTab Is tpotros Then
                selector.Grid2 = dwotros
            End If
            selector.Location = MousePosition
            selector.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dw_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dwVidrios.CellValueChanged, dwPerfiles.CellValueChanged, dwAccesorios.CellValueChanged, dwotros.CellValueChanged
        Try
            Dim dw As DataGridView = DirectCast(sender, DataGridView)
            If e.RowIndex >= 0 Then
                If (dw Is dwVidrios And e.ColumnIndex = vvisibilidad.Index) Or (dw Is dwPerfiles And e.ColumnIndex = pvisibilidad.Index) Or
                (dw Is dwAccesorios And e.ColumnIndex = avisibilidad.Index) Or (dw Is dwotros And e.ColumnIndex = ovisibilidad.Index) Then
                    dw.Rows(e.RowIndex).Visible = Convert.ToBoolean(dw.Item(e.ColumnIndex, e.RowIndex).Value)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

End Class