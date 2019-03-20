Imports Block.Game.Gameplay.Managers

Namespace Gameplay.Rules
    Public Class GameRuleBlitz : Inherits GameRule : Implements IHasUpdate : Implements IHasEndCondition, IHasCountdown
        Public Overrides ReadOnly Property ID As Integer = 3
        Public Overrides ReadOnly Property Name As String = "Blitz"
        Public Overrides ReadOnly Property Description As String = "play quick!"
        Public Overrides ReadOnly Property HasTimer As Boolean = True
        Public Overrides ReadOnly Property HasMoves As Boolean = False
        Public Overrides ReadOnly Property HasScore As Boolean = False
        Public Overrides ReadOnly Property AllowUndo As Boolean = False

        Public ReadOnly Property CountdownLength As Single Implements IHasCountdown.CountdownLength
            Get
                Return 3000
            End Get
        End Property

        Private Const LENGTH As Single = 300

        Public Sub Update(ByRef manager As RuleContainer) Implements IHasUpdate.Update
            manager.Elapsed = (LENGTH * 1000) - manager.Watch.ElapsedMilliseconds()
        End Sub
    End Class
End Namespace
