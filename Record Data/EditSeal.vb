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
Public Class EditSeal
    Private cls As New Class_SQLSERVERDB

    Dim Ref, LSeal As String

    Private Sub EditSeal_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            'LSeal = Topup.MasterGridAdvisenote.CurrentRow.Cells("Load_seal").Value.ToString

            'Ref = Topup.MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString
            Seallast.Text = LSeal
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BTSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTSAVE.Click
        Try
            Dim q As String

            q = ""
            q = "Update T_loadingnote Set Load_Seal='" + Seallast_Edit.Text + "',Remark='" + Remark.Text + "' where reference =" + Ref + ""

            cls.Update(q)

            Dim LC_LOAD As String
            q = ""
            q = "Select Load_id from t_loadingnote where Reference=" + Ref + ""

            Dim dt As DataTable = cls.Query(q)

            LC_LOAD = dt.Rows(0).Item("LOAD_ID").ToString

            q = ""
            q = "Update t_loadingnotecompartment Set LC_Seal='" + Seallast_Edit.Text + "' Where LC_LOAD =" + LC_LOAD + ""

            cls.Update(q)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        Dim Seal() As String = Split(Seallast_Edit.Text, "-")
        Dim sealcount As String
        Dim AA As String = "123456789"

        sealcount = AA.Substring(AA.Length, 4)

        Seal(0).Substring(Seal(0).Length, 4)

        Seal(1).Substring(1, 4)
        sealcount = Int(Seal(1)) - Int(Seal(0))
        Remark.Text = sealcount.ToString
    End Sub
End Class
