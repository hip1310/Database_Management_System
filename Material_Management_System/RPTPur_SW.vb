Imports System.Data.SqlClient

Public Class RPTPur_SW
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet

    Private Sub RPTPur_SW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()

        da = New SqlDataAdapter("SELECT Supplier_Master.Name, Purchase_Master.Inv_No, Purchase_Master.Date, Material_Master.Mate_Name, Purchase_Detail.Rate, Purchase_Detail.Qty,Purchase_Detail.Amount, Purchase_Detail.Remark FROM Purchase_Detail INNER JOIN Material_Master ON Purchase_Detail.Mate_Id = Material_Master.Mate_Id INNER JOIN Purchase_Master ON Purchase_Detail.Inv_No = Purchase_Master.Inv_No INNER JOIN Supplier_Master ON Purchase_Master.Sup_Id = Supplier_Master.Sup_Id", cn)

        ds = New Data.DataSet
        da.Fill(ds, "DataTable4")

        CRYPur_SW1.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = CRYPur_SW1

        Call Fill_Combo("Supplier_Master", "Name", ComboBox1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CrystalReportViewer1.SelectionFormula = "{DataTable4.Name} = '" & ComboBox1.Text & "' "
        CrystalReportViewer1.ReportSource = CRYPur_SW1
        CrystalReportViewer1.RefreshReport()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class