Namespace Common.Types

    ''' <summary>
    ''' Collection of generic name/value pair representing bonuses.
    ''' </summary>
    <Serializable()> _
    Public Class GenericBonusCollection
        Inherits Generic.List(Of GenericBonus)

        ''' <summary>
        ''' Returns the sum of all bonuses in collection.
        ''' </summary>
        Public Function Sum() As Integer
            If Me.Count <= 0 Then _
                Return Nothing

            Return Me.Sum(Function(Bonus) _
                                   Bonus.Bonus)
        End Function

    End Class

    ''' <summary>
    ''' Generic name/value pair representing bonuses.
    ''' </summary>
    <Serializable()> _
    Public Class GenericBonus

        ''' <summary>
        ''' Name of untyped bonus.
        ''' </summary>
        Public Name As String = Nothing

        ''' <summary>
        ''' Numeric value of untyped bonus.
        ''' </summary>
        Public Bonus As Integer = 0

        ''' <summary>
        ''' Creates an instance of bonus.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal BonusName As String, _
                       ByVal BonusValue As Integer)

            Name = BonusName
            Bonus = BonusValue
        End Sub

    End Class
End Namespace