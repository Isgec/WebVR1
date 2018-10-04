Partial Class GF_vrLinkExecutions
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrLinkExecutions.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?LinkID=" & aVal(0) & "&SRNNo=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrLinkExecutions_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrLinkExecutions.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim LinkID As Int32 = GVvrLinkExecutions.DataKeys(e.CommandArgument).Values("LinkID")  
				Dim SRNNo As Int32 = GVvrLinkExecutions.DataKeys(e.CommandArgument).Values("SRNNo")  
				Dim RedirectUrl As String = TBLvrLinkExecutions.EditUrl & "?LinkID=" & LinkID & "&SRNNo=" & SRNNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrLinkExecutions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrLinkExecutions.Init
    DataClassName = "GvrLinkExecutions"
    SetGridView = GVvrLinkExecutions
  End Sub
  Protected Sub TBLvrLinkExecutions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLinkExecutions.Init
    SetToolBar = TBLvrLinkExecutions
  End Sub
  Protected Sub F_SRNNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SRNNo.TextChanged
    Session("F_SRNNo") = F_SRNNo.Text
    Session("F_SRNNo_Display") = F_SRNNo_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SRNNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrRequestExecution.SelectvrRequestExecutionAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_SRNNo_Display.Text = String.Empty
    If Not Session("F_SRNNo_Display") Is Nothing Then
      If Session("F_SRNNo_Display") <> String.Empty Then
        F_SRNNo_Display.Text = Session("F_SRNNo_Display")
      End If
    End If
    F_SRNNo.Text = String.Empty
    If Not Session("F_SRNNo") Is Nothing Then
      If Session("F_SRNNo") <> String.Empty Then
        F_SRNNo.Text = Session("F_SRNNo")
      End If
    End If
		Dim strScriptSRNNo As String = "<script type=""text/javascript""> " & _
			"function ACESRNNo_Selected(sender, e) {" & _
			"  var F_SRNNo = $get('" & F_SRNNo.ClientID & "');" & _
			"  var F_SRNNo_Display = $get('" & F_SRNNo_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_SRNNo.value = p[0];" & _
			"  F_SRNNo_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SRNNo") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SRNNo", strScriptSRNNo)
			End If
		Dim strScriptPopulatingSRNNo As String = "<script type=""text/javascript""> " & _
			"function ACESRNNo_Populating(o,e) {" & _
			"  var p = $get('" & F_SRNNo.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACESRNNo_Populated(o,e) {" & _
			"  var p = $get('" & F_SRNNo.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SRNNoPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SRNNoPopulating", strScriptPopulatingSRNNo)
			End If
		Dim validateScriptSRNNo As String = "<script type=""text/javascript"">" & _
			"  function validate_SRNNo(o) {" & _
			"    validated_FK_VR_LinkExecutions_SRNNo_main = true;" & _
			"    validate_FK_VR_LinkExecutions_SRNNo(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSRNNo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSRNNo", validateScriptSRNNo)
		End If
		Dim validateScriptFK_VR_LinkExecutions_SRNNo As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_VR_LinkExecutions_SRNNo(o) {" & _
			"    var value = o.id;" & _
			"    var SRNNo = $get('" & F_SRNNo.ClientID & "');" & _
			"    try{" & _
			"    if(SRNNo.value==''){" & _
			"      if(validated_FK_VR_LinkExecutions_SRNNo.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + SRNNo.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_VR_LinkExecutions_SRNNo(value, validated_FK_VR_LinkExecutions_SRNNo);" & _
			"  }" & _
			"  validated_FK_VR_LinkExecutions_SRNNo_main = false;" & _
			"  function validated_FK_VR_LinkExecutions_SRNNo(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_LinkExecutions_SRNNo") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_LinkExecutions_SRNNo", validateScriptFK_VR_LinkExecutions_SRNNo)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_LinkExecutions_SRNNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim SRNNo As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(SRNNo)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
