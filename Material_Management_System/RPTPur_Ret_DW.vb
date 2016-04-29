Imports System.Data.SqlClient
Public Class RPTPur_Ret_DW
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet

    Private Sub RPTPur_Ret_DW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()

        da = New SqlDataAdapter("SELECT Purchase_Return.Date, Purchase_Master.Inv_No, Supplier_Master.Name, Material_Master.Mate_Name, Purchase_Return.Qty FROM Supplier_Master INNER JOIN Purchase_Master ON Supplier_Master.Sup_Id = Purchase_Master.Sup_Id INNER JOIN Purchase_Return ON Purchase_Master.Inv_No = Purchase_Return.Inv_No INNER JOIN Material_Master ON Purchase_Return.Mate_Id = Material_Master.Mate_Id", cn)

        ds = New Data.DataSet
        da.Fill(ds, "DataTable5")

        CRYPur_Ret_DW1.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = CRYPur_Ret_DW1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dtstr1 As String
        dtstr1 = CStr(DateTimePicker1.Value.Date)

        CrystalReportViewer1.SelectionFormula = "{DataTable5.Date} = '" & dtstr1 & "' "
        CrystalReportViewer1.ReportSource = CRYPur_Ret_DW1
        CrystalReportViewer1.RefreshReport()
    End Sub

    
End Class