Partial Class GF_vrReqReasonByExecuter
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrReqReasonByExecuter.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?RequestNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrReqReasonByExecuter_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrReqReasonByExecuter.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim RequestNo As Int32 = GVvrReqReasonByExecuter.DataKeys(e.CommandArgument).Values("RequestNo")  
				Dim RedirectUrl As String = TBLvrReqReasonByExecuter.EditUrl & "?RequestNo=" & RequestNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "initiatewf".ToLower Then
			Try
				Dim RequestNo As Int32 = GVvrReqReasonByExecuter.DataKeys(e.CommandArgument).Values("RequestNo")  
				SIS.VR.vrReqReasonByExecuter.InitiateWF(RequestNo)
				GVvrReqReasonByExecuter.DataBind()
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "approvewf".ToLower Then
			Try
				Dim RequestNo As Int32 = GVvrReqReasonByExecuter.DataKeys(e.CommandArgument).Values("RequestNo")  
				SIS.VR.vrReqReasonByExecuter.ApproveWF(RequestNo)
				GVvrReqReasonByExecuter.DataBind()
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "rejectwf".ToLower Then
			Try
				Dim RequestNo As Int32 = GVvrReqReasonByExecuter.DataKeys(e.CommandArgument).Values("RequestNo")  
				SIS.VR.vrReqReasonByExecuter.RejectWF(RequestNo)
				GVvrReqReasonByExecuter.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrReqReasonByExecuter_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrReqReasonByExecuter.Init
    DataClassName = "GvrReqReasonByExecuter"
    SetGridView = GVvrReqReasonByExecuter
  End Sub
  Protected Sub TBLvrReqReasonByExecuter_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrReqReasonByExecuter.Init
    SetToolBar = TBLvrReqReasonByExecuter
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
  Protected Sub F_VehicleTypeID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_VehicleTypeID.TextChanged
    Session("F_VehicleTypeID") = F_VehicleTypeID.Text
    Session("F_VehicleTypeID_Display") = F_VehicleTypeID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function VehicleTypeIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrVehicleTypes.SelectvrVehicleTypesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_RequestedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RequestedBy.TextChanged
    Session("F_RequestedBy") = F_RequestedBy.Text
    Session("F_RequestedBy_Display") = F_RequestedBy_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequestedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_RequestStatus_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RequestStatus.TextChanged
    Session("F_RequestStatus") = F_RequestStatus.Text
    Session("F_RequestStatus_Display") = F_RequestStatus_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequestStatusCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrRequestStates.SelectvrRequestStatesAutoCompleteList(prefixText, count, contextKey)
  End Function
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
    F_VehicleTypeID_Display.Text = String.Empty
    If Not Session("F_VehicleTypeID_Display") Is Nothing Then
      If Session("F_VehicleTypeID_Display") <> String.Empty Then
        F_VehicleTypeID_Display.Text = Session("F_VehicleTypeID_Display")
      End If
    End If
    F_VehicleTypeID.Text = String.Empty
    If Not Session("F_VehicleTypeID") Is Nothing Then
      If Session("F_VehicleTypeID") <> String.Empty Then
        F_VehicleTypeID.Text = Session("F_VehicleTypeID")
      End If
    End If
		Dim strScriptVehicleTypeID As String = "<script type=""text/javascript""> " & _
			"function ACEVehicleTypeID_Selected(sender, e) {" & _
			"  var F_VehicleTypeID = $get('" & F_VehicleTypeID.ClientID & "');" & _
			"  var F_VehicleTypeID_Display = $get('" & F_VehicleTypeID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_VehicleTypeID.value = p[0];" & _
			"  F_VehicleTypeID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_VehicleTypeID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_VehicleTypeID", strScriptVehicleTypeID)
			End If
		Dim strScriptPopulatingVehicleTypeID As String = "<script type=""text/javascript""> " & _
			"function ACEVehicleTypeID_Populating(o,e) {" & _
			"  var p = $get('" & F_VehicleTypeID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEVehicleTypeID_Populated(o,e) {" & _
			"  var p = $get('" & F_VehicleTypeID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_VehicleTypeIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_VehicleTypeIDPopulating", strScriptPopulatingVehicleTypeID)
			End If
    F_RequestedBy_Display.Text = String.Empty
    If Not Session("F_RequestedBy_Display") Is Nothing Then
      If Session("F_RequestedBy_Display") <> String.Empty Then
        F_RequestedBy_Display.Text = Session("F_RequestedBy_Display")
      End If
    End If
    F_RequestedBy.Text = String.Empty
    If Not Session("F_RequestedBy") Is Nothing Then
      If Session("F_RequestedBy") <> String.Empty Then
        F_RequestedBy.Text = Session("F_RequestedBy")
      End If
    End If
		Dim strScriptRequestedBy As String = "<script type=""text/javascript""> " & _
			"function ACERequestedBy_Selected(sender, e) {" & _
			"  var F_RequestedBy = $get('" & F_RequestedBy.ClientID & "');" & _
			"  var F_RequestedBy_Display = $get('" & F_RequestedBy_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_RequestedBy_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequestedBy") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequestedBy", strScriptRequestedBy)
			End If
		Dim strScriptPopulatingRequestedBy As String = "<script type=""text/javascript""> " & _
			"function ACERequestedBy_Populating(o,e) {" & _
			"  var p = $get('" & F_RequestedBy.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACERequestedBy_Populated(o,e) {" & _
			"  var p = $get('" & F_RequestedBy.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequestedByPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequestedByPopulating", strScriptPopulatingRequestedBy)
			End If
    F_RequestStatus_Display.Text = String.Empty
    If Not Session("F_RequestStatus_Display") Is Nothing Then
      If Session("F_RequestStatus_Display") <> String.Empty Then
        F_RequestStatus_Display.Text = Session("F_RequestStatus_Display")
      End If
    End If
    F_RequestStatus.Text = String.Empty
    If Not Session("F_RequestStatus") Is Nothing Then
      If Session("F_RequestStatus") <> String.Empty Then
        F_RequestStatus.Text = Session("F_RequestStatus")
      End If
    End If
		Dim strScriptRequestStatus As String = "<script type=""text/javascript""> " & _
			"function ACERequestStatus_Selected(sender, e) {" & _
			"  var F_RequestStatus = $get('" & F_RequestStatus.ClientID & "');" & _
			"  var F_RequestStatus_Display = $get('" & F_RequestStatus_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_RequestStatus.value = p[0];" & _
			"  F_RequestStatus_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequestStatus") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequestStatus", strScriptRequestStatus)
			End If
		Dim strScriptPopulatingRequestStatus As String = "<script type=""text/javascript""> " & _
			"function ACERequestStatus_Populating(o,e) {" & _
			"  var p = $get('" & F_RequestStatus.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACERequestStatus_Populated(o,e) {" & _
			"  var p = $get('" & F_RequestStatus.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequestStatusPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequestStatusPopulating", strScriptPopulatingRequestStatus)
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
		Dim validateScriptVehicleTypeID As String = "<script type=""text/javascript"">" & _
			"  function validate_VehicleTypeID(o) {" & _
			"    validated_FK_VR_VehicleRequest_VehicleTypeID_main = true;" & _
			"    validate_FK_VR_VehicleRequest_VehicleTypeID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateVehicleTypeID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateVehicleTypeID", validateScriptVehicleTypeID)
		End If
		Dim validateScriptRequestedBy As String = "<script type=""text/javascript"">" & _
			"  function validate_RequestedBy(o) {" & _
			"    validated_FK_VR_VehicleRequest_RequestedBy_main = true;" & _
			"    validate_FK_VR_VehicleRequest_RequestedBy(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateRequestedBy") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateRequestedBy", validateScriptRequestedBy)
		End If
		Dim validateScriptRequestStatus As String = "<script type=""text/javascript"">" & _
			"  function validate_RequestStatus(o) {" & _
			"    validated_FK_VR_VehicleRequest_RequestState_main = true;" & _
			"    validate_FK_VR_VehicleRequest_RequestState(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateRequestStatus") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateRequestStatus", validateScriptRequestStatus)
		End If
		Dim validateScriptFK_VR_VehicleRequest_RequestedBy As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_VR_VehicleRequest_RequestedBy(o) {" & _
			"    var value = o.id;" & _
			"    var RequestedBy = $get('" & F_RequestedBy.ClientID & "');" & _
			"    try{" & _
			"    if(RequestedBy.value==''){" & _
			"      if(validated_FK_VR_VehicleRequest_RequestedBy.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + RequestedBy.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_VR_VehicleRequest_RequestedBy(value, validated_FK_VR_VehicleRequest_RequestedBy);" & _
			"  }" & _
			"  validated_FK_VR_VehicleRequest_RequestedBy_main = false;" & _
			"  function validated_FK_VR_VehicleRequest_RequestedBy(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_VehicleRequest_RequestedBy") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_VehicleRequest_RequestedBy", validateScriptFK_VR_VehicleRequest_RequestedBy)
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
		Dim validateScriptFK_VR_VehicleRequest_RequestState As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_VR_VehicleRequest_RequestState(o) {" & _
			"    var value = o.id;" & _
			"    var RequestStatus = $get('" & F_RequestStatus.ClientID & "');" & _
			"    try{" & _
			"    if(RequestStatus.value==''){" & _
			"      if(validated_FK_VR_VehicleRequest_RequestState.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + RequestStatus.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_VR_VehicleRequest_RequestState(value, validated_FK_VR_VehicleRequest_RequestState);" & _
			"  }" & _
			"  validated_FK_VR_VehicleRequest_RequestState_main = false;" & _
			"  function validated_FK_VR_VehicleRequest_RequestState(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_VehicleRequest_RequestState") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_VehicleRequest_RequestState", validateScriptFK_VR_VehicleRequest_RequestState)
		End If
		Dim validateScriptFK_VR_VehicleRequest_VehicleTypeID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_VR_VehicleRequest_VehicleTypeID(o) {" & _
			"    var value = o.id;" & _
			"    var VehicleTypeID = $get('" & F_VehicleTypeID.ClientID & "');" & _
			"    try{" & _
			"    if(VehicleTypeID.value==''){" & _
			"      if(validated_FK_VR_VehicleRequest_VehicleTypeID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + VehicleTypeID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_VR_VehicleRequest_VehicleTypeID(value, validated_FK_VR_VehicleRequest_VehicleTypeID);" & _
			"  }" & _
			"  validated_FK_VR_VehicleRequest_VehicleTypeID_main = false;" & _
			"  function validated_FK_VR_VehicleRequest_VehicleTypeID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_VehicleRequest_VehicleTypeID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_VehicleRequest_VehicleTypeID", validateScriptFK_VR_VehicleRequest_VehicleTypeID)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_VehicleRequest_RequestedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim RequestedBy As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(RequestedBy)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_VehicleRequest_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ProjectID As String = CType(aVal(1),String)
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
    Dim mRet As String="0|" & aVal(0)
		Dim SupplierID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmVendors = SIS.QCM.qcmVendors.qcmVendorsGetByID(SupplierID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_VehicleRequest_RequestState(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim RequestStatus As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.VR.vrRequestStates = SIS.VR.vrRequestStates.vrRequestStatesGetByID(RequestStatus)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_VehicleRequest_VehicleTypeID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim VehicleTypeID As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.VR.vrVehicleTypes = SIS.VR.vrVehicleTypes.vrVehicleTypesGetByID(VehicleTypeID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
