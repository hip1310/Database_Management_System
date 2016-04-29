Imports System.Data.SqlClient
Public Class RPTOrd_DW
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        cn = New SqlConnection
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()

        da = New SqlDataAdapter("SELECT Order_Master.Date, Order_Master.O_Id, Supplier_Master.Name, Material_Master.Mate_Name, Order_Detail.Qty FROM Order_Master INNER JOIN Order_Detail ON Order_Master.O_Id = Order_Detail.O_Id INNER JOIN Supplier_Master ON Order_Master.Sup_Id = Supplier_Master.Sup_Id INNER JOIN Material_Master ON Order_Detail.Mate_Id = Material_Master.Mate_Id", cn)

        ds = New Data.DataSet
        da.Fill(ds, "DataTable8")

        CRYOrd_DW2.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = CRYOrd_DW2
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dtstr1 As String
        dtstr1 = CStr(DateTimePicker1.Value.Date)

        CrystalReportViewer1.SelectionFormula = "{DataTable8.Date} = '" & dtstr1 & "' "
        CrystalReportViewer1.ReportSource = CRYOrd_DW2
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class