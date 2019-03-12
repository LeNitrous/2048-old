Imports ProtoBuf

Namespace Rules
    <ProtoContract>
    Public MustInherit Class GameRule : Implements IGameRule
        <ProtoMember(1)>
        MustOverride ReadOnly Property ID As Integer
        <ProtoMember(2)>
        MustOverride ReadOnly Property Name As String
        <ProtoMember(3)>
        MustOverride ReadOnly Property Description As String
        <ProtoMember(4)>
        MustOverride ReadOnly Property ShowTimer As Boolean
        <ProtoMember(5)>
        MustOverride ReadOnly Property ShowMoves As Boolean
        <ProtoMember(6)>
        MustOverride ReadOnly Property ShowScore As Boolean

        Public MustOverride Function NewRecordCondition() As Boolean Implements IGameRule.NewRecordCondition
    End Class
End Namespace
