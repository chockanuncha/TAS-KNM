Public Class Setting





    Private Sub Setting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'IRPCDataset.T_SETTING' table. You can move, or remove it, as needed.
        Me.T_SETTINGTableAdapter.Fill(Me.IRPCDataset.T_SETTING)

    End Sub

    Private Sub BTSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTSAVE.Click, RadButton2.Click
        Try


            TSettingBindingSource.EndEdit()
            T_SETTINGTableAdapter.Update(IRPCDataset.T_SETTING)
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถอัพเดทข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Setting_Load(sender, e)
        End Try

        Setting_Load(sender, e)
    End Sub

    Private Sub BTCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTCANCEL.Click, RadButton1.Click
        Setting_Load(sender, e)
    End Sub
End Class
