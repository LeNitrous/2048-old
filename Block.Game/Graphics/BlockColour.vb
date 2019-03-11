Imports osuTK.Graphics

Namespace Graphics
    Public Class BlockColour
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

        Public TileColours As New List(Of Color4) From {
            FromHex("eee4da"),
            FromHex("ede0c8"),
            FromHex("f2b179"),
            FromHex("f59563"),
            FromHex("f67c5f"),
            FromHex("f65e3b"),
            FromHex("edcf72"),
            FromHex("edcc61"),
            FromHex("edc850"),
            FromHex("edc53f"),
            FromHex("edc22e"),
            FromHex("3c3a32")
        }
    End Class
End Namespace
