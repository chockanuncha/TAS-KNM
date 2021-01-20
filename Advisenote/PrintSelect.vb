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
Public Class PrintSelect
    Private cls As New Class_SQLSERVERDB
    Private Sub Bsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        Dim ref As String
        'ref = Unloadingnote.MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString
        ref = Advisenote.MasterGridAdvisenote.CurrentRow.Cells("reference").Value.ToString
        If Default_chk.Checked = True Then
            Dim Myreport As New ReportDocument
            Myreport = New ReportDocument
            Dim q As String
            q = ""
            q = "SELECT    T1.LOAD_CAPACITY as LOAD_CAPACITY"
            q &= " , T1.LOAD_PRESET as LOAD_PRESET,T1.LOAD_PRESETFINISH as LOAD_PRESETFINISH,T2.lc_preset,  T1.LOAD_CARD as LOAD_CARD,T1.Load_qdashboard as LOAD_Q"
            q &= " , T2.LC_COMPARTMENT as LC_COMPARTMENT,T1.LOAD_TANK as LOAD_TANK"
            q &= " , T2.LC_BAY as LC_BAY,SUBSTR(CAST(T1.Reference AS VARCHAR2(30)),1,30) AS Reference,  T1.LOAD_DATE as LOAD_DATE"
            q &= " , T1.LOAD_DID as LOAD_DID , T_Status.STATUS_NAME as STATUS_NAME , T1.LOADDO as LOAD_DOfull , T_TRUCK.TRUCK_NUMBER as LOAD_VEHICLE , t_companyparent.Company_name as LOAD_CUSTOMER "
            q &= " , T_DRIVER.Driver_NAME || '  ' ||  T_Driver.Driver_Lastname AS LOAD_DRIVER"
            q &= " , T1.load_id as Load_id, V_DO.DO_STATUS  as DO_STATUS"
            q &= " , T_customer.Customer_Name,t_product.Product_code  as PRODUCT_CODE, T_Batchmeter.BATCH_NAME as BATCH_NAME"
            q &= " , T1.Container as Container, T1.LOAD_TRUCKCOMPANY as LOAD_TRUCKCOMPANY"
            q &= " , LC_SEAL as LC_SEAL, T1.LOAD_SEAL as LOAD_SEAL, T1.LOAD_SEALCOUNT  as LOAD_SEALCOUNT"
            q &= " , T1.ADDNOTEDATE  as ADDNOTEDATE, T2.LC_STARTTIME  as LC_STARTTIME, T2.LC_ENDTIME  as LC_ENDTIME "
            q &= "FROM T_Customer  RIGHT OUTER JOIN (Select * from T_unLoadingnote  Where Reference  ='" & ref & "' )  T1 "
            q &= "ON T_Customer.ID = T1.LOAD_CUSTOMER  "
            q &= "LEFT OUTER JOIN T_STATUS  ON T1.LOAD_STATUS = T_STATUS.STATUS_ID   "
            q &= "LEFT OUTER JOIN V_DO ON T1.LOAD_ID = V_DO.LOAD_ID    "
            q &= "LEFT OUTER JOIN T_TRUCK ON T1.LOAD_VEHICLE = T_TRUCK.ID   "
            q &= "LEFT OUTER JOIN T_DRIVER ON T1.LOAD_DRIVER = T_DRIVER.ID   "
            q &= "LEFT OUTER JOIN T_CARD  ON T1.LOAD_CARD = T_CARD.CARD_NUMBER   "
            q &= "LEFT OUTER JOIN t_companyparent  ON T1.LOAD_COMPANYPARENT = t_cOMPANYPARENT.Company_id   "
            q &= "Left OUTER JOIN T_BATCHMETER   "
            q &= "RIGHT OUTER JOIN (Select * From T_unLoadingnoteCOMPARTMENT where lc_status<>'99') T2 "
            q &= "ON T_BATCHMETER.BATCH_NUMBER = T2.LC_METER   "
            q &= "LEFT OUTER JOIN T_Product ON T2.LC_PRO = T_Product.ID ON T1.LOAD_ID = T2.LC_LOAD "
            q &= "Order by T2.lc_compartment"

            Dim ds As New DataSet
            ds = cls.Query_DS(q, "V_Loadingnote")

            Myreport.Load("UnloadingReport.rpt")
            Myreport.SetDataSource(ds)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()
            ds.Dispose()
        Else
            'ref = Unloadingnote.MasterGridAdvisenote.CurrentRow.Cells("load_id").Value.ToString
            ref = Advisenote.MasterGridAdvisenote.CurrentRow.Cells("load_id").Value.ToString
            Dim Myreport As New ReportDocument
            Myreport = New ReportDocument
            Dim q As String
            q = ""
            q = "SELECT * from vcheckinload where load_id='" & ref & "'"

            Dim ds As New DataSet
            ds = cls.Query_DS(q, "vcheckinload")

            Myreport.Load("Qreport.rpt")
            Myreport.SetDataSource(ds)
            ReportPrint.CrystalReportViewer3.ReportSource = Myreport
            ReportPrint.ShowDialog()
            ds.Dispose()
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Me.Close()
    End Sub

    Private Sub PrintSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Default_chk.Checked = True
    End Sub

    Private Sub PrintSelect_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Default_chk.Checked = True
    End Sub
End Class
