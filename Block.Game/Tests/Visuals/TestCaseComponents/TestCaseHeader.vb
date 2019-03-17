Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Testing
Imports Block.Game.Graphics.UserInterface

Namespace Tests.Visuals.TestCaseComponents
    Public Class TestCaseHeader : Inherits TestCase
        <BackgroundDependencyLoader>
        Private Sub Load()
            Add(New Header With {
                .Text = "Settings",
                .Icon = "settings",
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre
            })
        End Sub
    End Class
End Namespace
