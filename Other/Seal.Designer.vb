<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Seal
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
        Me.Seallast = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SealUp = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Bcancel = New Telerik.WinControls.UI.RadButton()
        Me.Bsave = New Telerik.WinControls.UI.RadButton()
        Me.RadPanel2 = New Telerik.WinControls.UI.RadPanel()
        CType(Me.Seallast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SealUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bcancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bsave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Seallast
        '
        Me.Seallast.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Seallast.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Seallast.Location = New System.Drawing.Point(444, 173)
        Me.Seallast.Name = "Seallast"
        Me.Seallast.ReadOnly = True
        Me.Seallast.Size = New System.Drawing.Size(188, 38)
        Me.Seallast.TabIndex = 41
        Me.Seallast.TabStop = False
        Me.Seallast.Text = "DDDD"
        Me.Seallast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(120, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 35)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "หมายเลขซีลล่าสุด"
        '
        'SealUp
        '
        Me.SealUp.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SealUp.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.SealUp.Location = New System.Drawing.Point(444, 245)
        Me.SealUp.Name = "SealUp"
        Me.SealUp.Size = New System.Drawing.Size(188, 38)
        Me.SealUp.TabIndex = 43
        Me.SealUp.TabStop = False
        Me.SealUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(120, 247)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(252, 35)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "แก้ไขหมายเลขซีล"
        '
        'Bcancel
        '
        Me.Bcancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Bcancel.ForeColor = System.Drawing.SystemColors.Control
        Me.Bcancel.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Button_Cancel
        Me.Bcancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.Bcancel.Location = New System.Drawing.Point(501, 318)
        Me.Bcancel.Name = "Bcancel"
        Me.Bcancel.Size = New System.Drawing.Size(131, 52)
        Me.Bcancel.TabIndex = 95
        Me.Bcancel.Text = "&Cancel"
        Me.Bcancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Bcancel.ThemeName = "Office2010Blue"
        '
        'Bsave
        '
        Me.Bsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Bsave.ForeColor = System.Drawing.SystemColors.Control
        Me.Bsave.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.document_save
        Me.Bsave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.Bsave.Location = New System.Drawing.Point(364, 318)
        Me.Bsave.Name = "Bsave"
        Me.Bsave.Size = New System.Drawing.Size(131, 52)
        Me.Bsave.TabIndex = 94
        Me.Bsave.Text = "&Save"
        Me.Bsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Bsave.ThemeName = "Office2010Blue"
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.document_save
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "&Save"
        CType(Me.Bsave.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.SystemColors.Control
        CType(Me.Bsave.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).NumberOfColors = 2
        CType(Me.Bsave.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.SystemColors.Control
        '
        'RadPanel2
        '
        Me.RadPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadPanel2.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadPanel2.ForeColor = System.Drawing.Color.White
        Me.RadPanel2.Location = New System.Drawing.Point(0, 0)
        Me.RadPanel2.Name = "RadPanel2"
        Me.RadPanel2.Size = New System.Drawing.Size(754, 112)
        Me.RadPanel2.TabIndex = 96
        Me.RadPanel2.Text = "Utilitie>>กล่องซีล"
        Me.RadPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadPanel2.GetChildAt(0), Telerik.WinControls.UI.RadPanelElement).Text = "Utilitie>>กล่องซีล"
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(248, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(244, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).NumberOfColors = 4
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(246, Byte), Integer))
        '
        'Seal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(754, 382)
        Me.Controls.Add(Me.RadPanel2)
        Me.Controls.Add(Me.Bcancel)
        Me.Controls.Add(Me.Bsave)
        Me.Controls.Add(Me.SealUp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Seallast)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Seal"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "กล่องซีล"
        Me.ThemeName = "Office2010Blue"
        CType(Me.Seallast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SealUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bcancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bsave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Seallast As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SealUp As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Bcancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents Bsave As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadPanel2 As Telerik.WinControls.UI.RadPanel
End Class

