Imports System.Reflection
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Logging
Imports Block.Game.Rules

Namespace Screens.Menu
    Public Class ButtonSystem : Inherits Container(Of ButtonGroup)
        Public PrevPage As String
        Public NextPage As String = "main"

        Public Sub New()
            AddRange(New List(Of ButtonGroup) From {
                New ButtonGroup("main", New List(Of MenuButton) From {
                    New MenuButton("play", "lets begin our <Play>", Sub() GoToPage("play")),
                    New MenuButton("exit", "leaving so soon?")
                }),
                New ButtonGroup("play", New List(Of MenuButton) From {
                    New MenuButton("solo", "you're alone on this", Sub() GoToPage("solo")),
                    New MenuButton("multi", "play with others")
                }, "main")
            })

            Dim ruleButtons As New List(Of MenuButton)
            For Each Rule As GameRule In GetGameRules()
                ruleButtons.Add(New MenuButton(Rule.Name.ToLower(), Rule.Description, Sub()
                                                                                      End Sub,
                                               String.Format("mode-{0}", Rule.Name.ToLower().Replace(" ", String.Empty))))
            Next

            Add(New ButtonGroup("solo", ruleButtons, "play"))

            RelativeSizeAxes = Axes.X
            AutoSizeAxes = Axes.Y
            Anchor = Anchor.Centre
            Origin = Anchor.Centre
        End Sub

        Public Overrides Sub Add(group As ButtonGroup)
            If Children.Count > 0 Then
                group.Add(New MenuButton("back", "", Sub() GoToPage("back")))
                group.State = ButtonGroupState.Backward
            Else
                group.State = ButtonGroupState.Visible
            End If

            MyBase.Add(group)
        End Sub

        Private Sub GoToPage(ByVal page As String)
            If page = "back" Then
                Dim temp = NextPage
                NextPage = GetPageByName(NextPage).ParentId
                PrevPage = temp
            Else
                PrevPage = NextPage
                NextPage = page
            End If

            Dim old As ButtonGroup = GetPageByName(PrevPage)
            Dim now As ButtonGroup = GetPageByName(NextPage)

            old.State = If(page = "back", ButtonGroupState.Backward, ButtonGroupState.Forward)
            now.State = ButtonGroupState.Visible
        End Sub

        Private Function GetPageByName(ByVal name As String) As ButtonGroup
            Try
                Return [Single](Function(p) p.Id = name)
            Catch e As InvalidOperationException
                Logger.Log(String.Format("ButtonGroup {0} is not found.", name))
                Return Nothing
            End Try
        End Function

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
