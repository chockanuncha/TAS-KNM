Imports System
Imports ExtendedErrorProvider
Imports Telerik.WinControls

Public Class Usergroup
    Private cls As New Class_SQLSERVERDB
    Private Page_Group As String = "Operate Settings"
    Private cls_role As New Class_Permission

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim Del As Integer = 0

    Dim EditDoc, AddDoc As Boolean
    Public Function Chk_View()
        '------------------------------------------- Start Check Permission
        RadMessageBox.SetThemeName("Office2010Blue")

        cls_role.Chk_Permission(MAIN.U_GROUP_ID, 16)

        If cls_role.ChkView = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to view this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Return False
        End If
        '------------------------------------------- End Check Permission 12334343434
        Return True
    End Function


    Private Sub Usergroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Chk_View()

        EditDoc = False
        AddDoc = False

        'TODO: This line of code loads data into the 'DataSet_Table.T_UGRP' table. You can move, or remove it, as needed.
        Me.T_UGRPTableAdapter1.Fill(Me.DataSet_Table.T_UGRP)

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

        '------------------------------------------- Check Add Permission
        If cls_role.ChkAdd = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to add data in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Add Permission

        Try
            BCancel_Click(sender, e)

            EditDoc = False
            AddDoc = True

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

        '------------------------------------------- Check Edit Permission
        If cls_role.ChkEdit = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to edit data in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Edit Permission

        EditDoc = True
        AddDoc = False

        MasterGrid.Enabled = True
        DetailGroup.Enabled = True
        BindingNavigator1.Enabled = False
        UPDATEBY.Text = MAIN.U_NAME
    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        '------------------------------------------- Check Delete Permission
        If cls_role.ChkDel = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to delete data in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Delete Permission

        MasterGrid.Enabled = True
        DetailGroup.Enabled = False
        BindingNavigator1.Enabled = False

        If MsgBox("Do you want to delete group '" & U_Name_s.Text & "' ?", vbYesNo + vbDefaultButton2, "Comfirmation") = vbYes Then
            Try
                Dim q As String

                q &= ""
                q &= "Delete t_ugrp where G_name='" + U_Name_s.Text + "'"

                cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Delete group : " & U_Name_s.Text, "T_UGRP", "")

                cls.Delete(q)

                Usergroup_Load(sender, e)
            Catch ex As Exception
                MessageBox.Show("", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Usergroup_Load(sender, e)
                Exit Sub
            End Try
        Else
            Usergroup_Load(sender, e)
        End If


    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TUgrpBindingSource.CancelEdit()
        Me.DataSet_Table.T_UGRP.RejectChanges()
        Usergroup_Load(sender, e)
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                TUgrpBindingSource.Item(TUgrpBindingSource.Position)("UPDATE_DATE") = Now
                UPDATEBY.Text = MAIN.U_NAME
                TUgrpBindingSource.EndEdit()
                T_UGRPTableAdapter1.Update(Me.DataSet_Table.T_UGRP)
                Me.DataSet_Table.T_UGRP.AcceptChanges()

                If AddDoc Then
                    cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Create group name : " & U_Name_s.Text, "T_UGRP", "")
                    EditDoc = False
                    AddDoc = False
                ElseIf EditDoc Then
                    cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Edit group : " & U_Name_s.Text, "T_UGRP", "")
                    EditDoc = False
                    AddDoc = False
                End If
                Usergroup_Load(sender, e)
                'Me.BringToFront()
            End If

        Catch ex As Exception
            MessageBox.Show("This group already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub Usergroup_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        USER.Fill_Data()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        '------------------------------------------- Check Edit Permission
        If (cls_role.ChkEdit = False) And MAIN.U_GROUP_ID <> 1 Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to edit data in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Edit Permission

        GroupRole.G_ID = TUgrpBindingSource.Item(TUgrpBindingSource.Position)("G_ID")
        GroupRole.LUser.Text = TUgrpBindingSource.Item(TUgrpBindingSource.Position)("G_NAME").ToString
        GroupRole.Show()
    End Sub
End Class
