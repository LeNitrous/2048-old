Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.UserInterface
Imports osu.Framework.Input.Events
Imports osuTK

Namespace Graphics.UserInterface
    Public Class BlockButton
        Inherits ClickableContainer

        Private BackgroundContainer As Container
        Private Background As Box = CreateFillBox()
        Private Backdrop As Box = CreateFillBox()
        Private SpriteText As SpriteText
        Protected Text As String

        Public Sub New(ByVal t As String)
            RelativeSizeAxes = Axes.X
            Height = 40

            SpriteText = CreateText()
            BackgroundContainer = New Container With {
                .RelativeSizeAxes = Axes.Both,
                .CornerRadius = 5,
                .Masking = True,
                .Children = New List(Of Drawable)({
                    Background,
                    SpriteText
                })
            }
            InternalChild = New Container With {
                .RelativeSizeAxes = Axes.Both,
                .Children = New List(Of Drawable)({
                    New Container With {
                        .Anchor = Anchor.BottomLeft,
                        .RelativeSizeAxes = Axes.X,
                        .CornerRadius = 5,
                        .Masking = True,
                        .Height = 20,
                        .Y = -11,
                        .Child = Backdrop
                    },
                    BackgroundContainer
                })
            }
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(color As BlockColor)
            Background.Colour = color.FromHex("8f7a66")
            Backdrop.Colour = color.FromHex("6c5c4d")
        End Sub

        Protected Function CreateFillBox() As Box
            Return New Box With {
                .RelativeSizeAxes = Axes.Both
            }
        End Function

        Protected Overrides Function OnMouseDown(e As MouseDownEvent) As Boolean
            BackgroundContainer.MoveToOffset(New Vector2(0, 11))
            Return MyBase.OnMouseDown(e)
        End Function

        Protected Overrides Function OnMouseUp(e As MouseUpEvent) As Boolean
            BackgroundContainer.MoveToOffset(New Vector2(0, -11))
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
