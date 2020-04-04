Imports System.Windows.Forms.DataVisualization.Charting

Public Class Main

    Private Log As New Logger(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\UoP Racing\Log Analyzer\", ".txt", "LogAnalyzer", False)

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Log.Write("Starting")
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Log.Write("Ending")
        Log.Close()
    End Sub

#Region "Helper"

    Private Function Map(ByVal Value As Double, ByVal Low As Double, ByVal High As Double, ByVal toLow As Double, ByVal toHigh As Double)
        Return (Value - Low) * (toHigh - toLow) / (High - Low) + toLow
    End Function

    Private Function ClosestPoint(ByRef Values As DataPointCollection, ByVal Value As Double) As DataPoint
        Return Values.Aggregate(Function(x, y) If(Math.Abs(x.XValue - Value) < Math.Abs(y.XValue - Value), x, y))
    End Function

    Private Function ChartEmpty() As Boolean
        Return Chart.ChartAreas.Count <= 0
    End Function

#End Region

#Region "Log IO"

    Dim LogPath As String
    Public Shared LogFile As String() = Nothing
    Public Shared LogHeaders As String() = Nothing
    Dim LogFileLength As Integer = 0
    Public Shared LogDelimiter As Char = ","
    Private Const FirstLogDelimiter As Char = ","
    Private Const SecondLogDelimiter As Char = ";"
    Private Enum LogFileType
        UoP6e
        UoP7e
        Generic
        FSG
    End Enum
    Private LogType As LogFileType = LogFileType.Generic

    Private Sub OpenLogFile(ByVal Path As String)
        ClearCharts()
        ' Open the file
        If Not IO.File.Exists(Path) Then Exit Sub
        LogPath = Path
        LogFile = IO.File.ReadAllLines(Path)
        Log.Write("Loaded log file: " & Path)
        ' Check the validity of the log file
        If Not CheckLogFile() Then
            LogPath = ""
            LogFile = Nothing
            LogHeaders = Nothing
            Log.Write("Invalid log file")
            Exit Sub
        End If

        ToolStripStatusLabel_LogFile.Text = Path
        AnalyzeLogFile()
    End Sub

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

    Private Sub AnalyzeLogFile()
        ' Recognize and load the log
        Select Case LogHeaders(0)
            Case "vtime"
                LogType = LogFileType.UoP6e
                'MsgBox("Loaded UoP6e log file.", MsgBoxStyle.Information, "Success")
                LoadLogFile_6()
            Case "vTime[s]"
                LogType = LogFileType.FSG
                'MsgBox("Loaded FSG log file.", MsgBoxStyle.Information, "Success")
                LoadLogFile_FSG()
            Case "DT"
                LogType = LogFileType.UoP7e
                MsgBox("UoP7e log files are not supported yet.")
                Exit Sub
            Case Else
                LogType = LogFileType.Generic
                MsgBox("Generic log files are not supported yet.")
                Exit Sub
        End Select
        If PictureBox_LoadLog.Visible Then
            PictureBox_LoadLog.Visible = False
        End If
    End Sub

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
                    Writer.Close()
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

    Private Sub LoadLogFile()
        ' FIXME: These will need to be searched and not statically acquired
        MinTime = LogFile(1).Split(LogDelimiter)(0)
        MaxTime = LogFile(LogFile.Count - 1).Split(LogDelimiter)(0)
        LogFileLength = (MaxTime - MinTime)
        MaxScaleSize = LogFileLength
        ScaleSize = MaxScaleSize
        CheckedListBox.Items.Clear()
        CheckedListBox.Items.AddRange(LogHeaders)
        ' Remove the time element
        CheckedListBox.Items.RemoveAt(0)
        ' Disable all charts
        For Index As Integer = 0 To CheckedListBox.Items.Count - 1
            CheckedListBox.SetItemChecked(Index, False)
        Next
        ClearCharts()
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

    Private Sub LoadLogFile_7()
        ' Not yet supported
    End Sub

    Private Sub OpenFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog.FileOk
        OpenLogFile(OpenFileDialog.FileName)
    End Sub

    Private Sub SaveFileDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog.FileOk
        Dim Writer As New IO.StreamWriter(SaveFileDialog.FileName)
        Writer.WriteLine(String.Join(FirstLogDelimiter, LogHeaders))
        For Index As Integer = 1 To LogFile.Count - 1
            Writer.WriteLine(String.Join(FirstLogDelimiter, LogFile(Index).Split(LogDelimiter)))
        Next
        Writer.Close()
        Writer.Dispose()
    End Sub

#End Region

#Region "Chart Loading"

    Private Sub SetChartArea(ByRef Area As ChartArea)

        Dim AreaSeries As String = Chart.Series(Area.Name.Replace("ChartArea_", "Series_")).Name
        Dim Series As Series = Chart.Series(AreaSeries)

        Area.AxisX.LabelStyle.Format = "{0:0,.###}s"
        Area.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Number
        Area.AxisX.LabelStyle.Interval = ScaleSize / My.Settings.Chart_Scale_Interval
        Area.AxisX.MajorGrid.LineColor = My.Settings.Chart_GridColor
        Area.AxisY.MajorGrid.LineColor = My.Settings.Chart_GridColor
        Area.AxisX.MinorGrid.LineColor = My.Settings.Chart_GridColor
        Area.AxisX.MajorGrid.Enabled = True
        Area.AxisX.MajorTickMark.Enabled = True
        Area.AxisX.MinorGrid.Enabled = False
        Area.AxisX.MajorGrid.IntervalType = DateTimeIntervalType.Number
        Area.AxisX.MajorGrid.Interval = ScaleSize / My.Settings.Chart_Scale_AxisX_Grids
        Area.AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Number
        Area.AxisX.MajorTickMark.Interval = ScaleSize / My.Settings.Chart_Scale_AxisX_Grids / 2
        Area.AxisX.MajorTickMark.TickMarkStyle = TickMarkStyle.InsideArea

        Area.AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Number
        Area.AxisX.MinorGrid.Interval = ScaleSize / My.Settings.Chart_Scale_AxisX_Grids / 5
        Area.AxisX.MinorGrid.LineColor = System.Drawing.Color.LightGray
        Area.AxisX.MinorGrid.LineDashStyle = ChartDashStyle.Dot
        Area.AxisX.ScaleView.MinSizeType = DateTimeIntervalType.Number
        Area.AxisX.ScaleView.MinSize = My.Settings.Chart_Scale_MaxZoom
        Area.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number
        Area.AxisX.ScaleView.Size = LogFileLength
        Area.AxisX.ScaleView.SmallScrollSizeType = DateTimeIntervalType.Number
        Area.AxisX.ScaleView.SmallScrollSize = 1.0R

        ' Enable this to enable the zoom using the cursor
        Area.AxisX.ScaleView.Zoomable = False
        Area.AxisX.ScrollBar.BackColor = System.Drawing.Color.White
        Area.AxisX.ScrollBar.ButtonColor = System.Drawing.SystemColors.ControlLight
        Area.AxisX.ScrollBar.LineColor = System.Drawing.Color.Black

        Area.CursorX.IsUserEnabled = True
        Area.CursorX.IsUserSelectionEnabled = True
        Area.CursorX.AutoScroll = False
        Area.CursorX.AxisType = AxisType.Primary
        Area.CursorX.IntervalType = DateTimeIntervalType.Number
        Area.CursorX.Interval = 0.0R

        If My.Settings.Chart_ZeroLine Then
            Dim ZeroLine As New StripLine
            ZeroLine.Interval = 0
            ZeroLine.IntervalOffset = 0
            ZeroLine.BorderWidth = 3
            ZeroLine.BorderColor = Color.Firebrick
            Area.AxisY.StripLines.Add(ZeroLine)
        End If

    End Sub

    Private Sub ClearCharts()
        Chart.ChartAreas.Clear()
        Chart.Series.Clear()
        Chart.Legends.Clear()
    End Sub

    Private Function LimitChartAreas() As Integer
        ' Count the areas that are checked
        Dim Areas As Integer = 0
        For Index As Integer = 0 To CheckedListBox.Items.Count - 1
            If CheckedListBox.GetItemChecked(Index) Then Areas += 1
        Next
        TotalCharts = Areas
        ' Limit the maximum chart areas to display
        If Areas > My.Settings.Chart_MaxChartAreas Then Areas = My.Settings.Chart_MaxChartAreas
        VScrollBar.Maximum = If(TotalCharts > My.Settings.Chart_MaxChartAreas, TotalCharts - My.Settings.Chart_MaxChartAreas, 0)
        VScrollBar.Value = 0
        Return Areas
    End Function

    Private Sub UpdateChart()
        Try

            ClearCharts()

            ' Only allow a maximum number of chart areas
            Dim Areas As Integer = LimitChartAreas()
            ' Scroll the chart areas to display the maximum chart areas only
            Dim Areas_Index As Integer = ChartScrollIndex

            ' For each requested chart
            For Index As Integer = 1 To CheckedListBox.Items.Count
                ' If the series is selected
                If CheckedListBox.GetItemChecked(Index - 1) Then

                    ' Create the new chart area
                    Dim Area As New ChartArea
                    Area.Name = "ChartArea_" & LogHeaders(Index)
                    ' Position based on the maximum areas and scroll
                    Area.Position = New ElementPosition(0, Areas_Index * 100 / Areas, 100, 100 / Areas)
                    Areas_Index += 1
                    Area.AlignmentOrientation = AreaAlignmentOrientations.Vertical
                    ' Align with the last area
                    If Chart.ChartAreas.Count > 0 Then Area.AlignWithChartArea = Chart.ChartAreas(Chart.ChartAreas.Count - 1).Name
                    If Chart.ChartAreas.Count = 2 Then Chart.ChartAreas(0).AlignWithChartArea = Chart.ChartAreas(1).Name
                    ' Add the new chart area to the chart control
                    Chart.ChartAreas.Add(Area)

                    ' Create the legend for the area
                    Dim Legend As New Legend
                    Legend.Name = "Legend_" & LogHeaders(Index)
                    Legend.DockedToChartArea = Area.Name
                    Legend.Docking = Docking.Top
                    Legend.IsEquallySpacedItems = True
                    Legend.LegendStyle = LegendStyle.Column
                    Chart.Legends.Add(Legend)
                    Legend.Enabled = True

                    ' Create the series for the new area
                    Dim Series As New Series
                    Series.Name = "Series_" & LogHeaders(Index)
                    ' Associate the series with the area and the legend
                    Series.ChartArea = Area.Name
                    Series.Legend = Legend.Name
                    ' Include the MIN and MAX values to the legend
                    Series.LegendText = LogHeaders(Index) & " Min: #MIN{D0}, Max: #MAX{D0}"
                    Series.ChartType = My.Settings.Chart_Series_Type 'SeriesChartType.FastPoint
                    Series.XValueType = ChartValueType.Int32
                    Series.BorderWidth = My.Settings.Chart_Border_Size
                    ' Set the Y-axis value properties
                    Series.YValueType = ChartValueType.Auto
                    Series.YAxisType = AxisType.Primary
                    Chart.Series.Add(Series)

                    ' Add the first point manually
                    Dim Line As String() = LogFile(1).Split(LogDelimiter)
                    Dim Millis As Integer = Line(0)
                    Dim LastValue As Double = CDbl(Line(Index))
                    'Series.Points.AddXY(ChartTimeOffset.AddMilliseconds(Millis), LastValue)
                    Series.Points.AddXY(Millis, LastValue)
                    Dim Avoided As Integer = 0
                    ' Maximum points to be ignored at once
                    Dim MaxAvoided As Integer = 100

                    ' Fill the series with the data points from the log file while 
                    ' avoiding adding points with the same value as their previous one
                    Dim LastMillis As Integer = Millis
                    For Index2 As Integer = 2 To LogFile.Count - 1
                        Line = LogFile(Index2).Split(LogDelimiter)
                        Millis = Line(0)
                        If Millis < LastMillis Then
                            Dim result As DialogResult = MessageBox.Show("The selected log file seems to be corrupted. Line " & Index2 + 1 & " seems to be jumping back in time. The application can continue by skipping this line but some features may not work correctly. Do you want to continue?", "Warning", MessageBoxButtons.OKCancel)
                            If result = DialogResult.OK Then
                                Continue For
                            ElseIf result = DialogResult.Cancel Then
                                ClearCharts()
                                Exit Sub
                            End If
                        End If
                        If CDbl(Line(Index)) <> LastValue Or Index2 = LogFile.Count - 1 Then
                            LastValue = CDbl(Line(Index))
                            'Series.Points.AddXY(ChartTimeOffset.AddMilliseconds(Millis), LastValue)
                            Series.Points.AddXY(Millis, LastValue)
                        Else
                            Avoided += 1
                            If Avoided = MaxAvoided Then
                                LastValue = Double.MinValue
                            End If
                        End If
                        LastMillis = Millis
                    Next
                    ' Scroll and zoom the area to fit all the points
                    'Area.AxisX.ScaleView.Position = ChartTimeOffset.AddMilliseconds(LogFile(1).Split(LogDelimiter)(0)).ToOADate
                    'Area.AxisX.ScaleView.Size = LogFileLength
                    SetChartArea(Area)
                    ChartResetScale = Area.AxisX.ScaleView

                    If KeepScale Then ZoomChart(ScaleSize, ScalePosition)


                    UpdateScales()
                End If
            Next

            AutoScaleY()

        Catch ex As Exception
            Log.Write(ex.Message)
        End Try
    End Sub

#End Region

#Region "Chart"

    Private KeepScale As Boolean = False

    Private ScaleSize As Double = 0 ' auto calculated when series are loaded
    Private MaxScaleSize As Double = 0 ' auto calculated when series are loaded
    Dim ChartScrollIndex As Integer = 0
    Dim TotalCharts As Integer = 0
    Private ScalePosition As Double = 0

    Private MinTime As Double = 0 ' Auto calculated when log file is opened
    Private MaxTime As Double = 0 ' Auto calculated when log file is opened
    Private ChartResetScale As AxisScaleView

#Region "Scrolling"

    Private Sub UpdatePositions()
        ' Update the vertical positions of the chart areas
        Dim Areas_Index As Integer = ChartScrollIndex
        Dim Areas As Integer = Chart.ChartAreas.Count
        If Areas > My.Settings.Chart_MaxChartAreas Then
            Areas = My.Settings.Chart_MaxChartAreas
        End If
        For Index As Integer = 0 To Chart.ChartAreas.Count - 1

            If Areas_Index < 0 Or Areas_Index > My.Settings.Chart_MaxChartAreas Then
                Chart.ChartAreas(Index).Visible = False
            Else
                Chart.ChartAreas(Index).Visible = True
                Chart.ChartAreas(Index).Position = New ElementPosition(0, Areas_Index * 100 / Areas, 100, 100 / Areas)
            End If
            Areas_Index += 1
        Next
    End Sub

    Private Sub VScrollBar_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar.Scroll
        If ChartScrollIndex <> -e.NewValue Then
            ChartScrollIndex = -e.NewValue
            UpdatePositions()
        End If
    End Sub

    Private Sub SyncChartAreas(ByRef ChangedArea As ChartArea)
        For Each Area As ChartArea In Chart.ChartAreas
            ' Dynamically create the grid
            Area.AxisX.LabelStyle.Interval = ScaleSize / My.Settings.Chart_Scale_Interval
            Area.AxisX.MajorGrid.Interval = ScaleSize / My.Settings.Chart_Scale_AxisX_Grids
            Area.AxisX.MajorTickMark.Interval = ScaleSize / My.Settings.Chart_Scale_AxisX_Grids / 2
            If Area IsNot ChangedArea Then
                Area.AxisX.ScaleView.Size = ChangedArea.AxisX.ScaleView.Size
                Area.AxisX.ScaleView.Scroll(ChangedArea.AxisX.ScaleView.Position)
            End If
        Next
        AutoScaleY()
        UpdateScales()
    End Sub

    ' Keep the X-axis scroll aligned between all charts
    Private Sub Chart_AxisViewChanged(sender As Object, e As ViewEventArgs) Handles Chart.AxisViewChanged
        SyncChartAreas(e.ChartArea)
    End Sub

#End Region

#Region "Zooming"

    Private Sub ZoomChart(ByVal Scale As Double, ByVal Position As Double)
        If Not ChartEmpty() Then
            ScaleSize = Scale
            ScalePosition = Position
            Chart.ChartAreas(0).AxisX.ScaleView.Size = ScaleSize
            Chart.ChartAreas(0).AxisX.ScaleView.Position = ScalePosition
            SyncChartAreas(Chart.ChartAreas(0))
            UpdateScales()
            AutoScaleY()
        End If
    End Sub

    ' FIXME: Fix the zooming out when one side is already fully shown
    Private Sub Chart_MouseWheel(sender As Object, e As MouseEventArgs) Handles Chart.MouseWheel

        ' Static variable to help limit the zoom
        Static LastZoomAction As Integer = 0

        ' If there are no chart areas then exit cause we will be using the first chart area to zoom and scroll
        If Chart.ChartAreas.Count <= 0 Then Exit Sub

        With My.Settings
            ' Dynamically calculate how many steps are required to fully zoom in
            Dim StepScaleSize As Double = (MaxScaleSize - .Chart_Scale_MaxZoom) / .Chart_Scale_ZoomSteps
            If (e.Delta > 0) Then
                ' Zoom In
                ' Don't allow further zoom in if we are already in the maximum zoom
                If LastZoomAction = 1 Then Exit Sub Else LastZoomAction = 0
                Dim NewScaleSize As Double = ScaleSize - StepScaleSize
                If NewScaleSize < .Chart_Scale_MaxZoom Then
                    ScaleSize = .Chart_Scale_MaxZoom
                    ' Limit zoom in
                    LastZoomAction = 1
                Else
                    ScaleSize = NewScaleSize
                End If
            ElseIf (e.Delta < 0) Then
                ' Zoom Out
                ' Don't allow further zoom out if we are already in the minimum zoom
                If LastZoomAction = -1 Then Exit Sub Else LastZoomAction = 0
                Dim NewScaleSize As Double = ScaleSize + StepScaleSize
                If NewScaleSize > MaxScaleSize Then
                    ScaleSize = MaxScaleSize
                    ' Limit zoom out
                    LastZoomAction = -1
                Else
                    ScaleSize = NewScaleSize
                End If
            End If

            ' Calculate the new scale size and position for the chart areas

            ' The pre zoom scale (in milliseconds)
            Dim CurrentScale As Double = Chart.ChartAreas(0).AxisX.ScaleView.Size
            ' The relative position of the cursor inside the chart area (in %)
            Dim CursorPosition As Integer = Math.Round(Map(Chart.ChartAreas(0).AxisX.PixelPositionToValue(e.X),
            Chart.ChartAreas(0).AxisX.ScaleView.ViewMinimum, Chart.ChartAreas(0).AxisX.ScaleView.ViewMaximum, 0, 100)) ' Percent
            ' The ratio of the new scale size and the previous scale size
            Dim ScaleSizeRatio As Double = CurrentScale / ScaleSize
            ' The old minimum time of the X-axis (in OLE)
            Dim Min As Double = Chart.ChartAreas(0).AxisX.ScaleView.ViewMinimum
            ' The old maximum time of the X-axis (in OLE)
            Dim Max As Double = Chart.ChartAreas(0).AxisX.ScaleView.ViewMaximum
            ' The time of the pivot point (in OLE) that's based on the cursor position
            Dim Pivot As Double = Map(CursorPosition, 0, 100, Min, Max)
            ' The new minimum time of the X-axis (in OLE)
            Dim NewMin As Double = Min
            ' The new maximum time of the X-axis (in OLE)
            Dim NewMax As Double = Max

            ' Variables to hold the new calculated minimum/maximum views
            Dim _NewSize As Double

            If ScaleSizeRatio > 1 Then
                ' Zoom In

                ' The total percentage of the amount of time that needs to be removed from the new scale (in fraction)
                Dim Multiplier As Double = (1.0 - (ScaleSize / CurrentScale))
                ' The total amount of time that needs to be removed from the new scale (in milliseconds)
                Dim TimeLoss As Double = CurrentScale * Multiplier
                ' The fraction of the Multiplier that needs to be removed from the left of the pivot (in %)
                Dim LeftMultiplier As Double = Map(CursorPosition, 0.0, 100.0, 0.0, 1.0)
                ' The fraction of the Multiplier that needs to be removed from the right of the pivot (in %)
                Dim RightMultiplier As Double = Map(CursorPosition, 0.0, 100.0, 1.0, 0.0)
                ' The amount of time that needs to be removed from each side of the pivot (in milliseconds)
                Dim LeftAmount As Double = TimeLoss * LeftMultiplier
                Dim RightAmount As Double = TimeLoss * RightMultiplier

                ' Calculate the new view minimums/maximums
                NewMin = Min + LeftAmount
                NewMax = Max - RightAmount
                _NewSize = NewMax - NewMin
            Else
                ' Zoom Out

                ' The total percentage of the amount of time that needs to be added to the new scale (in fraction)
                Dim Multiplier As Double = (1.0 - (CurrentScale / ScaleSize))
                ' The total amount of time that needs to be added to the new scale (in seconds)
                Dim TimeGain As Double = CurrentScale * Multiplier
                ' TODO: Maybe invert those two
                ' The fraction of the Multiplier that needs to be added to the left of the pivot (in %)
                Dim LeftMultiplier As Double = Map(CursorPosition, 0.0, 100.0, 1.0, 0.0)
                ' The fraction of the Multiplier that needs to be added to the right of the pivot (in %)
                Dim RightMultiplier As Double = Map(CursorPosition, 0.0, 100.0, 0.0, 1.0)
                ' The amount of time that needs to be removed from each side of the pivot (in milliseconds)
                Dim LeftAmount As Double = TimeGain * LeftMultiplier
                Dim RightAmount As Double = TimeGain * RightMultiplier

                ' Calculate the new view minimums/maximums
                NewMin = Min - LeftAmount
                NewMax = Max + RightAmount
                _NewSize = NewMax - NewMin
            End If

            ' Zoom and scroll the chart
            ScaleSize = Math.Max(_NewSize, 0)
            Chart.ChartAreas(0).AxisX.ScaleView.Size = ScaleSize
            ScalePosition = NewMin
            Chart.ChartAreas(0).AxisX.ScaleView.Scroll(ScalePosition)

            ' Fix the charts
            SyncChartAreas(Chart.ChartAreas(0))
            UpdateScales()
            AutoScaleY()

        End With

    End Sub

#End Region

#Region "Scaling"

    ' Fit all values in the Y-axis
    Private Sub AutoScaleY()
        For Each Area As ChartArea In Chart.ChartAreas
            For Each Series As Series In Chart.Series
                If Series.ChartArea = Area.Name And Series.Enabled Then
                    Dim viewMin As Double = Area.AxisX.ScaleView.ViewMinimum
                    Dim viewMax As Double = Area.AxisX.ScaleView.ViewMaximum
                    Dim min As DataPoint = New DataPoint(0, Double.MaxValue)
                    Dim max As DataPoint = New DataPoint(0, Double.MinValue)
                    'Loop through all points to find min & max
                    For Each dp As DataPoint In Series.Points
                        'Set min & max points only in the range of the view
                        If dp.XValue >= viewMin And dp.XValue <= viewMax Then
                            'Compares Yvalues(0)
                            If dp.YValues(0) > max.YValues(0) Then max = dp
                            If dp.YValues(0) < min.YValues(0) Then min = dp
                        ElseIf dp.XValue >= viewMax Then
                            'Exit for if already past the view
                            Exit For
                        End If
                    Next
                    'How much space you want between axes and zoomed min & max.
                    'A bit tricky as it has to depend on the scale of the zoom.
                    'Feel free to improve the algorithm.
                    Dim buffer As Double = Math.Max(10 ^ Math.Floor(Math.Log10(max.YValues(0) - min.YValues(0))) / 10, 1)
                    Area.AxisY.Minimum = min.YValues(0) - buffer
                    Area.AxisY.Maximum = max.YValues(0) + buffer
                End If
            Next
        Next
    End Sub

#End Region

    ' Show the chart X-axis scale and grid/selection size in the status bar
    Private Sub UpdateScales()

        If Chart.ChartAreas.Count > 0 Then
            ' ScaleSize is measured in milliseconds

            ToolStripStatusLabel_Scale.Text = "Window Size: "
            If ScaleSize > 60000 Then
                ToolStripStatusLabel_Scale.Text &= (ScaleSize / 60000.0).ToString("F1") & " min, "
            ElseIf ScaleSize > 1000 Then
                ToolStripStatusLabel_Scale.Text &= (ScaleSize / 1000.0).ToString("F1") & " sec, "
            Else
                ToolStripStatusLabel_Scale.Text &= ScaleSize.ToString("F0") & " msec, "
            End If

            ToolStripStatusLabel_Scale.Text &= "Grid Size: "
            If (ScaleSize / My.Settings.Chart_Scale_AxisX_Grids) > 60000 Then
                ToolStripStatusLabel_Scale.Text &= (ScaleSize / My.Settings.Chart_Scale_AxisX_Grids / 60000.0).ToString("F1") & " min"
            ElseIf (ScaleSize / My.Settings.Chart_Scale_AxisX_Grids) > 1000 Then
                ToolStripStatusLabel_Scale.Text &= (ScaleSize / My.Settings.Chart_Scale_AxisX_Grids / 1000.0).ToString("F1") & " sec"
            Else
                ToolStripStatusLabel_Scale.Text &= (ScaleSize / My.Settings.Chart_Scale_AxisX_Grids).ToString("F0") & " msec"
            End If

            Dim SelectionLength As Double = SelectionSize()
            If SelectionLength = 0 Then Exit Sub

            ToolStripStatusLabel_Scale.Text &= ", Selection Size: "

            If SelectionLength > 60000 Then
                ToolStripStatusLabel_Scale.Text &= (SelectionLength / 60000.0).ToString("F1") & " min"
            ElseIf SelectionLength > 1000 Then
                ToolStripStatusLabel_Scale.Text &= (SelectionLength / 1000.0).ToString("F1") & " sec"
            Else
                ToolStripStatusLabel_Scale.Text &= SelectionLength.ToString("F") & " msec"
            End If

        End If

    End Sub

    Public Sub DataUpdated()
        KeepScale = True
        UpdateChart()
        KeepScale = False
    End Sub

#End Region

#Region "Chart Gestures"

    ' Variables to handle the cursor selection
    Private Selecting As Boolean = False
    Private SelectionStart As Integer = Nothing
    Private SelectionEnd As Integer = Nothing
    Dim CursorPosition As Point

    ' Cursor selection changing
    Private Sub Chart_SelectionRangeChanging(sender As Object, e As CursorEventArgs) Handles Chart.SelectionRangeChanging
        ' Start displaying the selection range instead of the chart values
        Selecting = True
        SelectionStart = e.NewSelectionStart
        SelectionEnd = e.NewSelectionEnd
        ' Sync selection between charts
        For Each Area As ChartArea In Chart.ChartAreas
            If Area IsNot e.ChartArea Then
                Area.CursorX.SelectionStart = e.NewSelectionStart
                Area.CursorX.SelectionEnd = e.NewSelectionEnd
            End If
        Next
    End Sub

    ' Cursor selection changed
    Private Sub Chart_SelectionRangeChanged(sender As Object, e As CursorEventArgs) Handles Chart.SelectionRangeChanged
        UpdateScales()
        AutoScaleY()
        ' Stop displaying the selection range instead of the chart values
        Selecting = False
    End Sub

    ' Hide the tooltip when the cursor is not inside the chart
    Private Sub Chart_MouseLeave(sender As Object, e As EventArgs) Handles Chart.MouseLeave
        ToolTip.Hide(Chart)
    End Sub

    Private Sub Chart_MouseMove(sender As Object, e As MouseEventArgs) Handles Chart.MouseMove
        Static LastFire As DateTime = Now()
        Dim Interval As Integer = 1000 / If(My.Settings.Chart_LimitCPU, 24, 60)

        ' Limit the frequency of the event to reduce CPU usage
        If Now.Subtract(LastFire).TotalMilliseconds < Interval Then Exit Sub
        LastFire = Now()

        ' Limit the minimum cursor movement before triggering to reduce flicker
        Static LastX = MousePosition.X
        Static LastY = MousePosition.Y
        Dim MinimumMove As Integer = If(My.Settings.Chart_LimitFlicker, 3, 1)
        If Math.Sqrt(Math.Pow(LastX - MousePosition.X, 2) + Math.Pow(LastY - MousePosition.Y, 2))<MinimumMove Then Exit Sub
        LastX= MousePosition.X
        LastY= MousePosition.Y

        ' Only execute when there are charts drawn
        If Chart.ChartAreas.Count > 0 Then

            Dim Values As String = ""

            ' If cursor is selecting then show the selection range
            If Selecting Then
                Values = "Selection Start: " & SelectionStart.ToString("F0") & " ms" & vbNewLine
                Values &= "Selection End: " & SelectionEnd.ToString("F0") & " ms" & vbNewLine
                Dim Length As Double = Math.Abs(SelectionEnd - SelectionStart)
                Values &= "Selection Length: "
                If Length > 60000 Then
                    Values &= (Length / 60000.0).ToString("F1") & " min"
                ElseIf Length > 1000 Then
                    Values &= (Length / 1000.0).ToString("F1") & " sec"
                Else
                    Values &= Length.ToString("F0") & " msec"
                End If
            Else
                Dim FirstAreaOnly As Boolean = False
                Dim XValue As Double = -1
                Dim Point As New DataPoint
                Dim PointTime As New Double 'DateTime

                ' For all chart areas
                For Each Area As ChartArea In Chart.ChartAreas

                    ' Draw the cursor
                    Try
                        Area.CursorX.SetCursorPixelPosition(e.Location, True)
                        'Area.CursorY.SetCursorPixelPosition(e.Location, True)
                        CursorPosition = e.Location
                    Catch ex As Exception
                        Continue For
                    End Try

                    ' Get the X-axis value based on the cursor position
                    If Not FirstAreaOnly Then
                        Try
                            XValue = Area.AxisX.PixelPositionToValue(e.X)
                        Catch ex As Exception
                            Exit Sub
                        End Try
                    End If

                    ' The series on the specific area
                    Dim Series As Series = Chart.Series(Area.Name.Replace("ChartArea_", "Series_"))

                    ' Find the point closest to the X-axis value
                    Point = ClosestPoint(Series.Points, XValue)
                    If Not FirstAreaOnly Then
                        PointTime = Point.XValue
                        FirstAreaOnly = True
                    End If

                    ' Append the values to the tooltip text
                    Values &= (Series.Name.Replace("Series_", "") & ":").PadRight(20, " ")
                    Values &= "(" & PointTime & " ms, " & Point.YValues(0) & ")" & vbNewLine

                Next

            End If

            ToolTip.Show(Values, Chart, New Point(e.X + 15, e.Y))
        End If
    End Sub

#End Region

#Region "Series Selection"

#Region "AutoHiding CheckedListBox"

    Private Sub Label_Series_MouseEnter(sender As Object, e As EventArgs) Handles Label_Series.MouseEnter
        CheckedListBox.Visible = True
        Timer_SeriesHide.Start()
    End Sub

    Private Sub Timer_SeriesHide_Tick(sender As Object, e As EventArgs) Handles Timer_SeriesHide.Tick
        CheckedListBox.Visible = False
        Timer_SeriesHide.Stop()
    End Sub

    Private Sub CheckedListBox_MouseEnter(sender As Object, e As EventArgs) Handles CheckedListBox.MouseEnter
        Timer_SeriesHide.Stop()
    End Sub

    Private Sub CheckedListBox_MouseLeave(sender As Object, e As EventArgs) Handles CheckedListBox.MouseLeave
        Timer_SeriesHide.Start()
    End Sub

#End Region

    Private Sub CheckedListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBox.SelectedIndexChanged
        ' Activate the chart update timer
        Timer_ChartUpdate.Stop()
        Timer_ChartUpdate.Start()
    End Sub

    Private Sub Timer_ChartUpdate_Tick(sender As Object, e As EventArgs) Handles Timer_ChartUpdate.Tick
        ' Update the charts and stop the timer
        Timer_ChartUpdate.Stop()
        UpdateChart()
    End Sub

#End Region

#Region "Menu"

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        OpenFileDialog.ShowDialog()
    End Sub

    Private Sub PictureBox_LoadLog_Click(sender As Object, e As EventArgs) Handles PictureBox_LoadLog.Click
        OpenFileDialog.ShowDialog()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.Show()
    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        Dim _Report As New Report
        _Report.ShowDialog()
        _Report.Dispose()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim Splash As New AboutBox
        Splash.ShowDialog()
        Splash.Dispose()
    End Sub

    Private Sub ShowLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowLogToolStripMenuItem.Click
        If IO.File.Exists(Log.Path) = True Then Process.Start(Log.Path)
    End Sub

#End Region

#Region "Debug"

    Private Sub Label_Breakpoint_Click(sender As Object, e As EventArgs) Handles Label_Breakpoint.Click
        Dim X As Integer = 0
        X = 1
    End Sub

#End Region

#Region "Chart Menu"

    Private Function SelectionSize() As Double
        If Double.IsNaN(Chart.ChartAreas(0).CursorX.SelectionEnd()) Or Double.IsNaN(Chart.ChartAreas(0).CursorX.SelectionStart) Then
            Return 0
        End If
        Dim SelectionLength As Double = Math.Abs(Chart.ChartAreas(0).CursorX.SelectionEnd - Chart.ChartAreas(0).CursorX.SelectionStart)
        Return SelectionLength
    End Function

    Private Sub ResetScaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetScaleToolStripMenuItem.Click
        ZoomChart(LogFileLength, LogFile(1).Split(LogDelimiter)(0))
    End Sub

    Private Sub ZoomToSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomToSelectionToolStripMenuItem.Click
        If ChartEmpty() Then Exit Sub
        If Double.IsNaN(Chart.ChartAreas(0).CursorX.SelectionStart) Or Double.IsNaN(Chart.ChartAreas(0).CursorX.SelectionEnd) Then Exit Sub
        ZoomChart(SelectionSize, Math.Min(Chart.ChartAreas(0).CursorX.SelectionStart, Chart.ChartAreas(0).CursorX.SelectionEnd))
    End Sub

    Private Sub HideLegendsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideLegendsToolStripMenuItem.Click
        If HideLegendsToolStripMenuItem.Text = "Hide Legends" Then
            For Each Legend As Legend In Chart.Legends
                Legend.Enabled = False
            Next
            HideLegendsToolStripMenuItem.Text = "Show Legends"
        Else
            For Each Legend As Legend In Chart.Legends
                Legend.Enabled = True
            Next
            HideLegendsToolStripMenuItem.Text = "Hide Legends"
        End If
    End Sub

    Private Sub HideAnnotationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HideAnnotationsToolStripMenuItem.Click
        If HideAnnotationsToolStripMenuItem.Text = "Hide Annotations" Then
            ToolTip.Active = False
            HideAnnotationsToolStripMenuItem.Text = "Show Annotations"
        Else
            ToolTip.Active = True
            HideAnnotationsToolStripMenuItem.Text = "Hide Annotations"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Chart.Series(1).ChartArea = Chart.ChartAreas(0).Name
    End Sub

    Private Sub TrimToSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrimToSelectionToolStripMenuItem.Click
        TrimLog()
    End Sub

    Private Sub DataEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataEditorToolStripMenuItem.Click
        If LogFile IsNot Nothing And LogHeaders IsNot Nothing Then DataEditor.Show()
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        SaveFileDialog.FileName = LogPath.Substring(LogPath.LastIndexOf("\") + 1)
        SaveFileDialog.ShowDialog()
    End Sub

#End Region

#Region "Data Editing"

    Private Sub TrimLog()
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to trim the log file? This will discard all values that are not in the selected range.", "Trim log file", MessageBoxButtons.OKCancel)
        If result = DialogResult.OK Then
            If SelectionStart > 0 And SelectionEnd > 0 Then
                If Math.Abs(SelectionEnd - SelectionStart) > 500 Then ' At least 500ms
                    Dim TrimFrom As Integer = Math.Min(SelectionStart, SelectionEnd)
                    Dim TrimTo As Integer = Math.Max(SelectionStart, SelectionEnd)
                    Dim NewLog As New List(Of String)
                    LogHeaders(0) = "vtime"
                    NewLog.Add(String.Join(FirstLogDelimiter, LogHeaders))
                    For Index As Integer = 1 To LogFile.Count - 1
                        Dim Line As String() = LogFile(Index).Split(LogDelimiter)
                        If Line(0) >= TrimFrom And Line(0) <= TrimTo Then
                            Line(0) -= TrimFrom
                            NewLog.Add(String.Join(FirstLogDelimiter, Line))
                        End If
                    Next
                    LogFile = NewLog.ToArray()
                    CheckLogFile()
                    AnalyzeLogFile()
                End If
            End If
        End If
    End Sub

#End Region

    Private Sub Test()

    End Sub

    Private Sub ExportImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportImageToolStripMenuItem.Click
        ImageExportDialog.ShowDialog()
    End Sub

    Private Sub ImageExportDialog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ImageExportDialog.FileOk
        Dim bmp As New Bitmap(Chart.Width, Chart.Height)
        Chart.DrawToBitmap(bmp, Chart.DisplayRectangle)
        bmp.Save(ImageExportDialog.FileName, System.Drawing.Imaging.ImageFormat.Png)
    End Sub

    'Private Sub Chart_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    '    Select Case e.KeyCode
    '        Case Keys.Left

    '            CursorPosition.X -= 1
    '            If CursorPosition.X < 0 Then
    '                CursorPosition.X = 0
    '            End If

    '            For Each Area As ChartArea In Chart.ChartAreas
    '                Try
    '                    Area.CursorX.SetCursorPixelPosition(CursorPosition, True)
    '                Catch ex As Exception
    '                    Continue For
    '                End Try

    '            Next

    '        Case Keys.Right

    '        Case Keys.Up

    '        Case Keys.Down

    '    End Select
    'End Sub

End Class