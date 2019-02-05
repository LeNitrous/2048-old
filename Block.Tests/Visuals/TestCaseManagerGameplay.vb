Imports osu.Framework.Allocation
Imports osu.Framework.Input.Events

Namespace Visuals
    <ComponentModel.Description("full gameplay")>
    Public Class TestCaseManagerGameplay
        Inherits TestCaseManager

        <BackgroundDependencyLoader>
        Private Sub Load()
            Manager.AddStartTiles()

            AddHandler Manager.GameWin, AddressOf OnWin
            AddHandler Manager.GameOver, AddressOf OnLose
        End Sub

        Protected Overrides Function OnKeyDown(e As KeyDownEvent) As Boolean
            Manager.HandleInput(e)
            Return MyBase.OnKeyDown(e)
        End Function

        Private Sub OnWin()
            Console.WriteLine("YOU WIN")
        End Sub

        Private Sub OnLose()
            Console.WriteLine("YOU LOSE")
        End Sub
    End Class
End Namespace
