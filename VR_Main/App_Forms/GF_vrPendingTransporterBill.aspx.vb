Partial Class GF_vrPendingTransporterBill
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrPendingTransporterBill.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?IRNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrPendingTransporterBill_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrPendingTransporterBill.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim IRNo As Int32 = GVvrPendingTransporterBill.DataKeys(e.CommandArgument).Values("IRNo")  
				Dim RedirectUrl As String = TBLvrPendingTransporterBill.EditUrl & "?IRNo=" & IRNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "approvewf".ToLower Then
			Try
				Dim IRNo As Int32 = GVvrPendingTransporterBill.DataKeys(e.CommandArgument).Values("IRNo")  
				SIS.VR.vrPendingTransporterBill.ApproveWF(IRNo)
				GVvrPendingTransporterBill.DataBind()
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "rejectwf".ToLower Then
			Try
				Dim BillReturnRemarks As String = CType(GVvrPendingTransporterBill.Rows(e.CommandArgument).FindControl("F_BillReturnRemarks"),TextBox).Text
				Dim IRNo As Int32 = GVvrPendingTransporterBill.DataKeys(e.CommandArgument).Values("IRNo")  
				SIS.VR.vrPendingTransporterBill.RejectWF(IRNo, BillReturnRemarks)
				GVvrPendingTransporterBill.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrPendingTransporterBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrPendingTransporterBill.Init
    DataClassName = "GvrPendingTransporterBill"
    SetGridView = GVvrPendingTransporterBill
  End Sub
  Protected Sub TBLvrPendingTransporterBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrPendingTransporterBill.Init
    SetToolBar = TBLvrPendingTransporterBill
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
  Protected Sub F_ForwardedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ForwardedBy.TextChanged
    Session("F_ForwardedBy") = F_ForwardedBy.Text
    Session("F_ForwardedBy_Display") = F_ForwardedBy_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ForwardedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
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
    F_ForwardedBy_Display.Text = String.Empty
    If Not Session("F_ForwardedBy_Display") Is Nothing Then
      If Session("F_ForwardedBy_Display") <> String.Empty Then
        F_ForwardedBy_Display.Text = Session("F_ForwardedBy_Display")
      End If
    End If
    F_ForwardedBy.Text = String.Empty
    If Not Session("F_ForwardedBy") Is Nothing Then
      If Session("F_ForwardedBy") <> String.Empty Then
        F_ForwardedBy.Text = Session("F_ForwardedBy")
      End If
    End If
		Dim strScriptForwardedBy As String = "<script type=""text/javascript""> " & _
			"function ACEForwardedBy_Selected(sender, e) {" & _
			"  var F_ForwardedBy = $get('" & F_ForwardedBy.ClientID & "');" & _
			"  var F_ForwardedBy_Display = $get('" & F_ForwardedBy_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_ForwardedBy_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ForwardedBy") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ForwardedBy", strScriptForwardedBy)
			End If
		Dim strScriptPopulatingForwardedBy As String = "<script type=""text/javascript""> " & _
			"function ACEForwardedBy_Populating(o,e) {" & _
			"  var p = $get('" & F_ForwardedBy.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEForwardedBy_Populated(o,e) {" & _
			"  var p = $get('" & F_ForwardedBy.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ForwardedByPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ForwardedByPopulating", strScriptPopulatingForwardedBy)
			End If
		Dim validateScriptTransporterID As String = "<script type=""text/javascript"">" & _
			"  function validate_TransporterID(o) {" & _
			"    validated_FK_VR_TransporterBill_TransporterID_main = true;" & _
			"    validate_FK_VR_TransporterBill_TransporterID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateTransporterID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateTransporterID", validateScriptTransporterID)
		End If
		Dim validateScriptForwardedBy As String = "<script type=""text/javascript"">" & _
			"  function validate_ForwardedBy(o) {" & _
			"    validated_FK_VR_TransporterBill_ForwardedBy_main = true;" & _
			"    validate_FK_VR_TransporterBill_ForwardedBy(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateForwardedBy") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateForwardedBy", validateScriptForwardedBy)
		End If
		Dim validateScriptFK_VR_TransporterBill_ForwardedBy As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_VR_TransporterBill_ForwardedBy(o) {" & _
			"    var value = o.id;" & _
			"    var ForwardedBy = $get('" & F_ForwardedBy.ClientID & "');" & _
			"    try{" & _
			"    if(ForwardedBy.value==''){" & _
			"      if(validated_FK_VR_TransporterBill_ForwardedBy.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + ForwardedBy.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_VR_TransporterBill_ForwardedBy(value, validated_FK_VR_TransporterBill_ForwardedBy);" & _
			"  }" & _
			"  validated_FK_VR_TransporterBill_ForwardedBy_main = false;" & _
			"  function validated_FK_VR_TransporterBill_ForwardedBy(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_TransporterBill_ForwardedBy") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_TransporterBill_ForwardedBy", validateScriptFK_VR_TransporterBill_ForwardedBy)
		End If
		Dim validateScriptFK_VR_TransporterBill_TransporterID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_VR_TransporterBill_TransporterID(o) {" & _
			"    var value = o.id;" & _
			"    var TransporterID = $get('" & F_TransporterID.ClientID & "');" & _
			"    try{" & _
			"    if(TransporterID.value==''){" & _
			"      if(validated_FK_VR_TransporterBill_TransporterID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + TransporterID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_VR_TransporterBill_TransporterID(value, validated_FK_VR_TransporterBill_TransporterID);" & _
			"  }" & _
			"  validated_FK_VR_TransporterBill_TransporterID_main = false;" & _
			"  function validated_FK_VR_TransporterBill_TransporterID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_TransporterBill_TransporterID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_TransporterBill_TransporterID", validateScriptFK_VR_TransporterBill_TransporterID)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_TransporterBill_ForwardedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ForwardedBy As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(ForwardedBy)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_TransporterBill_TransporterID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim TransporterID As String = CType(aVal(1),String)
		Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TransporterID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
