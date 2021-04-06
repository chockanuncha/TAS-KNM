Imports CrystalDecisions.CrystalReports.Engine


Public Class ReportBOL
    Private cls As New Class_SQLSERVERDB

    Dim Memory As MemoryManagement.Manage

    Private Sub RadButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClose.Click
        Me.Close()
    End Sub
    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Try
            Dim ref, sql As String
            ref = MasterGrid.CurrentRow.Cells("reference").Value.ToString
            Dim Myreport As New ReportDocument
            Myreport = New ReportDocument
            'sql = "select max(Reference) as Reference,"
            'sql &= "max(St_ST_date) as St_ST_date,sum(Gross_m1) as Gross_m1,sum(net86f) as Net_m1,min(Startm1) as Startm1,max(Stopm1) as Stopm1,min(Startm1_net) as Startm1_net,max(Stopm1_net) as Stopm1_net, "
            'sql &= "Isnull(to_char(min(LC_STARTTIME),'HH24:MI:SS'),min(St_ST_time_start)) as St_ST_time_start,to_char(max(LC_ENDTIME),'HH24:MI:SS') as St_ST_time_stop,max(Batch_name) as Batch_name,max(Lc_Compartment) as Lc_Compartment,max(LC_preset) as LC_preset,max(Load_driver) as Load_driver,max(load_customer) as load_customer,max(load_Vehicle) as load_Vehicle,max(Product_code) as Product_code,max(lc_tank) as lc_tank,"
            'sql &= "max(Avg_temp_m1) as Avg_temp_m1,max(load_dofull) as load_dofull,max(addnotedate) as addnotedate,min(Q_time) as Q_time,min(Checkin_time) as Checkin_time,max(VCF_M1) as VCF_M1,max(Density30C_M1) as Density30C_M1,max(DO_TYPE) as DO_TYPE,max(Product_name) as Product_name,"
            'sql &= "max(LC_Seal) as LC_Seal,MAX(lc_additive) as Lc_additive,max(checkout_time) as checkout_time "
            'sql &= " from v_bol_m1m2_new where reference='" & ref & "' group by Reference,Lc_Compartment order by reference,Lc_Compartment"

            sql = "Select max(CUSTOMER_NAME) As INT1,"
            sql &= "Case MAX(Container) When NULL Then MAX (TRUCK_NUMBER) When '' THEN MAX (TRUCK_NUMBER) ELSE MAX (Container) + '/ ' + MAX (TRUCK_NUMBER) END AS INT2,"
            sql &= "max(PRODUCT_CODE) As ST2,"
            sql &= "max(ADDNOTEDATE) As DT1,"
            sql &= "isnull(MAX(Driver_NAME), '' ) + '  ' + isnull( MAX (Driver_Lastname), '' ) AS ST1,"
            sql &= "max(REFERENCE) As INT3, "
            sql &= "max(LOAD_SEAL) As ST4,"
            sql &= "max(DATE_START) As DT2,"
            sql &= "max(LC_COMPARTMENT) As INT5,"
            sql &= "max(LOADDO) As INT6,"
            sql &= "max(BATCH_NAME) As ST3,"
            sql &= "cast(max(T_LOADINGNOTECOMPARTMENT.LC_PRESET) as float) As F2,"
            sql &= "sum(MASS) As F3,"
            sql &= "sum(GROSS_M1) As F4,"
            sql &= "max(AVG_TEMP) As F5,"
            sql &= "max(AVERAGE_DATA_SPECIFIED_BY_PARAMETER_N21041) As F6,"
            sql &= "max(METER_FACTOR) As F7,"
            sql &= "min(DATE_START) As DT7,"
            sql &= "max(DATE_END) As DT8,"
            sql &= "min(WEIGHTIN_TIME) As DT6,"
            sql &= "max(WEIGHTOUT_TIME) As DT9,"
            sql &= "sum(RAW_WEIGHT_IN) As F8,"
            sql &= "sum(RAW_WEIGHT_OUT) As F9 "
            sql &= "FROM(Select * FROM T_LOADINGNOTE WHERE reference= '" & ref & "' ) T_LOADINGNOTE "
            sql &= "Left Join (select * from T_LOADINGNOTECOMPARTMENT where lc_status in(2,3,4)) T_LOADINGNOTECOMPARTMENT On T_LOADINGNOTE.LOAD_ID = T_LOADINGNOTECOMPARTMENT.LC_LOAD "
            sql &= "Left Join T_TRUCK On T_LOADINGNOTE.LOAD_VEHICLE = T_TRUCK.ID "
            sql &= "Left Join T_CUSTOMER On T_LOADINGNOTE.LOAD_CUSTOMER = T_CUSTOMER.ID "
            sql &= "Left Join T_DRIVER On T_LOADINGNOTE.LOAD_DRIVER = T_DRIVER.ID "
            sql &= "Left Join T_CARD On T_LOADINGNOTE.LOAD_CARD = T_CARD.CARD_NUMBER "
            sql &= "Left Join  T_BATCHMETER on T_LOADINGNOTECOMPARTMENT.LC_METER = T_BATCHMETER.ID "
            sql &= "Left Join T_PRODUCT On T_LOADINGNOTECOMPARTMENT.LC_PRO = T_PRODUCT.ID "
            sql &= "Left Join T_LOG_BATCH_DATA On T_LOADINGNOTECOMPARTMENT.LC_ID = T_LOG_BATCH_DATA.LC_ID "
            sql &= "Group BY Reference, Lc_Compartment "
            sql &= "ORDER BY reference, Lc_Compartment "


            Dim MyDataSet As New DataSet
            'MyDataSet = cls.Query_DS(sql, "V_BOL_M1M2_NEW")
            MyDataSet = cls.Query_DS(sql, "DataTable_Report1")

            Myreport.Load("Report_File/BOL_R2.rpt")
            Myreport.SetDataSource(MyDataSet)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()
            MyDataSet.Dispose()
            Myreport.Close()
            Myreport.Dispose()



            Try
                Memory = New MemoryManagement.Manage
                Memory.FlushMemory()
            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try

    End Sub



    Private Sub ReportBOL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadCalendar1.SelectedDate = Date.Now.Date
    End Sub

    Private Sub ReportBOL_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        'RadCalendar1_SelectionChanged(sender, e)
        SelectCalendar()
    End Sub

    Private Sub VBOLM1M2NewBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VBOLM1M2NewBindingSource.PositionChanged
        P_SUM.Text = VBOLM1M2NewBindingSource.Count.ToString
    End Sub

    Private Sub MasterGrid_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs)
        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        Try

            Dim n_year As Integer = 0
            n_year = 543
            Dim ref, sql As String
            ref = MasterGrid.CurrentRow.Cells("reference").Value.ToString
            Dim Myreport As New ReportDocument
            Myreport = New ReportDocument
            sql = ""
            sql = "select max(Reference) as Reference,"
            sql &= "max(St_ST_date) as St_ST_date,Sum(Gross_m1) as Gross_m1,Sum(Net_m1) as Net_m1,min(Startm1) as Startm1,max(Stopm1) as Stopm1,min(Startm1_net) as Startm1_net,max(Stopm1_net) as Stopm1_net, "

            sql &= "min(St_ST_time_start) as St_ST_time_start,max(St_ST_time_stop) as St_ST_time_stop,max(Batch_name) as Batch_name,max(Lc_Compartment) as Lc_Compartment,max(LC_preset) as LC_preset,max(Load_driver) as Load_driver,max(load_customer) as load_customer,max(load_Vehicle) as load_Vehicle,max(Product_code) as Product_code,max(lc_tank) as lc_tank,"

            sql &= "max(Avg_temp_m1) as Avg_temp_m1,max(load_dofull) as load_dofull,max(addnotedate) as addnotedate,min(Q_time) as Q_time,min(Checkin_time) as Checkin_time,max(VCF_M1) as VCF_M1,max(Density30C_M1) as Density30C_M1,max(DO_TYPE) as DO_TYPE,max(Product_name) as Product_name,max(LC_Seal) as LC_Seal"
            sql &= " from v_bol_m1m2_new where addnotedate = '" + String.Format("{0:yyyy-M-d}", DateAdd(DateInterval.Year, -n_year, RadCalendar1.SelectedDate)) + "' and lc_status in(3,4) "
            sql &= "group by Reference,Lc_Compartment order by reference,Lc_Compartment"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "V_BOL_M1M2_NEW")

            Myreport.Load("BOLToday.rpt")
            Myreport.SetDataSource(MyDataSet)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()
            MyDataSet.Dispose()

            Try
                Memory = New MemoryManagement.Manage
                Memory.FlushMemory()
            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim q As String
        Dim Diff As Double = 0

        q = "Select * from t_tankstock   where tankno in('02-TK-810A') and "
        q &= "(Substr(TO_CHAR(Creatdate, 'YYYY-MM-DD HH24:MI:SS'),15,5) = '00:00' OR Substr(TO_CHAR(Creatdate, 'YYYY-MM-DD HH24:MI:SS'),15,5) = '00:01' ) "
        q &= "and id between '379860' and '380436'"
        q &= "order by Creatdate desc "

        Dim dt As DataTable = cls.Query(q)

        For i = 0 To dt.Rows.Count - 1
            Try
                'TextBox1.Text = dt.Rows(i).Item("TOV").ToString
                'TextBox2.Text = dt.Rows(i + 1).Item("TOV").ToString
                'TextBox3.Text = CDbl(dt.Rows(i).Item("TOV")) - CDbl(dt.Rows(i + 1).Item("TOV"))

                Diff = CDbl(dt.Rows(i).Item("TOV")) - CDbl(dt.Rows(i + 1).Item("TOV"))
                q = "Update t_tankstock set Tov_Diff='" & Diff & "' where ID = '" & dt.Rows(i).Item("ID").ToString & "'"

                cls.Update(q)
            Catch ex As Exception
            End Try
        Next

    End Sub

    Private Sub RadCalendar1_SelectionChanged(sender As Object, e As MouseEventArgs)
        SelectCalendar()
    End Sub
    Private Sub SelectCalendar()
        Try
            RadTextBox1.Text = RadCalendar1.SelectedDate  'RadCalendar1
            Dim sql As String
            sql = "Select REFERENCE as REFERENCE,REFERENCE As INT1,isnull(Driver_NAME, '' ) + '  ' + isnull(Driver_Lastname, '' ) AS ST1,TRUCK_NUMBER As INT2,LOAD_DATE As DT1,LOAD_CARD As INT3 "
            sql &= "FROM (SELECT * FROM T_LOADINGNOTE WHERE (DAY(LOAD_DATE) = '" & RadCalendar1.SelectedDate.Day & "' and MONTH(LOAD_DATE) = '" & RadCalendar1.SelectedDate.Month & "' and YEAR(LOAD_DATE) = '" & RadCalendar1.SelectedDate.Year & "' ) and LOAD_STATUS in (3,4)) T_LOADINGNOTE "
            sql &= "Left join T_STATUS On T_STATUS.STATUS_ID = T_LOADINGNOTE.LOAD_STATUS "
            sql &= "Left Join T_TRUCK on T_LOADINGNOTE.LOAD_VEHICLE = T_TRUCK.ID "
            sql &= "Left Join T_CUSTOMER on T_LOADINGNOTE.LOAD_CUSTOMER = T_CUSTOMER.ID "
            sql &= "Left Join T_DRIVER on T_LOADINGNOTE.LOAD_DRIVER = T_DRIVER.ID "
            sql &= "Left Join T_CARD on T_LOADINGNOTE.LOAD_CARD = T_CARD.CARD_NUMBER "
            sql &= "Left Join T_PRODUCT on T_LOADINGNOTE.LOAD_PRODUCT = T_PRODUCT.ID order by Reference"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "BOL_Report")
            VBOLM1M2NewBindingSource.DataSource = MyDataSet
            VBOLM1M2NewBindingSource.DataMember = "BOL_Report"
            MyDataSet.Dispose()

            'Try
            '    Memory = New MemoryManagement.Manage
            '    Memory.FlushMemory()
            'Catch ex As Exception
            'End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadCalendar1_SelectionChanged(sender As Object, e As EventArgs) Handles RadCalendar1.SelectionChanged
        SelectCalendar()
    End Sub

    Private Sub RadCalendar1_MouseUp(sender As Object, e As MouseEventArgs) Handles RadCalendar1.MouseUp
        SelectCalendar()
    End Sub
End Class
