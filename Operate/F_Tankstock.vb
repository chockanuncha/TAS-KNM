Imports System.Data
Imports System
Imports System.IO
Imports System.Data.Common
Imports ExtendedErrorProvider
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Threading
Imports System.Drawing.Printing
Imports System.ComponentModel
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data

Public Class F_Tankstock1
    Private cls As New Class_SQKDB

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Dim q, sql As String
        Try
            sql = ""
            sql = "select * from t_tank order by tankno "

            Dim dt As DataTable = cls.Query(sql)

            Dim i As Integer = 0
            For i = 0 To dt.Rows.Count - 1
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
                q &= "'" & dt.Rows(i).Item("tankPRODUCT").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("TOV").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("Density30").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("TankTemp").ToString() & "',"

                q &= "'0',"
                q &= "'0',"
                q &= "'1',"
                q &= "'" & dt.Rows(i).Item("ID").ToString() & "')"

                cls.Insert(q)

            Next
            q = ""
            q = "Update t_tank set TANK_UNLOADACTIVE='0',TANK_LOADACTIVE='0',TANK_CLOSEACTIVE='1' "

            cls.Update(q)

        Catch ex As Exception
            MessageBox.Show("ไม่สามารถอัพเดทข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        Dim q, sql As String
        Try

            sql = ""
            sql = "select * from t_tank order by tankno "

            Dim dt As DataTable = cls.Query(sql)

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
                q &= "'" & dt.Rows(i).Item("tankPRODUCT").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("TOV").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("Density30").ToString() & "',"
                q &= "'" & dt.Rows(i).Item("TankTemp").ToString() & "',"

                q &= "'0',"
                q &= "'0',"
                q &= "'1',"

                q &= "'" & dt.Rows(i).Item("ID").ToString() & "')"

                cls.Insert(q)

            Next

        Catch ex As Exception
            MessageBox.Show("ไม่สามารถอัพเดทข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Me.Close()
    End Sub
End Class
