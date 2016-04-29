Imports System.Data.SqlClient
Public Class RPTPayment_DW
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet

    Private Sub RPTPayment_DW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()

        da = New SqlDataAdapter("SELECT Payment.Date, Payment.Inv_No, Supplier_Master.Name, Payment.Amount, Payment.Cheque_No FROM Supplier_Master INNER JOIN Payment ON Supplier_Master.Sup_Id = Payment.Sup_Id", cn)

        ds = New Data.DataSet
        da.Fill(ds, "DataTable7")

        CRYPayment_Dw1.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = CRYPayment_Dw1

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dtstr1 As String
        dtstr1 = CStr(DateTimePicker1.Value.Date)

        CrystalReportViewer1.SelectionFormula = "{DataTable7.Date} = '" & dtstr1 & "' "
        CrystalReportViewer1.ReportSource = CRYPayment_Dw1
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class