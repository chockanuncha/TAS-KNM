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
Public Class Banner
    Private cls As New Class_SQLSERVERDB
    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Me.Close()
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        If MsgBox("Do you want edit data?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
            Try
                Dim q As String

                q = ""
                q = "Update T_BANNER Set Banner1 ='" & Bannertext.Text & "'"

                cls.Update(q)
            Catch ex As Exception
                MsgBox("Cannot edit banner, please contact administrator.", vbOKOnly + vbDefaultButton2, "Error")
                Banner_Shown(sender, e)
                Exit Sub
            End Try
        Else
            Banner_Shown(sender, e)
            Exit Sub
        End If
    End Sub

    Private Sub Banner_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim dt As DataTable

        Dim q As String
        Bannertext.Text = ""
        Try
            q = ""
            q = "select Banner1 from T_Banner "

            dt = cls.Query(q)
            If dt.Rows.Count > 0 Then
                Bannertext.Text = dt(0)("Banner1").ToString
            End If


        Catch ex As Exception
            MsgBox("Database Disconnect!", vbOKOnly + vbDefaultButton2, "Error")
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub

    'Private Sub Banner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Eventext.Left = 980
    'End Sub
End Class
