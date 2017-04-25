Imports System.DirectoryServices

Public Class ClsUtilidadesServidor
    Public Function llenarListaUsuariosNt() As String()
        Try
            Dim objDirectorioActivo As DirectoryEntry = New DirectoryEntry("LDAP://alco.com.co")
            Dim objBuscador As DirectorySearcher = New DirectorySearcher(objDirectorioActivo)
            objBuscador.Filter = ("(&(objectClass=user)" + "( (userPrincipalName=*)))")
            objBuscador.PropertiesToLoad.Add("userPrincipalName")
            Return objBuscador.FindAll().Cast(Of SearchResult).Select(Function(x) Convert.ToString(x.Properties("userPrincipalName")(0)).Replace("@alco.com.co", "")).OrderBy(Function(x) x).ToArray()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerNombreDirectorio(ByVal usuario As String) As String
        TraerNombreDirectorio = String.Empty
        Try
            Dim objDirectorioActivo As DirectoryEntry = New DirectoryEntry("LDAP://alco.com.co")
            Dim objBuscador As DirectorySearcher = New DirectorySearcher(objDirectorioActivo)
            Dim objSeleccionados As SearchResult
            objBuscador.PropertiesToLoad.Add("userPrincipalName")
            objBuscador.Filter = "(&(&(objectClass=user))" + "(|" + "(userPrincipalName=" & Trim(usuario) & "@alco.com.co" & "*)))"
            objSeleccionados = objBuscador.FindOne()
            If objSeleccionados Is Nothing Then
                Throw New Exception("Errores con registro de usuario en el servidor")
            End If
            If objSeleccionados.GetDirectoryEntry().Properties.Count > 0 Then
                Return Convert.ToString(objSeleccionados.GetDirectoryEntry().Properties("name").Value)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
