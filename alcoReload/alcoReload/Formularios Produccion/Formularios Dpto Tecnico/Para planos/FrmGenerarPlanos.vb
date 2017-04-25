Imports DatagridTreeView
Imports Formulador
Imports ReglasNegocio
Imports Informes
Public Class FrmGenerarPlanos
#Region "vars"
    Private _idorden As Integer = 0
    Private _curid As Integer = 0
    Private r_sel As DataGridViewRow = Nothing
#End Region
#Region "props"
    Public Property IdOrdenPedido As Integer
        Get
            Return _idorden
        End Get
        Set(value As Integer)
            _idorden = value
        End Set
    End Property
    Public Property IdOrdenProduccion As Integer
        Get
            Return _curid
        End Get
        Set(value As Integer)
            _curid = value
        End Set
    End Property
#End Region
#Region "procs"
    Private Sub cargacombositems()
        Try
#Region "Cargar listas"
            Dim macabado As New ClsAcabados
            Dim mvidrio As New ClsArticulos
            Dim mespesor As New ClsEspesores

            Dim lAcabados = macabado.TraerTodos().ToList
            Dim lVidrios = mvidrio.TraerTodos.Where(Function(a) a.IdFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO).ToList
            Dim lEspesores = mespesor.TraerTodos.ToList
#End Region
#Region "Desplegables Items Op"
            vidrio.DisplayMember = "Referencia"
            vidrio.ValueMember = "Id"
            vidrio.DataSource = lVidrios
            colorvidrio.DisplayMember = "Prefijo"
            colorvidrio.ValueMember = "Id"
            colorvidrio.DataSource = lAcabados.Where(Function(a) (a.Id = 32 Or a.idFamiliaMaterial = ClsEnums.FamiliasMateriales.VIDRIO) And CInt(a.IdEstado) = ClsEnums.Estados.ACTIVO).ToList
            acabado.DisplayMember = "Prefijo"
            acabado.ValueMember = "Id"
            acabado.DataSource = lAcabados.Where(Function(a) (a.Id = 32 Or a.idFamiliaMaterial = ClsEnums.FamiliasMateriales.PERFILERIA) And CInt(a.IdEstado) = ClsEnums.Estados.ACTIVO).ToList
            espesor.DisplayMember = "Prefijo"
            espesor.ValueMember = "Id"
            espesor.DataSource = lEspesores
#End Region
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub cargarbase()
        Try
            Dim m_oped As New ClsOrdenDePedido
            Dim oped As OrdenDePedido = m_oped.TraerxIdOrden(_idorden)
            lbcliente.Text = oped.Cliente
            lbobra.Text = oped.Obra
            lbcodobra.Text = oped.Nit & "-" & oped.CodObra
            lbfechacreacion.Text = oped.FechaCreacion.ToString("dd/MM/yyyy")
            Dim cot As New cotizaciones.ClsCostizaciones
            Dim carga_plantillas As New CargasPlantilla
            Dim m_padoprod As New ClsPadreOrdenProd
            Dim l_padoprod As List(Of PadreOrdenProd) = m_padoprod.TraerxIdOrdenPed(_idorden)
            Dim m_hijoped As New ClsItemsHijoOped
            Dim m_hijoprod As New ClsHijosOrdenProd
            Dim l_hijoprod As List(Of HijoOrdenProd) = Nothing
            l_padoprod.ForEach(Sub(p)
                                   Dim n As New DataGridViewTreeNode
                                   dwItem.Nodes.Add(n)
                                   n.Cells(Id.Index).Value = p.Id
                                   n.Cells(idordenped.Index).Value = p.IdOrdenped
                                   n.Cells(idarticulo.Index).Value = 0
                                   n.Cells(ubicacion.Index).Value = p.ubicacion
                                   n.Cells(descripcion.Index).Value = p.descripcion
                                   n.Cells(observaciones.Index).Value = p.Observaciones
                                   n.Cells(anchovano.Index).Value = p.anchoRequerido
                                   n.Cells(anchofabricacion.Index).Value = p.AnchoFabricacion
                                   n.Cells(anchooriginal.Index).Value = p.Ancho
                                   n.Cells(altovano.Index).Value = p.AltoRequerido
                                   n.Cells(altofabricacion.Index).Value = p.AltoFabricacion
                                   n.Cells(altooriginal.Index).Value = p.Alto
                                   n.Cells(cantidad.Index).Value = p.CantidadRequerida
                                   n.Cells(cantidadoriginal.Index).Value = p.Cantidad
                                   n.Cells(piezasxunidad.Index).Value = p.PiezasxUnidadRequeridas
                                   n.Cells(vidrio.Index).Value = p.IdVidrio
                                   n.Cells(acabado.Index).Value = p.IdAcabadoPerfil
                                   n.Cells(colorvidrio.Index).Value = p.idColorVidrio
                                   n.Cells(espesor.Index).Value = p.IdEspesor
                                   n.Cells(tipoitem.Index).Value = 0
                                   n.Cells(puntos.Index).Value = 0
                                   n.Cells(especial.Index).Value = p.Imagen
                                   n.Cells(idestado.Index).Value = p.IdEstado
                                   If _curid > 0 Then
                                       l_hijoprod = m_hijoprod.TraerporIdPadreOrdenProduccion(p.Id)
                                   Else
                                       l_hijoprod = m_hijoprod.TraerporIdPadreOrdenPed(p.IdOrdenped)
                                   End If
                                   l_hijoprod.ForEach(Sub(h)
                                                          Dim nh As New DataGridViewTreeNode
                                                          n.Nodes.Add(nh)
                                                          nh.Cells(Id.Index).Value = h.Id
                                                          nh.Cells(idordenped.Index).Value = h.IdOrdenped
                                                          nh.Cells(idarticulo.Index).Value = h.idArticulo
                                                          nh.Cells(automatico.Index).Value = h.indAutomatico
                                                          nh.Cells(ubicacion.Index).Value = h.ubicacion
                                                          nh.Cells(descripcion.Index).Value = h.descripcion
                                                          nh.Cells(observaciones.Index).Value = h.Observaciones
                                                          nh.Cells(anchovano.Index).Value = h.anchoRequerido
                                                          nh.Cells(anchofabricacion.Index).Value = h.AnchoFabricacion
                                                          nh.Cells(anchooriginal.Index).Value = h.Ancho
                                                          nh.Cells(altovano.Index).Value = h.AltoRequerido
                                                          nh.Cells(altofabricacion.Index).Value = h.AltoFabricacion
                                                          nh.Cells(altooriginal.Index).Value = h.Alto
                                                          nh.Cells(cantidad.Index).Value = h.CantidadRequerida
                                                          nh.Cells(cantidadoriginal.Index).Value = h.Cantidad
                                                          nh.Cells(piezasxunidad.Index).Value = h.PiezasxUnidadRequeridas
                                                          nh.Cells(vidrio.Index).Value = h.IdVidrio
                                                          nh.Cells(acabado.Index).Value = h.IdAcabadoPerfil
                                                          nh.Cells(colorvidrio.Index).Value = h.idColorVidrio
                                                          nh.Cells(espesor.Index).Value = h.IdEspesor
                                                          nh.Cells(tipoitem.Index).Value = h.tipoitem
                                                          nh.Cells(puntos.Index).Value = h.Puntos
                                                          Dim an As AnalizadorLexico = New AnalizadorLexico
                                                          carga_plantillas.CargarPlantilla(If(h.Id = 0, h.IdOrdenped, h.Id),
                                                                                           an,
                                                                                           If(h.Id = 0, ClsEnums.TipoCarga.ORDENPEDIDO, ClsEnums.TipoCarga.ORDENPRODUCCION))
                                                          Dim coti As cotizaciones.cotizacion = cot.TraerxId(m_hijoped.TraerIdCotizacionPertenece(h.IdOrdenped))
                                                          carga_plantillas.ValorarAnalizador(an, coti.Id, coti.versionCostoAcabado,
                                                        coti.versionCostoNivel, coti.versionCostoKiloAluminio,
                                                        coti.versionCostoVidrio, coti.versionCostoAccesorio, coti.versionCostoOtrosArticulos)
                                                          nh.Cells(idestado.Index).Value = h.IdEstado
                                                          If h.IdEstado = ClsEnums.Estados.TERMINADO Then
                                                              nh.DefaultCellStyle.BackColor = Color.LightSkyBlue
                                                          End If
                                                          If an Is Nothing Then
                                                              nh.DefaultCellStyle.BackColor = Color.MistyRose
                                                          Else
                                                              nh.Cells(especial.Index).Value = an
                                                          End If
                                                      End Sub)
                               End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub verimagen()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim vimg As New FrmVerimagen
            vimg.Imagen = DirectCast(r.Cells(especial.Index).Value, Byte())
            vimg.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub editarplano()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim feditm As New FrmEditorModelos
            feditm.IdPlantillaOProd = Convert.ToInt32(r.Cells(Id.Index).Value)
            If feditm.ShowDialog() = DialogResult.OK Then
                Dim an As AnalizadorLexico = feditm.Analizador
                guardar_analizador_plantilla(an, Convert.ToInt32(r.Cells(Id.Index).Value))
                Dim dibujos_plantilla As New ClsDibujosPlantillaOrdenProd
                Dim observaciones_plantilla As New ClsObservacionesPlantillaOrdenProd
                dibujos_plantilla.EliminarxIdItemOp(Convert.ToInt32(r.Cells(Id.Index).Value))
                observaciones_plantilla.EliminarxIdItemOp(Convert.ToInt32(r.Cells(Id.Index).Value))

                Dim m_plant As New ClsPlantillasModelos
                Dim m_plant_oprod As New ClsPlantillaOrdenProd
                m_plant_oprod.Modificar(My.Settings.UsuarioActivo, Convert.ToInt32(r.Cells(Id.Index).Value),
                                       Convert.ToInt32(feditm.cbtipomodelo.SelectedValue), Convert.ToInt32(feditm.cbclasificacionmodelo.SelectedValue),
                                        Convert.ToInt32(feditm.cbfamiliamodelo.SelectedValue), Convert.ToInt32(feditm.cbconfiguracionmodelo.SelectedValue),
                                       Convert.ToInt32(feditm.cbcaracteristicasadicionales.SelectedValue))

                For Each d As ControlesPersonalizados.DibujosPlantilla In feditm.flpContenedordibujos.Controls
                    dibujos_plantilla.Insertar(Convert.ToInt32(r.Cells(Id.Index).Value), My.Settings.UsuarioActivo,
                                               d.Nombre, d.Predeterminado, d.ObtenerStrImagen(), ClsEnums.Estados.ACTIVO, d.PlantillaVidrio)
                Next
                For Each o As ControlesPersonalizados.ObservacionesenPlantilla In feditm.flpcontenedorobservaciones.Controls
                    observaciones_plantilla.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(r.Cells(Id.Index).Value),
                                                     o.Observacion, o.Visible, ClsEnums.Estados.ACTIVO)
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub reemplazarplanodesdebaseoriginal()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim freemplazo As New FrmReemplazarPlantilla
            freemplazo.Desde_Plantillas_Originales = False
            If freemplazo.ShowDialog() = DialogResult.OK Then
                r.Cells(idarticulo.Index).Value = freemplazo.Id_Seleccionado
                Dim cp As New CargasPlantilla()
                Dim an As AnalizadorLexico = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)
                Dim dic As New Dictionary(Of String, String)
                an.ListaVariables.ToList().ForEach(Sub(x)
                                                       dic.Add(x.Nombre, x.Valor)
                                                   End Sub
                    )
                Dim analizador As New AnalizadorLexico
                cp.CargarPlantillaOriginal(freemplazo.Id_Seleccionado, analizador, dic)
                r.Cells(especial.Index).Value = analizador
                cp.ValorarAnalizador(analizador)
                Dim plant As New ClsPlantillasModelos
                r.Cells(descripcion.Index).Value = plant.TraerxId(freemplazo.Id_Seleccionado).NombreModelo

                Dim m_plant As New ClsPlantillasModelos
                Dim m_plant_oprod As New ClsPlantillaOrdenProd
                Dim p = m_plant.TraerxId(freemplazo.Id_Seleccionado)
                m_plant_oprod.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(r.Cells(Id.Index).Value),
                                       p.IdTipoModelo, p.IdClasificacionoModelo, p.IdFamiliaModelo, p.IdConfiguracion,
                                       p.IdCaracteristicaAdicional)

                guardarnodohijo(r)
                Dim dibujos_plantilla As New ClsDibujosPlantillaOrdenProd
                Dim observaciones_plantilla As New ClsObservacionesPlantillaOrdenProd
                guardar_analizador_plantilla(analizador, Convert.ToInt32(r.Cells(Id.Index).Value))
                dibujos_plantilla.Insertar_desde_Plantilla(freemplazo.Id_Seleccionado, Convert.ToInt32(r.Cells(Id.Index).Value), My.Settings.UsuarioActivo)
                observaciones_plantilla.Insertar_desde_Plantilla(freemplazo.Id_Seleccionado, Convert.ToInt32(r.Cells(Id.Index).Value), My.Settings.UsuarioActivo)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub reemplazarplanodesdebasetrabajada()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim freemplazo As New FrmReemplazarPlantilla
            freemplazo.Desde_Plantillas_Originales = False
            freemplazo.Nit = lbcodobra.Text.Split("-")(0)
            freemplazo.Codigo_Obra = lbcodobra.Text.Split("-")(1)
            If freemplazo.ShowDialog() = DialogResult.OK Then
                r.Cells(idarticulo.Index).Value = freemplazo.Id_Seleccionado
                Dim cp As New CargasPlantilla()
                Dim an As AnalizadorLexico = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)
                Dim dic As New Dictionary(Of String, String)
                an.ListaVariables.ToList().ForEach(Sub(x)
                                                       dic.Add(x.Nombre, x.Valor)
                                                   End Sub
                    )
                Dim analizador As New AnalizadorLexico
                cp.CargarPlantillaOriginal(freemplazo.Id_Seleccionado, analizador, dic)
                r.Cells(especial.Index).Value = analizador
                cp.ValorarAnalizador(analizador)
                Dim plant As New ClsPlantillasModelos
                r.Cells(descripcion.Index).Value = plant.TraerxId(freemplazo.Id_Seleccionado).NombreModelo

                Dim m_plant As New ClsPlantillasModelos
                Dim m_plant_oprod As New ClsPlantillaOrdenProd
                Dim p = m_plant_oprod.TraerporId(freemplazo.Id_Seleccionado)
                m_plant_oprod.Modificar(My.Settings.UsuarioActivo, Convert.ToInt32(r.Cells(Id.Index).Value),
                                       p.IdTipoModelo, p.IdClasificacionoModelo, p.IdFamiliaModelo, p.IdConfiguracion,
                                       p.IdCaracteristicaAdicional)

                guardarnodohijo(r)
                Dim dibujos_plantilla As New ClsDibujosPlantillaOrdenProd
                Dim observaciones_plantilla As New ClsObservacionesPlantillaOrdenProd
                guardar_analizador_plantilla(analizador, Convert.ToInt32(r.Cells(Id.Index).Value))
                dibujos_plantilla.Insertar_desde_Plantilla(freemplazo.Id_Seleccionado, Convert.ToInt32(r.Cells(Id.Index).Value), My.Settings.UsuarioActivo)
                observaciones_plantilla.Insertar_desde_Plantilla(freemplazo.Id_Seleccionado, Convert.ToInt32(r.Cells(Id.Index).Value), My.Settings.UsuarioActivo)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub listamateriales()
        Try
            Dim frm As New FrmListaMateriales
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim cot As New cotizaciones.ClsCostizaciones
            Dim m_hijoped As New ClsItemsHijoOped
            Dim coti As cotizaciones.cotizacion = cot.TraerxId(m_hijoped.TraerIdCotizacionPertenece(Convert.ToInt32(r.Cells(idordenped.Index).Value)))
            frm.IdCotiza = coti.Id
            frm.VersionCostoAcabado = coti.versionCostoAcabado
            frm.VersionCostoAccesorio = coti.versionCostoAccesorio
            frm.VersionCostoKiloAluminio = coti.versionCostoKiloAluminio
            frm.VersionCostoNivel = coti.versionCostoNivel
            frm.VersionCostoOtrosArticulos = coti.versionCostoOtrosArticulos
            frm.VersionCostoVidrio = coti.versionCostoVidrio
            frm.MostrarFinanciero = False
            frm.Tipo_Formulario = ClsEnums.TiOperacion.SOLO_LECTURA
            frm.lista = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico).ListaMateriales
            frm.Text += " " & Convert.ToString(r.Cells(ubicacion.Index).Value)
            frm.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub guardarnodohijo(h As DataGridViewTreeNode)
        Try
            Dim m_hijo_oprod As New ClsHijosOrdenProd
            Dim m_plant_oprod As New ClsPlantillaOrdenProd
            Dim m_plant_base As New ClsPlantillasModelos
            If Convert.ToInt32(h.Cells(Id.Index).Value) > 0 Then
                m_hijo_oprod.Modificar(Convert.ToInt32(h.Parent.Cells(Id.Index).Value), Convert.ToInt32(h.Cells(idordenped.Index).Value),
                                      DirectCast(h.Cells(anchofabricacion.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(h.Cells(anchofabricacion.Index).Value),
                                      DirectCast(h.Cells(altofabricacion.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(h.Cells(altofabricacion.Index).Value),
                                      DirectCast(h.Cells(cantidad.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(h.Cells(cantidad.Index).Value),
                                      DirectCast(h.Cells(piezasxunidad.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(h.Cells(piezasxunidad.Index).Value),
                                      Convert.ToDecimal(h.Cells(metros.Index).Value), Convert.ToInt32(h.Cells(vidrio.Index).Value), Convert.ToInt32(h.Cells(espesor.Index).Value), Convert.ToInt32(h.Cells(colorvidrio.Index).Value),
                                      Convert.ToInt32(h.Cells(acabado.Index).Value), Convert.ToBoolean(h.Cells(automatico.Index).Value),
                                      Convert.ToDecimal(h.Cells(preciou.Index).Value), Convert.ToDecimal(h.Cells(precio_instala.Index).Value),
                                      Convert.ToDecimal(h.Cells(metros_instalacion.Index).Value), Convert.ToDecimal(h.Cells(puntos.Index).Value),
                                      Convert.ToString(h.Cells(observaciones.Index).Value), My.Settings.UsuarioActivo,
                                      Convert.ToInt32(h.Cells(idarticulo.Index).Value), ClsEnums.Estados.ACTIVO,
                                      Convert.ToBoolean(h.Cells(nsr.Index).Value), Convert.ToInt32(h.Cells(tipoitem.Index).Value),
                                      Convert.ToString(h.Cells(ubicacion.Index).Value), Convert.ToString(h.Cells(descripcion.Index).Value),
                                      Convert.ToInt32(h.Cells(Id.Index).Value))

                Dim p = m_plant_oprod.TraerporIdOrdenProd(Convert.ToInt32(h.Parent.Cells(Id.Index).Value))
                m_plant_oprod.Modificar(My.Settings.UsuarioActivo, Convert.ToInt32(h.Cells(Id.Index).Value),
                                       p.IdTipoModelo, p.IdClasificacionoModelo, p.IdFamiliaModelo, p.IdConfiguracion,
                                       p.IdCaracteristicaAdicional)
            Else
                h.Cells(Id.Index).Value = m_hijo_oprod.Insertar(Convert.ToInt32(h.Parent.Cells(Id.Index).Value), Convert.ToInt32(h.Cells(idordenped.Index).Value),
                                      DirectCast(h.Cells(anchofabricacion.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(h.Cells(anchofabricacion.Index).Value),
                                      DirectCast(h.Cells(altofabricacion.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(h.Cells(altofabricacion.Index).Value),
                                      DirectCast(h.Cells(cantidad.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(h.Cells(cantidad.Index).Value),
                                      DirectCast(h.Cells(piezasxunidad.Index), EspecialColumns.Columna_Formula.FormuleCell).Formula, Convert.ToDecimal(h.Cells(piezasxunidad.Index).Value),
                                      Convert.ToDecimal(h.Cells(metros.Index).Value), Convert.ToInt32(h.Cells(vidrio.Index).Value), Convert.ToInt32(h.Cells(espesor.Index).Value), Convert.ToInt32(h.Cells(colorvidrio.Index).Value),
                                      Convert.ToInt32(h.Cells(acabado.Index).Value), Convert.ToBoolean(h.Cells(automatico.Index).Value),
                                      Convert.ToDecimal(h.Cells(preciou.Index).Value), Convert.ToDecimal(h.Cells(precio_instala.Index).Value),
                                      Convert.ToDecimal(h.Cells(metros_instalacion.Index).Value), Convert.ToDecimal(h.Cells(puntos.Index).Value),
                                      Convert.ToString(h.Cells(observaciones.Index).Value), My.Settings.UsuarioActivo,
                                      Convert.ToInt32(h.Cells(idarticulo.Index).Value), ClsEnums.Estados.ACTIVO,
                                      Convert.ToBoolean(h.Cells(nsr.Index).Value), Convert.ToInt32(h.Cells(tipoitem.Index).Value),
                                      Convert.ToString(h.Cells(ubicacion.Index).Value), Convert.ToString(h.Cells(descripcion.Index).Value))
                Dim p = m_plant_base.TraerxId(Convert.ToInt32(h.Cells(idarticulo.Index).Value))
                m_plant_oprod.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(h.Cells(Id.Index).Value),
                                       p.IdTipoModelo, p.IdClasificacionoModelo, p.IdFamiliaModelo, p.IdConfiguracion, p.CaracteristicaAdicional)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub guardar_analizador_plantilla(an As AnalizadorLexico, id_hijo_op As Integer)
        Try
            Dim variables_plantilla As New ClsVariablesPlantillaOrdenProd
            Dim descuento_global As New ClsDescuentosGeneralesPlantillaOrdenProd
            Dim descuento_material_plantilla As New ClsDescuentosMaterialPlantillaOrdenProd
            Dim materiales_plantilla As New ClsMaterialesPlantillaOrdenProd
            variables_plantilla.EliminarxIdItemOp(id_hijo_op)
            descuento_global.EliminarxIdItemOp(id_hijo_op)
            descuento_material_plantilla.EliminarxIdItemOp(id_hijo_op)
            materiales_plantilla.EliminarxIdItemOp(id_hijo_op)
#Region "Variables"
            an.ListaVariables.ToList.ForEach(Sub(var As Parametro)
                                                 If var.Id > 0 Then
                                                     Dim minimo_f As String = String.Empty
                                                     Dim minimo_v As String = String.Empty

                                                     If var.Restricciones.Contains("MINIMO") Then
                                                         minimo_v = var.Restricciones.Item("MINIMO").Valor
                                                         minimo_f = var.Restricciones.Item("MINIMO").Formula
                                                     End If
                                                     Dim maximo_f As String = String.Empty
                                                     Dim maximo_v As String = String.Empty
                                                     If var.Restricciones.Contains("MAXIMO") Then
                                                         maximo_v = var.Restricciones.Item("MAXIMO").Valor
                                                         maximo_f = var.Restricciones.Item("MAXIMO").Formula
                                                     End If
                                                     variables_plantilla.Insertar(id_hijo_op, var.Id,
                                                                minimo_f, minimo_v, maximo_f, maximo_v, var.Valor,
                                                                My.Settings.UsuarioActivo)
                                                 End If
                                             End Sub)
#End Region
#Region "Materiales"
            an.ListaMateriales.ToList().ForEach(Sub(m)
                                                    Dim id_mat As Integer = 0
                                                    Select Case m.TipoObjeto
                                                        Case Is = TiposElementos.Vidrios
                                                            id_mat = materiales_plantilla.Insertar(id_hijo_op,
                                                         m.Id, My.Settings.UsuarioActivo, TiposElementos.Vidrios,
                                                         Convert.ToInt32(m.Parametros.Item("IDORIENTACIONPOSICION").Valor),
                                                        m.Parametros.Item("ESPESOR").Formula, m.Parametros.Item("ESPESOR").Valor,
                                                        If(m.Parametros.Item("ARTICULO").Formula.StartsWith("="), m.Parametros.Item("ARTICULO").Formula, m.Parametros.Item("ARTICULO").Valor),
                                                        m.Parametros.Item("REFERENCIA").Valor,
                                                        Convert.ToInt32(m.Parametros.Item("IDUBICACIONMATERIAL").Valor),
                                                        Convert.ToInt32(m.Parametros.Item("IDMATERIALPARA").Valor),
                                                        m.Parametros.Item("COLOR").Formula, m.Parametros.Item("COLOR").Valor,
                                                        Convert.ToInt32(m.Parametros.Item("IDTIPOMATERIAL").Valor), Convert.ToInt32(m.Parametros.Item("IDTIPOCORTES").Valor),
                                                        m.Parametros.Item("CANTIDAD").Formula, m.Parametros.Item("CANTIDAD").Valor,
                                                        m.Parametros.Item("PXUNIDAD").Formula, m.Parametros.Item("PXUNIDAD").Valor,
                                                        m.Parametros.Item("ANCHO").Formula, m.Parametros.Item("ANCHO").Valor,
                                                        m.Parametros.Item("ALTO").Formula, m.Parametros.Item("ALTO").Valor,
                                                        m.Parametros.Item("PESO").Formula, If(String.IsNullOrEmpty(m.Parametros.Item("PESO").Valor.Replace("'", "")), 0, m.Parametros.Item("PESO").Valor),
                                                        m.Parametros.Item("DESCUENTO").Formula, m.Parametros.Item("DESCUENTO").Valor,
                                                        m.Parametros.Item("DETALLE").Formula, m.Parametros.Item("DETALLE").Valor, 1,
                                                        m.Parametros.Item("VISIBILIDAD").Formula, CInt(m.Parametros.Item("VISIBILIDAD").Valor), m.Utilizar, m.Desperdicio, m.Costo_Instalacion_Unidad, m.Indice)
                                                        Case TiposElementos.Perfiles, TiposElementos.Accesorios, TiposElementos.Otros
                                                            id_mat = materiales_plantilla.Insertar(id_hijo_op,
                                                         m.Id, My.Settings.UsuarioActivo, m.TipoObjeto,
                                                         Convert.ToInt32(m.Parametros.Item("IDORIENTACIONPOSICION").Valor), "", 1,
                                                        If(m.Parametros.Item("ARTICULO").Formula.StartsWith("="), m.Parametros.Item("ARTICULO").Formula, m.Parametros.Item("ARTICULO").Valor),
                                                        m.Parametros.Item("REFERENCIA").Valor,
                                                        Convert.ToInt32(m.Parametros.Item("IDUBICACIONMATERIAL").Valor),
                                                        Convert.ToInt32(m.Parametros.Item("IDMATERIALPARA").Valor),
                                                        m.Parametros.Item("ACABADO").Formula, m.Parametros.Item("ACABADO").Valor,
                                                        Convert.ToInt32(m.Parametros.Item("IDTIPOMATERIAL").Valor),
                                                        Convert.ToInt32(m.Parametros.Item("IDTIPOCORTES").Valor),
                                                        m.Parametros.Item("CANTIDAD").Formula, m.Parametros.Item("CANTIDAD").Valor,
                                                        m.Parametros.Item("PXUNIDAD").Formula, m.Parametros.Item("PXUNIDAD").Valor,
                                                        m.Parametros.Item("DIMENSION").Formula, m.Parametros.Item("DIMENSION").Valor, "", 0,
                                                        m.Parametros.Item("PESO").Formula, m.Parametros.Item("PESO").Valor,
                                                        m.Parametros.Item("DESCUENTO").Formula, m.Parametros.Item("DESCUENTO").Valor,
                                                        m.Parametros.Item("DETALLE").Formula, m.Parametros.Item("DETALLE").Valor, 1,
                                                        m.Parametros.Item("VISIBILIDAD").Formula, m.Parametros.Item("VISIBILIDAD").Valor,
                                                        m.Utilizar, m.Desperdicio, m.Costo_Instalacion_Unidad, m.Indice)
                                                    End Select
                                                    m.Descuentos.ToList().ForEach(Sub(d)
                                                                                      If d.Nombre <> "DESCUENTO" Then
                                                                                          descuento_material_plantilla.Insertar(id_mat, d.IdDescuento, d.Formula,
                                                                                                                                  d.Valor, My.Settings.UsuarioActivo)
                                                                                      End If
                                                                                  End Sub)
                                                End Sub
                )
#End Region
#Region "descuentos"
            an.ListaDescuentos.ToList().ForEach(Sub(a)
                                                    descuento_global.Insertar(id_hijo_op,
                                                    a.IdDescuento, a.Formula, a.Valor,
                                                    My.Settings.UsuarioActivo)
                                                End Sub)
#End Region
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub guardar_extras_plantilla(id_hijo_oped As Integer,
                                         id_hijo_op As Integer)
        Try
            Dim dibujos_plantilla As New ClsDibujosPlantillaOrdenProd
            Dim observaciones_plantilla As New ClsObservacionesPlantillaOrdenProd
            Dim l_dib = dibujos_plantilla.TraerporIdHijoOp(id_hijo_op)
            If l_dib.Count <= 0 Then
                Dim dib_d As New ClsDibujosPlantillaOped
                Dim l_di = dib_d.TraerporIdHijoOp(id_hijo_oped)
                For Each d In l_di
                    dibujos_plantilla.Insertar(id_hijo_op, My.Settings.UsuarioActivo, d.Nombre,
                                               d.Predeterminado, d.DXF, d.IdEstado, d.PlantillaVidrio)
                Next
            End If
            Dim l_obs = observaciones_plantilla.TraerporIdHijoOP(id_hijo_op)
            If l_obs.Count <= 0 Then
                Dim obs_plant As New ClsObservacionesPlantillaOped
                Dim l_ob = obs_plant.TraerporIdHijoOP(id_hijo_oped)
                For Each o In l_ob
                    observaciones_plantilla.Insertar(My.Settings.UsuarioActivo, id_hijo_op,
                                                     o.Observacion, o.Visibilidad, o.IdEstado)
                Next
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub guardar(total As Boolean)
        Try
            dwItem.EndEdit()
            Dim m_orden_prod As New ClsEncabeOrdenProd
            Dim m_padre_oprod As New ClsPadreOrdenProd
            Dim m_hijo_oprod As New ClsHijosOrdenProd
            If _curid = 0 Then
                _curid = m_orden_prod.Insertar(_idorden, My.Settings.UsuarioActivo,
                                                   If(total, ClsEnums.Estados.PARCIAL, ClsEnums.Estados.TERMINADO))
            Else
                m_orden_prod.Modificar(_idorden,
                                        If(total, ClsEnums.Estados.PARCIAL, ClsEnums.Estados.TERMINADO),
                                        My.Settings.UsuarioActivo, _curid)
            End If
            For Each p As DataGridViewTreeNode In dwItem.Nodes
                If Convert.ToInt32(p.Cells(Id.Index).Value) > 0 Then
                    m_padre_oprod.Modificar(_curid, Convert.ToInt32(p.Cells(idordenped.Index).Value),
                                            Convert.ToString(p.Cells(observaciones.Index).Value),
                                            Convert.ToDecimal(p.Cells(puntos.Index).Value),
                                            Convert.ToDecimal(p.Cells(preciou.Index).Value),
                                            My.Settings.UsuarioActivo, ClsEnums.Estados.ACTIVO,
                                            Convert.ToBoolean(p.Cells(nsr.Index).Value),
                                            Convert.ToInt32(p.Cells(Id.Index).Value))
                Else
                    p.Cells(Id.Index).Value = m_padre_oprod.Insertar(_curid, Convert.ToInt32(p.Cells(idordenped.Index).Value),
                                            Convert.ToString(p.Cells(observaciones.Index).Value),
                                            Convert.ToDecimal(p.Cells(puntos.Index).Value),
                                            Convert.ToDecimal(p.Cells(preciou.Index).Value),
                                            My.Settings.UsuarioActivo, ClsEnums.Estados.ACTIVO,
                                            Convert.ToBoolean(p.Cells(nsr.Index).Value))
                End If
                For Each h As DataGridViewTreeNode In p.Nodes
                    guardarnodohijo(h)
                    If DirectCast(h.Cells(tipoitem.Index).Value, ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                        guardar_analizador_plantilla(DirectCast(h.Cells(especial.Index).Value, AnalizadorLexico),
                                                     Convert.ToInt32(h.Cells(Id.Index).Value))
                        guardar_extras_plantilla(Convert.ToInt32(h.Cells(idordenped.Index).Value),
                                                  Convert.ToInt32(h.Cells(Id.Index).Value))
                    End If
                Next
            Next
            MsgBox("Los datos se han guardado correctamente", MsgBoxStyle.Information)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub restaurar_material()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            Dim m_hijoprod As New ClsHijosOrdenProd
            Dim hijoprod As HijoOrdenProd = m_hijoprod.Traerbasexidbase(Convert.ToInt32(r.Cells(idordenped.Index).Value))
            r.Cells(Id.Index).Value = hijoprod.Id
            r.Cells(idordenped.Index).Value = hijoprod.IdOrdenped
            r.Cells(idarticulo.Index).Value = hijoprod.idArticulo
            r.Cells(automatico.Index).Value = hijoprod.indAutomatico
            r.Cells(ubicacion.Index).Value = hijoprod.ubicacion
            r.Cells(descripcion.Index).Value = hijoprod.descripcion
            r.Cells(observaciones.Index).Value = hijoprod.Observaciones
            r.Cells(anchovano.Index).Value = hijoprod.anchoRequerido
            r.Cells(anchofabricacion.Index).Value = hijoprod.AnchoFabricacion
            r.Cells(anchooriginal.Index).Value = hijoprod.Ancho
            r.Cells(altovano.Index).Value = hijoprod.AltoRequerido
            r.Cells(altofabricacion.Index).Value = hijoprod.AltoFabricacion
            r.Cells(altooriginal.Index).Value = hijoprod.Alto
            r.Cells(cantidad.Index).Value = hijoprod.CantidadRequerida
            r.Cells(cantidadoriginal.Index).Value = hijoprod.Cantidad
            r.Cells(piezasxunidad.Index).Value = hijoprod.PiezasxUnidadRequeridas
            r.Cells(vidrio.Index).Value = hijoprod.IdVidrio
            r.Cells(acabado.Index).Value = hijoprod.IdAcabadoPerfil
            r.Cells(colorvidrio.Index).Value = hijoprod.idColorVidrio
            r.Cells(espesor.Index).Value = hijoprod.IdEspesor
            r.Cells(tipoitem.Index).Value = hijoprod.tipoitem
            r.Cells(puntos.Index).Value = hijoprod.Puntos
            r.Cells(idestado.Index).Value = hijoprod.IdEstado
            Dim carga_plantillas As New CargasPlantilla
            Dim m_hijoped As New ClsItemsHijoOped
            Dim an As AnalizadorLexico = New AnalizadorLexico
            Dim cot As New cotizaciones.ClsCostizaciones
            carga_plantillas.CargarPlantilla(hijoprod.IdOrdenped,
                                             an,
                                             ClsEnums.TipoCarga.ORDENPEDIDO)
            Dim coti As cotizaciones.cotizacion = cot.TraerxId(m_hijoped.TraerIdCotizacionPertenece(hijoprod.IdOrdenped))
            carga_plantillas.ValorarAnalizador(an, coti.Id, coti.versionCostoAcabado,
          coti.versionCostoNivel, coti.versionCostoKiloAluminio,
          coti.versionCostoVidrio, coti.versionCostoAccesorio, coti.versionCostoOtrosArticulos)
            If an Is Nothing Then
                r.DefaultCellStyle.BackColor = Color.MistyRose
            Else
                r.Cells(especial.Index).Value = an
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub restaurar_nodo_padre()
        Try
            If MsgBox("¿Esta seguro que desea devolver los items a su version original?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim n As DataGridViewTreeNode = DirectCast(dwItem.SelectedRows(0), DataGridViewTreeNode)
                n.Nodes.Clear()
                Dim m_hijoprod As New ClsHijosOrdenProd
                Dim list_hijoprod As List(Of HijoOrdenProd) = m_hijoprod.TraerbasexidPadreOped(Convert.ToInt32(n.Cells(idordenped.Index).Value))
                Dim carga_plantillas As New CargasPlantilla
                Dim m_hijoped As New ClsItemsHijoOped
                Dim cot As New cotizaciones.ClsCostizaciones
                list_hijoprod.ForEach(Sub(h)
                                          Dim nh As New DataGridViewTreeNode
                                          n.Nodes.Add(nh)
                                          nh.Cells(Id.Index).Value = h.Id
                                          nh.Cells(idordenped.Index).Value = h.IdOrdenped
                                          nh.Cells(idarticulo.Index).Value = h.idArticulo
                                          nh.Cells(automatico.Index).Value = h.indAutomatico
                                          nh.Cells(ubicacion.Index).Value = h.ubicacion
                                          nh.Cells(descripcion.Index).Value = h.descripcion
                                          nh.Cells(observaciones.Index).Value = h.Observaciones
                                          nh.Cells(anchovano.Index).Value = h.anchoRequerido
                                          nh.Cells(anchofabricacion.Index).Value = h.AnchoFabricacion
                                          nh.Cells(anchooriginal.Index).Value = h.Ancho
                                          nh.Cells(altovano.Index).Value = h.AltoRequerido
                                          nh.Cells(altofabricacion.Index).Value = h.AltoFabricacion
                                          nh.Cells(altooriginal.Index).Value = h.Alto
                                          nh.Cells(cantidad.Index).Value = h.CantidadRequerida
                                          nh.Cells(cantidadoriginal.Index).Value = h.Cantidad
                                          nh.Cells(piezasxunidad.Index).Value = h.PiezasxUnidadRequeridas
                                          nh.Cells(vidrio.Index).Value = h.IdVidrio
                                          nh.Cells(acabado.Index).Value = h.IdAcabadoPerfil
                                          nh.Cells(colorvidrio.Index).Value = h.idColorVidrio
                                          nh.Cells(espesor.Index).Value = h.IdEspesor
                                          nh.Cells(tipoitem.Index).Value = h.tipoitem
                                          nh.Cells(puntos.Index).Value = h.Puntos
                                          nh.Cells(idestado.Index).Value = h.IdEstado
                                          Dim an As AnalizadorLexico = New AnalizadorLexico
                                          carga_plantillas.CargarPlantilla(h.IdOrdenped,
                                                                           an,
                                                                           ClsEnums.TipoCarga.ORDENPEDIDO)
                                          Dim coti As cotizaciones.cotizacion = cot.TraerxId(m_hijoped.TraerIdCotizacionPertenece(h.IdOrdenped))
                                          carga_plantillas.ValorarAnalizador(an, coti.Id, coti.versionCostoAcabado,
                                        coti.versionCostoNivel, coti.versionCostoKiloAluminio,
                                        coti.versionCostoVidrio, coti.versionCostoAccesorio, coti.versionCostoOtrosArticulos)
                                          If an Is Nothing Then
                                              nh.DefaultCellStyle.BackColor = Color.MistyRose
                                          Else
                                              nh.Cells(especial.Index).Value = an
                                          End If
                                      End Sub)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub finalizar_plano()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            If MsgBox("¿Esta seguro que dar por terminado el plano?. No podra hacer mas ediciones sobre este.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim m_hijoprod As New ClsHijosOrdenProd
                m_hijoprod.Modificar_Estado(Convert.ToInt32(r.Cells(Id.Index).Value), ClsEnums.Estados.TERMINADO,
                                            My.Settings.UsuarioActivo)
                r.DefaultCellStyle.BackColor = Color.LightSkyBlue
                r.Cells(idestado.Index).Value = ClsEnums.Estados.TERMINADO
                MsgBox("El item se ha marcado como terminado.", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub habilitar_para_edicion()
        Try
            Dim r As DataGridViewRow = dwItem.SelectedRows(0)
            If MsgBox("¿Esta seguro que quiere habilitar el plano para edicion?. Si hay complementos asociados estos se perderan", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim complem As New ClsComplementos
                complem.EliminarporIdBase(Convert.ToInt32(r.Cells(Id.Index).Value))
                complem.EliminarporIdComplento(Convert.ToInt32(r.Cells(Id.Index).Value))
                Dim m_hijoprod As New ClsHijosOrdenProd
                m_hijoprod.Modificar_Estado(Convert.ToInt32(r.Cells(Id.Index).Value), ClsEnums.Estados.ACTIVO,
                                            My.Settings.UsuarioActivo)
                r.DefaultCellStyle.BackColor = Color.White
                r.Cells(idestado.Index).Value = ClsEnums.Estados.ACTIVO
                MsgBox("El item se ha habilitado para edición.", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub complementos()
        Try
            Dim complem As New ClsComplementos
            Dim r As DataGridViewTreeNode = dwItem.SelectedRows(0)
            Dim dic As New Dictionary(Of Integer, String)
            For Each n As DataGridViewTreeNode In r.Parent.Nodes
                If DirectCast(n.Cells(tipoitem.Index).Value, ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                    If n IsNot r And DirectCast(n.Cells(idestado.Index).Value, ClsEnums.Estados) = ClsEnums.Estados.TERMINADO Then
                        dic.Add(Convert.ToInt32(n.Cells(Id.Index).Value), Convert.ToString(n.Cells(descripcion.Index).Value))
                    End If
                End If
            Next
            If dic.Count > 0 Then
                Dim comp As New FrmComplementos
                Dim lcomp = complem.TraerPorIdBase(Convert.ToInt32(r.Cells(Id.Index).Value))
                comp.Seleccionados = lcomp.Select(Function(x) x.IdComplemento).ToList()
                comp.Complementos = dic
                If comp.ShowDialog() = DialogResult.OK Then
                    complem.EliminarporIdBase(Convert.ToInt32(r.Cells(Id.Index).Value))
                    For Each c In comp.Seleccionados
                        complem.Insertar(My.Settings.UsuarioActivo, Convert.ToInt32(r.Cells(Id.Index).Value), c)
                    Next
                End If
            Else
                MsgBox("No hay items disponibles para hacer complementos", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub btnGuardarTotal_Click(sender As Object, e As EventArgs)
        Try
            If MsgBox("¿Esta seguro que desea guardar totalmente los cambios?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                guardar(True)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnGuardarParcial_Click(sender As Object, e As EventArgs)
        Try
            guardar(False)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmGenerarPlanos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargacombositems()
            cargarbase()
            If _curid <= 0 Then
                guardar(False)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItem.CellMouseDown
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                If e.Button = MouseButtons.Right Then
                    dwItem.Rows(e.RowIndex).Selected = True
                    Dim menu As New ContextMenuStrip
                    menu.Items.Add("PARA PLANOS", Nothing)
                    Dim terminado As Boolean = DirectCast(dwItem.Item(idestado.Index, e.RowIndex).Value, ClsEnums.Estados) = ClsEnums.Estados.TERMINADO
                    If DirectCast(dwItem.Rows(e.RowIndex), DataGridViewTreeNode).Level = 1 Then
                        menu.Items.Add("Ver Imagen", Nothing, AddressOf verimagen)
                        menu.Items.Add("Restaurar a Original", Nothing, AddressOf restaurar_nodo_padre)
                    Else
                        If Convert.ToInt32(dwItem.Item(tipoitem.Index, e.RowIndex).Value) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                            menu.Items.Add("Lista Materiales", Nothing, AddressOf listamateriales)
                            If Not terminado Then
                                menu.Items.Add("Editar Plano", Nothing, AddressOf editarplano)
                                menu.Items.Add("Reemplazar Plano desde Originales", Nothing, AddressOf reemplazarplanodesdebaseoriginal)
                                menu.Items.Add("Reemplazar Plano desde Trabajados", Nothing, AddressOf reemplazarplanodesdebasetrabajada)
                                menu.Items.Add("Finalizar Plano", Nothing, AddressOf finalizar_plano)
                                menu.Items.Add("Complementos", Nothing, AddressOf complementos)
                            Else
                                menu.Items.Add("Habilitar para edicion", Nothing, AddressOf habilitar_para_edicion)
                            End If
                        End If
                        If Not terminado Then
                            menu.Items.Add("Restaurar a Original", Nothing, AddressOf restaurar_material)
                        End If
                    End If
                    menu.Show(Control.MousePosition)
                Else
                    If DirectCast(dwItem.Rows(e.RowIndex), DataGridViewTreeNode).Level > 1 Then
                        r_sel = dwItem.Rows(e.RowIndex)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dwItem.CellBeginEdit
        Try
            If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
                If DirectCast(dwItem.Rows(e.RowIndex), DataGridViewTreeNode).Level = 1 Or
                    Convert.ToInt32(dwItem.Item(idestado.Index, e.RowIndex).Value) = ClsEnums.Estados.TERMINADO Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            DirectCast(Me.MdiParent, frmInicial).btnLimpiar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnrecargar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnexportar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Enabled = True
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Click, AddressOf btnGuardarParcial_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnGuardar.Click, AddressOf btnGuardarParcial_Click
            AddHandler DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal.Click, AddressOf btnGuardarTotal_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Try
            DirectCast(Me.MdiParent, frmInicial).btnLimpiar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnrecargar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnexportar.Enabled = False
            DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Enabled = False
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnguardarParcial.Click, AddressOf btnGuardarParcial_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnGuardar.Click, AddressOf btnGuardarParcial_Click
            RemoveHandler DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal.Click, AddressOf btnGuardarTotal_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnlistacorte_Click(sender As Object, e As EventArgs) Handles btnlistacorte.Click
        Try
            'guardar(False)
            Dim f_lista_cort As New FrmListaCorte
            f_lista_cort.IdOrdenProduccion = _curid
            f_lista_cort.ShowDialog()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItem.CellMouseUp
        Try
            r_sel = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwItem.CellMouseMove
        Try
            If r_sel IsNot Nothing Then
                'If DirectCast(r_sel.Cells(tipoitem.Index).Value, ClsEnums.FamiliasMateriales) <> ClsEnums.FamiliasMateriales.DISEÑOS Then
                Dim r = r_sel.Clone()
                    dwItem.DoDragDrop(r, DragDropEffects.All)
                    r_sel = Nothing
                'End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_DragOver(sender As Object, e As DragEventArgs) Handles dwItem.DragOver
        Try
            Dim clientPoint As Point = dwItem.PointToClient(New Point(e.X, e.Y))
            Dim ht As DataGridView.HitTestInfo = dwItem.HitTest(clientPoint.X, clientPoint.Y)
            If ht.RowIndex >= 0 Then
                Dim r As DataGridViewTreeNode = dwItem.Rows(ht.RowIndex)
                If e.Data.GetDataPresent(GetType(DatagridTreeView.DataGridViewTreeNode)) Then
                    Dim n As DataGridViewRow = e.Data.GetData(GetType(DatagridTreeView.DataGridViewTreeNode))
                    Dim nh As DataGridViewTreeNode = r.Parent.Nodes.Cast(Of DataGridViewTreeNode).FirstOrDefault(Function(x) Convert.ToInt32(x.Cells(Id.Index).Value) = Convert.ToInt32(n.Cells(Id.Index).Value))
                    If nh IsNot Nothing Then
                        If DirectCast(r.Cells(tipoitem.Index).Value, ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.DISEÑOS And
                            Convert.ToInt32(n.Cells(Id.Index).Value) <> Convert.ToInt32(r.Cells(Id.Index).Value) And
                             DirectCast(r.Cells(idestado.Index).Value, ClsEnums.Estados) <> ClsEnums.Estados.TERMINADO Then
                            e.Effect = DragDropEffects.Move
                        Else
                            e.Effect = DragDropEffects.None
                        End If
                    Else
                        e.Effect = DragDropEffects.None
                        Return
                    End If
                End If
            Else
                e.Effect = DragDropEffects.None
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwItem_DragDrop(sender As Object, e As DragEventArgs) Handles dwItem.DragDrop
        Try
            Dim clientPoint As Point = dwItem.PointToClient(New Point(e.X, e.Y))
            Dim ht As DataGridView.HitTestInfo = dwItem.HitTest(clientPoint.X, clientPoint.Y)
            Dim n As DataGridViewTreeNode = DirectCast(dwItem.Rows(ht.RowIndex), DataGridViewTreeNode)
            If e.Data.GetDataPresent(GetType(DatagridTreeView.DataGridViewTreeNode)) Then
                Dim r As DataGridViewRow = e.Data.GetData(GetType(DatagridTreeView.DataGridViewTreeNode))
                r = n.Parent.Nodes.Cast(Of DataGridViewTreeNode).FirstOrDefault(Function(x) Convert.ToInt32(x.Cells(Id.Index).Value) = Convert.ToInt32(r.Cells(Id.Index).Value))
                If MsgBox("El item " & Convert.ToString(r.Cells(descripcion.Index).Value) & " se agregara al modelo " &
                     Convert.ToString(dwItem.Item(descripcion.Index, ht.RowIndex).Value) & ". ¿Esta seguro que quiere continuar?", MsgBoxStyle.YesNo) Then
                    Dim h As New ClsHijosOrdenProd
                    If DirectCast(r.Cells(tipoitem.Index).Value, ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.DISEÑOS Then
                        Dim an_base As AnalizadorLexico = DirectCast(dwItem.Item(especial.Index, ht.RowIndex).Value, AnalizadorLexico)
                        Dim an As AnalizadorLexico = DirectCast(r.Cells(especial.Index).Value, AnalizadorLexico)

                        an.ListaVariables.ToList().ForEach(Sub(v)
                                                               If Not an_base.ListaVariables.Contains(v.Nombre) Then
                                                                   an_base.ListaVariables.Add(v)
                                                               End If
                                                           End Sub)

                        an.ListaDescuentos.ToList().ForEach(Sub(d)
                                                                If Not an_base.ListaDescuentos.Contains(d.Nombre) Then
                                                                    an_base.ListaDescuentos.Add(d)
                                                                End If
                                                            End Sub)
                        Dim ind_vidrio As Integer = an_base.ListaMateriales.CountbyName("ACCESORIOS")
                        Dim ind_perfileria As Integer = an_base.ListaMateriales.CountbyName("PERFIL")
                        Dim ind_accesorio As Integer = an_base.ListaMateriales.CountbyName("VIDRIO")
                        Dim ind_otro As Integer = an_base.ListaMateriales.CountbyName("OTROS")
                        an.ListaMateriales.ToList().ForEach(Sub(m)
                                                                Dim v_original As String = m.Nombre & "(" & Convert.ToString(m.Indice) & ")"
                                                                Select Case m.TipoObjeto
                                                                    Case TiposElementos.Accesorios
                                                                        an.reemplazar_elemento_en_formula(v_original, m.Nombre & "(" & Convert.ToString(ind_accesorio) & ")")
                                                                        m.Indice = ind_accesorio
                                                                        an_base.ListaMateriales.Add(m)
                                                                        ind_accesorio += 1
                                                                    Case TiposElementos.Otros
                                                                        an.reemplazar_elemento_en_formula(v_original, m.Nombre & "(" & Convert.ToString(ind_otro) & ")")
                                                                        m.Indice = ind_otro
                                                                        an_base.ListaMateriales.Add(m)
                                                                        ind_otro += 1
                                                                    Case TiposElementos.Vidrios
                                                                        an.reemplazar_elemento_en_formula(v_original, m.Nombre & "(" & Convert.ToString(ind_vidrio) & ")")
                                                                        m.Indice = ind_vidrio
                                                                        an_base.ListaMateriales.Add(m)
                                                                        ind_vidrio += 1
                                                                    Case TiposElementos.Perfiles
                                                                        an.reemplazar_elemento_en_formula(v_original, m.Nombre & "(" & Convert.ToString(ind_perfileria) & ")")
                                                                        m.Indice = ind_perfileria
                                                                        an_base.ListaMateriales.Add(m)
                                                                        ind_perfileria += 1
                                                                End Select
                                                            End Sub)
                        Dim cp As New CargasPlantilla
                        cp.ValorarAnalizador(an_base)
                        n.Cells(especial.Index).Value = an_base
                        guardar_analizador_plantilla(an_base, Convert.ToInt32(n.Cells(Id.Index).Value))
                        h.Eliminar_por_Id(Convert.ToInt32(r.Cells(Id.Index).Value))
                        n.Parent.Nodes.Remove(r)
                    Else
                        Dim m_hijo = h.TraerporId(Convert.ToInt32(r.Cells(Id.Index).Value))
                        Dim nombre_material As String = ""
                        Select Case DirectCast(m_hijo.tipoitem, ClsEnums.FamiliasMateriales)
                            Case Is = ClsEnums.FamiliasMateriales.ACCESORIOS
                                nombre_material = "ACCESORIOS"
                            Case Is = ClsEnums.FamiliasMateriales.PERFILERIA
                                nombre_material = "PERFIL"
                            Case Is = ClsEnums.FamiliasMateriales.VIDRIO
                                nombre_material = "VIDRIO"
                            Case Is = ClsEnums.FamiliasMateriales.OTROS
                                nombre_material = "OTROS"
                        End Select
                        Dim an As AnalizadorLexico = DirectCast(n.Cells(especial.Index).Value, AnalizadorLexico)
#Region "Nuevo Material"
                        Dim material As New Objeto(nombre_material, an.ListaMateriales.Where(Function(x) x.Nombre = nombre_material).Count())
                        material.Id = 0 'PENDIENTE
                        material.TipoObjeto = m_hijo.tipoitem
                        material.Utilizar = True
                        material.Desperdicio = 0
                        material.Costo_Instalacion_Unidad = 0
                        material.Parametros.Add(New Parametro("REFERENCIA", "", m_hijo.descripcion, TiposValores.Letras))
                        If DirectCast(m_hijo.tipoitem, ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.VIDRIO Then
                            material.Parametros.Add(New Parametro("COLOR", "", m_hijo.colorVidrio, TiposValores.Letras))
                            material.Parametros.Add(New Parametro("ANCHO", "", m_hijo.AnchoFabricacion, TiposValores.Letras))
                            material.Parametros.Add(New Parametro("ALTO", "", m_hijo.AltoFabricacion, TiposValores.Letras))
                            material.Parametros.Add(New Parametro("ESPESOR", "", m_hijo.Espesor, TiposValores.Letras))
                        Else
                            material.Parametros.Add(New Parametro("ACABADO", "", m_hijo.AcabadoPerfil, TiposValores.Letras))
                            material.Parametros.Add(New Parametro("DIMENSION", "", m_hijo.AnchoFabricacion, TiposValores.Letras))
                        End If
                        material.Parametros.Add(New Parametro("PXUNIDAD", "", m_hijo.PiezasxUnidadRequeridas, TiposValores.Letras))
                        material.Parametros.Add(New Parametro("CANTIDAD", "", m_hijo.CantidadRequerida, TiposValores.Letras))
                        material.Parametros.Add(New Parametro("DESCUENTO", "", 0, TiposValores.Letras))
                        material.Parametros.Add(New Parametro("DETALLE", "", "", TiposValores.Letras))
                        material.Parametros.Add(New Parametro("ORIENTACION", "", "NO APLICA", TiposValores.Letras))
                        material.Parametros.Add(New Parametro("UBICACION", "", "NO APLICA", TiposValores.Letras))
                        material.Parametros.Add(New Parametro("PARA", "", "OBRA", TiposValores.Letras))
                        material.Parametros.Add(New Parametro("TIPO", "", "N/A", TiposValores.Letras))
                        material.Parametros.Add(New Parametro("PESO", "", m_hijo.AnchoFabricacion, TiposValores.Letras))
                        material.Parametros.Add(New Parametro("VISIBILIDAD", "", 1, TiposValores.Booleano))
                        If DirectCast(m_hijo.tipoitem, ClsEnums.FamiliasMateriales) = ClsEnums.FamiliasMateriales.PERFILERIA Then
                            material.Parametros.Add(New Parametro("CORTES", "", "N/A", TiposValores.Letras))
                        End If
                        material.Parametros.Add(New Parametro("ARTICULO", "", m_hijo.idArticulo, TiposValores.Numerico))
                        material.Parametros.Add(New Parametro("IDORIENTACIONPOSICION", "", 90, TiposValores.Numerico))
                        material.Parametros.Add(New Parametro("IDUBICACIONMATERIAL", "", 1, TiposValores.Numerico))
                        material.Parametros.Add(New Parametro("IDMATERIALPARA", "", 1, TiposValores.Numerico))
                        material.Parametros.Add(New Parametro("IDTIPOMATERIAL", "", 2, TiposValores.Numerico))
                        material.Parametros.Add(New Parametro("IDTIPOCORTES", "", 1, TiposValores.Numerico))
#End Region
                        DirectCast(n.Cells(especial.Index).Value, AnalizadorLexico).ListaMateriales.Add(material)
                        guardar_analizador_plantilla(DirectCast(n.Cells(especial.Index).Value, AnalizadorLexico),
                                                     Convert.ToInt32(n.Cells(Id.Index).Value))
                        h.Eliminar_por_Id(Convert.ToInt32(r.Cells(Id.Index).Value))
                        n.Parent.Nodes.Remove(r)
                        MsgBox("El item " & Convert.ToString(r.Cells(descripcion.Index).Value) & " se ha agregado al modelo " &
                         Convert.ToString(dwItem.Item(descripcion.Index, ht.RowIndex).Value), MsgBoxStyle.Information)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub tbGeneral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbGeneral.SelectedIndexChanged
        Try
            If _curid > 0 Then
                If tbGeneral.SelectedTab Is ListaCorte Then
#Region "Vista previa impresión ListaCorte"
                    ImprimirListaCorte()
#End Region
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Impresion"
    Private Sub ImprimirListaCorte()
        Try
            Dim ds As New DataSet
            If _curid > 0 Then

                Dim mListaCorte As New datosInformesTableAdapters.sp_top012_listaCorteXmlTableAdapter
                Dim tbLista As DataTable = mListaCorte.GetData(_curid)
                ds.Tables.Add(tbLista)
                ds.WriteXmlSchema(IO.Path.Combine(Environment.GetEnvironmentVariables(System.EnvironmentVariableTarget.Machine).Item("TMP"), "listaCorte.xml"))
                Dim b As New Informes.listaCorte
                b.SetDataSource(ds)
                visor.ReportSource = b
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#End Region
End Class