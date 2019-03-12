Namespace Rules
    Public Class GameRuleEndless : Inherits GameRule
        Public Overrides ReadOnly Property ID As Integer = 1
        Public Overrides ReadOnly Property Name As String = "Endless"
        Public Overrides ReadOnly Property Description As String = "there is no end"
        Public Overrides ReadOnly Property ShowTimer As Boolean = False
        Public Overrides ReadOnly Property ShowMoves As Boolean = True
        Public Overrides ReadOnly Property ShowScore As Boolean = True

        Public Overrides Function NewRecordCondition() As Boolean
            Return False
        End Function
    End Class
End Namespace
