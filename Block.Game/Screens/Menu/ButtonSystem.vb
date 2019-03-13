Imports System.Reflection
Imports osu.Framework
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports Block.Game.Rules

Namespace Screens.Menu
    Public Class ButtonSystem : Inherits Container(Of ButtonGroup)
        Public Page As New Bindable(Of ButtonGroup)

        Public Sub New()
            AddRange(New List(Of ButtonGroup) From {
                New ButtonGroup(New List(Of MenuButton)) From {
                    New MenuButton("play", "lets begin our <Play>"),
                    New MenuButton("exit", "leaving so soon?")
                },
                New ButtonGroup(New List(Of MenuButton)) From {
                    New MenuButton("solo", "you're alone on this"),
                    New MenuButton("multi", "play with others")
                }
            })

            Dim ruleButtons As New List(Of MenuButton)
            For Each Rule As GameRule In GetGameRules()
                ruleButtons.Add(New MenuButton(Rule.Name.ToLower(), Rule.Description, Sub()
                                                                                      End Sub,
                                               String.Format("mode-{0}", Rule.Name.ToLower().Replace(" ", String.Empty))))
            Next

            Add(New ButtonGroup(ruleButtons))

            RelativeSizeAxes = Axes.X
            AutoSizeAxes = Axes.Y
            Anchor = Anchor.Centre
            Origin = Anchor.Centre
            Y = 100

            AddHandler Page.ValueChanged, AddressOf HandlePageChange
        End Sub

        Public Overrides Sub Add(page As ButtonGroup)
            If Children.Count > 0 Then
                page.Add(New MenuButton("back", ""))
                page.State = ButtonGroupState.Backward
            End If

            MyBase.Add(page)
        End Sub

        Private Sub HandlePageChange(ByVal page As ValueChangedEvent(Of ButtonGroup))
            page.OldValue.State = ButtonGroupState.Forward
            page.NewValue.State = ButtonGroupState.Visible
        End Sub

        Private Function GetGameRules() As List(Of GameRule)
            Dim rules As New List(Of GameRule)
            Dim found = Assembly.GetExecutingAssembly().GetTypes().Where(Function(t) String.Equals(t.Namespace, "Block.Game.Rules", StringComparison.Ordinal))
            For Each instance In found
                If instance.IsSubclassOf(GetType(GameRule)) Then
                    rules.Add(CType(Activator.CreateInstance(instance), GameRule))
                End If
            Next
            Return rules
        End Function
    End Class
End Namespace
