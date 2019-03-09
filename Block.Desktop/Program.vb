Imports osu.Framework
Imports osu.Framework.Platform
Imports Block.Game
Imports Block.Game.Tests

Module Program
    Sub Main(args As String())
#If TESTS Then
        Using game As osu.Framework.Game = New BlockTest
            Using gameHost As GameHost = Host.GetSuitableHost("2048-tests")
                gameHost.Run(game)
            End Using
        End Using
#Else
        Using game As osu.Framework.Game = New BlockGame
            Using gameHost As GameHost = Host.GetSuitableHost("2048")
                gameHost.Run(game)
            End Using
        End Using
#End If
    End Sub
End Module
