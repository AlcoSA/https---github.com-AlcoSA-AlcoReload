Imports Formulador
Imports ReglasNegocio
Imports ControlesPersonalizados.Estructurador
Public Class CargaDibujos

    Public Function CrearDibujos(idpadre As Integer,
                          datos As List(Of Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal)),
                          esduplicado As Boolean, tipo_carga As ClsEnums.TipoCarga) As RegionEstructuras
        CrearDibujos = Nothing
        Try
            Dim listaestructura As List(Of DibujoPadreCotiza) = Nothing
            Select Case tipo_carga
                Case ClsEnums.TipoCarga.COTIZA
                    Dim dibujoscotiza As New ClsDibujosItemsCotiza
                    listaestructura = dibujoscotiza.TraerxIdITemCotiza(idpadre)
                Case ClsEnums.TipoCarga.ORDENPEDIDO
                    Dim dibujoscotiza As New ClsDibujosItemsOps
                    listaestructura = dibujoscotiza.TraerxIdITemOp(idpadre)
            End Select
            If listaestructura.Count > 0 Then
                Dim dib As DibujoPadreCotiza = listaestructura.First(Function(x) x.Nivel = 0)
                Dim est As New ControlesPersonalizados.Estructurador.RegionEstructuras(dib.X, dib.Y, dib.Ancho, dib.Alto)
                est.OrientacionEstructura = dib.Orientacion
                Dim tp As Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal) = datos.FirstOrDefault(Function(d) d.Item1 = dib.IdHijo)
                If tp IsNot Nothing Then
                    est.Ancho_Real = tp.Item4
                    est.Alto_Real = tp.Item5
                End If
                If dib.DXF.Equals("Pared") Then
                    est.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.BASICO
                ElseIf dib.DXF.Equals("Ele_Arriba") Then
                    est.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_ARRIBA
                ElseIf dib.DXF.Equals("Ele_Izquierda") Then
                    est.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_IZQUIERDA
                ElseIf dib.DXF.Equals("Ele_Abajo") Then
                    est.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_ABAJO
                ElseIf dib.DXF.Equals("Ele_Derecha") Then
                    est.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_DERECHA
                ElseIf dib.DXF.Split("&")(0).Equals("Perfil") Then
                    est.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.PERFIL
                    est.Referencia_Perfil = dib.DXF.Split("-")(1)
                    est.Acabado_Perfil = dib.DXF.Split("-")(2)
                Else
                    Dim an As AnalizadorLexico = tp.Item2
                    If an Is Nothing Then
                        Dim cp As New CargasPlantilla
                        cp.CargarPlantilla(dib.IdHijo, an, ClsEnums.TipoCarga.COTIZA)
                    End If
                    Dim vn As New DXF.Dibujante_DXF.Ventana(an, New SizeF(400, 400))
                    vn.LeerDxfPersonalizado(dib.DXF)
                    est.Arquitecto = vn
                    est.Id_Hijo_Owner = 0
                    est.Index_Hijo_Owner = 0
                End If
                CargarDibujos(listaestructura, dib, est, datos, True)
                CrearDibujos = est
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function

    Private Function CargarDibujos(lista As List(Of DibujoPadreCotiza), item As DibujoPadreCotiza,
                                  creg As ControlesPersonalizados.Estructurador.RegionEstructuras,
                                  datos As List(Of Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal)),
                                  esduplicado As Boolean) As RegionEstructuras
        Try
            Dim lnew As List(Of DibujoPadreCotiza) = lista.Where(Function(x) x.IdContendor = item.Id).ToList()
            lnew.ForEach(Sub(e)
                             Dim rg As New ControlesPersonalizados.Estructurador.RegionEstructuras(e.X, e.Y, e.Ancho, e.Alto)
                             rg.OrientacionEstructura = e.Orientacion
                             If e.DXF.Equals("Pared") Then
                                 rg.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.BASICO
                             ElseIf e.DXF.Equals("Ele_Arriba") Then
                                 rg.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_ARRIBA
                             ElseIf e.DXF.Equals("Ele_Izquierda") Then
                                 rg.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_IZQUIERDA
                             ElseIf e.DXF.Equals("Ele_Abajo") Then
                                 rg.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_ABAJO
                             ElseIf e.DXF.Equals("Ele_Derecha") Then
                                 rg.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.ELE_DERECHA
                             ElseIf e.DXF.Split("&")(0).Equals("Perfil") Then
                                 Dim tp As Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal) =
                                 datos.FirstOrDefault(Function(d) d.Item1 = e.IdHijo)
                                 rg.Ancho_Real = tp.Item4
                                 rg.Alto_Real = tp.Item5
                                 rg.TipoEstructura = ControlesPersonalizados.Estructurador.Tipo_Estructura.PERFIL
                                 rg.Referencia_Perfil = e.DXF.Split("&")(1)
                                 rg.Acabado_Perfil = e.DXF.Split("&")(2)
                                 If Not esduplicado Then
                                     rg.Id_Hijo_Owner = e.IdHijo
                                 End If
                                 rg.Index_Hijo_Owner = tp.Item3
                             Else
                                 Dim tp As Tuple(Of Integer, AnalizadorLexico, Integer, Decimal, Decimal) =
                                 datos.FirstOrDefault(Function(d) d.Item1 = e.IdHijo)
                                 Dim an As AnalizadorLexico = tp.Item2
                                 rg.Ancho_Real = tp.Item4
                                 rg.Alto_Real = tp.Item5
                                 If an Is Nothing Then
                                     Dim cp As New CargasPlantilla
                                     cp.CargarPlantilla(e.IdHijo, an, ClsEnums.TipoCarga.COTIZA)
                                 End If
                                 Dim vn As New DXF.Dibujante_DXF.Ventana(an, New SizeF(400, 400))
                                 vn.LeerDxfPersonalizado(e.DXF)
                                 rg.Arquitecto = vn
                                 If Not esduplicado Then
                                     rg.Id_Hijo_Owner = e.IdHijo
                                 End If
                                 rg.Index_Hijo_Owner = tp.Item3
                             End If
                             creg.Estructuras.Add(rg)
                             CargarDibujos = CargarDibujos(lista, e, rg, datos, esduplicado)
                         End Sub)
            Return creg
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function crearBitMap(rg As RegionEstructuras) As Byte()
        Try
            Dim util As New ClsUtilidadesImagenes
            Dim bmp As New Bitmap(700, 700)
            Dim g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
            rg.RegionControlContenedor = New RectangleF(0, 0, bmp.Width, bmp.Height - 2)
            HacerDibujo(rg, g)
            crearBitMap = util.ImagenaArregloBytes(bmp)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Private Sub HacerDibujo(estructura As RegionEstructuras, g As Graphics)
        Try
            estructura.Construir(g, False)
            estructura.Estructuras.ToList.ForEach(Sub(i)
                                                      HacerDibujo(i, g)
                                                  End Sub)
        Catch ex As Exception
            Throw New Exception("La operación realizar dibujo tiene errores: " & ex.Message, ex.InnerException)
        End Try
    End Sub

End Class
