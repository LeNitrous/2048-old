Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osu.Framework.Input.Events
Imports osuTK
Imports osuTK.Graphics
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes

Namespace Screens.Menu
    Public Class MenuButton : Inherits ClickableContainer
        Public ReadOnly TextureIcon As String
        Public ReadOnly ClickAction As Action
        Private Flash As RoundedBox

        Public Sub New(ByVal icon As String, Optional ByVal onClick As Action = Nothing)
            TextureIcon = icon
            ClickAction = onClick
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal store As TextureStore, ByVal colours As BlockColour)
            Size = New Vector2(142)
            Rotation = 45.0F
            EdgeEffect = New EdgeEffectParameters With {
                .Colour = Color4.Black,
                .Hollow = True,
                .Radius = 5.0F,
                .Type = EdgeEffectType.Shadow
            }
            Flash = New RoundedBox With {
                .RelativeSizeAxes = Axes.Both,
                .Colour = Color4.WhiteSmoke,
                .Alpha = 0
            }
            Children = New List(Of Drawable) From {
                New RoundedBox With {
                    .RelativeSizeAxes = Axes.Both,
                    .Colour = colours.DarkerBrown
                },
                New Sprite With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Texture = store.Get("Interface/" & TextureIcon),
                    .Size = New Vector2(80),
                    .Rotation = -45.0F
                },
                Flash
            }
        End Sub

        Protected Overrides Function OnClick(e As ClickEvent) As Boolean
            Flash.Alpha = 0.9F
            Flash.FadeOut(300, Easing.OutQuart)
            If Not ClickAction Is Nothing Then
                ClickAction.Invoke
            End If
            Return MyBase.OnClick(e)
        End Function
    End Class
End Namespace
