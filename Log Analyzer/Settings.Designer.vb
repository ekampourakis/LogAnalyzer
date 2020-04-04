<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.Label_MaxZoom = New System.Windows.Forms.Label()
        Me.Label_ZoomSteps = New System.Windows.Forms.Label()
        Me.Label_ScaleInterval = New System.Windows.Forms.Label()
        Me.Label_XGrids = New System.Windows.Forms.Label()
        Me.Label_MaxAreas = New System.Windows.Forms.Label()
        Me.TrackBar_ZoomSteps = New System.Windows.Forms.TrackBar()
        Me.TrackBar_ScaleInterval = New System.Windows.Forms.TrackBar()
        Me.TrackBar_XGrids = New System.Windows.Forms.TrackBar()
        Me.TrackBar_MaxAreas = New System.Windows.Forms.TrackBar()
        Me.TrackBar_MaxZoom = New System.Windows.Forms.TrackBar()
        Me.Button_ResetDefaults = New System.Windows.Forms.Button()
        Me.Button_Reload = New System.Windows.Forms.Button()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.Label_SeriesType = New System.Windows.Forms.Label()
        Me.ComboBox_SeriesType = New System.Windows.Forms.ComboBox()
        Me.TrackBar_BorderSize = New System.Windows.Forms.TrackBar()
        Me.Label_BorderSize = New System.Windows.Forms.Label()
        Me.CheckBox_LimitCPU = New System.Windows.Forms.CheckBox()
        Me.CheckBox_ReduceFlicker = New System.Windows.Forms.CheckBox()
        Me.CheckBox_ZeroLine = New System.Windows.Forms.CheckBox()
        CType(Me.TrackBar_ZoomSteps, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_ScaleInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_XGrids, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_MaxAreas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_MaxZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_BorderSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label_MaxZoom
        '
        Me.Label_MaxZoom.AutoSize = True
        Me.Label_MaxZoom.Location = New System.Drawing.Point(9, 9)
        Me.Label_MaxZoom.Name = "Label_MaxZoom"
        Me.Label_MaxZoom.Size = New System.Drawing.Size(84, 13)
        Me.Label_MaxZoom.TabIndex = 0
        Me.Label_MaxZoom.Text = "Maximum Zoom:"
        '
        'Label_ZoomSteps
        '
        Me.Label_ZoomSteps.AutoSize = True
        Me.Label_ZoomSteps.Location = New System.Drawing.Point(9, 73)
        Me.Label_ZoomSteps.Name = "Label_ZoomSteps"
        Me.Label_ZoomSteps.Size = New System.Drawing.Size(67, 13)
        Me.Label_ZoomSteps.TabIndex = 1
        Me.Label_ZoomSteps.Text = "Zoom Steps:"
        '
        'Label_ScaleInterval
        '
        Me.Label_ScaleInterval.AutoSize = True
        Me.Label_ScaleInterval.Location = New System.Drawing.Point(9, 137)
        Me.Label_ScaleInterval.Name = "Label_ScaleInterval"
        Me.Label_ScaleInterval.Size = New System.Drawing.Size(75, 13)
        Me.Label_ScaleInterval.TabIndex = 2
        Me.Label_ScaleInterval.Text = "Scale Interval:"
        '
        'Label_XGrids
        '
        Me.Label_XGrids.AutoSize = True
        Me.Label_XGrids.Location = New System.Drawing.Point(9, 201)
        Me.Label_XGrids.Name = "Label_XGrids"
        Me.Label_XGrids.Size = New System.Drawing.Size(44, 13)
        Me.Label_XGrids.TabIndex = 3
        Me.Label_XGrids.Text = "X Grids:"
        '
        'Label_MaxAreas
        '
        Me.Label_MaxAreas.AutoSize = True
        Me.Label_MaxAreas.Location = New System.Drawing.Point(9, 265)
        Me.Label_MaxAreas.Name = "Label_MaxAreas"
        Me.Label_MaxAreas.Size = New System.Drawing.Size(84, 13)
        Me.Label_MaxAreas.TabIndex = 4
        Me.Label_MaxAreas.Text = "Maximum Areas:"
        '
        'TrackBar_ZoomSteps
        '
        Me.TrackBar_ZoomSteps.Location = New System.Drawing.Point(12, 89)
        Me.TrackBar_ZoomSteps.Maximum = 30
        Me.TrackBar_ZoomSteps.Minimum = 10
        Me.TrackBar_ZoomSteps.Name = "TrackBar_ZoomSteps"
        Me.TrackBar_ZoomSteps.Size = New System.Drawing.Size(229, 45)
        Me.TrackBar_ZoomSteps.TabIndex = 5
        Me.TrackBar_ZoomSteps.Value = 20
        '
        'TrackBar_ScaleInterval
        '
        Me.TrackBar_ScaleInterval.Location = New System.Drawing.Point(12, 153)
        Me.TrackBar_ScaleInterval.Minimum = 1
        Me.TrackBar_ScaleInterval.Name = "TrackBar_ScaleInterval"
        Me.TrackBar_ScaleInterval.Size = New System.Drawing.Size(229, 45)
        Me.TrackBar_ScaleInterval.TabIndex = 6
        Me.TrackBar_ScaleInterval.Value = 5
        '
        'TrackBar_XGrids
        '
        Me.TrackBar_XGrids.Location = New System.Drawing.Point(12, 217)
        Me.TrackBar_XGrids.Maximum = 25
        Me.TrackBar_XGrids.Minimum = 5
        Me.TrackBar_XGrids.Name = "TrackBar_XGrids"
        Me.TrackBar_XGrids.Size = New System.Drawing.Size(229, 45)
        Me.TrackBar_XGrids.TabIndex = 7
        Me.TrackBar_XGrids.Value = 15
        '
        'TrackBar_MaxAreas
        '
        Me.TrackBar_MaxAreas.Location = New System.Drawing.Point(12, 281)
        Me.TrackBar_MaxAreas.Minimum = 1
        Me.TrackBar_MaxAreas.Name = "TrackBar_MaxAreas"
        Me.TrackBar_MaxAreas.Size = New System.Drawing.Size(229, 45)
        Me.TrackBar_MaxAreas.TabIndex = 8
        Me.TrackBar_MaxAreas.Value = 6
        '
        'TrackBar_MaxZoom
        '
        Me.TrackBar_MaxZoom.LargeChange = 100
        Me.TrackBar_MaxZoom.Location = New System.Drawing.Point(12, 25)
        Me.TrackBar_MaxZoom.Maximum = 1000
        Me.TrackBar_MaxZoom.Minimum = 100
        Me.TrackBar_MaxZoom.Name = "TrackBar_MaxZoom"
        Me.TrackBar_MaxZoom.Size = New System.Drawing.Size(229, 45)
        Me.TrackBar_MaxZoom.SmallChange = 20
        Me.TrackBar_MaxZoom.TabIndex = 9
        Me.TrackBar_MaxZoom.TickFrequency = 100
        Me.TrackBar_MaxZoom.Value = 500
        '
        'Button_ResetDefaults
        '
        Me.Button_ResetDefaults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_ResetDefaults.Location = New System.Drawing.Point(383, 286)
        Me.Button_ResetDefaults.Name = "Button_ResetDefaults"
        Me.Button_ResetDefaults.Size = New System.Drawing.Size(93, 23)
        Me.Button_ResetDefaults.TabIndex = 10
        Me.Button_ResetDefaults.Text = "Reset Defaults"
        Me.Button_ResetDefaults.UseVisualStyleBackColor = True
        '
        'Button_Reload
        '
        Me.Button_Reload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Reload.Location = New System.Drawing.Point(383, 315)
        Me.Button_Reload.Name = "Button_Reload"
        Me.Button_Reload.Size = New System.Drawing.Size(93, 23)
        Me.Button_Reload.TabIndex = 11
        Me.Button_Reload.Text = "Reload Settings"
        Me.Button_Reload.UseVisualStyleBackColor = True
        '
        'Button_Save
        '
        Me.Button_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_Save.Enabled = False
        Me.Button_Save.Location = New System.Drawing.Point(383, 344)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(93, 23)
        Me.Button_Save.TabIndex = 12
        Me.Button_Save.Text = "Save"
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'Label_SeriesType
        '
        Me.Label_SeriesType.AutoSize = True
        Me.Label_SeriesType.Location = New System.Drawing.Point(9, 329)
        Me.Label_SeriesType.Name = "Label_SeriesType"
        Me.Label_SeriesType.Size = New System.Drawing.Size(66, 13)
        Me.Label_SeriesType.TabIndex = 13
        Me.Label_SeriesType.Text = "Series Type:"
        '
        'ComboBox_SeriesType
        '
        Me.ComboBox_SeriesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_SeriesType.FormattingEnabled = True
        Me.ComboBox_SeriesType.Items.AddRange(New Object() {"Line", "Point"})
        Me.ComboBox_SeriesType.Location = New System.Drawing.Point(12, 345)
        Me.ComboBox_SeriesType.Name = "ComboBox_SeriesType"
        Me.ComboBox_SeriesType.Size = New System.Drawing.Size(229, 21)
        Me.ComboBox_SeriesType.TabIndex = 14
        '
        'TrackBar_BorderSize
        '
        Me.TrackBar_BorderSize.LargeChange = 10
        Me.TrackBar_BorderSize.Location = New System.Drawing.Point(247, 25)
        Me.TrackBar_BorderSize.Maximum = 50
        Me.TrackBar_BorderSize.Minimum = 10
        Me.TrackBar_BorderSize.Name = "TrackBar_BorderSize"
        Me.TrackBar_BorderSize.Size = New System.Drawing.Size(229, 45)
        Me.TrackBar_BorderSize.SmallChange = 5
        Me.TrackBar_BorderSize.TabIndex = 16
        Me.TrackBar_BorderSize.TickFrequency = 5
        Me.TrackBar_BorderSize.Value = 30
        '
        'Label_BorderSize
        '
        Me.Label_BorderSize.AutoSize = True
        Me.Label_BorderSize.Location = New System.Drawing.Point(244, 9)
        Me.Label_BorderSize.Name = "Label_BorderSize"
        Me.Label_BorderSize.Size = New System.Drawing.Size(64, 13)
        Me.Label_BorderSize.TabIndex = 15
        Me.Label_BorderSize.Text = "Border Size:"
        '
        'CheckBox_LimitCPU
        '
        Me.CheckBox_LimitCPU.AutoSize = True
        Me.CheckBox_LimitCPU.Location = New System.Drawing.Point(247, 76)
        Me.CheckBox_LimitCPU.Name = "CheckBox_LimitCPU"
        Me.CheckBox_LimitCPU.Size = New System.Drawing.Size(214, 17)
        Me.CheckBox_LimitCPU.TabIndex = 17
        Me.CheckBox_LimitCPU.Text = "Limit CPU Usage (Reduces refresh rate)"
        Me.CheckBox_LimitCPU.UseVisualStyleBackColor = True
        '
        'CheckBox_ReduceFlicker
        '
        Me.CheckBox_ReduceFlicker.AutoSize = True
        Me.CheckBox_ReduceFlicker.Location = New System.Drawing.Point(247, 99)
        Me.CheckBox_ReduceFlicker.Name = "CheckBox_ReduceFlicker"
        Me.CheckBox_ReduceFlicker.Size = New System.Drawing.Size(227, 17)
        Me.CheckBox_ReduceFlicker.TabIndex = 18
        Me.CheckBox_ReduceFlicker.Text = "Reduce flicker (Reduces cursor sensitivity)"
        Me.CheckBox_ReduceFlicker.UseVisualStyleBackColor = True
        '
        'CheckBox_ZeroLine
        '
        Me.CheckBox_ZeroLine.AutoSize = True
        Me.CheckBox_ZeroLine.Checked = True
        Me.CheckBox_ZeroLine.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_ZeroLine.Location = New System.Drawing.Point(247, 133)
        Me.CheckBox_ZeroLine.Name = "CheckBox_ZeroLine"
        Me.CheckBox_ZeroLine.Size = New System.Drawing.Size(103, 17)
        Me.CheckBox_ZeroLine.TabIndex = 0
        Me.CheckBox_ZeroLine.Text = "Y Axis Zero Line"
        Me.CheckBox_ZeroLine.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 379)
        Me.Controls.Add(Me.CheckBox_ZeroLine)
        Me.Controls.Add(Me.CheckBox_ReduceFlicker)
        Me.Controls.Add(Me.CheckBox_LimitCPU)
        Me.Controls.Add(Me.TrackBar_BorderSize)
        Me.Controls.Add(Me.Label_BorderSize)
        Me.Controls.Add(Me.ComboBox_SeriesType)
        Me.Controls.Add(Me.Label_SeriesType)
        Me.Controls.Add(Me.Button_Save)
        Me.Controls.Add(Me.Button_Reload)
        Me.Controls.Add(Me.Button_ResetDefaults)
        Me.Controls.Add(Me.TrackBar_MaxZoom)
        Me.Controls.Add(Me.TrackBar_MaxAreas)
        Me.Controls.Add(Me.TrackBar_XGrids)
        Me.Controls.Add(Me.TrackBar_ScaleInterval)
        Me.Controls.Add(Me.TrackBar_ZoomSteps)
        Me.Controls.Add(Me.Label_MaxAreas)
        Me.Controls.Add(Me.Label_XGrids)
        Me.Controls.Add(Me.Label_ScaleInterval)
        Me.Controls.Add(Me.Label_ZoomSteps)
        Me.Controls.Add(Me.Label_MaxZoom)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(504, 418)
        Me.MinimumSize = New System.Drawing.Size(504, 418)
        Me.Name = "Settings"
        Me.Text = "Log Analyzer - Settings"
        CType(Me.TrackBar_ZoomSteps, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_ScaleInterval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_XGrids, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_MaxAreas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_MaxZoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_BorderSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label_MaxZoom As Label
    Friend WithEvents Label_ZoomSteps As Label
    Friend WithEvents Label_ScaleInterval As Label
    Friend WithEvents Label_XGrids As Label
    Friend WithEvents Label_MaxAreas As Label
    Friend WithEvents TrackBar_ZoomSteps As TrackBar
    Friend WithEvents TrackBar_ScaleInterval As TrackBar
    Friend WithEvents TrackBar_XGrids As TrackBar
    Friend WithEvents TrackBar_MaxAreas As TrackBar
    Friend WithEvents TrackBar_MaxZoom As TrackBar
    Friend WithEvents Button_ResetDefaults As Button
    Friend WithEvents Button_Reload As Button
    Friend WithEvents Button_Save As Button
    Friend WithEvents Label_SeriesType As Label
    Friend WithEvents ComboBox_SeriesType As ComboBox
    Friend WithEvents TrackBar_BorderSize As TrackBar
    Friend WithEvents Label_BorderSize As Label
    Friend WithEvents CheckBox_LimitCPU As CheckBox
    Friend WithEvents CheckBox_ReduceFlicker As CheckBox
    Friend WithEvents CheckBox_ZeroLine As CheckBox
End Class
