﻿Imports System
Imports ExtendedErrorProvider

Public Class ChangPassword
    Dim cls As New Class_SQKDB
    Dim Oldpass, Newpass, UserID As String

    Private Sub ChangPassword_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Username.Text = MAIN.U_NAME.ToString
        UserID = MAIN.U_NAME_ID
        U_passnew.Text = ""
        U_PassConfirm.Text = ""
        U_PassOLD.Text = ""
        U_PassOLD.Focus()
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click

        Dim sql As String = "Select * from V_USER  where U_ID='" + UserID + "'" +
                            " and U_PASSWD ='" + U_PassOLD.Text + "'" +
                            " and U_STATUS ='1'"

        Dim dt As DataTable = cls.Query(sql)

        If dt.Rows.Count > 0 Then
            If U_passnew.Text = U_PassConfirm.Text Then

                sql = "UPDATE T_USER SET Update_date=Getdate()" ' ,U_PASSWD_DATE='" & Now.AddDays(90) & "'"
                sql &=",U_PASSWD='" & U_passnew.Text & "' Where U_ID='" & UserID.ToString & "'"

                cls.Update(sql)

                MsgBox("Password chang successful", vbOKOnly & vbDefaultButton3, "OK")
                Me.Close()
            Else
                MessageBox.Show("New Password Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                U_passnew.Text = ""
                U_PassConfirm.Text = ""
                U_passnew.Focus()
            End If
        Else
            MessageBox.Show("Current Password Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            U_PassOLD.Text = ""
            Me.U_PassOLD.Focus()
        End If
    End Sub

    Private Sub RadButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton2.Click
        Me.Close()
    End Sub

    Private Sub U_PassConfirm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles U_PassConfirm.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Bsave_Click(sender, e)
            End If
        Finally
        End Try
    End Sub
End Class
