Imports osu.Framework.Bindables
Imports osu.Framework.Input.Events
Imports osuTK
Imports osuTK.Input
Imports Block.Core.Objects

Namespace Objects
    Public Class Manager

        Public ReadOnly Score As New BindableInt
        Public ReadOnly Moves As New BindableInt
        Public Grid As Grid
        Public ShouldAddRandomTile As Boolean = True
        Public Event GameWin()
        Public Event GameOver()

        Public Sub New(ByVal size As Integer)
            Grid = New Grid(size)
        End Sub

        Public Sub AddRandomTile()
            If Grid.GetAvailableCells().Count Then
                Dim value = If(Grid.RNG.NextDouble() < 0.9, 2, 4)
                Dim tile = New Tile(value, Grid.GetRandomAvailableCell())
                Grid.InsertTile(tile)
            End If
        End Sub

        Public Sub Move(ByVal direction As MoveDirection)
            Dim vector = GetMoveVector(direction)
            Dim traversals = BuildTraversals(vector)
            Dim moved = False

            PrepareTiles()

            traversals.X.ForEach(Sub(x)
                                     traversals.Y.ForEach(Sub(y)
                                                              Dim cell = New Vector2(x, y)
                                                              Dim tile = Grid.CellContent(cell)

                                                              If tile IsNot Nothing Then
                                                                  Dim positions = FindFarthestPosition(cell, vector)
                                                                  Dim nextTile = Grid.CellContent(positions.NextCell)

                                                                  If nextTile IsNot Nothing Then
                                                                      If nextTile = tile And nextTile.From Is Nothing Then
                                                                          Dim merged = New Tile(CInt(tile), positions.NextCell) With {
                                                                              .From = New List(Of Tile)({tile, nextTile})
                                                                          }
                                                                          Grid.InsertTile(merged)
                                                                          Grid.RemoveTile(tile)
                                                                          merged.Increment()
                                                                          tile.UpdatePosition(positions.NextCell, True)
                                                                          nextTile.UpdatePosition(positions.NextCell, True)

                                                                          Score.Set(Score.Value + CInt(merged))
                                                                          If CInt(merged) = 2048 Then
                                                                              RaiseEvent GameWin()
                                                                          End If
                                                                      Else
                                                                          MoveTile(tile, positions.Farthest)
                                                                      End If
                                                                  Else
                                                                      MoveTile(tile, positions.Farthest)
                                                                  End If

                                                                  If Not PositionsEqual(cell, tile.Position.Value) Then
                                                                      moved = True
                                                                  End If
                                                              End If
                                                          End Sub)
                                 End Sub)
            If moved Then
                Moves.Set(Moves.Value + 1)
                If ShouldAddRandomTile Then
                    AddRandomTile()
                End If
                If Not MovesAvailable() Then
                    RaiseEvent GameOver()
                End If
            End If
        End Sub

        Public Sub HandleInput(e As KeyDownEvent)
            Select Case e.Key
                Case Key.Up
                    Move(MoveDirection.Up)
                Case Key.Down
                    Move(MoveDirection.Down)
                Case Key.Left
                    Move(MoveDirection.Left)
                Case Key.Right
                    Move(MoveDirection.Right)
            End Select
        End Sub

        Public Sub AddStartTiles()
            For i = 0 To 1
                AddRandomTile()
            Next
        End Sub

        Private Sub MoveTile(ByRef tile As Tile, ByVal cell As Vector2)
            Dim tilePos = tile.Position.Value
            Grid.Cells(tilePos.X, tilePos.Y) = Nothing
            Grid.Cells(cell.X, cell.Y) = tile
            tile.UpdatePosition(cell)
        End Sub

        Private Sub PrepareTiles()
            Grid.EachCell(Sub(pos, tile)
                              If tile IsNot Nothing Then
                                  tile.From = Nothing
                                  tile.SavePosition()
                              End If
                          End Sub)
        End Sub

        Private Function BuildTraversals(ByVal vector As Vector2) As Traversable
            Dim traversals = New Traversable

            For pos = 0 To Grid.Size
                traversals.X.Add(pos)
                traversals.Y.Add(pos)
            Next

            If vector.X = 1 Then
                traversals.X.Reverse()
            End If

            If vector.Y = 1 Then
                traversals.Y.Reverse()
            End If

            Return traversals
        End Function

        Private Function GetMoveVector(ByVal direction As MoveDirection) As Vector2
            Select Case direction
                Case MoveDirection.Up
                    Return New Vector2(0, -1)
                Case MoveDirection.Right
                    Return New Vector2(1, 0)
                Case MoveDirection.Down
                    Return New Vector2(0, 1)
                Case MoveDirection.Left
                    Return New Vector2(-1, 0)
                Case Else
                    Throw New ArgumentOutOfRangeException
            End Select
        End Function

        Private Function FindFarthestPosition(ByVal cell As Vector2, ByVal vector As Vector2) As FarthestPosition
            Dim previous As Vector2

            Do
                previous = cell
                cell = New Vector2(previous.X + vector.X, previous.Y + vector.Y)
            Loop While Grid.WithinBounds(cell) And Grid.CellIsAvailable(cell)

            Return New FarthestPosition(previous, cell)
        End Function

        Private Function MovesAvailable() As Boolean
            Return Grid.CellsAvailable() Or TileMatchesAvailable()
        End Function

        Private Function TileMatchesAvailable() As Boolean
            Dim tile As Tile
            For x = 0 To Grid.Size
                For y = 0 To Grid.Size
                    tile = Grid.CellContent(New Vector2(x, y))

                    If tile IsNot Nothing Then
                        For Each direction In System.Enum.GetValues(GetType(MoveDirection))
                            Dim vector = GetMoveVector(direction)
                            Dim cell = New Vector2(x + vector.X, y + vector.Y)
                            Dim other = Grid.CellContent(cell)
                            If other IsNot Nothing Then
                                If other = tile Then
                                    Return True
                                End If
                            End If
                        Next
                    End If
                Next
            Next
            Return False
        End Function

        Private Function PositionsEqual(ByVal first As Vector2, ByVal second As Vector2) As Boolean
            Return first.X = second.X And first.Y = second.Y
        End Function

        Private Class Traversable
            Public X As New List(Of Integer)
            Public Y As New List(Of Integer)
        End Class

        Private Class FarthestPosition
            Public Farthest As Vector2
            Public NextCell As Vector2

            Public Sub New(ByVal previous As Vector2, cell As Vector2)
                Farthest = previous
                NextCell = cell
            End Sub
        End Class
    End Class

    Public Enum MoveDirection
        Up
        Right
        Down
        Left
    End Enum
End Namespace
