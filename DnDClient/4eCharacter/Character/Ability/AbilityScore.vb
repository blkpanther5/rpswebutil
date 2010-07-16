Namespace Character.Ability

    ''' <summary>
    ''' Represents a generic ability score and modifiers.
    ''' </summary>
    <Serializable()> _
    Public Class AbilityScore

#Region "Literals"

        ''' <summary>
        ''' Private use integer representing character level.
        ''' </summary>
        Private _Level As Integer = 1

#End Region

#Region "Properties"

        ''' <summary>
        ''' Represents current creatures level.
        ''' </summary>
        Friend WriteOnly Property Level As Integer
            Set(ByVal value As Integer)
                _Level = value
            End Set
        End Property

#End Region

#Region "Properties"

        ''' <summary>
        ''' Final tallied creature ability score.
        ''' </summary>
        Public Property Score As Integer

        ''' <summary>
        ''' Returns calculated modifer for ability score.
        ''' </summary>
        Public ReadOnly Property Modifier As Integer
            Get
                Return Math.Floor(Score - 10) / 2
            End Get
        End Property

        ''' <summary>
        ''' Returns calculated modifier for ability score plus half level.
        ''' </summary>
        Public ReadOnly Property ModifierPlus As Integer
            Get
                Return Math.Floor(_Level / 2) + Modifier
            End Get
        End Property

#End Region

    End Class

End Namespace
