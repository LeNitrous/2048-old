Imports osu.Framework
Imports osu.Framework.Platform
Imports Block.Game.Tests

Module Program
    Sub Main(args As String())
#If Tests Then
        Using game As osu.Framework.Game = New Tests
            Using gameHost As GameHost = Host.GetSuitableHost("2048-tests")
                gameHost.Run(game)
            End Using
        End Using
#Else
        Using game As osu.Framework.Game = New Game.Game
            Using gameHost As GameHost = Host.GetSuitableHost("2048")
                gameHost.Run(game)
            End Using
        End Using
#End If
    End Sub
End Module
