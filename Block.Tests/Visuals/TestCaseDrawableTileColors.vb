Imports osu.Framework.Testing
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osuTK
Imports Block.Core.Objects
Imports Block.Core.Objects.Drawables

Namespace Visuals
    Public Class TestCaseDrawableTileColors
        Inherits TestCase

        Public Sub New()
            Dim tileContainer = CreateTileContainer()
            Add(tileContainer)

            For i = 1 To 12
                Dim drawableTile = New DrawableTile(New Tile(New Vector2(0, 0), 2 ^ i)) With {
                    .Anchor = Anchor.Centre
                }
                tileContainer.Add(drawableTile)
            Next
        End Sub

        Private Function CreateTileContainer() As FillFlowContainer
            Return New FillFlowContainer With {
                .RelativeSizeAxes = Axes.Both
            }
        End Function
    End Class
End Namespace
