Imports osu.Framework.Allocation
Imports osu.Framework.Audio
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osu.Framework.Screens
Imports osuTK
Imports Block.Game.Graphics
Imports Block.Game.Screens.Play

Namespace Screens.Menu
    Public Class MainMenu : Inherits Screen
        Private Selector As RuleSelector

        <Resolved>
        Private Property Stack As ScreenStack

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour, ByVal audio As AudioManager, ByVal store As TextureStore)
            BackgroundTrack = audio.Track.Get("mainmenu")

            Dim logo = New Sprite With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Texture = store.Get("logo"),
                .Colour = colour.FromHex("#776e65"),
                .Scale = New Vector2(1.5),
                .Y = -200
            }
            Selector = New RuleSelector With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .SelectRule = AddressOf OnPlay,
                .Y = 50
            }
            Content.AddRange(New List(Of Drawable) From {
                logo,
                Selector,
                New MenuButton("multi") With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Y = 300
                },
                New MenuButton("exit") With {
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
            })
            logo.MoveToY(-190, 1000, Easing.OutSine).Then().MoveToY(-200, 1000, Easing.OutSine).Loop()
        End Sub

        Private Sub OnPlay(Optional ByVal size As Integer = 4)
            Stack.Exit()
            Stack.Push(New Player(Selector.GetSelectedRule(), 4))
        End Sub
    End Class
End Namespace
