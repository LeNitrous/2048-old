Imports ProtoBuf

Namespace Online.Models
    <ProtoContract>
    Public Class UserAttempt
        <ProtoMember(1)>
        Public userId As Integer
        <ProtoMember(2)>
        Public ruleId As Integer
        <ProtoMember(3)>
        Public score As Integer
        <ProtoMember(4)>
        Public moves As Integer
        <ProtoMember(5)>
        Public elapsed As Integer
    End Class
End Namespace
