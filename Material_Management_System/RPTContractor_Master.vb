Imports System.Data.SqlClient

Public Class RPTContractor_Master
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet

    Private Sub RPTContractor_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()

        da = New SqlDataAdapter("SELECT * FROM Contractor_Master", cn)

        ds = New Data.DataSet
        da.Fill(ds, "Contractor_Master")

        CRYContractor_Master1.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = CRYContractor_Master1

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class