Imports osu.Framework.Allocation
Imports Block.Game.Screens.Play

Namespace Tests.Visuals.TestCaseOverlays
    Public Class TestCasePauseDialog : Inherits TestCaseDialogBox
        <BackgroundDependencyLoader>
        Private Sub Load()
            Dialog = New PauseDialog
        End Sub
    End Class
End Namespace
