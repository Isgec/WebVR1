Partial Class RP_vrRequestExecution
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrRequestExecution.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SRNNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim SRNNo As Int32 = CType(aVal(0),Int32)
		Dim oVar As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(SRNNo)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Request Execution No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SRNNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Execution Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ExecutionDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Transporter"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TransporterID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_Transporters10_TransporterName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Placed On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VehiclePlacedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Vehicle Type"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VehicleTypeID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_VehicleTypes13_cmba
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VehicleNo
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
    oCol.Text = "Arranged By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ArrangedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users1_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Arranged On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ArrangedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trafic Officer Division"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TraficOfficerDivisionID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.HRM_Divisions4_Description
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Request Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RequestStatusID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_RequestStates6_Description
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Approval Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ApprovalRemarks
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Approved By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ApprovedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users3_UserFullName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Approved On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ApprovedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "GR No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.GRNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "GR Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.GRDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Loaded At Supplier"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.LoadedAtSupplier, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Loaded On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.LoadedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Trans Shipment"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.TransShipment, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment GR No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TransGRNO
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Trans Shipment GR Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TransGRDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment Vehicle No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TransVehicleNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Trans Shipment Vehicle Type ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TransVehicleTypeID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_VehicleTypes14_cmba
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment Transporter ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TransTransporterID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_Transporters8_TransporterName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Receipt At Site"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.ReceiptAtSite, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users2_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Receipt On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Material State ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MaterialStateID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_MaterialStates5_Description
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Receipt Material Size"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptMaterialSize
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt Material Weight"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptMaterialWeight
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Receipt Weight Unit"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptSizeUnit
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_Units11_Description
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt No. Of Packages"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptNoOfPackages
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Reached At Site"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.ReachedAtSite, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Reached On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReachedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Unloaded At Site"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.UnloadedAtSite, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Unloaded On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.UnloadedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "SiteReceiptNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SiteReceiptNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "SiteReceiptDate"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SiteReceiptDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Receipt Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptRemarks
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment At Site"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.TransShipmentAtSite, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Site GR No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SiteGRNO
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Site GR Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SiteGRDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Site Vehicle No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SiteVehicleNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Site Vehicle Type ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SiteVehicleTypeID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_VehicleTypes12_cmba
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Site Transporter ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SiteTransporterID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_Transporters9_TransporterName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IRNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IRNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_TransporterBill7_IRDescription
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    form1.Controls.Add(oTbl)
    Dim ovrLinkedRequests As List(Of SIS.VR.vrLinkedRequest) = SIS.VR.vrLinkedRequest.vrLinkedRequestSelectList(0, 999, "", False, "", SRNNo)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Request No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Request Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Supplier ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Supplier Location"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project Type"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Delivery Location"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Item Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Material Size"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Material Weight"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Weight Unit"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "No. Of Packages"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Type ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Required On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "MICN"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Custom Invoice No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Requested By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "User Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Requested On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Requester Division ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Request Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Returned On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Returned By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "User Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Return Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Request Execution No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Execution Description"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each ovrLinkedRequest As SIS.VR.vrLinkedRequest In ovrLinkedRequests
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.RequestNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.RequestDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.SupplierID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.IDM_Vendors5_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.SupplierLocation
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.ProjectID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.IDM_Projects4_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.ProjectType
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.DeliveryLocation
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.ItemDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.MaterialSize
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.MaterialWeight
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.SizeUnit
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.VR_Units8_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.NoOfPackages
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.VehicleTypeID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.VR_VehicleTypes9_cmba
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.VehicleRequiredOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedRequest.MICN, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.CustomInvoiceNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.Remarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.RequestedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.aspnet_Users1_UserFullName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.RequestedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.RequesterDivisionID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.HRM_Divisions3_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.RequestStatus
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.VR_RequestStates7_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.ReturnedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.ReturnedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.aspnet_Users2_UserFullName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.ReturnRemarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.SRNNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedRequest.VR_RequestExecution6_ExecutionDescription
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
    Dim ovrUnLinkedRequests As List(Of SIS.VR.vrUnLinkedRequest) = SIS.VR.vrUnLinkedRequest.vrUnLinkedRequestSelectList(0, 999, "", False, "")
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Request No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Request Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Supplier ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Supplier Location"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Project Type"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Delivery Location"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Item Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Material Size"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Material Weight"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Weight Unit"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "No. Of Packages"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Type ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Required On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "MICN"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Custom Invoice No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Requested By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "User Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Requested On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Requester Division ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Request Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Returned On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Returned By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "User Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Return Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Request Execution No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Execution Description"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each ovrUnLinkedRequest As SIS.VR.vrUnLinkedRequest In ovrUnLinkedRequests
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.RequestNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.RequestDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.SupplierID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.IDM_Vendors5_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.SupplierLocation
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.ProjectID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.IDM_Projects4_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.ProjectType
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.DeliveryLocation
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.ItemDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.MaterialSize
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.MaterialWeight
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.SizeUnit
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.VR_Units8_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.NoOfPackages
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.VehicleTypeID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.VR_VehicleTypes9_cmba
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.VehicleRequiredOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnLinkedRequest.MICN, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.CustomInvoiceNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.Remarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.RequestedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.aspnet_Users1_UserFullName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.RequestedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.RequesterDivisionID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.HRM_Divisions3_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.RequestStatus
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.VR_RequestStates7_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.ReturnedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.ReturnedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.aspnet_Users2_UserFullName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.ReturnRemarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.SRNNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnLinkedRequest.VR_RequestExecution6_ExecutionDescription
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
  End Sub
End Class
