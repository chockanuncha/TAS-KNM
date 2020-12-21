Imports System.Data
Imports System
Imports System.Data.Common
Imports Telerik.WinControls.Themes
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Primitives
Imports System.ComponentModel

Public Class Loginauthorize
    Private cls As New Class_SQKDB
    Public Success As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Userauthorize As String
        Dim dt As DataTable
        Try
            Dim sql As String = "Select * from V_USER  where U_NAME='" + UserName.Text + "'" +
                                " and U_PASSWD ='" + Pass.Text + "'" +
                                " and U_STATUS ='1' and u_group>=3 "
            dt = cls.Query(sql)

            If dt.Rows.Count > 0 Then
                Userauthorize = dt(0)("U_NAME")
                Success = 1

                If Advisenote.authorizeUser = 1 Then
                    Advisenote.authorize_Remark.Text = Advisenote.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติการเช็คอินของรถทะเบียน : " & Advisenote.Cbn2.Text & " , "

                    Advisenote.AuthorRemark = Advisenote.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติการเช็คอินของรถทะเบียน : " & Advisenote.Cbn2.Text & " , "
                End If
                If Advisenote.authorizeUser = 2 Then
                    Advisenote.authorize_Remark.Text = Advisenote.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติประกันภัยของรถทะเบียน : " & Advisenote.Cbn2.Text & " , "
                    Advisenote.AuthorRemark = Advisenote.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติประกันภัยของรถทะเบียน : " & Advisenote.Cbn2.Text & " , "
                End If
                If Advisenote.authorizeUser = 3 Then
                    Advisenote.authorize_Remark.Text = Advisenote.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติการวัดน้ำของรถทะเบียน : " & Advisenote.Cbn2.Text & " , "
                    Advisenote.AuthorRemark = Advisenote.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติการวัดน้ำของรถทะเบียน : " & Advisenote.Cbn2.Text & " , "
                End If
                If Advisenote.authorizeUser = 4 Then
                    Advisenote.authorize_Remark.Text = Advisenote.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติการตรวจสภาพรถทะเบียน : " & Advisenote.Cbn2.Text & " , "
                    Advisenote.AuthorRemark = Advisenote.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติการตรวจสภาพรถทะเบียน : " & Advisenote.Cbn2.Text & " , "
                End If

                '' ThuckH '''

                If Advisenote.authorizeUser = 7 Then
                    Advisenote.authorize_Remark.Text = Advisenote.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติประกันภัยของรถทะเบียน : " & Advisenote.TruckH.Text & " , "
                    Advisenote.AuthorRemark = Advisenote.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติประกันภัยของรถทะเบียน : " & Advisenote.TruckH.Text & " , "
                End If
                If Advisenote.authorizeUser = 8 Then
                    Advisenote.authorize_Remark.Text = Advisenote.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติการวัดน้ำของรถทะเบียน : " & Advisenote.TruckH.Text & " , "
                    Advisenote.AuthorRemark = Advisenote.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติการวัดน้ำของรถทะเบียน : " & Advisenote.TruckH.Text & " , "
                End If
                If Advisenote.authorizeUser = 9 Then
                    Advisenote.authorize_Remark.Text = Advisenote.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติการตรวจสภาพรถทะเบียน : " & Advisenote.TruckH.Text & " , "
                    Advisenote.AuthorRemark = Advisenote.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติการตรวจสภาพรถทะเบียน : " & Advisenote.TruckH.Text & " , "
                End If

                If Advisenote.authorizeUser = 5 Then
                    Advisenote.AuthorRemarkDriver = "User : " & Userauthorize & " Authorize ประวัติใบขับขี่ของ พขร. : " & Advisenote.Driver.Text & " , "
                    Advisenote.authorize_Remark.Text = Advisenote.AuthorRemark & Advisenote.AuthorRemarkDriver
                End If

                If Advisenote.authorizeUser = 6 Then
                    Advisenote.AuthorRemarkDriver = Advisenote.AuthorRemarkDriver & "User : " & Userauthorize & " Authorize ประวัติบัตรอบรมของ พขร. : " & Advisenote.Driver.Text & " , "
                    Advisenote.authorize_Remark.Text = Advisenote.AuthorRemark & Advisenote.AuthorRemarkDriver

                End If

                If Topup.authorizeUser = 1 Then
                    Topup.authorize_Remark.Text = Topup.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติการเช็คอินของรถทะเบียน : " & Topup.Cbn2.Text & " , "

                    Topup.AuthorRemark = Topup.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติการเช็คอินของรถทะเบียน : " & Topup.Cbn2.Text & " , "
                End If
                If Topup.authorizeUser = 2 Then
                    Topup.authorize_Remark.Text = Topup.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติประกันภัยของรถทะเบียน : " & Topup.Cbn2.Text & " , "
                    Topup.AuthorRemark = Topup.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติประกันภัยของรถทะเบียน : " & Topup.Cbn2.Text & " , "
                End If
                If Topup.authorizeUser = 3 Then
                    Topup.authorize_Remark.Text = Topup.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติการวัดน้ำของรถทะเบียน : " & Topup.Cbn2.Text & " , "
                    Topup.AuthorRemark = Topup.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติการวัดน้ำของรถทะเบียน : " & Topup.Cbn2.Text & " , "
                End If
                If Topup.authorizeUser = 4 Then
                    Topup.authorize_Remark.Text = Topup.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติการตรวจสภาพรถทะเบียน : " & Topup.Cbn2.Text & " , "
                    Topup.AuthorRemark = Topup.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติการตรวจสภาพรถทะเบียน : " & Topup.Cbn2.Text & " , "
                End If

                If Topup.authorizeUser = 5 Then
                    Topup.AuthorRemarkDriver = "User : " & Userauthorize & " Authorize ประวัติใบขับขี่ของ พขร. : " & Topup.Driver.Text & " , "
                    Topup.authorize_Remark.Text = Topup.AuthorRemark & Topup.AuthorRemarkDriver
                End If

                If Topup.authorizeUser = 6 Then
                    Topup.AuthorRemarkDriver = Topup.AuthorRemarkDriver & "User : " & Userauthorize & " Authorize ประวัติบัตรอบรมของ พขร. : " & Topup.Driver.Text & " , "
                    Topup.authorize_Remark.Text = Topup.AuthorRemark & Topup.AuthorRemarkDriver
                End If


                If Unloadingnote.authorizeUser = 1 Then
                    Unloadingnote.authorize_Remark.Text = Unloadingnote.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติการเช็คอินของรถทะเบียน : " & Unloadingnote.Cbn2.Text & " , "

                    Unloadingnote.AuthorRemark = Unloadingnote.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติการเช็คอินของรถทะเบียน : " & Unloadingnote.Cbn2.Text & " , "
                End If
                If Unloadingnote.authorizeUser = 2 Then
                    Unloadingnote.authorize_Remark.Text = Unloadingnote.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติประกันภัยของรถทะเบียน : " & Unloadingnote.Cbn2.Text & " , "
                    Unloadingnote.AuthorRemark = Unloadingnote.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติประกันภัยของรถทะเบียน : " & Unloadingnote.Cbn2.Text & " , "
                End If
                If Unloadingnote.authorizeUser = 3 Then
                    Unloadingnote.authorize_Remark.Text = Unloadingnote.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติการวัดน้ำของรถทะเบียน : " & Unloadingnote.Cbn2.Text & " , "
                    Unloadingnote.AuthorRemark = Unloadingnote.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติการวัดน้ำของรถทะเบียน : " & Unloadingnote.Cbn2.Text & " , "
                End If
                If Unloadingnote.authorizeUser = 4 Then
                    Unloadingnote.authorize_Remark.Text = Unloadingnote.authorize_Remark.Text & "User : " & Userauthorize & " Authorize ประวัติการตรวจสภาพรถทะเบียน : " & Unloadingnote.Cbn2.Text & " , "
                    Unloadingnote.AuthorRemark = Unloadingnote.AuthorRemark & "User : " & Userauthorize & " Authorize ประวัติการตรวจสภาพรถทะเบียน : " & Unloadingnote.Cbn2.Text & " , "
                End If

                If Unloadingnote.authorizeUser = 5 Then
                    Unloadingnote.AuthorRemarkDriver = "User : " & Userauthorize & " Authorize ประวัติใบขับขี่ของ พขร. : " & Unloadingnote.Driver.Text & " , "
                    Unloadingnote.authorize_Remark.Text = Unloadingnote.AuthorRemark & Unloadingnote.AuthorRemarkDriver
                End If

                If Unloadingnote.authorizeUser = 6 Then
                    Unloadingnote.AuthorRemarkDriver = Unloadingnote.AuthorRemarkDriver & "User : " & Userauthorize & " Authorize ประวัติบัตรอบรมของ พขร. : " & Unloadingnote.Driver.Text & " , "
                    Unloadingnote.authorize_Remark.Text = Unloadingnote.AuthorRemark & Unloadingnote.AuthorRemarkDriver
                End If

                Me.Close()

            Else
                MessageBox.Show("User and Password Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                UserName.Text = ""
                Pass.Text = ""
                UserName.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Advisenote.authorizeUser < 5 Then
            Advisenote.Cbn2.SelectedIndex = -1
            Advisenote.Cbn2.Focus()
        Else
            Advisenote.Driver.SelectedIndex = -1
            Advisenote.Driver.Focus()
        End If

        If Unloadingnote.authorizeUser < 5 Then
            Unloadingnote.Cbn2.SelectedIndex = -1
            Unloadingnote.Cbn2.Focus()

        Else
            Unloadingnote.Driver.SelectedIndex = -1
            Unloadingnote.Driver.Focus()
        End If

        If Topup.authorizeUser < 5 Then
            Topup.Cbn2.SelectedIndex = -1
            Topup.Cbn2.Focus()

        Else
            Topup.Driver.SelectedIndex = -1
            Topup.Driver.Focus()
        End If

        Success = 0
        Me.Close()
    End Sub

    Private Sub Pass_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Pass.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                Button1_Click(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Loginauthorize_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        UserName.Text = ""
        Pass.Text = ""
        UserName.Focus()

    End Sub

    Private Sub Loginauthorize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UserName.Text = ""
        UserName.Focus()
        Pass.Text = ""
    End Sub
End Class
