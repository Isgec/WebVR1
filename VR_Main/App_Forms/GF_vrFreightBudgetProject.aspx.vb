Imports System.Web.Script.Serialization
Partial Class GF_vrFreightBudgetProject
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrFreightBudgetProject.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ProjectID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrFreightBudgetProject_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrFreightBudgetProject.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVvrFreightBudgetProject.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim RedirectUrl As String = TBLvrFreightBudgetProject.EditUrl & "?ProjectID=" & ProjectID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim ProjectID As String = GVvrFreightBudgetProject.DataKeys(e.CommandArgument).Values("ProjectID")  
        SIS.VR.vrFreightBudgetProject.DeleteWF(ProjectID)
        GVvrFreightBudgetProject.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim ProjectID As String = GVvrFreightBudgetProject.DataKeys(e.CommandArgument).Values("ProjectID")  
        SIS.VR.vrFreightBudgetProject.InitiateWF(ProjectID)
        GVvrFreightBudgetProject.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVvrFreightBudgetProject_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrFreightBudgetProject.Init
    DataClassName = "GvrFreightBudgetProject"
    SetGridView = GVvrFreightBudgetProject
  End Sub
  Protected Sub TBLvrFreightBudgetProject_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrFreightBudgetProject.Init
    SetToolBar = TBLvrFreightBudgetProject
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
  Protected Sub F_FreightBudgetProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_FreightBudgetProjectID.TextChanged
    Session("F_FreightBudgetProjectID") = F_FreightBudgetProjectID.Text
    Session("F_FreightBudgetProjectID_Display") = F_FreightBudgetProjectID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FreightBudgetProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_CreatedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CreatedBy.TextChanged
    Session("F_CreatedBy") = F_CreatedBy.Text
    Session("F_CreatedBy_Display") = F_CreatedBy_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CreatedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
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
    F_FreightBudgetProjectID_Display.Text = String.Empty
    If Not Session("F_FreightBudgetProjectID_Display") Is Nothing Then
      If Session("F_FreightBudgetProjectID_Display") <> String.Empty Then
        F_FreightBudgetProjectID_Display.Text = Session("F_FreightBudgetProjectID_Display")
      End If
    End If
    F_FreightBudgetProjectID.Text = String.Empty
    If Not Session("F_FreightBudgetProjectID") Is Nothing Then
      If Session("F_FreightBudgetProjectID") <> String.Empty Then
        F_FreightBudgetProjectID.Text = Session("F_FreightBudgetProjectID")
      End If
    End If
    Dim strScriptFreightBudgetProjectID As String = "<script type=""text/javascript""> " & _
      "function ACEFreightBudgetProjectID_Selected(sender, e) {" & _
      "  var F_FreightBudgetProjectID = $get('" & F_FreightBudgetProjectID.ClientID & "');" & _
      "  var F_FreightBudgetProjectID_Display = $get('" & F_FreightBudgetProjectID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_FreightBudgetProjectID.value = p[0];" & _
      "  F_FreightBudgetProjectID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_FreightBudgetProjectID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_FreightBudgetProjectID", strScriptFreightBudgetProjectID)
      End If
    Dim strScriptPopulatingFreightBudgetProjectID As String = "<script type=""text/javascript""> " & _
      "function ACEFreightBudgetProjectID_Populating(o,e) {" & _
      "  var p = $get('" & F_FreightBudgetProjectID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEFreightBudgetProjectID_Populated(o,e) {" & _
      "  var p = $get('" & F_FreightBudgetProjectID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_FreightBudgetProjectIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_FreightBudgetProjectIDPopulating", strScriptPopulatingFreightBudgetProjectID)
      End If
    F_CreatedBy_Display.Text = String.Empty
    If Not Session("F_CreatedBy_Display") Is Nothing Then
      If Session("F_CreatedBy_Display") <> String.Empty Then
        F_CreatedBy_Display.Text = Session("F_CreatedBy_Display")
      End If
    End If
    F_CreatedBy.Text = String.Empty
    If Not Session("F_CreatedBy") Is Nothing Then
      If Session("F_CreatedBy") <> String.Empty Then
        F_CreatedBy.Text = Session("F_CreatedBy")
      End If
    End If
    Dim strScriptCreatedBy As String = "<script type=""text/javascript""> " & _
      "function ACECreatedBy_Selected(sender, e) {" & _
      "  var F_CreatedBy = $get('" & F_CreatedBy.ClientID & "');" & _
      "  var F_CreatedBy_Display = $get('" & F_CreatedBy_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_CreatedBy_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CreatedBy") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CreatedBy", strScriptCreatedBy)
      End If
    Dim strScriptPopulatingCreatedBy As String = "<script type=""text/javascript""> " & _
      "function ACECreatedBy_Populating(o,e) {" & _
      "  var p = $get('" & F_CreatedBy.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACECreatedBy_Populated(o,e) {" & _
      "  var p = $get('" & F_CreatedBy.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CreatedByPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CreatedByPopulating", strScriptPopulatingCreatedBy)
      End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_ProjectID(o) {" & _
      "    validated_FK_VR_FreightBudgetProject_ProjectID_main = true;" & _
      "    validate_FK_VR_FreightBudgetProject_ProjectID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptFreightBudgetProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_FreightBudgetProjectID(o) {" & _
      "    validated_FK_VR_FreightBudgetProject_FrBdProjectID_main = true;" & _
      "    validate_FK_VR_FreightBudgetProject_FrBdProjectID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFreightBudgetProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFreightBudgetProjectID", validateScriptFreightBudgetProjectID)
    End If
    Dim validateScriptCreatedBy As String = "<script type=""text/javascript"">" & _
      "  function validate_CreatedBy(o) {" & _
      "    validated_FK_VR_FreightBudgetProject_CreatedBy_main = true;" & _
      "    validate_FK_VR_FreightBudgetProject_CreatedBy(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCreatedBy", validateScriptCreatedBy)
    End If
    Dim validateScriptFK_VR_FreightBudgetProject_CreatedBy As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_VR_FreightBudgetProject_CreatedBy(o) {" & _
      "    var value = o.id;" & _
      "    var CreatedBy = $get('" & F_CreatedBy.ClientID & "');" & _
      "    try{" & _
      "    if(CreatedBy.value==''){" & _
      "      if(validated_FK_VR_FreightBudgetProject_CreatedBy.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + CreatedBy.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_VR_FreightBudgetProject_CreatedBy(value, validated_FK_VR_FreightBudgetProject_CreatedBy);" & _
      "  }" & _
      "  validated_FK_VR_FreightBudgetProject_CreatedBy_main = false;" & _
      "  function validated_FK_VR_FreightBudgetProject_CreatedBy(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_FreightBudgetProject_CreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_FreightBudgetProject_CreatedBy", validateScriptFK_VR_FreightBudgetProject_CreatedBy)
    End If
    Dim validateScriptFK_VR_FreightBudgetProject_ProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_VR_FreightBudgetProject_ProjectID(o) {" & _
      "    var value = o.id;" & _
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" & _
      "    try{" & _
      "    if(ProjectID.value==''){" & _
      "      if(validated_FK_VR_FreightBudgetProject_ProjectID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ProjectID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_VR_FreightBudgetProject_ProjectID(value, validated_FK_VR_FreightBudgetProject_ProjectID);" & _
      "  }" & _
      "  validated_FK_VR_FreightBudgetProject_ProjectID_main = false;" & _
      "  function validated_FK_VR_FreightBudgetProject_ProjectID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_FreightBudgetProject_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_FreightBudgetProject_ProjectID", validateScriptFK_VR_FreightBudgetProject_ProjectID)
    End If
    Dim validateScriptFK_VR_FreightBudgetProject_FrBdProjectID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_VR_FreightBudgetProject_FrBdProjectID(o) {" & _
      "    var value = o.id;" & _
      "    var FreightBudgetProjectID = $get('" & F_FreightBudgetProjectID.ClientID & "');" & _
      "    try{" & _
      "    if(FreightBudgetProjectID.value==''){" & _
      "      if(validated_FK_VR_FreightBudgetProject_FrBdProjectID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + FreightBudgetProjectID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_VR_FreightBudgetProject_FrBdProjectID(value, validated_FK_VR_FreightBudgetProject_FrBdProjectID);" & _
      "  }" & _
      "  validated_FK_VR_FreightBudgetProject_FrBdProjectID_main = false;" & _
      "  function validated_FK_VR_FreightBudgetProject_FrBdProjectID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_FreightBudgetProject_FrBdProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_FreightBudgetProject_FrBdProjectID", validateScriptFK_VR_FreightBudgetProject_FrBdProjectID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_FreightBudgetProject_CreatedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CreatedBy As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(CreatedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_FreightBudgetProject_ProjectID(ByVal value As String) As String
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
  Public Shared Function validate_FK_VR_FreightBudgetProject_FrBdProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim FreightBudgetProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(FreightBudgetProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
