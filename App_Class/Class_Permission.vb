Public Class Class_Permission
    Public Function Check_Permission(ByVal User_Groups As String, ByVal Page_Group As String) As Boolean
        Dim cls As New Class_SQKDB
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
End Class
