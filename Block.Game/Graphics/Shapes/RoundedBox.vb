Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osuTK.Graphics

Namespace Graphics.Shapes
    Public Class RoundedBox : Inherits Container
        Public Property BackgroundColour As Color4
            Get
                Return Background.Colour
            End Get
            Set(value As Color4)
                Background.Colour = value
            End Set
        End Property
        Private Background As Box

        Public Sub New()
            Masking = True
            CornerRadius = 5
            Background = New Box With {.RelativeSizeAxes = Axes.Both}
            InternalChild = Background
        End Sub
    End Class
End Namespace
