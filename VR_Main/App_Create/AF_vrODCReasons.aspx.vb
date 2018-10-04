Partial Class AF_vrODCReasons
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrODCReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrODCReasons.Init
    DataClassName = "AvrODCReasons"
    SetFormView = FVvrODCReasons
  End Sub
  Protected Sub TBLvrODCReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrODCReasons.Init
    SetToolBar = TBLvrODCReasons
  End Sub
  Protected Sub FVvrODCReasons_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrODCReasons.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrODCReasons.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrODCReasons") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrODCReasons", mStr)
    End If
    If Request.QueryString("ReasonID") IsNot Nothing Then
      CType(FVvrODCReasons.FindControl("F_ReasonID"), TextBox).Text = Request.QueryString("ReasonID")
      CType(FVvrODCReasons.FindControl("F_ReasonID"), TextBox).Enabled = False
    End If
  End Sub

End Class
