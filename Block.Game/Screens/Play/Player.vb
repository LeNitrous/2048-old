Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports Block.Game.Rules
Imports Block.Game.Screens.Play.Drawables
Imports Block.Game.Screens.Play.Managers

Namespace Screens.Play
    Public Class Player : Inherits Screen
        Private ReadOnly RuleManager As RuleManager
        Private ReadOnly GridManager As GridManager

        Public Sub New(rule As GameRule, Optional size As Integer = 4)
            GridManager = New GridManager(size)
            RuleManager = New RuleManager(rule, GridManager)
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            InternalChildren = New List(Of Drawable) From {
                New DrawableGrid(GridManager) With {
                    .Area = 600,
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .Y = 50
                }
            }
        End Sub
    End Class
End Namespace
