Partial Class GF_vrODCReasons
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrODCReasons.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ReasonID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrODCReasons_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrODCReasons.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim ReasonID As Int32 = GVvrODCReasons.DataKeys(e.CommandArgument).Values("ReasonID")  
				Dim RedirectUrl As String = TBLvrODCReasons.EditUrl & "?ReasonID=" & ReasonID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrODCReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrODCReasons.Init
    DataClassName = "GvrODCReasons"
    SetGridView = GVvrODCReasons
  End Sub
  Protected Sub TBLvrODCReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrODCReasons.Init
    SetToolBar = TBLvrODCReasons
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
