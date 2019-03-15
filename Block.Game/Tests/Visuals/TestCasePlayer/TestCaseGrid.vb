Imports osu.Framework.Graphics
Imports osu.Framework.Input.Bindings
Imports osu.Framework.Testing
Imports Block.Game.Objects
Imports Block.Game.Objects.Managers
Imports Block.Game.Objects.Drawables

Namespace Tests.Visuals.TestCasePlayer
    Public Class TestCaseGrid : Inherits TestCase
        Public Manager As New GridManager(4)

        Public Sub New()
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
