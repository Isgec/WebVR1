Partial Class GF_DisplayRequestExecution
	Inherits SIS.SYS.GridBase
	Protected Sub GVvrRequestExecution_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrRequestExecution.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SRNNo As Int32 = GVvrRequestExecution.DataKeys(e.CommandArgument).Values("SRNNo")
				Dim RedirectUrl As String = TBLvrRequestExecution.EditUrl & "?SRNNo=" & SRNNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
	End Sub
	Protected Sub GVvrRequestExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrRequestExecution.Init
		DataClassName = "GvrRequestExecution"
		SetGridView = GVvrRequestExecution
	End Sub
	Protected Sub TBLvrRequestExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrRequestExecution.Init
		SetToolBar = TBLvrRequestExecution
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
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function SaveGR(ByVal context As String) As String
		Return SIS.VR.LC_vrGetGR.SaveGR(context)
	End Function
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function GetGRDetails(ByVal context As String) As String
		Dim aVal() As String = context.Split("|".ToCharArray)
		Dim SRNNo As String = aVal(0)
		Return SIS.VR.LC_vrGetGR.GetGRDetails(SRNNo)
	End Function
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function SaveTransShip(ByVal context As String) As String
		Return SIS.VR.LC_vrTransShip.SaveTransShip(context)
	End Function
	<System.Web.Services.WebMethod(EnableSession:=True)> _
	Public Shared Function GetTransShip(ByVal context As String) As String
		Dim aVal() As String = context.Split("|".ToCharArray)
		Dim SRNNo As String = aVal(0)
		Return SIS.VR.LC_vrTransShip.GetTransShip(SRNNo)
	End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function TransTransporterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.VR.vrTransporters.SelectvrTransportersAutoCompleteList(prefixText, count, contextKey)
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_VR_RequestExecution_TransTransporterID(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim TransTransporterID As String = CType(aVal(1), String)
		Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TransTransporterID)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function GetLink(ByVal value As String) As String
		Return SIS.VR.LC_LinkExecution.GetLink(value)
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function SelectLink(ByVal value As String) As String
		Return SIS.VR.LC_LinkExecution.SelectLink(value)
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function RemoveLink(ByVal value As String) As String
		Return SIS.VR.LC_LinkExecution.RemoveLink(value)
	End Function
End Class
