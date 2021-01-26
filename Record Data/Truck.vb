Imports System
Imports ExtendedErrorProvider
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.Export
Imports Telerik.WinControls.UI.Export
Imports System.IO

Public Class Truck
    Private cls As New Class_SQLSERVERDB
    Private cls_role As New Class_Permission

    Private Page_Group As String = "Operate Data"

    Dim Addnew As Boolean
    Dim TRUCK_ID As Integer
    Dim MyErrorProvider As New ErrorProviderExtended
    Public Shared ShowType As Integer
    Public TRUCK_DRIVER, Comp As String
    Public TRUCK_COMPANY As String
    Public TRUCK_NO As String
    Dim Evens As Integer = 0
    Dim adddata As String = 0
    Dim Ref As String

    Dim EditDoc, AddDoc As Boolean

    Public Function Chk_View()
        '------------------------------------------- Start Check Permission
        RadMessageBox.SetThemeName("Office2010Blue")

        cls_role.Chk_Permission(MAIN.U_GROUP_ID, 13)

        If cls_role.ChkView = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to view this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Return False
        End If
        '------------------------------------------- End Check Permission
        Return True
    End Function


    Private Sub Truck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet_View.V_TRUCK' table. You can move, or remove it, as needed.
        Me.V_TRUCKTableAdapter.Fill(Me.DataSet_View.V_TRUCK)
        EditDoc = False
        AddDoc = False

        'TODO: This line of code loads data into the 'DataSet_Table.T_TRUCKCOMPARTMENT' table. You can move, or remove it, as needed.
        Me.T_TRUCKCOMPARTMENTTableAdapter.Fill(Me.DataSet_Table.T_TRUCKCOMPARTMENT)
        'TODO: This line of code loads data into the 'DataSet_Table.T_TRUCK' table. You can move, or remove it, as needed.
        Me.T_TRUCKTableAdapter.Fill(Me.DataSet_Table.T_TRUCK)
        Dim descriptor1 As New FilterDescriptor(Ve_tran1.DisplayMember, FilterOperator.StartsWith, String.Empty)
        Ve_tran1.EditorControl.FilterDescriptors.Add(descriptor1)
        Ve_tran1.DropDownStyle = RadDropDownStyle.DropDown

        MasterGrid.FilterDescriptors.Clear()

        Me.T_COMPANYTableAdapter.Fill(Me.DataSet_Table.T_COMPANY)
        'TODO: This line of code loads data into the 'IRPCDataset.T_TRUCKTYPE' table. You can move, or remove it, as needed.
        Me.T_TRUCKTYPETableAdapter.Fill(Me.DataSet_Table.T_TRUCKTYPE)
        'TODO: This line of code loads data into the 'IRPCDataset.T_TRUCKUNIT' table. You can move, or remove it, as needed.

        'RadGridView1.DataSource = TTruckComploadBindingSource
        'RadGridView1.ResumeLayout()
        RadPageView1.SelectedPage = RadPageViewPage1
        Me.DataSet_Table.Relations.Clear()
        adddata = 0
        Comp = "0"
        DetailGroup.Enabled = False
        'VE_EXPIREDATE.Value = Now
        RadPanel4.Enabled = False
        Try
            Dim relation As New DataRelation("TRUCKCOMPARTMENT",
                     Me.DataSet_Table.Tables("T_TRUCK").Columns("ID"),
                     Me.DataSet_Table.Tables("T_TRUCKCOMPARTMENT").Columns("T_TRUCKID"),
                     False)
            Me.DataSet_Table.Relations.Add(relation)
            TTRUCKBindingSource.DataSource = Me.DataSet_Table
            TTRUCKBindingSource.DataMember = "T_TRUCK"
            TTRUCKCOMPARTMENTBindingSource.DataSource = TTRUCKBindingSource
            TTRUCKCOMPARTMENTBindingSource.DataMember = "TRUCKCOMPARTMENT"
            Me.T_TRUCKTableAdapter.Fill(Me.DataSet_Table.T_TRUCK)
            Me.T_TRUCKCOMPARTMENTTableAdapter.Fill(Me.DataSet_Table.T_TRUCKCOMPARTMENT)
            DataComp.DataSource = TTRUCKCOMPARTMENTBindingSource
            BindingNavigator1.Enabled = True
            MasterGrid.Enabled = True
            Evens = 0

            'VE_COMNUM_Leave(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Dim q As String
        Dim dt As DataTable

        Try
            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)

        Catch ex As Exception

        End Try

        Try
            Try
                If Evens = 0 Then
                    TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("update_date") = Now
                    TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_COMPANY") = TCOMPANYBindingSource.Item(TCOMPANYBindingSource.Position)("COMPANY_ID")
                    TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_OWNER") = Owner.Text
                    TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_TYPE") = TTRUCKTYPEBindingSource.Item(TTRUCKTYPEBindingSource.Position)("ID")
                    TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_TRA") = RadTextBox2.Text

                    TTRUCKBindingSource.EndEdit()
                    T_TRUCKTableAdapter.Update(Me.DataSet_Table.T_TRUCK)
                    Me.DataSet_Table.T_TRUCK.AcceptChanges()
                    BindingNavigator1.Enabled = True
                    DetailGroup.Enabled = True
                    RadPanel4.Enabled = True

                    Me.BringToFront()


                    q = ""
                    q = "select max(ID) as TRUCK_ID   from T_TRUCK order by id desc"

                    dt = cls.Query(q)

                    If dt(0)("TRUCK_ID").ToString = "" Then
                        MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้ กรุณาตรวจสอบ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Truck_Load(sender, e)
                        Exit Sub
                    End If
                    TRUCK_ID = dt(0)("TRUCK_ID")

                    Dim i As Integer
                    For i = 0 To DataComp.Rows.Count - 1
                        q = ""
                        q = "insert into T_Truckcompartment ("
                        q &= "T_TRUCKID,"
                        q &= "T_TRUCKCOMPNO,"
                        q &= "T_TRUCKCOMPCAP,"
                        q &= "T_TRUCKCOMPCAP_L "
                        q &= ") values("
                        q &= "" & TRUCK_ID & ","
                        q &= "" & DataComp.Rows.Item(i).Cells(0).Value & ","
                        q &= "" & DataComp.Rows.Item(i).Cells(1).Value & ","
                        q &= "" & DataComp.Rows.Item(i).Cells(2).Value & ")"

                        cls.Insert(q)
                    Next
                End If

            Catch ex As Exception
                MsgBox(ex.Message())
                Exit Sub
            End Try

            If Evens = 1 Then
                Try
                    If VE_COMNUM.Text = "" And Comp = "" Then
                        VE_COMNUM_Leave(sender, e)
                    End If
                    VE_COMNUM.Focus()
                    Try
                        Dim trucktype_ID As String
                        trucktype_ID = TTRUCKTYPEBindingSource.Item(TTRUCKTYPEBindingSource.Position)("ID").ToString()

                        If TTRUCKTYPEBindingSource.Item(TTRUCKTYPEBindingSource.Position)("ID") <> "1002" And (DataComp.Rows.Count = 0 Or VE_COMNUM.Text = "" Or VE_COMNUM.Text = "0") Then
                            MessageBox.Show("Cannot edit record, Please check compartment data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                            RadPageView1.SelectedPage = RadPageViewPage1
                            'RadPageView1.Pages.Item(0).Enabled = True
                            'RadPageView1.Pages.Item(1).Enabled = True
                        End If
                    Catch ex As Exception

                    End Try

                    TRUCK_ID = T_ID.Text

                    q = ""
                    q = " Update T_Truck "
                    q &= " Set TRUCK_BLACK_LIST='" & TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_BLACK_LIST").ToString() & "', "
                    q &= "truck_number = '" & VE_NUM.Text & "',"
                    q &= "Truck_Company='" & TCOMPANYBindingSource.Item(TCOMPANYBindingSource.Position)("COMPANY_ID").ToString() & "', "
                    q &= "Truck_type='" & TTRUCKTYPEBindingSource.Item(TTRUCKTYPEBindingSource.Position)("ID").ToString() & "', "

                    If TTRUCKTYPEBindingSource.Item(TTRUCKTYPEBindingSource.Position)("ID").ToString() = "1003" Then
                        q &= "TRUCK_TRA='" & RadTextBox2.Text & "', "
                    Else
                        q &= "TRUCK_TRA='', "
                    End If

                    Dim n_year As Integer = 0
                    n_year = 543
                    q &= "TRUCK_MEASURELAST= TO_DATE('" & (String.Format("{0:dd/MM/yyyy HH:mm:ss}", VE_ISSUEDATE.Value)) & "','DD/MM/YYYY HH24:MI:SS')" & ","
                    q &= "TRUCK_MEASURENEXT= TO_DATE('" & (String.Format("{0:dd/MM/yyyy HH:mm:ss}", VE_EXPIREDATE.Value)) & "','DD/MM/YYYY HH24:MI:SS')" & ","
                    q &= "INSURANCE_VALID_FORM= TO_DATE('" & (String.Format("{0:dd/MM/yyyy HH:mm:ss}", INSURANCE_VALID_FORM.Value)) & "','DD/MM/YYYY HH24:MI:SS')" & ","
                    q &= "INSURANCE_VALID_TO= TO_DATE('" & (String.Format("{0:dd/MM/yyyy HH:mm:ss}", INSURANCE_VALID_TO.Value)) & "','DD/MM/YYYY HH24:MI:SS')" & ","
                    q &= "Condition_VALID_FORM= TO_DATE('" & (String.Format("{0:dd/MM/yyyy HH:mm:ss}", Condition_VALID_FORM.Value)) & "','DD/MM/YYYY HH24:MI:SS')" & ","
                    q &= "Condition_VALID_TO= TO_DATE('" & (String.Format("{0:dd/MM/yyyy HH:mm:ss}", Condition_VALID_TO.Value)) & "','DD/MM/YYYY HH24:MI:SS')" & ","
                    q &= "INSURANCE='" & INSURANCE.Text & "', "
                    q &= "INSURANCE_TYPE='" & INSURANCE_Type.Text & "', "
                    q &= "TRUCK_COMP_NUM='" & Comp.ToString & "', "
                    q &= "TRUCK_CAPASITY='" & VE_CAPA.Text & "', "
                    q &= "TRUCK_WEIGHT='" & Min_WEIGHT.Text & "', "
                    q &= "MAX_LOAD_WEIGHT='" & Max_WEIGHT.Text & "', "
                    q &= "Truck_owner= '" & Owner.Text & "',"
                    If VE_ARMTOP.Checked = True Then
                        q &= "TRUCK_LOADTYPE ='TOP', "
                    Else
                        q &= "TRUCK_LOADTYPE ='BOTH', "
                    End If
                    q &= "Update_date= Sysdate ,"
                    q &= "Update_by  ='" & T_UPDATEBY.Text & "', "
                    ' q &= "Transport_type = '" & TransportTypeBindingSource.Item(TransportTypeBindingSource.Position)("ID") & "',"
                    q &= "Remark  ='" & U_REMARK.Text & "' "
                    q &= "WHERE ID ='" & TRUCK_ID.ToString & "'"

                    cls.Update(q)

                Catch ex As Exception
                    MsgBox(ex.Message())
                    RadPageView1.SelectedPage = RadPageViewPage1
                    Exit Sub

                End Try


                If TTRUCKTYPEBindingSource.Item(TTRUCKTYPEBindingSource.Position)("ID") <> "1002" Then
                    q = ""
                    q = "delete  T_Truckcompartment Where T_Truckid=" & TRUCK_ID.ToString & ""

                    cls.Delete(q)

                    Dim i As Integer
                    For i = 0 To DataComp.Rows.Count - 1
                        q = ""
                        q = "insert into T_Truckcompartment ("
                        q &= "T_TRUCKID,"
                        q &= "T_TRUCKCOMPNO,"
                        q &= "T_TRUCKCOMPCAP,"
                        q &= "T_TRUCKCOMPCAP_L "
                        q &= ") values("
                        q &= "" & TRUCK_ID & ","
                        q &= "" & DataComp.Rows.Item(i).Cells(0).Value & ","
                        q &= "" & DataComp.Rows.Item(i).Cells(1).Value & ","
                        q &= "" & DataComp.Rows.Item(i).Cells(2).Value & ")"

                        cls.Insert(q)

                    Next
                End If
            End If

            If AddDoc Then
                cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Create truck no. : " & VE_NUM.Text, "T_TRUCK", "")
                EditDoc = False
                AddDoc = False
            ElseIf EditDoc Then
                cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Edit truck no. : " & VE_NUM.Text, "T_TRUCK", "")
                EditDoc = False
                AddDoc = False
            End If

            Truck_Load(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
    End Sub


    Private Sub VE_COMNUM_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VE_COMNUM.Leave
        Dim Comps As Integer = 0
        Dim SumVal As Double = 0
        Try
            If VE_COMNUM.Text = "0" And Comp = "" Then
                Comps = 1
            End If

            If Evens = 0 Or Comp = "1" Then
                DataComp.DataMember = Nothing
                DataComp.DataSource = Nothing
                DataComp.Rows.Clear()
                TTRUCKCOMPARTMENTBindingSource.CancelEdit()

                For i = 1 To Int(VE_COMNUM.Text)
                    DataComp.Rows.Add(i, 0, 0)
                Next

                VE_CAPA.Text = SumVal
            End If
            If Evens = 1 Then

                Dim sql As String
                sql = ""
                sql = "Select * from t_truckcompartment where T_Truckid='" & TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("ID").ToString() & "'"
                sql &= " order by T_Truckid,T_Truckcompno "

                Dim dt As DataTable = cls.Query(sql)

                If DataComp.Rows.Count - 1 < Int(VE_COMNUM.Text) Then
                    DataComp.DataMember = Nothing
                    DataComp.DataSource = Nothing
                    DataComp.Rows.Clear()
                    TTRUCKCOMPARTMENTBindingSource.CancelEdit()

                    Dim i As Integer
                    For i = 1 To Int(VE_COMNUM.Text)
                        Try
                            DataComp.Rows.Add(i, dt.Rows(i - 1).Item("T_TRUCKCOMPCAP").ToString, dt.Rows(i - 1).Item("T_TRUCKCOMPCAP_L").ToString)
                        Catch ex As Exception
                            DataComp.Rows.Add(i, 0, 0)
                        End Try
                    Next
                End If
            End If

            Comp = VE_COMNUM.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub VE_COMNUM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar <> Chr(8) Then
            Dim strAllowableChars As String
            strAllowableChars = "0123456789-:/ "
            If InStr(strAllowableChars, e.KeyChar.ToString) = 0 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub VE_CAPA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar <> Chr(8) Then
            Dim strAllowableChars As String
            strAllowableChars = "0123456789-:/ "
            If InStr(strAllowableChars, e.KeyChar.ToString) = 0 Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        TTRUCKBindingSource.CancelEdit()
        Truck_Load(sender, e)
    End Sub

    Private Sub MasterGrid_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)
        Try
            With sender.Rows(e.RowIndex)
                Select Case UCase(.Cells(4).Value)
                    Case "NO"
                        .DefaultCellStyle.BackColor = Color.White
                    Case "YES"
                        .DefaultCellStyle.BackColor = Color.Red
                End Select
            End With

        Catch ex As Exception

        End Try

    End Sub

    Private Sub VE_BACKYES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VE_BACKYES.Click
        If sender.Checked = True Then TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_BLACK_LIST") = "YES"

    End Sub

    Private Sub VE_BACKNO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VE_BACKNO.Click
        If sender.Checked = True Then TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_BLACK_LIST") = "NO"

    End Sub

    Private Sub VE_ARMTOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VE_ARMTOP.Click

        Try
            If sender.Checked = True Then TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_LOADTYPE") = "TOP"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub VE_ARMBOTH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VE_ARMBOTH.Click

        Try
            If sender.Checked = True Then TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_LOADTYPE") = "BOTH"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub VE_NUM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VE_NUM.TextChanged
        RadTextBox1.Text = VE_NUM.Text
    End Sub

    Private Sub VE_TRA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar <> Chr(8) Then
            Dim strAllowableChars As String
            strAllowableChars = "0123456789-:/ "
            If InStr(strAllowableChars, e.KeyChar.ToString) = 0 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub VE_COMNUM_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        VE_COMNUM_Leave(sender, Nothing)
    End Sub

    Private Sub DataComp_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim i As Integer = 1
            Dim Capa As Integer = 0

            For i = 1 To DataComp.RowCount
                Capa = Capa + Int(DataComp.Rows.Item(i - 1).Cells(1).Value.ToString)
            Next
            VE_CAPA.Text = Capa.ToString

        Catch ex As Exception

        End Try
    End Sub


    Private Sub DataComp_CellValueChanged(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles DataComp.CellValueChanged
        DataComp_Leave(sender, Nothing)
    End Sub

    Private Sub DataComp_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        DataComp_Leave(sender, Nothing)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        DataComp.DataMember = Nothing
        DataComp.DataSource = Nothing
        DataComp.Rows.Add(1, 3000, 200, TRUCK_ID)


    End Sub

    Private Sub DataComp_DefaultValuesNeeded(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewRowEventArgs)

        e.Row.Cells("T_TRUCKID").Value = TRUCK_ID
        e.Row.Cells("T_TRUCKCOMPNO").Value = 1
        e.Row.Cells("T_TRUCKCOMPCAP").Value = 3000
    End Sub


    Private Sub Truck_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        adddata = 0
        Try
            Me.MasterGrid.TableElement.RowHeight = 25
            Me.MasterGrid.TableElement.TableHeaderHeight = 30

            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)

        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub

    Private Sub MasterGrid_CellFormatting_1(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles MasterGrid.CellFormatting
        Try
            e.CellElement.NumberOfColors = 4
            e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
            e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
            e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
            e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
        Catch ex As Exception

        End Try
    End Sub



    Private Sub VE_TRAN1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Ve_tran1.MultiColumnComboBoxElement.ShowPopup()
    End Sub

    Private Sub TTruckBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TTRUCKBindingSource.PositionChanged
        Try
            If BtEdit.Enabled = False Then TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("update_date") = Now

            If UCase(TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_LOADTYPE").ToString()) = "TOP" Then
                VE_ARMTOP.Checked = True
            Else
                VE_ARMBOTH.Checked = True
            End If

            If UCase(TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_BLACK_LIST").ToString()) = "YES" Then
                VE_BACKYES.Checked = True
            Else
                VE_BACKNO.Checked = True
            End If

            Try
                Dim TruckCom As String
                TruckCom = TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("truck_Company").ToString
                Try
                    If TruckCom = "0" Then
                        TCOMPANYBindingSource.Position = -1
                    Else
                        TCOMPANYBindingSource.Position = Int(TCOMPANYBindingSource.Find("Company_ID", TruckCom.ToString))
                    End If

                Catch ex As Exception
                    TCOMPANYBindingSource.Position = -1
                End Try

                'TransportTypeBindingSource.Position = 2
                'TransportTypeBindingSource.Position = Int(TransportTypeBindingSource.Find("ID", TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("transport_type").ToString))

                'Me.DataSet_Table.T_TRUCKCOMPARTMENT.FindByID(TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("ID"))
                'RadGridView1.DataSource = Nothing
            Catch ex As Exception
                'TransportTypeBindingSource.Position = -1
            End Try

            G_SUM.Text = TTRUCKBindingSource.Count.ToString
            ToolStripLabel1.Text = "of { " & TTRUCKBindingSource.Count.ToString & " }"
            'Evens = 1
            'VE_COMNUM_Leave(sender, e)
            'Evens = 0
        Catch ex As Exception

        End Try
        'Try
        '    If ShowType <> 1 Then
        '        Dim Idtruck As Integer = 0
        '        Idtruck = TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("ID").ToString
        '        TTRUCKCOMPARTMENTBindingSource.Filter = "T_TRUCKID=" & Idtruck
        '        'TTruckCompBindingSource.Filter = "T_TRUCKID=" & Idtruck
        '        'TTruckComploadBindingSource.Filter = "TRUCK_ID=" & Idtruck
        '        RadGridView1.Refresh()
        '    End If
        'Catch ex As Exception

        'End Try
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
            EditDoc = True
            AddDoc = False

            Comp = ""
            MasterGrid.Enabled = False
            DetailGroup.Enabled = True
            RadPanel4.Enabled = True

            BindingNavigator1.Enabled = False

            Evens = 1
            TRUCK_ID = T_ID.Text
            VE_NUM.Focus()
            VE_COMNUM_Leave(sender, e)
            Comp = VE_COMNUM.Text

        Catch ex As Exception

        End Try
        'TextBox1.Text = Comp.ToString
    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btadd.Click


        '------------------------------------------- Check Add Permission
        If cls_role.ChkAdd = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to add data in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Add Permission


        INSURANCE_VALID_TO.Value = Date.Now
        INSURANCE_VALID_FORM.Value = Date.Now
        VE_ISSUEDATE.Value = Date.Now
        VE_EXPIREDATE.Value = Date.Now
        Condition_VALID_FORM.Value = Date.Now
        Condition_VALID_TO.Value = Date.Now
        adddata = 1
        Try
            EditDoc = False
            AddDoc = True

            MasterGrid.FilterDescriptors.Clear()
            MasterGrid.SuspendLayout()
            MasterGrid.DataSource = Nothing
            TTRUCKBindingSource.AddNew()
            Ve_tran1.SelectedIndex = -1
            Owner.SelectedIndex = -1
            'UNIT.SelectedIndex = 0
            TRuckType.SelectedIndex = -1

            DetailGroup.Enabled = True

            RadPanel4.Enabled = True
            BindingNavigator1.Enabled = False
            MasterGrid.Enabled = False
            VE_BACKNO.Checked = True

            Try
                TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_LOADTYPE") = "TOP"
                TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_BLACK_LIST") = "NO"
                TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_DATE") = Now
                TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_TYPE") = "1"
                TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_ARM") = "1"

                ''' ประกันภัย

                TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("INSURANCE_VALID_TO") = Now
                TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("INSURANCE_VALID_FORM") = Now
                ''' วัดน้ำ
                TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_MEASURELAST") = Now
                TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("TRUCK_MEASURENEXT") = Now
                TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("CONDITION_VALID_FORM") = Now
                TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("CONDITION_VALID_TO") = Now


                MasterGrid.DataSource = TTRUCKBindingSource
                MasterGrid.ResumeLayout()

            Catch ex As Exception
                MessageBox.Show("Cannot add record, Contact administrator", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TTRUCKBindingSource.CancelEdit()
                Truck_Load(sender, e)
                Exit Sub
            End Try
            VE_ISSUEDATE.Value = Now
            VE_EXPIREDATE.Value = Now
            VE_ARMTOP.Checked = True
            VE_BACKNO.Checked = True

            Evens = 0
            RadPageView1.SelectedPage = RadPageViewPage1
            VE_NUM.Focus()
        Catch ex As Exception

        End Try
    End Sub



    Private Sub BtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDelete.Click

        '------------------------------------------- Check Delete Permission
        If cls_role.ChkDel = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to delete data in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Delete Permission


        Try
            TRUCK_ID = T_ID.Text
            If MsgBox("Truck No. : '" & VE_NUM.Text & "', Do you want to delete?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
                Try

                    Dim sql As String
                    sql = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
                      & ",USERGROUP='" & MAIN.U_GROUP & "'"

                    cls.Update(sql)

                Catch ex As Exception
                End Try

                Dim q As String

                q = ""
                q = "delete  T_truck Where ID='" & TRUCK_ID.ToString & "' and Truck_number='" & VE_NUM.Text & "'"

                cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Delete truck no. : " & VE_NUM.Text, "T_TRUCK", "")

                cls.Delete(q)

                q = ""
                q = "delete  T_Truckcompartment Where T_Truckid=" + TRUCK_ID.ToString + ""

                cls.Delete(q)

                Truck_Load(sender, e)
            Else
                Truck_Load(sender, e)
            End If
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub

    Private Sub VTRUCKBindingSource_PositionChanged(sender As Object, e As EventArgs) Handles VTRUCKBindingSource.PositionChanged
        Try
            TTRUCKBindingSource.Position = TTRUCKBindingSource.Find("ID", VTRUCKBindingSource.Item(VTRUCKBindingSource.Position)("ID"))
            TTruckBindingSource_PositionChanged(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButton3_Click(sender As Object, e As EventArgs) Handles RadButton3.Click


        Dim tempPath As String = ""

        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "Excel files (*.xls)|*.xls"
        saveFileDialog1.FilterIndex = 1
        saveFileDialog1.RestoreDirectory = True


        If saveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            Dim exporter As New ExportToExcelML(MasterGrid)
            Dim exportThemeColors As Boolean = True

            tempPath = saveFileDialog1.FileName

            'Dim spreadExporter As New GridViewSpreadExport(MasterGrid)
            'spreadExporter.ExportChildRowsGrouped = True
            'spreadExporter.ExportGroupedColumns = True
            'spreadExporter.ExportVisualSettings = True

            'Dim exportRenderer As New SpreadExportRenderer()

            Try
                exporter.RunExport(tempPath)
                'spreadExporter.RunExport(tempPath, exportRenderer)
            Catch ex As Exception
                MsgBox(ex)
            End Try


            MsgBox("Export Success.", MsgBoxStyle.Information, "Success!")
        End If
    End Sub

    Private Sub TTRUCKTYPEBindingSource_PositionChanged(sender As Object, e As EventArgs) Handles TTRUCKTYPEBindingSource.PositionChanged
        Try
            Dim TruckTypeID As Integer = TTRUCKTYPEBindingSource.Item(TTRUCKTYPEBindingSource.Position)("ID")
            If TruckTypeID = 1003 Then
                RadTextBox2.Enabled = True
            Else
                RadTextBox2.Text = ""
                RadTextBox2.Enabled = False
            End If
        Catch ex As Exception
            RadTextBox2.Text = ""
            RadTextBox2.Enabled = False
        End Try
    End Sub

    Private Sub Owner_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Owner.Leave
        If adddata = 1 Then
            Try
                If Owner.SelectedIndex = 1 Then
                    VE_EXPIREDATE.MinDate = "31/12/2599 00:00:00"
                Else
                    VE_EXPIREDATE.MinDate = Date.Now
                End If

            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
