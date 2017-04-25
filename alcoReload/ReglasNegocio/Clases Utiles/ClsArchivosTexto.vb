Imports System.Text
Imports System.Threading.Tasks

Public Class ClsArchivosTexto
    Public Sub Tabla_Archivo(tabla As DataTable, ruta As String)
        Try

            Dim sb As New StringBuilder
            tabla.Rows.Cast(Of DataRow).ToList().ForEach(Sub(x)
                                                             For i As Integer = 0 To tabla.Columns.Count - 1
                                                                 sb.Append(Convert.ToString(x.ItemArray(i)) & ",")
                                                             Next
                                                             sb.AppendLine()
                                                         End Sub)
            Using outputFile As New IO.StreamWriter(ruta, True)
                outputFile.WriteLine(sb.ToString())
            End Using
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function Comparar_Archivos_Texto(ruta_archivo_1 As String, ruta_archivo_2 As String) As Boolean
        Try
            Dim archivo_a As New IO.StreamReader(ruta_archivo_1)
            Dim archivo_b As New IO.StreamReader(ruta_archivo_2)
            Dim lines_a() As String = archivo_a.ReadToEnd().Split(Chr(13))
            Dim lines_b() As String = archivo_b.ReadToEnd().Split(Chr(13))
            Dim archivos_diferentes As Boolean = False
            Parallel.For(0, lines_a.Length - 1,
                   Sub(i As Integer)
                       If Not lines_a(i).Equals(lines_b(i)) Then
                           archivos_diferentes = True
                           Return
                       End If
                   End Sub)
            archivo_a.Close()
            archivo_b.Close()
            Return archivos_diferentes
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
