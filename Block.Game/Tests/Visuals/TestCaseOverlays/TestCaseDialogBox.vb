Imports osu.Framework.Allocation
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Testing
Imports Block.Game.Overlays

Namespace Tests.Visuals.TestCaseOverlays
    Public Class TestCaseDialogBox : Inherits TestCase
        Public Dialog As Dialog
        <BackgroundDependencyLoader>
        Private Sub Load()
            Dialog = New Dialog With {
                .Title = "test",
                .Icon = "menu"
            }
        End Sub

        Protected Overrides Sub LoadComplete()
            MyBase.LoadComplete()
            Add(Dialog)
            AddStep("open", Sub() Dialog.State = Visibility.Visible)
            AddStep("close", Sub() Dialog.State = Visibility.Hidden)
            AddStep("toggle", Sub() Dialog.ToggleVisibility())
        End Sub
    End Class
End Namespace
