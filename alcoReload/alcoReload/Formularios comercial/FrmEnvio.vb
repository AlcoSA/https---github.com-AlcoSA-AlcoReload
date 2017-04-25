Imports ReglasNegocio
Imports ReglasNegocio.cotizaciones

Public Class FrmEnvio
#Region "Variables"
    Private _objetoEnvio As String
    Private _listId As List(Of Integer)
    Private _destinatarios As String
    Private _mensaje As String
    Private _rutasAdjuntos As String = String.Empty
    Private _contieneUrl As Boolean = False

    Private maximizado As Boolean = False
#End Region
#Region "Propiedades"
    Public Property ObjetoEnvio() As String
        Get
            Return _objetoEnvio
        End Get
        Set(ByVal value As String)
            _objetoEnvio = value
        End Set
    End Property
    Public Property ListId() As List(Of Integer)
        Get
            Return _listId
        End Get
        Set(ByVal value As List(Of Integer))
            _listId = value
        End Set
    End Property
    Public Property Destinatarios() As String
        Get
            Return _destinatarios
        End Get
        Set(ByVal value As String)
            _destinatarios = value
        End Set
    End Property
    Public Property Mensaje() As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property
    Public Property RutasAdujuntos() As String
        Get
            Return _rutasAdjuntos
        End Get
        Set(ByVal value As String)
            _rutasAdjuntos = value
        End Set
    End Property
    Public Property ContieneURL() As Boolean
        Get
            Return _contieneUrl
        End Get
        Set(ByVal value As Boolean)
            _contieneUrl = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub cargarAdjuntos()
        Try
            If _rutasAdjuntos <> String.Empty Then
                Dim rutasAdj As String() = _rutasAdjuntos.Split(";")
                For Each ruta As String In rutasAdj
                    Dim r As DataGridViewRow = dwAdjuntos.Rows(dwAdjuntos.Rows.Add())
                    r.Cells(col_ruta.Index).Value = ruta
                    r.Cells(col_nombreArchivo.Index).Value = ruta.Split("\").Last()
                    r.Cells(col_formato.Index).Value = ruta.Split(".").Last()
                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub trimDatos()
        Try
            If Not String.IsNullOrEmpty(Destinatarios) Then
                If _destinatarios.Chars(_destinatarios.Length - 1) = ";" Then
                    _destinatarios = _destinatarios.Remove(_destinatarios.Length - 1)
                End If

                If _rutasAdjuntos.Chars(_rutasAdjuntos.Length - 1) = ";" Then
                    _rutasAdjuntos = _rutasAdjuntos.Remove(_rutasAdjuntos.Length - 1)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Function GenerarCuerpo() As String
        Try
            Dim cuerpo As String = String.Empty
            Dim u_webmail As New ClsUtilidades_Web_Mail
            cuerpo = "<html>"
            cuerpo += "<body>"
            cuerpo += "<h1>" & _objetoEnvio.ToUpper & "</h1>"
            Dim renglones As String() = txtCuerpo.Text.Split(Environment.NewLine)
            For Each r As String In renglones
                cuerpo += "<a>" & r & "</a><br>"
            Next
            cuerpo += "<p><b>Fecha: </b>" & DateTime.Now.ToString() & "</p>"
            cuerpo += "</body>"
            cuerpo += "</html>"
            If _contieneUrl Then
                If _objetoEnvio.Contains("COTIZA") Then
                    Dim mCotiza As New ClsCostizaciones
                    For Each id As Integer In _listId
                        cuerpo += " <a href=" & u_webmail.ComprimirURL("http://servidorapp/alco_web/Cotizacion.aspx?id_cotiza=" & u_webmail.EncriptarParametros(id)) &
                            ">Ingrese para aprobar la cotización " & id & "-" & RTrim(mCotiza.TraerxId(id).nombreCotizacion) & " </a><br>"
                    Next
                ElseIf _objetoEnvio.Contains("ORDENES DE PEDIDO") Then
                    Dim mOrdenPedido As New ClsOrdenDePedido
                    For Each id As Integer In _listId
                        cuerpo += " <a href=" & u_webmail.ComprimirURL("http://servidorapp/alco_web/Default.aspx?id_ordenped=" & u_webmail.EncriptarParametros(id)) &
                            ">Ingrese para ver el pedido de " & RTrim(mOrdenPedido.TraerxIdOrden(id).Obra) & "</a><br>"
                    Next
                End If
                cuerpo += "<p><b>Para visualizar correctamente la información, utilice Mozzilla firefox o Google chrome como navegadores.</b></p>"
            End If
            cuerpo += "</body>"
            cuerpo += "</html>"
            Return cuerpo
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            Return String.Empty
        End Try
    End Function
#End Region
    Private Sub FrmEnvio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            trimDatos()
            txtDestino.Text = _destinatarios
            txtAsunto.Text = _objetoEnvio
            txtCuerpo.Text = _mensaje
            cargarAdjuntos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub dwAdjuntos_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dwAdjuntos.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                If dwAdjuntos.Rows.Count > 0 Then
                    If maximizado = False Then
                        Me.Width = 900
                        Dim point As Point = Me.Location
                        Dim newPoint As New Point
                        newPoint.X = point.X - 245
                        newPoint.Y = point.Y
                        Me.Location = newPoint
                        maximizado = True
                    End If
                    lectorPDF.src = dwAdjuntos.Rows(e.RowIndex).Cells(col_ruta.Index).Value
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Try
            bwCargas.RunWorkerAsync("Enviando")
            Dim u_webmail As New ClsUtilidades_Web_Mail

            If _contieneUrl And _objetoEnvio.Contains("COTIZA") Then
                Dim c_hist As New ClsHistorialCorreosCotizacion
                Dim mCotizacion As New ClsCostizaciones
                For Each id As Integer In _listId
                    c_hist.Insertar(id, "LOCAL", txtDestino.Text, "alco@alco.com.co", "ALCO", "ALCO", "ventas", txtAsunto.Text, Mensaje)
                    mCotizacion.ActualizarAprobacionCliente(id, ClsEnums.Estados.ENVIADO)
                Next
            End If
            u_webmail.EnviarCorreo(txtDestino.Text, txtAsunto.Text, GenerarCuerpo(), Nothing, True, If(_rutasAdjuntos <> String.Empty, _rutasAdjuntos.Split(";"), Nothing))

            bwCargas_RunWorkerCompleted(Nothing, Nothing)
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
            bwCargas_RunWorkerCompleted(Nothing, Nothing)
        End Try
    End Sub
    Private Sub bwCargas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwCargas.DoWork
        Try
            Dim carga As New FrmCargaProceso
            carga.Proceso = e.Argument
            Application.Run(carga)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub bwCargas_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwCargas.RunWorkerCompleted
        Try
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class
