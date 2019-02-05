Imports System.Reflection
Imports osu.Framework
Imports osu.Framework.Allocation
Imports osu.Framework.IO.Stores
Imports Block.Core.Graphics

Public Class BlockGame
    Inherits Game

    Private Dependencies As DependencyContainer

    Protected Overrides Function CreateChildDependencies(parent As IReadOnlyDependencyContainer) As IReadOnlyDependencyContainer
        Dependencies = New DependencyContainer(MyBase.CreateChildDependencies(parent))
        Return Dependencies
    End Function

    <BackgroundDependencyLoader>
    Private Sub Load()
        Resources.AddStore(New NamespacedResourceStore(Of Byte())(New DllResourceStore(Assembly.GetExecutingAssembly().Location), "Resources"))

        Fonts = New FontStore(New GlyphStore(Resources, "Fonts/ClearSans-Regular"))
        Dependencies.Cache(Fonts)
        Dependencies.Cache(New BlockColor())

        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Bold"))
        Fonts.AddStore(New GlyphStore(Resources, "Fonts/ClearSans-Light"))
    End Sub
End Class
