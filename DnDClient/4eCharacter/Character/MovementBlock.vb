Imports RolePlayingSystem.Common.Types

Namespace Character.Movement

    ''' <summary>
    ''' Represents the movement scores for a creature.
    ''' </summary>
    <Serializable()> _
    Public Class MovementBlock

#Region "Properties"

        ''' <summary>
        ''' Final tallied movement speed of creature.
        ''' </summary>
        ''' <remarks>Value is in squares of movement.</remarks>
        Public ReadOnly Property Speed As Integer
            Get
                Return Base + Armor + Item + Misc.Sum()
            End Get
        End Property

        ''' <summary>
        ''' Base creature movement speed.
        ''' </summary>
        Public Property Base As Integer

        ''' <summary>
        ''' Armor penalty (or bonus) to movement speed.
        ''' </summary>
        Public Property Armor As Integer

        ''' <summary>
        ''' Enhancements to speed granted by items.
        ''' </summary>
        Public Property Item As Integer

        ''' <summary>
        ''' Miscellanious bonuses or detriments to movement speed.
        ''' </summary>
        Public Property Misc As GenericBonusCollection

#End Region

    End Class

End Namespace
