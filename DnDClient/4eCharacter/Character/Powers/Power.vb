Namespace Character.Powers

    ''' <summary>
    ''' Represents a creature's power or ability.
    ''' </summary>
    <Serializable()> _
    Public Class Power
        'Implements IComparable

#Region "Literals"

        Private _Name As String = Nothing

        Private _Action As String = Nothing

        Private _Type As String = Nothing

        Private _Level As Integer = 1

        Private _Used As Boolean = False

        Private _Usage As Generic.IEnumerable(Of Usage)

        Private _Description As String = Nothing

        Private _Notes As String = Nothing

#End Region

#Region "Properties"

        ''' <summary>
        ''' Name of power.
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
        ''' Type of power.
        ''' </summary>
        Public ReadOnly Property Type As String
            Get
                Return _Type
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
        ''' Contains weapon usage for power.
        ''' </summary>
        Public Property Usage As Generic.IEnumerable(Of Usage)
            Get
                Return _Usage
            End Get
            Set(ByVal value As Generic.IEnumerable(Of Usage))
                _Usage = value
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
        ''' <param name="Usage">Collection of weapon usage stats for power.</param>
        ''' <param name="Description">HTML description of power.</param>
        Public Sub New(ByVal Name As String, _
                       ByVal Action As String, _
                       ByVal Type As String, _
                       ByVal Level As Integer, _
                       ByVal Usage As IEnumerable(Of Usage), _
                       Optional ByVal Description As String = Nothing)

            'Create object.
            _Name = Name
            _Action = Action
            _Type = Type
            _Level = Level
            _Usage = Usage
            _Description = Description
        End Sub

#End Region

    End Class

End Namespace
