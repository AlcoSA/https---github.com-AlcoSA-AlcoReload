Imports System.Drawing
Public Class ClsUtilidadesImagenes

    Public Function ArregloBytesaImagen(arreglo() As Byte) As Image
        Try
            Return Image.FromStream(New IO.MemoryStream(arreglo))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function ImagenaArregloBytes(imagen As Image) As Byte()
        Try
            Dim mstream As New IO.MemoryStream
            imagen.Save(mstream, Drawing.Imaging.ImageFormat.Png)
            Return mstream.ToArray
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
