Imports ReglasNegocio
Public Class FrmEnvioPedidoaCliente
#Region "Variables"
    Private _listIdPedidos As List(Of Integer)
#End Region
#Region "Propiedades"
    Public Property ListIdPedidos() As List(Of Integer)
        Get
            Return _listIdPedidos
        End Get
        Set(ByVal value As List(Of Integer))
            _listIdPedidos = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Function Validar(correo As String) As Boolean
        Try
            Dim emailRegex As New System.Text.RegularExpressions.Regex("^(?<user>[^@]+)@(?<host>.+)$")
            Dim emailMatch As System.Text.RegularExpressions.Match =
            emailRegex.Match(correo)
            If Not emailMatch.Success Then
                MsgBox("Debe ingresar una dirección de correo electrónico valida", MsgBoxStyle.Critical)
                Return False
            End If
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnenviar_Click(sender As Object, e As EventArgs) Handles btnenviar.Click
        Try
            If Validar(txtcorreo.Text) Then
                bwcargas.RunWorkerAsync("Enviando")
                Dim u_webmail As New ClsUtilidades_Web_Mail
                'Dim url_corta As String = u_webmail.ComprimirURL("http://www.alco.com.co:8081/web_Alco/Default.aspx?id_ordenped=" & u_webmail.EncriptarParametros(_idpedido))
                'Dim url_corta As String = u_webmail.ComprimirURL("http://servidorapp/alco_web/Default.aspx?id_ordenped=" & u_webmail.EncriptarParametros(_idpedido))
                Dim DicUrl As New Dictionary(Of Integer, String)
                For Each id As Integer In _listIdPedidos
                    DicUrl.Add(id, u_webmail.ComprimirURL("http://servidorapp/alco_web/Default.aspx?id_ordenped=" & u_webmail.EncriptarParametros(id)))
                Next
                Dim mensaje As String = String.Empty
                mensaje = "<html>"
                mensaje &= "<body>"
                mensaje &= "<h1>" & "VISTA ORDENES PEDIDO ALCO" & "</h1>"
                mensaje &= "<p>" & txtmensaje.Text & "</p>"
                mensaje &= "<p> <b> Fecha: </b>" & DateTime.Now.ToString() + "</p>"
                Dim mOrdenPedido As New ClsOrdenDePedido
                For Each item In DicUrl
                    mensaje &= " <a href=" & item.Value & ">Ingrese para ver el pedido de " & RTrim(mOrdenPedido.TraerxIdOrden(item.Key).Obra) & "</a><br>"
                Next
                mensaje &= "<p><b>Para visualizar correctamente la información, utilice Mozzilla firefox o Google chrome como navegadores.</b></p>"
                mensaje &= "</body>"
                mensaje &= "</html>"
                u_webmail.EnviarCorreo(txtcorreo.Text, txtasunto.Text, mensaje,
                                       Nothing, True)
                Dim c_hist As New ClsHistorialCorreosOrdenPed
                For Each id As Integer In _listIdPedidos
                    c_hist.Insertar(id, "LOCAL", txtcorreo.Text, "alco@alco.com.co", "ALCO", "VentaS", txtasunto.Text, mensaje)
                Next
                bwcargas_RunWorkerCompleted(Nothing, Nothing)
                Me.DialogResult = DialogResult.OK
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub FrmEnvioPedidoaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim morden As New ClsOrdenDePedido
            Dim listCorreos As New List(Of String)
            For Each id As Integer In _listIdPedidos
                Dim ped As OrdenDePedido = morden.TraerTodos.Where(Function(a) a.Id = id).ToList.First()
                If String.IsNullOrEmpty(Trim(ped.Correo_Obra)) Then
                    listCorreos.Add(Trim(ped.Correo_Cliente))
                Else
                    listCorreos.Add(Trim(ped.Correo_Obra))
                End If
            Next
            Dim correo As String = String.Empty
            For Each c As String In listCorreos.Distinct().ToList
                correo = c + "; "
            Next
            txtcorreo.Text = correo.Remove(correo.Length - 2)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub bwcargas_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwcargas.DoWork
        Try
            Dim carga As New FrmCargaProceso
            carga.Proceso = e.Argument
            Application.Run(carga)
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub bwcargas_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwcargas.RunWorkerCompleted
        Try
            If (Application.OpenForms().Item("FrmCargaProceso") IsNot Nothing) Then DirectCast(Application.OpenForms().Item("FrmCargaProceso"), FrmCargaProceso).Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class