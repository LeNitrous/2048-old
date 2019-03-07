Imports osu.Framework.Bindables
Imports osuTK

Namespace Objects
    Public Class Tile

        Public ReadOnly Position As New Bindable(Of Vector2)
        Public ReadOnly Score As New BindableInt
        Public IsMerged As Boolean
        Public PreviousPosition As Vector2
        Public From As List(Of Tile)

        Public Sub New(ByVal value As Integer, ByVal pos As Vector2)
            Position.Value = pos
            Score.Value = value
        End Sub

        Public Sub New(ByVal value As Integer)
            Position.Value = New Vector2()
            Score.Value = value
        End Sub

        Public Sub Increment()
            Score.Set(Score.Value * 2)
        End Sub

        Public Sub SetValue(ByVal exp As Integer)
            Score.Set(2 ^ exp)
        End Sub

        Public Sub SavePosition()
            PreviousPosition = Position.Value
        End Sub

        Public Sub UpdatePosition(ByVal pos As Vector2, Optional ByVal merged As Boolean = False)
            Position.Value = pos
            IsMerged = merged
            Position.TriggerChange()
        End Sub

        Public Function GetProgress() As Integer
            Return Math.Log(Score.Value) / Math.Log(2)
        End Function

        Public Shared Narrowing Operator CType(ByVal tile As Tile) As Integer
            Return If(Not tile Is Nothing, tile.Score.Value, 0)
        End Operator

        Public Shared Operator =(ByVal a As Tile, ByVal b As Tile) As Boolean
            Return If(Not a Is Nothing And Not b Is Nothing, a.Score.Value = b.Score.Value, False)
        End Operator

        Public Shared Operator <>(ByVal a As Tile, ByVal b As Tile) As Boolean
            Return If(Not a Is Nothing And Not b Is Nothing, a.Score.Value = b.Score.Value, True)
        End Operator
    End Class
End Namespace
