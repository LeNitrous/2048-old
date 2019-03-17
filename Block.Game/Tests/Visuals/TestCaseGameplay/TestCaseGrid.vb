Imports osu.Framework.Allocation
Imports osu.Framework.Testing
Imports Block.Game.Gameplay.Drawables
Imports Block.Game.Gameplay.Managers
Imports Block.Game.Gameplay.Objects

Namespace Tests.Visuals.TestCaseGameplay
    Public Class TestCaseGrid : Inherits TestCase
        Public Manager As New GridManager(4)

        <BackgroundDependencyLoader>
        Private Sub Load()
            Add(New DrawableGrid(Manager))

            AddStep("fill grid", AddressOf FillGrid)
        End Sub

        Private Sub FillGrid()
            Manager.Grid.EachCell(Sub(pos, tile)
                                      Manager.Grid.InsertTile(New Tile(2, pos))
                                  End Sub)
        End Sub
    End Class
End Namespace
