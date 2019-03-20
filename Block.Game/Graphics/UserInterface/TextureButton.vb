Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osuTK.Graphics
Imports osu.Framework.Input.Events

Namespace Graphics.UserInterface
    Public Class TextureButton : Inherits ClickableContainer
        Public ClickAction As Action
        Public Icon As String
        Public Flipped As Boolean
        Public BaseColour As Color4
        Protected Texture As Sprite
        Protected Flash As Sprite

        <Resolved>
        Private Property Store As TextureStore

        <BackgroundDependencyLoader>
        Private Sub Load()
            Flash = CreateSprite()
            With Flash
                .Colour = Color4.WhiteSmoke
                .Alpha = 0
            End With
            Texture = CreateSprite()
            Texture.Colour = BaseColour
            Children = New List(Of Drawable) From {
                New ClickSound,
                Texture,
                Flash
            }
        End Sub

        Private Function CreateSprite() As Sprite
            Return New Sprite With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .RelativeSizeAxes = Axes.Both,
                    .Texture = Store.Get("Interface/" & Icon),
                    .Rotation = If(Flipped, 180, 0)
                }
        End Function

        Protected Overrides Function OnClick(e As ClickEvent) As Boolean
            Flash.ClearTransforms()
            Flash.Alpha = 0.9
            Flash.FadeOut(300, Easing.OutQuart)
            If Not ClickAction Is Nothing Then
                ClickAction.Invoke()
            End If
            Return MyBase.OnClick(e)
        End Function
    End Class
End Namespace
