<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportDayBetween
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
        Me.GB1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.DTP1 = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.GB2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.B_ExportExcel = New Telerik.WinControls.UI.RadButton()
        Me.DTP2 = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.DTP3 = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.BClose = New Telerik.WinControls.UI.RadButton()
        Me.BPrint = New Telerik.WinControls.UI.RadButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CHKBetween = New System.Windows.Forms.RadioButton()
        Me.CHKDay = New System.Windows.Forms.RadioButton()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.Office2010BlueTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme()
        Me.Header = New Telerik.WinControls.UI.RadPanel()
        CType(Me.GB1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB1.SuspendLayout()
        CType(Me.DTP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GB2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB2.SuspendLayout()
        CType(Me.B_ExportExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTP3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Header, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GB1
        '
        Me.GB1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.GB1.Controls.Add(Me.DTP1)
        Me.GB1.HeaderText = "Select Date"
        Me.GB1.Location = New System.Drawing.Point(779, 230)
        Me.GB1.Name = "GB1"
        Me.GB1.Size = New System.Drawing.Size(32, 30)
        Me.GB1.TabIndex = 22
        Me.GB1.Text = "Select Date"
        Me.GB1.ThemeName = "Office2010Blue"
        Me.GB1.Visible = False
        '
        'DTP1
        '
        Me.DTP1.CustomFormat = "dd/MM/yyyy"
        Me.DTP1.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP1.Location = New System.Drawing.Point(93, 25)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.Size = New System.Drawing.Size(164, 28)
        Me.DTP1.TabIndex = 9
        Me.DTP1.Text = "16/06/2557"
        Me.DTP1.ThemeName = "Office2010Blue"
        Me.DTP1.Value = New Date(2014, 6, 16, 15, 4, 17, 1)
        '
        'GB2
        '
        Me.GB2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me.GB2.Controls.Add(Me.B_ExportExcel)
        Me.GB2.Controls.Add(Me.DTP2)
        Me.GB2.Controls.Add(Me.DTP3)
        Me.GB2.Controls.Add(Me.RadLabel2)
        Me.GB2.Controls.Add(Me.RadLabel3)
        Me.GB2.Controls.Add(Me.BClose)
        Me.GB2.Controls.Add(Me.BPrint)
        Me.GB2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GB2.HeaderText = "Select Date"
        Me.GB2.Location = New System.Drawing.Point(0, 100)
        Me.GB2.Name = "GB2"
        Me.GB2.Size = New System.Drawing.Size(608, 156)
        Me.GB2.TabIndex = 21
        Me.GB2.Text = "Select Date"
        Me.GB2.ThemeName = "Office2010Blue"
        '
        'B_ExportExcel
        '
        Me.B_ExportExcel.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_ExportExcel.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Print32
        Me.B_ExportExcel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.B_ExportExcel.Location = New System.Drawing.Point(468, 32)
        Me.B_ExportExcel.Name = "B_ExportExcel"
        Me.B_ExportExcel.Size = New System.Drawing.Size(135, 45)
        Me.B_ExportExcel.TabIndex = 20
        Me.B_ExportExcel.Text = "Export Excel"
        Me.B_ExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.B_ExportExcel.ThemeName = "Breeze"
        Me.B_ExportExcel.Visible = False
        CType(Me.B_ExportExcel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Print32
        CType(Me.B_ExportExcel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.B_ExportExcel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.B_ExportExcel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Export Excel"
        '
        'DTP2
        '
        Me.DTP2.Culture = New System.Globalization.CultureInfo("en-GB")
        Me.DTP2.CustomFormat = "dd/MM/yyyy"
        Me.DTP2.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP2.Location = New System.Drawing.Point(129, 41)
        Me.DTP2.Name = "DTP2"
        Me.DTP2.Size = New System.Drawing.Size(146, 28)
        Me.DTP2.TabIndex = 0
        Me.DTP2.Text = "06/05/2021"
        Me.DTP2.ThemeName = "Office2010Blue"
        Me.DTP2.Value = New Date(2021, 5, 6, 0, 0, 0, 0)
        '
        'DTP3
        '
        Me.DTP3.Culture = New System.Globalization.CultureInfo("en-GB")
        Me.DTP3.CustomFormat = "dd/MM/yyyy"
        Me.DTP3.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.DTP3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP3.Location = New System.Drawing.Point(316, 40)
        Me.DTP3.Name = "DTP3"
        Me.DTP3.Size = New System.Drawing.Size(146, 28)
        Me.DTP3.TabIndex = 1
        Me.DTP3.Text = "06/05/2021"
        Me.DTP3.ThemeName = "Office2010Blue"
        Me.DTP3.Value = New Date(2021, 5, 6, 0, 0, 0, 0)
        '
        'RadLabel2
        '
        Me.RadLabel2.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel2.Location = New System.Drawing.Point(65, 41)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(61, 27)
        Me.RadLabel2.TabIndex = 12
        Me.RadLabel2.Text = "Date :"
        '
        'RadLabel3
        '
        Me.RadLabel3.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel3.Location = New System.Drawing.Point(289, 41)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(16, 27)
        Me.RadLabel3.TabIndex = 13
        Me.RadLabel3.Text = "-"
        '
        'BClose
        '
        Me.BClose.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.BClose.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BClose.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BClose.Location = New System.Drawing.Point(316, 85)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(144, 50)
        Me.BClose.TabIndex = 3
        Me.BClose.Text = "Close"
        Me.BClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BClose.ThemeName = "Breeze"
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Close"
        '
        'BPrint
        '
        Me.BPrint.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPrint.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Print32
        Me.BPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BPrint.Location = New System.Drawing.Point(129, 85)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(144, 50)
        Me.BPrint.TabIndex = 2
        Me.BPrint.Text = "Print"
        Me.BPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BPrint.ThemeName = "Breeze"
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Print32
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Print"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CHKBetween)
        Me.GroupBox4.Controls.Add(Me.CHKDay)
        Me.GroupBox4.Location = New System.Drawing.Point(859, 219)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(69, 41)
        Me.GroupBox4.TabIndex = 20
        Me.GroupBox4.Tag = ""
        Me.GroupBox4.Text = "Type report"
        Me.GroupBox4.Visible = False
        '
        'CHKBetween
        '
        Me.CHKBetween.AutoSize = True
        Me.CHKBetween.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.CHKBetween.Location = New System.Drawing.Point(27, 116)
        Me.CHKBetween.Name = "CHKBetween"
        Me.CHKBetween.Size = New System.Drawing.Size(100, 27)
        Me.CHKBetween.TabIndex = 1
        Me.CHKBetween.Text = "Between"
        Me.CHKBetween.UseVisualStyleBackColor = True
        '
        'CHKDay
        '
        Me.CHKDay.AutoSize = True
        Me.CHKDay.Checked = True
        Me.CHKDay.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.CHKDay.Location = New System.Drawing.Point(27, 27)
        Me.CHKDay.Name = "CHKDay"
        Me.CHKDay.Size = New System.Drawing.Size(60, 27)
        Me.CHKDay.TabIndex = 0
        Me.CHKDay.TabStop = True
        Me.CHKDay.Text = "Day"
        Me.CHKDay.UseVisualStyleBackColor = True
        '
        'Header
        '
        Me.Header.BackColor = System.Drawing.SystemColors.Control
        Me.Header.Dock = System.Windows.Forms.DockStyle.Top
        Me.Header.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Header.ForeColor = System.Drawing.Color.White
        Me.Header.Location = New System.Drawing.Point(0, 0)
        Me.Header.Name = "Header"
        Me.Header.Size = New System.Drawing.Size(608, 100)
        Me.Header.TabIndex = 30
        Me.Header.Text = "#####"
        Me.Header.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.Header.GetChildAt(0), Telerik.WinControls.UI.RadPanelElement).Text = "#####"
        CType(Me.Header.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.Header.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(248, Byte), Integer))
        CType(Me.Header.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(244, Byte), Integer))
        CType(Me.Header.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).NumberOfColors = 1
        CType(Me.Header.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).GradientStyle = Telerik.WinControls.GradientStyles.Linear
        CType(Me.Header.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'ReportDayBetween
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 256)
        Me.Controls.Add(Me.GB2)
        Me.Controls.Add(Me.Header)
        Me.Controls.Add(Me.GB1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "ReportDayBetween"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PrintReport"
        Me.ThemeName = "Office2010Blue"
        CType(Me.GB1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB1.ResumeLayout(False)
        Me.GB1.PerformLayout()
        CType(Me.DTP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GB2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB2.ResumeLayout(False)
        Me.GB2.PerformLayout()
        CType(Me.B_ExportExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTP3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.Header, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GB1 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents DTP1 As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents GB2 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents DTP2 As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents DTP3 As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CHKBetween As System.Windows.Forms.RadioButton
    Friend WithEvents CHKDay As System.Windows.Forms.RadioButton
    Friend WithEvents BClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents BPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents Office2010BlueTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Public WithEvents Header As Telerik.WinControls.UI.RadPanel
    Friend WithEvents B_ExportExcel As Telerik.WinControls.UI.RadButton
End Class

