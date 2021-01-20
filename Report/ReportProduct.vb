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
Public Class ReportProduct
    Private cls As New Class_SQLSERVERDB

    Private Sub ReportProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadCalendar1.SelectedDate = Date.Now.Date
    End Sub


    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Try
            Dim sql As String
            Dim Myreport As New ReportDocument
            Myreport = New ReportDocument
            Dim n_year As Integer = 0
            If My.Application.Culture.ToString = "th-TH" Then
                n_year = 543
            End If
            sql = "Select * from V_Product_total where LDATE ='" & String.Format("{0:yyyy-MM-d}", DateAdd(DateInterval.Year, -n_year, RadCalendar1.SelectedDate)) & "'"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "V_Product_total")

            Myreport.Load("Productsum.rpt")
            Myreport.SetDataSource(MyDataSet)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()
            MyDataSet.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClose.Click
        Me.Close()
    End Sub

    Private Sub ReportProduct_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        RadCalendar1.SelectedDate = Date.Now.Date
    End Sub
End Class
