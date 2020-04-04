Public Class Settings

#Region "Value Controls"

    Private Sub TrackBar_MaxZoom_Scroll(sender As Object, e As EventArgs) Handles TrackBar_MaxZoom.ValueChanged, TrackBar_MaxZoom.Scroll
        Label_MaxZoom.Text = "Maximum Zoom: " & TrackBar_MaxZoom.Value & "ms"
        ValueChanged()
    End Sub

    Private Sub TrackBar_ZoomSteps_Scroll(sender As Object, e As EventArgs) Handles TrackBar_ZoomSteps.ValueChanged, TrackBar_ZoomSteps.Scroll
        Label_ZoomSteps.Text = "Zoom Steps: " & TrackBar_ZoomSteps.Value
        ValueChanged()
    End Sub

    Private Sub TrackBar_ScaleInterval_Scroll(sender As Object, e As EventArgs) Handles TrackBar_ScaleInterval.ValueChanged, TrackBar_ScaleInterval.Scroll
        Label_ScaleInterval.Text = "Scale Interval: " & TrackBar_ScaleInterval.Value
        ValueChanged()
    End Sub

    Private Sub TrackBar_XGrids_Scroll(sender As Object, e As EventArgs) Handles TrackBar_XGrids.ValueChanged, TrackBar_XGrids.Scroll
        Label_XGrids.Text = "X Grids: " & TrackBar_XGrids.Value
        ValueChanged()
    End Sub

    Private Sub TrackBar_MaxAreas_Scroll(sender As Object, e As EventArgs) Handles TrackBar_MaxAreas.ValueChanged, TrackBar_MaxAreas.Scroll
        Label_MaxAreas.Text = "Maximum Areas: " & TrackBar_MaxAreas.Value
        ValueChanged()
    End Sub

    Private Sub ComboBox_SeriesType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_SeriesType.SelectedIndexChanged
        ValueChanged()
    End Sub

#End Region

    Private Sub LoadSettings()
        TrackBar_MaxZoom.Value = My.Settings.Chart_Scale_MaxZoom * 1000
        TrackBar_ZoomSteps.Value = My.Settings.Chart_Scale_ZoomSteps
        TrackBar_ScaleInterval.Value = My.Settings.Chart_Scale_Interval
        TrackBar_XGrids.Value = My.Settings.Chart_Scale_AxisX_Grids
        TrackBar_MaxAreas.Value = My.Settings.Chart_MaxChartAreas
        TrackBar_BorderSize.Value = My.Settings.Chart_Border_Size * 10
        If My.Settings.Chart_Series_Type = DataVisualization.Charting.SeriesChartType.Line Then
            ComboBox_SeriesType.SelectedIndex = 0
        ElseIf My.Settings.Chart_Series_Type = DataVisualization.Charting.SeriesChartType.Point Then
            ComboBox_SeriesType.SelectedIndex = 1
        End If
        CheckBox_LimitCPU.Checked = My.Settings.Chart_LimitCPU
        CheckBox_ReduceFlicker.Checked = My.Settings.Chart_LimitFlicker
        CheckBox_ZeroLine.Checked = My.Settings.Chart_ZeroLine

        Button_Save.Enabled = False
        _ValueChanged = False
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSettings()
    End Sub

    Dim _ValueChanged As Boolean = False
    Private Sub ValueChanged()
        If Not _ValueChanged Then
            _ValueChanged = True
            Button_Save.Enabled = True
        End If
    End Sub

    Private Sub Button_ResetDefaults_Click(sender As Object, e As EventArgs) Handles Button_ResetDefaults.Click
        Dim Result As DialogResult = MessageBox.Show("Are you sure you want to reset all settings to their default value?", "Reset defaults", MessageBoxButtons.OKCancel)
        If Result = DialogResult.Cancel Then
        ElseIf Result = DialogResult.OK Then
            My.Settings.Reset()
            LoadSettings()
        End If
    End Sub

    Private Sub Button_Reload_Click(sender As Object, e As EventArgs) Handles Button_Reload.Click
        If _ValueChanged Then
            Dim Result As DialogResult = MessageBox.Show("Are you sure you want to reload all settings? All your unsaved changes will be lost.", "Reset defaults", MessageBoxButtons.OKCancel)
            If Result = DialogResult.Cancel Then
            ElseIf Result = DialogResult.OK Then
                LoadSettings()
            End If
        Else
            LoadSettings()
        End If
    End Sub

    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        My.Settings.Chart_Scale_MaxZoom = TrackBar_MaxZoom.Value / 1000.0
        My.Settings.Chart_Scale_ZoomSteps = TrackBar_ZoomSteps.Value
        My.Settings.Chart_Scale_Interval = TrackBar_ScaleInterval.Value
        My.Settings.Chart_Scale_AxisX_Grids = TrackBar_XGrids.Value
        My.Settings.Chart_MaxChartAreas = TrackBar_MaxAreas.Value
        My.Settings.Chart_Border_Size = TrackBar_BorderSize.Value / 10.0
        If ComboBox_SeriesType.SelectedIndex = 0 Then
            My.Settings.Chart_Series_Type = DataVisualization.Charting.SeriesChartType.Line
        Else
            My.Settings.Chart_Series_Type = DataVisualization.Charting.SeriesChartType.Point
        End If
        My.Settings.Chart_LimitCPU = CheckBox_LimitCPU.Checked
        My.Settings.Chart_LimitFlicker = CheckBox_ReduceFlicker.Checked
        My.Settings.Chart_ZeroLine = CheckBox_ZeroLine.Checked

        My.Settings.Save()
        _ValueChanged = False
        Button_Save.Enabled = False

        Main.DataUpdated()
    End Sub

    Private Sub TrackBar_BorderSize_Scroll(sender As Object, e As EventArgs) Handles TrackBar_BorderSize.Scroll
        Label_BorderSize.Text = "Border Size: " & TrackBar_BorderSize.Value / 10.0 & " pixels"
        ValueChanged()
    End Sub

    Private Sub CheckBox_LimitCPU_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_LimitCPU.CheckedChanged
        ValueChanged()
    End Sub

    Private Sub CheckBox_ReduceFlicker_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_ReduceFlicker.CheckedChanged
        ValueChanged()
    End Sub

    Private Sub CheckBox_ZeroLine_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_ZeroLine.CheckedChanged
        ValueChanged()
    End Sub
End Class