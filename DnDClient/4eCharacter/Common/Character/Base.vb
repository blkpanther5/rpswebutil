Imports RolePlayingSystem.Common.Utility
Imports RolePlayingSystem.Common.Ability
Imports RolePlayingSystem.Common.Defense
Imports RolePlayingSystem.Common.Movement
Imports RolePlayingSystem.Common.Skills

Namespace Common.Character

    ''' <summary>
    ''' This class represents a 4th Edition Dungeons and Dragons character.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class Base

#Region "Properties"

        ''' <summary>
        ''' Name of character.
        ''' </summary>
        Public Property Name As String

        ''' <summary>
        ''' Level of character.
        ''' </summary>
        Public Property Level As Integer

        ''' <summary>
        ''' Class of character.
        ''' </summary>
        Public Property CharacterClass As String

        ''' <summary>
        ''' Race of character.
        ''' </summary>
        Public Property CharacterRace As String

        ''' <summary>
        ''' Size class of character.
        ''' </summary>
        Public Property Size As SizeClass

        ''' <summary>
        ''' Gender of character.
        ''' </summary>
        Public Property Gender As Gender

        ''' <summary>
        ''' Selected Paragon Path of character.
        ''' </summary>
        Public Property ParagonPath As String

        ''' <summary>
        ''' Selected Epic Destiny of character.
        ''' </summary>
        Public Property EpicDestiny As String

        ''' <summary>
        ''' Alignment of character.
        ''' </summary>
        Public Property Alignment As Alignment

        ''' <summary>
        ''' Deity of character.
        ''' </summary>
        Public Property Deity As String

        ''' <summary>
        ''' Height of character.
        ''' </summary>
        Public Property Height As String

        ''' <summary>
        ''' Weight of character.
        ''' </summary>
        Public Property Weight As String

        ''' <summary>
        ''' Name of player who owns this character.
        ''' </summary>
        Public Property PlayerName As String

        ''' <summary>
        ''' Name of current character's adventure.
        ''' </summary>
        Public Property AdventureName As String

        ''' <summary>
        ''' Represents characters ability scores and modifiers.
        ''' </summary>
        Public Property AbilityScores As AbilityScoreBlock

        ''' <summary>
        ''' Defense scores of creature.
        ''' </summary>
        Public Property Defenses As DefenseScoreBlock

        ''' <summary>
        ''' Represents creatures movement scores.
        ''' </summary>
        Public Property Movement As MovementBlock

        Public Property Skills As SkillCollection
#End Region

    End Class

End Namespace
