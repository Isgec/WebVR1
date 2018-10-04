Partial Class EF_vrODCReasons
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrODCReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrODCReasons.Init
    DataClassName = "EvrODCReasons"
    SetFormView = FVvrODCReasons
  End Sub
  Protected Sub TBLvrODCReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrODCReasons.Init
    SetToolBar = TBLvrODCReasons
  End Sub
  Protected Sub FVvrODCReasons_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrODCReasons.PreRender
		TBLvrODCReasons.PrintUrl &= Request.QueryString("ReasonID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrODCReasons.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrODCReasons") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrODCReasons", mStr)
    End If
  End Sub

End Class
