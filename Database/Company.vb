Imports System
Imports ExtendedErrorProvider

Public Class Company
    Private cls As New Class_SQLSERVERDB
    Private cls_role As New Class_Permission

    Private Page_Group As String = "Operate Data"

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim ED As Integer = 0
    Dim Add As Integer = 0
    Dim Del As Integer = 0

    Private Sub TCompanyBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            G_SUM.Text = TCOMPANYBindingSource.Count.ToString
            ToolStripLabel1.Text = "of { " & TCOMPANYBindingSource.Count.ToString & " }"
            If ED = 1 Then TCOMPANYBindingSource.Item(TCOMPANYBindingSource.Position)("update_date") = Now
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                UPDATEBY.Text = MAIN.U_NAME
                TCOMPANYBindingSource.Item(TCOMPANYBindingSource.Position)("UPDATE_DATE") = Now
                TCOMPANYBindingSource.Item(TCOMPANYBindingSource.Position)("Company_TYPE") = Company_Type.Text
                TCOMPANYBindingSource.EndEdit()
                T_COMPANYTableAdapter.Update(Me.DataSet_Table.T_COMPANY)
                Me.DataSet_Table.T_COMPANY.AcceptChanges()
                Company_Load(sender, e)
                Me.BringToFront()
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
            Company_Load(sender, e)
        End Try
    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            Bcancel_Click(sender, e)
            MasterGrid.FilterDescriptors.Clear()
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TCOMPANYBindingSource.AddNew()
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = True
            UPDATEBY.Text = MAIN.U_NAME
            TCOMPANYBindingSource.Item(TCOMPANYBindingSource.Position)("Company_DATE") = Now
            TCOMPANYBindingSource.Item(TCOMPANYBindingSource.Position)("Company_ID") = TCOMPANYBindingSource.Count
            MasterGrid.DataSource = TCOMPANYBindingSource
            MasterGrid.ResumeLayout()
            Company_Code.Focus()
        Catch ex As Exception
            MsgBox(ex.Message())
            Company_Load(sender, e)
        End Try
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TCOMPANYBindingSource.CancelEdit()
        Me.DataSet_Table.T_COMPANY.RejectChanges()
        Company_Load(sender, e)
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        Try
            MasterGrid.Enabled = True
            DetailGroup.Enabled = True
            UPDATEBY.Text = MAIN.U_NAME
            BindingNavigator1.Enabled = False
            ED = 1
            TCOMPANYBindingSource.CancelEdit()
            Company_Code.Focus()

        Catch ex As Exception
            MsgBox(ex.Message())
            Company_Load(sender, e)
        End Try
    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If cls_role.Check_Permission(MAIN.U_GROUP, Page_Group) Then
            MasterGrid.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False
            If MsgBox("Company : '" & Company_Code.Text & "', Do you want to delete?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete t_company where Company_code='" + Company_Code.Text + "'"

                    cls.Delete(q)

                    Company_Load(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message())
                    Company_Load(sender, e)
                    Exit Sub
                End Try
            Else
                Company_Load(sender, e)
            End If
        Else
            MessageBox.Show("No Permission!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Company_Load(sender, e)
            Exit Sub
        End If

    End Sub

    Private Sub Company_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MasterGrid.FilterDescriptors.Clear()
        Me.T_COMPANYTableAdapter.Fill(Me.DataSet_Table.T_COMPANY)
        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True
        ED = 0
        Add = 0
        Del = 0
    End Sub

    Private Sub Company_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        Try
            Me.MasterGrid.TableElement.RowHeight = 25
            Me.MasterGrid.TableElement.TableHeaderHeight = 30
            MasterGrid.FilterDescriptors.Clear()

            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)

        Catch ex As Exception
            MsgBox(ex.Message())
            Company_Load(sender, e)
        End Try
    End Sub

    Private Sub MasterGrid_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles MasterGrid.CellFormatting
        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
    End Sub
End Class
