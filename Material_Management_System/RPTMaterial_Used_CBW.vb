Imports System.Data.SqlClient

Public Class RPTMaterial_Used_CBW
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet

    Private Sub RPTMaterial_Used_CBW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()

        da = New SqlDataAdapter("SELECT Contractor_Master.Name, Block_Master.Block_Id, Material_Master.Mate_Name, Material_Used.Qty FROM Block_Master INNER JOIN Contractor_Master ON Block_Master.C_Id = Contractor_Master.C_Id INNER JOIN Material_Used ON Block_Master.Block_Id = Material_Used.Block_Id INNER JOIN Material_Master ON Material_Used.Mate_Id = Material_Master.Mate_Id", cn)

        ds = New Data.DataSet
        da.Fill(ds, "DataTable2")

        CRYMate_Used_CBW1.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = CRYMate_Used_CBW1

        Call Fill_Combo("Contractor_Master", "Name", cmbcon)
        Call Fill_Combo("Block_Master", "Block_Id", cmbblock)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       
        CrystalReportViewer1.SelectionFormula = "{DataTable2.Name}= '" & cmbcon.Text & "' AND {DataTable2.Block_Id}='" & cmbblock.Text & "'"
        CrystalReportViewer1.ReportSource = CRYMate_Used_CBW1
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class