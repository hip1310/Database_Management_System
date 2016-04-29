Imports System.Data.SqlClient

Public Class Purchase_Master
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim dr As SqlDataReader
    Dim cm As SqlCommand
    Dim cm1 As SqlCommand
    Dim Cur, Max As Integer
    Dim sql As String
    Dim mateid As String
    Dim supid As String
    Dim amo As Decimal
    Dim pre_qua As Integer
    Dim qua As Integer

    Private Sub Purchase_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database1DataSet2.Purchase_Master' table. You can move, or remove it, as needed.
        Me.Purchase_MasterTableAdapter.Fill(Me.Database1DataSet2.Purchase_Master)
        ds = New DataSet
        cm = New SqlCommand
        cn = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True")
        cn.Open()
        cm.Connection = cn
        Call Fill_Combo("Supplier_Master", "Name", cmbsupid)
        Refresh_data()
    End Sub

    Public Sub Refresh_data()

        da = New SqlDataAdapter("select * from Purchase_Master", cn)

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
        sql = "delete from Purchase_Master where Inv_No  = '" & txtinvno.Text & "'"

        cm.CommandText = sql
        cm.CommandType = CommandType.Text
        cm.ExecuteNonQuery()

        
        MsgBox("record deleted")
        Call Refresh_data()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim count As Integer
        Try
            If txtinvno.Text = "" Then
                MsgBox("Invoice No must be entered!")
                txtinvno.Focus()
            ElseIf cmbsupid.Text = "" Then
                MsgBox("Select the Supplier!")
                cmbsupid.Focus()
            ElseIf purdate.Text = "" Then
                MsgBox("Select the Date!")
                purdate.Focus()
            ElseIf txtinvno.Text <> "" Then

                sql = "select count(Inv_No) from Purchase_Master where Inv_No='" & txtinvno.Text & "'"

                cm.Connection = cn
                cm.CommandText = sql

                dr = cm.ExecuteReader

                Do While dr.Read()
                    count = dr.Item(0)
                Loop
                cn.Close()


                If (count > 0) Then
                    MsgBox("Invoice No already exist! Enter Another!")
                End If

                cn.Open()
                purdate.Text = purdate.Value.Date
                sql = "insert into Purchase_Master([Inv_No],[Sup_Id],[Date]) values('" & txtinvno.Text & "' ,'" & supid & "','" & purdate.Text & "')"

                cm.CommandText = sql
                'cm.CommandType = CommandType.Text
                cm.ExecuteNonQuery()

                MsgBox("Record inserted")
                Call Refresh_data()
            End If
        Catch ex As Exception
            MsgBox("Can't Saved!")
        End Try

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        purdate.Text = purdate.Value.Date
        sql = "update Purchase_Master set Sup_Id='" & supid & "',Date='" & purdate.Text & "' where Inv_No = '" & txtinvno.Text & "'"

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