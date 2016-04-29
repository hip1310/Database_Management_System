Imports System.Data.SqlClient

Public Class Payment
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cm As SqlCommand
    Dim Cur, Max As Integer
    Dim sql As String
    Dim supid As String

    Private Sub Payment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet2.Payment' table. You can move, or remove it, as needed.
        Me.PaymentTableAdapter.Fill(Me.Database1DataSet2.Payment)
        ds = New DataSet
        cm = New SqlCommand
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        cm.Connection = cn
        Call Fill_Combo("Purchase_Master", "Inv_No", cmbinvno)

        Refresh_data()
    End Sub
    Public Sub Refresh_data()

        da = New SqlDataAdapter("select * from Payment", cn)

        ds.Clear()
        da.Fill(ds)

        Cur = 0
        Max = ds.Tables(0).Rows.Count
        Max = Max - 1

        Call Getdata()

    End Sub
    Public Sub Getdata()
        cmbinvno.Text = ds.Tables(0).Rows(Cur).Item(0)
        Call Get_Info("Supplier_Master", "Sup_Id", "Name", ds.Tables(0).Rows(Cur).Item(1))
        txtsupname.Text = Module1.val
        purdate.Text = ds.Tables(0).Rows(Cur).Item(2)
        txtamount.Text = ds.Tables(0).Rows(Cur).Item(3)
        txtremark.Text = ds.Tables(0).Rows(Cur).Item(4)
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
        purdate.Text = ""
        txtamount.Text = ""
        txtremark.Text = ""
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

        sql = "delete from Payment where Inv_No  = '" & cmbinvno.Text & "'"

        cm.CommandText = sql
        cm.CommandType = CommandType.Text
        cm.ExecuteNonQuery()
        MsgBox("record deleted")
        Call Refresh_data()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        purdate.Text = purdate.Value.Date
        sql = "insert into Payment([Inv_No],[Sup_Id],[Date],[Amount],[Cheque_No]) values('" & cmbinvno.Text & "' ,'" & supid & "','" & purdate.Text & "','" & txtamount.Text & "','" & txtremark.Text & "')"

        cm.CommandText = sql
        'cm.CommandType = CommandType.Text
        cm.ExecuteNonQuery()

        MsgBox("Record inserted")
        Call Refresh_data()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        purdate.Text = purdate.Value.Date
        sql = "update Payment set Sup_Id='" & supid & "',Date='" & purdate.Text & "',Amount='" & txtamount.Text & "',Cheque_No='" & txtremark.Text & "' where Inv_No = '" & cmbinvno.Text & "'"

        cm.CommandText = sql
        cm.ExecuteNonQuery()

        MsgBox("UPdated")
        Call Refresh_data()
    End Sub
    
    Private Sub cmbinvno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbinvno.SelectedIndexChanged
        Call Get_Info("Purchase_Master", "Inv_No", "Sup_Id", cmbinvno.Text)
        supid = Module1.val
        Call Get_Info("Supplier_Master", "Sup_Id", "Name", supid)
        txtsupname.Text = Module1.val
    End Sub
End Class