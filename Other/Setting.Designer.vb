<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Setting
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
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewCheckBoxColumn2 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Me.RadPanel2 = New Telerik.WinControls.UI.RadPanel()
        Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
        Me.TSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IRPCDataset = New RadControlsWinFormsApp1.IRPCDataset()
        Me.T_SETTINGTableAdapter = New RadControlsWinFormsApp1.IRPCDatasetTableAdapters.T_SETTINGTableAdapter()
        Me.BTCANCEL = New Telerik.WinControls.UI.RadButton()
        Me.BTSAVE = New Telerik.WinControls.UI.RadButton()
        Me.RadPanel1 = New Telerik.WinControls.UI.RadPanel()
        Me.RadPanel3 = New Telerik.WinControls.UI.RadPanel()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.RoundRectShape1 = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IRPCDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BTCANCEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BTSAVE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel3.SuspendLayout()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadPanel2
        '
        Me.RadPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadPanel2.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadPanel2.ForeColor = System.Drawing.Color.White
        Me.RadPanel2.Location = New System.Drawing.Point(0, 0)
        Me.RadPanel2.Name = "RadPanel2"
        Me.RadPanel2.Size = New System.Drawing.Size(673, 160)
        Me.RadPanel2.TabIndex = 11
        Me.RadPanel2.Text = "Configuration"
        Me.RadPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadPanel2.GetChildAt(0), Telerik.WinControls.UI.RadPanelElement).Text = "Configuration"
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(248, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(244, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).NumberOfColors = 1
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'RadGridView1
        '
        Me.RadGridView1.AutoScroll = True
        Me.RadGridView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RadGridView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadGridView1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold)
        Me.RadGridView1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridView1.Location = New System.Drawing.Point(0, 160)
        '
        'RadGridView1
        '
        Me.RadGridView1.MasterTemplate.AllowAddNewRow = False
        Me.RadGridView1.MasterTemplate.AllowDeleteRow = False
        Me.RadGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "APPNAME"
        GridViewTextBoxColumn2.HeaderText = "App Name."
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.MinWidth = 430
        GridViewTextBoxColumn2.Name = "APPNAME"
        GridViewTextBoxColumn2.Width = 431
        GridViewCheckBoxColumn2.DataType = GetType(Integer)
        GridViewCheckBoxColumn2.EnableExpressionEditor = False
        GridViewCheckBoxColumn2.FieldName = "STATUS"
        GridViewCheckBoxColumn2.HeaderText = "Show / Hide"
        GridViewCheckBoxColumn2.MinWidth = 220
        GridViewCheckBoxColumn2.Name = "STATUS"
        GridViewCheckBoxColumn2.Width = 221
        Me.RadGridView1.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn2, GridViewCheckBoxColumn2})
        Me.RadGridView1.MasterTemplate.DataSource = Me.TSettingBindingSource
        Me.RadGridView1.MasterTemplate.EnableGrouping = False
        Me.RadGridView1.Name = "RadGridView1"
        Me.RadGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadGridView1.Size = New System.Drawing.Size(673, 514)
        Me.RadGridView1.TabIndex = 12
        Me.RadGridView1.Text = "RadGridView1"
        Me.RadGridView1.ThemeName = "Office2010Blue"
        '
        'TSettingBindingSource
        '
        Me.TSettingBindingSource.DataMember = "T_SETTING"
        Me.TSettingBindingSource.DataSource = Me.IRPCDataset
        '
        'IRPCDataset
        '
        Me.IRPCDataset.DataSetName = "IRPCDataset"
        Me.IRPCDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_SETTINGTableAdapter
        '
        Me.T_SETTINGTableAdapter.ClearBeforeFill = True
        '
        'BTCANCEL
        '
        Me.BTCANCEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTCANCEL.BackColor = System.Drawing.Color.Transparent
        Me.BTCANCEL.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTCANCEL.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BTCANCEL.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BTCANCEL.Location = New System.Drawing.Point(495, 14)
        Me.BTCANCEL.Name = "BTCANCEL"
        Me.BTCANCEL.Size = New System.Drawing.Size(115, 56)
        Me.BTCANCEL.TabIndex = 32
        Me.BTCANCEL.Text = "ยกเลิก"
        Me.BTCANCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTCANCEL.ThemeName = "Breeze"
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "ยกเลิก"
        '
        'BTSAVE
        '
        Me.BTSAVE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTSAVE.BackColor = System.Drawing.Color.Transparent
        Me.BTSAVE.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTSAVE.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTSAVE.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        Me.BTSAVE.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BTSAVE.Location = New System.Drawing.Point(366, 14)
        Me.BTSAVE.Name = "BTSAVE"
        Me.BTSAVE.Size = New System.Drawing.Size(115, 56)
        Me.BTSAVE.TabIndex = 31
        Me.BTSAVE.Text = "บันทึก"
        Me.BTSAVE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTSAVE.ThemeName = "Breeze"
        CType(Me.BTSAVE.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        CType(Me.BTSAVE.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BTSAVE.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTSAVE.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTSAVE.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "บันทึก"
        '
        'RadPanel1
        '
        Me.RadPanel1.Controls.Add(Me.BTSAVE)
        Me.RadPanel1.Controls.Add(Me.BTCANCEL)
        Me.RadPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadPanel1.Location = New System.Drawing.Point(10, 400)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(622, 82)
        Me.RadPanel1.TabIndex = 33
        '
        'RadPanel3
        '
        Me.RadPanel3.Controls.Add(Me.RadButton1)
        Me.RadPanel3.Controls.Add(Me.RadButton2)
        Me.RadPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadPanel3.Location = New System.Drawing.Point(0, 605)
        Me.RadPanel3.Name = "RadPanel3"
        Me.RadPanel3.Size = New System.Drawing.Size(673, 69)
        Me.RadPanel3.TabIndex = 13
        '
        'RadButton1
        '
        Me.RadButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadButton1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadButton1.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.RadButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadButton1.Location = New System.Drawing.Point(546, 13)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(115, 44)
        Me.RadButton1.TabIndex = 6
        Me.RadButton1.Text = "ยกเลิก"
        Me.RadButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton1.ThemeName = "Breeze"
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "ยกเลิก"
        CType(Me.RadButton1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'RadButton2
        '
        Me.RadButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.RadButton2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadButton2.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        Me.RadButton2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadButton2.Location = New System.Drawing.Point(417, 13)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(115, 44)
        Me.RadButton2.TabIndex = 5
        Me.RadButton2.Text = "บันทึก"
        Me.RadButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton2.ThemeName = "Breeze"
        CType(Me.RadButton2.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        CType(Me.RadButton2.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.RadButton2.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadButton2.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadButton2.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "บันทึก"
        CType(Me.RadButton2.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 674)
        Me.Controls.Add(Me.RadPanel3)
        Me.Controls.Add(Me.RadGridView1)
        Me.Controls.Add(Me.RadPanel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Setting"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuration"
        Me.ThemeName = "Office2010Blue"
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TSettingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IRPCDataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BTCANCEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BTSAVE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel3.ResumeLayout(False)
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadPanel2 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents TSettingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IRPCDataset As RadControlsWinFormsApp1.IRPCDataset
    Friend WithEvents T_SETTINGTableAdapter As RadControlsWinFormsApp1.IRPCDatasetTableAdapters.T_SETTINGTableAdapter
    Friend WithEvents BTCANCEL As Telerik.WinControls.UI.RadButton
    Friend WithEvents BTSAVE As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents RadPanel3 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents RoundRectShape1 As Telerik.WinControls.RoundRectShape
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
End Class

