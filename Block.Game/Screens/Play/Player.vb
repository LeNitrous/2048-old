Imports osu.Framework.Allocation
Imports osu.Framework.Audio
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Input.Bindings
Imports osu.Framework.Screens
Imports osuTK
Imports Block.Game.Graphics
Imports Block.Game.Graphics.UserInterface
Imports Block.Game.Objects
Imports Block.Game.Objects.Managers
Imports Block.Game.Objects.Drawables
Imports Block.Game.Rules
Imports Block.Game.Screens.Menu

Namespace Screens.Play
    Public Class Player : Inherits Screen : Implements IKeyBindingHandler(Of MoveDirection)
        Private ReadOnly GameManager As GridManager
        Private ReadOnly GameRule As GameRule

        <Resolved>
        Private Property Stack As ScreenStack

        Public Sub New(ByVal rule As IGameRule, ByVal size As Integer)
            GameManager = New GridManager(size)
            GameRule = rule
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal audio As AudioManager, ByVal colour As BlockColour)
            BackgroundTrack = audio.Track.Get("gameplay-solo")

            Dim Counter As New FillFlowContainer With {
                .Direction = FillDirection.Horizontal,
                .Anchor = Anchor.Centre,
                .Position = New Vector2(-300, -360),
                .Size = New Vector2(300, 80)
            }
            Dim Buttons As New FillFlowContainer With {
                .Direction = FillDirection.Horizontal,
                .Anchor = Anchor.Centre,
                .Position = New Vector2(0, -360),
                .Size = New Vector2(300, 80),
                .Children = New List(Of Drawable) From {
                    New ButtonIcon("exit", AddressOf OnExit),
                    New ButtonIcon("restart", AddressOf OnRestart),
                    New ButtonIcon("back")
                }
            }

            If GameRule.ShowMoves Then
                Counter.Add(New MoveCounter(GameManager.Moves))
            End If

            If GameRule.ShowScore Then
                Counter.Add(New ScoreCounter(GameManager.Score))
            End If

            If GameRule.ShowTimer Then
                Counter.Add(New TimerCounter(GameManager.Watch))
            End If

            For Each Child In Counter.Children
                Child.Margin = New MarginPadding With {.Right = 5}
            Next

            For Each Child In Buttons.Children
                Child.Margin = New MarginPadding With {.Left = 5}
                Child.Anchor = Anchor.BottomRight
                Child.Origin = Anchor.BottomRight
            Next

            Content.AddRange(New List(Of Drawable) From {
                New GridInputContainer With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Y = 30,
                    .RelativeSizeAxes = Axes.None,
                    .AutoSizeAxes = Axes.Both,
                    .Child = New DrawableGrid(GameManager) With {.GridAreaSize = 600}
                },
                Counter,
                Buttons
            })

            GameManager.AddStartTiles()
            GameManager.Watch.Start()

            AddHandler GameManager.Win, AddressOf OnWin
            AddHandler GameManager.Lose, AddressOf OnLose
        End Sub

        Private Sub OnWin()
            GameManager.Watch.Stop()
            Stack.Exit()
            Stack.Push(New MainMenu)
        End Sub

        Private Sub OnLose()
            GameManager.Watch.Stop()
            Stack.Exit()
            Stack.Push(New MainMenu)
        End Sub

        Private Sub OnExit()
            Stack.Exit()
            Stack.Push(New MainMenu)
        End Sub

        Private Sub OnRestart()
            GameManager.Watch.Restart()
            GameManager.Score.Value = 0
            GameManager.Moves.Value = 0
        End Sub

        Private Sub OnRewind()
            Dim last As Tile(,) = GameManager.History.LastOrDefault()
            GameManager.Grid.Cells = last
        End Sub

        Public Function OnPressed(action As MoveDirection) As Boolean Implements IKeyBindingHandler(Of MoveDirection).OnPressed
            GameManager.Move(action)
            Return True
        End Function

        Public Function OnReleased(action As MoveDirection) As Boolean Implements IKeyBindingHandler(Of MoveDirection).OnReleased
            Return True
        End Function
    End Class
End Namespace
