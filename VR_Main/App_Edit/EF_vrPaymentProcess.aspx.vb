Partial Class EF_vrPaymentProcess
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrPaymentProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrPaymentProcess.Init
    DataClassName = "EvrPaymentProcess"
    SetFormView = FVvrPaymentProcess
  End Sub
  Protected Sub TBLvrPaymentProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrPaymentProcess.Init
    SetToolBar = TBLvrPaymentProcess
  End Sub
  Protected Sub FVvrPaymentProcess_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrPaymentProcess.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrPaymentProcess.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrPaymentProcess") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrPaymentProcess", mStr)
    End If
  End Sub

End Class
