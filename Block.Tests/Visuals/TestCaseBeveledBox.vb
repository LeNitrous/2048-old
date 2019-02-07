Imports osu.Framework.Allocation
Imports osu.Framework.Testing
Imports Block.Core.Graphics
Imports Block.Core.Graphics.Shapes
Imports osuTK

Namespace Visuals
    Public Class TestCaseBeveledBox
        Inherits TestCase

        Public Sub New()

        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(color As BlockColor)
            Add(New BeveledBox(color.FromHex("8f7a66"), color.FromHex("6c5c4d")) With {
                .Size = New Vector2(150)
            })
        End Sub
    End Class
End Namespace
