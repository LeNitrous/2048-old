Imports osuTK.Graphics

Namespace Graphics
    Public Class BlockColor
        Public Function Gray(ByVal amt As Single) As Color4
            Return New Color4(amt, amt, amt, 1.0F)
        End Function

        Public Function Gray(ByVal amt As Byte) As Color4
            Return New Color4(amt, amt, amt, 255)
        End Function

        Public Function FromHex(ByVal hex As String) As Color4
            If hex(0) = "#" Then
                hex = hex.Substring(1)
            End If
            Select Case hex.Length
                Case 3
                    Return New Color4(
                            Convert.ToByte(hex.Substring(0, 1), 16) * 17,
                            Convert.ToByte(hex.Substring(1, 1), 16) * 17,
                            Convert.ToByte(hex.Substring(2, 1), 16) * 17,
                            255)
                Case 6
                    Return New Color4(
                            Convert.ToByte(hex.Substring(0, 2), 16),
                            Convert.ToByte(hex.Substring(2, 2), 16),
                            Convert.ToByte(hex.Substring(4, 2), 16),
                            CByte(255))
                Case Else
                    Throw New ArgumentException("Malformed hex string!")
            End Select
        End Function
    End Class
End Namespace
