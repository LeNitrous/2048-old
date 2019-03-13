Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites

Namespace Graphics.UserInterface
    Public Class SelectSingle : Inherits CompositeDrawable
        Private Selected As New BindableInt(-1)
        Private Items As New List(Of SelectItem)

        Private Display As SpriteText

        Public Sub New()
            AddHandler Selected.ValueChanged, AddressOf UpdateSelection
        End Sub

        <BackgroundDependencyLoader>
        Private Sub Load()
            Height = 40
            Display = New SpriteText With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre
            }

            Dim backButton As New ButtonIcon("back", AddressOf PrevItem)
            Dim nextButton As New ButtonIcon("back", AddressOf NextItem) With {
                .Anchor = Anchor.TopRight,
                .Origin = Anchor.TopRight
            }

            InternalChildren = New List(Of Drawable) From {
                backButton,
                Display,
                nextButton
            }

            Selected.Set(0)
        End Sub

        Public Function GetSelected() As Object
            Return Items.ElementAt(Selected.Value).Element
        End Function

        Public Function GetSelectedIndex() As Integer
            Return Selected.Value
        End Function

        Public Sub AddItem(ByVal text As String, ByVal element As Object)
            Items.Add(New SelectItem(text, element))

            Dim longest = 0
            For Each item In Items
                longest = If(item.DisplayText.Length > longest, item.DisplayText.Length, longest)
            Next
            Width = 80 + (longest * 10)

            Selected.MinValue = 0
            Selected.MaxValue = Items.Count - 1
        End Sub

        Private Sub NextItem()
            Selected.Add(1)
        End Sub

        Private Sub PrevItem()
            Selected.Add(-1)
        End Sub

        Private Sub UpdateSelection(ByVal value As ValueChangedEvent(Of Integer))
            Display.Text = Items.ElementAt(Selected.Value).DisplayText
        End Sub

        Private Class SelectItem
            Public DisplayText As String
            Public Element As Object

            Public Sub New(ByVal text As String, ByVal element As Object)
                DisplayText = text
                Me.Element = element
            End Sub
        End Class
    End Class
End Namespace
