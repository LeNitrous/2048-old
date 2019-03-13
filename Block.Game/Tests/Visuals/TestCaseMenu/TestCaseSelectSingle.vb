Imports osu.Framework.Allocation
Imports osu.Framework.Testing
Imports Block.Game.Graphics.UserInterface

Namespace Tests.Visuals.TestCaseMenu
    Public Class TestCaseSelectSingle : Inherits TestCase
        <BackgroundDependencyLoader>
        Private Sub Load()
            Dim sel = New SelectSingle
            sel.AddItem("Numero Uno", 1)
            sel.AddItem("Numero Dos", 2)
            sel.AddItem("Hello Compadre", 12)
            Add(sel)
        End Sub
    End Class
End Namespace
