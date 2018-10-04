Partial Class RP_vrTransporterBill
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrTransporterBill.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?IRNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim IRNo As Int32 = CType(aVal(0),Int32)
		Dim oVar As SIS.VR.vrTransporterBill = SIS.VR.vrTransporterBill.vrTransporterBillGetByID(IRNo)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "IRNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IRNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IR Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IRDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "ERP PO Number"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ISGECPONumber
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "ERP PO Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ISGECPODate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "ERP PO Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ISGECPOAmount
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TransporterID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_Transporters9_TransporterName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Transporter Bill No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TransporterBillNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter Bill Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TransporterBillDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Bill Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BillAmount
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Bill Received On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BillReceivedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Bill Received By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BillReceivedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users5_UserFullName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Bill Receiver Division ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BillReceiverDivisionID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.HRM_Divisions6_Description
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Bill Status"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BillStatusID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_BillStatus8_Description
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Discripant Bill"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.DiscripantBill, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Bill Return Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BillReturnRemarks
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Bill Returned On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BillReturnedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Bill Returnedd By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.BillReturneddBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users1_UserFullName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "ERP Receipt No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "ERP Receipt Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "ERP Receipt Line"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptLine
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Passed Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.PassedAmount
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Forwarded To Account"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.ForwardedToAccount, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Forwarded On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ForwardedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Forwarded By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ForwardedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users2_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Receipt Acknowledgement"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.ReceiptAcknowledgement, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt Acknowledged On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptAcknowledgedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Receipt Acknowledged By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptAcknowledgedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users3_UserFullName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Discripant Receipt"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.DiscripantReceipt, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Receipt Returned On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptReturnedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt Returned By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptReturnedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users4_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Receipt Return Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReceiptReturnRemarks
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "SerialNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SerialNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_PaymentProcess7_PaymentDescription
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    form1.Controls.Add(oTbl)
    Dim ovrLinkedExecutions As List(Of SIS.VR.vrLinkedExecution) = SIS.VR.vrLinkedExecution.UZ_vrLinkedExecutionSelectList(0, 999, "", False, "", IRNo)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Request Execution No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Execution Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Placed On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Type"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "cmba"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Arranged By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "User Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Arranged On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trafic Officer Division"
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
    oCol.Text = "Approval Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Approved By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "User Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Approved On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "GR No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "GR Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Loaded At Supplier"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Loaded On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment GR No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment GR Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment Vehicle No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment Vehicle Type ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "cmba"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment Transporter ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt At Site"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "User Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Material State ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt Material Size"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt Material Weight"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt Weight Unit"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt No. Of Packages"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Reached At Site"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Reached On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Unloaded At Site"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Unloaded On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "SiteReceiptNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "SiteReceiptDate"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment At Site"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Site GR No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Site GR Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Site Vehicle No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Site Vehicle Type ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "cmba"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Site Transporter ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IRNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IR Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Material Size"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Size Unit"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Height"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Width"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Length"
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
    oCol.Text = "No Of Packages"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Over Dimention Consignement"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "GR Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Reached At Supplier On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "ODCByRequest"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Execution Linked"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Link ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Not Placed"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Delayed Placement"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Empty Return"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Detention At Supplier"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Debit To Transporter"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Payable To Transporter"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Borne By ISGEC"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Borne By Supplier"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Debit Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Payable Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "ISGEC Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Supplier Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Empty Return Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "ODC Reason"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each ovrLinkedExecution As SIS.VR.vrLinkedExecution In ovrLinkedExecutions
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.SRNNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ExecutionDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.TransporterID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_Transporters10_TransporterName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VehiclePlacedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VehicleTypeID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_VehicleTypes13_cmba
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VehicleNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.Remarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ArrangedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.aspnet_Users1_UserFullName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ArrangedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.TraficOfficerDivisionID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.HRM_Divisions4_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.RequestStatusID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_RequestStates6_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ApprovalRemarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ApprovedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.aspnet_Users3_UserFullName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ApprovedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.GRNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.GRDate
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.LoadedAtSupplier, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.LoadedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.TransShipment, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.TransGRNO
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.TransGRDate
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.TransVehicleNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.TransVehicleTypeID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_VehicleTypes14_cmba
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.TransTransporterID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_Transporters8_TransporterName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.ReceiptAtSite, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ReceiptBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.aspnet_Users2_UserFullName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ReceiptOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.MaterialStateID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_MaterialStates5_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ReceiptMaterialSize
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ReceiptMaterialWeight
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ReceiptSizeUnit
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_Units11_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ReceiptNoOfPackages
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.ReachedAtSite, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ReachedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.UnloadedAtSite, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.UnloadedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.SiteReceiptNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.SiteReceiptDate
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ReceiptRemarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.TransShipmentAtSite, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.SiteGRNO
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.SiteGRDate
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.SiteVehicleNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.SiteVehicleTypeID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_VehicleTypes12_cmba
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.SiteTransporterID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_Transporters9_TransporterName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.IRNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_TransporterBill7_IRDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.MaterialSize
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.SizeUnit
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_Units1_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.Height
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.Width
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.Length
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.MaterialWeight
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.WeightUnit
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_Units2_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.NoOfPackages
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.OverDimentionConsignement, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.GRRemarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.TransRemarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ReachedAtSupplierOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.ODCByRequest, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.Linked, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.LinkID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.VehicleNotPlaced, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.DelayedPlacement, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.EmptyReturn, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.DetentionAtSupplier, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.DebitToTransporter, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.PayableToTransporter, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.BorneByISGEC, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrLinkedExecution.BorneBySupplier, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.DebitAmount
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.PayableAmount
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ISGECAmount
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.SupplierAmount
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.EmptyReturnRemarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.ODCReasonID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrLinkedExecution.VR_ODCReasons16_Description
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
    Dim ovrUnlinkedExecutions As List(Of SIS.VR.vrUnlinkedExecution) = SIS.VR.vrUnlinkedExecution.UZ_vrUnlinkedExecutionSelectList(0, 999, "", False, "", IRNo)
    oTbl = New Table
    oTbl.GridLines = GridLines.Both
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Request Execution No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Execution Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Placed On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Type"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "cmba"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Arranged By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "User Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Arranged On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trafic Officer Division"
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
    oCol.Text = "Approval Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Approved By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "User Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Approved On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "GR No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "GR Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Loaded At Supplier"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Loaded On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment GR No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment GR Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment Vehicle No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment Vehicle Type ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "cmba"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment Transporter ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt At Site"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "User Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Material State ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt Material Size"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt Material Weight"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt Weight Unit"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt No. Of Packages"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Reached At Site"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Reached On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Unloaded At Site"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Unloaded On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "SiteReceiptNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "SiteReceiptDate"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Receipt Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment At Site"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Site GR No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Site GR Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Site Vehicle No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Site Vehicle Type ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "cmba"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Site Transporter ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IRNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "IR Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Material Size"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Size Unit"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Height"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Width"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Length"
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
    oCol.Text = "No Of Packages"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Over Dimention Consignement"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "GR Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Trans Shipment Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Reached At Supplier On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "ODCByRequest"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Execution Linked"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Link ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Not Placed"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Delayed Placement"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Empty Return"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Detention At Supplier"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Debit To Transporter"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Payable To Transporter"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Borne By ISGEC"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Borne By Supplier"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Debit Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Payable Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "ISGEC Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Supplier Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Empty Return Remarks"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "ODC Reason"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    For Each ovrUnlinkedExecution As SIS.VR.vrUnlinkedExecution In ovrUnlinkedExecutions
      oRow = New TableRow
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.SRNNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ExecutionDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.TransporterID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_Transporters10_TransporterName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VehiclePlacedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VehicleTypeID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_VehicleTypes13_cmba
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VehicleNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.Remarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ArrangedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.aspnet_Users1_UserFullName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ArrangedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.TraficOfficerDivisionID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.HRM_Divisions4_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.RequestStatusID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_RequestStates6_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ApprovalRemarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ApprovedBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.aspnet_Users3_UserFullName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ApprovedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.GRNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.GRDate
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.LoadedAtSupplier, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.LoadedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.TransShipment, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.TransGRNO
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.TransGRDate
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.TransVehicleNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.TransVehicleTypeID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_VehicleTypes14_cmba
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.TransTransporterID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_Transporters8_TransporterName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.ReceiptAtSite, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ReceiptBy
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.aspnet_Users2_UserFullName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ReceiptOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.MaterialStateID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_MaterialStates5_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ReceiptMaterialSize
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ReceiptMaterialWeight
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ReceiptSizeUnit
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_Units11_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ReceiptNoOfPackages
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.ReachedAtSite, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ReachedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.UnloadedAtSite, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.UnloadedOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.SiteReceiptNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.SiteReceiptDate
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ReceiptRemarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.TransShipmentAtSite, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.SiteGRNO
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.SiteGRDate
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.SiteVehicleNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.SiteVehicleTypeID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_VehicleTypes12_cmba
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.SiteTransporterID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_Transporters9_TransporterName
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.IRNo
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_TransporterBill7_IRDescription
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.MaterialSize
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.SizeUnit
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_Units1_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.Height
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.Width
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.Length
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.MaterialWeight
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.WeightUnit
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_Units2_Description
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.NoOfPackages
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.OverDimentionConsignement, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.GRRemarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.TransRemarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ReachedAtSupplierOn
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.ODCByRequest, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.Linked, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.LinkID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.VehicleNotPlaced, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.DelayedPlacement, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.EmptyReturn, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.DetentionAtSupplier, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.DebitToTransporter, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.PayableToTransporter, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.BorneByISGEC, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = IIf(ovrUnlinkedExecution.BorneBySupplier, "YES", "NO")
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.DebitAmount
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.PayableAmount
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ISGECAmount
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.SupplierAmount
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.EmptyReturnRemarks
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.ODCReasonID
      oRow.Cells.Add(oCol)
      oCol = New TableCell
      oCol.Text = ovrUnlinkedExecution.VR_ODCReasons16_Description
      oRow.Cells.Add(oCol)
      oTbl.Rows.Add(oRow)
    Next
    form1.Controls.Add(oTbl)
  End Sub
End Class
