Partial Class EF_vrRequestReasons
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrRequestReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrRequestReasons.Init
    DataClassName = "EvrRequestReasons"
    SetFormView = FVvrRequestReasons
  End Sub
  Protected Sub TBLvrRequestReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrRequestReasons.Init
    SetToolBar = TBLvrRequestReasons
  End Sub
  Protected Sub FVvrRequestReasons_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrRequestReasons.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrRequestReasons.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrRequestReasons") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrRequestReasons", mStr)
    End If
  End Sub

End Class
