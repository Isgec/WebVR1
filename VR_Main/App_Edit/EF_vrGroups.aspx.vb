Partial Class EF_vrGroups
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrGroups.Init
    DataClassName = "EvrGroups"
    SetFormView = FVvrGroups
  End Sub
  Protected Sub TBLvrGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrGroups.Init
    SetToolBar = TBLvrGroups
  End Sub
  Protected Sub FVvrGroups_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrGroups.PreRender
		TBLvrGroups.PrintUrl &= Request.QueryString("GroupID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrGroups.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrGroups") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrGroups", mStr)
    End If
  End Sub

End Class
