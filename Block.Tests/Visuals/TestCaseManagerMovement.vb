Imports osu.Framework.Testing
Imports osuTK
Imports Block.Core.Objects
Imports Block.Core.Objects.Drawables
Imports Block.Core.UI

Namespace Visuals
    <ComponentModel.Description("tile movement")>
    Public Class TestCaseManagerMovement
        Inherits TestCaseManager

        Public Sub New()
            Manager.ShouldAddRandomTile = False
            AddStep("add tiles", Sub()
                                     Manager.Grid.InsertTile(New Tile(New Vector2(1, 1), 1024))
                                 End Sub)
            AddStep("move left", Sub()
                                     Manager.Move(MoveDirection.Left)
                                 End Sub)
            AddStep("move right", Sub()
                                      Manager.Move(MoveDirection.Right)
                                  End Sub)
            AddStep("move up", Sub()
                                   Manager.Move(MoveDirection.Up)
                               End Sub)
            AddStep("move down", Sub()
                                     Manager.Move(MoveDirection.Down)
                                 End Sub)
        End Sub
    End Class
End Namespace
