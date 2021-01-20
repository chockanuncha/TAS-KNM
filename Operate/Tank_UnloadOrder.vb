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

Public Class Tank_UnloadOrder
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
        'TODO: This line of code loads data into the 'Dataset_table.T_TANK' table. You can move, or remove it, as needed.
        Me.T_TANKTableAdapter.Fill(Me.Dataset_table.T_TANK)
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
        Me.RadGridView1.TableElement.RowHeight = 40
        Me.RadGridView1.TableElement.TableHeaderHeight = 50
    End Sub

    Private Sub BTSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTSave.Click
        Try
            TTankBindingSource.Item(TTankBindingSource.Position)("Updatedate") = Now
            TTankBindingSource.Item(TTankBindingSource.Position)("Volume_Diff") = "0"
            TTankBindingSource.EndEdit()
            Dataset_table.T_TANK.AcceptChanges()
            Tank_Order_Load(sender, e)
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถอัพเดทข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Tank_Order_Load(sender, e)
        End Try

    End Sub



    Private Sub RadGridView1_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles RadGridView1.CellFormatting

        e.CellElement.NumberOfColors = 1
        e.CellElement.BackColor = Color.FromArgb(72, 162, 255)

    End Sub


    Private Sub RadGridView1_CellEndEdit(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles RadGridView1.CellEndEdit
        Try
            Dim Start, AddStart As Integer
            Start = e.Row.Cells(10).Value
            AddStart = e.Row.Cells(12).Value
            Dim TT As String
            TT = e.Row.Cells(10).Value.ToString
            e.Row.Cells(10).Value = e.Row.Cells(12).Value + Int(TT)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BTCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTCANCEL.Click
        TTankBindingSource.CancelEdit()
        Dataset_table.T_TANK.RejectChanges()
        Tank_Order_Load(sender, e)
    End Sub
End Class

