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
Imports System.Globalization

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
            sql = ""
            sql = "select max(Reference) as Reference,"
            sql &= "max(St_ST_date) as St_ST_date,sum(Gross_m1) as Gross_m1,sum(net86f) as Net_m1,min(Startm1) as Startm1,max(Stopm1) as Stopm1,min(Startm1_net) as Startm1_net,max(Stopm1_net) as Stopm1_net, "

            sql &= "Isnull(to_char(min(LC_STARTTIME),'HH24:MI:SS'),min(St_ST_time_start)) as St_ST_time_start,to_char(max(LC_ENDTIME),'HH24:MI:SS') as St_ST_time_stop,max(Batch_name) as Batch_name,max(Lc_Compartment) as Lc_Compartment,max(LC_preset) as LC_preset,max(Load_driver) as Load_driver,max(load_customer) as load_customer,max(load_Vehicle) as load_Vehicle,max(Product_code) as Product_code,max(lc_tank) as lc_tank,"
            sql &= "max(Avg_temp_m1) as Avg_temp_m1,max(load_dofull) as load_dofull,max(addnotedate) as addnotedate,min(Q_time) as Q_time,min(Checkin_time) as Checkin_time,max(VCF_M1) as VCF_M1,max(Density30C_M1) as Density30C_M1,max(DO_TYPE) as DO_TYPE,max(Product_name) as Product_name,"
            sql &= "max(LC_Seal) as LC_Seal,MAX(lc_additive) as Lc_additive,max(checkout_time) as checkout_time "

            sql &= " from v_bol_m1m2_new where reference='" & ref & "' group by Reference,Lc_Compartment order by reference,Lc_Compartment"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "V_BOL_M1M2_NEW")

            Myreport.Load("BOL.rpt")
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

    Private Sub RadCalendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCalendar1.SelectionChanged
        Try
            RadTextBox1.Text = RadCalendar1.SelectedDate  'RadCalendar1
            Dim sql As String

            sql = ""
            sql = "select T1.reference,T1.load_date,T2.Load_Driver,T3.Truck_Number as LOAD_VEHICLE,tcard.card_number as load_card,T1.AddnoteDate as LDate  from "
            sql &= "(select reference,load_driver,load_vehicle,load_preset,load_date,load_card,AddnoteDate from t_loadingnote where load_status in(3,4) "
            sql &= "and CAST(EXTRACT(YEAR FROM T_LOADINGNOTE.AddnoteDate) AS VARCHAR2(10)) || '-' || CAST(EXTRACT(MONTH FROM T_LOADINGNOTE.AddnoteDate) AS VARCHAR2(10)) "
            Dim n_year As Integer = 0
            n_year = 543
            sql &= "|| '-' || CAST(EXTRACT(DAY FROM T_LOADINGNOTE.AddnoteDate) AS VARCHAR2(10)) ='" + String.Format("{0:yyyy-M-d}", DateAdd(DateInterval.Year, -n_year, RadCalendar1.SelectedDate)) + "') T1 Left Join "
            sql &= "(select ID,Driver_NAME|| '  ' || Driver_Lastname AS LOAD_DRIVER from T_driver) T2 ON T1.load_driver=T2.ID Left Join "
            sql &= "(select ID,truck_number from t_truck) T3 ON T1.load_vehicle=T3.ID left join "
            sql &= "(select ID,card_number  from t_card) TCard  ON T1.load_card=Tcard.ID order by t1.reference "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "V_BOL_M1M2_NEW")

            VBOLM1M2NewBindingSource.DataSource = MyDataSet
            VBOLM1M2NewBindingSource.DataMember = "V_BOL_M1M2_NEW"
            MyDataSet.Dispose()

            Try
                Memory = New MemoryManagement.Manage
                Memory.FlushMemory()
            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ReportBOL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet_View.V_BOL_M1M2_NEW' table. You can move, or remove it, as needed.
        Me.V_BOL_M1M2_NEWTableAdapter.Fill(Me.DataSet_View.V_BOL_M1M2_NEW)
        RadCalendar1.SelectedDate = Date.Now.Date
    End Sub

    Private Sub ReportBOL_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        RadCalendar1_SelectionChanged(sender, e)
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

    Private Sub RadButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton2.Click

        Dim q As String
        Dim Diff As Double = 0

        q = "Select * from t_tankstock   where tankno in('02-TK-810A') and "
        q &= "(Substr(TO_CHAR(Creatdate, 'YYYY-MM-DD HH24:MI:SS'),15,5) = '00:00' OR Substr(TO_CHAR(Creatdate, 'YYYY-MM-DD HH24:MI:SS'),15,5) = '00:01' ) "
        q &= "and id between '379860' and '380436'"
        q &= "order by Creatdate desc "

        Dim dt As DataTable = cls.Query(q)

        For i = 0 To dt.Rows.Count - 1
            Try
                TextBox1.Text = dt.Rows(i).Item("TOV").ToString
                TextBox2.Text = dt.Rows(i + 1).Item("TOV").ToString
                TextBox3.Text = CDbl(dt.Rows(i).Item("TOV")) - CDbl(dt.Rows(i + 1).Item("TOV"))

                Diff = CDbl(dt.Rows(i).Item("TOV")) - CDbl(dt.Rows(i + 1).Item("TOV"))
                q = "Update t_tankstock set Tov_Diff='" & Diff & "' where ID = '" & dt.Rows(i).Item("ID").ToString & "'"

                cls.Update(q)
            Catch ex As Exception
            End Try
        Next

    End Sub
End Class
