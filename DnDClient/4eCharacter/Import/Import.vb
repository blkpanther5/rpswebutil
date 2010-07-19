Imports System.Linq
Imports System.Xml.Linq
Imports System.IO
Imports RolePlayingSystem.Common.Types
Imports RolePlayingSystem.Common.Utility
Imports RolePlayingSystem.Character.Defense
Imports RolePlayingSystem.Character.Skills

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
                    'Find ability modifier value, if needed.
                    Dim iAbilMod As Integer = Nothing

                    'Don't allow "modifier" elements to statlink back, otherwise we get an infinite loop.
                    If Not StatName.ToLower.Contains("modifier") AndAlso Convert.ToBoolean(getAttributeValue(Item.Attribute("abilmod"))) Then
                        iAbilMod = getStat(getAttributeValue(Item.Attribute("statlink")) & " modifier").Value
                    End If

                    'Add to collection.
                    StatModifiers.Add(New StatModifier(getAttributeValue(Item.Attribute("type")), _
                                                       CInt(getAttributeValue(Item.Attribute("Level"))), _
                                                       getAttributeValue(Item.Attribute("value")), _
                                                       getAttributeValue(Item.Attribute("charelem")), _
                                                       getAttributeValue(Item.Attribute("statlink")), _
                                                       getStat(getAttributeValue(Item.Attribute("statlink"))), _
                                                       iAbilMod, _
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
        ''' Loads specified defense score.
        ''' </summary>
        ''' <param name="Defense">Reference to defense score to populate.</param>
        ''' <param name="Stat">Stat object to load defense block with.</param>
        ''' <param name="IncludeArmor">Indicates this stat block should include armor.</param>
        Private Sub doLoadDefense(ByRef Defense As DefenseScore, _
                                  ByRef Stat As Stat, _
                                  Optional ByVal IncludeArmor As Boolean = False)

            'If the stat is empty, exit now.
            If Stat Is Nothing Then _
                Exit Sub

            'Load each sub-stat part that new need.
            Dim ArmorMod As IEnumerable(Of StatModifier) = Stat.StatModifiers.Where(Function(Elem) Elem.Type = "Armor")
            Dim AbilityMod As IEnumerable(Of StatModifier) = Stat.StatModifiers.Where(Function(Elem) Elem.Type = "Ability")
            Dim ClassMod As IEnumerable(Of StatModifier) = Stat.StatModifiers.Where(Function(Elem) Elem.Type = "Class")
            Dim FeatMod As IEnumerable(Of StatModifier) = Stat.StatModifiers.Where(Function(Elem) Elem.Type = "Feat")
            Dim EnhancementMod As IEnumerable(Of StatModifier) = Stat.StatModifiers.Where(Function(Elem) Elem.Type = "Enhancement")

            Defense.Ability = IIf(AbilityMod.Count > 0, AbilityMod.Max(Function(Elem) Elem.StatModifier), Nothing)
            Defense.ClassBonus = IIf(ClassMod.Count > 0, ClassMod.Sum(Function(Elem) Elem.StatLink.StatModifiers.Sum(Function(E) E.Value)), Nothing)
            Defense.Feat = IIf(FeatMod.Count > 0, FeatMod.Max(Function(Elem) Elem.Value), Nothing)
            Defense.Enhancement = IIf(EnhancementMod.Count > 0, EnhancementMod.Sum(Function(Elem) Elem.Value), Nothing)

            'Include armor score, if indicated.
            If IncludeArmor Then _
                Defense.Armor = IIf(ArmorMod.Count > 0, ArmorMod.Sum(Function(Elem) Elem.Value), Nothing)
        End Sub

        ''' <summary>
        ''' Begins parsing the supplied character sheet file.
        ''' </summary>
        Private Sub doInitCharacterParsing()
            'Basics.
            Dim HalfLevel As Stat = getStat("HALF-LEVEL")

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
                                                           getRule(Of Rule)(Type:="Alignment").Name.ToString.Replace(" ", "_")), Alignment)
            _Character.Deity = getRule(Of Rule)(Type:="Deity").Name
            _Character.Height = getDetail("Height")
            _Character.Weight = getDetail("Weight")
            _Character.PlayerName = getDetail("Player")
            _Character.AdventureName = getDetail("Company")

            'Begin loading base stats!
            _Character.AbilityScores.Strength.Score = getStat("Strength").Value
            _Character.AbilityScores.Dexterity.Score = getStat("Dexterity").Value
            _Character.AbilityScores.Constitution.Score = getStat("Constitution").Value
            _Character.AbilityScores.Intelligence.Score = getStat("Intelligence").Value
            _Character.AbilityScores.Wisdom.Score = getStat("Wisdom").Value
            _Character.AbilityScores.Charisma.Score = getStat("Charisma").Value

            'Load defenses.
            doLoadDefense(_Character.Defenses.AC, getStat("AC"), True)
            doLoadDefense(_Character.Defenses.Fortitude, getStat("Fortitude Defense"))
            doLoadDefense(_Character.Defenses.Reflex, getStat("Reflex Defense"))
            doLoadDefense(_Character.Defenses.Will, getStat("Will Defense"))

            'Load Movement info.
            Dim SpeedStat As Stat = getStat("Speed")
            Dim BaseSpeed As StatModifier = SpeedStat.StatModifiers.Find(Function(E) E.Level = "1")
            Dim ArmorSpeed As IEnumerable(Of StatModifier) = SpeedStat.StatModifiers.Where(Function(E) E.Type = "Armor")
            Dim ItemSpeed As IEnumerable(Of StatModifier) = SpeedStat.StatModifiers.Where(Function(E) E.Type = "item")
            _Character.Movement.Base = IIf(BaseSpeed IsNot Nothing, BaseSpeed.Value, 0)
            _Character.Movement.Armor = IIf(ArmorSpeed.Count > 0, ArmorSpeed.Sum(Function(E) E.Value), 0)
            _Character.Movement.Item = IIf(ItemSpeed.Count > 0, ItemSpeed.Sum(Function(E) E.Value), 0)

            'Add up any remaining misc speed modifiers.
            Dim MiscSpeed As New GenericBonusCollection
            MiscSpeed.Add(New GenericBonus(Nothing, SpeedStat.Value - _Character.Movement.Speed))
            _Character.Movement.Misc = MiscSpeed

            'Load up skills.
            'To find skills, we'll look for any rules with a type of skill.
            Dim SkillRules As IEnumerable(Of Rule) = getRule(Of IEnumerable(Of Rule))(Type:="Skill")
            Dim SkillCollection As New SkillCollection
            Dim TempSkill As Skill = Nothing 'Temporary container for iterated skill.

            For Each Rule As Rule In SkillRules
                'TempSkill = getStat(Rule.Name)
                'SkillCollection.Add(New Skill(TempSkill.Name, _
                '                              _Character.AbilityScores.)
            Next

            'AC
            'Dim AC As Stat = getStat("AC")
            'Dim ACArmor As StatModifier = AC.StatModifiers.Find(Function(Elem) Elem.StatLink.Name = "Armor")
            'Dim ACC
            '_Character.Defenses.AC.Armor = IIf(ACArmor IsNot Nothing, ACArmor.Value, Nothing)
            '_Character.Defenses.AC.Ability = AC.StatModifiers.Max(Function(Elem) Elem.StatModifier)


        End Sub

#End Region

    End Class

End Namespace
