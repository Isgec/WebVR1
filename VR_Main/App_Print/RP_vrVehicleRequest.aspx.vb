Partial Class RP_vrVehicleRequest
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrVehicleRequest.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RequestNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim RequestNo As Int32 = CType(aVal(0),Int32)
		Dim oVar As SIS.VR.vrVehicleRequest = SIS.VR.vrVehicleRequest.UZ_vrVehicleRequestGetByID(RequestNo)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Request No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RequestNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Supplier ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SupplierID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IDM_Vendors5_Description
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Request Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RequestDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Supplier Location"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SupplierLocation
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Project ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IDM_Projects4_Description
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project Type"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectType
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Delivery Location"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DeliveryLocation
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Item Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ItemDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Material Size"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MaterialSize
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Material Weight"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MaterialWeight
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Weight Unit"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SizeUnit
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_Units8_Description
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "No. Of Packages"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.NoOfPackages
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Vehicle Type ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VehicleTypeID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_VehicleTypes9_cmba
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Required On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VehicleRequiredOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "MICN"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.MICN, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Custom Invoice No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CustomInvoiceNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Remarks
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Requested By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RequestedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users1_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Requested On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RequestedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Requester Division ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RequesterDivisionID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.HRM_Divisions3_Description
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Request Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RequestStatus
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_RequestStates7_Description
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Returned On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReturnedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Returned By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReturnedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users2_UserFullName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Return Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReturnRemarks
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Request Execution No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SRNNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_RequestExecution6_ExecutionDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    form1.Controls.Add(oTbl)
  End Sub
End Class
