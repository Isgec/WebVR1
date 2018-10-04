Partial Class GF_vrRequestReasons
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrRequestReasons.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ReasonID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrRequestReasons_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrRequestReasons.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim ReasonID As Int32 = GVvrRequestReasons.DataKeys(e.CommandArgument).Values("ReasonID")  
				Dim RedirectUrl As String = TBLvrRequestReasons.EditUrl & "?ReasonID=" & ReasonID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrRequestReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrRequestReasons.Init
    DataClassName = "GvrRequestReasons"
    SetGridView = GVvrRequestReasons
  End Sub
  Protected Sub TBLvrRequestReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrRequestReasons.Init
    SetToolBar = TBLvrRequestReasons
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
