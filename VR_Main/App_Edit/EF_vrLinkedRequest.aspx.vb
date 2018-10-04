Partial Class EF_vrLinkedRequest
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrLinkedRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLinkedRequest.Init
    DataClassName = "EvrLinkedRequest"
    SetFormView = FVvrLinkedRequest
  End Sub
  Protected Sub TBLvrLinkedRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLinkedRequest.Init
    SetToolBar = TBLvrLinkedRequest
  End Sub
  Protected Sub FVvrLinkedRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLinkedRequest.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrLinkedRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrLinkedRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrLinkedRequest", mStr)
    End If
  End Sub

End Class
