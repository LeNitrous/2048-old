﻿Imports osu.Framework
Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Cursor
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Testing
Imports osu.Framework.Platform
Imports Block.Core.Graphics

Public Class VisualTest
    Inherits Game

    Private Dependencies As DependencyContainer

    Protected Overrides Function CreateChildDependencies(parent As IReadOnlyDependencyContainer) As IReadOnlyDependencyContainer
        Dependencies = New DependencyContainer(MyBase.CreateChildDependencies(parent))
        Return Dependencies
    End Function

    <BackgroundDependencyLoader>
    Private Sub Load()
        Dependencies.Cache(New BlockColor)

        Child = New DrawSizePreservingFillContainer With {
            .Children = New List(Of Drawable)({
                New TestBrowser("Block"),
                New CursorContainer()
            })
        }
    End Sub

    Public Overrides Sub SetHost(host As GameHost)
        MyBase.SetHost(host)
        host.Window.CursorState = host.Window.CursorState Or CursorState.Hidden
    End Sub
End Class
