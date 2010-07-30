Imports System.IO
Imports System.Linq
Imports System.Xml
Imports System.Xml.Linq
Imports RolePlayingSystem
Imports RolePlayingSystem.Data

Public Class _Client
    Inherits System.Web.UI.Page

    Public _Character As RolePlayingSystem.Character.Base = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Deserialize character.
        If Not String.IsNullOrEmpty(ViewState("CharacterFile")) Then
            Dim XmlRead As XmlReader = XmlReader.Create(ViewState("CharacterFile"))
            Dim Serializer As New System.Runtime.Serialization.NetDataContractSerializer()

            'Now read out the file back into the object.
            _Character = TryCast(Serializer.ReadObject(XmlRead, True), RolePlayingSystem.Character.Base)

            'Initialize character viewer.
            doLoadCharacter(_Character)
        End If
    End Sub

    Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        'Set cookie values for login and password.
        Dim Login As New HttpCookie("Login")
        Dim Password As New HttpCookie("Password")

        Login.Value = txtLogin.Text
        Password.Value = txtPassword.Text

        Login.Expires = Now.AddDays(1)
        Password.Expires = Now.AddDays(1)

        Response.Cookies.Add(Login)
        Response.Cookies.Add(Password)
    End Sub

    Private Sub btnGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGet.Click
        Dim CharacterImport As New RolePlayingSystem.Import.Character(Server.MapPath("Rolen.xml"), Request.Cookies("Login").Value, Request.Cookies("Password").Value)
        _Character = CharacterImport.Character

        'Save current file name.
        ViewState("CharacterFile") = Server.MapPath("/Data/") & "\" & _Character.Name & "_" & _Character.Level & ".xml"

        'Create stream and serializer.
        Dim XmlWrite As XmlWriter = XmlWriter.Create(ViewState("CharacterFile"))
        Dim Serializer As New System.Runtime.Serialization.NetDataContractSerializer()

        'Serialize.
        Serializer.WriteObject(XmlWrite, _Character)
        XmlWrite.Close()
    End Sub

#Region "Methods"

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

        'Load data source for powers.
        PowerRepeater.DataSource = Character.Powers.LogicalSort
        PowerRepeater.DataBind()
    End Sub

#End Region
End Class
