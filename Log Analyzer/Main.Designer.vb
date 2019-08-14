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
        Me.CheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.VScrollBar = New System.Windows.Forms.VScrollBar()
        Me.CheckBox_Plotting_Sync = New System.Windows.Forms.CheckBox()
        Me.CheckBox_AutoScale = New System.Windows.Forms.CheckBox()
        Me.CheckBox_ShowLegends = New System.Windows.Forms.CheckBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.CheckBox_ShowValues = New System.Windows.Forms.CheckBox()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel_Scale = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer_ChartUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_SeriesHide = New System.Windows.Forms.Timer(Me.components)
        Me.Label_Series = New System.Windows.Forms.Label()
        Me.Label_Breakpoint = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart
        '
        Me.Chart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Chart.Location = New System.Drawing.Point(0, 24)
        Me.Chart.Name = "Chart"
        Me.Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry
        Me.Chart.Size = New System.Drawing.Size(611, 438)
        Me.Chart.TabIndex = 0
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
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem})
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
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
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
        'CheckBox_Plotting_Sync
        '
        Me.CheckBox_Plotting_Sync.AutoSize = True
        Me.CheckBox_Plotting_Sync.Checked = True
        Me.CheckBox_Plotting_Sync.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_Plotting_Sync.Location = New System.Drawing.Point(84, 5)
        Me.CheckBox_Plotting_Sync.Name = "CheckBox_Plotting_Sync"
        Me.CheckBox_Plotting_Sync.Size = New System.Drawing.Size(50, 17)
        Me.CheckBox_Plotting_Sync.TabIndex = 19
        Me.CheckBox_Plotting_Sync.Text = "Sync"
        Me.CheckBox_Plotting_Sync.UseVisualStyleBackColor = True
        '
        'CheckBox_AutoScale
        '
        Me.CheckBox_AutoScale.AutoSize = True
        Me.CheckBox_AutoScale.Checked = True
        Me.CheckBox_AutoScale.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_AutoScale.Location = New System.Drawing.Point(140, 5)
        Me.CheckBox_AutoScale.Name = "CheckBox_AutoScale"
        Me.CheckBox_AutoScale.Size = New System.Drawing.Size(78, 17)
        Me.CheckBox_AutoScale.TabIndex = 18
        Me.CheckBox_AutoScale.Text = "Auto Scale"
        Me.CheckBox_AutoScale.UseVisualStyleBackColor = True
        '
        'CheckBox_ShowLegends
        '
        Me.CheckBox_ShowLegends.AutoSize = True
        Me.CheckBox_ShowLegends.Checked = True
        Me.CheckBox_ShowLegends.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_ShowLegends.Location = New System.Drawing.Point(224, 5)
        Me.CheckBox_ShowLegends.Name = "CheckBox_ShowLegends"
        Me.CheckBox_ShowLegends.Size = New System.Drawing.Size(67, 17)
        Me.CheckBox_ShowLegends.TabIndex = 22
        Me.CheckBox_ShowLegends.Text = "Legends"
        Me.CheckBox_ShowLegends.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.AutomaticDelay = 100
        '
        'CheckBox_ShowValues
        '
        Me.CheckBox_ShowValues.AutoSize = True
        Me.CheckBox_ShowValues.Checked = True
        Me.CheckBox_ShowValues.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_ShowValues.Location = New System.Drawing.Point(297, 5)
        Me.CheckBox_ShowValues.Name = "CheckBox_ShowValues"
        Me.CheckBox_ShowValues.Size = New System.Drawing.Size(58, 17)
        Me.CheckBox_ShowValues.TabIndex = 25
        Me.CheckBox_ShowValues.Text = "Values"
        Me.CheckBox_ShowValues.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel_Scale})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 462)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(757, 22)
        Me.StatusStrip.TabIndex = 26
        '
        'ToolStripStatusLabel_Scale
        '
        Me.ToolStripStatusLabel_Scale.Name = "ToolStripStatusLabel_Scale"
        Me.ToolStripStatusLabel_Scale.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabel_Scale.Text = "Scale Size: , Grid Size: "
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
        Me.Label_Breakpoint.Location = New System.Drawing.Point(546, 6)
        Me.Label_Breakpoint.Name = "Label_Breakpoint"
        Me.Label_Breakpoint.Size = New System.Drawing.Size(35, 13)
        Me.Label_Breakpoint.TabIndex = 28
        Me.Label_Breakpoint.Text = "Break"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(437, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 484)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label_Breakpoint)
        Me.Controls.Add(Me.Chart)
        Me.Controls.Add(Me.VScrollBar)
        Me.Controls.Add(Me.Label_Series)
        Me.Controls.Add(Me.CheckedListBox)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.CheckBox_ShowValues)
        Me.Controls.Add(Me.CheckBox_ShowLegends)
        Me.Controls.Add(Me.CheckBox_Plotting_Sync)
        Me.Controls.Add(Me.CheckBox_AutoScale)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "Main"
        Me.Text = "UoP Racing - Log Analyzer"
        CType(Me.Chart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
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
    Friend WithEvents CheckBox_Plotting_Sync As CheckBox
    Friend WithEvents CheckBox_AutoScale As CheckBox
    Friend WithEvents CheckBox_ShowLegends As CheckBox
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents CheckBox_ShowValues As CheckBox
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents Timer_ChartUpdate As Timer
    Friend WithEvents Timer_SeriesHide As Timer
    Friend WithEvents Label_Series As Label
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel_Scale As ToolStripStatusLabel
    Friend WithEvents Label_Breakpoint As Label
    Friend WithEvents Button1 As Button
End Class
