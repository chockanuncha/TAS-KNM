<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimeStatus
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
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewDateTimeColumn2 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewDateTimeColumn3 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDateTimeColumn4 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimeStatus))
        Me.RadPanel2 = New Telerik.WinControls.UI.RadPanel()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
        Me.RadPanel1 = New Telerik.WinControls.UI.RadPanel()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.RadButton4 = New Telerik.WinControls.UI.RadButton()
        Me.DataSet_View = New RadControlsWinFormsApp1.DataSet_View()
        Me.TIMERESULTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TIMERESULTTableAdapter = New RadControlsWinFormsApp1.DataSet_ViewTableAdapters.TIMERESULTTableAdapter()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet_View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIMERESULTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadPanel2
        '
        Me.RadPanel2.BackColor = System.Drawing.SystemColors.Control
        Me.RadPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadPanel2.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.RadPanel2.ForeColor = System.Drawing.Color.White
        Me.RadPanel2.Location = New System.Drawing.Point(0, 0)
        Me.RadPanel2.Name = "RadPanel2"
        Me.RadPanel2.Size = New System.Drawing.Size(1592, 118)
        Me.RadPanel2.TabIndex = 24
        Me.RadPanel2.Text = "Time Status"
        Me.RadPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadPanel2.GetChildAt(0), Telerik.WinControls.UI.RadPanelElement).Text = "Time Status"
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(248, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(244, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).NumberOfColors = 1
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).GradientStyle = Telerik.WinControls.GradientStyles.Linear
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label47.ForeColor = System.Drawing.Color.Black
        Me.Label47.Location = New System.Drawing.Point(1215, 19)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(16, 19)
        Me.Label47.TabIndex = 28
        Me.Label47.Text = "-"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText
        Me.DateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.DodgerBlue
        Me.DateTimePicker1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(1016, 16)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(197, 25)
        Me.DateTimePicker1.TabIndex = 26
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CalendarFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText
        Me.DateTimePicker2.CalendarTitleForeColor = System.Drawing.Color.DodgerBlue
        Me.DateTimePicker2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(1237, 16)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(197, 25)
        Me.DateTimePicker2.TabIndex = 27
        '
        'RadGridView1
        '
        Me.RadGridView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RadGridView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadGridView1.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.RadGridView1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridView1.Location = New System.Drawing.Point(0, 174)
        '
        '
        '
        Me.RadGridView1.MasterTemplate.AllowAddNewRow = False
        Me.RadGridView1.MasterTemplate.AllowColumnReorder = False
        Me.RadGridView1.MasterTemplate.AutoGenerateColumns = False
        Me.RadGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        GridViewTextBoxColumn1.DataType = GetType(Decimal)
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "reference"
        GridViewTextBoxColumn1.HeaderText = "Load No."
        GridViewTextBoxColumn1.MinWidth = 120
        GridViewTextBoxColumn1.Name = "reference"
        GridViewTextBoxColumn1.Width = 175
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "TRUCK_NUMBER"
        GridViewTextBoxColumn2.HeaderText = "Truck No."
        GridViewTextBoxColumn2.MinWidth = 200
        GridViewTextBoxColumn2.Name = "TRUCK_NUMBER"
        GridViewTextBoxColumn2.Width = 233
        GridViewDateTimeColumn1.EnableExpressionEditor = False
        GridViewDateTimeColumn1.FieldName = "CHECKIN"
        GridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        GridViewDateTimeColumn1.FormatString = "{0:HH:mm:ss}"
        GridViewDateTimeColumn1.HeaderText = "Enter Gate"
        GridViewDateTimeColumn1.IsAutoGenerated = True
        GridViewDateTimeColumn1.MinWidth = 100
        GridViewDateTimeColumn1.Name = "CHECKIN"
        GridViewDateTimeColumn1.Width = 145
        GridViewDateTimeColumn2.EnableExpressionEditor = False
        GridViewDateTimeColumn2.FieldName = "Q_TIME"
        GridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        GridViewDateTimeColumn2.FormatString = "{0:HH:mm:ss}"
        GridViewDateTimeColumn2.HeaderText = "Queue"
        GridViewDateTimeColumn2.IsAutoGenerated = True
        GridViewDateTimeColumn2.MinWidth = 100
        GridViewDateTimeColumn2.Name = "Q_TIME"
        GridViewDateTimeColumn2.Width = 145
        GridViewDateTimeColumn3.EnableExpressionEditor = False
        GridViewDateTimeColumn3.FieldName = "ADVISE"
        GridViewDateTimeColumn3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        GridViewDateTimeColumn3.FormatString = "{0:HH:mm:ss}"
        GridViewDateTimeColumn3.HeaderText = "Do. Time"
        GridViewDateTimeColumn3.IsAutoGenerated = True
        GridViewDateTimeColumn3.MinWidth = 120
        GridViewDateTimeColumn3.Name = "ADVISE"
        GridViewDateTimeColumn3.Width = 175
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "START_TIME"
        GridViewTextBoxColumn3.HeaderText = "Begin Loading"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.MinWidth = 100
        GridViewTextBoxColumn3.Name = "START_TIME"
        GridViewTextBoxColumn3.Width = 145
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "STOP_TIME"
        GridViewTextBoxColumn4.HeaderText = "End Loading"
        GridViewTextBoxColumn4.IsAutoGenerated = True
        GridViewTextBoxColumn4.MinWidth = 100
        GridViewTextBoxColumn4.Name = "STOP_TIME"
        GridViewTextBoxColumn4.Width = 145
        GridViewDateTimeColumn4.EnableExpressionEditor = False
        GridViewDateTimeColumn4.FieldName = "CHECKOUT"
        GridViewDateTimeColumn4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        GridViewDateTimeColumn4.FormatString = "{0:HH:mm:ss}"
        GridViewDateTimeColumn4.HeaderText = "Exit Gate"
        GridViewDateTimeColumn4.IsAutoGenerated = True
        GridViewDateTimeColumn4.MinWidth = 100
        GridViewDateTimeColumn4.Name = "CHECKOUT"
        GridViewDateTimeColumn4.Width = 145
        GridViewTextBoxColumn5.DataType = GetType(System.TimeSpan)
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "BAYTIME"
        GridViewTextBoxColumn5.HeaderText = "Loading Time"
        GridViewTextBoxColumn5.IsAutoGenerated = True
        GridViewTextBoxColumn5.MinWidth = 100
        GridViewTextBoxColumn5.Name = "BAYTIME"
        GridViewTextBoxColumn5.Width = 145
        GridViewTextBoxColumn6.DataType = GetType(System.TimeSpan)
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "PROCESSTIME"
        GridViewTextBoxColumn6.HeaderText = "Total Time"
        GridViewTextBoxColumn6.IsAutoGenerated = True
        GridViewTextBoxColumn6.MinWidth = 100
        GridViewTextBoxColumn6.Name = "PROCESSTIME"
        GridViewTextBoxColumn6.Width = 137
        Me.RadGridView1.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewDateTimeColumn1, GridViewDateTimeColumn2, GridViewDateTimeColumn3, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewDateTimeColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.RadGridView1.MasterTemplate.DataSource = Me.TIMERESULTBindingSource
        Me.RadGridView1.MasterTemplate.ShowRowHeaderColumn = False
        Me.RadGridView1.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.RadGridView1.Name = "RadGridView1"
        Me.RadGridView1.ReadOnly = True
        Me.RadGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadGridView1.ShowGroupPanel = False
        Me.RadGridView1.Size = New System.Drawing.Size(1592, 678)
        Me.RadGridView1.TabIndex = 29
        Me.RadGridView1.ThemeName = "Office2010Blue"
        '
        'RadPanel1
        '
        Me.RadPanel1.Controls.Add(Me.RadButton1)
        Me.RadPanel1.Controls.Add(Me.RadButton4)
        Me.RadPanel1.Controls.Add(Me.Label47)
        Me.RadPanel1.Controls.Add(Me.DateTimePicker2)
        Me.RadPanel1.Controls.Add(Me.DateTimePicker1)
        Me.RadPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RadPanel1.Location = New System.Drawing.Point(0, 118)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(1592, 56)
        Me.RadPanel1.TabIndex = 30
        '
        'RadButton1
        '
        Me.RadButton1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RadButton1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadButton1.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Print32
        Me.RadButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadButton1.Location = New System.Drawing.Point(0, 0)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(150, 56)
        Me.RadButton1.TabIndex = 130
        Me.RadButton1.Text = "Print"
        Me.RadButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RadButton1.ThemeName = "Breeze"
        '
        'RadButton4
        '
        Me.RadButton4.BackColor = System.Drawing.Color.Transparent
        Me.RadButton4.Dock = System.Windows.Forms.DockStyle.Right
        Me.RadButton4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RadButton4.ForeColor = System.Drawing.Color.Black
        Me.RadButton4.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.browse
        Me.RadButton4.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadButton4.Location = New System.Drawing.Point(1442, 0)
        Me.RadButton4.Name = "RadButton4"
        Me.RadButton4.Size = New System.Drawing.Size(150, 56)
        Me.RadButton4.TabIndex = 129
        Me.RadButton4.Text = "Search"
        Me.RadButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.RadButton4.ThemeName = "Breeze"
        CType(Me.RadButton4.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.browse
        CType(Me.RadButton4.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        CType(Me.RadButton4.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadButton4.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadButton4.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Search"
        '
        'DataSet_View
        '
        Me.DataSet_View.DataSetName = "DataSet_View"
        Me.DataSet_View.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TIMERESULTBindingSource
        '
        Me.TIMERESULTBindingSource.DataMember = "TIMERESULT"
        Me.TIMERESULTBindingSource.DataSource = Me.DataSet_View
        '
        'TIMERESULTTableAdapter
        '
        Me.TIMERESULTTableAdapter.ClearBeforeFill = True
        '
        'TimeStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1592, 852)
        Me.Controls.Add(Me.RadGridView1)
        Me.Controls.Add(Me.RadPanel1)
        Me.Controls.Add(Me.RadPanel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IconScaling = Telerik.WinControls.Enumerations.ImageScaling.None
        Me.Name = "TimeStatus"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Time Status"
        Me.ThemeName = "Office2010Blue"
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        Me.RadPanel1.PerformLayout()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet_View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIMERESULTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RadPanel2 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents RadButton4 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents DataSet_View As DataSet_View
    Friend WithEvents TIMERESULTBindingSource As BindingSource
    Friend WithEvents TIMERESULTTableAdapter As DataSet_ViewTableAdapters.TIMERESULTTableAdapter
End Class

