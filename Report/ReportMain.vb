Imports System
Imports System.Data

Public Class Reportmain
    Public R_ID As Integer = 0
    Public Report_Type, Header_name As String
    Dim Memory As MemoryManagement.Manage

    Private Sub Report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.AddOwnedForm(Me)
        Me.Show()
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        Header_name = RadButton1.Text
        Report_Type = "time"
        Me.AddOwnedForm(ReportDayBetween)
        ReportDayBetween.ShowDialog()
    End Sub

    Private Sub RadButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton6.Click
        ReportBOL.Text = "BOL Report"
        Me.AddOwnedForm(ReportBOL)
        ReportBOL.ShowDialog()
    End Sub

    Private Sub RadButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton14.Click
        Header_name = RadButton14.Text
        Report_Type = "customer"
        Me.AddOwnedForm(ReportDayBetween)
        ReportDayBetween.ShowDialog()
    End Sub

    Private Sub RadButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton12.Click
        Report_Type = "Statics"
        Me.AddOwnedForm(ReportSeal)
        ReportSeal.ShowDialog()
        ReportSeal.Text = "รายงานสถิติน้ำมันใส"
    End Sub

    Private Sub RadButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton4.Click
        Header_name = RadButton4.Text
        Report_Type = "meter"
        Me.AddOwnedForm(ReportDayBetween)
        ReportDayBetween.ShowDialog()
    End Sub

    Private Sub RadButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton13.Click
        Header_name = RadButton13.Text
        Report_Type = "productpay"
        Me.AddOwnedForm(ReportDayBetween)
        ReportDayBetween.ShowDialog()
    End Sub

    Private Sub RadButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton5.Click
        Header_name = RadButton5.Text
        Me.AddOwnedForm(ReportTank)
        ReportTank.ShowDialog()
    End Sub

    Private Sub RadButton23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton23.Click
        Header_name = RadButton23.Text
        Report_Type = "unloading"
        Me.AddOwnedForm(ReportDayBetween)
        ReportDayBetween.ShowDialog()
    End Sub

    Private Sub RadButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton2.Click
        Header_name = RadButton23.Text
        Report_Type = "Event"
        Me.AddOwnedForm(ReportDayBetween)
        ReportDayBetween.ShowDialog()
    End Sub

    Private Sub Reportmain_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            Memory = New MemoryManagement.Manage
            Memory.FlushMemory()
        Catch ex As Exception
        End Try

    End Sub
End Class
