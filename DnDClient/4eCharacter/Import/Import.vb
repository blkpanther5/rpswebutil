Imports System.Linq
Imports System.Xml.Linq
Imports System.IO
Imports RolePlayingSystem.Common.Utility

Namespace Import

    ''' <summary>
    ''' Performs importation and querying of character sheet file.
    ''' </summary>
    Public Class Character

#Region "Literals"

        ''' <summary>
        ''' Contains XDocument data for specified character sheet file.
        ''' </summary>
        Private _CharSheetData As New XDocument

        ''' <summary>
        ''' Path to specified character sheet file.
        ''' </summary>
        Private _CharSheetPath As String = Nothing

        ''' <summary>
        ''' Contains the final, parsed character base object for manipulation by consumer code.
        ''' </summary>
        Private _Character As New RolePlayingSystem.Character.Base

#End Region

#Region "Properties"

        ''' <summary>
        ''' Exposes character data to consuming application.
        ''' </summary>
        ''' <returns>Parsed character data.</returns>
        Public ReadOnly Property Character As RolePlayingSystem.Character.Base
            Get
                Return _Character
            End Get
        End Property

#End Region

#Region "Events"

        ''' <summary>
        ''' Inits the XML character file importation system.
        ''' </summary>
        ''' <param name="FilePath">Path to file to be queried.</param>
        Public Sub New(ByVal FilePath As String)
            'Check if file can be found, otherwise throw exception.
            If Not File.Exists(FilePath) Then _
                Throw New FileNotFoundException("Can't file specified character file.")

            'Attempt to load the document into memory for consumption by other functions.
            Try
                _CharSheetData = XDocument.Load(FilePath)

                'Attempt to start parsing process.
                doInitCharacterParsing()

            Catch ex As Exception
                'Do nothing.
                _Character = Nothing

            End Try

        End Sub

#End Region

#Region "Methods"

        ''' <summary>
        ''' Searches for a rule based on specified optional parameters.
        ''' </summary>
        ''' <typeparam name="t">Type to return, should either be Generic.List(Of Rule) or Rule.</typeparam>
        ''' <param name="Name">Name search parameter.</param>
        ''' <param name="Type">Type search parameter (ex. feat).</param>
        ''' <param name="InternalId">InternalId search parameter.</param>
        ''' <param name="CharElem">CharElem search parameter.</param>
        ''' <returns>Will return specified rules that match search query.</returns>
        Private Function getRule(Of t)(Optional ByVal Name As String = Nothing, _
                                       Optional ByVal Type As String = Nothing, _
                                       Optional ByVal InternalId As String = Nothing, _
                                       Optional ByVal CharElem As String = Nothing)

            Dim Output As Object = Nothing

            'Use Linq to query for the rules element by the 4 passed values.
            Try
                Dim Query = (From Rule In _CharSheetData.Descendants("RulesElementTally").Elements("RulesElement") _
                             Where (Rule.Attribute("name") = Name Or Name Is Nothing) And _
                             (Rule.Attribute("type") = Type Or Type Is Nothing) And _
                             (Rule.Attribute("internal-id") = InternalId Or InternalId Is Nothing) And _
                             (Rule.Attribute("charelem") = CharElem Or CharElem Is Nothing) _
                             Select Rule)

                'Depending on type passed in...
                If GetType(t) = GetType(Rule) Then
                    'Get first record matching.
                    Dim SubQuery = Query.FirstOrDefault()

                    'Create new rule object and assign values.
                    Dim Rule As New Rule(getAttributeValue(SubQuery.Attribute("name")), _
                                         getAttributeValue(SubQuery.Attribute("type")), _
                                         getAttributeValue(SubQuery.Attribute("internal-id")), _
                                         getAttributeValue(SubQuery.Attribute("charelem")), _
                                         getAttributeValue(SubQuery.Attribute("legality")), _
                                         getAttributeValue(SubQuery.Attribute("url")))

                    Output = Rule

                ElseIf GetType(t) = GetType(Generic.List(Of Rule)) Then
                    'Collection of rules.
                    Dim Rules As New Generic.List(Of Rule)

                    'Loop all matching records and create collection of rules to return.
                    For Each Rule As XElement In Query
                        Rules.Add(New Rule(getAttributeValue(Rule.Attribute("name")), _
                                           getAttributeValue(Rule.Attribute("type")), _
                                           getAttributeValue(Rule.Attribute("internal-id")), _
                                           getAttributeValue(Rule.Attribute("charelem")), _
                                           getAttributeValue(Rule.Attribute("legality")), _
                                           getAttributeValue(Rule.Attribute("url"))))

                        Output = Rules
                    Next
                End If
            Catch ex As Exception
                Output = New Rule(Nothing, _
                                  Nothing, _
                                  Nothing, _
                                  Nothing, _
                                  Nothing, _
                                  Nothing)

            End Try

            'Send back to consumer.
            Return Output
        End Function

        ''' <summary>
        ''' Searches loaded character file for specified stat.
        ''' </summary>
        ''' <param name="StatName">Name of stat to find.</param>
        ''' <returns>Parsed stat object.</returns>
        Private Function getStat(ByVal StatName As String) As Stat
            Try
                'Use linq to query xml doc for the specified stat name.
                Dim Query = (From Stat In _CharSheetData.Descendants("StatBlock").Elements("Stat") _
                             Where Stat.Attribute("name") = StatName _
                             Select Stat).SingleOrDefault

                Dim AltNames = (From Names In Query.Elements("alias").Attributes("name") _
                                Select Names.Value).ToArray()

                Dim StatMods = (From Mods In Query.Elements("statadd") _
                                Select Mods).ToList()

                Dim StatModifiers As New Generic.List(Of StatModifier)

                'Loop and create a collection of StatModifier objects.
                For Each Item As XElement In StatMods
                    StatModifiers.Add(New StatModifier(getAttributeValue(Item.Attribute("type")), _
                                                       CInt(getAttributeValue(Item.Attribute("Level"))), _
                                                       getAttributeValue(Item.Attribute("value")), _
                                                       getAttributeValue(Item.Attribute("charelem")), _
                                                       Convert.ToBoolean(getAttributeValue(Item.Attribute("statlink"))), _
                                                       getAttributeValue(Item.Attribute("abilmod")), _
                                                       getRule(Of Rule)(CharElem:=getAttributeValue(Item.Attribute("charelem")))))
                Next

                'Create new stat object, assign values and return.
                Dim ReturnStat As New Stat(StatName, Query.Attribute("value"), _
                                           Query, _
                                           AlternateNames:=AltNames, _
                                           StatModifiers:=StatModifiers)
                Return ReturnStat

            Catch ex As Exception
                'If we encounter an error, just return nothing.
                Return New Stat(Nothing, _
                                Nothing, _
                                Nothing)

            End Try
        End Function

        ''' <summary>
        ''' Searches details element for specified detail.
        ''' </summary>
        ''' <param name="DetailName">Name of element to retrieve</param>
        ''' <returns>String value of specified element.</returns>
        Private Function getDetail(ByVal DetailName As String) As String
            'Use linq to find and query the details element for specific sub element.
            Dim Query = (From Detail In _CharSheetData.Descendants("Details") _
                        Select Detail.Element(DetailName).Value).FirstOrDefault()

            'Trim string if not empty.
            If Not String.IsNullOrEmpty(Query) Then Query = Query.Trim()

            Return Query
        End Function

        ''' <summary>
        ''' Begins parsing the supplied character sheet file.
        ''' </summary>
        Private Sub doInitCharacterParsing()
            'Start by loading base info.
            _Character.Name = getDetail("name")
            _Character.CharacterClass = getRule(Of Rule)(Type:="Class").Name
            _Character.CharacterRace = getRule(Of Rule)(Type:="Race").Name
            _Character.Level = getStat("Level").Value
            _Character.Size = DirectCast([Enum].Parse(GetType(SizeClass), getRule(Of Rule)(Type:="Size").Name), SizeClass)
            _Character.Gender = DirectCast([Enum].Parse(GetType(Gender), getRule(Of Rule)(Type:="Gender").Name), Gender)
            _Character.ParagonPath = getRule(Of Rule)(Type:="Paragon Path").Name
            _Character.EpicDestiny = getRule(Of Rule)(Type:="Epic Destiny").Name
            _Character.Alignment = DirectCast([Enum].Parse(GetType(Alignment), _
                                                           getRule(Of Rule)(Type:="Alignment").Name.ToString.Replace("_", " ")), Alignment)


            'Begin loading base stats!
            _Character.AbilityScores.Strength.Score = getStat("Strength").Value
            _Character.AbilityScores.Dexterity.Score = getStat("Dexterity").Value
            _Character.AbilityScores.Constitution.Score = getStat("Constitution").Value
        End Sub

#End Region

    End Class

End Namespace
