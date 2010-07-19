Imports RolePlayingSystem.Character.Ability
Imports RolePlayingSystem.Common.Types

Namespace Character.Skills

    ''' <summary>
    ''' Represents a single skill for a character or creature.
    ''' </summary>
    <Serializable()> _
    Public Class Skill

#Region "Literals"

        Private _Level As Integer = 1

        Private _Ability As AbilityScore

        Private _Trained As Boolean = False

        Private _Penalty As Integer = 0

        Private _Misc As New GenericBonusCollection

        Private _Name As String = Nothing

#End Region

#Region "Properties"

        ''' <summary>
        ''' Represents current creatures level.
        ''' </summary>
        Friend WriteOnly Property Level As Integer
            Set(ByVal value As Integer)
                _Level = value
            End Set
        End Property

        ''' <summary>
        ''' Represents the associated ability bonus for skill.
        ''' </summary>
        Public ReadOnly Property Ability As AbilityScore
            Get
                Return _Ability
            End Get
        End Property

        ''' <summary>
        ''' Indicates if this skill is trained.
        ''' </summary>
        Public ReadOnly Property Trained As Boolean
            Get
                Return _Trained
            End Get
        End Property

        ''' <summary>
        ''' Contains any armor penalties (if applicable) to this skill.
        ''' </summary>
        Public ReadOnly Property Penalty As Integer
            Get
                Return _Penalty
            End Get
        End Property

        ''' <summary>
        ''' Un-categorized bonuses for this skill.
        ''' </summary>
        Public Property Misc As GenericBonusCollection
            Set(ByVal value As GenericBonusCollection)
                _Misc = value
            End Set
            Get
                Return _Misc
            End Get
        End Property

        ''' <summary>
        ''' Name of skill.
        ''' </summary>
        Public ReadOnly Property Name As String
            Get
                Return _Name
            End Get
        End Property

        ''' <summary>
        ''' Represents final tallied skill bonus.
        ''' </summary>
        Public ReadOnly Property Bonus As Integer
            Get
                Return (Misc.Sum() + ((Ability.ModifierPlus) + IIf(Trained, 5, 0) + Penalty))
            End Get
        End Property

#End Region

#Region "Events"

        ''' <summary>
        ''' Instantiates a new instance of a skill.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(ByVal SkillName As String, _
                       ByRef Ability As AbilityScore, _
                       ByVal Trained As Boolean, _
                       ByVal Penalty As Integer, _
                       ByVal Misc As GenericBonusCollection)

            'Set values.
            _Name = SkillName
            _Ability = Ability
            _Trained = Trained
            _Penalty = Penalty
            _Misc = Misc
        End Sub

#End Region

    End Class

End Namespace
