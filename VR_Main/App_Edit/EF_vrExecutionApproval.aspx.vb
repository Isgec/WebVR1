Partial Class EF_vrExecutionApproval
	Inherits SIS.SYS.UpdateBase
	Public Property Editable() As Boolean
		Get
			Return True
			If ViewState("Editable") IsNot Nothing Then
				Return CType(ViewState("Editable"), Boolean)
			End If
		End Get
		Set(ByVal value As Boolean)
			ViewState.Add("Editable", value)
		End Set
	End Property
	Protected Sub FVvrExecutionApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrExecutionApproval.Init
		DataClassName = "EvrExecutionApproval"
		SetFormView = FVvrExecutionApproval
	End Sub
  Protected Sub TBLvrExecutionApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrExecutionApproval.Init
    SetToolBar = TBLvrExecutionApproval
  End Sub
  Protected Sub FVvrExecutionApproval_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrExecutionApproval.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrExecutionApproval.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrExecutionApproval") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrExecutionApproval", mStr)
    End If
  End Sub
  Partial Class gvBase
		Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvvrLinkedRequestCC As New gvBase
  Protected Sub GVvrLinkedRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrLinkedRequest.Init
		gvvrLinkedRequestCC.DataClassName = "GvrLinkedRequest"
		gvvrLinkedRequestCC.SetGridView = GVvrLinkedRequest
  End Sub
  Protected Sub TBLvrLinkedRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLinkedRequest.Init
		gvvrLinkedRequestCC.SetToolBar = TBLvrLinkedRequest
  End Sub
  Protected Sub GVvrLinkedRequest_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrLinkedRequest.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim RequestNo As Int32 = GVvrLinkedRequest.DataKeys(e.CommandArgument).Values("RequestNo")  
				Dim RedirectUrl As String = TBLvrLinkedRequest.EditUrl & "?RequestNo=" & RequestNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "rejectwf".ToLower Then
			Try
				Dim RequestNo As Int32 = GVvrLinkedRequest.DataKeys(e.CommandArgument).Values("RequestNo")  
				SIS.VR.vrLinkedRequest.RejectWF(RequestNo)
				GVvrLinkedRequest.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub

End Class
