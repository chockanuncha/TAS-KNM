Imports System
Imports ExtendedErrorProvider
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data

Public Class CardETN
    Private cls As New Class_SQKDB
    Dim MyErrorProvider As New ErrorProviderExtended
    Dim D_Num As Integer = 0

    Private Sub CardETN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.T_CARDTableAdapter.Fill(Me.IRPCDataset.T_CARD)
        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True
    End Sub

    Private Sub StatusOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusOn.Click
        If sender.Checked = True Then TCardBindingSource.Item(TCardBindingSource.Position)("CARD_STATUS") = "1"
    End Sub

    Private Sub StatusOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusOff.Click
        If sender.Checked = True Then TCardBindingSource.Item(TCardBindingSource.Position)("CARD_STATUS") = "0"
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TCardBindingSource.CancelEdit()
        IRPCDataset.T_DRIVER.RejectChanges()
        CardETN_Load(sender, e)
    End Sub

    Private Sub TCardBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCardBindingSource.PositionChanged
        Try
            G_SUM.Text = TCardBindingSource.Count
            ToolStripLabel1.Text = "of { " & TCardBindingSource.Count.ToString & " }"
            If UCase(TCardBindingSource.Item(TCardBindingSource.Position)("CARD_STATUS").ToString) = "0" Then
                StatusOff.Checked = True
            Else
                StatusOn.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            BCancel_Click(sender, e)
            MasterGrid.FilterDescriptors.Clear()
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TCardBindingSource.AddNew()
            Cardcar1.SelectedIndex = -1
            RadDateTimePicker1.Value = Now
            RadDateTimePicker2.Value = Now
            Cardcar1.Enabled = False
            CardDriver.Enabled = False
            U_StatusOn.Checked = True
            TCardBindingSource.Item(TCardBindingSource.Position)("CARD_STATUS") = "1"
            TCardBindingSource.Item(TCardBindingSource.Position)("CARD_DATE") = Now
            Card_ISSUEDATE.Value = Now
            Card_Expriredate.Value = Now

            User_logon.Text = MAIN.U_NAME
            U_StatusOn.Checked = True

            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = True

            CardType.SelectedIndex = 0

            Cardcar1.Focus()
        Catch ex As Exception

        End Try

        Dim q, T_ID As String
        Try
            q = ""
            q = "select NVL(max(CARD_NUMBER),0)+1 as CARD_NUMBER   from T_CARD where card_number < 4000"

            Dim dt As DataTable = cls.Query(q)

            D_Num = Int(dt(0)("CARD_NUMBER"))

            CardSerial.Text = ""
            MasterGrid.DataSource = TCardBindingSource
            MasterGrid.ResumeLayout()

        Catch ex As Exception
        End Try
        CardNo.Text = D_Num.ToString
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        MasterGrid.Enabled = True
        DetailGroup.Enabled = True
        BindingNavigator1.Enabled = False
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                TCardBindingSource.Item(TCardBindingSource.Position)("update_date") = Now
                UPDATEBY.Text = MAIN.U_NAME
                TCardBindingSource.EndEdit()
                T_CARDTableAdapter.Update(Me.IRPCDataset.T_CARD)
                Me.IRPCDataset.T_CARDREADER.AcceptChanges()
                CardETN_Load(sender, e)
                Me.BringToFront()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            CardETN_Load(sender, e)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        MAIN.U_GROUP_ID = 3
        If MAIN.U_GROUP_ID < 3 Then
            MessageBox.Show("User นี้ไม่สามารถลบข้อมูลได้ ต้องเป็น User Supervisor", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CardETN_Load(sender, e)
            Exit Sub
        Else
            MasterGrid.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False
            If MsgBox("ต้องการลบข้อมูลบัตร ' " & CardNumber.Text & " ' หรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete T_Card where Card_number='" + CardNumber.Text + "'"

                    cls.Delete(q)

                    CardETN_Load(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message())
                    CardETN_Load(sender, e)
                    Exit Sub
                End Try
            Else
                CardETN_Load(sender, e)
                Exit Sub
            End If
        End If
    End Sub
End Class
