Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports Telerik.WinControls.Themes
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Primitives
Imports System.Threading
Imports System.Reflection
Imports ExtendedErrorProvider

Public Class Fault


    Private Sub Fault_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'IRPCDataset.T_USER' table. You can move, or remove it, as needed.
        Me.T_USERTableAdapter.Fill(Me.IRPCDataset.T_USER)

    End Sub

    Private Sub Fault_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.MasterGrid.TableElement.RowHeight = 30
        Me.MasterGrid.TableElement.TableHeaderHeight = 40
        If Me.Width < 1400 Then
            DetailGroup.Width = 800
        Else
            DetailGroup.Width = Me.Width / 2
        End If
        RadPanel2.Height = Me.Height / 5.6
    End Sub

    Private Sub MasterGrid_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles MasterGrid.CellFormatting
        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
    End Sub
End Class
