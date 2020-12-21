<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Banner
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Banner))
        Me.Bsave = New Telerik.WinControls.UI.RadButton()
        Me.BCancel = New Telerik.WinControls.UI.RadButton()
        Me.RadPanel2 = New Telerik.WinControls.UI.RadPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Bannertext = New System.Windows.Forms.RichTextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Bsave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bsave
        '
        Me.Bsave.BackColor = System.Drawing.Color.Transparent
        Me.Bsave.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bsave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bsave.ForeColor = System.Drawing.Color.Black
        Me.Bsave.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        Me.Bsave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.Bsave.Location = New System.Drawing.Point(793, 511)
        Me.Bsave.Name = "Bsave"
        Me.Bsave.Size = New System.Drawing.Size(115, 44)
        Me.Bsave.TabIndex = 131
        Me.Bsave.Text = "Save"
        Me.Bsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Bsave.ThemeName = "Breeze"
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Save"
        '
        'BCancel
        '
        Me.BCancel.BackColor = System.Drawing.Color.Transparent
        Me.BCancel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BCancel.ForeColor = System.Drawing.Color.Black
        Me.BCancel.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BCancel.Location = New System.Drawing.Point(922, 511)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(115, 44)
        Me.BCancel.TabIndex = 132
        Me.BCancel.Text = "Close"
        Me.BCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BCancel.ThemeName = "Breeze"
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Close"
        '
        'RadPanel2
        '
        Me.RadPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadPanel2.Font = New System.Drawing.Font("Tahoma", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadPanel2.ForeColor = System.Drawing.Color.White
        Me.RadPanel2.Location = New System.Drawing.Point(0, 0)
        Me.RadPanel2.Name = "RadPanel2"
        Me.RadPanel2.Size = New System.Drawing.Size(1049, 112)
        Me.RadPanel2.TabIndex = 130
        Me.RadPanel2.Text = "Configuration > Banner"
        Me.RadPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadPanel2.GetChildAt(0), Telerik.WinControls.UI.RadPanelElement).Text = "Configuration > Banner"
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(248, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(244, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).NumberOfColors = 1
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 29)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Banner Text"
        '
        'Bannertext
        '
        Me.Bannertext.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.Bannertext.Location = New System.Drawing.Point(13, 170)
        Me.Bannertext.Name = "Bannertext"
        Me.Bannertext.Size = New System.Drawing.Size(1024, 323)
        Me.Bannertext.TabIndex = 133
        Me.Bannertext.Text = ""
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'Banner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 568)
        Me.Controls.Add(Me.Bannertext)
        Me.Controls.Add(Me.Bsave)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.RadPanel2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None
        Me.MinimumSize = New System.Drawing.Size(1057, 632)
        Me.Name = "Banner"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Configuration > Banner"
        Me.ThemeName = "Office2010Blue"
        CType(Me.Bsave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bsave As Telerik.WinControls.UI.RadButton
    Friend WithEvents BCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadPanel2 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Bannertext As System.Windows.Forms.RichTextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class

