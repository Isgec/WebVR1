Partial Class EF_vrVTDefault
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrVTDefault_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrVTDefault.Init
    DataClassName = "EvrVTDefault"
    SetFormView = FVvrVTDefault
  End Sub
  Protected Sub TBLvrVTDefault_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrVTDefault.Init
    SetToolBar = TBLvrVTDefault
  End Sub
  Protected Sub FVvrVTDefault_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrVTDefault.PreRender
		TBLvrVTDefault.PrintUrl &= Request.QueryString("SerialNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrVTDefault.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrVTDefault") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrVTDefault", mStr)
    End If
  End Sub

End Class
