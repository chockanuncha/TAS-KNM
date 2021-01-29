<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditSeal
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
        Me.Seallast = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Remark = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundRectShape1 = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.BTCANCEL = New Telerik.WinControls.UI.RadButton()
        Me.BTSAVE = New Telerik.WinControls.UI.RadButton()
        Me.Seallast_Edit = New Telerik.WinControls.UI.RadTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel2.SuspendLayout()
        CType(Me.Seallast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Remark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BTCANCEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BTSAVE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Seallast_Edit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadPanel2
        '
        Me.RadPanel2.Controls.Add(Me.PictureBox1)
        Me.RadPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadPanel2.Font = New System.Drawing.Font("Tahoma", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadPanel2.ForeColor = System.Drawing.Color.White
        Me.RadPanel2.Location = New System.Drawing.Point(0, 0)
        Me.RadPanel2.Name = "RadPanel2"
        Me.RadPanel2.Size = New System.Drawing.Size(677, 99)
        Me.RadPanel2.TabIndex = 103
        Me.RadPanel2.Text = "แก้ไขซีล"
        Me.RadPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadPanel2.ThemeName = "Breeze"
        CType(Me.RadPanel2.GetChildAt(0), Telerik.WinControls.UI.RadPanelElement).Text = "แก้ไขซีล"
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(248, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(244, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).NumberOfColors = 1
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'Seallast
        '
        Me.Seallast.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Seallast.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Seallast.ForeColor = System.Drawing.SystemColors.Control
        Me.Seallast.Location = New System.Drawing.Point(225, 160)
        Me.Seallast.Name = "Seallast"
        Me.Seallast.ReadOnly = True
        Me.Seallast.Size = New System.Drawing.Size(435, 38)
        Me.Seallast.TabIndex = 120
        Me.Seallast.TabStop = True
        Me.Seallast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Seallast.ThemeName = "Breeze"
        CType(Me.Seallast.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        CType(Me.Seallast.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        CType(Me.Seallast.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 35)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "หมายเลขซีล"
        '
        'Remark
        '
        Me.Remark.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Remark.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Remark.Location = New System.Drawing.Point(225, 248)
        Me.Remark.Name = "Remark"
        Me.Remark.Size = New System.Drawing.Size(435, 38)
        Me.Remark.TabIndex = 2
        Me.Remark.TabStop = True
        Me.Remark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(79, 250)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 35)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "หมายเหตุ"
        '
        'BTCANCEL
        '
        Me.BTCANCEL.BackColor = System.Drawing.Color.Transparent
        Me.BTCANCEL.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTCANCEL.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BTCANCEL.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BTCANCEL.Location = New System.Drawing.Point(545, 305)
        Me.BTCANCEL.Name = "BTCANCEL"
        Me.BTCANCEL.Size = New System.Drawing.Size(115, 44)
        Me.BTCANCEL.TabIndex = 4
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
        'BTSAVE
        '
        Me.BTSAVE.BackColor = System.Drawing.Color.Transparent
        Me.BTSAVE.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTSAVE.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTSAVE.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        Me.BTSAVE.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BTSAVE.Location = New System.Drawing.Point(416, 305)
        Me.BTSAVE.Name = "BTSAVE"
        Me.BTSAVE.Size = New System.Drawing.Size(115, 44)
        Me.BTSAVE.TabIndex = 3
        Me.BTSAVE.Text = "บันทึก"
        Me.BTSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTSAVE.ThemeName = "Breeze"
        CType(Me.BTSAVE.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        CType(Me.BTSAVE.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BTSAVE.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTSAVE.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTSAVE.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "บันทึก"
        CType(Me.BTSAVE.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'Seallast_Edit
        '
        Me.Seallast_Edit.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Seallast_Edit.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Seallast_Edit.Location = New System.Drawing.Point(225, 204)
        Me.Seallast_Edit.Name = "Seallast_Edit"
        Me.Seallast_Edit.Size = New System.Drawing.Size(435, 38)
        Me.Seallast_Edit.TabIndex = 1
        Me.Seallast_Edit.TabStop = True
        Me.Seallast_Edit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 206)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(178, 35)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "แก้ไขเลขซีล"
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(191, 305)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(138, 47)
        Me.RadButton1.TabIndex = 121
        Me.RadButton1.Text = "RadButton1"
        Me.RadButton1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.irpc1
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(159, 99)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 193
        Me.PictureBox1.TabStop = True
        Me.PictureBox1.Visible = False
        '
        'EditSeal
        '
        Me.ClientSize = New System.Drawing.Size(677, 364)
        Me.Controls.Add(Me.RadButton1)
        Me.Controls.Add(Me.Seallast_Edit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BTCANCEL)
        Me.Controls.Add(Me.BTSAVE)
        Me.Controls.Add(Me.Remark)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RadPanel2)
        Me.Controls.Add(Me.Seallast)
        Me.Controls.Add(Me.Label2)
        Me.Name = "EditSeal"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "แก้ไขซีล"
        Me.ThemeName = "Office2010Blue"
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel2.ResumeLayout(False)
        CType(Me.Seallast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Remark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BTCANCEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BTSAVE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Seallast_Edit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadPanel2 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Remark As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Seallast As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RoundRectShape1 As Telerik.WinControls.RoundRectShape
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents BTCANCEL As Telerik.WinControls.UI.RadButton
    Friend WithEvents BTSAVE As Telerik.WinControls.UI.RadButton
    Public WithEvents Seallast_Edit As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class

