Namespace Common.Types

    ''' <summary>
    ''' Collection of generic name/value pair representing bonuses.
    ''' </summary>
    <Serializable()> _
    Public Class GenericBonusCollection

        ''' <summary>
        ''' Collection of untyped bonuses.
        ''' </summary>
        Public Items As Generic.List(Of GenericBonus)

        ''' <summary>
        ''' Returns the sum of all bonuses in collection.
        ''' </summary>
        Public Function Sum() As Integer
            Return Items.Sum(Function(Bonus) _
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

    End Class
End Namespace