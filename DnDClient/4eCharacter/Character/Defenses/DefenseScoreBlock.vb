Namespace Character.Defense

    ''' <summary>
    ''' Represents a generic defense score for a creature.
    ''' </summary>
    <Serializable()> _
    Public Class DefenseScoreBlock

#Region "Literals"

        ''' <summary>
        ''' Represents creature level for purpose of calculating ability score modifiers.
        ''' </summary>
        Friend _Level As Integer = 0

#End Region

#Region "Properties"

        ''' <summary>
        ''' Armor class of creature.
        ''' </summary>
        Public Property AC As DefenseScore

        ''' <summary>
        ''' Fortitude defense of creature.
        ''' </summary>
        Public Property Fortitude As DefenseScore

        ''' <summary>
        ''' Reflex defense of creature.
        ''' </summary>
        Public Property Reflex As DefenseScore

        ''' <summary>
        ''' Will defense of creature.
        ''' </summary>
        Public Property Will As DefenseScore

#End Region

    End Class

End Namespace
