Imports RolePlayingSystem.Common.Types
Imports RolePlayingSystem.Character.Skills

Namespace Character.Skills

    ''' <summary>
    ''' Represents all of the skills that are associated to a character.
    ''' </summary>
    <Serializable()> _
    Public Class SkillCollection
        Inherits Generic.List(Of Skill)

    End Class

End Namespace
