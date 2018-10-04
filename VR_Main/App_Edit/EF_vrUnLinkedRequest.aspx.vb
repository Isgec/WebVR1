Partial Class EF_vrUnLinkedRequest
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrUnLinkedRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUnLinkedRequest.Init
    DataClassName = "EvrUnLinkedRequest"
    SetFormView = FVvrUnLinkedRequest
  End Sub
  Protected Sub TBLvrUnLinkedRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrUnLinkedRequest.Init
    SetToolBar = TBLvrUnLinkedRequest
  End Sub
  Protected Sub FVvrUnLinkedRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUnLinkedRequest.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrUnLinkedRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrUnLinkedRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrUnLinkedRequest", mStr)
    End If
  End Sub

End Class
