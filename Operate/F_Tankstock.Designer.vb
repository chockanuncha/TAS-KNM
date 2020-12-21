<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Tankstock1
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
        Me.BPrint = New Telerik.WinControls.UI.RadButton()
        Me.RoundRectShape1 = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.BCancel = New Telerik.WinControls.UI.RadButton()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        CType(Me.BPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BPrint
        '
        Me.BPrint.BackColor = System.Drawing.Color.Transparent
        Me.BPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BPrint.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPrint.ForeColor = System.Drawing.Color.Black
        Me.BPrint.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        Me.BPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BPrint.Location = New System.Drawing.Point(7, 12)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(183, 62)
        Me.BPrint.TabIndex = 11
        Me.BPrint.Text = "Save"
        Me.BPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BPrint.ThemeName = "Breeze"
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Save"
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'RoundRectShape1
        '
        Me.RoundRectShape1.IsRightToLeft = False
        '
        'BCancel
        '
        Me.BCancel.BackColor = System.Drawing.Color.Transparent
        Me.BCancel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BCancel.ForeColor = System.Drawing.Color.Black
        Me.BCancel.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BCancel.Location = New System.Drawing.Point(209, 12)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(183, 62)
        Me.BCancel.TabIndex = 12
        Me.BCancel.Text = "Cancel"
        Me.BCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BCancel.ThemeName = "Breeze"
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Cancel"
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'RadButton1
        '
        Me.RadButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.RadButton1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadButton1.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Comic_Icons_3_files_edit_32x32_new
        Me.RadButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadButton1.Location = New System.Drawing.Point(196, 44)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(10, 30)
        Me.RadButton1.TabIndex = 13
        Me.RadButton1.Text = "ปิด Stock"
        Me.RadButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton1.ThemeName = "Breeze"
        Me.RadButton1.Visible = False
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Comic_Icons_3_files_edit_32x32_new
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "ปิด Stock"
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'F_Tankstock1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 84)
        Me.Controls.Add(Me.RadButton1)
        Me.Controls.Add(Me.BPrint)
        Me.Controls.Add(Me.BCancel)
        Me.Name = "F_Tankstock1"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confirm"
        Me.ThemeName = "Office2010Blue"
        CType(Me.BPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents RoundRectShape1 As Telerik.WinControls.RoundRectShape
    Friend WithEvents BCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
End Class

