Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Input.Events
Imports osuTK
Imports Block.Core.Graphics.Shapes

Namespace Graphics.UserInterface
    Public Class BlockButton
        Inherits ClickableContainer

        Private Background As BeveledBox
        Private SpriteText As SpriteText
        Protected Text As String

        Public Sub New(ByVal t As String)
            RelativeSizeAxes = Axes.X
            Height = 40
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(color As BlockColor)
            SpriteText = CreateText()
            Background = New BeveledBox(color.FromHex("8f7a66"), color.FromHex("6c5c4d")) With {
                .RelativeSizeAxes = Axes.Both
            }

            InternalChildren = New List(Of Drawable)({
                Background,
                SpriteText
            })
        End Sub

        Protected Overrides Function OnMouseDown(e As MouseDownEvent) As Boolean
            Background.Background.MoveToOffset(New Vector2(0, 11))
            Return MyBase.OnMouseDown(e)
        End Function

        Protected Overrides Function OnMouseUp(e As MouseUpEvent) As Boolean
            Background.Background.MoveToOffset(New Vector2(0, -11))
            Return MyBase.OnMouseUp(e)
        End Function

        Protected Overridable Function CreateText() As SpriteText
            Return New SpriteText With {
                .Depth = -1,
                .Origin = Anchor.Centre,
                .Anchor = Anchor.Centre
            }
        End Function
    End Class
End Namespace
