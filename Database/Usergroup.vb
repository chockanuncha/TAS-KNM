Imports System
Imports ExtendedErrorProvider

Public Class Usergroup
    Private cls As New Class_SQLSERVERDB

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim Del As Integer = 0

    Private Sub Usergroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Dataset_table.T_UGRP' table. You can move, or remove it, as needed.
        Me.T_UGRPTableAdapter.Fill(Me.Dataset_table.T_UGRP)
        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True
        Del = 0
    End Sub

    Private Sub TUgrpBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TUgrpBindingSource.PositionChanged
        Try
            TUgrpBindingSource.Item(TUgrpBindingSource.Position)("update_date") = Now
            G_SUM.Text = TUgrpBindingSource.Count.ToString
            ToolStripLabel1.Text = "of { " & TUgrpBindingSource.Count.ToString & " }"
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            BCancel_Click(sender, e)

            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TUgrpBindingSource.AddNew()
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = False
            TUgrpBindingSource.Item(TUgrpBindingSource.Position)("G_DATE") = Now
            MasterGrid.DataSource = TUgrpBindingSource
            MasterGrid.ResumeLayout()
            UPDATEBY.Text = MAIN.U_NAME
            U_Name.Text = TUgrpBindingSource.Count.ToString
            U_Name_s.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        MasterGrid.Enabled = True
        DetailGroup.Enabled = True
        BindingNavigator1.Enabled = False
        UPDATEBY.Text = MAIN.U_NAME
    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If MAIN.U_GROUP_ID < 3 Then
            MessageBox.Show("User นี้ไม่สามารถลบข้อมูลได้ ต้องเป็น User Supervisor", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Usergroup_Load(sender, e)
            Exit Sub
        Else
            MasterGrid.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False

            If MsgBox("ต้องการลบข้อมูลกลุ่ม User '" & U_Name_s.Text & "' หรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete t_ugrp where G_name='" + U_Name_s.Text + "'"

                    cls.Delete(q)

                    Usergroup_Load(sender, e)
                Catch ex As Exception
                    MessageBox.Show("ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Usergroup_Load(sender, e)
                    Exit Sub
                End Try
            Else
                Usergroup_Load(sender, e)
            End If
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TUgrpBindingSource.CancelEdit()
        Me.Dataset_table.T_UGRP.RejectChanges()
        Usergroup_Load(sender, e)
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                TUgrpBindingSource.Item(TUgrpBindingSource.Position)("UPDATE_DATE") = Now
                UPDATEBY.Text = MAIN.U_NAME
                TUgrpBindingSource.EndEdit()
                T_UGRPTableAdapter.Update(Me.Dataset_table.T_UGRP)
                Me.Dataset_table.T_UGRP.AcceptChanges()
                Usergroup_Load(sender, e)
                Me.BringToFront()
            End If

        Catch ex As Exception
            MessageBox.Show("ไม่สามารถบันทึกข้อมูลได้ กรุณาตรวจสอบ ชื่อกลุ่มผู้ใช้งานต้องไม่ซ้ำกัน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

    Private Sub Usergroup_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.MasterGrid.TableElement.RowHeight = 25
        Me.MasterGrid.TableElement.TableHeaderHeight = 30

        Dim sql As String
        sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
          & ",USERGROUP='" & MAIN.U_GROUP & "'"

        cls.Update(sql)

    End Sub

    Private Sub MasterGrid_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles MasterGrid.CellFormatting
        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
    End Sub
End Class
