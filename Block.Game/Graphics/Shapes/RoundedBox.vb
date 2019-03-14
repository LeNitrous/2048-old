Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osuTK.Graphics

Namespace Graphics.Shapes
    Public Class RoundedBox : Inherits CompositeDrawable
        Public Property BackgroundColour As Color4
            Get
                Return InnerBox.Colour
            End Get
            Set(value As Color4)
                InnerBox.Colour = value
            End Set
        End Property
        Private InnerBox As Box

        Public Sub New()
            InnerBox = New Box With {.RelativeSizeAxes = Axes.Both}
            InternalChild = New Container With {
                .RelativeSizeAxes = Axes.Both,
                .Masking = True,
                .CornerRadius = 5,
                .Child = InnerBox
            }
        End Sub
    End Class
End Namespace
