Imports RolePlayingSystem.Common.Utility

Namespace Common.Character

    ''' <summary>
    ''' This class represents a 4th Edition Dungeons and Dragons character.
    ''' </summary>
    ''' <remarks></remarks>
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

#End Region

    End Class

End Namespace
