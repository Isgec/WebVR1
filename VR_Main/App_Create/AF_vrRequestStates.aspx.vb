Partial Class AF_vrRequestStates
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrRequestStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrRequestStates.Init
    DataClassName = "AvrRequestStates"
    SetFormView = FVvrRequestStates
  End Sub
  Protected Sub TBLvrRequestStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrRequestStates.Init
    SetToolBar = TBLvrRequestStates
  End Sub
  Protected Sub FVvrRequestStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrRequestStates.PreRender
		Dim mStr As String = "<script type=""text/javascript""> "
		mStr = mStr & vbCrLf & " var script_vrRequestStates = {"
		mStr = mStr & vbCrLf &	"temp: function() {"
		mStr = mStr & vbCrLf &	"}"
		mStr = mStr & vbCrLf &	"}"
		mStr = mStr & vbCrLf &	"</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrRequestStates") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrRequestStates", mStr)
		End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVvrRequestStates.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVvrRequestStates.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub
End Class
