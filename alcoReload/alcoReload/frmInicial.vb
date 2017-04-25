Imports System.ComponentModel
Imports System.Xml
Imports ReglasNegocio
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Globalization

Public Class frmInicial
#Region "Variables de aplicacion"
    Private _GlobalCotizaForms As Integer
    Public Property GlobalCotizaForms() As Integer
        Get
            Return _GlobalCotizaForms
        End Get
        Set(ByVal value As Integer)
            _GlobalCotizaForms = value
        End Set
    End Property

#End Region
#Region "validaciones"
    Private Function configuracion_regional() As Boolean
        Try
            If Not CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.Equals(".") Or
                Not CultureInfo.CurrentCulture.NumberFormat.CurrencyGroupSeparator.Equals(",") Or
                Not CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol.Equals("$") Or
                Not CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.Equals(".") Or
                Not CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator.Equals(",") Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
#Region "Generales del Formulario"
    Private Sub frmInicial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = Me.Text & "Versión " & Application.ProductVersion
            _GlobalCotizaForms = 0
            My.Settings.UsuarioActivo = Security.Principal.WindowsIdentity.GetCurrent().Name.Replace("ALCO\", "")
            Dim utilserv As New ClsUtilidadesServidor
            My.Settings.Nombre_Usuario_Activo = utilserv.TraerNombreDirectorio(My.Settings.UsuarioActivo)
            Dim usuario As New ClsUsuarios
            Dim usu As Usuario = usuario.TraerpoUsuarioNt(My.Settings.UsuarioActivo)
            My.Settings.Id_Usuario = usu.Id
            My.Settings.Id_UsuarioUnoee = usu.IdUnoee
            My.Settings.Es_Administrador = (usu.IdGrupo = 2)
            My.Settings.Es_Desarrollador = (usu.IdGrupo = 3)
            My.Settings.Consola = False
            Formulador.Formulacion_General.Configuraciones.Modificar_Consola(False)
            CargarPermisos()
            If My.Settings.Id_UsuarioUnoee = 0 Then
                ManejoExcepciones.MensajeExcepcion.Show(New Exception("El usuario no esta registrado en la base de datos. Comuníquese con ITA"),
                                                        ManejoExcepciones.TipoExcepcion.Critica)
                Close()
            End If
            ManejoExcepciones.MensajeExcepcion.ActualizarUsuario(My.Settings.UsuarioActivo)
            AplicarPermisos(rbprincipal)
            rbprincipal.Tabs.Clear()
            LecturaXML()
            If Not configuracion_regional() Then
                ManejoExcepciones.MensajeExcepcion.Show(New Exception("La configuración regional no es la correcta para el funcionamiento adecuado de la aplicación"), ManejoExcepciones.TipoExcepcion.Advertencia)
                Me.Close()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonCerrar_Click(sender As Object, e As EventArgs) Handles btonCerrar.Click
        Try
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub frmInicial_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim copenforms As Integer = My.Application.OpenForms.Count - 1
            If copenforms > 0 Then
                If MsgBox(String.Format("Tiene {0} ventanas abiertas. ¿Esta seguro que desea cerrar la aplicación?", copenforms), MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Seguridad"
    Public Sub CargarPermisos()
        Try
            Dim execpermisos As New ClsEjecucionSeguridad
            My.Settings.Permisos.Clear()
            My.Settings.Permisos.AddRange(execpermisos.PermisosCompletosporidUsuario(My.Settings.Id_Usuario))

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub AplicarPermisos(cnt As Object)
        Try
            Select Case True
                Case TypeOf (cnt) Is Ribbon
                    DirectCast(cnt, Ribbon).QuickAcessToolbar.Items.ForEach(Sub(quickmenoitem)
                                                                                AplicarPermisos(quickmenoitem)
                                                                            End Sub)
                    DirectCast(cnt, Ribbon).OrbDropDown.MenuItems.ForEach(Sub(setupmenu)
                                                                              AplicarPermisos(setupmenu)
                                                                          End Sub)
                    DirectCast(cnt, Ribbon).Tabs.ForEach(Sub(pestaña)
                                                             AplicarPermisos(pestaña)
                                                         End Sub)
                Case TypeOf (cnt) Is RibbonTab
                    DirectCast(cnt, RibbonTab).Visible = My.Settings.Permisos.Contains(Convert.ToString(DirectCast(cnt, RibbonTab).Tag))
                    DirectCast(cnt, RibbonTab).Panels.ForEach(Sub(hoja)
                                                                  AplicarPermisos(hoja)
                                                              End Sub)
                Case TypeOf (cnt) Is RibbonPanel
                    DirectCast(cnt, RibbonPanel).Enabled = My.Settings.Permisos.Contains(Convert.ToString(DirectCast(cnt, RibbonPanel).Tag))
                    DirectCast(cnt, RibbonPanel).Items.ForEach(Sub(hijo)
                                                                   AplicarPermisos(hijo)
                                                               End Sub)
                Case TypeOf (cnt) Is RibbonButton
                    DirectCast(cnt, RibbonButton).Enabled = My.Settings.Permisos.Contains(Convert.ToString(DirectCast(cnt, RibbonButton).Tag))
                    DirectCast(cnt, RibbonButton).DropDownItems.ForEach(Sub(hBoton)
                                                                            If TypeOf hBoton IsNot RibbonSeparator Then
                                                                                AplicarPermisos(hBoton)
                                                                            End If
                                                                        End Sub)
                Case Else
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub EscribirXML()
        Try
            Dim writer As New XmlTextWriter(Path.Combine(Path.GetTempPath(), "Ultima_Estancia.xml"),
                                                        System.Text.Encoding.UTF8)
            writer.WriteStartDocument(True)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2
            writer.WriteStartElement("Ultima_Estancia")
            writer.WriteStartElement("Modulo")
            writer.WriteString(btnmodulos.Text)
            writer.WriteEndElement()
            writer.WriteStartElement("Pestana")
            writer.WriteString(rbprincipal.ActiveTab.Text)
            writer.WriteEndElement()
            writer.WriteEndElement()
            writer.WriteEndDocument()
            writer.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub LecturaXML()
        Try
            If File.Exists(Path.Combine(Path.GetTempPath(), "Ultima_Estancia.xml")) Then
                Dim reader As XmlTextReader = New XmlTextReader(Path.Combine(Path.GetTempPath(), "Ultima_Estancia.xml"))
                Do While (reader.Read())
                    Select Case reader.NodeType
                        Case XmlNodeType.Element
                            Select Case reader.Name
                                Case "Modulo"
                                    reader.Read()
                                    Dim modulo = btnmodulos.DropDownItems.FirstOrDefault(Function(b) b.Text = reader.Value)
                                    If modulo Is Nothing Then
                                        Return
                                    End If
                                    modulo.OnClick(New EventArgs())
                                Case "Pestana"
                                    reader.Read()
                                    Dim tb = rbprincipal.Tabs.FirstOrDefault(Function(t) t.Text = reader.Value)
                                    If tb IsNot Nothing Then
                                        rbprincipal.ActiveTab = tb
                                    End If
                            End Select
                        Case XmlNodeType.Text
                        Case XmlNodeType.EndElement
                    End Select
                Loop
                reader.Close()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
#Region "Selección Módulos"
    Private Sub btncomercial_Click(sender As Object, e As EventArgs) Handles btncomercial.Click
        Try
            rbprincipal.Tabs.Clear()
            rbprincipal.Tabs.AddRange({tbventas, tbcontratos, tbinstalacion, tbfacturacion, tblogistica, tbcostos, tbconsultasreportesComercial})
            btnmodulos.Text = btncomercial.Text
            rbprincipal.ActiveTab = tbventas
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnmanufactura_Click(sender As Object, e As EventArgs) Handles btnmanufactura.Click
        Try
            rbprincipal.Tabs.Clear()
            rbprincipal.Tabs.AddRange({tbingenieria, tbproduccion, tbdeptecnico, tbperfileria, tbconsultasreportesManufactura})
            btnmodulos.Text = btnmanufactura.Text
            rbprincipal.ActiveTab = tbingenieria
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnfinanciero_Click(sender As Object, e As EventArgs) Handles btnfinanciero.Click
        Try
            rbprincipal.Tabs.Clear()
            btnmodulos.Text = btnfinanciero.Text
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnplaneacion_Click(sender As Object, e As EventArgs) Handles btnplaneacion.Click
        Try
            rbprincipal.Tabs.Clear()
            btnmodulos.Text = btnplaneacion.Text
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "PARÁMETROS"
#Region "Parámetros generales"
    Private Sub mnEstados_Click(sender As System.Object, e As System.EventArgs) Handles mnEstados.Click
        Try
            Dim estados As New FrmEstados
            estados.MdiParent = Me
            estados.WindowState = FormWindowState.Maximized
            estados.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnAcabados_Click(sender As System.Object, e As System.EventArgs) Handles mnAcabados.Click
        Try
            Dim acabados As New FrmAcabados
            acabados.MdiParent = Me
            acabados.WindowState = FormWindowState.Maximized
            acabados.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnVariables_Click(sender As Object, e As EventArgs) Handles mnVariables.Click
        Try
            Dim variables As New FrmVariables
            variables.MdiParent = Me
            variables.WindowState = FormWindowState.Maximized
            variables.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnValoresVariables_Click(sender As Object, e As EventArgs) Handles mnValoresVariables.Click
        Try
            Dim valoresvar As New FrmValoresVariables
            valoresvar.MdiParent = Me
            valoresvar.WindowState = FormWindowState.Maximized
            valoresvar.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mmEspesoresVidrio_Click(sender As System.Object, e As System.EventArgs) Handles mmEspesoresVidrio.Click
        Try
            Dim valoresvar As New FrmEspesores
            valoresvar.MdiParent = Me
            valoresvar.WindowState = FormWindowState.Maximized
            valoresvar.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nmparametrostecnicos_Click(sender As Object, e As EventArgs) Handles nmparametrostecnicos.Click
        Try
            Dim ptecnicos As New FrmParametrosDescripcionTecnica
            ptecnicos.MdiParent = Me
            ptecnicos.WindowState = FormWindowState.Maximized
            ptecnicos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub nmvaloresparametros_Click(sender As Object, e As EventArgs) Handles nmvaloresparametros.Click
        Try
            Dim vptecnicos As New FrmValoresParametrosTecnicosArticulo
            vptecnicos.MdiParent = Me
            vptecnicos.WindowState = FormWindowState.Maximized
            vptecnicos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnserviciosItems_Click(sender As Object, e As EventArgs) Handles mnserviciosItems.Click
        Try
            Dim frmTrabajos As New FrmTrabajosItems
            frmTrabajos.MdiParent = Me
            frmTrabajos.WindowState = FormWindowState.Maximized
            frmTrabajos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Parámetros manufactura"
    Private Sub mnOrientacionPosicion_Click(sender As Object, e As EventArgs) Handles mnOrientacionPosicion.Click
        Try
            Dim orientapos As New FrmOrientacionPosiciones
            orientapos.MdiParent = Me
            orientapos.WindowState = FormWindowState.Maximized
            orientapos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnUbicacionMaterial_Click(sender As Object, e As EventArgs) Handles mnUbicacionMaterial.Click
        Try
            Dim ubicacionmaterial As New FrmUbicacionMaterial
            ubicacionmaterial.MdiParent = Me
            ubicacionmaterial.WindowState = FormWindowState.Maximized
            ubicacionmaterial.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnMaterialPara_Click(sender As Object, e As EventArgs) Handles mnMaterialPara.Click
        Try
            Dim materialpara As New FrmMaterialPara
            materialpara.MdiParent = Me
            materialpara.WindowState = FormWindowState.Maximized
            materialpara.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnFamiliasModelo_Click(sender As System.Object, e As System.EventArgs) Handles mnFamiliasModelo.Click
        Try
            Dim familiamodelos As New FrmFamiliasModelos
            familiamodelos.MdiParent = Me
            familiamodelos.WindowState = FormWindowState.Maximized
            familiamodelos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnFamiliasMateriales_Click(sender As System.Object, e As System.EventArgs) Handles mnFamiliasMateriales.Click
        Try
            Dim familiamateriales As New FrmFamiliasMateriales
            familiamateriales.MdiParent = Me
            familiamateriales.WindowState = FormWindowState.Maximized
            familiamateriales.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnTiposModelos_Click(sender As Object, e As EventArgs) Handles mnTiposModelos.Click
        Try
            Dim tipomodelo As New FrmTiposModelos
            tipomodelo.MdiParent = Me
            tipomodelo.WindowState = FormWindowState.Maximized
            tipomodelo.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnClasificacionModelos_Click(sender As System.Object, e As System.EventArgs) Handles mnClasificacionModelos.Click
        Try
            Dim clasificacionmodelo As New FrmClasificacionModelo
            clasificacionmodelo.MdiParent = Me
            clasificacionmodelo.WindowState = FormWindowState.Maximized
            clasificacionmodelo.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnTiposDatos_Click(sender As Object, e As EventArgs) Handles mnTiposDatos.Click
        Try
            Dim tiposDatos As New FrmTiposDatos
            tiposDatos.MdiParent = Me
            tiposDatos.WindowState = FormWindowState.Maximized
            tiposDatos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnTiposCortes_Click(sender As Object, e As EventArgs) Handles mnTiposCortes.Click
        Try
            Dim tiposCortes As New FrmTiposCortes
            tiposCortes.MdiParent = Me
            tiposCortes.WindowState = FormWindowState.Maximized
            tiposCortes.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnTiposMaterial_Click(sender As Object, e As EventArgs) Handles mnTiposMaterial.Click
        Try
            Dim tiposMaterial As New FrmTiposMaterial
            tiposMaterial.MdiParent = Me
            tiposMaterial.WindowState = FormWindowState.Maximized
            tiposMaterial.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnCaracteristicasAdicionales_Click(sender As Object, e As EventArgs) Handles mnCaracteristicasAdicionales.Click
        Try
            Dim caracteristicasAdd As New FrmCaracteristicasAdicionales
            caracteristicasAdd.MdiParent = Me
            caracteristicasAdd.WindowState = FormWindowState.Maximized
            caracteristicasAdd.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnConfiguraciones_Click(sender As Object, e As EventArgs) Handles mnConfiguraciones.Click
        Try
            Dim configura As New FrmConfiguraciones
            configura.MdiParent = Me
            configura.WindowState = FormWindowState.Maximized
            configura.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnDescuentos_Click(sender As Object, e As EventArgs) Handles mnDescuentos.Click
        Try
            Dim descuentos As New FrmDescuentos
            descuentos.MdiParent = Me
            descuentos.WindowState = FormWindowState.Maximized
            descuentos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnversionCargaVientos_Click(sender As Object, e As EventArgs) Handles mnversionCargaVientos.Click
        Try
            Dim versiones As New FrmVersionesCargaViento
            versiones.MdiParent = Me
            versiones.WindowState = FormWindowState.Maximized
            versiones.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnVelocidadesViento_Click(sender As Object, e As EventArgs) Handles mnVelocidadesViento.Click
        Try
            Dim velocidades As New FrmVelocidadesViento
            velocidades.MdiParent = Me
            velocidades.WindowState = FormWindowState.Maximized
            velocidades.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnpropiedadesmodelos_Click(sender As Object, e As EventArgs) Handles mnpropiedadesmodelos.Click
        Try
            Dim frmprop As New FrmPropiedadesMasicas
            frmprop.MdiParent = Me
            frmprop.WindowState = FormWindowState.Maximized
            frmprop.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Parámetros comercial"
#Region "Parámetros costos"
    Private Sub btonCostoKiloAluminio_Click(sender As Object, e As EventArgs) Handles btonCostoKiloAluminio.Click
        Try
            Dim costoNiveles As New FrmAluminios
            costoNiveles.MdiParent = Me
            costoNiveles.WindowState = FormWindowState.Maximized
            costoNiveles.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonCostoNiveles_Click(sender As Object, e As EventArgs) Handles btonNiveles.Click
        Try
            Dim costoNiveles As New FrmNiveles
            costoNiveles.MdiParent = Me
            costoNiveles.WindowState = FormWindowState.Maximized
            costoNiveles.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonCostoAaluminio_Click(sender As Object, e As EventArgs) Handles btonCostoAluminio.Click
        Try
            Dim CAluminio As New FrmCostoAluminio
            CAluminio.MdiParent = Me
            CAluminio.WindowState = FormWindowState.Maximized
            CAluminio.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonCostoVidrio_Click(sender As Object, e As EventArgs) Handles btonCostoVidrio.Click
        Try
            Dim costoVidrio As New FrmCostoVidrio
            costoVidrio.MdiParent = Me
            costoVidrio.WindowState = FormWindowState.Maximized
            costoVidrio.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonCostoVidrioIndividual_Click(sender As Object, e As EventArgs) Handles btonCostoVidrioIndividual.Click
        Try
            Dim costoVidrioInd As New FrmCostoVidrioIndividual
            costoVidrioInd.MdiParent = Me
            costoVidrioInd.WindowState = FormWindowState.Maximized
            costoVidrioInd.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonCostoOtrosArticulos_Click(sender As Object, e As EventArgs) Handles btonCostoArticulos.Click
        Try
            Dim costoOtrosArticulos As New FrmCostoOtrosArticulos
            costoOtrosArticulos.MdiParent = Me
            costoOtrosArticulos.WindowState = FormWindowState.Maximized
            costoOtrosArticulos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonCostoTrabajos_Click(sender As Object, e As EventArgs) Handles btonCostoTrabajos.Click
        Try
            Dim costoTrabajos As New FrmCostoTrabajosItems
            costoTrabajos.MdiParent = Me
            costoTrabajos.WindowState = FormWindowState.Maximized
            costoTrabajos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonVariosCostos_Click(sender As Object, e As EventArgs) Handles btonVariosCostos.Click
        Try
            Dim frmVarios As New FrmVariosCostos
            frmVarios.MdiParent = Me
            frmVarios.WindowState = FormWindowState.Maximized
            frmVarios.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Parámetros NSR10"
    Private Sub btonTipoEdificacion_Click(sender As Object, e As EventArgs) Handles btonTipoEdificacion.Click
        Try
            Dim tipoEdificacion As New FrmTiposEdificacion
            tipoEdificacion.MdiParent = Me
            tipoEdificacion.WindowState = FormWindowState.Maximized
            tipoEdificacion.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonGrupoUso_Click(sender As Object, e As EventArgs) Handles btonGrupoUso.Click
        Try
            Dim grupoUso As New FrmGruposUso
            grupoUso.MdiParent = Me
            grupoUso.WindowState = FormWindowState.Maximized
            grupoUso.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonCategExposicion_Click(sender As Object, e As EventArgs) Handles btonCategExposicion.Click
        Try
            Dim categoriasExp As New FrmCategoriasExp
            categoriasExp.MdiParent = Me
            categoriasExp.WindowState = FormWindowState.Maximized
            categoriasExp.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonTipoCubierta_Click(sender As Object, e As EventArgs) Handles btonTipoCubierta.Click
        Try
            Dim tiposCubiertas As New FrmTiposCubierta
            tiposCubiertas.MdiParent = Me
            tiposCubiertas.WindowState = FormWindowState.Maximized
            tiposCubiertas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonPresionModelo_Click(sender As Object, e As EventArgs) Handles btonPresionModelo.Click
        Try
            Dim presionModelo As New FrmPresionDisenos
            presionModelo.MdiParent = Me
            presionModelo.WindowState = FormWindowState.Maximized
            presionModelo.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonComponentes_Click(sender As Object, e As EventArgs) Handles btonComponentes.Click
        Try
            Dim componentes As New FrmComponentes
            componentes.MdiParent = Me
            componentes.WindowState = FormWindowState.Maximized
            componentes.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Parámetros Contratos"
    Private Sub btonObjetos_Click(sender As Object, e As EventArgs) Handles btonObjetos.Click
        Try
            Dim frmObjetosContratos As New frmObjetos
            frmObjetosContratos.MdiParent = Me
            frmObjetosContratos.WindowState = FormWindowState.Maximized
            frmObjetosContratos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonPara_Click(sender As Object, e As EventArgs) Handles btonPara.Click
        Try
            Dim frmTiposObra As New FrmTiposObra
            frmTiposObra.MdiParent = Me
            frmTiposObra.WindowState = FormWindowState.Maximized
            frmTiposObra.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonAseguradoras_Click(sender As Object, e As EventArgs) Handles btonAseguradoras.Click
        Try
            Dim frmAseguradoras As New frmAseguradoras
            frmAseguradoras.MdiParent = Me
            frmAseguradoras.WindowState = FormWindowState.Maximized
            frmAseguradoras.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonTipoPolizas_Click(sender As Object, e As EventArgs) Handles btonTipoPolizas.Click
        Try
            Dim frmPoliza As New frmPolizas
            frmPoliza.MdiParent = Me
            frmPoliza.WindowState = FormWindowState.Maximized
            frmPoliza.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonTiposEscrituras_Click(sender As Object, e As EventArgs) Handles btonTiposEscrituras.Click
        Try
            Dim frmTipoescritura As New frmTipoEscritura
            frmTipoescritura.MdiParent = Me
            frmTipoescritura.WindowState = FormWindowState.Maximized
            frmTipoescritura.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonCamarasComercio_Click(sender As Object, e As EventArgs) Handles btonCamarasComercio.Click
        Try
            Dim frmCamarasComercio As New frmCiudadesCamaraC
            frmCamarasComercio.MdiParent = Me
            frmCamarasComercio.WindowState = FormWindowState.Maximized
            frmCamarasComercio.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonTipoAnticipo_Click(sender As Object, e As EventArgs) Handles btonTipoAnticipo.Click
        Try
            Dim frmTipoAnticipos As New frmTipoAnticipo
            frmTipoAnticipos.MdiParent = Me
            frmTipoAnticipos.WindowState = FormWindowState.Maximized
            frmTipoAnticipos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonVariablesMinutas_Click(sender As Object, e As EventArgs) Handles btonVariablesMinutas.Click
        Try
            Dim frmPedido As New FrmCreacionVariables
            frmPedido.MdiParent = Me
            frmPedido.WindowState = FormWindowState.Maximized
            frmPedido.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonFormatosMinutas_Click(sender As Object, e As EventArgs) Handles btonFormatosMinutas.Click
        Try
            Dim frmformatos As New frmEsquemasContratos
            frmformatos.MdiParent = Me
            frmformatos.WindowState = FormWindowState.Maximized
            frmformatos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Parámetros Notas"
    Private Sub btonTiposNotas_Click(sender As Object, e As EventArgs) Handles btonTiposNotas.Click
        Try
            Dim frmTiposNotas As New FrmTiposNotas
            frmTiposNotas.MdiParent = Me
            frmTiposNotas.WindowState = FormWindowState.Maximized
            frmTiposNotas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonEsquemaNotas_Click(sender As Object, e As EventArgs) Handles btonEsquemaNotas.Click
        Try
            Dim frmEsquema As New FrmEsquemaInforme
            frmEsquema.MdiParent = Me
            frmEsquema.WindowState = FormWindowState.Maximized
            frmEsquema.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonOrigenesNotas_Click(sender As Object, e As EventArgs) Handles btonOrigenesNotas.Click
        Try
            Dim frmOrigen As New FrmOrigenesNotas
            frmOrigen.MdiParent = Me
            frmOrigen.WindowState = FormWindowState.Maximized
            frmOrigen.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Parámetros Cotizaciones"
    Private Sub btonDirectores_Click(sender As Object, e As EventArgs) Handles btonDirectores.Click
        Try
            Dim Directores As New FrmDirectores
            Directores.MdiParent = Me
            Directores.WindowState = FormWindowState.Maximized
            Directores.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonVendedores_Click(sender As Object, e As EventArgs) Handles btonVendedores.Click
        Try
            Dim Vendedores As New FrmVendedores
            Vendedores.MdiParent = Me
            Vendedores.WindowState = FormWindowState.Maximized
            Vendedores.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonFactores_Click(sender As Object, e As EventArgs) Handles btonFactores.Click
        Try
            Dim Factores As New FrmFactores
            Factores.MdiParent = Me
            Factores.WindowState = FormWindowState.Maximized
            Factores.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonFormasPago_Click(sender As Object, e As EventArgs) Handles btonFormasPago.Click
        Try
            Dim FormasPago As New FrmFormasPago
            FormasPago.MdiParent = Me
            FormasPago.WindowState = FormWindowState.Maximized
            FormasPago.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonImpuestos_Click(sender As Object, e As EventArgs) Handles btonImpuestos.Click
        Try
            Dim impuestos As New FrmImpuestos
            impuestos.MdiParent = Me
            impuestos.WindowState = FormWindowState.Maximized
            impuestos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonInstalacion_Click(sender As Object, e As EventArgs) Handles btonInstalacion.Click
        Try
            Dim Instalacion As New FrmInstalacion
            Instalacion.MdiParent = Me
            Instalacion.WindowState = FormWindowState.Maximized
            Instalacion.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonParametrosAIU_Click(sender As Object, e As EventArgs) Handles btonParametrosAIU.Click
        Try
            Dim frmParametrosAIU As New FrmParametrosAIU
            frmParametrosAIU.MdiParent = Me
            frmParametrosAIU.WindowState = FormWindowState.Maximized
            frmParametrosAIU.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonTiempoEntrega_Click_1(sender As Object, e As EventArgs) Handles btonTiempoEntrega.Click
        Try
            Dim TiemposEntrega As New FrmTiempoEntrega
            TiemposEntrega.MdiParent = Me
            TiemposEntrega.WindowState = FormWindowState.Maximized
            TiemposEntrega.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonTiposIdentificacion_Click(sender As Object, e As EventArgs) Handles btonTiposIdentificacion.Click
        Try
            Dim tiposIdentificacion As New FrmTiposIdentificacion
            tiposIdentificacion.MdiParent = Me
            tiposIdentificacion.WindowState = FormWindowState.Maximized
            tiposIdentificacion.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonTipoObra_Click(sender As Object, e As EventArgs) Handles btonTipoObra.Click
        Try
            Dim tipoObra As New FrmTiposObra
            tipoObra.MdiParent = Me
            tipoObra.WindowState = FormWindowState.Maximized
            tipoObra.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonVigencias_Click(sender As Object, e As EventArgs) Handles btonVigencias.Click
        Try
            Dim frmVigencia As New FrmVigencias
            frmVigencia.MdiParent = Me
            frmVigencia.WindowState = FormWindowState.Maximized
            frmVigencia.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonCondiciones_Click(sender As Object, e As EventArgs) Handles btonCondiciones.Click
        Try
            Dim newCondition As New FrmCondicionesCotiza
            newCondition.MdiParent = Me
            newCondition.WindowState = FormWindowState.Maximized
            newCondition.operacionActual = ReglasNegocio.ClsEnums.TiOperacion.INSERTAR
            newCondition.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonGruposCondiciones_Click(sender As Object, e As EventArgs) Handles btonGruposCondiciones.Click
        Try
            Dim frmGrupoCondiciones As New frmGruposCondicionesComerciales
            frmGrupoCondiciones.MdiParent = Me
            frmGrupoCondiciones.TipoOperacion = ClsEnums.TiOperacion.INSERTAR
            frmGrupoCondiciones.WindowState = FormWindowState.Maximized
            frmGrupoCondiciones.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonDuracionDuplicacion_Click(sender As Object, e As EventArgs) Handles btonDuracionDuplicacion.Click
        Try
            Dim frmDuracion As New FrmDuracionDuplicacion
            frmDuracion.MdiParent = Me
            frmDuracion.WindowState = FormWindowState.Maximized
            frmDuracion.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Parámetros instalacion"
    Private Sub btnProveedores_Click(sender As Object, e As EventArgs) Handles btnProveedores.Click
        Try
            Dim frmProveedores As New frmProveedores
            frmProveedores.MdiParent = Me
            frmProveedores.WindowState = FormWindowState.Maximized
            frmProveedores.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnEncargados_Click(sender As Object, e As EventArgs) Handles btnEncargados.Click
        Try
            Dim frmEncargados As New frmEncargados
            frmEncargados.MdiParent = Me
            frmEncargados.WindowState = FormWindowState.Maximized
            frmEncargados.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnConceptos_Click(sender As Object, e As EventArgs) Handles btnConceptos.Click
        Try
            Dim frmConceptos As New frmConceptos
            frmConceptos.MdiParent = Me
            frmConceptos.WindowState = FormWindowState.Maximized
            frmConceptos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnListaPrecios_Click(sender As Object, e As EventArgs) Handles btnListaPrecios.Click
        Try
            Dim frmListaPrecio As New frmListaPrecios
            frmListaPrecio.MdiParent = Me
            frmListaPrecio.WindowState = FormWindowState.Maximized
            frmListaPrecio.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnTiposCuentas_Click(sender As Object, e As EventArgs) Handles btnTiposCuentas.Click
        Try
            Dim frmTiposCuentas As New frmTiposCuentas
            frmTiposCuentas.MdiParent = Me
            frmTiposCuentas.WindowState = FormWindowState.Maximized
            frmTiposCuentas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnTiposOrdenesTrabajo_Click(sender As Object, e As EventArgs) Handles btnTiposOrdenesTrabajo.Click
        Try
            Dim frmTiposOrdtrabajo As New frmTiposOrdenesTrabajo
            frmTiposOrdtrabajo.MdiParent = Me
            frmTiposOrdtrabajo.WindowState = FormWindowState.Maximized
            frmTiposOrdtrabajo.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnDocumentos_Click(sender As Object, e As EventArgs) Handles btnDocumentos.Click
        Try
            Dim frmDocumentosOrdenTrabajo As New frmDocumentosOT
            frmDocumentosOrdenTrabajo.MdiParent = Me
            frmDocumentosOrdenTrabajo.WindowState = FormWindowState.Maximized
            frmDocumentosOrdenTrabajo.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#End Region
#Region "Parámetros producción"
#Region "Generales"
    Private Sub btnTercerosProduccion_Click_1(sender As Object, e As EventArgs) Handles btnTercerosProduccion.Click
        Try
            Dim frmtercprod As New Frmtercerosproduccion
            frmtercprod.MdiParent = Me
            frmtercprod.WindowState = FormWindowState.Maximized
            frmtercprod.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnMotivosDevolucionOP_Click_1(sender As Object, e As EventArgs) Handles btnMotivosDevolucionOP.Click
        Try
            Dim frmmotdevol As New FrmMotivosDevolucionProduccion
            frmmotdevol.MdiParent = Me
            frmmotdevol.WindowState = FormWindowState.Maximized
            frmmotdevol.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Calidad"
    Private Sub btnSecciones_Click(sender As Object, e As EventArgs) Handles btnSecciones.Click
        Try
            Dim frmSecciones As New frmSecciones
            frmSecciones.MdiParent = Me
            frmSecciones.WindowState = FormWindowState.Maximized
            frmSecciones.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnMotivosxSeccion_Click(sender As Object, e As EventArgs) Handles btnMotivosxSeccion.Click
        Try
            Dim frmMotivosxSeccion As New frmMotivosPorSecciones
            frmMotivosxSeccion.MdiParent = Me
            frmMotivosxSeccion.WindowState = FormWindowState.Maximized
            frmMotivosxSeccion.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnCausas_Click(sender As Object, e As EventArgs) Handles btnCausas.Click
        Try
            Dim frmCausas As New frmCausas
            frmCausas.MdiParent = Me
            frmCausas.WindowState = FormWindowState.Maximized
            frmCausas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnMotivosxCausa_Click(sender As Object, e As EventArgs) Handles btnMotivosxCausa.Click
        Try
            Dim frmMotivosxCausa As New frmMotivosPorCausas
            frmMotivosxCausa.MdiParent = Me
            frmMotivosxCausa.WindowState = FormWindowState.Maximized
            frmMotivosxCausa.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnDestinatarios_Click(sender As Object, e As EventArgs) Handles btnDestinatarios.Click
        Try
            Dim frmDestinatarios As New frmDestinatarios
            frmDestinatarios.MdiParent = Me
            frmDestinatarios.WindowState = FormWindowState.Maximized
            frmDestinatarios.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#End Region
#End Region
#Region "MANUFACTURA"
#Region "Ingeniería"
    Private Sub btnagregarPlantilla_Click(sender As Object, e As EventArgs) Handles btnagregarPlantilla.Click
        Try
            Dim plantillamodel As New FrmPlantillaModelo
            plantillamodel.MdiParent = Me
            plantillamodel.WindowState = FormWindowState.Maximized
            plantillamodel.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnlistaplantillas_Click(sender As Object, e As EventArgs) Handles btnlistaplantillas.Click
        Try
            Dim listaplantillas As New FrmListaPlantillas
            listaplantillas.MdiParent = Me
            listaplantillas.WindowState = FormWindowState.Maximized
            listaplantillas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Producción"
#End Region
#Region "Depto. técnico"
    Private Sub btnopaprobadas_Click(sender As Object, e As EventArgs) Handles btnopaprobadas.Click
        Try
            Dim frmOpAprobadas As New FrmOpAprobadas
            frmOpAprobadas.MdiParent = Me
            frmOpAprobadas.WindowState = FormWindowState.Maximized
            frmOpAprobadas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Logística"
#End Region
#Region "Perfilería"
#End Region
#Region "Consultas y reportes"
#End Region
#End Region
#Region "COMERCIAL"
#Region "Ventas"
    Private Sub btnCotizaciones_Click(sender As Object, e As EventArgs) Handles btnGeneraCotizaciones.Click
        Try
            Dim frm As New FrmCotizaciones
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnVerCotizaciones_Click(sender As Object, e As EventArgs) Handles btnVerCotizaciones.Click
        Try
            Dim verCotiza As New FrmVerCotizaciones
            verCotiza.MdiParent = Me
            verCotiza.WindowState = FormWindowState.Maximized
            verCotiza.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnRepFacturables_Click(sender As Object, e As EventArgs) Handles btnRepFacturables.Click
        Try
            Dim frmPedido As New frmPedido
            frmPedido.MdiParent = Me
            frmPedido.WindowState = FormWindowState.Maximized
            frmPedido.PedidoFacturable = True
            frmPedido.Text += " facturable"
            frmPedido.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnRepNoFacturables_Click(sender As Object, e As EventArgs) Handles btnRepNoFacturables.Click
        Try
            Dim frmPedido As New frmPedido
            frmPedido.MdiParent = Me
            frmPedido.WindowState = FormWindowState.Maximized
            frmPedido.PedidoFacturable = False
            frmPedido.Text += " no facturable"
            frmPedido.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnBuscarxVendedor_Click(sender As Object, e As EventArgs) Handles btnBuscarxVendedor.Click
        Try
            MessageBox.Show("Crear formulario de búsqueda pedidos rep")
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnregistrodeproblemas_Click(sender As Object, e As EventArgs) Handles btnregistrodeproblemas.Click
        Try
            Dim frmProblemas As New FrmRegistroProblemasProduccion
            frmProblemas.MdiParent = Me
            frmProblemas.WindowState = FormWindowState.Maximized
            frmProblemas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnlistaproblemas_Click(sender As Object, e As EventArgs) Handles btnlistaproblemas.Click
        Try
            Dim frm As New FrmlistaProblemasRegistrados
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Contratos"
    Private Sub btonListaContratos_Click_1(sender As Object, e As EventArgs) Handles btonListaContratos.Click
        Try
            Dim frmContratos As New FrmListaContratos
            frmContratos.MdiParent = Me
            frmContratos.WindowState = FormWindowState.Maximized
            frmContratos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btonNotasDirectas_Click(sender As Object, e As EventArgs) Handles btonNotasDirectas.Click
        Try
            Dim frmNotas As New FrmNotas
            frmNotas.MdiParent = Me
            frmNotas.WindowState = FormWindowState.Maximized
            frmNotas.origenNota = ClsEnums.OrigenNota.DIRECTA
            frmNotas.Text += " directas"
            frmNotas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonNotasDesdeContratos_Click(sender As Object, e As EventArgs) Handles btonNotasDesdeAnticipos.Click
        Try
            Dim frm As New FrmNotasDesdeAnticipo
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonListaNotasCobro_Click(sender As Object, e As EventArgs) Handles btonListaNotasCobro.Click
        Try
            Dim frmListadoNotas As New FrmListadoNotas
            frmListadoNotas.MdiParent = Me
            frmListadoNotas.WindowState = FormWindowState.Maximized
            frmListadoNotas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnIngresoyModi_Click(sender As Object, e As EventArgs) Handles btnIngresoyModi.Click
        Try
            Dim frmPolizas As New FrmRegistroPolizas
            frmPolizas.MdiParent = Me
            frmPolizas.WindowState = FormWindowState.Maximized
            frmPolizas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnFechasProduccion_Click(sender As Object, e As EventArgs) Handles btnFechasProduccion.Click
        Try
            Dim frmPlaneacion As New FrmPlaneacion
            frmPlaneacion.MdiParent = Me
            frmPlaneacion.WindowState = FormWindowState.Maximized
            frmPlaneacion.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Instalacion"
    Private Sub btnNuevaOrden_Click(sender As Object, e As EventArgs) Handles btnNuevaOrden.Click
        Try
            Dim frmNuevaOrden As New frmContratosOT
            frmNuevaOrden.MdiParent = Me
            frmNuevaOrden.WindowState = FormWindowState.Maximized
            frmNuevaOrden.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnListaOrdenesTrabajo_Click(sender As Object, e As EventArgs) Handles btnListaOrdenesTrabajo.Click
        Try
            Dim frmListaOrdenesTrabajo As New frmListaOrdenesTrabajo
            frmListaOrdenesTrabajo.MdiParent = Me
            frmListaOrdenesTrabajo.WindowState = FormWindowState.Maximized
            frmListaOrdenesTrabajo.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnCuentaxContrato_Click(sender As Object, e As EventArgs) Handles btnCuentaxContrato.Click
        Try
            Dim frmCuentaxContrato As New frmListaOT
            frmCuentaxContrato.MdiParent = Me
            frmCuentaxContrato.WindowState = FormWindowState.Maximized
            frmCuentaxContrato.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnListaCuentasxOT_Click(sender As Object, e As EventArgs) Handles btnListaCuentasxOT.Click
        Try
            Dim frmListaCuentas As New frmListaCuentasCobro
            frmListaCuentas.MdiParent = Me
            frmListaCuentas.WindowState = FormWindowState.Maximized
            frmListaCuentas.TipoCuentaCobro = ClsEnums.TipoCuentaCobro.DESDE_OT
            frmListaCuentas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnCuentaDirecta_Click(sender As Object, e As EventArgs) Handles btnCuentaDiracta.Click
        Try
            Dim frmCuentaCobro As New frmCuentaCobroDirecta
            frmCuentaCobro.MdiParent = Me
            frmCuentaCobro.WindowState = FormWindowState.Maximized
            frmCuentaCobro.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnListaCuentasDirectas_Click(sender As Object, e As EventArgs) Handles btnListaCuentasDirectas.Click
        Try
            Dim frmListaCuentas As New frmListaCuentasCobro
            frmListaCuentas.MdiParent = Me
            frmListaCuentas.WindowState = FormWindowState.Maximized
            frmListaCuentas.TipoCuentaCobro = ClsEnums.TipoCuentaCobro.DIRECTAS
            frmListaCuentas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnPagoRetenidos_Click(sender As Object, e As EventArgs) Handles btnPagoRetenidos.Click
        Try
            Dim frmPagoRet As New frmPagoRetenidos
            frmPagoRet.MdiParent = Me
            frmPagoRet.WindowState = FormWindowState.Maximized
            frmPagoRet.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnRetenidosPagados_Click(sender As Object, e As EventArgs) Handles btnRetenidosPagados.Click
        Try
            Dim frmRetPagados As New frmRetenidosPagados
            frmRetPagados.MdiParent = Me
            frmRetPagados.WindowState = FormWindowState.Maximized
            frmRetPagados.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnDetallePago_Click(sender As Object, e As EventArgs) Handles btnDetallePago.Click
        Try
            Dim frmDetallePago As New frmDetallePagados
            frmDetallePago.MdiParent = Me
            frmDetallePago.WindowState = FormWindowState.Maximized
            frmDetallePago.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnNuevaDevolucion_Click(sender As Object, e As EventArgs) Handles btnNuevaDevolucion.Click
        Try
            Dim frmListaCuentas As New frmListaCuentasCobro
            frmListaCuentas.MdiParent = Me
            frmListaCuentas.WindowState = FormWindowState.Maximized
            frmListaCuentas.VistaParaDevolucion = True
            frmListaCuentas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnListaDevoluciones_Click(sender As Object, e As EventArgs) Handles btnListaDevoluciones.Click
        Try
            Dim frmListaDevoluciones As New frmListaDevoluciones
            frmListaDevoluciones.MdiParent = Me
            frmListaDevoluciones.WindowState = FormWindowState.Maximized
            frmListaDevoluciones.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnCuentasPorFecha_Click(sender As Object, e As EventArgs) Handles btnCuentasPorFecha.Click
        Try
            Dim frmCuentasPorFecha As New frmCuentasPorFecha
            frmCuentasPorFecha.MdiParent = Me
            frmCuentasPorFecha.WindowState = FormWindowState.Maximized
            frmCuentasPorFecha.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnOrdenesVsCuentas_Click(sender As Object, e As EventArgs) Handles btnOrdenesVsCuentas.Click
        Try
            Dim frmOrdenesVsCuentas As New frmOrdenesVsCuentas
            frmOrdenesVsCuentas.MdiParent = Me
            frmOrdenesVsCuentas.WindowState = FormWindowState.Maximized
            frmOrdenesVsCuentas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#End Region
    Private Sub frmInicial_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Try
            If e.Control And e.KeyCode = Keys.F1 Then
                Dim mpruebas As New FrmMenuPruebas
                FrmMenuPruebas.Show()
            ElseIf e.Control And e.KeyCode = Keys.G Then
                btnGuardar.ForzeClick(New EventArgs())
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonCrearContrato_Click(sender As Object, e As EventArgs)
        Try
            Dim newContract As New frmContratos
            newContract.MdiParent = Me
            newContract.WindowState = FormWindowState.Maximized
            newContract.operacionActual = ReglasNegocio.ClsEnums.TiOperacion.INSERTAR
            newContract.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mmmodulosaplicacion_Click(sender As Object, e As EventArgs) Handles mmmodulosaplicacion.Click
        Try
            Dim modulos As New FrmModulosAplicacion
            modulos.MdiParent = Me
            modulos.WindowState = FormWindowState.Maximized
            modulos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btndepartamentos_Click(sender As Object, e As EventArgs) Handles btndepartamentos.Click
        Try
            Dim departamentos As New FrmDepartamentosAlco
            departamentos.MdiParent = Me
            departamentos.WindowState = FormWindowState.Maximized
            departamentos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnusuarios_Click(sender As Object, e As EventArgs) Handles btnusuarios.Click
        Try
            Dim usuarios As New FrmUsuarios
            usuarios.MdiParent = Me
            usuarios.WindowState = FormWindowState.Maximized
            usuarios.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btngrupos_Click(sender As Object, e As EventArgs) Handles btngrupos.Click
        Try
            Dim grupos As New FrmGruposSeguridad
            grupos.MdiParent = Me
            grupos.WindowState = FormWindowState.Maximized
            grupos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnpermisos_Click(sender As Object, e As EventArgs) Handles btnpermisos.Click
        Try
            Dim permisos As New FrmPermisos
            permisos.MdiParent = Me
            permisos.WindowState = FormWindowState.Maximized
            permisos.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnmodificarmasivo_Click(sender As Object, e As EventArgs) Handles btnmodificarmasivo.Click
        Try
            Dim modificamasivo As New FrmModificadorGlobalFormulas
            modificamasivo.MdiParent = Me
            modificamasivo.WindowState = FormWindowState.Maximized
            modificamasivo.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonlapendientecontrato_Click(sender As Object, e As EventArgs) Handles btonlapendientecontrato.Click
        Try
            Dim pendcontratar As New FrmContratosPendientes
            pendcontratar.MdiParent = Me
            pendcontratar.WindowState = FormWindowState.Maximized
            pendcontratar.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btontipoformato_Click(sender As Object, e As EventArgs) Handles btontipoformato.Click
        Try
            Dim tformat As New FrmTiposFormato
            tformat.MdiParent = Me
            tformat.WindowState = FormWindowState.Maximized
            tformat.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnpermisosextra_Click(sender As Object, e As EventArgs) Handles btnpermisosextra.Click
        Try
            Dim tperm As New FrmPermisosExtra
            tperm.MdiParent = Me
            tperm.WindowState = FormWindowState.Maximized
            tperm.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnArticulos_Click(sender As Object, e As EventArgs) Handles mnArticulos.Click
        Try
            Dim tperm As New FrmArticulos
            tperm.MdiParent = Me
            tperm.WindowState = FormWindowState.Maximized
            tperm.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub frmInicial_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            EscribirXML()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnimprimirop_Click(sender As Object, e As EventArgs) Handles btnimprimirop.Click
        Try
            Dim frmAprobacion As New FrmListaParaAprobaciones
            frmAprobacion.MdiParent = Me
            frmAprobacion.WindowState = FormWindowState.Maximized
            frmAprobacion.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btngenerarordenpedido_Click(sender As Object, e As EventArgs) Handles btngenerarordenpedido.Click
        Try
            Dim tformat As New FrmListaParaOrdenes
            tformat.MdiParent = Me
            tformat.WindowState = FormWindowState.Maximized
            tformat.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

#Region "Consola"
    <DllImport("kernel32.dll")> Public Shared Function AllocConsole() As Boolean
    End Function
    <DllImport("kernel32.dll")> Public Shared Function FreeConsole() As Boolean
    End Function
    Private Sub rbconsola_Click(sender As Object, e As EventArgs) Handles rbconsola.Click
        Try
            My.Settings.Consola = rbconsola.Checked
            Formulador.Formulacion_General.Configuraciones.Modificar_Consola(rbconsola.Checked)
            If rbconsola.Checked Then
                AllocConsole()
            Else
                FreeConsole()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub btnlistaordenespedido_Click(sender As Object, e As EventArgs) Handles btnlistaordenespedido.Click
        Try
            Dim tformat As New FrmListarOrdenesPedido
            tformat.MdiParent = Me
            tformat.WindowState = FormWindowState.Maximized
            tformat.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mmConectoresPlanosSiesa_Click(sender As Object, e As EventArgs) Handles mmConectoresPlanosSiesa.Click
        Try
            Dim tConectoresSiesa As New FrmConectoresPlanos
            tConectoresSiesa.MdiParent = Me
            tConectoresSiesa.WindowState = FormWindowState.Maximized
            tConectoresSiesa.TipoOperacion = ClsEnums.TiOperacion.INSERTAR
            tConectoresSiesa.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnFormularios_Click(sender As Object, e As EventArgs) Handles mnControlescon.Click
        Try
            Dim fforms As New FrmControlesEnlaceConectores
            fforms.MdiParent = Me
            fforms.WindowState = FormWindowState.Maximized
            fforms.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub mninformesdinamicos_Click(sender As Object, e As EventArgs) Handles mninformesdinamicos.Click
        Try
            Dim frminfd As New FrmInformesDinamicos
            frminfd.MdiParent = Me
            frminfd.WindowState = FormWindowState.Maximized
            frminfd.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnabrirproblema_Click(sender As Object, e As EventArgs) Handles btnabrirproblema.Click
        Try
            Dim frmListaProblemas As New FrmListaProblemasProduccion
            frmListaProblemas.MdiParent = Me
            frmListaProblemas.WindowState = FormWindowState.Maximized
            frmListaProblemas.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btninfdinamicosman_Click(sender As Object, e As EventArgs) Handles btninfdinamicosman.Click
        Try
            Dim frminfd As New FrmCargadorInformesDinamicos
            frminfd.MdiParent = Me
            frminfd.WindowState = FormWindowState.Maximized
            frminfd.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub mnmedsperfileria_Click(sender As Object, e As EventArgs) Handles mnmedsperfileria.Click
        Try
            Dim frmmed As New Frmmedidasperfileria
            frmmed.MdiParent = Me
            frmmed.WindowState = FormWindowState.Maximized
            frmmed.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonpermisos_Click(sender As Object, e As EventArgs) Handles btonpermisos.Click
        Try
            CargarPermisos()
            AplicarPermisos(Me)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btoncostosadicionalesobra_Click(sender As Object, e As EventArgs) Handles btoncostosadicionalesobra.Click
        Try
            Dim frmmcad As New FrmCostosAdicionalesObra
            frmmcad.MdiParent = Me
            frmmcad.WindowState = FormWindowState.Maximized
            frmmcad.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub


End Class
