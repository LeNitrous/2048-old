﻿Imports osu.Framework.Testing
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports Block.Core.Objects
Imports Block.Core.Objects.Drawables

Namespace Visuals.TestCaseTile
    Public Class TestCaseTileColours
        Inherits TestCase

        Public FlowContainer As FillFlowContainer

        Public Sub New()
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
    End Class
End Namespace
