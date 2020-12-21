<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnloadtankValue
    Inherits Telerik.WinControls.UI.RadForm

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
        Me.components = New System.ComponentModel.Container()
        Me.RadPanel2 = New Telerik.WinControls.UI.RadPanel()
        Me.Referencetext = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.Office2010BlueTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme()
        Me.RoundRectShape1 = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.BTCANCEL = New Telerik.WinControls.UI.RadButton()
        Me.BTSave = New Telerik.WinControls.UI.RadButton()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.Trucknumber = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tankvalue = New Telerik.WinControls.UI.RadTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tankno = New Telerik.WinControls.UI.RadTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tankvaluefinish = New Telerik.WinControls.UI.RadTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Tank_After = New System.Windows.Forms.RadioButton()
        Me.Tank_Befor = New System.Windows.Forms.RadioButton()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Referencetext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BTCANCEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BTSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Trucknumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tankvalue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tankno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tankvaluefinish, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadPanel2
        '
        Me.RadPanel2.BackColor = System.Drawing.SystemColors.Control
        Me.RadPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadPanel2.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.RadPanel2.ForeColor = System.Drawing.Color.White
        Me.RadPanel2.Location = New System.Drawing.Point(0, 0)
        Me.RadPanel2.Name = "RadPanel2"
        Me.RadPanel2.Size = New System.Drawing.Size(759, 105)
        Me.RadPanel2.TabIndex = 2
        Me.RadPanel2.Text = "ดึงค่าปริมาณถัง (Unloading Advisenote)"
        Me.RadPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadPanel2.GetChildAt(0), Telerik.WinControls.UI.RadPanelElement).Text = "ดึงค่าปริมาณถัง (Unloading Advisenote)"
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(248, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(244, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).NumberOfColors = 1
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).GradientStyle = Telerik.WinControls.GradientStyles.Linear
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'Referencetext
        '
        Me.Referencetext.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Referencetext.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Referencetext.Location = New System.Drawing.Point(386, 131)
        Me.Referencetext.Name = "Referencetext"
        Me.Referencetext.ReadOnly = True
        Me.Referencetext.Size = New System.Drawing.Size(318, 34)
        Me.Referencetext.TabIndex = 43
        Me.Referencetext.TabStop = False
        Me.Referencetext.Text = "DDDD"
        Me.Referencetext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(247, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 29)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Reference"
        '
        'BTCANCEL
        '
        Me.BTCANCEL.BackColor = System.Drawing.Color.Transparent
        Me.BTCANCEL.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTCANCEL.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BTCANCEL.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BTCANCEL.Location = New System.Drawing.Point(580, 382)
        Me.BTCANCEL.Name = "BTCANCEL"
        Me.BTCANCEL.Size = New System.Drawing.Size(156, 64)
        Me.BTCANCEL.TabIndex = 3
        Me.BTCANCEL.Text = "ยกเลิก"
        Me.BTCANCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTCANCEL.ThemeName = "Breeze"
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "ยกเลิก"
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'BTSave
        '
        Me.BTSave.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTSave.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        Me.BTSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BTSave.Location = New System.Drawing.Point(408, 382)
        Me.BTSave.Name = "BTSave"
        Me.BTSave.Size = New System.Drawing.Size(156, 64)
        Me.BTSave.TabIndex = 2
        Me.BTSave.Text = "บันทึก"
        Me.BTSave.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTSave.ThemeName = "Breeze"
        CType(Me.BTSave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        CType(Me.BTSave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BTSave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTSave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        CType(Me.BTSave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "บันทึก"
        '
        'RadButton1
        '
        Me.RadButton1.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadButton1.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.refresh
        Me.RadButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadButton1.Location = New System.Drawing.Point(203, 38)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(156, 64)
        Me.RadButton1.TabIndex = 1
        Me.RadButton1.Text = "ดึงค่าถัง"
        Me.RadButton1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton1.ThemeName = "Breeze"
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.refresh
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "ดึงค่าถัง"
        '
        'Trucknumber
        '
        Me.Trucknumber.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Trucknumber.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Trucknumber.Location = New System.Drawing.Point(386, 171)
        Me.Trucknumber.Name = "Trucknumber"
        Me.Trucknumber.ReadOnly = True
        Me.Trucknumber.Size = New System.Drawing.Size(318, 34)
        Me.Trucknumber.TabIndex = 48
        Me.Trucknumber.TabStop = False
        Me.Trucknumber.Text = "DDDD"
        Me.Trucknumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(152, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 29)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "หมายเลขทะเบียนรถ"
        '
        'Tankvalue
        '
        Me.Tankvalue.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tankvalue.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Tankvalue.Location = New System.Drawing.Point(386, 251)
        Me.Tankvalue.Name = "Tankvalue"
        Me.Tankvalue.ReadOnly = True
        Me.Tankvalue.Size = New System.Drawing.Size(318, 34)
        Me.Tankvalue.TabIndex = 50
        Me.Tankvalue.TabStop = False
        Me.Tankvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        CType(Me.Tankvalue.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).ForeColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(18, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.Tankvalue.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 251)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(347, 29)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "ค่าปริมาณถังก่อนโหลด (Litre)"
        '
        'Tankno
        '
        Me.Tankno.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tankno.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Tankno.Location = New System.Drawing.Point(386, 211)
        Me.Tankno.Name = "Tankno"
        Me.Tankno.ReadOnly = True
        Me.Tankno.Size = New System.Drawing.Size(318, 34)
        Me.Tankno.TabIndex = 52
        Me.Tankno.TabStop = False
        Me.Tankno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(236, 211)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 29)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "หมายเลขถัง"
        '
        'Tankvaluefinish
        '
        Me.Tankvaluefinish.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tankvaluefinish.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Tankvaluefinish.Location = New System.Drawing.Point(386, 291)
        Me.Tankvaluefinish.Name = "Tankvaluefinish"
        Me.Tankvaluefinish.ReadOnly = True
        Me.Tankvaluefinish.Size = New System.Drawing.Size(318, 34)
        Me.Tankvaluefinish.TabIndex = 54
        Me.Tankvaluefinish.TabStop = False
        Me.Tankvaluefinish.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        CType(Me.Tankvaluefinish.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).ForeColor = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(10, Byte), Integer))
        CType(Me.Tankvaluefinish.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 291)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(351, 29)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "ค่าปริมาณถังโหลดเสร็จ (Litre)"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Tank_After)
        Me.GroupBox4.Controls.Add(Me.Tank_Befor)
        Me.GroupBox4.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 21)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(192, 90)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = ""
        '
        'Tank_After
        '
        Me.Tank_After.AutoSize = True
        Me.Tank_After.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Tank_After.Location = New System.Drawing.Point(20, 58)
        Me.Tank_After.Name = "Tank_After"
        Me.Tank_After.Size = New System.Drawing.Size(162, 23)
        Me.Tank_After.TabIndex = 1
        Me.Tank_After.Text = "ปริมาณถังโหลดเสร็จ"
        Me.Tank_After.UseVisualStyleBackColor = True
        '
        'Tank_Befor
        '
        Me.Tank_Befor.AutoSize = True
        Me.Tank_Befor.Checked = True
        Me.Tank_Befor.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Tank_Befor.Location = New System.Drawing.Point(20, 24)
        Me.Tank_Befor.Name = "Tank_Befor"
        Me.Tank_Befor.Size = New System.Drawing.Size(160, 23)
        Me.Tank_Befor.TabIndex = 0
        Me.Tank_Befor.TabStop = True
        Me.Tank_Befor.Text = "ปริมาณถังก่อนโหลด"
        Me.Tank_Befor.UseVisualStyleBackColor = True
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.RadGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox1.Controls.Add(Me.RadButton1)
        Me.RadGroupBox1.Controls.Add(Me.GroupBox4)
        Me.RadGroupBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadGroupBox1.HeaderText = "ดึงค่าปริมาณถังปัจจุบัน"
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 344)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(2, 18, 2, 2)
        Me.RadGroupBox1.Size = New System.Drawing.Size(375, 117)
        Me.RadGroupBox1.TabIndex = 55
        Me.RadGroupBox1.Text = "ดึงค่าปริมาณถังปัจจุบัน"
        Me.RadGroupBox1.ThemeName = "Breeze"
        '
        'UnloadtankValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 467)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.Tankvaluefinish)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Tankno)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Tankvalue)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Trucknumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTCANCEL)
        Me.Controls.Add(Me.BTSave)
        Me.Controls.Add(Me.Referencetext)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RadPanel2)
        Me.Name = "UnloadtankValue"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ดึงค่าถัง"
        Me.ThemeName = "Office2010Blue"
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Referencetext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BTCANCEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BTSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Trucknumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tankvalue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tankno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tankvaluefinish, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadPanel2 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents Referencetext As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents Office2010BlueTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Friend WithEvents RoundRectShape1 As Telerik.WinControls.RoundRectShape
    Friend WithEvents BTCANCEL As Telerik.WinControls.UI.RadButton
    Friend WithEvents BTSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents Trucknumber As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tankvalue As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tankno As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tankvaluefinish As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Tank_After As System.Windows.Forms.RadioButton
    Friend WithEvents Tank_Befor As System.Windows.Forms.RadioButton
    Friend WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
End Class

