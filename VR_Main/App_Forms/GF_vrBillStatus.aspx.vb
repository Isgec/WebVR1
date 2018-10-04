Partial Class GF_vrBillStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrBillStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?BillStatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrBillStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrBillStatus.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim BillStatusID As Int32 = GVvrBillStatus.DataKeys(e.CommandArgument).Values("BillStatusID")  
				Dim RedirectUrl As String = TBLvrBillStatus.EditUrl & "?BillStatusID=" & BillStatusID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrBillStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrBillStatus.Init
    DataClassName = "GvrBillStatus"
    SetGridView = GVvrBillStatus
  End Sub
  Protected Sub TBLvrBillStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrBillStatus.Init
    SetToolBar = TBLvrBillStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
