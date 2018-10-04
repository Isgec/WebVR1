Partial Class RP_vrVehicleTypes
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrVehicleTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?VehicleTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim VehicleTypeID As Int32 = CType(aVal(0),Int32)
		Dim oVar As SIS.VR.vrVehicleTypes = SIS.VR.vrVehicleTypes.vrVehicleTypesGetByID(VehicleTypeID)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Vehicle Type ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VehicleTypeID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Description
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Define Capacity"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.DefineCapacity, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Capacity In KG"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.CapacityInKG
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Define Dimention"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.DefineDimention, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Height In Ft"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.HeightInFt
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Width In Ft"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.WidthInFt
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Length In Ft"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.LengthInFt
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Enforce Minimum Capacity"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.EnforceMinimumCapacity, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Minimum Capacity"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MinimumCapacity
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Enforce Maximum Capacity"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.EnforceMaximumCapacity, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Maximum Capacity"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MaximumCapacity
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Enforce Minimum Dimention"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.EnforceMinimumDimention, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Minimum Height"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MinimumHeight
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Minimum Width"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MinimumWidth
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Minimum Length"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MinimumLength
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Enforce Maximum Dimention"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.EnforceMaximumDimention, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Maximum Height"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MaximumHeight
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Maximum Width"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MaximumWidth
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Maximum Length"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MaximumLength
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    form1.Controls.Add(oTbl)
  End Sub
End Class
