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

Public Class ReportSeal
    Private cls As New Class_SQLSERVERDB

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Dim sql, q As String
        Dim Myreport As New ReportDocument
        Myreport = New ReportDocument

        If Reportmain.Report_Type = "seal" Then
            sql = ""
            sql = "Select * From v_seal "
            sql &= " where  to_date(Load_date)=To_date('" + String.Format("{0:dd/MM/yyyy}", RadCalendar1.SelectedDate) + "','dd/MM/yyyy,HH:MI AM')"
            Try

                Dim MyDataSet As New DataSet
                MyDataSet = cls.Query_DS(sql, "V_SEAL")

                Myreport.Load("LoadSeal.rpt")
                Myreport.SetDataSource(MyDataSet)
                ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                ReportPrint.ShowDialog()
            Catch ex As Exception

            End Try
        Else

            q = ""
            q = "update t_reportdate set fulldate='" + String.Format("{0:dd/MM/yyyy}", RadCalendar1.SelectedDate) + "'"

            cls.Update(q)

            sql = ""
            sql = "Select * From v_report_statistics "
            sql &= " where  Load_date='" + String.Format("{0:dd/MM/yyyy}", RadCalendar1.SelectedDate) + "'"

            Dim MyDataSet As New DataSet
            cls.Query_DA(sql, MyDataSet, "v_report_statistics")

            sql = ""
            sql = "Select * From v_report_SUMPRO_statistics "
            sql &= " where  Load_date='" + String.Format("{0:dd/MM/yyyy}", RadCalendar1.SelectedDate) + "'"

            cls.Query_DA(sql, MyDataSet, "v_report_SUMPRO_statistics")

            Myreport.Load("StaticLoad.rpt")
            Myreport.SetDataSource(MyDataSet)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()


            Try
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClose.Click
        Me.Close()
    End Sub

    Private Sub ReportSeal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadCalendar1.SelectedDate = Date.Now.Date

    End Sub

    Private Sub ReportSeal_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        RadCalendar1.SelectedDate = Date.Now.Date
    End Sub
End Class
