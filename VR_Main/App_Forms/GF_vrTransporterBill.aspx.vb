Partial Class GF_vrTransporterBill
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrTransporterBill.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?IRNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrTransporterBill_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrTransporterBill.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim IRNo As Int32 = GVvrTransporterBill.DataKeys(e.CommandArgument).Values("IRNo")  
				Dim RedirectUrl As String = TBLvrTransporterBill.EditUrl & "?IRNo=" & IRNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "initiatewf".ToLower Then
			Try
				Dim IRNo As Int32 = GVvrTransporterBill.DataKeys(e.CommandArgument).Values("IRNo")  
				SIS.VR.vrTransporterBill.InitiateWF(IRNo)
				GVvrTransporterBill.DataBind()
			Catch ex As Exception
			End Try
		End If
		If e.CommandName.ToLower = "completewf".ToLower Then
			Try
				Dim IRNo As Int32 = GVvrTransporterBill.DataKeys(e.CommandArgument).Values("IRNo")
				SIS.VR.vrTransporterBill.CompleteWF(IRNo)
				GVvrTransporterBill.DataBind()
			Catch ex As Exception
			End Try
		End If
	End Sub
  Protected Sub GVvrTransporterBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrTransporterBill.Init
    DataClassName = "GvrTransporterBill"
    SetGridView = GVvrTransporterBill
  End Sub
  Protected Sub TBLvrTransporterBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrTransporterBill.Init
    SetToolBar = TBLvrTransporterBill
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
  Protected Sub F_BillReceiverDivisionID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BillReceiverDivisionID.TextChanged
    Session("F_BillReceiverDivisionID") = F_BillReceiverDivisionID.Text
    Session("F_BillReceiverDivisionID_Display") = F_BillReceiverDivisionID_Display.Text
    InitGridPage()
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function BillReceiverDivisionIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmDivisions.SelectqcmDivisionsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_BillStatusID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BillStatusID.SelectedIndexChanged
    Session("F_BillStatusID") = F_BillStatusID.SelectedValue
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
    F_BillReceiverDivisionID_Display.Text = String.Empty
    If Not Session("F_BillReceiverDivisionID_Display") Is Nothing Then
      If Session("F_BillReceiverDivisionID_Display") <> String.Empty Then
        F_BillReceiverDivisionID_Display.Text = Session("F_BillReceiverDivisionID_Display")
      End If
    End If
    F_BillReceiverDivisionID.Text = String.Empty
    If Not Session("F_BillReceiverDivisionID") Is Nothing Then
      If Session("F_BillReceiverDivisionID") <> String.Empty Then
        F_BillReceiverDivisionID.Text = Session("F_BillReceiverDivisionID")
      End If
    End If
		Dim strScriptBillReceiverDivisionID As String = "<script type=""text/javascript""> " & _
			"function ACEBillReceiverDivisionID_Selected(sender, e) {" & _
			"  var F_BillReceiverDivisionID = $get('" & F_BillReceiverDivisionID.ClientID & "');" & _
			"  var F_BillReceiverDivisionID_Display = $get('" & F_BillReceiverDivisionID_Display.ClientID & "');" & _
			"  var retval = e.get_value();" & _
			"  var p = retval.split('|');" & _
			"  F_BillReceiverDivisionID.value = p[0];" & _
			"  F_BillReceiverDivisionID_Display.innerHTML = e.get_text();" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BillReceiverDivisionID") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BillReceiverDivisionID", strScriptBillReceiverDivisionID)
			End If
		Dim strScriptPopulatingBillReceiverDivisionID As String = "<script type=""text/javascript""> " & _
			"function ACEBillReceiverDivisionID_Populating(o,e) {" & _
			"  var p = $get('" & F_BillReceiverDivisionID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
			"  p.style.backgroundRepeat= 'no-repeat';" & _
			"  p.style.backgroundPosition = 'right';" & _
			"  o._contextKey = '';" & _
			"}" & _
			"function ACEBillReceiverDivisionID_Populated(o,e) {" & _
			"  var p = $get('" & F_BillReceiverDivisionID.ClientID & "');" & _
			"  p.style.backgroundImage  = 'none';" & _
			"}" & _
			"</script>"
			If Not Page.ClientScript.IsClientScriptBlockRegistered("F_BillReceiverDivisionIDPopulating") Then
				Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_BillReceiverDivisionIDPopulating", strScriptPopulatingBillReceiverDivisionID)
			End If
    F_BillStatusID.SelectedValue = String.Empty
    If Not Session("F_BillStatusID") Is Nothing Then
      If Session("F_BillStatusID") <> String.Empty Then
        F_BillStatusID.SelectedValue = Session("F_BillStatusID")
      End If
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
		Dim validateScriptBillReceiverDivisionID As String = "<script type=""text/javascript"">" & _
			"  function validate_BillReceiverDivisionID(o) {" & _
			"    validated_FK_VR_TransporterBill_BillReceiverDivisionID_main = true;" & _
			"    validate_FK_VR_TransporterBill_BillReceiverDivisionID(o);" & _
			"  }" & _
		  "</script>"
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateBillReceiverDivisionID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateBillReceiverDivisionID", validateScriptBillReceiverDivisionID)
		End If
		Dim validateScriptFK_VR_TransporterBill_BillReceiverDivisionID As String = "<script type=""text/javascript"">" & _
			"  function validate_FK_VR_TransporterBill_BillReceiverDivisionID(o) {" & _
			"    var value = o.id;" & _
			"    var BillReceiverDivisionID = $get('" & F_BillReceiverDivisionID.ClientID & "');" & _
			"    try{" & _
			"    if(BillReceiverDivisionID.value==''){" & _
			"      if(validated_FK_VR_TransporterBill_BillReceiverDivisionID.main){" & _
			"        var o_d = $get(o.id +'_Display');" & _
			"        try{o_d.innerHTML = '';}catch(ex){}" & _
			"      }" & _
			"    }" & _
			"    value = value + ',' + BillReceiverDivisionID.value ;" & _
			"    }catch(ex){}" & _
			"    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
			"    o.style.backgroundRepeat= 'no-repeat';" & _
			"    o.style.backgroundPosition = 'right';" & _
			"    PageMethods.validate_FK_VR_TransporterBill_BillReceiverDivisionID(value, validated_FK_VR_TransporterBill_BillReceiverDivisionID);" & _
			"  }" & _
			"  validated_FK_VR_TransporterBill_BillReceiverDivisionID_main = false;" & _
			"  function validated_FK_VR_TransporterBill_BillReceiverDivisionID(result) {" & _
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
		If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_TransporterBill_BillReceiverDivisionID") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_TransporterBill_BillReceiverDivisionID", validateScriptFK_VR_TransporterBill_BillReceiverDivisionID)
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
  Public Shared Function validate_FK_VR_TransporterBill_BillReceiverDivisionID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim BillReceiverDivisionID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmDivisions = SIS.QCM.qcmDivisions.qcmDivisionsGetByID(BillReceiverDivisionID)
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
