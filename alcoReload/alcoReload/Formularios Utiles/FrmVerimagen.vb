Imports ReglasNegocio
Public Class FrmVerimagen
#Region "vars"
    Private _imagen() As Byte
#End Region
#Region "props"
    Public Property Imagen As Byte()
        Get
            Return _imagen
        End Get
        Set(value As Byte())
            _imagen = value
            Dim img As New ClsUtilidadesImagenes
            pbimagen.Image = img.ArregloBytesaImagen(_imagen)
        End Set
    End Property
#End Region
End Class