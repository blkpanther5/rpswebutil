Imports System.IO
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq
Imports RolePlayingSystem
Imports RolePlayingSystem.Data
Imports RolePlayingSystem.Data.SQL
Imports RolePlayingSystem.Data.SQL.Entities

Public Class _Client
    Inherits System.Web.UI.Page

#Region "Literals"

    Protected dal As New SQL.RolePlayingSystem(ConfigurationManager.ConnectionStrings("dbcsDefault").ConnectionString)

    Protected _Account As tblAccount = Nothing

    Protected _AccountId As String = Nothing

    Public _Character As RolePlayingSystem.Character.Base = Nothing

#End Region

#Region "Events"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'First check credentials.
        doCheckLoginStatus()

        'Initialize database connection.
        _Account = dal.getUserById(_AccountId)

        'Grab path to first character.
        Dim sCharacterPath As String = (_Account.tblCharacters.FirstOrDefault().CharacterData)

        'Load default (first) character for testing!
        'Deserialize character.
        If File.Exists(sCharacterPath) Then
            Dim XmlRead As XmlReader = XmlReader.Create(sCharacterPath)
            Dim Serializer As New System.Runtime.Serialization.NetDataContractSerializer()

            Try
                'Now read out the file back into the object.
                _Character = TryCast(Serializer.ReadObject(XmlRead, True), RolePlayingSystem.Character.Base)

                'Initialize character viewer.
                doLoadCharacter(_Character)

            Catch ex As Exception
                'Display error message (todo).

            End Try
        End If
    End Sub

    Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        'Nothing
    End Sub

    Private Sub btnGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGet.Click
        Dim CharacterImport As New RolePlayingSystem.Import.Character(Server.MapPath("Rolen.xml"), _Account.Login, _Account.Password)
        _Character = CharacterImport.Character

        'Save current file name.
        Dim sCharacterPath As String = (_Account.tblCharacters.FirstOrDefault().CharacterData)

        'Create stream and serializer.
        Dim XmlWrite As XmlWriter = XmlWriter.Create(sCharacterPath)
        Dim Serializer As New System.Runtime.Serialization.NetDataContractSerializer()

        'Serialize.
        Serializer.WriteObject(XmlWrite, _Character)
        XmlWrite.Close()
    End Sub

#End Region

#Region "Methods"

    ''' <summary>
    ''' Attempts to verify login cookie is present.
    ''' </summary>
    Private Sub doCheckLoginStatus()
        Dim LoginCookie As HttpCookie = Nothing

        Try
            'Find the cookie.
            LoginCookie = Request.Cookies("AccountId")
            _AccountId = LoginCookie.Value

        Catch ex As Exception
            'On error, null cookie.
            LoginCookie = Nothing

        End Try

        'If cookie is missing, goto login page.
        If LoginCookie Is Nothing Then _
            Response.Redirect("default.aspx")
    End Sub

    ''' <summary>
    ''' Returns appropriate color type for specified power type.
    ''' </summary>
    ''' <param name="PowerType">Type of power (at-will, encounter, etc).</param>
    ''' <returns>String color name.</returns>
    Public Function getColorByPowerType(ByVal PowerType) As String
        'Gets the proper color based on power type.
        Select Case PowerType.ToLower()
            Case "at-will"
                Return "Green"

            Case "encounter"
                Return "Red"

            Case "daily"
                Return "Black"

            Case "utility"
                Return "Navy"

        End Select

        Return String.Empty
    End Function

    ''' <summary>
    ''' Loads fields in client page with appropriate character data.
    ''' </summary>
    ''' <param name="Character">Reference to character object.</param>
    Private Sub doLoadCharacter(ByRef Character As Character.Base)
        'Exit if character is blank.
        If Character Is Nothing Then _
            Exit Sub

        'Populate basic info section.
        lblCharacterName.Text = Character.Name
        lblPlayerName.Text = IIf(Character.PlayerName = Nothing, "N/A", Character.PlayerName)
        lblRace.Text = Character.CharacterRace
        lblClass.Text = Character.CharacterClass
        lblLevel.Text = Character.Level
        lblStrScore.Text = Character.AbilityScores.Strength.Score
        lblStrMod.Text = Character.AbilityScores.Strength.Modifier
        lblDexScore.Text = Character.AbilityScores.Dexterity.Score
        lblDexMod.Text = Character.AbilityScores.Dexterity.Modifier
        lblConScore.Text = Character.AbilityScores.Constitution.Score
        lblConMod.Text = Character.AbilityScores.Constitution.Modifier
        lblIntScore.Text = Character.AbilityScores.Intelligence.Score
        lblIntMod.Text = Character.AbilityScores.Intelligence.Modifier
        lblWisScore.Text = Character.AbilityScores.Wisdom.Score
        lblWisMod.Text = Character.AbilityScores.Wisdom.Modifier
        lblChaScore.Text = Character.AbilityScores.Charisma.Score
        lblChaMod.Text = Character.AbilityScores.Charisma.Modifier

        'Load the other info box.
        lblHP.Text = Character.CurrentHitPoints
        lblSurges.Text = Character.CurrentSurges
        lblACScore.Text = Character.Defenses.AC.Score
        lblRefScore.Text = Character.Defenses.Reflex.Score
        lblFortScore.Text = Character.Defenses.Fortitude.Score
        lblWillScore.Text = Character.Defenses.Will.Score

        'Load data source for powers.
        PowerRepeater.DataSource = Character.Powers.LogicalSort
        PowerRepeater.DataBind()

        PowerSummary.InnerHtml = Character.Powers(2).Description
    End Sub

#End Region

End Class
