Imports osu.Framework.Allocation
Imports osu.Framework.Testing
Imports Block.Game.Gameplay.Managers
Imports Block.Game.Gameplay.Objects
Imports Block.Game.Gameplay.Rules
Imports osuTK

Namespace Tests.Visuals.TestCaseGameplay
    Public Class TestCaseRuleContainer : Inherits TestCase
        Public GridManager As New GridManager(4)
        Public RuleManager As RuleContainer
        Public Won As Boolean = False
        Public Lost As Boolean = False

        <BackgroundDependencyLoader>
        Private Sub Load()
            RuleManager = New RuleContainer(New GameRuleClassic, GridManager)

            Add(RuleManager)

            ' Basic Movement
            AddStep("start game", Sub() RuleManager.Start())
            AddStep("move up", Sub() GridManager.Move(MoveDirection.Up))
            AddStep("move down", Sub() GridManager.Move(MoveDirection.Down))
            AddStep("move left", Sub() GridManager.Move(MoveDirection.Left))
            AddStep("move right", Sub() GridManager.Move(MoveDirection.Right))

            ' Pause
            AddStep("pause", Sub() RuleManager.Paused = True)
            AddAssert("try move up", Function() GridManager.Move(MoveDirection.Up) = False)
            AddAssert("try move down", Function() GridManager.Move(MoveDirection.Down) = False)
            AddAssert("try move left", Function() GridManager.Move(MoveDirection.Left) = False)
            AddAssert("try move right", Function() GridManager.Move(MoveDirection.Right) = False)
            AddStep("unpause", Sub() RuleManager.Paused = False)

            ' Lose
            AddStep("reset", Sub() RuleManager.Reset())
            AddStep("setup lose", Sub()
                                      Dim value = 2
                                      GridManager.Grid.EachCell(Sub(pos, tile)
                                                                    If value >= 65536 Then Exit Sub
                                                                    GridManager.Grid.InsertTile(New Tile(value, pos))
                                                                    value *= 2
                                                                End Sub)
                                  End Sub)
            AddStep("move right", Sub() GridManager.Move(MoveDirection.Right))
            AddAssert("moves available", Function() GridManager.MovesAvailable() = False)
            AddAssert("has lost", Function() Lost = True)

            ' Win
            AddStep("reset", Sub() RuleManager.Reset())
            AddStep("setup win", Sub()
                                     GridManager.Grid.InsertTile(New Tile(1024, New Vector2(1, 1)))
                                     GridManager.Grid.InsertTile(New Tile(1024, New Vector2(1, 3)))
                                 End Sub)
            AddStep("move up", Sub() GridManager.Move(MoveDirection.Up))
            AddAssert("has won", Function() Won = True)


            AddHandler RuleManager.OnEnd, AddressOf OnEndEvent
        End Sub

        Private Sub OnEndEvent(e As EndType)
            Select Case e
                Case EndType.Win
                    Won = True
                    Exit Select
                Case EndType.Lose
                    Lost = True
                    Exit Select
            End Select
        End Sub
    End Class
End Namespace
