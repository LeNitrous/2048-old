Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.IO.Stores
Imports osu.Framework.Screens
Imports Block.Game.Graphics
Imports Block.Game.Online.API
Imports Block.Game.Screens.Play

Public Class BlockGame
    Inherits osu.Framework.Game

    Public Stack As ScreenStack

    Private Shadows Dependencies As DependencyContainer

    Protected Overrides Function CreateChildDependencies(parent As IReadOnlyDependencyContainer) As IReadOnlyDependencyContainer
        Dependencies = New DependencyContainer(MyBase.CreateChildDependencies(parent))
        Return Dependencies
    End Function

    Public Sub New()
        Name = "lazer2048"
    End Sub

    <BackgroundDependencyLoader>
    Private Sub Load()
        Resources.AddStore(New DllResourceStore("Block.Game.Resources.dll"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Bold"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Italic"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Medium"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-MediumItalic"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Thin"))

        Dependencies.Cache(New API)
        Dependencies.Cache(New BlockColour())

        Stack = New ScreenStack With {
            .RelativeSizeAxes = Axes.Both
        }
        Stack.Push(New Player(PlayType.Classic, 4))
        Add(New DrawSizePreservingFillContainer With {
            .RelativeSizeAxes = Axes.Both,
            .Child = Stack
        })
    End Sub
End Class
