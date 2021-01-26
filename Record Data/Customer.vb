Imports System
Imports ExtendedErrorProvider
Public Class Customer
    Private cls As New Class_SQLSERVERDB
    Private cls_role As New Class_Permission

    Private Page_Group As String = "Operate Settings"

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim del As Integer = 0

    Private Sub Customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MasterGrid.FilterDescriptors.Clear()

        Me.T_CUSTOMERTableAdapter1.Fill(Me.DataSet_Table.T_CUSTOMER)

        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True
    End Sub

    Private Sub TCustomerBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCUSTOMERBindingSource.PositionChanged
        Try
            G_SUM.Text = TCUSTOMERBindingSource.Count.ToString
            ToolStripLabel1.Text = "of { " & TCUSTOMERBindingSource.Count.ToString & " }"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            Bcancel_Click(sender, e)
            MasterGrid.FilterDescriptors.Clear()
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TCustomerBindingSource.AddNew()

            Dim q, Customer_Number, CusCode As String
            q = ""
            q = "select NVL(max(ID),0)+1 as Customer_Number from T_Customer"

            Dim dt As DataTable = cls.Query(q)

            Customer_Number = dt(0)("Customer_Number")
            CusCode = dt(0)("Customer_Number")
            TCUSTOMERBindingSource.Item(TCUSTOMERBindingSource.Position)("ID") = TCUSTOMERBindingSource.Count
            TCUSTOMERBindingSource.Item(TCustomerBindingSource.Position)("Customer_Number") = Customer_Number
            'TCustomerBindingSource.Item(TCustomerBindingSource.Position)("Cus_Code") = Cus_Code
            Customer_No.Text = Customer_Number.ToString
            'Cus_Code.Text = CusCode.ToString
            'User_Level.SelectedIndex = 0
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = False
            TCustomerBindingSource.Item(TCustomerBindingSource.Position)("CUSTOMER_DATE") = Now
            MasterGrid.DataSource = TCustomerBindingSource
            MasterGrid.ResumeLayout()
            U_UPDATEBY.Text = MAIN.U_NAME
            CustomerCode.Focus()
        Catch ex As Exception
            MsgBox(ex.Message())
            Customer_Load(sender, e)
        End Try
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        MasterGrid.Enabled = True
        DetailGroup.Enabled = True
        BindingNavigator1.Enabled = False
        U_UPDATEBY.Text = MAIN.U_NAME
        TCustomerBindingSource.CancelEdit()
        CustomerCode.Focus()
    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If cls_role.Check_Permission(MAIN.U_GROUP, Page_Group) Then
            MasterGrid.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False

            If MsgBox("Customer : '" & CustomerCode.Text & "', Do you want to delete?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete t_Customer where Customer_code='" + CustomerCode.Text + "'"

                    cls.Delete(q)

                    Customer_Load(sender, e)
                Catch ex As Exception
                    Customer_Load(sender, e)
                    Exit Sub
                End Try
            Else
                Customer_Load(sender, e)
            End If
        Else
            MessageBox.Show("No Permission!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Customer_Load(sender, e)
            Exit Sub
        End If

    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                TCustomerBindingSource.Item(TCustomerBindingSource.Position)("update_date") = Now
                U_UPDATEBY.Text = MAIN.U_NAME
                TCustomerBindingSource.EndEdit()
                T_CUSTOMERTableAdapter1.Update(Me.DataSet_Table.T_CUSTOMER)
                Me.DataSet_Table.T_CUSTOMER.AcceptChanges()

                Customer_Load(sender, e)
                Me.BringToFront()
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
            Customer_Load(sender, e)
            Exit Sub
        End Try

    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Try
            TCustomerBindingSource.CancelEdit()
            Me.DataSet_Table.T_CUSTOMER.RejectChanges()
            Customer_Load(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Customer_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
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
        End Try
    End Sub


    Private Sub MasterGrid_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)
        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
    End Sub

End Class
