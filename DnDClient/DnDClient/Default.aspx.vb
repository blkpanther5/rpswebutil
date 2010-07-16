Imports System.Linq
Imports System.Xml.Linq

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim XDoc As XDocument = XDocument.Load(Server.MapPath("Rolen.xml"))

        Dim Output = From C In XDoc.Descendants("StatBlock").Elements("Stat") _
                     Where C.Attribute("name") = "Strength" _
                     Select C

        'Dim Ref = From R In XDoc.Descendants("StatBlock").Elements("Stat") _
        '          Where 

        Response.Write(Output.Value)
    End Sub

End Class