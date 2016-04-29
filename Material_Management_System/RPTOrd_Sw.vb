Imports System.Data.SqlClient

Public Class RPTOrd_Sw
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter
        cn = New SqlConnection
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()

        da = New SqlDataAdapter("SELECT Supplier_Master.Name, Order_Master.O_Id, Order_Master.Date, Material_Master.Mate_Name, Order_Detail.Qty FROM Order_Master INNER JOIN Order_Detail ON Order_Master.O_Id = Order_Detail.O_Id INNER JOIN Material_Master ON Order_Detail.Mate_Id = Material_Master.Mate_Id INNER JOIN Supplier_Master ON Order_Master.Sup_Id = Supplier_Master.Sup_Id", cn)

        ds = New Data.DataSet
        da.Fill(ds, "DataTable9")

        CRYOrd_Sw1.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = CRYOrd_Sw1

        Call Fill_Combo("Supplier_Master", "Name", ComboBox1)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CrystalReportViewer1.SelectionFormula = "{DataTable9.Name} = '" & ComboBox1.Text & "' "
        CrystalReportViewer1.ReportSource = CRYOrd_Sw1
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class