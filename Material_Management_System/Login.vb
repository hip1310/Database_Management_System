Imports System.Data.SqlClient
Public Class Login
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet
    Dim SQL As String

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds = New Data.DataSet

        cn = New SqlConnection

        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()
        da = New SqlDataAdapter("select * from User_Master", cn)
       
    End Sub

    Private Sub btnok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnok.Click
        SQL = "select * from User_Master where User_Name = '" & txtusername.Text & "' and Password = '" & txtpassword.Text & "'"
        da.SelectCommand.CommandText = SQL

        da.Fill(ds)

        If ds.Tables(0).Rows.Count <> 0 Then
            If (ds.Tables(0).Rows(0).Item(1) = "Admin") Then
                Module1.uname = txtusername.Text
                MsgBox("Login Successful!")
                Material_Management_System.Show()

                Me.Visible = False
            Else
                Module1.uname = txtusername.Text
                MsgBox("Login Successful!")

                Material_Management_System.TransactionToolStripMenuItem.Visible = False
                Material_Management_System.MasterToolStripMenuItem.Visible = False
                Material_Management_System.AddNewUserToolStripMenuItem.Visible = False
                Material_Management_System.Show()
                Me.Visible = False
            End If

        Else
            MsgBox(" UnSuccessfull Login ")
        End If
    End Sub

    Private Sub btncancle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancle.Click
        txtusername.Text = ""
        txtpassword.Text = ""
    End Sub
End Class