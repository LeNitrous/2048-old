Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osuTK
Imports osuTK.Graphics
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes
Imports osu.Framework.Input.Events

Namespace Screens.Menu
    Public Class MenuButton : Inherits ClickableContainer
        Private ReadOnly Title As String
        Private ReadOnly Subtitle As String
        Private ReadOnly ClickAction As Action

        Private TitleSprite As SpriteText
        Private SubtitleSprite As SpriteText
        Private Overlay As RoundedBox

        Public Sub New(ByVal title As String, Optional ByVal subtitle As String = "", Optional ByVal action As Action = Nothing)
            Me.Title = title
            Me.Subtitle = subtitle
            ClickAction = action
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour, ByVal store As TextureStore)
            Size = New Vector2(256)
            Scale = New Vector2(0.9)
            Origin = Anchor.Centre
            TitleSprite = New SpriteText With {
                .Text = Title,
                .Anchor = Anchor.BottomCentre,
                .Origin = Anchor.BottomCentre,
                .Font = New FontUsage("ClearSans", 32, "Bold"),
                .Y = -24,
                .Alpha = 0
            }
            SubtitleSprite = New SpriteText With {
                .Text = Subtitle,
                .Anchor = Anchor.BottomCentre,
                .Origin = Anchor.BottomCentre,
                .Font = New FontUsage("ClearSans", 16),
                .Y = -6,
                .Alpha = 0
            }
            Overlay = New RoundedBox With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .RelativeSizeAxes = Axes.Both,
                .BackgroundColour = Color4.WhiteSmoke,
                .Alpha = 0
            }
            Child = New Container With {
                .RelativeSizeAxes = Axes.Both,
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Children = New List(Of Drawable) From {
                    New RoundedBox With {
                        .Anchor = Anchor.Centre,
                        .Origin = Anchor.Centre,
                        .RelativeSizeAxes = Axes.Both,
                        .BackgroundColour = colour.FromHex("8f7a66")
                    },
                    New Sprite With {
                        .Size = New Vector2(125),
                        .Anchor = Anchor.Centre,
                        .Origin = Anchor.Centre,
                        .Texture = store.Get(String.Format("Interface/icon-{0}", Title)),
                        .FillMode = FillMode.Fill,
                        .FillAspectRatio = 1.0F
                    },
                    TitleSprite,
                    SubtitleSprite,
                    Overlay
                }
            }
        End Sub

        Protected Overrides Function OnHover(e As HoverEvent) As Boolean
            ScaleTo(1, 500, Easing.OutElastic)
            TitleSprite.Alpha = 1.0F
            SubtitleSprite.Alpha = 1.0F
            Return MyBase.OnHover(e)
        End Function

        Protected Overrides Sub OnHoverLost(e As HoverLostEvent)
            ScaleTo(0.9, 500, Easing.OutQuart)
            TitleSprite.FadeOut(100)
            SubtitleSprite.FadeOut(100)
            MyBase.OnHoverLost(e)
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
