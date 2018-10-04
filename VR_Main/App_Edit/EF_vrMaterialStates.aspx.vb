Partial Class EF_vrMaterialStates
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrMaterialStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrMaterialStates.Init
    DataClassName = "EvrMaterialStates"
    SetFormView = FVvrMaterialStates
  End Sub
  Protected Sub TBLvrMaterialStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrMaterialStates.Init
    SetToolBar = TBLvrMaterialStates
  End Sub
  Protected Sub FVvrMaterialStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrMaterialStates.PreRender
		TBLvrMaterialStates.PrintUrl &= Request.QueryString("MaterialStateID") & "|"
		Dim mStr As String = "<script type=""text/javascript""> "
		mStr = mStr & vbCrLf & " var script_vrMaterialStates = {"
		mStr = mStr & vbCrLf &	"temp: function() {"
		mStr = mStr & vbCrLf &	"}"
		mStr = mStr & vbCrLf &	"}"
		mStr = mStr & vbCrLf &	"</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrMaterialStates") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrMaterialStates", mStr)
		End If
  End Sub
End Class
