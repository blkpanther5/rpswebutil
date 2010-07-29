Imports RolePlayingSystem.Character.Ability

Namespace Character.Powers

    ''' <summary>
    ''' Represents a weapon/implement/etc usage for a power.
    ''' </summary>
    <Serializable()> _
    Public Class Usage

#Region "Literals"

        Private _Weapon As String = Nothing

        Private _Attack As String = Nothing

        Private _Damage As String = Nothing

        Private _Ability As AbilityScore

        Private _Vs As String = Nothing

        Private _AttackBreakdown As String = Nothing

        Private _DamageBreakdown As String = Nothing

#End Region

#Region "Properties"

        ''' <summary>
        ''' Name of weapon used in this instance.
        ''' </summary>
        Public ReadOnly Property Weapon As String
            Get
                Return _Weapon
            End Get
        End Property

        ''' <summary>
        ''' Total attack bonus using this weapon.
        ''' </summary>
        Public ReadOnly Property Attack As String
            Get
                Return _Attack
            End Get
        End Property

        ''' <summary>
        ''' Total damage using this weapon.
        ''' </summary>
        Public ReadOnly Property Damage As String
            Get
                Return _Damage
            End Get
        End Property

        ''' <summary>
        ''' Related ability score.
        ''' </summary>
        Public ReadOnly Property Ability As AbilityScore
            Get
                Return _Ability
            End Get
        End Property

        ''' <summary>
        ''' Score of oponent, that must be exceeded.
        ''' </summary>
        Public ReadOnly Property Vs As String
            Get
                Return _Vs
            End Get
        End Property

        ''' <summary>
        ''' Breakdown of attack bonuses.
        ''' </summary>
        Public ReadOnly Property AttackBreakdown As String
            Get
                Return _AttackBreakdown
            End Get
        End Property

        ''' <summary>
        ''' Breakdown of damage.
        ''' </summary>
        Public ReadOnly Property DamageBreakdown As String
            Get
                Return _DamageBreakdown
            End Get
        End Property

#End Region

#Region "Methods"

        ''' <summary>
        ''' Creates new instance of usage class.
        ''' </summary>
        ''' <param name="Weapon">Name of weapon used.</param>
        ''' <param name="Attack">Total attack bonus.</param>
        ''' <param name="Damage">Damage using this weapon.</param>
        ''' <param name="Ability">Related ability score.</param>
        ''' <param name="Vs">Score to beat.</param>
        ''' <param name="AttackBreakdown">Breakdown of attack bonus.</param>
        ''' <param name="DamageBreakdown">Breakdown of damage.</param>
        Public Sub New(ByVal Weapon As String, _
                       ByVal Attack As String, _
                       ByVal Damage As String, _
                       ByRef Ability As AbilityScore, _
                       ByVal Vs As String, _
                       ByVal AttackBreakdown As String, _
                       ByVal DamageBreakdown As String)

            'assign values.
            _Weapon = Weapon
            _Attack = Attack
            _Damage = Damage
            _Ability = Ability
            _Vs = Vs
            _AttackBreakdown = AttackBreakdown
            _DamageBreakdown = DamageBreakdown
        End Sub

#End Region

    End Class

End Namespace