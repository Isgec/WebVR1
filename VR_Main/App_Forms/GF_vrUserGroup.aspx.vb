Partial Class GF_vrUserGroup
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrUserGroup.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrUserGroup_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrUserGroup.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SerialNo As Int32 = GVvrUserGroup.DataKeys(e.CommandArgument).Values("SerialNo")  
				Dim RedirectUrl As String = TBLvrUserGroup.EditUrl & "?SerialNo=" & SerialNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrUserGroup_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrUserGroup.Init
    DataClassName = "GvrUserGroup"
    SetGridView = GVvrUserGroup
  End Sub
  Protected Sub TBLvrUserGroup_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrUserGroup.Init
    SetToolBar = TBLvrUserGroup
  End Sub
  Protected Sub F_UserID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_UserID.TextChanged
    Session("F_UserID") = F_UserID.Text
    Session("F_UserID_Display") = F_UserID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_GroupID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_GroupID.SelectedIndexChanged
    Session("F_GroupID") = F_GroupID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub F_RoleID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RoleID.TextChanged
    Session("F_RoleID") = F_RoleID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_UserID_Display.Text = String.Empty
    If Not Session("F_UserID_Display") Is Nothing Then
      If Session("F_UserID_Display") <> String.Empty Then
        F_UserID_Display.Text = Session("F_UserID_Display")
      End If
    End If
    F_UserID.Text = String.Empty
    If Not Session("F_UserID") Is Nothing Then
      If Session("F_UserID") <> String.Empty Then
        F_UserID.Text = Session("F_UserID")
      End If
    End If
    Dim strScriptUserID As String = "<script type=""text/javascript""> " &
      "function ACEUserID_Selected(sender, e) {" &
      "  var F_UserID = $get('" & F_UserID.ClientID & "');" &
      "  var F_UserID_Display = $get('" & F_UserID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_UserID.value = retval;" &
      "  F_UserID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_UserID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_UserID", strScriptUserID)
			End If
		Dim strScriptPopulatingUserID As String = "<script type=""text/javascript""> " & _
			"function ACEUserID_Populating(o,e) {" & _
			"  var p = $get('" & F_UserID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEUserID_Populated(o,e) {" & _
			"  var p = $get('" & F_UserID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_UserIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_UserIDPopulating", strScriptPopulatingUserID)
			End If
    F_GroupID.SelectedValue = String.Empty
    If Not Session("F_GroupID") Is Nothing Then
      If Session("F_GroupID") <> String.Empty Then
        F_GroupID.SelectedValue = Session("F_GroupID")
      End If
    End If
		Dim validateScriptUserID As String = "<script type=""text/javascript"">" & _
			"  function validate_UserID(o) {" & _
			"    validated_FK_VR_UserGroup_UserID_main = true;" & _
			"    validate_FK_VR_UserGroup_UserID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateUserID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateUserID", validateScriptUserID)
		End If
		Dim validateScriptFK_VR_UserGroup_UserID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_VR_UserGroup_UserID(o) {" & _
			"    var value = o.id;" & _
			"    var UserID = $get('" & F_UserID.ClientID & "');" & _
			"    try{" & _
			"    if(UserID.value==''){" & _
			"      if(validated_FK_VR_UserGroup_UserID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + UserID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_VR_UserGroup_UserID(value, validated_FK_VR_UserGroup_UserID);" & _
			"  }" & _
			"  validated_FK_VR_UserGroup_UserID_main = false;" & _
			"  function validated_FK_VR_UserGroup_UserID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_UserGroup_UserID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_UserGroup_UserID", validateScriptFK_VR_UserGroup_UserID)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_UserGroup_UserID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim UserID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(UserID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
