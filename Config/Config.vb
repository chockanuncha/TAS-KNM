Imports System
Imports ExtendedErrorProvider

Public Class ConfigQ
    Private cls As New Class_SQKDB
    Private Sub Config_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Qtarget_last.Text = ""
    End Sub

    Private Sub Config_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim q As String
        Dim dt As DataTable

        Qtarget_last.Text = ""
        RadTextBox4.Text = ""
        RadTextBox2.Text = ""
        Try
            q = ""
            q = "select CALL_TARGET from T_QSETTING order by id"

            dt = cls.Query(q)

            Qtarget_last.Text = dt(0)("CALL_TARGET").ToString
            Qtarget.Text = ""

            q = ""
            q = "select * from T_Q "

            dt = cls.Query(q)

            RadTextBox4.Text = dt(0)("Q_NO").ToString
            RadTextBox2.Text = dt(0)("Q_NO_Unload").ToString
            Qtarget.Text = ""

            RadTextBox3.Focus()
        Catch ex As Exception
            MsgBox(ex.Message())
        End Try

    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsave.Click
        If MsgBox("Do you want to update data?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
            Try
                Dim q As String
                q = ""
                q = "Update T_QSETTING Set CALL_TARGET ='" & Qtarget.Text & "'"

                cls.Update(q)

                Config_Shown(sender, e)
            Catch ex As Exception
                MsgBox(ex.Message())
                Config_Shown(sender, e)
                Exit Sub
            End Try
        Else
            Config_Shown(sender, e)
            Exit Sub
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Me.Close()
    End Sub

    Private Sub RadButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton3.Click
        Try
            Dim q As String
            q = ""
            q = "Update T_Q Set Q_NO ='" & RadTextBox3.Text & "'"

            cls.Update(q)

            Config_Shown(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message())
            Config_Shown(sender, e)
            Exit Sub
        End Try
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        Try
            Dim q As String
            q = ""
            q = "Update T_Q Set Q_NO_Unload ='" & RadTextBox1.Text & "'"

            cls.Update(q)

            Config_Shown(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message())
            Config_Shown(sender, e)
            Exit Sub
        End Try
    End Sub
End Class
