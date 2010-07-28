Imports System.IO
Imports System.Linq
Imports System.Xml.Linq
Imports RolePlayingSystem.Data

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Import As New RolePlayingSystem.Import.Character(Server.MapPath("Rolen.xml"))
        Dim Character As RolePlayingSystem.Character.Base = Import.Character

        Response.Write("Done! ")
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
        Dim CompendiumData As New Compendium()
        CompendiumData.getCompendiumSearchResults("Lightning Shift", Compendium.DataType.Power)

        'Dim Post As New Collections.Specialized.NameValueCollection
        'Post.Add("email", Request.Cookies("Login").Value)
        'Post.Add("password", Request.Cookies("Password").Value)

        'Response.Write("<hr />")
        'Response.Write(CompendiumData.getCompendiumEntry("http://www.wizards.com/dndinsider/compendium/power.aspx?id=3701", Post))
        'Response.Write("<hr />")
        'Response.Write(CompendiumData.getCompendiumEntry("http://www.wizards.com/dndinsider/compendium/power.aspx?id=3005", Post))
        'Response.Write("<hr />")
    End Sub
End Class