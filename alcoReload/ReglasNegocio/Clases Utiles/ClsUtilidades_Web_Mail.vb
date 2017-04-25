Imports System.IO
Imports System.Net
Imports System.Net.Mime
Imports System.Security.Cryptography
Imports System.Text

Public Class ClsUtilidades_Web_Mail
    Public Function ComprimirURL(url As String) As String
        ComprimirURL = url
        Try
            'Dim objRequest As HttpWebRequest = DirectCast(WebRequest.Create("http://tinyurl.com/api-create.php?url=" & url), HttpWebRequest)
            'Dim objResponse As HttpWebResponse = DirectCast(objRequest.GetResponse(), HttpWebResponse)
            'Dim stmReader As New StreamReader(objResponse.GetResponseStream())
            'ComprimirURL = stmReader.ReadToEnd()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="destinatarios">Mail de los destinatarios separados por comas </param>
    ''' <param name="asunto">Asunto del mail</param>
    ''' <param name="mensaje">Mensaje del mail en texto plano o HTML</param>
    ''' <param name="mail_pass">mail y password del dominio alco desde donde se va a enviar el correo | por defecto alco@alco.com.co</param>
    ''' <param name="html">indica si el cuerpo del mail es html</param>
    ''' <returns>Indicador de si se envió el correo</returns>
    Public Function EnviarCorreo(destinatarios As String, asunto As String, mensaje As String,
                                 Optional mail_pass As Dictionary(Of String, String) = Nothing,
                                 Optional html As Boolean = False,
                                 Optional ruta_adjuntos As String() = Nothing) As Boolean
        EnviarCorreo = False
        Try
            Dim mmsg As New Mail.MailMessage()
            destinatarios = destinatarios.Replace(";", ",")
            mmsg.To.Add(destinatarios)
            mmsg.Subject = asunto
            mmsg.Body = mensaje
            mmsg.BodyEncoding = System.Text.Encoding.UTF8
            mmsg.IsBodyHtml = html
            mmsg.From = New System.Net.Mail.MailAddress("alco@alco.com.co")
            If ruta_adjuntos IsNot Nothing Then
                For Each ruta As String In ruta_adjuntos
                    Dim adjunto = New Mail.Attachment(ruta, MediaTypeNames.Application.Octet)
                    Dim propi = adjunto.ContentDisposition
                    adjunto.ContentDisposition.CreationDate = File.GetCreationTime(ruta)
                    adjunto.ContentDisposition.ModificationDate = File.GetLastWriteTime(ruta)
                    adjunto.ContentDisposition.ReadDate = File.GetLastAccessTime(ruta)
                    adjunto.ContentDisposition.FileName = Path.GetFileName(ruta)
                    adjunto.ContentDisposition.Size = New FileInfo(ruta).Length
                    adjunto.ContentDisposition.DispositionType = DispositionTypeNames.Attachment
                    mmsg.Attachments.Add(adjunto)
                Next
            End If

            Dim cliente As New System.Net.Mail.SmtpClient()
            If mail_pass Is Nothing Then
                cliente.Credentials =
            New System.Net.NetworkCredential("alco@alco.com.co", "alco2016")
            Else
                Dim mail As String = mail_pass.Keys(0)
                Dim pass As String = String.Empty
                mail_pass.TryGetValue(mail, pass)
                cliente.Credentials =
            New System.Net.NetworkCredential(mail, pass)
            End If
            cliente.Host = "mail.alco.com.co"
            cliente.Send(mmsg)
            Return True
        Catch ex As Mail.SmtpException
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function EncriptarParametros(parametro As String) As String
        EncriptarParametros = parametro
        Try
            Dim EncryptionKey As String = "MAKV2SPBNI99212"
            Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(EncriptarParametros)
            Using encryptor As Aes = Aes.Create()
                Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
                 &H65, &H64, &H76, &H65, &H64, &H65,
                 &H76})
                encryptor.Key = pdb.GetBytes(32)
                encryptor.IV = pdb.GetBytes(16)
                Using ms As New MemoryStream()
                    Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                        cs.Write(clearBytes, 0, clearBytes.Length)
                        cs.Close()
                    End Using
                    EncriptarParametros = Convert.ToBase64String(ms.ToArray())
                End Using
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
