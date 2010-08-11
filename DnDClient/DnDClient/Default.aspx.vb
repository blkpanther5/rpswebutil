Imports RolePlayingSystem.Data
Imports RolePlayingSystem.Data.SQL
Imports RolePlayingSystem.Data.SQL.Entities

Public Class _Default
    Inherits System.Web.UI.Page

#Region "Literals"

    Private dal As New Data.SQL.RolePlayingSystem(ConfigurationManager.ConnectionStrings("dbcsDefault").ConnectionString)

#End Region

#Region "Events"

    ''' <summary>
    ''' Login button click event.
    ''' </summary>
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        'Attempt to validate using dal.
        Dim Account As tblAccount = dal.getUserByCredentials(txtLogin.Text, txtPassword.Text)

        If Account Is Nothing Then
            'If account is nothing, flag general validator.
            valGeneral.IsValid = False
        Else
            'Otherwise, set login cookie and redirect to client page.
            Dim LoginCookie As New HttpCookie("AccountId")

            'Cookie settings.
            LoginCookie.Value = Account.GUID
            LoginCookie.Expires = Now.AddDays(1)

            'Attach to page.
            Response.Cookies.Add(LoginCookie)

            'Redirect.
            Response.Redirect("client.aspx")
        End If
    End Sub

#End Region

End Class