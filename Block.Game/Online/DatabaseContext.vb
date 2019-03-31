Imports Block.Game.Online.Models
Imports LiteDB

Namespace Online
    Public Class DatabaseContext
        Private ReadOnly Database As LiteDatabase
        Public Users As LiteCollection(Of User)
        Public Attempts As LiteCollection(Of UserAttempt)

        Public Sub New()
            Database = New LiteDatabase("scores.db")
            Users = Database.GetCollection(Of User)("Users")
            Attempts = Database.GetCollection(Of UserAttempt)("Attempts")
        End Sub
    End Class
End Namespace
