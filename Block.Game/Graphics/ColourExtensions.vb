Imports System.Runtime.CompilerServices
Imports osuTK.Graphics

Module ColourExtensions
    <Extension()>
    Public Function Darken(colour As Color4, value As Single) As Color4
        Return New Color4(colour.R - value,
                          colour.G - value,
                          colour.B - value,
                          colour.A)
    End Function

    <Extension()>
    Public Function Lighten(colour As Color4, value As Single) As Color4
        Return New Color4(colour.R + value,
                          colour.G + value,
                          colour.B + value,
                          colour.A)
    End Function
End Module
