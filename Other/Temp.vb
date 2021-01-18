Public Class Temp


    Private Sub Temp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Dataset_table.T_DRIVER' table. You can move, or remove it, as needed.
        Me.T_DRIVERTableAdapter.Fill(Me.Dataset_table.T_DRIVER)

    End Sub

    Private Sub Btadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try



        Catch ex As Exception

        End Try
    End Sub
End Class
