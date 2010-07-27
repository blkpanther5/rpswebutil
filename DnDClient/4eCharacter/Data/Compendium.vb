Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Net
Imports RolePlayingSystem.Common.Net

Namespace Data

    ''' <summary>
    ''' Data manipulation, retrieval and caching utilities.
    ''' </summary>
    Public Class Compendium

#Region "Literals"

        Private _WebClient As New ExtendedWebClient

#End Region

#Region "Properties"

        ''' <summary>
        ''' Instance of web client, reused for multiple queries to compendium.
        ''' </summary>
        Protected Friend ReadOnly Property WebClient As ExtendedWebClient
            Get
                Return _WebClient
            End Get
        End Property

#End Region

#Region "Methods"

        ''' <summary>
        ''' Returns content of specified URL.
        ''' </summary>
        ''' <param name="Url">URL to post.</param>
        ''' <param name="PostData">Optional post data.</param>
        ''' <returns>String of HTML content.</returns>
        Function getCompendiumEntry(ByVal Url As String, _
                                           ByVal PostData As Collections.Specialized.NameValueCollection) As String

            'Login URL.
            Dim sLoginUrl As String = "http://www.wizards.com/dndinsider/compendium/login.aspx"

            'Web client object will do the heavy lifting.
            WebClient.UseDefaultCredentials = False
            WebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded")

            'Literal to hold response, get initial page.
            Dim Response() As Byte = WebClient.DownloadData(Url)
            Dim sResponse As String = Text.Encoding.ASCII.GetString(Response)

            'IF it contains "login.aspx", we need to execute login.
            If sResponse.Contains("login.aspx") Then
                'Parse out additional fields in webpage.
                Dim sPage As String = Nothing
                Dim sPageId As String = Nothing

                'Grab the target page and id, to append to login URL.
                For Each Match As Match In Regex.Matches(sResponse, "\<form.*page\=(\w*)\&amp\;id\=(\d*).*\>")
                    If Match.Groups.Count >= 3 Then
                        sPage = Match.Groups(1).Value
                        sPageId = Match.Groups(2).Value
                    End If
                Next

                'Append each field to post data string.
                For Each Match As Match In Regex.Matches(sResponse, "\<input.*\>")
                    Dim sValue As String = Nothing
                    Dim sId As String = Nothing

                    'Grab Id.
                    For Each SubMatch As Match In Regex.Matches(Match.Value, "id\=\""([\w\d\=\\\/\+\s]+)\""")
                        sId = SubMatch.Groups(SubMatch.Groups.Count - 1).Value
                    Next

                    'Grab value
                    For Each SubMatch As Match In Regex.Matches(Match.Value, "value\=\""([\w\d\=\\\/\+\s]+)\""")
                        sValue = SubMatch.Groups(SubMatch.Groups.Count - 1).Value
                    Next

                    'Do not append if email or password.
                    If sId <> "email" And sId <> "password" Then
                        PostData.Add(sId, sValue)
                    End If
                Next

                'Reconstruct the login URL.
                sLoginUrl += "?page=" & sPage & "&id=" & sPageId

                Try
                    'Attempt to authenticate.
                    sResponse = Text.Encoding.ASCII.GetString(WebClient.UploadValues(sLoginUrl, "POST", PostData))

                Catch ex As Exception
                    'If we throw an error, try the target page again, as we should have authenticated.
                    Response = WebClient.DownloadData(Url)
                    sResponse = Text.Encoding.ASCII.GetString(Response)

                End Try
            End If

            'Extract detail div.
            sResponse = sResponse.Replace(vbCrLf, " ")
            sResponse = sResponse.Substring(sResponse.IndexOf("<div id=""detail"">"))
            sResponse = sResponse.Substring(0, sResponse.LastIndexOf("</div>") + 6)

            'Remove any unknown characters (represended by '???').
            sResponse = Regex.Replace(sResponse, "\?{3}", "")

            'Return the final content.
            Return sResponse
        End Function

#End Region

    End Class

End Namespace
