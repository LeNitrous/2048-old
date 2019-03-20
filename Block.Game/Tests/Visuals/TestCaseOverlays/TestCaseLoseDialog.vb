Imports osu.Framework.Allocation
Imports Block.Game.Screens.Play

Namespace Tests.Visuals.TestCaseOverlays
    Public Class TestCaseLoseDialog : Inherits TestCaseDialogBox
        <BackgroundDependencyLoader>
        Private Sub Load()
            Dialog = New LoseDialog
        End Sub
    End Class
End Namespace
