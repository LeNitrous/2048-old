Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osuTK.Graphics

Namespace Graphics.Shapes
    Public Class RoundedBox : Inherits Container
        Public Shadows Property Colour As Color4
            Get
                Return Child.Colour
            End Get
            Set(value As Color4)
                Child.Colour = value
            End Set
        End Property

        Public Sub New()
            Masking = True
            CornerRadius = 5
            Child = New Box With {.RelativeSizeAxes = Axes.Both}
        End Sub
    End Class
End Namespace
