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

Public Class ReportTank
    Private cls As New Class_SQKDB

    Private Sub ReportTank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadCalendar1.SelectedDate = Date.Now.Date
    End Sub

    Private Sub BClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClose.Click
        Me.Close()
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Try
            Dim ref, sql As String
            Dim Myreport As New ReportDocument
            Myreport = New ReportDocument
            ' sql = "Select * from V_tankstock where creatdate ='" + String.Format("{0:dd/MM/yyyy}", RadCalendar1.SelectedDate) + "' "

            sql = ""
            sql = "select * from v_Tankstock Where "
            sql &= "CAST(EXTRACT(YEAR FROM V_tankstock.creatdate) AS VARCHAR2(10)) || '-' || "
            sql &= "CAST(EXTRACT(MONTH FROM V_tankstock.creatdate) AS VARCHAR2(10)) || '-' || "
            Dim n_year As Integer = 0
            n_year = 543
            sql &= "CAST(EXTRACT(DAY FROM V_tankstock.creatdate) AS VARCHAR2(10)) ='" + String.Format("{0:yyyy-M-d}", DateAdd(DateInterval.Year, -n_year, RadCalendar1.SelectedDate)) + "'"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "v_Tankstock")

            Myreport.Load("tankstock.rpt")
            Myreport.SetDataSource(MyDataSet)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()
            MyDataSet.Dispose()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReportTank_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        RadCalendar1.SelectedDate = Date.Now.Date
    End Sub
End Class
