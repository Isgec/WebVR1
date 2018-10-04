Partial Class EF_vrSanctionAlert
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrSanctionAlert_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrSanctionAlert.Init
    DataClassName = "EvrSanctionAlert"
    SetFormView = FVvrSanctionAlert
  End Sub
  Protected Sub TBLvrSanctionAlert_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrSanctionAlert.Init
    SetToolBar = TBLvrSanctionAlert
  End Sub
  Protected Sub FVvrSanctionAlert_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrSanctionAlert.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrSanctionAlert.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrSanctionAlert") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrSanctionAlert", mStr)
    End If
  End Sub

End Class
