Imports ReglasNegocio
Public Class FrmPermisos

#Region "Variables"
    Private mpermiso As ClsPermisosAplicacion
    Private mUsuarios As ClsUsuarios
    Private mGrupos As ClsGruposSeguridad
    Private seguridadGrupos As New ClsPermisosxGrupo
    Private seguridadUsuario As New ClsPermisosxUsuario
    Private tipoSegurdad As ClsEnums.Tipo_seguridad = ClsEnums.Tipo_seguridad.GRUPO
    Private checkedName As String
    Private todosLosPermisos As New TreeView
    Private listapermisos As New List(Of Permiso)
#End Region

#Region "Procedimientos"
    ''' <summary>
    ''' Procedimiento que carga la información de los permisos según el id de usuario
    ''' </summary>
    Public Sub cargarUsuarios()
        Try
            Dim mUsuarios As New ClsUsuarios
            Dim usr As List(Of Usuario) = mUsuarios.TraerTodos().ToList.Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO).ToList
            For Each u As Usuario In usr
                Dim ndUsuario As New TreeNode
                ndUsuario.Text = u.Usuario
                ndUsuario.Tag = u.IdGrupo
                ndUsuario.Name = u.Id
                twusuarios.Nodes.Add(ndUsuario)
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que carga la información de los permisos del grupo según el id del grupo
    ''' </summary>
    Public Sub CargarGrupos()
        Try
            Dim mGrupos As New ClsGruposSeguridad
            Dim grp As List(Of GrupoSeguridad) = mGrupos.TraerTodos().ToList.Where(Function(a) a.IdEstado = ClsEnums.Estados.ACTIVO).ToList
            For Each g As GrupoSeguridad In grp
                Dim ndGrupo As New TreeNode
                ndGrupo.Text = g.Grupo
                ndGrupo.Tag = g.Id
                ndGrupo.Name = g.Id
                twGrupos.Nodes.Add(ndGrupo)
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Selecciona todos los nodos del treeView de permisos
    ''' </summary>
    Public Sub seleccionar()
        Try
            For Each n As TreeNode In twPermisos.Nodes
                If Not n.Text = "Seleccionar todos" Then
                    seleccionNodoInterno(True, n)
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Des selecciona los hijos del nodo referencia y el treeview referencia
    ''' </summary>
    ''' <param name="tw">TreeView al que se le va ha realizar la acción de des selección</param>
    ''' <param name="nodoReferencia"></param>
    Public Sub desseleccionar(tw As TreeView, Optional nodoReferencia As TreeNode = Nothing)
        Try
            For Each n As TreeNode In tw.Nodes
                If nodoReferencia IsNot Nothing Then
                    If nodoReferencia.Name = n.Name Then
                    Else
                        seleccionNodoInterno(False, n)
                    End If
                Else
                    seleccionNodoInterno(False, n)
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Selecciona los nodos internos cuando el nodo tiene hijos
    ''' </summary>
    ''' <param name="seleccionas">indicador de acción bolean, true para seleccionar, false para des seleccionar</param>
    ''' <param name="ndp">objeto de tipo treenode a tratar</param>
    Public Sub seleccionNodoInterno(seleccionas As Boolean, Optional ndp As TreeNode = Nothing)
        Try
            ndp.Checked = seleccionas

            For Each nd As TreeNode In ndp.Nodes
                nd.Checked = seleccionas
                seleccionNodoInterno(seleccionas, nd)
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que recorre todos los controles del ribbon35 principal para realizar
    ''' la carga de los permisos disponibles
    ''' </summary>
    ''' <param name="cnt">Recibe un objeto de tipo Ribbon35</param>
    ''' <param name="arbol">TreeView al que se le crearan los nodos según los controles del ribbon35</param>
    ''' <param name="nodo">Nodo que se va a tratar</param>
    Public Sub recorrerPestañas(cnt As Object, arbol As TreeView, Optional nodo As TreeNode = Nothing)
        Try
            Select Case True
                Case TypeOf (cnt) Is Ribbon
                    arbol.Nodes.Add("Seleccionar todos")
                    For Each quickmenoitem In DirectCast(cnt, Ribbon).QuickAcessToolbar.Items
                        Dim itemAccesorapido As New TreeNode
                        If Not String.IsNullOrEmpty(DirectCast(quickmenoitem, RibbonButton).Text) Then
                            itemAccesorapido.Name = DirectCast(quickmenoitem, RibbonButton).Tag
                            itemAccesorapido.Text = DirectCast(quickmenoitem, RibbonButton).Text
                            itemAccesorapido.Tag = DirectCast(quickmenoitem, RibbonButton).Tag
                            If String.IsNullOrEmpty(Convert.ToString(itemAccesorapido.Tag)) Then
                                itemAccesorapido.ForeColor = Color.Red
                                itemAccesorapido.ToolTipText = "Debe asignarle un TAG al control para validar el permiso."
                            Else
                                listapermisos.Add(New Permiso(itemAccesorapido.Name, False))
                            End If
                            arbol.Nodes.Add(itemAccesorapido)
                        End If
                        recorrerPestañas(quickmenoitem, arbol, itemAccesorapido)
                    Next

                    For Each setupmenu In DirectCast(cnt, Ribbon).OrbDropDown.MenuItems
                        Dim ndItems As New TreeNode
                        ndItems.Name = DirectCast(setupmenu, RibbonButton).Tag
                        ndItems.Text = DirectCast(setupmenu, RibbonButton).Text
                        ndItems.Tag = DirectCast(setupmenu, RibbonButton).Tag
                        If String.IsNullOrEmpty(Convert.ToString(ndItems.Tag)) Then
                            ndItems.ForeColor = Color.Red
                            ndItems.ToolTipText = "Debe asignarle un TAG al control para validar el permiso."
                        Else
                            listapermisos.Add(New Permiso(ndItems.Name, False))
                        End If
                        arbol.Nodes.Add(ndItems)
                        recorrerPestañas(setupmenu, arbol, ndItems)
                    Next
                    For Each pestaña In DirectCast(cnt, Ribbon).Tabs
                        Dim ndPestaña As New TreeNode
                        ndPestaña.Name = DirectCast(pestaña, RibbonTab).Tag
                        ndPestaña.Text = DirectCast(pestaña, RibbonTab).Text
                        ndPestaña.Tag = DirectCast(pestaña, RibbonTab).Tag
                        If String.IsNullOrEmpty(Convert.ToString(ndPestaña.Tag)) Then
                            ndPestaña.ForeColor = Color.Red
                            ndPestaña.ToolTipText = "Debe asignarle un TAG al control para validar el permiso."
                        Else
                            listapermisos.Add(New Permiso(ndPestaña.Name, False))
                        End If
                        arbol.Nodes.Add(ndPestaña)
                        recorrerPestañas(pestaña, arbol, ndPestaña)
                    Next
                Case TypeOf (cnt) Is RibbonTab
                    For Each hoja In DirectCast(cnt, RibbonTab).Panels
                        Dim ndpanel As New TreeNode
                        ndpanel.Name = DirectCast(hoja, RibbonPanel).Tag
                        ndpanel.Text = DirectCast(hoja, RibbonPanel).Text
                        ndpanel.Tag = DirectCast(hoja, RibbonPanel).Tag
                        If String.IsNullOrEmpty(Convert.ToString(ndpanel.Tag)) Then
                            ndpanel.ForeColor = Color.Red
                            ndpanel.ToolTipText = "Debe asignarle un TAG al control para validar el permiso."
                        Else
                            listapermisos.Add(New Permiso(ndpanel.Name, False))
                        End If
                        nodo.Nodes.Add(ndpanel)
                        recorrerPestañas(hoja, arbol, ndpanel)
                    Next
                Case TypeOf (cnt) Is RibbonPanel
                    For Each hijo In DirectCast(cnt, RibbonPanel).Items
                        If TypeOf hijo IsNot RibbonSeparator Then
                            Dim ndItems As New TreeNode
                            ndItems.Name = DirectCast(hijo, RibbonButton).Tag
                            ndItems.Text = DirectCast(hijo, RibbonButton).Text
                            ndItems.Tag = DirectCast(hijo, RibbonButton).Tag
                            If String.IsNullOrEmpty(Convert.ToString(ndItems.Tag)) Then
                                ndItems.ForeColor = Color.Red
                                ndItems.ToolTipText = "Debe asignarle un TAG al control para validar el permiso."
                            Else
                                listapermisos.Add(New Permiso(ndItems.Name, False))
                            End If
                            nodo.Nodes.Add(ndItems)
                            recorrerPestañas(hijo, arbol, ndItems)
                        End If
                    Next
                Case TypeOf (cnt) Is RibbonButton
                    For Each hBoton In DirectCast(cnt, RibbonButton).DropDownItems
                        If TypeOf hBoton IsNot RibbonSeparator Then
                            Dim ndItems As New TreeNode
                            ndItems.Name = DirectCast(hBoton, RibbonButton).Tag
                            ndItems.Text = DirectCast(hBoton, RibbonButton).Text
                            ndItems.Tag = DirectCast(hBoton, RibbonButton).Tag
                            If String.IsNullOrEmpty(Convert.ToString(ndItems.Tag)) Then
                                ndItems.ForeColor = Color.Red
                                ndItems.ToolTipText = "Debe asignarle un TAG al control para validar el permiso."
                            Else
                                listapermisos.Add(New Permiso(ndItems.Name, False))
                            End If
                            nodo.Nodes.Add(ndItems)
                            recorrerPestañas(hBoton, arbol, ndItems)
                        End If
                    Next
                Case Else
            End Select
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub CargarPermisosExtra()
        Try
            Dim modperm As New ClsModulosPermisoExtra
            Dim permex As New ClsPermisosExtra
            Dim lmods As List(Of ModuloPermisoExtra) = modperm.TraerTodosLista()
            For Each m As ModuloPermisoExtra In lmods
                Dim n As New TreeNode
                n.Name = m.Codigo
                n.Text = m.Modulo
                n.Tag = m.Codigo

                listapermisos.Add(New Permiso(m.Codigo, False))
                Dim lperms As List(Of PermisoExtra) = permex.TraerxIdModulo(m.Id)
                For Each p As PermisoExtra In lperms
                    Dim nh As New TreeNode
                    nh.Name = p.Codigo
                    nh.Text = p.Permiso
                    nh.Tag = p.Codigo
                    listapermisos.Add(New Permiso(p.Codigo, False))
                    n.Nodes.Add(nh)
                Next
                twPermisos.Nodes.Add(n)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que guarda la información según la los nodos seleccionados en el treeview de permisos
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try
            If tipoSegurdad = ClsEnums.Tipo_seguridad.GRUPO Then
                seguridadGrupos.Delete(checkedName)
                For Each ndp As TreeNode In twPermisos.Nodes
                    If (ndp.Text <> "Seleccionar todos" And ndp.Text <> "Cerrar") Then
                        If ndp.Nodes.Count > 0 Then
                            If ndp.Checked Then
                                seguridadGrupos.Insertar(My.Settings.UsuarioActivo, checkedName, ndp.Name)
                            End If
                            GuardarNodosHijos(ndp)
                        Else
                            If ndp.Checked Then
                                seguridadGrupos.Insertar(My.Settings.UsuarioActivo, checkedName, ndp.Name)
                            End If
                        End If
                    End If
                Next
            ElseIf tipoSegurdad = ClsEnums.Tipo_seguridad.USUARIO Then
                seguridadUsuario.Delete(checkedName)
                For Each ndp As TreeNode In twPermisos.Nodes
                    If (ndp.Text <> "Seleccionar todos" And ndp.Text <> "Cerrar") Then
                        If ndp.Nodes.Count > 0 Then
                            If ndp.Checked Then
                                seguridadUsuario.Insertar(My.Settings.UsuarioActivo, checkedName, ndp.Name)
                            End If
                            GuardarNodosHijosUsuario(ndp)
                        Else
                            If ndp.Checked Then
                                seguridadUsuario.Insertar(My.Settings.UsuarioActivo, checkedName, ndp.Name)
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que guarda la información de los nodos hijos cuando el padre los tiene y cuando 
    ''' la seguridad es por grupo
    ''' </summary>
    ''' <param name="nodo"></param>
    Private Sub GuardarNodosHijos(nodo As TreeNode)
        Try
            For Each n As TreeNode In nodo.Nodes
                If n.Checked Then
                    seguridadGrupos.Insertar(My.Settings.UsuarioActivo, checkedName, n.Name)
                    If n.Nodes.Count > 0 Then
                        GuardarNodosHijos(n)
                    End If
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que guarda la información del los nodos hijos cuando el padre los tiene y cuando
    ''' la seguridad es por usuario.
    ''' </summary>
    ''' <param name="nodo"></param>
    Private Sub GuardarNodosHijosUsuario(nodo As TreeNode)
        Try
            For Each n As TreeNode In nodo.Nodes
                If n.Checked Then
                    seguridadUsuario.Insertar(My.Settings.UsuarioActivo, checkedName, n.Name)
                    If n.Nodes.Count > 0 Then
                        GuardarNodosHijosUsuario(n)
                    End If
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    ''' <summary>
    ''' Procedimiento que busca un nodo especifico y lo selecciona
    ''' </summary>
    ''' <param name="nodo"></param>
    Private Sub buscarNodo(nodo As TreeNode, ByRef treeViewResult As TreeView)
        Try
            If nodo.Nodes.Count > 0 Then
                For Each ndp As TreeNode In nodo.Nodes
                    If (ReemplazarTildes(LCase(ndp.Text)) Like "*" & ReemplazarTildes(LCase(txtBuscar.Text)) & "*") Then
                        Dim t As TreeNode() = todosLosPermisos.Nodes.Find(ndp.Name, True)
                        treeViewResult.Nodes.AddRange(t)
                    ElseIf ndp.Nodes.Count > 0 Then
                        buscarNodo(ndp, treeViewResult)
                    End If
                Next
            Else
                If (ReemplazarTildes(LCase(nodo.Text)) Like "*" & ReemplazarTildes((LCase(txtBuscar.Text))) & "*") Then
                    Dim t As TreeNode() = todosLosPermisos.Nodes.Find(nodo.Name, True)
                    treeViewResult.Nodes.AddRange(t)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Public Function ReemplazarTildes(ByVal cadenas As String) As String
        ReemplazarTildes = String.Empty
        Dim result As String = String.Empty
        Try
            Dim tildes As New Dictionary(Of String, String)
            tildes.Add("á", "a")
            tildes.Add("é", "e")
            tildes.Add("í", "i")
            tildes.Add("ó", "o")
            tildes.Add("ú", "u")
            tildes.Add("ü", "u")
            For Each vocal In tildes
                cadenas = cadenas.Replace(vocal.Key, vocal.Value)
            Next
            Return cadenas
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Function

#End Region

#Region "Procedimientos Controles"
    Private Sub FrmPermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim frmPadre As New frmInicial
            cargarUsuarios()
            CargarGrupos()
            recorrerPestañas(frmPadre.rbprincipal, twPermisos)
            CargarPermisosExtra()
            CrearArbolTemporal()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub CrearArbolTemporal()
        Try
            For Each n As TreeNode In twPermisos.Nodes
                todosLosPermisos.Nodes.Add(DirectCast(n.Clone, TreeNode))
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub twPermisos_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles twPermisos.AfterCheck
        Try
            If e.Action <> TreeViewAction.Unknown Then
                If (DirectCast(e.Node, TreeNode).Text = "Seleccionar todos" And DirectCast(e.Node, TreeNode).Checked) Then
                    seleccionar()
                ElseIf (DirectCast(e.Node, TreeNode).Text = "Seleccionar todos" And DirectCast(e.Node, TreeNode).Checked = False) Then
                    desseleccionar(sender)
                ElseIf e.Node.Nodes.Count > 0 Then
                    If e.Node.Checked Then
                        If e.Node.Level <> 0 Then
                            e.Node.Parent.Checked = True
                            e.Node.Checked = True
                            seleccionNodoInterno(True, e.Node)
                        Else
                            e.Node.Checked = True
                            seleccionNodoInterno(True, e.Node)
                        End If
                    Else
                        If e.Node.Level <> 0 Then e.Node.Parent.Checked = False
                        seleccionNodoInterno(False, e.Node)
                    End If
                Else
                    If e.Node.Level <> 0 Then
                        If e.Node.Checked Then
                            e.Node.Parent.Checked = True
                        End If
                    End If
                End If
            End If
            If Not String.IsNullOrEmpty(Convert.ToString(e.Node.Tag)) Then
                listapermisos.FirstOrDefault(Function(x) x.Codigo.Equals(Convert.ToString(e.Node.Tag))).Utilizado = e.Node.Checked
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmPermisos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try

            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            Dim btnimprimirr As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimprimir
            Dim btnimpresion As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnimpresion
            Dim btnvistaprevia As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnvistaprevia
            btnsParcial.Enabled = False
            AddHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsTotal.Click, AddressOf GuardadoTotal_Click

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnexpandir_Click(sender As Object, e As EventArgs) Handles btnexpandir.Click
        Try
            twPermisos.ExpandAll()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncontraer_Click(sender As Object, e As EventArgs) Handles btncontraer.Click
        Try
            twPermisos.CollapseAll()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub twGrupos_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles twGrupos.AfterCheck
        Try
            If e.Action <> TreeViewAction.Unknown Then
                lbtipoSeguridad.Text = "SEGURIDAD POR GRUPO"
                checkedName = e.Node.Name
                tipoSegurdad = ClsEnums.Tipo_seguridad.GRUPO
                desseleccionar(twPermisos)
                Dim listaPermisoGrupo As List(Of permisoGrupo) = seguridadGrupos.TraerTodos().Where(Function(a) a.idGrupo = CInt(e.Node.Tag)).ToList
                desseleccionar(twGrupos, e.Node)
                desseleccionar(twusuarios)
                If e.Node.Checked Then
                    For Each lItem As permisoGrupo In listaPermisoGrupo
                        If twPermisos.Nodes.Find(lItem.codigoControl, True).Where(Function(a) a.Name = lItem.codigoControl).ToList.Count > 0 Then
                            twPermisos.Nodes.Find(lItem.codigoControl, True).Where(Function(a) a.Name = lItem.codigoControl).ToList.Item(0).Checked = True
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub twusuarios_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles twusuarios.AfterCheck
        Try
            If e.Action <> TreeViewAction.Unknown Then
                lbtipoSeguridad.Text = "SEGURIDAD POR USUARIO"
                checkedName = e.Node.Name
                tipoSegurdad = ClsEnums.Tipo_seguridad.USUARIO
                desseleccionar(twPermisos)
                desseleccionar(twGrupos)
                Dim listaPermisoUsuario As List(Of permisoUsuario) = seguridadUsuario.TraerTodos().Where(Function(a) a.idUsuario = CInt(e.Node.Name)).ToList
                desseleccionar(twusuarios, e.Node)
                If e.Node.Checked Then
                    For Each lItem As permisoUsuario In listaPermisoUsuario
                        If twPermisos.Nodes.Find(lItem.codigoControl, True).Where(Function(a) a.Name = lItem.codigoControl).ToList.Count > 0 Then
                            twPermisos.Nodes.Find(lItem.codigoControl, True).Where(Function(a) a.Name = lItem.codigoControl).ToList.Item(0).Checked = True
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btonBuscar_Click(sender As Object, e As EventArgs) Handles btonBuscar.Click
        Try
            txtBuscar_TextChanged(txtBuscar, e)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Try
            Dim result As Boolean = False
            Dim treeViewResul As New TreeView
            For Each n As TreeNode In todosLosPermisos.Nodes
                result = ReemplazarTildes(LCase(n.Text)) Like "*" & ReemplazarTildes(LCase(txtBuscar.Text)) & "*"
                If (result) Then
                    treeViewResul.Nodes.Add(DirectCast(n.Clone, TreeNode))
                Else
                    buscarNodo(n, treeViewResul)
                End If
            Next
            twPermisos.Nodes.Clear()
            For Each nodo As TreeNode In treeViewResul.Nodes
                Dim n As TreeNode = DirectCast(nodo.Clone, TreeNode)
                If Not String.IsNullOrEmpty(Convert.ToString(n.Tag)) Then
                    n.Checked = listapermisos.FirstOrDefault(Function(x) x.Codigo.Equals(Convert.ToString(n.Tag))).Utilizado
                Else
                    n.Checked = False
                End If
                Dim i As Integer = twPermisos.Nodes.Add(n)
                For Each nh As TreeNode In twPermisos.Nodes(i).Nodes
                    If Not String.IsNullOrEmpty(Convert.ToString(nh.Tag)) Then
                        nh.Checked = listapermisos.FirstOrDefault(Function(x) x.Codigo.Equals(Convert.ToString(nh.Tag))).Utilizado
                    Else
                        nh.Checked = False
                    End If
                Next
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
End Class