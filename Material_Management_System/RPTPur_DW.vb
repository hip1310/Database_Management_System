Imports System.Data.SqlClient

Public Class RPTPur_DW
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet

    Private Sub RPTPur_DW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()

        da = New SqlDataAdapter("SELECT Purchase_Master.Date, Purchase_Master.Inv_No, Supplier_Master.Name, Material_Master.Mate_Name, Purchase_Detail.Rate, Purchase_Detail.Qty,Purchase_Detail.Amount, Purchase_Detail.Remark FROM Purchase_Master INNER JOIN Supplier_Master ON Purchase_Master.Sup_Id = Supplier_Master.Sup_Id INNER JOIN Purchase_Detail ON Purchase_Master.Inv_No = Purchase_Detail.Inv_No INNER JOIN Material_Master ON Purchase_Detail.Mate_Id = Material_Master.Mate_Id", cn)

        ds = New Data.DataSet
        da.Fill(ds, "DataTable3")

        CRYPur_DW1.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = CRYPur_DW1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dtstr1 As String
        dtstr1 = CStr(DateTimePicker1.Value.Date)

        CrystalReportViewer1.SelectionFormula = "{DataTable3.Date} = '" & dtstr1 & "' "
        CrystalReportViewer1.ReportSource = CRYPur_DW1
        CrystalReportViewer1.RefreshReport()
    End Sub

End Class