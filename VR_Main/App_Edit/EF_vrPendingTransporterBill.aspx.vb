Partial Class EF_vrPendingTransporterBill
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrPendingTransporterBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrPendingTransporterBill.Init
    DataClassName = "EvrPendingTransporterBill"
    SetFormView = FVvrPendingTransporterBill
  End Sub
  Protected Sub TBLvrPendingTransporterBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrPendingTransporterBill.Init
    SetToolBar = TBLvrPendingTransporterBill
  End Sub
  Protected Sub FVvrPendingTransporterBill_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrPendingTransporterBill.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrPendingTransporterBill.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrPendingTransporterBill") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrPendingTransporterBill", mStr)
    End If
  End Sub
  Partial Class gvBase
		Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvvrLinkedExecutionCC As New gvBase
  Protected Sub GVvrLinkedExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrLinkedExecution.Init
		gvvrLinkedExecutionCC.DataClassName = "GvrLinkedExecution"
		gvvrLinkedExecutionCC.SetGridView = GVvrLinkedExecution
  End Sub
  Protected Sub TBLvrLinkedExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLinkedExecution.Init
		gvvrLinkedExecutionCC.SetToolBar = TBLvrLinkedExecution
  End Sub
  Protected Sub GVvrLinkedExecution_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrLinkedExecution.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SRNNo As Int32 = GVvrLinkedExecution.DataKeys(e.CommandArgument).Values("SRNNo")  
				Dim RedirectUrl As String = TBLvrLinkedExecution.EditUrl & "?SRNNo=" & SRNNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "rejectwf".ToLower Then
			Try
				Dim SRNNo As Int32 = GVvrLinkedExecution.DataKeys(e.CommandArgument).Values("SRNNo")  
				SIS.VR.vrLinkedExecution.RejectWF(SRNNo)
				GVvrLinkedExecution.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub

End Class
