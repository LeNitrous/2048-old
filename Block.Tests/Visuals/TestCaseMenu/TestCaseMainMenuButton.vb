﻿Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Testing
Imports Block.Core.Screens.Menu

Namespace Visuals.TestCaseMenu
    Public Class TestCaseMainMenuButton
        Inherits TestCase

        <BackgroundDependencyLoader>
        Private Sub Load()
            Add(New MenuButton("play", "some classic 2048") With {.Anchor = Anchor.Centre})
        End Sub
    End Class
End Namespace