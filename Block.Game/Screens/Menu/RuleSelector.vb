Imports osu.Framework.Allocation
Imports osu.Framework.Bindables
Imports osu.Framework.Graphics
Imports osu.Framework.Graphics.Containers
Imports osu.Framework.Graphics.Sprites
Imports osu.Framework.Graphics.Textures
Imports osu.Framework.Input.Events
Imports Block.Game.Bindables
Imports Block.Game.Gameplay.Rules
Imports Block.Game.Graphics
Imports Block.Game.Graphics.Shapes
Imports Block.Game.Graphics.UserInterface
Imports osuTK
Imports osuTK.Graphics

Namespace Screens.Menu
    Public Class RuleSelector : Inherits Container
        Public SelectRule As Action(Of GameRule)
        Private SelectedRuleId As WrappingBindableInt
        Private RuleSelected As SelectorSelectButton
        Private RuleNameSprite As SpriteText
        Private RuleDescSprite As SpriteText

        <Resolved>
        Private Property Store As TextureStore

        <Resolved>
        Private Property Colours As Colours

        <Resolved>
        Private Property Rules As List(Of GameRule)

        <BackgroundDependencyLoader>
        Private Sub Load()
            Size = New Vector2(800, 200)
            RuleNameSprite = New SpriteText With {
                .Anchor = Anchor.BottomCentre,
                .Origin = Anchor.BottomCentre,
                .Colour = Colours.DarkestBrown,
                .Font = New FontUsage("ClearSans", 48, "Bold"),
                .Y = 90
            }
            RuleDescSprite = New SpriteText With {
                .Anchor = Anchor.BottomCentre,
                .Origin = Anchor.BottomCentre,
                .Colour = Colours.DarkestBrown,
                .Alpha = 0.8,
                .Font = New FontUsage("ClearSans", 32),
                .Y = 120
            }
            RuleSelected = New SelectorSelectButton With {
                .Anchor = Anchor.Centre,
                .Origin = Anchor.Centre,
                .ClickAction = AddressOf OnSelectRule,
                .Size = New Vector2(200)
            }
            Children = New List(Of Drawable) From {
                New TextureButton With {
                    .Icon = "back",
                    .ClickAction = Sub() SelectedRuleId.Add(-1),
                    .BaseColour = Colours.DarkerBrown,
                    .Anchor = Anchor.CentreLeft,
                    .Origin = Anchor.CentreLeft,
                    .Size = New Vector2(180)
                },
                RuleSelected,
                New TextureButton With {
                    .Icon = "back",
                    .ClickAction = Sub() SelectedRuleId.Add(1),
                    .BaseColour = Colours.DarkerBrown,
                    .Anchor = Anchor.CentreRight,
                    .Origin = Anchor.CentreRight,
                    .Size = New Vector2(180),
                    .Flipped = True
                },
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

        Private Class SelectorSelectButton : Inherits ClickableContainer
            Public CurrentRule As Bindable(Of GameRule)
            Public ClickAction As Action
            Private Flash As Container
            Private RuleIcon As Sprite

            <Resolved>
            Private Property Store As TextureStore

            <BackgroundDependencyLoader>
            Private Sub Load(ByVal colours As Colours)
                CurrentRule = New Bindable(Of GameRule)
                Flash = CreateCenterPiece(Color4.WhiteSmoke)
                Flash.Alpha = 0
                RuleIcon = New Sprite With {
                    .Anchor = Anchor.Centre,
                    .Origin = Anchor.Centre,
                    .RelativeSizeAxes = Axes.Both,
                    .Size = New Vector2(0.75)
                }
                Children = New List(Of Drawable) From {
                    New ClickSound,
                    CreateCenterPiece(colours.DarkerBrown),
                    RuleIcon,
                    Flash
                }
                AddHandler CurrentRule.ValueChanged, AddressOf OnRuleChange
            End Sub

            Private Sub OnRuleChange(rule As ValueChangedEvent(Of GameRule))
                RuleIcon.ClearTransforms()
                RuleIcon.Texture = Store.Get("Interface/mode-" & rule.NewValue.Name.ToLower().Replace(" ", String.Empty))
                RuleIcon.Scale = New Vector2(0.8)
                RuleIcon.ScaleTo(Vector2.One, 1000, Easing.OutElastic)
            End Sub

            Protected Overrides Function OnClick(e As ClickEvent) As Boolean
                Flash.ClearTransforms()
                Flash.Alpha = 0.9
                Flash.FadeOut(300, Easing.Out)
                ClickAction?.Invoke()
                Return MyBase.OnClick(e)
            End Function

            Private Function CreateCenterPiece(colour As Color4) As Container
                Return New Container With {
                    .RelativeSizeAxes = Axes.Both,
                    .Children = New List(Of Drawable) From {
                        New RoundedBox With {
                            .RelativeSizeAxes = Axes.Both,
                            .CornerRadius = 20,
                            .Colour = colour
                        },
                        New RoundedBox With {
                            .RelativeSizeAxes = Axes.Both,
                            .CornerRadius = 20,
                            .Anchor = Anchor.Centre,
                            .Origin = Anchor.Centre,
                            .Colour = colour,
                            .Rotation = 45
                        }
                    }
                }
            End Function
        End Class
    End Class
End Namespace
