Imports Telerik.WinControls.Data

Public Class Driverblacklist
    Private Sub Driverblacklist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet_Table.T_DRIVER_BLACKLIST' table. You can move, or remove it, as needed.
        Me.T_DRIVER_BLACKLISTTableAdapter.Fill(Me.DataSet_Table.T_DRIVER_BLACKLIST)

        Me.MasterGrid.TableElement.RowHeight = 35
        Me.MasterGrid.TableElement.TableHeaderHeight = 40

    End Sub
End Class
