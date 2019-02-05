Imports osu.Framework.Testing
Imports osuTK
Imports Block.Core.Objects
Imports Block.Core.Objects.Drawables

Namespace Visuals
    Public Class TestCaseDrawableGrid
        Inherits TestCase

        Public Sub New()
            Dim grid As New Grid(4)
            Dim drawableGrid As New DrawableGrid(grid)

            Add(drawableGrid)

            AddStep("add tile at 0,0", Sub()
                                           grid.InsertTile(New Tile(New Vector2(0, 0), 2))
                                       End Sub)
            AddStep("add tile at 2,1", Sub()
                                           grid.InsertTile(New Tile(New Vector2(2, 1), 32))
                                       End Sub)
            AddStep("add tile at 3,2", Sub()
                                           grid.InsertTile(New Tile(New Vector2(3, 2), 8))
                                       End Sub)
        End Sub
    End Class
End Namespace
