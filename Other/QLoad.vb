Imports System.Data
Imports System
Imports System.IO
Imports System.Data.Common
Imports ExtendedErrorProvider
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Threading
Imports System.Drawing.Printing
Imports System.ComponentModel
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Public Class Q_Load
    Private cls As New Class_SQKDB
    Private cls_ct As New Class_Controls
    Private Function LenSpace(ByVal DataSAP As String, ByVal Length As Integer, ByVal Len As Integer) As String
        Dim i As Integer
        If DataSAP.Length > Len Then
            For i = 1 To Len
                DataSAP = DataSAP & " "
            Next
        Else
            For i = 1 To Len - DataSAP.Length
                DataSAP = DataSAP & " "
            Next
            LenSpace = DataSAP
        End If
    End Function

    Private Sub SelectShipment()
        Dim q As String
        Try

            q = "select DO_NO,Ship_no,Truck_card,Truck_number,Driver_card,Driver_NAMEFull,load_id from VDoload where load_id in(select load_id from t_loadingnote where load_status=1) and Ship_no is null order by do_no desc"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "VDoload")

            SHipmentBindingSource.DataSource = MyDataSet
            SHipmentBindingSource.DataMember = "VDoload"

        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelectInvoide()
        Dim q As String
        Try

            q = "select DO_NO,Ship_no,Truck_card,Truck_number,Driver_card,load_id,Driver_NAMEFull from VDoload where load_id in(select load_id from t_loadingnote where load_status=3) and status>=5 order by do_no desc"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "VDoload")

            SHipmentBindingSource.DataSource = MyDataSet
            SHipmentBindingSource.DataMember = "VDoload"

        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelectWaitAdnote()
        Dim q As String
        Try

            q = ""
            q = "select t_checkin.id,t_checkin.ldate,t_checkin.driver_card,t_checkin.driver_id,t_checkin.truck_card,"
            q &= "t_checkin.truck_id,t_checkin.status,t_checkin.q_no,t_checkin.DO_ID,t_checkin.DO_NO,t_checkin.LOAD_ID,"

            q &= "T_TRUCK.TRUCK_NUMBER, t_DRIVER.Driver_Name as AA, t_DRIVER.Driver_Lastname,T_DRIVER.Driver_NAME|| '  ' || T_Driver.Driver_Lastname AS Driver_NAME from t_checkin LEFT OUTER JOIN T_TRUCK on t_checkin.truck_id=t_truck.id "
            q &= "LEFT OUTER JOIN t_DRIVER on t_checkin.driver_id=t_DRIVER.Id where t_checkin.status=2 order by t_checkin.do_no desc "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "vcheckinload")

            SHipmentBindingSource.DataSource = MyDataSet
            SHipmentBindingSource.DataMember = "vcheckinload"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DoSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SelectWaitAdnote()
        RadPanel_WaitAdnote.BringToFront()
    End Sub

    Private Sub Q_Load_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.MasterGrid.TableElement.RowHeight = 40
        Me.MasterGrid.TableElement.TableHeaderHeight = 50

        Me.QGrid.TableElement.RowHeight = 40
        Me.QGrid.TableElement.TableHeaderHeight = 50

        Me.CheckinGrid.TableElement.RowHeight = 40
        Me.CheckinGrid.TableElement.TableHeaderHeight = 50

        Me.AdnoteGrid.TableElement.RowHeight = 40
        Me.AdnoteGrid.TableElement.TableHeaderHeight = 50

        Me.RadGridView1.TableElement.RowHeight = 40
        Me.RadGridView1.TableElement.TableHeaderHeight = 50

        Me.RadGridView3.TableElement.RowHeight = 40
        Me.RadGridView3.TableElement.TableHeaderHeight = 50
    End Sub
    Private Sub SelectCheckin()
        Dim q As String
        Try

            q = ""
            q = "select Rownum as Item,t_checkin.id,t_checkin.ldate,t_checkin.driver_card,t_checkin.driver_id,t_checkin.truck_card,"
            q &= "t_checkin.truck_id,t_checkin.status,t_checkin.q_no,t_checkin.DO_ID,t_checkin.DO_NO,t_checkin.LOAD_ID,"
            q &= "T_TRUCK.TRUCK_NUMBER  "
            q &= "from t_checkin LEFT OUTER JOIN T_TRUCK on t_checkin.truck_id=t_truck.id "
            q &= "Where T_Checkin.Status=0 order by T_Checkin.Ldate "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "VDoload")

            SHipmentBindingSource.DataSource = MyDataSet
            SHipmentBindingSource.DataMember = "VDoload"
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Checkin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkin.Click
        SelectCheckin()
        RadPanel_Checkin.BringToFront()
    End Sub



    Private Sub Q_Load_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet_Table1.T_QLOADEND' table. You can move, or remove it, as needed.
        Me.T_QLOADENDTableAdapter.Fill(Me.DataSet_Table1.T_QLOADEND)
        'TODO: This line of code loads data into the 'DataSet_Table1.T_CHECKIN' table. You can move, or remove it, as needed.
        Me.T_CHECKINTableAdapter.Fill(Me.DataSet_Table1.T_CHECKIN)
        'TODO: This line of code loads data into the 'DataSet_View.VCARDLOAD' table. You can move, or remove it, as needed.
        Me.VCARDLOADTableAdapter.Fill(Me.DataSet_View.VCARDLOAD)
        'TODO: This line of code loads data into the 'DataSet_Table.T_TRUCK' table. You can move, or remove it, as needed.
        Me.T_TRUCKTableAdapter.Fill(Me.DataSet_Table.T_TRUCK)

        RadDropDownList1.SelectedIndex = -1

        SelectCheckin()
        RadPanel_Checkin.BringToFront()
    End Sub

    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'TCHECKINBindingSource.EndEdit()
            'T_CHECKINTableAdapter.Update(DataSet_Table.T_CHECKIN)
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถอัพเดทข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Q_Load_Load(sender, e)
        End Try
        'Me.T_CHECKINTableAdapter.Fill(Me.DataSet_Table.T_CHECKIN)
        End
    End Sub



    Private Sub BsaveQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BsaveQ.Click
        Try
            'TCHECKINBindingSource.EndEdit()
            'T_CHECKINTableAdapter.Update(DataSet_Table.T_CHECKIN)
        Catch ex As Exception
            MessageBox.Show("ไม่สามารถอัพเดทข้อมูลได้ กรุณาตรวจสอบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Q_Load_Load(sender, e)
        End Try
        'Me.T_CHECKINTableAdapter.Fill(Me.DataSet_Table.T_CHECKIN)
    End Sub

    Private Sub SelectCheckinQ()
        Dim q As String
        Try
            q = ""
            q = "select t_checkin.id,t_checkin.ldate,t_checkin.driver_card,t_checkin.driver_id,t_checkin.truck_card,"
            q &= "t_checkin.truck_id,t_checkin.status,t_checkin.q_no,t_checkin.DO_ID,t_checkin.DO_NO,t_checkin.LOAD_ID,t_checkin.Q_Date,"
            q &= "T_TRUCK.TRUCK_NUMBER, t_DRIVER.Driver_Name as AA, t_DRIVER.Driver_Lastname,T_DRIVER.Driver_NAME|| '  ' || T_Driver.Driver_Lastname AS Driver_NAME "
            q &= "from t_checkin LEFT OUTER JOIN T_TRUCK on t_checkin.truck_id=t_truck.id "
            q &= "LEFT OUTER JOIN t_DRIVER on t_checkin.driver_id=t_DRIVER.Id "
            q &= "Where T_Checkin.Status=1 order by T_Checkin.ID desc"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "T_Checkin")

            TCHECKINBindingSource.DataSource = MyDataSet
            TCHECKINBindingSource.DataMember = "T_Checkin"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub WaitQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaitQ.Click
        SelectCheckinQ()
        RadPanel_Q.BringToFront()
    End Sub

    Private Sub CreateAdnote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateAdnote.Click

        SelectCreateAdnote()
        RadPanel_CreatAdnote.BringToFront()
    End Sub
    Private Sub SelectCreateAdnote()
        Dim q As String
        Try

            q = ""
            q = "select t_checkin.id,t_checkin.ldate,t_checkin.driver_card,t_checkin.driver_id,t_checkin.truck_card,"
            q &= "t_checkin.truck_id,t_checkin.status,t_checkin.q_no,t_checkin.DO_ID,t_checkin.DO_NO,t_checkin.LOAD_ID,"

            q &= "T_TRUCK.TRUCK_NUMBER, t_DRIVER.Driver_Name as AA, t_DRIVER.Driver_Lastname,T_DRIVER.Driver_NAME|| '  ' || T_Driver.Driver_Lastname AS Driver_NAME from t_checkin LEFT OUTER JOIN T_TRUCK on t_checkin.truck_id=t_truck.id "
            q &= "LEFT OUTER JOIN t_DRIVER on t_checkin.driver_id=t_DRIVER.Id where Status=1 order by t_checkin.do_no desc "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "vcheckinload")

            SHipmentBindingSource.DataSource = MyDataSet
            SHipmentBindingSource.DataMember = "vcheckinload"
        Catch ex As Exception
        End Try
    End Sub


    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Dim sql, ref As String
        ref = MasterGrid.CurrentRow.Cells("id").Value.ToString
        If MsgBox("ต้องการยกเลิกคิวเลขที่ " + ref + " หรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then

            sql = ""
            sql = "delete  T_Checkin  where ID =" + ref + ""

            cls.Delete(sql)

            SelectCheckinQ()

        Else
            SelectCheckinQ()
        End If
    End Sub





    Private Sub TCheckinBindingSource_PositionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SelectDODetail()
    End Sub

    Private Sub SelectDODetail()

        Dim ref As String
        Dim q As String
        Try

            q = ""
            q = "select * from t_do where DO_NO in('" + MasterGrid.CurrentRow.Cells("DO_NO").Value.ToString + "')  order by DO_ITEM"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "T_DO")

            'DOdetailBindingSource.DataSource = MyDataSet
            'DOdetailBindingSource.DataMember = "T_DO"

        Catch ex As Exception
        End Try

    End Sub

    Private Sub RadButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton3.Click
        Dim sql, ref As String

        sql = ""
        sql = "select Truck_ID,Card_Number,Card_serial from vcardload "
        sql &= "where Truck_ID= '" & (TTRUCKBindingSource.Item(TTRUCKBindingSource.Position)("ID").ToString()) & "' and TRUCK_BLACK_LIST='NO' and Card_status='1'"

        Dim dt As DataTable = cls.Query(sql)

        If dt.Rows.Count > 0 Then

            sql = ""
            sql = "Delete t_CHECKIN where TRUCK_CARD ='" & dt.Rows(0).Item("CARD_SERIAL").ToString & "'"

            cls.Delete(sql)

            sql = "Insert into t_CHECKIN (LDATE,TRUCK_CARD,TRUCK_ID)"
            sql &= " Values ()"

            sql = "Insert into t_CHECKIN (" & _
                " LDATE,TRUCK_CARD,TRUCK_ID) VALUES (" & _
                " sysdate" & "," & _
                "'" & dt.Rows(0).Item("CARD_SERIAL").ToString & "'" & "," & _
                "'" & dt.Rows(0).Item("TRUCK_ID").ToString & "'" & ")"

            cls.Insert(sql)
        Else

        End If

        dt.Dispose()
        SelectCheckin()
    End Sub

    Private Sub RadButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton4.Click
        SelectCheckin()
    End Sub

    Private Sub CheckinGrid_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckinGrid.DoubleClick
        If MsgBox("ต้องการแตะบัตรทางออกของทะเบียนรถ : " & CheckinGrid.CurrentRow.Cells("Truck_number").Value.ToString & " หรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then
            Dim sql, ref As String
            Try
                ref = CheckinGrid.CurrentRow.Cells("id").Value.ToString

                sql = ""
                sql = "Update t_CHECKIN set Status='50',Chkout_Date=Sysdate where ID ='" & ref & "'"

                cls.Update(sql)

            Catch ex As Exception

            End Try

            Try
                sql = ""
                sql = "Update t_loadingnote set Checkout_time=Sysdate where load_ID in(Select Load_id from t_checkin where ID='" & CheckinGrid.CurrentRow.Cells("id").Value.ToString & "')"

                cls.Update(sql)

            Catch ex As Exception

            End Try
        End If
        SelectCheckin()
    End Sub

    Private Sub RadButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton6.Click
        RadPanel2.Text = "Clear Q Dashbord"
        Q_Dahbord.BringToFront()
        SelectQDashbord()
        SelectQUnDashbord()
    End Sub
    Private Sub SelectQDashbord()
        Dim ref As String
        Dim q As String
        Try

            q = ""
            q = "SELECT  t.*, row_number() OVER (ORDER BY ID desc) rn FROM    T_QLOADEND t  where ROWNUM<=10 order by id  desc"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "T_QLOADEND")

            TQLOADENDBindingSource.DataSource = MyDataSet
            TQLOADENDBindingSource.DataMember = "T_QLOADEND"

        Catch ex As Exception

        End Try

    End Sub
    Private Sub SelectQUnDashbord()

        Dim q As String
        Try

            q = ""
            q = "SELECT  t.*, row_number() OVER (ORDER BY ID desc) rn FROM    T_QUNLOADEND t  where ROWNUM<=10 order by id  desc"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "T_QLOADEND")

            'TQUnloadBindingSource.DataSource = MyDataSet
            'TQUnloadBindingSource.DataMember = "T_QUNLOADEND"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        If MsgBox("Dashbooard Queue : '" & DashbordLoad_Grid.CurrentRow.Cells("Q_NO").Value.ToString & "', Do you want to delete?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
            Dim ref, sql, q, Detail As String
            ref = DashbordLoad_Grid.CurrentRow.Cells("ID").Value.ToString
            Detail = "'USER """ & MAIN.U_NAME.ToString & """ ลบคิว loading บนหน้าจอ Dashbord คิวที่ " & DashbordLoad_Grid.CurrentRow.Cells("Q_No").Value.ToString & " ทะเบียนรถ " & DashbordLoad_Grid.CurrentRow.Cells("truck_number").Value.ToString

            sql = ""
            sql = "Delete T_QLOADEND  where ID='" & ref & "'"

            cls.Delete(sql)

            q = ""
            q = "INSERT INTO T_EVENT(LDATE,LTIME ,LDAY,LMONTH,LYEAR,E_USER,E_TYPE"
            q &= ",E_TABLE,DETAIL)"
            q &= "VALUES(SYSTIMESTAMP"
            q &= ",SYSTIMESTAMP"
            q &= ",EXTRACT(DAY FROM SYSTIMESTAMP)"
            q &= ",EXTRACT(MONTH FROM SYSTIMESTAMP)"
            q &= ",EXTRACT(YEAR FROM SYSTIMESTAMP)"
            q &= ",'" & MAIN.U_NAME.ToString & "'"
            q &= ",'D'"
            q &= ",'QLOADEND'"
            q &= "," & Detail.ToString & "')"

            cls.Insert(q)

            SelectQDashbord()

        Else
            RadPanel2.Text = "Clear Q Dashbord"
            Q_Dahbord.BringToFront()
            SelectQDashbord()
            SelectQUnDashbord()
        End If
    End Sub

    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click

        If MsgBox("ต้องการลบคิว Unload บนหน้าจอ Dashbord คิวที่ '" & DashbordUnLoad_Grid.CurrentRow.Cells("Q_NO").Value.ToString & "'หรือไม่ ?", vbYesNo + vbDefaultButton2, "ยืนยัน") = vbYes Then
            Dim ref, sql, q, Detail As String
            ref = DashbordUnLoad_Grid.CurrentRow.Cells("ID").Value.ToString

            Detail = "'USER """ & MAIN.U_NAME.ToString & """ ลบคิว Unload บนหน้าจอ Dashbord คิวที่ " & DashbordUnLoad_Grid.CurrentRow.Cells("Q_No").Value.ToString & " ทะเบียนรถ " & DashbordUnLoad_Grid.CurrentRow.Cells("truck_number").Value.ToString

            sql = ""
            sql = "Delete T_QUNLOADEND  where ID='" & ref & "'"

            cls.Delete(sql)

            q = ""
            q = "INSERT INTO T_EVENT(LDATE,LTIME ,LDAY,LMONTH,LYEAR,E_USER,E_TYPE"
            q &= ",E_TABLE,DETAIL)"
            q &= "VALUES(SYSTIMESTAMP"
            q &= ",SYSTIMESTAMP"
            q &= ",EXTRACT(DAY FROM SYSTIMESTAMP)"
            q &= ",EXTRACT(MONTH FROM SYSTIMESTAMP)"
            q &= ",EXTRACT(YEAR FROM SYSTIMESTAMP)"
            q &= ",'" & MAIN.U_NAME.ToString & "'"
            q &= ",'D'"
            q &= ",'QUNLOADEND'"
            q &= "," & Detail.ToString & "')"

            cls.Insert(q)

            SelectQUnDashbord()
        Else
            RadPanel2.Text = "Clear Q Dashbord"
            Q_Dahbord.BringToFront()
            SelectQDashbord()
            SelectQUnDashbord()
        End If
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        SelectQUnDashbord()
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        SelectQDashbord()
    End Sub

    Private Sub RadButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton7.Click
        RadPanel2.Text = "Check Out"
        SelectCheckout()
        CheckoutPanel.BringToFront()
    End Sub
    Private Sub SelectCheckout()

        Dim q As String
        Try

            q = ""
            q = "SELECT * FROM VCheckinload t  where Status<>50 order by id"

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "VCHECKINLOAD1")

            CheckOutBindingSource.DataSource = MyDataSet
            CheckOutBindingSource.DataMember = "VCHECKINLOAD1"
        Catch ex As Exception
        End Try

    End Sub

    Private Sub ToolStripButton24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton24.Click

        If MsgBox("Truck No. : '" & RadGridView3.CurrentRow.Cells("Truck_number").Value.ToString & "', Do you want to force checkout?", vbYesNo + vbDefaultButton2, "Confirm") = vbYes Then
            Dim ref, sql, q, Detail As String
            ref = RadGridView3.CurrentRow.Cells("ID").Value.ToString

            Detail = "'USER """ & MAIN.U_NAME.ToString & """ กด Check Out รถทะเบียน " & RadGridView3.CurrentRow.Cells("Truck_number").Value.ToString

            sql = ""
            sql = "Delete T_QUNLOADEND  where ID='" & ref & "'"

            cls.Delete(sql)

            sql = "update  T_CHECKIN Set " &
                            " STATUS=50,Chkout_date=sysdate where ID ='" & ref & "'"

            cls.Update(sql)

            sql = "Delete  t_dashboard where load_ID in(select load_id from t_checkin where ID ='" & ref & "')"

            cls.Delete(sql)

            sql = "Delete  t_dashboardunload where load_ID in(select load_id from t_checkin where ID ='" & ref & "')"

            cls.Delete(sql)

            sql = "update  T_LOADINGNOTE Set load_status=3,CHECKOUT_TIME=sysdate where Load_id " &
                            " in(select load_id from t_checkin where id ='" & ref & "')"

            cls.Update(sql)

            sql = "update  T_UNLOADINGNOTE Set load_status=3,CHECKOUT_TIME=sysdate where Load_id " &
                           " in(select load_id from t_checkin where id ='" & ref & "')"

            cls.Update(sql)

            q = ""
            q = "INSERT INTO T_EVENT(LDATE,LTIME ,LDAY,LMONTH,LYEAR,E_USER,E_TYPE"
            q &= ",E_TABLE,DETAIL)"
            q &= "VALUES(SYSTIMESTAMP"
            q &= ",SYSTIMESTAMP"
            q &= ",EXTRACT(DAY FROM SYSTIMESTAMP)"
            q &= ",EXTRACT(MONTH FROM SYSTIMESTAMP)"
            q &= ",EXTRACT(YEAR FROM SYSTIMESTAMP)"
            q &= ",'" & MAIN.U_NAME.ToString & "'"
            q &= ",'D'"
            q &= ",'T_Checkin'"
            q &= "," & Detail.ToString & "')"

            cls.Insert(q)

            SelectCheckout()
        Else
            RadPanel2.Text = "Check Out"
            SelectCheckout()
            CheckoutPanel.BringToFront()
        End If
    End Sub

    Private Sub ToolStripButton23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton23.Click
        SelectCheckout()
    End Sub
End Class
