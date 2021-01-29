<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Advisenote_Edit
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
        Me.RadPanel2 = New Telerik.WinControls.UI.RadPanel()
        Me.RoundRectShape1 = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.BTCANCEL = New Telerik.WinControls.UI.RadButton()
        Me.BTSave = New Telerik.WinControls.UI.RadButton()
        Me.Referencetext = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Trucktext = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Drivertext = New Telerik.WinControls.UI.RadTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Dotext = New Telerik.WinControls.UI.RadTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RadPanel1 = New Telerik.WinControls.UI.RadPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Status = New Telerik.WinControls.UI.RadDropDownList()
        Me.TStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet_Table = New RadControlsWinFormsApp1.DataSet_Table()
        Me.T_STATUSTableAdapter = New RadControlsWinFormsApp1.DataSet_TableTableAdapters.T_STATUSTableAdapter()

        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BTCANCEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BTSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Referencetext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Trucktext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Drivertext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dotext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.Status, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dataset_table, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.RadPanel2.Size = New System.Drawing.Size(837, 105)
        Me.RadPanel2.TabIndex = 3
        Me.RadPanel2.Text = "แก้ไข Status ใบแนะนำการเติม"
        Me.RadPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadPanel2.GetChildAt(0), Telerik.WinControls.UI.RadPanelElement).Text = "แก้ไข Status ใบแนะนำการเติม"
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(248, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(244, Byte), Integer))
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).NumberOfColors = 1
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).GradientStyle = Telerik.WinControls.GradientStyles.Linear
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'BTCANCEL
        '
        Me.BTCANCEL.BackColor = System.Drawing.Color.Transparent
        Me.BTCANCEL.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTCANCEL.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BTCANCEL.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BTCANCEL.Location = New System.Drawing.Point(209, 108)
        Me.BTCANCEL.Name = "BTCANCEL"
        Me.BTCANCEL.Size = New System.Drawing.Size(133, 55)
        Me.BTCANCEL.TabIndex = 5
        Me.BTCANCEL.Text = "ยกเลิก"
        Me.BTCANCEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTCANCEL.ThemeName = "Breeze"
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "ยกเลิก"
        CType(Me.BTCANCEL.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'BTSave
        '
        Me.BTSave.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTSave.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        Me.BTSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BTSave.Location = New System.Drawing.Point(60, 108)
        Me.BTSave.Name = "BTSave"
        Me.BTSave.Size = New System.Drawing.Size(133, 55)
        Me.BTSave.TabIndex = 4
        Me.BTSave.Text = "บันทึก"
        Me.BTSave.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BTSave.ThemeName = "Breeze"
        CType(Me.BTSave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.save__2_
        CType(Me.BTSave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BTSave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BTSave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        CType(Me.BTSave.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "บันทึก"
        '
        'Referencetext
        '
        Me.Referencetext.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Referencetext.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Referencetext.Location = New System.Drawing.Point(197, 121)
        Me.Referencetext.Name = "Referencetext"
        Me.Referencetext.ReadOnly = True
        Me.Referencetext.Size = New System.Drawing.Size(257, 28)
        Me.Referencetext.TabIndex = 45
        Me.Referencetext.TabStop = True
        Me.Referencetext.Text = "DDDD"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 23)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Reference"
        '
        'Trucktext
        '
        Me.Trucktext.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Trucktext.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Trucktext.Location = New System.Drawing.Point(197, 155)
        Me.Trucktext.Name = "Trucktext"
        Me.Trucktext.ReadOnly = True
        Me.Trucktext.Size = New System.Drawing.Size(257, 28)
        Me.Trucktext.TabIndex = 47
        Me.Trucktext.TabStop = True
        Me.Trucktext.Text = "DDDD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 23)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "ทะเบียนรถ"
        '
        'Drivertext
        '
        Me.Drivertext.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Drivertext.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Drivertext.Location = New System.Drawing.Point(197, 189)
        Me.Drivertext.Name = "Drivertext"
        Me.Drivertext.ReadOnly = True
        Me.Drivertext.Size = New System.Drawing.Size(257, 28)
        Me.Drivertext.TabIndex = 49
        Me.Drivertext.TabStop = True
        Me.Drivertext.Text = "DDDD"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 23)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "พขร."
        '
        'Dotext
        '
        Me.Dotext.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dotext.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Dotext.Location = New System.Drawing.Point(197, 223)
        Me.Dotext.Name = "Dotext"
        Me.Dotext.ReadOnly = True
        Me.Dotext.Size = New System.Drawing.Size(257, 28)
        Me.Dotext.TabIndex = 51
        Me.Dotext.TabStop = True
        Me.Dotext.Text = "DDDD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 226)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(162, 23)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "หมายเลขใบสั่งซื้อ"
        '
        'RadPanel1
        '
        Me.RadPanel1.Controls.Add(Me.Label5)
        Me.RadPanel1.Controls.Add(Me.Label30)
        Me.RadPanel1.Controls.Add(Me.Status)
        Me.RadPanel1.Controls.Add(Me.BTCANCEL)
        Me.RadPanel1.Controls.Add(Me.BTSave)
        Me.RadPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RadPanel1.Location = New System.Drawing.Point(463, 105)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(374, 175)
        Me.RadPanel1.TabIndex = 52
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(345, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 23)
        Me.Label5.TabIndex = 243
        Me.Label5.Text = "*"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label30.Location = New System.Drawing.Point(9, 19)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(80, 23)
        Me.Label30.TabIndex = 242
        Me.Label30.Text = "สถานะ :"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Status
        '
        Me.Status.AutoCompleteDisplayMember = "STATUS_NAME"
        Me.Status.AutoCompleteValueMember = "ID"
        Me.Status.DataSource = Me.TStatusBindingSource
        Me.Status.DefaultItemsCountInDropDown = 4
        Me.Status.DisplayMember = "STATUS_NAME"
        Me.Status.DropDownMinSize = New System.Drawing.Size(0, 150)
        Me.Status.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Status.Location = New System.Drawing.Point(91, 19)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(251, 28)
        Me.Status.TabIndex = 1
        Me.Status.ThemeName = "Office2010Blue"
        Me.Status.ValueMember = "ID"
        '
        'TStatusBindingSource
        '


        Me.TStatusBindingSource.DataMember = "T_STATUS"
        Me.TStatusBindingSource.DataSource = Me.Dataset_table
        Me.TStatusBindingSource.Filter = "Status_id<6"
        Me.TStatusBindingSource.Sort = "Status_id"
        '
        'Dataset_table
        '
        Me.Dataset_table.DataSetName = "Dataset_table"
        Me.Dataset_table.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '



        'T_STATUSTableAdapter
        '
        Me.T_STATUSTableAdapter.ClearBeforeFill = True
        '
        'Advisenote_Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 280)
        Me.Controls.Add(Me.RadPanel1)
        Me.Controls.Add(Me.Dotext)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Drivertext)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Trucktext)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Referencetext)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RadPanel2)
        Me.Name = "Advisenote_Edit"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "แก้ไข Status ใบแนะนำการเติม"
        Me.ThemeName = "Office2010Blue"
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BTCANCEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BTSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Referencetext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Trucktext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Drivertext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dotext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        Me.RadPanel1.PerformLayout()
        CType(Me.Status, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dataset_table, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadPanel2 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents RoundRectShape1 As Telerik.WinControls.RoundRectShape
    Friend WithEvents BTCANCEL As Telerik.WinControls.UI.RadButton
    Friend WithEvents BTSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents Referencetext As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Trucktext As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Drivertext As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Dotext As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Status As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents TStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Dataset_table As RadControlsWinFormsApp1.DataSet_Table
    Friend WithEvents T_STATUSTableAdapter As RadControlsWinFormsApp1.DataSet_TableTableAdapters.T_STATUSTableAdapter
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class

