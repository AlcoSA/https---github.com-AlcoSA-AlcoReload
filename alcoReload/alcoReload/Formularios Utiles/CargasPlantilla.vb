Imports ReglasNegocio
Imports Formulador
Public Class CargasPlantilla
#Region "Variables"
    Private _isFromCotiza As Boolean = False
#End Region
#Region "Propiedades"
    Public Property isFromCotiza As Boolean
        Get
            Return _isFromCotiza
        End Get
        Set(ByVal value As Boolean)
            _isFromCotiza = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Public Sub CargarPlantilla(idhijo As Integer, ByRef analizador As AnalizadorLexico, tipocarga As ClsEnums.TipoCarga)
        Try
            _isFromCotiza = True
            If analizador Is Nothing Then analizador = New AnalizadorLexico
            analizador = CargaryCrearCrearVariableGeneral(idhijo, analizador, tipocarga)
            analizador = cargaryCrearDescuentosGlobales(idhijo, analizador, tipocarga)
            analizador = CargaryCrearMaterial(idhijo, analizador, tipocarga)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub CargarPlantillaOriginal(idplantilla As Integer,
                                       ByRef analizador As AnalizadorLexico,
                                       Optional dic_valores As Dictionary(Of String, String) = Nothing)
        Try
            _isFromCotiza = False
            If analizador Is Nothing Then analizador = New AnalizadorLexico
            analizador = CrearVariablesdesdePlantilla(idplantilla, analizador, dic_valores)
            analizador = cargaryCrearDescuentosGlobalesdesdePlantilla(idplantilla, analizador)
            analizador = VerificaryCrearMaterialdesdePlantilla(idplantilla, analizador)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#Region "Variables"
    Public Function CrearVariablesdesdePlantilla(idplantilla As Integer, analizador As AnalizadorLexico, Optional dic_valores As Dictionary(Of String, String) = Nothing) As AnalizadorLexico
        Try
            Dim valorvaria As String = String.Empty
            Dim valminimo As String = String.Empty
            Dim valmaximo As String = String.Empty
            Dim mvarplantilla As New ClsVariablesPlantillas
            Dim lvars As List(Of VariablePlantilla) = mvarplantilla.TraerxIdPlantilla(idplantilla)
            lvars.ForEach(Sub(v)
                              Select Case v.TipoDato
                                  Case Is = ClsEnums.TiposDato.NUMERICO
                                      valminimo = If(String.IsNullOrEmpty(v.ValorMinimo) Or v.ValorMinimo.StartsWith("="), 0, v.ValorMinimo)
                                      valmaximo = If(String.IsNullOrEmpty(v.ValorMaximo) Or v.ValorMaximo.StartsWith("="), Int32.MaxValue, v.ValorMaximo)
                                  Case Is = ClsEnums.TiposDato.TEXTO
                                      valminimo = If(v.ValorMinimo.StartsWith("="), "", v.ValorMinimo)
                                      valmaximo = If(v.ValorMaximo.StartsWith("="), "", v.ValorMaximo)
                                  Case Is = ClsEnums.TiposDato.BOOLEANO
                                      valminimo = 0
                                      valmaximo = 1
                                  Case Is = ClsEnums.TiposDato.FECHA
                                      valminimo = If(String.IsNullOrEmpty(v.ValorMinimo) Or v.ValorMinimo.StartsWith("="), Date.MinValue.ToString(), v.ValorMinimo)
                                      valmaximo = If(String.IsNullOrEmpty(v.ValorMaximo) Or v.ValorMaximo.StartsWith("="), Date.MaxValue.ToString(), v.ValorMaximo)
                              End Select

                              If dic_valores IsNot Nothing Then
                                  If dic_valores.ContainsKey(v.Variable) Then
                                      dic_valores.TryGetValue(v.Variable, valorvaria)
                                  Else
                                      valorvaria = valminimo
                                  End If
                              Else
                                  valorvaria = valminimo
                              End If
                              Dim param As Parametro
                              Dim valvar As New ClsValoresVariables
                              If analizador.ListaVariables.Contains(v.Variable) Then
                                  param = analizador.ListaVariables.Item(v.Variable)
                                  param.Restricciones.Clear()
                                  If Not String.IsNullOrEmpty(v.ValorMinimo) Then
                                      param.Restricciones.Add(New Restriccion("MINIMO", valminimo, v.TipoDato))
                                  End If
                                  If Not String.IsNullOrEmpty(v.ValorMaximo) Then
                                      param.Restricciones.Add(New Restriccion("MAXIMO", valmaximo, v.TipoDato))
                                  End If
                                  param.TipoValor = v.TipoDato
                                  param.Valor = valorvaria
                                  param.Formula = valorvaria
                              Else
                                  param = New Parametro(v.Variable, valorvaria, valorvaria, v.TipoDato)
                                  param.Id = v.IdVariable
                                  If Convert.ToString(v.ValorMinimo).StartsWith("=") Then
                                      param.Restricciones.Add(New Restriccion("MINIMO", v.ValorMinimo,
                                                                                  valminimo, v.TipoDato))
                                  Else
                                      param.Restricciones.Add(New Restriccion("MINIMO",
                                                                              valminimo, v.TipoDato))
                                  End If
                                  If Convert.ToString(v.ValorMaximo).StartsWith("=") Then
                                      param.Restricciones.Add(New Restriccion("MAXIMO", v.ValorMaximo,
                                                                                  valmaximo, v.TipoDato))
                                  Else
                                      param.Restricciones.Add(New Restriccion("MAXIMO",
                                                                              valmaximo, v.TipoDato))
                                  End If
                                  analizador.ListaVariables.Add(param)
                              End If
                              Dim lvvar As List(Of ValorVariable) = valvar.TraerxIdVariable(v.IdVariable)
                              param.PosiblesValores.Clear()
                              param.PosiblesValores.AddRange(lvvar.Select(Function(x) x.Valor))
                          End Sub)
            CrearVariablesdesdePlantilla = analizador
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function CargaryCrearCrearVariableGeneral(idhijo As Integer,
                                                            analizador As AnalizadorLexico,
                                                            tipo_carga As ClsEnums.TipoCarga) As AnalizadorLexico
        Try
            Dim valorvaria As String = String.Empty
            Dim valminimo As String = String.Empty
            Dim valmaximo As String = String.Empty
            Dim lvars As List(Of VariableItemCotiza) = New List(Of VariableItemCotiza)
            Select Case tipo_carga
                Case ClsEnums.TipoCarga.COTIZA
                    Dim mvarhijov As New ClsVariablesPlantillaCotiza
                    lvars = mvarhijov.TraerxIdItemCotiza(idhijo)
                Case ClsEnums.TipoCarga.ORDENPEDIDO
                    Dim mvarhijov As New ClsVariablesPlantillaOped
                    lvars = mvarhijov.TraerxIdItemOp(idhijo)
                Case ClsEnums.TipoCarga.ORDENPRODUCCION
                    Dim mvarhijov As New ClsVariablesPlantillaOrdenProd
                    lvars = mvarhijov.TraerxIdItemOp(idhijo)
            End Select
            lvars.ForEach(Sub(v)
                              Select Case v.TipoDato
                                  Case Is = ClsEnums.TiposDato.NUMERICO
                                      valminimo = If(String.IsNullOrEmpty(v.ValorMinimo) Or v.ValorMinimo.StartsWith("="), 0, v.ValorMinimo)
                                      valmaximo = If(String.IsNullOrEmpty(v.ValorMaximo) Or v.ValorMaximo.StartsWith("="), Int32.MaxValue, v.ValorMaximo)
                                  Case Is = ClsEnums.TiposDato.TEXTO
                                      valminimo = If(v.ValorMinimo.StartsWith("="), "", v.ValorMinimo)
                                      valmaximo = If(v.ValorMaximo.StartsWith("="), "", v.ValorMaximo)
                                  Case Is = ClsEnums.TiposDato.BOOLEANO
                                      valminimo = 0
                                      valmaximo = 1
                                  Case Is = ClsEnums.TiposDato.FECHA
                                      valminimo = If(String.IsNullOrEmpty(v.ValorMinimo) Or v.ValorMinimo.StartsWith("="), Date.MinValue.ToString(), v.ValorMinimo)
                                      valmaximo = If(String.IsNullOrEmpty(v.ValorMaximo) Or v.ValorMaximo.StartsWith("="), Date.MaxValue.ToString(), v.ValorMaximo)
                              End Select
                              If String.IsNullOrEmpty(v.Valor) Then
                                  valorvaria = valminimo
                              Else
                                  valorvaria = v.Valor
                              End If
                              Dim param As Parametro
                              Dim valvar As New ClsValoresVariables
                              If analizador.ListaVariables.Contains(v.NombreVariable) Then
                                  param = analizador.ListaVariables.Item(v.NombreVariable)
                                  param.Restricciones.Clear()
                                  param.Restricciones.Add(New Restriccion("MINIMO", v.Minimo, valminimo, v.TipoDato))
                                  param.Restricciones.Add(New Restriccion("MAXIMO", v.Maximo, valmaximo, v.TipoDato))
                                  param.TipoValor = v.TipoDato
                                  param.Valor = valorvaria
                                  param.Formula = valorvaria
                              Else
                                  param = New Parametro(v.NombreVariable, String.Empty, valorvaria, v.TipoDato)
                                  param.Id = v.IdVariable
                                  param.Restricciones.Add(New Restriccion("MINIMO", v.Minimo, valminimo, v.TipoDato))
                                  param.Restricciones.Add(New Restriccion("MAXIMO", v.Maximo, valmaximo, v.TipoDato))
                                  analizador.ListaVariables.Add(param)
                              End If
                              Dim lvvar As List(Of ValorVariable) = valvar.TraerxIdVariable(v.IdVariable)
                              param.PosiblesValores.AddRange(lvvar.Select(Function(x) x.Valor))
                          End Sub)
            CargaryCrearCrearVariableGeneral = analizador
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region

#Region "Descuentos Globales"
    Public Function cargaryCrearDescuentosGlobalesdesdePlantilla(idplantilla As Integer, analizador As AnalizadorLexico) As AnalizadorLexico
        Try
            Dim listDescuentosGlobales As New List(Of descuentoGlobal)
            Dim mdescuentosGlobales = New ClsDescuentosGlobales
            listDescuentosGlobales = mdescuentosGlobales.TraerxIdPlantilla(idplantilla)
            cargaryCrearDescuentosGlobalesdesdePlantilla = cargaryCrearDescuentos(listDescuentosGlobales, analizador)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function cargaryCrearDescuentosGlobales(idhijo As Integer,
                                                          ByRef analizador As AnalizadorLexico,
                                                              tipo_carga As ClsEnums.TipoCarga) As AnalizadorLexico
        Try
            Dim listDescuentosGlobales As List(Of descuentoGlobal) = Nothing
            Select Case tipo_carga
                Case ClsEnums.TipoCarga.COTIZA
                    Dim mdescuentosGlobales As New ClsDescuentosGeneralesPlantillaCotiza
                    listDescuentosGlobales = mdescuentosGlobales.TraerporIdHijoCotiza(idhijo)
                Case ClsEnums.TipoCarga.ORDENPEDIDO
                    Dim mdescuentosGlobales As New ClsDescuentosGeneralesPlantillaOped
                    listDescuentosGlobales = mdescuentosGlobales.TraerporIdHijoOP(idhijo)
                Case ClsEnums.TipoCarga.ORDENPRODUCCION
                    Dim mdescuentosGlobales As New ClsDescuentosGeneralesPlantillaOrdenProd
                    listDescuentosGlobales = mdescuentosGlobales.TraerporIdHijoOP(idhijo)
            End Select
            cargaryCrearDescuentos(listDescuentosGlobales, analizador)
            cargaryCrearDescuentosGlobales = analizador
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Function cargaryCrearDescuentos(listadescuentos As List(Of descuentoGlobal),
                                        analizador As AnalizadorLexico) As AnalizadorLexico
        Try
            listadescuentos.ForEach(Sub(var)
                                        analizador.ListaDescuentos.Add(New Formulador.Descuento(var.Id,
                                                                                var.IdDescuento,
                                                                                 var.Descuento,
                                                                                 var.Valor,
                                                                                 var.Formula))
                                    End Sub)
            Return analizador
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region

#Region "Materiales"
    Public Function VerificaryCrearMaterialdesdePlantilla(idplantilla As Integer, ByRef analizador As AnalizadorLexico) As AnalizadorLexico
        Try
            Dim cmaterial As New ClsMaterialesPlantilla
            Dim cArticulo As New ClsArticulos
            Dim lmateriales As List(Of MaterialPlantilla) = cmaterial.TraerxIdplantilla(idplantilla)
            analizador.ListaMateriales.Clear()
            For i = 0 To lmateriales.Count - 1
                Dim nmat As String = String.Empty
                Select Case lmateriales(i).IdFamiliaMaterial
                    Case Is = ClsEnums.FamiliasMateriales.ACCESORIOS
                        nmat = "ACCESORIOS"
                    Case Is = ClsEnums.FamiliasMateriales.PERFILERIA
                        nmat = "PERFIL"
                    Case Is = ClsEnums.FamiliasMateriales.VIDRIO
                        nmat = "VIDRIO"
                    Case Is = ClsEnums.FamiliasMateriales.OTROS
                        nmat = "OTROS"
                End Select
                Dim nuevomaterial As New Objeto(nmat, lmateriales(i).Indicador)
                nuevomaterial.Id = lmateriales(i).Id
                nuevomaterial.TipoObjeto = lmateriales(i).IdFamiliaMaterial
                nuevomaterial.Costo_Instalacion_Unidad = lmateriales(i).Costo_Instalacion
                analizador.ListaMateriales.Add(nuevomaterial)
                Dim dic As Dictionary(Of String, String) = lmateriales(i).Formulacion(True)
                dic.ToList.ForEach(Sub(f)
                                       If f.Value.StartsWith("=") Then
                                           nuevomaterial.Parametros.Add(New Parametro(f.Key, f.Value,
                                                                            0, TiposValores.Letras))
                                       Else
                                           nuevomaterial.Parametros.Add(New Parametro(f.Key, String.Empty,
                                                    f.Value, TiposValores.Letras))
                                       End If
                                   End Sub)
                Dim articulo As New ClsArticulos

                Dim listadescuentos As List(Of DescuentoMaterial)
                Dim mdescuentosmaterial As New ClsDescuentosMaterial
                listadescuentos = mdescuentosmaterial.TraerxIdmaterial(lmateriales(i).Id)
                listadescuentos.ForEach(Sub(d)
                                            If Not (nuevomaterial.Descuentos.Contains(d.Descuento)) Then
                                                nuevomaterial.Descuentos.Add(New Formulador.Descuento(d.Id, d.IdDescuento,
                                                                                                      d.Descuento, d.Valor, d.Formula))
                                            End If
                                        End Sub)
            Next
            VerificaryCrearMaterialdesdePlantilla = analizador
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function CargaryCrearMaterial(idhijo As Integer,
                                                       ByRef analizador As AnalizadorLexico,
                                                       tipo_carga As ClsEnums.TipoCarga) As AnalizadorLexico
        Try

            Dim lmateriales As List(Of MaterialPlantillaMovimiento) = Nothing
            Select Case tipo_carga
                Case ClsEnums.TipoCarga.COTIZA
                    Dim cmaterial As New ClsMaterialesPlantillaCotiza
                    lmateriales = cmaterial.TraerporIdHijoCotiza(idhijo)
                Case ClsEnums.TipoCarga.ORDENPEDIDO
                    Dim cmaterial As New ClsMaterialesPlantillaOped
                    lmateriales = cmaterial.TraerporIdHijoOp(idhijo)
                Case ClsEnums.TipoCarga.ORDENPRODUCCION
                    Dim cmaterial As New ClsMaterialesPlantillaOrdenProd
                    lmateriales = cmaterial.TraerporIdHijoOp(idhijo)
            End Select
            analizador.ListaMateriales.Clear()
            For i = 0 To lmateriales.Count - 1
                Dim nmat As String = String.Empty
                Select Case lmateriales(i).IdFamiliaMaterial
                    Case Is = ClsEnums.FamiliasMateriales.ACCESORIOS
                        nmat = "ACCESORIOS"
                    Case Is = ClsEnums.FamiliasMateriales.PERFILERIA
                        nmat = "PERFIL"
                    Case Is = ClsEnums.FamiliasMateriales.VIDRIO
                        nmat = "VIDRIO"
                    Case Is = ClsEnums.FamiliasMateriales.OTROS
                        nmat = "OTROS"
                End Select
                Dim nuevomaterial As New Objeto(nmat, lmateriales(i).Indicador)
                nuevomaterial.Id = lmateriales(i).IditemOriginal
                nuevomaterial.TipoObjeto = lmateriales(i).IdFamiliaMaterial
                nuevomaterial.Utilizar = lmateriales(i).Utilizar
                nuevomaterial.Desperdicio = lmateriales(i).desperdicio
                nuevomaterial.Costo_Instalacion_Unidad = lmateriales(i).Costo_Instalacion
                analizador.ListaMateriales.Add(nuevomaterial)
                Dim dic As Dictionary(Of String, String()) = lmateriales(i).Formulacion_Formula_Valor(True)
                dic.ToList.ForEach(Sub(f)
                                       nuevomaterial.Parametros.Add(New Parametro(f.Key, f.Value(0),
                                                                            f.Value(1), TiposValores.Letras))
                                   End Sub)
                Dim listadescuentos As List(Of DescuentoMaterial) = New List(Of DescuentoMaterial)
                Select Case tipo_carga
                    Case ClsEnums.TipoCarga.COTIZA
                        Dim mdescuentosmaterial As New ClsDescuentosMaterialPlantillaCotiza
                        listadescuentos = mdescuentosmaterial.TraerxIdMaterialHijoCotiza(lmateriales(i).Id)
                    Case ClsEnums.TipoCarga.ORDENPEDIDO
                        Dim mdescuentosmaterial As New ClsDescuentosMaterialPlantillaOped
                        listadescuentos = mdescuentosmaterial.TraerxIdMaterialHijoOp(lmateriales(i).Id)
                    Case ClsEnums.TipoCarga.ORDENPRODUCCION
                        Dim mdescuentosmaterial As New ClsDescuentosMaterialPlantillaOrdenProd
                        listadescuentos = mdescuentosmaterial.TraerxIdMaterialHijoOp(lmateriales(i).Id)
                End Select
                listadescuentos.ForEach(Sub(d)
                                            If Not (nuevomaterial.Descuentos.Contains(d.Descuento)) Then

                                                nuevomaterial.Descuentos.Add(New Formulador.Descuento(d.Id, d.IdDescuento, d.Descuento,
                                                                                                      d.Valor, d.Formula))
                                            End If
                                        End Sub)
            Next
            Return analizador
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
    Public Sub ValorarAnalizador(ByRef analizador As AnalizadorLexico,
                                 id_Cotiza As Integer, version_Acabado As Integer,
                                 version_nivel As Integer, version_kilo_aluminio As Integer,
                                version_vidrio As Integer,
                                version_accesorios As Integer,
                                version_otros As Integer)
        Try
            analizador.ValorarRestricciones()
            analizador.ValorarElementosDescuentos()
            analizador.ValorarElementosMaterial()
            CalcularPreciosPlantilla(analizador, id_Cotiza, version_Acabado, version_nivel, version_kilo_aluminio,
                                     version_vidrio, version_accesorios, version_otros)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ValorarAnalizador(ByRef analizador As AnalizadorLexico)
        Try
            analizador.ValorarRestricciones()
            analizador.ValorarElementosDescuentos()
            analizador.ValorarElementosMaterial()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#Region "Costos"
    Public Sub CalcularPreciosPlantilla(ByRef analizador As AnalizadorLexico,
                                        idcotiza As Integer,
                                        version_Acabado As Integer, version_nivel As Integer, version_kilo_aluminio As Integer,
                                        version_vidrio As Integer,
                                        version_accesorios As Integer,
                                        version_otros As Integer)
        Try
            Dim costoVidrio As New ClsCostoVidrio
            Dim costoAccesorio As New ClsCostoAccesorio
            Dim costoaluminio As New CostoArticulo.ClsCostoAluminio
            Dim costootro As New ClsCostoOtrosArticulos
            Dim mArticulo As New ClsArticulos
            analizador.ListaMateriales.ToList.ForEach(Sub(material)
                                                          If Convert.ToBoolean(Convert.ToInt32(material.Parametros.Item("VISIBILIDAD").Valor)) And material.Utilizar Then
                                                              material.Desperdicio = CDec(IIf(_isFromCotiza, material.Desperdicio, mArticulo.TraerxReferencia(material.Parametros.Item("REFERENCIA").Valor).porcDesperdicio))

                                                              Dim pxuni As Decimal = Convert.ToDecimal(If(material.Parametros.Item("PXUNIDAD").Valor = "", 0, material.Parametros.Item("PXUNIDAD").Valor))
                                                              Dim fact As Decimal = 1 + (material.Desperdicio / 100)
                                                              Dim costo_base As Decimal = 0
                                                              Dim cantidad As Decimal = Convert.ToDecimal(material.Parametros.Item("CANTIDAD").Valor)
                                                              Select Case material.TipoObjeto
                                                                  Case TiposElementos.Vidrios
                                                                      Dim anc = Convert.ToDecimal(material.Parametros.Item("ANCHO").Valor) / 1000
                                                                      Dim alt = Convert.ToDecimal(material.Parametros.Item("ALTO").Valor) / 1000
                                                                      costo_base = costoVidrio.TraerCostoxReferenciaAcabadoEspesor(material.Parametros.Item("REFERENCIA").Valor,
                                                                                                                                             material.Parametros.Item("ESPESOR").Valor,
                                                                                                                                             material.Parametros.Item("COLOR").Valor, version_vidrio) + material.Costo_Instalacion_Unidad
                                                                      If costo_base = 0 Then
                                                                          Dim mCostoVidTemp As New ClsCostoVidrioTemporal
                                                                          costo_base = mCostoVidTemp.TraerCostoxReferencia(idcotiza, material.Parametros.Item("REFERENCIA").Valor,
                                                                                                                                             material.Parametros.Item("ESPESOR").Valor,
                                                                                                                                             material.Parametros.Item("COLOR").Valor)
                                                                      End If
                                                                      material.Costo_Unitario = Math.Round(costo_base * anc * alt * fact * pxuni, 0)
                                                                      material.Costo_Total = material.Costo_Unitario * cantidad
                                                                      material.VlrDesperdicio = costo_base * anc * alt * (fact - 1) * pxuni
                                                                  Case TiposElementos.Perfiles
                                                                      costo_base = costoaluminio.TraerCostoxReferenciayAcabado(material.Parametros.Item("REFERENCIA").Valor,
                                                                                                                               material.Parametros.Item("ACABADO").Valor, version_Acabado, version_nivel, version_kilo_aluminio) + material.Costo_Instalacion_Unidad
                                                                      Dim dimension As Decimal = CDec(material.Parametros("DIMENSION").Valor) / 1000
                                                                      material.Costo_Unitario = Math.Round((costo_base * dimension * pxuni * fact), 0)
                                                                      material.Costo_Total = material.Costo_Unitario * cantidad
                                                                      material.VlrDesperdicio = costo_base * dimension * (fact - 1) * pxuni
                                                                  Case TiposElementos.Accesorios
                                                                      Dim mCostoAccesorios As New ClsCostoAccesorio
                                                                      costo_base = costoAccesorio.TraerCostoxReferencia(material.Parametros.Item("REFERENCIA").Valor, version_accesorios) + material.Costo_Instalacion_Unidad
                                                                      Dim dimension As Decimal = CDec(material.Parametros("DIMENSION").Valor) / 1000
                                                                      If dimension > 0 Then
                                                                          material.Costo_Unitario = Math.Round((costo_base * dimension * pxuni * fact), 0)
                                                                          material.Costo_Total = material.Costo_Unitario * cantidad
                                                                          material.VlrDesperdicio = costo_base * dimension * (fact - 1) * pxuni
                                                                      Else
                                                                          material.Costo_Unitario = (costo_base * pxuni * fact)
                                                                          material.Costo_Total = Math.Round(material.Costo_Unitario * cantidad, 0)
                                                                          material.VlrDesperdicio = costo_base * pxuni * (fact - 1)
                                                                      End If

                                                                  Case TiposElementos.Otros
                                                                      costo_base = costootro.TraerxReferencia(material.Parametros.Item("REFERENCIA").Valor, version_otros) + material.Costo_Instalacion_Unidad
                                                                      material.Costo_Unitario = Math.Round((costo_base * pxuni * fact), 0)
                                                                      material.Costo_Total = material.Costo_Unitario * cantidad
                                                                      material.VlrDesperdicio = costo_base * pxuni * (fact - 1)
                                                              End Select
                                                              material.Costo_Instalacion_Total = material.Costo_Instalacion_Unidad * cantidad
                                                          Else
                                                              material.Costo_Unitario = 0
                                                              material.Costo_Total = 0
                                                              material.VlrDesperdicio = 0
                                                          End If
                                                      End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
#End Region
End Class
