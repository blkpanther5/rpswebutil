Imports RolePlayingSystem.Common.Types
Imports RolePlayingSystem.Character.Skills

Namespace Character.Skills

    ''' <summary>
    ''' Represents all of the skills that are associated to a character.
    ''' </summary>
    <Serializable()> _
    Public Class SkillCollection
        Inherits Generic.List(Of Skill)

#Region "Properties"

        ''' <summary>
        ''' Represents creature level for purpose of calculating ability score modifiers.
        ''' </summary>
        ''' <value></value>
        ''' <remarks></remarks>
        Friend WriteOnly Property Level As Integer
            Set(ByVal value As Integer)

            End Set
        End Property

#End Region

    End Class

End Namespace
