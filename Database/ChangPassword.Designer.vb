<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangPassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangPassword))
        Me.U_PassOLD = New Telerik.WinControls.UI.RadTextBox()
        Me.U_passnew = New Telerik.WinControls.UI.RadTextBox()
        Me.U_PassConfirm = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Username = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RadButton1 = New Telerik.WinControls.UI.RadButton()
        Me.RadButton2 = New Telerik.WinControls.UI.RadButton()
        CType(Me.U_PassOLD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_passnew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_PassConfirm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Username, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'U_PassOLD
        '
        Me.U_PassOLD.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.U_PassOLD.Location = New System.Drawing.Point(164, 85)
        Me.U_PassOLD.Name = "U_PassOLD"
        Me.U_PassOLD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.U_PassOLD.Size = New System.Drawing.Size(221, 22)
        Me.U_PassOLD.TabIndex = 0
        Me.U_PassOLD.TabStop = False
        Me.U_PassOLD.ThemeName = "Windows7"
        '
        'U_passnew
        '
        Me.U_passnew.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.U_passnew.Location = New System.Drawing.Point(164, 113)
        Me.U_passnew.Name = "U_passnew"
        Me.U_passnew.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.U_passnew.Size = New System.Drawing.Size(221, 22)
        Me.U_passnew.TabIndex = 1
        Me.U_passnew.TabStop = False
        Me.U_passnew.ThemeName = "Windows7"
        '
        'U_PassConfirm
        '
        Me.U_PassConfirm.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.U_PassConfirm.Location = New System.Drawing.Point(164, 141)
        Me.U_PassConfirm.Name = "U_PassConfirm"
        Me.U_PassConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.U_PassConfirm.Size = New System.Drawing.Size(221, 22)
        Me.U_PassConfirm.TabIndex = 2
        Me.U_PassConfirm.TabStop = False
        Me.U_PassConfirm.ThemeName = "Windows7"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 17)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Current password"
        '
        'Username
        '
        Me.Username.BackColor = System.Drawing.Color.White
        Me.Username.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Username.Location = New System.Drawing.Point(164, 57)
        Me.Username.Name = "Username"
        Me.Username.ReadOnly = True
        Me.Username.Size = New System.Drawing.Size(221, 22)
        Me.Username.TabIndex = 132
        Me.Username.TabStop = False
        Me.Username.ThemeName = "Windows7"
        Me.Username.WordWrap = False
        CType(Me.Username.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Text = ""
        CType(Me.Username.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        CType(Me.Username.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(62, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 17)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "New password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 17)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "Confirm new password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(85, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "User name"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(398, 51)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 136
        Me.PictureBox1.TabStop = False
        '
        'RadButton1
        '
        Me.RadButton1.Location = New System.Drawing.Point(185, 171)
        Me.RadButton1.Name = "RadButton1"
        Me.RadButton1.Size = New System.Drawing.Size(97, 27)
        Me.RadButton1.TabIndex = 5
        Me.RadButton1.Text = "Chang password"
        Me.RadButton1.ThemeName = "Windows7"
        '
        'RadButton2
        '
        Me.RadButton2.Location = New System.Drawing.Point(288, 171)
        Me.RadButton2.Name = "RadButton2"
        Me.RadButton2.Size = New System.Drawing.Size(97, 27)
        Me.RadButton2.TabIndex = 4
        Me.RadButton2.Text = "Cancel"
        Me.RadButton2.ThemeName = "Windows7"
        '
        'ChangPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(398, 204)
        Me.ControlBox = False
        Me.Controls.Add(Me.RadButton2)
        Me.Controls.Add(Me.RadButton1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Username)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.U_PassConfirm)
        Me.Controls.Add(Me.U_passnew)
        Me.Controls.Add(Me.U_PassOLD)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ChangPassword"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "   Change Your Password"
        Me.ThemeName = "Office2010Blue"
        CType(Me.U_PassOLD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_passnew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_PassConfirm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Username, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents U_PassOLD As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents U_passnew As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents U_PassConfirm As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Username As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents RadButton1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadButton2 As Telerik.WinControls.UI.RadButton
End Class

