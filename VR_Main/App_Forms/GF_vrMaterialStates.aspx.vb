Partial Class GF_vrMaterialStates
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrMaterialStates.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?MaterialStateID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrMaterialStates_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrMaterialStates.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim MaterialStateID As Int32 = GVvrMaterialStates.DataKeys(e.CommandArgument).Values("MaterialStateID")  
				Dim RedirectUrl As String = TBLvrMaterialStates.EditUrl & "?MaterialStateID=" & MaterialStateID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrMaterialStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrMaterialStates.Init
    DataClassName = "GvrMaterialStates"
    SetGridView = GVvrMaterialStates
  End Sub
  Protected Sub TBLvrMaterialStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrMaterialStates.Init
    SetToolBar = TBLvrMaterialStates
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
