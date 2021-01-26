Imports System
Imports ExtendedErrorProvider

Public Class F_Status
    Private cls As New Class_SQLSERVERDB
    Private cls_role As New Class_Permission
    Dim MyErrorProvider As New ErrorProviderExtended

    Private Page_Group As String = "Software and Database Management"
    Private Sub F_Status_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MasterGrid.FilterDescriptors.Clear()
        Me.T_STATUSTableAdapter.Fill(Me.DataSet_Table.T_STATUS)
        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True
    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            Bcancel_Click(sender, e)
            MasterGrid.FilterDescriptors.Clear()
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TstatusBindingSource.AddNew()
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = True
            MasterGrid.DataSource = TstatusBindingSource
            MasterGrid.ResumeLayout()
            U_UPDATEBY.Text = MAIN.U_NAME
        Catch ex As Exception
            MsgBox(ex.Message())
            F_Status_Load(sender, e)
        End Try
        TSTATUSBindingSource.Item(TSTATUSBindingSource.Position)("STATUS_ID") = 0
        StatusId.Focus()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TstatusBindingSource.CancelEdit()
        Me.DataSet_Table.T_STATUS.RejectChanges()
        F_Status_Load(sender, e)
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        MasterGrid.Enabled = False
        DetailGroup.Enabled = True
        BindingNavigator1.Enabled = False
        StatusId.Focus()
    End Sub

    Private Sub F_Status_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            Me.MasterGrid.TableElement.RowHeight = 25
            Me.MasterGrid.TableElement.TableHeaderHeight = 30
        Catch ex As Exception
            MsgBox(ex.Message())
            F_Status_Load(sender, e)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If cls_role.Check_Permission(MAIN.U_GROUP, Page_Group) Then
            MasterGrid.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False

            If MsgBox("Status No.: '" & StatusId.Text & "' , Do you want to delete?", vbYesNo + vbDefaultButton2, "Comfirm") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete t_Status where Status_id='" + StatusId.Text + "'"

                    cls.Delete(q)

                    F_Status_Load(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message())
                    F_Status_Load(sender, e)
                    Exit Sub
                End Try
            Else
                F_Status_Load(sender, e)
            End If
        Else
            MessageBox.Show("No Permission!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            F_Status_Load(sender, e)
            Exit Sub
        End If
       
    End Sub

    Private Sub TstatusBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSTATUSBindingSource.PositionChanged
        Try
            P_SUM.Text = TSTATUSBindingSource.Count.ToString()
            ToolStripLabel1.Text = "of { " & TSTATUSBindingSource.Count.ToString & " }"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                TstatusBindingSource.Item(TstatusBindingSource.Position)("update_date") = Now
                TstatusBindingSource.Item(TstatusBindingSource.Position)("update_by") = MAIN.U_NAME
                TstatusBindingSource.EndEdit()
                T_STATUSTableAdapter.Update(Me.DataSet_Table.T_STATUS)
                Me.DataSet_Table.T_STATUS.AcceptChanges()
                F_Status_Load(sender, e)
                Me.BringToFront()
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
            F_Status_Load(sender, e)
        End Try
    End Sub
End Class
