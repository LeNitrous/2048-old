Imports osu.Framework
Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Shapes
Imports osu.Framework.Graphics.Sprites
Imports osuTK
Imports osuTK.Graphics

Namespace Objects
    Public Class Block
        Inherits CompositeDrawable

        Public ReadOnly Value As Integer = 0
        Public ReadOnly BackgroundColor As Color4 = Color4.Black

        Private ReadOnly box As Box
        Private ReadOnly spriteText As SpriteText

        Public Sub New()
            box = New Box
            spriteText = New SpriteText
            InternalChildren = New List(Of Drawable)({
                box,
                spriteText
            })
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()

        End Sub
    End Class
End Namespace
