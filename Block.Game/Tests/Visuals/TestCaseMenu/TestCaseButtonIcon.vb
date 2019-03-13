Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Testing
Imports Block.Game.Graphics.UserInterface

Namespace Tests.Visuals.TestCaseMenu
    Public Class TestCaseButtonIcon : Inherits TestCase
        <BackgroundDependencyLoader>
        Private Sub Load()
            Add(New ButtonIcon("restart"))
        End Sub
    End Class
End Namespace
