Partial Class GF_vrRequestStates
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrRequestStates.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?StatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrRequestStates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrRequestStates.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim StatusID As Int32 = GVvrRequestStates.DataKeys(e.CommandArgument).Values("StatusID")  
				Dim RedirectUrl As String = TBLvrRequestStates.EditUrl & "?StatusID=" & StatusID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrRequestStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrRequestStates.Init
    DataClassName = "GvrRequestStates"
    SetGridView = GVvrRequestStates
  End Sub
  Protected Sub TBLvrRequestStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrRequestStates.Init
    SetToolBar = TBLvrRequestStates
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
