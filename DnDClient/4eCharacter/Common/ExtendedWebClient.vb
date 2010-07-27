Imports System.Net

Namespace Common.Net

    ''' <summary>
    ''' Extends default WebClient class by adding cookie handling capability.
    ''' </summary>
    Public Class ExtendedWebClient
        Inherits WebClient

#Region "Properties"

        ''' <summary>
        ''' Store for received cookies.
        ''' </summary>
        Private CookieContainer As New CookieContainer

#End Region

#Region "Methods"

        ''' <summary>
        ''' Function handles web requests (adds received cookies to container).
        ''' </summary>
        ''' <param name="address">Uri of resource.</param>
        Protected Overrides Function GetWebRequest(ByVal address As System.Uri) As System.Net.WebRequest
            Dim Request As WebRequest = MyBase.GetWebRequest(address)
            If TypeOf Request Is HttpWebRequest Then
                DirectCast(Request, HttpWebRequest).CookieContainer = CookieContainer
            End If

            Return Request
        End Function

#End Region

    End Class

End Namespace
