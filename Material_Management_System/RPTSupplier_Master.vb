Imports System.Data.SqlClient
Public Class RPTSupplier_Master
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet

    Private Sub RPTSupplier_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()

        da = New SqlDataAdapter("SELECT * FROM Supplier_Master", cn)

        ds = New Data.DataSet
        da.Fill(ds, "Supplier_Master")

        CRYSupplier_Master1.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = CRYSupplier_Master1
    End Sub
End Class