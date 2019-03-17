Imports osu.Framework.Allocation
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers

Namespace Overlays
    Public Class Overlay : Inherits FocusedOverlayContainer
        <Resolved>
        Private Property Game As Game

        Public Sub New()
            AddHandler StateChanged, AddressOf OnStateChange
        End Sub

        Protected Sub OnStateChange(state As Visibility)
            Select Case state
                Case Visibility.Visible
                    Game.AddOverlay(Me)
                Case Visibility.Hidden
                    Game.RemoveOverlay(Me)
            End Select
        End Sub
    End Class
End Namespace
