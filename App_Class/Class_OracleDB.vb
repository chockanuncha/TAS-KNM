Imports System.Data.SqlClient


Public Class Class_SQKDB
    'Create Connection
    Private con As SqlConnection = New SqlConnection()
    'Create Connection String Using Builder
    Private ocsb As SqlConnectionStringBuilder = New SqlConnectionStringBuilder

    Private Sub Connect()
        Try
            con.Close()
        Catch ex As Exception

        End Try

        con.ConnectionString = My.Settings.ConnectionString

        Try
            con.Open()
        Catch ex As Exception
            con.Close()
            con.Open()
        End Try

    End Sub

    Public Function Query(ByVal SQL_Command As String) As DataTable
        'Connect DB
        Connect()
        'Query command
        Dim cmd As New SqlCommand(SQL_Command, con)
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        Dim dt_inclass As New DataTable
        'dr.Read()
        dt_inclass.Load(dr)
        con.Close()
        Return dt_inclass
    End Function
    Public Function Query_DS(ByVal SQL_Command As String, ByVal DS_Name As String) As DataSet
        'Connect DB
        Connect()
        'Query command
        Dim cmd As New SqlCommand(SQL_Command, con)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds_inclass As New DataSet

        da.Fill(ds_inclass, DS_Name)

        con.Close()
        Return ds_inclass
    End Function

    Public Sub Query_DA(ByVal SQL_Command As String, ByRef MyDataSet As DataSet, ByVal DS_Name As String)
        'Connect DB
        Connect()
        'Query command
        Dim cmd As New SqlCommand(SQL_Command, con)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)

        da.Fill(MyDataSet, DS_Name)
    End Sub

    Public Sub Insert(ByVal str As String)
        'Connect DB
        Connect()
        'Query command
        Dim cmd As New SqlCommand(str, con)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Public Sub Update(ByVal str As String)
        'Connect DB
        Connect()
        'Query command
        Dim cmd As New SqlCommand(str, con)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Public Sub Delete(ByVal str As String)
        'Connect DB
        Connect()
        'Query command
        Dim cmd As New SqlCommand(str, con)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class
