Partial Class RP_vrLorryReceiptsD
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim ProjectID As String = CType(aVal(0), String)
    Dim MRNNo As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.VR.vrLorryReceiptsD = SIS.VR.vrLorryReceiptsD.vrLorryReceiptsDGetByID(ProjectID, MRNNo)
    Dim oTblvrLorryReceiptsD As New Table
    oTblvrLorryReceiptsD.Width = 1000
    oTblvrLorryReceiptsD.GridLines = GridLines.Both
    oTblvrLorryReceiptsD.Style.Add("margin-top", "15px")
    oTblvrLorryReceiptsD.Style.Add("margin-left", "10px")
    Dim oColvrLorryReceiptsD As TableCell = Nothing
    Dim oRowvrLorryReceiptsD As TableRow = Nothing
    oRowvrLorryReceiptsD = New TableRow
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Project"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.ProjectID
    oColvrLorryReceiptsD.Font.Size = "14"
    oColvrLorryReceiptsD.Font.Bold = True
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.IDM_Projects2_Description
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "MRN No"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.MRNNo
    oColvrLorryReceiptsD.Font.Size = "14"
    oColvrLorryReceiptsD.Font.Bold = True
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oTblvrLorryReceiptsD.Rows.Add(oRowvrLorryReceiptsD)
    oRowvrLorryReceiptsD = New TableRow
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Transporter"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.TransporterID
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.VR_Transporters7_TransporterName
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "MRN Date"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.MRNDate
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oTblvrLorryReceiptsD.Rows.Add(oRowvrLorryReceiptsD)
    oRowvrLorryReceiptsD = New TableRow
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Vehicle Type ID"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    'oColvrLorryReceiptsD = New TableCell
    'oColvrLorryReceiptsD.Text = oVar.VehicleTypeID
    'oColvrLorryReceiptsD.Style.Add("text-align", "right")
    'oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oColvrLorryReceiptsD.Text = oVar.VR_VehicleTypes8_cmba
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Vehicle Registration No"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.VehicleRegistrationNo
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oTblvrLorryReceiptsD.Rows.Add(oRowvrLorryReceiptsD)
    oRowvrLorryReceiptsD = New TableRow
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Vehicle In Time"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.VehicleInDate
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Vehicle Out Time"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.VehicleOutDate
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oTblvrLorryReceiptsD.Rows.Add(oRowvrLorryReceiptsD)
    oRowvrLorryReceiptsD = New TableRow
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Customer"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.CustomerID
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.VR_BusinessPartner3_BPName
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Way Bill Form No [Enter NA if NOT Applicable]"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.WayBillFormNo
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oTblvrLorryReceiptsD.Rows.Add(oRowvrLorryReceiptsD)
    oRowvrLorryReceiptsD = New TableRow
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Payment Made At Site"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = IIf(oVar.PaymentMadeAtSite, "YES", "NO")
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Amount Paid"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.AmountPaid
    oColvrLorryReceiptsD.Style.Add("text-align", "right")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oTblvrLorryReceiptsD.Rows.Add(oRowvrLorryReceiptsD)
    oRowvrLorryReceiptsD = New TableRow
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Other Vehicle Type"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.VehicleType
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Consignment Length [ in Ft. ]"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.VehicleLengthInFt
    oColvrLorryReceiptsD.Style.Add("text-align", "right")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oTblvrLorryReceiptsD.Rows.Add(oRowvrLorryReceiptsD)
    oRowvrLorryReceiptsD = New TableRow
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Consignment Width [ in Ft. ]"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.VechicleWidthInFt
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Consignment Height [ in Ft. ]"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.VehicleHeightInFt
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oTblvrLorryReceiptsD.Rows.Add(oRowvrLorryReceiptsD)
    oRowvrLorryReceiptsD = New TableRow
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Material State"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    'oColvrLorryReceiptsD = New TableCell
    'oColvrLorryReceiptsD.Text = oVar.MaterialStateID
    'oColvrLorryReceiptsD.Style.Add("text-align", "right")
    'oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oColvrLorryReceiptsD.Text = oVar.VR_MaterialStates5_Description
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Remarks For Damage Or Shortage"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.RemarksForDamageOrShortage
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oTblvrLorryReceiptsD.Rows.Add(oRowvrLorryReceiptsD)
    oRowvrLorryReceiptsD = New TableRow
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Over Dimension Consignment [ODC]"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.OverDimensionConsignment
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Detention At Site"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.DetentionAtSite
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oTblvrLorryReceiptsD.Rows.Add(oRowvrLorryReceiptsD)
    oRowvrLorryReceiptsD = New TableRow
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Reason For Detention"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.ReasonForDetention
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Other Remarks"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.OtherRemarks
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oTblvrLorryReceiptsD.Rows.Add(oRowvrLorryReceiptsD)

    oRowvrLorryReceiptsD = New TableRow
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Created/Uploaded By"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.FK_VR_LorryReceipts_CreatedBy.UserFullName
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = "Created/Uploaded On"
    oColvrLorryReceiptsD.Font.Bold = True
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oColvrLorryReceiptsD = New TableCell
    oColvrLorryReceiptsD.Text = oVar.CreatedOn
    oColvrLorryReceiptsD.Style.Add("text-align", "left")
    oColvrLorryReceiptsD.ColumnSpan = "2"
    oRowvrLorryReceiptsD.Cells.Add(oColvrLorryReceiptsD)
    oTblvrLorryReceiptsD.Rows.Add(oRowvrLorryReceiptsD)

    form1.Controls.Add(oTblvrLorryReceiptsD)
    Dim oTblvrLorryReceiptDetails As Table = Nothing
    Dim oRowvrLorryReceiptDetails As TableRow = Nothing
    Dim oColvrLorryReceiptDetails As TableCell = Nothing
    Dim ovrLorryReceiptDetailss As List(Of SIS.VR.vrLorryReceiptDetails) = SIS.VR.vrLorryReceiptDetails.vrLorryReceiptDetailsSelectList(0, 999, "", False, "", oVar.ProjectID, oVar.MRNNo)
    If ovrLorryReceiptDetailss.Count > 0 Then
      Dim oTblhvrLorryReceiptDetails As Table = New Table
      oTblhvrLorryReceiptDetails.Width = 1000
      oTblhvrLorryReceiptDetails.Style.Add("margin-top", "15px")
      oTblhvrLorryReceiptDetails.Style.Add("margin-left", "10px")
      oTblhvrLorryReceiptDetails.Style.Add("margin-right", "10px")
      Dim oRowhvrLorryReceiptDetails As TableRow = New TableRow
      Dim oColhvrLorryReceiptDetails As TableCell = New TableCell
      oColhvrLorryReceiptDetails.Font.Bold = True
      oColhvrLorryReceiptDetails.Font.Underline = True
      oColhvrLorryReceiptDetails.Font.Size = 10
      oColhvrLorryReceiptDetails.CssClass = "grpHD"
      oColhvrLorryReceiptDetails.Text = "Lorry Receipt Details"
      oRowhvrLorryReceiptDetails.Cells.Add(oColhvrLorryReceiptDetails)
      oTblhvrLorryReceiptDetails.Rows.Add(oRowhvrLorryReceiptDetails)
      form1.Controls.Add(oTblhvrLorryReceiptDetails)
      oTblvrLorryReceiptDetails = New Table
      oTblvrLorryReceiptDetails.Width = 1000
      oTblvrLorryReceiptDetails.GridLines = GridLines.Both
      oTblvrLorryReceiptDetails.Style.Add("margin-left", "10px")
      oTblvrLorryReceiptDetails.Style.Add("margin-right", "10px")
      oRowvrLorryReceiptDetails = New TableRow
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "Serial No"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "right")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "GR / LR No"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "left")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "GR / LR Date"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "center")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "Supplier ID"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "left")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "Supplier Invoice No"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "left")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "Supplier Invoice Date"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "center")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "Weight as per Invoice [KG]"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "right")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "Weight Received [KG]"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "right")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "MaterialForm"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "left")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "No. of Packages as per Invoice"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "right")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "No. of Packages Received"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "right")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "Cenvat Invoice Received"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "left")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Text = "Remarks"
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.CssClass = "colHD"
      oColvrLorryReceiptDetails.Style.Add("text-align", "left")
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oTblvrLorryReceiptDetails.Rows.Add(oRowvrLorryReceiptDetails)
      For Each ovrLorryReceiptDetails As SIS.VR.vrLorryReceiptDetails In ovrLorryReceiptDetailss
        oRowvrLorryReceiptDetails = New TableRow
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.SerialNo
        oColvrLorryReceiptDetails.Style.Add("text-align", "right")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.GRorLRNo
        oColvrLorryReceiptDetails.Style.Add("text-align", "left")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.GRorLRDate
        oColvrLorryReceiptDetails.Style.Add("text-align", "center")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.VR_BusinessPartner2_BPName
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Style.Add("text-align", "left")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.SupplierInvoiceNo
        oColvrLorryReceiptDetails.Style.Add("text-align", "left")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.SupplierInvoiceDate
        oColvrLorryReceiptDetails.Style.Add("text-align", "center")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.WeightAsPerInvoiceInKG
        oColvrLorryReceiptDetails.Style.Add("text-align", "right")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.WeightReceived
        oColvrLorryReceiptDetails.Style.Add("text-align", "right")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.MaterialForm
        oColvrLorryReceiptDetails.Style.Add("text-align", "left")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.NoOfPackagesAsPerInvoice
        oColvrLorryReceiptDetails.Style.Add("text-align", "right")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.NoOfPackagesReceived
        oColvrLorryReceiptDetails.Style.Add("text-align", "right")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.CenvatInvoiceReceived
        oColvrLorryReceiptDetails.Style.Add("text-align", "left")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oColvrLorryReceiptDetails = New TableCell
        oColvrLorryReceiptDetails.CssClass = "rowHD"
        oColvrLorryReceiptDetails.Text = ovrLorryReceiptDetails.Remarks
        oColvrLorryReceiptDetails.Style.Add("text-align", "left")
        oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
        oTblvrLorryReceiptDetails.Rows.Add(oRowvrLorryReceiptDetails)
      Next
      form1.Controls.Add(oTblvrLorryReceiptDetails)
    End If
  End Sub
End Class
