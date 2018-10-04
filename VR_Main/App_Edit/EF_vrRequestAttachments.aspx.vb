Partial Class EF_vrRequestAttachments
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrRequestAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrRequestAttachments.Init
    DataClassName = "EvrRequestAttachments"
    SetFormView = FVvrRequestAttachments
  End Sub
  Protected Sub TBLvrRequestAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrRequestAttachments.Init
    SetToolBar = TBLvrRequestAttachments
  End Sub
  Protected Sub FVvrRequestAttachments_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrRequestAttachments.PreRender
		TBLvrRequestAttachments.PrintUrl &= Request.QueryString("RequestNo") & "|"
		TBLvrRequestAttachments.PrintUrl &= Request.QueryString("SerialNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrRequestAttachments.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrRequestAttachments") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrRequestAttachments", mStr)
    End If
  End Sub

End Class
