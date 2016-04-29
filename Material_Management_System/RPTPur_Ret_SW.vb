Imports System.Data.SqlClient
Public Class RPTPur_Ret_SW
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet

    Private Sub RPTPer_Ret_SW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()

        da = New SqlDataAdapter("SELECT Supplier_Master.Name, Purchase_Master.Inv_No, Purchase_Return.Date, Material_Master.Mate_Name, Purchase_Return.Qty FROM Supplier_Master INNER JOIN Purchase_Master ON Supplier_Master.Sup_Id = Purchase_Master.Sup_Id INNER JOIN Purchase_Return ON Purchase_Master.Inv_No = Purchase_Return.Inv_No INNER JOIN Material_Master ON Purchase_Return.Mate_Id = Material_Master.Mate_Id", cn)

        ds = New Data.DataSet
        da.Fill(ds, "DataTable6")

        CRYPur_Ret_SW1.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = CRYPur_Ret_SW1

        Call Fill_Combo("Supplier_Master", "Name", ComboBox1)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CrystalReportViewer1.SelectionFormula = "{DataTable6.Name} = '" & ComboBox1.Text & "' "
        CrystalReportViewer1.ReportSource = CRYPur_Ret_SW1
        CrystalReportViewer1.RefreshReport()
    End Sub

    
End Class