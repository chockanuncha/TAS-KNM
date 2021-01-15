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
Public Class Advisenote_Edit
    Private cls As New Class_SQKDB
    Dim Ref, Truck, loadDO, StatusName, loadid As String
    Dim Tankcheck As Integer
    Private Sub Advisenote_Edit_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            'Ref = Topup.MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString
            'loadDO = Topup.MasterGridAdvisenote.CurrentRow.Cells("load_dofull").Value.ToString
            'Truck = Topup.MasterGridAdvisenote.CurrentRow.Cells("LOAD_VEHICLE").Value.ToString
            'Drivertext.Text = Topup.MasterGridAdvisenote.CurrentRow.Cells("Load_driver").Value.ToString
            'StatusName = Topup.MasterGridAdvisenote.CurrentRow.Cells("Status").Value.ToString
            'Referencetext.Text = Ref.ToString
            'Trucktext.Text = Truck.ToString
            'Dotext.Text = loadDO.ToString
            'TStatusBindingSource.Position = TStatusBindingSource.Find("Status_name", StatusName)
            'loadid = Topup.MasterGridAdvisenote.CurrentRow.Cells("load_id").Value.ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BTSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTSave.Click
        Dim q As String
        q = ""
        q = "Update t_loadingnote set load_status='" & (TStatusBindingSource.Item(TStatusBindingSource.Position)("ID").ToString()) & "' "
        q &= "Where Reference ='" & Referencetext.Text & "'"

        cls.Update(q)

        If (TStatusBindingSource.Item(TStatusBindingSource.Position)("ID").ToString()) = 4 Then
            q = ""
            q = "Update t_loadingnotecompartment set lc_status='" & (TStatusBindingSource.Item(TStatusBindingSource.Position)("ID").ToString()) & "' "
            q &= "Where lc_load ='" & loadid.ToString & "' and lc_status<>'99' "

            cls.Update(q)
        End If
        Me.Close()
    End Sub

    Private Sub Advisenote_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Dataset_table.T_STATUS' table. You can move, or remove it, as needed.
        Me.T_STATUSTableAdapter.Fill(Me.Dataset_table.T_STATUS)
    End Sub
End Class
