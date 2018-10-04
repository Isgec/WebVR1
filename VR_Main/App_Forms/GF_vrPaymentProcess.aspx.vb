Partial Class GF_vrPaymentProcess
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrPaymentProcess.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrPaymentProcess_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrPaymentProcess.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim SerialNo As Int32 = GVvrPaymentProcess.DataKeys(e.CommandArgument).Values("SerialNo")  
				Dim RedirectUrl As String = TBLvrPaymentProcess.EditUrl & "?SerialNo=" & SerialNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "completewf".ToLower Then
			Try
				Dim SerialNo As Int32 = GVvrPaymentProcess.DataKeys(e.CommandArgument).Values("SerialNo")  
				SIS.VR.vrPaymentProcess.CompleteWF(SerialNo)
				GVvrPaymentProcess.DataBind()
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrPaymentProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrPaymentProcess.Init
    DataClassName = "GvrPaymentProcess"
    SetGridView = GVvrPaymentProcess
  End Sub
  Protected Sub TBLvrPaymentProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrPaymentProcess.Init
    SetToolBar = TBLvrPaymentProcess
  End Sub
  Protected Sub F_ProcessedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProcessedBy.TextChanged
    Session("F_ProcessedBy") = F_ProcessedBy.Text
    Session("F_ProcessedBy_Display") = F_ProcessedBy_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProcessedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ProcessedBy_Display.Text = String.Empty
    If Not Session("F_ProcessedBy_Display") Is Nothing Then
      If Session("F_ProcessedBy_Display") <> String.Empty Then
        F_ProcessedBy_Display.Text = Session("F_ProcessedBy_Display")
      End If
    End If
    F_ProcessedBy.Text = String.Empty
    If Not Session("F_ProcessedBy") Is Nothing Then
      If Session("F_ProcessedBy") <> String.Empty Then
        F_ProcessedBy.Text = Session("F_ProcessedBy")
      End If
    End If
		Dim strScriptProcessedBy As String = "<script type=""text/javascript""> " & _
			"function ACEProcessedBy_Selected(sender, e) {" & _
			"  var F_ProcessedBy = $get('" & F_ProcessedBy.ClientID & "');" & _
			"  var F_ProcessedBy_Display = $get('" & F_ProcessedBy_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_ProcessedBy_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProcessedBy") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProcessedBy", strScriptProcessedBy)
			End If
		Dim strScriptPopulatingProcessedBy As String = "<script type=""text/javascript""> " & _
			"function ACEProcessedBy_Populating(o,e) {" & _
			"  var p = $get('" & F_ProcessedBy.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEProcessedBy_Populated(o,e) {" & _
			"  var p = $get('" & F_ProcessedBy.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProcessedByPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProcessedByPopulating", strScriptPopulatingProcessedBy)
			End If
		Dim validateScriptProcessedBy As String = "<script type=""text/javascript"">" & _
			"  function validate_ProcessedBy(o) {" & _
			"    validated_FK_VR_PaymentProcess_ProcessedBy_main = true;" & _
			"    validate_FK_VR_PaymentProcess_ProcessedBy(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProcessedBy") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProcessedBy", validateScriptProcessedBy)
		End If
		Dim validateScriptFK_VR_PaymentProcess_ProcessedBy As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_VR_PaymentProcess_ProcessedBy(o) {" & _
			"    var value = o.id;" & _
			"    var ProcessedBy = $get('" & F_ProcessedBy.ClientID & "');" & _
			"    try{" & _
			"    if(ProcessedBy.value==''){" & _
			"      if(validated_FK_VR_PaymentProcess_ProcessedBy.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + ProcessedBy.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_VR_PaymentProcess_ProcessedBy(value, validated_FK_VR_PaymentProcess_ProcessedBy);" & _
			"  }" & _
			"  validated_FK_VR_PaymentProcess_ProcessedBy_main = false;" & _
			"  function validated_FK_VR_PaymentProcess_ProcessedBy(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_PaymentProcess_ProcessedBy") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_PaymentProcess_ProcessedBy", validateScriptFK_VR_PaymentProcess_ProcessedBy)
		End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_PaymentProcess_ProcessedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ProcessedBy As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(ProcessedBy)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
