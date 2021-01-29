<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintSelect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintSelect))
        Me.BPrint = New Telerik.WinControls.UI.RadButton()
        Me.RoundRectShape1 = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.BCancel = New Telerik.WinControls.UI.RadButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Kiosk_chk = New System.Windows.Forms.RadioButton()
        Me.Default_chk = New System.Windows.Forms.RadioButton()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        CType(Me.BPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BPrint
        '
        Me.BPrint.BackColor = System.Drawing.Color.Transparent
        Me.BPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BPrint.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPrint.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Print32
        Me.BPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BPrint.Location = New System.Drawing.Point(51, 84)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(115, 44)
        Me.BPrint.TabIndex = 9
        Me.BPrint.Text = "พิมพ์"
        Me.BPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BPrint.ThemeName = "Breeze"
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Print32
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "พิมพ์"
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'BCancel
        '
        Me.BCancel.BackColor = System.Drawing.Color.Transparent
        Me.BCancel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BCancel.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BCancel.Location = New System.Drawing.Point(180, 84)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(115, 44)
        Me.BCancel.TabIndex = 10
        Me.BCancel.Text = "ยกเลิก"
        Me.BCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BCancel.ThemeName = "Breeze"
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "ยกเลิก"
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Kiosk_chk)
        Me.GroupBox4.Controls.Add(Me.Default_chk)
        Me.GroupBox4.Location = New System.Drawing.Point(25, 17)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(270, 61)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = True
        Me.GroupBox4.Tag = ""
        Me.GroupBox4.Text = "Printer"
        '
        'Kiosk_chk
        '
        Me.Kiosk_chk.AutoSize = True
        Me.Kiosk_chk.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Kiosk_chk.Location = New System.Drawing.Point(174, 18)
        Me.Kiosk_chk.Name = "Kiosk_chk"
        Me.Kiosk_chk.Size = New System.Drawing.Size(70, 27)
        Me.Kiosk_chk.TabIndex = 1
        Me.Kiosk_chk.Text = "Kiosk"
        Me.Kiosk_chk.UseVisualStyleBackColor = True
        '
        'Default_chk
        '
        Me.Default_chk.AutoSize = True
        Me.Default_chk.Checked = True
        Me.Default_chk.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Default_chk.Location = New System.Drawing.Point(27, 18)
        Me.Default_chk.Name = "Default_chk"
        Me.Default_chk.Size = New System.Drawing.Size(88, 27)
        Me.Default_chk.TabIndex = 0
        Me.Default_chk.TabStop = True
        Me.Default_chk.Text = "Default"
        Me.Default_chk.UseVisualStyleBackColor = True
        '
        'PrintSelect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(323, 148)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.BPrint)
        Me.Controls.Add(Me.BCancel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None
        Me.Name = "PrintSelect"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PrintSelect"
        Me.ThemeName = "Breeze"
        CType(Me.BPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BCancel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents RoundRectShape1 As Telerik.WinControls.RoundRectShape
    Friend WithEvents BCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Kiosk_chk As System.Windows.Forms.RadioButton
    Friend WithEvents Default_chk As System.Windows.Forms.RadioButton
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
End Class

