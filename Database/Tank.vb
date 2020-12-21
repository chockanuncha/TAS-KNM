Imports System.Data
Imports System
Imports System.IO
Imports System.Data.Common
Imports ExtendedErrorProvider
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Threading
Imports System.Drawing.Printing
Imports System.ComponentModel
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data


Public Class Tank
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

                MasterGrid.SuspendLayout()

                UPDATEBY.Text = MAIN.U_NAME
                TTANKBindingSource.Item(TTANKBindingSource.Position)("TANKPRODUCT_ID") = TPRODUCTBindingSource.Item(TPRODUCTBindingSource.Position)("ID")
                TTANKBindingSource.Item(TTANKBindingSource.Position)("TANKPRODUCT") = TPRODUCTBindingSource.Item(TPRODUCTBindingSource.Position)("Product_Code")
                TTANKBindingSource.Item(TTANKBindingSource.Position)("update_date") = Now
                TTANKBindingSource.Item(TTANKBindingSource.Position)("UPDATEBY") = MAIN.U_NAME
                TTANKBindingSource.EndEdit()
                BindingContext(DataSet_Table, "T_TANK").EndCurrentEdit()
                T_TANKTableAdapter.Update(Me.DataSet_Table.T_TANK)

                Me.DataSet_Table.T_TANK.AcceptChanges()

                Me.BringToFront()
                Tank_Load_1(sender, e)
            Else
                Tank_Load_1(sender, e)
            End If

        Catch ex As Exception
            Tank_Load_1(sender, e)
        End Try
    End Sub
    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            MasterGrid.FilterDescriptors.Clear()
            Bcancel_Click(sender, e)
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TTankBindingSource.AddNew()
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = True

            TTANKBindingSource.Item(TTANKBindingSource.Position)("TANKNO") = ""
            TTANKBindingSource.Item(TTankBindingSource.Position)("CREATDATE") = Now
            UPDATEBY.Text = MAIN.U_NAME
            MasterGrid.DataSource = TTankBindingSource
            MasterGrid.ResumeLayout()
            'ComboBox1.SelectedIndex = -1
            Del = 0
            U_StatusOn.Checked = True
        Catch ex As Exception
            MsgBox(ex.Message())
            Tank_Load_1(sender, e)
        End Try
        Tank_no.Focus()
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TTANKBindingSource.CancelEdit()
        Me.DataSet_Table.T_TANK.RejectChanges()
        Tank_Load_1(sender, e)
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        MasterGrid.Enabled = False
        DetailGroup.Enabled = True
        UPDATEBY.Text = MAIN.U_NAME
        ED = 1
        Tank_no.Focus()
    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If cls_role.Check_Permission(MAIN.U_GROUP, Page_Group) Then
            MasterGrid.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False

            If MsgBox("Tank Name : '" & Tank_no.Text & "', Do you want to delete?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete t_tank where tankno='" + Tank_no.Text + "'"

                    cls.Delete(q)

                    Tank_Load_1(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message())
                    Tank_Load_1(sender, e)
                    Exit Sub
                End Try
            Else
                Tank_Load_1(sender, e)
            End If
        Else
            MessageBox.Show("No permission!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Tank_Load_1(sender, e)
            Exit Sub
        End If

    End Sub

    Private Sub Tank_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            Me.MasterGrid.TableElement.RowHeight = 25
            Me.MasterGrid.TableElement.TableHeaderHeight = 30

            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)

        Catch ex As Exception
            MsgBox(ex.Message())
            Tank_Load_1(sender, e)
        End Try
    End Sub

    Private Sub Tank_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MasterGrid.FilterDescriptors.Clear()
        Me.T_PRODUCTTableAdapter.Fill(Me.DataSet_Table.T_PRODUCT)
        Me.T_TANKTableAdapter.Fill(Me.DataSet_Table.T_TANK)

        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True
        MasterGrid.FilterDescriptors.Clear()
    End Sub

    Private Sub TTankBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TTANKBindingSource.PositionChanged
        Try
            G_SUM.Text = TTANKBindingSource.Count.ToString
            ToolStripLabel1.Text = "of { " & TPRODUCTBindingSource.Count.ToString & " }"
            If ED = 1 Then TTANKBindingSource.Item(TTANKBindingSource.Position)("UPDATEDATE") = Now
            If UCase(TTANKBindingSource.Item(TTANKBindingSource.Position)("Tank_Active").ToString) = "1" Then
                U_StatusOn.Checked = True
            Else
                U_StatusOff.Checked = True
            End If

            TTANKBindingSource.Item(TTANKBindingSource.Position)("TANKPRODUCT_ID") = TPRODUCTBindingSource.Item(TPRODUCTBindingSource.Position)("ID")
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

    Private Sub U_StatusOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_StatusOn.Click
        If sender.Checked = True Then
            TTankBindingSource.Item(TTankBindingSource.Position)("TankStatus") = "1"
            TTankBindingSource.Item(TTankBindingSource.Position)("Tank_Active") = "1"
        End If

    End Sub

    Private Sub U_StatusOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_StatusOff.Click
        If sender.Checked = True Then
            TTankBindingSource.Item(TTankBindingSource.Position)("TankStatus") = "0"
            TTankBindingSource.Item(TTankBindingSource.Position)("Tank_Active") = "0"
        End If

    End Sub
End Class
