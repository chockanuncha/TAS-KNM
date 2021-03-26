Public Class Class_Permission

#Region "Declare Propertie"

    Private _ChkAdd As Boolean
    Public Property ChkAdd() As String
        Get
            Return _ChkAdd
        End Get
        Private Set
            _ChkAdd = Value
        End Set
    End Property

    Private _ChkEdit As Boolean
    Public Property ChkEdit() As String
        Get
            Return _ChkEdit
        End Get
        Private Set
            _ChkEdit = Value
        End Set
    End Property

    Private _ChkDel As Boolean
    Public Property ChkDel() As String
        Get
            Return _ChkDel
        End Get
        Private Set
            _ChkDel = Value
        End Set
    End Property

    Private _ChkPrint As Boolean
    Public Property ChkPrint() As String
        Get
            Return _ChkPrint
        End Get
        Private Set
            _ChkPrint = Value
        End Set
    End Property

    Private _ChkView As Boolean
    Public Property ChkView() As String
        Get
            Return _ChkView
        End Get
        Private Set
            _ChkView = Value
        End Set
    End Property
#End Region

    Public Function Check_Permission(ByVal User_Groups As String, ByVal Page_Group As String) As Boolean
        Dim cls As New Class_SQLSERVERDB
        Dim dt As DataTable

        Dim retval As Boolean = False
        dt = cls.Query("SELECT * FROM V_MAP_ROLE WHERE G_NAME='" & User_Groups & "' AND R_NAME='" & Page_Group & "'")
        If dt.Rows.Count > 0 Then
            retval = True
        Else
            retval = False
        End If
        Return retval
    End Function

    Public Sub Chk_Permission(ByVal u_group As Integer, ByVal p_num As Integer)
        Dim cls As New Class_SQLSERVERDB

        'Dim dt As DataTable = cls.Query("SELECT * FROM V_UGRP_ROLE WHERE G_ID=" & u_group & " AND MENUID=" & p_num)

        Dim dt As DataTable = cls.Query("SELECT * FROM V_UGRP_ROLE WHERE G_ID=" & u_group & "")
        'And MENUID=" & p_num)

        ChkAdd = ChkEdit = ChkDel = ChkPrint = ChkView = False
        For Each dr As DataRow In dt.Rows
            If CBool(dr("CHKADD")) = True Then ChkAdd = True
            If CBool(dr("CHKEDIT")) = True Then ChkEdit = True
            If CBool(dr("CHKDEL")) = True Then ChkDel = True
            If CBool(dr("CHKPRINT")) = True Then ChkPrint = True
            If CBool(dr("CHKVIEW")) = True Then ChkView = True
        Next
    End Sub
End Class
