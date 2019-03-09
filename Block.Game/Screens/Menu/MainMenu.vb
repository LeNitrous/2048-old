Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osuTK
Imports Block.Game.Graphics

Namespace Screens.Menu
    Public Class MainMenu
        Inherits Screen

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour)
            Content.AddRange(New List(Of Drawable) From {
                New SpriteText With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Text = "2048",
                    .Font = New FontUsage("OpenSans", 192, "Bold"),
                    .Colour = colour.FromHex("#776e65"),
                    .Y = -150
                },
                New FillFlowContainer With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .AutoSizeAxes = Axes.Both,
                    .Y = 150,
                    .Children = New List(Of Drawable) From {
                        New MenuButton("exit", "leaving so soon?") With {
                            .Anchor = Anchor.Centre,
                            .Origin = Anchor.Centre
                        },
                        New MenuButton("play", "some classic 2048") With {
                            .Anchor = Anchor.Centre,
                            .Origin = Anchor.Centre,
                            .Margin = New MarginPadding With {
                                .Horizontal = 20.0F
                            }
                        },
                        New MenuButton("settings", "fiddle around") With {
                            .Anchor = Anchor.Centre,
                            .Origin = Anchor.Centre
                        }
                    }
                }
            })
        End Sub
    End Class
End Namespace
