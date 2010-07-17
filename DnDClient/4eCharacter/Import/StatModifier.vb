Namespace Import

    ''' <summary>
    ''' Contains a conditional modifier for a stat block.
    ''' </summary>
    Public Class StatModifier

#Region "Literals"

        Private _Type As String = Nothing

        Private _Value As String = Nothing

        Private _Level As Integer = 1

        Private _CharElem As String = Nothing

        Private _StatName As String = Nothing

        Private _StatLink As Stat = New Stat(Nothing, Nothing, Nothing)

        Private _StatModifier As Boolean = False

        Private _Rule As Rule = Nothing

#End Region

#Region "Properties"

        ''' <summary>
        ''' Specifies type of stat modifier.
        ''' </summary>
        Public ReadOnly Property Type As String
            Get
                Return _Type
            End Get
        End Property

        ''' <summary>
        ''' Specifies value of stat modifier.
        ''' </summary>
        ''' <remarks>May always be 1 or 0 to indicate if the modifier is active.</remarks>
        Public ReadOnly Property Value As String
            Get
                Return _Value
            End Get
        End Property

        ''' <summary>
        ''' Indicates level of stat modifier.
        ''' </summary>
        Public ReadOnly Property Level As Integer
            Get
                Return _Level
            End Get
        End Property

        ''' <summary>
        ''' A reference to the supporting rules element.
        ''' </summary>
        Public ReadOnly Property CharElem As String
            Get
                Return _CharElem
            End Get
        End Property

        ''' <summary>
        ''' Contains name of stat linked to this modifier.
        ''' </summary>
        Public ReadOnly Property StatName As String
            Get
                Return _StatName
            End Get
        End Property

        ''' <summary>
        ''' Indicates if this modifier is tied to a specific ability score.
        ''' </summary>
        Public ReadOnly Property StatLink As Stat
            Get
                Return _StatLink
            End Get
        End Property

        ''' <summary>
        ''' Value of modifier, if indicated.
        ''' </summary>
        Public ReadOnly Property StatModifier As Boolean
            Get
                Return _StatModifier
            End Get
        End Property

        ''' <summary>
        ''' Gets associated rule element for specified stat.
        ''' </summary>
        ''' <returns>Rule element class.</returns>
        ''' <remarks>Returns nothing, if supporting rule cannot be found.</remarks>
        Public ReadOnly Property Rule As Rule
            Get
                Return _Rule
            End Get
        End Property

#End Region

#Region "Events"

        Public Sub New(ByVal Type As String, _
                       ByVal Level As Integer, _
                       ByVal Value As String, _
                       ByVal CharElem As String, _
                       ByVal StatName As String, _
                       ByVal StatLink As Stat, _
                       ByVal StatModifier As Boolean, _
                       ByVal Rule As Rule)

            'Assign values to private literals.
            _Type = Type
            _Level = Level
            _Value = Value
            _CharElem = CharElem
            _StatName = StatName
            _StatLink = StatLink
            _StatModifier = StatModifier
            _Rule = Rule
        End Sub

#End Region

    End Class

End Namespace