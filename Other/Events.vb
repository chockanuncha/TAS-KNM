Imports System.Data
Imports System
Imports System.IO
Imports System.Data.Common
Imports Telerik.WinControls.UI
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine

Public Class Journal_Events
    Private cls As New Class_SQKDB

    Dim n_year As Integer = 543
    Dim reporttype As Integer = 0

    Private Sub RadForm3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Application.ChangeCulture("th-TH")
        'TODO: This line of code loads data into the 'Dataset_table.T_EVENT' table. You can move, or remove it, as needed.
        Me.T_EVENTTableAdapter.Fill(Me.Dataset_table.T_EVENT)
        'TODO: This line of code loads data into the 'Dataset_table.T_ALARMS_BATCH_HISTORY' table. You can move, or remove it, as needed.
        Me.T_ALARMS_BATCH_HISTORYTableAdapter.Fill(Me.Dataset_table.T_ALARMS_BATCH_HISTORY)
        'TODO: This line of code loads data into the 'IRPCDataset.V_EVENT' table. You can move, or remove it, as needed.
        DateTimePicker1.Value = Date.Now
        DateTimePicker2.Value = Date.Now
        DateTimePicker3.Value = Date.Now
        DateTimePicker4.Value = Date.Now
        reporttype = 1
        AlarmSearch()
    End Sub

    Private Sub Journal_Events_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.GridAlarm.TableElement.RowHeight = 30
        Me.GridAlarm.TableElement.TableHeaderHeight = 40
        Me.GridEvent.TableElement.RowHeight = 30
        Me.GridEvent.TableElement.TableHeaderHeight = 40
        RadPageView1.SelectedPage = RadPageViewPage1
    End Sub

    Private Sub ToolStripButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton17.Click
        Try
            If DateTimePicker1.Focused = True Then
                DateTimePicker2.Focus()
                DateTimePicker1.Focus()
            Else
                DateTimePicker1.Focus()
                DateTimePicker2.Focus()
            End If

            AlarmSearch()
        Catch ex As Exception

        End Try

    End Sub

    Sub AlarmSearch()
        Dim q As String
        n_year = 543
        Try

            q = ""
            q = "Select * from t_Alarms_Batch_History where ADATETIME between "
            q &= "To_date('" & DateTimePicker1.Value.Year & "/" & DateTimePicker1.Value.Month & "/" & DateTimePicker1.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
            q &= "To_date('" & DateTimePicker2.Value.Year & "/" & DateTimePicker2.Value.Month & "/" & DateTimePicker2.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "
            q &= "order by ADATETIME "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "t_Alarms_Batch_History")

            TAlarmHistoryBindingSource.DataSource = MyDataSet
            TAlarmHistoryBindingSource.DataMember = "t_Alarms_Batch_History"
            MyDataSet.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Sub EventSearch()
        Dim q As String
        Dim n_year As Integer = 0
        n_year = 543
        Try

            q = ""
            q = "Select * from t_event where  LDATE between  "
            q &= "To_date('" & DateTimePicker3.Value.Year & "/" & DateTimePicker3.Value.Month & "/" & DateTimePicker3.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
            q &= "To_date('" & DateTimePicker4.Value.Year & "/" & DateTimePicker4.Value.Month & "/" & DateTimePicker4.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "
            q &= "Order by LDATE"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "t_event")

            VEventsBindingSource.DataSource = MyDataSet
            VEventsBindingSource.DataMember = "t_event"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        Try
            If DateTimePicker3.Focused = True Then
                DateTimePicker4.Focus()
                DateTimePicker3.Focus()
            Else
                DateTimePicker3.Focus()
                DateTimePicker4.Focus()
            End If
            EventSearch()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Printdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Printdata.Click

        If reporttype = 1 Then
            Dim sql As String
            n_year = 543
            Dim Myreport As New ReportDocument
            Myreport = New ReportDocument
            sql = "Select * from t_Alarms_Batch_History where ADATETIME between "
            sql &= "To_date('" & DateTimePicker1.Value.Year & "/" & DateTimePicker1.Value.Month & "/" & DateTimePicker1.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
            sql &= "To_date('" & DateTimePicker2.Value.Year & "/" & DateTimePicker2.Value.Month & "/" & DateTimePicker2.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "
            sql &= "order by ADATETIME "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(sql, "t_Alarms_Batch_History")

            If MyDataSet.Tables(0).Rows.Count = 0 Then
                MsgBox("ไม่มีข้อมูล ไม่สามารถพิมพ์รายงานได้", vbOKOnly + vbDefaultButton3, "ตรวจสอบ")
                Exit Sub
            Else
                Myreport.Load("Alarm.rpt")
                Myreport.SetDataSource(MyDataSet)
                ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                ReportPrint.ShowDialog()
                MyDataSet.Dispose()
            End If
        ElseIf reporttype = 2 Then

            Dim q As String
            n_year = 543
            Dim Myreport As New ReportDocument
            Myreport = New ReportDocument
            q = "Select ldate as ev_date,detail as ev_detail from t_event where  LDATE between  "
            q &= "To_date('" & DateTimePicker3.Value.Year & "/" & DateTimePicker3.Value.Month & "/" & DateTimePicker3.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
            q &= "To_date('" & DateTimePicker4.Value.Year & "/" & DateTimePicker4.Value.Month & "/" & DateTimePicker4.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS')  "
            q &= "Order by LDATE"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "V_Event")

            If MyDataSet.Tables(0).Rows.Count = 0 Then
                MsgBox("ไม่มีข้อมูล ไม่สามารถพิมพ์รายงานได้", vbOKOnly + vbDefaultButton3, "ตรวจสอบ")
                Exit Sub
            Else
                Myreport.Load("Event.rpt")
                Myreport.SetDataSource(MyDataSet)
                ReportPrint.CrystalReportViewer3.ReportSource = Myreport
                ReportPrint.ShowDialog()
                MyDataSet.Dispose()
            End If

        End If
    End Sub

    Private Sub Alarm_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Alarm_bt.Click
        reporttype = 1
        RadPageView1.SelectedPage = RadPageViewPage1
        AlarmSearch()
    End Sub

    Private Sub Event_bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Event_bt.Click
        reporttype = 2
        RadPageView1.SelectedPage = RadPageViewPage2
        EventSearch()
    End Sub
End Class
