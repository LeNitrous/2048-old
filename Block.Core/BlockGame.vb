Imports osu.Framework
Imports osu.Framework.Allocation
Imports osu.Framework.IO.Stores
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Sprites
Imports Block.Core.Graphics

Public Class BlockGame
    Inherits Game

    Private Shadows Dependencies As DependencyContainer

    Protected Overrides Function CreateChildDependencies(parent As IReadOnlyDependencyContainer) As IReadOnlyDependencyContainer
        Dependencies = New DependencyContainer(MyBase.CreateChildDependencies(parent))
        Return Dependencies
    End Function

    <BackgroundDependencyLoader>
    Private Sub Load()
        Resources.AddStore(New DllResourceStore("Block.Core.Resources.dll"))

        Dependencies.Cache(New BlockColour())
    End Sub
End Class
