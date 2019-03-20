Imports osuTK

Namespace Gameplay.Objects
    Public Class Grid
        Public Size As Integer
        Public Cells As Tile(,)
        Public Event TileAdded(tile As Tile)
        Public Event TileRemoved(tile As Tile)

        Public Sub New(s As Integer)
            Size = s
            ReDim Cells(Size, Size)
        End Sub

        Public Sub Empty()
            EachCell(Sub(pos, tile)
                         If tile Is Nothing Then Exit Sub
                         RemoveTile(tile)
                     End Sub)
        End Sub

        Public Sub SetGrid(toSet As Grid)
            Empty()
            toSet.EachCell(Sub(pos, tile)
                               If tile Is Nothing Then Exit Sub
                               InsertTile(tile)
                           End Sub)
            toSet.EachCell(Sub(pos, tile) Console.WriteLine("{0},{1}: {2}", pos.X, pos.Y, If(tile?.Score.Value, 0)))
        End Sub

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
