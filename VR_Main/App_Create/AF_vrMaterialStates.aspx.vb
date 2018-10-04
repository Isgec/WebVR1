Partial Class AF_vrMaterialStates
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrMaterialStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrMaterialStates.Init
    DataClassName = "AvrMaterialStates"
    SetFormView = FVvrMaterialStates
  End Sub
  Protected Sub TBLvrMaterialStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrMaterialStates.Init
    SetToolBar = TBLvrMaterialStates
  End Sub
  Protected Sub FVvrMaterialStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrMaterialStates.PreRender
		Dim mStr As String = "<script type=""text/javascript""> "
		mStr = mStr & vbCrLf & " var script_vrMaterialStates = {"
		mStr = mStr & vbCrLf &	"temp: function() {"
		mStr = mStr & vbCrLf &	"}"
		mStr = mStr & vbCrLf &	"}"
		mStr = mStr & vbCrLf &	"</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrMaterialStates") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrMaterialStates", mStr)
		End If
    If Request.QueryString("MaterialStateID") IsNot Nothing Then
      CType(FVvrMaterialStates.FindControl("F_MaterialStateID"), TextBox).Text = Request.QueryString("MaterialStateID")
      CType(FVvrMaterialStates.FindControl("F_MaterialStateID"), TextBox).Enabled = False
    End If
  End Sub
End Class
