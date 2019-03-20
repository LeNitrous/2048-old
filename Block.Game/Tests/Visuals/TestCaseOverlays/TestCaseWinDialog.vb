Imports osu.Framework.Allocation
Imports Block.Game.Screens.Play

Namespace Tests.Visuals.TestCaseOverlays
    Public Class TestCaseWinDialog : Inherits TestCaseDialogBox
        <BackgroundDependencyLoader>
        Private Sub Load()
            Dialog = New WinDialog
        End Sub
    End Class
End Namespace
