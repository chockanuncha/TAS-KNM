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
Imports System.Globalization
Imports Microsoft.Office.Interop



Public Class Report
    Private cls As New Class_SQKDB

    Dim xlApp As New Microsoft.Office.Interop.Excel.Application

    Public Shared Sub exportExcelfile(ByVal objValue As DataGridView, _
                                           ByVal objBGW As System.ComponentModel.BackgroundWorker)
        Try
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            ' elApp = CreateObject("Excel.Application")

            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            Dim strPath As String = "D:\Export\Excel\"
            xlApp = New Microsoft.Office.Interop.Excel.Application

            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("" + Date.Now.Date + "")

            For i = 0 To objValue.RowCount - 1
                objBGW.ReportProgress(CInt(100 * i / objValue.RowCount))

                For j = 0 To objValue.ColumnCount - 1
                    xlWorkSheet.Cells.NumberFormat = "@"
                    xlWorkSheet.Cells(i + 1, j + 1) = _
                        objValue(j, i).Value.ToString()
                Next
            Next

        Catch ex As Exception

        End Try

    End Sub


    Private Sub LoadingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadingToolStripMenuItem1.Click
        'Dim xlApp As Excel.Application
        LoadingBut.Visible = True
        UnloadBut.Visible = False
        TruckLoading.Visible = False
        TruckUnloading.Visible = False
        Label1.Text = "Loading Report To Excel"
    End Sub


    Private Sub UnloadingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnloadingToolStripMenuItem.Click
        UnloadBut.Visible = True
        LoadingBut.Visible = False
        TruckLoading.Visible = False
        TruckUnloading.Visible = False
        Label1.Text = "Unloading Report To Excel"
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadingBut.Click

        Dim xlApp As Object 'Excel.Application
        Dim ra As Object 'Excel.Range

        Dim q As String
        q = ""
        q = "select max(Addnotedate) as Addnotedate, "
        q &= " max(LOAD_VEHICLE) as Vehicle,"
        q &= " max(LOAD_DRIVER) as Driver,"
        q &= " max(Product_name) as Product,"
        q &= " max(LOAD_TANK) as Tank,"
        q &= " max(Customer_name) as Customer,"
        q &= " max(TANKFARM) as TANKFARM,"
        q &= " max(COA) as COA,"
        q &= " max(Batchlot) as Batchlot,"
        q &= " max(LC_SEAL) as Seal,"
        q &= " max(cast(Weightin_time as varchar(8))) as WeightinTime,"
        q &= " max(cast(Weightout_time as varchar(8))) as WeightOutTime,"
        q &= " max(Takentime) as TakenTime, "
        q &= " isnull(max(WeightIN),0) as WeightIN,"
        q &= " isnull(max(WeightOut),0) as WeightOut,"
        q &= " isnull(max(WeightTotal),0) as WeightTotal,"
        q &= " isnull(max(Density),0) as Density,"
        q &= " isnull(max(Weightcal),0) as Volume_Liters,"
        q &= " max(DO_NO) as Delivery_order_No,"
        q &= " max(DO_ITEM) as Delivery_order_Item,"
        q &= " max(SO_NO) as Sales_order_No,"
        q &= " max(SO_ITEM) as Sales_order_Item,"
        q &= " max(Remark) as Remark"
        q &= " FROM V_LOADINGNOTE "
        q &= " where Addnotedate between '" + String.Format("{0:yyyy-M-d}", printdate.Value) + "'" + ""
        q &= " and '" + String.Format("{0:yyyy-M-d}", Enddate.Value) + "'" + "  and load_status=3 "
        If CbProduct.Text <> "" Then q &= " and Product_name='" + CbProduct.Text + "'" + ""

        q &= " group by reference order by Product,Reference "


        Dim dt As DataTable = cls.Query(q)

        DBGrid1.DataSource = dt
        DataGridView1.DataSource = dt


        Dim Oexcel As New Microsoft.Office.Interop.Excel.Application
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As New Microsoft.Office.Interop.Excel.Worksheet


        wBook = Oexcel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        Oexcel.Cells(1, 7) = "Loaddate"
        Oexcel.Cells(1, 7).Font.Name = "Arial"
        Oexcel.Cells(1, 7).Font.FontStyle = "Regular"
        Oexcel.Cells(1, 7).Font.Size = 16

        For Each dc In dt.Columns
            colIndex = colIndex + 1


            Oexcel.Cells(2, colIndex) = dc.ColumnName

            Oexcel.Cells(2, colIndex).Font.Name = "Arial"
            Oexcel.Cells(2, colIndex).Font.FontStyle = "Bold" '"Regular"
            Oexcel.Cells(2, colIndex).Font.Size = 10
            Oexcel.Cells(2, colIndex).Interior.Color = RGB(0, 255, 0)
            Oexcel.Cells(2, colIndex).font.Color = RGB(0, 0, 0)
            Oexcel.Cells(2, colIndex).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            Oexcel.Cells(2, colIndex).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

            Select Case UCase(dc.ColumnName)
                Case UCase("Addnotedate")
                    Oexcel.Cells(2, colIndex).Value = "วันที่"
                Case UCase("Vehicle")
                    Oexcel.Cells(2, colIndex).Value = "ทะเบียนรถ"
                Case UCase("Driver")
                    Oexcel.Cells(2, colIndex).Value = "พนักงานขับรถ"
                Case UCase("Product")
                    Oexcel.Cells(2, colIndex).Value = "Product"
                Case UCase("Tank")
                    Oexcel.Cells(2, colIndex).Value = "Tank No."
                Case UCase("Customer")
                    Oexcel.Cells(2, colIndex).Value = "ลูกค้า"
                Case UCase("TANKFARM")
                    Oexcel.Cells(2, colIndex).Value = "คลัง"

                Case UCase("COA")
                    Oexcel.Cells(2, colIndex).Value = "COA.No"
                Case UCase("Batchlot")
                    Oexcel.Cells(2, colIndex).Value = "Batchlot"
                Case UCase("Seal")
                    Oexcel.Cells(2, colIndex).Value = "Seal No."

                Case UCase("WeightinTime")
                    Oexcel.Cells(2, colIndex).Value = "เวลาชั่งเข้า"
                Case UCase("WeightOutTime")
                    Oexcel.Cells(2, colIndex).Value = "เวลาชั่งออก"

                Case UCase("TakenTime")
                    Oexcel.Cells(2, colIndex).Value = "เวลาที่อยู่ในโรงงาน"
                Case UCase("WeightIN")
                    Oexcel.Cells(2, colIndex).Value = "น้ำหนักชั่งเข้า"
                Case UCase("WeightOut")
                    Oexcel.Cells(2, colIndex).Value = "น้ำหนักชั่งออก"

                Case UCase("WeightTotal")
                    Oexcel.Cells(2, colIndex).Value = "น้ำหนักโหลด (kg)"
                Case UCase("Density")
                    Oexcel.Cells(2, colIndex).Value = "Density"
                Case UCase("Volume_Liters")
                    Oexcel.Cells(2, colIndex).Value = "ปริมาตร (Liters)"
                Case UCase("Delivery_order_No")
                    Oexcel.Cells(2, colIndex).Value = "D/O No."
                Case UCase("Delivery_order_Item")
                    Oexcel.Cells(2, colIndex).Value = "D/O Item"
                Case UCase("Sales_order_No")
                    Oexcel.Cells(2, colIndex).Value = "S/O No."
                Case UCase("Sales_order_Item")
                    Oexcel.Cells(2, colIndex).Value = "S/O Item"
                Case Else
                    Oexcel.Cells(2, colIndex).Value = dc.ColumnName      '.Rows(i).Cells(colIndex).Value   
            End Select
        Next


        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                Oexcel.Cells(rowIndex + 2, colIndex) = dr(dc.ColumnName)

                Oexcel.Cells(rowIndex + 2, colIndex).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                Oexcel.Cells(rowIndex + 2, colIndex).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                Oexcel.Cells(rowIndex + 2, colIndex).Value = dr(dc.ColumnName)
                Oexcel.Cells(rowIndex + 2, colIndex).Font.Name = "Arial"
                Oexcel.Cells(rowIndex + 2, colIndex).Font.FontStyle = "Regular"
                Oexcel.Cells(rowIndex + 2, colIndex).Font.Size = 10

                Oexcel.Cells(rowIndex + 2, 1).NumberFormat = "dd-MM-yyyy"
                Oexcel.Cells(rowIndex + 2, 7).NumberFormat = "@"
                Oexcel.Cells(rowIndex + 2, 8).NumberFormat = "@"
                Oexcel.Cells(rowIndex + 2, 9).NumberFormat = "@"
                Oexcel.Cells(rowIndex + 2, 14).NumberFormat = "#,##0"
                Oexcel.Cells(rowIndex + 2, 15).NumberFormat = "#,##0"
                Oexcel.Cells(rowIndex + 2, 16).NumberFormat = "#,##0.00"
                Oexcel.Cells(rowIndex + 2, 17).NumberFormat = "#,##0.0000"
                Oexcel.Cells(rowIndex + 2, 18).NumberFormat = "#,##0"
                If Oexcel.Cells(rowIndex + 2, 17).Value <> "0" Then

                Else

                    Oexcel.Cells(rowIndex + 2, 17).Value = ""
                End If

            Next
        Next

        wSheet.Columns.AutoFit()
        Oexcel.Cells(1, 7) = "Loading Date  " + String.Format("{0:dd/MM/yyyy}", printdate.Value) + "-" + String.Format("{0:dd/MM/yyyy}", Enddate.Value)
        Oexcel.Cells(1, 7).Font.Name = "Arial"
        Oexcel.Cells(1, 7).Font.FontStyle = "Regular"
        Oexcel.Cells(1, 7).Font.Size = 16

        Dim tolist(1) As Integer
        tolist(0) = 16
        tolist(1) = 18
        With Oexcel.ActiveSheet.UsedRange
            .Subtotal(GroupBy:=4, Function:=-4157, TotalList:=tolist)
        End With


        Oexcel.Rows(3).EntireRow.Delete()
        For j As Integer = 1 To DataGridView1.RowCount + 300
            If Trim(Oexcel.Cells(j, 2).Value) = "" And Trim(Oexcel.Cells(j, 16).Value) <> "" Then
                Oexcel.Cells(j, 16).Font.Name = "Arial"
                Oexcel.Cells(j, 16).Font.Bold = True
                Oexcel.Cells(j, 16).Font.Underline = True
                Oexcel.Cells(j, 16).Font.Size = 10
                Oexcel.Cells(j, 16).Font.Color = RGB(0, 0, 255)

                Oexcel.Cells(j, 18).Font.Bold = True
                Oexcel.Cells(j, 18).Font.Underline = True
                Oexcel.Cells(j, 18).Font.Size = 10

                Oexcel.Cells(j, 18).Font.Color = RGB(0, 0, 255)

                Oexcel.Cells(j, 4).Font.Bold = True
                Oexcel.Cells(j, 4).Font.Underline = True
                Oexcel.Cells(j, 4).Font.Size = 10
                Oexcel.Cells(j, 4).Font.Color = RGB(0, 0, 255)
                For K As Integer = 1 To DataGridView1.ColumnCount
                    Oexcel.Cells(j, K).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    Oexcel.Cells(j, K).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                Next

            End If

        Next

        Dim strFileName As String = "D:\ss.xls"
        Dim blnFileOpen As Boolean = False

        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try


        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If

        wBook.SaveAs(strFileName)
        Oexcel.Workbooks.Open(strFileName)
        Oexcel.Visible = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnloadBut.Click

        Dim xlApp As Object 'Excel.Application
        Dim ra As Object 'Excel.Range
        On Error Resume Next
        xlApp = GetObject(, "Excel.Application")
        If Err.Number <> 0 Then
            xlApp = New Microsoft.Office.Interop.Excel.Application
            xlApp = CreateObject("Excel.Application")
        End If
        xlApp.Visible = True
        xlApp.Workbooks.Add()
        ra = xlApp.ActiveCell


        Dim q As String
        q = ""
        q = "select max(Addnotedate) as Addnotedate, "
        q &= " max(LOAD_VEHICLE) as Vehicle,"
        q &= " max(LOAD_DRIVER) as Driver,"
        q &= " max(PO_NO) as PONo,"
        q &= " max(Product_name) as Product,"
        q &= " max(Customer_name) as Vender,"
        q &= " max(LOAD_DOfull) as DONo,"
        q &= " max(Invoice) as Invoice,"
        q &= " max(cast(Weightin_time as varchar(8))) as WeightinTime,"
        q &= " max(cast(Weightout_time as varchar(8))) as WeightOutTime,"
        q &= " max(Takentime) as TakenTime,"
        q &= " max(WeightIN) as WeightIN,"
        q &= " max(WeightOut) as WeightOut,"
        q &= " max(WeightTotal) as WeightTotal,"
        q &= " max(Load_preset) as DoPreset,"
        q &= " max(Load_preset)-max(WeightTotal) as WeightDIFF,"
        q &= " ((max(Load_preset)-max(WeightTotal))*100) / max(Load_preset) as PERCENTDIFF,"
        q &= " max(LOCATION_CODE) as Tank"

        q &= " FROM V_UnLOADINGNOTE "
        q &= " where Addnotedate between '" + String.Format("{0:yyyy-M-d}", printdate.Value) + "'" + ""
        q &= " and '" + String.Format("{0:yyyy-M-d}", Enddate.Value) + "'" + " and load_status=3 "
        If CbProduct.Text <> "" Then q &= "   and Product_name='" + CbProduct.Text + "'" + ""

        q &= " group by reference order by Addnotedate desc,Reference "

        Dim dt1 As DataTable = cls.Query(q)

        DBGrid1.DataSource = dt1
        DataGridView1.DataSource = dt1

        With DataGridView1
            ra.offset(0, 7).value = "Unloading Date :" + String.Format("{0:dd/MM/yyyy}", printdate.Value) + "-" + String.Format("{0:dd/MM/yyyy}", Enddate.Value)
            ra.Offset(0, 7).Font.Name = "Arial"
            ra.Offset(0, 7).Font.FontStyle = "Regular"
            ra.Offset(0, 7).Font.Size = 16


            For j As Integer = 0 To .ColumnCount - 1
                ra.Offset(1, j).Font.Name = "Arial"
                ra.Offset(1, j).Font.FontStyle = "Bold" '"Regular"
                ra.Offset(1, j).Font.Size = 10
                ra.Offset(1, j).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                ra.Offset(1, j).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                Select Case UCase(.Columns(j).HeaderText)
                    Case UCase("Addnotedate")
                        ra.Offset(1, j).Value = "วันที่"
                    Case UCase("Vehicle")
                        ra.Offset(1, j).Value = "เลขทะเบียนรถ"
                    Case UCase("Driver")
                        ra.Offset(1, j).Value = "ชื่อคนขับ"
                    Case UCase("PONo")
                        ra.Offset(1, j).Value = "เลขที่ใบสั่งซื้อ"
                    Case UCase("Product")
                        ra.Offset(1, j).Value = "ชื่อผลิตภัณฑ์"
                    Case UCase("Vender")
                        ra.Offset(1, j).Value = "Vendor name"
                    Case UCase("DONo")
                        ra.Offset(1, j).Value = "เลขที่ D/O"
                    Case UCase("Invoice")
                        ra.Offset(1, j).Value = "เลขที่ Invoice"
                    Case UCase("WeightinTime")
                        ra.Offset(1, j).Value = "เวลาชั่งเข้า"
                    Case UCase("WeightIN")
                        ra.Offset(1, j).Value = "น้ำหนักชั่งเข้า"
                    Case UCase("WeightOutTime")
                        ra.Offset(1, j).Value = "เวลาชั่งออก"
                    Case UCase("WeightOut")
                        ra.Offset(1, j).Value = "น้ำหนักชั่งออก"
                    Case UCase("WeightTotal")
                        ra.Offset(1, j).Value = "น้ำหนักเข้า-ออก"
                    Case UCase("DoPreset")
                        ra.Offset(1, j).Value = "น้ำหนักตามDO"

                    Case UCase("WeightDIFF")
                        ra.Offset(1, j).Value = "น้ำหนักแตกต่าง"
                    Case UCase("PERCENTDIFF")
                        ra.Offset(1, j).Value = "% ความแตกต่าง"

                    Case UCase("TakenTime")
                        ra.Offset(1, j).Value = "เวลาที่อยู่ในโรงงาน"

                    Case UCase("Tank")
                        ra.Offset(1, j).Value = "Tank"
                    Case Else
                        ra.Offset(1, j).Value = .Columns(j).HeaderText      '.Rows(i).Cells(j).Value   
                End Select

                ra.Offset(1, j).Interior.Color = RGB(0, 255, 0)
                ra.Offset(1, j).font.Color = RGB(0, 0, 0)
                ra.Offset(1, j).HorizontalAlignment = Excel.Constants.xlCenter

            Next

            For i As Integer = 0 To .RowCount - 2
                For j As Integer = 0 To .ColumnCount - 1
                    ra.Offset(i + 2, j).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    ra.Offset(i + 2, j).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    ra.Offset(i + 2, j).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
                    ra.Offset(i + 2, j).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous
                    ra.Offset(i + 2, j).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    ra.Offset(i + 2, j).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous

                    ra.Offset(i + 2, j).Value = .Rows(i).Cells(j).Value
                    ra.Offset(i + 2, j).Font.Name = "Arial"
                    ra.Offset(i + 2, j).Font.FontStyle = "Regular"
                    ra.Offset(i + 2, j).Font.Size = 10

                    ra.Offset(i + 2, 0).NumberFormat = "dd-MM-eeee"
                    ra.Offset(i + 2, 3).NumberFormat = "@"
                    ra.Offset(i + 2, 6).NumberFormat = "@"
                    ra.Offset(i + 2, 7).NumberFormat = "@"
                    ra.Offset(i + 2, 9).NumberFormat = "@"
                    ra.Offset(i + 2, 10).NumberFormat = "hh:mm:ss"
                    ra.Offset(i + 2, 11).NumberFormat = "#,##0"
                    ra.Offset(i + 2, 12).NumberFormat = "#,##0"
                    ra.Offset(i + 2, 13).NumberFormat = "#,##0.00"
                    ra.Offset(i + 2, 14).NumberFormat = "#,##0"
                    ra.Offset(i + 2, 15).NumberFormat = "#,##0"
                    ra.Offset(i + 2, 16).NumberFormat = "#,##0.00"
                Next
            Next
            With xlApp
                .Columns(0).AutoFit()
                .Columns(1).AutoFit()
                .Columns(2).AutoFit()
                .Columns(3).AutoFit()
                .Columns(4).AutoFit()
                .Columns(5).AutoFit()
                .Columns(6).AutoFit()
                .Columns(7).AutoFit()
                .Columns(8).AutoFit()
                .Columns(9).AutoFit()
                .Columns(10).AutoFit()
                .Columns(11).AutoFit()
                .Columns(12).AutoFit()
                .Columns(13).AutoFit()
                .Columns(14).AutoFit()
                .Columns(15).AutoFit()
                .Columns(16).AutoFit()
                .Columns(17).AutoFit()
                .Columns(18).AutoFit()
                .Columns(19).AutoFit()
                .Visible = True
            End With
        End With


        With xlApp.ActiveSheet.UsedRange
            .Subtotal(GroupBy:=5, Function:=-4157, TotalList:=14)
        End With

        ra.Rows(3).EntireRow.Delete()
        For j As Integer = 0 To DataGridView1.RowCount + 300
            If Trim(ra.Offset(j, 1).Value) = "" And Trim(ra.Offset(j, 13).Value) <> "" Then
                ra.Offset(j, 13).Font.Bold = True
                ra.Offset(j, 13).Font.Underline = True
                ra.Offset(j, 13).Font.Size = 10
                ra.Offset(j, 13).Font.Color = RGB(0, 0, 255)
                ra.Offset(j, 4).Font.Bold = True
                ra.Offset(j, 4).Font.Underline = True
                ra.Offset(j, 4).Font.Size = 10
                ra.Offset(j, 4).Font.Color = RGB(0, 0, 255)

                For K As Integer = 0 To DataGridView1.ColumnCount - 1
                    ra.Offset(j, K).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                    ra.Offset(j, K).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                    ra.Offset(j, K).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous
                    ra.Offset(j, K).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous
                    ra.Offset(j, K).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                    ra.Offset(j, K).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                Next

            End If

        Next
    End Sub

    Private Sub Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'IRPCDataset.T_PRODUCT' table. You can move, or remove it, as needed.
        Me.T_PRODUCTTableAdapter.Fill(Me.IRPCDataset.T_PRODUCT)
        'TODO: This line of code loads data into the 'FPTDataSet.T_Product' table. You can move, or remove it, as needed.
        With DBGrid1
            .ReadOnly = True
            .MultiSelect = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        printdate.Value = String.Format("{0:yyyy-M-d 00:00:00}", Now)
        Enddate.Value = String.Format("{0:yyyy-M-d 23:59:59}", Now)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim q As String
        q = ""
        q = "select max(Addnotedate) as Addnotedate, "
        q &= " max(LOAD_VEHICLE) as VEHICLE,"
        q &= " max(LOAD_DRIVER) as DRIVER,"
        q &= " max(Product_name) as Product,"
        q &= " max(LOAD_TANK) as TANK,"
        q &= " max(Customer_name) as Customer,"
        q &= " max(COA) as COA,"
        q &= " max(LC_SEAL) as SEAL,"
        q &= " max(cast(Weightin_time as varchar(20))) as WeightinTime,"
        q &= " max(WeightIN) as WeightIN,"
        q &= " max(WeightOut_time) as WeightOutTime,"
        q &= " max(WeightOut) as WeightOut,"
        q &= " max(WeightTotal) as WeightTotal,"
        q &= " max(Density) as Density,"
        q &= " max(Takentime) as TakenTime "
        q &= " FROM V_LOADINGNOTE "
        q &= " where Addnotedate='" + String.Format("{0:yyyy-MM-dd}", printdate.Value) + "'" + ""
        q &= " group by reference order by Addnotedate desc,Reference "

        Dim dt1 As DataTable = cls.Query(q)

        DBGrid1.DataSource = dt1
        DataGridView1.DataSource = dt1


        DataGridView1.SelectAll()
        Clipboard.SetText( _
          DataGridView1.GetClipboardContent().GetText, _
          TextDataFormat.Text)
        DataGridView1.ClearSelection()

        Dim xlapp As Object
        On Error Resume Next
        xlapp = GetObject(, "Excel.Application")
        If Err.Number <> 0 Then
            xlapp = CreateObject("Excel.Application")
        End If
        xlapp.Visible = True
        xlapp.ScreenUpdating = False
        With xlapp.Workbooks.Add
            With .ActiveSheet
                .Paste()
                .Columns.Autofit()
                .Rows(1).Font.Bold = True
                .Range("A2").Select()
            End With
        End With
        xlapp.CutCopyMode = False
        xlapp.ScreenUpdating = True

    End Sub


    Private Sub Report_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        LoadingBut.Visible = False
        UnloadBut.Visible = False
        TruckLoading.Visible = False
        TruckUnloading.Visible = False
        Label1.Text = "Report Print"
        CbProduct.SelectedIndex = -1

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TruckLoading.Click

        Dim ref As String
        ref = 12751

        Dim Myreport As New ReportDocument
        Myreport = New ReportDocument
        Dim sql As String
        sql = "Select  * from V_Truckloadingreport "
        sql &= " where loaddate='" + String.Format("{0:yyyy-M-d}", printdate.Value) + "'" + ""
        sql &= " order by load_id desc "

        Dim ds As New DataSet()
        ds = cls.Query_DS(sql, "V_Truckloadingreport")

        If ds.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("ไม่มีข้อมูล", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Myreport.Load("Truckloadingreport.rpt")
            Myreport.SetDataSource(ds.Tables("V_Truckloadingreport"))
            ReportPrint.CrystalReportViewer1.ReportSource = Myreport
            ReportPrint.Show()
        End If

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TruckUnloading.Click

        Dim Myreport As New ReportDocument
        Myreport = New ReportDocument
        Dim sql As String
        sql = "Select  * from V_Truckunloadingreport "
        sql &= " where loaddate='" + String.Format("{0:yyyy-M-d}", printdate.Value) + "'" + ""
        sql &= " order by load_id desc "

        Dim ds As New DataSet()
        ds = cls.Query_DS(sql, "V_Truckloadingreport")

        If ds.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("No Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Myreport.Load("Truckunloadingreport.rpt")
            Myreport.SetDataSource(ds.Tables("V_TruckUnloadingreport"))
            ReportPrint.CrystalReportViewer1.ReportSource = Myreport
            ReportPrint.Show()
        End If
    End Sub

    Private Sub TruckLoadingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TruckLoadingReportToolStripMenuItem.Click
        LoadingBut.Visible = False
        UnloadBut.Visible = False
        TruckLoading.Visible = True
        TruckUnloading.Visible = False
        Label1.Text = "Truck Loading Report"
    End Sub

    Private Sub TruckUnloadingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TruckUnloadingReportToolStripMenuItem.Click
        LoadingBut.Visible = False
        UnloadBut.Visible = False
        TruckLoading.Visible = False
        TruckUnloading.Visible = True
        Label1.Text = "Truck Unloading Report"
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub SAPReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAPReportToolStripMenuItem.Click
        BTSAPReport.BringToFront()
        Label1.Text = "SAP Report"
    End Sub

    Private Sub BTSAPReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTSAPReport.Click

        Dim Myreport As New ReportDocument
        Myreport = New ReportDocument
        Dim sql As String
        sql = "Select  * from V_SAPReport "
        sql &= " where do_no is not null and  do_no<>'' and (CAST( convert(varchar(10),Weightin_Date,21)+' ' +convert(varchar(10),Weightin_time,120) as Datetime)) between  '" + String.Format("{0:yyyy-M-d HH:mm:00}", printdate.Value) + "'" + " and '" +
        String.Format("{0:yyyy-M-d HH:mm:59}", Enddate.Value) + "'" + ""
        If CbProduct.Text <> "" Then sql &= " and Product_name='" + CbProduct.Text + "'" + ""
        sql &= " order by Ship_NO,do_no  "

        Dim ds As New DataSet()
        ds = cls.Query_DS(sql, "V_SAPReport")

        If ds.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("No Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            ds.Tables("V_SAPReport").TableName = "V_LOADINGNOTE"
            Myreport.Load("DoReport.rpt")
            Myreport.SetDataSource(ds.Tables("V_LOADINGNOTE"))
            ReportPrint.CrystalReportViewer1.ReportSource = Myreport
            ReportPrint.Show()
        End If
        ds.Dispose()
    End Sub

    Private Sub SCAPReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SCAPReportToolStripMenuItem.Click
        BtScapPrint.BringToFront()
        Label1.Text = "Scap Report"
    End Sub

    Private Sub Report_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'IRPCDataset.V_LOADINGNOTE' table. You can move, or remove it, as needed.
        Me.V_LOADINGNOTETableAdapter1.Fill(Me.IRPCDataset.V_LOADINGNOTE)

    End Sub

    Private Sub BtScapPrint_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtScapPrint.Click

        Dim Myreport As New ReportDocument
        Myreport = New ReportDocument
        Dim sql As String
        sql = "Select  * from V_SAPReport "
        sql &= " where (do_no is  null or  do_no='') and (CAST( convert(varchar(10),Weightin_Date,21)+' ' +convert(varchar(10),Weightin_time,120) as Datetime)) between  '" + String.Format("{0:yyyy-M-d HH:mm:00}", printdate.Value) + "'" + " and '" +
        String.Format("{0:yyyy-M-d HH:mm:59}", Enddate.Value) + "'" + ""
        If CbProduct.Text <> "" Then sql &= " and Product_name='" + CbProduct.Text + "'" + ""
        sql &= " order by do_no  "

        Dim ds As New DataSet()
        ds = cls.Query_DS(sql, "V_LOADINGNOTE")

        If ds.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("No Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            Myreport.Load("ScapReport.rpt")
            Myreport.SetDataSource(ds.Tables("V_LOADINGNOTE"))
            ReportPrint.CrystalReportViewer1.ReportSource = Myreport
            ReportPrint.Show()
        End If
        ds.Dispose()
    End Sub
End Class