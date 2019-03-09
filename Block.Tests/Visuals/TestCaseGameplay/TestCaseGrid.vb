Imports osu.Framework.Allocation
Imports osu.Framework.Testing
Imports Block.Core.Objects
Imports Block.Core.Objects.Drawables
Imports osu.Framework.Input.Events

Namespace Visuals.TestCaseGameplay
    Public Class TestCaseGrid
        Inherits TestCase

        Public Manager As New Manager(4)

        Public Sub New()
            Add(New DrawableGrid(Manager.Grid))
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Manager.Grid.InsertTile(New Tile(2, New osuTK.Vector2(0, 0)))
        End Sub

        Protected Overrides Function OnKeyDown(e As KeyDownEvent) As Boolean
            Manager.HandleInput(e)
            Return MyBase.OnKeyDown(e)
        End Function
    End Class
End Namespace
