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

Public Class Reportdaily
    Private cls As New Class_SQLSERVERDB

    Dim RPT As Integer

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Dim sql As String
        Try

            If RPT = 1 Then
                Dim Myreport As New ReportDocument
                Myreport = New ReportDocument
                sql = ""
                sql = "Select * from V_TIMELOADING where ST_ST_DATE ='" + (String.Format("{0:dd/MM/yyyy}", RadCalendar1.SelectedDate)) + "'"

                Dim ds As New DataSet
                ds = cls.Query_DS(sql, "V_TIMELOADING")

                Myreport.Load("Bytimedaily.rpt")
                Myreport.SetDataSource(ds)
                ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                ReportPrint.ShowDialog()
                ds.Dispose()
            End If
            If RPT = 2 Then
                Dim Myreport As New ReportDocument
                Myreport = New ReportDocument
                sql = ""
                sql = "Select * from V_CUSTOMERDAILY where ST_ST_DATE ='" + (String.Format("{0:dd/MM/yyyy}", RadCalendar1.SelectedDate)) + "'"

                Dim ds As New DataSet
                ds = cls.Query_DS(sql, "V_CUSTOMERDAILY")

                Myreport.Load("Customerdaily.rpt")
                Myreport.SetDataSource(ds)
                ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                ReportPrint.ShowDialog()
                ds.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadCalendar1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'RadTextBox1.Text = RadCalendar1.SelectedDate  'RadCalendar1
    End Sub

    Private Sub Driver_StatusOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPT1On.Click
        RPT = 1
    End Sub

    Private Sub RPT2On_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPT2On.Click
        RPT = 2
    End Sub

    Private Sub RPT3On_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPT3On.Click
        RPT = 3
    End Sub

    Private Sub RPT4On_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPT4On.Click
        RPT = 4
    End Sub

    Private Sub RPT5On_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPT5On.Click
        RPT = 5
    End Sub

    Private Sub RPT6On_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPT6On.Click
        RPT = 6
    End Sub

    Private Sub Reportdaily_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RPT = 1
        RadCalendar1.SelectedDate = Date.Now.Date
    End Sub


    Private Sub BClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClose.Click
        Me.Close()
    End Sub

    Private Sub Reportdaily_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        RadCalendar1.SelectedDate = Date.Now.Date
    End Sub
End Class
