Imports System.Data.SqlClient

Public Class Supplier_Master
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cm As SqlCommand
    Dim Cur, Max As Integer
    Dim sql As String

    Private Sub Supplier_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet2.Supplier_Master' table. You can move, or remove it, as needed.
        Me.Supplier_MasterTableAdapter.Fill(Me.Database1DataSet2.Supplier_Master)
        ds = New DataSet
        cm = New SqlCommand
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        cm.Connection = cn

        Refresh_data()
    End Sub
    Public Sub Refresh_data()

        da = New SqlDataAdapter("select * from Supplier_Master", cn)

        ds.Clear()
        da.Fill(ds)

        Cur = 0
        Max = ds.Tables(0).Rows.Count
        Max = Max - 1

        Call Getdata()

    End Sub
    Public Sub Getdata()
        txtsupid.Text = ds.Tables(0).Rows(Cur).Item(0)
        txtname.Text = ds.Tables(0).Rows(Cur).Item(1)
        txtaddress.Text = ds.Tables(0).Rows(Cur).Item(2)
        txtcity.Text = ds.Tables(0).Rows(Cur).Item(3)
        txtpin.Text = ds.Tables(0).Rows(Cur).Item(4)
        txtphoneno.Text = ds.Tables(0).Rows(Cur).Item(5)
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
        txtsupid.Text = ""
        txtname.Text = ""
        txtaddress.Text = ""
        txtcity.Text = ""
        txtpin.Text = ""
        txtphoneno.Text = ""
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        sql = "delete from Supplier_Master where Supplier_Id  = '" & txtsupid.Text & "'"

        cm.CommandText = sql
        cm.CommandType = CommandType.Text

        cm.ExecuteNonQuery()
        MsgBox("record deleted")
        Call Refresh_data()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        sql = "insert into Supplier_Master([Sup_Id],[Name],[Address],[City],[Pin],[Phone_No]) values('" & txtsupid.Text & "' ,'" & txtname.Text & "','" & txtaddress.Text & "','" & txtcity.Text & "','" & txtpin.Text & "','" & txtphoneno.Text & "')"

        cm.CommandText = sql
        'cm.CommandType = CommandType.Text

        cm.ExecuteNonQuery()
        MsgBox("Record inserted")
        Call Refresh_data()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        sql = "update Supplier_Master set Name ='" & txtname.Text & "',Address='" & txtaddress.Text & "',City='" & txtcity.Text & "',Pin='" & txtpin.Text & "',Phone_No='" & txtphoneno.Text & "' where Sup_Id = '" & txtsupid.Text & "'"

        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("UPdated")
        Call Refresh_data()
    End Sub

End Class