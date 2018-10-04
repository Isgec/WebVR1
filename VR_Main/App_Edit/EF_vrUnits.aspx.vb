Partial Class EF_vrUnits
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUnits.Init
    DataClassName = "EvrUnits"
    SetFormView = FVvrUnits
  End Sub
  Protected Sub TBLvrUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrUnits.Init
    SetToolBar = TBLvrUnits
  End Sub
  Protected Sub FVvrUnits_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUnits.PreRender
		TBLvrUnits.PrintUrl &= Request.QueryString("UnitID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrUnits.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrUnits") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrUnits", mStr)
    End If
  End Sub

End Class
