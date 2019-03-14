Imports osu.Framework.Allocation
Imports osu.Framework.Audio
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osu.Framework.Screens
Imports osuTK
Imports Block.Game.Graphics
Imports Block.Game.Rules
Imports Block.Game.Screens.Play

Namespace Screens.Menu
    Public Class MainMenu : Inherits Screen
        <Resolved>
        Private Property Stack As ScreenStack

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour, ByVal audio As AudioManager, ByVal store As TextureStore)
            Dim music = audio.Track.Get("presenterator")
            music.RestartPoint = 24
            music.Looping = True
            music.Start()

            Content.AddRange(New List(Of Drawable) From {
                New Sprite With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Texture = store.Get("logo"),
                    .Colour = colour.FromHex("#776e65"),
                    .Scale = New Vector2(1.5),
                    .Y = -150
                }
            })
        End Sub

        Private Sub OnPlay(ByVal rule As IGameRule, Optional ByVal size As Integer = 4)
            Stack.Exit()
            Stack.Push(New Player(rule, 4))
        End Sub
    End Class
End Namespace
