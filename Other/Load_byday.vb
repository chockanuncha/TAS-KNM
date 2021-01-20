Imports System.Data
Imports System
Imports System.IO
Imports System.Data.Common
Imports ExtendedErrorProvider
Imports Telerik.WinControls.UI
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Threading
Imports System.Drawing.Printing
Imports System.ComponentModel
Public Class Load_byday
    Private cls As New Class_SQLSERVERDB

    Dim vpage As Integer = 0
    Private Sub SelectVLoadingNote1()
        Dim q As String
        Try

            q = "SELECT     max(LOAD_CAPACITY) as LOAD_CAPACITY" _
    & " , max(LOAD_PRESET) as LOAD_PRESET, max(LOAD_CARD) as LOAD_CARD," _
    & " max(LC_COMPARTMENT) as LC_COMPARTMENT," _
    & " max(LC_BAY) as LC_BAY,Reference, max(LOAD_DATE) as LOAD_DATE" _
    & " ,max(LOAD_DID) as LOAD_DID ,max(SP_Code) as SP_Code ,max(LOAD_TANK) as LOAD_TANK ,max(STATUS_NAME) as STATUS_NAME ,max(LOAD_DOfull) as LOAD_DOfull ,max(LOAD_VEHICLE) as LOAD_VEHICLE ,max(Product_name) as Product_name ,max(Customer_name) as Customer_name ,max(LOAD_DRIVER) as LOAD_DRIVER,max(load_id) as Load_id,max(DO_STATUS) as DO_STATUS,max(do_POSTDATE) as DO_POSTDATE," _
    & " max(Loaddate) as Loaddate,max(Product_code) as PRODUCT_CODE,max(BATCH_NAME) as BATCH_NAME" _
    & " ,max(Container) as Container,max(LOAD_TRUCKCOMPANY) as LOAD_TRUCKCOMPANY,max(LOAD_PRESET) as LOAD_PRESET" _
    & " ,max(LC_SEAL) as LC_SEAL,max(LOAD_SEAL) as LOAD_SEAL,max(LOAD_SEALCOUNT) as LOAD_SEALCOUNT" _
    & " ,max(ADDNOTEDATE) as ADDNOTEDATE,max(LC_STARTTIME) as LC_STARTTIME,max(LC_ENDTIME) as LC_ENDTIME " _
    & " FROM V_LOADINGNOTE  " _
    & " Where Load_status = 1 and Load_type<>4 " _
    & " group by reference" _
    & " order by Load_ID "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "V_LOADINGNOTE")

            V_LoadingnoteBindingSource.DataSource = MyDataSet
            V_LoadingnoteBindingSource.DataMember = "V_LOADINGNOTE"
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SelectVLoadingNote2()
        Dim q As String
        Try

            q = "SELECT     max(LOAD_CAPACITY) as LOAD_CAPACITY" _
    & " , max(LOAD_PRESET) as LOAD_PRESET, max(LOAD_CARD) as LOAD_CARD," _
    & " max(LC_COMPARTMENT) as LC_COMPARTMENT," _
    & " max(LC_BAY) as LC_BAY,Reference, max(LOAD_DATE) as LOAD_DATE" _
    & " ,max(LOAD_DID) as LOAD_DID ,max(SP_Code) as SP_Code ,max(LOAD_TANK) as LOAD_TANK ,max(STATUS_NAME) as STATUS_NAME ,max(LOAD_DOfull) as LOAD_DOfull ,max(LOAD_VEHICLE) as LOAD_VEHICLE ,max(Product_name) as Product_name ,max(Customer_name) as Customer_name ,max(LOAD_DRIVER) as LOAD_DRIVER,max(load_id) as Load_id,max(DO_STATUS) as DO_STATUS,max(do_POSTDATE) as DO_POSTDATE," _
    & " max(Loaddate) as Loaddate,max(Product_code) as PRODUCT_CODE,max(BATCH_NAME) as BATCH_NAME" _
    & " ,max(Container) as Container,max(LOAD_TRUCKCOMPANY) as LOAD_TRUCKCOMPANY,max(LOAD_PRESET) as LOAD_PRESET" _
    & " ,max(LC_SEAL) as LC_SEAL,max(LOAD_SEAL) as LOAD_SEAL,max(LOAD_SEALCOUNT) as LOAD_SEALCOUNT" _
    & " ,max(ADDNOTEDATE) as ADDNOTEDATE,max(LC_STARTTIME) as LC_STARTTIME,max(LC_ENDTIME) as LC_ENDTIME " _
    & " FROM V_LOADINGNOTE  " _
    & " Where Load_status = 2 and Load_type<>4 " _
    & " group by reference" _
    & " order by Load_ID "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "V_LOADINGNOTE")

            V_LoadingnoteBindingSource.DataSource = MyDataSet
            V_LoadingnoteBindingSource.DataMember = "V_LOADINGNOTE"
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SelectVLoadingNote3()
        Dim q As String
        Try

            q = "SELECT     max(LOAD_CAPACITY) as LOAD_CAPACITY" _
    & " , max(LOAD_PRESET) as LOAD_PRESET, max(LOAD_CARD) as LOAD_CARD," _
    & " max(LC_COMPARTMENT) as LC_COMPARTMENT," _
    & " max(LC_BAY) as LC_BAY,Reference, max(LOAD_DATE) as LOAD_DATE" _
    & " ,max(LOAD_DID) as LOAD_DID ,max(SP_Code) as SP_Code ,max(LOAD_TANK) as LOAD_TANK ,max(STATUS_NAME) as STATUS_NAME ,max(LOAD_DOfull) as LOAD_DOfull ,max(LOAD_VEHICLE) as LOAD_VEHICLE ,max(Product_name) as Product_name ,max(Customer_name) as Customer_name ,max(LOAD_DRIVER) as LOAD_DRIVER,max(load_id) as Load_id,max(DO_STATUS) as DO_STATUS,max(do_POSTDATE) as DO_POSTDATE," _
    & " max(Loaddate) as Loaddate,max(Product_code) as PRODUCT_CODE,max(BATCH_NAME) as BATCH_NAME" _
    & " ,max(Container) as Container,max(LOAD_TRUCKCOMPANY) as LOAD_TRUCKCOMPANY,max(LOAD_PRESET) as LOAD_PRESET" _
    & " ,max(LC_SEAL) as LC_SEAL,max(LOAD_SEAL) as LOAD_SEAL,max(LOAD_SEALCOUNT) as LOAD_SEALCOUNT" _
    & " ,max(ADDNOTEDATE) as ADDNOTEDATE,max(LC_STARTTIME) as LC_STARTTIME,max(LC_ENDTIME) as LC_ENDTIME " _
    & " FROM V_LOADINGNOTE  " _
    & " Where Load_status = 3 and Load_type<>4 " _
    & " group by reference" _
    & " order by Load_ID "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "V_LOADINGNOTE")

            V_LoadingnoteBindingSource.DataSource = MyDataSet
            V_LoadingnoteBindingSource.DataMember = "V_LOADINGNOTE"
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SelectVShipment()
        Dim q As String
        Try

            q = "SELECT     max(LOAD_CAPACITY) as LOAD_CAPACITY" _
    & " , max(LOAD_PRESET) as LOAD_PRESET, max(LOAD_CARD) as LOAD_CARD," _
    & " max(LC_COMPARTMENT) as LC_COMPARTMENT," _
    & " max(LC_BAY) as LC_BAY,Reference, max(LOAD_DATE) as LOAD_DATE" _
    & " ,max(LOAD_DID) as LOAD_DID ,max(SP_Code) as SP_Code ,max(LOAD_TANK) as LOAD_TANK ,max(STATUS_NAME) as STATUS_NAME ,max(LOAD_DOfull) as LOAD_DOfull ,max(LOAD_VEHICLE) as LOAD_VEHICLE ,max(Product_name) as Product_name ,max(Customer_name) as Customer_name ,max(LOAD_DRIVER) as LOAD_DRIVER,max(load_id) as Load_id,max(DO_STATUS) as DO_STATUS,max(do_POSTDATE) as DO_POSTDATE," _
    & " max(Loaddate) as Loaddate,max(Product_code) as PRODUCT_CODE,max(BATCH_NAME) as BATCH_NAME" _
    & " ,max(Container) as Container,max(LOAD_TRUCKCOMPANY) as LOAD_TRUCKCOMPANY,max(LOAD_PRESET) as LOAD_PRESET" _
    & " ,max(LC_SEAL) as LC_SEAL,max(LOAD_SEAL) as LOAD_SEAL,max(LOAD_SEALCOUNT) as LOAD_SEALCOUNT" _
    & " ,max(ADDNOTEDATE) as ADDNOTEDATE,max(LC_STARTTIME) as LC_STARTTIME,max(LC_ENDTIME) as LC_ENDTIME " _
    & " FROM V_LOADINGNOTE  " _
    & " Where Load_status = 1 and Load_type<>4 and SHIP_NO IS NOT NULL " _
    & " group by reference" _
    & " order by Load_ID "

            Dim MyDataSet As New DataSet
            MyDataSet = cls.Query_DS(q, "V_LOADINGNOTE")

            V_LoadingnoteBindingSource.DataSource = MyDataSet
            V_LoadingnoteBindingSource.DataMember = "V_LOADINGNOTE"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Editdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Editdata.Click
        vpage = 1
        SelectVLoadingNote1()
        Textpanel.Text = "รอการจ่าย"

    End Sub

    Private Sub Canceldata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Canceldata.Click
        vpage = 2
        SelectVLoadingNote2()
        Textpanel.Text = "กำลังจ่าย"
    End Sub

    Private Sub Printdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Printdata.Click
        vpage = 3
        SelectVLoadingNote3()
        Textpanel.Text = "จ่ายสมบูรณ์"
    End Sub

    Private Sub Load_byday_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vpage = 1
        SelectVLoadingNote1()
        Textpanel.Text = "รอการจ่าย"
    End Sub

    Private Sub Checkin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefresh.Click
        If vpage = 1 Then
            SelectVLoadingNote1()
        End If
        If vpage = 2 Then
            SelectVLoadingNote2()
        End If
        If vpage = 3 Then
            SelectVLoadingNote3()
        End If
        If vpage = 4 Then
            SelectVShipment()
        End If


    End Sub

    Private Sub Load_byday_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.MasterGridAdvisenote.TableElement.RowHeight = 30
        Me.MasterGridAdvisenote.TableElement.TableHeaderHeight = 40
        RadPanel2.Height = Me.Height / 5.6
    End Sub

    Private Sub RadButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadButton5.Click
        vpage = 4
        SelectVShipment()
        Textpanel.Text = "รอ Shipment"
    End Sub

    Private Sub MasterGridAdvisenote_CellFormatting(ByVal sender As System.Object, ByVal e As Telerik.WinControls.UI.CellFormattingEventArgs) Handles MasterGridAdvisenote.CellFormatting
        e.CellElement.NumberOfColors = 4
        e.CellElement.BackColor = Color.FromArgb(253, 141, 142)
        e.CellElement.BackColor2 = Color.FromArgb(254, 86, 86)
        e.CellElement.BackColor3 = Color.FromArgb(254, 55, 55)
        e.CellElement.BackColor4 = Color.FromArgb(254, 31, 32)
    End Sub
End Class
