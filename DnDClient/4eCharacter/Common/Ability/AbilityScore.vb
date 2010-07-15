Namespace Common.Ability

    ''' <summary>
    ''' Represents a generic ability score and modifiers.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class AbilityScore

#Region "Literals"

        ''' <summary>
        ''' Represents current creatures level.
        ''' </summary>
        Private _Level As Integer = 0

        ''' <summary>
        ''' Represents current ability score.
        ''' </summary>
        ''' <remarks></remarks>
        Private _Score As Integer = 0

#End Region

#Region "Properties"

        ''' <summary>
        ''' Final tallied creature ability score.
        ''' </summary>
        Public ReadOnly Property Score As Integer
            Get
                Return _Score
            End Get
        End Property

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

#Region "Events"

        ''' <summary>
        ''' Initializes base values for ability score.
        ''' </summary>
        ''' <param name="Level">Character level.</param>
        Public Sub New(ByVal Level As Integer, _
                       ByVal Score As Integer)
            'Save level to private literal.
            _Level = Level

            'Set ability score.
            _Score = Score
        End Sub

#End Region

    End Class

End Namespace
