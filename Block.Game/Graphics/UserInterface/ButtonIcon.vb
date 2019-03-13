Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osuTK
Imports osuTK.Graphics
Imports Block.Game.Graphics.Shapes
Imports osu.Framework.Input.Events

Namespace Graphics.UserInterface
    Public Class ButtonIcon : Inherits ClickableContainer
        Public IconSprite As Sprite

        Private ReadOnly Icon As String
        Private ReadOnly ClickAction As Action
        Private Overlay As RoundedBox

        Public Sub New(ByVal icon As String, Optional ByVal action As Action = Nothing)
            Me.Icon = icon
            ClickAction = action
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour, ByVal store As TextureStore)
            Size = New Vector2(40)
            Overlay = New RoundedBox With {
                .RelativeSizeAxes = Axes.Both,
                .Colour = Color4.WhiteSmoke,
                .Alpha = 0F
            }
            IconSprite = New Sprite With {
                .Texture = store.Get(String.Format("Interface/{0}", Icon)),
                .Size = New Vector2(24),
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre
            }
            Children = New List(Of Drawable) From {
                New RoundedBox With {
                    .RelativeSizeAxes = Axes.Both,
                    .Colour = colour.FromHex("8f7a66")
                },
                IconSprite,
                Overlay
            }
        End Sub

        Protected Overrides Function OnMouseDown(e As MouseDownEvent) As Boolean
            Overlay.FadeTo(0.1, 1000, Easing.OutQuart)
            Return MyBase.OnMouseDown(e)
        End Function

        Protected Overrides Function OnMouseUp(e As MouseUpEvent) As Boolean
            Overlay.FadeOut(1000, Easing.OutQuart)
            Return MyBase.OnMouseUp(e)
        End Function

        Protected Overrides Function OnClick(e As ClickEvent) As Boolean
            Overlay.ClearTransforms()
            Overlay.Alpha = 0.9F
            Overlay.FadeOut(500, Easing.OutQuart)

            If Not ClickAction Is Nothing Then
                ClickAction.Invoke()
            End If

            Return MyBase.OnClick(e)
        End Function
    End Class
End Namespace
