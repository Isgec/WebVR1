Partial Class AF_vrGroups
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrGroups.Init
    DataClassName = "AvrGroups"
    SetFormView = FVvrGroups
  End Sub
  Protected Sub TBLvrGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrGroups.Init
    SetToolBar = TBLvrGroups
  End Sub
  Protected Sub FVvrGroups_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrGroups.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrGroups.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrGroups") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrGroups", mStr)
    End If
    If Request.QueryString("GroupID") IsNot Nothing Then
      CType(FVvrGroups.FindControl("F_GroupID"), TextBox).Text = Request.QueryString("GroupID")
      CType(FVvrGroups.FindControl("F_GroupID"), TextBox).Enabled = False
    End If
  End Sub

End Class
