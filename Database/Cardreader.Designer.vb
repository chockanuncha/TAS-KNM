<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cardreaderform
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cardreaderform))
        Me.TCardreaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IRPCDataset = New RadControlsWinFormsApp1.IRPCDataset()
        Me.Windows7Theme1 = New Telerik.WinControls.Themes.Windows7Theme()
        Me.DetailGroup = New System.Windows.Forms.GroupBox()
        Me.Card_Comm = New Telerik.WinControls.UI.RadTextBox()
        Me.Meter1 = New Telerik.WinControls.UI.RadDropDownList()
        Me.TbayBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Bsave = New Telerik.WinControls.UI.RadButton()
        Me.RoundRectShape1 = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.BCancel = New Telerik.WinControls.UI.RadButton()
        Me.UPDATEBY = New Telerik.WinControls.UI.RadTextBox()
        Me.U_UPDATE = New Telerik.WinControls.UI.RadTextBox()
        Me.U_REMARK = New System.Windows.Forms.RichTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Location = New System.Windows.Forms.ComboBox()
        Me.Card_Address = New Telerik.WinControls.UI.RadTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Status_off = New System.Windows.Forms.RadioButton()
        Me.Status_on = New System.Windows.Forms.RadioButton()
        Me.RadLabel10 = New Telerik.WinControls.UI.RadLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LoadProcess_no = New System.Windows.Forms.RadioButton()
        Me.LoadProcess_ok = New System.Windows.Forms.RadioButton()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.Card_No = New Telerik.WinControls.UI.RadTextBox()
        Me.Card_Name = New Telerik.WinControls.UI.RadTextBox()
        Me.RadPanel3 = New Telerik.WinControls.UI.RadPanel()
        Me.MasterGrid = New Telerik.WinControls.UI.RadGridView()
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
        Me.G_SUM = New Telerik.WinControls.UI.RadTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.T_CARDREADERTableAdapter = New RadControlsWinFormsApp1.IRPCDatasetTableAdapters.T_CARDREADERTableAdapter()
        Me.T_BAYTableAdapter = New RadControlsWinFormsApp1.IRPCDatasetTableAdapters.T_BAYTableAdapter()
        CType(Me.TCardreaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IRPCDataset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DetailGroup.SuspendLayout()
        CType(Me.Card_Comm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Meter1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbayBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Bsave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UPDATEBY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_UPDATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Card_Address, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Card_No, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Card_Name, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel3.SuspendLayout()
        CType(Me.MasterGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MasterGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTemplate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.G_SUM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TCardreaderBindingSource
        '
        Me.TCardreaderBindingSource.DataMember = "T_CARDREADER"
        Me.TCardreaderBindingSource.DataSource = Me.IRPCDataset
        '
        'IRPCDataset
        '
        Me.IRPCDataset.DataSetName = "IRPCDataset"
        Me.IRPCDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DetailGroup
        '
        Me.DetailGroup.Controls.Add(Me.Card_Comm)
        Me.DetailGroup.Controls.Add(Me.Meter1)
        Me.DetailGroup.Controls.Add(Me.RadLabel6)
        Me.DetailGroup.Controls.Add(Me.Label5)
        Me.DetailGroup.Controls.Add(Me.Bsave)
        Me.DetailGroup.Controls.Add(Me.BCancel)
        Me.DetailGroup.Controls.Add(Me.UPDATEBY)
        Me.DetailGroup.Controls.Add(Me.U_UPDATE)
        Me.DetailGroup.Controls.Add(Me.U_REMARK)
        Me.DetailGroup.Controls.Add(Me.RadLabel1)
        Me.DetailGroup.Controls.Add(Me.Label2)
        Me.DetailGroup.Controls.Add(Me.Label1)
        Me.DetailGroup.Controls.Add(Me.Location)
        Me.DetailGroup.Controls.Add(Me.Card_Address)
        Me.DetailGroup.Controls.Add(Me.GroupBox2)
        Me.DetailGroup.Controls.Add(Me.RadLabel10)
        Me.DetailGroup.Controls.Add(Me.GroupBox1)
        Me.DetailGroup.Controls.Add(Me.RadLabel8)
        Me.DetailGroup.Controls.Add(Me.RadLabel2)
        Me.DetailGroup.Controls.Add(Me.RadLabel3)
        Me.DetailGroup.Controls.Add(Me.RadLabel4)
        Me.DetailGroup.Controls.Add(Me.RadLabel5)
        Me.DetailGroup.Controls.Add(Me.RadLabel7)
        Me.DetailGroup.Controls.Add(Me.Card_No)
        Me.DetailGroup.Controls.Add(Me.Card_Name)
        Me.DetailGroup.Dock = System.Windows.Forms.DockStyle.Right
        Me.DetailGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.DetailGroup.Location = New System.Drawing.Point(702, 0)
        Me.DetailGroup.Name = "DetailGroup"
        Me.DetailGroup.Size = New System.Drawing.Size(656, 693)
        Me.DetailGroup.TabIndex = 0
        Me.DetailGroup.TabStop = False
        '
        'Card_Comm
        '
        Me.Card_Comm.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TCardreaderBindingSource, "PORT", True))
        Me.Card_Comm.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Card_Comm.Location = New System.Drawing.Point(220, 194)
        Me.Card_Comm.Name = "Card_Comm"
        Me.Card_Comm.Size = New System.Drawing.Size(392, 28)
        Me.Card_Comm.TabIndex = 120
        Me.Card_Comm.TabStop = False
        Me.Card_Comm.ThemeName = "Office2010Blue"
        '
        'Meter1
        '
        Me.Meter1.AutoCompleteDisplayMember = "BAY_NUMBER"
        Me.Meter1.AutoCompleteValueMember = "BAY_NUMBER"
        Me.Meter1.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TCardreaderBindingSource, "CARD_BAY", True))
        Me.Meter1.DataSource = Me.TbayBindingSource
        Me.Meter1.DisplayMember = "BAY_NUMBER"
        Me.Meter1.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Meter1.Location = New System.Drawing.Point(220, 228)
        Me.Meter1.Name = "Meter1"
        '
        '
        '
        Me.Meter1.RootElement.StretchVertically = True
        Me.Meter1.Size = New System.Drawing.Size(392, 30)
        Me.Meter1.TabIndex = 119
        Me.Meter1.ThemeName = "Office2010Blue"
        Me.Meter1.ValueMember = "BAY_NUMBER"
        '
        'TbayBindingSource
        '
        Me.TbayBindingSource.DataMember = "T_BAY"
        Me.TbayBindingSource.DataSource = Me.IRPCDataset
        Me.TbayBindingSource.Sort = "Bay_number"
        '
        'RadLabel6
        '
        Me.RadLabel6.AutoSize = True
        Me.RadLabel6.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel6.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadLabel6.Location = New System.Drawing.Point(110, 228)
        Me.RadLabel6.Name = "RadLabel6"
        Me.RadLabel6.Size = New System.Drawing.Size(104, 27)
        Me.RadLabel6.TabIndex = 117
        Me.RadLabel6.Text = "Bay ที่ติดตั้ง"
        Me.RadLabel6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.RadLabel6.TextWrap = False
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 16.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label5.Location = New System.Drawing.Point(3, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(650, 27)
        Me.Label5.TabIndex = 115
        Me.Label5.Text = "Database System >> Cardreader"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Bsave
        '
        Me.Bsave.BackColor = System.Drawing.Color.Transparent
        Me.Bsave.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Bsave.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bsave.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        Me.Bsave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.Bsave.Location = New System.Drawing.Point(368, 559)
        Me.Bsave.Name = "Bsave"
        Me.Bsave.Size = New System.Drawing.Size(115, 44)
        Me.Bsave.TabIndex = 112
        Me.Bsave.Text = "บันทึก"
        Me.Bsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Bsave.ThemeName = "Breeze"
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "บันทึก"
        CType(Me.Bsave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'BCancel
        '
        Me.BCancel.BackColor = System.Drawing.Color.Transparent
        Me.BCancel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BCancel.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BCancel.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BCancel.Location = New System.Drawing.Point(497, 559)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(115, 44)
        Me.BCancel.TabIndex = 113
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
        'UPDATEBY
        '
        Me.UPDATEBY.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TCardreaderBindingSource, "UPDATE_BY", True))
        Me.UPDATEBY.Font = New System.Drawing.Font("Tahoma", 16.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.UPDATEBY.Location = New System.Drawing.Point(220, 515)
        Me.UPDATEBY.Name = "UPDATEBY"
        Me.UPDATEBY.ReadOnly = True
        Me.UPDATEBY.Size = New System.Drawing.Size(392, 31)
        Me.UPDATEBY.TabIndex = 76
        Me.UPDATEBY.TabStop = False
        Me.UPDATEBY.ThemeName = "Office2010Blue"
        CType(Me.UPDATEBY.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        CType(Me.UPDATEBY.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        '
        'U_UPDATE
        '
        Me.U_UPDATE.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TCardreaderBindingSource, "UPDATE_DATE", True))
        Me.U_UPDATE.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.U_UPDATE.Location = New System.Drawing.Point(220, 479)
        Me.U_UPDATE.Name = "U_UPDATE"
        Me.U_UPDATE.ReadOnly = True
        Me.U_UPDATE.Size = New System.Drawing.Size(392, 28)
        Me.U_UPDATE.TabIndex = 75
        Me.U_UPDATE.TabStop = False
        Me.U_UPDATE.ThemeName = "Office2010Blue"
        CType(Me.U_UPDATE.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        CType(Me.U_UPDATE.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        '
        'U_REMARK
        '
        Me.U_REMARK.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TCardreaderBindingSource, "REMARK", True))
        Me.U_REMARK.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.U_REMARK.Location = New System.Drawing.Point(220, 393)
        Me.U_REMARK.Name = "U_REMARK"
        Me.U_REMARK.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.U_REMARK.Size = New System.Drawing.Size(392, 80)
        Me.U_REMARK.TabIndex = 73
        Me.U_REMARK.Text = ""
        '
        'RadLabel1
        '
        Me.RadLabel1.AutoSize = True
        Me.RadLabel1.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel1.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadLabel1.Location = New System.Drawing.Point(129, 420)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(85, 27)
        Me.RadLabel1.TabIndex = 72
        Me.RadLabel1.Text = "หมายเหตุ"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.RadLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Label2.Location = New System.Drawing.Point(128, 518)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 23)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "แก้ไขโดย"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Label1.Location = New System.Drawing.Point(37, 482)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 23)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "วัน-เวลาที่แก้ไขล่าสุด"
        '
        'Location
        '
        Me.Location.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Location.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.Location.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Location.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TCardreaderBindingSource, "LOCATION", True))
        Me.Location.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Location.FormattingEnabled = True
        Me.Location.Items.AddRange(New Object() {"", "ISLAND 1 BAY 1", "ISLAND 1 BAY 2", "ISLAND 2 BAY 1", "ISLAND 2 BAY 2", "ISLAND 3 BAY 1", "ISLAND 3 BAY 2"})
        Me.Location.Location = New System.Drawing.Point(220, 264)
        Me.Location.Name = "Location"
        Me.Location.Size = New System.Drawing.Size(392, 31)
        Me.Location.TabIndex = 5
        '
        'Card_Address
        '
        Me.Card_Address.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TCardreaderBindingSource, "ADDRESS", True))
        Me.Card_Address.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Card_Address.Location = New System.Drawing.Point(220, 160)
        Me.Card_Address.Name = "Card_Address"
        Me.Card_Address.Size = New System.Drawing.Size(392, 28)
        Me.Card_Address.TabIndex = 2
        Me.Card_Address.TabStop = False
        Me.Card_Address.ThemeName = "Office2010Blue"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Status_off)
        Me.GroupBox2.Controls.Add(Me.Status_on)
        Me.GroupBox2.Location = New System.Drawing.Point(220, 343)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(392, 44)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'Status_off
        '
        Me.Status_off.AutoSize = True
        Me.Status_off.Checked = True
        Me.Status_off.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status_off.Location = New System.Drawing.Point(141, 12)
        Me.Status_off.Name = "Status_off"
        Me.Status_off.Size = New System.Drawing.Size(97, 25)
        Me.Status_off.TabIndex = 1
        Me.Status_off.TabStop = True
        Me.Status_off.Text = " หยุดใช้งาน"
        Me.Status_off.UseVisualStyleBackColor = True
        '
        'Status_on
        '
        Me.Status_on.AutoSize = True
        Me.Status_on.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status_on.Location = New System.Drawing.Point(17, 12)
        Me.Status_on.Name = "Status_on"
        Me.Status_on.Size = New System.Drawing.Size(83, 25)
        Me.Status_on.TabIndex = 0
        Me.Status_on.Text = "ใช้งานได้"
        Me.Status_on.UseVisualStyleBackColor = True
        '
        'RadLabel10
        '
        Me.RadLabel10.AutoSize = True
        Me.RadLabel10.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel10.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadLabel10.Location = New System.Drawing.Point(73, 352)
        Me.RadLabel10.Name = "RadLabel10"
        Me.RadLabel10.Size = New System.Drawing.Size(141, 27)
        Me.RadLabel10.TabIndex = 40
        Me.RadLabel10.Text = "สถานะการใช้งาน"
        Me.RadLabel10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.RadLabel10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.GroupBox1.Controls.Add(Me.LoadProcess_no)
        Me.GroupBox1.Controls.Add(Me.LoadProcess_ok)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Location = New System.Drawing.Point(220, 298)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 39)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = ""
        '
        'LoadProcess_no
        '
        Me.LoadProcess_no.AutoSize = True
        Me.LoadProcess_no.Checked = True
        Me.LoadProcess_no.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadProcess_no.Location = New System.Drawing.Point(141, 12)
        Me.LoadProcess_no.Name = "LoadProcess_no"
        Me.LoadProcess_no.Size = New System.Drawing.Size(65, 25)
        Me.LoadProcess_no.TabIndex = 1
        Me.LoadProcess_no.TabStop = True
        Me.LoadProcess_no.Text = " ไม่ใช่"
        Me.LoadProcess_no.UseVisualStyleBackColor = True
        '
        'LoadProcess_ok
        '
        Me.LoadProcess_ok.AutoSize = True
        Me.LoadProcess_ok.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoadProcess_ok.Location = New System.Drawing.Point(17, 12)
        Me.LoadProcess_ok.Name = "LoadProcess_ok"
        Me.LoadProcess_ok.Size = New System.Drawing.Size(44, 25)
        Me.LoadProcess_ok.TabIndex = 0
        Me.LoadProcess_ok.Text = "ใช่"
        Me.LoadProcess_ok.UseVisualStyleBackColor = True
        '
        'RadLabel8
        '
        Me.RadLabel8.AutoSize = True
        Me.RadLabel8.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel8.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadLabel8.Location = New System.Drawing.Point(26, 304)
        Me.RadLabel8.Name = "RadLabel8"
        Me.RadLabel8.Size = New System.Drawing.Size(188, 27)
        Me.RadLabel8.TabIndex = 37
        Me.RadLabel8.Text = "อยู่ในกระบวนการโหลด"
        Me.RadLabel8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.RadLabel8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'RadLabel2
        '
        Me.RadLabel2.AutoSize = True
        Me.RadLabel2.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel2.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadLabel2.Location = New System.Drawing.Point(71, 92)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(143, 27)
        Me.RadLabel2.TabIndex = 2
        Me.RadLabel2.Text = "หมายเลขอุปกรณ์"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadLabel3
        '
        Me.RadLabel3.AutoSize = True
        Me.RadLabel3.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel3.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadLabel3.Location = New System.Drawing.Point(80, 266)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(134, 27)
        Me.RadLabel3.TabIndex = 4
        Me.RadLabel3.Text = "ตำแหน่งที่ติดตั้ง"
        Me.RadLabel3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadLabel4
        '
        Me.RadLabel4.AutoSize = True
        Me.RadLabel4.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel4.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadLabel4.Location = New System.Drawing.Point(109, 161)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(105, 27)
        Me.RadLabel4.TabIndex = 6
        Me.RadLabel4.Text = "CR Address"
        Me.RadLabel4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.RadLabel4.TextWrap = False
        '
        'RadLabel5
        '
        Me.RadLabel5.AutoSize = True
        Me.RadLabel5.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel5.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadLabel5.Location = New System.Drawing.Point(111, 195)
        Me.RadLabel5.Name = "RadLabel5"
        Me.RadLabel5.Size = New System.Drawing.Size(103, 27)
        Me.RadLabel5.TabIndex = 8
        Me.RadLabel5.Text = "Comm Port"
        Me.RadLabel5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.RadLabel5.TextWrap = False
        '
        'RadLabel7
        '
        Me.RadLabel7.AutoSize = True
        Me.RadLabel7.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.RadLabel7.ImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadLabel7.Location = New System.Drawing.Point(122, 127)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(92, 27)
        Me.RadLabel7.TabIndex = 9
        Me.RadLabel7.Text = "ชื่ออุปกรณ์"
        Me.RadLabel7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.RadLabel7.TextWrap = False
        '
        'Card_No
        '
        Me.Card_No.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TCardreaderBindingSource, "CARD_NO", True))
        Me.Card_No.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Card_No.Location = New System.Drawing.Point(220, 92)
        Me.Card_No.Name = "Card_No"
        Me.Card_No.Size = New System.Drawing.Size(392, 28)
        Me.Card_No.TabIndex = 0
        Me.Card_No.TabStop = False
        Me.Card_No.ThemeName = "Office2010Blue"
        '
        'Card_Name
        '
        Me.Card_Name.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TCardreaderBindingSource, "NAME", True))
        Me.Card_Name.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.Card_Name.Location = New System.Drawing.Point(220, 126)
        Me.Card_Name.Name = "Card_Name"
        Me.Card_Name.Size = New System.Drawing.Size(392, 28)
        Me.Card_Name.TabIndex = 1
        Me.Card_Name.TabStop = False
        Me.Card_Name.ThemeName = "Office2010Blue"
        '
        'RadPanel3
        '
        Me.RadPanel3.Controls.Add(Me.MasterGrid)
        Me.RadPanel3.Controls.Add(Me.BindingNavigator1)
        Me.RadPanel3.Controls.Add(Me.RadPanel1)
        Me.RadPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadPanel3.Location = New System.Drawing.Point(0, 0)
        Me.RadPanel3.Name = "RadPanel3"
        Me.RadPanel3.Size = New System.Drawing.Size(702, 693)
        Me.RadPanel3.TabIndex = 13
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
        Me.MasterGrid.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MasterGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MasterGrid.Location = New System.Drawing.Point(0, 39)
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
        GridViewTextBoxColumn1.DataType = GetType(Decimal)
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "CARD_NO"
        GridViewTextBoxColumn1.HeaderText = "หมายเลขอุปกรณ์"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.MinWidth = 150
        GridViewTextBoxColumn1.Name = "CARD_NO"
        GridViewTextBoxColumn1.Width = 150
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "NAME"
        GridViewTextBoxColumn2.HeaderText = "ชื่ออุปกรณ์"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.MinWidth = 160
        GridViewTextBoxColumn2.Name = "NAME"
        GridViewTextBoxColumn2.Width = 160
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "LOCATION"
        GridViewTextBoxColumn3.HeaderText = "ตำแหน่งที่ติดตั้ง"
        GridViewTextBoxColumn3.MinWidth = 200
        GridViewTextBoxColumn3.Name = "LOCATION"
        GridViewTextBoxColumn3.Width = 200
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "locationtype"
        GridViewTextBoxColumn4.HeaderText = "ประเภทตำแหน่งที่ติดตั้ง"
        GridViewTextBoxColumn4.MinWidth = 200
        GridViewTextBoxColumn4.Name = "locationtype"
        GridViewTextBoxColumn4.Width = 200
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "PORT"
        GridViewTextBoxColumn5.HeaderText = "COMM PORT"
        GridViewTextBoxColumn5.MinWidth = 150
        GridViewTextBoxColumn5.Name = "column2"
        GridViewTextBoxColumn5.Width = 150
        Me.MasterGrid.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5})
        Me.MasterGrid.MasterTemplate.DataSource = Me.TCardreaderBindingSource
        Me.MasterGrid.MasterTemplate.EnableFiltering = True
        Me.MasterGrid.MasterTemplate.ShowRowHeaderColumn = False
        Me.MasterGrid.MasterTemplate.Templates.AddRange(New Telerik.WinControls.UI.GridViewTemplate() {Me.GridViewTemplate2})
        Me.MasterGrid.Name = "MasterGrid"
        Me.MasterGrid.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.MasterGrid.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.MasterGrid.RootElement.Padding = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.MasterGrid.Size = New System.Drawing.Size(702, 599)
        Me.MasterGrid.TabIndex = 40
        Me.MasterGrid.ThemeName = "Office2010Blue"
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BindingSource = Me.TCardreaderBindingSource
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
        Me.BindingNavigator1.Size = New System.Drawing.Size(702, 39)
        Me.BindingNavigator1.TabIndex = 50
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
        Me.RadPanel1.Controls.Add(Me.G_SUM)
        Me.RadPanel1.Controls.Add(Me.Label4)
        Me.RadPanel1.Controls.Add(Me.Label3)
        Me.RadPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RadPanel1.Location = New System.Drawing.Point(0, 638)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(702, 55)
        Me.RadPanel1.TabIndex = 41
        '
        'G_SUM
        '
        Me.G_SUM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.G_SUM.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.G_SUM.Location = New System.Drawing.Point(553, 15)
        Me.G_SUM.Name = "G_SUM"
        Me.G_SUM.Size = New System.Drawing.Size(85, 25)
        Me.G_SUM.TabIndex = 39
        Me.G_SUM.TabStop = False
        Me.G_SUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(644, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 19)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "เครื่อง"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(385, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 19)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "จำนวนเครื่องอ่านบัตร"
        '
        'T_CARDREADERTableAdapter
        '
        Me.T_CARDREADERTableAdapter.ClearBeforeFill = True
        '
        'T_BAYTableAdapter
        '
        Me.T_BAYTableAdapter.ClearBeforeFill = True
        '
        'Cardreaderform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1358, 693)
        Me.Controls.Add(Me.RadPanel3)
        Me.Controls.Add(Me.DetailGroup)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Cardreaderform"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database System >> Cardreader"
        Me.ThemeName = "Office2010Blue"
        CType(Me.TCardreaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IRPCDataset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DetailGroup.ResumeLayout(False)
        Me.DetailGroup.PerformLayout()
        CType(Me.Card_Comm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Meter1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbayBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Bsave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UPDATEBY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_UPDATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Card_Address, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Card_No, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Card_Name, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel3.ResumeLayout(False)
        Me.RadPanel3.PerformLayout()
        CType(Me.MasterGrid.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MasterGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTemplate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        Me.RadPanel1.PerformLayout()
        CType(Me.G_SUM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Windows7Theme1 As Telerik.WinControls.Themes.Windows7Theme

    Friend WithEvents DetailGroup As System.Windows.Forms.GroupBox
    Friend WithEvents Card_No As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Card_Name As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    'Friend WithEvents T_CARDREADERTableAdapter As RadControlsWinFormsApp1.IRPCDataset.T_DRIVERDataTable
    Friend WithEvents TCardreaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Location As System.Windows.Forms.ComboBox
    Friend WithEvents Card_Address As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Status_off As System.Windows.Forms.RadioButton
    Friend WithEvents Status_on As System.Windows.Forms.RadioButton
    Friend WithEvents RadLabel10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LoadProcess_no As System.Windows.Forms.RadioButton
    Friend WithEvents LoadProcess_ok As System.Windows.Forms.RadioButton
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadRichTextBox1 As Telerik.WinControls.UI.ITextBoxNavigator
    Friend WithEvents RadPanel3 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents MasterGrid As Telerik.WinControls.UI.RadGridView
    Friend WithEvents GridViewTemplate2 As Telerik.WinControls.UI.GridViewTemplate
    Friend WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents G_SUM As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents UPDATEBY As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents U_UPDATE As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents U_REMARK As System.Windows.Forms.RichTextBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    'Friend WithEvents T_CARDREADERTableAdapter1 As RadControlsWinFormsApp1.IRPCDataset.T_CARDREADERDataTable
    Friend WithEvents Bsave As Telerik.WinControls.UI.RadButton
    Friend WithEvents RoundRectShape1 As Telerik.WinControls.RoundRectShape
    Friend WithEvents BCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents IRPCDataset As RadControlsWinFormsApp1.IRPCDataset
    Friend WithEvents T_CARDREADERTableAdapter As RadControlsWinFormsApp1.IRPCDatasetTableAdapters.T_CARDREADERTableAdapter
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Meter1 As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents TbayBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_BAYTableAdapter As RadControlsWinFormsApp1.IRPCDatasetTableAdapters.T_BAYTableAdapter
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
    Friend WithEvents Card_Comm As Telerik.WinControls.UI.RadTextBox
End Class

