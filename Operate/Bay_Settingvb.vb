
Imports Telerik.WinControls

Public Class Bay_Setting
    Private cls_role As New Class_Permission
    Public Function Chk_View()
        '------------------------------------------- Start Check Permission
        RadMessageBox.SetThemeName("Office2010Blue")
        cls_role.Chk_Permission(MAIN.U_GROUP_ID, 5)
        If cls_role.ChkView = False Then
            Dim ds As DialogResult = RadMessageBox.Show(Me, "Your group not have permission to view this menu.", "Permission Denied!", MessageBoxButtons.OK, RadMessageIcon.Exclamation)
            Me.Text = ds.ToString()
            Return False
        End If
        '------------------------------------------- End Check Permission

        Return True
    End Function
    Private Sub Bay_Setting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet_Table.T_BAY' table. You can move, or remove it, as needed.
        Me.T_BAYTableAdapter.Fill(Me.DataSet_Table.T_BAY)
    End Sub

    Private Sub RadButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton2.Click
        Try
            TBayBindingSource.Item(TBayBindingSource.Position)("Update_date") = Now
            TBayBindingSource.EndEdit()
            T_BAYTableAdapter.Update(DataSet_Table.T_BAY)
        Catch ex As Exception
            MessageBox.Show("Cannot edit data, Please contact administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Bay_Setting_Load(sender, e)
        End Try

        Bay_Setting_Load(sender, e)
    End Sub

    Private Sub RadGridView1_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles RadGridView1.CellFormatting
        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
    End Sub

    Private Sub Bay_Setting_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.RadGridView1.TableElement.RowHeight = 40
        Me.RadGridView1.TableElement.TableHeaderHeight = 50
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Bay_Setting_Load(sender, e)
    End Sub

    Private Sub BTCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTCANCEL.Click
        TBayBindingSource.CancelEdit()
        DataSet_Table.T_BAY.RejectChanges()
        Bay_Setting_Load(sender, e)
    End Sub
End Class
