Partial Class EF_vrUnlinkedExecution
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrUnlinkedExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUnlinkedExecution.Init
    DataClassName = "EvrUnlinkedExecution"
    SetFormView = FVvrUnlinkedExecution
  End Sub
  Protected Sub TBLvrUnlinkedExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrUnlinkedExecution.Init
    SetToolBar = TBLvrUnlinkedExecution
  End Sub
  Protected Sub FVvrUnlinkedExecution_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUnlinkedExecution.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrUnlinkedExecution.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrUnlinkedExecution") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrUnlinkedExecution", mStr)
    End If
  End Sub

End Class
