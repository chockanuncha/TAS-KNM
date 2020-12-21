Imports System.Data
Imports System
Imports System.IO
Imports System.Data.Common
Imports Devart.Data.Oracle
Imports ExtendedErrorProvider
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Threading
Imports System.Drawing.Printing
Imports System.ComponentModel
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data

Public Class F_Tankstock
    Dim conn As OracleConnection = GetConnection()
    Dim cmd As New OracleCommand
    Private Function GetConnection() As OracleConnection
        Return New OracleConnection(My.Settings.ConnectionString)
    End Function


    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Dim q, sql As String


        Try


            conn.Open()
            cmd.Connection = conn
            sql = ""
            sql = "select * from t_tank order by tankno "
            Dim da As OracleDataAdapter = New OracleDataAdapter(sql, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            Dim i As Integer = 0
            For i = 0 To dt.Rows.Count - 1
                dt.Rows(0).Item("tankno").ToString()
                q = ""
                q = "insert into T_TankStock ("
                q &= "TANKNO,"
                q &= "PRODUCT,"
                q &= "TOV,"
                q &= "Density,"
                q &= "Temp,"
                q &= "Tank_load, "
                q &= "Tank_unload,"
                q &= "Tank_close,"
                q &= "TANKID "
                q &= ") values("
                q &= "'" & dt.Rows(i).Item("tankno").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("PRODUCT").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("TOV").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("Density").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("Temp").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("Tank_load").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("Tank_unload").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("Tank_close").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("TANKID").ToString() & "')"
                cmd.CommandText = q
                cmd.ExecuteNonQuery()

            Next
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถอัพเดทข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class
