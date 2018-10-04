Partial Class EF_vrTransporterBill
  Inherits SIS.SYS.UpdateBase
	Public Property DisableDelete() As Boolean
		Get
			If ViewState("DisableDelete") IsNot Nothing Then
				Return Convert.ToBoolean(ViewState("DisableDelete"))
			Else
				Return True
			End If
		End Get
		Set(ByVal value As Boolean)
			ViewState.Add("DisableDelete", value)
		End Set
	End Property
	Public Property DisableLinking() As Boolean
		Get
			If ViewState("DisableLinking") IsNot Nothing Then
				Return Convert.ToBoolean(ViewState("DisableLinking"))
			Else
				Return True
			End If
		End Get
		Set(ByVal value As Boolean)
			ViewState.Add("DisableLinking", value)
		End Set
	End Property
	Protected Sub FVvrTransporterBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrTransporterBill.Init
		DataClassName = "EvrTransporterBill"
		SetFormView = FVvrTransporterBill
	End Sub
  Protected Sub TBLvrTransporterBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrTransporterBill.Init
    SetToolBar = TBLvrTransporterBill
  End Sub
  Protected Sub FVvrTransporterBill_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrTransporterBill.PreRender
		TBLvrTransporterBill.PrintUrl &= Request.QueryString("IRNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrTransporterBill.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrTransporterBill") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrTransporterBill", mStr)
    End If
		TBLvrTransporterBill.EnableDelete = DisableDelete
		Dim oPnl As Panel = FVvrTransporterBill.FindControl("tmpPnl")
		oPnl.Visible = DisableLinking
	End Sub
  Partial Class gvBase
		Inherits SIS.SYS.psGridBase
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
				GVvrUnlinkedExecution.DataBind()
				GVvrLinkedExecution.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub
  Private WithEvents gvvrUnlinkedExecutionCC As New gvBase
  Protected Sub GVvrUnlinkedExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrUnlinkedExecution.Init
		gvvrUnlinkedExecutionCC.DataClassName = "GvrUnlinkedExecution"
		gvvrUnlinkedExecutionCC.SetGridView = GVvrUnlinkedExecution
  End Sub
  Protected Sub TBLvrUnlinkedExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrUnlinkedExecution.Init
		gvvrUnlinkedExecutionCC.SetToolBar = TBLvrUnlinkedExecution
  End Sub
  Protected Sub GVvrUnlinkedExecution_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrUnlinkedExecution.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SRNNo As Int32 = GVvrUnlinkedExecution.DataKeys(e.CommandArgument).Values("SRNNo")  
				Dim RedirectUrl As String = TBLvrUnlinkedExecution.EditUrl & "?SRNNo=" & SRNNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "approvewf".ToLower Then
			Try
				Dim IRNo As Int32 = FVvrTransporterBill.DataKey("IRNo")
				Dim SRNNo As Int32 = GVvrUnlinkedExecution.DataKeys(e.CommandArgument).Values("SRNNo")
				SIS.VR.vrUnlinkedExecution.ApproveWF(SRNNo, IRNo)
				GVvrUnlinkedExecution.DataBind()
				GVvrLinkedExecution.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub

	Protected Sub ODSvrTransporterBill_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrTransporterBill.Selected
		Dim oTB As SIS.VR.vrTransporterBill = CType(e.ReturnValue, SIS.VR.vrTransporterBill)
		If oTB.BillStatusID >= BillStatus.ExecutionLinked Then
			DisableDelete = False
		Else
			DisableDelete = True
		End If
		If oTB.ForwardedToAccount Then
			DisableLinking = False
		Else
			DisableLinking = True
		End If
	End Sub
End Class
