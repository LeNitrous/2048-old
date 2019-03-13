Imports osu.Framework.Allocation
Imports osu.Framework.Audio
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Screens
Imports Block.Game.Graphics
Imports Block.Game.Rules
Imports Block.Game.Screens.Play

Namespace Screens.Menu
    Public Class MainMenu : Inherits Screen
        <Resolved>
        Private Property Stack As ScreenStack

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour, ByVal audio As AudioManager)
            Dim music = audio.Track.Get("newfriendly")
            music.RestartPoint = 25061
            music.Looping = True
            music.Start()

            Content.AddRange(New List(Of Drawable) From {
                New SpriteText With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Text = "2048",
                    .Font = New FontUsage("ClearSans", 192, "Bold"),
                    .Colour = colour.FromHex("#776e65"),
                    .Y = -150
                },
                New ButtonSystem
            })
        End Sub

        Private Sub OnPlay(ByVal rule As IGameRule, Optional ByVal size As Integer = 4)
            Stack.Exit()
            Stack.Push(New Player(rule, 4))
        End Sub
    End Class
End Namespace
