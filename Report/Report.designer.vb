<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Report
    Inherits System.Windows.Forms.Form

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
        Me.Dataset_table = New RadControlsWinFormsApp1.DataSet_Table()
        Me.V_LOADINGNOTETableAdapter1 = New RadControlsWinFormsApp1.DataSet_ViewTableAdapters.V_LOADINGNOTETableAdapter()
        Me.V_LoadingnoteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TProductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_PRODUCTTableAdapter = New RadControlsWinFormsApp1.DataSet_TableTableAdapters.T_PRODUCTTableAdapter()
        Me.RadDateTimePicker1 = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadDateTimePicker2 = New Telerik.WinControls.UI.RadDateTimePicker()
        Me.RadPanel1 = New Telerik.WinControls.UI.RadPanel()
        Me.BtScapPrint = New Telerik.WinControls.UI.RadButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CbProduct = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.Dataset_table, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.V_LoadingnoteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TProductBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadDateTimePicker1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadDateTimePicker2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.BtScapPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dataset_table
        '
        Me.Dataset_table.DataSetName = "Dataset_table"
        Me.Dataset_table.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '

        '
        'Dataset_View
        '
        Me.Dataset_View.DataSetName = "Dataset_View"
        Me.Dataset_View.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '

        'V_LOADINGNOTETableAdapter1
        '
        Me.V_LOADINGNOTETableAdapter1.ClearBeforeFill = True
        '
        'V_LoadingnoteBindingSource
        '
        Me.V_LoadingnoteBindingSource.DataMember = "V_LOADINGNOTE"
        Me.V_LoadingnoteBindingSource.DataSource = Me.Dataset_View
        '
        'TProductBindingSource
        '
        Me.TProductBindingSource.DataMember = "T_PRODUCT"
        Me.TProductBindingSource.DataSource = Me.Dataset_table
        '
        'T_PRODUCTTableAdapter
        '
        Me.T_PRODUCTTableAdapter.ClearBeforeFill = True
        '
        'RadDateTimePicker1
        '
        Me.RadDateTimePicker1.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.RadDateTimePicker1.Location = New System.Drawing.Point(139, 97)
        Me.RadDateTimePicker1.Name = "RadDateTimePicker1"
        Me.RadDateTimePicker1.Size = New System.Drawing.Size(239, 31)
        Me.RadDateTimePicker1.TabIndex = 0
        Me.RadDateTimePicker1.TabStop = False
        Me.RadDateTimePicker1.Text = "28 กรกฎาคม 2557"
        Me.RadDateTimePicker1.Value = New Date(2014, 7, 28, 23, 23, 10, 107)
        '
        'RadDateTimePicker2
        '
        Me.RadDateTimePicker2.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadDateTimePicker2.Location = New System.Drawing.Point(514, 97)
        Me.RadDateTimePicker2.Name = "RadDateTimePicker2"
        Me.RadDateTimePicker2.Size = New System.Drawing.Size(221, 31)
        Me.RadDateTimePicker2.TabIndex = 1
        Me.RadDateTimePicker2.TabStop = False
        Me.RadDateTimePicker2.Text = "28 กรกฎาคม 2557"
        Me.RadDateTimePicker2.Value = New Date(2014, 7, 28, 23, 23, 10, 897)
        '
        'RadPanel1
        '
        Me.RadPanel1.Controls.Add(Me.BtScapPrint)
        Me.RadPanel1.Controls.Add(Me.Label7)
        Me.RadPanel1.Controls.Add(Me.CbProduct)
        Me.RadPanel1.Controls.Add(Me.Label6)
        Me.RadPanel1.Controls.Add(Me.Label5)
        Me.RadPanel1.Controls.Add(Me.RadDateTimePicker2)
        Me.RadPanel1.Controls.Add(Me.RadDateTimePicker1)
        Me.RadPanel1.Location = New System.Drawing.Point(12, 63)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(1137, 290)
        Me.RadPanel1.TabIndex = 2
        '
        'BtScapPrint
        '
        Me.BtScapPrint.Location = New System.Drawing.Point(403, 207)
        Me.BtScapPrint.Name = "BtScapPrint"
        Me.BtScapPrint.Size = New System.Drawing.Size(204, 66)
        Me.BtScapPrint.TabIndex = 183
        Me.BtScapPrint.Text = "RadButton1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.Label7.Location = New System.Drawing.Point(754, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 27)
        Me.Label7.TabIndex = 182
        Me.Label7.Text = "Product :"
        '
        'CbProduct
        '
        Me.CbProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CbProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CbProduct.DataSource = Me.TProductBindingSource
        Me.CbProduct.DisplayMember = "Product_name"
        Me.CbProduct.DropDownHeight = 400
        Me.CbProduct.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.CbProduct.FormattingEnabled = True
        Me.CbProduct.IntegralHeight = False
        Me.CbProduct.Location = New System.Drawing.Point(865, 96)
        Me.CbProduct.Name = "CbProduct"
        Me.CbProduct.Size = New System.Drawing.Size(247, 33)
        Me.CbProduct.TabIndex = 181
        Me.CbProduct.ValueMember = "Product_name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.Label6.Location = New System.Drawing.Point(397, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 27)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "End Date :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.Label5.Location = New System.Drawing.Point(11, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 27)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Start Date :"
        '
        'Report
        '
        Me.ClientSize = New System.Drawing.Size(1161, 471)
        Me.Controls.Add(Me.RadPanel1)
        Me.Name = "Report"
        CType(Me.Dataset_table, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.V_LoadingnoteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TProductBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadDateTimePicker1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadDateTimePicker2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        Me.RadPanel1.PerformLayout()
        CType(Me.BtScapPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadingToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnloadingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadingBut As System.Windows.Forms.Button
    Friend WithEvents DBGrid1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOAD_VEHICLE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SP_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Product_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOAD_TANK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATUS_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOAD_DRIVER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOAD_DOfull As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LC_COMPARTMENT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents V_LOADINGNOTETableAdapter As DataSet_ViewTableAdapters.V_LOADINGNOTETableAdapter
    Friend WithEvents UnloadBut As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    'Friend WithEvents FPTDataSet As TAS_TOL.FPTDataSet
    'Friend WithEvents V_LoadingnoteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LOADCAPACITYDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOADPRESETDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOADCARDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LCCOMPARTMENTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LCBAYDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOADDATEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOADDIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOADTANKDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATUSNAMEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOADDOfullDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOADVEHICLEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductnameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomernameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOADDRIVERDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoadidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents printdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TruckLoading As System.Windows.Forms.Button
    Friend WithEvents TruckUnloading As System.Windows.Forms.Button
    Friend WithEvents TruckReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TruckLoadingReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TruckUnloadingReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents CbProduct As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Enddate As System.Windows.Forms.DateTimePicker
    'Friend WithEvents TProductBindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents T_ProductTableAdapter As TAS_TOL.FPTDataSetTableAdapters.T_ProductTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SAPReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BTSAPReport As System.Windows.Forms.Button
    Friend WithEvents SCAPReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents BtScapPrint As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Dataset_table As RadControlsWinFormsApp1.DataSet_Table
    Friend WithEvents Dataset_View As RadControlsWinFormsApp1.DataSet_View
    Friend WithEvents BindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents V_LOADINGNOTETableAdapter1 As RadControlsWinFormsApp1.DataSet_ViewTableAdapters.V_LOADINGNOTETableAdapter
    Friend WithEvents V_LoadingnoteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TProductBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_PRODUCTTableAdapter As RadControlsWinFormsApp1.DataSet_TableTableAdapters.T_PRODUCTTableAdapter
    Friend WithEvents RadDateTimePicker1 As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadDateTimePicker2 As Telerik.WinControls.UI.RadDateTimePicker
    Friend WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CbProduct As System.Windows.Forms.ComboBox
    Friend WithEvents BtScapPrint As Telerik.WinControls.UI.RadButton
End Class
