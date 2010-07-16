Imports System.Linq
Imports System.Xml.Linq

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Import As New RolePlayingSystem.Import.Character(Server.MapPath("Rolen.xml"))
        Dim Character As RolePlayingSystem.Character.Base = Import.Character
    End Sub

End Class