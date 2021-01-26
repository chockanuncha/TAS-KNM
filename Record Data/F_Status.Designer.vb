<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Status
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Status))
        Me.Office2010BlueTheme1 = New Telerik.WinControls.Themes.Office2010BlueTheme()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.RadPanel3 = New Telerik.WinControls.UI.RadPanel()
        Me.MasterGrid = New Telerik.WinControls.UI.RadGridView()
        Me.TSTATUSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Table = New RadControlsWinFormsApp1.DataSet_Table()
        Me.GridViewTemplate2 = New Telerik.WinControls.UI.GridViewTemplate()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.Btfirst = New System.Windows.Forms.ToolStripButton()
        Me.Btprevious = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Btnext = New System.Windows.Forms.ToolStripButton()
        Me.BtLast = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Btadd = New System.Windows.Forms.ToolStripButton()
        Me.BtEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.RadPanel1 = New Telerik.WinControls.UI.RadPanel()
        Me.P_SUM = New Telerik.WinControls.UI.RadTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BCancel = New Telerik.WinControls.UI.RadButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Bsave = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.DetailGroup = New System.Windows.Forms.GroupBox()
        Me.U_UPDATEBY = New Telerik.WinControls.UI.RadTextBox()
        Me.U_UPDATE = New Telerik.WinControls.UI.RadTextBox()
        Me.Island_No = New Telerik.WinControls.UI.RadTextBox()
        Me.StatusId = New Telerik.WinControls.UI.RadTextBox()
        Me.RoundRectShape1 = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.T_STATUSTableAdapter = New RadControlsWinFormsApp1.DataSet_TableTableAdapters.T_STATUSTableAdapter()
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel3.SuspendLayout()
        CType(Me.MasterGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MasterGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TSTATUSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_Table, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTemplate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.P_SUM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bsave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DetailGroup.SuspendLayout()
        CType(Me.U_UPDATEBY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_UPDATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Island_No, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadPanel3
        '
        Me.RadPanel3.Controls.Add(Me.MasterGrid)
        Me.RadPanel3.Controls.Add(Me.BindingNavigator1)
        Me.RadPanel3.Controls.Add(Me.RadPanel1)
        Me.RadPanel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.RadPanel3.Location = New System.Drawing.Point(0, 0)
        Me.RadPanel3.Name = "RadPanel3"
        Me.RadPanel3.Size = New System.Drawing.Size(508, 694)
        Me.RadPanel3.TabIndex = 14
        Me.RadPanel3.Text = "RadPanel3"
        '
        'MasterGrid
        '
        Me.MasterGrid.AllowDrop = True
        Me.MasterGrid.AllowShowFocusCues = True
        Me.MasterGrid.BackColor = System.Drawing.SystemColors.Control
        Me.MasterGrid.Cursor = System.Windows.Forms.Cursors.Default
        Me.MasterGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MasterGrid.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.MasterGrid.ForeColor = System.Drawing.Color.Black
        Me.MasterGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MasterGrid.Location = New System.Drawing.Point(0, 39)
        '
        '
        '
        Me.MasterGrid.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom
        Me.MasterGrid.MasterTemplate.AllowAddNewRow = False
        Me.MasterGrid.MasterTemplate.AllowCellContextMenu = False
        Me.MasterGrid.MasterTemplate.AllowColumnChooser = False
        Me.MasterGrid.MasterTemplate.AllowColumnHeaderContextMenu = False
        Me.MasterGrid.MasterTemplate.AllowColumnReorder = False
        Me.MasterGrid.MasterTemplate.AllowDeleteRow = False
        Me.MasterGrid.MasterTemplate.AllowDragToGroup = False
        Me.MasterGrid.MasterTemplate.AllowEditRow = False
        Me.MasterGrid.MasterTemplate.AllowRowReorder = True
        Me.MasterGrid.MasterTemplate.AllowRowResize = False
        Me.MasterGrid.MasterTemplate.AutoGenerateColumns = False
        Me.MasterGrid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewDecimalColumn1.DataType = GetType(Long)
        GridViewDecimalColumn1.EnableExpressionEditor = False
        GridViewDecimalColumn1.FieldName = "STATUS_ID"
        GridViewDecimalColumn1.HeaderText = "STATUS NO."
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.MinWidth = 100
        GridViewDecimalColumn1.Name = "STATUS_ID"
        GridViewDecimalColumn1.Width = 163
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "STATUS_NAME"
        GridViewTextBoxColumn1.HeaderText = "STATUS NAME"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.MinWidth = 200
        GridViewTextBoxColumn1.Name = "STATUS_NAME"
        GridViewTextBoxColumn1.Width = 322
        Me.MasterGrid.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewDecimalColumn1, GridViewTextBoxColumn1})
        Me.MasterGrid.MasterTemplate.DataSource = Me.TSTATUSBindingSource
        Me.MasterGrid.MasterTemplate.EnableFiltering = True
        Me.MasterGrid.MasterTemplate.EnableGrouping = False
        Me.MasterGrid.MasterTemplate.ShowRowHeaderColumn = False
        Me.MasterGrid.MasterTemplate.Templates.AddRange(New Telerik.WinControls.UI.GridViewTemplate() {Me.GridViewTemplate2})
        Me.MasterGrid.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.MasterGrid.Name = "MasterGrid"
        Me.MasterGrid.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.MasterGrid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MasterGrid.ShowGroupPanel = False
        Me.MasterGrid.Size = New System.Drawing.Size(508, 600)
        Me.MasterGrid.TabIndex = 40
        Me.MasterGrid.ThemeName = "Office2010Blue"
        '
        'TSTATUSBindingSource
        '
        Me.TSTATUSBindingSource.DataMember = "T_STATUS"
        Me.TSTATUSBindingSource.DataSource = Me.DataSet_Table
        '
        'DataSet_Table
        '
        Me.DataSet_Table.DataSetName = "DataSet_Table"
        Me.DataSet_Table.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewTemplate2
        '
        Me.GridViewTemplate2.ViewDefinition = TableViewDefinition1
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BindingSource = Me.TSTATUSBindingSource
        Me.BindingNavigator1.CountItem = Nothing
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Btfirst, Me.Btprevious, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.Btnext, Me.BtLast, Me.ToolStripSeparator3, Me.Btadd, Me.BtEdit, Me.ToolStripButton1})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Me.Btfirst
        Me.BindingNavigator1.MoveLastItem = Me.BtLast
        Me.BindingNavigator1.MoveNextItem = Me.Btnext
        Me.BindingNavigator1.MovePreviousItem = Me.Btprevious
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.ToolStripTextBox1
        Me.BindingNavigator1.Size = New System.Drawing.Size(508, 39)
        Me.BindingNavigator1.TabIndex = 49
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'Btfirst
        '
        Me.Btfirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btfirst.Image = CType(resources.GetObject("Btfirst.Image"), System.Drawing.Image)
        Me.Btfirst.Name = "Btfirst"
        Me.Btfirst.RightToLeftAutoMirrorImage = True
        Me.Btfirst.Size = New System.Drawing.Size(23, 36)
        Me.Btfirst.Text = "Move first"
        '
        'Btprevious
        '
        Me.Btprevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btprevious.Image = CType(resources.GetObject("Btprevious.Image"), System.Drawing.Image)
        Me.Btprevious.Name = "Btprevious"
        Me.Btprevious.RightToLeftAutoMirrorImage = True
        Me.Btprevious.Size = New System.Drawing.Size(23, 36)
        Me.Btprevious.Text = "Move previous"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Position"
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 23)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.ToolTipText = "Current position"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 36)
        Me.ToolStripLabel1.Text = "of {0}"
        Me.ToolStripLabel1.ToolTipText = "Total number of items"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'Btnext
        '
        Me.Btnext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btnext.Image = CType(resources.GetObject("Btnext.Image"), System.Drawing.Image)
        Me.Btnext.Name = "Btnext"
        Me.Btnext.RightToLeftAutoMirrorImage = True
        Me.Btnext.Size = New System.Drawing.Size(23, 36)
        Me.Btnext.Text = "Move next"
        '
        'BtLast
        '
        Me.BtLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtLast.Image = CType(resources.GetObject("BtLast.Image"), System.Drawing.Image)
        Me.BtLast.Name = "BtLast"
        Me.BtLast.RightToLeftAutoMirrorImage = True
        Me.BtLast.Size = New System.Drawing.Size(23, 36)
        Me.BtLast.Text = "Move last"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'Btadd
        '
        Me.Btadd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Btadd.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.add_32
        Me.Btadd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Btadd.Name = "Btadd"
        Me.Btadd.RightToLeftAutoMirrorImage = True
        Me.Btadd.Size = New System.Drawing.Size(36, 36)
        Me.Btadd.Text = "Add new"
        '
        'BtEdit
        '
        Me.BtEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtEdit.Image = CType(resources.GetObject("BtEdit.Image"), System.Drawing.Image)
        Me.BtEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtEdit.Name = "BtEdit"
        Me.BtEdit.RightToLeftAutoMirrorImage = True
        Me.BtEdit.Size = New System.Drawing.Size(36, 36)
        Me.BtEdit.Text = "Edit"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'RadPanel1
        '
        Me.RadPanel1.BackColor = System.Drawing.SystemColors.Control
        Me.RadPanel1.Controls.Add(Me.P_SUM)
        Me.RadPanel1.Controls.Add(Me.Label4)
        Me.RadPanel1.Controls.Add(Me.Label3)
        Me.RadPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadPanel1.Location = New System.Drawing.Point(0, 639)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(508, 55)
        Me.RadPanel1.TabIndex = 41
        '
        'P_SUM
        '
        Me.P_SUM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.P_SUM.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.P_SUM.Location = New System.Drawing.Point(350, 17)
        Me.P_SUM.Name = "P_SUM"
        Me.P_SUM.Size = New System.Drawing.Size(85, 25)
        Me.P_SUM.TabIndex = 39
        Me.P_SUM.TabStop = False
        Me.P_SUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(441, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 19)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Status"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(232, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 19)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "จำนวน Status"
        '
        'RadLabel2
        '
        Me.RadLabel2.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel2.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadLabel2.Location = New System.Drawing.Point(115, 117)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(104, 27)
        Me.RadLabel2.TabIndex = 2
        Me.RadLabel2.Text = "Status No :"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        '
        'RadLabel8
        '
        Me.RadLabel8.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel8.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadLabel8.Location = New System.Drawing.Point(89, 158)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(130, 27)
        Me.RadLabel8.TabIndex = 37
        Me.RadLabel8.Text = "Status Name :"
        Me.RadLabel8.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel8.TextWrap = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Label2.Location = New System.Drawing.Point(110, 243)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 23)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Update By :"
        '
        'BCancel
        '
        Me.BCancel.BackColor = System.Drawing.Color.Transparent
        Me.BCancel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BCancel.ForeColor = System.Drawing.Color.Black
        Me.BCancel.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BCancel.Location = New System.Drawing.Point(397, 304)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(115, 44)
        Me.BCancel.TabIndex = 17
        Me.BCancel.Text = "Cancel"
        Me.BCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BCancel.ThemeName = "Breeze"
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BCancel.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Cancel"
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 16.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label5.Location = New System.Drawing.Point(3, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(589, 39)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "Database System > Status"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bsave
        '
        Me.Bsave.BackColor = System.Drawing.Color.Transparent
        Me.Bsave.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bsave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bsave.ForeColor = System.Drawing.Color.Black
        Me.Bsave.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        Me.Bsave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.Bsave.Location = New System.Drawing.Point(268, 304)
        Me.Bsave.Name = "Bsave"
        Me.Bsave.Size = New System.Drawing.Size(115, 44)
        Me.Bsave.TabIndex = 16
        Me.Bsave.Text = "Save"
        Me.Bsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Bsave.ThemeName = "Breeze"
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Save"
        '
        'RadLabel4
        '
        Me.RadLabel4.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel4.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadLabel4.Location = New System.Drawing.Point(96, 201)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(123, 27)
        Me.RadLabel4.TabIndex = 116
        Me.RadLabel4.Text = "Last Update :"
        Me.RadLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'DetailGroup
        '
        Me.DetailGroup.BackColor = System.Drawing.SystemColors.Control
        Me.DetailGroup.Controls.Add(Me.RadLabel4)
        Me.DetailGroup.Controls.Add(Me.Bsave)
        Me.DetailGroup.Controls.Add(Me.Label5)
        Me.DetailGroup.Controls.Add(Me.BCancel)
        Me.DetailGroup.Controls.Add(Me.U_UPDATEBY)
        Me.DetailGroup.Controls.Add(Me.U_UPDATE)
        Me.DetailGroup.Controls.Add(Me.Label2)
        Me.DetailGroup.Controls.Add(Me.RadLabel8)
        Me.DetailGroup.Controls.Add(Me.Island_No)
        Me.DetailGroup.Controls.Add(Me.RadLabel2)
        Me.DetailGroup.Controls.Add(Me.StatusId)
        Me.DetailGroup.Dock = System.Windows.Forms.DockStyle.Right
        Me.DetailGroup.Enabled = False
        Me.DetailGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DetailGroup.Location = New System.Drawing.Point(506, 0)
        Me.DetailGroup.Name = "DetailGroup"
        Me.DetailGroup.Size = New System.Drawing.Size(595, 694)
        Me.DetailGroup.TabIndex = 15
        Me.DetailGroup.TabStop = False
        '
        'U_UPDATEBY
        '
        Me.U_UPDATEBY.BackColor = System.Drawing.SystemColors.Control
        Me.U_UPDATEBY.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TSTATUSBindingSource, "UPDATE_BY", True))
        Me.U_UPDATEBY.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.U_UPDATEBY.Location = New System.Drawing.Point(221, 240)
        Me.U_UPDATEBY.Name = "U_UPDATEBY"
        Me.U_UPDATEBY.ReadOnly = True
        Me.U_UPDATEBY.Size = New System.Drawing.Size(291, 28)
        Me.U_UPDATEBY.TabIndex = 13
        Me.U_UPDATEBY.TabStop = False
        Me.U_UPDATEBY.ThemeName = "Office2010Blue"
        CType(Me.U_UPDATEBY.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        CType(Me.U_UPDATEBY.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        CType(Me.U_UPDATEBY.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Tahoma", 14.0!)
        '
        'U_UPDATE
        '
        Me.U_UPDATE.BackColor = System.Drawing.SystemColors.Control
        Me.U_UPDATE.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TSTATUSBindingSource, "UPDATE_DATE", True))
        Me.U_UPDATE.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.U_UPDATE.Location = New System.Drawing.Point(221, 200)
        Me.U_UPDATE.Name = "U_UPDATE"
        Me.U_UPDATE.ReadOnly = True
        Me.U_UPDATE.Size = New System.Drawing.Size(291, 28)
        Me.U_UPDATE.TabIndex = 12
        Me.U_UPDATE.TabStop = False
        Me.U_UPDATE.ThemeName = "Office2010Blue"
        CType(Me.U_UPDATE.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        CType(Me.U_UPDATE.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        CType(Me.U_UPDATE.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Tahoma", 14.0!)
        '
        'Island_No
        '
        Me.Island_No.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TSTATUSBindingSource, "STATUS_NAME", True))
        Me.Island_No.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Island_No.Location = New System.Drawing.Point(221, 157)
        Me.Island_No.Name = "Island_No"
        Me.Island_No.Size = New System.Drawing.Size(291, 28)
        Me.Island_No.TabIndex = 1
        Me.Island_No.TabStop = False
        Me.Island_No.ThemeName = "Office2010Blue"
        '
        'StatusId
        '
        Me.StatusId.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TSTATUSBindingSource, "STATUS_ID", True))
        Me.StatusId.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.StatusId.Location = New System.Drawing.Point(221, 116)
        Me.StatusId.Name = "StatusId"
        Me.StatusId.Size = New System.Drawing.Size(291, 28)
        Me.StatusId.TabIndex = 0
        Me.StatusId.TabStop = False
        Me.StatusId.ThemeName = "Office2010Blue"
        '
        'RoundRectShape1
        '
        Me.RoundRectShape1.IsRightToLeft = False
        '
        'T_STATUSTableAdapter
        '
        Me.T_STATUSTableAdapter.ClearBeforeFill = True
        '
        'F_Status
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 694)
        Me.Controls.Add(Me.DetailGroup)
        Me.Controls.Add(Me.RadPanel3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "F_Status"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database System > Status"
        Me.ThemeName = "Office2010Blue"
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel3.ResumeLayout(False)
        Me.RadPanel3.PerformLayout()
        CType(Me.MasterGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MasterGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TSTATUSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_Table, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTemplate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        Me.RadPanel1.PerformLayout()
        CType(Me.P_SUM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bsave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DetailGroup.ResumeLayout(False)
        Me.DetailGroup.PerformLayout()
        CType(Me.U_UPDATEBY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_UPDATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Island_No, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Office2010BlueTheme1 As Telerik.WinControls.Themes.Office2010BlueTheme
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents RadPanel3 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents MasterGrid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents GridViewTemplate2 As Telerik.WinControls.UI.GridViewTemplate
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents Btfirst As System.Windows.Forms.ToolStripButton
    Friend WithEvents Btprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtLast As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btadd As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents P_SUM As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Bsave As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents DetailGroup As System.Windows.Forms.GroupBox
    Friend WithEvents U_UPDATEBY As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents U_UPDATE As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Island_No As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents StatusId As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RoundRectShape1 As Telerik.WinControls.RoundRectShape
    Friend WithEvents DataSet_Table As DataSet_Table
    Friend WithEvents TSTATUSBindingSource As BindingSource
    Friend WithEvents T_STATUSTableAdapter As DataSet_TableTableAdapters.T_STATUSTableAdapter
End Class

