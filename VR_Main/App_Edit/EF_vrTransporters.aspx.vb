Partial Class EF_vrTransporters
	Inherits SIS.SYS.UpdateBase
	Protected Sub FVvrTransporters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrTransporters.Init
		DataClassName = "EvrTransporters"
		SetFormView = FVvrTransporters
	End Sub
  Protected Sub TBLvrTransporters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrTransporters.Init
    SetToolBar = TBLvrTransporters
  End Sub
  Protected Sub FVvrTransporters_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrTransporters.PreRender
		TBLvrTransporters.PrintUrl &= Request.QueryString("TransporterID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrTransporters.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrTransporters") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrTransporters", mStr)
		End If
	End Sub
End Class
