Imports System
Imports ExtendedErrorProvider

Public Class Companyparent
    Private cls As New Class_SQLSERVERDB

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim ED As Integer = 0
    Dim Add As Integer = 0
    Dim Del As Integer = 0

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            MasterGrid.FilterDescriptors.Clear()
            TCompanyparentBindingSource.CancelEdit()
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TCompanyparentBindingSource.AddNew()
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = True

            TCompanyparentBindingSource.Item(TCompanyparentBindingSource.Position)("Company_DATE") = Now
            MasterGrid.DataSource = TCompanyparentBindingSource
            MasterGrid.ResumeLayout()
            UPDATEBY.Text = MAIN.U_NAME
            Company_Code.Focus()
        Catch ex As Exception
            MsgBox(ex.Message())
            Companyparent_Load(sender, e)
        End Try
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Try
            TCompanyparentBindingSource.CancelEdit()
            Me.Dataset_table.T_COMPANYPARENT.RejectChanges()
            Companyparent_Load(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        Try
            MasterGrid.Enabled = True
            DetailGroup.Enabled = True
            UPDATEBY.Text = MAIN.U_NAME
            BindingNavigator1.Enabled = False
            TCompanyparentBindingSource.CancelEdit()
            Company_Code.Focus()
        Catch ex As Exception
            MsgBox(ex.Message())
            Companyparent_Load(sender, e)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                TCompanyparentBindingSource.Item(TCompanyparentBindingSource.Position)("UPDATE_DATE") = Now
                UPDATEBY.Text = MAIN.U_NAME
                TCompanyparentBindingSource.EndEdit()
                T_COMPANYPARENTTableAdapter1.Update(Me.Dataset_table.T_COMPANYPARENT)

                Me.Dataset_table.T_COMPANYPARENT.AcceptChanges()
                Companyparent_Load(sender, e)
                Me.BringToFront()
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
            Companyparent_Load(sender, e)
        End Try
    End Sub

    Private Sub TCompanyparentBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCompanyparentBindingSource.PositionChanged
        G_SUM.Text = TCompanyparentBindingSource.Count.ToString

        ToolStripLabel1.Text = "of { " & TCompanyparentBindingSource.Count.ToString & " }"
    End Sub

    Private Sub Companyparent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Dataset_table.T_COMPANYPARENT' table. You can move, or remove it, as needed.
        Me.T_COMPANYPARENTTableAdapter1.Fill(Me.Dataset_table.T_COMPANYPARENT)
        MasterGrid.FilterDescriptors.Clear()
        'TODO: This line of code loads data into the 'Dataset_table.T_COMPANYPARENT' table. You can move, or remove it, as needed.
        'Me.T_COMPANYPARENTTableAdapter.Fill(Me.Dataset_table.T_COMPANYPARENT)
        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True

    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDelete.Click

        If MAIN.U_GROUP_ID < 3 Then
            MessageBox.Show("User นี้ไม่สามารถลบข้อมูลได้ ต้องเป็น User Supervisor", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Companyparent_Load(sender, e)
            Exit Sub
        Else

            MasterGrid.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False

            If MsgBox("ต้องการลบข้อมูลบริษัท '" & Company_Code.Text & "'หรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then
                Try
                    Dim q As String
                    q &= ""
                    q &= "Delete t_companyparent where Company_Code='" + Company_Code.Text + "'"

                    cls.Delete(q)

                    Companyparent_Load(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message())
                    Companyparent_Load(sender, e)
                    Exit Sub
                End Try
            Else
                Companyparent_Load(sender, e)
            End If
        End If
    End Sub
End Class
