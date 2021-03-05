Imports System.IO
Imports ExtendedErrorProvider
Imports CrystalDecisions.CrystalReports.Engine
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data

#Region "Private Variable"


#End Region

Public Class Advisenote
    Private cls As New Class_SQLSERVERDB
    Private cls_role As New Class_Permission
    Private cls_data As New Class_SelectData
    Private Page_Group As String = "Operate Data"
    Private MyErrorProvider As New ErrorProviderExtended
    Private TRUCK_COMP_NUM, sum, auto, sealEdit, Chkin, Chkout, Kiosk, baycheck As Integer
    Private EditType, CanExit As Integer
    Dim Seallast As String
    Dim QLOAD As Integer = 0
    Dim ProductCom(12) As String
    Private product_Do, Seal_Last, Checkin_ID, Truck_id, Call_Tergets As String
    Private Property Advisenote As Object
    Public authorizeUser As Integer = 0
    Private QTIME, Checkintime As String
    Public AuthorRemark, AuthorRemarkDriver As String
    Dim Memory As MemoryManagement.Manage
    Dim EditDoc, AddDoc As Boolean

    Public Function Chk_View()
        '------------------------------------------- Start Check Permission
        RadMessageBox.SetThemeName("Office2010Blue")

        cls_role.Chk_Permission(MAIN.U_GROUP_ID, 1)

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

        'My.Application.ChangeCulture("en-GB")

        'My.Application.ChangeCulture("th-TH")

        'Dim ProID(1) As String
        'ProID(0) = 1
        'ProID(1) = 1291
        'Dim dr() As DataRow = Listbay(ProID)
        'Dim Bay2 As String = ""
        'For i As Integer = 0 To dr.Length - 1
        '    Bay2 &= "[" & dr(i)("Bay").ToString & " " & dr(i)("loadCount").ToString & "] "
        'Next
        'MessageBox.Show(Bay2)


        RadPageView1.SelectedPage = RadPageViewPage1
        DateTimePicker1xx.Value = Date.Now
        DateTimePicker2xx.Value = Date.Now
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
        TruckH.Enabled = False
        Me.T_STATUSTableAdapter1.Fill(Me.DataSet_Table.T_STATUS)
        Me.T_TRUCKTYPETableAdapter1.Fill(Me.DataSet_Table.T_TRUCKTYPE)
        Me.T_BATCHMETERTableAdapter1.Fill(Me.DataSet_Table.T_BATCHMETER)
        Me.T_TRUCKTableAdapter1.Fill(Me.DataSet_Table.T_TRUCK)
        Me.T_BAYTableAdapter1.Fill(Me.DataSet_Table.T_BAY)
        Me.T_PRODUCTTableAdapter.Fill(Me.DataSet_Table.T_PRODUCT)
        'Me.T_SHIPPERTableAdapter.Fill(Me.IRPCDataset.T_SHIPPER)
        Me.T_COMPANYTableAdapter1.Fill(Me.DataSet_Table.T_COMPANY)
        'Me.T_CUSTOMERTableAdapter1.Fill(Me.DataSet_Table.T_CUSTOMER)
        Me.T_DRIVERTableAdapter1.Fill(Me.DataSet_Table.T_DRIVER)
        SelectVLoadingNote()

        EditType = 0
        sealEdit = 0
        MyErrorProvider.Controls.Clear()
        MyErrorProvider.Controls.Add(Cbn2, "Vehicle No")
        MyErrorProvider.Controls.Add(Driver, "Driver Name")
        MyErrorProvider.Controls.Add(EdCustomer, " Customer code")
        MyErrorProvider.ClearAllErrorMessages()
        MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        Try
            Memory = New MemoryManagement.Manage
            Memory.FlushMemory()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Advisenote_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        'Dim x As Integer = 0
        'Dim y As Integer = 5
        'x = RadPanel2.Height + y
        'RadPageView1.Height = Me.Height - x
        Try
            Memory = New MemoryManagement.Manage
            Memory.FlushMemory()
        Catch ex As Exception
        End Try



        Timer1.Enabled = True

        baycheck = 0
        Cbn2.Enabled = True
        TruckH.Enabled = False
        Chkin = 0
        Chkout = 0
        Kiosk = 0
        QLOAD = 0
        authorizeUser = 0
        Me.MasterGridAdvisenote.TableElement.RowHeight = 25
        Me.MasterGridAdvisenote.TableElement.TableHeaderHeight = 30
        MasterGridAdvisenote.FilterDescriptors.Clear()
        Status.Enabled = True
        Dim s_day, s_month, s_year As String
        s_day = Date.Now.Day
        s_month = Date.Now.Month
        s_year = Date.Now.Year
        RadPageView1.SelectedPage = RadPageViewPage1
        Bsave.Visible = True
        Update.Visible = False

        ClearData()
        CompClear()
        'Me.VCHECKINLOADTableAdapter.Fill(Me.DataSet_View.VCHECKINLOAD)
        Me.T_BATCHMETERTableAdapter1.Fill(Me.DataSet_Table.T_BATCHMETER)
        Me.T_COMPANYTableAdapter1.Fill(Me.DataSet_Table.T_COMPANY)

        CanExit = 0
    End Sub

    Private Sub SelectVLoadingNote()
        Dim q As String

        Try
            q = ""
            q = "SELECT   max(T1.LOAD_CAPACITY) as LOAD_CAPACITY,max(load_q) as LOAD_Q"
            q &= " ,max(T1.LOAD_PRESET) as LOAD_PRESET, max(T1.LOAD_CARD) as LOAD_CARD"
            q &= " ,max(T2.LC_COMPARTMENT) as LC_COMPARTMENT ,max(T2.LC_BAY) as LC_BAY,Reference, max(T1.LOAD_DATE) as LOAD_DATE"
            q &= " ,max(T1.LOAD_DID) as LOAD_DID ,max(T_Status.STATUS_NAME) as STATUS_NAME ,max(T1.LOADDO) as LOAD_DOfull,max(t_customer.Customer_name) as Customer_name  "
            q &= " , CASE max(t1.Container)	WHEN NULL THEN max(T_TRUCK.TRUCK_NUMBER) WHEN '' THEN max(T_TRUCK.TRUCK_NUMBER) ELSE max(t1.Container)  + '/ ' + max(T_TRUCK.TRUCK_NUMBER) END AS Load_Vehicle "
            q &= " ,isnull(max(T_DRIVER.Driver_NAME), '')+ '  ' + isnull(max(T_Driver.Driver_Lastname), '') AS LOAD_DRIVER "
            q &= " ,max(T1.load_id) as Load_id " ',max(V_DO.DO_STATUS) as DO_STATUS"
            q &= " ,max(t_product.Product_code) as PRODUCT_CODE,max(T_Batchmeter.BATCH_NAME) as BATCH_NAME"
            q &= " ,max(T1.Container) as Container,max(T1.LOAD_TRUCKCOMPANY) as LOAD_TRUCKCOMPANY,max(T1.LOAD_PRESET) as LOAD_PRESET"
            q &= " ,max(LC_SEAL) as LC_SEAL,max(T1.LOAD_SEAL) as LOAD_SEAL,max(T1.LOAD_SEALCOUNT) as LOAD_SEALCOUNT"
            q &= " ,max(T1.ADDNOTEDATE) as ADDNOTEDATE,max(T2.LC_STARTTIME) as LC_STARTTIME,max(T2.LC_ENDTIME) as LC_ENDTIME "
            q &= "FROM T_Customer  RIGHT OUTER JOIN (Select * from T_LOADINGNOTE  Where T_LOADINGNOTE.AddnoteDate between "
            q &= "convert(datetime, '" & DateTimePicker1.Value.Year & "/" & DateTimePicker1.Value.Month & "/" & DateTimePicker1.Value.Day & " 00:00:00" & "') And "
            q &= "convert(datetime, '" & DatetimePicker2.Value.Year & "/" & DatetimePicker2.Value.Month & "/" & DatetimePicker2.Value.Day & " 23:59:59" & "')  "
            q &= "And Load_type<>1009 And Load_status in(1,2,3,4,5) and advisenote_type='Advisenote') T1 ON T_Customer.ID = T1.LOAD_CUSTOMER "
            q &= "LEFT OUTER JOIN T_STATUS  ON T1.LOAD_STATUS = T_STATUS.STATUS_ID   "
            q &= "LEFT OUTER JOIN T_TRUCK ON T1.LOAD_VEHICLE = T_TRUCK.ID   "
            q &= "LEFT OUTER JOIN T_DRIVER ON T1.LOAD_DRIVER = T_DRIVER.ID   "
            q &= "LEFT OUTER JOIN T_CARD  ON T1.LOAD_CARD = T_CARD.CARD_NUMBER   "
            q &= "Left OUTER JOIN T_BATCHMETER   "
            q &= "RIGHT OUTER JOIN (Select * From T_LOADINGNOTECOMPARTMENT) T2 ON T_BATCHMETER.BATCH_NUMBER = T2.LC_METER "
            q &= "LEFT OUTER JOIN T_Product ON T2.LC_PRO = T_Product.ID ON T1.LOAD_ID = T2.LC_LOAD "
            q &= "group by T1.reference order by T1.reference "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "V_LOADINGNOTE")
            V_LoadingnoteBindingSource.DataSource = MyDataSet
            V_LoadingnoteBindingSource.DataMember = "V_LOADINGNOTE"
            MyDataSet.Dispose()
            Try
                Memory = New MemoryManagement.Manage
                Memory.FlushMemory()
            Catch ex As Exception
            End Try
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        EditType = 0
    End Sub

    Private Sub Cbn2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbn2.Leave
        If Cbn2.Text = "" Then
            Exit Sub
        End If
        Dim tmp As DataTable
        Dim Vdate1, Vdate2, Vdate3 As Integer
        If Cbn2.Text = "" Then Exit Sub
        Dim sql As String
        sql = "SELECT * FROM T_TRUCK WHERE TRUCK_NUMBER='" & Cbn2.Text & "'"
        Dim dt5 As DataTable = cls.Query(sql)
        Try
            'TTruckTypeBindingSource.Position = TTruckTypeBindingSource.Find("ID", dt5(0)("TRUCK_TYPE").ToString)
            TCompanyBindingSource.Position = TCompanyBindingSource.Find("COMPANY_ID", CInt(dt5(0)("TRUCK_COMPANY")))
            Trucktype.SelectedValue = dt5(0)("TRUCK_TYPE")
        Catch ex As Exception
            Exit Sub
        End Try

        If EditType <> 1 And CanExit = 0 Then

            '''''''' Check Truck in Loading
            sql = "select load_vehicle From t_loadingnote where load_vehicle= '" & dt5(0)("ID").ToString & "' and load_status < 3 and Advisenote_type='Advisenote' "
            Dim dt2 As DataTable = cls.Query(sql)

            If dt2.Rows.Count > 0 Then
                MessageBox.Show("Truck No. : '" & Cbn2.Text & "' is loading not yet, Please check!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Cbn2.Text = ""
                Cbn2.SelectedIndex = -1
                Cbn3.SelectedIndex = -1
                Trucktype.SelectedIndex = -1
                Cbn2.Focus()
                Exit Sub
            End If
            dt2.Dispose()

            '''''''' Check Override Check in
            Dim q As String
            Dim Chk_Insurance, Chk_Measure, Chk_Inspection As Integer
            Chk_Insurance = Chk_Measure = Chk_Inspection = 0

            q = "Select OVERRIDE_NAME, STATUS from t_override"

            tmp = cls.Query(q)
            For Each dr As DataRow In tmp.Rows
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

            AuthorRemark = ""
            authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString

            If Chkin = 1 Then
                sql = "Select * from t_checkin where truck_id='" & dt5(0)("ID").ToString & "'"
                sql &= " and Status in(1) order by ldate desc"
                Dim dt As DataTable = cls.Query(sql)

                If dt.Rows.Count <> 0 Then
                    Checkin_ID = dt.Rows(0).Item("ID").ToString
                    Dim Checkintimes As DateTime = dt.Rows(0).Item("Ldate").ToString
                    Checkintime = Checkintimes.Day & "/" & Checkintimes.Month & "/" & Checkintimes.Year & " " & Checkintimes.Hour & ":" & Checkintimes.Minute & ":" & Checkintimes.Second
                    Dim QTIMEs As Date = dt.Rows(0).Item("Q_DATE").ToString
                    QTIME = QTIMEs.Day & "/" & QTIMEs.Month & "/" & QTIMEs.Year & " " & QTIMEs.Hour & ":" & QTIMEs.Minute & ":" & QTIMEs.Second
                    authorizeUser = 0
                    Dim LoadQ As String
                    LoadQ = dt.Rows(0).Item("Q_NO").ToString
                    Cbn7.Text = LoadQ.ToString
                Else
                    MsgBox("Invalid this truck no. in Check In process, Please check!", vbOKOnly & vbDefaultButton3, "Checking")
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

            sql = "select Insurance_dateexpire,measure_dateexpire,Condition_dateexpire  From V_Truck where TRUCK_NUMBER= '" & dt5(0)("TRUCK_NUMBER").ToString & "'"

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
                MessageBox.Show("Truck's insurance will expire in : '" & Vdate1.ToString & "' day", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If (Vdate2 < 30 And Vdate2 > 0) And Chk_Measure Then
                MessageBox.Show("Truck's measure certificate will expire in : '" & Vdate2.ToString & "' day", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

        Try
            If EditType <> 1 Then
                Cbn10.Text = ""
                Order.Text = ""
            End If
            CompClear()
            TRUCK_COMP_NUM = dt5(0)("TRUCK_COMP_NUM").ToString
            If sealEdit = 0 Then
                Seal_Total.Text = "0" 'TRUCK_COMP_NUM.ToString
                Seal_Total_Leave(sender, e)
            End If



            Dim TRUCK_CAPASITY As Integer
            Dim q As String

            'If Cbn2.Text <> "" Then
            q = ""
            q = "select TRUCK_CAPASITY,T_TRUCKCOMPCAP,T_TRUCKCOMPCAP_L from (Select ID,TRUCK_CAPASITY,TRUCK_NUMBER From T_Truck where TRUCK_NUMBER= '" & dt5(0)("TRUCK_NUMBER").ToString & "') T1 "
            q &= "Left Join (Select ID, t_truckcompno,T_TRUCKID,T_TRUCKCOMPCAP,T_TRUCKCOMPCAP_L From T_Truckcompartment) T2 On T1.ID = T2.T_TRUCKID ORDER BY T1.ID ASC, T2.t_truckcompno ASC  "

            Dim dt As DataTable = cls.Query(q)

            TRUCK_CAPASITY = dt.Rows(0).Item("TRUCK_CAPASITY").ToString()
            Cbn5.Text = TRUCK_CAPASITY

            RadButton1_Click(sender, e)

            For i = 1 To TRUCK_COMP_NUM 'dt.Rows.Count - 1
                'Try
                DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i).ToString), RadTextBox).Text = "0"
                DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (i).ToString), RadTextBox).Text = dt.Rows(i - 1).Item("T_TRUCKCOMPCAP").ToString()
                DirectCast(Me.GroupBox1.Controls.Item("Capacity_l" + (i).ToString), RadTextBox).Text = dt.Rows(i - 1).Item("T_TRUCKCOMPCAP_L").ToString()
                'Catch ex As Exception
                '    Exit Sub
                'End Try
            Next i
            'End If
            'conn.Close()

            Dim Ttype As String

            q = "Select TRUCK_TYPE, TRUCK_COMPANY, TRUCK_TRA from T_truck where TRUCK_NUMBER= '" & dt5(0)("TRUCK_NUMBER") & "'"

            tmp = cls.Query(q)

            Ttype = tmp(0)("TRUCK_TYPE")

            Cbn3.SelectedValue = tmp(0)("TRUCK_COMPANY")
            TCompanyBindingSource.Position = TCompanyBindingSource.Find("COMPANY_ID", tmp(0)("TRUCK_COMPANY"))

            If Ttype = "1003" Then
                TruckH.Enabled = False
                TruckH.Text = tmp(0)("TRUCK_TRA")
                'TruckH.Focus()
                'Exit Sub
            End If
        Catch ex As Exception
            'conn.Close()
        End Try
    End Sub

    Sub ClearData()
        Try
            PictureBox1.Image = Nothing

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
            TruckH.Text = ""
            TruckH.SelectedIndex = -1

            Cbn3.Text = ""
            'Cbn3.SelectedIndex = -1

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
                    DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (i).ToString), RadTextBox).Enabled = True
                    DirectCast(Me.GroupBox1.Controls.Item("Capacity_l" + (i).ToString), RadTextBox).Enabled = True
                    DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i).ToString), RadTextBox).Enabled = True
                    DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i).ToString), RadDropDownList).Enabled = True
                    DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i).ToString), RadDropDownList).Enabled = True
                    DirectCast(Me.GroupBox10.Controls.Item("Meter" + (i).ToString), RadDropDownList).Enabled = True
                    DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (i).ToString), RadTextBox).Text = ""
                    DirectCast(Me.GroupBox1.Controls.Item("Capacity_l" + (i).ToString), RadTextBox).Text = ""
                    DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i).ToString), RadTextBox).Text = ""
                    DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i).ToString), RadDropDownList).SelectedIndex = -1
                    DirectCast(Me.GroupBox10.Controls.Item("Meter" + (i).ToString), RadDropDownList).SelectedIndex = -1

                Catch ex As Exception
                    Exit Sub
                End Try
            Next i
            Try
                Memory = New MemoryManagement.Manage
                Memory.FlushMemory()
            Catch ex As Exception
            End Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Try
            'CanExit = 1
            'EditType = 1
            MyErrorProvider.ClearAllErrorMessages()
            'ClearData()
            'CompClear()
            'Me.Advisenote_Load(sender, e)
            Me.Advisenote_Shown(sender, e)
            'EditType = 0
        Catch ex As Exception
        End Try

        Try

            Dim Sql As String
            Sql = ""
            Sql = "Select ID,Batch_name from T_batchmeter where  Batch_Status=10 Order by Batch_name"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

            TBatchmeterBindingSource1.DataSource = MyDataSet
            TBatchmeterBindingSource1.DataMember = "T_batchmeter"

            TBatchmeterBindingSource2.DataSource = MyDataSet
            TBatchmeterBindingSource2.DataMember = "T_batchmeter"

            TBatchmeterBindingSource3.DataSource = MyDataSet
            TBatchmeterBindingSource3.DataMember = "T_batchmeter"

            TBatchmeterBindingSource4.DataSource = MyDataSet
            TBatchmeterBindingSource4.DataMember = "T_batchmeter"

            TBatchmeterBindingSource5.DataSource = MyDataSet
            TBatchmeterBindingSource5.DataMember = "T_batchmeter"

            TBatchmeterBindingSource6.DataSource = MyDataSet
            TBatchmeterBindingSource6.DataMember = "T_batchmeter"

            TBatchmeterBindingSource7.DataSource = MyDataSet
            TBatchmeterBindingSource7.DataMember = "T_batchmeter"

            TBatchmeterBindingSource8.DataSource = MyDataSet
            TBatchmeterBindingSource8.DataMember = "T_batchmeter"

            TBatchmeterBindingSource9.DataSource = MyDataSet
            TBatchmeterBindingSource9.DataMember = "T_batchmeter"

            TBatchmeterBindingSource10.DataSource = MyDataSet
            TBatchmeterBindingSource10.DataMember = "T_batchmeter"

            TBatchmeterBindingSource11.DataSource = MyDataSet
            TBatchmeterBindingSource11.DataMember = "T_batchmeter"

            TBatchmeterBindingSource12.DataSource = MyDataSet
            TBatchmeterBindingSource12.DataMember = "T_batchmeter"

            MyDataSet.Dispose()

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

        '----------------------- Check Add Permission
        If cls_role.ChkAdd = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to create documents in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '----------------------- Check Add Permission


        Dim sql As String
        Dim tmp As DataTable
        Dim dt_tmp As DataTable

        EditType = 0
        CanExit = 0
        ClearData()
        Me.T_CUSTOMERTableAdapter1.Fill(Me.DataSet_Table.T_CUSTOMER)

        QLOAD = 1
        auto = 0
        DO_Type.SelectedIndex = 0
        Dim q, s_day, s_month, s_year As String
        s_day = Date.Now.Day
        s_month = Date.Now.Month
        s_year = Date.Now.Year
        Cbn9.Text = Format(Date.Now.Date, "dd/MM/yyyy")
        Dateedit.Value = Now

        Status.SelectedText = "Waiting"
        Status.Enabled = False
        Update_by.Text = MAIN.U_NAME

        Dim yearthai As String

        sql = ""
        sql = "SELECT * FROM T_OVERRIDE WHERE OVERRIDE_NAME='QUEUE'"

        tmp = cls.Query(sql)
        Select Case tmp(0)("STATUS")
            Case 0
                Load_q.Text = "0"
                Cbn7.Text = "0"
            Case 1
                sql = ""
                sql = "select Q_NO+1 as Q_NO from T_Q "

                dt_tmp = cls.Query(sql)
                Load_q.Text = dt_tmp(0)("Q_NO").ToString

                yearthai = Str(Int(s_year + 543))

                sql = ""
                sql = "select  Isnull(max(LOAD_DID),0)+1 as LOAD_DID from T_LOADINGNOTE "
                sql &= " where LOAD_DAY=" + s_day + " and LOAD_MONTH =" + s_month + " and LOAD_YEAR=" + yearthai + ""

                dt_tmp = cls.Query(sql)
                Cbn7.Text = dt_tmp(0)("Load_DID").ToString
        End Select

        Try
            q = ""
            q = "select Isnull(max(Load_id),0)+1 as load_id ,Isnull(max(Reference),0)+1 as Reference  from T_loadingnote"

            dt_tmp = cls.Query(q)

            Cbn6.Text = dt_tmp(0)("Load_id")
            Cbn8.Text = dt_tmp(0)("Reference")
            Timer1.Enabled = False
            RadPageView1.SelectedPage = RadPageViewPage2
            Cbn2.Focus()
            Bsave.Visible = True
            Update.Visible = False

            EditDoc = False
            AddDoc = True
        Catch ex As Exception
            MsgBox(ex.Message())
            Timer1.Enabled = True
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


    Private Sub OrderBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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


        '----------------------- Check Print Permission
        If cls_role.ChkPrint = False Then
            Dim DiR As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to print documents in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = DiR.ToString()
            Exit Sub
        End If
        '----------------------- Check Print Permission

        'Try
        Dim ref As String
        Try
            ref = MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Myreport As New ReportDocument
        Myreport = New ReportDocument
        Dim q As String
        q = cls_data.SelectPrintLoadingNote(ref)

        Dim ds As New DataSet
        ds = cls.Query_DS(q, "V_Loadingnote")

        Myreport.Load("Report_File/AdvisenoteReport.rpt")
        Myreport.SetDataSource(ds)
        ReportPrint.CrystalReportViewer3.ReportSource = Myreport
        ReportPrint.ShowDialog()
        ds.Dispose()
        Myreport.Close()
        Try
            Memory = New MemoryManagement.Manage
            Memory.FlushMemory()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton7.Click
        Dim sql, SealDetail, q As String
        Dim Seal_totalV As Integer
        Dim tmp As DataTable

        sql = ""
        sql = "select * from T_seal"

        tmp = cls.Query(sql)

        SealDetail = tmp(0)("Seal_Last")
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
            MessageBox.Show("Please specify DO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cbn11.Focus()
            Exit Sub
        End If
        If Cbn2.SelectedIndex = -1 Then
            MessageBox.Show("Please specify Truck No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cbn2.Focus()
            Exit Sub
        End If
        If EdCustomer.SelectedIndex = -1 Then
            MessageBox.Show("Please specify Destination", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EdCustomer.Focus()
            Exit Sub
        End If

        If Cbn10.Text = "" Then
            MessageBox.Show("Please specify Total Preset", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cbn10.Focus()
            Exit Sub
        End If
        If Driver.SelectedIndex = -1 Then
            MessageBox.Show("Please specify Driver", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Driver.Focus()
            Exit Sub
        End If

        Container.Text = TruckH.Text

        Dim q, sc, sql As String
        Dim i, SL, ST, r, j As Integer

        Dim s_day, s_month, s_year As String
        Dim Card As String

        Update_date.Text = Date.Now

        s_day = Date.Now.Day
        s_month = Date.Now.Month
        s_year = Date.Now.Year

        Dim yearthai As String
        Dim tmp As DataTable

        q = ""
        q = "select Isnull(max(Load_id),0)+1 as load_id ,Isnull(max(Reference),0)+1 as Reference  from T_loadingnote"

        tmp = cls.Query(q)

        Cbn6.Text = tmp(0)("Load_id")
        Cbn8.Text = tmp(0)("Reference")

        yearthai = Str(Int(s_year + 543))
        sql = ""
        sql = "select  Isnull(max(LOAD_DID),0)+1 as LOAD_DID from T_LOADINGNOTE "
        sql &= " where LOAD_DAY=" + s_day + " and LOAD_MONTH =" + s_month + " and LOAD_YEAR=" + yearthai + ""

        tmp = cls.Query("SELECT STATUS FROM T_OVERRIDE WHERE OVERRIDE_NAME='QUEUE'")
        If tmp(0)("STATUS") = 1 Then
            tmp = cls.Query(sql)
            Cbn7.Text = tmp(0)("Load_DID").ToString
        Else
            Cbn7.Text = "0"
        End If

        Try
            ''''   ST  '''''''''
            q = ""
            q = "select Isnull(max(ST_ID),0)+1 as ST_ID"
            q &= " from T_ST"

            tmp = cls.Query(q)

            ST = tmp(0)("ST_ID")

            '''''' SC '''''''''''
            q = ""
            q = "select count(load_id) as CLoad_id "
            q &= "from T_loadingnote  where format(Getdate(),'dd-MM-yyyy')=format(load_date,'dd-MM-yyyy') "

            'q &= "where to_char(load_date,'DD') = to_char(Getdate(),'DD') "
            'q &= "AND  to_char(load_date,'MM') = to_char(Getdate(),'MM') "
            'q &= "AND  to_char(load_date,'YY') = to_char(Getdate(),'YY') "
            'q &= "AND (ST_ID NOT IN (SELECT st_id FROM t_st))  "

            tmp = cls.Query(q)

            SL = tmp(0)("CLoad_id")
            sc = ST + SL

            'Dim Q_time, Checkin_time As String
            'q = ""
            'q = "select ldate,q_date  "
            'q &= "from T_Checkin where id='" & Checkin_ID & "' order by id desc"

            'Cmd.CommandText = q
            'Cmd.ExecuteReader()
            'dr = Cmd.ExecuteReader
            'dr.Read()
            'Q_time = dr.Item("LDATE")
            'Checkin_time = dr.Item("Q_Date")

            '''''''' Insert T_Loadingnote'''''''''''''''''''
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

            'Try
            '    sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
            '      & ",USERGROUP='" & MAIN.U_GROUP & "'"

            '    cls.Update(sql)
            'Catch ex As Exception

            'End Try

            q = ""
            q = "Insert into T_Loadingnote "
            q &= " (Reference,"
            q &= " LOAD_CARD,"
            q &= " LOAD_DID,"
            q &= " LOAD_VEHICLE,"
            q &= " LOAD_STATUS,"
            q &= " LOAD_CAPACITY,"
            'q &= " ST_ID,"
            'q &= " LOAD_Shipper,"
            q &= " LOAD_STARTTIME,"
            q &= " AddnoteDate,"
            q &= " LOAD_DRIVER,"
            q &= " LOAD_PRESET,"
            q &= " LOAD_DOfull, "
            q &= " LOADDO, "
            'q &= " Reference, "
            q &= " Remark, "

            q &= " Container, "
            q &= " LOAD_SEALCOUNT, "
            q &= " Load_customer, "
            q &= " Load_seal, "
            q &= " Update_date, "
            q &= " LOAD_Q, "
            q &= " LOAD_QDASHBOARD, "
            q &= " Q_TIME, "
            q &= " CHECKIN_TIME, "
            q &= " LOAD_TRUCKCOMPANY, "
            q &= " DO_TYPE, "
            q &= " UPDATE_BY, "
            q &= "LOAD_AUTHORIZE,"
            q &= " LOAD_TYPE )"
            q &= " Values ("
            q &= "'" & (Cbn8.Text) & "',"

            'Random PinCode
            Dim dt_tmp As DataTable
            Dim RandGen As New Random
            Dim strRand As Integer

            Do
                strRand = RandGen.Next(0, 10000)
                dt_tmp = cls.Query("SELECT * FROM T_LOADINGNOTE WHERE LOAD_CARD=" & strRand & " AND LOAD_DAY=" + s_day + " and LOAD_MONTH =" + s_month + " and LOAD_YEAR=" + yearthai + "")

                If dt_tmp.Rows.Count = 0 Then
                    Exit Do
                End If
            Loop
            strRand = 1
            q &= "'" & strRand & "',"

            '' LOAD_CARD ''
            'Try
            '    sql = ""
            '    sql = "select Truck_ID,Card_Number from vcardload "
            '    sql &= "where Truck_ID= '" & (TTRUCKBindingSource1.Item(TTRUCKBindingSource1.Position)("ID").ToString()) & "'"

            '    Dim dt2 As DataTable = cls.Query(sql)
            '    If dt2.Rows.Count > 0 Then Card = dt2(0)("Card_Number") Else Card = "0"

            '    q &= "'" & Card & "',"
            'Catch ex As Exception
            '    q &= "'" & ("0") & "',"
            'End Try

            If Cbn7.Text = "" Then
                Try
                    sql = ""
                    sql = "select Q_NO from T_Q "

                    Dim dt2 As DataTable = cls.Query(sql)

                    q &= "'" & dt2(0)("Q_NO").ToString & "',"
                Catch ex As Exception
                    q &= "'" & ("0") & "',"
                End Try
            Else
                Try
                    q &= "'" & Cbn7.Text & "',"
                Catch ex As Exception
                    q &= "'" & ("0") + "'" & ","
                End Try
            End If
            q &= "'" & (TTRUCKBindingSource1.Item(TTRUCKBindingSource1.Position)("ID").ToString()) & "'," ' load_vehicle
            q &= "'" & (TStatusBindingSource.Item(TStatusBindingSource.Position)("STATUS_ID").ToString()) & "',"
            q &= "'" & (Cbn5.Text) & "',"
            'q &= "'" & Str(sc) & "'," ' ST_ID
            'q &= "'" & (TShipperBindingSource.Item(TShipperBindingSource.Position)("ID").ToString()) & "',"
            q &= "'" & (Cbn9.Text) & "',"

            Dim n_year As Integer = 0
            'If (Date.Now.Year > "2500") Or (Dateedit.Value.Year > "2500") Then
            n_year = 543
            'End If

            q &= " Getdate() ,"
            'q &= "CONVERT (DATETIME,'" & (String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateAdd(DateInterval.Year, -n_year, Dateedit.Value))) & "','DD/MM/YYYY HH24:MI:SS')" & ","
            q &= "'" & (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) & "',"
            q &= "'" & Preset.ToString & "',"
            q &= "'" & (Cbn11.Text) & "'," 'LOAD_DOfull
            q &= "'" & (Cbn11.Text) & "'," 'Loaddo

            q &= "'" & (Edremark.Text) & "',"
            q &= "'" & (Container.Text) & "',"
            q &= "'" & (Seal_Total.Text) & "',"
            q &= "'" & (TCUSTOMERTBindingSource.Item(TCUSTOMERTBindingSource.Position)("ID").ToString()) & "',"
            q &= "'" & (Seal_No.Text) & "',"
            q &= " Getdate() ,"

            q &= "'" & (Load_q.Text) & "',"
            q &= "'" & (Load_q.Text) & "',"

            If Chkin = 0 Then
                q &= "CONVERT (DATETIME,'" & (String.Format("{0:MM/dd/yyyy HH:mm:ss}", QTIME)) & "')," 'DD/MM/YYYY HH24:MI:SS')" & ","
                q &= "CONVERT (DATETIME,'" & (String.Format("{0:MM/dd/yyyy HH:mm:ss}", Checkintime)) & "')," 'DD/MM/YYYY HH24:MI:SS')" & ","
                'CONVERT (DATETIME,'" & (String.Format("{0:MM/dd/yyyy HH:mm:ss}", VE_EXPIREDATE.Value)) & "')," 'MM/dd/yyyy HH24:MI:SS')" & ","
            Else
                q &= " Getdate() ,"
                q &= " Getdate() ,"
            End If

            q &= "'" & (TCompanyBindingSource.Item(TCompanyBindingSource.Position)("COMPANY_ID").ToString()) & "',"
            q &= "'" & (DO_Type.Text).ToString & "',"
            q &= "'" & (Update_by.Text).ToString & "',"
            q &= "'" & (authorize_Remark.Text).ToString & "',"
            q &= "'" & (TTruckTypeBindingSource.Item(TTruckTypeBindingSource.Position)("ID").ToString()) & "' )"

            cls.Insert(q)

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
                    q &= " lc_productname,"
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


                    ''LC_PRODUCTNAME
                    If (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Then
                        q &= "'" & (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).Text) & "',"
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

                        MessageBox.Show("Invalid tank open '" & ProductCom(r).ToString & "', Cannot create advisenote, Please check!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Cursor = Cursors.Default

                        If Tank_Order.Chk_View() = False Then
                            Exit Sub
                        Else
                            Tank_Order.ShowDialog()
                        End If
                        Exit Sub
                    End Try
                    '' LC_METER ''

                    'sql = "select batch_number from t_batchmeter where batch_status=10 and BATCH_PRO in(" & (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedValue.ToString) & ") "
                    'sql &= " and batch_island_no in(select batch_island_no from t_batchmeter where batch_bay in('" & (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (r + 1).ToString), RadDropDownList).Text) & "'))"
                    'sql &= " order by batch_number "
                    'Cmd.CommandText = sql
                    'Cmd.ExecuteReader()
                    'Dim da2 As OracleDataAdapter = New OracleDataAdapter(sql, conn)
                    'Dim dt2 As New DataTable
                    'da2.Fill(dt2)
                    'q &= "'" & dt2.Rows(0).Item("batch_number").ToString & "')"


                    'sql = "select batch_number from t_batchmeter where ID in(" & (DirectCast(Me.GroupBox10.Controls.Item("Meter" + (r + 1).ToString), RadDropDownList).SelectedValue.ToString) & ") "

                    sql = "select batch_number from t_batchmeter where Batch_name in('" & (DirectCast(Me.GroupBox10.Controls.Item("Meter" + (r + 1).ToString), RadDropDownList).Text) & "') "
                    Dim dt2 As DataTable = cls.Query(sql)

                    q &= "'" & dt2.Rows(0).Item("batch_number").ToString & "')"


                End If

                cls.Insert(q)
            Next r

            Dim Call_Terget As String = "0"
            Try
                q = ""
                q = "select CALL_TARGET from T_QSETTING order by id"
                Dim dt1 As DataTable = cls.Query(q)

                Call_Terget = dt1(0)("CALL_TARGET").ToString
                Call_Tergets = Call_Terget.ToString
            Catch ex As Exception
                Call_Tergets = "2"
            End Try

            q = ""
            q = "Insert into t_dashboard "
            q &= " (LOAD_ID,"
            q &= " DRIVER_ID,"
            q &= " DRIVER_CARD,"
            q &= " TRUCK_ID,"
            q &= " TRUCK_CARD ,"
            q &= " Status,"
            q &= " DO_NO,"
            q &= " Q_NO,"
            q &= " Q_Status,"
            q &= " CALL_Target,"
            q &= " Q_DATE) "
            q &= " Values ("
            q &= "'" & (Cbn6.Text) & "',"
            q &= "'" & (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) & "',"
            Dim TruckCard, DriverCard As String
            Try
                sql = ""
                sql = "select Driver_ID,Card_Number from vcardload "
                sql &= "where Driver_ID= '" & (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) & "',"
                Dim dt2 As DataTable = cls.Query(sql)
                DriverCard = dt2(0)("Card_Number")
                q &= "" & DriverCard & "',"
            Catch ex As Exception
                q &= "'" & ("0") & "',"
            End Try
            q &= "'" & (TTRUCKBindingSource1.Item(TTRUCKBindingSource1.Position)("ID").ToString()) & "',"
            Try
                sql = ""
                sql = "select Truck_ID,Card_Number from vcardload "
                sql &= "where Truck_ID= '" & (TTRUCKBindingSource1.Item(TTRUCKBindingSource1.Position)("ID").ToString()) & "'"

                Dim dt2 As DataTable = cls.Query(sql)
                If dt2.Rows.Count > 0 Then TruckCard = dt2(0)("Card_Number") Else TruckCard = "0"

                dt2.Dispose()

                q &= "'" & TruckCard & "',"
            Catch ex As Exception
                q &= "'" & ("0") & "',"
            End Try
            q &= " 1,"
            q &= "'" & Cbn11.Text & "',"
            q &= "'" & Load_q.Text & "',"
            If Kiosk = 1 Then
                q &= " 0,"
            Else
                q &= " -1,"
            End If
            q &= "'" & Call_Terget.ToString & "',"
            q &= " Getdate() )"

            cls.Insert(q)

        Catch ex As Exception
            q = "delete t_loadingnote where load_id = "
            q &= Cbn6.Text
            cls.Delete(q)

            q = "delete t_loadingnotecompartment where lc_load = "
            q &= Cbn6.Text
            cls.Delete(q)

            q = "delete T_dashboard where load_id = "
            q &= Cbn6.Text
            cls.Delete(q)

            MessageBox.Show("Cannot create advisenote, Please check!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.Message())
            Cursor = Cursors.Default
            Exit Sub
        End Try

        q = "Update t_Seal Set Seal_last='" & Seal_Last & "'"
        cls.Update(q)

        q = "Update t_Checkin Set Status=2 ,LOAD_ID='" & Cbn6.Text & "',Call_target='" & Call_Tergets.ToString & "' where ID='" & Checkin_ID & "'"
        cls.Update(q)

        If QLOAD = 1 Then
            q = "Update T_Q Set Q_NO='" & Load_q.Text & "'"
            cls.Update(q)
        End If


        If AddDoc Then
            cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Create loading advise note : " & Cbn8.Text, "T_LOADINGNOTE", "")
            EditDoc = False
            AddDoc = False
        ElseIf EditDoc Then
            cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Edit loading advise note : " & Cbn8.Text, "T_LOADINGNOTE", "")
            EditDoc = False
            AddDoc = False
        End If

        Dim Myreport As New ReportDocument
        Myreport = New ReportDocument

        q = cls_data.SelectPrintLoadingNote(Cbn8.Text)

        Dim ds As New DataSet
        ds = cls.Query_DS(q, "V_Loadingnote")

        Myreport.Load("Report_File/AdvisenoteReport.rpt")
        Myreport.SetDataSource(ds)
        ReportPrint.CrystalReportViewer3.ReportSource = Myreport
        ReportPrint.ShowDialog()
        ds.Dispose()
        Myreport.Close()
        Myreport.Dispose()

        tmp.Dispose()

        Try
            Advisenote_Shown(sender, e)
            SelectVLoadingNote()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update.Click
        Dim q, sql, ref As String
        Dim i, r, j As Integer

        Update_date.Text = Date.Now
        ref = MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString

        sql = ""
        sql = "select load_id,load_card from t_loadingnote where reference='" & ref & "' "

        Dim tmp As DataTable = cls.Query(sql)

        Dim loadID, loadcard As String
        loadID = tmp(0)("load_id")
        loadcard = tmp(0)("load_card")
        If MsgBox("Edit advisenote Load No.: ' " & ref & " '?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then

            'Try
            '    sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
            '      & ",USERGROUP='" & MAIN.U_GROUP & "'"

            '    cls.Update(sql)
            'Catch ex As Exception
            'End Try

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
            'Dim dt_tmp As DataTable
            'Dim RandGen As New Random
            'Dim strRand As Integer

            'Do
            '    strRand = RandGen.Next(0, 10000)
            '    dt_tmp = cls.Query("SELECT * FROM T_LOADINGNOTE WHERE LOAD_CARD=" & strRand & " AND LOAD_DAY=" & Now.Day & " and LOAD_MONTH =" & Now.Month & " and LOAD_YEAR=" & Now.Year & "")

            '    If dt_tmp.Rows.Count = 0 Then
            '        Exit Do
            '    End If
            'Loop


            q &= "'" & loadcard.ToString & "', "
            q &= " LOAD_DID = "
            q &= "'" & Cbn7.Text & "',"
            q &= " LOAD_VEHICLE = "
            q &= "'" & (TTRUCKBindingSource1.Item(TTRUCKBindingSource1.Position)("ID").ToString()) & "',"
            q &= " LOAD_STATUS = "
            q &= "'" & (TStatusBindingSource.Item(TStatusBindingSource.Position)("STATUS_ID").ToString()) & "',"
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

            q &= "Getdate(),"
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

                'q = ""
                'q &= "Select * from  T_LOADINGNOTECOMPARTMENT where lc_load= "
                'q &= "'" & loadID & "' order by lc_compartment  "
                'Cmd.CommandText = q
                'Cmd.ExecuteNonQuery()
                'Dim da As OracleDataAdapter = New OracleDataAdapter(q, conn)
                'Dim dt As New DataTable
                'da.Fill(dt)

                q = ""
                q = "select LC_Status,lc_bay "
                q &= " From V_Loadingnotecompartment "
                q &= " Where LC_LOAD = "
                q &= "" + Cbn6.Text + ""
                q &= " order by LC_Compartment"

                Dim dt1 As DataTable = cls.Query(q)

                For r = 0 To TRUCK_COMP_NUM - 1

                    Dim LC_status As String
                    LC_status = (TStatusBindingSource.Item(TStatusBindingSource.Position)("Status_ID").ToString())
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
                        q &= " LC_PRODUCTNAME='0',"
                        q &= " LC_CAPACITY='" & (DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (r + 1).ToString), RadTextBox).Text) & "',"
                        q &= " LC_PRESET='0',"
                        q &= " LC_BAY='0',"
                        q &= " LC_SEAL='0',"
                        q &= " LC_TANK='0',"
                        q &= " LC_API='0', "
                        q &= " LC_METER='0' "
                        q &= "Where lc_load="
                        q &= "'" & Cbn6.Text & "'"
                        q &= " and lc_compartment = "
                        q &= "'" & (DirectCast(Me.GroupBox15.Controls.Item("Comp" + (r + 1).ToString), RadTextBox).Text) & "' "
                        q &= " and lc_status in(1,99) "
                    Else
                        q = ""
                        q = "Update T_LOADINGNOTECOMPARTMENT Set "
                        q &= " LC_COMPARTMENT="
                        q &= "'" & (DirectCast(Me.GroupBox15.Controls.Item("Comp" + (r + 1).ToString), RadTextBox).Text) & "',"

                        'If LC_status >= 3 Then
                        '    q &= " LC_STATUS="
                        '    q &= "'" & LC_status & "',"
                        'ElseIf LC_status = 99 Then
                        '    q &= " LC_STATUS='1' ,"
                        'End If

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

                        q &= " LC_PRODUCTNAME="
                        '' LC_PRO ''
                        If (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Then
                            q &= "'" & (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).Text) & "',"
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

                        Dim dr1 As DataTable = cls.Query(sql)

                        Dim TankRef, Density As String

                        Try
                            TankRef = dr1(0)("tankno")
                            q &= "'" & TankRef & "',"
                        Catch ex As Exception
                            q &= "''" & ","
                        End Try



                        If ((dt1.Rows(r).Item("LC_Status").ToString = "1") Or (dt1.Rows(r).Item("LC_Status").ToString = "99")) Then
                            'If (dt1.Rows(r).Item("LC_BAY").ToString <> (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (r + 1).ToString), RadDropDownList).Text)) Then
                            'q &= " LC_METER='0',"


                            'sql = "select batch_number from t_batchmeter where batch_status=10 and BATCH_PRO in(" & (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedValue.ToString) & ") "
                            'sql &= " and batch_island_no in(select batch_island_no from t_batchmeter where batch_bay in('" & (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (r + 1).ToString), RadDropDownList).Text) & "'))"
                            'sql &= " order by batch_number "


                            sql = "select batch_number from t_batchmeter where Batch_name in('" & (DirectCast(Me.GroupBox10.Controls.Item("Meter" + (r + 1).ToString), RadDropDownList).Text) & "') "

                            Dim dt2 As DataTable = cls.Query(sql)

                            q &= " LC_METER='" & dt2.Rows(0).Item("batch_number").ToString & "',"

                            'End If
                        End If


                        q &= " LC_API="
                        Try
                            Density = dr1(0)("TANKAPI")
                            q &= "'" & Density & "' "
                        Catch ex As Exception
                            q &= "'' "
                        End Try


                        q &= "Where lc_load="
                        q &= "'" & Cbn6.Text & "'"
                        q &= " and lc_compartment = "
                        q &= "'" & (DirectCast(Me.GroupBox15.Controls.Item("Comp" + (r + 1).ToString), RadTextBox).Text) & "' "
                        q &= " and lc_status in(1,99) "

                        dt1.Dispose()

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
            Me.T_STATUSTableAdapter1.Fill(Me.DataSet_Table.T_STATUS)
            Me.T_TRUCKTYPETableAdapter1.Fill(Me.DataSet_Table.T_TRUCKTYPE)
            Me.T_BATCHMETERTableAdapter1.Fill(Me.DataSet_Table.T_BATCHMETER)
            Me.T_TRUCKTableAdapter1.Fill(Me.DataSet_Table.T_TRUCK)
            Me.T_BAYTableAdapter1.Fill(Me.DataSet_Table.T_BAY)
            Me.T_PRODUCTTableAdapter.Fill(Me.DataSet_Table.T_PRODUCT)
            'Me.T_SHIPPERTableAdapter.Fill(Me.IRPCDataset.T_SHIPPER)
            Me.T_COMPANYTableAdapter1.Fill(Me.DataSet_Table.T_COMPANY)
            Me.T_CUSTOMERTableAdapter1.Fill(Me.DataSet_Table.T_CUSTOMER)
            Me.T_DRIVERTableAdapter1.Fill(Me.DataSet_Table.T_DRIVER)
            CompClear()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Canceldata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Canceldata.Click


        '----------------------- Check Delete Permission
        If cls_role.ChkDel = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to delete documents in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '----------------------- Check Delete Permission


        Try
            Dim sql As String


            Dim ref, LC_ID, load_do, load_status As String

            Try
                ref = MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString
            Catch ex As Exception
                Exit Sub
            End Try

            sql = ""
            sql = "select Load_id,load_dofull,load_status from T_Loadingnote where reference = "
            sql &= ref

            Dim tmp As DataTable = cls.Query(sql)

            LC_ID = tmp(0)("Load_id")
            load_do = tmp(0)("load_dofull")
            load_status = tmp(0)("load_status")

            If load_status = 3 Then
                MsgBox("This truck no. loading ended, Cannot cancel", vbOKOnly + vbDefaultButton2, "Error")
                Exit Sub
            Else

                If MsgBox("Cancel advisenote load no. : " + ref + " ?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then

                    Try

                        sql = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
                              & ",USERGROUP='" & MAIN.U_GROUP & "'"

                        cls.Update(sql)
                    Catch ex As Exception

                    End Try

                    'sql = "delete   T_Loadingnote where reference ='" & ref & "'"
                    'cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Delete loading advise note : " & ref, "T_LOADINGNOTE", "")
                    'cls.Delete(sql)

                    'sql = "delete t_loadingnotecompartment where lc_load ='" & LC_ID & "'"
                    'cls.Delete(sql)

                    sql = "update T_Loadingnote set load_status=50 where reference ='" & ref & "'"
                    cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Cancel loading advise note : " & ref, "T_LOADINGNOTE", "")
                    cls.Update(sql)

                    sql = "Update t_loadingnotecompartment set lc_status=50 where lc_load ='" & LC_ID & "'"
                    cls.Update(sql)

                    Timer1.Enabled = True
                    RadPageView1.SelectedPage = RadPageViewPage1

                    sql = "Update   T_Checkin set status=1,load_id='',CALL_ACTUAL=0 where load_id ='" & LC_ID & "'"
                    cls.Update(sql)

                    sql = "delete   t_dashboard where load_id ='" & LC_ID & "'"
                    cls.Delete(sql)

                    sql = "delete   T_Qloadend where load_id ='" & LC_ID & "'"
                    cls.Delete(sql)

                    SelectVLoadingNote()
                    ' Me.VCHECKINLOAD1TableAdapter.Fill(Me.DataSet_Table.VCHECKINLOAD1)
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Editdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Editdata.Click

        '----------------------- Check Edit Permission
        If cls_role.ChkEdit = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to edit documents in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Exit Sub
        End If
        '----------------------- Check Edit Permission


        Dim sql, sealCount As String

        Cbn2.Enabled = False
        TruckH.Enabled = False

        EditType = 1
        Bay_Leave(sender, e)
        CanExit = 1
        Status.Enabled = True

        Dim q, ref, load_status As String
        Dim truck As Integer
        Try
            ref = MasterGridAdvisenote.CurrentRow.Cells("REFERENCE").Value.ToString
        Catch ex As Exception
            Exit Sub
        End Try

        sql = ""
        sql = "select load_status from T_Loadingnote where reference = "
        sql &= ref

        Dim tmp As DataTable = cls.Query(sql)

        load_status = tmp(0)("load_status")
        If load_status = 3 Then
            MsgBox("This truck no. loading ended, Cannot edit", vbOKOnly + vbDefaultButton3, "Error")
            Exit Sub
        Else

            sealEdit = 1

            Refresh()
            q &= ""
            q &= "Select Isnull(T_LOADINGNOTE.load_did,0) as Load_did ,t_loadingnote.load_truckcompany as Company,"
            q &= "Isnull(T_LOADINGNOTE.LOAD_delivery,0) as load_delivery ,"
            q &= "Isnull(T_TRUCK.TRUCK_NUMBER,0) as load_vehicle ,"
            q &= "Isnull(T_LOADINGNOTE.LOAD_vehicle,0) as load_vehicle_ID ,"
            q &= "Isnull(T_LOADINGNOTE.LOAD_capacity,0) as load_capacity ,"
            q &= "Isnull(T_LOADINGNOTE.LOAD_driver,0) as load_driver ,"
            q &= "Isnull(T_LOADINGNOTE.LOAD_preset,0) as load_preset ,"
            q &= "Isnull(T_LOADINGNOTE.LOAD_SEAL,0) as LOAD_SEAL ,"
            q &= "Isnull(T_LOADINGNOTE.LOAD_card,0) as load_card ,"
            q &= "T_LOADINGNOTE.AddnoteDate as AddnoteDate,"
            q &= "Isnull(T_LOADINGNOTE.Reference,0) as Reference ,"
            q &= "Isnull(T_LOADINGNOTE.LOAD_id,0) as load_id ,"
            q &= "Isnull(T_LOADINGNOTE.LOAD_Sealcount,0) as load_Sealcount ,"
            q &= "T_LOADINGNOTE.Container AS Container ,"
            q &= "Isnull(T_LOADINGNOTE.Remark,'') as Remark ,"
            q &= "Isnull(T_Customer.Customer_name ,0) as Customer_Code ,"   'T_Customer.Customer_name
            q &= "Isnull(T_LOADINGNOTE.load_customer ,0) as Customer_ID ,"
            q &= "Isnull(T_DRIVER.Driver_Name ,0) as Driver_Name ,"   'T_DRIVER.Driver
            q &= "Isnull(T_STATUS.status_name,0) as status_Name ,"   'T_STATUS.status_name
            q &= "Isnull(T_COMPANY.COMPANY_name ,0) as LOAD_TRUCKCOMPANY ,"  'T_COMPANY.COMPANY_CODE
            q &= "Isnull(T_LOADINGNOTE.LOAD_status,0) as Load_status ,"
            q &= "T_LOADINGNOTE.Update_date as Update_date ,"
            q &= "T_LOADINGNOTE.UPDATE_BY as Update_by ,"
            q &= "Isnull(T_LOADINGNOTE.LOAD_DOfull,0) as LOAD_DOfull ,"
            q &= "Isnull(T_LOADINGNOTE.LOAD_TYPE,-1) as LOAD_TYPE ,"
            q &= "Isnull(T_LOADINGNOTE.LOAD_Q ,0) as LOAD_Q ,"
            q &= "Isnull(T_Loadingnote.load_Driver ,0) as Driver_ID ,"
            q &= "Isnull(T_LOADINGNOTE.DO_TYPE,'0') as DO_TYPE ,"
            q &= "T_LOADINGNOTE.LOAD_AUTHORIZE  AS LOAD_AUTHORIZE "
            ' q &= "T_LOADINGNOTE.remark  AS REmark "

            q &= "FROM "
            q &= "(Select * from T_LOADINGNOTE where Reference = '" & ref & "' and load_Status in(1,2,3,4,5) and load_status <> 99) T_Loadingnote "
            q &= "LEFT OUTER JOIN  T_STATUS ON T_LOADINGNOTE.LOAD_STATUS = T_STATUS.STATUS_ID "
            ' &= "Left OUTER JOIN  V_DO ON T_LOADINGNOTE.LOAD_ID = V_DO.LOAD_ID "
            q &= "Left OUTER JOIN T_Customer  ON  T_LOADINGNOTE.LOAD_CUSTOMER =T_Customer.ID "
            q &= "LEFT OUTER JOIN  T_COMPANY ON T_LOADINGNOTE.LOAD_TRUCKCOMPANY = T_COMPANY.COMPANY_ID  "
            q &= "LEFT OUTER JOIN  T_TRUCK ON T_LOADINGNOTE.LOAD_VEHICLE = T_TRUCK.ID "
            q &= "LEFT OUTER JOIN T_DRIVER ON T_LOADINGNOTE.LOAD_DRIVER = T_DRIVER.ID  "
            q &= "ORDER BY T_LOADINGNOTE.LOAD_ID DESC  "

            Dim dt As DataTable = cls.Query(q)

            sealCount = dt.Rows(0).Item("Load_sealcount").ToString
            Seal_Total.Text = sealCount.ToString
            Try
                Bcancel_Click(sender, e)
                Cbn6.Text = dt.Rows(0).Item("load_ID").ToString
                Cbn11.Text = dt.Rows(0).Item("load_DOfull").ToString
                Cbn10.Text = dt.Rows(0).Item("load_Preset").ToString
                Cbn8.Text = dt.Rows(0).Item("Reference").ToString
                Container.Text = dt.Rows(0).Item("Container").ToString
                Seal_Total.Text = dt.Rows(0).Item("Load_sealcount").ToString
                DO_Type.Text = dt.Rows(0).Item("DO_Type").ToString
                Update_by.Text = dt.Rows(0).Item("Update_by").ToString
                'RadButton7_Click(sender, e)
                'Seal_Total.Text = dt.Rows(0).Item("Load_sealcount").ToString
                sealCount = dt.Rows(0).Item("Load_sealcount").ToString
                Seal_Total.Text = sealCount.ToString
                Seal_No.Text = dt.Rows(0).Item("Load_seal").ToString
                Cbn5.Text = dt.Rows(0).Item("load_Capacity").ToString
                Cbn7.Text = dt.Rows(0).Item("Load_did").ToString
                Load_q.Text = dt.Rows(0).Item("Load_Q").ToString
                'truck = dt.Rows(0).Item("load_vehicle_ID")
                authorize_Remark.Text = dt.Rows(0).Item("load_Authorize").ToString
                Update_date.Text = dt.Rows(0).Item("update_date").ToString

                Dateedit.Value = dt.Rows(0).Item("AddnoteDate").ToString

                If dt.Rows(0).Item("load_vehicle").ToString <> "" And dt.Rows(0).Item("load_vehicle").ToString <> "0" Then
                    Cbn2.Text = dt.Rows(0).Item("load_vehicle").ToString
                    TTRUCKBindingSource1.Position = TTRUCKBindingSource1.Find("Truck_number", dt.Rows(0).Item("load_vehicle").ToString)
                End If

                'If dt.Rows(0).Item("Container").ToString <> "" Then
                '    TTRUCKBindingSource1.Position = TTRUCKBindingSource1.Find("Truck_number", dt.Rows(0).Item("Container").ToString)
                'End If


                'TDriverBindingSource.Position = TDriverBindingSource.Find("DRIVER_NAME", dt.Rows(0).Item("Driver_Name").ToString)
                TDriverBindingSource.Position = TDriverBindingSource.Find("ID", dt.Rows(0).Item("Load_Driver").ToString)

                TCompanyBindingSource.Position = 2
                Dim CCom As Integer
                CCom = dt.Rows(0).Item("Company")
                'TCompanyBindingSource.Position = TCompanyBindingSource.Find("Company_name", dt.Rows(0).Item("LOAD_TRUCKCOMPANY").ToString)
                TCompanyBindingSource.Position = TCompanyBindingSource.Find("Company_ID", CCom)


                'TShipperBindingSource.Position = TShipperBindingSource.Find("ID", dt.Rows(0).Item("LOAD_Shipper").ToString)
                TCUSTOMERTBindingSource.Position = TCUSTOMERTBindingSource.Find("Customer_name", dt.Rows(0).Item("Customer_code").ToString)
                TTruckTypeBindingSource.Position = TTruckTypeBindingSource.Find("ID", dt.Rows(0).Item("Load_type").ToString)
                TStatusBindingSource.Position = TStatusBindingSource.Find("Status_ID", dt.Rows(0).Item("load_status").ToString)

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

                TruckH.Text = dt.Rows(0).Item("Container").ToString
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

                Next

                For i = 0 To dt1.Rows.Count - 1

                    If (dt1.Rows(i).Item("LC_Bay").ToString) <> "0" Then
                        Bay = ""
                        Bay = (dt1.Rows(i).Item("LC_BAY").ToString)
                        index = DirectCast(Me.GroupBox11.Controls.Item("Islandbay" + (i + 1).ToString), RadDropDownList).FindString(Bay)
                        DirectCast(Me.GroupBox11.Controls.Item("Islandbay" + (i + 1).ToString), RadDropDownList).SelectedIndex = index

                    Else
                        DirectCast(Me.GroupBox11.Controls.Item("Islandbay" + (i + 1).ToString), RadDropDownList).SelectedIndex = -1
                    End If

                    DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i + 1).ToString), RadTextBox).Text = (dt1.Rows(i).Item("LC_PRESET").ToString)

                    If (dt1.Rows(i).Item("LC_Meter").ToString) <> "0" Then
                        Meter = ""
                        Meter = (dt1.Rows(i).Item("Batch_name").ToString)
                        index = DirectCast(Me.GroupBox10.Controls.Item("meter" + (i + 1).ToString), RadDropDownList).FindString(Meter)
                        DirectCast(Me.GroupBox10.Controls.Item("meter" + (i + 1).ToString), RadDropDownList).SelectedIndex = index

                    Else
                        DirectCast(Me.GroupBox10.Controls.Item("meter" + (i + 1).ToString), RadDropDownList).SelectedIndex = -1
                    End If

                    'Dim lcStatus As String = dt1.Rows(i).Item("LC_Status").ToString
                    If ((dt1.Rows(i).Item("LC_Status").ToString = "1") Or (dt1.Rows(i).Item("LC_Status").ToString = "99")) Then


                        DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Enabled = True
                        DirectCast(Me.GroupBox11.Controls.Item("Islandbay" + (i + 1).ToString), RadDropDownList).Enabled = True
                        DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i + 1).ToString), RadTextBox).Enabled = True
                        DirectCast(Me.GroupBox10.Controls.Item("meter" + (i + 1).ToString), RadDropDownList).Enabled = True
                    Else
                        DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Enabled = False
                        DirectCast(Me.GroupBox11.Controls.Item("Islandbay" + (i + 1).ToString), RadDropDownList).Enabled = False
                        DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i + 1).ToString), RadTextBox).Enabled = False
                        DirectCast(Me.GroupBox10.Controls.Item("meter" + (i + 1).ToString), RadDropDownList).Enabled = False
                    End If


                Next i
                Seal_Total.Text = sealCount.ToString
            Catch ex As Exception

            End Try
            sealEdit = 0
            Timer1.Enabled = False
            RadPageView1.SelectedPage = RadPageViewPage2
            Bsave.Visible = False
            Update.Visible = True
            Cbn11.Focus()
        End If
    End Sub

    Private Sub Seal_Total_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Seal_Total.Leave
        If sealEdit = 0 Then
            'RadButton7_Click(sender, e)
        End If
    End Sub

    Private Sub Seal_Total_TextChange(ByVal sender As Object, ByVal Empty As EventArgs)

    End Sub

    Private Sub RadButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton5.Click

        '----------------------- Check Edit Permission
        If cls_role.ChkEdit = False Then
            Dim DiR As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to edit documents in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = DiR.ToString()
            Exit Sub
        End If
        '----------------------- Check Edit Permission

        Try
            Me.AddOwnedForm(Advisenote_Edit)
            Advisenote_Edit.ShowDialog()
            SelectVLoadingNote()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub EditSeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1xx.ValueChanged
        'SelectVLoadingNote()
    End Sub

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

    Private Sub Product_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TProductBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TProductBindingSource.PositionChanged
        Try
            Dim Product_ID As Integer
            Dim Product_N As String
            Product_ID = TProductBindingSource.Item(TProductBindingSource.Position)("ID").ToString()
            Product_N = TProductBindingSource.Item(TProductBindingSource.Position)("Product_name").ToString()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Bay_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Order_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cbn10_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbn10.Leave
        Try

            End If
            End If

            If (Vdate1 < 30 And Vdate1 > 0) And Chk_DriverLicense Then
                MessageBox.Show("Driver license will expire in : '" & Vdate1.ToString & "' Day", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If (Vdate2 < 30 And Vdate2 > 0) And Chk_DriverTraining Then
                MessageBox.Show("Training license will expire in : '" & Vdate2.ToString & "' Day", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            'AuthorRemark = ""

            Try
                Dim ArrPic() As Byte = TDriverBindingSource.Item(TDriverBindingSource.Position)("DRIVER_PICTURE")
                Dim Ms As MemoryStream = New MemoryStream(ArrPic)
                PictureBox1.Image = Image.FromStream(Ms)
                Ms.Dispose()


            Catch ex As Exception
                PictureBox1.Image = Nothing
            End Try
    End Sub

    Private Sub Preset1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Int(Preset1.Text) > Int(Capacity1.Text) Then
                Preset1.Text = Capacity1.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Int(Preset2.Text) > Int(Capacity2.Text) Then
                Preset2.Text = Capacity2.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Int(Preset3.Text) > Int(Capacity3.Text) Then
                Preset3.Text = Capacity3.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Int(Preset4.Text) > Int(Capacity4.Text) Then
                Preset4.Text = Capacity4.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Int(Preset5.Text) > Int(Capacity5.Text) Then
                Preset5.Text = Capacity5.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Int(Preset6.Text) > Int(Capacity6.Text) Then
                Preset6.Text = Capacity6.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Int(Preset7.Text) > Int(Capacity7.Text) Then
                Preset7.Text = Capacity7.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Int(Preset8.Text) > Int(Capacity8.Text) Then
                Preset8.Text = Capacity8.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Int(Preset9.Text) > Int(Capacity9.Text) Then
                Preset9.Text = Capacity9.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Int(Preset10.Text) > Int(Capacity10.Text) Then
                Preset10.Text = Capacity10.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Preset11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Preset12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Int(Preset12.Text) > Int(Capacity12.Text) Then
                Preset12.Text = Capacity12.Text
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Product_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub ProductList1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ProductID As String = ""
            Dim sql As String
            Dim ProductCount As Integer = 0
            TBAYBindingSource1.DataSource = Nothing
            TBAYBindingSource1.DataMember = Nothing
            Dim Product_ID As Integer = 0
            Product_ID = TProductBindingSource1.Item(TProductBindingSource1.Position)("ID").ToString()

            sql = ""
            sql = "select bay_number,bay_status  from t_bay where bay_status=1 and  bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') Order by bay_number"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "T_bay")

            TBAYBindingSource1.DataSource = MyDataSet
            TBAYBindingSource1.DataMember = "T_bay"
            IslandBay1.DisplayMember = "Bay_number"
            For ProCount As Integer = 0 To TRUCK_COMP_NUM - 1
                If ProductID = "" Then
                    ProductID = "'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                ElseIf DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() <> "" Then
                    ProductID &= ",'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                End If
            Next
            sql = ""
            sql = "select max(ID) as ID from t_Product where Product_code in(" & ProductID & ") Group by ID order by ID"

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
            'For i As Integer = 0 To TRUCK_COMP_NUM - 1
            '    If DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text() <> "" Then
            '        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text = dr(0)("Bay").ToString

            '    End If
            'Next
            If ProductList1.Text = "" Then IslandBay1.SelectedIndex = -1

            dt.Dispose()
            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub AddAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ClearData()
    '    CompClear()
    '    EditType = 0
    '    QLOAD = 0
    '    Status.Enabled = True
    '    CanExit = 0
    '    auto = 0
    '    DO_Type.SelectedIndex = 0
    '    Dim q, s_day, s_month, s_year, sql As String
    '    s_day = Date.Now.Day
    '    s_month = Date.Now.Month
    '    s_year = Date.Now.Year
    '    Cbn9.Text = Format(Date.Now.Date, "dd/MM/yyyy")
    '    Dateedit.Value = Now

    '    Status.SelectedText = "รอเติม"
    '    Status.Enabled = False
    '    Update_by.Text = MAIN.U_NAME

    '    Me.T_DRIVERTableAdapter1.Fill(Me.DataSet_Table.T_DRIVER)
    '    Try
    '        Dim yearthai As String

    '        q = ""
    '        q = "select Isnull(max(Load_id),0)+1 as load_id ,Isnull(max(Reference),0)+1 as Reference  from T_loadingnote"

    '        Dim tmp As DataTable = cls.Query(q)

    '        Cbn6.Text = tmp(0)("Load_id")
    '        Cbn8.Text = tmp(0)("Reference")
    '        Cbn11.Focus()
    '        'RadPageView1.SelectedPage = RadPageViewPage2
    '        Dim DriverName, truck As String
    '        Try
    '            Load_q.Text = RadGridView1.CurrentRow.Cells("Q_NO").Value.ToString
    '            Checkin_ID = RadGridView1.CurrentRow.Cells("ID").Value.ToString
    '        Catch ex As Exception
    '            MessageBox.Show("กรุณาเลือกคิวที่ต้องการ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Exit Sub
    '        End Try
    '        Timer1.Enabled = False
    '        RadPageView1.SelectedPage = RadPageViewPage2
    '        yearthai = Str(Int(s_year + 543))
    '        sql = ""
    '        sql = "select  Isnull(max(LOAD_DID),0)+1 as LOAD_DID from T_LOADINGNOTE "
    '        sql &= " where LOAD_DAY=" + s_day + " and LOAD_MONTH =" + s_month + " and LOAD_YEAR=" + yearthai + ""

    '        tmp = cls.Query(sql)

    '        Cbn7.Text = tmp(0)("Load_DID").ToString

    '        If Cbn7.Text = "" Then
    '            'Dim sql As String
    '            sql = ""
    '            sql = "select Q_NO+1 as Q_NO from T_Q "

    '            tmp = cls.Query(sql)

    '            Load_q.Text = tmp(0)("Q_NO").ToString
    '            QLOAD = 1
    '        End If

    '        truck = RadGridView1.CurrentRow.Cells("Truck_number").Value.ToString

    '        Try
    '            DriverName = RadGridView1.CurrentRow.Cells("Driver_id").Value.ToString
    '            TDriverBindingSource.Position = TDriverBindingSource.Find("ID", DriverName.ToString)
    '        Catch ex As Exception
    '            Driver.SelectedIndex = -1
    '        End Try
    '        TTRUCKBindingSource1.Position = TTRUCKBindingSource1.Find("Truck_number", truck.ToString)

    '        Cbn2.SelectedIndex = TTRUCKBindingSource1.Position
    '        Cbn2_Leave(sender, e)
    '        Bsave.Visible = True
    '        Update.Visible = False
    '        Dim Ttype As String

    '        q = "Select TRUCK_TYPE from T_truck where TRUCK_NUMBER= '" & (Cbn2.Text) & "'"

    '        tmp = cls.Query(q)

    '        Ttype = tmp(0)("TRUCK_TYPE")

    '        If Ttype = "1003" Then
    '            TruckH.Enabled = True
    '            TruckH.Focus()
    '        Else
    '            Cbn11.Focus()
    '        End If

    '    Catch ex As Exception
    '        Timer1.Enabled = True
    '        RadPageView1.SelectedPage = RadPageViewPage1
    '    End Try
    'End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.VCHECKINLOAD1TableAdapter.Fill(Me.IRPCDataset.VCHECKINLOAD1)
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        SelectVLoadingNote()
    End Sub

    'Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    '----------------------- Check Delete Permission
    '    If cls_role.ChkDel = False Then
    '        Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to delete documents in this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
    '        Me.Text = ds.ToString()
    '        Exit Sub
    '    End If
    '    '----------------------- Check Delete Permission

    '    Dim ref As String
    '    ref = RadGridView1.CurrentRow.Cells("Q_NO").Value.ToString
    '    If MsgBox("Do you want cancel queue no.: " + ref + " ?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then
    '        Dim sql As String

    '        sql = ""
    '        sql = "Update t_checkin set status=0,load_id='',load_type=0,CALL_ACTUAL=0 where ID='" & VCheckinBindingSource.Item(VCheckinBindingSource.Position)("ID").ToString & "'"

    '        cls.Update(sql)
    '    End If
    '    'Me.VCHECKINLOAD1TableAdapter.Fill(Me.IRPCDataset.VCHECKINLOAD1)
    'End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        Canceldata_Click(sender, e)

    End Sub

    Private Sub Order_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

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


    Private Sub ProductList3_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ProductID As String = ""
            Dim sql As String
            Dim ProductCount As Integer = 0

            TBAYBindingSource3.DataSource = Nothing
            TBAYBindingSource3.DataMember = Nothing
            Dim Product_ID As Integer = 0
            Product_ID = TProductBindingSource3.Item(TProductBindingSource3.Position)("ID").ToString()

            sql = ""
            sql = "select bay_number,bay_status  from t_bay where bay_status=1 and  bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') Order by bay_number"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "T_bay")

            TBAYBindingSource3.DataSource = MyDataSet
            TBAYBindingSource3.DataMember = "T_bay"
            IslandBay3.DisplayMember = "Bay_number"
            For ProCount As Integer = 0 To TRUCK_COMP_NUM - 1
                If ProductID = "" Then
                    ProductID = "'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                ElseIf DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() <> "" Then
                    ProductID &= ",'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                End If
            Next
            sql = ""
            sql = "select max(ID) as ID from t_Product where Product_code in(" & ProductID & ") Group by ID order by ID"

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
            'For i As Integer = 0 To TRUCK_COMP_NUM - 1
            '    If DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text() <> "" Then
            '        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text = dr(0)("Bay").ToString
            '    End If
            'Next
            If ProductList3.Text = "" Then IslandBay3.SelectedIndex = -1
            dt.Dispose()
            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProductList4_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ProductID As String = ""
            Dim sql As String
            Dim ProductCount As Integer = 0

            TBayBindingSource4.DataSource = Nothing
            TBayBindingSource4.DataMember = Nothing
            Dim Product_ID As Integer = 0
            Product_ID = TProductBindingSource4.Item(TProductBindingSource4.Position)("ID").ToString()

            sql = ""
            sql = "select bay_number,bay_status  from t_bay where bay_status=1 and bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') Order by bay_number"


            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "T_bay")

            TBayBindingSource4.DataSource = MyDataSet
            TBayBindingSource4.DataMember = "T_bay"
            IslandBay4.DisplayMember = "Bay_number"
            For ProCount As Integer = 0 To TRUCK_COMP_NUM - 1
                If ProductID = "" Then
                    ProductID = "'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                ElseIf DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() <> "" Then
                    ProductID &= ",'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                End If
            Next
            sql = ""
            sql = "select max(ID) as ID from t_Product where Product_code in(" & ProductID & ") Group by ID order by ID"
            'Dim da1 As OracleDataAdapter = New OracleDataAdapter(sql, conn)

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
            'For i As Integer = 0 To TRUCK_COMP_NUM - 1
            '    If DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text() <> "" Then
            '        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text = dr(0)("Bay").ToString
            '    End If
            'Next
            If ProductList4.Text = "" Then IslandBay4.SelectedIndex = -1
            dt.Dispose()
            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProductList2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ProductID As String = ""
        Dim sql As String
        Dim ProductCount As Integer = 0

        TBAYBindingSource2.DataSource = Nothing
        TBAYBindingSource2.DataMember = Nothing
        Dim Product_ID As Integer = 0
        Product_ID = TProductBindingSource2.Item(TProductBindingSource2.Position)("ID").ToString()

        sql = ""
        sql = "select bay_number,bay_status from t_bay where bay_status=1 and  bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
        sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
        sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
        sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
        sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
        sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
        sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
        sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
        sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "

        MyDataSet = cls.Query_DS(sql, "T_bay")

        TBAYBindingSource2.DataSource = MyDataSet
        TBAYBindingSource2.DataMember = "T_bay"
        IslandBay2.DisplayMember = "Bay_number"
        For ProCount As Integer = 0 To TRUCK_COMP_NUM - 1
            If ProductID = "" Then
                ProductID = "'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
            ElseIf DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() <> "" Then
                ProductID &= ",'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
            End If
        Next
        sql = ""
        sql = "select max(ID) as ID from t_Product where Product_code in(" & ProductID & ") Group by ID order by ID"
        'Dim da1 As OracleDataAdapter = New OracleDataAdapter(sql, conn)

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
        'For i As Integer = 0 To TRUCK_COMP_NUM - 1
        '    If DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text() <> "" Then
        '        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text = dr(0)("Bay").ToString
        '    End If
        'Next
        If ProductList2.Text = "" Then IslandBay2.SelectedIndex = -1
        dt.Dispose()
        MyDataSet.Dispose()
    End Sub

    Private Sub ProductList5_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ProductID As String = ""
            Dim sql As String
            Dim ProductCount As Integer = 0

            TBayBindingSource5.DataSource = Nothing
            TBayBindingSource5.DataMember = Nothing
            Dim Product_ID As Integer = 0
            Product_ID = TProductBindingSource5.Item(TProductBindingSource5.Position)("ID").ToString()

            sql = ""
            sql = "select bay_number,bay_status  from t_bay where bay_status=1 and  bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') Order by bay_number"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "T_bay")

            TBayBindingSource5.DataSource = MyDataSet
            TBayBindingSource5.DataMember = "T_bay"
            IslandBay5.DisplayMember = "Bay_number"
            For ProCount As Integer = 0 To TRUCK_COMP_NUM - 1
                If ProductID = "" Then
                    ProductID = "'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                ElseIf DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() <> "" Then
                    ProductID &= ",'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                End If
            Next
            sql = ""
            sql = "select max(ID) as ID from t_Product where Product_code in(" & ProductID & ") Group by ID order by ID"

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
            'For i As Integer = 0 To TRUCK_COMP_NUM - 1
            '    If DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text() <> "" Then
            '        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text = dr(0)("Bay").ToString
            '    End If
            'Next
            If ProductList5.Text = "" Then IslandBay5.SelectedIndex = -1
            dt.Dispose()
            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProductList6_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ProductID As String = ""
            Dim sql As String
            Dim ProductCount As Integer = 0

            TBayBindingSource6.DataSource = Nothing
            TBayBindingSource6.DataMember = Nothing
            Dim Product_ID As Integer = 0
            Product_ID = TProductBindingSource6.Item(TProductBindingSource6.Position)("ID").ToString()

            sql = ""
            sql = "select bay_number,bay_status  from t_bay where bay_status=1 and  bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') Order by bay_number"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "T_bay")

            TBayBindingSource6.DataSource = MyDataSet
            TBayBindingSource6.DataMember = "T_bay"
            IslandBay6.DisplayMember = "Bay_number"
            For ProCount As Integer = 0 To TRUCK_COMP_NUM - 1
                If ProductID = "" Then
                    ProductID = "'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                ElseIf DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() <> "" Then
                    ProductID &= ",'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                End If
            Next
            sql = ""
            sql = "select max(ID) as ID from t_Product where Product_code in(" & ProductID & ") Group by ID order by ID"

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
            'For i As Integer = 0 To TRUCK_COMP_NUM - 1
            '    If DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text() <> "" Then
            '        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text = dr(0)("Bay").ToString
            '    End If
            'Next
            If ProductList6.Text = "" Then IslandBay6.SelectedIndex = -1
            dt.Dispose()
            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProductList7_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ProductID As String = ""
            Dim sql As String
            Dim ProductCount As Integer = 0

            TBayBindingSource7.DataSource = Nothing
            TBayBindingSource7.DataMember = Nothing
            Dim Product_ID As Integer = 0
            Product_ID = TProductBindingSource7.Item(TProductBindingSource7.Position)("ID").ToString()

            sql = ""
            sql = "select bay_number,bay_status  from t_bay where bay_status=1 and  bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') Order by bay_number"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "T_bay")

            TBayBindingSource7.DataSource = MyDataSet
            TBayBindingSource7.DataMember = "T_bay"
            IslandBay7.DisplayMember = "Bay_number"
            For ProCount As Integer = 0 To TRUCK_COMP_NUM - 1
                If ProductID = "" Then
                    ProductID = "'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                ElseIf DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() <> "" Then
                    ProductID &= ",'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                End If
            Next
            sql = ""
            sql = "select max(ID) as ID from t_Product where Product_code in(" & ProductID & ") Group by ID order by ID"

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
            'For i As Integer = 0 To TRUCK_COMP_NUM - 1
            '    If DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text() <> "" Then
            '        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text = dr(0)("Bay").ToString
            '    End If
            'Next
            If ProductList7.Text = "" Then IslandBay7.SelectedIndex = -1
            dt.Dispose()
            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProductList8_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ProductID As String = ""
            Dim sql As String
            Dim ProductCount As Integer = 0

            TBayBindingSource8.DataSource = Nothing
            TBayBindingSource8.DataMember = Nothing
            Dim Product_ID As Integer = 0
            Product_ID = TProductBindingSource8.Item(TProductBindingSource8.Position)("ID").ToString()

            sql = ""
            sql = "select bay_number,bay_status  from t_bay where bay_status=1 and  bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') Order by bay_number"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "T_bay")

            TBayBindingSource8.DataSource = MyDataSet
            TBayBindingSource8.DataMember = "T_bay"
            IslandBay8.DisplayMember = "Bay_number"
            For ProCount As Integer = 0 To TRUCK_COMP_NUM - 1
                If ProductID = "" Then
                    ProductID = "'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                ElseIf DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() <> "" Then
                    ProductID &= ",'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                End If
            Next
            sql = ""
            sql = "select max(ID) as ID from t_Product where Product_code in(" & ProductID & ") Group by ID order by ID"

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
            'For i As Integer = 0 To TRUCK_COMP_NUM - 1
            '    If DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text() <> "" Then
            '        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text = dr(0)("Bay").ToString
            '    End If
            'Next
            If ProductList8.Text = "" Then IslandBay8.SelectedIndex = -1
            dt.Dispose()
            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProductList9_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ProductID As String = ""
            Dim sql As String
            Dim ProductCount As Integer = 0

            TBayBindingSource9.DataSource = Nothing
            TBayBindingSource9.DataMember = Nothing
            Dim Product_ID As Integer = 0
            Product_ID = TProductBindingSource9.Item(TProductBindingSource9.Position)("ID").ToString()

            sql = ""
            sql = "select bay_number,bay_status  from t_bay where bay_status=1 and  bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') Order by bay_number"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "T_bay")

            TBayBindingSource9.DataSource = MyDataSet
            TBayBindingSource9.DataMember = "T_bay"
            IslandBay9.DisplayMember = "Bay_number"
            For ProCount As Integer = 0 To TRUCK_COMP_NUM - 1
                If ProductID = "" Then
                    ProductID = "'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                ElseIf DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() <> "" Then
                    ProductID &= ",'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                End If
            Next
            sql = ""
            sql = "select max(ID) as ID from t_Product where Product_code in(" & ProductID & ") Group by ID order by ID"

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
            'For i As Integer = 0 To TRUCK_COMP_NUM - 1
            '    If DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text() <> "" Then
            '        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text = dr(0)("Bay").ToString
            '    End If
            'Next
            If ProductList9.Text = "" Then IslandBay9.SelectedIndex = -1
            dt.Dispose()
            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProductList10_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ProductID As String = ""
            Dim sql As String
            Dim ProductCount As Integer = 0

            TBayBindingSource10.DataSource = Nothing
            TBayBindingSource10.DataMember = Nothing
            Dim Product_ID As Integer = 0
            Product_ID = TProductBindingSource10.Item(TProductBindingSource10.Position)("ID").ToString()

            sql = ""
            sql = "select bay_number,bay_status  from t_bay where bay_status=1 and  bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') Order by bay_number"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "T_bay")

            TBayBindingSource10.DataSource = MyDataSet
            TBayBindingSource10.DataMember = "T_bay"
            IslandBay10.DisplayMember = "Bay_number"
            For ProCount As Integer = 0 To TRUCK_COMP_NUM - 1
                If ProductID = "" Then
                    ProductID = "'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                ElseIf DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() <> "" Then
                    ProductID &= ",'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                End If
            Next
            sql = ""
            sql = "select max(ID) as ID from t_Product where Product_code in(" & ProductID & ") Group by ID order by ID"

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

            'For i As Integer = 0 To TRUCK_COMP_NUM - 1
            '    If DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text() <> "" Then
            '        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text = dr(0)("Bay").ToString
            '    End If
            'Next
            If ProductList10.Text = "" Then IslandBay10.SelectedIndex = -1
            dt.Dispose()
            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProductList11_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ProductID As String = ""
            Dim sql As String
            Dim ProductCount As Integer = 0

            TBayBindingSource11.DataSource = Nothing
            TBayBindingSource11.DataMember = Nothing
            Dim Product_ID As Integer = 0
            Product_ID = TProductBindingSource11.Item(TProductBindingSource11.Position)("ID").ToString()

            sql = ""
            sql = "select bay_number,bay_status  from t_bay where bay_status=1 and  bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') Order by bay_number"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "T_bay")

            TBayBindingSource11.DataSource = MyDataSet
            TBayBindingSource11.DataMember = "T_bay"
            IslandBay11.DisplayMember = "Bay_number"
            For ProCount As Integer = 0 To TRUCK_COMP_NUM - 1
                If ProductID = "" Then
                    ProductID = "'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                ElseIf DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() <> "" Then
                    ProductID &= ",'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                End If
            Next
            sql = ""
            sql = "select max(ID) as ID from t_Product where Product_code in(" & ProductID & ") Group by ID order by ID"

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
            'For i As Integer = 0 To TRUCK_COMP_NUM - 1
            '    If DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text() <> "" Then
            '        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text = dr(0)("Bay").ToString
            '    End If
            'Next
            If ProductList11.Text = "" Then IslandBay11.SelectedIndex = -1

            dt.Dispose()
            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProductList12_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ProductID As String = ""
            Dim sql As String
            Dim ProductCount As Integer = 0

            TBayBindingSource12.DataSource = Nothing
            TBayBindingSource12.DataMember = Nothing
            Dim Product_ID As Integer = 0
            Product_ID = TProductBindingSource12.Item(TProductBindingSource12.Position)("ID").ToString()

            sql = ""
            sql = "select bay_number,bay_status  from t_bay where bay_status=1 and  bay_meter1 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= " bay_meter2 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter3 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter4 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter5 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter6 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter7 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter8 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter9 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') or "
            sql &= "bay_meter10 in(select batch_number from t_batchmeter where batch_pro='" & Product_ID & "' and batch_Status='10') Order by bay_number"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "T_bay")

            TBayBindingSource12.DataSource = MyDataSet
            TBayBindingSource12.DataMember = "T_bay"
            IslandBay12.DisplayMember = "Bay_number"
            For ProCount As Integer = 0 To TRUCK_COMP_NUM - 1
                If ProductID = "" Then
                    ProductID = "'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                ElseIf DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() <> "" Then
                    ProductID &= ",'" & DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (ProCount + 1).ToString), RadDropDownList).Text() & "'"
                End If
            Next
            sql = ""
            sql = "select max(ID) as ID from t_Product where Product_code in(" & ProductID & ") Group by ID order by ID"

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
            'For i As Integer = 0 To TRUCK_COMP_NUM - 1
            '    If DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (i + 1).ToString), RadDropDownList).Text() <> "" Then
            '        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" + (i + 1).ToString), RadDropDownList).Text = dr(0)("Bay").ToString
            '    End If
            'Next
            If ProductList12.Text = "" Then IslandBay12.SelectedIndex = -1
            dt.Dispose()
            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        SelectVLoadingNote()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2xx.ValueChanged
        'SelectVLoadingNote()
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
                Dim LenStr As Integer = Len(Seal_Func02(1))
                For ii = CDec(Strings.Right(Seal_Func02(0), LenStr)) To CDec(Seal_Func02(1))
                    Seal_NumberForCount.Add(ii.ToString)
                Next
            Else
                Seal_NumberForCount.Add(Seal_Func01(i))
            End If
        Next

        Seal_Total.Text = Seal_NumberForCount.Count
    End Sub

#Region "Select_Bay"
    Private Sub IslandBay1_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
        Try
            Dim sqlcmd As String = "select * from t_batchmeter where batch_status=10 order by batch_name"
            Dim dt As DataTable = cls.Query(sqlcmd)
            TBatchmeterBindingSource1.DataSource = dt
            TBatchmeterBindingSource1.Filter = "batch_bay=" & TBAYBindingSource1.Item(TBAYBindingSource1.Position)("Bay_Number").ToString()
            Meter1.DisplayMember = "BATCH_NAME"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IslandBay2_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
        Try
            Dim sqlcmd As String = "select * from t_batchmeter where batch_status=10 order by batch_name"
            Dim dt As DataTable = cls.Query(sqlcmd)
            TBatchmeterBindingSource2.DataSource = dt
            TBatchmeterBindingSource2.Filter = "batch_bay=" & TBAYBindingSource2.Item(TBAYBindingSource2.Position)("Bay_Number").ToString()
            Meter2.DisplayMember = "BATCH_NAME"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IslandBay3_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
        Try
            TBatchmeterBindingSource3.Filter = "batch_bay=" & TBAYBindingSource3.Item(TBAYBindingSource3.Position)("Bay_Number").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IslandBay4_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
        Try
            TBatchmeterBindingSource4.Filter = "batch_bay=" & TBayBindingSource4.Item(TBayBindingSource4.Position)("Bay_Number").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IslandBay5_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
        Try
            TBatchmeterBindingSource5.Filter = "batch_bay=" & TBayBindingSource5.Item(TBayBindingSource5.Position)("Bay_Number").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IslandBay6_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
        Try
            TBatchmeterBindingSource6.Filter = "batch_bay=" & TBayBindingSource6.Item(TBayBindingSource6.Position)("Bay_Number").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IslandBay7_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
        Try
            TBatchmeterBindingSource7.Filter = "batch_bay=" & TBayBindingSource7.Item(TBayBindingSource7.Position)("Bay_Number").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IslandBay8_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
        Try
            TBatchmeterBindingSource8.Filter = "batch_bay=" & TBayBindingSource8.Item(TBayBindingSource8.Position)("Bay_Number").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IslandBay9_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
        Try
            TBatchmeterBindingSource9.Filter = "batch_bay=" & TBayBindingSource9.Item(TBayBindingSource9.Position)("Bay_Number").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IslandBay10_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
        Try
            TBatchmeterBindingSource10.Filter = "batch_bay=" & TBayBindingSource10.Item(TBayBindingSource10.Position)("Bay_Number").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IslandBay11_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
        Try
            TBatchmeterBindingSource11.Filter = "batch_bay=" & TBayBindingSource11.Item(TBayBindingSource11.Position)("Bay_Number").ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IslandBay12_SelectedIndexChanged(sender As Object, e As UI.Data.PositionChangedEventArgs)
        Try
            TBatchmeterBindingSource12.Filter = "batch_bay=" & TBayBindingSource12.Item(TBayBindingSource12.Position)("Bay_Number").ToString()
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub Cbn2_SelectedValueChanged(sender As Object, e As EventArgs)
        If Cbn2.Text = "" Then Exit Sub
        Dim pri As String = "555"
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Memory = New MemoryManagement.Manage
            Memory.FlushMemory()
            'Me.VCHECKINLOAD1TableAdapter.Fill(Me.IRPCDataset.VCHECKINLOAD1)
            SelectVLoadingNote()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Bay_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Meter.SelectedIndex = -1
            Dim Bay_Number, Product_ID As Integer
            Dim Sql As String

            Bay_Number = TBayBindingSource.Item(TBayBindingSource.Position)("Bay_Number").ToString()
            Product_ID = TProductBindingSource.Item(TProductBindingSource.Position)("ID").ToString()
            Sql = ""
            Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

            TBatchmeterBindingSource.DataSource = MyDataSet
            TBatchmeterBindingSource.DataMember = "T_batchmeter"
            MyDataSet.Dispose()
            'TBatchmeterBindingSource.Position = 0
            Meter.SelectedIndex = 0

        Catch ex As Exception
        End Try
    End Sub

    Private Sub IslandBay1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EditType = 0 And baycheck = 1 Then
            Try
                Meter1.SelectedIndex = -1

                Dim Bay_Number, Product_ID As Integer
                Dim Sql As String

                Bay_Number = TBAYBindingSource1.Item(TBAYBindingSource1.Position)("Bay_Number").ToString()
                Bay_Number = IslandBay1.Text
                Product_ID = TProductBindingSource1.Item(TProductBindingSource1.Position)("ID").ToString()
                Sql = ""
                Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

                TBatchmeterBindingSource1.DataSource = MyDataSet
                TBatchmeterBindingSource1.DataMember = "T_batchmeter"
                MyDataSet.Dispose()
                'TBatchmeterBindingSource.Position = 0
                Meter1.SelectedIndex = 0
            Catch ex As Exception
                Meter1.Text = ""
            End Try
        End If
    End Sub

    Private Sub IslandBay2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (EditType = 0 And baycheck = 1) Then
            Try
                Meter2.SelectedIndex = -1

                Dim Bay_Number, Product_ID As Integer
                Dim Sql As String

                Bay_Number = TBAYBindingSource2.Item(TBAYBindingSource2.Position)("Bay_Number").ToString()
                Bay_Number = IslandBay2.Text

                Product_ID = TProductBindingSource2.Item(TProductBindingSource2.Position)("ID").ToString()
                Sql = ""
                Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

                TBatchmeterBindingSource2.DataSource = MyDataSet
                TBatchmeterBindingSource2.DataMember = "T_batchmeter"
                MyDataSet.Dispose()
                'TBatchmeterBindingSource.Position = 0
                Meter2.SelectedIndex = 0
            Catch ex As Exception
                Meter2.Text = ""
            End Try
        End If
    End Sub

    Private Sub IslandBay3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EditType = 0 And baycheck = 1 Then
            Try
                Meter3.SelectedIndex = -1

                Dim Bay_Number, Product_ID As Integer
                Dim Sql As String

                Bay_Number = TBAYBindingSource3.Item(TBAYBindingSource3.Position)("Bay_Number").ToString()
                Bay_Number = IslandBay3.Text

                Product_ID = TProductBindingSource3.Item(TProductBindingSource3.Position)("ID").ToString()
                Sql = ""
                Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

                TBatchmeterBindingSource3.DataSource = MyDataSet
                TBatchmeterBindingSource3.DataMember = "T_batchmeter"
                MyDataSet.Dispose()
                'TBatchmeterBindingSource.Position = 0
                Meter3.SelectedIndex = 0
            Catch ex As Exception
                Meter3.Text = ""
            End Try
        End If
    End Sub

    Private Sub IslandBay4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EditType = 0 And baycheck = 1 Then
            Try
                Meter4.SelectedIndex = -1

                Dim Bay_Number, Product_ID As Integer
                Dim Sql As String

                Bay_Number = TBayBindingSource4.Item(TBayBindingSource4.Position)("Bay_Number").ToString()
                Bay_Number = IslandBay4.Text

                Product_ID = TProductBindingSource4.Item(TProductBindingSource4.Position)("ID").ToString()
                Sql = ""
                Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

                TBatchmeterBindingSource4.DataSource = MyDataSet
                TBatchmeterBindingSource4.DataMember = "T_batchmeter"
                MyDataSet.Dispose()
                'TBatchmeterBindingSource.Position = 0
                Meter4.SelectedIndex = 0
            Catch ex As Exception
                Meter4.Text = ""
            End Try
        End If
    End Sub

    Private Sub IslandBay5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EditType = 0 And baycheck = 1 Then
            Try
                Meter5.SelectedIndex = -1

                Dim Bay_Number, Product_ID As Integer
                Dim Sql As String

                Bay_Number = TBayBindingSource5.Item(TBayBindingSource5.Position)("Bay_Number").ToString()
                Bay_Number = IslandBay5.Text

                Product_ID = TProductBindingSource5.Item(TProductBindingSource5.Position)("ID").ToString()
                Sql = ""
                Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

                TBatchmeterBindingSource5.DataSource = MyDataSet
                TBatchmeterBindingSource5.DataMember = "T_batchmeter"
                MyDataSet.Dispose()
                'TBatchmeterBindingSource.Position = 0
                Meter5.SelectedIndex = 0
            Catch ex As Exception
                Meter5.Text = ""
            End Try
        End If
    End Sub

    Private Sub IslandBay6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EditType = 0 And baycheck = 1 Then
            Try
                Meter6.SelectedIndex = -1

                Dim Bay_Number, Product_ID As Integer
                Dim Sql As String

                Bay_Number = TBayBindingSource6.Item(TBayBindingSource6.Position)("Bay_Number").ToString()
                Bay_Number = IslandBay6.Text

                Product_ID = TProductBindingSource6.Item(TProductBindingSource6.Position)("ID").ToString()
                Sql = ""
                Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

                TBatchmeterBindingSource6.DataSource = MyDataSet
                TBatchmeterBindingSource6.DataMember = "T_batchmeter"
                MyDataSet.Dispose()
                'TBatchmeterBindingSource.Position = 0
                Meter6.SelectedIndex = 0
            Catch ex As Exception
                Meter6.Text = ""
            End Try
        End If
    End Sub

    Private Sub IslandBay7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EditType = 0 And baycheck = 1 Then
            Try
                Meter7.SelectedIndex = -1

                Dim Bay_Number, Product_ID As Integer
                Dim Sql As String

                Bay_Number = TBayBindingSource7.Item(TBayBindingSource7.Position)("Bay_Number").ToString()
                Bay_Number = IslandBay7.Text

                Product_ID = TProductBindingSource7.Item(TProductBindingSource7.Position)("ID").ToString()
                Sql = ""
                Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

                TBatchmeterBindingSource7.DataSource = MyDataSet
                TBatchmeterBindingSource7.DataMember = "T_batchmeter"
                MyDataSet.Dispose()
                'TBatchmeterBindingSource.Position = 0
                Meter7.SelectedIndex = 0
            Catch ex As Exception
                Meter7.Text = ""
            End Try
        End If
    End Sub

    Private Sub IslandBay8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EditType = 0 And baycheck = 1 Then
            Try
                Meter8.SelectedIndex = -1

                Dim Bay_Number, Product_ID As Integer
                Dim Sql As String

                Bay_Number = TBayBindingSource8.Item(TBayBindingSource8.Position)("Bay_Number").ToString()
                Bay_Number = IslandBay8.Text

                Product_ID = TProductBindingSource8.Item(TProductBindingSource8.Position)("ID").ToString()
                Sql = ""
                Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

                TBatchmeterBindingSource8.DataSource = MyDataSet
                TBatchmeterBindingSource8.DataMember = "T_batchmeter"
                MyDataSet.Dispose()
                'TBatchmeterBindingSource.Position = 0
                Meter8.SelectedIndex = 0
            Catch ex As Exception
                Meter8.Text = ""
            End Try
        End If
    End Sub

    Private Sub IslandBay9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EditType = 0 And baycheck = 1 Then
            Try
                Meter9.SelectedIndex = -1

                Dim Bay_Number, Product_ID As Integer
                Dim Sql As String

                Bay_Number = TBayBindingSource9.Item(TBayBindingSource9.Position)("Bay_Number").ToString()
                Bay_Number = IslandBay9.Text

                Product_ID = TProductBindingSource9.Item(TProductBindingSource9.Position)("ID").ToString()
                Sql = ""
                Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

                TBatchmeterBindingSource9.DataSource = MyDataSet
                TBatchmeterBindingSource9.DataMember = "T_batchmeter"
                MyDataSet.Dispose()
                'TBatchmeterBindingSource.Position = 0
                Meter9.SelectedIndex = 0
            Catch ex As Exception
                Meter9.Text = ""
            End Try
        End If
    End Sub

    Private Sub IslandBay10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EditType = 0 And baycheck = 1 Then
            Try
                Meter10.SelectedIndex = -1

                Dim Bay_Number, Product_ID As Integer
                Dim Sql As String

                Bay_Number = TBayBindingSource10.Item(TBayBindingSource10.Position)("Bay_Number").ToString()
                Bay_Number = IslandBay10.Text

                Product_ID = TProductBindingSource10.Item(TProductBindingSource10.Position)("ID").ToString()
                Sql = ""
                Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

                TBatchmeterBindingSource10.DataSource = MyDataSet
                TBatchmeterBindingSource10.DataMember = "T_batchmeter"
                MyDataSet.Dispose()
                'TBatchmeterBindingSource.Position = 0
                Meter10.SelectedIndex = 0
            Catch ex As Exception
                Meter10.Text = ""
            End Try
        End If
    End Sub

    Private Sub IslandBay11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EditType = 0 And baycheck = 1 Then
            Try
                Meter11.SelectedIndex = -1

                Dim Bay_Number, Product_ID As Integer
                Dim Sql As String

                Bay_Number = TBayBindingSource11.Item(TBayBindingSource11.Position)("Bay_Number").ToString()
                Bay_Number = IslandBay11.Text

                Product_ID = TProductBindingSource11.Item(TProductBindingSource11.Position)("ID").ToString()
                Sql = ""
                Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

                TBatchmeterBindingSource11.DataSource = MyDataSet
                TBatchmeterBindingSource11.DataMember = "T_batchmeter"
                MyDataSet.Dispose()
                'TBatchmeterBindingSource.Position = 0
                Meter11.SelectedIndex = 0
            Catch ex As Exception
                Meter11.Text = ""
            End Try
        End If
    End Sub

    Private Sub IslandBay12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If EditType = 0 And baycheck = 1 Then
            Try
                Meter12.SelectedIndex = -1

                Dim Bay_Number, Product_ID As Integer
                Dim Sql As String

                Bay_Number = TBayBindingSource12.Item(TBayBindingSource12.Position)("Bay_Number").ToString()
                Bay_Number = IslandBay12.Text

                Product_ID = TProductBindingSource12.Item(TProductBindingSource12.Position)("ID").ToString()
                Sql = ""
                Sql = "Select ID,Batch_name from T_batchmeter where Batch_bay='" & Bay_Number & "' and batch_pro='" & Product_ID & "' and Batch_Status=10 Order by Batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(Sql, "T_batchmeter")

                TBatchmeterBindingSource12.DataSource = MyDataSet
                TBatchmeterBindingSource12.DataMember = "T_batchmeter"
                MyDataSet.Dispose()
                'TBatchmeterBindingSource.Position = 0
                Meter12.SelectedIndex = 0
            Catch ex As Exception
                Meter12.Text = ""
            End Try
        End If
    End Sub

End Class

