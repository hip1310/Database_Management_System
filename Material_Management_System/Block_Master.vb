Imports System.Data.SqlClient

Public Class Block_Master
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cm As SqlCommand
    Dim Cur, Max As Integer
    Dim sql As String
    Dim val1 As String

    Private Sub Block_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet2.Block_Master' table. You can move, or remove it, as needed.
        Me.Block_MasterTableAdapter.Fill(Me.Database1DataSet2.Block_Master)
        ds = New DataSet
        cm = New SqlCommand
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        cm.Connection = cn
        Call fill_combo("Contractor_Master", "Name", cmbcid)
        Refresh_data()

    End Sub
    Public Sub Refresh_data()

        da = New SqlDataAdapter("select * from Block_Master", cn)

        ds.Clear()
        da.Fill(ds)

        Cur = 0
        Max = ds.Tables(0).Rows.Count
        Max = Max - 1

        Call Getdata()

    End Sub
    Public Sub Getdata()
        txtbid.Text = ds.Tables(0).Rows(Cur).Item(0)
        Call Get_Info("Contractor_Master", "C_Id", "Name", ds.Tables(0).Rows(Cur).Item(1))
        cmbcid.Text = Module1.val
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
        txtbid.Text = ""
        cmbcid.Text = ""
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

        sql = "delete from Block_Master where Block_Id  = '" & txtbid.Text & "'"

        cm.CommandText = sql
        cm.CommandType = CommandType.Text

        cm.ExecuteNonQuery()
        MsgBox("record deleted")
        Call Refresh_data()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        sql = "insert into Block_Master([Block_Id],[C_Id]) values('" & txtbid.Text & "' ,'" & val1 & "')"

        cm.CommandText = sql
        'cm.CommandType = CommandType.Text

        cm.ExecuteNonQuery()
        MsgBox("Record inserted")
        Call Refresh_data()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        sql = "update Block_Master set C_Id ='" & val1 & "'where Block_Id = '" & txtbid.Text & "'"

        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("UPdated")
        Call Refresh_data()
    End Sub

    Private Sub cmbcid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcid.SelectedIndexChanged
        Call Get_Info("Contractor_Master", "Name", "C_Id", cmbcid.Text)
        val1 = Module1.val
    End Sub
End Class