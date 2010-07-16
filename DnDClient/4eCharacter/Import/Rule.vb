Namespace Import

    ''' <summary>
    ''' Represents a rule reference for a specific character sheet element.
    ''' </summary>
    Public Class Rule

#Region "Literals"

        Private _Name As String = Nothing

        Private _Type As String = Nothing

        Private _InternalId As String = Nothing

        Private _CharElem As String = Nothing

        Private _Legality As String = Nothing

        Private _URL As String = Nothing

#End Region

#Region "Properties"

        ''' <summary>
        ''' Represents the name of the rule.
        ''' </summary>
        Public ReadOnly Property Name As String
            Get
                Return _Name
            End Get
        End Property

        ''' <summary>
        ''' Represents the type of the rule (such as feat).
        ''' </summary>
        Public ReadOnly Property Type As String
            Get
                Return _Type
            End Get
        End Property

        ''' <summary>
        ''' The internal Id of this rule.
        ''' </summary>
        Public ReadOnly Property InternalId As String
            Get
                Return _InternalId
            End Get
        End Property

        ''' <summary>
        ''' Reference Id, links rules to stats, etc.
        ''' </summary>
        Public ReadOnly Property CharElem As String
            Get
                Return _CharElem
            End Get
        End Property

        ''' <summary>
        ''' Indicates if this rule is legalally applied.
        ''' </summary>
        Public ReadOnly Property Legality As String
            Get
                Return _Legality
            End Get
        End Property

        ''' <summary>
        ''' The reference URL (to the D and D Insider website).
        ''' </summary>
        Public ReadOnly Property URL As String
            Get
                Return _URL
            End Get
        End Property

#End Region

#Region "Events"

        ''' <summary>
        ''' Creates new instance of the rules object and sets vaules.
        ''' </summary>
        ''' <param name="Name">Name of rule.</param>
        ''' <param name="Type">Type of rule.</param>
        ''' <param name="InternalId">Internal id for rule.</param>
        ''' <param name="CharElem">Linking id for rule.</param>
        ''' <param name="Legality">Indicates if the rule is legally applied.</param>
        ''' <param name="URL">URL reference for rule, points to D and D insider website.</param>
        Public Sub New(ByVal Name As String, _
                       ByVal Type As String, _
                       ByVal InternalId As String, _
                       ByVal CharElem As String, _
                       ByVal Legality As String, _
                       ByVal URL As String)

            'Set values on new object.
            _Name = Name
            _Type = Type
            _InternalId = InternalId
            _CharElem = CharElem
            _Legality = Legality
            _URL = URL
        End Sub

#End Region

    End Class

End Namespace