Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osu.Framework.Input.Events
Imports osuTK

Namespace Graphics.UserInterface
    Public Class IconButton : Inherits Button
        Public Icon As String

        Public Sub New(icon As String, Optional clickAction As Action = Nothing)
            MyBase.New("", clickAction)
            Me.Icon = icon
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(colours As Colours, store As TextureStore)
            Size = New Vector2(40)
            BodyColour = colours.DarkestBrown
            Body.Colour = colours.DarkestBrown
            RemoveAll(Function(d) True)

            Children = New List(Of Drawable) From {
                New ClickSound,
                Body,
                New Sprite With {
                    .Size = New Vector2(20),
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Texture = store.Get("Interface/" & Icon)
                },
                Flash
            }
        End Sub
    End Class
End Namespace
