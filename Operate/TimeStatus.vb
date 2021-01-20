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

Public Class TimeStatus
    Private cls As New Class_SQLSERVERDB

    Private Sub SelectTime()
        Dim q As String
        Try

            q = "select * from TimeResult Where load_date Between "
            q &= "To_date('" & DateTimePicker1.Value.Year & "/" & DateTimePicker1.Value.Month & "/" & DateTimePicker1.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
            q &= "To_date('" & DateTimePicker2.Value.Year & "/" & DateTimePicker2.Value.Month & "/" & DateTimePicker2.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "TimeResult")

            TIMERESULTBindingSource.DataSource = MyDataSet
            TIMERESULTBindingSource.DataMember = "TimeResult"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TimeStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet_View.TIMERESULT' table. You can move, or remove it, as needed.
        Me.TIMERESULTTableAdapter.Fill(Me.DataSet_View.TIMERESULT)

        SelectTime()
    End Sub

    Private Sub TimeStatus_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.RadGridView1.TableElement.RowHeight = 40
        Me.RadGridView1.TableElement.TableHeaderHeight = 50
    End Sub

    Private Sub RadButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton4.Click
        SelectTime()
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click

        Dim Myreport As New ReportDocument
        Myreport = New ReportDocument
        Dim q As String
            q = "select * from TimeResult Where load_date Between "
        q &= "To_date('" & DateTimePicker1.Value.Year & "/" & DateTimePicker1.Value.Month & "/" & DateTimePicker1.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
        q &= "To_date('" & DateTimePicker2.Value.Year & "/" & DateTimePicker2.Value.Month & "/" & DateTimePicker2.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "
        Dim MyDataSet As New DataSet
        MyDataSet = cls.Query_DS(q, "TimeResult")

        If MyDataSet.Tables(0).Rows.Count > 0 Then
            MsgBox("ไม่มีข้อมูล ไม่สามารถพิมพ์รายงานได้", vbOKOnly + vbDefaultButton3, "ตรวจสอบ")
            Exit Sub
        Else
            Myreport.Load("trucktimeresult1.rpt")
            Myreport.SetDataSource(MyDataSet)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()
            MyDataSet.Dispose()
        End If
    End Sub
End Class
