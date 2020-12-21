Imports System
Imports ExtendedErrorProvider

Public Class Bay
    Private cls As New Class_SQKDB
    Private cls_role As New Class_Permission

    Private Page_Group As String = "Software and Database Management"

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim Del As Integer = 0

    Private Sub Bay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MasterGrid.FilterDescriptors.Clear()
        'TODO: This line of code loads data into the 'DataSet_Table.T_BATCHMETER' table. You can move, or remove it, as needed.
        Me.T_BATCHMETERTableAdapter.Fill(Me.DataSet_Table.T_BATCHMETER)
        'TODO: This line of code loads data into the 'DataSet_Table.T_BAY' table. You can move, or remove it, as needed.
        Me.T_BAYTableAdapter.Fill(Me.DataSet_Table.T_BAY)

        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True

    End Sub

    Private Sub TBayBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBAYBindingSource.PositionChanged
        Try
            P_SUM.Text = TBAYBindingSource.Count.ToString()
            ToolStripLabel1.Text = "of { " & TBAYBindingSource.Count.ToString & " }"
            If BtEdit.Enabled = False Then TBAYBindingSource.Item(TBAYBindingSource.Position)("update_date") = Now
            Dim a As String
            a = TBAYBindingSource.Item(TBAYBindingSource.Position)("Bay_Status").ToString
            If UCase(TBAYBindingSource.Item(TBAYBindingSource.Position)("Bay_Status").ToString) = "1" Then
                U_StatusOn.Checked = True
            Else
                U_StatusOff.Checked = True

            End If

            If TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter1_Status").ToString = "1" Then
                CheckMeter1.Checked = True
                Meter1.Enabled = True
            Else
                CheckMeter1.Checked = False
                Meter1.Enabled = False
                Meter1.SelectedIndex = -1
            End If

            If TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter2_Status").ToString = "1" Then
                CheckMeter2.Checked = True
                Meter2.Enabled = True
            Else
                CheckMeter2.Checked = False
                Meter2.Enabled = False
                Meter2.SelectedIndex = -1
            End If

            If TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter3_Status").ToString = "1" Then
                CheckMeter3.Checked = True
                Meter3.Enabled = True
            Else
                CheckMeter3.Checked = False
                Meter3.Enabled = False
                Meter3.SelectedIndex = -1
            End If

            If TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter4_Status").ToString = "1" Then
                CheckMeter4.Checked = True
                Meter4.Enabled = True
            Else
                CheckMeter4.Checked = False
                Meter4.Enabled = False
                Meter4.SelectedIndex = -1
            End If

            If TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter5_Status").ToString = "1" Then
                CheckMeter5.Checked = True
                Meter5.Enabled = True
            Else
                CheckMeter5.Checked = False
                Meter5.Enabled = False
                Meter5.SelectedIndex = -1
            End If

            If TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter6_Status").ToString = "1" Then
                CheckMeter6.Checked = True
                Meter6.Enabled = True
            Else
                CheckMeter6.Checked = False
                Meter6.Enabled = False
                Meter6.SelectedIndex = -1
            End If

            If TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter7_Status").ToString = "1" Then
                CheckMeter7.Checked = True
                Meter7.Enabled = True
            Else
                CheckMeter7.Checked = False
                Meter7.Enabled = False
                Meter7.SelectedIndex = -1
            End If

            If TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter8_Status").ToString = "1" Then
                CheckMeter8.Checked = True
                Meter8.Enabled = True
            Else
                CheckMeter8.Checked = False
                Meter8.Enabled = False
                Meter8.SelectedIndex = -1
            End If

            If TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter9_Status").ToString = "1" Then
                CheckMeter9.Checked = True
                Meter9.Enabled = True
            Else
                CheckMeter9.Checked = False
                Meter9.Enabled = False
                Meter9.SelectedIndex = -1
            End If

            If TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter10_Status").ToString = "1" Then
                CheckMeter10.Checked = True
                Meter10.Enabled = True
            Else
                CheckMeter10.Checked = False
                Meter10.Enabled = False
                Meter10.SelectedIndex = -1
            End If

            'Bay_Position.SelectedIndex = Bay_Position.Items.IndexOf(TBAYBindingSource.Item(TBAYBindingSource.Position)("Bay_Position").ToString)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                U_UPDATEBY.Text = MAIN.U_NAME
                TBayBindingSource.Item(TBayBindingSource.Position)("update_date") = Now
                TBayBindingSource.EndEdit()
                T_BAYTableAdapter.Update(Me.DataSet_Table.T_BAY)
                Me.DataSet_Table.T_BAY.AcceptChanges()
                Bay_Load(sender, e)
                Me.BringToFront()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub


    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TBayBindingSource.CancelEdit()
        Me.DataSet_Table.T_BAY.RejectChanges()
        Bay_Load(sender, e)
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        MasterGrid.Enabled = True
        DetailGroup.Enabled = True
        BindingNavigator1.Enabled = False
        U_UPDATEBY.Text = MAIN.U_NAME
        Bay_No.Focus()
    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If cls_role.Check_Permission(MAIN.U_GROUP, Page_Group) Then
            MasterGrid.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False
            U_UPDATEBY.Text = MAIN.U_NAME
            If MsgBox("Bay No.: '" & Bay_No.Text & "', Do you want to delete?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
                Try
                    Dim sqluser As String
                    sqluser = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
                      & ",USERGROUP='" & MAIN.U_GROUP & "'"

                    cls.Update(sqluser)

                Catch ex As Exception
                End Try
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete t_bay where Bay_number='" + Bay_No.Text + "'"

                    cls.Delete(q)

                    Bay_Load(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message())
                    Exit Sub
                End Try
            Else
                Bay_Load(sender, e)
            End If
        Else
            MessageBox.Show("No Permission!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Bay_Load(sender, e)
            Exit Sub
        End If

    End Sub

    Private Sub Bay_StatusOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_StatusOn.Click
        If sender.Checked = True Then TBayBindingSource.Item(TBayBindingSource.Position)("Bay_Status") = "1"
    End Sub

    Private Sub Bay_StatusOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_StatusOff.Click
        If sender.Checked = True Then TBayBindingSource.Item(TBayBindingSource.Position)("Bay_Status") = "0"
    End Sub


    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            Dim sqluser As String
            sqluser = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sqluser)

        Catch ex As Exception
        End Try

        Try
            Bcancel_Click(sender, e)

            MasterGrid.FilterDescriptors.Clear()
            Bay_No.Focus()
            CheckMeter1.Checked = False
            CheckMeter2.Checked = False
            CheckMeter3.Checked = False
            CheckMeter4.Checked = False
            CheckMeter5.Checked = False
            CheckMeter6.Checked = False
            CheckMeter7.Checked = False
            CheckMeter8.Checked = False
            CheckMeter9.Checked = False
            CheckMeter10.Checked = False
            TBAYBindingSource.AddNew()
            TBAYBindingSource.Item(TBAYBindingSource.Position)("ID") = TBAYBindingSource.Count
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Bay_Number") = TBAYBindingSource.Count
            TBAYBindingSource.Item(TBayBindingSource.Position)("Meter1_status") = "0"
            TBayBindingSource.Item(TBayBindingSource.Position)("Meter2_status") = "0"
            TBayBindingSource.Item(TBayBindingSource.Position)("Meter3_status") = "0"
            TBayBindingSource.Item(TBayBindingSource.Position)("Meter4_status") = "0"
            TBayBindingSource.Item(TBayBindingSource.Position)("Meter5_status") = "0"
            TBayBindingSource.Item(TBayBindingSource.Position)("Meter6_status") = "0"
            TBayBindingSource.Item(TBayBindingSource.Position)("Meter7_status") = "0"
            TBayBindingSource.Item(TBayBindingSource.Position)("Meter8_status") = "0"
            TBayBindingSource.Item(TBayBindingSource.Position)("Meter9_status") = "0"
            TBayBindingSource.Item(TBayBindingSource.Position)("Meter10_status") = "0"
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing

            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = True
            U_StatusOn.Checked = True
            TBayBindingSource.Item(TBayBindingSource.Position)("Bay_STATUS") = "1"
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Bay_DATE") = Now

            U_UPDATEBY.Text = MAIN.U_NAME
            MasterGrid.DataSource = TBayBindingSource
            MasterGrid.ResumeLayout()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        Bay_No.Focus()
    End Sub

    Private Sub Bay_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            Me.MasterGrid.TableElement.RowHeight = 25
            Me.MasterGrid.TableElement.TableHeaderHeight = 30
            MasterGrid.FilterDescriptors.Clear()

            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)

        Catch ex As Exception
        End Try
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

    Private Sub CheckMeter1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckMeter1.Click
        If sender.Checked = False Then
            Meter1.Enabled = True
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter1_status") = 1
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER1") = 0
        Else
            Meter1.Enabled = False
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter1_status") = 0
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER1") = 0
        End If
    End Sub

    Private Sub CheckMeter2_Click(sender As Object, e As EventArgs) Handles CheckMeter2.Click
        If sender.Checked = False Then
            Meter2.Enabled = True
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter2_status") = 1
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER2") = 0
        Else
            Meter2.Enabled = False
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter2_status") = 0
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER2") = 0
        End If
    End Sub
    Private Sub CheckMeter3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckMeter3.Click
        If sender.Checked = False Then
            Meter3.Enabled = True
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter3_status") = 1
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER3") = 0
        Else
            Meter3.Enabled = False
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter3_status") = 0
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER3") = 0
        End If
    End Sub

    Private Sub CheckMeter4_Click(sender As Object, e As EventArgs) Handles CheckMeter4.Click
        If sender.Checked = False Then
            Meter4.Enabled = True
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter4_status") = 1
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER4") = 0
        Else
            Meter4.Enabled = False
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter4_status") = 0
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER4") = 0
        End If
    End Sub
    Private Sub CheckMeter5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckMeter5.Click
        If sender.Checked = False Then
            Meter5.Enabled = True
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter5_status") = 1
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER5") = 0
        Else
            Meter5.Enabled = False
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter5_status") = 0
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER5") = 0
        End If
    End Sub

    Private Sub CheckMeter6_Click(sender As Object, e As EventArgs) Handles CheckMeter6.Click
        If sender.Checked = False Then
            Meter6.Enabled = True
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter6_status") = 1
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER6") = 0
        Else
            Meter6.Enabled = False
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter6_status") = 0
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER6") = 0
        End If
    End Sub
    Private Sub CheckMeter7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckMeter7.Click
        If sender.Checked = False Then
            Meter7.Enabled = True
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter7_status") = 1
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER7") = 0
        Else
            Meter7.Enabled = False
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter7_status") = 0
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER7") = 0
        End If
    End Sub

    Private Sub CheckMeter8_Click(sender As Object, e As EventArgs) Handles CheckMeter8.Click
        If sender.Checked = False Then
            Meter8.Enabled = True
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter8_status") = 1
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER8") = 0
        Else
            Meter8.Enabled = False
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter8_status") = 0
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER8") = 0
        End If
    End Sub
    Private Sub CheckMeter9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckMeter9.Click
        If sender.Checked = False Then
            Meter9.Enabled = True
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter9_status") = 1
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER9") = 0
        Else
            Meter9.Enabled = False
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter9_status") = 0
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER9") = 0
        End If
    End Sub

    Private Sub CheckMeter10_Click(sender As Object, e As EventArgs) Handles CheckMeter10.Click
        If sender.Checked = False Then
            Meter10.Enabled = True
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter10_status") = 1
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER10") = 0
        Else
            Meter10.Enabled = False
            TBAYBindingSource.Item(TBAYBindingSource.Position)("Meter10_status") = 0
            TBAYBindingSource.Item(TBAYBindingSource.Position)("BAY_METER10") = 0
        End If
    End Sub
End Class
