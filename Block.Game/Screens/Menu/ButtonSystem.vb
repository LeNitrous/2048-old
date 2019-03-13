Imports System.Reflection
Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports Block.Game.Graphics
Imports Block.Game.Rules

Namespace Screens.Menu
    Public Class ButtonSystem : Inherits Container(Of ButtonGroup)
        Private PreviousPage As ButtonGroup
        Private CurrentPage As ButtonGroup

        Public Sub New()
            Add(New ButtonGroup("main", "", New List(Of MenuButton) From {
                New MenuButton("exit", "leaving so soon?"),
                New MenuButton("play", "lets begin our <Play>", Sub() SwitchPageTo("play"))
            }))

            Add(New ButtonGroup("play", "main", New List(Of MenuButton) From {
                New MenuButton("solo", "you're alone on this", Sub() SwitchPageTo("rules")),
                New MenuButton("multi", "play with others")
            }))

            Dim ruleButtons As New List(Of MenuButton)
            For Each Rule As Type In GetGameRules()
                If Rule.IsSubclassOf(GetType(GameRule)) Then
                    Dim gamerule = CType(Activator.CreateInstance(Rule), GameRule)
                    ruleButtons.Add(New MenuButton(gamerule.Name.ToLower(), gamerule.Description, Sub()
                                                                                                  End Sub,
                                                   String.Format("mode-{0}", gamerule.Name.ToLower().Replace(" ", String.Empty))))
                End If
            Next

            Add(New ButtonGroup("rules", "play", ruleButtons))

            RelativeSizeAxes = Axes.X
            AutoSizeAxes = Axes.Y
            Anchor = Anchor.Centre
            Origin = Anchor.Centre
            Y = 100
        End Sub

        Public Overrides Sub Add(page As ButtonGroup)
            If Children.Count > 0 Then
                page.Add(New MenuButton("back", "", Sub() MoveBack()))
                page.State = ButtonGroupState.Backward
            Else
                CurrentPage = page
                CurrentPage.State = ButtonGroupState.Visible
            End If

            MyBase.Add(page)
        End Sub

        Private Sub SwitchPageTo(ByVal pageId As String)
            PreviousPage = CurrentPage
            CurrentPage = GetPageByID(pageId)

            PreviousPage.State = ButtonGroupState.Forward
            CurrentPage.State = ButtonGroupState.Visible
        End Sub

        Private Sub MoveBack()
            Dim tempPage = CurrentPage
            CurrentPage = PreviousPage
            PreviousPage = GetPageByID(tempPage.ParentID)

            PreviousPage.State = ButtonGroupState.Backward
            CurrentPage.State = ButtonGroupState.Visible
        End Sub

        Private Function GetPageByID(ByVal pageId As String) As ButtonGroup
            Return Children.Where(Function(page) page.ID = pageId).First()
        End Function

        Private Function GetGameRules() As IEnumerable(Of Type)
            Return Assembly.GetExecutingAssembly().GetTypes().Where(Function(t) String.Equals(t.Namespace, "Block.Game.Rules", StringComparison.Ordinal))
        End Function
    End Class
End Namespace
