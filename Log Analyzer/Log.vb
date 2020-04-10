<Serializable()> Public Class Log

    Private _LogFile As Dictionary(Of String, List(Of Double))

    Private LogFile As String() = Nothing
    Dim LogPath As String
    Public LogDelimiter As Char = ","
    Private Const FirstLogDelimiter As Char = ","
    Private Const SecondLogDelimiter As Char = ";"
    Public LogHeaders As String() = Nothing

    Default Public Property Series(ByVal Name As String) As List(Of Double)
        Get
            If _LogFile.ContainsKey(Name) Or Name = "Time" Then
                If Name = "Time" Then
                    Return _LogFile("vtime")
                End If
                Return _LogFile(Name)
            End If
            Return Nothing
        End Get
        Set(value As List(Of Double))

        End Set
    End Property

    Public Sub New()
        _LogFile = New Dictionary(Of String, List(Of Double))
    End Sub

    Private Sub Open(ByRef LogFile As String(), ByVal Delimiter As String)
        _LogFile = New Dictionary(Of String, List(Of Double))
        Dim Headers As String() = LogFile(0).Split(Delimiter)
        Headers(0) = "vtime"
        ' Manually add the first line
        Dim Line As String() = LogFile(1).Split(Delimiter)
        For Index As Integer = 0 To Headers.Count - 1
            _LogFile.Add(Headers(Index), New List(Of Double)({Line(Index)}))
        Next
        ' Automatically add the rest of lines
        For Index As Integer = 2 To LogFile.Count - 1
            Line = LogFile(Index).Split(Delimiter)
            For Index2 As Integer = 0 To Headers.Count - 1
                _LogFile(Headers(Index2)).Add(Line(Index2))
            Next
        Next
    End Sub

    Public Function Open(ByVal Path As String) As Boolean
        ' Open the file
        If Not IO.File.Exists(Path) Then Return False
        LogPath = Path
        LogFile = IO.File.ReadAllLines(Path)
        If Not CheckLogFile() Then
            LogPath = ""
            LogFile = Nothing
            LogHeaders = Nothing
            Return False
        End If
        Return AnalyzeLogFile()
    End Function

    Private Function CheckLogFile() As Boolean
        ' Log file must contain the headers in the first row
        If LogFile(0).StartsWith("vtime") Or LogFile(0).StartsWith("vTime") Then
            ' Headers must be seperated with a valid log delimiter
            If LogFile(0).Contains(FirstLogDelimiter) Or LogFile(0).Contains(SecondLogDelimiter) Then
                ' Load the file into the structures
                If Not LogFile(0).Contains(FirstLogDelimiter) Then LogDelimiter = SecondLogDelimiter Else LogDelimiter = FirstLogDelimiter
                LogHeaders = LogFile(0).Replace(" ", "").Split(LogDelimiter)
            Else
                MsgBox("The selected file doesn't appear to be a valid log file. Only comma (,) or semicolon (;) seperated data are supported.", MsgBoxStyle.Critical, "Error")
                Return False
            End If
        Else
            MsgBox("The selected file doesn't appear to be a valid log file. The first line of the file must contain the log headers.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        Dim LastMillis As Integer = 0
        Dim CorruptedLines As New List(Of Integer)
        For Index As Integer = 1 To LogFile.Count - 1
            Dim Columns As String()
            Try
                Columns = LogFile(Index).Split(LogDelimiter)
            Catch ex As Exception
                CorruptedLines.Add(Index)
                Continue For
            End Try

            ' All lines must have equal amount of columns
            If Columns.Count <> LogHeaders.Count Then
                ' Corrupted line
                CorruptedLines.Add(Index)
                Continue For
            End If

            ' Multiple runs are fixable in the same log file
            If LogFile(Index).StartsWith("vtime") Or LogFile(Index).StartsWith("vTime") Then
                ' Multiple runs
                Dim result As DialogResult = MessageBox.Show("The selected log file seems to be containing more than just one run. This file format is not support by this version of the application. The application can although split the log file to multiple files based on their runs. Do you want to split the log file to try to correct this error?", "Error", MessageBoxButtons.OKCancel)
                If result = DialogResult.OK Then
                    SplitLogFile()
                    MsgBox("Please try to open the *NEW* log files. If the error persists contact your application maintainer.", MsgBoxStyle.Exclamation, "Warning")
                End If
                Return False
            End If

            ' First column must be in ascending order and in milliseconds
            If Columns(0) <= LastMillis Then
                ' Jump back in time
                MsgBox("An unexpected error occured in the log file. A jump back in time was recognized in line " & Index & ".", MsgBoxStyle.Critical, "Error")
                Return False
            End If

        Next

        ' Remove corrupted lines
        Dim NewLogFile(LogFile.Count() - CorruptedLines.Count() - 1) As String
        Dim Line As Integer = 0
        For Index As Integer = 0 To LogFile.Count - 1
            If CorruptedLines.Count > 0 Then
                If Index <> CorruptedLines.Item(0) Then
AddLine:
                    NewLogFile(Line) = LogFile(Index)
                    Line += 1
                Else
                    CorruptedLines.RemoveAt(0)
                End If
            Else
                GoTo AddLine
            End If

        Next
        LogFile = NewLogFile

        Return True
    End Function

    Private Sub SplitLogFile()
        Dim RunIndex As Integer = 0
        Dim Path As String = IO.Path.GetDirectoryName(LogPath) & "\"
        Dim Name As String = IO.Path.GetFileNameWithoutExtension(LogPath)
        Dim Writer As IO.StreamWriter
        Dim LastMillis As Integer = 0
        Dim HeaderIndex As Integer = 0
        Dim RemovedLines As Integer = 0
        For Index As Integer = 0 To LogFile.Count - 1
            If LogFile(Index).StartsWith("vtime") Or LogFile(Index).StartsWith("vTime") Then
                RunIndex += 1
                HeaderIndex = Index
                If RunIndex > 1 Then
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                    Writer.Close()
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                    Writer.Dispose()
                End If
                Writer = New IO.StreamWriter(Path & Name & "_Run" & RunIndex & ".txt")
                Writer.WriteLine(LogFile(Index))
                LastMillis = 0
            Else
                Dim Columns() As String = LogFile(Index).Split(LogDelimiter)
                ' All lines must have equal amount of columns
                ' First column must be in ascending order and in milliseconds
                If Columns.Count <> LogHeaders.Count Or Columns(0) <= LastMillis Then
                    RemovedLines += 1
                    Continue For
                End If
                LastMillis = Columns(0)
                Writer.WriteLine(LogFile(Index))
            End If
        Next
        MsgBox("Successfully extracted " & RunIndex & " runs from the log file and removed " & RemovedLines & " corrupted lines.", MsgBoxStyle.Information, "Success")
        Writer.Close()
        Writer.Dispose()
    End Sub

    Private Function AnalyzeLogFile()
        ' Recognize and load the log
        Select Case LogHeaders(0)
            Case "vtime"
                'LogType = LogFileType.UoP6e
                'MsgBox("Loaded UoP6e log file.", MsgBoxStyle.Information, "Success")
                LoadLogFile_6()
                Return True
            Case "vTime[s]"
                'LogType = LogFileType.FSG
                'MsgBox("Loaded FSG log file.", MsgBoxStyle.Information, "Success")
                LoadLogFile_FSG()
                Return True
            Case "DT"
                'LogType = LogFileType.UoP7e
                MsgBox("UoP7e log files are not supported yet.")
            Case Else
                'LogType = LogFileType.Generic
                MsgBox("Generic log files are not supported yet.")
        End Select
        Return False
    End Function

    Private Sub LoadLogFile()
        ' FIXME: These will need to be searched and not statically acquired
        'MinTime = LogFile(1).Split(LogDelimiter)(0)
        'MaxTime = LogFile(LogFile.Count - 1).Split(LogDelimiter)(0)
        'Length = (MaxTime - MinTime)
        Open(LogFile, LogDelimiter)
    End Sub

    Private Sub LoadLogFile_6()
        LoadLogFile()
    End Sub

    Private Sub LoadLogFile_FSG()
        Dim Offset As Integer = Math.Floor(Double.Parse(LogFile(1).Split(LogDelimiter)(0), Globalization.CultureInfo.InvariantCulture) * 1000.0)
        For Index As Integer = 1 To LogFile.Count - 1
            LogFile(Index) = CInt(Double.Parse(LogFile(Index).Split(LogDelimiter)(0), Globalization.CultureInfo.InvariantCulture) * 1000.0) - Offset & LogFile(Index).Substring(LogFile(Index).IndexOf(LogDelimiter))
        Next
        LoadLogFile()
    End Sub

    Public Sub Save(ByVal Path As String)
        Dim Writer As New IO.StreamWriter(Path)
        Writer.WriteLine(String.Join(FirstLogDelimiter, Headers()))
        For Index As Integer = 0 To Count() - 1
            Dim Line As New List(Of String)
            For Index2 As Integer = 0 To Headers().Count - 1
                Line.Add(GetValue(Headers(Index2), Index))
            Next
            Writer.WriteLine(String.Join(FirstLogDelimiter, Line))
        Next
        Writer.Close()
        Writer.Dispose()
    End Sub

    Public Function Trim(ByVal SelectionStart As Double, ByVal SelectionEnd As Double) As Boolean
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to trim the log file? This will discard all values that are not in the selected range.", "Trim log file", MessageBoxButtons.OKCancel)
        If result = DialogResult.OK Then
            If SelectionStart > 0 And SelectionEnd > 0 Then
                If Math.Abs(SelectionEnd - SelectionStart) > 500 Then ' At least 500ms
                    Dim TrimFrom As Integer = Math.Min(SelectionStart, SelectionEnd)
                    Dim TrimTo As Integer = Math.Max(SelectionStart, SelectionEnd)
                    Dim NewLog As New List(Of String)
                    NewLog.Add(String.Join(FirstLogDelimiter, Headers()))
                    For Index As Integer = 1 To Count() - 1
                        'Dim Line As String() = LogFile(Index).Split(LogDelimiter)
                        'If Line(0) >= TrimFrom And Line(0) <= TrimTo Then
                        '    Line(0) -= TrimFrom
                        '    NewLog.Add(String.Join(FirstLogDelimiter, Line))
                        'End If

                        Dim Value As Double = GetValue("Time", Index)
                        If Value >= TrimFrom And Value <= TrimTo Then
                            Dim Line As New List(Of String)
                            Line.Add(Value - TrimFrom)
                            For Index2 As Integer = 1 To Headers().Count - 1
                                Line.Add(GetValue(Headers(Index2), Index))
                            Next
                            NewLog.Add(String.Join(FirstLogDelimiter, Line))
                        End If
                    Next
                    'LogFile = NewLog.ToArray()
                    'CheckLogFile()
                    'AnalyzeLogFile()
                    Open(NewLog.ToArray(), FirstLogDelimiter)
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Public Function Headers() As String()
        Return _LogFile.Keys.ToArray
    End Function

    'Public Function Series(ByVal Name As String) As List(Of Double)
    '    If _LogFile.ContainsKey(Name) Then
    '        Return _LogFile(Name)
    '    End If
    '    Return Nothing
    'End Function

    Public Function Count() As Integer
        Return Series("Time").Count
    End Function

    Public Function MinTime() As Double
        Return GetValue("Time", 0)
    End Function

    Public Function MaxTime() As Double
        Return GetValue("Time", Count() - 1)
    End Function

    Public Function Length() As Double
        Return MaxTime() - MinTime()
    End Function

    Public Function SetValue(ByVal Series As String, ByVal Index As Integer, ByVal Value As Double) As Boolean
        If _LogFile.ContainsKey(Series) Then
            If Index >= 0 And Index < Count() Then
                _LogFile(Series).Item(Index) = Value
                Return True
            End If
        End If
        Return False
    End Function

    Public Function GetValue(ByVal Series As String, ByVal Index As Integer) As Double
        If Index >= 0 And Index < Count() Then
            Return Me.Series(Series).Item(Index)
        End If
        Return Nothing
    End Function

End Class
