Imports System.Data.SqlClient

Public Class Order_Detail
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

    Private Sub Order_Detail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet2.Order_Detail' table. You can move, or remove it, as needed.
        Me.Order_DetailTableAdapter.Fill(Me.Database1DataSet2.Order_Detail)
        ds = New DataSet
        cm = New SqlCommand
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        cm.Connection = cn
        Call Fill_Combo("Material_Master", "Mate_Name", cmbmateid)
        Call Fill_Combo("Order_Master", "O_Id", cmbinvno)
        Refresh_data()

    End Sub
    Public Sub Refresh_data()

        da = New SqlDataAdapter("select * from Order_Detail", cn)

        ds.Clear()
        da.Fill(ds)

        Cur = 0
        Max = ds.Tables(0).Rows.Count
        Max = Max - 1

        Call Getdata()

    End Sub
    Public Sub Getdata()
        txtpdid.Text = ds.Tables(0).Rows(Cur).Item(0)
        cmbinvno.Text = ds.Tables(0).Rows(Cur).Item(1)
        Call Get_Info("Order_Master", "O_Id", "Sup_Id", ds.Tables(0).Rows(Cur).Item(1))
        supid = Module1.val
        Call Get_Info("Supplier_Master", "Sup_Id", "Name", supid)
        txtsupname.Text = Module1.val
        Call Get_Info("Material_Master", "Mate_Id", "Mate_Name", ds.Tables(0).Rows(Cur).Item(2))
        cmbmateid.Text = Module1.val
        txtqty.Text = ds.Tables(0).Rows(Cur).Item(3)
        Call Get_Info("Material_Master", "Mate_Id", " Measurement", mateid)
        Label3.Text = Module1.val


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
        txtsupname.Text = ""
        txtpdid.Text = ""
        cmbmateid.Text = ""
        txtqty.Text = ""
        Label3.Text = ""
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

        sql = "delete from Order_Detail where OD_Id  = '" & txtpdid.Text & "'"

        cm.CommandText = sql
        cm.CommandType = CommandType.Text
        cm.ExecuteNonQuery()

        
        MsgBox("record deleted")
        Call Refresh_data()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        sql = "insert into Order_Detail([Od_Id],[O_Id],[Mate_Id],[Qty]) values('" & txtpdid.Text & "','" & cmbinvno.Text & "' ,'" & mateid & "','" & txtqty.Text & "')"

        cm.CommandText = sql
        'cm.CommandType = CommandType.Text
        cm.ExecuteNonQuery()

    
        MsgBox("Record inserted")
        Call Refresh_data()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        sql = "update Order_Detail set O_Id='" & cmbinvno.Text & "',Mate_Id ='" & mateid & "',Qty='" & txtqty.Text & "' where OD_Id = '" & txtpdid.Text & "'"

        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("UPdated")
        Call Refresh_data()
    End Sub



    Private Sub cmbmateid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmateid.SelectedIndexChanged
        Call Get_Info("Material_Master", "Mate_Name", "Mate_Id", cmbmateid.Text)
        mateid = Module1.val
        Call Get_Info("Material_Master", "Mate_Id", " Measurement", mateid)
        Label3.Text = Module1.val
    End Sub


    Private Sub cmbinvno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbinvno.SelectedIndexChanged
        Call Get_Info("Order_Master", "O_Id", "Sup_Id", cmbinvno.Text)
        supid = Module1.val
        Call Get_Info("Supplier_Master", "Sup_Id", "Name", supid)
        txtsupname.Text = Module1.val
    End Sub
End Class