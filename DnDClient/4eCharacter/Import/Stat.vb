Namespace Import

    ''' <summary>
    ''' Represents a stat element from character XML file.
    ''' </summary>
    Public Class Stat

#Region "Literals"

        Private _Name As String = Nothing

        Private _AlternateNames As String() = Nothing

        Private _Value As Integer = 0

        Private _StatElement As XElement = Nothing

        Private _StatModifiers As Generic.List(Of StatModifier)

#End Region

#Region "Properties"

        ''' <summary>
        ''' Contains primary name for stat.
        ''' </summary>
        ''' <returns>Name value for stat.</returns>
        Public ReadOnly Property Name As String
            Get
                Return _Name
            End Get
        End Property

        ''' <summary>
        ''' Contains any alternate names for stat (ie. str for strength, etc).
        ''' </summary>
        ''' <returns>Array of string alternate name values.</returns>
        Public ReadOnly Property AlternateNames As String()
            Get
                Return _AlternateNames
            End Get
        End Property

        ''' <summary>
        ''' Contains numeric value for stat.
        ''' </summary>
        ''' <returns>Numeric stat value.</returns>
        Public ReadOnly Property Value As Integer
            Get
                Return _Value
            End Get
        End Property

        ''' <summary>
        ''' Contains raw unmodified XML stat element.
        ''' </summary>
        ''' <returns>XML Element.</returns>
        ''' <remarks>Used for further processing.</remarks>
        Public ReadOnly Property StatElement As XElement
            Get
                Return _StatElement
            End Get
        End Property

        ''' <summary>
        ''' Contains all "statadd" elements for a particular stat block.
        ''' </summary>
        ''' <returns>Collection of stat modifiers.</returns>
        Public ReadOnly Property StatModifiers As Generic.List(Of StatModifier)
            Get
                Return _StatModifiers
            End Get
        End Property

#End Region

#Region "Events"

        ''' <summary>
        ''' Generates new instance of stat class.
        ''' </summary>
        Public Sub New(ByVal Name As String, _
                       ByVal Value As Integer, _
                       ByVal StatElement As XElement, _
                       Optional ByVal AlternateNames As String() = Nothing, _
                       Optional ByVal StatModifiers As Generic.List(Of StatModifier) = Nothing)

            'Assign all values to private literals.
            _Name = Name
            _Value = Value
            _StatElement = StatElement
            _AlternateNames = AlternateNames
            _StatModifiers = StatModifiers
        End Sub

#End Region

    End Class

    ''' <summary>
    ''' Contains a conditional modifier for a stat block.
    ''' </summary>
    Public Class StatModifier

#Region "Literals"

        Private _Type As String = Nothing

        Private _Value As String = Nothing

        Private _Level As Integer = 1

        Private _CharElem As String = Nothing

        Private _AbilityLink As String = Nothing

        Private _AbilityModifier As Boolean = False

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
        ''' Indicates if this modifier is tied to a specific ability score.
        ''' </summary>
        Public ReadOnly Property AbilityLink As String
            Get
                Return _AbilityLink
            End Get
        End Property

        ''' <summary>
        ''' Value of modifier, if indicated.
        ''' </summary>
        Public ReadOnly Property AbilityModifier As Boolean
            Get
                Return _AbilityModifier
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
                       ByVal AbilityLink As String, _
                       ByVal AbilityModifier As Boolean, _
                       ByVal Rule As Rule)

            'Assign values to private literals.
            _Type = Type
            _Level = Level
            _Value = Value
            _CharElem = CharElem
            _AbilityLink = AbilityLink
            _AbilityModifier = AbilityModifier
            _Rule = Rule
        End Sub

#End Region

    End Class

End Namespace
