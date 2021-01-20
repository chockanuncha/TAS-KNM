
Imports System
Imports ExtendedErrorProvider
Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports Telerik.WinControls.UI.Export
Imports Telerik.Data
Imports Telerik.Windows.Controls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls
Public Class Tank_Order
    Private cls As New Class_SQLSERVERDB

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim MyDataSet As New DataSet
    Dim ED As Integer = 0
    Dim Add As Integer = 0
    Dim Del As Integer = 0
    Private exportVisualSettings As Boolean
    Private Sub bg_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)

        RadMessageBox.SetThemeName(Me.TankGrid.ThemeName)
        RadMessageBox.Show("The data in the grid was exported successfully.", "Export to Excel")
    End Sub

    Private Sub DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        'exporter.Export(Me.TankGrid, CType(e.Argument, String), "newSheet1")
    End Sub

    Protected Function GetExampleDefaultTheme() As String
        Return "ControlDefault"
    End Function

    Private Sub RunExportToExcelML(ByVal fileName As String, ByRef openExportFile As Boolean)
        Dim excelExporter As New ExportToExcelML(Me.TankGrid)
        excelExporter.SummariesExportOption = SummariesOption.ExportAll

        excelExporter.ExportVisualSettings = Me.exportVisualSettings

        Try
            excelExporter.RunExport(fileName)

            RadMessageBox.SetThemeName(Me.TankGrid.ThemeName)
            Dim dr As DialogResult = RadMessageBox.Show("The data in the grid was exported successfully. Do you want to open the file?", "Export to Excel", MessageBoxButtons.YesNo, RadMessageIcon.Question)
            If dr = System.Windows.Forms.DialogResult.Yes Then
                openExportFile = True
            End If
        Catch ex As Exception
            RadMessageBox.SetThemeName(Me.TankGrid.ThemeName)
            RadMessageBox.Show(Me, ex.Message, "I/O Error", MessageBoxButtons.OK, RadMessageIcon.Error)
        End Try
    End Sub

    Private Sub Tank_Order_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet_Table.T_TANK' table. You can move, or remove it, as needed.
        Me.T_TANKTableAdapter.Fill(Me.DataSet_Table.T_TANK)
        RadGridView1.Enabled = True
        RadGroupBox1.Enabled = False
        RadGridView1.FilterDescriptors.Clear()
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim cmdbuilder As New SqlCommandBuilder(da)
        'Dim i As Integer
        'Try
        '    i = da.Update(MyDataSet, "t_tank")
        '    MsgBox("Records Updated= " & i)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub Tank_Order_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Try
            Dim sqluser As String
            sqluser = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sqluser)

        Catch ex As Exception
        End Try
        Me.RadGridView1.TableElement.RowHeight = 40
        Me.RadGridView1.TableElement.TableHeaderHeight = 50
    End Sub

    Private Sub BTSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTSave.Click
        Dim q, sql, T_ID, Test, Tankname, product As String
        Dim load, unload, closetank, numid As Integer
        T_ID = TTANKBindingSource.Item(TTANKBindingSource.Position)("ID").ToString
        Test = TTANKBindingSource.Item(TTANKBindingSource.Position)("TANKNO").ToString

        sql = ""
        sql = " select * from t_tank where TankProduct= '" & TTANKBindingSource.Item(TTANKBindingSource.Position)("TankProduct").ToString & "' "
        sql &= " and ID <> '" & T_ID.ToString & "'"

        Dim dt As DataTable = cls.Query(sql)

        If dt.Rows.Count <> 0 Then
            load = Int(dt.Rows(0).Item("Tank_loadactive").ToString())
            unload = Int(dt.Rows(0).Item("Tank_unloadactive").ToString())
            closetank = Int(dt.Rows(0).Item("Tank_CloseActive").ToString())
            Tankname = dt.Rows(0).Item("Tankno").ToString()
            product = dt.Rows(0).Item("TankProduct").ToString()

            If Tankload.Checked = True And load = 1 Then
                MessageBox.Show("ผลิตภัณฑ์ '" & product.ToString & "' มีถัง '" & Tankname.ToString & "' เปิดจ่ายอยู่แล้ว ไม่สามารถเปิดจ่ายพร้อมกันได้", "กรุณาตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If Tankunload.Checked = True And unload = 1 Then
                MessageBox.Show("ผลิตภัณฑ์ '" & product.ToString & "'  มีถัง '" & Tankname.ToString & "' เปิดรับอยู่แล้ว ไม่สามารถเปิดรับพร้อมกันได้", "กรุณาตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        '' Check Status Tankload,Unload,Close
        sql = ""
        sql = "Select * from t_tank where ID='" & TTANKBindingSource.Item(TTANKBindingSource.Position)("ID") & "'"

        Dim dt1 As DataTable = cls.Query(sql)

        closetank = Int(dt1.Rows(0).Item("Tank_CloseActive").ToString())
        If (Tankload.Checked = True Or Tankunload.Checked = True) And closetank = 0 Then
            If Tankload.Checked = True Then
                MessageBox.Show("กรุณาทำการปิดถังก่อนทำการเปิดจ่าย", "กรุณาตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                MessageBox.Show("กรุณาทำการปิดถังก่อนทำการเปิดรับ", "กรุณาตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        '' Update Status T_Tank
        Try
            q = ""
            q = "Update t_tank set "
            If Tankload.Checked = True Then
                q &= "Tank_loadactive = 1,"
            Else
                q &= "Tank_loadactive = 0,"
            End If
            If Tankunload.Checked = True Then
                q &= "Tank_unloadactive = 1,"
            Else
                q &= "Tank_unloadactive = 0,"
            End If
            If Tankclose.Checked = True Then
                q &= "Tank_CloseActive = 1, "
            Else
                q &= "Tank_CloseActive = 0, "
            End If
            q &= "DENSITY30 = '" & Density.Text & "',"
            q &= "TankTemp = '" & Temp.Text & "'  "
            q &= "where ID ='" & TTANKBindingSource.Item(TTANKBindingSource.Position)("ID").ToString() & "'"

            cls.Update(q)


        Catch ex As Exception
            MsgBox(ex.Message())
        End Try
        'Try
        '    sql = "Select numid from t_tankstock where TankID='" & TTANKBindingSource.Item(TTANKBindingSource.Position)("ID") & "' "
        '    sql &= "order by Creatdate desc,ID desc"

        '    dt = cls.Query(sql)

        '    numid = Int(dt.Rows(0).Item("Numid").ToString())
        '    numid = numid + 1
        'Catch ex As Exception
        '    MsgBox(ex.Message())
        'End Try

        Try
            Tank_Order_Load(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub



    Private Sub RadGridView1_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles RadGridView1.CellFormatting
        e.CellElement.NumberOfColors = 1
        e.CellElement.BackColor = Color.FromArgb(72, 162, 255)
    End Sub

    Private Sub BTCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTCANCEL.Click
        TTANKBindingSource.CancelEdit()
        DataSet_Table.T_TANK.RejectChanges()
        Tank_Order_Load(sender, e)
    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEdit.Click
        RadGridView1.Enabled = False
        Try
            Dim sqluser As String
            sqluser = "UPDATE T_USERLOGIN SET Update_date=Getdate(),USERNAME='" & MAIN.U_NAME & "'" _
              & ",USERGROUP='" & MAIN.U_GROUP & "'"

            cls.Update(sqluser)

        Catch ex As Exception
        End Try
        RadGroupBox1.Enabled = True
    End Sub

    Private Sub TTankBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TTANKBindingSource.PositionChanged
        Try
            If UCase(TTANKBindingSource.Item(TTANKBindingSource.Position)("tank_loadactive").ToString) = "1" Then
                Tankload.Checked = True
            End If
            If UCase(TTANKBindingSource.Item(TTANKBindingSource.Position)("tank_unloadactive").ToString) = "1" Then
                Tankunload.Checked = True
            End If
            If UCase(TTANKBindingSource.Item(TTANKBindingSource.Position)("tank_closeactive").ToString) = "1" Then
                Tankclose.Checked = True
            End If

            ToolStripLabel1.Text = "of {" & TTANKBindingSource.Count & "}"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click, RadButton2.Click
        F_Tankstock1.ShowDialog()
        Tank_Order_Load(sender, e)
    End Sub
End Class

