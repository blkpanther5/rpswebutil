Namespace Common.Ability

    ''' <summary>
    ''' Represents a creatures ability scores and modifiers.
    ''' </summary>
    <Serializable()> _
    Public Class AbilityScoreBlock

#Region "Literals"

        ''' <summary>
        ''' Represents creature level for purpose of calculating ability score modifiers.
        ''' </summary>
        Private _Level As Integer = 0

#End Region

#Region "Properties"

        ''' <summary>
        ''' Represents a creatures stength score.
        ''' </summary>
        Public Property Strength As AbilityScore

        ''' <summary>
        ''' Represents a creatures constitution score.
        ''' </summary>
        Public Property Constitution As AbilityScore

        ''' <summary>
        ''' Represents a creatures dexterity score.
        ''' </summary>
        Public Property Dexterity As AbilityScore

        ''' <summary>
        ''' Represents a creatures intelligence score.
        ''' </summary>
        Public Property Intelligence As AbilityScore

        ''' <summary>
        ''' Represents a creatures wisdom score.
        ''' </summary>
        Public Property Wisdom As AbilityScore

        ''' <summary>
        ''' Represents a creatures charisma score.
        ''' </summary>
        Public Property Charisma As AbilityScore

#End Region

#Region "Events"

        ''' <summary>
        ''' Initializes a creature ability score array.
        ''' </summary>
        Public Sub New(ByVal Level As Integer, _
                       ByVal StrengthScore As Integer, _
                       ByVal ConstitutionScore As Integer, _
                       ByVal DexterityScore As Integer, _
                       ByVal IntelligenceScore As Integer, _
                       ByVal WisdomScore As Integer, _
                       ByVal CharismaScore As Integer)

            'Generate new abilityscore objects and assign them.
            Strength = New AbilityScore(Level, StrengthScore)
            Constitution = New AbilityScore(Level, ConstitutionScore)
            Dexterity = New AbilityScore(Level, DexterityScore)
            Intelligence = New AbilityScore(Level, IntelligenceScore)
            Wisdom = New AbilityScore(Level, WisdomScore)
            Charisma = New AbilityScore(Level, CharismaScore)
        End Sub

#End Region

    End Class

End Namespace
