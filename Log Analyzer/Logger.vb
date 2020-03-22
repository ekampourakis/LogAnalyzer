Public Class Logger

    Private _Writer As IO.StreamWriter
    Private _LogName As String

    Public Sub New(ByVal LogPath As String, ByVal Optional LogExtension As String = ".log", ByVal Optional LogName As String = Nothing, ByVal Optional MakeUnique As Boolean = True)
        If LogName = Nothing Then
            LogName = "Log"
        End If
        If MakeUnique Then
            LogName &= Now.ToString(" dd_mm_yyyy HH_mm")
        End If
        If IO.Directory.Exists(LogPath) Then
            If Not LogPath.EndsWith("\") Then
                LogPath &= "\"
            End If
        Else
            IO.Directory.CreateDirectory(LogPath)
        End If
        _Writer = New IO.StreamWriter(LogPath & LogName & LogExtension)
    End Sub

    Public Sub Close()
        If _Writer IsNot Nothing Then
            _Writer.Close()
            _Writer.Dispose()
        End If
    End Sub

    Public Sub Write(ByVal Data As String)
        If _Writer IsNot Nothing Then
            _Writer.WriteLine(Data)
        End If
    End Sub

End Class