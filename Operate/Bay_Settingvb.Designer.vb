<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bay_Setting
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
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Bay_Setting))
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.RoundRectShape1 = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.RadPanel3 = New Telerik.WinControls.UI.RadPanel()
        Me.BTCANCEL = New Telerik.WinControls.UI.RadButton()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
        Me.TBAYBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Table = New RadControlsWinFormsApp1.DataSet_Table()
        Me.T_BAYTableAdapter = New RadControlsWinFormsApp1.DataSet_TableTableAdapters.T_BAYTableAdapter()
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel3.SuspendLayout()
        CType(Me.BTCANCEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBAYBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Table, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RoundRectShape1
        '
        Me.RoundRectShape1.IsRightToLeft = False
        '
        'RadPanel3
        '
        Me.RadPanel3.Controls.Add(Me.BTCANCEL)
        Me.RadPanel3.Controls.Add(Me.RadButton2)
        Me.RadPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadPanel3.Location = New System.Drawing.Point(0, 601)
        Me.RadPanel3.Name = "RadPanel3"
        Me.RadPanel3.Size = New System.Drawing.Size(1358, 93)
        Me.RadPanel3.TabIndex = 1
        Me.RadPanel3.ThemeName = "Breeze"
        '
        'BTCANCEL
        '
        Me.BTCANCEL.BackColor = System.Drawing.Color.Transparent
        Me.BTCANCEL.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTCANCEL.ForeColor = System.Drawing.Color.Black
        Me.BTCANCEL.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BTCANCEL.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BTCANCEL.Location = New System.Drawing.Point(1175, 17)
        Me.BTCANCEL.Name = "BTCANCEL"
        Me.BTCANCEL.Size = New System.Drawing.Size(166, 64)
        Me.BTCANCEL.TabIndex = 22
        Me.BTCANCEL.Text = "Cancel"
        Me.BTCANCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTCANCEL.ThemeName = "Breeze"
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Cancel"
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'RadButton2
        '
        Me.RadButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadButton2.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadButton2.ForeColor = System.Drawing.Color.Black
        Me.RadButton2.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        Me.RadButton2.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadButton2.Location = New System.Drawing.Point(991, 17)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(166, 64)
        Me.RadButton2.TabIndex = 0
        Me.RadButton2.Text = "Save"
        Me.RadButton2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.RadButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton2.ThemeName = "Breeze"
        CType(Me.RadButton2.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        CType(Me.RadButton2.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.RadButton2.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadButton2.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        CType(Me.RadButton2.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Save"
        CType(Me.RadButton2.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).GradientStyle = Telerik.WinControls.GradientStyles.Solid
        CType(Me.RadButton2.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).Shape = Me.RoundRectShape1
        '
        'RadGridView1
        '
        Me.RadGridView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RadGridView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadGridView1.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadGridView1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridView1.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.RadGridView1.MasterTemplate.AllowAddNewRow = False
        Me.RadGridView1.MasterTemplate.AutoGenerateColumns = False
        Me.RadGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewDecimalColumn1.DataType = GetType(Long)
        GridViewDecimalColumn1.DecimalPlaces = 0
        GridViewDecimalColumn1.EnableExpressionEditor = False
        GridViewDecimalColumn1.FieldName = "BAY_NUMBER"
        GridViewDecimalColumn1.HeaderText = "Bay No."
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.MinWidth = 120
        GridViewDecimalColumn1.Name = "BAY_NUMBER"
        GridViewDecimalColumn1.ReadOnly = True
        GridViewDecimalColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewDecimalColumn1.Width = 255
        GridViewDecimalColumn2.DataType = GetType(Long)
        GridViewDecimalColumn2.DecimalPlaces = 0
        GridViewDecimalColumn2.EnableExpressionEditor = False
        GridViewDecimalColumn2.FieldName = "ISLAND_NUMBER"
        GridViewDecimalColumn2.HeaderText = "Island No."
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.MinWidth = 120
        GridViewDecimalColumn2.Name = "ISLAND_NUMBER"
        GridViewDecimalColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewDecimalColumn2.Width = 255
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "BAY_POSITION"
        GridViewTextBoxColumn1.HeaderText = "Bay Position"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.MinWidth = 170
        GridViewTextBoxColumn1.Name = "BAY_POSITION"
        GridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn1.Width = 362
        GridViewCheckBoxColumn1.DataType = GetType(Decimal)
        GridViewCheckBoxColumn1.EnableExpressionEditor = False
        GridViewCheckBoxColumn1.FieldName = "BAY_STATUS"
        GridViewCheckBoxColumn1.HeaderText = "Status"
        GridViewCheckBoxColumn1.MinWidth = 100
        GridViewCheckBoxColumn1.Name = "Bay_status"
        GridViewCheckBoxColumn1.Width = 213
        GridViewDecimalColumn3.DataType = GetType(Long)
        GridViewDecimalColumn3.DecimalPlaces = 0
        GridViewDecimalColumn3.EnableExpressionEditor = False
        GridViewDecimalColumn3.FieldName = "BAY_QUEUE"
        GridViewDecimalColumn3.HeaderText = "Queue in Bay"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.MinWidth = 120
        GridViewDecimalColumn3.Name = "BAY_QUEUE"
        GridViewDecimalColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewDecimalColumn3.Width = 256
        Me.RadGridView1.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewDecimalColumn1, GridViewDecimalColumn2, GridViewTextBoxColumn1, GridViewCheckBoxColumn1, GridViewDecimalColumn3})
        Me.RadGridView1.MasterTemplate.DataSource = Me.TBAYBindingSource
        Me.RadGridView1.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.RadGridView1.Name = "RadGridView1"
        Me.RadGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadGridView1.ShowGroupPanel = False
        Me.RadGridView1.Size = New System.Drawing.Size(1358, 601)
        Me.RadGridView1.TabIndex = 0
        Me.RadGridView1.ThemeName = "Breeze"
        '
        'TBAYBindingSource
        '
        Me.TBAYBindingSource.DataMember = "T_BAY"
        Me.TBAYBindingSource.DataSource = Me.DataSet_Table
        '
        'DataSet_Table
        '
        Me.DataSet_Table.DataSetName = "DataSet_Table"
        Me.DataSet_Table.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_BAYTableAdapter
        '
        Me.T_BAYTableAdapter.ClearBeforeFill = True
        '
        'Bay_Setting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1358, 694)
        Me.Controls.Add(Me.RadGridView1)
        Me.Controls.Add(Me.RadPanel3)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None
        Me.Name = "Bay_Setting"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Tracking >> Bay Settings"
        Me.ThemeName = "Office2010Blue"
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel3.ResumeLayout(False)
        CType(Me.BTCANCEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBAYBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Table, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents RoundRectShape1 As Telerik.WinControls.RoundRectShape
    Friend WithEvents RadPanel3 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents BTCANCEL As Telerik.WinControls.UI.RadButton
    Friend WithEvents DataSet_Table As DataSet_Table
    Friend WithEvents TBAYBindingSource As BindingSource
    Friend WithEvents T_BAYTableAdapter As DataSet_TableTableAdapters.T_BAYTableAdapter
End Class

