Imports osu.Framework.Testing
Imports osuTK
Imports Block.Core.Objects
Imports Block.Core.Objects.Drawables
Imports Block.Core.UI

Namespace Visuals
    <ComponentModel.Description("tile merging")>
    Public Class TestCaseManagerMerging
        Inherits TestCaseManager

        Public Sub New()
            Manager.ShouldAddRandomTile = False
            AddStep("add tiles", Sub()
                                     Manager.Grid.InsertTile(New Tile(New Vector2(0, 0), 2))
                                     Manager.Grid.InsertTile(New Tile(New Vector2(1, 0), 2))
                                     Manager.Grid.InsertTile(New Tile(New Vector2(1, 1), 4))
                                     Manager.Grid.InsertTile(New Tile(New Vector2(2, 1), 4))
                                     Manager.Grid.InsertTile(New Tile(New Vector2(1, 2), 8))
                                     Manager.Grid.InsertTile(New Tile(New Vector2(3, 2), 8))
                                     Manager.Grid.InsertTile(New Tile(New Vector2(0, 3), 16))
                                     Manager.Grid.InsertTile(New Tile(New Vector2(3, 3), 16))
                                 End Sub)
            AddStep("merge", Sub()
                                 Manager.Move(MoveDirection.Left)
                             End Sub)
            AddStep("move right", Sub()
                                      Manager.Move(MoveDirection.Right)
                                  End Sub)
        End Sub
    End Class
End Namespace
