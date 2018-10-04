Partial Class AF_vrVTDefault
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrVTDefault_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrVTDefault.Init
    DataClassName = "AvrVTDefault"
    SetFormView = FVvrVTDefault
  End Sub
  Protected Sub TBLvrVTDefault_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrVTDefault.Init
    SetToolBar = TBLvrVTDefault
  End Sub
  Protected Sub FVvrVTDefault_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrVTDefault.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrVTDefault.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrVTDefault") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrVTDefault", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVvrVTDefault.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVvrVTDefault.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub

End Class
