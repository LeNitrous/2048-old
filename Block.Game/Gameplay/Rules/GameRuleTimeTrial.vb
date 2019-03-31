Imports Block.Game.Online.Models
Imports LiteDB

Namespace Gameplay.Rules
    Public Class GameRuleTimeTrial : Inherits GameRule : Implements IHasCountdown, IHasLeaderboard
        Public Overrides ReadOnly Property ID As Integer = 2
        Public Overrides ReadOnly Property Name As String = "Time Trial"
        Public Overrides ReadOnly Property Description As String = "play as fast as you can"
        Public Overrides ReadOnly Property HasTimer As Boolean = True
        Public Overrides ReadOnly Property HasMoves As Boolean = False
        Public Overrides ReadOnly Property HasScore As Boolean = False
        Public Overrides ReadOnly Property AllowUndo As Boolean = False

        Public ReadOnly Property CountdownLength As Single Implements IHasCountdown.CountdownLength
            Get
                Return 3000
            End Get
        End Property

        Public Function GetNewLeadCondition(attempts As LiteCollection(Of UserAttempt), attempt As UserAttempt) As Boolean Implements IHasLeaderboard.GetNewLeadCondition
            Dim top = attempts.Find(Query.EQ("ruleId", 2)).ToList().OrderBy(Function(a) a.elapsed).FirstOrDefault()
            Return If(top IsNot Nothing, top.elapsed < attempt.elapsed, True)
        End Function
    End Class
End Namespace
