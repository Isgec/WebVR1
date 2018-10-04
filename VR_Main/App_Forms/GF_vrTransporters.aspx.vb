Partial Class GF_vrTransporters
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrTransporters.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?TransporterID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrTransporters_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrTransporters.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim TransporterID As String = GVvrTransporters.DataKeys(e.CommandArgument).Values("TransporterID")  
				Dim RedirectUrl As String = TBLvrTransporters.EditUrl & "?TransporterID=" & TransporterID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrTransporters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrTransporters.Init
    DataClassName = "GvrTransporters"
    SetGridView = GVvrTransporters
  End Sub
  Protected Sub TBLvrTransporters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrTransporters.Init
    SetToolBar = TBLvrTransporters
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
