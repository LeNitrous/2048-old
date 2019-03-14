Imports osu.Framework.Allocation
Imports osu.Framework.Graphics.Sprites

Namespace Graphics.Sprites
    Public Class BlockSpriteText : Inherits SpriteText
        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colours As BlockColour)
            Font = New FontUsage("ClearSans", 16)
            Colour = colours.FromHex("776e65")
        End Sub
    End Class
End Namespace
