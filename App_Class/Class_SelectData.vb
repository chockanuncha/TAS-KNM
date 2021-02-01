Public Class Class_SelectData

    Public Function SelectPrintLoadingNote(ByVal ref As String)
        Dim q As String
        q = ""
        q = "SELECT    T1.LOAD_CAPACITY as LOAD_CAPACITY"
        q &= " , T1.LOAD_PRESET as LOAD_PRESET,T2.lc_preset,  T1.LOAD_CARD as LOAD_CARD"
        q &= " , T2.LC_COMPARTMENT as LC_COMPARTMENT"
        q &= " , T2.LC_BAY as LC_BAY,CAST(T1.Reference AS VARCHAR(30)) AS Reference,  T1.LOAD_DATE as LOAD_DATE,T1.Load_qdashboard as LOAD_Q"
        q &= " , T1.LOAD_DID as LOAD_DID , T_Status.STATUS_NAME as STATUS_NAME , T1.LOADDO as LOAD_DOfull , t_customer.Customer_name as LOAD_CUSTOMER "
        q &= " , COALESCE(t1.Container, (t1.Container  + '/' +   T_TRUCK.TRUCK_NUMBER), T_TRUCK.TRUCK_NUMBER ) AS Load_Vehiclexx "
        q &= " , CASE t1.Container	WHEN NULL THEN T_TRUCK.TRUCK_NUMBER WHEN '' THEN T_TRUCK.TRUCK_NUMBER ELSE t1.Container  + '/ ' +T_TRUCK.TRUCK_NUMBER END AS Load_Vehicle "
        q &= " , T_DRIVER.Driver_NAME + ' ' +  T_Driver.Driver_Lastname AS LOAD_DRIVER"
        q &= " , T1.load_id as Load_id "
        q &= " , T_customer.Customer_Name,t_product.Product_code  as PRODUCT_CODE, T_Batchmeter.BATCH_NAME as BATCH_NAME"
        q &= " , T1.Container as Container, T1.LOAD_TRUCKCOMPANY as LOAD_TRUCKCOMPANY"
        q &= " , LC_SEAL as LC_SEAL, T1.LOAD_SEAL as LOAD_SEAL, T1.LOAD_SEALCOUNT  as LOAD_SEALCOUNT"
        q &= " , T1.ADDNOTEDATE  as ADDNOTEDATE, T2.LC_STARTTIME  as LC_STARTTIME, T2.LC_ENDTIME  as LC_ENDTIME "
        q &= " FROM T_Customer  RIGHT OUTER JOIN (Select * from T_LOADINGNOTE  Where Reference  ='" & ref & "' )  T1 "
        q &= " ON T_Customer.ID = T1.LOAD_CUSTOMER  "
        q &= " LEFT OUTER JOIN T_STATUS  ON T1.LOAD_STATUS = T_STATUS.STATUS_ID   "
        'q &= "LEFT OUTER JOIN V_DO ON T1.LOAD_ID = V_DO.LOAD_ID    "
        q &= "LEFT OUTER JOIN T_TRUCK ON T1.LOAD_VEHICLE = T_TRUCK.ID   "
        q &= "LEFT OUTER JOIN T_DRIVER ON T1.LOAD_DRIVER = T_DRIVER.ID   "
        q &= "LEFT OUTER JOIN T_CARD  ON T1.LOAD_CARD = T_CARD.CARD_NUMBER   "
        q &= "Left OUTER JOIN T_BATCHMETER   "
        q &= "RIGHT OUTER JOIN (Select * From T_LOADINGNOTECOMPARTMENT where lc_status<>'99') T2 "
        q &= "ON T_BATCHMETER.BATCH_NUMBER = T2.LC_METER   "
        q &= "LEFT OUTER JOIN T_Product ON T2.LC_PRO = T_Product.ID ON T1.LOAD_ID = T2.LC_LOAD "
        q &= "Order by T2.lc_compartment"


        Return q
    End Function

    Public Function SelectPrintUnloadingNote(ByVal ref As String)
        Dim q As String
        q = "SELECT * FROM T_UNLOADINGNOTE WHERE REFERENCE='" & ref & "'"
        Return q
    End Function

End Class
