Imports osu.Framework.Allocation
Imports osu.Framework.Input.Events

Namespace Visuals
    <ComponentModel.Description("full gameplay")>
    Public Class TestCaseManagerGameplay
        Inherits TestCaseManager

        <BackgroundDependencyLoader>
        Private Sub Load()
            Manager.AddRandomTile()
            Manager.AddRandomTile()
        End Sub

        Protected Overrides Function OnKeyDown(e As KeyDownEvent) As Boolean
            Manager.HandleInput(e)
            Return MyBase.OnKeyDown(e)
        End Function
    End Class
End Namespace
