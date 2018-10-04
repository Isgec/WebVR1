Partial Class EF_vrLinkedExecution
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrLinkedExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLinkedExecution.Init
    DataClassName = "EvrLinkedExecution"
    SetFormView = FVvrLinkedExecution
  End Sub
  Protected Sub TBLvrLinkedExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLinkedExecution.Init
    SetToolBar = TBLvrLinkedExecution
  End Sub
  Protected Sub FVvrLinkedExecution_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLinkedExecution.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrLinkedExecution.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrLinkedExecution") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrLinkedExecution", mStr)
    End If
  End Sub

End Class
