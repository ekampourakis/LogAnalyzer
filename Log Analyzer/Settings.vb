Public Class Settings

#Region "Value Controls"

    Private Sub TrackBar_MaxZoom_Scroll(sender As Object, e As EventArgs) Handles TrackBar_MaxZoom.Scroll, TrackBar_MaxZoom.ValueChanged
        Label_MaxZoom.Text = "Maximum Zoom: " & TrackBar_MaxZoom.Value & "ms"
        ValueChanged()
    End Sub

    Private Sub TrackBar_ZoomSteps_Scroll(sender As Object, e As EventArgs) Handles TrackBar_ZoomSteps.Scroll, TrackBar_ZoomSteps.ValueChanged
        Label_ZoomSteps.Text = "Zoom Steps: " & TrackBar_ZoomSteps.Value
        ValueChanged()
    End Sub

    Private Sub TrackBar_ScaleInterval_Scroll(sender As Object, e As EventArgs) Handles TrackBar_ScaleInterval.Scroll, TrackBar_ScaleInterval.ValueChanged
        Label_ScaleInterval.Text = "Scale Interval: " & TrackBar_ScaleInterval.Value
        ValueChanged()
    End Sub

    Private Sub TrackBar_XGrids_Scroll(sender As Object, e As EventArgs) Handles TrackBar_XGrids.Scroll, TrackBar_XGrids.ValueChanged
        Label_XGrids.Text = "X Grids: " & TrackBar_XGrids.Value
        ValueChanged()
    End Sub

    Private Sub TrackBar_MaxAreas_Scroll(sender As Object, e As EventArgs) Handles TrackBar_MaxAreas.Scroll, TrackBar_MaxAreas.ValueChanged
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
        If My.Settings.Chart_Series_Type = DataVisualization.Charting.SeriesChartType.FastLine Then
            ComboBox_SeriesType.SelectedIndex = 0
        ElseIf My.Settings.Chart_Series_Type = DataVisualization.Charting.SeriesChartType.FastPoint Then
            ComboBox_SeriesType.SelectedIndex = 1
        End If
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
        If ComboBox_SeriesType.SelectedIndex = 0 Then
            My.Settings.Chart_Series_Type = DataVisualization.Charting.SeriesChartType.FastLine
        Else
            My.Settings.Chart_Series_Type = DataVisualization.Charting.SeriesChartType.FastPoint
        End If
        My.Settings.Save()
        _ValueChanged = False
        Button_Save.Enabled = False
    End Sub

End Class