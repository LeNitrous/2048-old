Imports osu.Framework
Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.IO.Stores
Imports osu.Framework.Screens
Imports Block.Core.Graphics
Imports Block.Core.Screens.Menu

Public Class BlockGame
    Inherits Game

    Private Dependencies As DependencyContainer

    Protected Overrides Function CreateChildDependencies(parent As IReadOnlyDependencyContainer) As IReadOnlyDependencyContainer
        Dependencies = New DependencyContainer(MyBase.CreateChildDependencies(parent))
        Return Dependencies
    End Function

    <BackgroundDependencyLoader>
    Private Sub Load()
        Resources.AddStore(New DllResourceStore("Block.Resources.dll"))

        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Bold"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-BoldItalic"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Italic"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Light"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Medium"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-MediumItalic"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Regular"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Thin"))
        Dependencies.Cache(New BlockColor())

        Add(New ScreenStack(New MainMenu) With {
            .RelativeSizeAxes = Axes.Both
        })
    End Sub
End Class
