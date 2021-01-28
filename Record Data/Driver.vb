Imports System
Imports ExtendedErrorProvider
Imports Telerik.WinControls

Public Class Driver
    Private cls As New Class_SQLSERVERDB
    Private cls_role As New Class_Permission

    Private Page_Group As String = "Operate Data"

    Public Shared ShowType As Integer
    Public Shared SpCode As String
    Dim MyErrorProvider As New ErrorProviderExtended
    Dim ED As Integer = 0
    Dim Ref As String
    Dim del As Integer = 0
    Dim Add As Integer = 0

    Public Function Chk_View()
        '------------------------------------------- Start Check Permission
        RadMessageBox.SetThemeName("Office2010Blue")

        cls_role.Chk_Permission(MAIN.U_GROUP_ID, 12)

        If cls_role.ChkView = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to view this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Return False
        End If
        '------------------------------------------- End Check Permission
        Return True
    End Function

    Private Sub Driver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MasterGrid.FilterDescriptors.Clear()

        'TODO: This line of code loads data into the 'DataSet_Table.T_COMPANY' table. You can move, or remove it, as needed.
        Me.T_COMPANYTableAdapter.Fill(Me.DataSet_Table.T_COMPANY)
        'TODO: This line of code loads data into the 'DataSet_Table.T_DRIVER' table. You can move, or remove it, as needed.
        Me.T_DRIVERTableAdapter.Fill(Me.DataSet_Table.T_DRIVER)


        BindingNavigator1.Enabled = True

        MasterGrid.Enabled = True
        DetailGroup.Enabled = False

        ED = 0
        Add = 0
        del = 0
    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click

        '------------------------------------------- Check Add Permission
        If cls_role.ChkAdd = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to add data in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Add Permission


        Try
            Bcancel_Click(sender, e)

            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TDriverBindingSource.AddNew()
            Add = 1

            Driver_StatusOn.Checked = True
            Dim q, Driver_Number As String
            q = ""
            q = "select isnull(max(cast(Driver_Number as int)),0)+1 as Driver_Number  from T_Driver"

            Dim dt As DataTable = cls.Query(q)

            Driver_Number = dt(0)("Driver_Number")

            TDriverBindingSource.Item(TDriverBindingSource.Position)("Driver_Number") = Driver_Number
            DriverNumber.Text = Driver_Number.ToString

            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False

            RadDateTimePicker1.Value = Date.Now
            RadDateTimePicker2.Value = Date.Now
            RadDateTimePicker3.Value = Date.Now

            Driver_StatusOn.Checked = True
            TDRIVERBindingSource.Item(TDRIVERBindingSource.Position)("ID") = TDRIVERBindingSource.Count
            TDRIVERBindingSource.Item(TDriverBindingSource.Position)("Driver_STATUS") = "1"
            TDriverBindingSource.Item(TDriverBindingSource.Position)("warning_status") = "0"
            TDriverBindingSource.Item(TDriverBindingSource.Position)("Driver_BLACK_LIST") = "NO"
            TDriverBindingSource.Item(TDriverBindingSource.Position)("Driver_DATE") = Now
            MasterGrid.Enabled = True
            MasterGrid.DataSource = TDriverBindingSource
            MasterGrid.ResumeLayout()
            U_UPDATEBY.Text = MAIN.U_NAME
            Drivername.Focus()
            del = 0

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCANCEL.Click
        TDriverBindingSource.CancelEdit()
        Me.DataSet_Table.T_DRIVER.RejectChanges()
        Driver_Load(sender, e)
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click

        '------------------------------------------- Check Edit Permission
        If cls_role.ChkEdit = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to edit data in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Edit Permission

        Try
            ED = 1
            U_UPDATEBY.Text = MAIN.U_NAME
            MasterGrid.Enabled = False
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        '------------------------------------------- Check Delete Permission
        If cls_role.ChkDel = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to delete data in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Delete Permission

        MasterGrid.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False

            If MsgBox("Driver : '" & Drivername.Text & "  " & DriverLname.Text & "', Do you want to delete?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete T_Driver where Driver_number='" + DriverNumber.Text + "'"

                    cls.Delete(q)

                    Driver_Load(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message())
                    Driver_Load(sender, e)
                    Exit Sub
                End Try
            Else
                Driver_Load(sender, e)
            End If

    End Sub

    Private Sub Driver_StatusOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Driver_StatusOn.Click
        If sender.Checked = True Then TDriverBindingSource.Item(TDriverBindingSource.Position)("Driver_STATUS") = "1"

    End Sub

    Private Sub Driver_StatusOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Driver_StatusOff.Click
        If sender.Checked = True Then TDriverBindingSource.Item(TDriverBindingSource.Position)("Driver_STATUS") = "0"

    End Sub

    Private Sub TDriverBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDRIVERBindingSource.PositionChanged
        Try
            G_SUM.Text = TDRIVERBindingSource.Count.ToString
            ToolStripLabel1.Text = "of { " & TDRIVERBindingSource.Count.ToString & " }"

            If UCase(TDRIVERBindingSource.Item(TDRIVERBindingSource.Position)("Driver_STATUS").ToString) = "1" Then
                Driver_StatusOn.Checked = True
            Else
                Driver_StatusOff.Checked = True
            End If

            If UCase(TDRIVERBindingSource.Item(TDRIVERBindingSource.Position)("Driver_BLACK_LIST").ToString) = "YES" Then
                Bl.Checked = True
            Else
                NonBl.Checked = True
            End If

            'If UCase(TDRIVERBindingSource.Item(TDRIVERBindingSource.Position)("Warning_STATUS").ToString) = "1" Then
            '    Warning_on.Checked = True
            'Else
            '    Warning_off.Checked = True
            'End If

            If UCase(TDRIVERBindingSource.Item(TDRIVERBindingSource.Position)("DRIVER_DATE_END").ToString) = "" Then
                RadDateTimePicker1.Value = "0:00:00"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSAVE.Click

        If Drivername.Text = "" Or DriverLname.Text = "" Or RadTextBox1.Text = "" Or RadTextBox4.Text = "" Then
            MessageBox.Show("Please spicify information", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Drivername.Focus()
            Exit Sub
        End If

        Try
            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)

        Catch ex As Exception

        End Try

        Dim q, Driver_Number As String
        q = ""
        q = "select isnull(max(cast(Driver_Number as int)),0)+1 as Driver_Number  from T_Driver"

        Dim dt As DataTable = cls.Query(q)

        Driver_Number = dt(0)("Driver_Number")
        If TDRIVERBindingSource.Item(TDRIVERBindingSource.Position)("Driver_Number") = "" Then
            TDRIVERBindingSource.Item(TDRIVERBindingSource.Position)("Driver_Number") = Driver_Number
        End If
        DriverNumber.Text = Driver_Number.ToString

        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                TDRIVERBindingSource.Item(TDRIVERBindingSource.Position)("update_date") = Now
                TDRIVERBindingSource.Item(TDRIVERBindingSource.Position)("update_by") = MAIN.U_NAME
                TDRIVERBindingSource.Item(TDriverBindingSource.Position)("Driver_Number") = DriverNumber.Text
                TDriverBindingSource.Item(TDriverBindingSource.Position)("Driver_Company") = TCompanyBindingSource.Item(TCompanyBindingSource.Position)("COMPANY_ID")
                TDriverBindingSource.EndEdit()
                T_DRIVERTableAdapter.Update(Me.DataSet_Table.T_DRIVER)
                Me.DataSet_Table.T_DRIVER.AcceptChanges()

                If Add = 1 Then
                    Dim sql, DriverID As String
                    sql = ""
                    sql = "select Driver_id from t_driverregister Where Driver_id in(select max(id) as ID from t_driver where Driver_name='" & Drivername.Text & "' and Driver_lastname='" & DriverLname.Text & "')"

                    dt = cls.Query(sql)

                    If dt.Rows.Count > 0 Then
                        DriverID = dt.Rows(0).Item("Driver_id").ToString()

                        sql = ""
                        sql = " Delete t_driverregister Where Driver_id='" & DriverID & "' "

                        cls.Delete(sql)

                    End If

                    sql = ""
                    sql = " insert into t_driverregister (DRIVERFULLNAME,Driver_id) Values ('" & Drivername.Text & "  " & DriverLname.Text & "',"
                    sql &= " (select max(id) as ID from t_driver where Driver_name='" & Drivername.Text & "' and Driver_lastname='" & DriverLname.Text & "'))"

                    cls.Insert(sql)

                End If

                Driver_Load(sender, e)
                Me.BringToFront()
            Else
                Driver_Load(sender, e)
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
            Exit Sub
        End Try
    End Sub

    Private Sub Driver_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            Me.MasterGrid.TableElement.RowHeight = 25
            Me.MasterGrid.TableElement.TableHeaderHeight = 30

            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)


        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub MasterGrid_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)

        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
    End Sub


    Private Sub Bl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bl.Click
        If sender.Checked = True Then TDRIVERBindingSource.Item(TDRIVERBindingSource.Position)("Driver_BLACK_LIST") = "YES"
    End Sub

    Private Sub NonBl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NonBl.Click
        If sender.Checked = True Then TDRIVERBindingSource.Item(TDRIVERBindingSource.Position)("Driver_BLACK_LIST") = "NO"
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            For i = 0 To MasterGrid.Rows.Count - 1
                If MasterGrid.Rows(i).Cells(3).Value = "YES" Then
                    MasterGrid.CurrentCell.BackColor = Color.Red
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        Driverblacklist.ShowDialog()
    End Sub

    Private Sub Warning_on_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then TDriverBindingSource.Item(TDriverBindingSource.Position)("warning_status") = "1"
    End Sub

    Private Sub Warning_off_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then TDriverBindingSource.Item(TDriverBindingSource.Position)("warning_status") = "0"
    End Sub

    Private Sub RadPageView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub SelectDriverlog()
        Dim q As String
        Try
            q = ""
            q = "SELECT * from t_driverlog where driverid='" & TDRIVERBindingSource.Item(TDRIVERBindingSource.Position)("ID").ToString & "'"
            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "T_Driver")
            MyDataSet.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub

    Private Sub RadPageViewPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SelectDriverlog()
    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Dim sql, DriverID As String
        sql = ""
        sql = "select Driver_id from t_driverregister Where Driver_id in(select max(id) as ID from t_driver where Driver_name='" & Drivername.Text & "' and Driver_lastname='" & DriverLname.Text & "')"

        Dim dt As DataTable = cls.Query(sql)

        If dt.Rows.Count > 0 Then
            DriverID = dt.Rows(0).Item("Driver_id").ToString()

            sql = ""
            sql = " Delete t_driverregister Where Driver_id='" & DriverID & "' "

            cls.Delete(sql)

        End If

        sql = ""
        sql = " insert into t_driverregister (DRIVERFULLNAME,Driver_id) Values ('" & Drivername.Text & "  " & DriverLname.Text & "',"
        sql &= " (select max(id) as ID from t_driver where Driver_name='" & Drivername.Text & "' and Driver_lastname='" & DriverLname.Text & "'))"

        cls.Insert(sql)

        Driver_Load(sender, e)
        Me.BringToFront()
    End Sub
End Class
