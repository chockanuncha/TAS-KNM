Imports System
Imports ExtendedErrorProvider

Public Class Product
    Private cls As New Class_SQKDB
    Private cls_role As New Class_Permission

    Private Page_Group As String = "Operate Settings"

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim Del As Integer = 0
    Dim Oper As Integer = 0

    Private Sub Product_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MasterGrid.FilterDescriptors.Clear()
        'TODO: This line of code loads data into the 'DataSet_Table.T_PRODUCTUNIT' table. You can move, or remove it, as needed.
        Me.T_PRODUCTUNITTableAdapter.Fill(Me.DataSet_Table.T_PRODUCTUNIT)
        'TODO: This line of code loads data into the 'DataSet_Table.T_PRODUCT' table. You can move, or remove it, as needed.
        Me.T_PRODUCTTableAdapter.Fill(Me.DataSet_Table.T_PRODUCT)


        MasterGrid.ResumeLayout()
        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterGrid.Enabled = True

        Del = 0
        Oper = 0

    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            Bcancel_Click(sender, e)
            MasterGrid.FilterDescriptors.Clear()
            TPRODUCTBindingSource.AddNew()
            TPRODUCTBindingSource.Item(TPRODUCTBindingSource.Position)("Product_DATE") = Now
            TPRODUCTBindingSource.Item(TPRODUCTBindingSource.Position)("UPDATE_DATE") = Now
            TPRODUCTBindingSource.Item(TPRODUCTBindingSource.Position)("UPDATE_BY") = MAIN.U_NAME
            TPRODUCTBindingSource.Item(TPRODUCTBindingSource.Position)("Product_CODE") = ""
            P_Code.Focus()
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = True
            P_typePro.Checked = True
            Oper = 0
            MasterGrid.DataSource = TProductBindingSource
            MasterGrid.ResumeLayout()
            UPDATEBY.Text = MAIN.U_NAME
            TProductBindingSource.Item(TProductBindingSource.Position)("Product_Type") = "20"
        Catch ex As Exception
            MsgBox(ex.Message())
            Product_Load(sender, e)
        End Try

        P_Code.Focus()
    End Sub

    Private Sub TProductBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TPRODUCTBindingSource.PositionChanged

        Try
            If UCase(TPRODUCTBindingSource.Item(TPRODUCTBindingSource.Position)("Product_Type").ToString) = "1" Then
                P_typePro.Checked = True
            Else
                P_typeAdd.Checked = True
            End If
            P_COLOR.Value = Color.FromArgb(Int(TPRODUCTBindingSource.Item(TPRODUCTBindingSource.Position)("Product_color").ToString))

            P_REMARK.Text = TPRODUCTBindingSource.Item(TPRODUCTBindingSource.Position)("Product_remark").ToString
            If Oper <> 1 Then
                TPRODUCTUNITBindingSource.Position = TPRODUCTUNITBindingSource.Find("ID", TPRODUCTBindingSource.Item(TPRODUCTBindingSource.Position)("Product_UNIT").ToString)
            End If
            G_SUM.Text = TPRODUCTBindingSource.Count.ToString
            ToolStripLabel1.Text = "of { " & TPRODUCTBindingSource.Count.ToString & " }"
        Catch ex As Exception
        End Try

    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        Try
            Oper = 1
            MasterGrid.Enabled = True
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            UPDATEBY.Text = MAIN.U_NAME
            P_Code.Focus()
        Catch ex As Exception
            MsgBox(ex.Message())
            Product_Load(sender, e)
        End Try
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TProductBindingSource.CancelEdit()
        Me.DataSet_Table.T_PRODUCT.RejectChanges()
        Product_Load(sender, e)
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            If MyErrorProvider.CheckAndShowSummaryErrorMessage = True Then
                MasterGrid.SuspendLayout()
                If Oper <> 1 Then
                    TProductBindingSource.Item(TProductBindingSource.Position)("Product_date") = Now
                End If
                TProductBindingSource.Item(TProductBindingSource.Position)("Product_code") = Trim(P_Code.Text)
                UPDATEBY.Text = MAIN.U_NAME
                TProductBindingSource.Item(TProductBindingSource.Position)("update_date") = Now
                TProductBindingSource.Item(TProductBindingSource.Position)("Product_Color") = P_COLOR.Value.ToArgb()
                TProductBindingSource.Item(TProductBindingSource.Position)("Product_unit") = TPRODUCTUNITBindingSource.Item(TPRODUCTUNITBindingSource.Position)("ID")
                TProductBindingSource.EndEdit()
                BindingContext(DataSet_Table, "T_Product").EndCurrentEdit()
                T_PRODUCTTableAdapter.Update(Me.DataSet_Table.T_PRODUCT)
                Me.DataSet_Table.T_PRODUCT.AcceptChanges()
                Oper = 0
                Me.BringToFront()
                Product_Load(sender, e)
            Else
                Product_Load(sender, e)
            End If

        Catch ex As Exception
            MsgBox(ex.Message())
            Product_Load(sender, e)
        End Try

    End Sub

    Private Sub P_typePro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P_typePro.Click
        If sender.Checked = True Then TProductBindingSource.Item(TProductBindingSource.Position)("Product_Type") = "1"
    End Sub

    Private Sub P_typeAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P_typeAdd.Click
        If sender.Checked = True Then TProductBindingSource.Item(TProductBindingSource.Position)("Product_Type") = "0"
    End Sub

    Private Sub Product_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            Me.MasterGrid.TableElement.RowHeight = 25
            Me.MasterGrid.TableElement.TableHeaderHeight = 30
            Oper = 0

            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)

        Catch ex As Exception
            MsgBox(ex.Message())
            Product_Load(sender, e)
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

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If cls_role.Check_Permission(MAIN.U_GROUP, Page_Group) Then
            MasterGrid.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False

            If MsgBox("Product : '" & P_Code.Text & "', Do you want to delete?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete T_Product where Product_code='" & Trim(P_Code.Text) & "'"

                    cls.Delete(q)

                    Product_Load(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message())
                    Product_Load(sender, e)
                    Exit Sub
                End Try
            Else
                Product_Load(sender, e)
            End If
        Else
            MessageBox.Show("No Permission!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Product_Load(sender, e)
            Exit Sub
        End If
    End Sub
End Class
