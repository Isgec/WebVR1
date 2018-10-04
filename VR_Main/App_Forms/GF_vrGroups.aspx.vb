Partial Class GF_vrGroups
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrGroups.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?GroupID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrGroups_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrGroups.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim GroupID As Int32 = GVvrGroups.DataKeys(e.CommandArgument).Values("GroupID")  
				Dim RedirectUrl As String = TBLvrGroups.EditUrl & "?GroupID=" & GroupID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrGroups.Init
    DataClassName = "GvrGroups"
    SetGridView = GVvrGroups
  End Sub
  Protected Sub TBLvrGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrGroups.Init
    SetToolBar = TBLvrGroups
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
