Imports System.Data.SqlClient
Public Class Material_Used
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cm As SqlCommand
    Dim Cur, Max As Integer
    Dim sql As String
    Dim mateid As String
    Dim supid As String
    Dim amo As Decimal
    Dim pre_qua As Integer
    Dim qua As Integer

    Private Sub Material_Used_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet2.Material_Used' table. You can move, or remove it, as needed.
        Me.Material_UsedTableAdapter.Fill(Me.Database1DataSet2.Material_Used)
        ds = New DataSet
        cm = New SqlCommand
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        cm.Connection = cn
        Call Fill_Combo("Material_Master", "Mate_Name", cmbmateid)
        Call Fill_Combo("Block_Master", "Block_Id", cmbsupid)
        Refresh_data()
    End Sub
    Public Sub Refresh_data()

        da = New SqlDataAdapter("select * from Material_Used", cn)

        ds.Clear()
        da.Fill(ds)

        Cur = 0
        Max = ds.Tables(0).Rows.Count
        Max = Max - 1

        Call Getdata()

    End Sub
    Public Sub Getdata()
        txtinvno.Text = ds.Tables(0).Rows(Cur).Item(0)
        Call Get_Info("Material_Master", "Mate_Id", "Mate_Name", ds.Tables(0).Rows(Cur).Item(1))
        cmbmateid.Text = Module1.val
        cmbsupid.Text = ds.Tables(0).Rows(Cur).Item(2)
        purdate.Text = ds.Tables(0).Rows(Cur).Item(3)
        txtqty.Text = ds.Tables(0).Rows(Cur).Item(4)
        txtremark.Text = ds.Tables(0).Rows(Cur).Item(5)
        Call Get_Info("Material_Master", "Mate_Id", " Measurement", mateid)
        Label4.Text = Module1.val
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
        cmbmateid.Text = ""
        cmbsupid.Text = ""
        purdate.Text = ""
        txtqty.Text = ""
        txtremark.Text = ""
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Call Get_Values()
        sql = "delete from Material_Used where Used_Id  = '" & txtinvno.Text & "'"

        cm.CommandText = sql
        cm.CommandType = CommandType.Text
        cm.ExecuteNonQuery()


        sql = "update Material_Master set Qty=" & pre_qua & " + " & qua & "  where Mate_Id= '" & mateid & "';"
        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("record deleted")
        Call Refresh_data()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        purdate.Text = purdate.Value.Date

        sql = "insert into Material_Used([Used_Id],[Mate_Id],[Block_Id],[Date],[Qty],[Remark]) values('" & txtinvno.Text & "' ,'" & mateid & "','" & cmbsupid.Text & "','" & purdate.Text & "','" & txtqty.Text & "','" & txtremark.Text & "')"

        cm.CommandText = sql
        'cm.CommandType = CommandType.Text
        cm.ExecuteNonQuery()

        Call Get_Values()
        Dim temp = Convert.ToInt32(txtqty.Text)
        sql = "update Material_Master set Qty=" & pre_qua & " - " & temp & " where Mate_Id= '" & mateid & "';"
        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("Record inserted")
        Call Refresh_data()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Call Get_Values()

        purdate.Text = purdate.Value.Date

        sql = "update Material_Used set Mate_Id ='" & mateid & "',Block_Id='" & cmbsupid.Text & "',Date='" & purdate.Text & "',Qty='" & txtqty.Text & "',Remark='" & txtremark.Text & "' where Used_Id = '" & txtinvno.Text & "'"

        cm.CommandText = sql
        cm.ExecuteNonQuery()


        Dim temp = Convert.ToInt32(txtqty.Text)
        sql = "update Material_Master set Qty=" & pre_qua & " + " & qua & " - " & temp & " where Mate_Id= '" & mateid & "';"
        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("UPdated")
        Call Refresh_data()
    End Sub

    Private Sub cmbmateid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmateid.SelectedIndexChanged
        Call Get_Info("Material_Master", "Mate_Name", "Mate_Id", cmbmateid.Text)
        mateid = Module1.val
        Call Get_Info("Material_Master", "Mate_Id", " Measurement", mateid)
        Label4.Text = Module1.val
    End Sub

    
    Private Sub Get_Values()
        Call Get_Info("Material_Master", "Mate_Id", "Qty", mateid)
        pre_qua = Convert.ToInt32(Module1.val)
        Call Get_Info("Material_used", "Used_Id", "Qty", txtinvno.Text)
        qua = Convert.ToInt32(Module1.val)
    End Sub
End Class