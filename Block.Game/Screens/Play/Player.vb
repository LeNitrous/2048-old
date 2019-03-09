Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports Block.Game.Graphics
Imports Block.Game.Objects
Imports Block.Game.Objects.Drawables

Namespace Screens.Play
    Public Class Player
        Inherits Screen

        Private ReadOnly GameManager As Manager
        Private ReadOnly GameType As PlayType

        Public Sub New(ByVal type As PlayType, ByVal size As Integer)
            GameManager = New Manager(size)
            GameType = type

            GameManager.AddStartTiles()
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load(ByVal colour As BlockColour)
            Content.AddRange(New List(Of Drawable) From {
                New DrawableGrid(GameManager.Grid) With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre
                }
            })
        End Sub
    End Class
End Namespace
