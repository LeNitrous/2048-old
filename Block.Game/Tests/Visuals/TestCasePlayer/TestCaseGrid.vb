Imports osu.Framework.Allocation
Imports osu.Framework.Input.Events
Imports osu.Framework.Testing
Imports osuTK
Imports Block.Game.Objects
Imports Block.Game.Objects.Drawables

Namespace Tests.Visuals.TestCasePlayer
    Public Class TestCaseGrid : Inherits TestCase
        Public Manager As New Manager(4)

        Public Sub New()
            Add(New DrawableGrid(Manager.Grid))
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Manager.AddStartTiles()
        End Sub

        Protected Overrides Function OnKeyDown(e As KeyDownEvent) As Boolean
            Manager.HandleInput(e)
            Return MyBase.OnKeyDown(e)
        End Function
    End Class
End Namespace
