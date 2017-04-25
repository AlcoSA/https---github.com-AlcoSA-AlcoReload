Imports ReglasNegocio

Public Class FrmProblemasProduccion
#Region "Variables"
    Private tform As ClsEnums.TiOperacion = ClsEnums.TiOperacion.INSERTAR

    Private _idEncabezado As Integer
    Private _consecutivo As Integer
    Private _estadoSolucion As String
    Private _fechaRegistro As DateTime
    Private _idVendedor As String
    Private _vendedor As String
    Private _idSeccion As String
    Private _seccion As String
    Private _nit As String
    Private _cliente As String
    Private _codigoObra As String
    Private _obra As String
    Private _descripcionProblema As String
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
    Public Property IdEncabezado() As Integer
        Get
            Return _idEncabezado
        End Get
        Set(ByVal value As Integer)
            _idEncabezado = value
        End Set
    End Property
    Public Property Consecutivo() As Integer
        Get
            Return _consecutivo
        End Get
        Set(ByVal value As Integer)
            _consecutivo = value
        End Set
    End Property
    Public Property EstadoSolucion() As String
        Get
            Return _estadoSolucion
        End Get
        Set(ByVal value As String)
            _estadoSolucion = value
        End Set
    End Property
    Public Property FechaRegistro() As DateTime
        Get
            Return _fechaRegistro
        End Get
        Set(ByVal value As DateTime)
            _fechaRegistro = value
        End Set
    End Property
    Public Property IdVendedor() As String
        Get
            Return _idVendedor
        End Get
        Set(ByVal value As String)
            _idVendedor = value
        End Set
    End Property
    Public Property Vendedor() As String
        Get
            Return _vendedor
        End Get
        Set(ByVal value As String)
            _vendedor = value
        End Set
    End Property
    Public Property IdSeccion() As String
        Get
            Return _idSeccion
        End Get
        Set(ByVal value As String)
            _idSeccion = value
        End Set
    End Property
    Public Property Seccion() As String
        Get
            Return _seccion
        End Get
        Set(ByVal value As String)
            _seccion = value
        End Set
    End Property
    Public Property Nit() As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property
    Public Property CodigoObra() As String
        Get
            Return _codigoObra
        End Get
        Set(ByVal value As String)
            _codigoObra = value
        End Set
    End Property
    Public Property Obra() As String
        Get
            Return _obra
        End Get
        Set(ByVal value As String)
            _obra = value
        End Set
    End Property
    Public Property DescripcionProblema() As String
        Get
            Return _descripcionProblema
        End Get
        Set(ByVal value As String)
            _descripcionProblema = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarInformacion()
        Try
            lblConsecutivo.Text = _consecutivo
            lblEstado.Text = _estadoSolucion
            txtFecha.Text = _fechaRegistro.ToShortDateString()
            txtVendedor.Text = _vendedor
            txtSeccion.Text = _seccion
            txtNit.Text = _nit
            txtCliente.Text = _cliente
            txtCodigoObra.Text = _codigoObra
            txtObra.Text = _obra
            txtDescripcionProblema.Text = _descripcionProblema

            If tform = ClsEnums.TiOperacion.MODIFICAR Then
                Dim mCausas As New ClsMovitoCausasPp
                Dim causa As movitoCausaPp = mCausas.TraerxIdEncabezado(_idEncabezado)
                If causa.Descripcion IsNot Nothing Then
                    Aca_txtDescripcion.Text = causa.Descripcion
                End If

                Dim mAccionInmediata As New ClsMovitoAccionesImnediatasPp
                Dim AccInmediata As movitoAccionInmediataPp = mAccionInmediata.TraerxIdEncabezado(_idEncabezado)
                If AccInmediata.Descripcion IsNot Nothing Then
                    Ain_txtDescripcion.Text = AccInmediata.Descripcion
                End If

                Dim mAccionDefinida As New ClsMovitoAccionesDefinidasPp
                Dim accDefinida As movitoAccionDefinidaPp = mAccionDefinida.TraerxIdEncabezado(_idEncabezado)
                If accDefinida.Descripcion IsNot Nothing Then
                    Ade_txtDescripcion.Text = accDefinida.Descripcion
                End If
            End If
            cargarAdjuntos(Aca_dwArchivos)
            cargarAdjuntos(Ain_dwArchivos)
            cargarAdjuntos(Ade_dwArchivos)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub cargarAdjuntos(dw As DataGridView)
        Try
            Dim mDocumentos As New ClsDocumentosProblemasP
            Dim listAdjuntos As List(Of documentoPP) = mDocumentos.TraerAdjuntos(_idEncabezado, dw.Tag)
            For Each doc As documentoPP In listAdjuntos
                Dim r As DataGridViewRow = dw.Rows(dw.Rows.Add())
                r.Cells(dw.Columns(0).Index).Value = doc.Id
                r.Cells(dw.Columns(2).Index).Value = doc.NombreArchivo
                r.Cells(dw.Columns(3).Index).Value = doc.RutaDocumento
                If r.Cells(dw.Columns(3).Index).Value.ToString().Contains(".pdf") Then
                    r.Cells(dw.Columns(1).Index).Value = ImageList.Images(0)
                Else
                    r.Cells(dw.Columns(1).Index).Value = ImageList.Images(1)
                End If
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub escribirRuta(txt As TextBox)
        Try
            Dim abrir As New OpenFileDialog()
            abrir.Filter = "Archivos de Imagen o PDF (*.bmp;*.jpg;*.gif; *tiff; *pdf;)|*.bmp;*.jpg;*.gif;*.tiff;*.pdf| Todos los Archivos (*.*)|*.*"
            abrir.ShowDialog()

            Dim arreglo As Array = abrir.FileNames
            For Each ruta In arreglo
                txt.Text = abrir.FileName
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function validacionAgregarArchivo(txt As TextBox, lblerror As Label) As Boolean
        Try
            If txt.Text = String.Empty Then
                ErrorProvider.SetError(lblerror, "No hay ninguna ruta de archivo")
                Return False
            End If
            ErrorProvider.Clear()

            Dim ruta As String() = txt.Text.Split("\")
            Dim nombreArchivo As String = ruta.Last.ToLower()

            If Not nombreArchivo.Contains(".pdf") Then
                If Not nombreArchivo.Contains(".bmp") Then
                    If Not nombreArchivo.Contains(".jpg") Then
                        If Not nombreArchivo.Contains(".gif") Then
                            If Not nombreArchivo.Contains(".tiff") Then
                                ErrorProvider.SetError(txt, "El formato del archivo no es compatible")
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
    Private Sub guardadoGeneral()
        Try
            Dim mEncabezado As New ClsEncabezadoProblemasP
            Dim mCausas As New ClsMovitoCausasPp
            Dim mAccionesInmediatas As New ClsMovitoAccionesImnediatasPp
            Dim mAccionesDefinidas As New ClsMovitoAccionesDefinidasPp

            Dim movitosInsertados As Integer = 0

            If Aca_txtDescripcion.Text <> String.Empty OrElse Aca_dwArchivos.Rows.Count > 0 Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    If Aca_txtDescripcion.Text <> String.Empty Then
                        mCausas.Insertar(My.Settings.UsuarioActivo, _idEncabezado, Aca_txtDescripcion.Text)
                    End If
                    guardarAdjuntos(Aca_dwArchivos, "ACausa")
                    movitosInsertados += 1
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    If mCausas.TraerxIdEncabezado(_idEncabezado).Id = 0 Then
                        mCausas.Insertar(My.Settings.UsuarioActivo, _idEncabezado, Aca_txtDescripcion.Text)
                    Else
                        mCausas.Actualizar(Aca_txtDescripcion.Text, My.Settings.UsuarioActivo, _idEncabezado)
                    End If
                    guardarAdjuntos(Aca_dwArchivos, "ACausa")
                    movitosInsertados += 1
                End If
            End If

            If Ain_txtDescripcion.Text <> String.Empty OrElse Ain_dwArchivos.Rows.Count > 0 Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    If Ain_txtDescripcion.Text <> String.Empty Then
                        mAccionesInmediatas.Insertar(My.Settings.UsuarioActivo, _idEncabezado, Ain_txtDescripcion.Text)
                    End If
                    guardarAdjuntos(Ain_dwArchivos, "AInmediata")
                    movitosInsertados += 1
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    If mAccionesInmediatas.TraerxIdEncabezado(_idEncabezado).Id = 0 Then
                        mAccionesInmediatas.Insertar(My.Settings.UsuarioActivo, _idEncabezado, Ain_txtDescripcion.Text)
                    Else
                        mAccionesInmediatas.Actualizar(Ain_txtDescripcion.Text, My.Settings.UsuarioActivo, _idEncabezado)
                    End If
                    guardarAdjuntos(Ain_dwArchivos, "AInmediata")
                    movitosInsertados += 1
                End If
            End If

            If Ade_txtDescripcion.Text <> String.Empty OrElse Ade_dwArchivos.Rows.Count > 0 Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    If Ade_txtDescripcion.Text <> String.Empty Then
                        mAccionesDefinidas.Insertar(My.Settings.UsuarioActivo, _idEncabezado, Ade_txtDescripcion.Text)
                    End If
                    guardarAdjuntos(Ade_dwArchivos, "ADefinida")
                    movitosInsertados += 1
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    If mAccionesDefinidas.TraerxIdEncabezado(_idEncabezado).Id = 0 Then
                        mAccionesDefinidas.Insertar(My.Settings.UsuarioActivo, _idEncabezado, Ade_txtDescripcion.Text)
                    Else
                        mAccionesDefinidas.Actualizar(Ade_txtDescripcion.Text, My.Settings.UsuarioActivo, _idEncabezado)
                    End If
                    guardarAdjuntos(Ade_dwArchivos, "ADefinida")
                    movitosInsertados += 1
                End If
            End If

            If movitosInsertados > 0 Then
                MessageBox.Show("La información se ha guardado exitosamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub guardarAdjuntos(dw As DataGridView, prefijoMovito As String)
        Try
            Dim mDocumentosPp As New ClsDocumentosProblemasP
            If dw.Rows.Count > 0 Then
                If tform = ClsEnums.TiOperacion.INSERTAR Then
                    For Each r As DataGridViewRow In dw.Rows
                        Dim ruta As String = r.Cells(dw.Columns(3).Index).Value
                        Dim idDocumento As Integer = mDocumentosPp.InsertarDocumentos(My.Settings.UsuarioActivo, _idEncabezado, dw.Tag, r.Cells(dw.Columns(2).Index).Value,
                                                             ruta, ClsEnums.Estados.ACTIVO)
                        Dim rutaServidor As String = ClsRutas.RutaImagenesPP & "\Pdp" & lblConsecutivo.Text & "-" & prefijoMovito & "-" & idDocumento & r.Cells(dw.Columns(4).Index).Value.ToString()
                        My.Computer.FileSystem.CopyFile(ruta, rutaServidor)
                        mDocumentosPp.ActualizarRuta(idDocumento, rutaServidor)
                    Next
                ElseIf tform = ClsEnums.TiOperacion.MODIFICAR Then
                    For Each r As DataGridViewRow In dw.Rows
                        If r.Cells(dw.Columns(0).Index).Value Is Nothing OrElse r.Cells(dw.Columns(0).Index).Value Is String.Empty Then
                            Dim ruta As String = r.Cells(dw.Columns(3).Index).Value
                            Dim idDocumento As Integer = mDocumentosPp.InsertarDocumentos(My.Settings.UsuarioActivo, _idEncabezado, dw.Tag, r.Cells(dw.Columns(2).Index).Value,
                                                             ruta, ClsEnums.Estados.ACTIVO)
                            Dim rutaServidor As String = ClsRutas.RutaImagenesPP & "\Pdp" & lblConsecutivo.Text & "-" & prefijoMovito & "-" & idDocumento & r.Cells(dw.Columns(4).Index).Value.ToString()
                            My.Computer.FileSystem.CopyFile(ruta, rutaServidor)
                            mDocumentosPp.ActualizarRuta(idDocumento, rutaServidor)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function destinosCorreo() As String
        Try
            Dim mVendedores As New ClsVendedoresSiesa
            Dim vend As vendedorDetalle = mVendedores.TraerVendedoresDetalle(_idVendedor)
            Dim mDestinatarios As New ClsDestinatarios
            Dim listDestinos As List(Of destinatario) = mDestinatarios.TraerTodos().Where(Function(a)
                                                                                              Return a.IdEstado = ClsEnums.Estados.ACTIVO And
                                                                                              a.IdSeccion = CInt(_idSeccion)

                                                                                          End Function).ToList
            Dim direcciones As String
            If vend.Mail <> String.Empty Then
                direcciones = vend.Mail & ", "
            Else
                direcciones = String.Empty
            End If

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
                "<br> Responsable respuesta: " & sec.Encargado & "<br>Descripción del hecho:<br>" & encabezado.DescripcionProblema & "<br><br>Análisis de causa:<br>" &
                If(Aca_txtDescripcion.Text <> String.Empty, Aca_txtDescripcion.Text, "---").ToString() & "<br><br>Acción inmediata:<br>" &
                If(Ain_txtDescripcion.Text <> String.Empty, Ain_txtDescripcion.Text, "---").ToString() & "<br><br>Acción definida:<br>" &
                If(Ade_txtDescripcion.Text <> String.Empty, Ade_txtDescripcion.Text, "---").ToString()
            Dim adjuntos As String = String.Empty
            For Each r As DataGridViewRow In Aca_dwArchivos.Rows
                adjuntos += r.Cells(Aca_col_rutaArchivo.Index).Value.ToString() & ";"
            Next
            For Each r As DataGridViewRow In Ain_dwArchivos.Rows
                adjuntos += r.Cells(Ain_col_rutaArchivo.Index).Value.ToString() & ";"
            Next
            For Each r As DataGridViewRow In Ade_dwArchivos.Rows
                adjuntos += r.Cells(Ade_col_rutaArchivo.Index).Value.ToString() & ";"
            Next
            If adjuntos <> String.Empty Then
                adjuntos = adjuntos.Remove(adjuntos.Length - 1)
            End If
            Dim rutas As String() = adjuntos.Split(";")
            mClaseMail.EnviarCorreo(destinosCorreo(), "Problema de producción " & encabezado.Consecutivo, cuerpo, Nothing, True, rutas)
            mEncabezado.ActualizarEstadoProblemaProduccion(encabezado.Id, ClsEnums.Estados.SOLUCIONADO)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub FrmProblemasProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cargarInformacion()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#Region "Análisis de causa"
    Private Sub Aca_btnBuscarArchivosDescripcionProblema_Click(sender As Object, e As EventArgs) Handles Aca_btnBuscarArchivosDescripcionProblema.Click
        Try
            ErrorProvider.Clear()
            escribirRuta(Aca_txtRutaArchivo)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Aca_btnAgregarArchivo_Click(sender As Object, e As EventArgs) Handles Aca_btnAgregarArchivo.Click
        Try
            If Not validacionAgregarArchivo(Aca_txtRutaArchivo, Aca_lblErrorDw) Then
                Return
            End If
            Dim ruta As String() = Aca_txtRutaArchivo.Text.Split("\")
            Dim nombreArchivo As String = ruta.Last
            Dim formato As String() = nombreArchivo.Split(".")
            Dim r As DataGridViewRow = Aca_dwArchivos.Rows(Aca_dwArchivos.Rows.Add())
            If Aca_txtRutaArchivo.Text.Contains(".pdf") Then
                r.Cells(Aca_col_imagen.Index).Value = ImageList.Images.Item(0)
            Else
                r.Cells(Aca_col_imagen.Index).Value = ImageList.Images.Item(1)
            End If

            r.Cells(Aca_col_nombreArchivo.Index).Value = nombreArchivo
            r.Cells(Aca_col_rutaArchivo.Index).Value = Aca_txtRutaArchivo.Text
            r.Cells(Aca_col_formato.Index).Value = "." & formato.Last
            Aca_txtRutaArchivo.Text = String.Empty
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Aca_btnQuitarArchivo_Click(sender As Object, e As EventArgs) Handles Aca_btnQuitarArchivo.Click
        Try
            Dim r As DataGridViewRow = Aca_dwArchivos.CurrentRow()
            If MessageBox.Show("Está seguro de quitar el archivo del problema de producción", "",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                If r.Cells(Aca_col_idArchivo.Index).Value IsNot Nothing OrElse r.Cells(Aca_col_idArchivo.Index).Value IsNot String.Empty Then

                    Dim mDocumentoPp As New ClsDocumentosProblemasP
                    mDocumentoPp.ActualizarEstado(r.Cells(Aca_col_idArchivo.Index).Value, ClsEnums.Estados.ARCHIVADO)
                    If Aca_PictureBox.Image IsNot Nothing Then
                        Aca_PictureBox.Image.Dispose()
                    End If
                    My.Computer.FileSystem.DeleteFile(r.Cells(Aca_col_rutaArchivo.Index).Value.ToString())
                End If
                Aca_dwArchivos.Rows.Remove(r)
                If Aca_dwArchivos.Rows.Count = 0 Then
                    Aca_btnQuitarArchivo.Enabled = False
                End If
                Aca_pnlIMG.Visible = False
                Aca_pnlPDF.Visible = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Aca_dwArchivos_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Aca_dwArchivos.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                If e.Button = MouseButtons.Left Then
                    Aca_btnQuitarArchivo.Enabled = True
                    Dim r As DataGridViewRow = Aca_dwArchivos.Rows(e.RowIndex)
                    If r.Cells(Aca_col_rutaArchivo.Index).Value.ToString().Contains(".pdf") Then
                        Aca_pnlIMG.Visible = False
                        Aca_pnlPDF.Visible = True
                        Aca_AxAcroPDF.src = Nothing
                        Aca_AxAcroPDF.src = r.Cells(Aca_col_rutaArchivo.Index).Value
                        Aca_AxAcroPDF.setShowToolbar(False)
                    Else
                        Aca_pnlPDF.Visible = False
                        Aca_pnlIMG.Visible = True
                        Aca_PictureBox.Image = Nothing
                        Aca_PictureBox.Image = Image.FromFile(r.Cells(Aca_col_rutaArchivo.Index).Value)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Acciones inmediatas"
    Private Sub Ain_btnBuscarArchivosDescripcionProblema_Click(sender As Object, e As EventArgs) Handles Ain_btnBuscarArchivosDescripcionProblema.Click
        Try
            ErrorProvider.Clear()
            escribirRuta(Ain_txtRutaArchivo)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Ain_btnAgregarArchivo_Click(sender As Object, e As EventArgs) Handles Ain_btnAgregarArchivo.Click
        Try
            If Not validacionAgregarArchivo(Ain_txtRutaArchivo, Ain_lblErrorDw) Then
                Return
            End If
            Dim ruta As String() = Ain_txtRutaArchivo.Text.Split("\")
            Dim nombreArchivo As String = ruta.Last
            Dim formato As String() = nombreArchivo.Split(".")
            Dim r As DataGridViewRow = Ain_dwArchivos.Rows(Ain_dwArchivos.Rows.Add())
            If Ain_txtRutaArchivo.Text.Contains(".pdf") Then
                r.Cells(Ain_col_imagen.Index).Value = ImageList.Images.Item(0)
            Else
                r.Cells(Ain_col_imagen.Index).Value = ImageList.Images.Item(1)
            End If

            r.Cells(Ain_col_nombreArchivo.Index).Value = nombreArchivo
            r.Cells(Ain_col_rutaArchivo.Index).Value = Ain_txtRutaArchivo.Text
            r.Cells(Ain_col_formato.Index).Value = "." & formato.Last
            Ain_txtRutaArchivo.Text = String.Empty
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Ain_btnQuitarArchivo_Click(sender As Object, e As EventArgs) Handles Ain_btnQuitarArchivo.Click
        Try
            Dim r As DataGridViewRow = Ain_dwArchivos.CurrentRow()
            If MessageBox.Show("Está seguro de quitar el archivo del problema de producción", "",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                If r.Cells(Ain_col_idArchivo.Index).Value IsNot Nothing OrElse r.Cells(Ain_col_idArchivo.Index).Value IsNot String.Empty Then
                    Dim mDocumentoPp As New ClsDocumentosProblemasP
                    mDocumentoPp.ActualizarEstado(r.Cells(Ain_col_idArchivo.Index).Value, ClsEnums.Estados.ARCHIVADO)
                    If Ain_PictureBox.Image IsNot Nothing Then
                        Ain_PictureBox.Image.Dispose()
                    End If
                    My.Computer.FileSystem.DeleteFile(r.Cells(Ain_col_rutaArchivo.Index).Value.ToString())
                End If
                Ain_dwArchivos.Rows.Remove(r)
                If Ain_dwArchivos.Rows.Count = 0 Then
                    Ain_btnQuitarArchivo.Enabled = False
                End If
                Ain_pnlIMG.Visible = False
                Ain_pnlPDF.Visible = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Ain_dwArchivos_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Ain_dwArchivos.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                If e.Button = MouseButtons.Left Then
                    Ain_btnQuitarArchivo.Enabled = True
                    Dim r As DataGridViewRow = Ain_dwArchivos.Rows(e.RowIndex)
                    If r.Cells(Ain_col_rutaArchivo.Index).Value.ToString().Contains(".pdf") Then
                        Ain_pnlIMG.Visible = False
                        Ain_pnlPDF.Visible = True
                        Ain_AxAcroPDF.src = Nothing
                        Ain_AxAcroPDF.src = r.Cells(Ain_col_rutaArchivo.Index).Value
                        Ain_AxAcroPDF.setShowToolbar(False)
                    Else
                        Ain_pnlPDF.Visible = False
                        Ain_pnlIMG.Visible = True
                        Ain_PictureBox.Image = Nothing
                        Ain_PictureBox.Image = Image.FromFile(r.Cells(Ain_col_rutaArchivo.Index).Value)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
#Region "Acciones definidas"
    Private Sub Ade_btnBuscarArchivosDescripcionProblema_Click(sender As Object, e As EventArgs) Handles Ade_btnBuscarArchivosDescripcionProblema.Click
        Try
            ErrorProvider.Clear()
            escribirRuta(Ade_txtRutaArchivo)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Ade_btnAgregarArchivo_Click(sender As Object, e As EventArgs) Handles Ade_btnAgregarArchivo.Click
        Try
            If Not validacionAgregarArchivo(Ade_txtRutaArchivo, Ade_lblErrorDw) Then
                Return
            End If
            Dim ruta As String() = Ade_txtRutaArchivo.Text.Split("\")
            Dim nombreArchivo As String = ruta.Last
            Dim formato As String() = nombreArchivo.Split(".")
            Dim r As DataGridViewRow = Ade_dwArchivos.Rows(Ade_dwArchivos.Rows.Add())
            If Ade_txtRutaArchivo.Text.Contains(".pdf") Then
                r.Cells(Ade_col_imagen.Index).Value = ImageList.Images.Item(0)
            Else
                r.Cells(Ade_col_imagen.Index).Value = ImageList.Images.Item(1)
            End If

            r.Cells(Ade_col_nombreArchivo.Index).Value = nombreArchivo
            r.Cells(Ade_col_rutaArchivo.Index).Value = Ade_txtRutaArchivo.Text
            r.Cells(Ade_col_formato.Index).Value = "." & formato.Last
            Ade_txtRutaArchivo.Text = String.Empty
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Ade_btnQuitarArchivo_Click(sender As Object, e As EventArgs) Handles Ade_btnQuitarArchivo.Click
        Try
            Dim r As DataGridViewRow = Ade_dwArchivos.CurrentRow()
            If MessageBox.Show("Está seguro de quitar el archivo del problema de producción", "",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                If r.Cells(Ade_col_idArchivo.Index).Value IsNot Nothing OrElse r.Cells(Ade_col_idArchivo.Index).Value IsNot String.Empty Then
                    Dim mDocumentoPp As New ClsDocumentosProblemasP
                    mDocumentoPp.ActualizarEstado(r.Cells(Ade_col_idArchivo.Index).Value, ClsEnums.Estados.ARCHIVADO)
                    If Ade_PictureBox.Image IsNot Nothing Then
                        Ade_PictureBox.Image.Dispose()
                    End If
                    My.Computer.FileSystem.DeleteFile(r.Cells(Ade_col_rutaArchivo.Index).Value.ToString())
                End If
                Ade_dwArchivos.Rows.Remove(r)
                If Ade_dwArchivos.Rows.Count = 0 Then
                    Ade_btnQuitarArchivo.Enabled = False
                End If
                Ade_PnlIMG.Visible = False
                Ade_pnlPDF.Visible = False
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Ade_dwArchivos_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Ade_dwArchivos.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                If e.Button = MouseButtons.Left Then
                    Ade_btnQuitarArchivo.Enabled = True
                    Dim r As DataGridViewRow = Ade_dwArchivos.Rows(e.RowIndex)
                    If r.Cells(Ade_col_rutaArchivo.Index).Value.ToString().Contains(".pdf") Then
                        Ade_PnlIMG.Visible = False
                        Ade_pnlPDF.Visible = True
                        Ade_AxAcroPDF.src = Nothing
                        Ade_AxAcroPDF.src = r.Cells(Ade_col_rutaArchivo.Index).Value
                        Ade_AxAcroPDF.setShowToolbar(False)
                    Else
                        Ade_pnlPDF.Visible = False
                        Ade_PnlIMG.Visible = True
                        Ade_PictureBox.Image = Nothing
                        Ade_PictureBox.Image = Image.FromFile(r.Cells(Ade_col_rutaArchivo.Index).Value)
                    End If
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region
    Private Sub Frm_Activated(sender As Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            AddHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            AddHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub Frm_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        Try
            Dim btnsTotal As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardarTotal
            Dim btnguardar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnGuardar
            Dim btnsLimpiar As RibbonButton = DirectCast(Me.MdiParent, frmInicial).btnLimpiar
            RemoveHandler btnguardar.Click, AddressOf GuardadoTotal_Click
            RemoveHandler btnsTotal.Click, AddressOf GuardadoTotal_Click
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub GuardadoTotal_Click(sender As Object, e As EventArgs)
        Try
            guardadoGeneral()
            Dim mEncabezado As New ClsEncabezadoProblemasP
            mEncabezado.ActualizarEstadoProblemaProduccion(_idEncabezado, ClsEnums.Estados.SOLUCIONADO_PARCIAL)
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnCambiarResponsable_Click(sender As Object, e As EventArgs) Handles btnCambiarResponsable.Click
        Try
            Dim frm As New FrmCambioSeccion
            frm.IdEncabezado = _idEncabezado
            frm.Consecutivo = _consecutivo
            frm.IdSeccionOriginal = _idSeccion
            frm.SeccionOriginal = _seccion
            Dim mSeccion As New ClsSecciones
            Dim sec As seccion = mSeccion.TraerxId(_idSeccion)
            frm.ResponsableOriginal = sec.Encargado
            If frm.ShowDialog() = DialogResult.OK Then
                _idSeccion = frm.IdSeccionCambio
                _seccion = frm.SeccionCambio
                cargarInformacion()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnSolucionProblema_Click(sender As Object, e As EventArgs) Handles btnSolucionProblema.Click
        Try
            If MessageBox.Show("Se va a guardar la solución del problema de producción y se enviará una copia a los responsables. ¿Desea continuar?",
                               "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then

                guardadoGeneral()
                enviarProblema(_idEncabezado)
                Dim mEncabezado As New ClsEncabezadoProblemasP
                mEncabezado.ActualizarEstadoProblemaProduccion(_idEncabezado, ClsEnums.Estados.SOLUCIONADO)
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAnularProblema_Click(sender As Object, e As EventArgs) Handles btnAnularProblema.Click
        Try
            If MessageBox.Show("¿Está seguro de anular el problema de producción?", "",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                Dim mEncabezado As New ClsEncabezadoProblemasP
                mEncabezado.ActualizarEstadoProblemaProduccion(_idEncabezado, ClsEnums.Estados.ANULADO)
                Me.Close()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnDevolverProblema_Click(sender As Object, e As EventArgs) Handles btnDevolverProblema.Click
        Try
            Dim frm As New FrmDevolucionProblema
            Dim mClaseMail As New ClsUtilidades_Web_Mail
            Dim mEncabezado As New ClsEncabezadoProblemasP
            If frm.ShowDialog() = DialogResult.OK Then
                mClaseMail.EnviarCorreo(destinosCorreo(), "Devolución problema de producción " & _consecutivo, "Se devuelve el problema de producción " &
                                        _consecutivo & " por: <br>" & frm.Motivo, Nothing, True)
                mEncabezado.ActualizarEstadoProblemaProduccion(_idEncabezado, ClsEnums.Estados.EN_ELABORACION)
                Me.Close()
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class