Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Input.Bindings
Imports osuTK
Imports Block.Game.Graphics
Imports Block.Game.Graphics.UserInterface
Imports Block.Game.Objects.Managers
Imports Block.Game.Objects.Drawables
Imports Block.Game.Rules

Namespace Screens.Play
    Public Class Player : Inherits Screen : Implements IKeyBindingHandler(Of MoveDirection)
        Private ReadOnly GameManager As GridManager
        Private ReadOnly GameRule As GameRule

        Public Sub New(ByVal rule As IGameRule, ByVal size As Integer)
            GameManager = New GridManager(size)
            GameRule = rule
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour)
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
                    New ButtonIcon("exit"),
                    New ButtonIcon("restart")
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

        End Sub

        Private Sub OnLose()
            GameManager.Watch.Stop()
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
