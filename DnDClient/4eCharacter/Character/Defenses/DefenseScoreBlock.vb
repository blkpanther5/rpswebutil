Namespace Character.Defense

    ''' <summary>
    ''' Represents a generic defense score for a creature.
    ''' </summary>
    <Serializable()> _
    Public Class DefenseScoreBlock

#Region "Properties"

        ''' <summary>
        ''' Represents creature level for purpose of calculating ability score modifiers.
        ''' </summary>
        Friend WriteOnly Property Level As Integer
            Set(ByVal value As Integer)
                AC.Level = value
                Fortitude.Level = value
                Reflex.Level = value
                Will.Level = value
            End Set
        End Property

        ''' <summary>
        ''' Armor class of creature.
        ''' </summary>
        Public Property AC As New DefenseScore

        ''' <summary>
        ''' Fortitude defense of creature.
        ''' </summary>
        Public Property Fortitude As New DefenseScore

        ''' <summary>
        ''' Reflex defense of creature.
        ''' </summary>
        Public Property Reflex As New DefenseScore

        ''' <summary>
        ''' Will defense of creature.
        ''' </summary>
        Public Property Will As New DefenseScore

#End Region

    End Class

End Namespace
