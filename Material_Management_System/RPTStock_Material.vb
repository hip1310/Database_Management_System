Imports System.Data.SqlClient
Public Class RPTStock_Material
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet

    Private Sub RPTStock_Material_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()

        da = New SqlDataAdapter("select * from Material_Master", cn)

        ds = New Data.DataSet
        da.Fill(ds, "Material_Master")

        CRYStock_Material1.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = CRYStock_Material1
    End Sub
End Class