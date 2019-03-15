Imports osu.Framework.Bindables

Namespace Bindables
    Public Class WrappingBindableInt : Inherits BindableInt
        Public Overrides Property Value As Integer
            Get
                Return MyBase.Value
            End Get
            Set(value As Integer)
                If value > MaxValue Then
                    MyBase.Value = MinValue
                ElseIf value < MinValue Then
                    MyBase.Value = MaxValue
                Else
                    MyBase.Value = value
                End If
            End Set
        End Property
    End Class
End Namespace
