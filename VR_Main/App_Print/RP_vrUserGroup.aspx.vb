Partial Class RP_vrUserGroup
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrUserGroup.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim SerialNo As Int32 = CType(aVal(0),Int32)
		Dim oVar As SIS.VR.vrUserGroup = SIS.VR.vrUserGroup.vrUserGroupGetByID(SerialNo)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Serial No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SerialNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "User ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.UserID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users1_UserFullName
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Group ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.GroupID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.VR_Groups2_GroupName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Role ID"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.RoleID
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Out Of Contract Approver"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.OutOfContractApprover, "YES", "NO")
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
