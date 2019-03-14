Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Testing
Imports Block.Game.Screens.Menu

Namespace Tests.Visuals.TestCaseMenu
    Public Class TestCaseMainMenuSelect : Inherits TestCase
        <BackgroundDependencyLoader>
        Private Sub Load()
            Add(New RuleSelector With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre
            })
        End Sub
    End Class
End Namespace
