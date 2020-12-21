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
    Private cls As New Class_SQKDB
    Dim chk As Integer
    Dim n_year As Integer = 543
    Dim Memory As MemoryManagement.Manage

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
            If chk = 1 Then
                If Reportmain.Report_Type = "productpay" Then

                    Dim Myreport As New ReportDocument
                    Myreport = New ReportDocument
                    sql = "select min(load_date) as MinL_Date,max(load_date) as L_Date,Product_code,max(t1.lc_tank) as Batch_pro,Sum(t1.lc_preset) as Presets,Sum(t2.Gross) as Gross,Sum(t2.net86f) as net,Sum(t1.lc_preset-t2.gross) as Loss "
                    sql &= "from (select * from v_loadingnote where lc_status in(3,4)) t1  left join (select * from V_report_meter) t2  "
                    sql &= "on t1.reference=t2.st_ref_no and t1.lc_compartment=t2.sy_comp "
                    sql &= "where t1.load_date between "
                    sql &= "To_date('" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
                    sql &= "To_date('" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  and lc_status in(3,4)  "
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
                    sql = ""
                    sql = "select max(Reference) as Reference,"
                    sql &= "max(St_ST_date) as St_ST_date,sum(Gross_m1) as Gross_m1,Sum(Net_m1) as Net_m1,Sum(Net86f) as NET86F,"
                    sql &= "(max(lc_preset)-Sum(Gross_m1)) as LOSS_M1,Sum(Loss_M1) as LOSS_M1xx,min(Startm1) as Startm1,max(Stopm1) as Stopm1,min(Startm1_net) as Startm1_net,max(Stopm1_net) as Stopm1_net, "
                    sql &= "min(St_ST_time_start) as St_ST_time_start,max(St_ST_time_stop) as St_ST_time_stop,max(Batch_name) as Batch_name,max(Lc_Compartment) as Lc_Compartment,max(LC_preset) as LC_preset,max(Load_driver) as Load_driver,max(load_customer) as load_customer,max(load_Vehicle) as load_Vehicle,max(Product_code) as Product_code,max(lc_tank) as lc_tank,"
                    sql &= "max(Avg_temp_m1) as Avg_temp_m1,max(load_dofull) as load_dofull,max(addnotedate) as addnotedate,min(Q_time) as Q_time,min(Checkin_time) as Checkin_time,max(VCF_M1) as VCF_M1,max(Density30C_M1) as Density30C_M1,max(DO_TYPE) as DO_TYPE,max(Product_name) as Product_name,max(LC_Seal) as LC_Seal"
                    sql &= ",max(Customer_name) as Customer_Name,sum(Gross_M1) as Gross_M1 "
                    sql &= " from v_bol_m1m2_new where addnotedate between "
                    sql &= "To_date('" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
                    sql &= "To_date('" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "
                    sql &= "and lc_status in(3,4) "
                    sql &= "group by Reference,Lc_Compartment order by reference,Lc_Compartment"

                    Dim MyDataSet As New DataSet
                    MyDataSet = cls.Query_DS(sql, "V_BOL_M1M2_NEW")

                    If MyDataSet.Tables(0).Rows.Count = 0 Then
                        MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
                        Exit Sub
                    Else
                        Myreport.Load("BOLToday.rpt")
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
                    sql = "select L_date,load_customer,Product_name,max(company_name) as company_name, "
                    sql &= "Sum(Presets) as PRESETs,Sum(Grosss) as Grosss,Sum(net) as Net,Sum(loss) as Loss from V_TRUCK_LOADING_REPORT "
                    sql &= "where L_Date between To_date('" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
                    sql &= "To_date('" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "
                    sql &= "Group by L_date,load_customer,product_name Order by L_date,load_customer,product_name"

                    Dim MyDataSet As New DataSet
                    MyDataSet = cls.Query_DS(sql, "V_TRUCK_LOADING_REPORT")

                    If MyDataSet.Tables(0).Rows.Count = 0 Then
                        MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
                        Exit Sub
                    Else
                        Myreport.Load("Customerreport.rpt")
                        Myreport.SetDataSource(MyDataSet)
                        ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                        ReportPrint.ShowDialog()
                        MyDataSet.Dispose()
                    End If
                End If


                If Reportmain.Report_Type = "meter" Then
                    Dim Myreport As New ReportDocument
                    Myreport = New ReportDocument

                    sql = "select t1.batch_name,max(load_date) as L_Date,max(Product_code) as Product_code,"
                    sql &= "max(t1.addnotedate) as ST_DATE,"
                    sql &= "To_date(max(t1.addnotedate), 'dd/mm/yyyy') as ST_DATE1,"
                    sql &= "Sum(t1.lc_preset) as Presets,Sum(t2.Gross) as Gross,Sum(t2.net86f) as net,Sum(t1.lc_preset-t2.gross) as Loss "
                    sql &= ",min(Sy_Start_total_m1) as Sy_Start_total_m1,max(Sy_Stop_total_m1) as Sy_Stop_total_m1 "
                    sql &= "from (select * from v_loadingnote where  advisenote_type<>'TOPUP' and lc_status in(3,4)) t1  left join (select * from V_report_meter) t2 "
                    sql &= "on t1.reference=t2.st_ref_no and t1.lc_compartment=t2.sy_comp "
                    sql &= "where T1.addnotedate between "
                    sql &= "To_date('" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
                    sql &= "To_date('" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "
                    sql &= "group by t1.batch_name order by t1.batch_name"

                    Dim MyDataSet As New DataSet
                    MyDataSet = cls.Query_DS(sql, "v_meter_controlling")

                    If MyDataSet.Tables(0).Rows.Count = 0 Then
                        MsgBox("No Data, Cannot Print!", vbOKOnly + vbDefaultButton3, "Error")
                        Exit Sub
                    Else
                        Myreport.Load("Metersum_BTW.rpt")
                        Myreport.SetDataSource(MyDataSet)
                        ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                        ReportPrint.ShowDialog()
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

                    sql &= "where load_Date between To_date('" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
                    sql &= "To_date('" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "
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
                    sql &= "To_date('" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
                    sql &= "To_date('" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "
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
End Class
