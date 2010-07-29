Namespace Common.Types

    ''' <summary>
    ''' Collection of generic name/value pair representing bonuses.
    ''' </summary>
    <Serializable()> _
    Public Class GenericBonusCollection
        Inherits Generic.List(Of GenericBonus)

        ''' <summary>
        ''' Returns the sum of all bonuses in collection.
        ''' </summary>
        Public Function Sum() As Integer
            If Me IsNot Nothing AndAlso Me.Count <= 0 Then _
                Return Nothing

            Return Me.Sum(Function(Bonus) _
                                   Bonus.Bonus)
        End Function

    End Class

    ''' <summary>
    ''' Generic name/value pair representing bonuses.
    ''' </summary>
    <Serializable()> _
    Public Class GenericBonus

        ''' <summary>
        ''' Name of untyped bonus.
        ''' </summary>
        Public Name As String = Nothing

        ''' <summary>
        ''' Numeric value of untyped bonus.
        ''' </summary>
        Public Bonus As Integer = 0

        ''' <summary>
        ''' Creates an instance of bonus.
        ''' </summary>
        Public Sub New(ByVal BonusName As String, _
                       ByVal BonusValue As Integer)

            Name = BonusName
            Bonus = BonusValue
        End Sub

    End Class

    ''' <summary>
    ''' Generic use name-value-pair object.
    ''' </summary>
    <Serializable()> _
    Public Class GenericNVP

        ''' <summary>
        ''' Name of pair.
        ''' </summary>
        Public Property Name As String

        ''' <summary>
        ''' Value of pair.
        ''' </summary>
        Public Property Value As String

        ''' <summary>
        ''' Associated internal id of rule.
        ''' </summary>
        Public Property InternalId As String

        ''' <summary>
        ''' Creates object.
        ''' </summary>
        ''' <param name="Name">Name of item.</param>
        ''' <param name="Value">Value of item.</param>
        ''' <param name="InternalId">Internal reference id.</param>
        Public Sub New(ByVal Name As String, _
                       ByVal Value As String, _
                       ByVal InternalId As String)

            'set values.
            Me.Name = Name
            Me.Value = Value
            Me.InternalId = InternalId
        End Sub

    End Class

    ''' <summary>
    ''' Represents unified collection of Url resources.
    ''' </summary>
    <Serializable()> _
    Public Class UrlCollection
        Inherits Generic.List(Of Url)

        ''' <summary>
        ''' Finds Url by specified internal id.
        ''' </summary>
        ''' <param name="InternalId">Internal Id of Url to locate.</param>
        ''' <returns>Url object.</returns>
        Public Function getUrlByInternalId(ByVal InternalId As String)
            'Attempt to find Url by the specified id.
            Return Me.Find(Function(E) E.InternalId = InternalId)
        End Function

    End Class

    ''' <summary>
    ''' Represents a single Url resource coupled with specified Internal Id.
    ''' </summary>
    <Serializable()> _
    Public Class Url

        ''' <summary>
        ''' Url of object.
        ''' </summary>
        Public Uri As String = Nothing

        ''' <summary>
        ''' Internal unique identifier for Url.
        ''' </summary>
        ''' <remarks></remarks>
        Public InternalId As String = Nothing

        ''' <summary>
        ''' Creates an instance of Url.
        ''' </summary>
        Public Sub New(ByVal Uri As String, _
                       ByVal InternalId As String)

            Uri = Uri
            InternalId = InternalId
        End Sub

    End Class
End Namespace