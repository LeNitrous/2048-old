Imports osu.Framework.Screens
Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports Block.Game.Graphics
Imports Block.Game.Rules
Imports Block.Game.Screens.Play

Namespace Screens.Menu
    Public Class MainMenu : Inherits Screen
        Public MainSystem As MenuButtonGroup
        Public PlaySystem As MenuButtonGroup
        Public ModeSystem As MenuButtonGroup
        Public LeadSystem As MenuButtonGroup

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal stack As ScreenStack, ByVal colour As BlockColour)
            MainSystem = New MenuButtonGroup
            MainSystem.AddButtonRange(New List(Of MenuButton) From {
                New MenuButton("exit", "leaving so soon?"),
                New MenuButton("play", "some classic 2048", Sub() MainSystem.SwitchTo(PlaySystem))
            })

            PlaySystem = New MenuButtonGroup(1)
            PlaySystem.AddButtonRange(New List(Of MenuButton) From {
                New MenuButton("back", "", Sub() MainSystem.Back()),
                New MenuButton("solo", "you alone", Sub() PlaySystem.SwitchTo(ModeSystem))
            })

            ModeSystem = New MenuButtonGroup(1)
            ModeSystem.AddButtonRange(New List(Of MenuButton) From {
                New MenuButton("back", "", Sub() PlaySystem.Back()),
                New MenuButton("classic", "reach the 2048 tile", Sub()
                                                                     stack.Exit()
                                                                     stack.Push(New Player(New GameRuleClassic, 3))
                                                                 End Sub),
                New MenuButton("endless", "play as long as you can", Sub()
                                                                         stack.Exit()
                                                                         stack.Push(New Player(New GameRuleEndless, 3))
                                                                     End Sub)
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
                    .Font = New FontUsage("ClearSans", 192, "Bold"),
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
