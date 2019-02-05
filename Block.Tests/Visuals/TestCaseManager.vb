Imports osu.Framework.Testing
Imports Block.Core.Objects.Drawables
Imports Block.Core.Screens.Play

Namespace Visuals
    Public Class TestCaseManager
        Inherits TestCase

        Public ReadOnly Manager As New Manager(4)

        Public Sub New()
            Add(New DrawableGrid(Manager.Grid))
        End Sub
    End Class
End Namespace
