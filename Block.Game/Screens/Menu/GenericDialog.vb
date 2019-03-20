Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports Block.Game.Overlays

Namespace Screens.Menu
    Public Class GenericDialog : Inherits DialogPrompt
        Public Property Message As String
            Get
                Dim sprite As SpriteText = BodyContent.Child
                Return sprite.Text
            End Get
            Set(value As String)
                Dim sprite As SpriteText = BodyContent.Child
                sprite.Text = value
            End Set
        End Property

        Public Sub New()
            Title = "information"
            Icon = "menu"
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            BodyContent.Child = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Text = "",
                .Font = New FontUsage("ClearSans", 28)
            }
            AddButton("close", Sub() State = Visibility.Hidden)
        End Sub
    End Class
End Namespace
