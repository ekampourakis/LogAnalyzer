Imports System
Imports System.Collections.Specialized
Imports System.Net
Imports System.Text

Imports Newtonsoft.Json

Public Class Payload
    <JsonProperty("channel")>
    Public Property Channel As String
    <JsonProperty("username")>
    Public Property Username As String
    <JsonProperty("text")>
    Public Property Text As String
End Class


Public Class SlackClient

    Private ReadOnly _uri As Uri
    Private ReadOnly _encoding As Encoding = New UTF8Encoding()

    Public Sub New(ByVal urlWithAccessToken As String)
        _uri = New Uri(urlWithAccessToken)
        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
    End Sub

    Public Sub PostMessage(ByVal text As String, ByVal Optional username As String = Nothing, ByVal Optional channel As String = Nothing)
        Dim payload As Payload = New Payload() With {
            .channel = channel,
            .username = username,
            .text = text
        }
        PostMessage(payload)
    End Sub

    Public Sub PostMessage(ByVal payload As Payload)
        Dim payloadJson As String = JsonConvert.SerializeObject(payload)

        Using client As WebClient = New WebClient()
            Dim data As NameValueCollection = New NameValueCollection()
            data("payload") = payloadJson
            Dim response = client.UploadValues(_uri, "POST", data)
            Dim responseText As String = _encoding.GetString(response)
        End Using
    End Sub

End Class
