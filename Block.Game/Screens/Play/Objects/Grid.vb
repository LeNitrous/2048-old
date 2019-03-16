Imports osuTK

Namespace Screens.Play.Objects
    Public Class Grid
        Public RNG As New Random
        Public Size As Integer
        Public Cells As Tile(,)
        Public Event TileAdded(tile As Tile)
        Public Event TileRemoved(tile As Tile)

        Public Sub New(s As Integer, Optional previousState As Tile(,) = Nothing)
            Size = s
            Cells = If(Not previousState Is Nothing, previousState, Empty())
        End Sub

        Public Function Empty() As Tile(,)
            ReDim Cells(Size, Size)
            Return Cells
        End Function

        Public Function GetRandomAvailableCell() As Vector2
            Dim cells = GetAvailableCells()
            If cells.Count Then
                Return cells.ElementAt(RNG.Next(cells.Count))
            End If
        End Function

        Public Function GetAvailableCells() As List(Of Vector2)
            Dim empty As New List(Of Vector2)
            EachCell(Sub(pos, cell)
                         If cell Is Nothing Then
                             empty.Add(pos)
                         End If
                     End Sub)
            Return empty
        End Function

        Public Function CellsAvailable() As Boolean
            Return Not GetAvailableCells().Count = 0
        End Function

        Public Function CellIsAvailable(cell As Vector2) As Boolean
            Return Not CellIsOccupied(cell)
        End Function

        Public Function CellIsOccupied(cell As Vector2) As Boolean
            Return Not CellContent(cell) Is Nothing
        End Function

        Public Function CellContent(cell As Vector2) As Tile
            If WithinBounds(cell) Then
                Return Cells(cell.X, cell.Y)
            Else
                Return Nothing
            End If
        End Function

        Public Function WithinBounds(cell As Vector2) As Boolean
            Return cell.X >= 0 And cell.X < Size And
                   cell.Y >= 0 And cell.Y < Size
        End Function

        Public Sub EachCell(callback As Action(Of Vector2, Tile))
            For row = 0 To Size - 1
                For col = 0 To Size - 1
                    callback.Invoke(New Vector2(row, col), Cells(row, col))
                Next
            Next
        End Sub

        Public Sub InsertTile(tile As Tile)
            Dim tilePos = tile.Position.Value
            If CellIsOccupied(tilePos) Then
                RemoveTile(tile)
            End If
            Cells(tilePos.X, tilePos.Y) = tile
            RaiseEvent TileAdded(tile)
        End Sub

        Public Sub RemoveTile(tile As Tile)
            Dim tilePos = tile.Position.Value
            Cells(tilePos.X, tilePos.Y) = Nothing
            RaiseEvent TileRemoved(tile)
        End Sub
    End Class
End Namespace
