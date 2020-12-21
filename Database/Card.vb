Imports System
Imports ExtendedErrorProvider
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data

Public Class Card
    Private cls As New Class_SQKDB

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim ED As Integer = 0
    Dim Add As Integer = 0
    Dim D_Num As Integer = 0
    Dim Del As Integer = 0
    Dim CardOld As String

    Private Sub Card_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim descriptor As New FilterDescriptor(Cardcar1.DisplayMember, FilterOperator.StartsWith, String.Empty)
        'Cardcar1.EditorControl.FilterDescriptors.Add(descriptor)
        'Cardcar1.DropDownStyle = RadDropDownStyle.DropDown

        CARDREAD.Items.Insert(0, New RadListDataItem(String.Empty, String.Empty))

        MasterTemplate.FilterDescriptors.Clear()

        Me.T_DRIVERTableAdapter.Fill(Me.DataSet_Table.T_DRIVER)
        Me.T_TRUCKTableAdapter.Fill(Me.DataSet_Table.T_TRUCK)
        Me.T_CARDTableAdapter.Fill(Me.DataSet_Table.T_CARD)

        BindingNavigator1.Enabled = True
        DetailGroup.Enabled = False
        MasterTemplate.Enabled = True


    End Sub

    Private Sub U_StatusOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_StatusOn.Click
        If sender.Checked = True Then TCARDBindingSource.Item(TCARDBindingSource.Position)("CARD_STATUS") = "1"
    End Sub

    Private Sub U_StatusOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_StatusOff.Click
        If sender.Checked = True Then TCARDBindingSource.Item(TCARDBindingSource.Position)("CARD_STATUS") = "0"
    End Sub

    Private Sub TCardBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            G_SUM.Text = TCARDBindingSource.Count.ToString

            ToolStripLabel1.Text = "of { " & TCARDBindingSource.Count.ToString & " }"
            CardNo.Text = TCARDBindingSource.Item(TCARDBindingSource.Position)("Card_Number").ToString
            If ED = 1 Then TCARDBindingSource.Item(TCARDBindingSource.Position)("update_date") = Now
            If UCase(TCARDBindingSource.Item(TCARDBindingSource.Position)("Card_STATUS").ToString) = "1" Then
                U_StatusOn.Checked = True
            Else
                U_StatusOff.Checked = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Dim q As String
        Try
            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)

        Catch ex As Exception
        End Try

        If ED = 0 Then
            Try
                TDriverBindingSource.CancelEdit()
                q = ""
                q = "select card_serial from vCardload where card_serial=Substr(('000000'||'" & CardSerial.Text & "'),-10,'" & CardSerial.Text & "')"
                q = "select card_serial from vCardload where card_serial='" & CardSerial.Text & "'"

                Dim dt As DataTable = cls.Query(q)

                If dt.Rows.Count > 0 Then
                    MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้ รหัสข้อมูลบัตรซ้ำ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                q = ""
                q = "Insert into T_CARD "
                q &= " (Card_Number,"
                q &= "Card_Type,"
                q &= "CARD_CAR,"
                q &= "TRUCK_ID,"
                q &= "CARD_DRIVER ,"
                q &= "DRIVER_ID,"
                q &= "CARD_TYPE_READ ,"
                q &= "CARD_SERIAL ,"
                q &= "CARD_STATUS ,"
                q &= "CARD_DATEBEGIN,"
                q &= "CARD_DATEEND ,"
                q &= "CARD_OPER ,"
                q &= "REMARK ,"
                q &= "UPDATE_DATE,"
                q &= "UPDATE_BY)"
                q &= " Values ("
                q &= "'" + (CardNo.Text) + "'" + ","
                q &= "'" + (CardType.Text) + "'" + ","

                If CardType.Text = "TRUCK" Then
                    q &= "'" + (TTruckBindingSource.Item(TTruckBindingSource.Position)("ID").ToString()) + "'" + ","
                    q &= "'" + (TTruckBindingSource.Item(TTruckBindingSource.Position)("ID").ToString()) + "'" + ","
                    q &= "''" + ","
                    q &= "''" + ","
                End If
                If CardType.Text = "DRIVER" Then
                    q &= "''" + ","
                    q &= "''" + ","
                    q &= "'" + (TDriverBindingSource.Item(TDriverBindingSource.Position)("DRIVER_NUMBER").ToString()) + "'" + ","
                    q &= "'" + (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) + "'" + ","
                End If
                q &= "'" + (CARDREAD.Text) + "'" + ","
                q &= "'" + (CardSerial.Text) + "'" + ","
                'q &= "'" + (Card_ISSUEDATE.Text) + "'" + ","
                'q &= "'" + (Card_Expriredate.Text) + "'" + ","   TCardBindingSource.Item(TCardBindingSource.Position)("CARD_STATUS")
                If TCardBindingSource.Item(TCardBindingSource.Position)("CARD_STATUS") = 1 Then
                    q &= " 1 ,"
                Else
                    q &= " 0 ,"
                End If
                Dim n_year As Integer = 0
                n_year = 543
                q &= "TO_DATE('" + (String.Format("{0:dd/MM/yyyy}", DateAdd(DateInterval.Year, -n_year, Card_ISSUEDATE.Value))) + "','DD/MM/YYYY')" + ","
                q &= "TO_DATE('" + (String.Format("{0:dd/MM/yyyy}", DateAdd(DateInterval.Year, -n_year, Card_Expriredate.Value))) + "','DD/MM/YYYY')" + ","

                'q &= "TO_DATE('" + (String.Format("{0:dd/MM/yyyy}", Card_ISSUEDATE.Value)) + "','DD/MM/YYYY')" + ","
                'q &= "TO_DATE('" + (String.Format("{0:dd/MM/yyyy}", Card_Expriredate.Value)) + "','DD/MM/YYYY')" + ","

                q &= "'" + (User_logon.Text) + "'" + ","
                q &= "'" + (REMARK.Text) + "'" + ","
                q &= "'" + (U_UPDATE.Text) + "'" + ","
                q &= "'" + (U_UPDATEBY.Text) + "'" + ")"

                cls.Insert(q)

                Card_Load(sender, e)
            Catch ex As Exception
                'MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MsgBox(ex.Message())
                Exit Sub
            End Try
        End If

        If ED = 1 Then
            Try
                TDriverBindingSource.CancelEdit()
                q = ""
                q = "select card_serial from vCardload where card_serial=Substr(('000000'||'" & CardSerial.Text & "'),-10,'" & CardSerial.Text & "')"
                q = "select card_serial from T_CARD where card_serial='" & CardSerial.Text & "'"

                Dim dt As DataTable = cls.Query(q)

                If dt.Rows.Count > 0 And (CardSerial.Text <> CardOld.ToString) Then
                    MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้ รหัสข้อมูลบัตรซ้ำ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                q = ""
                q = " Update T_Card "
                q &= " Set Card_Type = "
                q &= "'" + CardType.Text + "'" + ","

                If CardType.Text = "TRUCK" Then
                    q &= "CARD_CAR = " + (TTruckBindingSource.Item(TTruckBindingSource.Position)("ID").ToString()) + ","
                    q &= "TRUCK_ID = " + (TTruckBindingSource.Item(TTruckBindingSource.Position)("ID").ToString()) + ","
                    q &= "CARD_DRIVER = '' ,"
                    q &= "DRIVER_ID = '' ,"
                End If
                If CardType.Text = "DRIVER" Then
                    q &= "CARD_CAR ='' ,"
                    q &= "TRUCK_ID ='' ,"
                    q &= "CARD_DRIVER = " + (TDriverBindingSource.Item(TDriverBindingSource.Position)("DRIVER_NUMBER").ToString()) + ","
                    q &= "DRIVER_ID = " + (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) + ","
                End If
                q &= "CARD_TYPE_READ  = "
                q &= "'" + CARDREAD.Text + "'" + ","

                q &= "CARD_SERIAL = "
                q &= "'" + CardSerial.Text + "'" + ","

                q &= "CARD_STATUS  = "
                If TCardBindingSource.Item(TCardBindingSource.Position)("CARD_STATUS") = 1 Then
                    q &= " 1 ,"
                Else
                    q &= " 0 ,"
                End If

                Dim n_year As Integer = 0
                n_year = 543
                q &= "CARD_DATEBEGIN = "
                q &= "TO_DATE('" + (String.Format("{0:dd/MM/yyyy}", DateAdd(DateInterval.Year, -n_year, Card_ISSUEDATE.Value))) + "','DD/MM/YYYY')" + ","
                q &= "CARD_DATEEND  = "
                q &= "TO_DATE('" + (String.Format("{0:dd/MM/yyyy}", DateAdd(DateInterval.Year, -n_year, Card_Expriredate.Value))) + "','DD/MM/YYYY')" + ","
                q &= "CARD_OPER = "
                q &= "'" + (User_logon.Text) + "'" + ","
                q &= "Remark = "
                q &= "'" + (REMARK.Text) + "'" + ","
                q &= "UPDATE_DATE = "
                q &= "'" + (U_UPDATE.Text) + "'" + ","
                q &= "UPDATE_BY = "
                q &= "'" + (U_UPDATEBY.Text) + "' "
                q &= "Where Card_Number='" + CardNo.Text + "'"

                cls.Update(q)

            Catch ex As Exception
                MessageBox.Show("ไม่สามารถแก้ไขข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If

        Dim n_year1 As Integer = 0
        n_year1 = 543
        q = ""
        q = " Update T_TRUCK "
        q &= " Set Card_valid_Form = "
        q &= "TO_DATE('" + (String.Format("{0:dd/MM/yyyy}", DateAdd(DateInterval.Year, -n_year1, Card_ISSUEDATE.Value))) + "','DD/MM/YYYY')" + ","
        q &= "Card_valid_TO = "
         q &= "TO_DATE('" + (String.Format("{0:dd/MM/yyyy}", DateAdd(DateInterval.Year, -n_year1, Card_Expriredate.Value))) + "','DD/MM/YYYY')" + " "
        q &= "Where ID='" & TTruckBindingSource.Item(TTruckBindingSource.Position)("ID").ToString() & "'"

        cls.Update(q)

        Card_Load(sender, e)
    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click
        Try
            Bcancel_Click(sender, e)
            MasterTemplate.FilterDescriptors.Clear()
            MasterTemplate.SuspendLayout()
            MasterTemplate.DataSource = Nothing
            TCardBindingSource.AddNew()
            ED = 0
            Cardcar1.SelectedIndex = -1
            TDriverBindingSource.Position = 0

            Cardcar1.Enabled = False
            CardDriver.Enabled = False
            U_StatusOn.Checked = True
            TCardBindingSource.Item(TCardBindingSource.Position)("CARD_STATUS") = "1"
            TCardBindingSource.Item(TCardBindingSource.Position)("CARD_DATE") = Now
            Card_ISSUEDATE.Value = Now
            Card_Expriredate.Value = Now

            User_logon.Text = MAIN.U_NAME
            U_StatusOn.Checked = True
            Del = 0
            DetailGroup.Enabled = True
            BindingNavigator1.Enabled = False
            MasterTemplate.Enabled = True

            CardType.SelectedIndex = 0
            CardType_Leave(sender, e)
            Cardcar1.Focus()
        Catch ex As Exception

        End Try

        Dim q, T_ID As String
        Try
            q = ""
            q = "select NVL(max(CARD_NUMBER),0)+1 as CARD_NUMBER   from T_CARD"

            Dim dt As DataTable = cls.Query(q)

            D_Num = Int(dt(0)("CARD_NUMBER"))

            CardSerial.Text = ""
            MasterTemplate.DataSource = TCardBindingSource
            MasterTemplate.ResumeLayout()

        Catch ex As Exception
        End Try
        CardNo.Text = D_Num.ToString
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TDriverBindingSource.CancelEdit()
        DataSet_Table.T_DRIVER.RejectChanges()
        Card_Load(sender, e)
    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        MasterTemplate.Enabled = True
        DetailGroup.Enabled = True
        U_UPDATEBY.Text = MAIN.U_NAME
        BindingNavigator1.Enabled = False
        ED = 1

        If CardType.Text = "TRUCK" Then
            CardType.SelectedIndex = 0
        Else
            CardType.SelectedIndex = 1
        End If
        CardType_Leave(sender, e)

        CardSerial.Focus()
        Try
            CardOld = TCardBindingSource.Item(TCardBindingSource.Position)("CARD_Serial").ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If MAIN.U_GROUP_ID < 3 Then
            MessageBox.Show("User นี้ไม่สามารถลบข้อมูลได้ ต้องเป็น User Supervisor", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Card_Load(sender, e)
            Exit Sub
        Else

            MasterTemplate.Enabled = True
            DetailGroup.Enabled = False
            BindingNavigator1.Enabled = False


            If MsgBox("ต้องการลบข้อมูลบัตร ' " & CardNo.Text & " ' หรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then
                Try
                    Dim q As String

                    q &= ""
                    q &= "Delete T_Card where Card_number='" + CardNo.Text + "'"

                    cls.Delete(q)

                    Card_Load(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message())
                    Card_Load(sender, e)
                    Exit Sub
                End Try
            Else
                Card_Load(sender, e)
                Exit Sub
            End If
        End If
    End Sub


    Private Sub Card_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            Me.MasterTemplate.TableElement.RowHeight = 25
            Me.MasterTemplate.TableElement.TableHeaderHeight = 30
            MasterTemplate.FilterDescriptors.Clear()

            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MasterTemplate_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles MasterTemplate.CellFormatting
        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
    End Sub

    Private Sub CardType_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardType.Leave
        Try
            If CardType.SelectedIndex = 0 Then ' Truck
                Cardcar1.Enabled = True
                CardDriver.Enabled = False
                CardDriver.SelectedIndex = -1
                TDriverBindingSource.Position = 0
                Add = 1
            End If
            If CardType.SelectedIndex = 1 Then 'Driver
                CardDriver.Enabled = True
                Cardcar1.Enabled = False
                Cardcar1.SelectedIndex = -1
                TTruckBindingSource.Position = 0
                Add = 2
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cardcar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cardcar1.Click
        'Cardcar1.MultiColumnComboBoxElement.ShowPopup()
    End Sub

    Private Sub CardSerial_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CardSerial.KeyPress

    End Sub

End Class
