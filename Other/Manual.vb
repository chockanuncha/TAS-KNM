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

Public Class Manual

    Dim MyErrorProvider As New ErrorProviderExtended
    Dim MyDataSet As New DataSet

    Private Sub Manual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Dataset_table.T_CHECKIN' table. You can move, or remove it, as needed.
        Me.T_CHECKINTableAdapter.Fill(Me.Dataset_table.T_CHECKIN)

    End Sub

    Private Sub Manual_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.MasterGrid.TableElement.RowHeight = 40
        Me.MasterGrid.TableElement.TableHeaderHeight = 50

    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        Try
            TCheckinBindingSource.EndEdit()
            T_CHECKINTableAdapter.Update(Dataset_table.T_CHECKIN)
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถอัพเดทข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Manual_Load(sender, e)
        End Try
        Me.T_CHECKINTableAdapter.Fill(Me.Dataset_table.T_CHECKIN)
        End
    End Sub

    Private Sub MasterGrid_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles MasterGrid.CellFormatting
        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Try
            TCheckinBindingSource.EndEdit()
            T_CHECKINTableAdapter.Update(Dataset_table.T_CHECKIN)
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถอัพเดทข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Manual_Load(sender, e)
        End Try
        Me.T_CHECKINTableAdapter.Fill(Me.Dataset_table.T_CHECKIN)
        End
    End Sub
End Class
