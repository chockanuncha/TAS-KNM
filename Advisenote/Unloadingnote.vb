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

Public Class Unloadingnote
    Private cls As New Class_SQKDB

    Private MyErrorProvider As New ErrorProviderExtended
    Private TRUCK_COMP_NUM, sum, auto, sealEdit, Chkin, Chkout, Kiosk As Integer
    Private EditType, CanExit As Integer
    Dim Seallast As String

    Dim ProductCom(12) As String
    Private product_Do, Seal_Last, Checkin_ID, Truck_id, Call_Tergets As String
    Private QTIME, Checkintime As DateTime
    Private Property Advisenote As Object
    Public authorizeUser As Integer = 0
    Dim QLOAD As Integer = 0
    Public AuthorRemark, AuthorRemarkDriver As String

    Private Sub Advisenote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Application.ChangeCulture("th-TH")
        'TODO: This line of code loads data into the 'IRPCDataset.VCHECKINLOAD1' table. You can move, or remove it, as needed.
        Me.VCHECKINLOAD1TableAdapter.Fill(Me.IRPCDataset.VCHECKINLOAD1)
        'TODO: This line of code loads data into the 'IRPCDataset.T_COMPANYPARENT' table. You can move, or remove it, as needed.
        Me.T_COMPANYPARENTTableAdapter.Fill(Me.IRPCDataset.T_COMPANYPARENT)
        'TODO: This line of code loads data into the 'IRPCDataset.T_TANK' table. You can move, or remove it, as needed.
        Me.T_TANKTableAdapter.Fill(Me.IRPCDataset.T_TANK)
        'TODO: This line of code loads data into the 'IRPCDataset.V_TRUCK2' table. You can move, or remove it, as needed.
        'Me.V_TRUCK2TableAdapter.Fill(Me.IRPCDataset.V_TRUCK2)


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

        Dim descriptor8 As New FilterDescriptor(TTank.DisplayMember, FilterOperator.StartsWith, String.Empty)
        TTank.EditorControl.FilterDescriptors.Add(descriptor8)
        TTank.DropDownStyle = RadDropDownStyle.DropDown

        Dim descriptor9 As New FilterDescriptor(Shipper.DisplayMember, FilterOperator.StartsWith, String.Empty)
        Shipper.EditorControl.FilterDescriptors.Add(descriptor9)
        Shipper.DropDownStyle = RadDropDownStyle.DropDown

        Me.T_STATUSTableAdapter.Fill(Me.IRPCDataset.T_STATUS)
        'TODO: This line of code loads data into the 'IRPCDataset.T_TRUCKTYPE' table. You can move, or remove it, as needed.
        Me.T_TRUCKTYPETableAdapter.Fill(Me.IRPCDataset.T_TRUCKTYPE)
        'TODO: This line of code loads data into the 'IRPCDataset.T_BATCHMETER' table. You can move, or remove it, as needed.
        Me.T_BATCHMETERTableAdapter.Fill(Me.IRPCDataset.T_BATCHMETER)
        'TODO: This line of code loads data into the 'IRPCDataset.V_TRUCK' table. You can move, or remove it, as needed.
        Me.V_TRUCKTableAdapter.Fill(Me.IRPCDataset.V_TRUCK)

        'TODO: This line of code loads data into the 'IRPCDataset.T_BAY' table. You can move, or remove it, as needed.
        Me.T_BAYTableAdapter.Fill(Me.IRPCDataset.T_BAY)
        'TODO: This line of code loads data into the 'IRPCDataset2.T_PRODUCT' table. You can move, or remove it, as needed.
        Me.T_PRODUCTTableAdapter1.Fill(Me.IRPCDataset.T_PRODUCT)
        'TODO: This line of code loads data into the 'IRPCDataset.T_SHIPPER' table. You can move, or remove it, as needed.
        Me.T_SHIPPERTableAdapter.Fill(Me.IRPCDataset.T_SHIPPER)
        'TODO: This line of code loads data into the 'IRPCDataset.T_COMPANY' table. You can move, or remove it, as needed.
        Me.T_COMPANYTableAdapter.Fill(Me.IRPCDataset.T_COMPANY)
        'TODO: This line of code loads data into the 'IrpcDataset1.T_COMPANY' table. You can move, or remove it, as needed.

        Me.T_CUSTOMERTableAdapter.Fill(Me.IRPCDataset.T_CUSTOMER)
        'Me.T_PRODUCTTableAdapter.Fill(Me.DataSet1.T_PRODUCT)
        Me.T_DRIVERTableAdapter.Fill(Me.IRPCDataset.T_DRIVER)
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
        Try
            Dim sql As String
            sql = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sql)
        Catch ex As Exception
        End Try

        Me.VCHECKINLOAD1TableAdapter.Fill(Me.IRPCDataset.VCHECKINLOAD1)
        QLOAD = 0
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
        CanExit = 0
    End Sub

    Private Sub SelectVLoadingNote()
        Dim q As String

        Try
            q = ""
            q = "SELECT   max(T1.LOAD_CAPACITY) as LOAD_CAPACITY,max(load_q) as load_q,max(T1.Update_by) as Update_by"
            q &= " ,max(T1.LOAD_PRESET) as LOAD_PRESET,max(T1.LOAD_PRESET86F) as LOAD_PRESET86F,max(T1.LOAD_PRESETFINISH) as LOAD_PRESETFINISH, max(T1.LOAD_CARD) as LOAD_CARD"
            q &= " ,max(T2.LC_COMPARTMENT) as LC_COMPARTMENT"
            q &= " ,max(T2.LC_BAY) as LC_BAY,Reference, max(T1.LOAD_DATE) as LOAD_DATE"
            q &= " ,max(T1.LOAD_DID) as LOAD_DID ,max(T_Status.STATUS_NAME) as STATUS_NAME ,max(T1.LOADDO) as LOAD_DOfull ,max(T_TRUCK.TRUCK_NUMBER) as LOAD_VEHICLE ,max(t_customer.Customer_name) as Customer_name "
            q &= " ,max(T_DRIVER.Driver_NAME)|| '  ' || max(T_Driver.Driver_Lastname) AS LOAD_DRIVER"
            q &= " ,max(T1.load_id) as Load_id,max(V_DO.DO_STATUS) as DO_STATUS"
            q &= ",max(t_product.Product_code) as PRODUCT_CODE,max(T_Batchmeter.BATCH_NAME) as BATCH_NAME"
            q &= " ,max(T1.Container) as Container,max(T1.LOAD_TRUCKCOMPANY) as LOAD_TRUCKCOMPANY,max(T_COMPANYPARENT.Company_name) as LOAD_COMPANYPARENT "
            q &= " ,max(LC_SEAL) as LC_SEAL,max(T1.LOAD_SEAL) as LOAD_SEAL,max(T1.LOAD_SEALCOUNT) as LOAD_SEALCOUNT"
            q &= " ,max(T1.ADDNOTEDATE) as ADDNOTEDATE,max(T2.LC_STARTTIME) as LC_STARTTIME,max(T2.LC_ENDTIME) as LC_ENDTIME,max(T1.load_tank) as TANK "
            q &= " ,max(T1.Tank_befor) as TANK_BEFOR,Max(T1.TANK_After) as TANK_AFTER "
            Dim n_year As Integer = 0
            n_year = 543
            q &= "FROM T_Customer  RIGHT OUTER JOIN (Select * from T_unLoadingnote  Where T_unLoadingnote.AddnoteDate between "
            q &= "To_date('" & DateTimePicker1.Value.Year & "/" & DateTimePicker1.Value.Month & "/" & DateTimePicker1.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
            q &= "To_date('" & DateTimePicker2.Value.Year & "/" & DateTimePicker2.Value.Month & "/" & DateTimePicker2.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "

            q &= "And Load_type<>1009 And Load_status in(1,2,3,4)) T1  "
            q &= "ON T_Customer.ID = T1.LOAD_CUSTOMER  "
            q &= "LEFT OUTER JOIN T_STATUS  ON T1.LOAD_STATUS_n = T_STATUS.STATUS_ID   "
            q &= "LEFT OUTER JOIN V_DO ON T1.LOAD_ID = V_DO.LOAD_ID    "
            q &= "LEFT OUTER JOIN T_TRUCK ON T1.LOAD_VEHICLE = T_TRUCK.ID   "
            q &= "LEFT OUTER JOIN T_DRIVER ON T1.LOAD_DRIVER = T_DRIVER.ID   "
            q &= "LEFT OUTER JOIN T_CARD  ON T1.LOAD_CARD = T_CARD.CARD_NUMBER   "
            q &= "LEFT OUTER JOIN T_Product ON T1.LOAD_product = T_Product.ID "
            q &= "LEFT OUTER JOIN T_COMPANYPARENT ON T1.LOAD_COMPANYPARENT = T_COMPANYPARENT.COMPANY_ID "
            q &= "Left OUTER JOIN T_BATCHMETER   "
            q &= "RIGHT OUTER JOIN (Select * From T_unLoadingnoteCOMPARTMENT) T2 "
            q &= "ON T_BATCHMETER.BATCH_NUMBER = T2.LC_METER  ON T1.LOAD_ID = T2.LC_LOAD "
            q &= "group by T1.reference  "
            q &= "order by load_id"

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
        AuthorRemark = ""
        authorize_Remark.Text = AuthorRemark.ToString & AuthorRemarkDriver.ToString
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

            '''''''' Check Override Check in
            Dim q As String

            q = ""
            q = "Select STATUS from t_override where Override_name='CHECK IN'"

            Dim dt99 As DataTable = cls.Query(q)

            Chkin = dt99(0)("STATUS")

            q = ""
            q = "Select STATUS from t_override where Override_name='KIOSK'"

            dt99 = cls.Query(q)

            Kiosk = dt99(0)("STATUS")

            If Chkin = 0 Then
                sql = ""
                sql = "Select * from t_checkin where truck_id='" & VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString() & "'"
                sql &= " and Status in(1) order by ldate desc"

                Dim dt As DataTable = cls.Query(sql)

                If dt.Rows.Count <> 0 Then
                    Checkin_ID = dt.Rows(0).Item("ID").ToString
                    Dim Checkintimes As DateTime = dt.Rows(0).Item("Ldate").ToString
                    Checkintime = Checkintimes.Day & "/" & Checkintimes.Month & "/" & Checkintimes.Year & " " & Checkintimes.Hour & ":" & Checkintimes.Minute & ":" & Checkintimes.Second
                    Dim QTIMEs As Date = dt.Rows(0).Item("Q_DATE").ToString
                    QTIME = QTIME.Day & "/" & QTIME.Month & "/" & QTIME.Year & " " & QTIME.Hour & ":" & QTIME.Minute & ":" & QTIME.Second
                    authorizeUser = 0
                    Dim LoadQ As String
                    LoadQ = dt.Rows(0).Item("Q_NO").ToString
                    Cbn7.Text = LoadQ.ToString
                Else
                    MsgBox("ไม่พบข้อมูลทะเบียนรถคันนี้ ในกระบวนการเช็คอิน", vbOKOnly & vbDefaultButton3, "ตรวจสอบ")
                    If MsgBox("ต้องการ Authorize โดย Supervisor หรือไม่ ?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then
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
            Catch ex As Exception
                Vdate1 = -1
            End Try

            If Vdate1 <= 0 Then
                MessageBox.Show("ประกันภัยของรถหมดอายุกรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If MsgBox("ต้องการ Authorize โดย Supervisor หรือไม่ ?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then
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
            Catch ex As Exception
                Vdate2 = -1
            End Try
            If (Vdate2 <= 0 And Vdate2 >= -10000) Then
                MessageBox.Show("การวัดน้ำของรถหมดอายุกรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If MsgBox("ต้องการ Authorize โดย Supervisor หรือไม่ ?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then
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
            If Vdate3 <= 0 Then
                MessageBox.Show("การตรวจสภาพรถหมดอายุกรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If MsgBox("ต้องการ Authorize โดย Supervisor หรือไม่ ?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then
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


            If Vdate1 < 30 And Vdate1 > 0 Then
                MessageBox.Show("ประกันภัยของรถเหลืออีก : '" & Vdate1.ToString & "' วัน", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If Vdate2 < 30 And Vdate2 > 0 Then
                MessageBox.Show("การวัดน้ำของรถเหลืออีก : '" & Vdate2.ToString & "' วัน", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                Seal_Total.Text = TRUCK_COMP_NUM.ToString
                Seal_Total_Leave(sender, e)
            End If



            Dim TRUCK_CAPASITY As Integer
            Dim q As String

            If Cbn2.SelectedIndex >= 0 Or Cbn2.Text <> "" Then
                q = ""
                q = "select TRUCK_CAPASITY,T_TRUCKCOMPCAP,T_TRUCKCOMPCAP_L from (Select ID,TRUCK_CAPASITY,TRUCK_NUMBER From T_Truck where TRUCK_NUMBER= '" & (Cbn2.Text) & "') T1 "
                q &= "Left Join (Select T_TRUCKID,T_TRUCKCOMPCAP,T_TRUCKCOMPCAP_L From T_Truckcompartment) T2 On T1.ID = T2.T_TRUCKID "

                Dim dt As DataTable = cls.Query(q)

                TRUCK_CAPASITY = dt.Rows(0).Item("TRUCK_CAPASITY").ToString()
                Cbn5.Text = TRUCK_CAPASITY

                RadButton1_Click(sender, e)

                For i = 1 To TRUCK_COMP_NUM
                    Try
                        DirectCast(Me.GroupBox13.Controls.Item("Preset" + (i).ToString), RadTextBox).Text = "0"
                        DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (i).ToString), RadTextBox).Text = dt.Rows(i - 1).Item("T_TRUCKCOMPCAP").ToString()

                    Catch ex As Exception
                        Exit Sub
                    End Try
                Next i
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub ClearData()
        Try
            AuthorRemarkDriver = ""
            AuthorRemark = ""
            Bay.Text = ""
            Bay.SelectedIndex = -1
            Meter.Text = ""
            Meter.SelectedIndex = -1
            EdCustomer.Text = ""
            sealEdit = 0
            DO_Type.SelectedIndex = -1
            Cbn2.Text = ""
            Cbn2.SelectedIndex = -1
            Cbn3.Text = ""
            Cbn3.SelectedIndex = -1
            Shipper.Text = ""
            Shipper.SelectedIndex = -1
            Driver.Text = ""
            Driver.SelectedIndex = -1
            Cbn5.Text = ""
            Cbn7.Text = ""
            Cbn10.Text = ""
            PresetFinish.Text = ""
            TankBefor.Text = ""
            Tankafter.Text = "'"
            TTank.Text = ""
            TTank.SelectedIndex = -1
            authorize_Remark.Text = ""

            Preset86.Text = ""

            Shipper.Text = ""
            Shipper.SelectedIndex = -1
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

            For i = 1 To 12 'dt.Rows.Count - 1
                Try
                    DirectCast(Me.GroupBox12.Controls.Item("Capacity" & (i).ToString), RadTextBox).Text = ""
                    DirectCast(Me.GroupBox15.Controls.Item("Preset" & (i).ToString), RadTextBox).Text = ""
                Catch ex As Exception
                    Exit Sub
                End Try
            Next i
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Try
            MyErrorProvider.ClearAllErrorMessages()
            ClearData()
            CompClear()
            Me.Advisenote_Shown(sender, e)
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
        EditType = 0
        ClearData()
        auto = 0
        QLOAD = 1
        DO_Type.SelectedIndex = 0
        Dim q, s_day, s_month, s_year, s_hr, s_mn, s_sc, TTimes As String
        s_day = Date.Now.Day
        s_month = Date.Now.Month
        s_year = Date.Now.Year
        Cbn9.Text = Format(Date.Now.Date, "dd/MM/yyyy")
        Dateedit.Value = Now

        'Status.SelectedText = "รอเติม"
        Status.SelectedIndex = 0
        Status.Enabled = False
        Update_by.Text = MAIN.U_NAME
        Dim Sql As String
        Dim yearthai As String
        yearthai = Str(Int(s_year & 543))

        Sql = ""
        Sql = "select  NVL(max(LOAD_DID),0)+1 as LOAD_DID from T_unLoadingnote "
        Sql &= " where LOAD_DAY=" & s_day & " and LOAD_MONTH =" & s_month & " and LOAD_YEAR=" & yearthai & ""

        Dim dt As DataTable = cls.Query(Sql)

        Cbn7.Text = dt(0)("LOAD_DID")

        Sql = ""
        Sql = "select Q_NO_unload+1 as Q_NO_unload from T_Q "

        dt = cls.Query(Sql)

        Load_q.Text = dt(0)("Q_NO_unload")
        TankBefor.Text = "0"
        Tankafter.Text = "0"
        Tankloss.Text = "0"

        Try
            q = ""
            q = "select NVL(max(Load_id),0)+1 as load_id ,NVL(max(Reference),0)+1 as Reference  from T_unLoadingnote"

            dt = cls.Query(q)

            Cbn6.Text = dt(0)("Load_id")
            Cbn8.Text = dt(0)("Reference")

            RadPageView1.SelectedPage = RadPageViewPage2
            Cbn11.Focus()
            Bsave.Visible = True
            Update.Visible = False

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
            DirectCast(Me.GroupBox14.Controls.Item("ProductList" & (i).ToString), RadDropDownList).SelectedIndex = -1
            If Comp_Num > 0 Then
                DirectCast(Me.GroupBox15.Controls.Item("Comp" & (i).ToString), RadTextBox).Enabled = True
                DirectCast(Me.GroupBox14.Controls.Item("ProductList" & (i).ToString), RadDropDownList).Enabled = True
                DirectCast(Me.GroupBox13.Controls.Item("Preset" & (i).ToString), RadTextBox).Enabled = True
                DirectCast(Me.GroupBox12.Controls.Item("Capacity" & (i).ToString), RadTextBox).Enabled = True
                DirectCast(Me.GroupBox11.Controls.Item("IslandBay" & (i).ToString), RadDropDownList).Enabled = True
                DirectCast(Me.GroupBox10.Controls.Item("Meter" & (i).ToString), RadDropDownList).Enabled = True

            Else
                DirectCast(Me.GroupBox15.Controls.Item("Comp" & (i).ToString), RadTextBox).Enabled = False
                DirectCast(Me.GroupBox14.Controls.Item("ProductList" & (i).ToString), RadDropDownList).Enabled = False
                DirectCast(Me.GroupBox13.Controls.Item("Preset" & (i).ToString), RadTextBox).Enabled = False
                DirectCast(Me.GroupBox12.Controls.Item("Capacity" & (i).ToString), RadTextBox).Enabled = False
                DirectCast(Me.GroupBox11.Controls.Item("IslandBay" & (i).ToString), RadDropDownList).Enabled = False
                DirectCast(Me.GroupBox10.Controls.Item("Meter" & (i).ToString), RadDropDownList).Enabled = False
            End If
            Comp_Num = Comp_Num - 1
        Next i
    End Sub

    Private Sub CompClear()
        Dim i As Integer = 1
        For i = 1 To 12
            DirectCast(Me.GroupBox14.Controls.Item("ProductList" & (i).ToString), RadDropDownList).SelectedIndex = -1
            DirectCast(Me.GroupBox13.Controls.Item("Preset" & (i).ToString), RadTextBox).Text = ""
            DirectCast(Me.GroupBox12.Controls.Item("Capacity" & (i).ToString), RadTextBox).Text = ""
            DirectCast(Me.GroupBox11.Controls.Item("IslandBay" & (i).ToString), RadDropDownList).SelectedIndex = -1
            DirectCast(Me.GroupBox10.Controls.Item("Meter" & (i).ToString), RadDropDownList).SelectedIndex = -1
            ProductCom(i - 1) = ""
        Next i
        GDetail.Enabled = False
    End Sub


    Private Sub OrderBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderBut.Click
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
            PresetFinish.Text = "0"
            Bayt = Bay.SelectedIndex
            For i = 0 To TRUCK_COMP_NUM - 1
                'If Bayt = -1 Then
                Dim Capa As String
                Capa = DirectCast(Me.GroupBox12.Controls.Item("Capacity" & (i + 1).ToString), RadTextBox).Text
                If (Int(DirectCast(Me.GroupBox12.Controls.Item("Capacity" & (i + 1).ToString), RadTextBox).Text) <= tov) Then
                    DirectCast(Me.GroupBox14.Controls.Item("ProductList" & (i + 1).ToString), RadDropDownList).SelectedIndex = Product.SelectedIndex
                    ProductCom(i) = TProductBindingSource.Item(TProductBindingSource.Position)("Product_code").ToString()

                    BayIndex = Bay.Text
                    Index = DirectCast(Me.GroupBox11.Controls.Item("IslandBay" & (i + 1).ToString), RadDropDownList).FindString(BayIndex)
                    DirectCast(Me.GroupBox11.Controls.Item("IslandBay" & (i + 1).ToString), RadDropDownList).SelectedIndex = Index

                    Batchmeter = Meter.Text
                    Index = DirectCast(Me.GroupBox10.Controls.Item("meter" & (i + 1).ToString), RadDropDownList).FindString(Batchmeter)
                    DirectCast(Me.GroupBox10.Controls.Item("meter" & (i + 1).ToString), RadDropDownList).SelectedIndex = Index

                    DirectCast(Me.GroupBox13.Controls.Item("Preset" & (i + 1).ToString), RadTextBox).Text = DirectCast(Me.GroupBox12.Controls.Item("Capacity" & (i + 1).ToString), RadTextBox).Text
                    tov = tov - Int(DirectCast(Me.GroupBox13.Controls.Item("Preset" & (i + 1).ToString), RadTextBox).Text)
                Else
                    DirectCast(Me.GroupBox13.Controls.Item("Preset" & (i + 1).ToString), RadTextBox).Text = tov

                    If tov <> 0 Then
                        DirectCast(Me.GroupBox14.Controls.Item("ProductList" & (i + 1).ToString), RadDropDownList).SelectedIndex = Product.SelectedIndex
                        ProductCom(i) = TProductBindingSource.Item(TProductBindingSource.Position)("Product_code").ToString()


                        BayIndex = Bay.Text
                        Index = DirectCast(Me.GroupBox11.Controls.Item("IslandBay" & (i + 1).ToString), RadDropDownList).FindString(BayIndex)
                        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" & (i + 1).ToString), RadDropDownList).SelectedIndex = Index
                        Batchmeter = Meter.Text
                        Index = DirectCast(Me.GroupBox10.Controls.Item("meter" & (i + 1).ToString), RadDropDownList).FindString(Batchmeter)
                        DirectCast(Me.GroupBox10.Controls.Item("meter" & (i + 1).ToString), RadDropDownList).SelectedIndex = Index

                    Else
                        DirectCast(Me.GroupBox14.Controls.Item("ProductList" & (i + 1).ToString), RadDropDownList).SelectedIndex = -1 'Product.SelectedIndex
                        ProductCom(i) = ""
                        DirectCast(Me.GroupBox11.Controls.Item("IslandBay" & (i + 1).ToString), RadDropDownList).SelectedIndex = -1 'Bay.SelectedIndex
                        DirectCast(Me.GroupBox10.Controls.Item("Meter" & (i + 1).ToString), RadDropDownList).SelectedIndex = -1 'Meter.SelectedIndex
                    End If
                    tov = tov - Int(DirectCast(Me.GroupBox13.Controls.Item("Preset" & (i + 1).ToString), RadTextBox).Text)
                End If

            Next i
            Gain.Text = "0"
            Gain_TextChanged(sender, e)
        Catch ex As Exception
        End Try
    End Sub

    Private Function Item(ByVal p1 As String) As Object
        Throw New NotImplementedException
    End Function

    Private Sub RadButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton2.Click
        If ProductList1.SelectedIndex = -1 Then
            RadTextBox2.Text = ProductList1.SelectedValue.ToString
        Else
            RadTextBox2.Text = ProductList1.SelectedIndex.ToString
        End If
    End Sub

    Private Sub Printdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Printdata.Click
        Dim ref, sql As String
        ref = MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString

        Dim q As String
        If Default_chk.Checked = True Then
            q = ""
            q = "SELECT * from V_unLOADINGNOTE where load_id='" & ref & "'"

            Dim Myreport As New ReportDocument
            Myreport = New ReportDocument

            Dim ds As New DataSet
            ds = cls.Query_DS(q, "V_Loadingnote")

            Myreport.Load("UnloadingReport.rpt")
            Myreport.SetDataSource(ds)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()
            ds.Dispose()
            Myreport.Close()
        Else
            ref = MasterGridAdvisenote.CurrentRow.Cells("load_id").Value.ToString
            Dim Myreport As New ReportDocument
            Myreport = New ReportDocument
            q = ""
            q = "SELECT * from V_unLOADINGNOTE where load_id='" & ref & "'"

            Dim ds As New DataSet
            ds = cls.Query_DS(q, "V_LOADINGNOTE")

            Myreport.Load("loadnote.rpt")
            Myreport.SetDataSource(ds)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()
            ds.Dispose()
            Myreport.Close()
        End If
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
                Seal_No.Text = "" & SealNumber2(SealDetail) & "" & (SealNumber(SealDetail) + 1).ToString
                Seal_Last = "" & SealNumber2(SealDetail) & "" & (SealNumber(SealDetail) + 1).ToString
                RadTextBox7.Text = Seal_Last
            Else
                Seal_No.Text = "" & SealNumber2(SealDetail) & "" & (SealNumber(SealDetail) + 1).ToString & "" & "-" & (SealNumber(SealDetail) & TRUCK_COMP_NUM).ToString
                Seal_Last = "" & SealNumber2(SealDetail) & "" & (SealNumber(SealDetail) & TRUCK_COMP_NUM).ToString
                RadTextBox7.Text = Seal_Last
            End If
        Else
            If Seal_totalV = 1 Then
                Seal_No.Text = "" & SealNumber2(SealDetail) & "" & (SealNumber(SealDetail) & Seal_totalV).ToString
                Seal_Last = "" & SealNumber2(SealDetail) & "" & (SealNumber(SealDetail) + 1).ToString
                RadTextBox7.Text = Seal_Last
            Else
                Seal_No.Text = "" & SealNumber2(SealDetail) & "" & (SealNumber(SealDetail) + 1).ToString & "" & "-" & (SealNumber(SealDetail) & Seal_totalV).ToString

                Seal_Last = "" & SealNumber2(SealDetail) & "" & (SealNumber(SealDetail) & Seal_totalV).ToString
                RadTextBox7.Text = Seal_Last
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
        OrderBut_Click(sender, e)
        If Cbn11.Text = "" Then
            MessageBox.Show("กรุณาใส่ข้อมูลเลขที่ DO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cbn11.Focus()
            Exit Sub
        End If
        If Cbn2.SelectedIndex = -1 Then
            MessageBox.Show("กรุณาใส่ข้อมูลทะเบียนรถ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cbn2.Focus()
            Exit Sub
        End If
        If Shipper.SelectedIndex = -1 Then
            MessageBox.Show("กรุณาใส่ข้อมูล Shipper", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Shipper.Focus()
            Exit Sub
        End If

        If Cbn10.Text = "" Then
            MessageBox.Show("กรุณาใส่ข้อมูลปริมาณขอเติม", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cbn10.Focus()
            Exit Sub
        End If
        If Preset86.Text = "" Then
            MessageBox.Show("กรุณาใส่ข้อมูลปริมาณยอดตั๋ว@86 F", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Preset86.Focus()
            Exit Sub
        End If

        If Cbn3.SelectedIndex = -1 Then
            MessageBox.Show("กรุณาใส่ข้อมูลต้นทาง", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Cbn3.Focus()
            Exit Sub
        End If
        If Driver.SelectedIndex = -1 Then
            MessageBox.Show("กรุณาใส่ข้อมูลพนักงานขับรถ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Driver.Focus()
            Exit Sub
        End If

        Dim s_day, s_month, s_year, q As String
        s_day = Date.Now.Day
        s_month = Date.Now.Month
        s_year = Date.Now.Year

        q = ""
        q = "select NVL(max(Load_id),0)+1 as load_id ,NVL(max(Reference),0)+1 as Reference  from T_unloadingnote"

        Dim dt As DataTable = cls.Query(q)
        Dim dt_tmp As DataTable

        Cbn6.Text = dt(0)("Load_id")
        Cbn8.Text = dt(0)("Reference")

        Dim sc, sql As String
        Dim i, SL, ST, r, j As Integer

        Dim Card As String

        Update_date.Text = Date.Now
        s_year = Date.Now.Year

        Try
            ''''   ST  '''''''''

            Try
                sql = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
                  & ",USERGROUP='" & MAIN.U_GROUP & "'"

                cls.Update(sql)
            Catch ex As Exception

            End Try

            q = ""
            q = "select NVL(max(ST_ID),0)+1 as ST_ID"
            q &= " from T_ST"

            dt_tmp = cls.Query(q)

            ST = dt_tmp(0)("ST_ID")


            '''''' SC '''''''''''
            q = ""
            q = "select count(load_id) as CLoad_id "
            q &= "from T_unLoadingnote "
            q &= "where to_char(load_date,'DD') = to_char(Sysdate,'DD') "
            q &= "AND  to_char(load_date,'MM') = to_char(Sysdate,'MM') "
            q &= "AND  to_char(load_date,'YY') = to_char(Sysdate,'YY') "
            q &= "AND (ST_ID NOT IN (SELECT st_id FROM t_st))  "

            dt_tmp = cls.Query(q)

            SL = dt_tmp(0)("CLoad_id")
            sc = ST & SL

            '''''''' Insert T_unLoadingnote'''''''''''''''''''
            q = ""
            q = "Insert into T_unLoadingnote "
            q &= " (LOAD_ID,"
            q &= " LOAD_CARD,"
            q &= " LOAD_DID,"
            q &= " LOAD_VEHICLE,"
            q &= " LOAD_STATUS,"
            q &= " LOAD_STATUS_N,"
            q &= " LOAD_CAPACITY,"
            q &= " ST_ID,"
            q &= " LOAD_Shipper,"
            q &= " LOAD_STARTTIME,"
            q &= " AddnoteDate,"
            q &= " LOAD_DRIVER,"
            q &= " LOAD_PRESET,"
            q &= " LOAD_PRESET86f,"

            q &= " Load_presetfinish,"
            q &= " LOAD_DOfull, "
            q &= " LOADDO, "
            q &= " Reference, "
            q &= " Remark, "
            q &= " Load_product, "
            q &= " Container, "
            q &= " LOAD_SEALCOUNT, "
            q &= " Load_customer, "
            q &= " Load_seal, "
            q &= " Update_date, "
            q &= " LOAD_Q, "
            q &= " LOAD_QDASHBOARD, "
            q &= " Q_TIME, "
            q &= " CHECKIN_TIME, "
            'q &= " LOAD_TRUCKCOMPANY, "
            q &= " DO_TYPE, "
            q &= " UPDATE_BY, "
            q &= " LOAD_TANK, "
            q &= " LOAD_COMPANYPARENT,"
            q &= " LOAD_BAY,"
            q &= " LOAD_AUTHORIZE,"
            q &= " LOAD_TEMP,"
            q &= " LOAD_DENSITY,"
            q &= " LOSSGAIN,"
            q &= " LOAD_TOTAL,"

            q &= " LOAD_TYPE )"
            q &= " Values ("
            q &= "'" & (Cbn6.Text) & "'" & ","
            '' LOAD_CARD ''

            Try
                sql = ""
                sql = "select Truck_ID,Card_Number from vcardload "
                sql &= "where Truck_ID= '" & (VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString()) & "'"

                dt_tmp = cls.Query(sql)

                Card = dt_tmp(0)("Card_Number")
                q &= "'" & Card & "'" & ","

            Catch ex As Exception
                q &= "'" & ("0") & "'" & ","
            End Try

            q &= "'" & (Cbn7.Text).ToString & "'" & ","
            q &= "" & (VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString()) & "" & ","
            q &= "'" & (TStatusBindingSource.Item(TStatusBindingSource.Position)("Status_Group").ToString()) & "'" & ","
            q &= "'" & (TStatusBindingSource.Item(TStatusBindingSource.Position)("Status_ID").ToString()) & "'" & ","
            q &= "" & (Cbn5.Text) & "" & ","
            q &= "" & Str(sc) & "" & ","
            q &= "'" & (TShipperBindingSource.Item(TShipperBindingSource.Position)("ID").ToString()) & "'" & ","
            q &= "'" & (Cbn9.Text) & "'" & ","
            'Addnote
            Dim n_year As Integer = 0
            n_year = 543

            q &= "TO_DATE('" & (String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateAdd(DateInterval.Year, -n_year, Dateedit.Value))) & "','DD/MM/YYYY HH24:MI:SS')" & ","
            q &= "'" & (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) & "'" & ","
            q &= "'" & (Cbn10.Text) & "'" & ","
            q &= "'" & (Preset86.Text) & "'" & ","
            q &= "'" & PresetFinish.Text & "',"
            q &= "'" & (Cbn11.Text) & "'" & ","
            q &= "'" & (Cbn11.Text) & "'" & ","
            q &= "'" & (Cbn8.Text) & "'" & ","
            q &= "'" & (Edremark.Text) & "'" & ","
            q &= "'" & (TProductBindingSource.Item(TProductBindingSource.Position)("ID").ToString()) & "'" & ","

            q &= "'" & (Container.Text) & "'" & ","
            q &= "'" & (Seal_Total.Text) & "'" & ","

            q &= "'" & (TCUSTOMERTBindingSource.Item(TCUSTOMERTBindingSource.Position)("ID").ToString()) & "'" & ","
            q &= "'" & (Seal_No.Text) & "'" & ","
            q &= " Sysdate ,"
            q &= "'" & (Load_q.Text) & "'" & ","
            q &= "'" & (Load_q.Text) & "'" & ","
            'q &= "'" & (Cbn7.Text) & "'" & ","

            If Chkin = 0 Then
                q &= "TO_DATE('" & (String.Format("{0:dd/MM/yyyy hh:mm:ss}", QTIME)) & "','DD/MM/YYYY HH24:MI:SS')" & ","
                q &= "TO_DATE('" & (String.Format("{0:dd/MM/yyyy hh:mm:ss}", Checkintime)) & "','DD/MM/YYYY HH24:MI:SS')" & ","
            Else
                q &= " Sysdate ,"
                q &= " Sysdate ,"
            End If

            q &= "'" & (DO_Type.Text).ToString & "'" & ","
            q &= "'" & (Update_by.Text).ToString & "'" & ","
            q &= "'" & (TTankBindingSource.Item(TTankBindingSource.Position)("Tankno").ToString()) & "'" & ","
            q &= "'" & (TCompanyBindingSource.Item(TCompanyBindingSource.Position)("Company_ID").ToString()) & "'" & ","
            q &= "'" & (TBayBindingSource.Item(TBayBindingSource.Position)("BAY_NUMBER").ToString()) & "'" & ","
            q &= "'" & (authorize_Remark.Text) & "'" & ","
            q &= "'" & (load_temp.Text) & "'" & ","
            q &= "'" & (Load_density.Text) & "'" & ","
            q &= "'" & (Gain.Text) & "'" & ","
            q &= "'" & (LoadTotal.Text) & "'" & ","
            q &= "'" & (TTruckTypeBindingSource.Item(TTruckTypeBindingSource.Position)("ID").ToString()) & "'" & ")"

            cls.Insert(q)



            ''''''''' Insert T_unLoadingnoteCompartment
            For r = 0 To TRUCK_COMP_NUM - 1
                q = ""
                q = "Insert into T_unLoadingnoteCOMPARTMENT "
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
                q &= " LC_Density_30C,"
                q &= " LC_METER) "

                q &= "Values ("
                q &= "'" & Cbn6.Text & "'" & ","
                '' LC_COMPARTMENT ''


                Try
                    q &= "'" & (DirectCast(Me.GroupBox15.Controls.Item("Comp" & (r + 1).ToString), RadTextBox).Text) & "'" & ","
                Catch ex As Exception
                    q &= "0" & ","
                End Try
                '' LC_PRO ''
                Try
                    If DirectCast(Me.GroupBox13.Controls.Item("Preset" & (r + 1).ToString), RadTextBox).Text > 0 Then
                        q &= "1" & ","
                    Else
                        q &= "99" & ","
                    End If
                Catch ex As Exception
                    q &= "99" & ","
                End Try
                '' LC_BASE ''

                Try
                    If (DirectCast(Me.GroupBox13.Controls.Item("Preset" & (r + 1).ToString), RadTextBox).Text) <> "" Then
                        q &= "'" & (DirectCast(Me.GroupBox13.Controls.Item("Preset" & (r + 1).ToString), RadTextBox).Text) & "'" & ","
                    Else
                        q &= "0" & ","
                    End If
                Catch ex As Exception
                    q &= "0" & ","
                End Try

                '' LC_BLEND''
                q &= "0" & ","
                '' LC_PRO ''
                Try
                    If (DirectCast(Me.GroupBox14.Controls.Item("ProductList" & (r + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Then
                        q &= "'" & (DirectCast(Me.GroupBox14.Controls.Item("ProductList" & (r + 1).ToString), RadDropDownList).SelectedValue.ToString) & "'" & ","
                    Else
                        q &= "0" & ","
                    End If
                Catch ex As Exception
                    q &= "0" & ","
                End Try

                'q &= "'" & (DirectCast(Me.GroupBox14.Controls.Item("ProductList" & (r + 1).ToString), RadDropDownList).SelectedValue.ToString) & "'" & ","
                '' LC_CAPACITY ''
                Try
                    q &= "'" & (DirectCast(Me.GroupBox12.Controls.Item("Capacity" & (r + 1).ToString), RadTextBox).Text) & "'" & ","
                Catch ex As Exception
                    q &= "0" & ","
                End Try
                '' LC_PRESET ''
                Try
                    If (DirectCast(Me.GroupBox13.Controls.Item("Preset" & (r + 1).ToString), RadTextBox).Text) <> "" Then
                        q &= "'" & (DirectCast(Me.GroupBox13.Controls.Item("Preset" & (r + 1).ToString), RadTextBox).Text) & "'" & ","
                    Else
                        q &= "0" & ","
                    End If
                Catch ex As Exception
                    q &= "0" & ","
                End Try

                '' LC_BAY ''
                Try
                    If (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" & (r + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Then
                        q &= "'" & (DirectCast(Me.GroupBox11.Controls.Item("IslandBay" & (r + 1).ToString), RadDropDownList).Text) & "'" & ","
                    Else
                        q &= "0" & ","
                    End If
                Catch ex As Exception
                    q &= "0" & ","
                End Try
                '' LC_SEAL ''
                Try
                    q &= "'" & (Seal_No.Text) & "'" & ","
                Catch ex As Exception
                    q &= "0" & ","
                End Try
                Try
                    q &= "'" & (TTankBindingSource.Item(TTankBindingSource.Position)("Tankno").ToString()) & "'" & ","
                Catch ex As Exception
                    q &= "0" & ","
                End Try
                Try
                    q &= "'" & (TTankBindingSource.Item(TTankBindingSource.Position)("Density30").ToString()) & "'" & ","
                Catch ex As Exception
                    q &= "0" & ","
                End Try

                '' LC_METER ''
                Try
                    If (DirectCast(Me.GroupBox10.Controls.Item("Meter" & (r + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Then
                        q &= "'" & (DirectCast(Me.GroupBox10.Controls.Item("Meter" & (r + 1).ToString), RadDropDownList).SelectedValue.ToString) & "'" & ")"
                    Else
                        q &= "0" & ")"
                    End If
                Catch ex As Exception
                    q &= "0" & ")"
                End Try

                cls.Insert(q)
            Next r

            q = ""
            q = "select CALL_TARGET from T_QSETTING order by id"

            dt_tmp = cls.Query(q)

            Dim Call_Terget As String
            Call_Terget = dt_tmp(0)("CALL_TARGET").ToString
            Call_Tergets = Call_Terget.ToString

            q = ""
            q = "Insert into t_dashboardUnload "
            q &= " (LOAD_ID,"
            q &= " DRIVER_ID,"
            q &= " DRIVER_CARD,"
            q &= " TRUCK_ID,"
            q &= " TRUCK_CARD,"
            q &= " Status,"
            q &= " DO_NO,"
            q &= " Q_NO,"
            q &= " Q_STATUS,"
            q &= " Call_target,"
            q &= " Q_DATE) "

            q &= " Values ("

            q &= "'" & (Cbn6.Text) & "'" & ","
            q &= "'" & (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) & "'" & ","
            Dim TruckCard, DriverCard As String
            Try
                sql = ""
                sql = "select Driver_ID,Card_Number from vcardload "
                sql &= "where Driver_ID= '" & (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) & "'"

                dt_tmp = cls.Query(sql)

                DriverCard = dt_tmp(0)("Card_Number")
                q &= "" & DriverCard & "" & ","

            Catch ex As Exception
                q &= "'" & ("0") & "'" & ","
            End Try

            q &= "" & (VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString()) & "" & ","
            Try
                sql = ""
                sql = "select Truck_ID,Card_Number from vcardload "
                sql &= "where Truck_ID= '" & (VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString()) & "'"

                dt_tmp = cls.Query(sql)

                TruckCard = dt(0)("Card_Number")
                q &= "" & TruckCard & "" & ","

            Catch ex As Exception
                q &= "'" & ("0") & "'" & ","
            End Try
            q &= " 1,"
            q &= "'" & Cbn11.Text & "'" & ","
            q &= "'" & Load_q.Text & "'" & ","

            If Kiosk = 1 Then
                q &= " 0,"
            Else
                q &= " -1,"
            End If
            q &= "'" & Call_Tergets.ToString & "'" & ","

            q &= " Sysdate )"

            cls.Insert(q)

        Catch ex As Exception

            q = ""
            q = "delete T_unLoadingnote where load_id = "
            q &= Cbn6.Text

            cls.Delete(q)

            q = ""
            q = "delete T_unLoadingnotecompartment where lc_load = "
            q &= Cbn6.Text

            cls.Delete(q)

            q = ""
            q = "delete T_dashboardunload where load_id = "
            q &= Cbn6.Text

            cls.Delete(q)

            MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
            Exit Sub
        End Try

        If QLOAD = 1 Then
            q = ""
            q = "Update T_Q Set Q_NO_unload='" & Load_q.Text & "'"

            cls.Update(q)
        End If

        Try
            q = ""
            q = "Update t_Checkin Set Status=2 ,LOAD_ID='" & Cbn6.Text & "',CALL_TARGET='" & Call_Tergets.ToString & "' where ID='" & Checkin_ID.ToString & "'"

            cls.Update(q)
        Catch ex As Exception
        End Try


        '''''''''''''''''' New '''''

        q = ""
        q = "SELECT * from V_unLOADINGNOTE where load_id='" & Cbn8.Text & "'"
        Dim Myreport As New ReportDocument
        Myreport = New ReportDocument

        Dim ds As New DataSet
        ds = cls.Query_DS(q, "V_Loadingnote")

        Myreport.Load("UnloadingReport.rpt")
        Myreport.SetDataSource(ds)
        ReportPrint.CrystalReportViewer3.ReportSource = Myreport
        ReportPrint.ShowDialog()
        ds.Dispose()
        Myreport.Close()
        Try
            Advisenote_Shown(sender, e)
            SelectVLoadingNote()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update.Click
        OrderBut_Click(sender, e)

        Dim q, id, sc, sql, ref As String
        Dim i, SL, ST, r, j As Integer

        Update_date.Text = Date.Now
        ref = MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString

        sql = ""
        sql = "select load_id from T_unLoadingnote where reference='" & ref & "' "

        Dim loadID As String
        Dim dt_tmp As DataTable = cls.Query(sql)

        loadID = dt_tmp(0)("load_id")

        If MsgBox("ต้องการแก้ไขข้อมูลใบแนะนำการเติมเลขที่ '" & ref & "' หรือไม่ ?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then

            Try
                sql = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
                  & ",USERGROUP='" & MAIN.U_GROUP & "'"

                cls.Update(sql)
            Catch ex As Exception
            End Try

            Dim truckk As String
            truckk = (VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString())
            q = ""
            q = "UPDATE T_unLoadingnote "
            q &= "SET LOAD_CARD = "
            Try
                'If TDriverBindingSource.Item(TDriverBindingSource.Position)("Driver_Pincode").ToString() <> "" Then
                sql = ""
                sql = "select Truck_ID,Card_Number from vcardload "
                sql &= "where Truck_ID= '" & (VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString()) & "'"

                Dim Card As String

                dt_tmp = cls.Query(sql)

                Card = dt_tmp(0)("Card_Number")
                q &= "'" & Card & "'" & ","
            Catch ex As Exception
                q &= "'" & ("") & "'" & ","
            End Try

            q &= " LOAD_DID = "
            q &= "'" & (Cbn7.Text).ToString & "'" & ","
            q &= " LOAD_VEHICLE = "
            q &= "" & (VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString()) & "" & ","
            q &= " LOAD_STATUS = "
            q &= "'" & (TStatusBindingSource.Item(TStatusBindingSource.Position)("Status_group").ToString()) & "'" & ","
            q &= " LOAD_STATUS_N = "
            q &= "'" & (TStatusBindingSource.Item(TStatusBindingSource.Position)("Status_ID").ToString()) & "'" & ","
            q &= " LOAD_CAPACITY = "
            q &= "" & (Cbn5.Text) & "" & ","
            q &= " LOAD_Shipper = "
            q &= "'" & (TShipperBindingSource.Item(TShipperBindingSource.Position)("ID").ToString()) & "'" & ","
            q &= " LOAD_STARTTIME = "
            q &= "'" & (Cbn9.Text) & "'" & ","
            q &= " AddnoteDate = "
            Dim n_year As Integer = 0
            n_year = 543
            q &= "TO_DATE('" & (String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateAdd(DateInterval.Year, -n_year, Dateedit.Value))) & "','DD/MM/YYYY HH24:MI:SS')" & ","


            q &= " LOAD_DRIVER = "
            q &= "'" & (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) & "'" & ","
            q &= " LOAD_PRESET = "
            q &= "'" & (Cbn10.Text) & "'" & ","
            q &= " LOAD_PRESET86F = "
            q &= "'" & (Preset86.Text) & "'" & ","

            q &= " LOAD_PRESETFINISH = "
            q &= "'" & (PresetFinish.Text) & "'" & ","
            q &= " LOAD_DOfull = "
            q &= "'" & (Cbn11.Text) & "'" & ","
            q &= " LOADDO = "
            q &= "'" & (Cbn11.Text) & "'" & ","
            q &= " Reference = "
            q &= "'" & (Cbn8.Text) & "'" & ","
            q &= " Remark = "
            q &= "'" & (Edremark.Text) & "'" & ","
            q &= " Container = "
            q &= "'" & (Container.Text) & "'" & ","
            q &= " LOAD_SEALCOUNT = "
            q &= "'" & (Seal_Total.Text) & "'" & ","

            q &= " Load_Product = "
            q &= "'" & (TProductBindingSource.Item(TProductBindingSource.Position)("ID").ToString()) & "'" & ","

            q &= " Load_Tank = "
            q &= "'" & (TTankBindingSource.Item(TTankBindingSource.Position)("Tankno").ToString()) & "'" & ","
            q &= " Load_Bay = "
            q &= "'" & (TBayBindingSource.Item(TBayBindingSource.Position)("BAY_NUMBER").ToString()) & "'" & ","

            q &= " Load_Companyparent = "
            q &= "'" & (TCompanyBindingSource.Item(TCompanyBindingSource.Position)("COMPANY_ID").ToString()) & "'" & ","
            q &= " Load_seal = "
            q &= "'" & (Seal_No.Text) & "'" & ","
            q &= " Update_date = "
            q &= " Sysdate, "
            q &= " LOAD_Q = "
            q &= "'" & (Load_q.Text) & "'" & ","
            q &= " LOAD_QDASHBOARD = "
            q &= "'" & (Load_q.Text) & "'" & ","
            q &= " LOAD_TYPE = "
            q &= "'" & (TTruckTypeBindingSource.Item(TTruckTypeBindingSource.Position)("ID").ToString()) & "'" & ","
            q &= " DO_TYPE = "
            q &= "'" & (DO_Type.Text) & "'" & ","


            q &= " LOAD_AUTHORIZE ="
            q &= "'" & (authorize_Remark.Text) & "'" & ","
            q &= " LOAD_TEMP ="
            q &= "'" & (load_temp.Text) & "'" & ","
            q &= " LOAD_DENSITY ="
            q &= "'" & (Load_density.Text) & "'" & ","
            q &= " LOSSGAIN ="
            q &= "'" & (Gain.Text) & "'" & ","
            q &= " LOAD_TOTAL ="
            q &= "'" & (LoadTotal.Text) & "'" & ","
            q &= " UPDATE_BY = "
            q &= "'" & (Update_by.Text) & "' "

            q &= "WHERE reference= "
            q &= "" & ref & "  "

            cls.Update(q)

            ''''''''' Insert T_unLoadingnoteCompartment

            Try

                For r = 0 To TRUCK_COMP_NUM - 1
                    Dim LC_status As String
                    LC_status = (TStatusBindingSource.Item(TStatusBindingSource.Position)("Status_ID").ToString())
                    If (Order.Text) = "" Or (Order.Text) = "0" Or
                         (Product.SelectedIndex = -1) Or
                          (TTank.SelectedIndex = -1) Or
                        (Bay.SelectedIndex) = -1 Then
                        LC_status = "99"
                    End If
                    If LC_status = 99 Then
                        q = ""
                        q = "Update T_unLoadingnoteCOMPARTMENT Set "
                        q &= " LC_STATUS="
                        q &= "'" & LC_status & "'" & ","
                        q &= " LC_BASE='0',"
                        q &= " LC_BLEND='0',"
                        q &= " LC_PRO='0',"
                        q &= " LC_CAPACITY='0',"
                        q &= " LC_PRESET='0',"
                        q &= " LC_BAY='0',"
                        q &= " LC_SEAL='',"
                        q &= " LC_TANK='',"
                        q &= " LC_Density_30C='0',"
                        q &= " LC_METER='0' "
                        q &= "Where lc_load="
                        q &= "'" + Cbn6.Text + "'"
                        q &= " and lc_compartment = "
                        q &= "'" + (DirectCast(Me.GroupBox15.Controls.Item("Comp" + (r + 1).ToString), RadTextBox).Text) + "'"
                    Else
                        q = ""
                        q = "Update T_unLoadingnoteCOMPARTMENT Set "
                        q &= " LC_COMPARTMENT="
                        q &= "'" + (DirectCast(Me.GroupBox15.Controls.Item("Comp" + (r + 1).ToString), RadTextBox).Text) + "'" + ","

                        If LC_status >= 3 Then
                            q &= " LC_STATUS="
                            q &= "'" & LC_status & "',"
                        End If

                        q &= " LC_BASE="
                        '' LC_BASE ''
                        If (Order.Text) <> "" Then
                            q &= "'" + (Order.Text) + "'" + ","
                        Else
                            q &= "0" + ","
                        End If
                        q &= " LC_BLEND="
                        '' LC_BLEND''
                        q &= "0" + ","

                        q &= " LC_PRO="
                        '' LC_PRO ''
                        If (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedIndex) <> -1 Then
                            q &= "'" + (DirectCast(Me.GroupBox14.Controls.Item("ProductList" + (r + 1).ToString), RadDropDownList).SelectedValue.ToString) + "'" + ","
                        Else
                            q &= "0" + ","
                        End If
                        q &= " LC_CAPACITY="
                        '' LC_CAPACITY ''
                        q &= "'" + (DirectCast(Me.GroupBox12.Controls.Item("Capacity" + (r + 1).ToString), RadTextBox).Text) + "'" + ","
                        q &= " LC_PRESET="
                        '' LC_PRESET ''
                        If (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) <> "" Then
                            q &= "'" + (DirectCast(Me.GroupBox13.Controls.Item("Preset" + (r + 1).ToString), RadTextBox).Text) + "'" + ","
                        Else
                            q &= "0" + ","
                        End If
                        q &= " LC_BAY="
                        '' LC_BAY ''
                        q &= "'" & (TBayBindingSource.Item(TBayBindingSource.Position)("BAY_NUMBER").ToString()) & "'" & ","

                        q &= " LC_SEAL="
                        '' LC_SEAL ''
                        q &= "'" + (Seal_No.Text) + "'" + ","
                        q &= " LC_TANK="
                        '' LC_TANK ''
                        q &= "'" & TTank.Text & "'"

                        q &= " Where lc_load="
                        q &= "'" & Cbn6.Text & "'"
                        q &= " and lc_compartment = "
                        q &= "'" & (DirectCast(Me.GroupBox15.Controls.Item("Comp" + (r + 1).ToString), RadTextBox).Text) & "' "
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
            Me.T_STATUSTableAdapter.Fill(Me.IRPCDataset.T_STATUS)
            Me.T_TRUCKTYPETableAdapter.Fill(Me.IRPCDataset.T_TRUCKTYPE)
            Me.T_BATCHMETERTableAdapter.Fill(Me.IRPCDataset.T_BATCHMETER)
            Me.V_TRUCKTableAdapter.Fill(Me.IRPCDataset.V_TRUCK)
            Me.T_BAYTableAdapter.Fill(Me.IRPCDataset.T_BAY)
            Me.T_PRODUCTTableAdapter1.Fill(Me.IRPCDataset.T_PRODUCT)
            Me.T_SHIPPERTableAdapter.Fill(Me.IRPCDataset.T_SHIPPER)
            Me.T_COMPANYTableAdapter.Fill(Me.IRPCDataset.T_COMPANY)
            Me.T_COMPANYPARENTTableAdapter.Fill(Me.IRPCDataset.T_COMPANYPARENT)
            Me.T_DRIVERTableAdapter.Fill(Me.IRPCDataset.T_DRIVER)
            Me.T_TANKTableAdapter.Fill(Me.IRPCDataset.T_TANK)
            CompClear()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Canceldata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Canceldata.Click
        If MAIN.U_GROUP_ID < 3 Then
            MessageBox.Show("User นี้ไม่สามารถยกเลิกตั๋วได้ ต้องเป็น User Supervisor", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            Dim sql As String

            Dim ref, LC_ID, load_do, load_status As String

            ref = MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString
            sql = ""
            sql = "select Load_id,load_dofull,load_status from T_unLoadingnote where reference = "
            sql &= ref

            Dim dt As DataTable = cls.Query(sql)

            LC_ID = dt(0)("Load_id")
            load_do = dt(0)("load_dofull")
            load_status = dt(0)("load_status")
            If load_status = 2 Then
                MsgBox("รถคันนี้กำลังทำการเติม ไม่สามารถลบได้", vbOKOnly + vbDefaultButton2, "ตรวจสอบ")
                Exit Sub

            ElseIf load_status = 3 Then
                MsgBox("รถคันนี้ทำการเติมเสร็จแล้ว ไม่สามารถลบได้", vbOKOnly + vbDefaultButton2, "ตรวจสอบ")
                Exit Sub
            Else
                If MsgBox("ต้องการยกเลิกใบแนะนำการเติมเลขที่ " & ref & " หรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then

                    Try

                        sql = "UPDATE T_USERLOGIN SET Update_date=Sysdate,USERNAME='" & MAIN.U_NAME & "'" _
                          & ",USERGROUP='" & MAIN.U_GROUP & "'"

                        cls.Update(sql)
                    Catch ex As Exception

                    End Try

                    sql = ""
                    sql = "update  T_unLoadingnote set load_status='50' where reference ='" & ref & "'"

                    cls.Update(sql)

                    sql = ""
                    sql = "update  T_unLoadingnotecompartment set lc_status='50' where lc_load ='" & LC_ID & "'"

                    cls.Update(sql)

                    sql = ""
                    sql = "Update   T_Checkin set status=1,load_id='',Call_actual='0'  where load_id ='" & LC_ID & "'"

                    cls.Update(sql)

                    sql = ""
                    sql = "delete   t_dashboardunload where load_id ='" & LC_ID & "'"

                    cls.Update(sql)

                    sql = ""
                    sql = "delete   T_QUnloadend where load_id ='" & LC_ID & "'"

                    cls.Delete(sql)

                    RadPageView1.SelectedPage = RadPageViewPage1
                    SelectVLoadingNote()
                End If
            End If
        End If
    End Sub

    Private Sub Editdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Editdata.Click
        EditType = 1
        Status.Enabled = True
        Dim q, sql, ref, load_status As String
        Dim truck As Integer
        Try
            ref = MasterGridAdvisenote.CurrentRow.Cells("REFERENCE").Value.ToString
        Catch ex As Exception
            Exit Sub
        End Try

        sql = ""
        sql = "select load_status from T_unLoadingnote where reference = "
        sql &= ref

        Dim dt As DataTable = cls.Query(sql)

        load_status = dt(0)("load_status")
        If load_status = 30 Then
            MsgBox("รถคันนี้ทำการเติมเสร็จแล้ว ไม่สามารถแก้ไขได้", vbOKOnly & vbDefaultButton3, "ตรวจสอบ")
            Exit Sub
        Else

            sealEdit = 1
            Bcancel_Click(sender, e)
            Refresh()
            q &= ""
            q &= "Select NVL(T_unLoadingnote.load_did,0) as Load_did ,NVL(T_unLoadingnote.load_status_n,0) as LOAD_STATUS_N,"
            q &= "NVL(T_unLoadingnote.LOAD_Shipper,0) as load_shipper ,"
            q &= "NVL(T_unLoadingnote.LOAD_delivery,0) as load_delivery ,"
            q &= "NVL(T_TRUCK.TRUCK_NUMBER,0) as load_vehicle ,"
            q &= "NVL(T_unLoadingnote.LOAD_vehicle,0) as load_vehicle_ID ,"
            q &= "NVL(T_unLoadingnote.LOAD_capacity,0) as load_capacity ,"
            q &= "Trim(NVL(T_unLoadingnote.LOAD_driver,0)) as load_driver ,"
            q &= "NVL(T_unLoadingnote.LOAD_preset,0) as load_preset ,"
            q &= "NVL(T_unLoadingnote.LOAD_preset86F,0) as load_preset86F ,"
            q &= "NVL(T_unLoadingnote.LOAD_presetfinish,0) as load_presetfinish ,"
            q &= "NVL(T_unLoadingnote.LOAD_SEAL,0) as LOAD_SEAL ,"
            q &= "NVL(T_unLoadingnote.LOAD_card,0) as load_card ,"
            q &= "T_unLoadingnote.AddnoteDate as AddnoteDate,"
            q &= "NVL(T_unLoadingnote.Reference,0) as Reference ,"
            q &= "NVL(T_unLoadingnote.LOAD_id,0) as load_id ,"
            q &= "NVL(T_unLoadingnote.LOAD_Sealcount,0) as load_Sealcount ,"
            q &= "T_unLoadingnote.Container AS Container ,"
            q &= "NVL(T_unLoadingnote.Remark,0) as Remark ,"
            q &= "NVL(T_Customer.Customer_name ,0) as Customer_name ,"   'T_Customer.Customer_name
            q &= "NVL(T_DRIVER.Driver_Name ,0) as Driver_Name ,"   'T_DRIVER.Driver
            q &= "NVL(T_STATUS.status_name,0) as status_Name ,"   'T_STATUS.status_name
            q &= "NVL(T_COMPANYPARENT.COMPANY_CODE ,0) as LOAD_TRUCKCOMPANY ,"  'T_COMPANY.COMPANY_CODE
            q &= "NVL(T_unLoadingnote.LOAD_status,0) as Load_status ,"
            q &= "T_unLoadingnote.Update_date as Update_date ,"
            q &= "T_unLoadingnote.UPDATE_BY as Update_by ,"
            q &= "NVL(T_unLoadingnote.LOAD_DOfull,0) as LOAD_DOfull ,"
            q &= "NVL(T_unLoadingnote.LOAD_TYPE,-1) as LOAD_TYPE ,"
            q &= "NVL(T_unLoadingnote.LOAD_Q ,0) as LOAD_Q ,"
            q &= "NVL(T_unLoadingnote.load_Driver ,0) as Driver_ID ,"
            q &= "NVL(T_unLoadingnote.DO_TYPE,'0') as DO_TYPE ,"
            q &= "NVL(T_unLoadingnote.load_tank,'0') as load_tank ,T_unLoadingnote.load_bay as LOAD_BAY,"
            q &= "NVL(T_unLoadingnote.load_product,'0') as load_product ,NVL(t_product.product_code,'0') as load_productcode,"
            q &= "NVL(T_unLoadingnote.load_Companyparent,0) as load_Companyparent ,"

            q &= "NVL(T_unLoadingnote.load_authorize,0) as load_authorize,"
            q &= "NVL(T_unLoadingnote.lossgain,0) as lossgain,"
            q &= "NVL(T_unLoadingnote.Load_density,0) as Load_density,"
            q &= "NVL(T_unLoadingnote.load_total,0) as load_total ,"
            q &= "NVL(T_unLoadingnote.load_temp,0) as load_temp ,"

            q &= "T_unLoadingnote.remark  AS REmark,T_unLoadingnote.Tank_Befor,T_unLoadingnote.Tank_after "
            q &= "FROM "
            q &= "(Select * from T_unLoadingnote where Reference = '" & ref & "' and load_Status in(1,2,3) and load_status <> 99) T_unLoadingnote "
            q &= "LEFT OUTER JOIN  T_STATUS ON T_unLoadingnote.LOAD_STATUS = T_STATUS.STATUS_ID "
            q &= "Left OUTER JOIN  V_DO ON T_unLoadingnote.LOAD_ID = V_DO.LOAD_ID "
            q &= "Left OUTER JOIN T_Customer  ON T_Customer.ID = T_unLoadingnote.LOAD_CUSTOMER "
            q &= "LEFT OUTER JOIN T_COMPANYPARENT ON T_unLoadingnote.LOAD_COMPANYPARENT = T_COMPANYPARENT.COMPANY_ID "
            q &= "LEFT OUTER JOIN  T_COMPANY ON T_unLoadingnote.LOAD_TRUCKCOMPANY = T_COMPANY.COMPANY_ID  "
            q &= "LEFT OUTER JOIN  T_TRUCK ON T_unLoadingnote.LOAD_VEHICLE = T_TRUCK.ID "
            q &= "LEFT OUTER JOIN T_DRIVER ON T_unLoadingnote.LOAD_DRIVER = T_DRIVER.ID  "
            q &= "LEFT OUTER JOIN t_product ON T_unLoadingnote.LOAD_product = t_product.ID  "
            q &= "LEFT OUTER JOIN T_shipper ON T_unLoadingnote.LOAD_Shipper = T_shipper.ID  "
            q &= "ORDER BY T_unLoadingnote.LOAD_ID DESC  "

            dt = cls.Query(q)

            Dim SealCount As String
            SealCount = dt.Rows(0).Item("Load_sealcount").ToString
            Try
                Cbn6.Text = dt.Rows(0).Item("load_ID").ToString
                Cbn11.Text = dt.Rows(0).Item("load_DOfull").ToString
                Cbn10.Text = dt.Rows(0).Item("load_Preset").ToString
                Preset86.Text = dt.Rows(0).Item("load_Preset86f").ToString
                Order.Text = dt.Rows(0).Item("load_Preset").ToString
                PresetFinish.Text = dt.Rows(0).Item("load_Presetfinish").ToString
                Cbn8.Text = dt.Rows(0).Item("Reference").ToString
                Container.Text = dt.Rows(0).Item("Container").ToString
                Seal_Total.Text = dt.Rows(0).Item("Load_sealcount").ToString
                DO_Type.Text = dt.Rows(0).Item("DO_Type").ToString
                Update_by.Text = dt.Rows(0).Item("Update_by").ToString
                Load_q.Text = dt.Rows(0).Item("Load_q").ToString
                Seal_Total.Text = dt.Rows(0).Item("Load_sealcount").ToString
                Seal_No.Text = dt.Rows(0).Item("Load_seal").ToString
                Cbn5.Text = dt.Rows(0).Item("load_Capacity").ToString
                Cbn7.Text = dt.Rows(0).Item("Load_did").ToString

                truck = dt.Rows(0).Item("load_vehicle_ID")
                TankBefor.Text = dt.Rows(0).Item("Tank_befor").ToString
                Tankafter.Text = dt.Rows(0).Item("Tank_After").ToString
                TTank.Text = dt.Rows(0).Item("load_tank").ToString
                authorize_Remark.Text = dt.Rows(0).Item("load_authorize").ToString
                Gain.Text = dt.Rows(0).Item("lossgain").ToString
                Load_density.Text = dt.Rows(0).Item("Load_density").ToString
                LoadTotal.Text = dt.Rows(0).Item("load_total").ToString
                load_temp.Text = dt.Rows(0).Item("load_temp").ToString

                Try
                    Tankloss.Text = (Int(TankBefor.Text) - Int(Tankafter.Text)).ToString
                Catch ex As Exception
                    Tankloss.Text = "0"
                End Try
                Dim TTa As String
                Dateedit.Value = dt.Rows(0).Item("AddnoteDate").ToString

                If dt.Rows(0).Item("load_vehicle").ToString <> "" And dt.Rows(0).Item("load_vehicle").ToString <> "0" Then
                    Cbn2.Text = dt.Rows(0).Item("load_vehicle").ToString
                    VTruckBindingSource.Position = VTruckBindingSource.Find("Truck_number", dt.Rows(0).Item("load_vehicle").ToString)
                End If
                TDriverBindingSource.Position = TDriverBindingSource.Find("DRIVER_NAME", dt.Rows(0).Item("Driver_Name").ToString)
                TShipperBindingSource.Position = TShipperBindingSource.Find("ID", dt.Rows(0).Item("LOAD_Shipper").ToString)

                TTa = TCompanyBindingSource.Position

                TCompanyBindingSource.Position = TCompanyBindingSource.Find("Company_id", dt.Rows(0).Item("LOAD_Companyparent").ToString)

                TTruckTypeBindingSource.Position = TTruckTypeBindingSource.Find("ID", dt.Rows(0).Item("Load_type").ToString)
                TStatusBindingSource.Position = TStatusBindingSource.Find("Status_ID", dt.Rows(0).Item("load_status_N").ToString)

                TTankBindingSource.Position = TTankBindingSource.Find("tankno", dt.Rows(0).Item("load_tank").ToString)
                TProductBindingSource.Position = TProductBindingSource.Find("ID", dt.Rows(0).Item("load_product").ToString)
                TBayBindingSource.Position = TBayBindingSource.Find("Bay_number", dt.Rows(0).Item("load_bay").ToString)
                TProductBindingSource.Position = TProductBindingSource.Find("Product_code", dt.Rows(0).Item("load_productcode").ToString)
                Dim truckk As String
                truckk = (VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString())
            Catch ex As Exception
            End Try

            Try
                q = ""
                q = "SELECT     T_UNLOADINGNOTECOMPARTMENT.LC_ID AS LC_ID, T_UNLOADINGNOTECOMPARTMENT.LC_LOAD AS LC_LOAD, T_UNLOADINGNOTECOMPARTMENT.LC_PRO AS LC_PRO,"
                q &= " T_Product.Product_code AS Product_code, T_UNLOADINGNOTECOMPARTMENT.LC_COMPARTMENT AS LC_COMPARTMENT, T_UNLOADINGNOTECOMPARTMENT.LC_STATUS AS LC_STATUS,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_CAPACITY AS LC_CAPACITY, T_UNLOADINGNOTECOMPARTMENT.LC_PRESET AS LC_PRESET,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_LOADEDQTY AS LC_LOADEDQTY, T_UNLOADINGNOTECOMPARTMENT.LC_METER AS LC_METER,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_BAY AS LC_BAY, T_UNLOADINGNOTECOMPARTMENT.LC_ISLAND AS LC_ISLAND,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_STARTTIME AS LC_STARTTIME, T_UNLOADINGNOTECOMPARTMENT.LC_ENDTIME AS LC_ENDTIME,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_BATCHGROSSBASE AS LC_BATCHGROSSBASE, T_UNLOADINGNOTECOMPARTMENT.LC_BATCHGROSSBLEND AS LC_BATCHGROSSBLEND,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_BATCHNETBASE_30C AS LC_BATCHNETBASE_30C, T_UNLOADINGNOTECOMPARTMENT.LC_BATCHNETBLEND_30C AS LC_BATCHNETBLEND_30C,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_CUMULBASE_GROSLTR AS LC_CUMULBASE_GROSLTR, T_UNLOADINGNOTECOMPARTMENT.LC_CUMULBLEND_GROSLTR AS LC_CUMULBLEND_GROSLTR,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_CUMULBASE_NETLTR AS LC_CUMULBASE_NETLTR, T_UNLOADINGNOTECOMPARTMENT.LC_CUMULBLEND_NETLTR AS LC_CUMULBLEND_NETLTR,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_TEMP AS LC_TEMP, T_UNLOADINGNOTECOMPARTMENT.LC_DENSITY_30C AS LC_DENSITY_30C,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_VCF AS LC_VCF, T_UNLOADINGNOTECOMPARTMENT.LC_METERFACTOR3 AS LC_METERFACTOR3,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_K_FACTOR AS LC_K_FACTOR, T_UNLOADINGNOTECOMPARTMENT.LC_BASE AS LC_BASE,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_BLEND AS LC_BLEND, T_UNLOADINGNOTECOMPARTMENT.LC_BATCHNET_15C AS LC_BATCHNET_15C,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_CUMULNET_15C AS LC_CUMULNET_15C, T_UNLOADINGNOTECOMPARTMENT.LC_TANKGB AS LC_TANKGB,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_TANKETH AS LC_TANKETH, T_UNLOADINGNOTECOMPARTMENT.LC_TANK AS LC_TANK, T_UNLOADINGNOTECOMPARTMENT.LC_SEAL AS LC_SEAL,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_API AS LC_API, T_UNLOADINGNOTECOMPARTMENT.LC_Temp_manual AS LC_Temp_manual,"
                q &= " T_UNLOADINGNOTECOMPARTMENT.LC_SHIPPER AS LC_SHIPPER, T_SHIPPER.SP_Code AS SP_Code, T_UNLOADINGNOTECOMPARTMENT.LC_CUSTOMER AS LC_CUSTOMER,"
                q &= " T_Customer.Customer_code AS Customer_code, T_BATCHMETER.BATCH_NAME AS BATCH_NAME, T_UNLOADINGNOTECOMPARTMENT.LC_Additive AS LC_Additive,"
                q &= " T_Customer.Customer_name AS Customer_name "
                q &= " FROM    (Select * from T_UNLOADINGNOTECOMPARTMENT Where LC_LOAD ='" & Cbn6.Text & "') T_UNLOADINGNOTECOMPARTMENT LEFT OUTER JOIN"
                q &= " T_BATCHMETER ON T_UNLOADINGNOTECOMPARTMENT.LC_METER = T_BATCHMETER.BATCH_NUMBER LEFT OUTER JOIN"
                q &= " T_Customer ON T_UNLOADINGNOTECOMPARTMENT.LC_CUSTOMER = T_Customer.ID LEFT OUTER JOIN"
                q &= " T_SHIPPER ON T_UNLOADINGNOTECOMPARTMENT.LC_SHIPPER = T_SHIPPER.ID LEFT OUTER JOIN"
                q &= " T_Product ON T_UNLOADINGNOTECOMPARTMENT.LC_PRO = T_Product.ID  Order by T_UNLOADINGNOTECOMPARTMENT.LC_Compartment"

                Dim dt1 As DataTable = cls.Query(q)

                Cbn2_Leave(sender, e)
                Dim product1, Meter, Bay1 As String
                Dim index As Integer
                For i = 0 To dt1.Rows.Count - 1
                    If (dt1.Rows(i).Item("Product_code").ToString) <> "" Then
                        product1 = ""
                        product1 = (dt1.Rows(i).Item("Product_code").ToString)
                        index = DirectCast(Me.GroupBox14.Controls.Item("ProductList" & (i + 1).ToString), RadDropDownList).FindString(product1)
                        DirectCast(Me.GroupBox14.Controls.Item("ProductList" & (i + 1).ToString), RadDropDownList).SelectedIndex = index
                        Product.SelectedIndex = index
                    End If

                    If (dt1.Rows(i).Item("LC_Bay").ToString) <> "0" Then
                        Bay1 = ""
                        Bay1 = (dt1.Rows(i).Item("LC_BAY").ToString)
                        index = DirectCast(Me.GroupBox11.Controls.Item("Islandbay" & (i + 1).ToString), RadDropDownList).FindString(Bay1)
                        DirectCast(Me.GroupBox11.Controls.Item("Islandbay" & (i + 1).ToString), RadDropDownList).SelectedIndex = index
                        Bay.SelectedIndex = index
                    Else
                        DirectCast(Me.GroupBox11.Controls.Item("Islandbay" & (i + 1).ToString), RadDropDownList).SelectedIndex = -1
                    End If

                    DirectCast(Me.GroupBox13.Controls.Item("Preset" & (i + 1).ToString), RadTextBox).Text = (dt1.Rows(i).Item("LC_PRESET").ToString)
                Next i
                TBayBindingSource.Position = TBayBindingSource.Find("Bay_number", dt1.Rows(0).Item("lc_bay").ToString)

                Seal_Total.Text = SealCount.ToString
            Catch ex As Exception

            End Try

            TRUCK_COMP_NUM = VTruckBindingSource.Item(VTruckBindingSource.Position)("TRUCK_COMP_NUM").ToString
            sealEdit = 0
            RadPageView1.SelectedPage = RadPageViewPage2
            Bsave.Visible = False
            Update.Visible = True
        End If

        Dim truckk2 As String
        truckk2 = (VTruckBindingSource.Item(VTruckBindingSource.Position)("ID").ToString())
    End Sub

    Private Sub Seal_Total_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Seal_Total.Leave
        If sealEdit = 0 Then
        End If
    End Sub

    Private Sub Seal_Total_TextChange(ByVal sender As Object, ByVal Empty As EventArgs)
        Throw New NotImplementedException
    End Sub

    Private Sub EditSeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim ref, sql, Seal As String
            ref = MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString
            sql = ""
            sql = "Select load_id,reference from T_unLoadingnote where reference =" & ref & ""

            Dim ds As New DataSet
            ds = cls.Query_DS(sql, "T_unLoadingnote")

            Me.AddOwnedForm(EditSeal)
            EditSeal.ShowDialog()
            SelectVLoadingNote()
            ds.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub EdCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EdCustomer.Click
        EdCustomer.MultiColumnComboBoxElement.ShowPopup()
    End Sub

    Private Sub Cbn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbn3.Click
        Cbn3.MultiColumnComboBoxElement.ShowPopup()
    End Sub


    Private Sub Driver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Driver.Click
        Driver.MultiColumnComboBoxElement.ShowPopup()
    End Sub

    Private Sub MasterGridAdvisenote_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles MasterGridAdvisenote.CellFormatting
        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SelectVLoadingNote()
    End Sub

    Private Sub Product_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Product.Click
        Product.MultiColumnComboBoxElement.ShowPopup()
    End Sub

    Private Sub Bay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bay.Click
        Try
            Bay.MultiColumnComboBoxElement.ShowPopup()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Meter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Meter.Click
        Meter.MultiColumnComboBoxElement.ShowPopup()
    End Sub
    Private Sub TProductBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TProductBindingSource.PositionChanged
        If EditType <> 1 Then
            Try
                Dim Product_ID As Integer
                Dim Sql, Product_N As String
                Product_ID = TProductBindingSource.Item(TProductBindingSource.Position)("ID").ToString()
                Product_N = TProductBindingSource.Item(TProductBindingSource.Position)("Product_name").ToString()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Bay_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bay.Leave
        Try
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
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Order_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Order.KeyPress

    End Sub

    Private Sub Order_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Order.TextChanged

    End Sub

    Private Sub Cbn10_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbn10.Leave
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cbn10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbn10.TextChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Tankunload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tankunload.Click
        Try
            Me.AddOwnedForm(UnloadtankValue)
            UnloadtankValue.ShowDialog()
            SelectVLoadingNote()

        Catch ex As Exception
        End Try
    End Sub


    Private Sub Product_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Product.Leave
        Try
            TTank.SelectedIndex = -1
            Bay.SelectedIndex = -1
            Dim Product_ID As Integer
            Dim Sql, Product_N, q As String
            Product_ID = TProductBindingSource.Item(TProductBindingSource.Position)("ID").ToString()
            Product_N = TProductBindingSource.Item(TProductBindingSource.Position)("Product_code").ToString()

            Sql = ""
            Sql = "Select Tankno,id,TankProduct,density30 from t_tank where TankProduct = '" & Product_N & "' and Tank_Active= 1 order by Tankno"

            Dim dt As DataTable = cls.Query(Sql)

            Dim MyDataSet1 As New DataSet

            MyDataSet1 = cls.Query_DS(Sql, "t_tank")

            If dt.Rows.Count = 0 Then
                MessageBox.Show("ไม่ได้เปิดการใช้งานถังรับ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Cursor = Cursors.Default
                Tank_Order.ShowDialog()
                Product.Focus()
                Exit Sub
            End If

            TTankBindingSource.DataSource = MyDataSet1
            TTankBindingSource.DataMember = "t_tank"
            MyDataSet1.Dispose()
            TTank.SelectedIndex = 0

            Sql = ""
            Sql = "select * from  t_bayunload t where bay_pro1='" & Product_ID & "' or bay_pro2='" & Product_ID & "' or bay_pro3='" & Product_ID & "'"
            Sql &= "order by bay_number"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(Sql, "T_bay")

            TBayBindingSource.DataSource = MyDataSet
            TBayBindingSource.DataMember = "T_bay"
            MyDataSet.Dispose()
            Bay.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TTank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TTank.Click
        TTank.MultiColumnComboBoxElement.ShowPopup()
    End Sub


    Private Sub Shipper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Shipper.Click
        Shipper.MultiColumnComboBoxElement.ShowPopup()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim q, sc, sql As String
        Dim i, SL, ST, r, j As Integer
        Dim s_year As String
        Dim Card As String
        Update_date.Text = Date.Now
        s_year = Date.Now.Year

        ''''   ST  '''''''''
        q = ""
        q = "select NVL(max(ST_ID),0)+1 as ST_ID"
        q &= " from T_ST"

        Dim dt As DataTable = cls.Query(q)
        ST = dt(0)("ST_ID")
    End Sub

    Private Sub Driver_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Driver.Leave
        AuthorRemarkDriver = ""
        If Driver.Text = "" Then
            Exit Sub
        End If

        Dim Vdate1, Vdate2 As Integer
        If EditType <> 1 Then

            Dim sql As String
            sql = ""
            sql = "select (to_date(DRIVER_DATE_END)-to_date(sysdate)) as DRIVER_DATE_END,(to_date(TRAIN_DATE_end)-to_date(sysdate)) TRAIN_DATE_end From T_Driver where ID= '" & (TDriverBindingSource.Item(TDriverBindingSource.Position)("ID").ToString()) & "'"

            Dim dt1 As DataTable = cls.Query(sql)

            Try
                Vdate1 = Int(dt1.Rows(0).Item("DRIVER_DATE_END").ToString())
            Catch ex As Exception
                Vdate1 = -1
            End Try

            If Vdate1 <= 0 Then
                MessageBox.Show("ใบขับขี่หมดอายุกรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If MsgBox("ต้องการ Authorize โดย Supervisor หรือไม่ ?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then

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
            If Vdate2 <= 0 Then
                MessageBox.Show("บัตรอบรมหมดอายุกรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If MsgBox("ต้องการ Authorize โดย Supervisor หรือไม่ ?", vbYesNo + vbDefaultButton2, "Confirmation") = vbYes Then

                    authorizeUser = 6
                    Loginauthorize.ShowDialog()
                    If Loginauthorize.Success = 0 Then
                        'If AuthorRemark = "" Then
                        '    authorize_Remark.Text = ""
                        'End If
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

        If Vdate1 < 30 And Vdate1 > 0 Then
            MessageBox.Show("วันหมดอายุใบขับขี่เหลืออีก : '" & Vdate1.ToString & "' วัน", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If Vdate2 < 30 And Vdate2 > 0 Then
            MessageBox.Show("วันหมดอายุบัตรอบรมเหลืออีก : '" & Vdate2.ToString & "' วัน", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Gain_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Gain.KeyPress

    End Sub

    Private Sub Gain_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gain.TextChanged
        Try
            Dim load_preset, gain1 As String
            load_preset = Cbn10.Text
            gain1 = Gain.Text
            PresetFinish.Text = Str(Int(load_preset) + Int(gain1)).ToString
        Catch ex As Exception
        End Try
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.VCHECKINLOAD1TableAdapter.Fill(Me.IRPCDataset.VCHECKINLOAD1)
    End Sub

    Private Sub AddAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddAuto.Click
        Dim dt As DataTable

        ClearData()
        EditType = 0
        Status.Enabled = True
        QLOAD = 0
        auto = 1
        DO_Type.SelectedIndex = 0
        Dim q, s_day, s_month, s_year As String
        s_day = Date.Now.Day
        s_month = Date.Now.Month
        s_year = Date.Now.Year
        Cbn9.Text = Format(Date.Now.Date, "dd/MM/yyyy")
        Dateedit.Value = Now

        Status.SelectedText = "รอเติม"
        Status.Enabled = False
        Update_by.Text = MAIN.U_NAME

        Me.T_DRIVERTableAdapter.Fill(Me.IRPCDataset.T_DRIVER)
        Try
            q = ""
            q = "select NVL(max(Load_id),0)+1 as load_id ,NVL(max(Reference),0)+1 as Reference  from T_unloadingnote"

            dt = cls.Query(q)

            Try
                Cbn6.Text = dt(0)("Load_id")
                Cbn8.Text = dt(0)("Reference")
                Cbn11.Focus()
            Catch ex As Exception

            End Try

            Dim DriverName, truck As String

            Try
                Load_q.Text = RadGridView1.CurrentRow.Cells("Q_NO").Value.ToString
                Checkin_ID = RadGridView1.CurrentRow.Cells("ID").Value.ToString
            Catch ex As Exception
                MessageBox.Show("กรุณาเลือกคิวที่ต้องการ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try

            RadPageView1.SelectedPage = RadPageViewPage2
            Try
                Dim yearthai As String
                yearthai = Str(Int(s_year + 543))
                Dim sql As String
                sql = ""
                sql = "select  NVL(max(LOAD_DID),0)+1 as LOAD_DID from T_UnLOADINGNOTE "
                sql &= " where LOAD_DAY=" + s_day + " and LOAD_MONTH =" + s_month + " and LOAD_YEAR=" + yearthai + ""

                dt = cls.Query(sql)

                Cbn7.Text = dt(0)("Load_DID").ToString

                If Cbn7.Text = "" Then

                    sql = ""
                    sql = "select Q_NO_Unload+1 as Q_NO from T_Q "

                    dt = cls.Query(sql)
                    Load_q.Text = dt(0)("Q_NO").ToString
                    QLOAD = 1
                End If


            Catch ex As Exception

            End Try

            truck = RadGridView1.CurrentRow.Cells("Truck_number").Value.ToString


            Try
                DriverName = RadGridView1.CurrentRow.Cells("Driver_id").Value.ToString
                TDriverBindingSource.Position = TDriverBindingSource.Find("ID", DriverName.ToString)
            Catch ex As Exception
                Driver.SelectedIndex = -1
            End Try
            VTruckBindingSource.Position = VTruckBindingSource.Find("Truck_number", truck.ToString)
            Cbn2.SelectedIndex = VTruckBindingSource.Position
            Cbn2_Leave(sender, e)
            Bsave.Visible = True
            Update.Visible = False
        Catch ex As Exception
            RadPageView1.SelectedPage = RadPageViewPage1
        End Try
        Cbn11.Focus()

    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Dim sql As String

        sql = ""
        sql = "Update t_checkin set status=0,load_id='',load_type=0 where ID='" & VCheckinBindingSource.Item(VCheckinBindingSource.Position)("ID").ToString & "'"

        cls.Update(sql)

        Me.VCHECKINLOAD1TableAdapter.Fill(Me.IRPCDataset.VCHECKINLOAD1)
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        SelectVLoadingNote()
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        If MAIN.U_GROUP_ID < 3 Then
            MessageBox.Show("User นี้ไม่สามารถยกเลิกตั๋วได้ ต้องเป็น User Supervisor", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            Canceldata_Click(sender, e)
        End If
        Me.VCHECKINLOAD1TableAdapter.Fill(Me.IRPCDataset.VCHECKINLOAD1)
    End Sub

    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        SelectVLoadingNote()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        SelectVLoadingNote()
    End Sub
End Class
