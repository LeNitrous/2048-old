Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osuTK.Graphics

Namespace Graphics.Shapes
    Public Class BeveledBox
        Inherits CompositeDrawable

        Public ReadOnly Background As Container = CreateRoundedContainer()
        Private ReadOnly Backdrop As Container = CreateRoundedContainer()
        Private ReadOnly BackgroundBox As Box
        Private ReadOnly BackdropBox As Box

        Public Sub New(ByVal frontColor As Color4, ByVal backColor As Color4)
            BackgroundBox = CreateBox(frontColor)
            BackdropBox = CreateBox(backColor)
            With Backdrop
                .RelativeSizeAxes = Axes.X
                .Anchor = Anchor.BottomLeft
                .Origin = Anchor.TopLeft
                .Child = BackdropBox
                .Y = -20
                .Height = 30
            End With
            With Background
                .Child = BackgroundBox
            End With
            InternalChildren = New List(Of Drawable)({
                Backdrop,
                Background
            })
        End Sub

        Private Function CreateRoundedContainer() As Container
            Return New Container With {
                .RelativeSizeAxes = Axes.Both,
                .CornerRadius = 5,
                .Masking = True
            }
        End Function

        Private Function CreateBox(ByVal color As Color4) As Box
            Return New Box With {
                .RelativeSizeAxes = Axes.Both,
                .Colour = color
            }
        End Function
    End Class
End Namespace
