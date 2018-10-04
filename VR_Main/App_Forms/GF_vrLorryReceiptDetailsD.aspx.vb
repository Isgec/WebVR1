Partial Class GF_vrLorryReceiptDetailsD
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrLorryReceiptDetailsD.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectID=" & aVal(0) & "&MRNNo=" & aVal(1) & "&SerialNo=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrLorryReceiptDetailsD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrLorryReceiptDetailsD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVvrLorryReceiptDetailsD.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim MRNNo As Int32 = GVvrLorryReceiptDetailsD.DataKeys(e.CommandArgument).Values("MRNNo")  
        Dim SerialNo As Int32 = GVvrLorryReceiptDetailsD.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLvrLorryReceiptDetailsD.EditUrl & "?ProjectID=" & ProjectID & "&MRNNo=" & MRNNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVvrLorryReceiptDetailsD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrLorryReceiptDetailsD.Init
    DataClassName = "GvrLorryReceiptDetailsD"
    SetGridView = GVvrLorryReceiptDetailsD
  End Sub
  Protected Sub TBLvrLorryReceiptDetailsD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceiptDetailsD.Init
    SetToolBar = TBLvrLorryReceiptDetailsD
  End Sub
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
  Protected Sub F_MRNNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_MRNNo.TextChanged
    Session("F_MRNNo") = F_MRNNo.Text
    Session("F_MRNNo_Display") = F_MRNNo_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function MRNNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrLorryReceipts.SelectvrLorryReceiptsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
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
    F_MRNNo_Display.Text = String.Empty
    If Not Session("F_MRNNo_Display") Is Nothing Then
      If Session("F_MRNNo_Display") <> String.Empty Then
        F_MRNNo_Display.Text = Session("F_MRNNo_Display")
      End If
    End If
    F_MRNNo.Text = String.Empty
    If Not Session("F_MRNNo") Is Nothing Then
      If Session("F_MRNNo") <> String.Empty Then
        F_MRNNo.Text = Session("F_MRNNo")
      End If
    End If
    Dim strScriptMRNNo As String = "<script type=""text/javascript""> " & _
      "function ACEMRNNo_Selected(sender, e) {" & _
      "  var F_MRNNo = $get('" & F_MRNNo.ClientID & "');" & _
      "  var F_MRNNo_Display = $get('" & F_MRNNo_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_MRNNo.value = p[1];" & _
      "  F_MRNNo_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_MRNNo") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_MRNNo", strScriptMRNNo)
      End If
    Dim strScriptPopulatingMRNNo As String = "<script type=""text/javascript""> " & _
      "function ACEMRNNo_Populating(o,e) {" & _
      "  var p = $get('" & F_MRNNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEMRNNo_Populated(o,e) {" & _
      "  var p = $get('" & F_MRNNo.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_MRNNoPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_MRNNoPopulating", strScriptPopulatingMRNNo)
      End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_ProjectID(o) {" & _
      "    validated_FK_VR_LorryReceiptDetails_ProjectID_main = true;" & _
      "    validate_FK_VR_LorryReceiptDetails_ProjectID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptMRNNo As String = "<script type=""text/javascript"">" & _
      "  function validate_MRNNo(o) {" & _
      "    validated_FK_VR_LorryReceiptDetails_MRNNo_main = true;" & _
      "    validate_FK_VR_LorryReceiptDetails_MRNNo(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateMRNNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateMRNNo", validateScriptMRNNo)
    End If
    Dim validateScriptFK_VR_LorryReceiptDetails_ProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_VR_LorryReceiptDetails_ProjectID(o) {" & _
      "    var value = o.id;" & _
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
      "    try{" & _
      "    if(ProjectID.value==''){" & _
      "      if(validated_FK_VR_LorryReceiptDetails_ProjectID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ProjectID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_VR_LorryReceiptDetails_ProjectID(value, validated_FK_VR_LorryReceiptDetails_ProjectID);" & _
      "  }" & _
      "  validated_FK_VR_LorryReceiptDetails_ProjectID_main = false;" & _
      "  function validated_FK_VR_LorryReceiptDetails_ProjectID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_LorryReceiptDetails_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_LorryReceiptDetails_ProjectID", validateScriptFK_VR_LorryReceiptDetails_ProjectID)
    End If
    Dim validateScriptFK_VR_LorryReceiptDetails_MRNNo As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_VR_LorryReceiptDetails_MRNNo(o) {" & _
      "    var value = o.id;" & _
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
      "    try{" & _
      "    if(ProjectID.value==''){" & _
      "      if(validated_FK_VR_LorryReceiptDetails_MRNNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ProjectID.value ;" & _
      "    }catch(ex){}" & _
      "    var MRNNo = $get('" & F_MRNNo.ClientID & "');" & _
      "    try{" & _
      "    if(MRNNo.value==''){" & _
      "      if(validated_FK_VR_LorryReceiptDetails_MRNNo.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + MRNNo.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_VR_LorryReceiptDetails_MRNNo(value, validated_FK_VR_LorryReceiptDetails_MRNNo);" & _
      "  }" & _
      "  validated_FK_VR_LorryReceiptDetails_MRNNo_main = false;" & _
      "  function validated_FK_VR_LorryReceiptDetails_MRNNo(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_LorryReceiptDetails_MRNNo") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_LorryReceiptDetails_MRNNo", validateScriptFK_VR_LorryReceiptDetails_MRNNo)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_LorryReceiptDetails_ProjectID(ByVal value As String) As String
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
  Public Shared Function validate_FK_VR_LorryReceiptDetails_MRNNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim MRNNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.VR.vrLorryReceipts = SIS.VR.vrLorryReceipts.vrLorryReceiptsGetByID(ProjectID,MRNNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
