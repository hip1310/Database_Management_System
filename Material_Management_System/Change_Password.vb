Imports System.Data.SqlClient

Public Class Change_Password
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim dr As SqlDataReader
    Dim ds As DataSet
    Dim cm As SqlCommand
    Dim Cur, Max As Integer
    Dim sql As String
    Dim val1 As String

    Private Sub Change_Password_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New DataSet
        cm = New SqlCommand
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        cm.Connection = cn

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Dim count As Integer
        sql = "select count(User_Name) from User_Master where User_Name='" & txtuname.Text & "'"

        cm.Connection = cn
        cm.CommandText = sql

        dr = cm.ExecuteReader

        Do While dr.Read()
            count = dr.Item(0)
        Loop
        cn.Close()


        If (count = 0) Then
            MsgBox("User Name doesn't exist!")
            txtuname.Focus()
        End If

        cn.Open()
        Dim pass As String
        sql = "select Password from User_Master where User_Name='" & txtuname.Text & "'"

        cm.Connection = cn
        cm.CommandText = sql

        dr = cm.ExecuteReader

        Do While dr.Read()
            pass = dr.Item(0)
        Loop
        cn.Close()

        cn.Open()
        If (txtopass.Text = pass) Then
            If (txtnpass.Text = txtcpass.Text) Then
                sql = "update User_Master set Password='" & txtnpass.Text & "' where User_Name = '" & txtuname.Text & "'"

                cm.CommandText = sql
                cm.ExecuteNonQuery()

                MsgBox("Password Changed Successfully!")
            Else
                MsgBox("Password doesn't match!")
                txtcpass.Focus()
            End If
        End If

    End Sub
End Class