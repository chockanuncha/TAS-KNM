Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports Telerik.WinControls.Themes
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Primitives
Imports System.Threading
Imports System.Reflection
Imports ExtendedErrorProvider


Public Class Shipper
    Private cls As New Class_SQKDB

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim Del As Integer = 0

    Private Sub TProductBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TShipperBindingSource.PositionChanged
        Try
            G_SUM.Text = TShipperBindingSource.Count
            ToolStripLabel1.Text = "of { " & TShipperBindingSource.Count.ToString & " }"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                TShipperBindingSource.Item(TShipperBindingSource.Position)("update_date") = Now
                UPDATEBY.Text = MAIN.U_NAME
                TShipperBindingSource.EndEdit()
                T_SHIPPERTableAdapter.Update(Me.Dataset_table.T_SHIPPER)
                Me.Dataset_table.T_SHIPPER.AcceptChanges()
                Shipper_Load(sender, e)
                Me.BringToFront()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Shipper_Load(sender, e)
        End Try
    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            Bcancel_Click(sender, e)
            MasterGrid.FilterDescriptors.Clear()
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TShipperBindingSource.AddNew()
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = False
            TShipperBindingSource.Item(TShipperBindingSource.Position)("SP_DATE") = Now
            MasterGrid.DataSource = TShipperBindingSource
            MasterGrid.ResumeLayout()
            UPDATEBY.Text = MAIN.U_NAME
            P_Code.Focus()
        Catch ex As Exception
            MsgBox(ex.Message())
            Shipper_Load(sender, e)
        End Try
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TShipperBindingSource.CancelEdit()
        Me.Dataset_table.T_SHIPPER.RejectChanges()
        Shipper_Load(sender, e)
    End Sub


    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        Try
            MasterGrid.Enabled = True
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            P_Code.Focus()
        Catch ex As Exception
            MsgBox(ex.Message())
            Shipper_Load(sender, e)
        End Try
    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If MAIN.U_GROUP_ID < 3 Then
            MessageBox.Show("User นี้ไม่สามารถลบข้อมูลได้ ต้องเป็น User Supervisor", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Shipper_Load(sender, e)
            Exit Sub
        Else
            MasterGrid.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False

            If MsgBox("ต้องการลบข้อมูลผู้ขนส่งรหัส : '" & Sp_code.Text & "' หรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete t_shipper where Sp_code='" + Sp_code.Text + "'"

                    cls.Delete(q)

                    Shipper_Load(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message())
                    Shipper_Load(sender, e)
                    Exit Sub
                End Try
            Else
                Shipper_Load(sender, e)
            End If
        End If
    End Sub


    Private Sub Shipper_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MasterGrid.FilterDescriptors.Clear()
        'TODO: This line of code loads data into the 'Dataset_table.T_SHIPPER' table. You can move, or remove it, as needed.
        Me.T_SHIPPERTableAdapter.Fill(Me.Dataset_table.T_SHIPPER)
        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True

    End Sub

    Private Sub Shipper_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.MasterGrid.TableElement.RowHeight = 25
        Me.MasterGrid.TableElement.TableHeaderHeight = 30

    End Sub

    Private Sub MasterGrid_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles MasterGrid.CellFormatting
        Try
            e.CellElement.NumberOfColors = 4
            e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
            e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
            e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
            e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
        Catch ex As Exception

        End Try
    End Sub
End Class
