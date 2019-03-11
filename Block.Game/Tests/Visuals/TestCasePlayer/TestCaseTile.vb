Imports NUnit.Framework
Imports osu.Framework.Testing
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports Block.Game.Objects
Imports Block.Game.Objects.Drawables

Namespace Tests.Visuals.TestCasePlayer
    <TestFixture>
    Public Class TestCaseTile : Inherits TestCase
        Public FlowContainer As FillFlowContainer

        <Test>
        Public Sub Colours()
            FlowContainer = New FillFlowContainer With {
                .RelativeSizeAxes = Axes.Both
            }
            Add(FlowContainer)

            Dim i As Integer = 2
            While i <= 16384
                FlowContainer.Add(New DrawableTile(New Tile(i)))
                i *= 2
            End While
        End Sub

        <Test>
        Public Sub Increment()
            Dim tileObject = New Tile(2)
            Dim drawable = New DrawableTile(tileObject) With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre
            }
            Add(drawable)

            AddRepeatStep("Increment", Sub() tileObject.Increment(), 5)
            AddWaitStep(10)
            AddRepeatStep("Increment Again", Sub() tileObject.Increment(), 5)
        End Sub
    End Class
End Namespace
