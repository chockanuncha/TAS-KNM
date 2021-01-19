Imports System
Imports ExtendedErrorProvider

Public Class USER
    Private cls As New Class_SQKDB
    Private cls_role As New Class_Permission

    Private Page_Group As String = "Operate Settings"
    Private Form_State As String = ""

    Public Shared ShowType As Integer
    Public Shared SpCode As String
    Dim MyErrorProvider As New ErrorProviderExtended
    Dim AddEdit As Integer = 0
    Dim Oldpass As String
    Dim Del As Integer = 0

    Private Sub USER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form_State = ""

        MasterGrid.FilterDescriptors.Clear()
        Fill_Data()

        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True

        U_Passconfirm.Text = ""

        passlabel.Visible = True
        AddEdit = 0
        Del = 0
    End Sub
    Private Sub Fill_Data()
        Me.DataSet_Table.T_UGRP.Clear()
        Me.DataSet_Table.T_USER.Clear()
        Me.DataSet_View.V_USER.Clear()

        'TODO: This line of code loads data into the 'DataSet_Table.T_UGRP' table. You can move, or remove it, as needed.
        Me.T_UGRPTableAdapter.Fill(Me.DataSet_Table.T_UGRP)
        'TODO: This line of code loads data into the 'DataSet_Table.T_USER' table. You can move, or remove it, as needed.
        Me.T_USERTableAdapter.Fill(Me.DataSet_Table.T_USER)
        'TODO: This line of code loads data into the 'DataSet_View.V_USER' table. You can move, or remove it, as needed.
        Me.V_USERTableAdapter.Fill(Me.DataSet_View.V_USER)
    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        If cls_role.Check_Permission(MAIN.U_GROUP, Page_Group) Then
            Try

                Bcancel_Click(sender, e) 'Clear field
                MasterGrid.FilterDescriptors.Clear()
                MasterGrid.SuspendLayout()

                Form_State = "Add"

                'Add new rows
                TUSERBindingSource.AddNew()

                'SuspendLayout
                DetailGroup.Enabled = True
                BindingNavigator1.Enabled = False
                MasterGrid.Enabled = False

                'Set Default Value
                User_Level.SelectedIndex = 5
                U_StatusOn.Checked = True
                U_UPDATE.Text = Now
                U_UPDATEBY.Text = MAIN.U_NAME

                'Set to Binding
                TUSERBindingSource.Item(TUSERBindingSource.Position)("U_STATUS") = 1
                TUSERBindingSource.Item(TUSERBindingSource.Position)("U_DATE") = Now

                U_Name.Focus()

            Catch ex As Exception
                MsgBox(ex.Message())
                USER_Load(sender, e)
            End Try

        Else
            MessageBox.Show("No permission!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            USER_Load(sender, e)
            Exit Sub
        End If
    End Sub
    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        If cls_role.Check_Permission(MAIN.U_GROUP, Page_Group) Then
            Try
                U_Name.Enabled = False
                MasterGrid.Enabled = False
                DetailGroup.Enabled = True
                BindingNavigator1.Enabled = False

                AddEdit = 2

                If TUSERBindingSource.Item(VUSERBindingSource.Position)("U_EXPIRE").ToString = "1" Then
                    RadCheckBox1.Checked = True
                    RadCheckBox1_ToggleStateChanged(Nothing, Nothing)
                Else
                    RadCheckBox1.Checked = False
                    RadCheckBox1_ToggleStateChanged(Nothing, Nothing)
                End If

                U_UPDATEBY.Text = MAIN.U_NAME
            Catch ex As Exception
                MsgBox(ex.Message())
            End Try
        Else
            MessageBox.Show("No permission!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            USER_Load(sender, e)
            Exit Sub
        End If
    End Sub
    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If cls_role.Check_Permission(MAIN.U_GROUP, Page_Group) Then
            MasterGrid.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False

            If MsgBox("Delete User : '" & U_Name.Text & " ' , Are you sure?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete t_user where U_name='" + U_Name.Text + "'"

                    cls.Delete(q)

                    USER_Load(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message())
                    USER_Load(sender, e)
                    Exit Sub
                End Try
            Else
                USER_Load(sender, e)
            End If
        Else
            MessageBox.Show("No permission!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            USER_Load(sender, e)
            Exit Sub
        End If
    End Sub
    Private Sub TUserBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            TUSERBindingSource.Item(VUSERBindingSource.Position)("update_date") = Now
            G_SUM.Text = TUSERBindingSource.Count.ToString
            ToolStripLabel1.Text = "of { " & VUSERBindingSource.Count.ToString & " }"
            If UCase(TUSERBindingSource.Item(VUSERBindingSource.Position)("U_STATUS").ToString) = "1" Then
                U_StatusOn.Checked = True
            Else
                U_StatusOff.Checked = True
            End If
            Oldpass = TUSERBindingSource.Item(VUSERBindingSource.Position)("U_Passwd").ToString
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Form_State = ""
        U_Name.Enabled = True
        TUSERBindingSource.CancelEdit()
        Me.DataSet_Table.T_USER.RejectChanges()
        USER_Load(sender, e)
    End Sub


    Private Sub U_StatusOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_StatusOn.Click
        If sender.Checked = True Then TUSERBindingSource.Item(VUSERBindingSource.Position)("U_STATUS") = "1"
    End Sub

    Private Sub U_StatusOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_StatusOff.Click
        If sender.Checked = True Then TUSERBindingSource.Item(VUSERBindingSource.Position)("U_STATUS") = "0"
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Select Case Form_State
            Case "Add", "Edit"
                If U_Pass.Text = "" Then
                    MessageBox.Show("Password field is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    U_Passconfirm.Text = ""
                    U_Pass.Text = ""
                    U_Pass.Focus()

                    Exit Sub
                End If
                If U_Pass.Text <> U_Passconfirm.Text Then
                    MessageBox.Show("The password and confirm Password not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    U_Passconfirm.Text = ""
                    U_Pass.Text = ""
                    U_Pass.Focus()

                    Exit Sub
                End If
                TUSERBindingSource.Item(TUSERBindingSource.Position)("U_PASSWD") = U_Pass.Text
                TUSERBindingSource.Item(TUSERBindingSource.Position)("U_PASSWD_DATE") = Now.AddDays(90)
        End Select

        If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
            TUSERBindingSource.Item(TUSERBindingSource.Position)("update_date") = Now
            U_UPDATEBY.Text = MAIN.U_NAME
            TUSERBindingSource.Item(TUSERBindingSource.Position)("U_GROUP") = TUGRPBindingSource.Item(TUGRPBindingSource.Position)("G_ID")
            TUSERBindingSource.EndEdit()
            T_USERTableAdapter.Update(Me.DataSet_Table.T_USER)
            Me.DataSet_Table.T_USER.AcceptChanges()
            USER_Load(sender, e)
            Me.BringToFront()
        End If

        U_Passconfirm.Text = ""
        U_Pass.Text = ""
        Form_State = ""
    End Sub

    Private Sub USER_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            Me.MasterGrid.TableElement.RowHeight = 25
            Me.MasterGrid.TableElement.TableHeaderHeight = 30

            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)
        Catch ex As Exception
            MsgBox(ex.Message())
            USER_Load(sender, e)
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

    Private Sub VUSERBindingSource_PositionChanged(sender As Object, e As EventArgs) Handles VUSERBindingSource.PositionChanged
        Try
            TUSERBindingSource.Position = VUSERBindingSource.Position
            TUSERBindingSource.Item(VUSERBindingSource.Position)("update_date") = Now
            G_SUM.Text = VUSERBindingSource.Count.ToString
            ToolStripLabel1.Text = "of { " & VUSERBindingSource.Count.ToString & " }"
            If UCase(TUSERBindingSource.Item(VUSERBindingSource.Position)("U_STATUS").ToString) = "1" Then
                U_StatusOn.Checked = True
            Else
                U_StatusOff.Checked = True
            End If

            If TUSERBindingSource.Item(VUSERBindingSource.Position)("U_EXPIRE").ToString = "1" Then
                RadCheckBox1.Checked = True
                RadCheckBox1_ToggleStateChanged(Nothing, Nothing)
            Else
                RadCheckBox1.Checked = False
                RadCheckBox1_ToggleStateChanged(Nothing, Nothing)
            End If

            Oldpass = TUSERBindingSource.Item(VUSERBindingSource.Position)("U_Passwd").ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub U_Pass_TextChanged(sender As Object, e As EventArgs) Handles U_Pass.TextChanged
        If Form_State = "" Then Form_State = "Edit"
    End Sub

    Private Sub RadCheckBox1_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles RadCheckBox1.ToggleStateChanged
        If RadCheckBox1.Checked = True Then
            RadDateTimePicker1.Enabled = True
        Else
            RadDateTimePicker1.Enabled = False
        End If
    End Sub
End Class
