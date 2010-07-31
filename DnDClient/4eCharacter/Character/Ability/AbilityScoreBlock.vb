Namespace Character.Ability

    ''' <summary>
    ''' Represents a creatures ability scores and modifiers.
    ''' </summary>
    <Serializable()> _
    Public Class AbilityScoreBlock

#Region "Properties"

        ''' <summary>
        ''' Represents creature level for purpose of calculating ability score modifiers.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Friend WriteOnly Property Level As Integer
            Set(ByVal value As Integer)
                Strength.Level = value
                Constitution.Level = value
                Dexterity.Level = value
                Intelligence.Level = value
                Wisdom.Level = value
                Charisma.Level = value
            End Set
        End Property

        ''' <summary>
        ''' Represents a creatures stength score.
        ''' </summary>
        Public Property Strength As New AbilityScore

        ''' <summary>
        ''' Represents a creatures constitution score.
        ''' </summary>
        Public Property Constitution As New AbilityScore

        ''' <summary>
        ''' Represents a creatures dexterity score.
        ''' </summary>
        Public Property Dexterity As New AbilityScore

        ''' <summary>
        ''' Represents a creatures intelligence score.
        ''' </summary>
        Public Property Intelligence As New AbilityScore

        ''' <summary>
        ''' Represents a creatures wisdom score.
        ''' </summary>
        Public Property Wisdom As New AbilityScore

        ''' <summary>
        ''' Represents a creatures charisma score.
        ''' </summary>
        Public Property Charisma As New AbilityScore

#End Region

#Region "Methods"

        ''' <summary>
        ''' Allows return of appropriate ability score by text name (or 3 char abbreviation).
        ''' </summary>
        ''' <param name="Name">Name or abbreviation of ability.</param>
        ''' <returns>Ability Score reference.</returns>
        Public Function getAbilityByName(ByVal Name As String) As AbilityScore
            Select Case Name.ToLower()
                Case "strength", "str"
                    Return Me.Strength

                Case "dexterity", "dex"
                    Return Me.Dexterity

                Case "constitution", "con"
                    Return Me.Constitution

                Case "intelligence", "int"
                    Return Me.Intelligence

                Case "wisdom", "wis"
                    Return Me.Wisdom

                Case "charisma", "cha"
                    Return Me.Charisma

                Case Else
                    Return Nothing
            End Select
        End Function

#End Region

    End Class

End Namespace
