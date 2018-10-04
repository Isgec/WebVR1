Partial Class EF_vrExecutionAttachments
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrExecutionAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrExecutionAttachments.Init
    DataClassName = "EvrExecutionAttachments"
    SetFormView = FVvrExecutionAttachments
  End Sub
  Protected Sub TBLvrExecutionAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrExecutionAttachments.Init
    SetToolBar = TBLvrExecutionAttachments
  End Sub
  Protected Sub FVvrExecutionAttachments_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrExecutionAttachments.PreRender
		TBLvrExecutionAttachments.PrintUrl &= Request.QueryString("SRNNo") & "|"
		TBLvrExecutionAttachments.PrintUrl &= Request.QueryString("SerialNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrExecutionAttachments.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrExecutionAttachments") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrExecutionAttachments", mStr)
    End If
  End Sub

End Class
