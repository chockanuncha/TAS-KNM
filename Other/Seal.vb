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
Public Class Seal
    Private cls As New Class_SQKDB

    Private Sub Seal_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim q As String

        q = ""
        q = "select * from T_Seal order by id"

        Dim dt As DataTable = cls.Query(q)

        Seallast.Text = dt(0)("Seal_last")
        SealUp.Text = ""
        SealUp.Focus()
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        If MsgBox("ต้องการแก้ไขข้อมูลหรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then
            Try
                Dim q As String

                q = ""
                q = "Update T_seal Set Seal_last ='" + SealUp.Text + "'"

                cls.Update(q)

                Seal_Shown(sender, e)
            Catch ex As Exception
                MsgBox("ไม่สามารถแก้ไขข้อมูลได้ ?", vbOKOnly + vbDefaultButton2, "ผิดพลาด")
                Seal_Shown(sender, e)
                Exit Sub
            End Try
        Else
            Seal_Shown(sender, e)
            Exit Sub
        End If
    End Sub

    Private Sub Bcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcancel.Click
        Seal_Shown(sender, e)
    End Sub
End Class
