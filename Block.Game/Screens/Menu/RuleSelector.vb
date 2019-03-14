Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports Block.Game.Graphics
Imports Block.Game.Rules

Namespace Screens.Menu
    Public Class RuleSelector

        <Resolved>
        Private Property Store As TextureStore

        <Resolved>
        Private Property Rules As GameRule

        <Resolved>
        Private Property Colours As BlockColour

        Public Sub New()

        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()

        End Sub

        Private Class SelectorSelectButton
            Public Sub New()

            End Sub
        End Class

        Private Class SelectorChangeButton
            Public Sub New()

            End Sub
        End Class
    End Class
End Namespace
