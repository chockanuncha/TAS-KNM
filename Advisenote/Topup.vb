﻿Imports System.Data
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

Public Class Topup
    Private cls As New Class_SQLSERVERDB
    Private cls_role As New Class_Permission
    Private cls_data As New Class_SelectData

    Private Page_Group As String = "Operate Data"

    Private MyErrorProvider As New ErrorProviderExtended
    Private TRUCK_COMP_NUM, sum, auto, sealEdit, Chkin, Chkout, Kiosk As Integer
    'Private EditType As Integer
    Private EditType, CanExit As Integer
    Dim Seallast As String
    Dim ProductCom(12) As String
    Private product_Do, Seal_Last, Checkin_ID, Truck_id As String
    Private QTIME, Checkintime As DateTime
    Private Property Advisenote As Object
    Public authorizeUser As Integer = 0
    Public AuthorRemark, AuthorRemarkDriver As String

    Public isFind As Boolean = False
    Public FindRef As String = ""

    Dim EditDoc, AddDoc As Boolean

    Public Function Chk_View()
        '------------------------------------------- Start Check Permission
        RadMessageBox.SetThemeName("Office2010Blue")

        cls_role.Chk_Permission(MAIN.U_GROUP_ID, 2)

        If cls_role.ChkView = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to view this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()

            Return False
        End If
        '------------------------------------------- End Check Permission
        Return True
    End Function

    Private Sub Advisenote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EditDoc = False
        AddDoc = False




        'TODO: This line of code loads data into the 'IRPCDataset.V_TRUCK2' table. You can move, or remove it, as needed.
        'Me.V_TRUCK2TableAdapter.Fill(Me.IRPCDataset.V_TRUCK2)

        My.Application.ChangeCulture("en-US")
        'My.Application.ChangeCulture("th-TH")


        Dim descriptor As New FilterDescriptor(EdCustomer.DisplayMember, FilterOperator.StartsWith, String.Empty)
        EdCustomer.EditorControl.FilterDescriptors.Add(descriptor)
        EdCustomer.DropDownStyle = RadDropDownStyle.DropDown

        Dim descriptor3 As New FilterDescriptor(Cbn3.DisplayMember, FilterOperator.StartsWith, String.Empty)
        Cbn3.EditorControl.FilterDescriptors.Add(descriptor3)
        Cbn3.DropDownStyle = RadDropDownStyle.DropDown
        Dim descriptor4 As New FilterDescriptor(Driver.DisplayMember, FilterOperator.StartsWith, String.Empty)
        Driver.EditorControl.FilterDescriptors.Add(descriptor4)
        Driver.DropDownStyle = RadDropDownStyle.DropDown

        Dim descriptor5 As New FilterDescriptor(Product.DisplayMember, FilterOperator.StartsWith, String.Empty)
        Product.EditorControl.FilterDescriptors.Add(descriptor5)
        Product.DropDownStyle = RadDropDownStyle.DropDown

        Dim descriptor6 As New FilterDescriptor(Bay.DisplayMember, FilterOperator.StartsWith, String.Empty)
        Bay.EditorControl.FilterDescriptors.Add(descriptor6)
        Bay.DropDownStyle = RadDropDownStyle.DropDown

        Dim descriptor7 As New FilterDescriptor(Meter.DisplayMember, FilterOperator.StartsWith, String.Empty)
        Meter.EditorControl.FilterDescriptors.Add(descriptor7)
        Meter.DropDownStyle = RadDropDownStyle.DropDown
        Cbn2.Enabled = True

        Me.T_STATUSTableAdapter.Fill(Me.DataSet_Table.T_STATUS)
        'TODO: This line of code loads data into the 'IRPCDataset.T_TRUCKTYPE' table. You can move, or remove it, as needed.
        Me.T_TRUCKTYPETableAdapter.Fill(Me.DataSet_Table.T_TRUCKTYPE)
        'TODO: This line of code loads data into the 'IRPCDataset.T_BATCHMETER' table. You can move, or remove it, as needed.
        Me.T_BATCHMETERTableAdapter.Fill(Me.DataSet_Table.T_BATCHMETER)
        'TODO: This line of code loads data into the 'IRPCDataset.V_TRUCK' table. You can move, or remove it, as needed.
        Me.V_TRUCKTableAdapter.Fill(Me.DataSet_View.V_TRUCK)

        'TODO: This line of code loads data into the 'IRPCDataset.T_BAY' table. You can move, or remove it, as needed.
        Me.T_BAYTableAdapter.Fill(Me.DataSet_Table.T_BAY)
        'TODO: This line of code loads data into the 'IRPCDataset2.T_PRODUCT' table. You can move, or remove it, as needed.
        Me.T_PRODUCTTableAdapter1.Fill(Me.DataSet_Table.T_PRODUCT)
        'TODO: This line of code loads data into the 'IRPCDataset.T_SHIPPER' table. You can move, or remove it, as needed.
        Me.T_SHIPPERTableAdapter.Fill(Me.DataSet_Table.T_SHIPPER)
        'TODO: This line of code loads data into the 'IRPCDataset.T_COMPANY' table. You can move, or remove it, as needed.
        Me.T_COMPANYTableAdapter.Fill(Me.DataSet_Table.T_COMPANY)
        'TODO: This line of code loads data into the 'IrpcDataset1.T_COMPANY' table. You can move, or remove it, as needed.

        Me.T_CUSTOMERTableAdapter.Fill(Me.DataSet_Table.T_CUSTOMER)
        'Me.T_PRODUCTTableAdapter.Fill(Me.DataSet1.T_PRODUCT)
        Me.T_DRIVERTableAdapter.Fill(Me.DataSet_Table.T_DRIVER)
        'Catch ex As Exception
        'MessageBox.Show("ไม่สามารถ Connect Database ได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Exit Sub
        ' End Try

        EditType = 0
        sealEdit = 0
        'Me.T_TRUCKTableAdapter.Fill(Me.IRPCDataset.T_TRUCK)
        MyErrorProvider.Controls.Clear()
        MyErrorProvider.Controls.Add(Cbn2, "Vehicle No")
        MyErrorProvider.Controls.Add(Driver, "Driver Name")
        MyErrorProvider.Controls.Add(EdCustomer, " Customer code")
        MyErrorProvider.ClearAllErrorMessages()
        MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        RadPageView1.SelectedPage = RadPageViewPage1

        SelectVLoadingNote()

    End Sub

    Private Sub Advisenote_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        'Dim x As Integer = 0
        'Dim y As Integer = 5
        'x = RadPanel2.Height + y
        'RadPageView1.Height = Me.Height - x
        Cbn2.Enabled = True
        Chkin = 0
        Chkout = 0
        Kiosk = 0

        authorizeUser = 0
        Me.MasterGridAdvisenote.TableElement.RowHeight = 25
        Me.MasterGridAdvisenote.TableElement.TableHeaderHeight = 30
        MasterGridAdvisenote.FilterDescriptors.Clear()
        Status.Enabled = True
        Dim q, s_day, s_month, s_year, s_hr, s_mn, s_sc, TTimes As String
        s_day = Date.Now.Day
        s_month = Date.Now.Month
        s_year = Date.Now.Year
        RadPageView1.SelectedPage = RadPageViewPage1
        Bsave.Visible = True
        Update.Visible = False

        ClearData()
        CompClear()

        'Try
        '    Dim sql As String
        '    sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
        '      & ",USERGROUP='" & MAIN.U_GROUP & "'"

        '    cls.Update(sql)
        'Catch ex As Exception

        'End Try
        CanExit = 0
    End Sub

    Private Sub SelectVLoadingNote()
        Dim q As String

        Try
            q = ""
            q = "SELECT   max(T1.LOAD_CAPACITY) as LOAD_CAPACITY"
            q &= " ,max(T1.LOAD_PRESET) as LOAD_PRESET, max(T1.LOAD_CARD) as LOAD_CARD"
            q &= " ,max(T2.LC_COMPARTMENT) as LC_COMPARTMENT"
            q &= " ,max(T2.LC_BAY) as LC_BAY,Reference, max(T1.LOAD_DATE) as LOAD_DATE"
            q &= " ,max(T1.LOAD_DID) as LOAD_DID ,max(T_Status.STATUS_NAME) as STATUS_NAME ,max(T1.LOADDO) as LOAD_DOfull ,max(T_TRUCK.TRUCK_NUMBER) as LOAD_VEHICLE ,max(t_customer.Customer_name) as Customer_name "
            q &= " ,max(T_DRIVER.Driver_NAME)|| '  ' || max(T_Driver.Driver_Lastname) AS LOAD_DRIVER"
            q &= " ,max(T1.load_id) as Load_id,max(V_DO.DO_STATUS) as DO_STATUS"
            q &= ",max(t_product.Product_code) as PRODUCT_CODE,max(T_Batchmeter.BATCH_NAME) as BATCH_NAME"
            q &= " ,max(T1.Container) as Container,max(T1.LOAD_TRUCKCOMPANY) as LOAD_TRUCKCOMPANY,max(T1.LOAD_PRESET) as LOAD_PRESET"
            q &= " ,max(LC_SEAL) as LC_SEAL,max(T1.LOAD_SEAL) as LOAD_SEAL,max(T1.LOAD_SEALCOUNT) as LOAD_SEALCOUNT"
            q &= " ,max(T1.ADDNOTEDATE) as ADDNOTEDATE,max(T2.LC_STARTTIME) as LC_STARTTIME,max(T2.LC_ENDTIME) as LC_ENDTIME "




            q &= "FROM T_Customer  RIGHT OUTER JOIN (Select * from T_LOADINGNOTE  Where T_LOADINGNOTE.AddnoteDate between "
            Dim n_year As Integer = 0
            n_year = 543
            q &= "CONVERT (DATETIME,'" & DateTimePicker1.Value.Year & "/" & DateTimePicker1.Value.Month & "/" & DateTimePicker1.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
            q &= "CONVERT (DATETIME,'" & DateTimePicker2.Value.Year & "/" & DateTimePicker2.Value.Month & "/" & DateTimePicker2.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "



            q &= "And Load_type<>1009 And Load_status in(1,2,3,4,5) and advisenote_type='TOPUP') T1  "
            q &= "ON T_Customer.ID = T1.LOAD_CUSTOMER  "
            q &= "LEFT OUTER JOIN T_STATUS  ON T1.LOAD_STATUS = T_STATUS.STATUS_ID   "
            q &= "LEFT OUTER JOIN V_DO ON T1.LOAD_ID = V_DO.LOAD_ID    "
            q &= "LEFT OUTER JOIN T_TRUCK ON T1.LOAD_VEHICLE = T_TRUCK.ID   "
            q &= "LEFT OUTER JOIN T_DRIVER ON T1.LOAD_DRIVER = T_DRIVER.ID   "
            q &= "LEFT OUTER JOIN T_CARD  ON T1.LOAD_CARD = T_CARD.CARD_NUMBER   "
            q &= "Left OUTER JOIN T_BATCHMETER   "
            q &= "RIGHT OUTER JOIN (Select * From T_LOADINGNOTECOMPARTMENT) T2 "
            q &= "ON T_BATCHMETER.BATCH_NUMBER = T2.LC_METER   "
            q &= "LEFT OUTER JOIN T_Product ON T2.LC_PRO = T_Product.ID ON T1.LOAD_ID = T2.LC_LOAD "
            q &= "group by T1.reference  "
            q &= "order by load_id "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "V_LOADINGNOTE")

            V_LoadingnoteBindingSource.DataSource = MyDataSet
            V_LoadingnoteBindingSource.DataMember = "V_LOADINGNOTE"
            MyDataSet.Dispose()
            n_year = 0
        Catch ex As Exception
        End Try
        EditType = 0
    End Sub

    Private Sub Cbn2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbn2.Leave
        Dim Vdate1, Vdate2, Vdate3 As Integer

        If Cbn2.Text = "" Then
            Exit Sub
        End If

        If EditType <> 1 And CanExit = 0 Then
            Try
                TTruckTypeBindingSource.Position = TTruckTypeBindingSource.Find("ID", VTruckBindingSource.Item(Cbn2.SelectedIndex)("TRUCK_TYPE").ToString)
                TCompanyBindingSource.Position = TCompanyBindingSource.Find("COMPANY_ID", VTruckBindingSource.Item(Cbn2.SelectedIndex)("TRUCK_COMPANYID").ToString)
            Catch ex As Exception
            End Try

            Dim sql As String

            '''''''' Check Truck in Loading
            sql = ""
            sql = "select load_vehicle From t_loadingnote where load_vehicle= '" & VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString & "' and load_status < 3 and Advisenote_type='Topup' "

            Dim dt2 As DataTable = cls.Query(sql)

            If dt2.Rows.Count > 0 Then
                MessageBox.Show("This Truck No. : '" & Cbn2.Text & "' load not yet, Please check!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Cbn2.Text = ""
                Cbn2.SelectedIndex = -1
                Cbn3.SelectedIndex = -1
                Trucktype.SelectedIndex = -1
                Cbn2.Focus()
                Exit Sub
            End If

            '''''''' Check Override Check in
            Dim q As String
            Dim Chk_Insurance, Chk_Measure, Chk_Inspection As Integer
            Chk_Insurance = Chk_Measure = Chk_Inspection = 0

            q = ""
            q = "Select OVERRIDE_NAME, STATUS from t_override"

            Dim dt3 As DataTable = cls.Query(q)
            For Each dr As DataRow In dt3.Rows
                Select Case dr("OVERRIDE_NAME").ToString
                    Case "CHECK IN"
                        Chkin = dr("STATUS")
                    Case "KIOSK"
                        Kiosk = dr("STATUS")
                    Case "CHECK INSURANCE"
                        Chk_Insurance = dr("STATUS")
                    Case "CHECK MEASURE"
                        Chk_Measure = dr("STATUS")
                    Case "CHECK INSPECTION"
                        Chk_Inspection = dr("STATUS")
                End Select
            Next

            'q = ""
            'q = "Select STATUS from t_override where Override_name='KIOSK'"
            'cmd.CommandText = q
            'cmd.ExecuteReader()
            'dr = cmd.ExecuteReader
            'dr.Read()
            'Kiosk = dr.Item("STATUS")

            AuthorRemark = ""
            authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString

            If Chkin = 1 Then
                sql = ""
                sql = "Select * from t_checkin where truck_id='" & VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString() & "'"
                sql &= " and Status in(1) order by ldate desc"

                Dim dt As DataTable = cls.Query(sql)

                If dt.Rows.Count <> 0 Then
                    Checkin_ID = dt.Rows(0).Item("ID").ToString
                    Dim Checkintimes As DateTime = dt.Rows(0).Item("Ldate").ToString
                    Checkintime = Checkintimes.Day & "/" & Checkintimes.Month & "/" & Checkintimes.Year & " " & Checkintimes.Hour & ":" & Checkintimes.Minute & ":" & Checkintimes.Second
                    Dim QTIMEs As Date = dt.Rows(0).Item("Q_DATE").ToString
                    authorizeUser = 0
                    Dim LoadQ As String
                    LoadQ = dt.Rows(0).Item("Q_NO").ToString
                    Cbn7.Text = LoadQ.ToString
                Else
                    MsgBox("Invalid this truck no. in check in process, Please check!", vbOKOnly & vbDefaultButton3, "Error")
                    If MsgBox("Do you want to bypass by Supervisor user?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then
                        authorizeUser = 1
                        Loginauthorize.ShowDialog()
                        If Loginauthorize.Success = 0 Then
                            Cbn2.SelectedIndex = -1
                            Cbn3.SelectedIndex = -1
                            Trucktype.SelectedIndex = -1
                            Cbn2.Focus()
                            Exit Sub
                        End If
                    Else
                        AuthorRemark = ""
                        authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString
                        Cbn2.SelectedIndex = -1
                        Cbn3.SelectedIndex = -1
                        Trucktype.SelectedIndex = -1
                        Cbn2.Focus()
                        Exit Sub
                    End If

                    authorizeUser = 0
                End If
            End If


            sql = ""
            sql = "select Insurance_dateexpire,measure_dateexpire,Condition_dateexpire  From V_Truck where TRUCK_NUMBER= '" & (Cbn2.Text) & "'"

            Dim dt1 As DataTable = cls.Query(sql)

            Try
                Vdate1 = Int(dt1.Rows(0).Item("Insurance_dateexpire").ToString())
                'Vdate1 = Vdate1 + 1
            Catch ex As Exception
                Vdate1 = -1
            End Try

            If Vdate1 <= 0 And Chk_Insurance Then
                MessageBox.Show("Truck's insurance expire, Please check!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If MsgBox("Do you want to bypass by Supervisor user?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then
                    authorizeUser = 2
                    Loginauthorize.ShowDialog()
                    If Loginauthorize.Success = 0 Then
                        'authorize_Remark.Text = ""
                        AuthorRemark = ""
                        authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString
                        Cbn2.SelectedIndex = -1
                        Cbn3.SelectedIndex = -1
                        Trucktype.SelectedIndex = -1
                        Cbn2.Focus()
                        Exit Sub
                    End If
                Else
                    'authorize_Remark.Text = ""
                    AuthorRemark = ""
                    authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString
                    Cbn2.SelectedIndex = -1
                    Cbn3.SelectedIndex = -1
                    Trucktype.SelectedIndex = -1
                    Cbn2.Focus()
                    Exit Sub
                End If
                authorizeUser = 0
            End If

            Try
                Vdate2 = Int(dt1.Rows(0).Item("measure_dateexpire").ToString())
                'Vdate2 = Vdate2 + 1
            Catch ex As Exception
                Vdate2 = -1
            End Try
            If (Vdate2 <= 0 And Vdate2 >= -10000) And Chk_Measure Then
                MessageBox.Show("Truck's measure certificate expire, Please check!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If MsgBox("Do you want to bypass by Supervisor user?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then
                    authorizeUser = 3
                    Loginauthorize.ShowDialog()
                    If Loginauthorize.Success = 0 Then
                        'authorize_Remark.Text = ""
                        AuthorRemark = ""
                        authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString
                        Cbn2.SelectedIndex = -1
                        Cbn3.SelectedIndex = -1
                        Trucktype.SelectedIndex = -1
                        Cbn2.Focus()
                        Exit Sub
                    End If
                Else
                    'authorize_Remark.Text = ""
                    AuthorRemark = ""
                    authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString
                    Cbn2.SelectedIndex = -1
                    Cbn3.SelectedIndex = -1
                    Trucktype.SelectedIndex = -1
                    Cbn2.Focus()
                    Exit Sub
                End If
                authorizeUser = 0
            End If

            Try
                Vdate3 = Int(dt1.Rows(0).Item("Condition_dateexpire").ToString())

            Catch ex As Exception
                Vdate3 = -1
            End Try
            If Vdate3 <= 0 And Chk_Inspection Then
                MessageBox.Show("Truck's inspection certificate expire, Please check!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If MsgBox("Do you want to bypass by Supervisor user?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then
                    authorizeUser = 4
                    Loginauthorize.ShowDialog()
                    If Loginauthorize.Success = 0 Then
                        'authorize_Remark.Text = ""
                        AuthorRemark = ""
                        authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString
                        Cbn2.SelectedIndex = -1
                        Cbn3.SelectedIndex = -1
                        Trucktype.SelectedIndex = -1
                        Cbn2.Focus()
                        Exit Sub
                    End If
                Else
                    'authorize_Remark.Text = ""
                    AuthorRemark = ""
                    authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString
                    Cbn2.SelectedIndex = -1
                    Cbn3.SelectedIndex = -1
                    Trucktype.SelectedIndex = -1
                    Cbn2.Focus()
                    Exit Sub
                End If
                authorizeUser = 0
            End If


            If (Vdate1 < 30 And Vdate1 > 0) And Chk_Insurance Then
                MessageBox.Show("Truck's insurance will expire in : '" & Vdate1.ToString & "' Day", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If (Vdate2 < 30 And Vdate2 > 0) And Chk_Measure Then
                MessageBox.Show("Truck's measure certificate will expire in : '" & Vdate2.ToString & "' Day", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        Try
            If EditType <> 1 Then
                Cbn10.Text = ""
                Order.Text = ""
            End If
            CompClear()
            TRUCK_COMP_NUM = VTruckBindingSource.Item(VTruckBindingSource.Position)("TRUCK_COMP_NUM").ToString
            If sealEdit = 0 Then
                Seal_Total.Text = "0" 'TRUCK_COMP_NUM.ToString

                Seal_Total_Leave(sender, e)
            End If



            Dim TRUCK_CAPASITY As Integer
            Dim q As String

            If Cbn2.SelectedIndex >= 0 Or Cbn2.Text <> "" Then
                q = ""
                q = "select TRUCK_CAPASITY,T_TRUCKCOMPCAP,T_TRUCKCOMPCAP_L from (Select ID,TRUCK_CAPASITY,TRUCK_NUMBER From T_Truck where TRUCK_NUMBER= '" & (Cbn2.Text) & "') T1 "
                q &= "Left Join (Select ID, T_TRUCKID,T_TRUCKCOMPCAP,T_TRUCKCOMPCAP_L From T_Truckcompartment) T2 On T1.ID = T2.T_TRUCKID ORDER BY T1.ID ASC, T2.ID ASC "

                Dim dt As DataTable = cls.Query(q)

                TRUCK_CAPASITY = dt.Rows(0).Item("TRUCK_CAPASITY").ToString()
                Cbn5.Text = TRUCK_CAPASITY

                RadButton1_Click(sender, e)

                For i = 1 To TRUCK_COMP_NUM 'dt.Rows.Count - 1
                    Try
                        DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i).ToString), RadTextBox).Text = "0"
                        DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (i).ToString), RadTextBox).Text = dt.Rows(i - 1).Item("T_TRUCKCOMPCAP").ToString()
                        DirectCast(Me.GroupBox1.Controls.Item("Capacity_l" + (i).ToString), RadTextBox).Text = dt.Rows(i - 1).Item("T_TRUCKCOMPCAP_L").ToString()
                    Catch ex As Exception
                        Exit Sub
                    End Try
                Next i
            End If
            'conn.Close()

            Dim Ttype As String

            q = "Select TRUCK_TYPE, TRUCK_COMPANY, TRUCK_TRA from T_truck where TRUCK_NUMBER= '" & Cbn2.Text & "'"

            Dim tmp As DataTable = cls.Query(q)

            Ttype = tmp(0)("TRUCK_TYPE")

            If Ttype = "1003" Then
                Container.Enabled = False
                Container.Text = tmp(0)("TRUCK_TRA")
                'TruckH.Focus()
                'Exit Sub
            End If
        Catch ex As Exception
            'conn.Close()
        End Try

    End Sub

    Sub ClearData()
        Try
            AuthorRemark = ""
            AuthorRemarkDriver = ""
            authorize_Remark.Text = ""
            'Bay.Text = ""
            Bay.SelectedIndex = -1
            Meter.Text = ""
            Meter.SelectedIndex = -1
            EdCustomer.SelectedIndex = -1
            EdCustomer.Text = ""
            sealEdit = 0
            DO_Type.SelectedIndex = -1
            Cbn2.Text = ""
            Cbn2.SelectedIndex = -1

            Cbn3.Text = ""
            Cbn3.SelectedIndex = -1
            Driver.Text = ""
            Driver.SelectedIndex = -1
            Cbn5.Text = ""
            Cbn7.Text = ""
            Cbn10.Text = ""
            Cbn11.Enabled = True
            Cbn11.Text = ""
            Seal_No.Text = ""
            Shipper.Text = ""

            Trucktype.Text = ""
            Trucktype.SelectedIndex = -1
            Status.Text = ""
            Status.SelectedIndex = 0
            Seal_Total.Text = ""
            Container.Text = ""
            Product.SelectedIndex = -1

            Temp.Text = ""
            Update_date.Text = ""
            Update_by.Text = ""
            Order.Text = ""
            Chkin = 0
            Kiosk = 0
            Chkout = 0
            For i = 1 To 12 'dt.Rows.Count - 1
                Try
                    DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (i).ToString), RadTextBox).Text = ""
                    DirectCast(Me.GroupBox1.Controls.Item("Capacity_l" + (i).ToString), RadTextBox).Text = ""
                    DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i).ToString), RadTextBox).Text = ""
                Catch ex As Exception
                    Exit Sub
                End Try
            Next i
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Try
            CanExit = 1
            EditType = 1
            MyErrorProvider.ClearAllErrorMessages()
            ClearData()
            CompClear()
            Me.Advisenote_Shown(sender, e)
            'EditType = 0
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Cbn4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Driver.Text = "" Then
            DriverID.SelectedIndex = -1
        Else
            DriverID.SelectedIndex = Driver.SelectedIndex
        End If
    End Sub

    Private Sub EDCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EdCustomer.Text = "" Then
            CustomerID.SelectedIndex = -1
        Else
            CustomerID.SelectedIndex = EdCustomer.SelectedIndex
        End If
    End Sub

    Private Sub Adddata_CLICK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Adddata.Click

        '------------------------------------------- Check Add Permission
        If cls_role.ChkAdd = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to add document in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Add Permission


        'Me.T_CUSTOMERTableAdapter.Fill(Me.IRPCDataset.T_CUSTOMER)

        bt_FindLN.Enabled = True

        CanExit = 0
        EditType = 0
        ClearData()
        auto = 0
        DO_Type.SelectedIndex = 0
        Dim q, s_day, s_month, s_year, s_hr, s_mn, s_sc, TTimes As String
        s_day = Date.Now.Day
        s_month = Date.Now.Month
        s_year = Date.Now.Year
        Cbn9.Text = Format(Date.Now.Date, "dd/MM/yyyy")
        Dateedit.Value = Now
        'Dateedit.Value = Format(Cbn9.Text, "dd/MM/yyyy")
        'Dateedit.Value = Format(Now, "dd/MM/yyyy HH:MM:ss")
        'Dateedit.Text = Format(Date.Now.Date, "dd/MM/yyyy")

        Status.SelectedText = "Waiting"
        Status.Enabled = False
        Update_by.Text = MAIN.U_NAME
        Dim Sql As String
        Dim yearthai As String
        yearthai = Str(Int(s_year + 543))

        Dim Chk_Queue As Integer = 0
        Dim dt_tmp As DataTable = cls.Query("SELECT * FROM T_OVERRIDE WHERE OVERRIDE_NAME='QUEUE'")
        For Each dr As DataRow In dt_tmp.Rows
            Chk_Queue = dr("STATUS")
        Next

        Sql = ""
        Sql = "select  NVL(max(LOAD_DID),0)+1 as LOAD_DID from T_LOADINGNOTE "
        Sql &= " where LOAD_DAY=" + s_day + " and LOAD_MONTH =" + s_month + " and LOAD_YEAR=" + yearthai + ""

        Dim dt1 As DataTable = cls.Query(Sql)

        Select Case Chk_Queue
            Case 0
                Cbn7.Text = "0"
                Load_q.Text = "0"
            Case 1
                Cbn7.Text = dt1(0)("Load_DID")
                Load_q.Text = dt1(0)("Load_DID")
        End Select


        Try
            q = ""
            q = "select NVL(max(Load_id),0)+1 as load_id ,NVL(max(Reference),0)+1 as Reference  from T_loadingnote"

            Dim dt2 As DataTable = cls.Query(q)

            Cbn6.Text = dt2(0)("Load_id")
            Cbn8.Text = dt2(0)("Reference")

            EditDoc = False
            AddDoc = True

            RadPageView1.SelectedPage = RadPageViewPage2
            Cbn11.Focus()
            Bsave.Visible = True
            Update.Visible = False

            'Try
            '    Sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
            '      & ",USERGROUP='" & MAIN.U_GROUP & "'"

            '    cls.Update(Sql)
            'Catch ex As Exception
            'End Try

        Catch ex As Exception
            RadPageView1.SelectedPage = RadPageViewPage1
        End Try
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        GDetail.Enabled = True
        Product.SelectedIndex = -1
        Bay.SelectedIndex = -1
        Meter.SelectedIndex = -1

        Dim Comp_Num As Integer
        Comp_Num = TRUCK_COMP_NUM
        Dim i As Integer = 1
        For i = 1 To 12
            DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i).ToString), RadDropDownList).SelectedIndex = -1
            If Comp_Num > 0 Then
                DirectCast(Me.GroupBox15.Controls.Item("Comp" + (i).ToString), RadTextBox).Enabled = True
                DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i).ToString), RadDropDownList).Enabled = True
                DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i).ToString), RadTextBox).Enabled = True
                DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (i).ToString), RadTextBox).Enabled = True
                DirectCast(Me.GroupBox1.Controls.Item("Capacity_l" + (i).ToString), RadTextBox).Enabled = True
                DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i).ToString), RadDropDownList).Enabled = True
                DirectCast(Me.GroupBox10.Controls.Item("Meter" + (i).ToString), RadDropDownList).Enabled = True

            Else
                DirectCast(Me.GroupBox15.Controls.Item("Comp" + (i).ToString), RadTextBox).Enabled = False
                DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i).ToString), RadDropDownList).Enabled = False
                DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i).ToString), RadTextBox).Enabled = False
                DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (i).ToString), RadTextBox).Enabled = False
                DirectCast(Me.GroupBox1.Controls.Item("Capacity_l" + (i).ToString), RadTextBox).Enabled = False
                DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i).ToString), RadDropDownList).Enabled = False
                DirectCast(Me.GroupBox10.Controls.Item("Meter" + (i).ToString), RadDropDownList).Enabled = False
            End If
            Comp_Num = Comp_Num - 1
        Next i
    End Sub

    Private Sub CompClear()
        Dim i As Integer = 1
        For i = 1 To 12
            DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i).ToString), RadDropDownList).SelectedIndex = -1
            DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i).ToString), RadTextBox).Text = ""
            DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (i).ToString), RadTextBox).Text = ""
            DirectCast(Me.GroupBox1.Controls.Item("Capacity_l" + (i).ToString), RadTextBox).Text = ""
            DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i).ToString), RadDropDownList).SelectedIndex = -1
            DirectCast(Me.GroupBox10.Controls.Item("Meter" + (i).ToString), RadDropDownList).SelectedIndex = -1
            ProductCom(i - 1) = ""
        Next i
        GDetail.Enabled = False
    End Sub


    Private Sub OrderBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderBut.Click
        'Cbn2_TextChanged(sender, e)
        Dim tov, Bayt As Integer
        Dim Batchmeter, BayIndex As String
        Dim Index As Integer
        Try
            If Order.Text <> "" Then
                tov = Int(Order.Text)
                Cbn10.Text = Order.Text
            Else
                tov = Int(Cbn10.Text)
            End If
            Bayt = Bay.SelectedIndex
            For i = 0 To TRUCK_COMP_NUM - 1
                'If Bayt = -1 Then
                If (Int(DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (i + 1).ToString), RadTextBox).Text) <= tov) Then
                    DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).SelectedIndex = Product.SelectedIndex
                    'DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text = Product.Text
                    ProductCom(i) = TProductBindingSource.Item(TProductBindingSource.Position)("Product_code").ToString()
                    'DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).SelectedIndex = Bay.SelectedIndex

                    BayIndex = Bay.Text
                    Index = DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).FindString(BayIndex)
                    DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).SelectedIndex = Index

                    'DirectCast(Me.GroupBox10.Controls.Item("Meter" + (i + 1).ToString), RadDropDownList).SelectedIndex = Meter.SelectedIndex
                    Batchmeter = Meter.Text
                    Index = DirectCast(Me.GroupBox10.Controls.Item("meter" + (i + 1).ToString), RadDropDownList).FindString(Batchmeter)
                    DirectCast(Me.GroupBox10.Controls.Item("meter" + (i + 1).ToString), RadDropDownList).SelectedIndex = Index

                    DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i + 1).ToString), RadTextBox).Text = DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (i + 1).ToString), RadTextBox).Text
                    tov = tov - Int(DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i + 1).ToString), RadTextBox).Text)
                Else
                    DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i + 1).ToString), RadTextBox).Text = tov

                    If tov <> 0 Then
                        DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).SelectedIndex = Product.SelectedIndex
                        ProductCom(i) = TProductBindingSource.Item(TProductBindingSource.Position)("Product_code").ToString()


                        BayIndex = Bay.Text
                        Index = DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).FindString(BayIndex)
                        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).SelectedIndex = Index
                        Batchmeter = Meter.Text
                        Index = DirectCast(Me.GroupBox10.Controls.Item("meter" + (i + 1).ToString), RadDropDownList).FindString(Batchmeter)
                        DirectCast(Me.GroupBox10.Controls.Item("meter" + (i + 1).ToString), RadDropDownList).SelectedIndex = Index

                        'DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).SelectedIndex = Bay.SelectedIndex
                        'DirectCast(Me.GroupBox10.Controls.Item("Meter" + (i + 1).ToString), RadDropDownList).SelectedIndex = Meter.SelectedIndex
                    Else
                        DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).SelectedIndex = -1 'Product.SelectedIndex
                        ProductCom(i) = ""
                        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).SelectedIndex = -1 'Bay.SelectedIndex
                        DirectCast(Me.GroupBox10.Controls.Item("Meter" + (i + 1).ToString), RadDropDownList).SelectedIndex = -1 'Meter.SelectedIndex
                    End If
                    tov = tov - Int(DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i + 1).ToString), RadTextBox).Text)
                End If

            Next i
        Catch ex As Exception

        End Try
    End Sub

    Private Function Item(ByVal p1 As String) As Object
        Throw New NotImplementedException
    End Function

    Private Sub RadButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton2.Click
        '        If ProductList1.SelectedValue.ToString <> "" Then
        If ProductList1.SelectedIndex = -1 Then
            RadTextBox2.Text = ProductList1.SelectedValue.ToString
        Else
            RadTextBox2.Text = ProductList1.SelectedIndex.ToString
        End If

    End Sub

    Private Sub Printdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Printdata.Click

        '------------------------------------------- Check Print Permission
        If cls_role.ChkDel = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to print document in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Print Permission


        Try
            Dim ref As String
            ref = MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString
            Dim Myreport As New ReportDocument
            Myreport = New ReportDocument
            Dim q As String

            q = cls_data.SelectPrintLoadingNote(ref)

            Dim ds As New DataSet
            ds = cls.Query_DS(q, "V_Loadingnote")

            Myreport.Load("Report_File/TopUpReport.rpt")
            Myreport.SetDataSource(ds)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()
            ds.Dispose()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton7.Click
        Dim sql, SealDetail, q As String
        Dim Seal_totalV As Integer
        sql = ""
        sql = "select * from T_seal"

        Dim dt As DataTable = cls.Query(sql)

        SealDetail = dt(0)("Seal_Last")
        Seal_Last = ""
        Seal_totalV = 0
        Try
            Seal_totalV = Int(Seal_Total.Text)
        Catch ex As Exception
            Seal_totalV = 0
            Seal_No.Text = ""
            Exit Sub
        End Try
        If Seal_totalV <= 0 Then
            Seal_No.Text = ""
            Exit Sub
        End If
        If TRUCK_COMP_NUM = Seal_totalV Then
            If TRUCK_COMP_NUM = 1 Then
                Seal_No.Text = "" + SealNumber2(SealDetail) + "" + (SealNumber(SealDetail) + 1).ToString
                Seal_Last = "" + SealNumber2(SealDetail) + "" + (SealNumber(SealDetail) + 1).ToString
                'RadTextBox7.Text = Seal_Last
            Else
                'SealNO = "" + SealNumber2(SealDetail) + "" + (SealNumber(SealDetail) + 1).ToString + "" + "-" + (SealNumber(SealDetail) + Seal_totalV).ToString ' + SealNumber2(SealDetail) + "" + (SealNumber(SealDetail) + Seal_totalV).ToString
                Seal_No.Text = "" + SealNumber2(SealDetail) + "" + (SealNumber(SealDetail) + 1).ToString + "" + "-" + (SealNumber(SealDetail) + TRUCK_COMP_NUM).ToString
                Seal_Last = "" + SealNumber2(SealDetail) + "" + (SealNumber(SealDetail) + TRUCK_COMP_NUM).ToString
                'RadTextBox7.Text = Seal_Last
            End If
        Else
            If Seal_totalV = 1 Then
                Seal_No.Text = "" + SealNumber2(SealDetail) + "" + (SealNumber(SealDetail) + Seal_totalV).ToString
                Seal_Last = "" + SealNumber2(SealDetail) + "" + (SealNumber(SealDetail) + 1).ToString
                'RadTextBox7.Text = Seal_Last
            Else
                Seal_No.Text = "" + SealNumber2(SealDetail) + "" + (SealNumber(SealDetail) + 1).ToString + "" + "-" + (SealNumber(SealDetail) + Seal_totalV).ToString

                'Seal_No.Text = "" + SealNumber2(SealDetail) + "" + (SealNumber(SealDetail) + 1).ToString + "" + "-" + SealNumber2(SealDetail) + "" + (SealNumber(SealDetail) + Seal_totalV).ToString
                Seal_Last = "" + SealNumber2(SealDetail) + "" + (SealNumber(SealDetail) + Seal_totalV).ToString
                'RadTextBox7.Text = Seal_Last
            End If
        End If

    End Sub

    Function SealNumber(ByVal Seal_last As String) As Integer
        Try
            Dim seal As String
            For i = 1 To Seal_last.Length
                If (Asc(GetChar(Seal_last, i)) >= 48) And (Asc(GetChar(Seal_last, i)) <= 57) Then
                    seal = seal & GetChar(Seal_last, i).ToString
                End If
            Next
            Return seal
        Catch ex As Exception

        End Try
    End Function

    Function SealNumber2(ByVal Seal_last As String) As String
        Try
            Dim seal As String
            For i = 1 To Seal_last.Length
                'If (Asc(GetChar(Seal_last, i)) <= 47) And (Asc(GetChar(Seal_last, i)) >= 58) Then
                If (Asc(GetChar(Seal_last, i)) >= 48) And (Asc(GetChar(Seal_last, i)) <= 57) Then
                    seal = seal
                Else
                    seal = seal & GetChar(Seal_last, i).ToString
                End If
            Next
            Return seal


        Catch ex As Exception

        End Try
    End Function

    Private Sub Seal_Total_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Seal_Total.KeyPress
        Try
            If IsNumeric(e.KeyChar) = False AndAlso e.KeyChar <> Chr(8) Then
                e.KeyChar = Chr(0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cbn10_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbn10.KeyPress
        If IsNumeric(e.KeyChar) = False AndAlso e.KeyChar <> Chr(8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        If Cbn11.Text = "" Then
            MessageBox.Show("Please specify DO. No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cbn11.Focus()
            Exit Sub
        End If
        If Cbn2.SelectedIndex = -1 Then
            MessageBox.Show("Please specify Truck No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cbn2.Focus()
            Exit Sub
        End If
        If EdCustomer.SelectedIndex = -1 Then
            MessageBox.Show("Please specify Customer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EdCustomer.Focus()
            Exit Sub
        End If

        If Cbn10.Text = "" Then
            MessageBox.Show("Please specify Total Preset", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cbn10.Focus()
            Exit Sub
        End If
        If Driver.SelectedIndex = -1 Then
            MessageBox.Show("Please specify Driver Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Driver.Focus()
            Exit Sub
        End If


        Dim q, sc, sql As String
        Dim i, SL, ST, r, j As Integer
        Dim s_year As String
        Dim Card As String
        Update_date.Text = Date.Now
        s_year = Date.Now.Year
        Try
            ''''   ST  '''''''''
            q = ""
            q = "select NVL(max(ST_ID),0)+1 as ST_ID"
            q &= " from T_ST"

            Dim dt1 As DataTable = cls.Query(q)

            ST = dt1(0)("ST_ID")

            '''''' SC '''''''''''
            q = ""
            q = "select count(load_id) as CLoad_id "
            q &= "from T_loadingnote "
            q &= "where to_char(load_date,'DD') = to_char(Getdate(),'DD') "
            q &= "AND  to_char(load_date,'MM') = to_char(Getdate(),'MM') "
            q &= "AND  to_char(load_date,'YY') = to_char(Getdate(),'YY') "
            q &= "AND (ST_ID NOT IN (SELECT st_id FROM t_st))  "

            dt1 = cls.Query(q)
            SL = dt1(0)("CLoad_id")
            sc = ST + SL

            Dim Preset As Integer = 0
            For i = 0 To TRUCK_COMP_NUM - 1
                Try
                    If ((DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Or
                        (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text) <> "") And
                         ((DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Or
                         (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text) <> "") Then
                        Preset = Preset + Int(DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i + 1).ToString), RadTextBox).Text)
                        ProductCom(i) = DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text
                    Else
                        ProductCom(i) = ""
                    End If

                Catch ex As Exception
                End Try
            Next

            '''''''' Insert T_Loadingnote'''''''''''''''''''
            '''
            Dim strCL As String = "Insert into T_Loadingnote ("
            Dim strVL As String = " VALUES("

            strCL &= "LOAD_ID"
            strVL &= "'" & Cbn6.Text & "'"

            'Random PinCode
            Dim dt_tmp As DataTable
            Dim RandGen As New Random
            Dim strRand As Integer

            Do
                strRand = RandGen.Next(0, 10000)
                dt_tmp = cls.Query("SELECT * FROM T_LOADINGNOTE WHERE LOAD_CARD=" & strRand & " AND LOAD_DAY=" & Now.Day & " and LOAD_MONTH =" & Now.Month & " and LOAD_YEAR=" & Now.Year & "")

                If dt_tmp.Rows.Count = 0 Then
                    Exit Do
                End If
            Loop

            strCL &= ", LOAD_CARD"
            strVL &= ", '" & strRand & "'"

            Dim DID_VAL As String = ""
            If Cbn7.Text = "" Then
                Try
                    sql = ""
                    sql = "select Q_NO from T_Q "

                    Dim QueueNo As String
                    Dim dt2 As DataTable = cls.Query(sql)
                    If dt2.Rows.Count > 0 Then QueueNo = dt2(0)("Q_NO") Else QueueNo = "0"

                    DID_VAL = "'" & QueueNo & "'"
                Catch ex As Exception
                    DID_VAL = "'" & ("0") & "'"
                End Try
            Else
                Try
                    DID_VAL = "'" & Cbn7.Text & "'"
                Catch ex As Exception
                    DID_VAL = "'" & ("0") + "'" & ""
                End Try
            End If

            strCL &= ", LOAD_DID"
            strVL &= ", " & DID_VAL

            strCL &= ", LOAD_VEHICLE"
            strVL &= ", '" & (VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString()) & "'"

            strCL &= ", LOAD_STATUS"
            strVL &= ", '" & (TStatusBindingSource.Item(TStatusBindingSource.Position)("ID").ToString()) & "'"

            strCL &= ", LOAD_CAPACITY"
            strVL &= ", '" & (Cbn5.Text) & "'"

            strCL &= ", ST_ID"
            strVL &= ", '" & (Str(sc)) & "'"

            strCL &= ", LOAD_STARTTIME"
            strVL &= ", '" & (Cbn9.Text) & "'"

            strCL &= ", AddnoteDate"
            strVL &= ", Getdate()"

            strCL &= ", LOAD_DRIVER"
            strVL &= ", '" & (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) & "'"

            strCL &= ", LOAD_PRESET"
            strVL &= ", '" & Preset.ToString & "'"

            strCL &= ", LOAD_DOfull"
            strVL &= ", '" & (Cbn11.Text) & "'"

            strCL &= ", LOADDO"
            strVL &= ", '" & (Cbn11.Text) & "'"

            strCL &= ", Reference"
            strVL &= ", '" & (Cbn8.Text) & "'"

            strCL &= ", Remark"
            strVL &= ", '" & (Edremark.Text) & "'"

            strCL &= ", Container"
            strVL &= ", '" & (Container.Text) & "'"

            strCL &= ", LOAD_SEALCOUNT"
            strVL &= ", '" & (Seal_Total.Text) & "'"

            strCL &= ", Load_customer"
            strVL &= ", '" & (TCUSTOMERTBindingSource.Item(TCUSTOMERTBindingSource.Position)("ID").ToString()) & "'"

            strCL &= ", Load_seal"
            strVL &= ", '" & (Seal_No.Text) & "'"

            strCL &= ", Update_date"
            strVL &= ", Getdate()"

            strCL &= ", LOAD_Q"
            strVL &= ", '" & (Load_q.Text) & "'"

            strCL &= ", LOAD_QDASHBOARD"
            strVL &= ", '" & (Load_q.Text) & "'"

            strCL &= ", Q_TIME"
            strVL &= ", Getdate()"

            strCL &= ", CHECKIN_TIME"
            strVL &= ", Getdate()"

            strCL &= ", LOAD_TRUCKCOMPANY"
            strVL &= ", '" & (TCompanyBindingSource.Item(TCompanyBindingSource.Position)("COMPANY_ID").ToString()) & "'"

            strCL &= ", DO_TYPE"
            strVL &= ", '" & (DO_Type.Text) & "'"

            strCL &= ", UPDATE_BY"
            strVL &= ", '" & (Update_by.Text) & "'"

            strCL &= ", LOAD_AUTHORIZE"
            strVL &= ", '" & (authorize_Remark.Text) & "'"

            strCL &= ", Advisenote_type"
            strVL &= ", 'TOPUP'"

            strCL &= ", LOAD_TYPE"
            strVL &= ", '" & (TTruckTypeBindingSource.Item(TTruckTypeBindingSource.Position)("ID").ToString()) & "'"

            strCL &= ")"
            strVL &= ")"

            cls.Insert(strCL & " " & strVL)

            ''''''''' Insert T_LoadingnoteCompartment
            For r = 0 To TRUCK_COMP_NUM - 1
                Dim LC_status As String
                LC_status = (TStatusBindingSource.Item(TStatusBindingSource.Position)("ID").ToString())
                If (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) = "" Or (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) = "0" Or
                     (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedIndex) = -1 Or
                    (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (r + 1).ToString), RadDropDownList).SelectedIndex) = -1 Then
                    LC_status = "99"
                End If


                If LC_status = 99 Then


                    q = ""
                    q = "Insert into T_LOADINGNOTECOMPARTMENT "
                    q &= " (LC_LOAD,"
                    q &= " LC_COMPARTMENT,"
                    q &= " LC_STATUS,"
                    q &= " LC_BASE,"
                    q &= " LC_BLEND,"
                    q &= " LC_PRO,"
                    q &= " LC_CAPACITY,"
                    q &= " LC_PRESET,"
                    q &= " LC_BAY,"
                    q &= " LC_SEAL,"
                    q &= " LC_TANK,"
                    q &= " LC_API,"
                    q &= " LC_METER) "
                    q &= "Values ("
                    q &= "'" & Cbn6.Text & "',"
                    q &= "'" & (DirectCast(Me.GroupBox15.Controls.Item("Comp" + (r + 1).ToString), RadTextBox).Text) & "',"
                    q &= "'99',"
                    q &= "'0',"
                    q &= "'0',"
                    q &= "'0'," 'LC_pro
                    q &= "'" & (DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (r + 1).ToString), RadTextBox).Text) & "',"
                    q &= "'0',"
                    q &= "'0',"
                    q &= "'0',"
                    q &= "'0',"
                    q &= "'0',"
                    q &= "'0')" 'LC_Meter

                Else
                    q = ""
                    q = "Insert into T_LOADINGNOTECOMPARTMENT "
                    q &= " (LC_LOAD,"
                    q &= " LC_COMPARTMENT,"
                    q &= " LC_STATUS,"
                    q &= " LC_BASE,"
                    q &= " LC_BLEND,"
                    q &= " LC_PRO,"
                    q &= " LC_CAPACITY,"
                    q &= " LC_PRESET,"
                    q &= " LC_BAY,"
                    q &= " LC_SEAL,"
                    q &= " LC_TANK,"
                    q &= " LC_API,"
                    q &= " LC_METER) "
                    q &= "Values ("
                    q &= "'" & Cbn6.Text & "',"
                    '' LC_COMPARTMENT ''
                    q &= "'" & (DirectCast(Me.GroupBox15.Controls.Item("Comp" + (r + 1).ToString), RadTextBox).Text) + "',"
                    '' LC_PRO ''
                    Try
                        If DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text > 0 And ProductCom(r) <> "" And ProductCom(r) <> "" Then
                            q &= "'1',"
                        Else
                            q &= "'0',"
                        End If
                    Catch ex As Exception
                        q &= "'99',"
                    End Try
                    '' LC_BASE ''
                    If (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) <> "" Then
                        q &= "'" & (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) & "',"
                    Else
                        q &= "'0',"
                    End If

                    '' LC_BLEND''
                    q &= "'0',"
                    '' LC_PRO ''
                    If (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Then
                        q &= "'" & (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedValue.ToString) & "',"
                    Else
                        q &= "'0',"
                    End If
                    'q &= "'" + (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedValue.ToString) + "'" + ","
                    '' LC_CAPACITY ''
                    q &= "'" & (DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (r + 1).ToString), RadTextBox).Text) & "',"
                    '' LC_PRESET ''
                    If (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) <> "" Then
                        q &= "'" & (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) & "',"
                    Else
                        q &= "'0',"
                    End If
                    '' LC_BAY ''
                    If (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (r + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Then
                        q &= "'" & (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (r + 1).ToString), RadDropDownList).Text) & "',"
                    Else
                        q &= "'0',"
                    End If
                    '' LC_SEAL ''
                    q &= "'" & (Seal_No.Text) & "',"


                    '' LC_TANK '' LC_Density_30C

                    Try
                        sql = ""
                        sql = "select Tankno,TANKAPI from t_tank where Tankproduct = '" & ProductCom(r) & "' "
                        sql &= "and tank_loadactive = 1 order by updatedate desc"

                        Dim dt As DataTable = cls.Query(sql)

                        q &= "'" & dt.Rows(0).Item("Tankno").ToString & "',"
                        q &= "'" & dt.Rows(0).Item("TANKAPI").ToString & "',"
                    Catch ex As Exception
                        q = ""
                        q = "delete t_loadingnote where load_id = "
                        q &= Cbn6.Text

                        cls.Delete(q)

                        q = ""
                        q = "delete t_loadingnotecompartment where lc_load = "
                        q &= Cbn6.Text

                        cls.Delete(q)

                        MessageBox.Show("Invalid open tank '" & ProductCom(r).ToString & "' , Cannot create top up, Please check!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Cursor = Cursors.Default
                        Tank_Order.ShowDialog()
                        Exit Sub
                    End Try


                    sql = "select batch_number from t_batchmeter where Batch_name in('" & (DirectCast(Me.GroupBox10.Controls.Item("Meter" + (r + 1).ToString), RadDropDownList).Text) & "') "

                    Dim dt2 As DataTable = cls.Query(sql)

                    q &= "'" & dt2.Rows(0).Item("batch_number").ToString & "')"

                    'q &= "0" & ")"

                End If
                '' LC_METER ''
                cls.Insert(q)
            Next r

        Catch ex As Exception

            q = ""
            q = "delete t_loadingnote where load_id = "
            q &= Cbn6.Text

            cls.Delete(q)

            q = ""
            q = "delete t_loadingnotecompartment where lc_load = "
            q &= Cbn6.Text

            cls.Delete(q)

            MessageBox.Show("Cannot create top up, Please check!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
            Exit Sub
        End Try

        If AddDoc Then
            cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Create Top up advise note : " & Cbn8.Text, "T_LOADINGNOTE", "")
            EditDoc = False
            AddDoc = False
        ElseIf EditDoc Then
            cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Edit Top up advise note : " & Cbn8.Text, "T_LOADINGNOTE", "")
            EditDoc = False
            AddDoc = False
        End If

        Dim Myreport As New ReportDocument
        Myreport = New ReportDocument

        q = cls_data.SelectPrintLoadingNote(Cbn8.Text)

        Dim ds As New DataSet
        ds = cls.Query_DS(q, "V_Loadingnote")

        Myreport.Load("Report_File/TopUpReport.rpt")
        Myreport.SetDataSource(ds)
        ReportPrint.CrystalReportViewer3.ReportSource = Myreport
        ReportPrint.ShowDialog()
        ds.Dispose()
        Try
            Advisenote_Shown(sender, e)
            SelectVLoadingNote()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update.Click
        Dim q, id, sc, sql, ref As String
        Dim i, r, j As Integer

        Update_date.Text = Date.Now
        ref = MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString

        sql = ""
        sql = "select load_id from t_loadingnote where reference='" & ref & "' "

        Dim dt As DataTable = cls.Query(sql)
        Dim loadID As String
        loadID = dt(0)("load_id")

        If MsgBox("Do you want to edit load no.: ' " & ref & " ' ?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then

            Dim Preset As Integer = 0
            For i = 0 To TRUCK_COMP_NUM - 1
                Try
                    If ((DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Or
                        (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text) <> "") And
                         ((DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Or
                         (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text) <> "") Then
                        Preset = Preset + Int(DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i + 1).ToString), RadTextBox).Text)
                        ProductCom(i) = (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text)
                    Else
                        ProductCom(i) = ""
                    End If
                Catch ex As Exception
                End Try
            Next

            q = ""
            q = "UPDATE T_LOADINGNOTE "
            q &= "SET LOAD_CARD = "

            'Random PinCode
            Dim dt_tmp As DataTable
            Dim RandGen As New Random
            Dim strRand As Integer

            Do
                strRand = RandGen.Next(0, 10000)
                dt_tmp = cls.Query("SELECT * FROM T_LOADINGNOTE WHERE LOAD_CARD=" & strRand & " AND LOAD_DAY=" & Now.Day & " and LOAD_MONTH =" & Now.Month & " and LOAD_YEAR=" & Now.Year & "")

                If dt_tmp.Rows.Count = 0 Then
                    Exit Do
                End If
            Loop

            q &= "'" & strRand & "', "

            'Try
            '    'If TDriverBindingSource.Item(TDriverBindingSource.Position)("Driver_Pincode").ToString() <> "" Then
            '    'sql = ""
            '    'sql = "select Truck_ID,Card_Number from vcardload "
            '    'sql &= "where Truck_ID= '" & (VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString()) & "'"

            '    'Dim dt1 As DataTable = cls.Query(sql)
            '    'Dim Card As String
            '    'Card = dt1(0)("Card_Number")
            '    q &= "'0',"
            'Catch ex As Exception
            '    MessageBox.Show("Cannot edit this load no., Please check!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    MsgBox(ex.Message())
            '    Exit Sub
            'End Try

            q &= " LOAD_DID = "
            q &= "'" & Cbn7.Text & "',"
            q &= " LOAD_VEHICLE = "
            q &= "'" & (VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString()) & "',"
            q &= " LOAD_STATUS = "
            q &= "'" & (TStatusBindingSource.Item(TStatusBindingSource.Position)("ID").ToString()) & "',"
            q &= " LOAD_CAPACITY = "
            q &= "'" & (Cbn5.Text) & "',"
            'q &= " LOAD_Shipper = "
            'q &= "'" & (TShipperBindingSource.Item(TShipperBindingSource.Position)("ID").ToString()) & "',"
            q &= " LOAD_STARTTIME = "
            q &= "'" & (Cbn9.Text) & "',"
            q &= " AddnoteDate = "
            Dim n_year As Integer = 0
            'If Date.Now.Year > "2500" Then
            n_year = 543
            'End If

            q &= "Getdate() ,"
            'q &= "CONVERT (DATETIME,'" & (String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateAdd(DateInterval.Year, -n_year, Dateedit.Value))) + "','DD/MM/YYYY HH24:MI:SS')" + ","
            q &= " LOAD_DRIVER = "
            q &= "'" & (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) & "',"
            q &= " LOAD_PRESET = "
            q &= "'" & Preset.ToString & "',"
            q &= " LOAD_DOfull = "
            q &= "'" & (Cbn11.Text) & "',"
            q &= " LOADDO = "
            q &= "'" & (Cbn11.Text) & "',"
            q &= " Reference = "
            q &= "'" & (Cbn8.Text) & "',"
            q &= " Remark = "
            q &= "'" & (Edremark.Text) & "',"
            q &= " Container = "
            q &= "'" & (Container.Text) & "',"
            q &= " LOAD_SEALCOUNT = "
            q &= "'" & (Seal_Total.Text) & "',"
            q &= " Load_customer = "
            q &= "'" & (TCUSTOMERTBindingSource.Item(TCUSTOMERTBindingSource.Position)("ID").ToString()) & "',"
            q &= " Load_seal = "
            q &= "'" & (Seal_No.Text) & "',"
            q &= " Update_date = "
            q &= " Getdate(), "
            q &= " LOAD_Q = "
            q &= "'" & (Load_q.Text) & "',"
            q &= " LOAD_QDASHBOARD = "
            q &= "'" & (Load_q.Text) & "',"
            'LOAD_QDASHBOARD
            q &= " LOAD_TYPE = "
            q &= "'" & (TTruckTypeBindingSource.Item(TTruckTypeBindingSource.Position)("ID").ToString()) & "',"
            q &= " DO_TYPE = "
            q &= "'" & (DO_Type.Text) & "',"
            q &= " UPDATE_BY = "
            q &= "'" & (Update_by.Text) & "',"
            q &= " LOAD_AUTHORIZE = "
            q &= "'" & (authorize_Remark.Text) & "',"

            q &= " LOAD_TRUCKCOMPANY = "
            q &= "'" & (TCompanyBindingSource.Item(TCompanyBindingSource.Position)("COMPANY_ID").ToString()) & "' "
            q &= "WHERE reference= "
            q &= "" + ref + "  "

            cls.Update(q)



            ''''''''' Insert T_LoadingnoteCompartment
            Try
                q = ""
                q = "select LC_Status,lc_bay "
                q &= " From V_Loadingnotecompartment "
                q &= " Where LC_LOAD = "
                q &= "" + Cbn6.Text + ""
                q &= " order by LC_Compartment"

                Dim dt1 As DataTable = cls.Query(q)

                For r = 0 To TRUCK_COMP_NUM - 1

                    Dim LC_status As String
                    LC_status = (TStatusBindingSource.Item(TStatusBindingSource.Position)("ID").ToString())
                    If (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) = "" Or (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) = "0" Or
                         (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedIndex) = -1 Or
                        (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (r + 1).ToString), RadDropDownList).SelectedIndex) = -1 Then
                        LC_status = "99"
                    End If

                    If LC_status = 99 Then
                        q = ""
                        q = "Update T_LOADINGNOTECOMPARTMENT Set "
                        q &= " LC_STATUS="
                        q &= "'" & LC_status & "',"
                        q &= " LC_BASE='0',"
                        q &= " LC_BLEND='0',"
                        q &= " LC_PRO='0',"
                        q &= " LC_CAPACITY='" & (DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (r + 1).ToString), RadTextBox).Text) & "',"
                        q &= " LC_PRESET='0',"
                        q &= " LC_BAY='0',"
                        q &= " LC_SEAL='0',"
                        q &= " LC_TANK='0',"
                        q &= " LC_API='0' "
                        'q &= " LC_METER='0' "
                        q &= "Where lc_load="
                        q &= "'" & Cbn6.Text & "'"
                        q &= " and lc_compartment = "
                        q &= "'" & (DirectCast(Me.GroupBox15.Controls.Item("Comp" + (r + 1).ToString), RadTextBox).Text) & "'"
                    Else
                        q = ""
                        q = "Update T_LOADINGNOTECOMPARTMENT Set "
                        q &= " LC_COMPARTMENT="
                        q &= "'" & (DirectCast(Me.GroupBox15.Controls.Item("Comp" + (r + 1).ToString), RadTextBox).Text) & "',"


                        If ((dt1.Rows(r).Item("LC_Status").ToString = "1") Or (dt1.Rows(r).Item("LC_Status").ToString = "99")) Then
                            q &= " LC_STATUS='1' ,"
                        End If

                        q &= " LC_BASE="
                        '' LC_BASE ''
                        If (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) <> "" Then
                            q &= "'" & (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) & "',"
                        Else
                            q &= "0" + ","
                        End If
                        q &= " LC_BLEND="
                        '' LC_BLEND''
                        q &= "0" + ","

                        q &= " LC_PRO="
                        '' LC_PRO ''
                        If (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Then
                            q &= "'" & (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedValue.ToString) & "',"
                        Else
                            q &= "0" & ","
                        End If
                        q &= " LC_CAPACITY="
                        '' LC_CAPACITY ''
                        q &= "'" & (DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (r + 1).ToString), RadTextBox).Text) & "',"
                        q &= " LC_PRESET="
                        '' LC_PRESET ''
                        If (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) <> "" Then
                            q &= "'" & (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) & "',"
                        Else
                            q &= "0" & ","
                        End If
                        'q &= " LC_ISLAND,"
                        q &= " LC_BAY="
                        '' LC_BAY ''
                        If (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (r + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Then
                            q &= "'" & (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (r + 1).ToString), RadDropDownList).Text) & "',"
                        Else
                            q &= "0" & ","
                        End If
                        q &= " LC_SEAL="
                        '' LC_SEAL ''
                        q &= "'" & (Seal_No.Text) & "',"
                        q &= " LC_TANK="
                        '' LC_TANK ''
                        sql = ""
                        sql = "select tankno,TANKAPI from t_tank where Tankproduct = '" & ProductCom(r) & "' "
                        sql &= "and tank_loadactive = '1' order by updatedate desc"

                        Dim dt5 As DataTable = cls.Query(sql)

                        Dim TankRef, Density As String

                        Try
                            TankRef = dt5(0)("tankno")
                            q &= "'" & TankRef & "',"
                        Catch ex As Exception
                            q &= "''" & ","
                        End Try

                        Try

                            sql = "select batch_number from t_batchmeter where Batch_name in('" & (DirectCast(Me.GroupBox10.Controls.Item("Meter" + (r + 1).ToString), RadDropDownList).Text) & "') "

                            Dim dt2 As DataTable = cls.Query(sql)

                            q &= " LC_METER='" & dt2.Rows(0).Item("batch_number").ToString & "',"

                        Catch ex As Exception
                            q &= " LC_METER='0' ,"
                        End Try


                        q &= " LC_API="
                        Try
                            Density = dt5(0)("TANKAPI")
                            q &= "'" & Density & "'"
                        Catch ex As Exception
                            q &= "'' "
                        End Try


                        q &= "Where lc_load="
                        q &= "'" & Cbn6.Text & "'"
                        q &= " and lc_compartment = "
                        q &= "'" & (DirectCast(Me.GroupBox15.Controls.Item("Comp" + (r + 1).ToString), RadTextBox).Text) & "' "
                        q &= " and lc_status in(1,99) "
                        'If (TStatusBindingSource.Item(TStatusBindingSource.Position)("ID").ToString() = 1) Or (TStatusBindingSource.Item(TStatusBindingSource.Position)("ID").ToString() = 2) Then
                        '    Dim in_status As String
                        '    in_status = "1"
                        '    If ((DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) <> "" Or (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) <> "0") And
                        '        (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedIndex) <> -1 And
                        '        (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (r + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Then

                        '        in_status = "1,99"
                        '    End If
                        '    q &= " and lc_status in(" & in_status & ") "
                        'Else
                        '    q &= " and lc_status in(1,2) "

                        'End If

                    End If

                    cls.Update(q)
                Next r

            Catch ex As Exception

            End Try

            Advisenote_Shown(sender, e)
            SelectVLoadingNote()
        End If

    End Sub

    Sub Refresh()
        Try
            Me.T_STATUSTableAdapter.Fill(Me.DataSet_Table.T_STATUS)
            Me.T_TRUCKTYPETableAdapter.Fill(Me.DataSet_Table.T_TRUCKTYPE)
            Me.T_BATCHMETERTableAdapter.Fill(Me.DataSet_Table.T_BATCHMETER)
            Me.V_TRUCKTableAdapter.Fill(Me.DataSet_View.V_TRUCK)
            Me.T_BAYTableAdapter.Fill(Me.DataSet_Table.T_BAY)
            Me.T_PRODUCTTableAdapter1.Fill(Me.DataSet_Table.T_PRODUCT)
            Me.T_SHIPPERTableAdapter.Fill(Me.DataSet_Table.T_SHIPPER)
            Me.T_COMPANYTableAdapter.Fill(Me.DataSet_Table.T_COMPANY)
            Me.T_CUSTOMERTableAdapter.Fill(Me.DataSet_Table.T_CUSTOMER)
            Me.T_DRIVERTableAdapter.Fill(Me.DataSet_Table.T_DRIVER)
            CompClear()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Canceldata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Canceldata.Click, ToolStripButton8.Click


        '------------------------------------------- Check Delete Permission
        If cls_role.ChkDel = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to delete document in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Delete Permission


        Dim sql, ref, LC_ID, load_do, load_status As String

        ref = MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString
        sql = ""
        sql = "select Load_id,load_dofull,load_status from T_Loadingnote where reference = "
        sql &= ref

        Dim dt As DataTable = cls.Query(sql)

        LC_ID = dt(0)("Load_id")
        load_do = dt(0)("load_dofull")
        load_status = dt(0)("load_status")
        If load_status = 3 Then
            MsgBox("This truck load complete, Cannot delete", vbOKOnly + vbDefaultButton2, "Error")
            Exit Sub
        Else

            If MsgBox("Do you want to delete load no.: " + ref + " ?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then
                Try
                    sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
                          & ",USERGROUP='" & MAIN.U_GROUP & "'"

                    cls.Update(sql)
                Catch ex As Exception
                End Try


                sql = ""
                sql = "delete   T_Loadingnote where reference =" + ref + ""

                cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Delete Top up advise note : " & ref, "T_LOADINGNOTE", "")

                cls.Delete(sql)

                sql = ""
                sql = "delete t_loadingnotecompartment where lc_load =" + LC_ID + ""

                cls.Delete(sql)

                RadPageView1.SelectedPage = RadPageViewPage1

                sql = ""
                sql = "delete   T_DO where load_id =" + LC_ID + ""

                cls.Delete(sql)

                sql = ""
                sql = "delete   T_Shipment where Sapload_id =" + ref + ""

                cls.Delete(sql)

                sql = ""
                sql = "Update   T_Checkin set status=3 where load_id =" + LC_ID + ""

                cls.Update(sql)

                SelectVLoadingNote()
            End If
        End If

    End Sub

    Public Sub FindFromLoadingNote()
        Dim ref, q As String
        Dim dt As DataTable

        ref = FindRef

        Refresh()
        q &= ""
        q &= "Select NVL(T_LOADINGNOTE.load_did,0) as Load_did ,"
        q &= "NVL(T_LOADINGNOTE.LOAD_Shipper,0) as load_shipper ,"
        q &= "NVL(T_LOADINGNOTE.LOAD_delivery,0) as load_delivery ,"
        q &= "NVL(T_TRUCK.TRUCK_NUMBER,0) as load_vehicle ,"
        q &= "NVL(T_LOADINGNOTE.LOAD_vehicle,0) as load_vehicle_ID ,"
        q &= "NVL(T_LOADINGNOTE.LOAD_capacity,0) as load_capacity ,"
        q &= "Trim(NVL(T_LOADINGNOTE.LOAD_driver,0)) as load_driver ,"
        q &= "NVL(T_LOADINGNOTE.LOAD_preset,0) as load_preset ,"
        q &= "NVL(T_LOADINGNOTE.LOAD_SEAL,0) as LOAD_SEAL ,"
        q &= "NVL(T_LOADINGNOTE.LOAD_card,0) as load_card ,"
        q &= "T_LOADINGNOTE.AddnoteDate as AddnoteDate,"
        q &= "NVL(T_LOADINGNOTE.Reference,0) as Reference ,"
        q &= "NVL(T_LOADINGNOTE.LOAD_id,0) as load_id ,"
        q &= "NVL(T_LOADINGNOTE.LOAD_Sealcount,0) as load_Sealcount ,"
        q &= "T_LOADINGNOTE.Container AS Container ,"
        q &= "NVL(T_LOADINGNOTE.Remark,'') as Remark ,"
        q &= "NVL(T_Customer.Customer_name ,0) as Customer_name ,"   'T_Customer.Customer_name
        q &= "NVL(T_DRIVER.Driver_Name ,0) as Driver_Name ,"   'T_DRIVER.Driver
        q &= "NVL(T_STATUS.status_name,0) as status_Name ,"   'T_STATUS.status_name
        q &= "NVL(T_COMPANY.COMPANY_CODE ,0) as LOAD_TRUCKCOMPANY ,"  'T_COMPANY.COMPANY_CODE
        q &= "NVL(T_LOADINGNOTE.LOAD_status,0) as Load_status ,"
        q &= "T_LOADINGNOTE.Update_date as Update_date ,"
        q &= "T_LOADINGNOTE.UPDATE_BY as Update_by ,"
        q &= "NVL(T_LOADINGNOTE.LOAD_DOfull,0) as LOAD_DOfull ,"
        q &= "NVL(T_LOADINGNOTE.LOAD_TYPE,-1) as LOAD_TYPE ,"
        q &= "NVL(T_LOADINGNOTE.LOAD_Q ,0) as LOAD_Q ,"
        q &= "NVL(T_Loadingnote.load_Driver ,0) as Driver_ID ,"
        q &= "NVL(T_LOADINGNOTE.DO_TYPE,'0') as DO_TYPE ,"
        q &= "T_LOADINGNOTE.LOAD_AUTHORIZE  AS LOAD_AUTHORIZE "
        'q &= "T_LOADINGNOTE.remark  AS REmark "

        q &= "FROM "
        q &= "(Select * from T_LOADINGNOTE where Reference = '" & ref & "' and load_Status in(1,2,3,4,5) and load_status <> 99) T_Loadingnote "
        q &= "LEFT OUTER JOIN  T_STATUS ON T_LOADINGNOTE.LOAD_STATUS = T_STATUS.STATUS_ID "
        q &= "Left OUTER JOIN  V_DO ON T_LOADINGNOTE.LOAD_ID = V_DO.LOAD_ID "
        q &= "Left OUTER JOIN T_Customer  ON T_Customer.ID = T_LOADINGNOTE.LOAD_CUSTOMER "
        q &= "LEFT OUTER JOIN  T_COMPANY ON T_LOADINGNOTE.LOAD_TRUCKCOMPANY = T_COMPANY.COMPANY_ID  "
        q &= "LEFT OUTER JOIN  T_TRUCK ON T_LOADINGNOTE.LOAD_VEHICLE = T_TRUCK.ID "
        q &= "LEFT OUTER JOIN T_DRIVER ON T_LOADINGNOTE.LOAD_DRIVER = T_DRIVER.ID  "
        q &= "ORDER BY T_LOADINGNOTE.LOAD_ID DESC  "

        dt = cls.Query(q)

        Try
            'Cbn6.Text = dt.Rows(0).Item("load_ID").ToString
            Cbn11.Text = dt.Rows(0).Item("load_DOfull").ToString
            'Cbn10.Text = dt.Rows(0).Item("load_Preset").ToString
            'Cbn8.Text = dt.Rows(0).Item("Reference").ToString
            Container.Text = dt.Rows(0).Item("Container").ToString
            'Seal_Total.Text = dt.Rows(0).Item("Load_sealcount").ToString
            DO_Type.Text = dt.Rows(0).Item("DO_Type").ToString
            'Update_by.Text = dt.Rows(0).Item("Update_by").ToString
            'Seal_Total.Text = dt.Rows(0).Item("Load_sealcount").ToString
            Seal_No.Text = dt.Rows(0).Item("Load_seal").ToString


            Cbn5.Text = dt.Rows(0).Item("load_Capacity").ToString
            'Cbn7.Text = dt.Rows(0).Item("Load_did").ToString
            'Load_q.Text = dt.Rows(0).Item("Load_Q").ToString
            'Truck.Text = dt.Rows(0).Item("load_vehicle_ID")
            'authorize_Remark.Text = dt.Rows(0).Item("load_Authorize").ToString

            'Dateedit.Value = dt.Rows(0).Item("AddnoteDate").ToString

            If dt.Rows(0).Item("load_vehicle").ToString <> "" And dt.Rows(0).Item("load_vehicle").ToString <> "0" Then
                Cbn2.Text = dt.Rows(0).Item("load_vehicle").ToString
                VTruckBindingSource.Position = VTruckBindingSource.Find("Truck_number", dt.Rows(0).Item("load_vehicle").ToString)
            End If

            TDriverBindingSource.Position = TDriverBindingSource.Find("DRIVER_NAME", dt.Rows(0).Item("Driver_Name").ToString)

            'TShipperBindingSource.Position = TShipperBindingSource.Find("ID", dt.Rows(0).Item("LOAD_Shipper").ToString)
            TCUSTOMERTBindingSource.Position = TCUSTOMERTBindingSource.Find("Customer_name", dt.Rows(0).Item("Customer_name").ToString)
            TTruckTypeBindingSource.Position = TTruckTypeBindingSource.Find("ID", dt.Rows(0).Item("Load_type").ToString)
            TStatusBindingSource.Position = TStatusBindingSource.Find("Status_ID", "1")
            TCompanyBindingSource.Position = TCompanyBindingSource.Find("Company_Code", dt.Rows(0).Item("LOAD_TRUCKCOMPANY").ToString)

            EdCustomer.Text = TCUSTOMERTBindingSource.Item(TCUSTOMERTBindingSource.Position)("CUSTOMER_CODE").ToString
            Cbn3.Text = TCompanyBindingSource.Item(TCompanyBindingSource.Position)("COMPANY_CODE").ToString
            Trucktype.Text = TTruckTypeBindingSource.Item(TTruckTypeBindingSource.Position)("TYPE").ToString
            Driver.Text = TDriverBindingSource.Item(TDriverBindingSource.Position)("DRIVER_NAME").ToString
            Status.Text = TStatusBindingSource.Item(TStatusBindingSource.Position)("STATUS_NAME").ToString

        Catch ex As Exception

        End Try

        Cbn2_Leave(Nothing, Nothing)

        Seal_No_Leave(Nothing, Nothing)
    End Sub

    Private Sub Editdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Editdata.Click


        '------------------------------------------- Check Edit Permission
        If cls_role.ChkEdit = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to edit document in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '------------------------------------------- Check Edit Permission

        ClearData()
        bt_FindLN.Enabled = False

        Cbn2.Enabled = False
        EditType = 1
        CanExit = 1
        Status.Enabled = True

        Dim q, sql, ref, load_status As String
        Dim truck As Integer
        Try
            ref = MasterGridAdvisenote.CurrentRow.Cells("REFERENCE").Value.ToString
        Catch ex As Exception
            Exit Sub
        End Try

        sql = ""
        sql = "select load_status from T_Loadingnote where reference = "
        sql &= ref

        Dim dt As DataTable = cls.Query(sql)

        load_status = dt(0)("load_status")
        If load_status = 3 Then
            MsgBox("This truck load complete, Cannot edit", vbOKOnly + vbDefaultButton3, "Error")
            Exit Sub
        Else
            Try
                Dim sqluser As String
                sqluser = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
                  & ",USERGROUP='" & MAIN.U_GROUP & "'"

                cls.Update(sqluser)
            Catch ex As Exception
            End Try

            sealEdit = 1
            'Bcancel_Click(sender, e)
            Refresh()
            q &= ""
            q &= "Select NVL(T_LOADINGNOTE.load_did,0) as Load_did ,"
            q &= "NVL(T_LOADINGNOTE.LOAD_Shipper,0) as load_shipper ,"
            q &= "NVL(T_LOADINGNOTE.LOAD_delivery,0) as load_delivery ,"
            q &= "NVL(T_TRUCK.TRUCK_NUMBER,0) as load_vehicle ,"
            q &= "NVL(T_LOADINGNOTE.LOAD_vehicle,0) as load_vehicle_ID ,"
            q &= "NVL(T_LOADINGNOTE.LOAD_capacity,0) as load_capacity ,"
            q &= "Trim(NVL(T_LOADINGNOTE.LOAD_driver,0)) as load_driver ,"
            q &= "NVL(T_LOADINGNOTE.LOAD_preset,0) as load_preset ,"
            q &= "NVL(T_LOADINGNOTE.LOAD_SEAL,0) as LOAD_SEAL ,"
            q &= "NVL(T_LOADINGNOTE.LOAD_card,0) as load_card ,"
            q &= "T_LOADINGNOTE.AddnoteDate as AddnoteDate,"
            q &= "NVL(T_LOADINGNOTE.Reference,0) as Reference ,"
            q &= "NVL(T_LOADINGNOTE.LOAD_id,0) as load_id ,"
            q &= "NVL(T_LOADINGNOTE.LOAD_Sealcount,0) as load_Sealcount ,"
            q &= "T_LOADINGNOTE.Container AS Container ,"
            q &= "NVL(T_LOADINGNOTE.Remark, '') as Remark ,"
            q &= "NVL(T_Customer.Customer_name ,0) as Customer_name ,"   'T_Customer.Customer_name
            q &= "NVL(T_DRIVER.Driver_Name ,0) as Driver_Name ,"   'T_DRIVER.Driver
            q &= "NVL(T_STATUS.status_name,0) as status_Name ,"   'T_STATUS.status_name
            q &= "NVL(T_COMPANY.COMPANY_CODE ,0) as LOAD_TRUCKCOMPANY ,"  'T_COMPANY.COMPANY_CODE
            q &= "NVL(T_LOADINGNOTE.LOAD_status,0) as Load_status ,"
            q &= "T_LOADINGNOTE.Update_date as Update_date ,"
            q &= "T_LOADINGNOTE.UPDATE_BY as Update_by ,"
            q &= "NVL(T_LOADINGNOTE.LOAD_DOfull,0) as LOAD_DOfull ,"
            q &= "NVL(T_LOADINGNOTE.LOAD_TYPE,-1) as LOAD_TYPE ,"
            q &= "NVL(T_LOADINGNOTE.LOAD_Q ,0) as LOAD_Q ,"
            q &= "NVL(T_Loadingnote.load_Driver ,0) as Driver_ID ,"
            q &= "NVL(T_LOADINGNOTE.DO_TYPE,'0') as DO_TYPE ,"
            q &= "T_LOADINGNOTE.LOAD_AUTHORIZE  AS LOAD_AUTHORIZE, "
            q &= "T_LOADINGNOTE.remark  AS REmark "

            q &= "FROM "
            q &= "(Select * from T_LOADINGNOTE where Reference = '" & ref & "' and load_Status in(1,2,3,4,5) and load_status <> 99) T_Loadingnote "
            q &= "LEFT OUTER JOIN  T_STATUS ON T_LOADINGNOTE.LOAD_STATUS = T_STATUS.STATUS_ID "
            q &= "Left OUTER JOIN  V_DO ON T_LOADINGNOTE.LOAD_ID = V_DO.LOAD_ID "
            q &= "Left OUTER JOIN T_Customer  ON T_Customer.ID = T_LOADINGNOTE.LOAD_CUSTOMER "
            q &= "LEFT OUTER JOIN  T_COMPANY ON T_LOADINGNOTE.LOAD_TRUCKCOMPANY = T_COMPANY.COMPANY_ID  "
            q &= "LEFT OUTER JOIN  T_TRUCK ON T_LOADINGNOTE.LOAD_VEHICLE = T_TRUCK.ID "
            q &= "LEFT OUTER JOIN T_DRIVER ON T_LOADINGNOTE.LOAD_DRIVER = T_DRIVER.ID  "
            q &= "ORDER BY T_LOADINGNOTE.LOAD_ID DESC  "


            dt = cls.Query(q)


            Try
                Cbn6.Text = dt.Rows(0).Item("load_ID").ToString
                Cbn11.Text = dt.Rows(0).Item("load_DOfull").ToString
                Cbn10.Text = dt.Rows(0).Item("load_Preset").ToString
                Cbn8.Text = dt.Rows(0).Item("Reference").ToString
                Container.Text = dt.Rows(0).Item("Container").ToString
                Seal_Total.Text = dt.Rows(0).Item("Load_sealcount").ToString
                DO_Type.Text = dt.Rows(0).Item("DO_Type").ToString
                Update_by.Text = dt.Rows(0).Item("Update_by").ToString
                'RadButton7_Click(sender, e)
                Seal_Total.Text = dt.Rows(0).Item("Load_sealcount").ToString
                Seal_No.Text = dt.Rows(0).Item("Load_seal").ToString
                Cbn5.Text = dt.Rows(0).Item("load_Capacity").ToString
                Cbn7.Text = dt.Rows(0).Item("Load_did").ToString
                Load_q.Text = dt.Rows(0).Item("Load_Q").ToString
                truck = dt.Rows(0).Item("load_vehicle_ID")
                authorize_Remark.Text = dt.Rows(0).Item("load_Authorize").ToString


                Dateedit.Value = dt.Rows(0).Item("AddnoteDate").ToString

                If dt.Rows(0).Item("load_vehicle").ToString <> "" And dt.Rows(0).Item("load_vehicle").ToString <> "0" Then
                    Cbn2.Text = dt.Rows(0).Item("load_vehicle").ToString
                    VTruckBindingSource.Position = VTruckBindingSource.Find("Truck_number", dt.Rows(0).Item("load_vehicle").ToString)
                End If

                TDriverBindingSource.Position = TDriverBindingSource.Find("DRIVER_NAME", dt.Rows(0).Item("Driver_Name").ToString)

                TShipperBindingSource.Position = TShipperBindingSource.Find("ID", dt.Rows(0).Item("LOAD_Shipper").ToString)
                TCUSTOMERTBindingSource.Position = TCUSTOMERTBindingSource.Find("Customer_name", dt.Rows(0).Item("Customer_name").ToString)
                TTruckTypeBindingSource.Position = TTruckTypeBindingSource.Find("ID", dt.Rows(0).Item("Load_type").ToString)
                TStatusBindingSource.Position = TStatusBindingSource.Find("Status_ID", dt.Rows(0).Item("load_status").ToString)
                TCompanyBindingSource.Position = TCompanyBindingSource.Find("Company_Code", dt.Rows(0).Item("LOAD_TRUCKCOMPANY").ToString)

                EdCustomer.Text = TCUSTOMERTBindingSource.Item(TCUSTOMERTBindingSource.Position)("CUSTOMER_CODE").ToString
                Cbn3.Text = TCompanyBindingSource.Item(TCompanyBindingSource.Position)("COMPANY_CODE").ToString
                Trucktype.Text = TTruckTypeBindingSource.Item(TTruckTypeBindingSource.Position)("TYPE").ToString

                Driver.Text = TDriverBindingSource.Item(TDriverBindingSource.Position)("DRIVER_NAME").ToString
                Try
                    Dim ArrPic() As Byte = TDriverBindingSource.Item(TDriverBindingSource.Position)("DRIVER_PICTURE")
                    Dim Ms As MemoryStream = New MemoryStream(ArrPic)
                    PictureBox1.Image = Image.FromStream(Ms)
                    Ms.Dispose()


                Catch ex As Exception
                    PictureBox1.Image = Nothing
                End Try

                Status.Text = TStatusBindingSource.Item(TStatusBindingSource.Position)("STATUS_NAME").ToString

                Edremark.Text = dt.Rows(0).Item("REMARK").ToString
            Catch ex As Exception

            End Try

            Try
                q = ""
                q = "select * "
                q &= " From V_Loadingnotecompartment "
                q &= " Where LC_LOAD = "
                q &= "" + Cbn6.Text + ""
                q &= " order by LC_Compartment"
                'q &= "" + ref + ""  

                Dim dt1 As DataTable = cls.Query(q)

                Cbn2_Leave(sender, e)
                Dim product, Meter, Bay As String
                Dim index As Integer
                For i = 0 To dt1.Rows.Count - 1
                    If (dt1.Rows(i).Item("Product_code").ToString) <> "" Then
                        product = ""
                        product = (dt1.Rows(i).Item("Product_code").ToString)
                        index = DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).FindString(product)
                        DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).SelectedIndex = index
                    End If
                    If (dt1.Rows(i).Item("LC_Meter").ToString) <> "0" Then
                        Meter = ""
                        Meter = (dt1.Rows(i).Item("Batch_name").ToString)
                        index = DirectCast(Me.GroupBox10.Controls.Item("meter" + (i + 1).ToString), RadDropDownList).FindString(Meter)
                        DirectCast(Me.GroupBox10.Controls.Item("meter" + (i + 1).ToString), RadDropDownList).SelectedIndex = index

                    Else
                        DirectCast(Me.GroupBox10.Controls.Item("meter" + (i + 1).ToString), RadDropDownList).SelectedIndex = -1
                    End If

                    If (dt1.Rows(i).Item("LC_Bay").ToString) <> "0" Then
                        Bay = ""
                        Bay = (dt1.Rows(i).Item("LC_BAY").ToString)
                        index = DirectCast(Me.GroupBox11.Controls.Item("Islandbay" + (i + 1).ToString), RadDropDownList).FindString(Bay)
                        DirectCast(Me.GroupBox11.Controls.Item("Islandbay" + (i + 1).ToString), RadDropDownList).SelectedIndex = index

                    Else
                        DirectCast(Me.GroupBox11.Controls.Item("Islandbay" + (i + 1).ToString), RadDropDownList).SelectedIndex = -1
                    End If
                    DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i + 1).ToString), RadTextBox).Text = (dt1.Rows(i).Item("LC_PRESET").ToString)
                Next i

            Catch ex As Exception

            End Try

            EditDoc = True
            AddDoc = False

            sealEdit = 0
            RadPageView1.SelectedPage = RadPageViewPage2
            Bsave.Visible = False
            Update.Visible = True

        End If
    End Sub

    Private Sub Seal_Total_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Seal_Total.Leave
        If sealEdit = 0 Then
            'RadButton7_Click(sender, e)
        End If

    End Sub

    Private Sub Seal_Total_TextChange(ByVal sender As Object, ByVal Empty As EventArgs)
        Throw New NotImplementedException
    End Sub

    Private Sub RadButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.AddOwnedForm(AdvisenoteShip)
        'AdvisenoteShip.ShowDialog()

    End Sub

    Private Sub EditSeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ref, sql, Seal As String
            ref = MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString
            sql = ""
            sql = "Select load_id,reference from T_Loadingnote where reference =" + ref + ""

            Dim ds As New DataSet
            ds = cls.Query_DS(sql, "T_Loadingnote")

            Me.AddOwnedForm(EditSeal)
            EditSeal.ShowDialog()
            SelectVLoadingNote()
            ds.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub EdCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EdCustomer.Click
    '    EdCustomer.MultiColumnComboBoxElement.ShowPopup()
    'End Sub

    'Private Sub Cbn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbn3.Click
    '    Cbn3.MultiColumnComboBoxElement.ShowPopup()
    'End Sub



    'Private Sub Driver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Driver.Click
    '    Driver.MultiColumnComboBoxElement.ShowPopup()
    'End Sub

    Private Sub MasterGridAdvisenote_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles MasterGridAdvisenote.CellFormatting
        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
    End Sub

    'Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SelectVLoadingNote()
    'End Sub

    'Private Sub Product_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Product.Click
    '    Product.MultiColumnComboBoxElement.ShowPopup()
    'End Sub

    'Private Sub Bay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bay.Click
    '    Try
    '        Bay.MultiColumnComboBoxElement.ShowPopup()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub Meter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Meter.Click
    '    Meter.MultiColumnComboBoxElement.ShowPopup()
    'End Sub

    Private Sub Product_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Product.Leave
        Try
            Dim ProductID As String = ""
            Dim sql As String
            Dim ProductCount As Integer = 0
            TBayBindingSource.DataSource = Nothing
            TBayBindingSource.DataMember = Nothing

            Dim Product_ID As Integer = 0
            Product_ID = TProductBindingSource.Item(TProductBindingSource.Position)("ID").ToString()

            'sql = ""
            'sql = "select bay_number,bay_status  from t_bay where bay_status=1 and  bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            'sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            'sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            'sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            'sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            'sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            'sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            'sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            'sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            'sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') Order by bay_number"

            sql = "SELECT * FROM T_BAY WHERE BAY_STATUS=1"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "T_bay")

            TBayBindingSource.DataSource = MyDataSet
            TBayBindingSource.DataMember = "T_bay"


            TBAYBindingSource1.DataSource = Nothing
            TBAYBindingSource1.DataMember = Nothing
            TBAYBindingSource1.DataSource = MyDataSet
            TBAYBindingSource1.DataMember = "T_bay"
            IslandBay1.DisplayMember = "Bay_number"
            IslandBay1.SelectedIndex = -1

            TBAYBindingSource2.DataSource = Nothing
            TBAYBindingSource2.DataMember = Nothing
            TBAYBindingSource2.DataSource = MyDataSet
            TBAYBindingSource2.DataMember = "T_bay"
            IslandBay2.DisplayMember = "Bay_number"
            IslandBay2.SelectedIndex = -1

            TBAYBindingSource3.DataSource = Nothing
            TBAYBindingSource3.DataMember = Nothing
            TBAYBindingSource3.DataSource = MyDataSet
            TBAYBindingSource3.DataMember = "T_bay"
            IslandBay3.DisplayMember = "Bay_number"
            IslandBay3.SelectedIndex = -1

            TBayBindingSource4.DataSource = Nothing
            TBayBindingSource4.DataMember = Nothing
            TBayBindingSource4.DataSource = MyDataSet
            TBayBindingSource4.DataMember = "T_bay"
            IslandBay4.DisplayMember = "Bay_number"
            IslandBay4.SelectedIndex = -1


            TBayBindingSource5.DataSource = Nothing
            TBayBindingSource5.DataMember = Nothing
            TBayBindingSource5.DataSource = MyDataSet
            TBayBindingSource5.DataMember = "T_bay"
            IslandBay5.DisplayMember = "Bay_number"
            IslandBay5.SelectedIndex = -1

            TBayBindingSource6.DataSource = Nothing
            TBayBindingSource6.DataMember = Nothing
            TBayBindingSource6.DataSource = MyDataSet
            TBayBindingSource6.DataMember = "T_bay"
            IslandBay6.DisplayMember = "Bay_number"
            IslandBay6.SelectedIndex = -1

            TBayBindingSource7.DataSource = Nothing
            TBayBindingSource7.DataMember = Nothing
            TBayBindingSource7.DataSource = MyDataSet
            TBayBindingSource7.DataMember = "T_bay"
            IslandBay7.DisplayMember = "Bay_number"
            IslandBay7.SelectedIndex = -1

            TBayBindingSource8.DataSource = Nothing
            TBayBindingSource8.DataMember = Nothing
            TBayBindingSource8.DataSource = MyDataSet
            TBayBindingSource8.DataMember = "T_bay"
            IslandBay8.DisplayMember = "Bay_number"
            IslandBay8.SelectedIndex = -1

            TBayBindingSource9.DataSource = Nothing
            TBayBindingSource9.DataMember = Nothing
            TBayBindingSource9.DataSource = MyDataSet
            TBayBindingSource9.DataMember = "T_bay"
            IslandBay9.DisplayMember = "Bay_number"
            IslandBay9.SelectedIndex = -1

            TBayBindingSource10.DataSource = Nothing
            TBayBindingSource10.DataMember = Nothing
            TBayBindingSource10.DataSource = MyDataSet
            TBayBindingSource10.DataMember = "T_bay"
            IslandBay10.DisplayMember = "Bay_number"
            IslandBay10.SelectedIndex = -1


            sql = ""
            sql = "select max(ID) as ID from t_Product where ID in(" & Product_ID & ") Group by ID order by ID"

            Dim dt As DataTable = cls.Query(sql)

            Dim ProID(dt.Rows.Count - 1) As String
            For i As Integer = 0 To dt.Rows.Count - 1
                ProID(i) = dt.Rows(i).Item("ID").ToString
            Next
            Dim dr() As DataRow = Listbay(ProID)
            Dim Bay2 As String = ""
            For i As Integer = 0 To dr.Length - 1
                If Bay2 = "" Then
                    Bay2 &= dr(i)("Bay").ToString
                Else
                    Bay2 &= "," & dr(i)("Bay").ToString
                End If
            Next

            Bay.Text = dr(0)("Bay").ToString

            Bay_Leave(Nothing, Nothing)

            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TProductBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TProductBindingSource.PositionChanged
        Try
            Dim Product_ID As Integer
            Dim Sql, Product_N As String

            Product_ID = TProductBindingSource.Item(TProductBindingSource.Position)("ID").ToString()
            Product_N = TProductBindingSource.Item(TProductBindingSource.Position)("Product_name").ToString()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bay_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bay.Leave, Bay.SelectedIndexChanged
        Try
            Dim Bay_Number, Product_ID As Integer
            Dim Sql As String

            Bay_Number = TBayBindingSource.Item(TBayBindingSource.Position)("Bay_Number").ToString()
            Product_ID = TProductBindingSource.Item(TProductBindingSource.Position)("ID").ToString()
            Sql = ""
            Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and batch_status=10 Order by Batch_name"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

            TBatchmeterBindingSource.DataSource = MyDataSet
            TBatchmeterBindingSource.DataMember = "T_batchmeter"

            Meter.SelectedIndex = 0

            TBatchmeterBindingSource1.DataSource = Nothing
            TBatchmeterBindingSource1.DataMember = Nothing
            TBatchmeterBindingSource1.DataSource = MyDataSet
            TBatchmeterBindingSource1.DataMember = "T_batchmeter"
            Meter1.DisplayMember = "Batch_name"
            Meter1.SelectedIndex = -1

            TBatchmeterBindingSource2.DataSource = Nothing
            TBatchmeterBindingSource2.DataMember = Nothing
            TBatchmeterBindingSource2.DataSource = MyDataSet
            TBatchmeterBindingSource2.DataMember = "T_batchmeter"
            Meter2.DisplayMember = "Batch_name"
            Meter2.SelectedIndex = -1

            TBatchmeterBindingSource3.DataSource = Nothing
            TBatchmeterBindingSource3.DataMember = Nothing
            TBatchmeterBindingSource3.DataSource = MyDataSet
            TBatchmeterBindingSource3.DataMember = "T_batchmeter"
            Meter3.DisplayMember = "Batch_name"
            Meter3.SelectedIndex = -1

            TBatchmeterBindingSource4.DataSource = Nothing
            TBatchmeterBindingSource4.DataMember = Nothing
            TBatchmeterBindingSource4.DataSource = MyDataSet
            TBatchmeterBindingSource4.DataMember = "T_batchmeter"
            Meter4.DisplayMember = "Batch_name"
            Meter4.SelectedIndex = -1

            TBatchmeterBindingSource5.DataSource = Nothing
            TBatchmeterBindingSource5.DataMember = Nothing
            TBatchmeterBindingSource5.DataSource = MyDataSet
            TBatchmeterBindingSource5.DataMember = "T_batchmeter"
            Meter5.DisplayMember = "Batch_name"
            Meter5.SelectedIndex = -1

            TBatchmeterBindingSource6.DataSource = Nothing
            TBatchmeterBindingSource6.DataMember = Nothing
            TBatchmeterBindingSource6.DataSource = MyDataSet
            TBatchmeterBindingSource6.DataMember = "T_batchmeter"
            Meter6.DisplayMember = "Batch_name"
            Meter6.SelectedIndex = -1

            TBatchmeterBindingSource7.DataSource = Nothing
            TBatchmeterBindingSource7.DataMember = Nothing
            TBatchmeterBindingSource7.DataSource = MyDataSet
            TBatchmeterBindingSource7.DataMember = "T_batchmeter"
            Meter7.DisplayMember = "Batch_name"
            Meter7.SelectedIndex = -1

            TBatchmeterBindingSource8.DataSource = Nothing
            TBatchmeterBindingSource8.DataMember = Nothing
            TBatchmeterBindingSource8.DataSource = MyDataSet
            TBatchmeterBindingSource8.DataMember = "T_batchmeter"
            Meter8.DisplayMember = "Batch_name"
            Meter8.SelectedIndex = -1

            TBatchmeterBindingSource9.DataSource = Nothing
            TBatchmeterBindingSource9.DataMember = Nothing
            TBatchmeterBindingSource9.DataSource = MyDataSet
            TBatchmeterBindingSource9.DataMember = "T_batchmeter"
            Meter9.DisplayMember = "Batch_name"
            Meter9.SelectedIndex = -1

            TBatchmeterBindingSource10.DataSource = Nothing
            TBatchmeterBindingSource10.DataMember = Nothing
            TBatchmeterBindingSource10.DataSource = MyDataSet
            TBatchmeterBindingSource10.DataMember = "T_batchmeter"
            Meter10.DisplayMember = "Batch_name"
            Meter10.SelectedIndex = -1

            TBatchmeterBindingSource11.DataSource = Nothing
            TBatchmeterBindingSource11.DataMember = Nothing
            TBatchmeterBindingSource11.DataSource = MyDataSet
            TBatchmeterBindingSource11.DataMember = "T_batchmeter"
            Meter11.DisplayMember = "Batch_name"
            Meter11.SelectedIndex = -1


            TBatchmeterBindingSource12.DataSource = Nothing
            TBatchmeterBindingSource12.DataMember = Nothing
            TBatchmeterBindingSource12.DataSource = MyDataSet
            TBatchmeterBindingSource12.DataMember = "T_batchmeter"
            Meter12.DisplayMember = "Batch_name"
            Meter12.SelectedIndex = -1

            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Order_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Order.KeyPress, Preset5.KeyPress, Preset4.KeyPress, Preset3.KeyPress, Preset2.KeyPress, Preset1.KeyPress
        If IsNumeric(e.KeyChar) = False AndAlso e.KeyChar <> Chr(8) Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub Order_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Order.TextChanged
        Try
            If Int(Order.Text) > Int(Cbn5.Text) Then
                Order.Text = Cbn5.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Cbn10_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbn10.Leave
        Try
            'If EditType <> 1 Then
            If Int(Cbn10.Text) > Int(Cbn5.Text) Then
                Cbn10.Text = Cbn5.Text
                Cbn10.Focus()
            End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cbn7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbn7.TextChanged
        Load_q.Text = Cbn7.Text

        'Dim Quete, lengQ As String
        'lengQ = Len(Cbn7.Text)

        'If lengQ = 1 Then
        '    Quete = "A00" & Cbn7.Text
        'End If
        'If lengQ = 2 Then
        '    Quete = "A0" & Cbn7.Text
        'End If
        'If lengQ = 3 Then
        '    Quete = "A" & Cbn7.Text
        'End If
        'Load_q.Text = Quete.ToString

    End Sub

    Private Sub Cbn10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbn10.TextChanged
        Try
            'If EditType <> 1 Then
            If Int(Cbn10.Text) > Int(Cbn5.Text) Then
                Cbn10.Text = Cbn5.Text
                Cbn10.Focus()
            End If
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Driver_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Driver.Leave

        AuthorRemarkDriver = ""
        If Driver.Text = "" Then
            Exit Sub
        End If

        Dim Vdate1, Vdate2 As Integer
        Dim Chk_DriverLicense As Integer = 0
        Dim Chk_DriverTraining As Integer = 0
        If EditType <> 1 Then

            Dim sql As String
            Dim dt_tmp As DataTable = cls.Query("SELECT * FROM T_OVERRIDE")


            For Each dr As DataRow In dt_tmp.Rows
                Select Case dr("OVERRIDE_NAME").ToString
                    Case "CHECK DRIVER LICENSE"
                        Chk_DriverLicense = dr("STATUS")
                    Case "CHECK DRIVER TRAINING"
                        Chk_DriverTraining = dr("STATUS")
                End Select
            Next

            sql = ""
            sql = "select (CONVERT (DATETIME,DRIVER_DATE_END)-CONVERT (DATETIME,Getdate())) as DRIVER_DATE_END,(CONVERT (DATETIME,TRAIN_DATE_end)-CONVERT (DATETIME,Getdate())) TRAIN_DATE_end From T_Driver where ID= '" & (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) & "'"

            Dim dt1 As DataTable = cls.Query(sql)

            Try
                Vdate1 = Int(dt1.Rows(0).Item("DRIVER_DATE_END").ToString())
            Catch ex As Exception
                Vdate1 = -1
            End Try

            If Vdate1 <= 0 And Chk_DriverLicense Then
                MessageBox.Show("Driver's driver license expire, Please check!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If MsgBox("Do you want to bypass by Supervisor user?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then

                    authorizeUser = 5
                    Loginauthorize.ShowDialog()
                    If Loginauthorize.Success = 0 Then
                        AuthorRemarkDriver = ""
                        authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString
                        Driver.SelectedIndex = -1
                        Driver.Focus()
                        Exit Sub
                    End If
                Else
                    AuthorRemarkDriver = ""
                    authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString
                    Driver.SelectedIndex = -1
                    Driver.Focus()
                    Exit Sub
                End If
                authorizeUser = 0
            End If

            Try
                Vdate2 = Int(dt1.Rows(0).Item("TRAIN_DATE_END").ToString())
            Catch ex As Exception
                Vdate2 = -1
            End Try
            If Vdate2 <= 0 And Chk_DriverTraining Then
                MessageBox.Show("Driver's training certificate expire, Please check!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If MsgBox("Do you want to bypass by Supervisor user?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then

                    authorizeUser = 6
                    Loginauthorize.ShowDialog()
                    If Loginauthorize.Success = 0 Then
                        AuthorRemarkDriver = ""
                        authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString
                        Driver.SelectedIndex = -1
                        Driver.Focus()
                        Exit Sub
                    End If
                Else
                    AuthorRemarkDriver = ""
                    authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString
                    Driver.SelectedIndex = -1
                    Driver.Focus()
                    Exit Sub
                End If
                authorizeUser = 0
            End If
        End If

        If (Vdate1 < 30 And Vdate1 > 0) And Chk_DriverLicense Then
            MessageBox.Show("Driver license will expire in : '" & Vdate1.ToString & "' Day", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If (Vdate2 < 30 And Vdate2 > 0) And Chk_DriverTraining Then
            MessageBox.Show("Training certificate will expire in : '" & Vdate2.ToString & "' Day", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Try
            Dim ArrPic() As Byte = TDriverBindingSource.Item(TDriverBindingSource.Position)("DRIVER_PICTURE")
            Dim Ms As MemoryStream = New MemoryStream(ArrPic)
            PictureBox1.Image = Image.FromStream(Ms)
            Ms.Dispose()


        Catch ex As Exception
            PictureBox1.Image = Nothing
        End Try

    End Sub

    Private Sub Preset1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Preset1.TextChanged
        Try
            If Int(Preset1.Text) > Int(Capacity1.Text) Then
                Preset1.Text = Capacity1.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Preset2.TextChanged
        Try
            If Int(Preset2.Text) > Int(Capacity2.Text) Then
                Preset2.Text = Capacity2.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Preset3.TextChanged
        Try
            If Int(Preset3.Text) > Int(Capacity3.Text) Then
                Preset3.Text = Capacity3.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bt_FindLN_Click(sender As Object, e As EventArgs) Handles bt_FindLN.Click
        '''Me.AddOwnedForm(FindLoadingNote)

        'FindLoadingNote.ShowDialog()
    End Sub

    Private Sub Seal_No_Leave(sender As Object, e As EventArgs) Handles Seal_No.Leave
        If Seal_No.Text = "" Then
            Seal_Total.Text = "0"
            Exit Sub
        End If

        Dim Seal_NumberForCount As New List(Of String)
        Dim Seal_Number As String = Seal_No.Text
        Dim Seal_Func01 As String() = Seal_Number.Split(",")

        For i = 0 To Seal_Func01.Length - 1
            Dim Seal_Func02 As String() = Seal_Func01(i).Split("-")
            If Seal_Func02.Length > 1 Then
                Dim SealLen As Integer = Len(Seal_Func02(1))
                For ii = CDec(Strings.Right(Seal_Func02(0), SealLen)) To CDec(Seal_Func02(1))
                    Seal_NumberForCount.Add(ii.ToString)
                Next
            Else
                Seal_NumberForCount.Add(Seal_Func01(i))
            End If
        Next

        Seal_Total.Text = Seal_NumberForCount.Count
    End Sub

    Private Sub Preset4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Preset4.TextChanged
        Try
            If Int(Preset4.Text) > Int(Capacity4.Text) Then
                Preset4.Text = Capacity4.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Preset5.TextChanged
        Try
            If Int(Preset5.Text) > Int(Capacity5.Text) Then
                Preset5.Text = Capacity5.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Preset6.TextChanged
        Try
            If Int(Preset6.Text) > Int(Capacity6.Text) Then
                Preset6.Text = Capacity6.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Preset7.TextChanged
        Try
            If Int(Preset7.Text) > Int(Capacity7.Text) Then
                Preset7.Text = Capacity7.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Preset8.TextChanged
        Try
            If Int(Preset8.Text) > Int(Capacity8.Text) Then
                Preset8.Text = Capacity8.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Preset9.TextChanged
        Try
            If Int(Preset9.Text) > Int(Capacity9.Text) Then
                Preset9.Text = Capacity9.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Preset10.TextChanged
        Try
            If Int(Preset10.Text) > Int(Capacity10.Text) Then
                Preset10.Text = Capacity10.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Preset11.TextChanged
        Try
            If Int(Preset11.Text) > Int(Capacity11.Text) Then
                Preset11.Text = Capacity11.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Preset12.TextChanged
        Try
            If Int(Preset12.Text) > Int(Capacity12.Text) Then
                Preset12.Text = Capacity12.Text
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Product_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Product.KeyPress
        Bay.SelectedIndex = -1
    End Sub

    Private Sub ProductList1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductList1.Leave
        'Try
        '    Dim Product_ID As Integer = 0
        '    Dim Sql, Product_N As String
        '    conn.Open()
        '    Product_ID = TProductBindingSource1.Item(TProductBindingSource1.Position)("ID").ToString()
        '    Product_N = TProductBindingSource1.Item(TProductBindingSource1.Position)("Product_name").ToString()
        '    Sql = ""
        '    Sql = "select bay_number from t_bay where bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "') or "
        '    Sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "') or "
        '    Sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "') or "
        '    Sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "') or "
        '    Sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "') or "
        '    Sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "') or "
        '    Sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "') or "
        '    Sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "') or "
        '    Sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "') or "
        '    Sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "') Order by bay_number"
        '    cmd.Connection = conn
        '    cmd.CommandText = Sql
        '    Dim dr As OracleDataReader = cmd.ExecuteReader()
        '    dr.Read()
        '    Dim da As OracleDataAdapter = New OracleDataAdapter(Sql, conn)
        '    Dim MyDataSet As New DataSet
        '    da.Fill(MyDataSet, "T_bay")
        '    TBAYBindingSource1.DataSource = MyDataSet
        '    TBAYBindingSource1.DataMember = "T_bay"
        '    da.Dispose()
        '    MyDataSet.Dispose()
        '    conn.Close()
        'Catch ex As Exception
        '    conn.Close()
        'End Try
    End Sub


    Private Sub RadButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton9.Click, ToolStripButton6.Click
        SelectVLoadingNote()
    End Sub

    Function Listbay(ByVal ProductID() As String) As DataRow()
        Dim sql As String
        Dim DtInBay As New DataTable
        'Dim BayCount() As String
        Dim InProductID As String
        Dim Ds As New DataSet
        Dim Dr() As DataRow
        'Dim Inbay() As String
        ' Dim InbayCount As Integer = 0
        InProductID = "'" & Strings.Join(ProductID, "','") & "'"

        DtInBay.Columns.Add("Bay", GetType(System.Int32))
        DtInBay.Columns.Add("LoadCount", GetType(System.Int32))

        sql = "select * from t_bay where  bay_status=1 order by bay_number"

        cls.Query_DA(sql, Ds, "T_BAY")

        ''' bay ที่เติมได้ครบ..........................................''''''''''''''

        ' InbayCount = 0
        For Bay As Integer = 0 To Ds.Tables("T_BAY").Rows.Count - 1
            Dim Mt_Bay As String = ""
            Dim dt As DataTable
            For mt As Integer = 1 To 10
                If Ds.Tables("T_BAY").Rows(Bay)("METER" & mt & "_STATUS").ToString = 1 And Trim(Ds.Tables("T_BAY").Rows(Bay)("BAY_METER" & mt).ToString <> "0") Then
                    If Mt_Bay = "" Then
                        Mt_Bay &= "'" & Ds.Tables("T_BAY").Rows(Bay)("BAY_METER" & mt).ToString & "'"
                    Else
                        Mt_Bay &= ",'" & Ds.Tables("T_BAY").Rows(Bay)("BAY_METER" & mt).ToString & "'"
                    End If
                End If
            Next
            Dim str As String = "select min(batch_number) as batch_number,BATCH_PRO from t_batchmeter where batch_status=10 and batch_number in(" & Mt_Bay & ") and BATCH_PRO in(" & InProductID & ") GROUP By BATCH_PRO"

            dt = cls.Query(str)

            If dt.Rows.Count >= ProductID.Length Then
                DtInBay.Rows.Add()
                DtInBay.Rows(DtInBay.Rows.Count - 1)("BAY") = Ds.Tables("T_BAY").Rows(Bay)("BAY_NUMBER").ToString
                'ReDim Preserve Inbay(InbayCount)
                'Inbay(InbayCount) = Ds.Tables("T_BAY").Rows(Bay)("BAY_NUMBER").ToString
                'InbayCount += 1

            End If
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Dim sInbay As String = ""
        For i As Integer = 0 To DtInBay.Rows.Count - 1
            If sInbay = "" Then
                sInbay &= "'" & DtInBay.Rows(i)("bay").ToString & "'"
            Else
                sInbay &= ",'" & DtInBay.Rows(i)("bay").ToString & "'"
            End If

        Next
        sql = "select lc_load,lc_bay from t_loadingnotecompartment where  LC_status in(0,1,2) and LC_BAY in(" & sInbay & ") Group by lc_load,lc_bay order by lc_bay"

        cls.Query_DA(sql, Ds, "T_LOAD")

        'InbayCount = 0
        For i As Integer = 0 To DtInBay.Rows.Count - 1
            Dr = Ds.Tables("T_LOAD").Select("lc_bay=" & DtInBay.Rows(i)("BAY").ToString, "")
            DtInBay.Rows(i)("LoadCount") = Dr.Length
            'ReDim Preserve BayCount(InbayCount)
            '(BayCount(InbayCount) = Dr.Length)
            'InbayCount += 1
        Next
        Dr = DtInBay.Select("", "LoadCount,BAY")
        DtInBay.Dispose()
        Ds.Dispose()
        Return Dr
    End Function
End Class

