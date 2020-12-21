<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reportdaily
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
        Me.RadPanel1 = New Telerik.WinControls.UI.RadPanel()
        Me.RadCalendar1 = New Telerik.WinControls.UI.RadCalendar()
        Me.GridViewTemplate2 = New Telerik.WinControls.UI.GridViewTemplate()
        Me.IRPCDataset = New RadControlsWinFormsApp1.IRPCDataset()
        Me.RadPanel3 = New Telerik.WinControls.UI.RadPanel()
        Me.BPrint = New Telerik.WinControls.UI.RadButton()
        Me.BClose = New Telerik.WinControls.UI.RadButton()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadPanel4 = New Telerik.WinControls.UI.RadPanel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RPT4On = New System.Windows.Forms.RadioButton()
        Me.RPT6On = New System.Windows.Forms.RadioButton()
        Me.RPT3On = New System.Windows.Forms.RadioButton()
        Me.RPT2On = New System.Windows.Forms.RadioButton()
        Me.RPT5On = New System.Windows.Forms.RadioButton()
        Me.RPT1On = New System.Windows.Forms.RadioButton()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.Office2010BlueTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.RadCalendar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTemplate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IRPCDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel3.SuspendLayout()
        CType(Me.BPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel4.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadPanel1
        '
        Me.RadPanel1.Controls.Add(Me.RadCalendar1)
        Me.RadPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RadPanel1.Location = New System.Drawing.Point(0, 0)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(397, 445)
        Me.RadPanel1.TabIndex = 0
        Me.RadPanel1.ThemeName = "Breeze"
        '
        'RadCalendar1
        '
        Me.RadCalendar1.DayNameFormat = Telerik.WinControls.UI.DayNameFormat.Full
        Me.RadCalendar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadCalendar1.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCalendar1.HeaderHeight = 50
        Me.RadCalendar1.Location = New System.Drawing.Point(0, 0)
        Me.RadCalendar1.Name = "RadCalendar1"
        '
        '
        '
        Me.RadCalendar1.RootElement.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent
        Me.RadCalendar1.ShowFooter = True
        Me.RadCalendar1.Size = New System.Drawing.Size(397, 445)
        Me.RadCalendar1.TabIndex = 8
        Me.RadCalendar1.Text = "RadCalendar1"
        Me.RadCalendar1.ThemeName = "Office2010Blue"
        Me.RadCalendar1.TitleFormat = " MMMM  yyyy"
        Me.RadCalendar1.UseCompatibleTextRendering = False
        CType(Me.RadCalendar1.GetChildAt(0), Telerik.WinControls.UI.RadCalendarElement).ZoomFactor = 1.3!
        CType(Me.RadCalendar1.GetChildAt(0), Telerik.WinControls.UI.RadCalendarElement).BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        CType(Me.RadCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'IRPCDataset
        '
        Me.IRPCDataset.DataSetName = "IRPCDataset"
        Me.IRPCDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RadPanel3
        '
        Me.RadPanel3.Controls.Add(Me.BPrint)
        Me.RadPanel3.Controls.Add(Me.BClose)
        Me.RadPanel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.RadPanel3.Location = New System.Drawing.Point(816, 0)
        Me.RadPanel3.Name = "RadPanel3"
        Me.RadPanel3.Size = New System.Drawing.Size(203, 445)
        Me.RadPanel3.TabIndex = 4
        Me.RadPanel3.ThemeName = "Breeze"
        '
        'BPrint
        '
        Me.BPrint.BackColor = System.Drawing.Color.Transparent
        Me.BPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BPrint.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPrint.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Print32
        Me.BPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BPrint.Location = New System.Drawing.Point(26, 41)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(154, 60)
        Me.BPrint.TabIndex = 16
        Me.BPrint.Text = "พิมพ์"
        Me.BPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BPrint.ThemeName = "Breeze"
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Print32
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "พิมพ์"
        '
        'BClose
        '
        Me.BClose.BackColor = System.Drawing.Color.Transparent
        Me.BClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BClose.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BClose.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BClose.Location = New System.Drawing.Point(26, 129)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(154, 60)
        Me.BClose.TabIndex = 17
        Me.BClose.Text = "ปิด  "
        Me.BClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BClose.ThemeName = "Breeze"
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "ปิด  "
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = Me.IRPCDataset
        Me.BindingSource1.Position = 0
        '
        'RadPanel4
        '
        Me.RadPanel4.Controls.Add(Me.GroupBox4)
        Me.RadPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPanel4.Location = New System.Drawing.Point(397, 0)
        Me.RadPanel4.Name = "RadPanel4"
        Me.RadPanel4.Size = New System.Drawing.Size(419, 445)
        Me.RadPanel4.TabIndex = 6
        Me.RadPanel4.ThemeName = "Breeze"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RPT4On)
        Me.GroupBox4.Controls.Add(Me.RPT6On)
        Me.GroupBox4.Controls.Add(Me.RPT3On)
        Me.GroupBox4.Controls.Add(Me.RPT2On)
        Me.GroupBox4.Controls.Add(Me.RPT5On)
        Me.GroupBox4.Controls.Add(Me.RPT1On)
        Me.GroupBox4.Location = New System.Drawing.Point(32, 29)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(381, 318)
        Me.GroupBox4.TabIndex = 41
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = ""
        '
        'RPT4On
        '
        Me.RPT4On.AutoSize = True
        Me.RPT4On.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RPT4On.Location = New System.Drawing.Point(20, 111)
        Me.RPT4On.Name = "RPT4On"
        Me.RPT4On.Size = New System.Drawing.Size(166, 27)
        Me.RPT4On.TabIndex = 5
        Me.RPT4On.Text = "รายงานตามมิเตอร์"
        Me.RPT4On.UseVisualStyleBackColor = True
        Me.RPT4On.Visible = False
        '
        'RPT6On
        '
        Me.RPT6On.AutoSize = True
        Me.RPT6On.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RPT6On.Location = New System.Drawing.Point(20, 177)
        Me.RPT6On.Name = "RPT6On"
        Me.RPT6On.Size = New System.Drawing.Size(284, 27)
        Me.RPT6On.TabIndex = 4
        Me.RPT6On.Text = "รายงานจำนวนรถเข้ารับผลิตภัณฑ์"
        Me.RPT6On.UseVisualStyleBackColor = True
        Me.RPT6On.Visible = False
        '
        'RPT3On
        '
        Me.RPT3On.AutoSize = True
        Me.RPT3On.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RPT3On.Location = New System.Drawing.Point(20, 78)
        Me.RPT3On.Name = "RPT3On"
        Me.RPT3On.Size = New System.Drawing.Size(199, 27)
        Me.RPT3On.TabIndex = 3
        Me.RPT3On.Text = "รายงานตาม Load No."
        Me.RPT3On.UseVisualStyleBackColor = True
        Me.RPT3On.Visible = False
        '
        'RPT2On
        '
        Me.RPT2On.AutoSize = True
        Me.RPT2On.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RPT2On.Location = New System.Drawing.Point(20, 45)
        Me.RPT2On.Name = "RPT2On"
        Me.RPT2On.Size = New System.Drawing.Size(210, 27)
        Me.RPT2On.TabIndex = 2
        Me.RPT2On.Text = "รายงานตามบริษัทลูกค้า"
        Me.RPT2On.UseVisualStyleBackColor = True
        '
        'RPT5On
        '
        Me.RPT5On.AutoSize = True
        Me.RPT5On.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RPT5On.Location = New System.Drawing.Point(20, 144)
        Me.RPT5On.Name = "RPT5On"
        Me.RPT5On.Size = New System.Drawing.Size(231, 27)
        Me.RPT5On.TabIndex = 1
        Me.RPT5On.Text = "รายงานตามกลุ่มผลิตภัณฑ์"
        Me.RPT5On.UseVisualStyleBackColor = True
        Me.RPT5On.Visible = False
        '
        'RPT1On
        '
        Me.RPT1On.AutoSize = True
        Me.RPT1On.Checked = True
        Me.RPT1On.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RPT1On.Location = New System.Drawing.Point(20, 12)
        Me.RPT1On.Name = "RPT1On"
        Me.RPT1On.Size = New System.Drawing.Size(260, 27)
        Me.RPT1On.TabIndex = 0
        Me.RPT1On.TabStop = True
        Me.RPT1On.Text = "รายงานเวลาการจ่ายผลิตภัณฑ์"
        Me.RPT1On.UseVisualStyleBackColor = True
        '
        'Reportdaily
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1019, 445)
        Me.Controls.Add(Me.RadPanel4)
        Me.Controls.Add(Me.RadPanel3)
        Me.Controls.Add(Me.RadPanel1)
        Me.Name = "Reportdaily"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "รายงานการจ่ายน้ำมันของรถบรรทุกประจำวัน"
        Me.ThemeName = "Office2010Blue"
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        CType(Me.RadCalendar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTemplate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IRPCDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel3.ResumeLayout(False)
        CType(Me.BPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel4.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents GridViewTemplate2 As Telerik.WinControls.UI.GridViewTemplate
    Friend WithEvents IRPCDataset As RadControlsWinFormsApp1.IRPCDataset
    Friend WithEvents RadPanel3 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents RadPanel4 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RPT5On As System.Windows.Forms.RadioButton
    Friend WithEvents RPT1On As System.Windows.Forms.RadioButton
    Friend WithEvents RPT2On As System.Windows.Forms.RadioButton
    Friend WithEvents RPT4On As System.Windows.Forms.RadioButton
    Friend WithEvents RPT6On As System.Windows.Forms.RadioButton
    Friend WithEvents RPT3On As System.Windows.Forms.RadioButton
    Friend WithEvents BPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents BClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents Office2010BlueTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Friend WithEvents RadCalendar1 As Telerik.WinControls.UI.RadCalendar
End Class

