Imports System.Text.RegularExpressions
Imports System.Web

Namespace Common

    ''' <summary>
    ''' Contains commonly used functions, enumerations and tools.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Utility

        ''' <summary>
        ''' Represents size class of object.
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum SizeClass
            Tiny = 0
            Small = 1
            Medium = 2
            Large = 3
            Huge = 4
            Gargantuan = 5
            Colossal = 6
        End Enum

        ''' <summary>
        ''' Represents gender of creature.
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum Gender
            Undefined = -1
            Male = 0
            Female = 1
        End Enum

        ''' <summary>
        ''' Represents alignment of creature.
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum Alignment
            Good = 0
            Lawful_Good = 1
            Evil = 2
            Chaotic_Evil = 3
            Unaligned = 4
        End Enum

        ''' <summary>
        ''' Performs simple check for null attributes.
        ''' </summary>
        ''' <param name="Attribute">XAttribute to check.</param>
        ''' <returns>Object value of supplied attribute.</returns>
        Shared Function getAttributeValue(ByVal Attribute As XAttribute) As Object
            'First check if the attribute is valid.
            If Attribute Is Nothing Then _
                Return Nothing

            'Ok, now return the attribute value.
            Return Attribute.Value
        End Function

        ''' <summary>
        ''' Returns content of specified URL.
        ''' </summary>
        ''' <param name="Url">URL to post.</param>
        ''' <param name="PostData">Optional post data.</param>
        ''' <returns>String of HTML content.</returns>
        Shared Function getCompendiumEntry(ByVal Url As String, _
                                           ByVal PostData As Collections.Specialized.NameValueCollection) As String

            'Login URL.
            Dim sLoginUrl As String = "http://www.wizards.com/dndinsider/compendium/login.aspx"

            'Web client object will do the heavy lifting.
            Dim Client As New Net.WebClient
            Client.UseDefaultCredentials = False

            'Literal to hold response, get initial page.
            Dim Response() As Byte = Client.DownloadData(Url)
            Dim sResponse As String = Text.Encoding.ASCII.GetString(Response)

            'IF it contains "login.aspx", we need to execute login.
            If sResponse.Contains("login.aspx") Then
                'Parse out additional fields in webpage.
                Dim sPage As String = Nothing
                Dim sPageId As String = Nothing

                For Each Match As Match In Regex.Matches(sResponse, "\<form.*page\=(\w*)\&amp\;id\=(\d*).*\>")
                    If Match.Groups.Count >= 3 Then
                        sPage = Match.Groups(1).Value
                        sPageId = Match.Groups(2).Value
                    End If
                Next

                'Append each field to post data string.
                For Each Match As Match In RegEx.Matches(sResponse, "\<input.*\>")
                    Dim sValue As String = Nothing
                    Dim sId As String = Nothing

                    'Grab Id.
                    For Each SubMatch As Match In RegEx.Matches(Match.Value, "id\=\""([\w\d\=\\\/\+\s]+)\""")
                        sId = SubMatch.Groups(SubMatch.Groups.Count - 1).Value
                    Next

                    'Grab value
                    For Each SubMatch As Match In RegEx.Matches(Match.Value, "value\=\""([\w\d\=\\\/\+\s]+)\""")
                        sValue = SubMatch.Groups(SubMatch.Groups.Count - 1).Value
                    Next

                    'Do not append if email or password.
                    If sId <> "email" And sId <> "password" Then
                        PostData.Add(sId, sValue)
                    End If
                Next

                'Parse byte array as ASCII text.
                sLoginUrl += "?page=" & sPage & "&id=" & sPageId
                Return Text.Encoding.ASCII.GetString(Client.UploadValues(sLoginUrl, "POST", PostData))
            End If

            Return sResponse
        End Function

    End Class

End Namespace
