Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osuTK.Graphics

Namespace Graphics.Shapes
    Public Class RoundedBox
        Inherits CompositeDrawable

        Public BackgroundColour As New Color4

        <BackgroundDependencyLoader>
        Private Sub Load()
            InternalChild = New Container With {
                .RelativeSizeAxes = Axes.Both,
                .Masking = True,
                .CornerRadius = 5,
                .Child = New Box With {
                    .RelativeSizeAxes = Axes.Both,
                    .Colour = BackgroundColour
                }
            }
        End Sub
    End Class
End Namespace
