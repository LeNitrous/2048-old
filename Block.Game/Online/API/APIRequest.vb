Imports System.Net.Http
Imports System.Security.Cryptography

Namespace Online.API
    Public MustInherit Class APIRequest
        Public Event HandleResolvedRequest As APIHandleResolved
        Public Event HandleRejectedRequest As APIHandleRejected

        Public Delegate Sub APIHandleRejected(ByVal e As Exception)
        Public Delegate Sub APIHandleResolved()
        Public Delegate Sub APIHandleResolved(Of T)(ByVal content As T)
    End Class

    Public MustInherit Class APIRequest(Of T)
        Inherits APIRequest

        Private Sub Request()

        End Sub

        Private Function Encrypt() As Byte()
            Throw New NotImplementedException
        End Function

        Private Function Decrypt() As Byte()
            Throw New NotImplementedException
        End Function
    End Class
End Namespace
