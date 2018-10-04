Partial Class GF_vrSanctionExecutionApproval
	Inherits SIS.SYS.GridBase
	Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrExecutionApproval.aspx"
	Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		Dim oBut As ImageButton = CType(sender, ImageButton)
		Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
		Dim RedirectUrl As String = _InfoUrl & "?SRNNo=" & aVal(0)
		Response.Redirect(RedirectUrl)
	End Sub
	Protected Sub GVvrExecutionApproval_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrExecutionApproval.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SRNNo As Int32 = GVvrExecutionApproval.DataKeys(e.CommandArgument).Values("SRNNo")
				Dim RedirectUrl As String = TBLvrExecutionApproval.EditUrl & "?SRNNo=" & SRNNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "approvewf".ToLower Then
			Try
				Dim ApprovalRemarks As String = CType(GVvrExecutionApproval.Rows(e.CommandArgument).FindControl("F_ApprovalRemarks"), TextBox).Text
				Dim SRNNo As Int32 = GVvrExecutionApproval.DataKeys(e.CommandArgument).Values("SRNNo")
				SIS.VR.vrExecutionApproval.ApproveWF(SRNNo, ApprovalRemarks)
				GVvrExecutionApproval.DataBind()
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "rejectwf".ToLower Then
			Try
				Dim ApprovalRemarks As String = CType(GVvrExecutionApproval.Rows(e.CommandArgument).FindControl("F_ApprovalRemarks"), TextBox).Text
				Dim SRNNo As Int32 = GVvrExecutionApproval.DataKeys(e.CommandArgument).Values("SRNNo")
				SIS.VR.vrExecutionApproval.RejectWF(SRNNo, ApprovalRemarks)
				GVvrExecutionApproval.DataBind()
			Catch ex As Exception
			End Try
		End If
	End Sub
	Protected Sub GVvrExecutionApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrExecutionApproval.Init
		DataClassName = "GvrExecutionApproval"
		SetGridView = GVvrExecutionApproval
	End Sub
	Protected Sub TBLvrExecutionApproval_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrExecutionApproval.Init
		SetToolBar = TBLvrExecutionApproval
	End Sub
	Protected Sub F_TransporterID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_TransporterID.TextChanged
		Session("F_TransporterID") = F_TransporterID.Text
		Session("F_TransporterID_Display") = F_TransporterID_Display.Text
		InitGridPage()
	End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function TransporterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.VR.vrTransporters.SelectvrTransportersAutoCompleteList(prefixText, count, contextKey)
	End Function
	Protected Sub F_VehicleTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_VehicleTypeID.SelectedIndexChanged
		Session("F_VehicleTypeID") = F_VehicleTypeID.SelectedValue
		InitGridPage()
	End Sub
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		F_TransporterID_Display.Text = String.Empty
		If Not Session("F_TransporterID_Display") Is Nothing Then
			If Session("F_TransporterID_Display") <> String.Empty Then
				F_TransporterID_Display.Text = Session("F_TransporterID_Display")
			End If
		End If
		F_TransporterID.Text = String.Empty
		If Not Session("F_TransporterID") Is Nothing Then
			If Session("F_TransporterID") <> String.Empty Then
				F_TransporterID.Text = Session("F_TransporterID")
			End If
		End If
		Dim strScriptTransporterID As String = "<script type=""text/javascript""> " & _
		 "function ACETransporterID_Selected(sender, e) {" & _
		 "  var F_TransporterID = $get('" & F_TransporterID.ClientID & "');" & _
		 "  var F_TransporterID_Display = $get('" & F_TransporterID_Display.ClientID & "');" & _
		 "  var retval = e.get_value();" & _
		 "  var p = retval.split('|');" & _
		 "  F_TransporterID.value = p[0];" & _
		 "  F_TransporterID_Display.innerHTML = e.get_text();" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_TransporterID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_TransporterID", strScriptTransporterID)
		End If
		Dim strScriptPopulatingTransporterID As String = "<script type=""text/javascript""> " & _
		 "function ACETransporterID_Populating(o,e) {" & _
		 "  var p = $get('" & F_TransporterID.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
		 "  p.style.backgroundRepeat= 'no-repeat';" & _
		 "  p.style.backgroundPosition = 'right';" & _
		 "  o._contextKey = '';" & _
		 "}" & _
		 "function ACETransporterID_Populated(o,e) {" & _
		 "  var p = $get('" & F_TransporterID.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'none';" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_TransporterIDPopulating") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_TransporterIDPopulating", strScriptPopulatingTransporterID)
		End If
		F_VehicleTypeID.SelectedValue = String.Empty
		If Not Session("F_VehicleTypeID") Is Nothing Then
			If Session("F_VehicleTypeID") <> String.Empty Then
				F_VehicleTypeID.SelectedValue = Session("F_VehicleTypeID")
			End If
		End If
		Dim validateScriptTransporterID As String = "<script type=""text/javascript"">" & _
		 "  function validate_TransporterID(o) {" & _
		 "    validated_FK_VR_RequestExecution_TransporterID_main = true;" & _
		 "    validate_FK_VR_RequestExecution_TransporterID(o);" & _
		 "  }" & _
			"</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateTransporterID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateTransporterID", validateScriptTransporterID)
		End If
		Dim validateScriptFK_VR_RequestExecution_TransporterID As String = "<script type=""text/javascript"">" & _
		 "  function validate_FK_VR_RequestExecution_TransporterID(o) {" & _
		 "    var value = o.id;" & _
		 "    var TransporterID = $get('" & F_TransporterID.ClientID & "');" & _
		 "    try{" & _
		 "    if(TransporterID.value==''){" & _
		 "      if(validated_FK_VR_RequestExecution_TransporterID.main){" & _
		 "        var o_d = $get(o.id +'_Display');" & _
		 "        try{o_d.innerHTML = '';}catch(ex){}" & _
		 "      }" & _
		 "    }" & _
		 "    value = value + ',' + TransporterID.value ;" & _
		 "    }catch(ex){}" & _
		 "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
		 "    o.style.backgroundRepeat= 'no-repeat';" & _
		 "    o.style.backgroundPosition = 'right';" & _
		 "    PageMethods.validate_FK_VR_RequestExecution_TransporterID(value, validated_FK_VR_RequestExecution_TransporterID);" & _
		 "  }" & _
		 "  validated_FK_VR_RequestExecution_TransporterID_main = false;" & _
		 "  function validated_FK_VR_RequestExecution_TransporterID(result) {" & _
		 "    var p = result.split('|');" & _
		 "    var o = $get(p[1]);" & _
		 "    var o_d = $get(p[1]+'_Display');" & _
		 "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
		 "    o.style.backgroundImage  = 'none';" & _
		 "    if(p[0]=='1'){" & _
		 "      o.value='';" & _
		 "      try{o_d.innerHTML = '';}catch(ex){}" & _
		 "      __doPostBack(o.id, o.value);" & _
		 "    }" & _
		 "    else" & _
		 "      __doPostBack(o.id, o.value);" & _
		 "  }" & _
			"</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_RequestExecution_TransporterID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_RequestExecution_TransporterID", validateScriptFK_VR_RequestExecution_TransporterID)
		End If
	End Sub
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_VR_RequestExecution_TransporterID(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim TransporterID As String = CType(aVal(1), String)
		Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TransporterID)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function

End Class
