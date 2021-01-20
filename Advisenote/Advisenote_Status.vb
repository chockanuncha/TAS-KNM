Imports System.Threading
Imports System.Drawing.Printing
Imports System.ComponentModel

Public Class Advisenote_Status
    Private cls As New Class_SQLSERVERDB
    Public Grid As Integer

    Private Sub Advisenote_Status_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        SelectWaiting()
        SelectLoading()
        SelectFinish()
        SelectPartload()
        Grid = 0
    End Sub

    Private Sub SelectWaiting()
        Dim q As String
        Try
            q = "Select t1.Reference,t1.load_id,NVL2(t1.Container,(t1.Container|| '/' ||t2.TRUCK_NUMBER),t2.TRUCK_NUMBER ) as Truck,"
            q &= "T3.Driver_Name||'  '||T3.Driver_Lastname as Driver "
            q &= ",load_preset,t4.customer_name as Customer,t1.load_dofull as DO "

            q &= "From (Select Reference,load_preset,load_id,load_vehicle,load_driver,load_customer,load_dofull,Container from T_loadingnote where load_status=1 "
            q &= " and T_LOADINGNOTE.AddnoteDate between "
            q &= "To_date('" & DP1.Value.Year & "/" & DP1.Value.Month & "/" & DP1.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
            q &= "To_date('" & DP2.Value.Year & "/" & DP2.Value.Month & "/" & DP2.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS') ) T1 "

            q &= "Left join T_Truck t2 on t1.load_vehicle=t2.id "
            q &= "left join t_driver t3 On t1.load_driver=t3.id "
            q &= "left join t_customer t4 On t1.load_customer=t4.id "
            q &= "Order by t1.reference "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "T1")

            WaitingBindingSource.DataSource = MyDataSet
            WaitingBindingSource.DataMember = "T1"

        Catch ex As Exception
        End Try
    End Sub
    Private Sub SelectLoading()
        Dim q As String
        Try
            q = "Select t1.Reference,t1.load_id,NVL2(t1.Container,(t1.Container|| '/' ||t2.TRUCK_NUMBER),t2.TRUCK_NUMBER ) as Truck,"
            q &= "T3.Driver_Name||'  '||T3.Driver_Lastname as Driver "
            q &= ",load_preset,t4.customer_name as Customer,t1.load_dofull as DO "

            q &= "From (Select Reference,load_preset,load_id,load_vehicle,load_driver,load_customer,load_dofull,Container from T_loadingnote where load_status=2 "
            q &= " and T_LOADINGNOTE.AddnoteDate between "
            q &= "To_date('" & DP1.Value.Year & "/" & DP1.Value.Month & "/" & DP1.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
            q &= "To_date('" & DP2.Value.Year & "/" & DP2.Value.Month & "/" & DP2.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS') ) T1 "

            q &= "Left join T_Truck t2 on t1.load_vehicle=t2.id "
            q &= "left join t_driver t3 On t1.load_driver=t3.id "
            q &= "left join t_customer t4 On t1.load_customer=t4.id "
            q &= "Order by t1.reference "


            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "T1")

            LoadingBindingSource.DataSource = MyDataSet
            LoadingBindingSource.DataMember = "T1"

        Catch ex As Exception
        End Try
    End Sub
    Private Sub SelectFinish()
        Dim q As String
        Try
            q = "Select t1.Reference,t1.load_id,NVL2(t1.Container,(t1.Container|| '/' ||t2.TRUCK_NUMBER),t2.TRUCK_NUMBER ) as Truck,"
            q &= "T3.Driver_Name||'  '||T3.Driver_Lastname as Driver "
            q &= ",load_preset,t4.customer_name as Customer,t1.load_dofull as DO "

            q &= "From (Select Reference,load_preset,load_id,load_vehicle,load_driver,load_customer,load_dofull,Container from T_loadingnote where load_status=3 "
            q &= " and T_LOADINGNOTE.AddnoteDate between "
            q &= "To_date('" & DP1.Value.Year & "/" & DP1.Value.Month & "/" & DP1.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
            q &= "To_date('" & DP2.Value.Year & "/" & DP2.Value.Month & "/" & DP2.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS') ) T1 "

            q &= "Left join T_Truck t2 on t1.load_vehicle=t2.id "
            q &= "left join t_driver t3 On t1.load_driver=t3.id "
            q &= "left join t_customer t4 On t1.load_customer=t4.id "
            q &= "Order by t1.reference "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "T1")

            FinishBindingSource.DataSource = MyDataSet
            FinishBindingSource.DataMember = "T1"
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SelectPartload()
        Dim q As String
        Try
            q = "Select t1.Reference,t1.load_id,NVL2(t1.Container,(t1.Container|| '/' ||t2.TRUCK_NUMBER),t2.TRUCK_NUMBER ) as Truck,"
            q &= "T3.Driver_Name||'  '||T3.Driver_Lastname as Driver "
            q &= ",load_preset,t4.customer_name as Customer,t1.load_dofull as DO "

            q &= "From (Select Reference,load_preset,load_id,load_vehicle,load_driver,load_customer,load_dofull,Container from T_loadingnote where load_status=4 "
            q &= " and T_LOADINGNOTE.AddnoteDate between "
            q &= "To_date('" & DP1.Value.Year & "/" & DP1.Value.Month & "/" & DP1.Value.Day & " 00:00:00" & "', 'yyyy/mm/dd HH24:MI:SS') And "
            q &= "To_date('" & DP2.Value.Year & "/" & DP2.Value.Month & "/" & DP2.Value.Day & " 23:59:59" & "', 'yyyy/mm/dd HH24:MI:SS') ) T1 "

            q &= "Left join T_Truck t2 on t1.load_vehicle=t2.id "
            q &= "left join t_driver t3 On t1.load_driver=t3.id "
            q &= "left join t_customer t4 On t1.load_customer=t4.id "
            q &= "Order by t1.reference "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "T1")

            PartloadBindingSource.DataSource = MyDataSet
            PartloadBindingSource.DataMember = "T1"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SelectWaiting()
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        SelectLoading()
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        SelectFinish()
    End Sub

    Private Sub ToolStripButton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton16.Click
        SelectPartload()
    End Sub

    Private Sub ToolStripButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton17.Click
        Try
            If MsgBox("ต้องการทำ Partload ทะเบียนรถ : " & RadGridView2.CurrentRow.Cells("Truck").Value.ToString & " หรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then
                Dim sql, ref As String
                ref = RadGridView2.CurrentRow.Cells("Reference").Value.ToString
                Try
                    sql = ""
                    sql = "Update t_loadingnote set load_Status='4' where reference ='" & ref & "'"

                    cls.Update(sql)
                Catch ex As Exception
                End Try

                Try
                    sql = ""
                    sql = "Update t_loadingnoteCompartment set lc_status='4' where lc_load ='" & ref & "' and lc_status in(1,2) "

                    cls.Update(sql)
                Catch ex As Exception
                End Try

                Advisenote_Status_Shown(sender, e)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton1.Click
        SelectWaiting()
        SelectLoading()
        SelectFinish()
        SelectPartload()
    End Sub

    Private Sub RadGridView2_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadGridView2.DoubleClick
        Grid = 2
        Me.AddOwnedForm(Advisenote_StatusGridView)
        Advisenote_StatusGridView.ShowDialog()
    End Sub

    Private Sub RadGridView3_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadGridView3.DoubleClick
        Grid = 3
        Me.AddOwnedForm(Advisenote_StatusGridView)
        Advisenote_StatusGridView.ShowDialog()
    End Sub

    Private Sub RadGridView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadGridView1.DoubleClick
        Grid = 1
        Me.AddOwnedForm(Advisenote_StatusGridView)
        Advisenote_StatusGridView.ShowDialog()
    End Sub

    Private Sub RadGridView4_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadGridView4.DoubleClick
        Grid = 4
        Me.AddOwnedForm(Advisenote_StatusGridView)
        Advisenote_StatusGridView.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        SelectWaiting()
        SelectLoading()
        SelectFinish()
        SelectPartload()
    End Sub
End Class
