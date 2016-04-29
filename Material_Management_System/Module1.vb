Imports System.Data.SqlClient
Module Module1
    Public uname As String
    Public utype As String
    Public password As String
    Public val As String
    Dim conStr As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"


    Public Sub Get_Info(ByVal tname As String, ByVal fname1 As String, ByVal fname2 As String, ByVal fid As String)

        Dim cn As New SqlConnection(conStr)
        Dim adp As New SqlDataAdapter
        Dim mds As New DataSet
        Dim sql As String
        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand

        sql = "select " & fname2 & " from " & tname & " where " & fname1 & " = '" & fid & "'"
        cmd.Connection = cn
        cmd.CommandText = sql
        cn.Open()
        dr = cmd.ExecuteReader

        Do While dr.Read()
            val = Convert.ToString(dr.Item(0))
        Loop
        cn.Close()

    End Sub
    Public Sub Get_CharInfo(ByVal tname As String, ByVal fname1 As String, ByVal fname2 As String, ByVal fid As String, ByRef txt As TextBox)
        Dim cn As New SqlConnection(conStr)
        Dim adp As New SqlDataAdapter
        Dim mds As New DataSet
        Dim sql As String
        sql = "select " & fname2 & " from " & tname & " where " & fname1 & " = '" & fid & "'"
        adp = New SqlDataAdapter(sql, cn)
        mds = New DataSet
        adp.Fill(mds)
        txt.Text = mds.Tables(0).Rows(0).Item(0)
    End Sub
    Public Sub Fill_Combo(ByVal tname As String, ByVal fname As String, ByVal cmb As ComboBox)
        Dim mds As New DataSet
        Dim cn As New SqlConnection(conStr)
        Dim adp As New SqlDataAdapter
        Dim sql As String
        sql = "select " & fname & " from " & tname
        adp = New SqlDataAdapter(sql, cn)
        mds = New DataSet
        adp.Fill(mds)
        Dim i As Integer
        For i = 0 To mds.Tables(0).Rows.Count - 1
            cmb.Items.Add(mds.Tables(0).Rows(i).Item(0))
        Next
    End Sub
End Module
