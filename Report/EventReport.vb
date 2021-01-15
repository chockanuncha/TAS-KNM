Public Class EventReport

    Private Sub EventReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'IRPCDataset.T_EVENT' table. You can move, or remove it, as needed.
        Me.T_EVENTTableAdapter.Fill(Me.Dataset_table.T_EVENT)
        'TODO: This line of code loads data into the 'FPTDataSet.T_EVENT' table. You can move, or remove it, as needed.
        ' Me.T_EVENTTableAdapter.Fill(Me.FPTDataSet.T_EVENT)


    End Sub
End Class