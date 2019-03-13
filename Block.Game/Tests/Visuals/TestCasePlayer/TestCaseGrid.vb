Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Input.Bindings
Imports osu.Framework.Testing
Imports Block.Game.Objects.Managers
Imports Block.Game.Objects.Drawables

Namespace Tests.Visuals.TestCasePlayer
    Public Class TestCaseGrid : Inherits TestCase : Implements IKeyBindingHandler(Of MoveDirection)
        Public Manager As New GridManager(4)

        Public Sub New()
            Add(New GridInputContainer With {
                .RelativeSizeAxes = Axes.None,
                .AutoSizeAxes = Axes.Both,
                .Child = New DrawableGrid(Manager)
            })
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Manager.AddStartTiles()
        End Sub

        Public Function OnPressed(action As MoveDirection) As Boolean Implements IKeyBindingHandler(Of MoveDirection).OnPressed
            Manager.Move(action)
            Return True
        End Function

        Public Function OnReleased(action As MoveDirection) As Boolean Implements IKeyBindingHandler(Of MoveDirection).OnReleased
            Return True
        End Function
    End Class
End Namespace
