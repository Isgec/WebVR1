Partial Class GF_vrVRDisplay
	Inherits SIS.SYS.GridBase
	Protected Sub GVvrVehicleRequest_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrVehicleRequest.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim RequestNo As Int32 = GVvrVehicleRequest.DataKeys(e.CommandArgument).Values("RequestNo")
				Dim RedirectUrl As String = TBLvrVehicleRequest.EditUrl & "?RequestNo=" & RequestNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "lgcopy".ToLower Then
			Try
				Dim RequestNo As Int32 = GVvrVehicleRequest.DataKeys(e.CommandArgument).Values("RequestNo")
				Dim oVR As SIS.VR.vrVehicleRequest = SIS.VR.vrVehicleRequest.vrVehicleRequestGetByID(RequestNo)
				With oVR
					.RequestNo = 0
					.RequestedBy = HttpContext.Current.Session("LoginID")
					.RequestedOn = Now
					.RequestStatus = RequestStates.Free
					.ReturnedBy = ""
					.ReturnedOn = ""
					.ReturnRemarks = ""
					.SRNNo = ""
					.VehicleRequiredOn = ""
				End With
				oVR = SIS.VR.vrVehicleRequest.InsertData(oVR)
				RequestNo = oVR.RequestNo
				Dim RedirectUrl As String = TBLvrVehicleRequest.EditUrl & "?RequestNo=" & RequestNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "initiatewf".ToLower Then
			Try
				Dim RequestNo As Int32 = GVvrVehicleRequest.DataKeys(e.CommandArgument).Values("RequestNo")
				Dim Err As Boolean = False
				Dim oRq As SIS.VR.vrVehicleRequest = SIS.VR.vrVehicleRequest.vrVehicleRequestGetByID(RequestNo)
				If oRq.ProjectType.ToUpper = "DOMESTIC" Then
					'If Not oRq.MICN Or Not oRq.DIIssued Or Not oRq.WayBill Then
					If Not oRq.MICN Or Not oRq.DIIssued Then
						Err = True
						'LabelErrMsg.Text = "In DOMESTIC Projects MICN, DI must be Issued and Way Bill mus be received. Can not forward request."
						LabelErrMsg.Text = "In DOMESTIC Projects MICN and DI must be Issued. Can not forward request."
					End If
				Else
					If Not oRq.MICN Or Not oRq.CustomInvoiceIssued Or Not oRq.CT1Issued Or Not oRq.ARE1Issued Or Not oRq.DIIssued Then
						Err = True
						LabelErrMsg.Text = "In EXPORT Projects MICN, Custom Invoice, CT-1, ARE-1  and DI must be issued. Can not forward request."
					End If
				End If
				If Not Err Then
					SIS.VR.vrVehicleRequest.InitiateWF(RequestNo)
					GVvrVehicleRequest.DataBind()
				End If
			Catch ex As Exception
			End Try
		End If
	End Sub
	Protected Sub GVvrVehicleRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrVehicleRequest.Init
		DataClassName = "GvrVehicleRequest"
		SetGridView = GVvrVehicleRequest
	End Sub
	Protected Sub TBLvrVehicleRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrVehicleRequest.Init
		SetToolBar = TBLvrVehicleRequest
	End Sub
	Protected Sub F_SupplierID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SupplierID.TextChanged
		Session("F_SupplierID") = F_SupplierID.Text
		Session("F_SupplierID_Display") = F_SupplierID_Display.Text
		InitGridPage()
	End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.QCM.qcmVendors.SelectqcmVendorsAutoCompleteList(prefixText, count, contextKey)
	End Function
	Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
		Session("F_ProjectID") = F_ProjectID.Text
		Session("F_ProjectID_Display") = F_ProjectID_Display.Text
		InitGridPage()
	End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
	End Function
	Protected Sub F_RequestStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RequestStatus.SelectedIndexChanged
		Session("F_RequestStatus") = F_RequestStatus.SelectedValue
		InitGridPage()
	End Sub
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
		F_SupplierID_Display.Text = String.Empty
		If Not Session("F_SupplierID_Display") Is Nothing Then
			If Session("F_SupplierID_Display") <> String.Empty Then
				F_SupplierID_Display.Text = Session("F_SupplierID_Display")
			End If
		End If
		F_SupplierID.Text = String.Empty
		If Not Session("F_SupplierID") Is Nothing Then
			If Session("F_SupplierID") <> String.Empty Then
				F_SupplierID.Text = Session("F_SupplierID")
			End If
		End If
		Dim strScriptSupplierID As String = "<script type=""text/javascript""> " & _
		 "function ACESupplierID_Selected(sender, e) {" & _
		 "  var F_SupplierID = $get('" & F_SupplierID.ClientID & "');" & _
		 "  var F_SupplierID_Display = $get('" & F_SupplierID_Display.ClientID & "');" & _
		 "  var retval = e.get_value();" & _
		 "  var p = retval.split('|');" & _
		 "  F_SupplierID.value = p[0];" & _
		 "  F_SupplierID_Display.innerHTML = e.get_text();" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SupplierID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SupplierID", strScriptSupplierID)
		End If
		Dim strScriptPopulatingSupplierID As String = "<script type=""text/javascript""> " & _
		 "function ACESupplierID_Populating(o,e) {" & _
		 "  var p = $get('" & F_SupplierID.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
		 "  p.style.backgroundRepeat= 'no-repeat';" & _
		 "  p.style.backgroundPosition = 'right';" & _
		 "  o._contextKey = '';" & _
		 "}" & _
		 "function ACESupplierID_Populated(o,e) {" & _
		 "  var p = $get('" & F_SupplierID.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'none';" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SupplierIDPopulating") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SupplierIDPopulating", strScriptPopulatingSupplierID)
		End If
		F_ProjectID_Display.Text = String.Empty
		If Not Session("F_ProjectID_Display") Is Nothing Then
			If Session("F_ProjectID_Display") <> String.Empty Then
				F_ProjectID_Display.Text = Session("F_ProjectID_Display")
			End If
		End If
		F_ProjectID.Text = String.Empty
		If Not Session("F_ProjectID") Is Nothing Then
			If Session("F_ProjectID") <> String.Empty Then
				F_ProjectID.Text = Session("F_ProjectID")
			End If
		End If
		Dim strScriptProjectID As String = "<script type=""text/javascript""> " & _
		 "function ACEProjectID_Selected(sender, e) {" & _
		 "  var F_ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
		 "  var F_ProjectID_Display = $get('" & F_ProjectID_Display.ClientID & "');" & _
		 "  var retval = e.get_value();" & _
		 "  var p = retval.split('|');" & _
		 "  F_ProjectID.value = p[0];" & _
		 "  F_ProjectID_Display.innerHTML = e.get_text();" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectID", strScriptProjectID)
		End If
		Dim strScriptPopulatingProjectID As String = "<script type=""text/javascript""> " & _
		 "function ACEProjectID_Populating(o,e) {" & _
		 "  var p = $get('" & F_ProjectID.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
		 "  p.style.backgroundRepeat= 'no-repeat';" & _
		 "  p.style.backgroundPosition = 'right';" & _
		 "  o._contextKey = '';" & _
		 "}" & _
		 "function ACEProjectID_Populated(o,e) {" & _
		 "  var p = $get('" & F_ProjectID.ClientID & "');" & _
		 "  p.style.backgroundImage  = 'none';" & _
		 "}" & _
		 "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectIDPopulating") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectIDPopulating", strScriptPopulatingProjectID)
		End If
		F_RequestStatus.SelectedValue = String.Empty
		If Not Session("F_RequestStatus") Is Nothing Then
			If Session("F_RequestStatus") <> String.Empty Then
				F_RequestStatus.SelectedValue = Session("F_RequestStatus")
			End If
		End If
		Dim validateScriptSupplierID As String = "<script type=""text/javascript"">" & _
		 "  function validate_SupplierID(o) {" & _
		 "    validated_FK_VR_VehicleRequest_SupplierID_main = true;" & _
		 "    validate_FK_VR_VehicleRequest_SupplierID(o);" & _
		 "  }" & _
			"</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSupplierID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSupplierID", validateScriptSupplierID)
		End If
		Dim validateScriptProjectID As String = "<script type=""text/javascript"">" & _
		 "  function validate_ProjectID(o) {" & _
		 "    validated_FK_VR_VehicleRequest_ProjectID_main = true;" & _
		 "    validate_FK_VR_VehicleRequest_ProjectID(o);" & _
		 "  }" & _
			"</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
		End If
		Dim validateScriptRequestStatus As String = "<script type=""text/javascript"">" & _
		 "  function validate_RequestStatus(o) {" & _
		 "  }" & _
			"</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateRequestStatus") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateRequestStatus", validateScriptRequestStatus)
		End If
		Dim validateScriptFK_VR_VehicleRequest_ProjectID As String = "<script type=""text/javascript"">" & _
		 "  function validate_FK_VR_VehicleRequest_ProjectID(o) {" & _
		 "    var value = o.id;" & _
		 "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
		 "    try{" & _
		 "    if(ProjectID.value==''){" & _
		 "      if(validated_FK_VR_VehicleRequest_ProjectID.main){" & _
		 "        var o_d = $get(o.id +'_Display');" & _
		 "        try{o_d.innerHTML = '';}catch(ex){}" & _
		 "      }" & _
		 "    }" & _
		 "    value = value + ',' + ProjectID.value ;" & _
		 "    }catch(ex){}" & _
		 "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
		 "    o.style.backgroundRepeat= 'no-repeat';" & _
		 "    o.style.backgroundPosition = 'right';" & _
		 "    PageMethods.validate_FK_VR_VehicleRequest_ProjectID(value, validated_FK_VR_VehicleRequest_ProjectID);" & _
		 "  }" & _
		 "  validated_FK_VR_VehicleRequest_ProjectID_main = false;" & _
		 "  function validated_FK_VR_VehicleRequest_ProjectID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_VehicleRequest_ProjectID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_VehicleRequest_ProjectID", validateScriptFK_VR_VehicleRequest_ProjectID)
		End If
		Dim validateScriptFK_VR_VehicleRequest_SupplierID As String = "<script type=""text/javascript"">" & _
		 "  function validate_FK_VR_VehicleRequest_SupplierID(o) {" & _
		 "    var value = o.id;" & _
		 "    var SupplierID = $get('" & F_SupplierID.ClientID & "');" & _
		 "    try{" & _
		 "    if(SupplierID.value==''){" & _
		 "      if(validated_FK_VR_VehicleRequest_SupplierID.main){" & _
		 "        var o_d = $get(o.id +'_Display');" & _
		 "        try{o_d.innerHTML = '';}catch(ex){}" & _
		 "      }" & _
		 "    }" & _
		 "    value = value + ',' + SupplierID.value ;" & _
		 "    }catch(ex){}" & _
		 "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
		 "    o.style.backgroundRepeat= 'no-repeat';" & _
		 "    o.style.backgroundPosition = 'right';" & _
		 "    PageMethods.validate_FK_VR_VehicleRequest_SupplierID(value, validated_FK_VR_VehicleRequest_SupplierID);" & _
		 "  }" & _
		 "  validated_FK_VR_VehicleRequest_SupplierID_main = false;" & _
		 "  function validated_FK_VR_VehicleRequest_SupplierID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_VehicleRequest_SupplierID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_VehicleRequest_SupplierID", validateScriptFK_VR_VehicleRequest_SupplierID)
		End If
	End Sub
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_VR_VehicleRequest_ProjectID(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim ProjectID As String = CType(aVal(1), String)
		Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_VR_VehicleRequest_SupplierID(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim SupplierID As String = CType(aVal(1), String)
		Dim oVar As SIS.QCM.qcmVendors = SIS.QCM.qcmVendors.qcmVendorsGetByID(SupplierID)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_Request(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = ""
		Dim mErr As Boolean = False
		Dim RequestNo As String = CType(aVal(0), String)
		Dim oRq As SIS.VR.vrVehicleRequest = SIS.VR.vrVehicleRequest.vrVehicleRequestGetByID(RequestNo)
		If oRq.ProjectType.ToUpper = "DOMESTIC" Then
			If Not oRq.MICN Or Not oRq.DIIssued Or Not oRq.WayBill Then
				mErr = True
				mRet = "In DOMESTIC Projects MICN, DI must be Issued and Way Bill mus be received. Can not forward request."
			End If
		Else
			If Not oRq.MICN Or Not oRq.CustomInvoiceIssued Or Not oRq.CT1Issued Or Not oRq.ARE1Issued Or Not oRq.DIIssued Then
				mErr = True
				mRet = "In EXPORT Projects MICN, Custom Invoice, CT-1, ARE-1  and DI must be issued. Can not forward request."
			End If
		End If
		If mErr Then
			mRet = "1|" & aVal(0) & "|" & mRet
		Else
			mRet = "0|" & aVal(0) & "|" & mRet
		End If
		Return mRet
	End Function
End Class
