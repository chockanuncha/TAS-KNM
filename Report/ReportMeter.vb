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


Public Class ReportMeter
    Private cls As New Class_SQLSERVERDB

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Try
            Dim ref, sql As String
            Dim Myreport As New ReportDocument
            Myreport = New ReportDocument
            Dim n_year As Integer
            n_year = 543

            sql = "Select * from v_meter_controlling where LDATE ='" + String.Format("{0:yyyy-MM-dd}", DateAdd(DateInterval.Year, -n_year, RadCalendar1.SelectedDate)) + "'"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "v_meter_controlling")

            Myreport.Load("Metersum.rpt")
            Myreport.SetDataSource(MyDataSet)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()
            MyDataSet.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReportMeter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadCalendar1.SelectedDate = Date.Now.Date
    End Sub

    Private Sub BClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClose.Click
        Me.Close()
    End Sub

    Private Sub ReportMeter_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        RadCalendar1.SelectedDate = Date.Now.Date
    End Sub
End Class
