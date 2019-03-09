Imports System.Net.Http

Namespace Online.API
    Public Class API
        Public Uri As String = ""
        Public Iv As String = "itsukakotori"
        Public Key As String = "kotoriitsuka"

        Private ReadOnly Client As HttpClient

        Public Sub New()
            Client = New HttpClient
        End Sub
    End Class
End Namespace
