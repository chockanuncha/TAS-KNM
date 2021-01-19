Imports System
Imports ExtendedErrorProvider


Public Class BatchMeter
    Private cls As New Class_SQKDB
    Private cls_role As New Class_Permission

    Private Page_Group As String = "Software and Database Management"

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim ED As Integer = 0
    Dim Add As Integer = 0
    Dim Del As Integer = 0

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                If LeftChk.Checked = True Then
                    TBATCHMETERBindingSource.Item(TBATCHMETERBindingSource.Position)("ARMPROSITION") = "Left"
                Else
                    TBATCHMETERBindingSource.Item(TBATCHMETERBindingSource.Position)("ARMPROSITION") = "Right"
                End If

                TBATCHMETERBindingSource.Item(TBatchmeterBindingSource.Position)("UPDATE_DATE") = Now
                UPDATEBY.Text = MAIN.U_NAME
                TBatchmeterBindingSource.EndEdit()
                T_BATCHMETERTableAdapter.Update(Me.DataSet_Table.T_BATCHMETER)
                Me.DataSet_Table.T_BATCHMETER.AcceptChanges()
                BatchMeter_Load(sender, e)
                Me.BringToFront()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            Exit Sub
        End Try
    End Sub
    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click, ToolStripButton5.Click
        Try
            Dim sqluser As String
            sqluser = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sqluser)

        Catch ex As Exception
        End Try
        Try
            Bcancel_Click(sender, e)
            MasterGrid.FilterDescriptors.Clear()
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TBatchmeterBindingSource.AddNew()
            RadPanel5.Enabled = True
            RadPanel4.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = True
            MasterGrid.DataSource = TBatchmeterBindingSource
            MasterGrid.ResumeLayout()
            Meter_StatusOn.Checked = True
            ComboBox1.SelectedIndex = 0
            TBATCHMETERBindingSource.Item(TBATCHMETERBindingSource.Position)("Batch_number") = TBATCHMETERBindingSource.Count.ToString
            TBATCHMETERBindingSource.Item(TBATCHMETERBindingSource.Position)("ID") = TBATCHMETERBindingSource.Count.ToString
            TBATCHMETERBindingSource.Item(TBATCHMETERBindingSource.Position)("BATCH_STATUS") = "10"

            BatchID.Focus()
            LeftChk.Checked = True


        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            BatchMeter_Load(sender, e)
        End Try
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TBatchmeterBindingSource.CancelEdit()
        Me.DataSet_Table.T_BATCHMETER.RejectChanges()
        BatchMeter_Load(sender, e)
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click, ToolStripButton6.Click
        Try
            Dim sqluser As String
            sqluser = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sqluser)

        Catch ex As Exception
        End Try

        MasterGrid.Enabled = False
        RadPanel5.Enabled = True
        RadPanel4.Enabled = True
        UPDATEBY.Text = MAIN.U_NAME
        BindingNavigator1.Enabled = False
        ED = 1
        BatchID.Focus()
    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDelete.Click, ToolStripButton7.Click
        If cls_role.Check_Permission(MAIN.U_GROUP, Page_Group) Then
            Try
                Dim sqluser As String
                sqluser = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
                  & ",USERGROUP='" & MAIN.U_GROUP & "'"

                cls.Update(sqluser)

            Catch ex As Exception
            End Try
            MasterGrid.Enabled = True
            RadPanel5.Enabled = False
            RadPanel4.Enabled = False
            BindingNavigator1.Enabled = False
            Dim ref As String
            ref = MasterGrid.CurrentRow.Cells("ID").Value.ToString
            If MsgBox("Batchmeter : '" & BatchName.Text & "', Do you want to delete?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete t_batchmeter where ID='" + ref + "'"

                    cls.Delete(q)

                    BatchMeter_Load(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message.ToString())
                    BatchMeter_Load(sender, e)
                    Exit Sub
                End Try
            Else
                BatchMeter_Load(sender, e)
            End If
        Else
            MessageBox.Show("No permission!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BatchMeter_Load(sender, e)
            Exit Sub
        End If

    End Sub

    Private Sub BatchMeter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            MasterGrid.FilterDescriptors.Clear()
            'TODO: This line of code loads data into the 'DataSet_Table.T_BAY' table. You can move, or remove it, as needed.
            Me.T_BAYTableAdapter.Fill(Me.DataSet_Table.T_BAY)
            'TODO: This line of code loads data into the 'DataSet_Table.T_ISLAND' table. You can move, or remove it, as needed.
            Me.T_ISLANDTableAdapter.Fill(Me.DataSet_Table.T_ISLAND)
            'TODO: This line of code loads data into the 'DataSet_Table.T_PRODUCT' table. You can move, or remove it, as needed.
            Me.T_PRODUCTTableAdapter.Fill(Me.DataSet_Table.T_PRODUCT)


            Me.T_BATCHMETERTableAdapter.Fill(Me.DataSet_Table.T_BATCHMETER)
            BindingNavigator1.Enabled = True
            RadPanel5.Enabled = False
            RadPanel4.Enabled = False
            MasterGrid.Enabled = True
            ED = 0
            Add = 0
        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub
    Private Sub Meter_StatusOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then TBATCHMETERBindingSource.Item(TBATCHMETERBindingSource.Position)("BATCH_STATUS") = "10"

    End Sub
    Private Sub Meter_StatusOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then TBATCHMETERBindingSource.Item(TBATCHMETERBindingSource.Position)("BATCH_STATUS") = "0"

    End Sub
    Private Sub TBatchmeterBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBATCHMETERBindingSource.PositionChanged
        Try
            G_SUM.Text = TBATCHMETERBindingSource.Count.ToString
            ToolStripLabel1.Text = "of { " & TBATCHMETERBindingSource.Count.ToString & " }"
            If ED = 1 Then TBATCHMETERBindingSource.Item(TBATCHMETERBindingSource.Position)("update_date") = Now
            If UCase(TBATCHMETERBindingSource.Item(TBATCHMETERBindingSource.Position)("Batch_STATUS").ToString) = "10" Then
                Meter_StatusOn.Checked = True
            Else
                Meter_StatusOff.Checked = True
            End If

            If TBATCHMETERBindingSource.Item(TBATCHMETERBindingSource.Position)("ARMPROSITION").ToString = "Left" Then
                LeftChk.Checked = True
            Else
                RightChk.Checked = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub BatchMeter_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            Me.MasterGrid.TableElement.RowHeight = 30
            Me.MasterGrid.TableElement.TableHeaderHeight = 45
            MasterGrid.FilterDescriptors.Clear()
            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
            BatchMeter_Load(sender, e)
        End Try
    End Sub

    Private Sub LeftChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then TBATCHMETERBindingSource.Item(TBATCHMETERBindingSource.Position)("ARMPROSITION") = "Left"
    End Sub

    Private Sub RightChk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then TBATCHMETERBindingSource.Item(TBATCHMETERBindingSource.Position)("ARMPROSITION") = "Right"
    End Sub
End Class
