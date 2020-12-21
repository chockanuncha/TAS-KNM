Public Class Advisenote_StatusGridView
    Private cls As New Class_SQKDB
    Dim reff As String

    Private Sub Advisenote_StatusGridView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        reff = ""
        Timer1.Enabled = False
        SelectDatagrid()
    End Sub

    Private Sub SelectDatagrid()
        Dim ref, q As String
        Try
            If Advisenote_Status.Grid = 1 Then
                ref = Advisenote_Status.RadGridView1.CurrentRow.Cells("load_id").Value.ToString
            ElseIf Advisenote_Status.Grid = 2 Then
                ref = Advisenote_Status.RadGridView2.CurrentRow.Cells("load_id").Value.ToString
            ElseIf Advisenote_Status.Grid = 3 Then
                ref = Advisenote_Status.RadGridView3.CurrentRow.Cells("load_id").Value.ToString
            ElseIf Advisenote_Status.Grid = 4 Then
                ref = Advisenote_Status.RadGridView4.CurrentRow.Cells("load_id").Value.ToString
            End If

            reff = ref

            q = "Select t1.lc_compartment,t1.lc_bay,t2.product_code as Product,t1.lc_preset "
            q &= ",t3.GROSS_M1 as Gross,t3.net86f as NET,(t1.lc_preset-t3.GROSS_M1) as Loss "
            q &= ",t3.AVG_TEMP_M1 as TEMP,t4.STATUS_NAME as Status "
            q &= "from (select * from t_loadingnotecompartment where lc_load= '" & ref & "' order by lc_compartment) T1 "
            q &= "left join t_product t2 on t1.lc_pro=t2.id "
            q &= "left join T_Status t4 on t1.lc_Status=t4.id "
            q &= "left join V_BOL_M1M2_NEW t3 on t1.lc_load=t3.Reference and t1.lc_compartment=t3.LC_COMPARTMENT "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "T1")

            BindingSource1.DataSource = MyDataSet
            BindingSource1.DataMember = "T1"
        Catch ex As Exception
        End Try
        Timer1.Enabled = True
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dim q As String
        Try
            q = "Select t1.lc_compartment,t1.lc_bay,t2.product_code as Product,t1.lc_preset "
            q &= ",t3.GROSS_M1 as Gross,t3.net86f as NET,(t1.lc_preset-t3.GROSS_M1) as Loss "
            q &= ",t3.AVG_TEMP_M1 as TEMP,t4.STATUS_NAME as Status "
            q &= "from (select * from t_loadingnotecompartment where lc_load= '" & reff & "' order by lc_compartment) T1 "
            q &= "left join t_product t2 on t1.lc_pro=t2.id "
            q &= "left join T_Status t4 on t1.lc_Status=t4.id "
            q &= "left join V_BOL_M1M2_NEW t3 on t1.lc_load=t3.Reference and t1.lc_compartment=t3.LC_COMPARTMENT "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "T1")

            BindingSource1.DataSource = MyDataSet
            BindingSource1.DataMember = "T1"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim q As String
        Try
            q = "Select t1.lc_compartment,t1.lc_bay,t2.product_code as Product,t1.lc_preset "
            q &= ",t3.GROSS_M1 as Gross,t3.net86f as NET,(t1.lc_preset-t3.GROSS_M1) as Loss "
            q &= ",t3.AVG_TEMP_M1 as TEMP,t4.STATUS_NAME as Status "
            q &= "from (select * from t_loadingnotecompartment where lc_load= '" & reff & "' order by lc_compartment) T1 "
            q &= "left join t_product t2 on t1.lc_pro=t2.id "
            q &= "left join T_Status t4 on t1.lc_Status=t4.id "
            q &= "left join V_BOL_M1M2_NEW t3 on t1.lc_load=t3.Reference and t1.lc_compartment=t3.LC_COMPARTMENT "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "T1")

            BindingSource1.DataSource = MyDataSet
            BindingSource1.DataMember = "T1"
        Catch ex As Exception
        End Try
    End Sub
End Class
