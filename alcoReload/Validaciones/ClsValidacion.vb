Public Class ClsValidacion

    Public Function SoloLetras(ByRef Teclas As Integer) As Integer
        Select Case Teclas
            Case 65 To 90, 97 To 122, 164, 165, 13, 8, 32, 44
                SoloLetras = Teclas
                Exit Function
            Case Else

        End Select

    End Function
End Class
