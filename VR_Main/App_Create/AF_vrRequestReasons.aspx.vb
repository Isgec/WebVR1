Partial Class AF_vrRequestReasons
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrRequestReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrRequestReasons.Init
    DataClassName = "AvrRequestReasons"
    SetFormView = FVvrRequestReasons
  End Sub
  Protected Sub TBLvrRequestReasons_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrRequestReasons.Init
    SetToolBar = TBLvrRequestReasons
  End Sub
  Protected Sub FVvrRequestReasons_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrRequestReasons.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrRequestReasons.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrRequestReasons") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrRequestReasons", mStr)
    End If
    If Request.QueryString("ReasonID") IsNot Nothing Then
      CType(FVvrRequestReasons.FindControl("F_ReasonID"), TextBox).Text = Request.QueryString("ReasonID")
      CType(FVvrRequestReasons.FindControl("F_ReasonID"), TextBox).Enabled = False
    End If
  End Sub

End Class
