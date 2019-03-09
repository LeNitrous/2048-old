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
        Resources.AddStore(New DllResourceStore("Block.Sokething.dll"))

        Dependencies.Cache(New BlockColour())

        Add(New Sprite With {
            .Size = New osuTK.Vector2(125),
            .Anchor = Anchor.Centre,
            .Origin = Anchor.Centre,
            .FillMode = FillMode.Fill,
            .Texture = Textures.Get("Interface/icon-exit")
        })
    End Sub
End Class
