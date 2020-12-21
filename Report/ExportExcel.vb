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
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports Excel = Microsoft.Office.Interop.Excel

Public Class ExportExcel

    Private cls As New Class_SQKDB
    Private Sub SelectTime()
        Dim sql As String
        Try
            sql = "select to_char(max(load_date)) as L_Date,Product_code,max(t1.lc_tank) as Batch_pro,Sum(t1.lc_preset) as Presets,ROUND(Sum(t2.Gross),3) as Gross,ROUND(Sum(t2.net86f),3) as net,ROUND(Sum(t1.lc_preset-t2.gross),3) as Loss "
            sql &= "from (select * from v_loadingnote where lc_status in(3,4)) t1  left join (select * from V_report_meter) t2  "
            sql &= "on t1.reference=t2.st_ref_no and t1.lc_compartment=t2.sy_comp "
            sql &= "where t1.load_date between "
            sql &= "To_date('" & DTP2.Value.Year & "/" & DTP2.Value.Month & "/" & DTP2.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
            sql &= "To_date('" & DTP3.Value.Year & "/" & DTP3.Value.Month & "/" & DTP3.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  and lc_status in(3,4)  "
            sql &= "group by Product_code,to_date(load_date,'dd/mm/yyyy') order by to_date(load_date,'dd/mm/yyyy'),t1.Product_code "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "TimeResult")

            BindingSource1.DataSource = MyDataSet
            BindingSource1.DataMember = "TimeResult"

        Catch ex As Exception

        End Try
    End Sub


    Private Sub ExportExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'IRPCDataset.V_BOL_M1M2_NEW' table. You can move, or remove it, as needed.
        'Me.V_BOL_M1M2_NEWTableAdapter.Fill(Me.IRPCDataset.V_BOL_M1M2_NEW)
        SelectTime()
    End Sub

    Private Sub B_ExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_ExportExcel.Click
        Try
            SelectTime()
            Dim s_day, s_month, s_year, s_hr, s_mn, s_sc, TTimes As String
            s_day = Date.Now.Day
            s_month = Date.Now.Month
            s_year = Date.Now.Year
            s_hr = Date.Now.Hour
            s_mn = Date.Now.Minute
            s_sc = Date.Now.Second
            TTimes = s_day & s_month & s_year & "-" & s_hr & s_mn & s_sc

            Dim SetupPath As String = "c:\รายงานการจ่ายผลิตภัณฑ์_" & TTimes.ToString & ".xlsx"

            Dim xlApp As Excel.Application = New Excel.Application

            xlApp.SheetsInNewWorkbook = 1

            Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim xlWorkSheet As Excel.Worksheet = xlWorkBook.Worksheets.Item(1)

            xlWorkSheet.Name = "รายงานการจ่ายผลิตภัณฑ์"

            For nRow = 0 To RadGridView1.Rows.Count - 1

                For nCol = 0 To RadGridView1.Columns.Count - 1
                    xlWorkSheet.Cells(nRow + 1, nCol + 1) = "'" & RadGridView1.Rows(nRow).Cells(nCol).Value
                Next nCol

            Next nRow

            xlApp.DisplayAlerts = False

            xlWorkBook.SaveAs(SetupPath, Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
                               Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlLocalSessionChanges)

            xlWorkBook.Close()
            xlApp.Quit()
            MessageBox.Show("Export เรียบร้อยไฟล์ถูกบันทึกที่ " & SetupPath.ToString & "", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub BClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClose.Click
        Me.Close()
    End Sub
End Class
