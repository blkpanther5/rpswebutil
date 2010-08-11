Imports RolePlayingSystem.Common.Types
Imports RolePlayingSystem.Common.Utility
Imports RolePlayingSystem.Character.Ability
Imports RolePlayingSystem.Character.Defense
Imports RolePlayingSystem.Character.Movement
Imports RolePlayingSystem.Character.Skills
Imports RolePlayingSystem.Character.Powers

Namespace Character

    ''' <summary>
    ''' This class represents a 4th Edition Dungeons and Dragons character.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class Base

#Region "Literals"

        ''' <summary>
        ''' Internal use literal represeting character level.
        ''' </summary>
        ''' <remarks></remarks>
        Private _Level As Integer = 1

#End Region

#Region "Properties"

        ''' <summary>
        ''' Level of character.
        ''' </summary>
        Public Property Level As Integer
            Get
                Return _Level
            End Get
            Set(ByVal value As Integer)
                'Initialize level for all necessary classes.
                _Level = value
                AbilityScores.Level = _Level
                Defenses.Level = _Level
            End Set
        End Property

        ''' <summary>
        ''' Name of character.
        ''' </summary>
        Public Property Name As String

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
        ''' Represents characters maximum hit points.
        ''' </summary>
        Public Property HitPoints As Integer

        ''' <summary>
        ''' Characters current hit points.
        ''' </summary>
        Public Property CurrentHitPoints As Integer

        ''' <summary>
        ''' Represents characters maximum surges.
        ''' </summary>
        Public Property Surges As Integer

        ''' <summary>
        ''' Characters current surges left.
        ''' </summary>
        Public Property CurrentSurges As Integer

        ''' <summary>
        ''' Value surge heals.
        ''' </summary>
        Public Property SurgeValue As Integer

        ''' <summary>
        ''' Represents if the character has used his/her second wind ability.
        ''' </summary>
        Public Property SecondWindUsed As Boolean

        ''' <summary>
        ''' Represents a creatures initiative values.
        ''' </summary>
        Public Property Initiative As New Initiative

        ''' <summary>
        ''' Represents characters ability scores and modifiers.
        ''' </summary>
        Public Property AbilityScores As New AbilityScoreBlock

        ''' <summary>
        ''' Defense scores of creature.
        ''' </summary>
        Public Property Defenses As New DefenseScoreBlock

        ''' <summary>
        ''' Represents creatures movement scores.
        ''' </summary>
        Public Property Movement As New MovementBlock

        ''' <summary>
        ''' Represents the skill collection of the creature/character.
        ''' </summary>
        Public Property Skills As New SkillCollection

        ''' <summary>
        ''' Represents all usable powers for creature/character.
        ''' </summary>
        Public Property Powers As New PowerCollection

        Public Property RaceFeatures As New List(Of GenericNVP)

        Public Property ClassFeatures As New List(Of GenericNVP)

        'Public Property Feats As New SortedSet(Of GenericNVP)
#End Region

    End Class

End Namespace
