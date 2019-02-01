Imports osu.Framework
Imports osu.Framework.Platform

Module Program
    Sub Main(args As String())
        Using game As Game = New VisualTest
            Using gameHost As GameHost = Host.GetSuitableHost("2048.Tests")
                gameHost.Run(game)
            End Using
        End Using
    End Sub
End Module
