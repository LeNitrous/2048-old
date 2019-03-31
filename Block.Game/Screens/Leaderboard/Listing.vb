Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes
Imports Block.Game.Online.Models
Imports osuTK

Namespace Screens.Leaderboard
    Public Class Listing : Inherits Container
        Private ReadOnly Attempts As List(Of UserAttempt)
        Private RankList As FillFlowContainer

        Public Sub New(attempts As List(Of UserAttempt))
            Me.Attempts = attempts
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Size = New Vector2(800, 600)
            RankList = New FillFlowContainer With {
                .Direction = FillDirection.Vertical,
                .RelativeSizeAxes = Axes.X,
                .AutoSizeAxes = Axes.Y
            }
            Child = New ScrollContainer With {
                .RelativeSizeAxes = Axes.Both,
                .Child = RankList,
                .ScrollbarVisible = False
            }
            For Each attempt In Attempts
                RankList.Add(New ListingItem(attempt, Attempts.IndexOf(attempt) + 1))
            Next
        End Sub

        Private Class ListingItem : Inherits Container
            Private ReadOnly Attempt As UserAttempt
            Private ReadOnly RankIndex As Integer

            Public Sub New(attempt As UserAttempt, pos As Integer)
                Me.Attempt = attempt
                RankIndex = pos
            End Sub

            <BackgroundDependencyLoader>
            Private Sub Load(colours As Colours)
                Size = New Vector2(800, 100)
                Margin = New MarginPadding With {.Bottom = 10}
                Children = New List(Of Drawable) From {
                    New RoundedBox With {
                        .RelativeSizeAxes = Axes.Both,
                        .Colour = colours.DarkestBrown
                    },
                    New SpriteText With {
                        .Anchor = Anchor.CentreLeft,
                        .Origin = Anchor.Centre,
                        .Position = New Vector2(40, -3),
                        .Text = RankIndex,
                        .Font = New FontUsage("ClearSans", 84, "Bold")
                    },
                    New SpriteText With {
                        .Position = New Vector2(95, 20),
                        .Text = "Guest",
                        .Font = New FontUsage("ClearSans", 32, "Bold")
                    }
                }
            End Sub
        End Class
    End Class
End Namespace
