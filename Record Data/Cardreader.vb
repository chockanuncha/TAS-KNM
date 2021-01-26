Imports System
Imports ExtendedErrorProvider

Public Class Cardreaderform
    Private cls As New Class_SQKDB
    Dim MyErrorProvider As New ErrorProviderExtended
    Dim Del As Integer = 0

    Private Sub Cardreader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MasterGrid.FilterDescriptors.Clear()
        'TODO: This line of code loads data into the 'IRPCDataset.T_BAY' table. You can move, or remove it, as needed.
        Me.T_BAYTableAdapter.Fill(Me.IRPCDataset.T_BAY)
        'TODO: This line of code loads data into the 'IRPCDataset.T_CARDREADER' table. You can move, or remove it, as needed.
        Me.T_CARDREADERTableAdapter.Fill(Me.IRPCDataset.T_CARDREADER)
        'TODO: This line of code loads data into the 'IRPCDataset.T_CARDREADER' table. You can move, or remove it, as needed.
        'Me.T_CARDREADERTableAdapter1.Fill(Me.IRPCDataset.T_CARDREADER)
        'TODO: This line of code loads data into the 'IRPCDataset.T_CARDREADER' table. You can move, or remove it, as needed.
        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True

    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                TCardreaderBindingSource.Item(TCardreaderBindingSource.Position)("update_date") = Now
                UPDATEBY.Text = MAIN.U_NAME
                TCardreaderBindingSource.Item(TCardreaderBindingSource.Position)("PORT") = Card_Comm.Text
                TCardreaderBindingSource.Item(TCardreaderBindingSource.Position)("Location") = Location.Text
                TCardreaderBindingSource.EndEdit()
                T_CARDREADERTableAdapter.Update(Me.IRPCDataset.T_CARDREADER)
                Me.IRPCDataset.T_CARDREADER.AcceptChanges()
                Cardreader_Load(sender, e)
                Me.BringToFront()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Cardreader_Load(sender, e)
        End Try
    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            MasterGrid.FilterDescriptors.Clear()
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TCardreaderBindingSource.AddNew()
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = False
            Status_on.Checked = True
            LoadProcess_ok.Checked = True
            Location.SelectedIndex = -1
            TCardreaderBindingSource.Item(TCardreaderBindingSource.Position)("STATUS") = "1"
            TCardreaderBindingSource.Item(TCardreaderBindingSource.Position)("LOADPROCESS") = "1"
            TCardreaderBindingSource.Item(TCardreaderBindingSource.Position)("CARD_DATE") = Now
            MasterGrid.DataSource = TCardreaderBindingSource
            MasterGrid.ResumeLayout()
            UPDATEBY.Text = MAIN.U_NAME
        Catch ex As Exception
            MsgBox(ex.Message())
            Cardreader_Load(sender, e)
        End Try
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TCardreaderBindingSource.CancelEdit()
        Me.IRPCDataset.T_CARDREADER.RejectChanges()
        Cardreader_Load(sender, e)
    End Sub
    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        MasterGrid.Enabled = True
        DetailGroup.Enabled = True
        BindingNavigator1.Enabled = False
    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If MAIN.U_GROUP_ID < 3 Then
            MessageBox.Show("User นี้ไม่สามารถลบข้อมูลได้ ต้องเป็น User Supervisor", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cardreader_Load(sender, e)
            Exit Sub
        Else
            If MsgBox("ต้องการลบข้อมูล Cardreader '" & Card_Name.Text & "' หรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete t_cardreader where Name='" + Card_Name.Text + "'"

                    cls.Delete(q)

                    Cardreader_Load(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message())
                    Cardreader_Load(sender, e)
                    Exit Sub
                End Try
            Else
                Cardreader_Load(sender, e)
            End If
        End If
    End Sub

    Private Sub LoadProcess_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadProcess_ok.Click
        If sender.Checked = True Then TCardreaderBindingSource.Item(TCardreaderBindingSource.Position)("LoadProcess") = "1"
    End Sub

    Private Sub LoadProcess_no_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadProcess_no.Click
        If sender.Checked = True Then TCardreaderBindingSource.Item(TCardreaderBindingSource.Position)("LoadProcess") = "0"
    End Sub

    Private Sub Status_on_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Status_on.Click
        If sender.Checked = True Then TCardreaderBindingSource.Item(TCardreaderBindingSource.Position)("Status") = "1"
    End Sub

    Private Sub Status_off_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Status_off.Click
        If sender.Checked = True Then TCardreaderBindingSource.Item(TCardreaderBindingSource.Position)("Status") = "0"
    End Sub

    Private Sub TCardreaderBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCardreaderBindingSource.PositionChanged
        Try
            G_SUM.Text = TCardreaderBindingSource.Count
            ToolStripLabel1.Text = "of { " & TCardreaderBindingSource.Count.ToString & " }"

            If UCase(TCardreaderBindingSource.Item(TCardreaderBindingSource.Position)("LoadProcess").ToString) = "0" Then
                LoadProcess_no.Checked = True
            Else
                LoadProcess_ok.Checked = True
            End If

            If UCase(TCardreaderBindingSource.Item(TCardreaderBindingSource.Position)("Status").ToString) = "0" Then
                Status_off.Checked = True
            Else
                Status_on.Checked = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cardreaderform_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
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
