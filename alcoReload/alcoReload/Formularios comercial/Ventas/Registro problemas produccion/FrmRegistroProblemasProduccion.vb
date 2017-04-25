Imports Multiusos
Imports ReglasNegocio

Public Class FrmRegistroProblemasProduccion
#Region "Variables"
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR
    Private _curid As Integer = 0

    Private idPais As String
    Private idDepto As String
    Private idCiudad As String
    Private loadcompleted As Boolean = False
    Private isRuta As Boolean = False
#End Region
#Region "Propiedades"
    Public Property Operacion() As ClsEnums.TiOperacion
        Get
            Return tform
        End Get
        Set(ByVal value As ClsEnums.TiOperacion)
            tform = value
        End Set
    End Property
    Public Property Curid() As Integer
        Get
            Return _curid
        End Get
        Set(ByVal value As Integer)
            _curid = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarIntellisens()
        Try
            Dim mCliente As New clsClientesUnoee
            mCliente.t200_selectAllClientesUnoee(itNit.TablaFuente)
            itCliente.TablaFuente = itNit.TablaFuente
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarSecciones()
        Try
            Dim mSecciones As New ClsSecciones
            Dim listSecciones As List(Of seccion) = mSecciones.TraerTodos()
            cmbSeccion.ValueMember = "Id"
            cmbSeccion.DisplayMember = "Prefijo"
            cmbSeccion.DatosVisibles = {"Prefijo", "Descripcion"}
            cmbSeccion.DataSource = listSecciones
            cmbSeccion.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarVendedores()
        Try
            Dim mVendedor As New ClsVendedoresSiesa
            Dim listVendedores As List(Of vendedor) = mVendedor.TraerxEstado(ClsEnums.Estados.ACTIVO)
            cmbVendedor.ValueMember = "idSiesa"
            cmbVendedor.DatosVisibles = {"idSiesa", "Nombre"}
            cmbVendedor.DataSource = listVendedores
            cmbVendedor.SelectedItem = Nothing
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarInformacionObra()
        Try
            If loadcompleted Then
                If itCodigoObra.Text <> String.Empty And itObra.Text <> String.Empty Then
                    Dim mObras As New clsObrasUnoee
                    Dim obra As obrasUnoee = mObras.traerObraByNitClienteAndSuc(itNit.Text, itCodigoObra.Text)
                    txtContacto.Text = obra.nomContacto
                    idPais = obra.IdPais
                    idDepto = obra.IdDepartamento
                    idCiudad = obra.IdCiudad
                    txtCiudad.Text = obra.Ciudad
                    txtTelefono.Text = obra.telefono
                    txtFax.Text = obra.Fax
                    txtDireccion.Text = obra.direccion
                    cmbVendedor.Text = obra.idVendedor
                Else

                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarParaEdicion()
        Try
            Dim mEncabezado As New ClsEncabezadoProblemasP
            Dim enc As encabezadoPP = mEncabezado.TraerxId(_curid)
            dtpFecha.Value = enc.FechaRegistro
            lblConsecutivo.Text = enc.Consecutivo
            itNit.Text = enc.Nit
            itCliente.Text = enc.Cliente
            itCodigoObra.Text = enc.CodigoObra
            itObra.Text = enc.Obra
            txtContacto.Text = enc.Contacto
            txtCiudad.Text = enc.Ciudad
            txtTelefono.Text = enc.Telefono
            txtFax.Text = enc.Fax
            txtDireccion.Text = enc.Direccion
            cmbVendedor.SelectedValue = enc.IdVendedor
            txtVendedor.Text = enc.Vendedor
            cmbSeccion.SelectedValue = enc.IdSeccion
            txtOp.Text = enc.IdOp
            txtDescripcionProblema.Text = enc.DescripcionProblema
            idPais = enc.IdPais
            idDepto = enc.IdDepartamento
            idCiudad = enc.IdCiudad

            Dim mDocumentoPp As New ClsDocumentosProblemasP
            Dim listAdjuntos As List(Of documentoPP) = mDocumentoPp.TraerAdjuntos(_curid, 1)
            For Each doc As documentoPP In listAdjuntos
                Dim r As DataGridViewRow = dwArchivos.Rows(dwArchivos.Rows.Add())
                r.Cells(col_idAdjunto.Index).Value = doc.Id
                r.Cells(col_nombreArchivo.Index).Value = doc.NombreArchivo
                r.Cells(col_rutaArchivo.Index).Value = doc.RutaDocumento
                If r.Cells(col_nombreArchivo.Index).Value.ToString().Contains(".pdf") Then
                    r.Cells(col_imagen.Index).Value = ImageList.Images(0)
                Else
                    r.Cells(col_imagen.Index).Value = ImageList.Images(1)
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub limpiar()
        Try
            dtpFecha.Value = DateTime.Now
            itNit.selected_item = Nothing
            itNit.Text = String.Empty
            itCliente.selected_item = Nothing
            itCliente.Text = String.Empty
            itCodigoObra.selected_item = Nothing
            itCodigoObra.Text = String.Empty
            itObra.selected_item = Nothing
            itObra.Text = String.Empty
            txtContacto.Text = String.Empty
            txtCiudad.Text = String.Empty
            txtTelefono.Text = String.Empty
            txtFax.Text = String.Empty
            txtDireccion.Text = String.Empty
            cmbVendedor.SelectedItem = Nothing
            txtVendedor.Text = String.Empty
            cmbSeccion.SelectedItem = Nothing
            txtOp.Text = String.Empty
            txtDescripcionProblema.Text = String.Empty
            dwArchivos.Rows.Clear()
            ErrorProvider.Clear()
            pnlPDF.Visible = False
            pnlIMG.Visible = False

            idPais = Nothing
            idDepto = Nothing
            idCiudad = Nothing

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionAgregarArchivo() As Boolean
        Try
            If txtRutaArchivo.Text = String.Empty Then
                ErrorProvider.SetError(lblError, "No hay ninguna ruta de archivo")
                Return False
            End If
            ErrorProvider.Clear()
            If isRuta = False Then
                ErrorProvider.SetError(lblError, "El texto no corresponde a una ruta")
                Return False
            End If
            ErrorProvider.Clear()

            Dim ruta As String() = txtRutaArchivo.Text.Split("\")
            Dim nombreArchivo As String = ruta.Last.ToLower()

            If Not nombreArchivo.Contains(".pdf") Then
                If Not nombreArchivo.Contains(".bmp") Then
                    If Not nombreArchivo.Contains(".jpg") Then
                        If Not nombreArchivo.Contains(".gif") Then
                            If Not nombreArchivo.Contains(".tiff") Then
                                ErrorProvider.SetError(lblError, "El formato del archivo no es compatible")
                                Return False
                            End If
                        End If
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Function validacionFinal()
        Try
            If itNit.Text = String.Empty Then
                ErrorProvider.SetError(itNit, "Debe ingresar el nit del cliente")
                Return False
            End If
            ErrorProvider.Clear()

            If itCliente.Text = String.Empty Then
                ErrorProvider.SetError(itCliente, "Debe ingresar la razón social del cliente")
                Return False
            End If
            ErrorProvider.Clear()

            If itCodigoObra.Text = String.Empty Then
                ErrorProvider.SetError(itCodigoObra, "Debe ingresar el código de la obra")
                Return False
            End If
            ErrorProvider.Clear()

            If itObra.Text = String.Empty Then
                ErrorProvider.SetError(itObra, "Debe ingresar el nombre de la obra")
                Return False
            End If
            ErrorProvider.Clear()

            If txtContacto.Text = String.Empty Then
                ErrorProvider.SetError(txtContacto, "Debe ingresar el nombre del contacto")
                Return False
            End If
            ErrorProvider.Clear()

            If txtCiudad.Text = String.Empty Then
                ErrorProvider.SetError(txtCiudad, "Debe ingresar la ciudad")
                Return False
            End If
            ErrorProvider.Clear()

            If txtVendedor.Text = String.Empty Then
                ErrorProvider.SetError(txtVendedor, "Debe indicar el vendedor")
                Return False
            End If
            ErrorProvider.Clear()

            If cmbSeccion.SelectedItem Is Nothing Then
                ErrorProvider.SetError(cmbSeccion, "Debe seleccionar la sección")
                Return False
            End If
            ErrorProvider.Clear()

            If txtOp.Text = String.Empty Then
                ErrorProvider.SetError(txtOp, "Debe ingresar el número de orden de producción")
                Return False
            End If
            ErrorProvider.Clear()

            If txtDescripcionProblema.Text = String.Empty Then
                ErrorProvider.SetError(txtDescripcionProblema, "Debe ingresar la descripción del problema")
                Return False
            End If
            ErrorProvider.Clear()

            Return True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return False
        End Try
    End Function
    Private Function InsertarProblemaProduccion() As Integer
        Try
            Dim mEncabezado As New ClsEncabezadoProblemasP
            Dim mDocumentosPp As New ClsDocumentosProblemasP
            Dim idEncabezado As Integer
            idEncabezado = mEncabezado.InsertarEncabezado(My.Settings.UsuarioActivo, CInt(lblConsecutivo.Text), CInt(txtOp.Text), dtpFecha.Value,
                itNit.Text, itCliente.Text, itCodigoObra.Text, itObra.Text, txtContacto.Text, idPais,
                                                              idDepto, idCiudad, txtTelefono.Text, txtFax.Text, txtDireccion.Text, cmbSeccion.SelectedValue,
                                                              cmbVendedor.Text, ClsEnums.Estados.ACTIVO, ClsEnums.Estados.EN_ELABORACION)
            mEncabezado.InsertarDescripcion(My.Settings.UsuarioActivo, idEncabezado, txtDescripcionProblema.Text)
            If dwArchivos.Rows.Count > 0 Then
                For Each r As DataGridViewRow In dwArchivos.Rows
                    Dim ruta As String = r.Cells(col_rutaArchivo.Index).Value
                    Dim idDocumento As Integer = mDocumentosPp.InsertarDocumentos(My.Settings.UsuarioActivo, idEncabezado, 1, r.Cells(col_nombreArchivo.Index).Value,
                                                   ruta, ClsEnums.Estados.ACTIVO)
                    Dim rutaServidor As String = ClsRutas.RutaImagenesPP & "\Pdp" & lblConsecutivo.Text & "-" & idDocumento & r.Cells(col_formato.Index).Value.ToString()
                    My.Computer.FileSystem.CopyFile(ruta, rutaServidor)
                    mDocumentosPp.ActualizarRuta(idDocumento, rutaServidor)
                Next
            End If
            Return idEncabezado
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return Nothing
        End Try
    End Function
    Private Function destinosCorreo() As String
        Try
            Dim mDestinatarios As New ClsDestinatarios
            Dim listDestinos As List(Of destinatario) = mDestinatarios.TraerTodos().Where(Function(a)
                                                                                              Return a.IdEstado = ClsEnums.Estados.ACTIVO And
                                                                                              a.IdSeccion = CInt(cmbSeccion.SelectedValue)
                                                                                          End Function).ToList
            Dim direcciones As String = String.Empty
            For Each des As destinatario In listDestinos
                direcciones += des.Correo + ", "
            Next
            direcciones = direcciones.Remove(direcciones.Length - 2)
            Return direcciones
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return Nothing
        End Try
    End Function
    Private Sub enviarProblema(idEncabezado)
        Try
            Dim mClaseMail As New ClsUtilidades_Web_Mail
            Dim mEncabezado As New ClsEncabezadoProblemasP
            Dim mSeccion As New ClsSecciones

            Dim encabezado As encabezadoPP = mEncabezado.TraerxId(idEncabezado)
            Dim sec As seccion = mSeccion.TraerxId(encabezado.IdSeccion)
            Dim cuerpo As String = "Consecutivo: " & encabezado.Consecutivo & "<br> Nombre de la obra: " & encabezado.Obra & "<br> Número de op: " & encabezado.IdOp &
                "<br> Fecha de radicación: " & encabezado.FechaRegistro.ToShortDateString() & "<br> Nombre de quien radica el problema: " & encabezado.Vendedor &
                "<br> Responsable respuesta: " & sec.Encargado & "<br> Descripción del hecho:<br>" & encabezado.DescripcionProblema & "<br>"
            Dim adjuntos As String = String.Empty
            For Each r As DataGridViewRow In dwArchivos.Rows
                adjuntos += r.Cells(col_rutaArchivo.Index).Value.ToString() & ";"
            Next
            Dim rutas As String()
            If adjuntos <> String.Empty Then
                adjuntos = adjuntos.Remove(adjuntos.Length - 1)
                rutas = adjuntos.Split(";")
            End If
            mClaseMail.EnviarCorreo(destinosCorreo(), "Problema de producción " & encabezado.Consecutivo, cuerpo, Nothing, True, rutas)
            mEncabezado.ActualizarEstadoProblemaProduccion(encabezado.Id, ClsEnums.Estados.ENVIADO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub ActualizarEncabezado()
        Try
            Dim mEncabezado As New ClsEncabezadoProblemasP
            Dim mDocumentosPp As New ClsDocumentosProblemasP
            mEncabezado.ActualizarEncabezado(CInt(txtOp.Text), dtpFecha.Value, itNit.Text, itCliente.Text, itCodigoObra.Text, itObra.Text,
                                             txtContacto.Text, idPais, idDepto, idCiudad, txtTelefono.Text, txtFax.Text, txtDireccion.Text,
                                             cmbSeccion.SelectedValue, cmbVendedor.Text, ClsEnums.Estados.ACTIVO,
                                             ClsEnums.Estados.EN_ELABORACION, My.Settings.UsuarioActivo, _curid)
            If dwArchivos.Rows.Count > 0 Then
                For Each r As DataGridViewRow In dwArchivos.Rows
                    If r.Cells(col_idAdjunto.Index).Value Is Nothing OrElse r.Cells(col_idAdjunto.Index).Value Is String.Empty Then
                        Dim ruta As String = r.Cells(col_rutaArchivo.Index).Value
                        Dim idDocumento As Integer = mDocumentosPp.InsertarDocumentos(My.Settings.UsuarioActivo, _curid, 1, r.Cells(col_nombreArchivo.Index).Value,
                                                       ruta, ClsEnums.Estados.ACTIVO)
                        Dim rutaServidor As String = ClsRutas.RutaImagenesPP & "\Pdp" & lblConsecutivo.Text & "-" & idDocumento & r.Cells(col_formato.Index).Value.ToString()
                        My.Computer.FileSystem.CopyFile(ruta, rutaServidor)
                        mDocumentosPp.ActualizarRuta(idDocumento, rutaServidor)
                    End If
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Funcionamiento Intellisen"
    Private Sub itNit_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itNit.selected_value_changed
        Try
            ErrorProvider.Clear()
            itCliente.Text = e.ValorSecundario
            itCliente.Value2 = e.ValorPrimario
            itCodigoObra.Text = String.Empty
            itObra.Text = String.Empty
            Dim mObras As New clsObrasUnoee
            If Not String.IsNullOrEmpty(e.Id) Then
                mObras.traerObrasByID(e.Id, itCodigoObra.TablaFuente)
                itObra.TablaFuente = itCodigoObra.TablaFuente
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itNit_KeyUp(sender As Object, e As KeyEventArgs) Handles itNit.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itCliente.Text = String.Empty
                itCliente.Value2 = Nothing
                itCodigoObra.Text = String.Empty
                itObra.Text = String.Empty
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itCliente_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itCliente.selected_value_changed
        Try
            ErrorProvider.Clear()
            itNit.Text = e.ValorSecundario
            itNit.Value2 = e.ValorPrimario
            itCodigoObra.Text = String.Empty
            itObra.Text = String.Empty
            Dim mObras As New clsObrasUnoee
            If Not String.IsNullOrEmpty(e.Id) Then
                mObras.traerObrasByID(e.Id, itCodigoObra.TablaFuente)
                itObra.TablaFuente = itCodigoObra.TablaFuente
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itCliente_KeyUp(sender As Object, e As KeyEventArgs) Handles itCliente.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itNit.Text = String.Empty
                itNit.Value2 = Nothing
                itCodigoObra.Text = String.Empty
                itObra.Text = String.Empty
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itCodigoObra_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itCodigoObra.selected_value_changed
        Try
            ErrorProvider.Clear()
            itObra.Text = e.ValorSecundario
            itObra.Value2 = e.ValorPrimario
            cargarInformacionObra()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itCodigoObra_KeyUp(sender As Object, e As KeyEventArgs) Handles itCodigoObra.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itObra.Text = String.Empty
                itObra.Value2 = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itObra_selected_value_changed(sender As Object, e As ControlesPersonalizados.Intellisens.SeleccionCambiada_EventArgs) Handles itObra.selected_value_changed
        Try
            ErrorProvider.Clear()
            itCodigoObra.Text = e.ValorSecundario
            itCodigoObra.Value2 = e.ValorPrimario
            cargarInformacionObra()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub itObra_KeyUp(sender As Object, e As KeyEventArgs) Handles itObra.KeyUp
        Try
            If DirectCast(sender, ControlesPersonalizados.Intellisens.intellises).Text = String.Empty Then
                itCodigoObra.Text = String.Empty
                itCodigoObra.Value2 = Nothing
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmProblemasProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarIntellisens()
            cargarSecciones()
            cargarVendedores()
            Dim mEncabezado As New ClsEncabezadoProblemasP
            If tform = ClsEnums.TiOperacion.INSERTAR Then
                lblConsecutivo.Text = CInt(mEncabezado.traerConsecutivo()) + 1

            ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                cargarParaEdicion()
            End If
            loadcompleted = True
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub Frm_Activated(sender As Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            btnsParcial.Enabled = True
            Dim btnsguardarTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            AddHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsguardarTotal.Click, AddressOf Guardado_Parcial_Click
            'AddHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        Try
            Dim btnsParcial As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            btnsParcial.Enabled = True
            Dim btnsguardarTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnguardarParcial
            RemoveHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsguardarTotal.Click, AddressOf Guardado_Parcial_Click
            'RemoveHandler btnsLimpiar.Click, AddressOf btnLimpiar_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try
            If validacionFinal() Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    Dim idInsertado As Integer = InsertarProblemaProduccion()
                    enviarProblema(idInsertado)
                    limpiar()
                    FrmProblemasProduccion_Load(Nothing, Nothing)
                    MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    ActualizarEncabezado()
                    enviarProblema(_curid)
                    limpiar()
                    MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Guardado_Parcial_Click(sender As Object, e As EventArgs)
        Try
            If validacionFinal() Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    InsertarProblemaProduccion()
                    limpiar()
                    FrmProblemasProduccion_Load(Nothing, Nothing)
                    MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    ActualizarEncabezado()
                    limpiar()
                    MessageBox.Show("La información se ha guardado exitosamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cmbVendedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbVendedor.SelectedValueChanged
        Try
            If loadcompleted Then
                If cmbVendedor.SelectedItem IsNot Nothing Then
                    Dim vendedor As vendedor = cmbVendedor.SelectedItem
                    txtVendedor.Text = vendedor.Nombre
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnBuscarArchivosDescripcionProblema_Click(sender As Object, e As EventArgs) Handles btnBuscarArchivosDescripcionProblema.Click
        Try
            ErrorProvider.Clear()
            Dim abrir As New OpenFileDialog()
            abrir.Filter = "Archivos de Imagen o PDF (*.bmp;*.jpg;*.gif; *tiff; *pdf;)|*.bmp;*.jpg;*.gif;*.tiff;*.pdf| Todos los Archivos (*.*)|*.*"
            abrir.ShowDialog()

            Dim arreglo As Array = abrir.FileNames
            For Each ruta In arreglo
                txtRutaArchivo.Text = abrir.FileName
            Next
            If txtRutaArchivo.Text <> String.Empty Then
                isRuta = True
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAgregarArchivo_Click(sender As Object, e As EventArgs) Handles btnAgregarArchivo.Click
        Try
            If Not validacionAgregarArchivo() Then
                Return
            End If
            Dim ruta As String() = txtRutaArchivo.Text.Split("\")
            Dim nombreArchivo As String = ruta.Last
            Dim formato As String() = nombreArchivo.Split(".")
            Dim r As DataGridViewRow = dwArchivos.Rows(dwArchivos.Rows.Add())
            If txtRutaArchivo.Text.Contains(".pdf") Then
                r.Cells(col_imagen.Index).Value = ImageList.Images.Item(0)
            Else
                r.Cells(col_imagen.Index).Value = ImageList.Images.Item(1)
            End If

            r.Cells(col_nombreArchivo.Index).Value = nombreArchivo
            r.Cells(col_rutaArchivo.Index).Value = txtRutaArchivo.Text
            r.Cells(col_formato.Index).Value = "." & formato.Last
            txtRutaArchivo.Text = String.Empty
            isRuta = False
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnQuitarArchivo_Click(sender As Object, e As EventArgs) Handles btnQuitarArchivo.Click
        Try
            Dim r As DataGridViewRow = dwArchivos.CurrentRow()
            If MessageBox.Show("Está seguro de quitar el archivo del problema de producción", "",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                If tform = ClsEnums.TiOperacion.MODIFICAR Then
                    Dim mDocumentoPp As New ClsDocumentosProblemasP
                    mDocumentoPp.ActualizarEstado(r.Cells(col_idAdjunto.Index).Value, ClsEnums.Estados.ARCHIVADO)
                    If PictureBox.Image IsNot Nothing Then
                        PictureBox.Image.Dispose()
                    End If
                    My.Computer.FileSystem.DeleteFile(r.Cells(col_rutaArchivo.Index).Value.ToString())
                End If
                dwArchivos.Rows.Remove(r)
                pnlPDF.Visible = False
                pnlIMG.Visible = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub dwArchivos_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwArchivos.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                If e.Button = MouseButtons.Left Then
                    btnQuitarArchivo.Enabled = True
                    Dim r As DataGridViewRow = dwArchivos.Rows(e.RowIndex)
                    If r.Cells(col_rutaArchivo.Index).Value.ToString().Contains(".pdf") Then
                        pnlIMG.Visible = False
                        pnlPDF.Visible = True
                        AxAcroPDF.src = Nothing
                        AxAcroPDF.src = r.Cells(col_rutaArchivo.Index).Value
                        AxAcroPDF.setShowToolbar(False)

                    Else
                        pnlPDF.Visible = False
                        pnlIMG.Visible = True
                        PictureBox.Image = Nothing
                        PictureBox.Image = Image.FromFile(r.Cells(col_rutaArchivo.Index).Value)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class