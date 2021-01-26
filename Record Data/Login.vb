Imports System.Data
Imports System
Imports System.Data.Common
Imports Telerik.WinControls.Themes
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Primitives
Imports System.ComponentModel
Public Class Login
    Private cls As New Class_SQLSERVERDB
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim Inumrow As Integer
        'Dim row As String

#If DEBUG Then
        If UserName.Text = "" Then
            UserName.Text = "ping"
            Pass.Text = "p"
        End If
#End If

        Try
            Dim sql As String = "Select * from V_USER  where U_NAME='" + UserName.Text + "'" +
                                " and U_PASSWD ='" + Pass.Text + "'" +
                                " and U_STATUS ='1'"

            Dim dt As DataTable = cls.Query(sql)
            Dim dt_user As DataTable
            Dim isPassExpire As Integer = 0

            If dt.Rows.Count > 0 Then
                dt_user = cls.Query("SELECT * FROM T_USER WHERE U_NAME='" & dt(0)("U_NAME") & "'")

                'Check expire user
                If dt_user(0)("U_EXPIRE").ToString = "1" Then
                    If DateDiff(DateInterval.Day, dt_user(0)("U_EXPIRE_DATE"), Now) > 0 Then
                        MessageBox.Show("Access denied, User expired!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                'Check password expire
                isPassExpire = DateDiff(DateInterval.Day, dt_user(0)("U_PASSWD_DATE"), Now)

                Dim tmp As String = dt(0)("U_NAME").ToString
                Dim ftmp As String = tmp.Substring(0, 1).ToUpper
                Dim ltmp As String = tmp.Substring(1, tmp.Length - 1).ToLower

                MAIN.BLogout.Visible = True
                MAIN.BLogin.Visible = False
                MAIN.radPanorama1.Enabled = True
                MAIN.U_NAME = ftmp & ltmp
                MAIN.U_GROUP = dt(0)("G_NAME")
                MAIN.U_NAME_ID = dt(0)("U_ID")
                MAIN.U_GROUP_ID = dt(0)("G_ID")
                MAIN.M_NAME.Text = MAIN.U_NAME
                MAIN.M_GROUP.Text = MAIN.U_GROUP

                MAIN.RadButton1.Enabled = True
                MAIN.LoadingGroup.Enabled = True
                MAIN.Unloading.Enabled = False
                MAIN.ToolGroup.Enabled = True
                MAIN.MMIGroups.Enabled = True
                MAIN.Report.Enabled = True
                MAIN.DatabaseGroup.Enabled = True
                MAIN.ConfigGroup.Enabled = True
                'MAIN.Supervisor.Enabled = True
                MAIN.CEvent("USER : " + MAIN.U_NAME + " Login Tas ")

                If isPassExpire <= 0 Then
                    ChangPassword.RadButton2.Visible = False
                    ChangPassword.ShowDialog()
                End If
                Me.Close()
            Else
                MessageBox.Show("User and Password Fail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.UserName.Focus()
                MAIN.BLogout.Visible = False
                MAIN.BLogin.Visible = True
            End If
        Finally
        End Try
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        UserName.Text = ""
        UserName.Focus()
        Pass.Text = ""
        MAIN.BLogout.Visible = False
        MAIN.BLogin.Visible = True
    End Sub

    Private Sub Pass_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Pass.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Button1_Click(sender, e)
            End If
        Finally
        End Try
    End Sub

    Private Sub Login_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        UserName.Focus()
    End Sub
End Class