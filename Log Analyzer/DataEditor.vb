Public Class DataEditor

    Dim LogFile_Backup As String()

    Function DeepClone(Of T)(ByRef orig As T) As T
        ' Don't serialize a null object, simply return the default for that object
        If (Object.ReferenceEquals(orig, Nothing)) Then Return Nothing
        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim stream As New IO.MemoryStream()
        formatter.Serialize(stream, orig)
        stream.Seek(0, IO.SeekOrigin.Begin)
        Return CType(formatter.Deserialize(stream), T)
    End Function

    Private Sub DataEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Main.LogHeaders.Length > 1 Then
            ComboBox_Series.Items.AddRange(Main.LogHeaders)
        Else
            ComboBox_Series.Enabled = False
        End If
        LogFile_Backup = DeepClone(Main.LogFile)
    End Sub

    Private Sub ComboBox_Series_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Series.SelectedIndexChanged
        If ComboBox_Series.SelectedIndex > 0 Then
            Unlock()
        Else
            Lock()
        End If
    End Sub

    Private Sub Add(ByVal Value As Double, ByVal Column As Integer)
        Dim LogFile As String() = Main.LogFile
        Dim Delimiter As String = Main.LogDelimiter
        For Index As Integer = 1 To LogFile.Length - 1
            Dim Line As String() = LogFile(Index).Split(Delimiter)
            Line(Column) = CDbl(Line(Column)) + Value
            LogFile(Index) = String.Join(Delimiter, Line)
        Next
        Main.LogFile = LogFile
        Main.SettingsUpdated()
    End Sub

    Private Sub Multiply(ByVal Value As Double, ByVal Column As Integer)
        Dim LogFile As String() = Main.LogFile
        Dim Delimiter As String = Main.LogDelimiter
        For Index As Integer = 1 To LogFile.Length - 1
            Dim Line As String() = LogFile(Index).Split(Delimiter)
            Line(Column) = CDbl(Line(Column)) * Value
            LogFile(Index) = String.Join(Delimiter, Line)
        Next
        Main.LogFile = LogFile
        Main.SettingsUpdated()
    End Sub

    Private Sub EMA(ByVal Alpha As Double, ByVal Column As Integer)
        Dim LogFile As String() = Main.LogFile
        Dim Delimiter As String = Main.LogDelimiter
        Dim LastValue As Double = LogFile(1).Split(Delimiter)(Column)
        For Index As Integer = 1 To LogFile.Length - 1
            Dim Line As String() = LogFile(Index).Split(Delimiter)
            Line(Column) = CDbl(Line(Column)) * Alpha + LastValue * (1 - Alpha)
            LastValue = Line(Column)
            LogFile(Index) = String.Join(Delimiter, Line)
        Next
        Main.LogFile = LogFile
        Main.SettingsUpdated()
    End Sub

    Private Sub MA(ByVal WindowSize As Integer, ByVal Column As Integer)
        Dim LogFile As String() = Main.LogFile
        Dim Delimiter As String = Main.LogDelimiter
        Dim HalfWindow As Integer = Math.Floor(WindowSize / 2.0)
        For Index As Integer = 1 + HalfWindow To LogFile.Length - 1 - HalfWindow
            Dim Line As String() = LogFile(Index).Split(Delimiter)

            Dim Value As Double = Line(Column)
            For Window As Integer = Index - HalfWindow To Index + HalfWindow
                Value += LogFile(Window).Split(Delimiter)(Column)
            Next
            Value /= HalfWindow * 2 + 1
            Line(Column) = Value
            LogFile(Index) = String.Join(Delimiter, Line)
        Next
        Main.LogFile = LogFile
        Main.SettingsUpdated()
    End Sub

    Private Sub Lock()
        GroupBox_DataEditing.Enabled = False
        GroupBox_DataFiltering.Enabled = False
    End Sub

    Private Sub Unlock()
        GroupBox_DataEditing.Enabled = True
        GroupBox_DataFiltering.Enabled = True
    End Sub

    Private Sub Button_Add_Click(sender As Object, e As EventArgs) Handles Button_Add.Click
        Lock()
        Add(NumericUpDown_Offset.Value, ComboBox_Series.SelectedIndex)
        Unlock()
    End Sub

    Private Sub Button_Subtract_Click(sender As Object, e As EventArgs) Handles Button_Subtract.Click
        Lock()
        Add(-NumericUpDown_Offset.Value, ComboBox_Series.SelectedIndex)
        Unlock()
    End Sub

    Private Sub Button_Multiply_Click(sender As Object, e As EventArgs) Handles Button_Multiply.Click
        Lock()
        Multiply(NumericUpDown_Factor.Value, ComboBox_Series.SelectedIndex)
        Unlock()
    End Sub

    Private Sub Button_Divide_Click(sender As Object, e As EventArgs) Handles Button_Divide.Click
        Lock()
        Multiply(1.0 / NumericUpDown_Factor.Value, ComboBox_Series.SelectedIndex)
        Unlock()
    End Sub

    Private Sub Button_EMA_Apply_Click(sender As Object, e As EventArgs) Handles Button_EMA_Apply.Click
        Lock()
        EMA(NumericUpDown_EMA_Alpha.Value, ComboBox_Series.SelectedIndex)
        Unlock()
    End Sub

    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to apply the filters to the log file?", "Apply filters", MessageBoxButtons.OKCancel)
        If result = DialogResult.Cancel Then
            Main.LogFile = DeepClone(LogFile_Backup)
            Main.SettingsUpdated()
        End If
    End Sub

    Private Sub Button_Reset_Click(sender As Object, e As EventArgs) Handles Button_Reset.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to reset the applied filters?", "Reset filters", MessageBoxButtons.OKCancel)
        If result = DialogResult.OK Then
            Main.LogFile = DeepClone(LogFile_Backup)
            Main.SettingsUpdated()
        End If
    End Sub

    Private Sub Button_MA_Apply_Click(sender As Object, e As EventArgs) Handles Button_MA_Apply.Click
        Lock()
        MA(NumericUpDown_MA_WindowSize.Value, ComboBox_Series.SelectedIndex)
        Unlock()
    End Sub

    Private Sub CheckBox_TopMost_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_TopMost.CheckedChanged
        TopMost = CheckBox_TopMost.Checked
    End Sub
End Class