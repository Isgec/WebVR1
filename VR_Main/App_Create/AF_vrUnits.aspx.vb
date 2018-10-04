Partial Class AF_vrUnits
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUnits.Init
    DataClassName = "AvrUnits"
    SetFormView = FVvrUnits
  End Sub
  Protected Sub TBLvrUnits_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrUnits.Init
    SetToolBar = TBLvrUnits
  End Sub
  Protected Sub FVvrUnits_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUnits.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrUnits.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrUnits") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrUnits", mStr)
    End If
    If Request.QueryString("UnitID") IsNot Nothing Then
      CType(FVvrUnits.FindControl("F_UnitID"), TextBox).Text = Request.QueryString("UnitID")
      CType(FVvrUnits.FindControl("F_UnitID"), TextBox).Enabled = False
    End If
  End Sub

End Class
