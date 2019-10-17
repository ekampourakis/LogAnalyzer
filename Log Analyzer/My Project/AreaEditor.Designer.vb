<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AreaEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AreaEditor))
        Me.ListView = New System.Windows.Forms.ListView()
        Me.ColumnHeader_ChartArea = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader_ChartSeries = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ListView
        '
        Me.ListView.CheckBoxes = True
        Me.ListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader_ChartArea, Me.ColumnHeader_ChartSeries})
        Me.ListView.FullRowSelect = True
        Me.ListView.GridLines = True
        Me.ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView.Location = New System.Drawing.Point(140, 131)
        Me.ListView.MultiSelect = False
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(545, 195)
        Me.ListView.TabIndex = 0
        Me.ListView.UseCompatibleStateImageBehavior = False
        Me.ListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader_ChartArea
        '
        Me.ColumnHeader_ChartArea.Text = "Chart Area"
        Me.ColumnHeader_ChartArea.Width = 126
        '
        'ColumnHeader_ChartSeries
        '
        Me.ColumnHeader_ChartSeries.Text = "Area Series"
        Me.ColumnHeader_ChartSeries.Width = 215
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(322, 50)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(111, 13)
        Me.Label.TabIndex = 1
        Me.Label.Text = "BETA - DO NOT USE"
        '
        'AreaEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label)
        Me.Controls.Add(Me.ListView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AreaEditor"
        Me.Text = "Log Analyzer - Area Editor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ListView As ListView
    Friend WithEvents ColumnHeader_ChartArea As ColumnHeader
    Friend WithEvents ColumnHeader_ChartSeries As ColumnHeader
    Friend WithEvents Label As Label
End Class
