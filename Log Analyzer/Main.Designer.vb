<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Chart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ContextMenuStrip_Chart = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ResetScaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ZoomToSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.HideLegendsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideAnnotationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditAreasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.VScrollBar = New System.Windows.Forms.VScrollBar()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel_Scale = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel_LogFile = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer_ChartUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_SeriesHide = New System.Windows.Forms.Timer(Me.components)
        Me.Label_Series = New System.Windows.Forms.Label()
        Me.Label_Breakpoint = New System.Windows.Forms.Label()
        Me.PictureBox_LoadLog = New System.Windows.Forms.PictureBox()
        Me.DataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip_Chart.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.PictureBox_LoadLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart
        '
        Me.Chart.ContextMenuStrip = Me.ContextMenuStrip_Chart
        Me.Chart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart.Location = New System.Drawing.Point(0, 24)
        Me.Chart.Name = "Chart"
        Me.Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry
        Me.Chart.Size = New System.Drawing.Size(611, 438)
        Me.Chart.TabIndex = 0
        Me.Chart.Text = " "
        '
        'ContextMenuStrip_Chart
        '
        Me.ContextMenuStrip_Chart.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip_Chart.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResetScaleToolStripMenuItem, Me.ToolStripSeparator1, Me.ZoomToSelectionToolStripMenuItem, Me.ToolStripSeparator2, Me.HideLegendsToolStripMenuItem, Me.HideAnnotationsToolStripMenuItem, Me.ToolStripSeparator3, Me.EditAreasToolStripMenuItem})
        Me.ContextMenuStrip_Chart.Name = "ContextMenuStrip_Chart"
        Me.ContextMenuStrip_Chart.Size = New System.Drawing.Size(174, 132)
        '
        'ResetScaleToolStripMenuItem
        '
        Me.ResetScaleToolStripMenuItem.Name = "ResetScaleToolStripMenuItem"
        Me.ResetScaleToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ResetScaleToolStripMenuItem.Text = "Reset Scale"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(170, 6)
        '
        'ZoomToSelectionToolStripMenuItem
        '
        Me.ZoomToSelectionToolStripMenuItem.Name = "ZoomToSelectionToolStripMenuItem"
        Me.ZoomToSelectionToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ZoomToSelectionToolStripMenuItem.Text = "Zoom To Selection"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(170, 6)
        '
        'HideLegendsToolStripMenuItem
        '
        Me.HideLegendsToolStripMenuItem.Name = "HideLegendsToolStripMenuItem"
        Me.HideLegendsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.HideLegendsToolStripMenuItem.Text = "Hide Legends"
        '
        'HideAnnotationsToolStripMenuItem
        '
        Me.HideAnnotationsToolStripMenuItem.Name = "HideAnnotationsToolStripMenuItem"
        Me.HideAnnotationsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.HideAnnotationsToolStripMenuItem.Text = "Hide Annotations"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(170, 6)
        '
        'EditAreasToolStripMenuItem
        '
        Me.EditAreasToolStripMenuItem.Name = "EditAreasToolStripMenuItem"
        Me.EditAreasToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.EditAreasToolStripMenuItem.Text = "Edit Areas"
        '
        'CheckedListBox
        '
        Me.CheckedListBox.CheckOnClick = True
        Me.CheckedListBox.Dock = System.Windows.Forms.DockStyle.Right
        Me.CheckedListBox.FormattingEnabled = True
        Me.CheckedListBox.Location = New System.Drawing.Point(631, 24)
        Me.CheckedListBox.Name = "CheckedListBox"
        Me.CheckedListBox.Size = New System.Drawing.Size(126, 438)
        Me.CheckedListBox.TabIndex = 1
        Me.CheckedListBox.Visible = False
        '
        'MenuStrip
        '
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(757, 24)
        Me.MenuStrip.TabIndex = 3
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.DataToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.Filter = "Log Files|*.txt|All Files|*.*"
        Me.OpenFileDialog.Title = "Open a log file..."
        '
        'VScrollBar
        '
        Me.VScrollBar.Dock = System.Windows.Forms.DockStyle.Right
        Me.VScrollBar.LargeChange = 1
        Me.VScrollBar.Location = New System.Drawing.Point(611, 24)
        Me.VScrollBar.Maximum = 0
        Me.VScrollBar.Name = "VScrollBar"
        Me.VScrollBar.Size = New System.Drawing.Size(20, 438)
        Me.VScrollBar.TabIndex = 6
        '
        'ToolTip
        '
        Me.ToolTip.AutomaticDelay = 100
        '
        'StatusStrip
        '
        Me.StatusStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_Scale, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel_LogFile})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 462)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(757, 22)
        Me.StatusStrip.TabIndex = 26
        '
        'ToolStripStatusLabel_Scale
        '
        Me.ToolStripStatusLabel_Scale.Name = "ToolStripStatusLabel_Scale"
        Me.ToolStripStatusLabel_Scale.Size = New System.Drawing.Size(292, 17)
        Me.ToolStripStatusLabel_Scale.Text = "Window Size: NaN, Grid Size: NaN, Selection Size: NaN"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(388, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'ToolStripStatusLabel_LogFile
        '
        Me.ToolStripStatusLabel_LogFile.Name = "ToolStripStatusLabel_LogFile"
        Me.ToolStripStatusLabel_LogFile.Size = New System.Drawing.Size(62, 17)
        Me.ToolStripStatusLabel_LogFile.Text = "No log file"
        '
        'Timer_ChartUpdate
        '
        Me.Timer_ChartUpdate.Interval = 1000
        '
        'Timer_SeriesHide
        '
        Me.Timer_SeriesHide.Enabled = True
        Me.Timer_SeriesHide.Interval = 3000
        '
        'Label_Series
        '
        Me.Label_Series.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Series.AutoSize = True
        Me.Label_Series.Location = New System.Drawing.Point(691, 11)
        Me.Label_Series.Name = "Label_Series"
        Me.Label_Series.Size = New System.Drawing.Size(66, 13)
        Me.Label_Series.TabIndex = 27
        Me.Label_Series.Text = "Show Series"
        '
        'Label_Breakpoint
        '
        Me.Label_Breakpoint.AutoSize = True
        Me.Label_Breakpoint.Location = New System.Drawing.Point(513, 8)
        Me.Label_Breakpoint.Name = "Label_Breakpoint"
        Me.Label_Breakpoint.Size = New System.Drawing.Size(35, 13)
        Me.Label_Breakpoint.TabIndex = 28
        Me.Label_Breakpoint.Text = "Break"
        Me.Label_Breakpoint.Visible = False
        '
        'PictureBox_LoadLog
        '
        Me.PictureBox_LoadLog.BackColor = System.Drawing.Color.White
        Me.PictureBox_LoadLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_LoadLog.Image = Global.Log_Analyzer.My.Resources.Resources.open_file
        Me.PictureBox_LoadLog.Location = New System.Drawing.Point(0, 24)
        Me.PictureBox_LoadLog.Name = "PictureBox_LoadLog"
        Me.PictureBox_LoadLog.Size = New System.Drawing.Size(611, 438)
        Me.PictureBox_LoadLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox_LoadLog.TabIndex = 29
        Me.PictureBox_LoadLog.TabStop = False
        '
        'DataToolStripMenuItem
        '
        Me.DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        Me.DataToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DataToolStripMenuItem.Text = "Data"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 484)
        Me.Controls.Add(Me.PictureBox_LoadLog)
        Me.Controls.Add(Me.Label_Breakpoint)
        Me.Controls.Add(Me.Chart)
        Me.Controls.Add(Me.VScrollBar)
        Me.Controls.Add(Me.Label_Series)
        Me.Controls.Add(Me.CheckedListBox)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "Main"
        Me.Text = "UoP Racing - Log Analyzer"
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip_Chart.ResumeLayout(False)
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.PictureBox_LoadLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Chart As DataVisualization.Charting.Chart
    Friend WithEvents CheckedListBox As CheckedListBox
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents VScrollBar As VScrollBar
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents Timer_ChartUpdate As Timer
    Friend WithEvents Timer_SeriesHide As Timer
    Friend WithEvents Label_Series As Label
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel_Scale As ToolStripStatusLabel
    Friend WithEvents Label_Breakpoint As Label
    Friend WithEvents ContextMenuStrip_Chart As ContextMenuStrip
    Friend WithEvents ResetScaleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ZoomToSelectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents HideLegendsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel_LogFile As ToolStripStatusLabel
    Friend WithEvents HideAnnotationsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents EditAreasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox_LoadLog As PictureBox
    Friend WithEvents DataToolStripMenuItem As ToolStripMenuItem
End Class
