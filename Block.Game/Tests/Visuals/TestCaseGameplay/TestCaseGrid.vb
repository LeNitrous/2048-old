Imports osu.Framework.Allocation
Imports osu.Framework.Testing
Imports Block.Game.Gameplay.Drawables
Imports Block.Game.Gameplay.Managers
Imports Block.Game.Gameplay.Objects

Namespace Tests.Visuals.TestCaseGameplay
    Public Class TestCaseGrid : Inherits TestCase
        <BackgroundDependencyLoader>
        Private Sub Load()
            Dim manager = New GridManager(4)
            Dim drawableGrid = New DrawableGrid(manager)
            Add(drawableGrid)

            AddStep("fill grid", Sub()
                                     manager.Grid.EachCell(Sub(pos, tile)
                                                               manager.Grid.InsertTile(New Tile(2, pos))
                                                           End Sub)
                                 End Sub)
            AddStep("collapse", Sub() drawableGrid.Collapse())
        End Sub
    End Class
End Namespace
