<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Report
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Report))
        Me.GroupBox_BugReport = New System.Windows.Forms.GroupBox()
        Me.Button_ReportBug = New System.Windows.Forms.Button()
        Me.TextBox_BugName = New System.Windows.Forms.TextBox()
        Me.TextBox_BugDescription = New System.Windows.Forms.TextBox()
        Me.TextBox_BugSummary = New System.Windows.Forms.TextBox()
        Me.Label_BugName = New System.Windows.Forms.Label()
        Me.Label_BugDescription = New System.Windows.Forms.Label()
        Me.Label_BugSummary = New System.Windows.Forms.Label()
        Me.GroupBox_FeatureSuggest = New System.Windows.Forms.GroupBox()
        Me.Button_SuggestFeature = New System.Windows.Forms.Button()
        Me.Label_FeatureSummary = New System.Windows.Forms.Label()
        Me.TextBox_FeatureName = New System.Windows.Forms.TextBox()
        Me.Label_FeatureDescription = New System.Windows.Forms.Label()
        Me.TextBox_FeatureDescription = New System.Windows.Forms.TextBox()
        Me.Label_FeatureName = New System.Windows.Forms.Label()
        Me.TextBox_FeatureSummary = New System.Windows.Forms.TextBox()
        Me.GroupBox_BugReport.SuspendLayout()
        Me.GroupBox_FeatureSuggest.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox_BugReport
        '
        Me.GroupBox_BugReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_BugReport.Controls.Add(Me.Button_ReportBug)
        Me.GroupBox_BugReport.Controls.Add(Me.TextBox_BugName)
        Me.GroupBox_BugReport.Controls.Add(Me.TextBox_BugDescription)
        Me.GroupBox_BugReport.Controls.Add(Me.TextBox_BugSummary)
        Me.GroupBox_BugReport.Controls.Add(Me.Label_BugName)
        Me.GroupBox_BugReport.Controls.Add(Me.Label_BugDescription)
        Me.GroupBox_BugReport.Controls.Add(Me.Label_BugSummary)
        Me.GroupBox_BugReport.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox_BugReport.Name = "GroupBox_BugReport"
        Me.GroupBox_BugReport.Size = New System.Drawing.Size(330, 238)
        Me.GroupBox_BugReport.TabIndex = 0
        Me.GroupBox_BugReport.TabStop = False
        Me.GroupBox_BugReport.Text = "Bug Report"
        '
        'Button_ReportBug
        '
        Me.Button_ReportBug.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button_ReportBug.Location = New System.Drawing.Point(249, 209)
        Me.Button_ReportBug.Name = "Button_ReportBug"
        Me.Button_ReportBug.Size = New System.Drawing.Size(75, 23)
        Me.Button_ReportBug.TabIndex = 6
        Me.Button_ReportBug.Text = "Report Bug"
        Me.Button_ReportBug.UseVisualStyleBackColor = True
        '
        'TextBox_BugName
        '
        Me.TextBox_BugName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_BugName.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.TextBox_BugName.Location = New System.Drawing.Point(6, 183)
        Me.TextBox_BugName.Name = "TextBox_BugName"
        Me.TextBox_BugName.Size = New System.Drawing.Size(318, 20)
        Me.TextBox_BugName.TabIndex = 5
        Me.TextBox_BugName.Text = "Anonymous"
        '
        'TextBox_BugDescription
        '
        Me.TextBox_BugDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_BugDescription.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.TextBox_BugDescription.Location = New System.Drawing.Point(6, 71)
        Me.TextBox_BugDescription.Multiline = True
        Me.TextBox_BugDescription.Name = "TextBox_BugDescription"
        Me.TextBox_BugDescription.Size = New System.Drawing.Size(318, 93)
        Me.TextBox_BugDescription.TabIndex = 4
        Me.TextBox_BugDescription.Text = "I was looking at the RPM and Torque graphs and the program crashed when I tried t" &
    "o zoom in"
        '
        'TextBox_BugSummary
        '
        Me.TextBox_BugSummary.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.TextBox_BugSummary.Location = New System.Drawing.Point(6, 32)
        Me.TextBox_BugSummary.Name = "TextBox_BugSummary"
        Me.TextBox_BugSummary.Size = New System.Drawing.Size(318, 20)
        Me.TextBox_BugSummary.TabIndex = 3
        Me.TextBox_BugSummary.Text = "Zoom in bug"
        '
        'Label_BugName
        '
        Me.Label_BugName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_BugName.AutoSize = True
        Me.Label_BugName.Location = New System.Drawing.Point(3, 167)
        Me.Label_BugName.Name = "Label_BugName"
        Me.Label_BugName.Size = New System.Drawing.Size(63, 13)
        Me.Label_BugName.TabIndex = 2
        Me.Label_BugName.Text = "Your Name:"
        '
        'Label_BugDescription
        '
        Me.Label_BugDescription.AutoSize = True
        Me.Label_BugDescription.Location = New System.Drawing.Point(3, 55)
        Me.Label_BugDescription.Name = "Label_BugDescription"
        Me.Label_BugDescription.Size = New System.Drawing.Size(85, 13)
        Me.Label_BugDescription.TabIndex = 1
        Me.Label_BugDescription.Text = "Bug Description:"
        '
        'Label_BugSummary
        '
        Me.Label_BugSummary.AutoSize = True
        Me.Label_BugSummary.Location = New System.Drawing.Point(3, 16)
        Me.Label_BugSummary.Name = "Label_BugSummary"
        Me.Label_BugSummary.Size = New System.Drawing.Size(75, 13)
        Me.Label_BugSummary.TabIndex = 0
        Me.Label_BugSummary.Text = "Bug Summary:"
        '
        'GroupBox_FeatureSuggest
        '
        Me.GroupBox_FeatureSuggest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_FeatureSuggest.Controls.Add(Me.Button_SuggestFeature)
        Me.GroupBox_FeatureSuggest.Controls.Add(Me.Label_FeatureSummary)
        Me.GroupBox_FeatureSuggest.Controls.Add(Me.TextBox_FeatureName)
        Me.GroupBox_FeatureSuggest.Controls.Add(Me.Label_FeatureDescription)
        Me.GroupBox_FeatureSuggest.Controls.Add(Me.TextBox_FeatureDescription)
        Me.GroupBox_FeatureSuggest.Controls.Add(Me.Label_FeatureName)
        Me.GroupBox_FeatureSuggest.Controls.Add(Me.TextBox_FeatureSummary)
        Me.GroupBox_FeatureSuggest.Location = New System.Drawing.Point(348, 12)
        Me.GroupBox_FeatureSuggest.Name = "GroupBox_FeatureSuggest"
        Me.GroupBox_FeatureSuggest.Size = New System.Drawing.Size(330, 238)
        Me.GroupBox_FeatureSuggest.TabIndex = 1
        Me.GroupBox_FeatureSuggest.TabStop = False
        Me.GroupBox_FeatureSuggest.Text = "Feature Suggest"
        '
        'Button_SuggestFeature
        '
        Me.Button_SuggestFeature.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button_SuggestFeature.Location = New System.Drawing.Point(249, 209)
        Me.Button_SuggestFeature.Name = "Button_SuggestFeature"
        Me.Button_SuggestFeature.Size = New System.Drawing.Size(75, 23)
        Me.Button_SuggestFeature.TabIndex = 13
        Me.Button_SuggestFeature.Text = "Suggest Feature"
        Me.Button_SuggestFeature.UseVisualStyleBackColor = True
        '
        'Label_FeatureSummary
        '
        Me.Label_FeatureSummary.AutoSize = True
        Me.Label_FeatureSummary.Location = New System.Drawing.Point(6, 16)
        Me.Label_FeatureSummary.Name = "Label_FeatureSummary"
        Me.Label_FeatureSummary.Size = New System.Drawing.Size(92, 13)
        Me.Label_FeatureSummary.TabIndex = 7
        Me.Label_FeatureSummary.Text = "Feature Summary:"
        '
        'TextBox_FeatureName
        '
        Me.TextBox_FeatureName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_FeatureName.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.TextBox_FeatureName.Location = New System.Drawing.Point(9, 183)
        Me.TextBox_FeatureName.Name = "TextBox_FeatureName"
        Me.TextBox_FeatureName.Size = New System.Drawing.Size(315, 20)
        Me.TextBox_FeatureName.TabIndex = 12
        Me.TextBox_FeatureName.Text = "Anonymous"
        '
        'Label_FeatureDescription
        '
        Me.Label_FeatureDescription.AutoSize = True
        Me.Label_FeatureDescription.Location = New System.Drawing.Point(6, 55)
        Me.Label_FeatureDescription.Name = "Label_FeatureDescription"
        Me.Label_FeatureDescription.Size = New System.Drawing.Size(102, 13)
        Me.Label_FeatureDescription.TabIndex = 8
        Me.Label_FeatureDescription.Text = "Feature Description:"
        '
        'TextBox_FeatureDescription
        '
        Me.TextBox_FeatureDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_FeatureDescription.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.TextBox_FeatureDescription.Location = New System.Drawing.Point(9, 71)
        Me.TextBox_FeatureDescription.Multiline = True
        Me.TextBox_FeatureDescription.Name = "TextBox_FeatureDescription"
        Me.TextBox_FeatureDescription.Size = New System.Drawing.Size(315, 93)
        Me.TextBox_FeatureDescription.TabIndex = 11
        Me.TextBox_FeatureDescription.Text = "Add the color purple as option for the charts"
        '
        'Label_FeatureName
        '
        Me.Label_FeatureName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_FeatureName.AutoSize = True
        Me.Label_FeatureName.Location = New System.Drawing.Point(6, 167)
        Me.Label_FeatureName.Name = "Label_FeatureName"
        Me.Label_FeatureName.Size = New System.Drawing.Size(63, 13)
        Me.Label_FeatureName.TabIndex = 9
        Me.Label_FeatureName.Text = "Your Name:"
        '
        'TextBox_FeatureSummary
        '
        Me.TextBox_FeatureSummary.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.TextBox_FeatureSummary.Location = New System.Drawing.Point(9, 32)
        Me.TextBox_FeatureSummary.Name = "TextBox_FeatureSummary"
        Me.TextBox_FeatureSummary.Size = New System.Drawing.Size(315, 20)
        Me.TextBox_FeatureSummary.TabIndex = 10
        Me.TextBox_FeatureSummary.Text = "More colors"
        '
        'Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 258)
        Me.Controls.Add(Me.GroupBox_FeatureSuggest)
        Me.Controls.Add(Me.GroupBox_BugReport)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(706, 297)
        Me.MinimumSize = New System.Drawing.Size(706, 297)
        Me.Name = "Report"
        Me.Text = "Log Analyzer - Report"
        Me.GroupBox_BugReport.ResumeLayout(False)
        Me.GroupBox_BugReport.PerformLayout()
        Me.GroupBox_FeatureSuggest.ResumeLayout(False)
        Me.GroupBox_FeatureSuggest.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox_BugReport As GroupBox
    Friend WithEvents Button_ReportBug As Button
    Friend WithEvents TextBox_BugName As TextBox
    Friend WithEvents TextBox_BugDescription As TextBox
    Friend WithEvents TextBox_BugSummary As TextBox
    Friend WithEvents Label_BugName As Label
    Friend WithEvents Label_BugDescription As Label
    Friend WithEvents Label_BugSummary As Label
    Friend WithEvents GroupBox_FeatureSuggest As GroupBox
    Friend WithEvents Button_SuggestFeature As Button
    Friend WithEvents Label_FeatureSummary As Label
    Friend WithEvents TextBox_FeatureName As TextBox
    Friend WithEvents Label_FeatureDescription As Label
    Friend WithEvents TextBox_FeatureDescription As TextBox
    Friend WithEvents Label_FeatureName As Label
    Friend WithEvents TextBox_FeatureSummary As TextBox
End Class
