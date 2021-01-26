<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Driverblacklist
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
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Driverblacklist))
        Me.Office2010BlueTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MasterGrid = New Telerik.WinControls.UI.RadGridView()
        Me.GridViewTemplate5 = New Telerik.WinControls.UI.GridViewTemplate()
        Me.DataSet_Table = New RadControlsWinFormsApp1.DataSet_Table()
        Me.TDRIVERBLACKLISTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_DRIVER_BLACKLISTTableAdapter = New RadControlsWinFormsApp1.DataSet_TableTableAdapters.T_DRIVER_BLACKLISTTableAdapter()
        CType(Me.MasterGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MasterGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTemplate5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Table, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TDRIVERBLACKLISTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Underline)
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(981, 40)
        Me.Label7.TabIndex = 132
        Me.Label7.Text = "Driver Black List"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MasterGrid
        '
        Me.MasterGrid.AllowShowFocusCues = True
        Me.MasterGrid.AutoScroll = True
        Me.MasterGrid.BackColor = System.Drawing.SystemColors.Control
        Me.MasterGrid.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.MasterGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MasterGrid.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MasterGrid.ForeColor = System.Drawing.Color.Red
        Me.MasterGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MasterGrid.Location = New System.Drawing.Point(0, 40)
        '
        '
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
        GridViewTextBoxColumn1.FieldName = "DRIVER_NUMBER"
        GridViewTextBoxColumn1.HeaderText = "Driver No."
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.MinWidth = 80
        GridViewTextBoxColumn1.Name = "DRIVER_NUMBER"
        GridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn1.Width = 148
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "DRIVER_LICENSE"
        GridViewTextBoxColumn2.HeaderText = "บัตรประชาชนเลขที่"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.IsVisible = False
        GridViewTextBoxColumn2.MinWidth = 80
        GridViewTextBoxColumn2.Name = "DRIVER_LICENSE"
        GridViewTextBoxColumn2.Width = 80
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "DRIVER_NAME"
        GridViewTextBoxColumn3.HeaderText = "First Name"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.MinWidth = 120
        GridViewTextBoxColumn3.Name = "DRIVER_NAME"
        GridViewTextBoxColumn3.Width = 221
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "DRIVER_LASTNAME"
        GridViewTextBoxColumn4.HeaderText = "Last Name"
        GridViewTextBoxColumn4.IsAutoGenerated = True
        GridViewTextBoxColumn4.MinWidth = 120
        GridViewTextBoxColumn4.Name = "DRIVER_LASTNAME"
        GridViewTextBoxColumn4.Width = 221
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "Blacklist_Detail"
        GridViewTextBoxColumn5.HeaderText = "Black List Details"
        GridViewTextBoxColumn5.IsAutoGenerated = True
        GridViewTextBoxColumn5.MinWidth = 200
        GridViewTextBoxColumn5.Name = "Blacklist_Detail"
        GridViewTextBoxColumn5.Width = 369
        Me.MasterGrid.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5})
        Me.MasterGrid.MasterTemplate.DataSource = Me.TDRIVERBLACKLISTBindingSource
        Me.MasterGrid.MasterTemplate.EnableFiltering = True
        Me.MasterGrid.MasterTemplate.ShowRowHeaderColumn = False
        Me.MasterGrid.MasterTemplate.Templates.AddRange(New Telerik.WinControls.UI.GridViewTemplate() {Me.GridViewTemplate5})
        Me.MasterGrid.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.MasterGrid.Name = "MasterGrid"
        Me.MasterGrid.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.MasterGrid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MasterGrid.Size = New System.Drawing.Size(981, 587)
        Me.MasterGrid.TabIndex = 133
        Me.MasterGrid.ThemeName = "Office2010Blue"
        '
        'GridViewTemplate5
        '
        Me.GridViewTemplate5.ViewDefinition = TableViewDefinition1
        '
        'DataSet_Table
        '
        Me.DataSet_Table.DataSetName = "DataSet_Table"
        Me.DataSet_Table.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TDRIVERBLACKLISTBindingSource
        '
        Me.TDRIVERBLACKLISTBindingSource.DataMember = "T_DRIVER_BLACKLIST"
        Me.TDRIVERBLACKLISTBindingSource.DataSource = Me.DataSet_Table
        '
        'T_DRIVER_BLACKLISTTableAdapter
        '
        Me.T_DRIVER_BLACKLISTTableAdapter.ClearBeforeFill = True
        '
        'Driverblacklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 627)
        Me.Controls.Add(Me.MasterGrid)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None
        Me.Name = "Driverblacklist"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Driver Black List"
        Me.ThemeName = "Office2010Blue"
        CType(Me.MasterGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MasterGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTemplate5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Table, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TDRIVERBLACKLISTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Office2010BlueTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MasterGrid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents GridViewTemplate5 As Telerik.WinControls.UI.GridViewTemplate
    Friend WithEvents DataSet_Table As DataSet_Table
    Friend WithEvents TDRIVERBLACKLISTBindingSource As BindingSource
    Friend WithEvents T_DRIVER_BLACKLISTTableAdapter As DataSet_TableTableAdapters.T_DRIVER_BLACKLISTTableAdapter
End Class

