Partial Class RP_vrTransporters
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrTransporters.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?TransporterID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim TransporterID As String = CType(aVal(0),String)
		Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TransporterID)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Transporter ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TransporterID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Transporter Name"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.TransporterName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Address Line [1]"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Address1Line
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Address Line [2]"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.Address2Line
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "City"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.City
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "EMail ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.EMailID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    form1.Controls.Add(oTbl)
  End Sub
End Class
