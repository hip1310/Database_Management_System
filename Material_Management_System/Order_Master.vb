Imports System.Data.SqlClient

Public Class Order_Master
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cm As SqlCommand
    Dim Cur, Max As Integer
    Dim sql As String
    Dim mateid As String
    Dim supid As String

    Private Sub Order_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet2.Order_Master' table. You can move, or remove it, as needed.
        Me.Order_MasterTableAdapter.Fill(Me.Database1DataSet2.Order_Master)
        ds = New DataSet
        cm = New SqlCommand
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        cm.Connection = cn
        Call Fill_Combo("Supplier_Master", "Name", cmbsupid)
        Refresh_data()

    End Sub
    Public Sub Refresh_data()

        da = New SqlDataAdapter("select * from Order_Master", cn)

        ds.Clear()
        da.Fill(ds)

        Cur = 0
        Max = ds.Tables(0).Rows.Count
        Max = Max - 1

        Call Getdata()

    End Sub
    Public Sub Getdata()
        txtinvno.Text = ds.Tables(0).Rows(Cur).Item(0)
        Call Get_Info("Supplier_Master", "Sup_Id", "Name", ds.Tables(0).Rows(Cur).Item(1))
        cmbsupid.Text = Module1.val
        purdate.Text = ds.Tables(0).Rows(Cur).Item(2)
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
        txtinvno.Text = ""
        cmbsupid.Text = ""
        purdate.Text = ""
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        sql = "delete from Order_Master where O_Id  = '" & txtinvno.Text & "'"

        cm.CommandText = sql
        cm.CommandType = CommandType.Text
        cm.ExecuteNonQuery()


        MsgBox("record deleted")
        Call Refresh_data()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        purdate.Text = purdate.Value.Date
        sql = "insert into Order_Master([O_Id],[Sup_Id],[Date]) values('" & txtinvno.Text & "' ,'" & supid & "','" & purdate.Text & "')"

        cm.CommandText = sql
        'cm.CommandType = CommandType.Text
        cm.ExecuteNonQuery()

        MsgBox("Record inserted")
        Call Refresh_data()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        purdate.Text = purdate.Value.Date
        sql = "update Order_Master set Sup_Id='" & supid & "',Date='" & purdate.Text & "' where O_Id = '" & txtinvno.Text & "'"

        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("UPdated")
        Call Refresh_data()
    End Sub

    Private Sub cmbsupid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsupid.SelectedIndexChanged
        Call Get_Info("Supplier_Master", "Name", "Sup_Id", cmbsupid.Text)
        supid = Module1.val
    End Sub
End Class