Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.UserInterface
Imports osu.Framework.Input.Events
Imports osuTK

Namespace Graphics.UserInterface
    Public Class BlockButton
        Inherits Button

        Private hover As Box

        Public Sub New(ByVal t As String)
            RelativeSizeAxes = Axes.X
            Height = 40
            Text = t
            Margin = New MarginPadding With {
                .Bottom = 5
            }

            Content.Masking = True
            Content.CornerRadius = 3
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(color As BlockColor)
            hover = New Box With {
                .RelativeSizeAxes = Axes.Both,
                .Blending = BlendingMode.Additive,
                .Alpha = 0,
                .Depth = -1
            }
            AddRange(New List(Of Drawable)({hover}))
            BackgroundColour = color.RipeBrown
        End Sub

        Protected Overrides Function OnHover(e As HoverEvent) As Boolean
            hover.FadeTo(0.25, 200)
            Return MyBase.OnHover(e)
        End Function

        Protected Overrides Sub OnHoverLost(e As HoverLostEvent)
            hover.FadeOut(200)
            MyBase.OnHoverLost(e)
        End Sub

        Protected Overrides Function OnMouseDown(e As MouseDownEvent) As Boolean
            Content.ScaleTo(New Vector2(0.9), 500, Easing.OutCubic)
            Return MyBase.OnMouseDown(e)
        End Function

        Protected Overrides Function OnMouseUp(e As MouseUpEvent) As Boolean
            Content.ScaleTo(New Vector2(1), 500, Easing.OutElastic)
            Return MyBase.OnMouseUp(e)
        End Function

        Protected Overrides Function CreateText() As SpriteText
            Return New SpriteText With {
                .Depth = -1,
                .Origin = Anchor.Centre,
                .Anchor = Anchor.Centre
            }
        End Function
    End Class
End Namespace
