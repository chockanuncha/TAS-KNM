<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Workonlan
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Me.RadPanel2 = New Telerik.WinControls.UI.RadPanel()
        Me.BCancel = New Telerik.WinControls.UI.RadButton()
        Me.Bsave = New Telerik.WinControls.UI.RadButton()
        Me.RadPanel1 = New Telerik.WinControls.UI.RadPanel()
        Me.MasterGrid = New Telerik.WinControls.UI.RadGridView()
        Me.TComputerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Dataset_table = New RadControlsWinFormsApp1.DataSet_Table()
        Me.GridViewTemplate2 = New Telerik.WinControls.UI.GridViewTemplate()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.T_COMPUTERTableAdapter = New RadControlsWinFormsApp1.DataSet_TableTableAdapters.T_COMPUTERTableAdapter
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.RoundRectShape1 = New Telerik.WinControls.RoundRectShape(Me.components)
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bsave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.MasterGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MasterGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TComputerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dataset_table, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTemplate2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadPanel2
        '
        Me.RadPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadPanel2.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadPanel2.ForeColor = System.Drawing.Color.White
        Me.RadPanel2.Location = New System.Drawing.Point(0, 0)
        Me.RadPanel2.Name = "RadPanel2"
        Me.RadPanel2.Size = New System.Drawing.Size(1012, 92)
        Me.RadPanel2.TabIndex = 126
        Me.RadPanel2.Text = "Configuration > StartUp Computer"
        Me.RadPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadPanel2.GetChildAt(0), Telerik.WinControls.UI.RadPanelElement).Text = "Configuration > StartUp Computer"
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(248, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(244, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).NumberOfColors = 1
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'BCancel
        '
        Me.BCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        'Me.BCANCEL.BackColor = System.Drawing.Color.Transparent
        Me.BCancel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BCancel.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BCancel.Location = New System.Drawing.Point(109, 313)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(142, 56)
        Me.BCancel.TabIndex = 129
        Me.BCancel.Text = "ปิด"
        Me.BCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BCancel.ThemeName = "Breeze"
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "ปิด"
        '
        'Bsave
        '
        'Me.BSAVE.BackColor = System.Drawing.Color.Transparent
        Me.Bsave.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bsave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bsave.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Computer
        Me.Bsave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.Bsave.Location = New System.Drawing.Point(15, 39)
        Me.Bsave.Name = "Bsave"
        Me.Bsave.Size = New System.Drawing.Size(236, 81)
        Me.Bsave.TabIndex = 128
        Me.Bsave.Text = "StartUp Computer"
        Me.Bsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Bsave.ThemeName = "Breeze"
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Computer
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "StartUp Computer"
        '
        'RadPanel1
        '
        Me.RadPanel1.Controls.Add(Me.MasterGrid)
        Me.RadPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPanel1.Location = New System.Drawing.Point(0, 92)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(749, 381)
        Me.RadPanel1.TabIndex = 130
        '
        'MasterGrid
        '
        Me.MasterGrid.AllowDrop = True
        Me.MasterGrid.AllowShowFocusCues = True
        Me.MasterGrid.AutoScroll = True
        Me.MasterGrid.BackColor = System.Drawing.SystemColors.Control
        Me.MasterGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.MasterGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MasterGrid.EnableHotTracking = False
        Me.MasterGrid.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.MasterGrid.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MasterGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MasterGrid.Location = New System.Drawing.Point(0, 0)
        '
        'MasterGrid
        '
        Me.MasterGrid.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        Me.MasterGrid.MasterTemplate.AllowAddNewRow = False
        Me.MasterGrid.MasterTemplate.AllowCellContextMenu = False
        Me.MasterGrid.MasterTemplate.AllowColumnChooser = False
        Me.MasterGrid.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.MasterGrid.MasterTemplate.AllowColumnReorder = False
        Me.MasterGrid.MasterTemplate.AllowColumnResize = False
        Me.MasterGrid.MasterTemplate.AllowDeleteRow = False
        Me.MasterGrid.MasterTemplate.AllowDragToGroup = False
        Me.MasterGrid.MasterTemplate.AllowEditRow = False
        Me.MasterGrid.MasterTemplate.AllowRowReorder = True
        Me.MasterGrid.MasterTemplate.AllowRowResize = False
        Me.MasterGrid.MasterTemplate.AutoGenerateColumns = False
        Me.MasterGrid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "C_NAME"
        GridViewTextBoxColumn1.HeaderText = "ชื่อเครื่อง"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.Name = "C_NAME"
        GridViewTextBoxColumn1.Width = 181
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "C_IPADDRESS"
        GridViewTextBoxColumn2.HeaderText = "IP ADDRESS"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.Name = "C_IPADDRESS"
        GridViewTextBoxColumn2.Width = 181
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "C_MACADDRESS"
        GridViewTextBoxColumn3.HeaderText = "MAC ADDRESS"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.Name = "C_MACADDRESS"
        GridViewTextBoxColumn3.Width = 181
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "C_SUBNET"
        GridViewTextBoxColumn4.HeaderText = "SUBNETMARK"
        GridViewTextBoxColumn4.IsAutoGenerated = True
        GridViewTextBoxColumn4.Name = "C_SUBNET"
        GridViewTextBoxColumn4.Width = 185
        Me.MasterGrid.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4})
        Me.MasterGrid.MasterTemplate.DataSource = Me.TComputerBindingSource
        Me.MasterGrid.MasterTemplate.EnableFiltering = True
        Me.MasterGrid.MasterTemplate.EnableGrouping = False
        Me.MasterGrid.MasterTemplate.ShowRowHeaderColumn = False
        Me.MasterGrid.MasterTemplate.Templates.AddRange(New Telerik.WinControls.UI.GridViewTemplate() {Me.GridViewTemplate2})
        Me.MasterGrid.Name = "MasterGrid"
        Me.MasterGrid.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.MasterGrid.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.MasterGrid.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.MasterGrid.ShowGroupPanel = False
        Me.MasterGrid.Size = New System.Drawing.Size(749, 381)
        Me.MasterGrid.TabIndex = 43
        Me.MasterGrid.ThemeName = "Office2010Blue"
        '
        'TComputerBindingSource
        '
        Me.TComputerBindingSource.DataMember = "T_COMPUTER"
        Me.TComputerBindingSource.DataSource = Me.Dataset_table
        '
        'Dataset_table
        '
        Me.Dataset_table.DataSetName = "Dataset_table"
        Me.Dataset_table.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewTemplate2
        '
        Me.GridViewTemplate2.EnableGrouping = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BCancel)
        Me.GroupBox1.Controls.Add(Me.Bsave)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(749, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 381)
        Me.GroupBox1.TabIndex = 131
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Startup Computer"
        '
        'T_COMPUTERTableAdapter
        '
        Me.T_COMPUTERTableAdapter.ClearBeforeFill = True
        '
        'Workonlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 473)
        Me.Controls.Add(Me.RadPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RadPanel2)
        Me.Name = "Workonlan"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Workonlan"
        Me.ThemeName = "Office2010Blue"
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bsave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        CType(Me.MasterGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MasterGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TComputerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dataset_table, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTemplate2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadPanel2 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents BCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents Bsave As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents MasterGrid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents GridViewTemplate2 As Telerik.WinControls.UI.GridViewTemplate
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TComputerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Dataset_table As RadControlsWinFormsApp1.DataSet_Table
    Friend WithEvents T_COMPUTERTableAdapter As RadControlsWinFormsApp1.DataSet_TableTableAdapters.T_COMPUTERTableAdapter
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents RoundRectShape1 As Telerik.WinControls.RoundRectShape
End Class

