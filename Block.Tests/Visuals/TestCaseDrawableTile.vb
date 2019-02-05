Imports osu.Framework.Testing
Imports osuTK
Imports Block.Core.Objects
Imports Block.Core.Objects.Drawables

Namespace Visuals
    Public Class TestCaseDrawableTile
        Inherits TestCase

        Public Sub New()
            Dim Tile As New Tile(New Vector2(0, 0), 2)
            Dim DrawableTile As New DrawableTile(Tile) With {
                    .Anchor = Anchor.Centre
                }

            AddStep("add tile", Sub()
                                    Add(DrawableTile)
                                End Sub)
            AddRepeatStep("increment", Sub()
                                           Tile.Increment()
                                       End Sub, 3)
            AddWaitStep(3, "wait")
            AddRepeatStep("increment", Sub()
                                           Tile.Increment()
                                       End Sub, 3)
            AddWaitStep(3, "wait")
            AddRepeatStep("increment", Sub()
                                           Tile.Increment()
                                       End Sub, 3)
            AddWaitStep(3, "wait")
            AddRepeatStep("increment", Sub()
                                           Tile.Increment()
                                       End Sub, 1)
            AddWaitStep(3, "wait")
            AddRepeatStep("2048!", Sub()
                                       Tile.SetValue(11)
                                   End Sub, 1)
        End Sub
    End Class
End Namespace
