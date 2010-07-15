Imports RolePlayingSystem.Common.Types
Imports RolePlayingSystem.Common.Skills

Namespace Common.Skills

    ''' <summary>
    ''' Represents all of the skills that are associated to a character.
    ''' </summary>
    <Serializable()> _
    Public Class SkillCollection

#Region "Properties"

        ''' <summary>
        ''' A collection of all characters skills.
        ''' </summary>
        ''' <remarks></remarks>
        Public Items As Generic.List(Of Skill)

#End Region

    End Class

End Namespace
