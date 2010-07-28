Namespace Powers

    ''' <summary>
    ''' Represents a creature's power or ability.
    ''' </summary>
    <Serializable()> _
    Public Class Power

#Region "Literals"

        Private _Name As String = Nothing

        Private _Action As String = Nothing

        Private _Level As Integer = 1

        Private _Used As Boolean = False

        Private _Description As String = Nothing

        Private _AttackBreakdown As String = Nothing

        Private _DamageBreakdown As String = Nothing

        Private _Notes As String = Nothing

#End Region

#Region "Properties"

        ''' <summary>
        ''' Name of power
        ''' </summary>
        Public ReadOnly Property Name As String
            Get
                Return _Name
            End Get
        End Property

        ''' <summary>
        ''' Action required for using power.
        ''' </summary>
        Public ReadOnly Property Action As String
            Get
                Return _Action
            End Get
        End Property

        ''' <summary>
        ''' Level of power.
        ''' </summary>
        Public ReadOnly Property Level As Integer
            Get
                Return _Level
            End Get
        End Property

        ''' <summary>
        ''' Indicates if power has been used.
        ''' </summary>
        Public Property Used As String
            Get
                Return _Used
            End Get
            Set(ByVal value As String)
                _Used = value
            End Set
        End Property

        ''' <summary>
        ''' Contains HTML description of power.
        ''' </summary>
        Public ReadOnly Property Description As String
            Get
                Return _Description
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

        ''' <summary>
        ''' User defined notes.
        ''' </summary>
        Public Property Notes As String
            Get
                Return _Notes
            End Get
            Set(ByVal value As String)
                _Notes = value
            End Set
        End Property

#End Region

#Region "Events"

        ''' <summary>
        ''' Creates instance of object.
        ''' </summary>
        ''' <param name="Name">Name of power.</param>
        ''' <param name="Action">Action required to use power.</param>
        ''' <param name="Level">Level of power.</param>
        ''' <param name="AttackBreakdown">Breakdown of attack bonus.</param>
        ''' <param name="DamageBreakdown">Breakdown of damage.</param>
        ''' <param name="Description">HTML description of power.</param>
        Public Sub New(ByVal Name As String, _
                       ByVal Action As String, _
                       ByVal Level As Integer, _
                       ByVal AttackBreakdown As String, _
                       ByVal DamageBreakdown As String, _
                       Optional ByVal Description As String = Nothing)

            'Create object.
            _Name = Name
            _Action = Action
            _Level = Level
            _AttackBreakdown = AttackBreakdown
            _DamageBreakdown = DamageBreakdown
            _Description = Description
        End Sub

#End Region

    End Class

End Namespace
