﻿Imports RolePlayingSystem.Character.Ability
Imports RolePlayingSystem.Common.Types

Namespace Character.Defense

    ''' <summary>
    ''' Represents a generic defense score and modifiers.
    ''' </summary>
    ''' <remarks></remarks>
    <Serializable()> _
    Public Class DefenseScore

#Region "Literals"

        ''' <summary>
        ''' Represents current creatures level.
        ''' </summary>
        Private _Level As Integer = 1

        ''' <summary>
        ''' Represents a creatures base defense score.
        ''' </summary>
        Private _BaseScore As Integer = 10

        ''' <summary>
        ''' Represents armor bonus to defense score.
        ''' </summary>
        Private _Armor As Integer = 0

        ''' <summary>
        ''' Represents ability modifier to defense score.
        ''' </summary>
        Private _Ability As AbilityScore = Nothing

        ''' <summary>
        ''' Represents class modifier to defense score.
        ''' </summary>
        Private _Class As Integer = 0

        ''' <summary>
        ''' Represents feat modifier to defense score.
        ''' </summary>
        Private _Feat As Integer = 0

        ''' <summary>
        ''' Represents armor/item bonus to defense score.
        ''' </summary>
        Private _Enhancement As Integer = 0

        ''' <summary>
        ''' Misc defense bonuses.
        ''' </summary>
        Private _Misc As New GenericBonusCollection

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
        ''' Bonus granted by armor.
        ''' </summary>
        Public Property Armor As Integer
            Get
                Return _Armor
            End Get
            Set(ByVal value As Integer)
                _Armor = value
            End Set
        End Property

        ''' <summary>
        ''' Bonus granted by realted ability.
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
        ''' Bonus granted by class.
        ''' </summary>
        Public Property ClassBonus As Integer
            Get
                Return _Class
            End Get
            Set(ByVal value As Integer)
                _Class = value
            End Set
        End Property

        ''' <summary>
        ''' Bonus granted by feats.
        ''' </summary>
        Public Property Feat As Integer
            Get
                Return _Feat
            End Get
            Set(ByVal value As Integer)
                _Feat = value
            End Set
        End Property

        ''' <summary>
        ''' Bonus granted by item enhancements.
        ''' </summary>
        Public Property Enhancement As Integer
            Get
                Return _Enhancement
            End Get
            Set(ByVal value As Integer)
                _Enhancement = value
            End Set
        End Property

        ''' <summary>
        ''' Additional bonuses.
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
        ''' Final tallied creature ability score.
        ''' </summary>
        Public ReadOnly Property Score As Integer
            Get
                Return _BaseScore + Ability.ModifierPlus + Armor + ClassBonus + Feat + Enhancement + Misc.Sum()
            End Get
        End Property

#End Region

    End Class
End Namespace
