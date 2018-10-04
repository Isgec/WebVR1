Partial Class GF_vrVTDefault
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrVTDefault.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrVTDefault_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrVTDefault.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SerialNo As Int32 = GVvrVTDefault.DataKeys(e.CommandArgument).Values("SerialNo")  
				Dim RedirectUrl As String = TBLvrVTDefault.EditUrl & "?SerialNo=" & SerialNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrVTDefault_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrVTDefault.Init
    DataClassName = "GvrVTDefault"
    SetGridView = GVvrVTDefault
  End Sub
  Protected Sub TBLvrVTDefault_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrVTDefault.Init
    SetToolBar = TBLvrVTDefault
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
