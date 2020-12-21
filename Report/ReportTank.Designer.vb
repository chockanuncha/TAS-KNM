<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportTank
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
        Me.RoundRectShape1 = New Telerik.WinControls.RoundRectShape(Me.components)
        Me.RadPanel3 = New Telerik.WinControls.UI.RadPanel()
        Me.BClose = New Telerik.WinControls.UI.RadButton()
        Me.BPrint = New Telerik.WinControls.UI.RadButton()
        Me.RadCalendar1 = New Telerik.WinControls.UI.RadCalendar()
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel3.SuspendLayout()
        CType(Me.BClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadCalendar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RoundRectShape1
        '
        Me.RoundRectShape1.IsRightToLeft = False
        '
        'RadPanel3
        '
        Me.RadPanel3.Controls.Add(Me.BClose)
        Me.RadPanel3.Controls.Add(Me.BPrint)
        Me.RadPanel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.RadPanel3.Location = New System.Drawing.Point(551, 0)
        Me.RadPanel3.Name = "RadPanel3"
        Me.RadPanel3.Size = New System.Drawing.Size(182, 442)
        Me.RadPanel3.TabIndex = 6
        '
        'BClose
        '
        Me.BClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BClose.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold)
        Me.BClose.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        Me.BClose.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BClose.Location = New System.Drawing.Point(23, 114)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(147, 63)
        Me.BClose.TabIndex = 5
        Me.BClose.Text = "Close"
        Me.BClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BClose.ThemeName = "Breeze"
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.cancel
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Close"
        CType(Me.BClose.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Shape = Me.RoundRectShape1
        '
        'BPrint
        '
        Me.BPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BPrint.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BPrint.Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Print32
        Me.BPrint.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BPrint.Location = New System.Drawing.Point(23, 29)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(147, 63)
        Me.BPrint.TabIndex = 4
        Me.BPrint.Text = "Print"
        Me.BPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BPrint.ThemeName = "Breeze"
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Image = Global.RadControlsWinFormsApp1.My.Resources.Resources.Print32
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BPrint.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = "Print"
        CType(Me.BPrint.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).Shape = Me.RoundRectShape1
        '
        'RadCalendar1
        '
        Me.RadCalendar1.DayNameFormat = Telerik.WinControls.UI.DayNameFormat.Full
        Me.RadCalendar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadCalendar1.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCalendar1.HeaderHeight = 50
        Me.RadCalendar1.Location = New System.Drawing.Point(0, 0)
        Me.RadCalendar1.Name = "RadCalendar1"
        '
        '
        '
        Me.RadCalendar1.RootElement.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent
        Me.RadCalendar1.RootElement.Shape = Me.RoundRectShape1
        Me.RadCalendar1.ShowFooter = True
        Me.RadCalendar1.Size = New System.Drawing.Size(551, 442)
        Me.RadCalendar1.TabIndex = 7
        Me.RadCalendar1.ThemeName = "Office2010Blue"
        Me.RadCalendar1.TitleFormat = " MMMM  yyyy"
        Me.RadCalendar1.UseCompatibleTextRendering = False
        CType(Me.RadCalendar1.GetChildAt(0), Telerik.WinControls.UI.RadCalendarElement).ZoomFactor = 1.3!
        CType(Me.RadCalendar1.GetChildAt(0), Telerik.WinControls.UI.RadCalendarElement).HeaderHeight = 50
        CType(Me.RadCalendar1.GetChildAt(0), Telerik.WinControls.UI.RadCalendarElement).BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        CType(Me.RadCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.RadCalendar1.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'ReportTank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 442)
        Me.Controls.Add(Me.RadCalendar1)
        Me.Controls.Add(Me.RadPanel3)
        Me.Name = "ReportTank"
        '
        '
        '
        Me.RootElement.ApplyShapeToControl = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Tank Report"
        Me.ThemeName = "Office2010Blue"
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel3.ResumeLayout(False)
        CType(Me.BClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadCalendar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RoundRectShape1 As Telerik.WinControls.RoundRectShape
    Friend WithEvents RadPanel3 As Telerik.WinControls.UI.RadPanel
    Friend WithEvents BClose As Telerik.WinControls.UI.RadButton
    Friend WithEvents BPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadCalendar1 As Telerik.WinControls.UI.RadCalendar
End Class

