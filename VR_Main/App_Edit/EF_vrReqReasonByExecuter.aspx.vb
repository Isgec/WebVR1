Partial Class EF_vrReqReasonByExecuter
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrReqReasonByExecuter_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrReqReasonByExecuter.Init
    DataClassName = "EvrReqReasonByExecuter"
    SetFormView = FVvrReqReasonByExecuter
  End Sub
  Protected Sub TBLvrReqReasonByExecuter_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrReqReasonByExecuter.Init
    SetToolBar = TBLvrReqReasonByExecuter
  End Sub
  Protected Sub FVvrReqReasonByExecuter_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrReqReasonByExecuter.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrReqReasonByExecuter.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrReqReasonByExecuter") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrReqReasonByExecuter", mStr)
    End If
  End Sub

End Class
