<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DataEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataEditor))
        Me.Label_Series = New System.Windows.Forms.Label()
        Me.ComboBox_Series = New System.Windows.Forms.ComboBox()
        Me.GroupBox_DataEditing = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDown_Factor = New System.Windows.Forms.NumericUpDown()
        Me.Button_Divide = New System.Windows.Forms.Button()
        Me.Button_Multiply = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown_Offset = New System.Windows.Forms.NumericUpDown()
        Me.Button_Subtract = New System.Windows.Forms.Button()
        Me.Button_Add = New System.Windows.Forms.Button()
        Me.GroupBox_DataFiltering = New System.Windows.Forms.GroupBox()
        Me.GroupBox_MA = New System.Windows.Forms.GroupBox()
        Me.Button_MA_Apply = New System.Windows.Forms.Button()
        Me.NumericUpDown_MA_WindowSize = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox_EMA = New System.Windows.Forms.GroupBox()
        Me.Button_EMA_Apply = New System.Windows.Forms.Button()
        Me.NumericUpDown_EMA_Alpha = New System.Windows.Forms.NumericUpDown()
        Me.Label_EMA_Alpha = New System.Windows.Forms.Label()
        Me.Button_Reset = New System.Windows.Forms.Button()
        Me.Button_Save = New System.Windows.Forms.Button()
        Me.CheckBox_TopMost = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericUpDown_Crop = New System.Windows.Forms.NumericUpDown()
        Me.Button_CropBelow = New System.Windows.Forms.Button()
        Me.Button_CropAbove = New System.Windows.Forms.Button()
        Me.GroupBox_DataEditing.SuspendLayout()
        CType(Me.NumericUpDown_Factor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_Offset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_DataFiltering.SuspendLayout()
        Me.GroupBox_MA.SuspendLayout()
        CType(Me.NumericUpDown_MA_WindowSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_EMA.SuspendLayout()
        CType(Me.NumericUpDown_EMA_Alpha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown_Crop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label_Series
        '
        Me.Label_Series.AutoSize = True
        Me.Label_Series.Location = New System.Drawing.Point(12, 9)
        Me.Label_Series.Name = "Label_Series"
        Me.Label_Series.Size = New System.Drawing.Size(72, 13)
        Me.Label_Series.TabIndex = 0
        Me.Label_Series.Text = "Select Series:"
        '
        'ComboBox_Series
        '
        Me.ComboBox_Series.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox_Series.FormattingEnabled = True
        Me.ComboBox_Series.Location = New System.Drawing.Point(12, 25)
        Me.ComboBox_Series.Name = "ComboBox_Series"
        Me.ComboBox_Series.Size = New System.Drawing.Size(161, 21)
        Me.ComboBox_Series.TabIndex = 1
        '
        'GroupBox_DataEditing
        '
        Me.GroupBox_DataEditing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_DataEditing.Controls.Add(Me.Button_CropAbove)
        Me.GroupBox_DataEditing.Controls.Add(Me.Button_CropBelow)
        Me.GroupBox_DataEditing.Controls.Add(Me.NumericUpDown_Crop)
        Me.GroupBox_DataEditing.Controls.Add(Me.Label4)
        Me.GroupBox_DataEditing.Controls.Add(Me.Label2)
        Me.GroupBox_DataEditing.Controls.Add(Me.NumericUpDown_Factor)
        Me.GroupBox_DataEditing.Controls.Add(Me.Button_Divide)
        Me.GroupBox_DataEditing.Controls.Add(Me.Button_Multiply)
        Me.GroupBox_DataEditing.Controls.Add(Me.Label1)
        Me.GroupBox_DataEditing.Controls.Add(Me.NumericUpDown_Offset)
        Me.GroupBox_DataEditing.Controls.Add(Me.Button_Subtract)
        Me.GroupBox_DataEditing.Controls.Add(Me.Button_Add)
        Me.GroupBox_DataEditing.Enabled = False
        Me.GroupBox_DataEditing.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox_DataEditing.Name = "GroupBox_DataEditing"
        Me.GroupBox_DataEditing.Size = New System.Drawing.Size(272, 213)
        Me.GroupBox_DataEditing.TabIndex = 2
        Me.GroupBox_DataEditing.TabStop = False
        Me.GroupBox_DataEditing.Text = "Data Editing"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Constant Factor:"
        '
        'NumericUpDown_Factor
        '
        Me.NumericUpDown_Factor.DecimalPlaces = 3
        Me.NumericUpDown_Factor.Location = New System.Drawing.Point(144, 32)
        Me.NumericUpDown_Factor.Maximum = New Decimal(New Integer() {0, 1, 0, 0})
        Me.NumericUpDown_Factor.Minimum = New Decimal(New Integer() {0, 1, 0, -2147483648})
        Me.NumericUpDown_Factor.Name = "NumericUpDown_Factor"
        Me.NumericUpDown_Factor.Size = New System.Drawing.Size(122, 20)
        Me.NumericUpDown_Factor.TabIndex = 6
        '
        'Button_Divide
        '
        Me.Button_Divide.Location = New System.Drawing.Point(191, 87)
        Me.Button_Divide.Name = "Button_Divide"
        Me.Button_Divide.Size = New System.Drawing.Size(75, 23)
        Me.Button_Divide.TabIndex = 5
        Me.Button_Divide.Text = "Divide"
        Me.Button_Divide.UseVisualStyleBackColor = True
        '
        'Button_Multiply
        '
        Me.Button_Multiply.Location = New System.Drawing.Point(191, 58)
        Me.Button_Multiply.Name = "Button_Multiply"
        Me.Button_Multiply.Size = New System.Drawing.Size(75, 23)
        Me.Button_Multiply.TabIndex = 4
        Me.Button_Multiply.Text = "Multiply"
        Me.Button_Multiply.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Constant Offset:"
        '
        'NumericUpDown_Offset
        '
        Me.NumericUpDown_Offset.DecimalPlaces = 3
        Me.NumericUpDown_Offset.Location = New System.Drawing.Point(6, 32)
        Me.NumericUpDown_Offset.Maximum = New Decimal(New Integer() {0, 1, 0, 0})
        Me.NumericUpDown_Offset.Name = "NumericUpDown_Offset"
        Me.NumericUpDown_Offset.Size = New System.Drawing.Size(122, 20)
        Me.NumericUpDown_Offset.TabIndex = 2
        '
        'Button_Subtract
        '
        Me.Button_Subtract.Location = New System.Drawing.Point(53, 87)
        Me.Button_Subtract.Name = "Button_Subtract"
        Me.Button_Subtract.Size = New System.Drawing.Size(75, 23)
        Me.Button_Subtract.TabIndex = 1
        Me.Button_Subtract.Text = "Subtract"
        Me.Button_Subtract.UseVisualStyleBackColor = True
        '
        'Button_Add
        '
        Me.Button_Add.Location = New System.Drawing.Point(53, 58)
        Me.Button_Add.Name = "Button_Add"
        Me.Button_Add.Size = New System.Drawing.Size(75, 23)
        Me.Button_Add.TabIndex = 0
        Me.Button_Add.Text = "Add"
        Me.Button_Add.UseVisualStyleBackColor = True
        '
        'GroupBox_DataFiltering
        '
        Me.GroupBox_DataFiltering.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_DataFiltering.Controls.Add(Me.GroupBox_MA)
        Me.GroupBox_DataFiltering.Controls.Add(Me.GroupBox_EMA)
        Me.GroupBox_DataFiltering.Enabled = False
        Me.GroupBox_DataFiltering.Location = New System.Drawing.Point(290, 12)
        Me.GroupBox_DataFiltering.Name = "GroupBox_DataFiltering"
        Me.GroupBox_DataFiltering.Size = New System.Drawing.Size(227, 282)
        Me.GroupBox_DataFiltering.TabIndex = 3
        Me.GroupBox_DataFiltering.TabStop = False
        Me.GroupBox_DataFiltering.Text = "Data Filtering"
        '
        'GroupBox_MA
        '
        Me.GroupBox_MA.Controls.Add(Me.Button_MA_Apply)
        Me.GroupBox_MA.Controls.Add(Me.NumericUpDown_MA_WindowSize)
        Me.GroupBox_MA.Controls.Add(Me.Label3)
        Me.GroupBox_MA.Location = New System.Drawing.Point(6, 83)
        Me.GroupBox_MA.Name = "GroupBox_MA"
        Me.GroupBox_MA.Size = New System.Drawing.Size(215, 58)
        Me.GroupBox_MA.TabIndex = 10
        Me.GroupBox_MA.TabStop = False
        Me.GroupBox_MA.Text = "Moving Average"
        '
        'Button_MA_Apply
        '
        Me.Button_MA_Apply.Location = New System.Drawing.Point(134, 29)
        Me.Button_MA_Apply.Name = "Button_MA_Apply"
        Me.Button_MA_Apply.Size = New System.Drawing.Size(75, 23)
        Me.Button_MA_Apply.TabIndex = 9
        Me.Button_MA_Apply.Text = "Apply"
        Me.Button_MA_Apply.UseVisualStyleBackColor = True
        '
        'NumericUpDown_MA_WindowSize
        '
        Me.NumericUpDown_MA_WindowSize.Location = New System.Drawing.Point(6, 32)
        Me.NumericUpDown_MA_WindowSize.Name = "NumericUpDown_MA_WindowSize"
        Me.NumericUpDown_MA_WindowSize.Size = New System.Drawing.Size(122, 20)
        Me.NumericUpDown_MA_WindowSize.TabIndex = 8
        Me.NumericUpDown_MA_WindowSize.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Window Size:"
        '
        'GroupBox_EMA
        '
        Me.GroupBox_EMA.Controls.Add(Me.Button_EMA_Apply)
        Me.GroupBox_EMA.Controls.Add(Me.NumericUpDown_EMA_Alpha)
        Me.GroupBox_EMA.Controls.Add(Me.Label_EMA_Alpha)
        Me.GroupBox_EMA.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox_EMA.Name = "GroupBox_EMA"
        Me.GroupBox_EMA.Size = New System.Drawing.Size(215, 58)
        Me.GroupBox_EMA.TabIndex = 0
        Me.GroupBox_EMA.TabStop = False
        Me.GroupBox_EMA.Text = "Exponential Moving Average"
        '
        'Button_EMA_Apply
        '
        Me.Button_EMA_Apply.Location = New System.Drawing.Point(134, 29)
        Me.Button_EMA_Apply.Name = "Button_EMA_Apply"
        Me.Button_EMA_Apply.Size = New System.Drawing.Size(75, 23)
        Me.Button_EMA_Apply.TabIndex = 9
        Me.Button_EMA_Apply.Text = "Apply"
        Me.Button_EMA_Apply.UseVisualStyleBackColor = True
        '
        'NumericUpDown_EMA_Alpha
        '
        Me.NumericUpDown_EMA_Alpha.DecimalPlaces = 3
        Me.NumericUpDown_EMA_Alpha.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NumericUpDown_EMA_Alpha.Location = New System.Drawing.Point(6, 32)
        Me.NumericUpDown_EMA_Alpha.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown_EMA_Alpha.Name = "NumericUpDown_EMA_Alpha"
        Me.NumericUpDown_EMA_Alpha.Size = New System.Drawing.Size(122, 20)
        Me.NumericUpDown_EMA_Alpha.TabIndex = 8
        Me.NumericUpDown_EMA_Alpha.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'Label_EMA_Alpha
        '
        Me.Label_EMA_Alpha.AutoSize = True
        Me.Label_EMA_Alpha.Location = New System.Drawing.Point(3, 16)
        Me.Label_EMA_Alpha.Name = "Label_EMA_Alpha"
        Me.Label_EMA_Alpha.Size = New System.Drawing.Size(70, 13)
        Me.Label_EMA_Alpha.TabIndex = 0
        Me.Label_EMA_Alpha.Text = "Alpha Factor:"
        '
        'Button_Reset
        '
        Me.Button_Reset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button_Reset.Location = New System.Drawing.Point(12, 271)
        Me.Button_Reset.Name = "Button_Reset"
        Me.Button_Reset.Size = New System.Drawing.Size(75, 23)
        Me.Button_Reset.TabIndex = 4
        Me.Button_Reset.Text = "Reset"
        Me.Button_Reset.UseVisualStyleBackColor = True
        '
        'Button_Save
        '
        Me.Button_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button_Save.Location = New System.Drawing.Point(209, 271)
        Me.Button_Save.Name = "Button_Save"
        Me.Button_Save.Size = New System.Drawing.Size(75, 23)
        Me.Button_Save.TabIndex = 5
        Me.Button_Save.Text = "Save"
        Me.Button_Save.UseVisualStyleBackColor = True
        '
        'CheckBox_TopMost
        '
        Me.CheckBox_TopMost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox_TopMost.AutoSize = True
        Me.CheckBox_TopMost.Location = New System.Drawing.Point(104, 277)
        Me.CheckBox_TopMost.Name = "CheckBox_TopMost"
        Me.CheckBox_TopMost.Size = New System.Drawing.Size(90, 17)
        Me.CheckBox_TopMost.TabIndex = 6
        Me.CheckBox_TopMost.Text = "Keep On Top"
        Me.CheckBox_TopMost.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Cropping:"
        '
        'NumericUpDown_Crop
        '
        Me.NumericUpDown_Crop.DecimalPlaces = 3
        Me.NumericUpDown_Crop.Location = New System.Drawing.Point(9, 129)
        Me.NumericUpDown_Crop.Maximum = New Decimal(New Integer() {0, 1, 0, 0})
        Me.NumericUpDown_Crop.Minimum = New Decimal(New Integer() {0, 1, 0, -2147483648})
        Me.NumericUpDown_Crop.Name = "NumericUpDown_Crop"
        Me.NumericUpDown_Crop.Size = New System.Drawing.Size(122, 20)
        Me.NumericUpDown_Crop.TabIndex = 9
        '
        'Button_CropBelow
        '
        Me.Button_CropBelow.Location = New System.Drawing.Point(56, 184)
        Me.Button_CropBelow.Name = "Button_CropBelow"
        Me.Button_CropBelow.Size = New System.Drawing.Size(75, 23)
        Me.Button_CropBelow.TabIndex = 10
        Me.Button_CropBelow.Text = "Crop Below"
        Me.Button_CropBelow.UseVisualStyleBackColor = True
        '
        'Button_CropAbove
        '
        Me.Button_CropAbove.Location = New System.Drawing.Point(56, 155)
        Me.Button_CropAbove.Name = "Button_CropAbove"
        Me.Button_CropAbove.Size = New System.Drawing.Size(75, 23)
        Me.Button_CropAbove.TabIndex = 11
        Me.Button_CropAbove.Text = "Crop Above"
        Me.Button_CropAbove.UseVisualStyleBackColor = True
        '
        'DataEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 306)
        Me.Controls.Add(Me.CheckBox_TopMost)
        Me.Controls.Add(Me.Button_Save)
        Me.Controls.Add(Me.Button_Reset)
        Me.Controls.Add(Me.GroupBox_DataFiltering)
        Me.Controls.Add(Me.GroupBox_DataEditing)
        Me.Controls.Add(Me.ComboBox_Series)
        Me.Controls.Add(Me.Label_Series)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(545, 248)
        Me.Name = "DataEditor"
        Me.Text = "UoP Racing - Data Editor"
        Me.GroupBox_DataEditing.ResumeLayout(False)
        Me.GroupBox_DataEditing.PerformLayout()
        CType(Me.NumericUpDown_Factor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_Offset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_DataFiltering.ResumeLayout(False)
        Me.GroupBox_MA.ResumeLayout(False)
        Me.GroupBox_MA.PerformLayout()
        CType(Me.NumericUpDown_MA_WindowSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_EMA.ResumeLayout(False)
        Me.GroupBox_EMA.PerformLayout()
        CType(Me.NumericUpDown_EMA_Alpha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown_Crop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label_Series As Label
    Friend WithEvents ComboBox_Series As ComboBox
    Friend WithEvents GroupBox_DataEditing As GroupBox
    Friend WithEvents GroupBox_DataFiltering As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents NumericUpDown_Factor As NumericUpDown
    Friend WithEvents Button_Divide As Button
    Friend WithEvents Button_Multiply As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents NumericUpDown_Offset As NumericUpDown
    Friend WithEvents Button_Subtract As Button
    Friend WithEvents Button_Add As Button
    Friend WithEvents GroupBox_EMA As GroupBox
    Friend WithEvents Button_EMA_Apply As Button
    Friend WithEvents NumericUpDown_EMA_Alpha As NumericUpDown
    Friend WithEvents Label_EMA_Alpha As Label
    Friend WithEvents Button_Reset As Button
    Friend WithEvents Button_Save As Button
    Friend WithEvents GroupBox_MA As GroupBox
    Friend WithEvents Button_MA_Apply As Button
    Friend WithEvents NumericUpDown_MA_WindowSize As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBox_TopMost As CheckBox
    Friend WithEvents Button_CropAbove As Button
    Friend WithEvents Button_CropBelow As Button
    Friend WithEvents NumericUpDown_Crop As NumericUpDown
    Friend WithEvents Label4 As Label
End Class
