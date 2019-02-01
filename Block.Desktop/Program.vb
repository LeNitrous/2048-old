Imports osu.Framework
Imports osu.Framework.Platform
Imports Block.Core

Module Program
    Sub Main(args As String())
        Using game As Game = New BlockGame
            Using gameHost As GameHost = Host.GetSuitableHost("2048")
                gameHost.Run(game)
            End Using
        End Using
    End Sub
End Module
