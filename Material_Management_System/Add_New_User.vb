Imports System.Data.SqlClient
Public Class User_Master
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim cm As SqlCommand
    Dim ds As DataSet
    Dim sql As String
    Dim cur, max As Integer

    Private Sub User_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        cm = New SqlCommand
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        cm.Connection = cn
        Refresh_data()
        
    End Sub
    Public Sub Refresh_data()

        da = New SqlDataAdapter("select * from User_Master", cn)

        ds.Clear()
        da.Fill(ds)

        Cur = 0
        Max = ds.Tables(0).Rows.Count
        Max = Max - 1

        Call Getdata()

    End Sub
    Public Sub Getdata()
        txtusername.Text = ds.Tables(0).Rows(cur).Item(0)
        cmbutype.Text = ds.Tables(0).Rows(cur).Item(1)
        txtpassword.Text = ds.Tables(0).Rows(cur).Item(2)
    End Sub
    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click
        Cur = 0
        Call Getdata()
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        If Cur < Max Then
            Cur = Cur + 1
            Call Getdata()
        Else
            MsgBox("End of records")
        End If
    End Sub

    Private Sub cmdPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrev.Click
        If Cur > 0 Then
            Cur = Cur - 1
            Call Getdata()
        Else
            MsgBox("Beginning of records")
        End If
    End Sub

    Private Sub cmdLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLast.Click
        Cur = Max
        Call Getdata()
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        txtusername.Text = ""
        cmbutype.Text = ""
        txtpassword.Text = ""

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        sql = "insert into User_Master values('" & txtusername.Text & "' ,'" & cmbutype.Text & "','" & txtpassword.Text & "')"

        cm.CommandText = Sql
        'cm.CommandType = CommandType.Text

        cm.ExecuteNonQuery()
        MsgBox("Record inserted")
        Call Refresh_data()
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        sql = "delete from User_Master where User_Name = " & val(txtusername.Text)

        cm.CommandText = sql
        cm.CommandType = CommandType.Text

        cm.ExecuteNonQuery()
        MsgBox("record deleted")
        Call Refresh_data()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        sql = "update User_Master set User_Type ='" & cmbutype.Text & "',Password ='" & txtpassword.Text & "'where User_Name ='" & txtusername.Text

        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("UPdated")
        Call Refresh_data()
    End Sub
End Class