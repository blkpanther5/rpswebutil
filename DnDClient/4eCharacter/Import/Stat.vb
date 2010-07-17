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

End Namespace
