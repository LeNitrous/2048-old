Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Testing
Imports osuTK
Imports Block.Game.Screens.Menu

Namespace Tests.Visuals.TestCaseMenu
    Public Class TestCaseMainMenuButtonSystem : Inherits TestCase
        <BackgroundDependencyLoader>
        Private Sub Load()
            Dim buttonSystem = New ButtonSystem
            Dim prevPageText = New SpriteText
            Dim nextPageText = New SpriteText With {.Position = New Vector2(0, 20)}
            Add(buttonSystem)

            AddHandler buttonSystem.Page.ValueChanged, Sub(page As ValueChangedEvent(Of ButtonGroup))
                                                           prevPageText.Text = "Previous Page: " + page.OldValue.ID
                                                           nextPageText.Text = "This Page: " + page.NewValue.ID
                                                       End Sub
        End Sub
    End Class
End Namespace
