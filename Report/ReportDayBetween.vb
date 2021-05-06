Imports System.Data
Imports System
Imports System.IO
Imports System.Data.Common
Imports ExtendedErrorProvider
Imports Telerik.WinControls.UI
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Threading
Imports System.Drawing.Printing
Imports System.ComponentModel

Public Class ReportDayBetween
    Private cls As New Class_SQLSERVERDB
    Dim chk As Integer
    Dim n_year As Integer = 543
    Dim Memory As MemoryManagement.Manage

#Region "Windows event"
    Private Sub CHKBetween_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKBetween.Click
        chk = 1
        GB1.Enabled = False
        GB2.Enabled = True
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Dim sql As String

        chk = 1
        n_year = 543
        Try
            '' Between ''
            If Reportmain.Report_Type = "productpay" Then

                Dim Myreport As New ReportDocument
                Myreport = New ReportDocument
                sql = "select min(load_date) as MinL_Date,max(load_date) as L_Date,Product_code,max(t1.lc_tank) as Batch_pro,Sum(t1.lc_preset) as Presets,Sum(t2.Gross) as Gross,Sum(t2.net86f) as net,Sum(t1.lc_preset-t2.gross) as Loss "
                sql &= "from (select * from v_loadingnote where lc_status in(3,4)) t1  left join (select * from V_report_meter) t2  "
                sql &= "on t1.reference=t2.st_ref_no and t1.lc_compartment=t2.sy_comp "
                sql &= "where t1.load_date between "
                sql &= "CONVERT (DATETIME,'" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
                sql &= "CONVERT (DATETIME,'" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  and lc_status in(3,4)  "
                sql &= "group by t1.Product_code,lc_tank order by t1.Product_code,lc_tank"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(sql, "V_Product_total")

                If MyDataSet.Tables(0).Rows.Count = 0 Then
                    MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
                    Exit Sub
                Else
                    Myreport.Load("Productsum.rpt")
                    Myreport.SetDataSource(MyDataSet)
                    ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                    ReportPrint.ShowDialog()
                    MyDataSet.Dispose()
                End If
            End If

            If Reportmain.Report_Type = "time" Then

                Dim Myreport As New ReportDocument
                Myreport = New ReportDocument

                sql = "select max(load_date) as dt1,"
                sql &= "max(lc_compartment) as int4, "
                sql &= "max(reference) as int1,"
                sql &= "max(load_dofull) as int2,"
                sql &= "max(customer_name) as st1,"
                sql &= "max(product_name) as st2,"
                sql &= "max(avg_temp) as f1,"
                sql &= "max(t_loadingnotecompartment.lc_preset) as f2,"
                sql &= "sum(mass) as f3,"
                sql &= "max(meter_factor) as f4,"
                sql &= "max(average_data_specified_by_parameter_n21041) as f5,"
                sql &= "sum(total_mass_start) as f7,"
                sql &= "sum(total_mass_end) as f8,"
                sql &= "sum(lc_batchmassbase) as f9,"
                sql &= "max(truck_number) as int3,"
                sql &= "isnull( max (driver_name), '' ) + '  ' + isnull( max (driver_lastname), '' ) as st3,"
                sql &= "max(weightin_time) as dt2,"
                sql &= "max(date_end) as dt4 ,"
                sql &= "min(date_start) as dt3, "
                sql &= "max(weightout_time) as dt5 "
                sql &= "from( select * from t_loadingnote where load_date between "
                sql &= "convert(datetime, '" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "') and "
                sql &= "convert(datetime, '" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "') and load_status in (3,4)) t_loadingnote "
                sql &= "left join (select * from t_loadingnotecompartment where lc_status in(2,3,4)) t_loadingnotecompartment  on t_loadingnote.load_id = t_loadingnotecompartment.lc_load "
                sql &= "left join t_truck on t_loadingnote.load_vehicle = t_truck.id "
                sql &= "left join t_customer on t_loadingnote.load_customer = t_customer.id "
                sql &= "left join t_driver on t_loadingnote.load_driver = t_driver.id "
                sql &= "left join t_card on t_loadingnote.load_card = t_card.card_number "
                sql &= "left join t_product on t_loadingnotecompartment.lc_pro = t_product.id "
                sql &= "left join t_status on t_loadingnote.load_status = t_status.status_id "
                sql &= "left join  t_batchmeter on t_loadingnotecompartment.lc_meter = t_batchmeter.id "
                sql &= "left join t_log_batch_data on t_loadingnotecompartment.lc_id = t_log_batch_data.lc_id "
                sql &= "group by load_id, lc_compartment "
                sql &= "order by load_id, lc_compartment"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(sql, "DataTable_Report1")
                'MyDataSet = cls.Query_DS(sql, "DataTable_Report")

                If MyDataSet.Tables(0).Rows.Count = 0 Then
                    MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
                    Exit Sub
                Else
                    'Myreport.Load("BOLToday.rpt")
                    Myreport.Load("Report_File/DailyReport.rpt")
                    Myreport.SetDataSource(MyDataSet)
                    ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                    ReportPrint.ShowDialog()
                    MyDataSet.Dispose()

                End If
            End If
            If Reportmain.Report_Type = "customer" Then
                Dim Myreport As New ReportDocument
                Myreport = New ReportDocument
                sql = ""
                sql = "select l_date,load_customer,product_name,max(company_name) as company_name, "
                sql &= "sum(presets) as presets,sum(grosss) as grosss,sum(net) as net,sum(loss) as loss from v_truck_loading_report "
                sql &= "where l_date between convert (datetime,'" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd hh24:mi:ss') and "
                sql &= "convert (datetime,'" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd hh24:mi:ss')  "
                sql &= "group by l_date,load_customer,product_name order by l_date,load_customer,product_name"

                Dim myDataSet As New DataSet
                myDataSet = cls.Query_DS(sql, "V_TRUCK_LOADING_REPORT")

                If myDataSet.Tables(0).Rows.Count = 0 Then
                    MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
                    Exit Sub
                Else
                    Myreport.Load("Customerreport.rpt")
                    Myreport.SetDataSource(myDataSet)
                    ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                    ReportPrint.ShowDialog()
                    myDataSet.Dispose()
                End If
            End If


            If Reportmain.Report_Type = "meter" Then
                Dim Myreport As New ReportDocument
                Myreport = New ReportDocument
                sql = "select max(ldate) as dt1,"
                sql &= "max(product_code) as st1,"
                sql &= "batch_name as st2,"
                sql &= "sum(t_log_batch_data.preset) as f1,"
                sql &= "sum(mass) as f2,"
                sql &= "min(total_mass_start) as f3,"
                sql &= "max(total_mass_end) as f4 "
                sql &= "from(select * from t_log_batch_data where ldate between "
                sql &= "convert(datetime, '" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "') and "
                sql &= "convert(datetime, '" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "')) t_log_batch_data "
                sql &= "left join t_batchmeter on t_log_batch_data.batch_number = t_batchmeter.batch_number "
                sql &= "left join t_product on t_log_batch_data.delivered_product = t_product.id "
                sql &= "group by batch_name"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(sql, "DataTable_Report1")
                ' MyDataSet = cls.Query_DS(sql, "v_meter_controlling")

                If MyDataSet.Tables(0).Rows.Count = 0 Then
                    MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
                    Exit Sub
                Else
                    'Myreport.Load("Metersum_BTW.rpt")

                    Myreport.Load("Report_File/MeterReport.rpt")
                    Myreport.SetDataSource(MyDataSet)
                    ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                    ReportPrint.ShowDialog()
                    'ReportPrint.ShowDialog()
                    MyDataSet.Dispose()
                End If


            End If
            If Reportmain.Report_Type = "tank" Then
                Dim Myreport As New ReportDocument
                Myreport = New ReportDocument

                sql = ""
                sql = "select * from v_Tankstock Where "
                sql &= "CAST(EXTRACT(YEAR FROM V_tankstock.creatdate) AS VARCHAR2(10)) || '-' || "
                sql &= "CAST(EXTRACT(MONTH FROM V_tankstock.creatdate) AS VARCHAR2(10)) || '-' || "
                sql &= "CAST(EXTRACT(DAY FROM V_tankstock.creatdate) AS VARCHAR2(10)) between '" + String.Format("{0:yyyy-M-d}", DateAdd(DateInterval.Year, -n_year, DTP2.Value)) + "' and '" + String.Format("{0:yyyy-M-d}", DateAdd(DateInterval.Year, -n_year, DTP3.Value)) + "'"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(sql, "v_Tankstock")

                If MyDataSet.Tables(0).Rows.Count = 0 Then
                    MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
                    Exit Sub
                Else
                    Myreport.Load("tankstock.rpt")
                    Myreport.SetDataSource(MyDataSet)
                    ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                    ReportPrint.ShowDialog()
                    MyDataSet.Dispose()
                End If
            End If
            If Reportmain.Report_Type = "unloading" Then
                Dim Myreport As New ReportDocument
                Myreport = New ReportDocument
                sql = ""
                sql = "Select * from v_unloadreport "

                sql &= "where load_Date between CONVERT (DATETIME,'" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
                sql &= "CONVERT (DATETIME,'" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "
                sql &= " order by load_id"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(sql, "v_unloadreport")

                If MyDataSet.Tables(0).Rows.Count = 0 Then
                    MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
                    Exit Sub
                Else
                    Myreport.Load("ReportUnloadingDay.rpt")
                    Myreport.SetDataSource(MyDataSet)
                    ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                    ReportPrint.ShowDialog()
                    MyDataSet.Dispose()
                End If
            End If
            If Reportmain.Report_Type = "product" Then
                Dim Myreport As New ReportDocument
                Myreport = New ReportDocument
                sql = ""
                sql = "Select * from v_unloadreport where "
                sql &= "CAST(EXTRACT(YEAR FROM v_unloadreport.load_date) AS VARCHAR2(10)) || '-' || "
                sql &= "CAST(EXTRACT(MONTH FROM v_unloadreport.load_date) AS VARCHAR2(10)) || '-' || "
                sql &= "CAST(EXTRACT(DAY FROM v_unloadreport.load_date) AS VARCHAR2(10)) between '" + String.Format("{0:yyyy-M-d}", DateAdd(DateInterval.Year, -n_year, DTP2.Value)) + "' and '" + String.Format("{0:yyyy-M-d}", DateAdd(DateInterval.Year, -n_year, DTP3.Value)) + "'"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(sql, "v_unloadreport")

                If MyDataSet.Tables(0).Rows.Count = 0 Then
                    MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
                    Exit Sub
                Else
                    Myreport.Load("ReportProductDay.rpt")
                    Myreport.SetDataSource(MyDataSet)
                    ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                    ReportPrint.ShowDialog()
                    MyDataSet.Dispose()
                End If
            End If


            If Reportmain.Report_Type = "customerrut" Then
                Dim Myreport As New ReportDocument
                Myreport = New ReportDocument
                sql = ""
                sql = "Select * from v_unloadreport where "
                sql &= "CAST(EXTRACT(YEAR FROM v_unloadreport.load_date) AS VARCHAR2(10)) || '-' || "
                sql &= "CAST(EXTRACT(MONTH FROM v_unloadreport.load_date) AS VARCHAR2(10)) || '-' || "
                sql &= "CAST(EXTRACT(DAY FROM v_unloadreport.load_date) AS VARCHAR2(10)) between '" + String.Format("{0:yyyy-M-d}", DateAdd(DateInterval.Year, -n_year, DTP2.Value)) + "' and '" + String.Format("{0:yyyy-M-d}", DateAdd(DateInterval.Year, -n_year, DTP3.Value)) + "'"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(sql, "v_unloadreport")

                If MyDataSet.Tables(0).Rows.Count = 0 Then
                    MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
                    Exit Sub
                Else
                    Myreport.Load("ReportCustomerDay.rpt")
                    Myreport.SetDataSource(MyDataSet)
                    ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                    ReportPrint.ShowDialog()
                    MyDataSet.Dispose()
                End If
            End If

            If Reportmain.Report_Type = "Event" Then

                Dim Myreport As New ReportDocument
                Myreport = New ReportDocument

                sql = "Select * from V_EVENT "
                sql &= "where EV_DATE between "
                sql &= "CONVERT (DATETIME,'" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
                sql &= "CONVERT (DATETIME,'" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "
                sql &= " order by EV_ID"

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(sql, "V_EVENT")

                If MyDataSet.Tables(0).Rows.Count = 0 Then
                    MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
                    Exit Sub
                Else
                    Myreport.Load("Event.rpt")
                    Myreport.SetDataSource(MyDataSet)
                    ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                    ReportPrint.ShowDialog()
                    MyDataSet.Dispose()
                End If
            End If


        Catch ex As Exception
        End Try

        Try
            Memory = New MemoryManagement.Manage
            Memory.FlushMemory()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClose.Click
        Me.Close()
    End Sub

    Private Sub ReportDayBetween_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DTP1.Value = Date.Now.Date
        DTP2.Value = Date.Now.Date
        DTP3.Value = Date.Now.Date
    End Sub

    Private Sub ReportDayBetween_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Header.Text = Reportmain.Header_name.ToString
        If Reportmain.Report_Type = "productpay" Then
            B_ExportExcel.Visible = True
        Else
            B_ExportExcel.Visible = False
        End If
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub B_ExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ExportExcel.Click
        ExportExcel.Header.Text = Reportmain.Header_name.ToString
        Me.AddOwnedForm(ExportExcel)
        ExportExcel.Show()
    End Sub
#End Region

#Region "Funtion"
    Sub ManualReport()
        Dim Myreport As New ReportDocument
        Myreport = New ReportDocument
        Dim sql As String = ""
        sql = "select max(ldate) as dt1,"
        Sql &= "max(product_code) as st1,"
        Sql &= "batch_name as st2,"
        Sql &= "sum(t_log_batch_data.preset) as f1,"
        Sql &= "sum(mass) as f2,"
        Sql &= "min(total_mass_start) as f3,"
        Sql &= "max(total_mass_end) as f4 "
        Sql &= "from(select * from t_log_batch_data where ldate between "
        Sql &= "convert(datetime, '" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "') and "
        Sql &= "convert(datetime, '" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "')) t_log_batch_data "
        Sql &= "left join t_batchmeter on t_log_batch_data.batch_number = t_batchmeter.batch_number "
        Sql &= "left join t_product on t_log_batch_data.delivered_product = t_product.id "
        Sql &= "group by batch_name"

        Dim MyDataSet As New DataSet
        MyDataSet = cls.Query_DS(sql, "DataTable_Report1")
        If MyDataSet.Tables(0).Rows.Count = 0 Then
            MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
            Exit Sub
        Else
            'Myreport.Load("Metersum_BTW.rpt")

            Myreport.Load("Report_File/MeterReport.rpt")
            Myreport.SetDataSource(MyDataSet)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()
            'ReportPrint.ShowDialog()

        End If
        MyDataSet.Dispose()

    End Sub
#End Region

End Class
