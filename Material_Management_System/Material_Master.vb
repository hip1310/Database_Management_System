Imports System.Data.SqlClient

Public Class Material_Master
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cm As SqlCommand
    Dim Cur, Max As Integer
    Dim sql As String
    
    Private Sub Material_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet2.Material_Master' table. You can move, or remove it, as needed.
        Me.Material_MasterTableAdapter.Fill(Me.Database1DataSet2.Material_Master)
        'TODO: This line of code loads data into the 'Database1DataSet2.Material_Master' table. You can move, or remove it, as needed.
        Me.Material_MasterTableAdapter.Fill(Me.Database1DataSet2.Material_Master)

        ds = New DataSet
        cm = New SqlCommand
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        cm.Connection = cn

        Refresh_data()

    End Sub
    Public Sub Refresh_data()

        da = New SqlDataAdapter("select * from Material_Master", cn)

        ds.Clear()
        da.Fill(ds)

        Cur = 0
        Max = ds.Tables(0).Rows.Count
        Max = Max - 1

        Call Getdata()

    End Sub
    Public Sub Getdata()
        txtmateid.Text = ds.Tables(0).Rows(Cur).Item(0)
        txtmaterialname.Text = ds.Tables(0).Rows(Cur).Item(1)
        txtmeasure.Text = Convert.ToString(ds.Tables(0).Rows(Cur).Item(3))
    End Sub

    Private Sub cmdFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFirst.Click
        Cur = 0
        Call Getdata()
        MsgBox("First Record!")

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
        MsgBox("Last Record!")
    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        txtmateid.Text = ""
        txtmaterialname.Text = ""
        txtmeasure.Text = ""
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        sql = "delete from Material_Master where Mate_Id  = '" & txtmateid.Text & "'"

        cm.CommandText = sql
        cm.CommandType = CommandType.Text

        cm.ExecuteNonQuery()
        MsgBox("record deleted")
        Call Refresh_data()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        sql = "insert into Material_Master([Mate_Id],[Mate_Name],[Qty],[Measurement]) values('" & txtmateid.Text & "' ,'" & txtmaterialname.Text & "', " & 0 & ",'" & txtmeasure.Text & "')"

        cm.CommandText = sql
        'cm.CommandType = CommandType.Text

        cm.ExecuteNonQuery()
        MsgBox("Record inserted")
        Call Refresh_data()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        sql = "update Material_Master set Mate_Name ='" & txtmaterialname.Text & "',Measurement='" & txtmeasure.Text & "' where Mate_Id = '" & txtmateid.Text & "'"

        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("UPdated")
        Call Refresh_data()
    End Sub

  
End Class