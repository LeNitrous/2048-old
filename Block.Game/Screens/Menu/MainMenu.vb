Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osu.Framework.Screens
Imports Block.Game.Graphics
Imports Block.Game.Rules
Imports Block.Game.Screens.Play
Imports osuTK

Namespace Screens.Menu
    Public Class MainMenu : Inherits Screen
        Private Player As Player
        Private RuleSelect As RuleSelector

        <BackgroundDependencyLoader>
        Private Sub Load(colours As Colours, store As TextureStore)
            RuleSelect = New RuleSelector With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .SelectRule = AddressOf OnPlay,
                .Y = 50
            }
            InternalChildren = New List(Of Drawable) From {
                RuleSelect,
                New Sprite With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Texture = store.Get("logo"),
                    .Colour = colours.FromHex("#776e65"),
                    .Scale = New Vector2(1.5),
                    .Y = -200
                },
                New MenuButton("exit", Sub() Game.Exit()) With {
                    .Scale = New Vector2(0.5),
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Y = 320
                },
                New MenuButton("multi") With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Position = New Vector2(-300, 180)
                },
                New MenuButton("leaderboard") With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Position = New Vector2(300, 180)
                },
                New MenuButton("settings") With {
                    .Anchor = Anchor.TopRight,
                    .Origin = Anchor.TopRight,
                    .Scale = New Vector2(0.5),
                    .Position = New Vector2(-10, 50)
                }
            }


        End Sub

        Private Sub OnPlay(rule As GameRule)
            LoadComponentAsync(New Player(rule), Sub(s) Push(s))
        End Sub
    End Class
End Namespace
