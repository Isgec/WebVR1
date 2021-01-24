Partial Class RP_vrLorryReceipts
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
    Dim ProjectID As String = CType(aVal(0), String)
    Dim MRNNo As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.VR.vrLorryReceipts = SIS.VR.vrLorryReceipts.vrLorryReceiptsGetByID(ProjectID, MRNNo)
    Dim oTbl As New Table
    oTbl.Width = 1000
    oTbl.GridLines = GridLines.Both
    'oTbl.Style.Add("margin-top", "15px")
    'oTbl.Style.Add("margin-left", "30px")
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Project"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProjectID
    oCol.Font.Size = "14"
    oCol.Font.Bold = True
    oCol.Style.Add("text-align", "left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.IDM_Projects2_Description
    oCol.Style.Add("text-align", "left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "MRN No"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MRNNo
    oCol.Font.Size = "14"
    oCol.Font.Bold = True
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Transporter"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TransporterID
    oCol.Style.Add("text-align", "left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_Transporters7_TransporterName
    oCol.Style.Add("text-align", "left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "MRN Date"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MRNDate
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Vehicle Type ID"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = oVar.VehicleTypeID
    'oCol.Style.Add("text-align", "right")
    'oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.ColumnSpan = "2"
    oCol.Text = oVar.VR_VehicleTypes8_cmba
    oCol.Style.Add("text-align", "left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Registration No"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VehicleRegistrationNo
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Vehicle In Time"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VehicleInDate
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Out Time"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VehicleOutDate
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Customer"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CustomerID
    oCol.Style.Add("text-align", "left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_BusinessPartner3_BPName
    oCol.Style.Add("text-align", "left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Way Bill Form No [Enter NA if NOT Applicable]"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.WayBillFormNo
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Payment Made At Site"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.PaymentMadeAtSite, "YES", "NO")
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Amount Paid"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.AmountPaid
    oCol.Style.Add("text-align", "right")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Other Vehicle Type"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VehicleType
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Length [ in Ft. ]"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VehicleLengthInFt
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Vehicle Width [ in Ft. ]"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VechicleWidthInFt
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Vehicle Height [ in Ft. ]"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VehicleHeightInFt
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Material State"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    'oCol = New TableCell
    'oCol.Text = oVar.MaterialStateID
    'oCol.Style.Add("text-align", "right")
    'oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.ColumnSpan = "2"
    oCol.Text = oVar.VR_MaterialStates5_Description
    oCol.Style.Add("text-align", "left")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Remarks For Damage Or Shortage"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RemarksForDamageOrShortage
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Over Dimension Consignment [ODC]"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.OverDimensionConsignment
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Detention At Site"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.DetentionAtSite
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Reason For Detention"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ReasonForDetention
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Other Remarks"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.OtherRemarks
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)

    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Created/Uploaded By"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.FK_VR_LorryReceipts_CreatedBy.UserFullName
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Created/Uploaded On"
    oCol.Font.Bold = True
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CreatedOn
    oCol.Style.Add("text-align", "left")
    oCol.ColumnSpan = "2"
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)

    form1.Controls.Add(oTbl)
    Dim oTblvrLorryReceiptDetails As Table = Nothing
    Dim oRowvrLorryReceiptDetails As TableRow = Nothing
    Dim oColvrLorryReceiptDetails As TableCell = Nothing
    Dim ovrLorryReceiptDetailss As List(Of SIS.VR.vrLorryReceiptDetails) = SIS.VR.vrLorryReceiptDetails.vrLorryReceiptDetailsSelectList(0, 999, "", False, "", oVar.ProjectID, oVar.MRNNo)
    If ovrLorryReceiptDetailss.Count > 0 Then
      oTblvrLorryReceiptDetails = New Table
      oTblvrLorryReceiptDetails.Width = 1000
      oTblvrLorryReceiptDetails.Style.Add("margin-top", "15px")
      'oTblvrLorryReceiptDetails.Style.Add("margin-left", "10px")
      'oTblvrLorryReceiptDetails.Style.Add("margin-right", "10px")
      oRowvrLorryReceiptDetails = New TableRow
      oColvrLorryReceiptDetails = New TableCell
      oColvrLorryReceiptDetails.Font.Bold = True
      oColvrLorryReceiptDetails.Font.Underline = True
      oColvrLorryReceiptDetails.Font.Size = 10
      oColvrLorryReceiptDetails.CssClass = "grpHD"
      oColvrLorryReceiptDetails.Text = "Lorry Receipt Details"
      oRowvrLorryReceiptDetails.Cells.Add(oColvrLorryReceiptDetails)
      oTblvrLorryReceiptDetails.Rows.Add(oRowvrLorryReceiptDetails)
      form1.Controls.Add(oTblvrLorryReceiptDetails)
      oTblvrLorryReceiptDetails = New Table
      oTblvrLorryReceiptDetails.Width = 1000
      oTblvrLorryReceiptDetails.GridLines = GridLines.Both
      'oTblvrLorryReceiptDetails.Style.Add("margin-left", "10px")
      'oTblvrLorryReceiptDetails.Style.Add("margin-right", "10px")
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
