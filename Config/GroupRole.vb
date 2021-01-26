Imports Telerik.WinControls.UI

Public Class GroupRole
    Private cls As New Class_SQLSERVERDB
    Private ds As New DataSet
    Public G_ID As Integer
    Private Sub GroupRole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Chk_View()

        Dim dt As DataTable = CreateDatatable()
        ds = New DataSet
        'TODO: This line of code loads data into the 'DataSet_View.V_UGRP_ROLE' table. You can move, or remove it, as needed.
        Me.V_UGRP_ROLETableAdapter.Fill(Me.DataSet_View.V_UGRP_ROLE)
        'TODO: This line of code loads data into the 'DataSet_Table.T_PROGRAMS' table. You can move, or remove it, as needed.
        Me.T_PROGRAMSTableAdapter.Fill(Me.DataSet_Table.T_PROGRAMS)

        Dim sql As String

        sql = "SELECT * FROM T_MENUS WHERE MENU_ID NOT IN(SELECT MENUID FROM T_UGRP_ROLE WHERE GROUPID='" & G_ID & "')"
        cls.Query_DA(sql, ds, "T_MENUS")

        sql = "SELECT * FROM T_UGRP_ROLE WHERE GROUPID='" & G_ID & "'"
        cls.Query_DA(sql, ds, "T_UGRP_ROLE")

        sql = "SELECT * FROM V_UGRP_ROLE WHERE GROUPID=" & G_ID & " ORDER BY PROGRAMID ASC, MENUID ASC"
        cls.Query_DA(sql, ds, "V_UGRP_ROLE")

        sql = "SELECT * FROM V_MENUS_PROGRAMS"
        cls.Query_DA(sql, ds, "V_MENUS_PROGRAMS")

        For Each dr As DataRow In ds.Tables(2).Rows
            Dim row As DataRow = dt.NewRow
            row("GROUP_ID") = dr("GROUPID")
            row("PROGRAM_NAME") = dr("PROGRAM_NAME")
            row("PROGRAM_ID") = dr("PROGRAMID")
            row("MENU_NAME") = dr("M_NAME")
            row("MENU_ID") = dr("MENUID")

            row("CHK_ADD") = dr("chkadd")
            row("CHK_EDIT") = dr("chkedit")
            row("CHK_DEL") = dr("chkdel")
            row("CHK_PRINT") = dr("chkprint")
            row("CHK_VIEW") = dr("chkview")

            dt.Rows.Add(row)
        Next


        VUGRPROLEBindingSource.DataSource = dt

        RadTreeView1.Nodes.Clear()
        For i As Integer = 0 To TPROGRAMSBindingSource.Count - 1
            RadTreeView1.Nodes.Add(TPROGRAMSBindingSource.Item(i)("Program_Name").ToString)
            Dim dr() As DataRow = ds.Tables("T_MENUS").Select("PROGRAM_ID='" & TPROGRAMSBindingSource.Item(i)("PROGRAM_ID").ToString & "'", "")
            For j As Integer = 0 To dr.Length - 1
                RadTreeView1.Nodes(TPROGRAMSBindingSource.Item(i)("Program_Name").ToString).Nodes.Add(dr(j)("M_Name").ToString)
            Next
            RadTreeView1.Nodes(TPROGRAMSBindingSource.Item(i)("Program_Name").ToString).Expanded = True
        Next

    End Sub

    Private Sub BtAdd_Click(sender As Object, e As EventArgs) Handles BtAdd.Click
        Dim Node1 As String = ""
        Dim Node2 As String = ""
        Dim Pos As Integer = 0
        For i As Integer = 0 To RadTreeView1.SelectedNodes.Count - 1
            Node1 = RadTreeView1.SelectedNodes.Item(0).RootNode.Value
            Node2 = RadTreeView1.SelectedNodes.Item(0).Value
            If Node1 = Node2 Then
                For j As Integer = 0 To RadTreeView1.Nodes(Node1).Nodes.Count - 1
                    VUGRPROLEBindingSource.AddNew()
                    Pos = VUGRPROLEBindingSource.Position
                    Node2 = RadTreeView1.Nodes(Node1).Nodes(0).Value()
                    VUGRPROLEBindingSource.Item(Pos)("GROUP_ID") = G_ID
                    VUGRPROLEBindingSource.Item(Pos)("PROGRAM_NAME") = Node1
                    VUGRPROLEBindingSource.Item(Pos)("PROGRAM_ID") = ds.Tables("V_MENUS_PROGRAMS").Compute("Max(Program_ID)", "Program_name='" & Node1 & "'")
                    VUGRPROLEBindingSource.Item(Pos)("MENU_NAME") = Node2
                    VUGRPROLEBindingSource.Item(Pos)("MENU_ID") = ds.Tables("V_MENUS_PROGRAMS").Compute("Max(Menu_ID)", "Program_name='" & Node1 & "'" & " and M_Name='" & Node2 & "'")

                    VUGRPROLEBindingSource.Item(Pos)("CHK_ADD") = False
                    VUGRPROLEBindingSource.Item(Pos)("CHK_EDIT") = False
                    VUGRPROLEBindingSource.Item(Pos)("CHK_DEL") = False
                    VUGRPROLEBindingSource.Item(Pos)("CHK_PRINT") = True
                    VUGRPROLEBindingSource.Item(Pos)("CHK_VIEW") = True
                    RadTreeView1.Nodes(Node1).Nodes(Node2).Remove()
                Next
            Else
                VUGRPROLEBindingSource.AddNew()
                Pos = VUGRPROLEBindingSource.Position
                VUGRPROLEBindingSource.Item(Pos)("GROUP_ID") = G_ID
                VUGRPROLEBindingSource.Item(Pos)("PROGRAM_NAME") = Node1
                VUGRPROLEBindingSource.Item(Pos)("PROGRAM_ID") = ds.Tables("V_MENUS_PROGRAMS").Compute("Max(Program_ID)", "Program_name='" & Node1 & "'")
                VUGRPROLEBindingSource.Item(Pos)("MENU_NAME") = Node2
                VUGRPROLEBindingSource.Item(Pos)("MENU_ID") = ds.Tables("V_MENUS_PROGRAMS").Compute("Max(Menu_ID)", "Program_name='" & Node1 & "'" & " and M_Name='" & Node2 & "'")

                VUGRPROLEBindingSource.Item(Pos)("CHK_ADD") = False
                VUGRPROLEBindingSource.Item(Pos)("CHK_EDIT") = False
                VUGRPROLEBindingSource.Item(Pos)("CHK_DEL") = False
                VUGRPROLEBindingSource.Item(Pos)("CHK_PRINT") = True
                VUGRPROLEBindingSource.Item(Pos)("CHK_VIEW") = True
                RadTreeView1.Nodes(Node1).Nodes(Node2).Remove()
            End If


        Next
        VUGRPROLEBindingSource.EndEdit()
        VUGRPROLEBindingSource.Position = -1
    End Sub

    Private Function CreateDatatable()
        Dim dt As New DataTable
        dt.Columns.Add("GROUP_ID", GetType(Integer))
        dt.Columns.Add("PROGRAM_NAME", GetType(String))
        dt.Columns.Add("PROGRAM_ID", GetType(Integer))
        dt.Columns.Add("MENU_NAME", GetType(String))
        dt.Columns.Add("MENU_ID", GetType(Integer))

        dt.Columns.Add("CHK_ADD", GetType(Boolean))
        dt.Columns.Add("CHK_EDIT", GetType(Boolean))
        dt.Columns.Add("CHK_DEL", GetType(Boolean))
        dt.Columns.Add("CHK_PRINT", GetType(Boolean))
        dt.Columns.Add("CHK_VIEW", GetType(Boolean))

        Return dt
    End Function

    Private Sub BTAddall_Click(sender As Object, e As EventArgs) Handles BTAddall.Click
        Dim Node1 As String = ""
        Dim Node2 As String = ""
        Dim Pos As Integer = 0
        For i As Integer = 0 To RadTreeView1.Nodes.Count - 1
            Node1 = RadTreeView1.Nodes.Item(i).RootNode.Value
            For j As Integer = 0 To RadTreeView1.Nodes(Node1).Nodes.Count - 1
                RadGridView1.Rows.AddNew()
                Pos = VUGRPROLEBindingSource.Position
                Node2 = RadTreeView1.Nodes(Node1).Nodes(0).Value()
                VUGRPROLEBindingSource.Item(Pos)("GROUP_ID") = G_ID
                VUGRPROLEBindingSource.Item(Pos)("PROGRAM_NAME") = Node1
                VUGRPROLEBindingSource.Item(Pos)("PROGRAM_ID") = ds.Tables("V_MENUS_PROGRAMS").Compute("Max(Program_ID)", "Program_name='" & Node1 & "'")
                VUGRPROLEBindingSource.Item(Pos)("MENU_NAME") = Node2
                VUGRPROLEBindingSource.Item(Pos)("MENU_ID") = ds.Tables("V_MENUS_PROGRAMS").Compute("Max(Menu_ID)", "Program_name='" & Node1 & "'" & " and M_Name='" & Node2 & "'")

                VUGRPROLEBindingSource.Item(Pos)("CHK_ADD") = False
                VUGRPROLEBindingSource.Item(Pos)("CHK_EDIT") = False
                VUGRPROLEBindingSource.Item(Pos)("CHK_DEL") = False
                VUGRPROLEBindingSource.Item(Pos)("CHK_PRINT") = True
                VUGRPROLEBindingSource.Item(Pos)("CHK_VIEW") = True
                RadTreeView1.Nodes(Node1).Nodes(Node2).Remove()
            Next

        Next
        VUGRPROLEBindingSource.EndEdit()
        VUGRPROLEBindingSource.Position = -1
    End Sub

    Private Sub BtDel_Click(sender As Object, e As EventArgs) Handles BtDel.Click
        For i As Integer = 0 To RadGridView1.SelectedRows.Count - 1
            Dim node_name As String = RadGridView1.SelectedRows(0).Cells("PROGRAMNAME").Value
            Dim node_val As String = RadGridView1.SelectedRows(0).Cells("MenuName").Value
            RadTreeView1.Nodes(node_name).Nodes.Add(node_val)
            RadGridView1.SelectedRows(0).Delete()
        Next
    End Sub

    Private Sub BtDelALL_Click(sender As Object, e As EventArgs) Handles BtDelALL.Click
        For i As Integer = 0 To RadGridView1.Rows.Count - 1
            RadTreeView1.Nodes(RadGridView1.Rows(0).Cells("ProgramName").Value).Nodes.Add(RadGridView1.Rows(0).Cells("MenuName").Value)
            RadGridView1.Rows(0).Delete()
        Next
    End Sub

    Private Sub Btcancel_Click(sender As Object, e As EventArgs) Handles Btcancel.Click
        Close()
    End Sub

    Private Sub BtSave_Click(sender As Object, e As EventArgs) Handles BtSave.Click

        cls.Delete("Delete From T_UGRP_ROLE where GROUPID='" & G_ID & "'")

        For i As Integer = 0 To VUGRPROLEBindingSource.Count - 1

            Dim sql As String = "insert Into T_UGRP_ROLE (GROUPID,MenuID,ProgramID,chkadd,chkedit,chkdel,chkprint,chkview) VALUES (" &
            "'" & VUGRPROLEBindingSource.Item(i)("GROUP_ID").ToString & "'," &
            "'" & VUGRPROLEBindingSource.Item(i)("MENU_ID").ToString & "'," &
            "'" & VUGRPROLEBindingSource.Item(i)("PROGRAM_ID").ToString & "'," &
            "" & CInt(VUGRPROLEBindingSource.Item(i)("CHK_ADD")) & "," &
            "" & CInt(VUGRPROLEBindingSource.Item(i)("CHK_EDIT")) & "," &
            "" & CInt(VUGRPROLEBindingSource.Item(i)("CHK_DEL")) & "," &
            "" & CInt(VUGRPROLEBindingSource.Item(i)("CHK_PRINT")) & "," &
            "" & CInt(VUGRPROLEBindingSource.Item(i)("CHK_VIEW")) & "" &
            ")"
            cls.Insert(sql)
        Next

        cls.InsertEvent(MAIN.U_NAME, "User : " & MAIN.U_NAME & "  Update Role in group : " & LUser.Text, "T_UGRP_ROLE", "")
        GroupRole_Load(Nothing, Nothing)
    End Sub
End Class
