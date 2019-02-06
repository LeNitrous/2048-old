Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Input.Events
Imports osuTK
Imports Block.Core.Graphics
Imports Block.Core.Graphics.UserInterface
Imports Block.Core.Objects.Drawables
Imports Block.Core.Screens.Play.Components

Namespace Screens.Play
    Public Class Player
        Inherits BlockScreen

        Private ReadOnly manager As Manager

        Private score As CounterScore
        Private moves As Counter
        Private timer As CounterClock
        Private grid As DrawableGrid

        Public Sub New()
            manager = New Manager(4)
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(color As BlockColor)
            BackgroundColor = color.FromHex("#faf8ef")

            grid = New DrawableGrid(manager.Grid) With {
                .Anchor = Anchor.TopCentre,
                .Origin = Anchor.TopCentre,
                .RelativePositionAxes = Axes.Y,
                .Y = 0.23
            }
            score = New CounterScore(manager.Score) With {
                .Anchor = Anchor.BottomRight,
                .Origin = Anchor.BottomRight,
                .Y = -72
            }
            moves = New Counter("Moves", manager.Moves) With {
                .Margin = New MarginPadding With {
                    .Right = 18
                }
            }
            timer = New CounterClock

            Content.Children = New List(Of Drawable)({
                New Container With {
                    .RelativeSizeAxes = Axes.Y,
                    .Anchor = Anchor.TopCentre,
                    .Origin = Anchor.TopCentre,
                    .Size = New Vector2(522, 0.2),
                    .Children = New List(Of Drawable)({
                        New FillFlowContainer With {
                            .Anchor = Anchor.BottomRight,
                            .Origin = Anchor.BottomRight,
                            .AutoSizeAxes = Axes.Both,
                            .FillMode = Axes.X,
                            .Children = New List(Of Drawable)({
                                moves,
                                timer
                            })
                        },
                        New FillFlowContainer With {
                            .Anchor = Anchor.BottomLeft,
                            .Origin = Anchor.BottomLeft,
                            .AutoSizeAxes = Axes.Both,
                            .FillMode = Axes.X,
                            .Children = New List(Of Drawable)({
                                New BlockButton("") With {
                                    .RelativeSizeAxes = Axes.None,
                                    .Width = 40,
                                    .Margin = New MarginPadding With {
                                        .Right = 12
                                    }
                                },
                                New BlockButton("") With {
                                    .RelativeSizeAxes = Axes.None,
                                    .Width = 40
                                }
                            })
                        },
                        score
                    })
                },
                grid
            })

            ' Lets start the game immediately for now.
            manager.AddStartTiles()
            timer.Start()
        End Sub

        Protected Overrides Function OnKeyDown(e As KeyDownEvent) As Boolean
            manager.HandleInput(e)
            Return MyBase.OnKeyDown(e)
        End Function
    End Class
End Namespace
