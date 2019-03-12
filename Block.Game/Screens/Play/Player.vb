Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports Block.Game.Graphics
Imports Block.Game.Objects
Imports Block.Game.Objects.Drawables
Imports Block.Game.Rules
Imports osu.Framework.Input.Events

Namespace Screens.Play
    Public Class Player : Inherits Screen
        Private ReadOnly GameManager As Manager
        Private ReadOnly GameRule As IGameRule

        Public Sub New(ByVal rule As IGameRule, ByVal size As Integer)
            GameManager = New Manager(size)
            GameRule = rule
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour)
            Dim Counter As New FillFlowContainer With {
                .AutoSizeAxes = Axes.Both,
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Y = -320
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

            Content.AddRange(New List(Of Drawable) From {
                New DrawSizePreservingFillContainer With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .RelativeSizeAxes = Axes.None,
                    .Strategy = DrawSizePreservationStrategy.Average,
                    .Size = New osuTK.Vector2(528),
                    .Child = New DrawableGrid(GameManager.Grid)
                },
                Counter
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

        Protected Overrides Function OnKeyDown(e As KeyDownEvent) As Boolean
            GameManager.HandleInput(e)
            Return MyBase.OnKeyDown(e)
        End Function
    End Class
End Namespace
