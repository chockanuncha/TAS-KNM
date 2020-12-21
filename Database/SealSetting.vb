Imports System
Imports ExtendedErrorProvider

Public Class Seal_setting
    Private cls As New Class_SQKDB

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim Credate As Integer = 0

    Private Sub Seal_setting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'IRPCDataset.T_SEAL' table. You can move, or remove it, as needed.
        Me.T_SEALTableAdapter.Fill(Me.IRPCDataset.T_SEAL)
        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True
        Credate = 0
        TSealBindingSource.CancelEdit()
    End Sub

    Private Sub Seal_setting_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.MasterGrid.TableElement.RowHeight = 25
        Me.MasterGrid.TableElement.TableHeaderHeight = 30
    End Sub


    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            BCancel_Click(sender, e)
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TSealBindingSource.AddNew()
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = True
            P_typePro.Checked = True
            IRPCRadio.Checked = True
            MasterGrid.DataSource = TSealBindingSource
            MasterGrid.ResumeLayout()
            UPDATEBY.Text = MAIN.U_NAME

            TSealBindingSource.Item(TSealBindingSource.Position)("seal_Type") = "1"
            Credate = 1
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
        Dim ref As String
        ref = MasterGrid.CurrentRow.Cells("ID").Value.ToString
        MasterGrid.Enabled = True
        DetailGroup.Enabled = False
        BindingNavigator1.Enabled = False
        If MsgBox("ต้องการลบข้อมูล Seal '" & Sealst.Text & "' หรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then
            Try
                Dim q As String

                q &= ""
                q &= "Delete T_seal where ID='" + ref + "'"

                cls.Delete(q)

                Seal_setting_Load(sender, e)
            Catch ex As Exception
                MessageBox.Show("ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Seal_setting_Load(sender, e)
                Exit Sub
            End Try
        Else
            Seal_setting_Load(sender, e)
        End If
    End Sub

    Private Sub TSealBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSealBindingSource.PositionChanged
        Try
            If UCase(TSealBindingSource.Item(TSealBindingSource.Position)("Seal_customer").ToString) = "1" Then
                IRPCRadio.Checked = True
            Else
                PTTRadio.Checked = True
            End If
            If UCase(TSealBindingSource.Item(TSealBindingSource.Position)("Seal_Status").ToString) = "0" Then
                P_typePro.Checked = True
            ElseIf UCase(TSealBindingSource.Item(TSealBindingSource.Position)("Seal_Status").ToString) = "1" Then

                P_typeAdd.Checked = True
            Else
                P_typeEnd.Checked = True
            End If

            G_SUM.Text = TSealBindingSource.Count.ToString
            ToolStripLabel1.Text = "of { " & TSealBindingSource.Count.ToString & " }"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TSealBindingSource.CancelEdit()
        Me.IRPCDataset.T_SEAL.RejectChanges()
        Seal_setting_Load(sender, e)
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                SealLast_Leave(sender, e)
                If Credate = 1 Then
                    TSealBindingSource.Item(TSealBindingSource.Position)("seal_DATE") = Now
                Else
                    TSealBindingSource.Item(TSealBindingSource.Position)("update_date") = Now
                End If

                TSealBindingSource.Item(TSealBindingSource.Position)("Seal_no") = SealLast.Text

                TSealBindingSource.EndEdit()
                T_SEALTableAdapter.Update(Me.IRPCDataset.T_SEAL)
                Me.IRPCDataset.T_SEAL.AcceptChanges()
                Me.BringToFront()
            End If
            Seal_setting_Load(sender, e)
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถบันทึกข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub IRPCRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IRPCRadio.Click
        If sender.Checked = True Then TSealBindingSource.Item(TSealBindingSource.Position)("Seal_customer") = "1"
    End Sub

    Private Sub PTTRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PTTRadio.Click
        If sender.Checked = True Then TSealBindingSource.Item(TSealBindingSource.Position)("Seal_customer") = "2"
    End Sub

    Private Sub P_typePro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P_typePro.Click
        If sender.Checked = True Then TSealBindingSource.Item(TSealBindingSource.Position)("Seal_Status") = "0"
    End Sub

    Private Sub P_typeAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P_typeAdd.Click
        If sender.Checked = True Then TSealBindingSource.Item(TSealBindingSource.Position)("Seal_Status") = "1"
    End Sub

    Private Sub P_typeEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P_typeEnd.Click
        If sender.Checked = True Then TSealBindingSource.Item(TSealBindingSource.Position)("Seal_Status") = "2"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim seal, SealLast1 As String
        SealLast1 = Microsoft.VisualBasic.Right(SealLast.Text, 4)
        seal = Microsoft.VisualBasic.Right(SealLs.Text, 4)
        RadTextBox3.Text = Trim(Str(Int(seal) - Int(SealLast1)))
    End Sub

    Private Sub SealLast_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SealLast.Leave
        Try
            Dim seal, SealLast1 As String
            SealLast1 = Microsoft.VisualBasic.Right(SealLast.Text, 4)
            seal = Microsoft.VisualBasic.Right(SealLs.Text, 4)
            RadTextBox3.Text = Trim(Str(Int(seal) - Int(SealLast1)))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub P_Name_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SealLs.Leave
        Try
            Dim sealStart, SealLast, Seal As String
            SealLast = Microsoft.VisualBasic.Right(Sealst.Text, 4)
            sealStart = Microsoft.VisualBasic.Right(SealLs.Text, 4)
            SealTotal.Text = Trim(Str(Int(sealStart) - Int(SealLast)))
        Catch ex As Exception

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
