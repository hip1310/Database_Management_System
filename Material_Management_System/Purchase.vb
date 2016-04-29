Imports System.Data.SqlClient
Public Class Purchase
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

    Private Sub Purchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet2.Purchase_Detail' table. You can move, or remove it, as needed.
        Me.Purchase_DetailTableAdapter.Fill(Me.Database1DataSet2.Purchase_Detail)
        ds = New DataSet
        cm = New SqlCommand
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        cm.Connection = cn
        Call Fill_Combo("Material_Master", "Mate_Name", cmbmateid)
        Call Fill_Combo("Purchase_Master", "Inv_No", cmbinvno)
        Refresh_data()
    End Sub
    Public Sub Refresh_data()

        da = New SqlDataAdapter("select * from Purchase_Detail", cn)

        ds.Clear()
        da.Fill(ds)

        Cur = 0
        Max = ds.Tables(0).Rows.Count
        Max = Max - 1

        Call Getdata()

    End Sub
    Public Sub Getdata()
        txtpdid.Text = ds.Tables(0).Rows(Cur).Item(0)
        Call Get_Info("Material_Master", "Mate_Id", "Mate_Name", ds.Tables(0).Rows(Cur).Item(1))
        cmbmateid.Text = Module1.val
        cmbinvno.Text = ds.Tables(0).Rows(Cur).Item(2)
        txtrate.Text = ds.Tables(0).Rows(Cur).Item(3)
        txtqty.Text = ds.Tables(0).Rows(Cur).Item(4)
        txtamount.Text = ds.Tables(0).Rows(Cur).Item(5)
        txtremark.Text = ds.Tables(0).Rows(Cur).Item(6)
        Call Get_Info("Purchase_Master", "Inv_No", "Sup_Id", ds.Tables(0).Rows(Cur).Item(2))
        supid = Module1.val
        Call Get_Info("Supplier_Master", "Sup_Id", "Name", supid)
        txtsupname.Text = Module1.val
        Call Get_Info("Material_Master", "Mate_Id", " Measurement", mateid)
        Label11.Text = Module1.val
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
        cmbinvno.Text = ""
        cmbmateid.Text = ""
        txtsupname.Text = ""
        txtrate.Text = ""
        txtqty.Text = ""
        txtamount.Text = ""
        txtremark.Text = ""
        txtpdid.Text = ""
        Label11.Text = ""
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Call Get_Values()
        sql = "delete from Purchase_Detail where PD_Id  = '" & txtpdid.Text & "'"

        cm.CommandText = sql
        cm.CommandType = CommandType.Text
        cm.ExecuteNonQuery()

        sql = "update Material_Master set Qty=" & pre_qua & " - " & qua & "  where Mate_Id= '" & mateid & "';"
        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("record deleted")
        Call Refresh_data()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        sql = "insert into Purchase_Detail([PD_Id],[Mate_Id],[Inv_No],[Rate],[Qty],[Amount],[Remark]) values('" & txtpdid.Text & "' ,'" & mateid & "','" & cmbinvno.Text & "','" & txtrate.Text & "','" & txtqty.Text & "','" & txtamount.Text & "','" & txtremark.Text & "')"

        cm.CommandText = sql
        'cm.CommandType = CommandType.Text
        cm.ExecuteNonQuery()

        Call Get_Values()
        Dim temp = Convert.ToInt32(txtqty.Text)
        sql = "update Material_Master set Qty=" & pre_qua & " + " & temp & " where Mate_Id= '" & mateid & "';"
        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("Record inserted")
        Call Refresh_data()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Call Get_Values()
        sql = "update Purchase_Detail set Mate_Id ='" & mateid & "',Inv_No='" & cmbinvno.Text & "',Rate='" & txtrate.Text & "',Qty='" & txtqty.Text & "',Amount='" & txtamount.Text & "',Remark='" & txtremark.Text & "' where PD_Id = '" & txtpdid.Text & "'"

        cm.CommandText = sql
        cm.ExecuteNonQuery()

        Dim temp = Convert.ToInt32(txtqty.Text)
        sql = "update Material_Master set Qty=" & pre_qua & " - " & qua & " + " & temp & " where Mate_Id= '" & mateid & "';"
        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("UPdated")
        Call Refresh_data()
    End Sub

    Private Sub txtqty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.TextChanged
        If txtqty.Text <> "" Then
            Dim quantity As Integer = Convert.ToInt32(txtqty.Text)
            Dim rate As Decimal = Convert.ToDecimal(txtrate.Text)
            amo = quantity * rate
            txtamount.Text = amo
        End If
    End Sub

    Private Sub cmbmateid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmateid.SelectedIndexChanged
        Call Get_Info("Material_Master", "Mate_Name", "Mate_Id", cmbmateid.Text)
        mateid = Module1.val
        Call Get_Info("Material_Master", "Mate_Id", " Measurement", mateid)
        Label11.Text = Module1.val
    End Sub

   
    Private Sub Get_Values()
        Call Get_Info("Material_Master", "Mate_Id", "Qty", mateid)
        pre_qua = Convert.ToInt32(Module1.val)
        Call Get_Info("Purchase_Detail", "PD_Id", "Qty", txtpdid.Text)
        qua = Convert.ToInt32(Module1.val)
    End Sub

    Private Sub cmbinvno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbinvno.SelectedIndexChanged
        Call Get_Info("Purchase_Master", "Inv_No", "Sup_Id", cmbinvno.Text)
        supid = Module1.val
        Call Get_Info("Supplier_Master", "Sup_Id", "Name", supid)
        txtsupname.Text = Module1.val
       
    End Sub

    
End Class