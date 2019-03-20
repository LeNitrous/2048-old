Imports ProtoBuf

Namespace Online.Models
    <ProtoContract>
    Public Class User
        <ProtoMember(1)>
        Public userId As Integer
        <ProtoMember(2)>
        Public name As String
        <ProtoMember(3)>
        Public password As String
    End Class
End Namespace
