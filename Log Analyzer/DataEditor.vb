Public Class DataEditor

    Dim LogFile As Log
    Dim LogFile_Backup As Log

    Private Sub DataEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Main.LogFile.Headers.Count > 1 Then
            ComboBox_Series.Items.AddRange(Main.LogFile.Headers)
            LogFile_Backup = DeepClone(Main.LogFile)
            LogFile = DeepClone(Main.LogFile)
        Else
            ComboBox_Series.Enabled = False
        End If
    End Sub

    Function DeepClone(Of T)(ByRef orig As T) As T
        ' Don't serialize a null object, simply return the default for that object
        If (Object.ReferenceEquals(orig, Nothing)) Then Return Nothing
        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim stream As New IO.MemoryStream()
        formatter.Serialize(stream, orig)
        stream.Seek(0, IO.SeekOrigin.Begin)
        Return CType(formatter.Deserialize(stream), T)
    End Function

#Region "Filter Functions"

    Private Sub Backup()
        LogFile = DeepClone(LogFile_Backup)
    End Sub

    Private Sub Apply()
        Main.LogFile = LogFile
        Main.DataUpdated()
    End Sub

    Private Sub Add(ByVal Value As Double, ByVal Series As String)
        Backup()
        For Index As Integer = 0 To LogFile.Count()
            LogFile.SetValue(Series, Index, LogFile.GetValue(Series, Index) + Value)
        Next
        Apply()
    End Sub

    Private Sub Multiply(ByVal Value As Double, ByVal Series As String)
        Backup()
        For Index As Integer = 0 To LogFile.Count()
            LogFile.SetValue(Series, Index, LogFile.GetValue(Series, Index) * Value)
        Next
        Apply()
    End Sub

    Private Sub EMA(ByVal Alpha As Double, ByVal Series As String)
        Backup()
        Dim LastValue As Double = LogFile.GetValue(Series, 0)
        For Index As Integer = 1 To LogFile.Count() - 1
            Dim Filtered As Double = LogFile.GetValue(Series, Index) * Alpha + LastValue * (1 - Alpha)
            LogFile.SetValue(Series, Index, Filtered)
            LastValue = Filtered
        Next
        Apply()
    End Sub

    Private Sub MA(ByVal WindowSize As Integer, ByVal Series As String)
        Backup()
        Dim HalfWindow As Integer = Math.Floor(WindowSize / 2)
        For Index As Integer = HalfWindow To LogFile.Count() - 1 - HalfWindow
            Dim Value As Double = LogFile.GetValue(Series, Index)
            For Window As Integer = Index - HalfWindow To Index + HalfWindow
                Value += LogFile.GetValue(Series, Window)
            Next
            Value /= HalfWindow * 2 + 1
            LogFile.SetValue(Series, Index, Value)
        Next
        Apply()
    End Sub

    Private Sub Crop(ByVal Amount As Double, ByVal Above As Boolean, ByVal Series As String)
        Backup()
        For Index As Integer = 0 To LogFile.Count() - 1
            If Above Then
                If LogFile.GetValue(Series, Index) > Amount Then
                    LogFile.SetValue(Series, Index, Amount)
                End If
            Else
                If LogFile.GetValue(Series, Index) < Amount Then
                    LogFile.SetValue(Series, Index, Amount)
                End If
            End If
        Next
        Apply()
    End Sub

#End Region

#Region "GUI"

    Private Sub Lock()
        GroupBox_DataEditing.Enabled = False
        GroupBox_DataFiltering.Enabled = False
    End Sub

    Private Sub Unlock()
        GroupBox_DataEditing.Enabled = True
        GroupBox_DataFiltering.Enabled = True
    End Sub

    Private Sub CheckBox_TopMost_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_TopMost.CheckedChanged
        TopMost = CheckBox_TopMost.Checked
    End Sub

    Private Sub ComboBox_Series_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Series.SelectedIndexChanged
        If ComboBox_Series.SelectedIndex > 0 Then
            Unlock()
        Else
            Lock()
        End If
    End Sub

#End Region

#Region "Buttons"

    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to apply the filters to the log file?", "Apply filters", MessageBoxButtons.OKCancel)
        If result = DialogResult.OK Then
            LogFile_Backup = DeepClone(LogFile)
        End If
    End Sub

    Private Sub Button_Reset_Click(sender As Object, e As EventArgs) Handles Button_Reset.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to reset the applied filters?", "Reset filters", MessageBoxButtons.OKCancel)
        If result = DialogResult.OK Then
            Backup()
            Apply()
        End If
    End Sub

#Region "Filter Buttons"

    Private Sub Button_Add_Click(sender As Object, e As EventArgs) Handles Button_Add.Click
        Lock()
        Add(NumericUpDown_Offset.Value, ComboBox_Series.SelectedItem)
        Unlock()
    End Sub

    Private Sub Button_Subtract_Click(sender As Object, e As EventArgs) Handles Button_Subtract.Click
        Lock()
        Add(-NumericUpDown_Offset.Value, ComboBox_Series.SelectedItem)
        Unlock()
    End Sub

    Private Sub Button_Multiply_Click(sender As Object, e As EventArgs) Handles Button_Multiply.Click
        Lock()
        Multiply(NumericUpDown_Factor.Value, ComboBox_Series.SelectedItem)
        Unlock()
    End Sub

    Private Sub Button_Divide_Click(sender As Object, e As EventArgs) Handles Button_Divide.Click
        Lock()
        Multiply(1.0 / NumericUpDown_Factor.Value, ComboBox_Series.SelectedItem)
        Unlock()
    End Sub

    Private Sub Button_EMA_Apply_Click(sender As Object, e As EventArgs) Handles Button_EMA_Apply.Click
        Lock()
        EMA(NumericUpDown_EMA_Alpha.Value, ComboBox_Series.SelectedItem)
        Unlock()
    End Sub

    Private Sub Button_MA_Apply_Click(sender As Object, e As EventArgs) Handles Button_MA_Apply.Click
        Lock()
        MA(NumericUpDown_MA_WindowSize.Value, ComboBox_Series.SelectedItem)
        Unlock()
    End Sub

    Private Sub Button_CropAbove_Click(sender As Object, e As EventArgs) Handles Button_CropAbove.Click
        Lock()
        Crop(NumericUpDown_Crop.Value, True, ComboBox_Series.SelectedItem)
        Unlock()
    End Sub

    Private Sub Button_CropBelow_Click(sender As Object, e As EventArgs) Handles Button_CropBelow.Click
        Lock()
        Crop(NumericUpDown_Crop.Value, False, ComboBox_Series.SelectedItem)
        Unlock()
    End Sub

#End Region

#End Region

End Class