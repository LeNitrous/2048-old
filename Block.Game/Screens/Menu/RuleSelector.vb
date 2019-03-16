Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osu.Framework.Input.Events
Imports Block.Game.Bindables
Imports Block.Game.Graphics
Imports Block.Game.Graphics.UserInterface
Imports Block.Game.Rules
Imports osuTK
Imports osuTK.Graphics

Namespace Screens.Menu
    Public Class RuleSelector : Inherits Container
        Public SelectRule As Action(Of GameRule)
        Private SelectedRuleId As WrappingBindableInt
        Private RuleSelected As SelectorSelectButton
        Private RuleNameSprite As SpriteText
        Private RuleDescSprite As SpriteText
        Private RuleIconSprite As Sprite

        <Resolved>
        Private Property Store As TextureStore

        <Resolved>
        Private Property Colours As Colours

        <Resolved>
        Private Property Rules As List(Of GameRule)

        <BackgroundDependencyLoader>
        Private Sub Load()
            Size = New Vector2(600, 200)
            RuleNameSprite = New SpriteText With {
                .Anchor = Anchor.BottomCentre,
                .Origin = Anchor.BottomCentre,
                .Colour = Colours.DarkestBrown,
                .Font = New FontUsage("ClearSans", 36, "Bold"),
                .Y = 40
            }
            RuleDescSprite = New SpriteText With {
                .Anchor = Anchor.BottomCentre,
                .Origin = Anchor.BottomCentre,
                .Colour = Colours.DarkestBrown,
                .Alpha = 0.8,
                .Font = New FontUsage("ClearSans", 20),
                .Y = 54
            }
            RuleIconSprite = New Sprite With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .Size = New Vector2(120)
            }
            RuleSelected = New SelectorSelectButton(AddressOf OnSelectRule) With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre
            }
            Children = New List(Of Drawable) From {
                New SelectorChangeButton(Sub() SelectedRuleId.Add(-1)) With {
                    .Facing = FacingDirection.Backward,
                    .Anchor = Anchor.CentreLeft,
                    .Origin = Anchor.CentreLeft
                },
                RuleSelected,
                New SelectorChangeButton(Sub() SelectedRuleId.Add(1)) With {
                    .Facing = FacingDirection.Forward,
                    .Anchor = Anchor.CentreRight,
                    .Origin = Anchor.CentreRight
                },
                RuleIconSprite,
                RuleNameSprite,
                RuleDescSprite
            }
            SelectedRuleId = New WrappingBindableInt With {
                .MinValue = 0,
                .MaxValue = Rules.Count - 1
            }
            AddHandler RuleSelected.CurrentRule.ValueChanged, AddressOf OnChangeRule
            AddHandler SelectedRuleId.ValueChanged, AddressOf OnChangeSelectedId
            RuleSelected.CurrentRule.Value = Rules.FirstOrDefault()
        End Sub

        Public Function GetSelectedRule() As GameRule
            Return If(Rules.ElementAtOrDefault(SelectedRuleId.Value), 0)
        End Function

        Private Sub OnChangeRule(ByVal rule As ValueChangedEvent(Of GameRule))
            RuleIconSprite.ClearTransforms()
            RuleIconSprite.Texture = Store.Get("Interface/mode-" & rule.NewValue.Name.ToLower().Replace(" ", String.Empty))
            RuleIconSprite.Scale = New Vector2(0.8)
            RuleIconSprite.ScaleTo(Vector2.One, 1000, Easing.OutElastic)
            RuleNameSprite.Text = rule.NewValue.Name.ToUpper()
            RuleDescSprite.Text = rule.NewValue.Description.ToLower()
        End Sub

        Private Sub OnChangeSelectedId(ByVal value As ValueChangedEvent(Of Integer))
            RuleSelected.CurrentRule.Value = If(Rules.ElementAtOrDefault(value.NewValue), 0)
        End Sub

        Private Sub OnSelectRule()
            If Not SelectRule Is Nothing Then
                SelectRule.Invoke(RuleSelected.CurrentRule.Value)
            End If
        End Sub

        Private Class SelectorSelectButton : Inherits MenuButton
            Public CurrentRule As Bindable(Of GameRule)

            Public Sub New(Optional ByVal onClick As Action = Nothing)
                MyBase.New("", onClick)
            End Sub

            <BackgroundDependencyLoader>
            Private Sub Load(ByVal colours As Colours)
                CurrentRule = New Bindable(Of GameRule)
                Size = New Vector2(140)
            End Sub
        End Class

        Private Class SelectorChangeButton : Inherits ClickableContainer
            Public Facing As FacingDirection = FacingDirection.Forward
            Public ClickAction As Action
            Private Flash As Sprite

            <Resolved>
            Private Property Store As TextureStore

            Public Sub New(Optional ByVal onClick As Action = Nothing)
                ClickAction = onClick
            End Sub

            <BackgroundDependencyLoader>
            Private Sub Load(ByVal colours As Colours)
                Size = New Vector2(140)
                Flash = CreateSprite()
                With Flash
                    .Colour = Color4.WhiteSmoke
                    .Alpha = 0
                End With
                Dim base = CreateSprite()
                base.Colour = colours.DarkerBrown
                Children = New List(Of Drawable) From {
                    New ClickSound,
                    base,
                    Flash
                }
            End Sub

            Private Function CreateSprite() As Sprite
                Return New Sprite With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .RelativeSizeAxes = Axes.Both,
                    .Texture = store.Get("Interface/back"),
                    .Rotation = If(Facing = FacingDirection.Forward, 180.0F, 0)
                }
            End Function

            Protected Overrides Function OnClick(e As ClickEvent) As Boolean
                Flash.ClearTransforms()
                Flash.Alpha = 0.9
                Flash.FadeOut(300, Easing.OutQuart)
                If Not ClickAction Is Nothing Then
                    ClickAction.Invoke()
                End If
                Return MyBase.OnClick(e)
            End Function
        End Class

        Public Enum FacingDirection
            Backward
            Forward
        End Enum
    End Class
End Namespace
