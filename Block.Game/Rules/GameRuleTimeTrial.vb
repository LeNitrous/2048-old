Namespace Rules
    Public Class GameRuleTimeTrial : Inherits GameRule
        Public Overrides ReadOnly Property ID As Integer = 2
        Public Overrides ReadOnly Property Name As String = "Time Trial"
        Public Overrides ReadOnly Property Description As String = "play as fast as you can"
        Public Overrides ReadOnly Property ShowTimer As Boolean = False
        Public Overrides ReadOnly Property ShowMoves As Boolean = False
        Public Overrides ReadOnly Property ShowScore As Boolean = True

        Public Overrides Function NewRecordCondition() As Boolean
            Return False
        End Function
    End Class
End Namespace
