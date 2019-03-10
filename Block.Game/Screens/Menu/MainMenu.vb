Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports Block.Game.Graphics

Namespace Screens.Menu
    Public Class MainMenu
        Inherits Screen

        Public MainSystem As MenuButtonGroup
        Public PlaySystem As MenuButtonGroup
        Public ModeSystem As MenuButtonGroup
        Public LeadSystem As MenuButtonGroup

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour)
            MainSystem = New MenuButtonGroup
            MainSystem.AddButtonRange(New List(Of MenuButton) From {
                New MenuButton("exit", "leaving so soon?"),
                New MenuButton("play", "some classic 2048", Sub() MainSystem.SwitchTo(PlaySystem)),
                New MenuButton("leaderboards", "best of the best", Sub() MainSystem.SwitchTo(LeadSystem)),
                New MenuButton("settings", "fiddle around")
            })

            PlaySystem = New MenuButtonGroup(1)
            PlaySystem.AddButtonRange(New List(Of MenuButton) From {
                New MenuButton("back", "", Sub() MainSystem.Back()),
                New MenuButton("solo", "you alone", Sub() PlaySystem.SwitchTo(ModeSystem)),
                New MenuButton("multi", "with other people")
            })

            ModeSystem = New MenuButtonGroup(1)
            ModeSystem.AddButtonRange(New List(Of MenuButton) From {
                New MenuButton("back", "", Sub() PlaySystem.Back()),
                New MenuButton("classic", "reach the 2048 tile!"),
                New MenuButton("endless", "no stopping you now"),
                New MenuButton("time trial", "play as fast as you can!"),
                New MenuButton("move trial", "play with the least moves possible!")
            })

            LeadSystem = New MenuButtonGroup(1)
            LeadSystem.AddButtonRange(New List(Of MenuButton) From {
                New MenuButton("back", "", Sub() MainSystem.Back()),
                New MenuButton("local", "local ranking"),
                New MenuButton("global", "world ranking")
            })

            Content.AddRange(New List(Of Drawable) From {
                New SpriteText With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Text = "2048",
                    .Font = New FontUsage("OpenSans", 192, "Bold"),
                    .Colour = colour.FromHex("#776e65"),
                    .Y = -150
                },
                MainSystem,
                LeadSystem,
                PlaySystem,
                ModeSystem
            })
        End Sub
    End Class
End Namespace
