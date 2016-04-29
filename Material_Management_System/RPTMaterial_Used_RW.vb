Imports System.Data.SqlClient
Public Class RPTMaterial_Used_RW
    Dim cn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As Data.DataSet

    Private Sub RPTMaterial_Used_RW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True"
        cn.Open()

        da = New SqlDataAdapter("SELECT Material_Used.Date, Material_Master.Mate_Name, Material_Used.Block_Id, Material_Used.Qty, Material_Used.Remark FROM Material_Used INNER JOIN Material_Master ON Material_Used.Mate_Id = Material_Master.Mate_Id", cn)

        ds = New Data.DataSet
        da.Fill(ds, "DataTable1")

        CRYMate_Used_RW2.SetDataSource(ds)
        CrystalReportViewer1.ReportSource = CRYMate_Used_RW2

    End Sub

  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dtstr1 As String
        dtstr1 = CStr(DateTimePicker1.Value.Date)

        Dim dtstr2 As String
        dtstr2 = CStr(DateTimePicker2.Value.Date)

        CrystalReportViewer1.SelectionFormula = "{DataTable1.Date} >= '" & dtstr2 & "' AND {DataTable1.Date} <= '" & dtstr1 & "'"
        CrystalReportViewer1.ReportSource = CRYMate_Used_RW2
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class