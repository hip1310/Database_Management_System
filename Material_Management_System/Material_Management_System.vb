Public Class Material_Management_System

    Private Sub MaterialMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialMasterToolStripMenuItem.Click
        Dim frm As Material_Master
        frm = New Material_Master
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub SupplierMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierMasterToolStripMenuItem.Click
        Dim frm As Supplier_Master
        frm = New Supplier_Master
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ContractorMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContractorMasterToolStripMenuItem.Click
        Dim frm As Contractor_Master
        frm = New Contractor_Master
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub BlockMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlockMasterToolStripMenuItem.Click
        Dim frm As Block_Master
        frm = New Block_Master
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PurchaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaToolStripMenuItem.Click
        Dim frm As Purchase
        frm = New Purchase
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PurchaseReeturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReeturnToolStripMenuItem.Click
        Dim frm As Purchase_Return
        frm = New Purchase_Return
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        Dim frm As Payment
        frm = New Payment
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub MaterialUsedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaterialUsedToolStripMenuItem.Click
        Dim frm As Material_Used
        frm = New Material_Used
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub StockMaterialReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockMaterialReportToolStripMenuItem.Click
        Dim frm As RPTStock_Material
        frm = New RPTStock_Material
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub DateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateToolStripMenuItem.Click
        Dim frm As RPTMaterial_Used_DW
        frm = New RPTMaterial_Used_DW
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RangeWiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RangeWiseToolStripMenuItem.Click
        Dim frm As RPTMaterial_Used_RW
        frm = New RPTMaterial_Used_RW
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ContractorBlockWiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContractorBlockWiseToolStripMenuItem.Click
        Dim frm As RPTMaterial_Used_CBW
        frm = New RPTMaterial_Used_CBW
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub DateWiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateWiseToolStripMenuItem.Click
        Dim frm As RPTPur_DW
        frm = New RPTPur_DW
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub SupplierWiseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierWiseToolStripMenuItem.Click
        Dim frm As RPTPur_SW
        frm = New RPTPur_SW
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub DateWiseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateWiseToolStripMenuItem1.Click
        Dim frm As RPTPur_Ret_DW
        frm = New RPTPur_Ret_DW
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub SupplierWiseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierWiseToolStripMenuItem1.Click
        Dim frm As RPTPur_Ret_SW
        frm = New RPTPur_Ret_SW
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub DateWiseToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateWiseToolStripMenuItem2.Click
        Dim frm As RPTPayment_DW
        frm = New RPTPayment_DW
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub SupplierDetailReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierDetailReportToolStripMenuItem.Click
        Dim frm As RPTSupplier_Master
        frm = New RPTSupplier_Master
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ContractorDetailReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContractorDetailReportToolStripMenuItem.Click
        Dim frm As RPTContractor_Master
        frm = New RPTContractor_Master
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub AddNewUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewUserToolStripMenuItem.Click
        Dim frm As User_Master
        frm = New User_Master
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub OrderMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderMasterToolStripMenuItem.Click
        Dim frm As Order_Master
        frm = New Order_Master
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub OrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderToolStripMenuItem.Click
        Dim frm As Order_Detail
        frm = New Order_Detail
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PurchaseMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseMasterToolStripMenuItem.Click
        Dim frm As Purchase_Master
        frm = New Purchase_Master
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Dim frm As Change_Password
        frm = New Change_Password
        frm.MdiParent = Me
        frm.Show()

    End Sub

    Private Sub Material_Management_System_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStripLabel3.Text = uname
        ToolStripLabel4.Text = Convert.ToString(Now)
    End Sub
End Class