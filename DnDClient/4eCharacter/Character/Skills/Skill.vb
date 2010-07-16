Imports RolePlayingSystem.Common.Types

Namespace Character.Skills

    ''' <summary>
    ''' Represents a single skill for a character or creature.
    ''' </summary>
    <Serializable()> _
    Public Class Skill

#Region "Literals"

        ''' <summary>
        ''' The level of creature, used in calculation of skill bonus.
        ''' </summary>
        Friend _Level As Integer = 0

#End Region

#Region "Properties"

        Public ReadOnly Property Bonus As Integer
            Get
                Return 0
            End Get
        End Property

        Public Property Name As String

        'Public Property 

#End Region

    End Class

End Namespace
