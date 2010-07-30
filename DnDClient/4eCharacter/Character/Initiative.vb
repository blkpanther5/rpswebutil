Imports RolePlayingSystem.Common.Types
Imports RolePlayingSystem.Character.Ability

Namespace Character

    ''' <summary>
    ''' Represents initiative scores for creature.
    ''' </summary>
    <Serializable()> _
    Public Class Initiative

#Region "Literals"

        Private _Ability As AbilityScore = Nothing

        Private _Misc As New GenericBonusCollection

#End Region

#Region "Properties"

        ''' <summary>
        ''' Reference to governing ability score.
        ''' </summary>
        Public Property Ability As AbilityScore
            Get
                Return _Ability
            End Get
            Set(ByVal value As AbilityScore)
                _Ability = value
            End Set
        End Property

        ''' <summary>
        ''' Any additional modifiers.
        ''' </summary>
        Public Property Misc As GenericBonusCollection
            Get
                Return _Misc
            End Get
            Set(ByVal value As GenericBonusCollection)
                _Misc = value
            End Set
        End Property

        ''' <summary>
        ''' Final tallied initiative.
        ''' </summary>
        Public ReadOnly Property Score As Integer
            Get
                Return Ability.ModifierPlus + Misc.Sum()
            End Get
        End Property

#End Region

    End Class

End Namespace