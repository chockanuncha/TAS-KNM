Imports System
Imports ExtendedErrorProvider

Public Class Override
    Dim MyErrorProvider As New ErrorProviderExtended
    Dim Del As Integer = 0

    Private cls_role As New Class_Permission

    Private Page_Group As String = "Software and Database Management"

    Private Sub Config_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Me.DataSet_Table.T_OVERRIDE.Clear()
            Me.T_OVERRIDETableAdapter.Fill(Me.DataSet_Table.T_OVERRIDE)

            BindingNavigator1.Enabled = True
            DetailGroup.Enabled = False
            MasterGrid.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub TOverrideBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOVERRIDEBindingSource.PositionChanged
        Try
            P_SUM.Text = TOVERRIDEBindingSource.Count.ToString()
            ToolStripLabel1.Text = "of { " & TOVERRIDEBindingSource.Count.ToString & " }"
            If BtEdit.Enabled = False Then TOVERRIDEBindingSource.Item(TOVERRIDEBindingSource.Position)("update_date") = Now
            If UCase(TOVERRIDEBindingSource.Item(TOVERRIDEBindingSource.Position)("Status").ToString) = "1" Then
                U_StatusOn.Checked = True
            Else
                U_StatusOff.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TOverrideBindingSource.CancelEdit()
        Me.DataSet_Table.T_OVERRIDE.RejectChanges()
        Config_Load(sender, e)
    End Sub

    Private Sub U_StatusOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_StatusOn.Click
        If sender.Checked = True Then TOVERRIDEBindingSource.Item(TOVERRIDEBindingSource.Position)("Status") = "1"
    End Sub

    Private Sub U_StatusOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_StatusOff.Click
        If sender.Checked = True Then TOVERRIDEBindingSource.Item(TOVERRIDEBindingSource.Position)("Status") = "0"
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                TOVERRIDEBindingSource.Item(TOVERRIDEBindingSource.Position)("update_date") = Now
                TOVERRIDEBindingSource.Item(TOVERRIDEBindingSource.Position)("update_by") = MAIN.U_NAME
                TOVERRIDEBindingSource.EndEdit()
                T_OVERRIDETableAdapter.Update(Me.DataSet_Table.T_OVERRIDE)
                Me.DataSet_Table.T_OVERRIDE.AcceptChanges()
                BCancel_Click(sender, e)
                Me.BringToFront()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        If cls_role.Check_Permission(MAIN.U_GROUP, Page_Group) Then
            MasterGrid.Enabled = False
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            U_UPDATEBY.Text = MAIN.U_NAME

            'TOVERRIDEBindingSource.Item(TOVERRIDEBindingSource.Position)("update_date") = Now
            'TOVERRIDEBindingSource.Item(TOVERRIDEBindingSource.Position)("update_by") = MAIN.U_NAME

            Bay_No.Focus()
        Else
            MessageBox.Show("No Permission!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
            Config_Load(sender, e)
        End If

    End Sub

End Class
