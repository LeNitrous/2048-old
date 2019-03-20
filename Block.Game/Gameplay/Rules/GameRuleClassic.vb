Namespace Gameplay.Rules
    Public Class GameRuleClassic : Inherits GameRule
        Public Overrides ReadOnly Property ID As Integer = 0
        Public Overrides ReadOnly Property Name As String = "Classic"
        Public Overrides ReadOnly Property Description As String = "reach the 2048 tile!"
        Public Overrides ReadOnly Property HasTimer As Boolean = False
        Public Overrides ReadOnly Property HasMoves As Boolean = True
        Public Overrides ReadOnly Property HasScore As Boolean = True
        Public Overrides ReadOnly Property AllowUndo As Boolean = True
    End Class
End Namespace
