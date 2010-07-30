Imports RolePlayingSystem.Common.Net
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Net
Imports System.Xml
Imports System.Text
Imports System.Linq
Imports System.Xml.Linq

Namespace Data

    ''' <summary>
    ''' Data manipulation, retrieval and caching utilities.
    ''' </summary>
    Public Class Compendium

#Region "Enumerations"

        ''' <summary>
        ''' Represents valid "tab" types for searching compendium.
        ''' </summary>
        Public Enum DataType
            Race = 0
            Power = 1
            [Class] = 2
            Feat = 3
            Item = 4
            Skill = 5
            Ritual = 6
            ParagonPath = 7
            EpicDestiny = 8
            Monster = 9
            Deity = 10
            Glossary = 11
        End Enum

#End Region

#Region "Literals"

        Private _WebClient As New ExtendedWebClient

        Private _Login As String = Nothing

        Private _Password As String = Nothing

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

        ''' <summary>
        ''' Contains user name to login to compendium.
        ''' </summary>
        Public Property Login As String
            Get
                Return _Login
            End Get
            Set(ByVal value As String)
                _Login = value
            End Set
        End Property

        ''' <summary>
        ''' Contains password to login to compendium.
        ''' </summary>
        Public Property Password As String
            Get
                Return _Password
            End Get
            Set(ByVal value As String)
                _Password = value
            End Set
        End Property
#End Region

#Region "Events"

        ''' <summary>
        ''' Creates instance of compendium utils.
        ''' </summary>
        ''' <param name="Login">Login, if needed for compendium.</param>
        ''' <param name="Password">Password, if needed for compendium.</param>
        ''' <remarks></remarks>
        Public Sub New(Optional ByVal Login As String = Nothing, _
                       Optional ByVal Password As String = Nothing)

            'Set values.
            _Login = Login
            _Password = Password
        End Sub

#End Region

#Region "Methods"

        ''' <summary>
        ''' Searches public compendium source for specified item.
        ''' </summary>
        ''' <param name="SearchQuery">Keyword search term.</param>
        ''' <param name="Type">Type of item to search for.</param>
        ''' <param name="Id">Optional Id search filter.</param>
        ''' <returns>Matching XElements.</returns>
        Function getCompendiumSearchResults(ByVal SearchQuery As String, _
                                            ByVal Type As DataType, _
                                            Optional ByVal Id As Integer = 0) As IEnumerable(Of XElement)

            'Load XML document from query response.
            Dim ResponseDoc As XDocument
            Dim ResponseElements As Generic.IEnumerable(Of XElement)

            Try
                ResponseDoc = _
                    XDocument.Load("http://www.wizards.com/dndinsider/compendium/CompendiumSearch.asmx/KeywordSearch?Keywords=" & SearchQuery & _
                   "&tab=" & [Enum].Parse(GetType(DataType), Type).ToString() & "&NameOnly=false")

                'Get result elements.
                ResponseElements = ResponseDoc.Descendants.Elements("Results").First.Elements()

                'If Id is specified, search for it.
                If Id <> 0 Then _
                    ResponseElements = ResponseElements.Where(Function(E) E.Elements("ID").Value = Id)

            Catch ex As Exception
                ResponseDoc = Nothing
                ResponseElements = Nothing

            End Try

            Return TryCast(ResponseElements, IEnumerable(Of XElement))
        End Function

        ''' <summary>
        ''' Returns content of specified URL.
        ''' </summary>
        ''' <param name="Url">URL to post.</param>
        ''' <returns>String of HTML content.</returns>
        Function getCompendiumEntry(ByVal Url As String) As String
            'Login URL.
            Dim sLoginUrl As String = "http://www.wizards.com/dndinsider/compendium/login.aspx"
            Dim PostData As New Collections.Specialized.NameValueCollection

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
                    'Add authentication to the Upload Values.
                    PostData.Add("email", Login)
                    PostData.Add("password", Password)

                    'Attempt to authenticate.
                    sResponse = Text.Encoding.ASCII.GetString(WebClient.UploadValues(sLoginUrl, "POST", PostData))

                    'Extract detail div.
                    sResponse = sResponse.Replace(vbCrLf, " ")
                    sResponse = sResponse.Substring(sResponse.IndexOf("<div id=""detail"">"))
                    sResponse = sResponse.Substring(0, sResponse.LastIndexOf("</div>") + 6)

                    'Remove any unknown characters (represended by '???').
                    sResponse = Regex.Replace(sResponse, "\?{3}", "")

                Catch ex As Exception
                    'If we throw an error, try the target page again, as we should have authenticated.
                    Response = WebClient.DownloadData(Url)
                    sResponse = Text.Encoding.ASCII.GetString(Response)

                End Try
            End If

            'Return the final content.
            Return sResponse
        End Function

#End Region

    End Class

End Namespace
