Partial Class RP_vrVTDefault
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrVTDefault.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim SerialNo As Int32 = CType(aVal(0),Int32)
		Dim oVar As SIS.VR.vrVTDefault = SIS.VR.vrVTDefault.vrVTDefaultGetByID(SerialNo)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "SerialNo"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SerialNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Minimum Capacity Percentage"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MinimumCapacityPercentage
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Maximum Capacity Percentage"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MaximumCapacityPercentage
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Minimum Height Percentage"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MinimumHeightPercentage
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Minimum Width Percentage"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MinimumWidthPercentage
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Minimum Length Percentage"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MinimumLengthPercentage
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Maximum Height Percentage"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MaximumHeightPercentage
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Maximum Width Percentage"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MaximumWidthPercentage
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Maximum Length Percentage"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.MaximumLengthPercentage
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
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
