Imports System.Data
Imports System
Imports System.IO
Imports System.Data.Common
Imports ExtendedErrorProvider
Imports System.Drawing.Printing
Imports System.ComponentModel
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Public Class UnloadtankValue
    Private cls As New Class_SQKDB

    Dim Ref, Truck, Tank As String
    Dim Tankcheck As Integer

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click

        Dim q As String
        q = "select TOV,ID,TANKNO from t_tank where tankno='" & Tank.ToString & "'"

        Dim dt As DataTable = cls.Query(q)

        If Tankcheck = 1 Then
            Tankvalue.Text = dt(0)("TOV")
        Else
            Tankvaluefinish.Text = dt(0)("TOV")
        End If
    End Sub

    Private Sub UnloadtankValue_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Trucknumber.Text = ""
        Tankno.Text = ""
        Referencetext.Text = ""
        Tankvalue.Text = ""
        Tankvaluefinish.Text = ""
        Try

            Ref = Unloadingnote.MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString
            Tank = Unloadingnote.MasterGridAdvisenote.CurrentRow.Cells("TANK").Value.ToString
            Truck = Unloadingnote.MasterGridAdvisenote.CurrentRow.Cells("LOAD_VEHICLE").Value.ToString
            Tankvalue.Text = Unloadingnote.MasterGridAdvisenote.CurrentRow.Cells("Tank_befor").Value.ToString
            Tankvaluefinish.Text = Unloadingnote.MasterGridAdvisenote.CurrentRow.Cells("Tank_after").Value.ToString
            Referencetext.Text = Ref.ToString
            Trucknumber.Text = Truck.ToString
            Tankno.Text = Tank.ToString
            Tank_Befor.Checked = True
            Tankcheck = 1

        Catch ex As Exception

        End Try
    End Sub


    Private Sub U_StatusOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tank_Befor.Click
        Tankcheck = 1
    End Sub

    Private Sub Tank_After_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tank_After.Click
        Tankcheck = 2
    End Sub

    Private Sub BTCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTCANCEL.Click
        UnloadtankValue_Shown(sender, e)

    End Sub

    Private Sub BTSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTSave.Click
        Dim q, ID As String
        q = ""
        q = "Update t_unloadingnote set Tank_befor='" & Tankvalue.Text & "',Tank_after ='" & Tankvaluefinish.Text & "' "
        q &= "Where Reference ='" & Referencetext.Text & "'"

        cls.Update(q)
    End Sub
End Class
